Imports Common
Imports dbOp
Imports System.IO
Imports System.Data
'Imports DotNet.Highcharts
'Imports DotNet.Highcharts.Options
'Imports DotNet.Highcharts.Options.Seriessend
'Imports DotNet.Highcharts.Attributes
'Imports DotNet.Highcharts.Helpers
'Imports DotNet.Highcharts.Enums
'Imports System.Data
'Imports System.Drawing

Partial Class _hrBiometric
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2, True)
            divNotification.InnerHtml = getNotification(1)
            divNotificationMobile.InnerHtml = getNotification(1, True)
            '   divLogin.InnerHtml = showAccount("9383", "Vinod Kumar Kotiya", "vinodkotiya@ntpc.co.in")

            divAttandance.Visible = False
            divUpload.Visible = False
            divHome.Visible = False
            divMyAttendance.Visible = False
            divAllAttendance.Visible = False
            divManageAttendance.Visible = False
            divCalendar.Visible = False
            ' Session("email") = "abhayakgupta@bifpcl.com"
            If Request.Form.Count = 1 Then
                Dim appsecret = "eAVMt6AUhNrTVIVK7w4ke/eXNxaIth2ALv8NZ6lTfsg="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            divLogin.InnerHtml = showAccount(Session("email"), True)
            divLoginMobile.InnerHtml = showAccount(Session("email"), True)
            If Not Request.QueryString("mode") Is Nothing Then
                If Session("email") Is Nothing And Not Request.QueryString("mode") = "calendar" Then Response.Redirect("sso/Default.aspx?appid=12343278")
            End If
            Dim currentDate = Now()
            Dim lastMonth = New Date(2018, 6, 1)
            Dim Profileq As String = "Select distinct name || '  ' || workarea as t, email as v from contacts_New where email is not null and email <> '' order by workarea desc, name asc"

            If Request.QueryString("mode") = "calendar" Then
                divCalendar.Visible = True
                Dim q = "select holiday, strftime('%d.%m.%Y',holidaydate) as 'Date' from holiday where strftime('%Y',holidaydate) = '" & Now.Year & "' and org = '" & rblHolidayOrg.SelectedValue & "' and loc like '" & rblHolidayLoc.SelectedValue & "' order by org, holidaydate "
                Dim myDT = getDBTable(q, "hrdb")
                If myDT.Rows.Count = 0 Then
                    divMsg.InnerHtml = "No data found " & q
                    Exit Sub
                End If
                gvCalendar.DataSource = myDT
                gvCalendar.DataBind()

            ElseIf Request.QueryString("mode") = "attendance" Then
                If Not checkAuthorization(Session("email"), "hrBiometric.aspx?mode=attendance") Then
                    divMsg.InnerHtml = "You don't have authorisation to view this module"
                    Exit Sub
                End If
                divAttandance.Visible = True
                txtDate.Text = Now.AddDays(-1).ToString("dd.MM.yyyy")
                showAttandance()
            ElseIf Request.QueryString("mode") = "biometric" Then
                If Not checkAuthorization(Session("email"), "hrBiometric.aspx?mode=biometric") Then
                    divMsg.InnerHtml = "You don't have authorisation to view this module"
                    Exit Sub
                End If
                divUpload.Visible = True

            ElseIf Request.QueryString("mode") = "myattendance" Then
                divMyAttendance.Visible = True
                executeDB("insert into login (eid, log, logintime) values (0, 'My Attendance Page Access by:" & Session("email") & " at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
                currentDate = Now().AddMonths(1)
                While currentDate >= lastMonth
                    '   items.Add(New ListItem(DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"), DateTime.Now.AddDays(i).ToString("yyyy-mm-dd")))
                    ddlMonth.Items.Add(New ListItem(currentDate.ToString("MM.yyyy"), currentDate.ToString("MM#yyyy")))
                    currentDate = currentDate.AddMonths(-1)
                End While
                '  ddlRepdate.DataSource = items
                ddlMonth.DataBind()
                showMyAttandance(Session("email"), ddlMonth.SelectedValue, "my", False)
            ElseIf Request.QueryString("mode") = "leaverequest" Then
                divRequest.Visible = True
                executeDB("insert into login (eid, log, logintime) values (0, 'Leave Request Page Access by:" & Session("email") & " at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
                Dim mydt = getDBTable("Select type,leave from leaves where 1 order by leave asc", "hrdb")
                ddlL1type.DataSource = mydt
                ddlL1type.DataBind()
                ddlL1type.Items.Add(New ListItem("-", "-"))
                ddlL1type.SelectedValue = "-"
                ddlL2type.DataSource = mydt
                ddlL2type.DataBind()
                ddlL2type.Items.Add(New ListItem("-", "-"))
                ddlL2type.SelectedValue = "-"
                ddlL3type.DataSource = mydt
                ddlL3type.DataBind()
                ddlL3type.Items.Add(New ListItem("-", "-"))
                ddlL3type.SelectedValue = "-"
                If Request.Params("id") Is Nothing Then
                    lbID.Text = Now.ToString("dMMyHHmmss")
                Else
                    ''load ID
                    lbMode.Text = "Modify"
                End If
                gvLeaveRequest.DataSource = getDBTable("select appid as 'Application no', apptype, strftime('%d.%m.%Y',dt_st_out) as 'Start Date', strftime('%d.%m.%Y',dt_st_in) as 'End Date' from leaverequest where status = 1", "hrdb")
                gvLeaveRequest.DataBind()
            ElseIf Request.Params("mode") = "print" Then
                pnlPrintApp.Visible = True
                'lbConfirmJobID.Text = Request.Params("id")
                'Dim filename = getDBsingle("select file from careers_jobs where jobid = " & lbConfirmJobID.Text, "appsdb")
                'cbConfirm.Items.Add(New ListItem("I have made demand draft as mentioned in <a href='upload/HR/Career/" & filename & "' target='_blank' > Job Detail </a>", "6"))
                ' Dim aIDEnc = Encrypt(Request.Params("aid"))
                Dim applicationID = Request.Params("aid") ' Session("aid") Decrypt(HttpUtility.UrlDecode(Request.Params("aid")))
                printApplication(applicationID)
            ElseIf Request.QueryString("mode") = "allattendance" Then
                If Not checkAuthorization(Session("email"), "hrBiometric.aspx?mode=allattendance") Then
                    divMsg.InnerHtml = "You don't have authorisation to view this module"
                    Exit Sub
                End If
                divAllAttendance.Visible = True
                currentDate = Now().AddMonths(1)
                While currentDate >= lastMonth
                    ddlMonthAll.Items.Add(New ListItem(currentDate.ToString("MM.yyyy"), currentDate.ToString("MM#yyyy")))
                    currentDate = currentDate.AddMonths(-1)
                End While
                ddlMonthAll.DataBind()
                ddlProfile.DataTextField = "t"
                ddlProfile.DataValueField = "v"
                ddlProfile.DataSource = getDBTable(Profileq, "hrdb")
                ddlProfile.DataBind()
                ddlProfile.Visible = True
                ddlProfile_SelectedIndexChanged(vbNull, EventArgs.Empty)
            ElseIf Request.QueryString("mode") = "manageattendance" Then
                If Not checkAuthorization(Session("email"), "hrBiometric.aspx?mode=allattendance") Then
                    divMsg.InnerHtml = "You don't have authorisation to view this module"
                    Exit Sub
                End If
                executeDB("insert into login (eid, log, logintime) values (0, 'Manage Attendance Page Access by:" & Session("email") & " at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")

                currentDate = Now().AddMonths(1)
                While currentDate >= lastMonth
                    ddlManageMonth.Items.Add(New ListItem(currentDate.ToString("MM.yyyy"), currentDate.ToString("MM#yyyy")))
                    currentDate = currentDate.AddMonths(-1)
                End While
                ddlManageMonth.DataBind()
                ddlManageMonth.SelectedIndex = 1
                divManageAttendance.Visible = True
                currentDate = Now()
                While currentDate <= Now.AddMonths(1)
                    ddlFutureDate.Items.Add(New ListItem(currentDate.ToString("dd.MM.yyyy"), currentDate.ToString("yyyy-MM-dd")))
                    currentDate = currentDate.AddDays(1)
                End While
                ddlFutureDate.DataBind()
                ddlManageProfile.Visible = True
                'ddlManageProfile_SelectedIndexChanged(vbNull, EventArgs.Empty)
                rblOrg_SelectedIndexChanged(vbNull, EventArgs.Empty)
                btnAssignCL.Text = "Assign CL/RH as on 01.01." & Now.Year & " (BIFPCL/NTPC)"
                btnAssignNTPCApr.Text = "Assign 15 EL/15 SAL/10 HPL as on 01.04." & Now.Year & " (NTPC)"
                btnAssignNTPCOct.Text = "Assign 15 EL/15 SAL/10 HPL as on 01.10." & Now.Year & " (NTPC)"
                Dim dtApr = New Date(Now.Year, 4, 1)
                Dim dtOct = New Date(Now.Year, 10, 1)
                If Now.Date > dtApr Then btnAssignNTPCApr.Enabled = True
                If Now.Date > dtOct Then btnAssignNTPCOct.Enabled = True
                pnlAccrual.Visible = True
                    '  SqlDataSource1.UpdateParameters("updateprogdate").DefaultValue = ddlRepdate.SelectedValue.ToString
                ElseIf Request.QueryString("mode") = "balance" Then
                        divBalance.Visible = True

                loadBalance(Session("email"), True)
            Else
                        divHome.Visible = True

                    End If
                End If
                executeDB("update hits set view = view+1 where page = 'hrBiometric'")
        executeDB("insert into login (eid, log, logintime) values (0, 'hrBiometric Page Access : at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub

    Sub loadBalance(ByVal email As String, ByVal myleave As Boolean)
        Dim q = ""
        Try
            q = "select ltype as 'Leave Type', quota as 'Quota', strftime('%d.%m.%Y',accrual_dt) as 'Date of accrual', remark as log from leavequota where strftime('%Y',accrual_dt) = '" & Now.Year & "'  and eid like '" & email & "' order by accrual_dt desc"
            Dim myLeaveAccrualDT = getDBTable(q, "hrdb")
            q = "select leavetype as 'Leave Type', strftime('%d.%m.%Y',leavedt)  as 'Date' from  contacts_new c left outer join leaveavailed b on c.bioid = b.uid  where strftime('%Y',leavedt) = '" & Now.Year & "'  and  email='" & email & "' and leavetype in ('CL','CLHF','CLHA', 'RH', 'EL','SAL','HPL','CHPL') order by leavedt desc"
            Dim myAvailedDT = getDBTable(q, "hrdb")
            'lbMessage.Text = q
            q = "select ltype as 'leavetype', sum(quota) as 'quota' from leavequota where strftime('%Y',accrual_dt) = '" & Now.Year & "'  and  eid='" & email & "' group by ltype "
            Dim myQuota = getDBTable(q, "hrdb")
            Dim myAvailed = getDBTable("select leavetype, count(leavetype) as 'availed' from contacts_new c left outer join leaveavailed b on c.bioid = b.uid where strftime('%Y',leavedt) = '" & Now.Year & "'  and  email='" & email & "' and leavetype in ('CL','CLHF','CLHA', 'RH', 'EL','SAL','HPL','CHPL') group by leavetype", "hrdb")
            Dim finalDT1 As New System.Data.DataTable()

            '''####### Creating Columns
            '''
            finalDT1.Columns.Add("Leave Type")
            finalDT1.Columns.Add("Quota")
            finalDT1.Columns.Add("Availed")
            finalDT1.Columns.Add("Balance")
            finalDT1.Columns.Add("Remark")
            For Each nwRow In myQuota.Rows

                Dim rowStr = ""
                Dim tmpRow = finalDT1.NewRow

                tmpRow("Leave Type") = nwRow("leavetype")
                tmpRow("Quota") = nwRow("quota")
                Dim mFactor = 1.0 '' it will be 1/2 for leavetype CLH or CHPL
                Dim filter = "leavetype = '" & nwRow("leavetype") & "'"
                If nwRow("leavetype") = "CL" Then filter = "leavetype = 'CL' or leavetype = 'CLHA' or leavetype = 'CLHF'"
                If nwRow("leavetype") = "HPL" Then filter = "leavetype = 'HPL' or leavetype = 'CHPL'"
                Dim dr = myAvailed.Select(filter)
                If dr.Length > 0 Then
                    tmpRow("Availed") = processTableCLHPL(dr)
                    tmpRow("Remark") = "including half/commuted"
                Else
                    tmpRow("Availed") = 0
                    tmpRow("Remark") = nwRow("leavetype") & " not availed" '& myAvailed.Rows.Count & filter
                End If
                tmpRow("Balance") = tmpRow("Quota") - tmpRow("Availed")
                finalDT1.Rows.Add(tmpRow)
            Next
            If myleave Then
                gvLeaveAccrual.DataSource = myLeaveAccrualDT
                gvLeaveAccrual.DataBind()
                gvAvailed.DataSource = myAvailedDT
                gvAvailed.DataBind()
                gvLeaveQuota.DataSource = finalDT1
                gvLeaveQuota.DataBind()
            Else
                gvLeaveAccrualManage.DataSource = myLeaveAccrualDT
                gvLeaveAccrualManage.DataBind()
                gvLeaveQuotaManage.DataSource = finalDT1
                gvLeaveQuotaManage.DataBind()
            End If
        Catch ex As Exception
            divMsg.InnerHtml = ex.Message & q
        End Try
    End Sub
    Function processTableCLHPL(ByVal mydr As DataRow()) As Double
        Dim total = 0.0
        For i = 0 To mydr.Count - 1
            If mydr(i)("leavetype") = "CL" Or mydr(i)("leavetype") = "HPL" Then
                total = total + mydr(i)("availed")
            ElseIf mydr(i)("leavetype") = "CLHA" Or mydr(i)("leavetype") = "CLHF" Then
                total = total + (mydr(i)("availed") * 0.5)
            ElseIf mydr(i)("leavetype") = "CHPL" Then
                total = total + (mydr(i)("availed") * 2)
            Else
                total = mydr(i)("availed")
            End If
        Next
        Return total
    End Function
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        'If Session("eid") Is Nothing Then
        '    Response.Redirect("admin.aspx")
        '    Exit Sub
        'End If

        If FileUpload1.HasFile Then

            If System.IO.Path.GetExtension(FileUpload1.FileName).Contains(".csv") Or System.IO.Path.GetExtension(FileUpload1.FileName).Contains(".CSV") Then
                Try
                    If FileUpload1.FileContent.Length <= 0 Then
                        divMsg.InnerHtml = "File is empty"
                        Exit Sub
                    Else
                        divMsg.InnerHtml = "File has bytes: " & FileUpload1.FileContent.Length
                        '  Exit Sub
                    End If
                    '
                    Dim mydt As DataTable = New DataTable()

                    Using sr As StreamReader = New StreamReader(FileUpload1.FileContent)
                        Dim headers As String() = sr.ReadLine().Split(","c)

                        For Each header As String In headers
                            mydt.Columns.Add(header)
                        Next

                        While Not sr.EndOfStream
                            Dim rows As String() = sr.ReadLine().Split(","c)
                            Dim dr As DataRow = mydt.NewRow()

                            For i As Integer = 0 To headers.Length - 1
                                dr(i) = rows(i)
                            Next

                            mydt.Rows.Add(dr)
                        End While
                    End Using
                    ' Declare DataTable

                    ViewState("mydt") = mydt



                    gvPreview.Visible = True
                    gvPreview.Caption = "This is preview. Check it & if everything is fine then Click on Submit to Save the Data"
                    gvPreview.DataSource = mydt.AsEnumerable().Take(200).CopyToDataTable() 'ViewState("mydt")
                    gvPreview.DataBind()
                    '  divMsg.InnerHtml = mydt.Columns(0).ToString
                    btnPreview.Visible = False
                    FileUpload1.Visible = False
                    btnFinalSubmit.Visible = True
                    btnCancelUpload.Visible = True
                    'pnlDataGrid.Visible = False
                Catch ex As Exception
                    divMsg.InnerHtml = "Error in xls to table conversion " & ex.Message
                End Try

            Else
                divMsg.InnerHtml = "Attach Excel File .xlsx & not older .xls"
            End If
        Else
            divMsg.InnerHtml = "Attach Excel File .xlsx & not older .xls"
        End If
    End Sub
    Private Sub btnFinalSubmit_Click(sender As Object, e As EventArgs) Handles btnFinalSubmit.Click
        Try
            Dim msg = ""
            Dim mydt As DataTable = ViewState("mydt")
            '' p_date, m_tcode, spf_code is primary key , skip if qty is zero
            Dim qMain = "replace into biometric (uid, name,dt,intime,outtime,absent) values "
            '   Dim dt = DateTime.ParseExact(txtDate.Text, "dd.M.yyyy", Nothing)
            Dim q = ""
            Dim i = 1
            Dim skiped = ""
            Dim updated = ""
            Dim qS As New List(Of String)()
            For Each r In mydt.Rows
                If i = 1 Then  '' skip first row column name, or qty is blank or zero
                    i = i + 1
                    skiped = skiped & "," & i
                    Continue For
                End If
                Dim absent = 0
                If r(5).ToString.Contains("True") Then absent = 1
                Dim dt = DateTime.ParseExact(r(2), "M/d/yyyy", Nothing)
                Dim ot = r(4).ToString
                '  If r(0).ToString = "1092" And Not String.IsNullOrEmpty(r(3).ToString) And Not String.IsNullOrEmpty(ot) Then ot = "19:" & Now.Second.ToString.PadLeft(2, "0")
                q = q & " (" & r(0) & ",'" & r(1).ToString.Replace("'", "") & "','" & dt.ToString("yyyy-MM-dd") & "','" & r(3).ToString & "','" & ot & "', " & absent & "), "

                i = i + 1
                If i Mod 100 = 0 Then
                    qS.Add(qMain & q & "(1,'1999-01-01','dummy','09:00','06:00',0);")
                    q = ""
                End If
                updated = updated & "," & i
            Next

            ''to tackle last comma insert dummy row with del = 1
            '  q = q & "(1,'1999-01-01','dummy','09:00','06:00',0);"
            qS.Add(qMain & q & "(1,'1999-01-01','dummy','09:00','06:00',0);")
            For Each qry In qS
                Dim ret = executeDB(qry, "hrdb")
                If ret.Contains("Error") Then
                    divMsg.InnerHtml = " Unable to upload data" & qry & ret & vbCrLf
                    Exit Sub
                End If
            Next


            msg = i & " records have been uploaded succesfully <br/>Blank Rows number skipped: " & skiped & " <br/> Rows updated: " & updated & " " '& q
            btnFinalSubmit.Visible = False
            btnCancelUpload.Visible = False
            gvPreview.Visible = False
            ' showForEdit(msg & "<br/>")
        Catch ex As Exception
            divMsg.InnerHtml = "Final submit " & ex.Message
        End Try
    End Sub
    Private Sub btnCancelUpload_Click(sender As Object, e As EventArgs) Handles btnCancelUpload.Click

        Response.Redirect("hrBiometric.aspx")
    End Sub

    Private Sub btnShowAttandance_Click(sender As Object, e As EventArgs) Handles btnShowAttandance.Click
        showAttandance()
    End Sub
    Sub showMyAttandance(ByVal email As String, ByVal myMonth As String, ByVal mode As String, ByVal Showabsent As Boolean)
        Dim q = ""
        Try
            Dim location = getDBsingle("select workarea from contacts_New where email = '" & email & "' limit 1", "hrdb")
            If location.Contains("Error") Then
                divMsg.InnerHtml = "HO/SO location not found for you"
                Exit Sub
            End If
            Dim parent = getDBsingle("select org from contacts_New where email = '" & email & "' limit 1", "hrdb")
            If parent.Contains("Error") Then
                divMsg.InnerHtml = "Parent organisation not found for you"
                Exit Sub
            End If
            Dim st_dt, end_dt As String
            Dim v() = myMonth.Split("#")
            Dim stDayno = 16 'for ntpc
            If parent = "NTPC" Then
                stDayno = 16
            ElseIf parent = "BPDB" Or parent = "BIFPCL" Then
                stDayno = 21
            Else
                gvAllAttendance.Visible = False
                divMsg.InnerHtml = "Parent organisation not found for you " & parent
                Exit Sub
            End If
            Dim stdate = New Date(v(1), v(0), stDayno)
            stdate = stdate.AddMonths(-1)
            Dim enddate = New Date(stdate.AddMonths(1).Year, stdate.AddMonths(1).Month, (stDayno - 1))
            end_dt = enddate.ToString("yyyy-MM-dd") 'stdate.Year & "-" & stdate.AddMonths(1).Month.ToString.PadLeft(2, "0") & "-" & (stDayno - 1).ToString
            st_dt = stdate.ToString("yyyy-MM-dd")

            '  q = "select  strftime('%d.%m.%Y',dt) as 'Date', intime as 'In', outtime as 'Out', '' as Duration, (CASE WHEN absent = 1 THEN 'Absent' ELSE 'Present' END) as Status, reg as 'Regularizing Indicator' from contacts_new c left outer join biometric b on c.bioid = b.uid where email='" & email & "' and (dt >= '" & st_dt & "' and  dt <= '" & end_dt & "')    order by dt asc"
            q = "select  strftime('%d.%m.%Y',dt) as 'Date', intime as 'In', outtime as 'Out', '' as Duration, (CASE WHEN absent = 1 THEN 'Absent' ELSE 'Present' END) as Status,  l.leavetype as 'Regularizing Indicator' from contacts_new c left outer join biometric b on c.bioid = b.uid left outer join leaveavailed l on b.uid = l.uid and b.dt = l.leavedt  where email='" & email & "' and (dt >= '" & st_dt & "' and  dt <= '" & end_dt & "')    order by dt asc"
            'divMsg.InnerHtml = q
            'Exit Sub
            Dim mydt = getDBTable(q, "hrdb")
            If mydt.Rows.Count = 0 Then
                lbMy.Text = "No Data found for " & st_dt & " to " & end_dt '& q
                gvMyattendance.Visible = False
                Exit Sub
            End If
            Dim finaldt = processAttendance(mydt, location, parent)
            If Showabsent Then finaldt.DefaultView.RowFilter = "Status like '%Absent%' or Status like '%Leave%' or Status like '%Holiday%'"
            If mode = "my" Then
                gvMyattendance.Visible = True

                gvMyattendance.DataSource = finaldt
                gvMyattendance.DataBind()
                lbMy.Text = "<b>Showing details for period " & stdate.ToString("dd.MM.yy") & " to " & enddate.ToString("dd.MM.yy") & "</b>" '& q
            ElseIf mode = "all" Then
                gvAllAttendance.Visible = True
                gvAllAttendance.DataSource = finaldt
                gvAllAttendance.DataBind()
                lbMyall.Text = "<b>Showing details for period " & st_dt & " to " & enddate.ToString("dd.MM.yy") & "</b> for " & email '& q
            End If
            divMyLeaveType.InnerHtml = getDBsingle("select group_concat(type || ' - ' || leave) from leaves where 1 order by type", "hrdb")
            gvLeavesAvailed.DataSource = getDBTable("select leavetype as 'Leave Type', strftime('%d.%m.%Y',leavedt)  as 'Date' from  contacts_new c left outer join leaveavailed b on c.bioid = b.uid  where  email='" & email & "' order by leavedt desc", "hrdb")
            gvLeavesAvailed.DataBind()
        Catch ex As Exception
            lbMyall.Text = ex.Message & q
        End Try
    End Sub
    Sub showAttandance()

        '  Dim absent = ""
        ' If cbAbsent.Checked Then absent = " and absent = 1 "
        Dim dt = DateTime.ParseExact(txtDate.Text, "dd.M.yyyy", Nothing)

        Dim q = "select   c.name  || ', ' || c.desig as 'Name', intime as 'In', outtime as 'Out', '' as Duration, (CASE WHEN absent = 1 THEN 'Absent' ELSE 'Present' END) as Status, leavetype as 'Regularizing Indicator', '" & txtDate.Text & "' as 'Date', org, workarea from  biometric b , contacts_new c on c.bioid = b.uid left outer join leaveavailed l on b.uid = l.uid and b.dt = l.leavedt where c.del = 0 and not dept='Support' and b.dt = '" & dt.ToString("yyyy-MM-dd") & "' and workarea like '%" & rblType.SelectedValue & "%' order by workarea, printorder"
        Try
            Dim mydt = getDBTable(q, "hrdb")
            If mydt.Rows.Count = 0 Then
                lbDetail.Text = "<span style='background-color: lightblue; color: white;'>Showing details for " & txtDate.Text & " " & WeekdayName(dt.DayOfWeek, False, Microsoft.VisualBasic.FirstDayOfWeek.Monday) & " Day of week " & dt.DayOfWeek & " </span>" '& q
                gvAttendance.Visible = False
                Exit Sub
            End If

            Dim finaldt = processAttendance(mydt, rblType.SelectedValue, "%")
            If cbAbsent.Checked Then finaldt.DefaultView.RowFilter = "Status like '%Absent%' or Status like '%Leave%' or Status like '%Holiday%'"
            gvAttendance.Visible = True
            gvAttendance.DataSource = finaldt
            gvAttendance.DataBind()
            divLeaveType.InnerHtml = getDBsingle("select group_concat(type || ' - ' || leave) from leaves where 1 order by type", "hrdb")

            lbDetail.Text = "<span style='background-color: lightblue; color: white;'>Showing details for " & txtDate.Text & " " & WeekdayName(dt.DayOfWeek, False, Microsoft.VisualBasic.FirstDayOfWeek.Monday) & " Day of week " & dt.DayOfWeek & " </span>" '& q
        Catch ex As Exception
            lbDetail.Text = ex.Message & dt.DayOfWeek '& q
        End Try
    End Sub
    Function processAttendance(ByVal mydt As DataTable, ByVal location As String, ByVal org As String) As DataTable
        For Each r In mydt.Rows
            Try
                If mydt.Columns.Contains("workarea") Then location = r("workarea").ToString '' for daily attendence
                If mydt.Columns.Contains("org") Then org = r("org").ToString '' for daily attendence

                Dim outStr = Left(r("Out").ToString, 5)
                Dim inStr = Left(r("In").ToString, 5)
                Dim dt = DateTime.ParseExact(r("Date"), "dd.M.yyyy", Nothing)
                If dt.DayOfWeek = 5 Then
                    r("Status") = "-"
                    r("Regularizing Indicator") = "Weekly Off"
                    Continue For
                End If
                If (dt.DayOfWeek = 6 And location = "HO") Then
                    r("Status") = "-"
                    r("Regularizing Indicator") = "Weekly Off"
                    Continue For
                End If
                '''' SHOW GH
                '''

                Dim holiday = checkHoliday(dt, org, location)
                If Not holiday.Contains("Error") Then
                    r("Status") = "<span style='background-color: blue; color: white;'>Holiday</span>"
                    r("Regularizing Indicator") = holiday
                    Continue For
                End If
                '''' Show My Leaves
                '''' 
                If Not String.IsNullOrEmpty(r("Regularizing Indicator").ToString) Then
                    r("Status") = "<span style='background-color: blue; color: white;'>Leave</span>"
                    r("Regularizing Indicator") = r("Regularizing Indicator")
                    Continue For
                End If
                If String.IsNullOrEmpty(outStr) And String.IsNullOrEmpty(inStr) Then
                    r("Duration") = "-"
                    r("Status") = "<span style='background-color: red; color: black;'>Absent</span>"
                    r("Regularizing Indicator") = "Apply OD/Leave"
                    r("In") = "<span style='background-color: red; color: white;'>" & r("In") & "</span>"
                    r("Out") = "<span style='background-color: red; color: white;'>" & r("Out") & "</span>"
                    Continue For
                End If
                ''''THIS STATEMENT TO BE DISABLED
                If (String.IsNullOrEmpty(outStr) And Not String.IsNullOrEmpty(inStr)) Or (Not String.IsNullOrEmpty(outStr) And String.IsNullOrEmpty(inStr)) Then
                    r("Duration") = "-"
                    r("Status") = "<span style='background-color: green; color: white;'>Present</span>"
                    r("Regularizing Indicator") = " "
                    r("In") = "<span style='background-color: red; color: white;'>" & r("In") & "</span>"
                    r("Out") = "<span style='background-color: red; color: white;'>" & r("Out") & "</span>"
                    Continue For
                End If

                Dim outtime = TimeSpan.Parse(outStr.PadLeft(5, "0"))
                Dim intime = TimeSpan.Parse(inStr.PadLeft(5, "0"))
                Dim in1 = TimeSpan.Parse("09:15")
                Dim in2 = TimeSpan.Parse("09:30")
                Dim out1 = TimeSpan.Parse("16:00")
                Dim zero = TimeSpan.Parse("00:00")

                r("Duration") = (outtime - intime).ToString("hh\:mm")
                If outtime = zero Or intime = zero Then r("Duration") = "-"
                ' r("Duration") = outtime.Subtract(intime).TotalMinutes
                If intime < in1 Then
                    r("In") = "<span style='background-color: green; color: white;'>" & r("In") & "</span>"
                ElseIf intime < in2 Then
                    r("In") = "<span style='background-color: yellow; color: black;'>" & r("In") & "</span>"
                ElseIf intime > in2 Then
                    r("In") = "<span style='background-color: red; color: white;'>" & r("In") & "</span>"
                    ' r("Status") = "<span style='background-color: yellow; color: black;'>Regularise</span>"
                    ' r("Regularizing Indicator") = "Apply OD/Leave"
                    r("Status") = "<span style='background-color: green; color: white;'>Present</span>"

                End If
                If outtime < out1 Then
                    r("Out") = "<span style='background-color: red; color: white;'>" & r("Out") & "</span>"
                    '  r("Status") = "<span style='background-color: yellow; color: black;'>Regularise</span>"
                    'r("Regularizing Indicator") = "Apply OD/Leave"
                    r("Status") = "<span style='background-color: green; color: white;'>Present</span>"

                ElseIf outtime > out1 Then
                    r("Out") = "<span style='background-color: green; color: white;'>" & r("Out") & "</span>"
                End If
                If intime < in2 And outtime > out1 Then
                    r("Status") = "<span style='background-color: green; color: white;'>Present</span>"
                End If
            Catch ex As Exception
                r("Status") = "<span style='background-color: purple; color: white;'>" & ex.Message & "</span>"
                r("Regularizing Indicator") = "Error in Biometric data"
                Continue For
            End Try
        Next

        Return mydt
    End Function
    Function checkHoliday(ByVal dt As Date, ByVal org As String, ByVal location As String) As String
        If org = "BIFPCL" Then
            org = "BPDB"  ''for BIFPCL staff holiday shall be same as BPDB and location shall be %
            '     location = "%"
        End If
        If dt.Year < 2019 And org = "NTPC" Then location = "%" '' pre 2019 same holiday calander
        'Dim q = "select holiday from holiday where holidaydate = '" & dt.ToString("yyyy-MM-dd") & "' and org like '" & org & "' "
        If Cache("mydtH") Is Nothing Then
            Dim q = "select holiday,holidaydate, org, loc from holiday where 1"
            Dim mydt = getDBTable(q, "hrdb")
            Cache.Insert("mydtH", mydt, Nothing, DateTime.Now.AddHours(24.0), TimeSpan.Zero)
        End If
        Dim finaldt = Cache("mydtH")
        Dim hrow() As DataRow = finaldt.Select("holidaydate = '" & dt.ToString("yyyy-MM-dd") & "' AND  org like '" & org & "' AND loc like '" & location & "'")
        If hrow.Count > 0 Then
            Return hrow(0).Item("holiday")
        Else
            Return "Error"
        End If

    End Function
    Private Sub rblType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblType.SelectedIndexChanged
        showAttandance()
    End Sub

    Private Sub cbAbsent_CheckedChanged(sender As Object, e As EventArgs) Handles cbAbsent.CheckedChanged
        showAttandance()
    End Sub


    Private Sub gvAttendance_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvAttendance.RowDataBound
        Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(4).Text)
        e.Row.Cells(4).Text = decodedText
        Dim decodedText2 = HttpUtility.HtmlDecode(e.Row.Cells(1).Text)
        e.Row.Cells(1).Text = decodedText2
        Dim decodedText3 = HttpUtility.HtmlDecode(e.Row.Cells(2).Text)
        e.Row.Cells(2).Text = decodedText3
    End Sub
    Private Sub gvMyattendance_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvMyattendance.RowDataBound
        Try
            Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(4).Text)
            e.Row.Cells(4).Text = decodedText
            Dim decodedText2 = HttpUtility.HtmlDecode(e.Row.Cells(1).Text)
            e.Row.Cells(1).Text = decodedText2
            Dim decodedText3 = HttpUtility.HtmlDecode(e.Row.Cells(2).Text)
            e.Row.Cells(2).Text = decodedText3
        Catch ex As Exception
            divMsg.InnerHtml = ex.Message
        End Try
    End Sub
    Private Sub gvAllAttendance_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvAllAttendance.RowDataBound
        Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(4).Text)
        e.Row.Cells(4).Text = decodedText
        Dim decodedText2 = HttpUtility.HtmlDecode(e.Row.Cells(1).Text)
        e.Row.Cells(1).Text = decodedText2
        Dim decodedText3 = HttpUtility.HtmlDecode(e.Row.Cells(2).Text)
        e.Row.Cells(2).Text = decodedText3
    End Sub


    Private Sub ddlMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMonth.SelectedIndexChanged
        showMyAttandance(Session("email"), ddlMonth.SelectedValue, "my", cbMyabsent.Checked)
    End Sub

    Private Sub ddlProfile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProfile.SelectedIndexChanged
        Dim thefile = getDBsingle("select uid from contacts_New where email = '" & ddlProfile.SelectedValue & "' limit 1", "hrdb")
        thefile = thefile & ".jpg"
        divPic.InnerHtml = "<img src=" & "/upload/employee/pics/" & thefile & "?" & Now.Second & "  onerror=" & Chr(34) & "this.src='upload/employee/pics/user.png';" & Chr(34) & " />"
        divMsg.InnerHtml = "Loading " & ddlProfile.SelectedValue
        showMyAttandance(ddlProfile.SelectedValue, ddlMonthAll.SelectedValue, "all", cbAllAbsent.Checked)

    End Sub
    Private Sub ddlManageProfile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlManageProfile.SelectedIndexChanged
        Dim thefile = getDBsingle("select uid from contacts_New where email = '" & ddlManageProfile.SelectedValue & "' limit 1", "hrdb")
        thefile = thefile & ".jpg"
        divPic2.InnerHtml = "<img src=" & "/upload/employee/pics/" & thefile & "?" & Now.Second & "  onerror=" & Chr(34) & "this.src='upload/employee/pics/user.png';" & Chr(34) & " />"
        divMsg.InnerHtml = "Loading " & ddlManageProfile.SelectedValue
        Dim st_dt, end_dt As String
        Dim v() = ddlManageMonth.SelectedValue.Split("#")
        Dim parent = getDBsingle("select org from contacts_New where email = '" & ddlManageProfile.SelectedValue & "' limit 1", "hrdb")
        lbLocation.Text = getDBsingle("select workarea from contacts_New where email = '" & ddlManageProfile.SelectedValue & "' limit 1", "hrdb")
        If parent.Contains("Error") Then
            divMsg.InnerHtml = "Parent organisation not found for you"
            Exit Sub
        End If
        If Parent = "NTPC" Then
            Dim stdate = New Date(v(1), v(0), 16)
            stdate = stdate.AddMonths(-1)
            end_dt = stdate.AddMonths(1).Year & "-" & stdate.AddMonths(1).Month.ToString.PadLeft(2, "0") & "-30"
            st_dt = stdate.ToString("yyyy-MM-dd")
        ElseIf Parent = "BPDB" Or Parent = "BIFPCL" Then
            Dim stdate = New Date(v(1), v(0), 21)
            stdate = stdate.AddMonths(-1)
            end_dt = stdate.AddMonths(1).Year & "-" & stdate.AddMonths(1).Month.ToString.PadLeft(2, "0") & "-30"
            st_dt = stdate.ToString("yyyy-MM-dd")
        End If
        SqlDataSource1.SelectParameters("email").DefaultValue = ddlManageProfile.SelectedValue
        SqlDataSource1.SelectParameters("st_dt").DefaultValue = st_dt
        SqlDataSource1.SelectParameters("end_dt").DefaultValue = end_dt
        loadBalance(ddlManageProfile.SelectedValue, False)
    End Sub
    Public Function showHoliday(ByVal mydate As String) As String
        Try
            Dim dt = DateTime.ParseExact(mydate, "dd.M.yyyy", Nothing)
            Dim wday = ""
            Dim holiday = checkHoliday(dt, rblOrg.SelectedValue, lbLocation.Text)
            If Not holiday.Contains("Error") Then
                wday = "<span style='background-color: blue; color: white;'>" & mydate & " GH " & holiday & "</span>"
            ElseIf dt.DayOfWeek = 5 Or dt.DayOfWeek = 6 Then
                wday = "<span style='background-color: lightblue; color: black;'>" & mydate & " " & dt.ToString("ddd") & "</span>"
            Else
                wday = mydate & " " & dt.ToString("ddd")
            End If
            Return wday
        Catch ex As Exception
            Return mydate
        End Try
    End Function

    Private Sub ddlMonthAll_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMonthAll.SelectedIndexChanged
        showMyAttandance(ddlProfile.SelectedValue, ddlMonthAll.SelectedValue, "all", cbAllAbsent.Checked)

    End Sub
    Private Sub cbMyabsent_CheckedChanged(sender As Object, e As EventArgs) Handles cbMyabsent.CheckedChanged
        showMyAttandance(Session("email"), ddlMonth.SelectedValue, "my", cbMyabsent.Checked)
        '  lbMy.Text = cbMyabsent.Checked
    End Sub

    Private Sub cbAllAbsent_CheckedChanged(sender As Object, e As EventArgs) Handles cbAllAbsent.CheckedChanged
        showMyAttandance(ddlProfile.SelectedValue, ddlMonthAll.SelectedValue, "all", cbAllAbsent.Checked)
    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("ondblclick") = Page.ClientScript.GetPostBackClientHyperlink(gvDPRDetail, "Edit$" & e.Row.RowIndex)
            e.Row.Attributes("style") = "cursor:pointer"
        End If
    End Sub

    Private Sub ddlManageMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlManageMonth.SelectedIndexChanged
        ddlManageProfile_SelectedIndexChanged(vbNull, EventArgs.Empty)
    End Sub

    Private Sub gvDPRDetail_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDPRDetail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            If (e.Row.RowState And DataControlRowState.Edit) > 0 Then
                Dim ddList As DropDownList = CType(e.Row.FindControl("ddlRegularise"), DropDownList)
                ddList.DataSource = getDBTable("Select type,leave from leaves where 1 order by leave asc", "hrdb")
                ddList.DataTextField = "leave"
                ddList.DataValueField = "type"
                ddList.DataBind()
                ddList.Items.Add(New ListItem("-", "-"))
                Dim dr As DataRowView = TryCast(e.Row.DataItem, DataRowView)
                ddList.SelectedValue = dr("leavetype").ToString()
            End If
        End If
    End Sub

    Private Sub gvDPRDetail_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles gvDPRDetail.RowEditing
        ' gvDPRDetail.EditIndex = e.NewEditIndex
    End Sub

    Private Sub gvDPRDetail_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles gvDPRDetail.RowUpdating
        Dim ddList As DropDownList = CType(gvDPRDetail.Rows(e.RowIndex).FindControl("ddlRegularise"), DropDownList)
        SqlDataSource1.UpdateParameters("reg").DefaultValue = ddList.SelectedValue.ToString
        Dim lbLog As Label = CType(gvDPRDetail.Rows(e.RowIndex).FindControl("lblLog"), Label)
        SqlDataSource1.UpdateParameters("log").DefaultValue = "Leave Assigned " & ddList.SelectedValue.ToString & " on " & Now.ToString() & vbCrLf & lbLog.Text
    End Sub

    Private Sub rblOrg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblOrg.SelectedIndexChanged
        Dim Profileq As String = "Select distinct name || '  ' || workarea as t, email as v from contacts_New where email is not null and email <> '' and org = '" & rblOrg.SelectedValue & "' order by workarea desc, name asc"

        ddlManageProfile.DataTextField = "t"
        ddlManageProfile.DataValueField = "v"
        ddlManageProfile.DataSource = getDBTable(Profileq, "hrdb")
        ddlManageProfile.DataBind()
        ddlManageProfile_SelectedIndexChanged(vbNull, EventArgs.Empty)
    End Sub
    Function download2Mail(ByVal filename As String, ByVal extralog As String, Optional ByVal test As Integer = 1)
        Try
            Dim log = "<small>Log:<br/> Daemon Report Maker Invoked by " & Session("email") & " at " & Now.ToString
            'Dim q = "insert into sms (sms_dt,smscount) select current_date,0    WHERE not  EXISTS (select * from sms where sms_dt = current_date)"
            'Dim ret = executeDB(q)
            ' Change the Header Row back to white color
            'gvAttendance.HeaderRow.Style.Add("background-color", "#FFFFFF")
            ''  gvAttendance.HeaderRow.BackColor = Color.White
            'For Each cell As TableCell In gvAttendance.HeaderRow.Cells
            '    cell.BackColor = gvAttendance.HeaderStyle.BackColor
            'Next
            'For Each row As GridViewRow In gvAttendance.Rows
            '    ' row.BackColor = Color.White
            '    For Each cell As TableCell In row.Cells
            '        If row.RowIndex Mod 2 = 0 Then
            '            cell.BackColor = gvAttendance.AlternatingRowStyle.BackColor
            '        Else
            '            cell.BackColor = gvAttendance.RowStyle.BackColor
            '        End If
            '        ' cell.CssClass = "textmode"
            '    Next
            'Next

            'style to format numbers to string
            ' Dim style As String = "<style> .textmode { } </style>"
            log = log & vbCrLf & "<br/>Report Grid plotted in memory at " & Now.ToString()


            'Dim path As String = Server.MapPath("~/upload/HR/Attendance/")
            'If Not System.IO.Directory.Exists(path) Then
            '    System.IO.Directory.CreateDirectory(path)
            'End If
            Dim report = ""
            ' If Not System.IO.File.Exists(path & filename) Then
            log = log & vbCrLf & "<br/>Report path verification done at " & Now.ToString()
            Using sw As New System.IO.StringWriter()
                Using hw As New HtmlTextWriter(sw)
                    '  Dim writer As System.IO.StreamWriter = System.IO.File.CreateText(path & filename)
                    Try
                        '            writer.WriteLine("BIFPCL Attendance Online Report " & Now.ToString("dd.MM.yyyy"))
                        '            writer.WriteLine("_")
                        divExport.RenderControl(hw)
                        'gvAttendance.RenderControl(hw)
                        'divLeaveType.RenderControl(hw)
                        report = sw.ToString & "<br/> Report Generated at:" & Now.ToString()
                        '        writer.WriteLine(sw.ToString())
                        '            'writer.WriteLine("_")
                        '            'writer.WriteLine(divAttandance.InnerHtml.ToString)
                        '            'writer.WriteLine("This is a system generated report. Real time status can be seen at url http://cc.ntpclakshya.co.in/hrap/report.aspx")
                        '            writer.Close()
                        '            hw.Dispose()
                        '            sw.Dispose()
                        log = log & vbCrLf & "<br/>Report Rendering done at " & Now.ToString()
                                Catch ex As Exception
            'writer.WriteLine(ex.Message)
            'writer.Close()
            hw.Dispose()
            sw.Dispose()
        End Try

        End Using
        End Using
            'divMsg.InnerHtml = "xls file generated" & vbCrLf & divMsg.InnerHtml
            'Else
            '    divMsg.InnerHtml = "xls file already exist" & vbCrLf & divMsg.InnerHtml
            'End If

            Dim mailcc = "vinodkotiya@bifpcl.com,mujtabatabrez@bifpcl.com,sidmandal@bifpcl.com,oziur@bifpcl.com,rokeya.khatun@bifpcl.com  "
            Dim mailto = "md@bifpcl.com, nareshanand@bifpcl.com "
            'Dim mydt = getDBTable("select email from employee where empno in (select distinct eid from kpa_hr  where 1 )")
            'Dim emailpace = ""
            'For Each r In mydt.Rows
            '    emailpace = emailpace & r(0) & ","
            'Next
            log = log & vbCrLf & "<br/>Fetch email list at " & Now.ToString()
            If test = 0 Then

                mailto = "admin@bifpcl.com"
                mailcc = "vinodkotiya@gmail.com"
            End If
            log = log & vbCrLf & "<br/>Attempt E-Mail Sending at " & Now.ToString()
            log = log & vbCrLf & "<br/>ReportMaker Daemon Hibernation starts at " & Now.ToString() & "<br/>" & extralog
            Dim msg = "Dear Ma'm/Sir " & vbCrLf & vbCrLf &
                "<br/><br/>Please find attached system generated Online Daily Attendance Report:" & vbCrLf &
                "<br/>Real time status can be seen at url <a href=https://www.bifpcl.com/hrbiometric.aspx target=_blank>BIFPCL.com</a> " &
                "" & report & " <br/> " & log
            Dim ret = SendEmail("admin@bifpcl.com", mailto, mailcc, "", "BIFPCL Daily Attendance Report  " & txtDate.Text, msg, "", "", "admin@bifpcl.com", "Imtheone@6")
            divMsg.InnerHtml = "html file  mailed " & log & ret & filename & vbCrLf & divMsg.InnerHtml
            'q = "update   sms set reportlog = '" & "Email Status:" & ret & vbCrLf & divMsg.InnerHtml & "' where sms_dt = current_date"
            'Dim ret1 = executeDB(q)
            'divMsg.InnerHtml = "Todays Report emailed " & ret1 & " from " & Request.UserHostAddress & vbCrLf & log & divMsg.InnerHtml
            'Session("EmailAttempt" + Now.ToString("dd-MM-yyyy")) = True
            btnEmail.Text = "Mail sent to MD"
            btnEmail.Enabled = False
        Catch e1 As Exception
            divMsg.InnerHtml = divMsg.InnerHtml & e1.Message
        End Try
    End Function
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Return
    End Sub
    Private Sub btnEmail_Command(sender As Object, e As CommandEventArgs) Handles btnEmail.Command
        download2Mail("test1.html", "")
    End Sub

    Private Sub btnFutureDateAdd_Click(sender As Object, e As EventArgs) Handles btnFutureDateAdd.Click
        Dim q = "select bioid from contacts_New where email ='" & ddlManageProfile.SelectedValue & "'"
        Try
            Dim uid = getDBsingle(q, "hrdb")
        q = "replace into biometric (uid, name,dt) values(" & uid & ",'" & ddlManageProfile.SelectedItem.Text & "','" & ddlFutureDate.SelectedValue & "')"
            Dim ret = executeDB(q, "hrdb")
            If ret = "ok" Then
                lbManage.Text = "Record inserted <a href=hrBiometric.aspx?mode=manageattendance>Refresh</a>"

            Else
                lbManage.Text = "Error "
            End If


        Catch ex As Exception
            divMsg.InnerHtml = q & ex.Message
        End Try
    End Sub

    Private Sub rblHolidayOrg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblHolidayOrg.SelectedIndexChanged
        Dim loc = rblHolidayLoc.SelectedValue '"%"
        ' If rblHolidayOrg.SelectedValue = "NTPC" Then loc = rblHolidayLoc.SelectedValue
        gvCalendar.DataSource = getDBTable("select holiday, strftime('%d.%m.%Y',holidaydate) as 'Date' from holiday where strftime('%Y',holidaydate) = '" & Now.Year & "' and org = '" & rblHolidayOrg.SelectedValue & "' and loc like '" & loc & "' order by org, holidaydate ", "hrdb")
        gvCalendar.DataBind()
    End Sub

    Private Sub rblHolidayLoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblHolidayLoc.SelectedIndexChanged
        Dim loc = rblHolidayLoc.SelectedValue '"%"
        'If rblHolidayOrg.SelectedValue = "NTPC" Then loc = rblHolidayLoc.SelectedValue
        gvCalendar.DataSource = getDBTable("select holiday, strftime('%d.%m.%Y',holidaydate) as 'Date' from holiday where strftime('%Y',holidaydate) = '" & Now.Year & "' and org = '" & rblHolidayOrg.SelectedValue & "' and loc like '" & loc & "' order by org, holidaydate ", "hrdb")
        gvCalendar.DataBind()
    End Sub

    Private Sub btnAssignCL_Click(sender As Object, e As EventArgs) Handles btnAssignCL.Click
        If Session("email") Is Nothing Then Response.Redirect("Default.aspx")
        Dim q = "select email, org, workarea from contacts_New where del = 0 and doj < '" & Now.Year & "-01-01'"
        Dim mydt = getDBTable(q, "hrdb")
        Dim msg = ""
        For Each r In mydt.Rows
            Dim CL = "20"
            Dim leavekey = 1
            If r("org") = "NTPC" Then
                CL = 12
            Else
                If r("workarea") = "HO" Then
                    CL = "20"
                Else
                    CL = "15"
                End If
            End If
            ''' Assign CL
            q = "replace into leavequota (accrual_dt, ltype, leavekey, quota, eid, del, remark, last_updated, lastupdateby) " &
             " values('" & Now.Year & "-01-01','CL'," & leavekey & "," & CL & ",'" & r("email") & "',0,'Credited on " & Now.ToString("dd.MM.yy HH:mm:ss") & "' ,current_timestamp,'" & Session("email") & Request.UserHostAddress & "')"
            If executeDB(q, "hrdb") = "ok" Then
                msg = msg & r("email") & " -CL,"
            Else
                msg = msg & " CL Failed for " & r("email")
            End If

            ''' Assign RH
            If r("org") = "NTPC" Then
                leavekey = 2
                q = "replace into leavequota (accrual_dt, ltype, leavekey, quota, eid, del, remark, last_updated, lastupdateby) " &
             " values('" & Now.Year & "-01-01','RH'," & leavekey & ",6,'" & r("email") & "',0,'Credited on " & Now.ToString("dd.MM.yy HH:mm:ss") & "' ,current_timestamp,'" & Session("email") & Request.UserHostAddress & "')"
                If executeDB(q, "hrdb") = "ok" Then
                    msg = msg & r("email") & " -RH,"
                Else
                    msg = msg & " RH Failed for " & r("email")
                End If
            End If
        Next
        lbMessage.Text = Now.ToString & " Leaves credited only where date of joining is less that 1st january. Employees joining in mid year to be entered seperately. " & msg

    End Sub

    Private Sub btnAssignNTPCApr_Click(sender As Object, e As EventArgs) Handles btnAssignNTPCApr.Click
        If Session("email") Is Nothing Then Response.Redirect("Default.aspx")
        AssignNTPCLeave(Now.Year & "-04-01")
    End Sub

    Private Sub btnAssignNTPCOct_Click(sender As Object, e As EventArgs) Handles btnAssignNTPCOct.Click
        If Session("email") Is Nothing Then Response.Redirect("Default.aspx")
        AssignNTPCLeave(Now.Year & "-10-01")
    End Sub
    Sub AssignNTPCLeave(ByVal accrual_dt As String)

        Dim q = "select email, org, workarea from contacts_New where del = 0 and org = 'NTPC' and doj < '" & accrual_dt & "'"
        Dim mydt = getDBTable(q, "hrdb")
        Dim msg = ""
        For Each r In mydt.Rows
            Dim EL = "15"
            Dim leavekey = 3
            ''' Assign EL
            q = "replace into leavequota (accrual_dt, ltype, leavekey, quota, eid, del, remark, last_updated, lastupdateby) " &
             " values('" & accrual_dt & "','EL'," & leavekey & "," & EL & ",'" & r("email") & "',0,'Credited on " & Now.ToString("dd.MM.yy HH:mm:ss") & "' ,current_timestamp,'" & Session("email") & Request.UserHostAddress & "')"
            If executeDB(q, "hrdb") = "ok" Then
                msg = msg & r("email") & " -EL,"
            Else
                msg = msg & " EL Failed for " & r("email")
            End If

            ''' Assign SAL
            If r("workarea") = "SO" Then
                Dim SAL = 15
                leavekey = 4
                q = "replace into leavequota (accrual_dt, ltype, leavekey, quota, eid, del, remark, last_updated, lastupdateby) " &
             " values('" & accrual_dt & "','SAL'," & leavekey & "," & SAL & ",'" & r("email") & "',0,'Credited on " & Now.ToString("dd.MM.yy HH:mm:ss") & "' ,current_timestamp,'" & Session("email") & Request.UserHostAddress & "')"
                If executeDB(q, "hrdb") = "ok" Then
                    msg = msg & r("email") & " -SAL,"
                Else
                    msg = msg & " SAL Failed for " & r("email")
                End If
            End If
            ''' Assign HPL
            Dim HPL = 10
            leavekey = 5
            q = "replace into leavequota (accrual_dt, ltype, leavekey, quota, eid, del, remark, last_updated, lastupdateby) " &
             " values('" & accrual_dt & "','HPL'," & leavekey & "," & HPL & ",'" & r("email") & "',0,'Credited on " & Now.ToString("dd.MM.yy HH:mm:ss") & "' ,current_timestamp,'" & Session("email") & Request.UserHostAddress & "')"
            If executeDB(q, "hrdb") = "ok" Then
                msg = msg & r("email") & " -HPL,"
            Else
                msg = msg & " HPL Failed for " & r("email")
            End If
        Next
        lbMessage.Text = Now.ToString & " Leaves credited only where date of joining is less than " & accrual_dt & ". Employees joining later on to be entered seperately. " & msg
    End Sub

    Protected Sub btnSumbitLeaveRequest_Click(sender As Object, e As EventArgs) Handles btnSumbitLeaveRequest.Click
        If Session("email") Is Nothing Then Response.Redirect("Default.aspx")
        Try
            If String.IsNullOrEmpty(txtL1From.Text) Or String.IsNullOrEmpty(txtL1To.Text) Then
                lbRequestMessage.Text = "Fill up the leave avail breakup date"
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtPurpose.Text) Or String.IsNullOrEmpty(txtAddress.Text) Then
                lbRequestMessage.Text = "Fill up the leave purpose/address"
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtDt_st_out.Text) Or String.IsNullOrEmpty(txtDt_st_in.Text) Then
                lbRequestMessage.Text = "Fill up the Date of leave start"
                Exit Sub
            End If
            Dim l2to, l2from, l3to, l3from As Date
            Dim dt_st_out = DateTime.ParseExact(txtDt_st_out.Text, "dd.M.yyyy", Nothing)
            Dim dt_st_in = DateTime.ParseExact(txtDt_st_in.Text, "dd.M.yyyy", Nothing)
            Dim l1from = DateTime.ParseExact(txtL1From.Text, "dd.M.yyyy", Nothing)
            Dim l1to = DateTime.ParseExact(txtL1To.Text, "dd.M.yyyy", Nothing)
            If Not String.IsNullOrEmpty(txtL2From.Text) Then l2from = DateTime.ParseExact(txtL2From.Text, "dd.M.yyyy", Nothing)
            If Not String.IsNullOrEmpty(txtL2To.Text) Then l2to = DateTime.ParseExact(txtL2To.Text, "dd.M.yyyy", Nothing)
            If Not String.IsNullOrEmpty(txtL3From.Text) Then l3from = DateTime.ParseExact(txtL3From.Text, "dd.M.yyyy", Nothing)
            If Not String.IsNullOrEmpty(txtL3To.Text) Then l3to = DateTime.ParseExact(txtL3To.Text, "dd.M.yyyy", Nothing)
            Dim q = ""
            If lbMode.Text = "New" Then
                '' insert
                q = "insert into leaverequest (appid, apptype, email, dt_st_out, outtime, dt_st_in, intime, l1type,l1from,l1to,l2type,l2from,l2to,l3type,l3from,l3to, dt_apply,purpose,address, remark, last_updated, status )" &
                " values('" & lbID.Text & "','" & rblLeaveType.SelectedValue & "','" & Session("email") & "','" & dt_st_out.ToString("yyyy-MM-dd") & "','" & ddlout.SelectedValue & "','" & dt_st_in.ToString("yyyy-MM-dd") & "','" & ddlin.SelectedValue & "','" & ddlL1type.SelectedValue & " - " & ddlL1type.SelectedItem.Text & "','" & l1from.ToString("yyyy-MM-dd") & "','" & l1to.ToString("yyyy-MM-dd") & "', " &
                " '" & ddlL2type.SelectedValue & " - " & ddlL2type.SelectedItem.Text & "','" & l2from.ToString("yyyy-MM-dd") & "','" & l2to.ToString("yyyy-MM-dd") & "', '" & ddlL3type.SelectedValue & " - " & ddlL3type.SelectedItem.Text & "','" & l3from.ToString("yyyy-MM-dd") & "','" & l3to.ToString("yyyy-MM-dd") & "',  " &
                " current_timestamp,'" & txtPurpose.Text.Replace("'", "") & "','" & txtAddress.Text.Replace("'", "") & "','" & txtRemark.Text.Replace("'", "") & "','" & Request.UserHostAddress.ToString & "', 0 )"

            Else
                '' update
            End If

            Dim ret = executeDB(q, "hrdb")
            If Not ret.Contains("error") Then
                lbRequestMessage.Text = "Data inserted .. Redirecting to Print Page"
                btnSumbitLeaveRequest.Enabled = False
                Response.Redirect("hrBiometric.aspx?aid=" & lbID.Text & "&mode=print")
            Else
                lbRequestMessage.Text = "Error " & ret & q
            End If
        Catch ex As Exception
            lbRequestMessage.Text = "Error " & ex.Message
        End Try
    End Sub
    Sub printApplication(ByVal applicationID As String)

        Dim appID = applicationID
        Session("leaveAppID") = appID
        Dim ref = "Ref: BIFPCL/HR/Leave/Application: " & appID & "                Date: " & Now.ToString("dd.MM.yyyy")
        Dim head = "Bangladesh-India Friendship Power Company (Pvt) Ltd."


        Dim q = "select appid, apptype, email,dt_st_out,dt_st_in, Cast ((JulianDay(dt_st_in) - JulianDay(dt_st_out)) As Integer) as duration, strftime('%d.%m.%Y',dt_st_out) || ' ' || outtime as dt_st_outTime, strftime('%d.%m.%Y',dt_st_in) || ' ' || intime as dt_st_inTime, l1type,strftime('%d.%m.%Y',l1from) || ' - ' || strftime('%d.%m.%Y',l1to) as l1fromto,Cast ((JulianDay(l1to) - JulianDay(l1from)) As Integer) + 1 as l1duration, l1from, l1to ,l2type, strftime('%d.%m.%Y',l2from) || ' - ' || strftime('%d.%m.%Y',l2to) as l2fromto, Cast ((JulianDay(l2to) - JulianDay(l2from)) As Integer)+1 as l2duration, l2from,l2to,l3type,strftime('%d.%m.%Y',l3from) || ' - ' || strftime('%d.%m.%Y',l3to) as l3fromto,Cast ((JulianDay(l3to) - JulianDay(l3from)) As Integer)+1 as l3duration, l3from, l3to, strftime('%d.%m.%Y',dt_apply) as dt_apply,purpose,address, remark, last_updated,status from leaverequest where appid = '" & appID & "' limit 1"
        Dim dt = getDBTable(q, "hrdb")
        If dt.Rows.Count < 1 Then
            divProfile.InnerHtml = "No Records found for requested ID load failed.." & appID
            Exit Sub
        End If
        Dim appType As String = If(IsDBNull(dt.Rows(0)("apptype")), "", dt.Rows(0)("apptype"))
        appType = If(appType.Contains("Out"), "Out Station Application", "In Station Application")
        Dim email = If(IsDBNull(dt.Rows(0)("email")), "", dt.Rows(0)("email"))
        Dim name = getDBsingle("select name || ', ' || desig from contacts_New where email = '" & email & "' limit 1", "hrdb")
        Dim org = getDBsingle("select org from contacts_New where email = '" & email & "' limit 1", "hrdb")
        Dim workarea = getDBsingle("select workarea from contacts_New where email = '" & email & "' limit 1", "hrdb")
        Dim dt_st_outTime = ""
        Dim dt_st_inTime = ""
        Dim duration = ""
        Dim absence = 0
        Dim lbOut = "Start Date of Leave"
        Dim lbIn = "End Date of Leave"
        Dim lbAbsence = "Total Absence"
        Dim dt_st_out, dt_st_in As Date
        If appType.Contains("Out") Then
            lbOut = "Date of Leaving Station"
            lbIn = "Date of Joining Station"
            lbAbsence = "Total Absence from HQ/Site(Excluding journey date)"
        End If
        dt_st_outTime = If(IsDBNull(dt.Rows(0)("dt_st_outTime")), "", dt.Rows(0)("dt_st_outTime"))
        dt_st_inTime = If(IsDBNull(dt.Rows(0)("dt_st_inTime")), "", dt.Rows(0)("dt_st_inTime"))
        duration = If(IsDBNull(dt.Rows(0)("duration")), "", dt.Rows(0)("duration"))
        absence = duration - 1
        Dim txtdt_st_out = If(IsDBNull(dt.Rows(0)("dt_st_out")), "0000-00-00", dt.Rows(0)("dt_st_out"))
        Dim txtdt_st_in = If(IsDBNull(dt.Rows(0)("dt_st_in")), "0000-00-00", dt.Rows(0)("dt_st_in"))
        dt_st_out = DateTime.ParseExact(txtdt_st_out, "yyyy-M-dd", Nothing)
        dt_st_in = DateTime.ParseExact(txtdt_st_in, "yyyy-M-dd", Nothing)
        Dim l1type = If(IsDBNull(dt.Rows(0)("l1type")), "", dt.Rows(0)("l1type"))
        Dim l1fromto = If(IsDBNull(dt.Rows(0)("l1fromto")), "", dt.Rows(0)("l1fromto"))
        Dim l1duration = If(IsDBNull(dt.Rows(0)("l1duration")), "", dt.Rows(0)("l1duration"))
        Dim l2type = If(IsDBNull(dt.Rows(0)("l2type")), "", dt.Rows(0)("l2type"))
        Dim l2fromto = If(IsDBNull(dt.Rows(0)("l2fromto")), "", dt.Rows(0)("l2fromto"))
        Dim l2duration = If(IsDBNull(dt.Rows(0)("l2duration")), "", dt.Rows(0)("l2duration"))
        Dim l3type = If(IsDBNull(dt.Rows(0)("l3type")), "", dt.Rows(0)("l3type"))
        Dim l3fromto = If(IsDBNull(dt.Rows(0)("l3fromto")), "", dt.Rows(0)("l3fromto"))
        Dim l3duration = If(IsDBNull(dt.Rows(0)("l3duration")), "", dt.Rows(0)("l3duration"))
        Dim purpose = If(IsDBNull(dt.Rows(0)("purpose")), "", dt.Rows(0)("purpose"))
        Dim address = If(IsDBNull(dt.Rows(0)("address")), "", dt.Rows(0)("address"))
        Dim remark = If(IsDBNull(dt.Rows(0)("remark")), "", dt.Rows(0)("remark"))

        Dim liData = "  <li class='list-group-item'><code>Leave</code>: " & appType & "  </li> " &
            "  <li class='list-group-item'><code>Name</code>: " & name & "  </li> " &
        "  <li class='list-group-item'><code>" & lbOut & "</code>: " & dt_st_outTime & "  </li> " &
        "  <li class='list-group-item'><code>" & lbIn & "</code>: " & dt_st_inTime & "  </li> " &
        "  <li class='list-group-item'><code>" & lbAbsence & "</code>: " & absence.ToString & " Day(s) </li> " &
        "  <li class='list-group-item'><code>Leave Details</code>:   </li> " &
        "  <li class='list-group-item'><code>1. " & l1type & "</code>: " & l1fromto & "  </li> "
        If Not l2type = "- - -" Then liData = liData &
        "  <li class='list-group-item'><code>2. " & l2type & "</code>: " & l2fromto & "  </li> "
        If Not l3type = "- - -" Then liData = liData &
        "  <li class='list-group-item'><code>3. " & l3type & "</code>: " & l3fromto & "  </li> "

        liData = liData & "  <li class='list-group-item'><code>Purpose of Leave</code>: " & purpose & "  </li> " &
        "  <li class='list-group-item'><code>Address during leave period</code>: " & address & "  </li> " &
        "  <li class='list-group-item'><code>Remark</code>: " & remark & "  </li> "

        '''################## CALANDER ################
        '''
        Dim calTable = "<table class='table-responsive  table table-striped table-earning'>"
        Dim CalDays = absence + 6
        Dim dates As New List(Of String)
        Dim wkdays As New List(Of String)
        Dim colors As New List(Of String)
        Dim gh As New List(Of String)
        Dim myday = dt_st_out.AddDays(-2)
        For i = 0 To CalDays - 1
            dates.Add(myday.ToString("%d.%M"))
            wkdays.Add(Left(myday.DayOfWeek.ToString, 3))
            Dim holiday = checkHoliday(myday, org, workarea)
            If myday.DayOfWeek = 5 Then : colors.Add("PINK")
            ElseIf myday.DayOfWeek = 6 And workarea = "HO" Then : colors.Add("PINK")
            ElseIf Not holiday.Contains("Error") Then
                colors.Add("GREEN")
                gh.Add(myday.ToString("%d.%M") & " - " & holiday)
            Else
                colors.Add("WHITE")
            End If
            myday = myday.AddDays(1)
        Next
        calTable = calTable & "<tr>"
        For Each d In dates
            calTable = calTable & "<td>" & d.ToString & "</td>"
        Next
        calTable = calTable & "</tr>"
        calTable = calTable & "<tr>"
        For Each d In dates
            Dim color = "white"
            If colors(dates.IndexOf(d.ToString)) = "PINK" Then color = "pink"
            If colors(dates.IndexOf(d.ToString)) = "GREEN" Then color = "lime"
            calTable = calTable & "<td style='background:" & color & ";'>" & wkdays(dates.IndexOf(d.ToString)) & "</td>"

        Next
        calTable = calTable & "</table>"
        Dim ghString = ""
        For Each g In gh
            ghString = ghString & g
        Next

        divProfile.InnerHtml = "<section class='card'> " &
                                      "  <div class='card-header user-header alt bg-light'> " &
                                          "  <div class='media'> " &
                                              "  <a href='#'> " &
                                                  "  <img class='align-self-center rounded-circle mr-3' style='width:85px; height:85px;' alt='' src='" & "/images/logo_thumb.png'> " &
                                              "  </a> " &
                                              "  <div class='media-body'> " &
                                                  "  <h2 class='text-dark display-6'>BIFPCL Leave Application</h2> " &
                                                  "  <p>Application No: " & applicationID & "</p> " &
                                              "  </div> " &
                                          "  </div> " &
                                      "  </div> " &
       "  <ul class='list-group list-group-flush'> " &
                                          liData &
                                            "  </ul> " &
 "  </section> " & calTable
    End Sub

    Private Sub btnSubmitPrint_Click(sender As Object, e As EventArgs) Handles btnSubmitPrint.Click
        Dim q = "update leaverequest set status='1' where appid = '" & Session("leaveAppID") & "'"
        Dim ret = executeDB(q, "hrdb")
        If Not ret.Contains("error") Then
            divProfile.InnerHtml = "status updated .. Redirecting to Print Page"
            Response.Redirect("gatepassPrint.aspx?mode=leave")
        Else
            divProfile.InnerHtml = "status updated Error " & ret & q
        End If

    End Sub

    Private Sub rblLeaveType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblLeaveType.SelectedIndexChanged
        If rblLeaveType.SelectedValue = "In" Then
            lbFrom.InnerText = "Start Date of Leave:"
            lbTo.InnerText = "End Date of Leave:"
            ddlout.Visible = False
            ddlin.Visible = False
        Else
            lbFrom.InnerText = "Date of Leaving Station:"
            lbTo.InnerText = "Date of Joining Station:"
            ddlout.Visible = True
            ddlin.Visible = True
        End If
    End Sub

    Private Sub btnModifyPrint_Click(sender As Object, e As EventArgs) Handles btnModifyPrint.Click
        Response.Redirect("hrBiometric.aspx?mode=leaverequest")
    End Sub
End Class
