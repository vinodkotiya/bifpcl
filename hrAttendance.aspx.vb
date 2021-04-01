Imports System.Data
Imports AjaxControlToolkit
Imports dbOp
Imports Common
Imports System.IO

Partial Class hrAttendance
    Inherits System.Web.UI.Page
    Private Sub dpr_entry_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim admin = False
        If Not IsPostBack Then
            Session("email") = "vinodkotiya@bifpcl.com"
            '<<<<<<<<<########## Login MODULE
            If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343278")
            '########## Login MODULE >>>>>>>>

            'If (Session("email").ToString.Contains("prakashcn") Or Session("email").ToString.Contains("vinodkotiya@bifpcl") Or Session("email").ToString.Contains("rashedul@bifpcl.com") Or Session("email").ToString.Contains("rudayashankar@bifpcl") Or Session("email").ToString.Contains("anupam.kumar")) Then
            '    admin = True
            'End If
            'Dim qry_project As String = "Select distinct pk.project t,pk.project v from Packages pk  where pk.project in (select distinct u.project from Projects_ntpc p, Units u , MileStones m where p.projectname = u.project and u.project=m.project and u.unit = m.unit and milestone= 'COD'  and achieved <>'A' and (u.zerodate ='' or not isnull(u.zerodate)) and p.region not in ('REDG','IJV')) order by pk.project "

            pnlUpdate.Visible = False
            pnlReport.Visible = False
            pnlBio.Visible = False
            If Request.QueryString("mode") = "report" Then
                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                If Not checkAuthorization(Session("email"), "hrAttendance.aspx?mode=report") Then
                    diverr.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access HR Absentee.<br/> May please contact HR Dept and provide your email id for authorisation."
                    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied HR Report Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    Exit Sub
                End If
                ''''''##########################################
                pnlReport.Visible = True
                rblReportDuration_SelectedIndexChanged(vbNull, EventArgs.Empty)

                executeDB("insert into login (eid, log, logintime) values (0, 'Access DPR Report Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
            ElseIf Request.QueryString("mode") = "download" Then
                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                If Not checkAuthorization(Session("email"), "hrAttendance.aspx?mode=report") Then
                        diverr.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access HR Absentee.<br/> May please contact HR Dept and provide your email id for authorisation."
                        executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied HR Report Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                        Exit Sub
                    End If
                ''''''##########################################
                '''
                chkDownload.Checked = True
                pnlReport.Visible = True
                    rblReportDuration_SelectedIndexChanged(vbNull, EventArgs.Empty)

                executeDB("insert into login (eid, log, logintime) values (0, 'Access Download bio Report Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

            ElseIf Request.QueryString("mode") = "checkbio" Then
                    pnlBio.Visible = True
                gvBio.DataSource = getDBTable("select distinct b.uid as 'BIOID', b.name as 'BIO Name', bioid as 'ID Master',  c.name as 'Name Master', workarea from contacts_new c  ,biometric b where c.bioid = b.uid order by c.name", "hrdb")
                gvBio.DataBind()
                gvBioMissing.DataSource = getDBTable("select distinct uid, name as 'Bioid' from biometric where dt > '2018-09-15' and not uid  in (select distinct ifnull(bioid,0) from contacts_new)", "hrdb")
                gvBioMissing.DataBind()
            End If
            'If admin = False Then
            '    gvDPRDetail.Visible = False
            '    gvPlan.Visible = False
            '    divMsg.InnerHtml = "You are not authorised for this section."
            '    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied DPR Update Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

            'End If
        End If

    End Sub
    Function processAttendance(ByVal mydt As DataTable) As DataTable
        For Each r In mydt.Rows
            Dim location = r("workarea").ToString
            Dim org = Trim(Left(r("org").ToString, 6))
            Dim outStr = Left(r("Out").ToString, 5)
            Dim inStr = r("In").ToString
            Dim dt = DateTime.ParseExact(r("Date"), "dd.M.yyyy", Nothing)


            ' Continue For

            '''' Show My Leaves
            '''' 
            If Not String.IsNullOrEmpty(r("RegularizingIndicator").ToString) Then
                '   r("Status") = "<span style='background-color: blue; color: white;'>Leave</span>"
                r("RegularizingIndicator") = r("RegularizingIndicator")
                Continue For
            End If

            '''' SHOW GH
            '''
            If org = "BIFPCL" Then org = "BPDB"  ''for BIFPCL staff holiday shall be same as BPDB
            ' Dim q = "select holiday from holiday where holidaydate = '" & dt.ToString("yyyy-MM-dd") & "' and org like '" & Org & "' "
            Dim holiday = checkHoliday(dt, org, location)  'getDBsingle(q, "hrdb")
            'r("RegularizingIndicator") = holiday
            'Continue For
            If Not holiday.Contains("Error") Then
                '  r("Status") = "<span style='background-color: blue; color: white;'>Holiday</span>"
                r("RegularizingIndicator") = "GH" 'holiday
                Continue For
            End If
            If dt.DayOfWeek = 5 Then
                r("RegularizingIndicator") = "WO"
                Continue For
            End If
            If (dt.DayOfWeek = 6 And location = "HO") Then
                r("RegularizingIndicator") = "WO"
                Continue For
            End If

            If String.IsNullOrEmpty(outStr) And String.IsNullOrEmpty(inStr) Then
                r("RegularizingIndicator") = "A"
                Continue For
            End If
            ''''THIS STATEMENT TO BE DISABLED
            If cbOnePunch.Checked Then
                If (Not String.IsNullOrEmpty(outStr) And Not String.IsNullOrEmpty(inStr)) Then
                    r("RegularizingIndicator") = "" '  '& dt.DayOfWeek & location
                Else
                    r("RegularizingIndicator") = If(Not String.IsNullOrEmpty(outStr), outStr, inStr)
                End If
                Continue For
            End If

                Dim showtime = ""

            If (Not String.IsNullOrEmpty(outStr) Or Not String.IsNullOrEmpty(inStr)) Then
                If cbShowTime.Checked Then showtime = vbCrLf & inStr & " - " & outStr
                r("RegularizingIndicator") = "P" & showtime '  '& dt.DayOfWeek & location
                Continue For
            End If

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
    Private Function loadLog(ByVal startdate As Date, ByVal enddate As Date) As Boolean
        Dim org = " and org = '" & rblOrg.SelectedValue & "' "
        If rblOrg.SelectedValue = "both" Then org = " and (org = 'BPDB' or org = 'BIFPCL') "
        Dim workarea = " and workarea like '%" & rblWorkArea.SelectedValue & "%'  "

        Dim q = "select c.name as Name, strftime('%d.%m.%Y',dt) as Date,   log as ChangeLog, length(log)  as tot from contacts_new c left outer join biometric b on c.bioid = b.uid left outer join leaveavailed l on b.uid = l.uid and b.dt = l.leavedt where log is not null and tot > 70 and (dt >= '" & startdate.ToString("yyyy-MM-dd") & "'  and  dt <= '" & enddate.ToString("yyyy-MM-dd") & "' ) " & org & workarea & " order by dt asc"
        Dim mydt = getDBTable(q, "hrdb")
        'If mydt.Rows.Count = 0 Then
        '    Return False
        'End If
        'For Each r In mydt.Rows
        '    Dim count = 0
        '    For Each match In Regex.Matches(sentence, tobematched, RegexOptions.ig)
        '        count = count + 1
        '    Next
        'Next
        gvLog.DataSource = mydt
        gvLog.DataBind()
        ' divtitle.InnerHtml = q
    End Function
    Private Function loadDPRBIO(ByVal startdate As Date, ByVal enddate As Date, ByVal filter As String, Optional ByVal dprtype As String = "DPR") As Boolean
        'divLeaveType.Visible = False
        ' divLeaveType.InnerHtml = getDBsingle("select group_concat(type || ' - ' || leave) from leaves where 1 order by type", "hrdb")
        divtitle.InnerHtml = rblOrg.SelectedItem.Text & " For period " & startdate & " - " & enddate
        Dim q = ""
        Dim errorPart = ""
        Try

            ' filter = "  and unit like'%" & rblReportUnit.SelectedValue & "%' and workarea like'%" & ddlReportWorkArea.SelectedValue & "%' " & " and agency like'%" & ddlReportAgency.SelectedValue & "%' " & filter

            'Dim q1 = "Select pm.actcode, agency, pm.activity ,  descr As 'Description' ,  pm.um , plan as 'Month Plan', pd.reco as 'Month Reconcile',pm.scope as scope,pp.act as 'Cumm up to date', pp.act as 'Day Progress',  pp.remark as 'Remark' from ProgressMaster pm left join ProgressPlan pd on pm.actcode=pd.actcode   and pd.mon=7 and pd.yr=2018 left join ProgressDetails pp on pm.actcode=pp.actcode where unit=" & rblReportUnit.SelectedValue & " and workarea like'%" & ddlReportWorkArea.SelectedValue & "%' " & filter
            'gvReport.DataSource = getDBTable(q1, "dprdb")
            'gvReport.DataBind()

            Dim startp As DateTime = startdate  'New DateTime(2013, 12, 1)
            Dim endp As DateTime = enddate ' New DateTime(2014, 1, 28)
            Dim CurrD As DateTime = startp

            Dim enddt = endp ' Year(endp) & "-" & Month(endp).ToString.PadLeft(2, "0") & "-" & Day(endp).ToString.PadLeft(2, "0")

            Dim org = " and org = '" & rblOrg.SelectedValue & "' "
            If rblOrg.SelectedValue = "both" Then org = " and (org = 'BPDB' or org = 'BIFPCL') "
            Dim workarea = " and workarea like '%" & rblWorkArea.SelectedValue & "%'  "
            'Get network data
            'Get DPR data
            q = "select b.uid,  dt as 'Date', strftime('%d/%m/%Y', dt) as 'D1', intime, outtime, c.uid as 'Employee Code' from biometric b, contacts_New c where c.del = 0 and  b.uid = c.bioid and dt between '" & CurrD.ToString("yyyy-MM-dd") & "' and '" & enddt.ToString("yyyy-MM-dd") & "'  order by dt asc"
            Dim bioDT = getDBTable(q, "hrdb")
            errorPart = "dprDT"
            diverr.InnerHtml = q & bioDT.Rows.Count

            Dim finalDT1 As New System.Data.DataTable()



            '''####### Creating Columns
            '''
            ' finalDT1.Columns.Add("Order")
            ' finalDT1.Columns.Add("bioid")
            finalDT1.Columns.Add("Employee Code")
            ' finalDT1.Columns.Add("Name")
            finalDT1.Columns.Add("Date")
            finalDT1.Columns.Add("Flag")
            finalDT1.Columns.Add("Time")
            ' finalDT1.Columns.Add("WorkArea")

            For Each bRow In bioDT.Rows

                Dim rowStr = ""
                Dim tmpRow = finalDT1.NewRow
                tmpRow("Employee Code") = bRow("Employee Code")
                tmpRow("Date") = bRow("D1")
                tmpRow("Flag") = "I"
                tmpRow("Time") = bRow("intime")
                finalDT1.Rows.Add(tmpRow)
                Dim tmpRow1 = finalDT1.NewRow
                tmpRow1("Employee Code") = bRow("Employee Code")
                tmpRow1("Date") = bRow("D1")
                tmpRow1("Flag") = "O"
                tmpRow1("Time") = bRow("outtime")
                finalDT1.Rows.Add(tmpRow1)
            Next

            ' finalDT1.Merge(result, False)
            gvReport.DataSource = finalDT1
            gvReport.DataBind()

            '  //This replaces <td> with <th> And adds the scope attribute
            gvReport.UseAccessibleHeader = True
            ' //This will add the <thead> And <tbody> elements
            gvReport.HeaderRow.TableSection = TableRowSection.TableHeader

            ' //This adds the <tfoot> element. 
            ' //Remove if you don't have a footer row
            gvReport.FooterRow.TableSection = TableRowSection.TableFooter
        Catch ex As Exception
            diverr.InnerHtml = "Error after  " & errorPart & ex.Message & q
        End Try
    End Function

    Private Function loadDPR(ByVal startdate As Date, ByVal enddate As Date, ByVal filter As String, Optional ByVal dprtype As String = "DPR") As Boolean

        divLeaveType.InnerHtml = getDBsingle("select group_concat(type || ' - ' || leave) from leaves where 1 order by type", "hrdb")
        divtitle.InnerHtml = rblOrg.SelectedItem.Text & " For period " & startdate & " - " & enddate
        Dim q = ""
        Dim errorPart = ""
        Try

            ' filter = "  and unit like'%" & rblReportUnit.SelectedValue & "%' and workarea like'%" & ddlReportWorkArea.SelectedValue & "%' " & " and agency like'%" & ddlReportAgency.SelectedValue & "%' " & filter

            'Dim q1 = "Select pm.actcode, agency, pm.activity ,  descr As 'Description' ,  pm.um , plan as 'Month Plan', pd.reco as 'Month Reconcile',pm.scope as scope,pp.act as 'Cumm up to date', pp.act as 'Day Progress',  pp.remark as 'Remark' from ProgressMaster pm left join ProgressPlan pd on pm.actcode=pd.actcode   and pd.mon=7 and pd.yr=2018 left join ProgressDetails pp on pm.actcode=pp.actcode where unit=" & rblReportUnit.SelectedValue & " and workarea like'%" & ddlReportWorkArea.SelectedValue & "%' " & filter
            'gvReport.DataSource = getDBTable(q1, "dprdb")
            'gvReport.DataBind()

            Dim startp As DateTime = startdate  'New DateTime(2013, 12, 1)
            Dim endp As DateTime = enddate ' New DateTime(2014, 1, 28)
            Dim CurrD As DateTime = startp

            Dim enddt = endp ' Year(endp) & "-" & Month(endp).ToString.PadLeft(2, "0") & "-" & Day(endp).ToString.PadLeft(2, "0")

            Dim org = " and org = '" & rblOrg.SelectedValue & "' "
            If rblOrg.SelectedValue = "both" Then org = " and (org = 'BPDB' or org = 'BIFPCL') "
            Dim workarea = " and workarea like '%" & rblWorkArea.SelectedValue & "%'  "
            'Get network data
            q = "select  name,  desig, org, workarea, bioid, eid, printorder from contacts_New where del = 0 and email is not null and email <> '' " & org & workarea & " order by printorder asc "
            ' diverr.InnerHtml = q
            Dim nwDT = getDBTable(q, "hrdb")

            If nwDT.Rows.Count = 0 Then
                divMsg.InnerHtml = "No data exist" '& q
                gvReport.DataSource = nwDT
                gvReport.DataBind()
                Return False
            End If

            divMsg.InnerHtml = nwDT.Rows.Count & " Records found for given filters." '& q
            'Get DPR data
            q = "select  b.uid, c.eid, c.org, c.workarea,  strftime('%d.%m.%Y', dt) as Date, dt  ,intime as 'In', outtime as 'Out', '' as Duration, '' as status, leavetype as 'RegularizingIndicator'  from biometric b left outer join contacts_new c on c.bioid = b.uid  left outer join leaveavailed l on b.uid = l.uid and b.dt = l.leavedt where dt >= '" & CurrD.ToString("yyyy-MM-dd") & "' and dt <= '" & enddt.ToString("yyyy-MM-dd") & "' order by printorder "
            Dim bioDT = getDBTable(q, "hrdb")
            Dim dprDT = processAttendance(bioDT)
            errorPart = "dprDT"

            Dim finalDT1 As New System.Data.DataTable()



            '''####### Creating Columns
            '''
            finalDT1.Columns.Add("Order")
            finalDT1.Columns.Add("bioid")
            finalDT1.Columns.Add("EId")
            finalDT1.Columns.Add("Name")
            finalDT1.Columns.Add("Designation")
            ' finalDT1.Columns.Add("WorkArea")

            While (CurrD <= endp)
                finalDT1.Columns.Add(CurrD.ToString("dd.MM"))
                '    If CurrD = endp Then finalDT1.Columns.Add("Remarks")
                CurrD = CurrD.AddDays(1)

            End While
            For Each nwRow In nwDT.Rows

                Dim rowStr = ""
                Dim tmpRow = finalDT1.NewRow
                tmpRow("Order") = nwRow("printorder")
                tmpRow("bioid") = nwRow("bioid")
                tmpRow("EId") = nwRow("eid")
                tmpRow("Name") = nwRow("name")
                tmpRow("Designation") = nwRow("desig")
                '   tmpRow("WorkArea") = nwRow("workarea")
                CurrD = startp
                '## Loop throu all dates for each activity
                While (CurrD <= endp)
                    Dim bioid = 0
                    If Not IsDBNull(nwRow("bioid")) Then bioid = nwRow("bioid")
                    Dim dr = dprDT.Select(" dt = '" & CurrD.ToString("yyyy-MM-dd") & "' AND uid = " & bioid)
                    If dr.Length = 1 Then
                        tmpRow(CurrD.ToString("dd.MM")) = dr(0)("RegularizingIndicator")
                        ' tmpRow("Remarks") = dr(0)("remark")
                    Else
                        tmpRow(CurrD.ToString("dd.MM")) = "PNR" ''' if no biometric data found then show it as weekly off
                        ' tmpRow(CurrD.ToString("dd.MM.yy")) = If(dprtype = "BHT", "0", "")
                    End If


                    CurrD = CurrD.AddDays(1)
                End While

                finalDT1.Rows.Add(tmpRow)

            Next
            ''' summation for activity wise
            ''' 

            '           Dim result = From row In finalDT1.AsEnumerable()
            '                        Group row By _group = New With {Key .Id = row.Field(Of String)("WorkArea"),
            '                         Key .Agency = row.Field(Of String)("Agency"),
            '                        Key .grp = row.Field(Of String)("Group")} Into g = Group
            '                        Select New With {Key .WorkArea = _group.Id, Key .Agency = _group.Agency, Key .Descr = g.Select(Function(x) x.Field(Of String)("Descr"))(0), Key .UM = g.Select(Function(x) x.Field(Of String)("UM"))(0),
            '   Key .Scope = g.Sum(Function(x) If(IsDBNull(x("Scope")), 0, x("Scope"))),
            '  Key .CummAch = g.Sum(Function(x) If(IsDBNull(x("CummAch")), 0, x("CummAch"))),
            '                                      Key .Cumm_21 = g.Sum(Function(x) If(IsDBNull(x("Cumm_21")), 0, x("Cumm_21"))),
            'Key .MonthTgt = g.Sum(Function(x) If(IsDBNull(x("MonthTgt")), 0, x("MonthTgt"))),
            '                        Key .MonthAch = g.Sum(Function(x) If(IsDBNull(x("MonthAch")), 0, x("MonthAch"))),
            '                        Key .Week1 = g.Sum(Function(x) If(IsDBNull(x("Week1")), 0, x("Week1"))),
            '                        Key .Week2 = g.Sum(Function(x) If(IsDBNull(x("Week2")), 0, x("Week2"))),
            '                        Key .Week3 = g.Sum(Function(x) If(IsDBNull(x("Week3")), 0, x("Week3"))),
            '                        Key .Week4 = g.Sum(Function(x) If(IsDBNull(x("Week4")), 0, x("Week4"))),
            '                         Key .DayProg = g.Sum(Function(x) If(IsDBNull(x(endp.ToString("dd.MM.yy"))), 0, x(endp.ToString("dd.MM.yy")))),
            '                        Key .Balance = g.Sum(Function(x) If(IsDBNull(x("Balance")), 0, x("Balance")))
            '       }   ',        Key.Content = String.Join(",", g.Select(Function(x) x.Field(Of String)("Agency")))
            '           ' Dim boundTable As DataTable = result.CopyToDataTable()

            errorPart = " Linq Vendor Grand Total wise custom report "

            ' finalDT1.Merge(result, False)
            gvReport.DataSource = finalDT1
            gvReport.DataBind()

            '  //This replaces <td> with <th> And adds the scope attribute
            gvReport.UseAccessibleHeader = True
            ' //This will add the <thead> And <tbody> elements
            gvReport.HeaderRow.TableSection = TableRowSection.TableHeader

            ' //This adds the <tfoot> element. 
            ' //Remove if you don't have a footer row
            gvReport.FooterRow.TableSection = TableRowSection.TableFooter
        Catch ex As Exception
            diverr.InnerHtml = "Error after  " & errorPart & ex.Message & q
        End Try
    End Function

    Private Function loadLeaveDetails(ByVal startdate As Date, ByVal enddate As Date, ByVal filter As String, Optional ByVal dprtype As String = "DPR") As Boolean

        divLeaveType.InnerHtml = getDBsingle("select group_concat(type || ' - ' || leave) from leaves where 1 order by type", "hrdb")
        divtitle.InnerHtml = rblOrg.SelectedItem.Text & " For period " & startdate & " - " & enddate
        Dim q = ""
        Dim errorPart = ""
        Try

            ' filter = "  and unit like'%" & rblReportUnit.SelectedValue & "%' and workarea like'%" & ddlReportWorkArea.SelectedValue & "%' " & " and agency like'%" & ddlReportAgency.SelectedValue & "%' " & filter

            'Dim q1 = "Select pm.actcode, agency, pm.activity ,  descr As 'Description' ,  pm.um , plan as 'Month Plan', pd.reco as 'Month Reconcile',pm.scope as scope,pp.act as 'Cumm up to date', pp.act as 'Day Progress',  pp.remark as 'Remark' from ProgressMaster pm left join ProgressPlan pd on pm.actcode=pd.actcode   and pd.mon=7 and pd.yr=2018 left join ProgressDetails pp on pm.actcode=pp.actcode where unit=" & rblReportUnit.SelectedValue & " and workarea like'%" & ddlReportWorkArea.SelectedValue & "%' " & filter
            'gvReport.DataSource = getDBTable(q1, "dprdb")
            'gvReport.DataBind()

            Dim startp As DateTime = startdate  'New DateTime(2013, 12, 1)
            Dim endp As DateTime = enddate ' New DateTime(2014, 1, 28)
            Dim CurrD As DateTime = startp

            Dim enddt = endp ' Year(endp) & "-" & Month(endp).ToString.PadLeft(2, "0") & "-" & Day(endp).ToString.PadLeft(2, "0")

            Dim org = " and org = '" & rblOrg.SelectedValue & "' "
            If rblOrg.SelectedValue = "both" Then org = " and (org = 'BPDB' or org = 'BIFPCL') "
            Dim workarea = " and workarea like '%" & rblWorkArea.SelectedValue & "%'  "
            'Get network data
            q = "select  name,  desig, org, workarea, bioid, eid, printorder from contacts_New where del= 0 and email is not null and email <> '' " & org & workarea & " order by printorder asc "
            ' diverr.InnerHtml = q
            Dim nwDT = getDBTable(q, "hrdb")

            If nwDT.Rows.Count = 0 Then
                divMsg.InnerHtml = "No data exist" '& q
                gvReport.DataSource = nwDT
                gvReport.DataBind()
                Return False
            End If

            divMsg.InnerHtml = nwDT.Rows.Count & " Records found for given filters." '& q
            'Get DPR data
            q = "select  b.uid, c.eid, c.org, c.workarea,  strftime('%d.%m.%Y', dt) as Date, dt  ,intime as 'In', outtime as 'Out', '' as Duration, '' as status, leavetype as 'RegularizingIndicator'  from biometric b left outer join contacts_new c on c.bioid = b.uid  left outer join leaveavailed l on b.uid = l.uid and b.dt = l.leavedt where dt >= '" & CurrD.ToString("yyyy-MM-dd") & "' and dt <= '" & enddt.ToString("yyyy-MM-dd") & "' order by printorder "
            Dim bioDT = getDBTable(q, "hrdb")
            Dim dprDT = processAttendance(bioDT)
            errorPart = "dprDT"

            Dim finalDT1 As New System.Data.DataTable()



            '''####### Creating Columns
            '''
            'finalDT1.Columns.Add("Order")
            'finalDT1.Columns.Add("bioid")
            finalDT1.Columns.Add("EId")
            finalDT1.Columns.Add("Name")
            finalDT1.Columns.Add("Designation")
            Dim leaveTypes = New List(Of String) From {"CL", "EL", "RH", "SAL", "LL", "HPL", "CHPL", "Others"}


            For Each leave In leaveTypes
                finalDT1.Columns.Add(leave)
            Next
            '    finalDT1.Columns.Add(CurrD.ToString("dd.MM"))
            '    '    If CurrD = endp Then finalDT1.Columns.Add("Remarks")
            '    CurrD = CurrD.AddDays(1)

            'End While
            For Each nwRow In nwDT.Rows

                Dim rowStr = ""
                Dim tmpRow = finalDT1.NewRow
                'tmpRow("Order") = nwRow("printorder")
                'tmpRow("bioid") = nwRow("bioid")
                tmpRow("EId") = nwRow("eid")
                tmpRow("Name") = nwRow("name")
                tmpRow("Designation") = nwRow("desig")
                '   tmpRow("WorkArea") = nwRow("workarea")
                CurrD = startp
                '## Loop throu all dates for each activity
                For Each leave In leaveTypes
                    Dim bioid = 0
                    If Not IsDBNull(nwRow("bioid")) Then bioid = nwRow("bioid")
                    Dim qfilter = " RegularizingIndicator in ('" & leave & "') AND uid = " & bioid
                    Dim leavecomma As String = String.Join(",", leaveTypes.[Select](Function(x) String.Format("'{0}'", x)))
                    leavecomma = leavecomma & ",'P','WO','GH'"
                    If leave = "Others" Then qfilter = " RegularizingIndicator not in (" & leavecomma & ") AND uid = " & bioid
                    Dim dr = dprDT.Select(qfilter)
                    If dr.Length > 0 Then
                        Dim leaveDates = ""
                        For Each r In dr
                            If Not leave = "Others" Then
                                leaveDates = leaveDates & r("Date") & "," & vbCrLf
                            Else
                                leaveDates = leaveDates & r("RegularizingIndicator") & "-" & r("Date") & "," & vbCrLf
                            End If

                        Next
                        tmpRow(leave) = leaveDates 'tmpRow("CL") & dr(0)("dt")
                        ' tmpRow("Remarks") = dr(0)("remark")
                        'Else
                        '        tmpRow(CurrD.ToString("dd.MM")) = "PNR" ''' if no biometric data found then show it as weekly off
                        ' tmpRow(CurrD.ToString("dd.MM.yy")) = If(dprtype = "BHT", "0", "")
                    End If


                    '      CurrD = CurrD.AddDays(1)
                Next

                finalDT1.Rows.Add(tmpRow)

                Next
                ''' summation for activity wise
                ''' 

                '           Dim result = From row In finalDT1.AsEnumerable()
                '                        Group row By _group = New With {Key .Id = row.Field(Of String)("WorkArea"),
                '                         Key .Agency = row.Field(Of String)("Agency"),
                '                        Key .grp = row.Field(Of String)("Group")} Into g = Group
                '                        Select New With {Key .WorkArea = _group.Id, Key .Agency = _group.Agency, Key .Descr = g.Select(Function(x) x.Field(Of String)("Descr"))(0), Key .UM = g.Select(Function(x) x.Field(Of String)("UM"))(0),
                '   Key .Scope = g.Sum(Function(x) If(IsDBNull(x("Scope")), 0, x("Scope"))),
                '  Key .CummAch = g.Sum(Function(x) If(IsDBNull(x("CummAch")), 0, x("CummAch"))),
                '                                      Key .Cumm_21 = g.Sum(Function(x) If(IsDBNull(x("Cumm_21")), 0, x("Cumm_21"))),
                'Key .MonthTgt = g.Sum(Function(x) If(IsDBNull(x("MonthTgt")), 0, x("MonthTgt"))),
                '                        Key .MonthAch = g.Sum(Function(x) If(IsDBNull(x("MonthAch")), 0, x("MonthAch"))),
                '                        Key .Week1 = g.Sum(Function(x) If(IsDBNull(x("Week1")), 0, x("Week1"))),
                '                        Key .Week2 = g.Sum(Function(x) If(IsDBNull(x("Week2")), 0, x("Week2"))),
                '                        Key .Week3 = g.Sum(Function(x) If(IsDBNull(x("Week3")), 0, x("Week3"))),
                '                        Key .Week4 = g.Sum(Function(x) If(IsDBNull(x("Week4")), 0, x("Week4"))),
                '                         Key .DayProg = g.Sum(Function(x) If(IsDBNull(x(endp.ToString("dd.MM.yy"))), 0, x(endp.ToString("dd.MM.yy")))),
                '                        Key .Balance = g.Sum(Function(x) If(IsDBNull(x("Balance")), 0, x("Balance")))
                '       }   ',        Key.Content = String.Join(",", g.Select(Function(x) x.Field(Of String)("Agency")))
                '           ' Dim boundTable As DataTable = result.CopyToDataTable()

                errorPart = " Linq Vendor Grand Total wise custom report "

            ' finalDT1.Merge(result, False)
            gvSummary.DataSource = finalDT1
            gvSummary.DataBind()

            '  //This replaces <td> with <th> And adds the scope attribute
            gvSummary.UseAccessibleHeader = True
            ' //This will add the <thead> And <tbody> elements
            gvSummary.HeaderRow.TableSection = TableRowSection.TableHeader

            ' //This adds the <tfoot> element. 
            ' //Remove if you don't have a footer row
            gvSummary.FooterRow.TableSection = TableRowSection.TableFooter
        Catch ex As Exception
            diverr.InnerHtml = "Error after  " & errorPart & ex.Message & q
        End Try
    End Function


    'Private Sub gvDPRDetail_Load(sender As Object, e As EventArgs) Handles gvDPRDetail.Load
    '    '   gvDPRDetail.HeaderRow.TableSection = TableRowSection.TableHeader
    'End Sub


    'Private Sub ddlRepdate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRepdate.SelectedIndexChanged
    '    'gvDPRDetail.DataSource = getDBTable(SqlDataSource1.SelectCommand)
    '    'gvDPRDetail.DataBind()
    '    '    Response.Write(SqlDataSource1.SelectCommand.ToString)
    '    reloadGrid()

    'End Sub

    'Private Sub ddlRepdate_Init(sender As Object, e As EventArgs) Handles ddlRepdate.Init
    '    For i As Integer = -7 To 0
    '        '   items.Add(New ListItem(DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"), DateTime.Now.AddDays(i).ToString("yyyy-mm-dd")))
    '        ddlRepdate.Items.Add(New ListItem(DateTime.Now.AddDays(i).ToString("dd.MM.yyyy"), DateTime.Now.AddDays(i).ToString("yyyy-MM-dd")))
    '    Next
    '    '  ddlRepdate.DataSource = items
    '    ddlRepdate.DataBind()
    '    ddlRepdate.Items(7).Selected = True
    '    reloadGrid()
    '    ' 
    '    '  
    'End Sub


    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Dim st_dt = DateTime.ParseExact(dt_stTextBox.Text, "dd.MM.yyyy", Nothing)
        Dim end_dt = DateTime.ParseExact(dt_endTextBox.Text, "dd.MM.yyyy", Nothing)
        If st_dt <= end_dt Then
            'If st_dt = end_dt And RadioButtonList1.SelectedValue = "SMS Report" Then
            '    loadDPR(st_dt, end_dt, "sms = 1")
            'ElseIf st_dt = end_dt And RadioButtonList1.SelectedValue = "Flash Report" Then
            '    loadDPR(Session("network"), st_dt, end_dt, "flash = 1")
            'Else
            ' RadioButtonList1.SelectedIndex = 0
            If chkDownload.Checked = True Then
                loadDPRBio(st_dt, end_dt, "1")
                Exit Sub
            End If
            loadDPR(st_dt, end_dt, "1")
            loadLog(st_dt, end_dt)
            loadLeaveDetails(st_dt, end_dt, "1")


        Else
            divMsg.InnerHtml = "Date range not proper."
        End If


    End Sub
    Private Sub lbDownloadSummary_Click(sender As Object, e As EventArgs) Handles lbDownloadSummary.Click
        saveExcel()
    End Sub



    'Protected Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click
    '    If Not String.IsNullOrEmpty(txtSMS.Text) Then
    '        download2Mail(getDBsingle("select project from NetworkMaster where network = '" & Session("network") & "' limit 1") & dt_stTextBox.Text.Replace(".", "") & ".xls")
    '    Else
    '        DisplayMessage("Please Enter Email Id's seperated with comma")
    '    End If

    'End Sub
    'Function download2Mail(ByVal filename As String)

    '    ' Change the Header Row back to white color
    '    gvDPR.HeaderRow.Style.Add("background-color", "#FFFFFF")
    '    '   gvDPR.Columns.RemoveAt(0)
    '    ' This loop is used to apply stlye to cells based on particular row
    '    For Each gvrow As GridViewRow In gvDPR.Rows
    '        gvrow.BackColor = Drawing.Color.White

    '        If gvrow.Cells(4).Text = "True" Then
    '            gvrow.BackColor = Drawing.Color.Yellow
    '            'For k As Integer = 0 To gvrow.Cells.Count - 1
    '            '    gvrow.Cells(k).Style.Add("background-color", "#EFF3FB")
    '            'Next
    '        End If
    '    Next



    '    Dim path As String = Server.MapPath("~/DPR/")
    '    If Not System.IO.Directory.Exists(path) Then
    '        System.IO.Directory.CreateDirectory(path)
    '    End If
    '    Using sw As New System.IO.StringWriter()
    '        Using hw As New HtmlTextWriter(sw)
    '            Dim writer As System.IO.StreamWriter = System.IO.File.CreateText(path & filename)
    '            gvReport.RenderControl(hw)
    '            writer.WriteLine(sw.ToString())
    '            writer.Close()
    '        End Using
    '    End Using
    '    ' DisplayMessage("xls file generated " & filename)
    '    SendEmail("cpmc@ntpc.co.in", txtSMS.Text, "cpmc2009@gmail.com", "", "SAP DPR:" & filename, "Dear Sir " & vbCrLf & "PFA SAP DPR " & filename, path + filename, "", "cpmc@ntpc.co.in", "cpmc1234")
    '    ' DisplayMessage("xls file generated and mailed " & filename)
    'End Function
    Sub saveExcel()
        ' Change the Header Row back to white color
        gvSummary.HeaderRow.Style.Add("background-color", "#FFFFFF")

        ' This loop is used to apply stlye to cells based on particular row
        'For Each gvrow As GridViewRow In gvReport.Rows
        '    gvrow.BackColor = Drawing.Color.White

        '    If gvrow.Cells(4).Text = "True" Then
        '        gvrow.BackColor = Drawing.Color.Yellow
        '        'For k As Integer = 0 To gvrow.Cells.Count - 1
        '        '    gvrow.Cells(k).Style.Add("background-color", "#EFF3FB")
        '        'Next
        '    End If
        'Next

        Response.ClearContent()

        Response.AddHeader("content-disposition", "attachment; filename=leavesummary" & Now.ToString("ddMy") & ".xls")

        Response.ContentType = "application/excel"

        Dim sWriter As New System.IO.StringWriter()

        Dim hTextWriter As New HtmlTextWriter(sWriter)

        gvSummary.RenderControl(hTextWriter)

        Response.Write(sWriter.ToString())

        Response.End()
        'lblMsg.Text = "Excel created"

        'GridView1.RenderControl(htw)

    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Return
    End Sub

    Private Sub rblReportDuration_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblReportDuration.SelectedIndexChanged
        Dim sel As String = rblReportDuration.SelectedValue
        ' Session("mode") = sel
        divMsg.InnerHtml = "Generating " & sel & " Report"
        ' btnSMS.Visible = False
        'btnEmail.Visible = False
        'txtSMS.Visible = False
        BarChart1.Visible = False

        If sel = "Monthly" Then
            Dim st_dt, end_dt As String
            Dim stDayno = 16 'for ntpc
            If rblOrg.SelectedValue = "NTPC" Then
                stDayno = 16
            Else
                stDayno = 21

            End If
            Dim stdate = New Date(Now.AddMonths(-1).Year, Now.AddMonths(-1).Month, stDayno)
            Dim enddate = New Date(stdate.AddMonths(1).Year, stdate.AddMonths(1).Month, (stDayno - 1))

            dt_stTextBox.Text = stdate.ToString("dd.MM.yyyy")
            dt_endTextBox.Text = enddate.ToString("dd.MM.yyyy")

            loadDPR(stdate, enddate, "1")
            loadLeaveDetails(stdate, enddate, "1")
            loadLog(stdate, enddate)
        ElseIf sel = "Weekly" Then
            Dim lastweek As Date = Now.AddDays(-7)
            'Dim firstweek As Date = New Date(prevDay.Year, prevDay.Month, 7)
            'If prevDay < firstweek Then lastweek = New Date(prevDay.Year, prevDay.Month, 1)

            dt_stTextBox.Text = lastweek.ToString("dd.MM.yyyy")
            dt_endTextBox.Text = Now.ToString("dd.MM.yyyy")
            loadDPR(lastweek, Now, "1")
            loadLeaveDetails(lastweek, Now, "1")
            loadLog(lastweek, Now)

        End If

    End Sub

    Private Sub rblOrg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblOrg.SelectedIndexChanged
        rblReportDuration_SelectedIndexChanged(vbNull, EventArgs.Empty)
    End Sub

    Private Sub rblWorkArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblWorkArea.SelectedIndexChanged
        rblReportDuration_SelectedIndexChanged(vbNull, EventArgs.Empty)
    End Sub

    Private Sub cbShowTime_CheckedChanged(sender As Object, e As EventArgs) Handles cbShowTime.CheckedChanged
        rblReportDuration_SelectedIndexChanged(vbNull, EventArgs.Empty)
    End Sub

    Private Sub cbOnePunch_CheckedChanged(sender As Object, e As EventArgs) Handles cbOnePunch.CheckedChanged
        rblReportDuration_SelectedIndexChanged(vbNull, EventArgs.Empty)
    End Sub

    'Private Sub gvReport_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvReport.RowDataBound
    '    Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(7).Text)
    '    e.Row.Cells(7).Text = decodedText
    'End Sub




    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    If gvReport.Rows.Count > 0 Then

    '        saveExcel()
    '    Else
    '        ' lblMsg.Text = "Please Upload MPP File First."
    '    End If
    'End Sub

End Class
