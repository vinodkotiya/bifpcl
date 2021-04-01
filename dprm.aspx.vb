Imports Common
Imports dbOp
Imports System.Data
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports iTextSharp.tool.xml
Imports System.IO
'Imports DotNet.Highcharts
'Imports DotNet.Highcharts.Options
'Imports DotNet.Highcharts.Options.Series
'Imports DotNet.Highcharts.Attributes
'Imports DotNet.Highcharts.Helpers
'Imports DotNet.Highcharts.Enums
'Imports System.Data
'Imports System.Drawing

Partial Class _dprm
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                '<########## Login MODULE
                'Session("email") = "vinodkotiya@bifpcl.com"
                If Request.Params("mode") = "pd@bifpcl.com" Or Request.Params("mode") = "md@bifpcl.com" Or Request.Params("mode") = "mgmt" Then
                    Session("email") = Request.Params("mode")
                End If
                'If Request.Form.Count = 1 Then
                '    Dim appsecret = "SjY1bBAA5fBIEs2eeJgytb01z6dC/BR479D0jANmlSM="
                '    Session("email") = Decrypt(Request.Form("email"), appsecret)
                '    '  divBug.InnerHtml = Session("email")
                'End If
                '
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343266")
                '########## Login MODULE >>>>>>>>

                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                'If Not (checkAuthorization(Session("email"), "onlybifpcl") Or checkAuthorization(Session("email"), "dprm.aspx")) Then
                '    divBoard.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access DPR.<br/> May please contact TS Dept and provide your email id for authorisation."
                '    Exit Sub
                'End If
                ''''''##########################################

                divMobiSidmenu.InnerHtml = makemenu(True, 2)
                divSidemenu.InnerHtml = makemenu(False, 2, True)
                divBug.InnerHtml = Session("email")
                divLogin.InnerHtml = showAccount(Session("email"), True)
                divLoginMobile.InnerHtml = showAccount(Session("email"), True)
                divNotification.InnerHtml = getNotification(1)
                '   divLogin.InnerHtml = showAccount("9383", "Vinod Kumar Kotiya", "vinodkotiya@ntpc.co.in")
                divLogin.InnerHtml = showAccount(Session("email"))

                loadDPR()
            End If
            '   executeDB("update hits set view = view+1 where page = 'dprm'")
            '  executeDB("insert into login (eid, log, logintime) values (0, 'DPR Mobile Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

            '   loadChart()
        Catch ex As Exception
            divBug.InnerHtml = "May be app secret is wrong" & ex.Message & Request.Form("email")
        End Try
    End Sub
    Sub loadDPR()
        Dim q = ""
        Dim errorPart = ""
        Try

            '  Dim Filter = " and (priority=1  or closed=1)  "
            Dim Filter = "" ' " and priority=1   "
            ' Filter = "  and unit like'%" & rblReportUnit.SelectedValue & "%' and workarea like'%" & ddlReportWorkArea.SelectedValue & "%' " & " and agency like'%" & ddlReportAgency.SelectedValue & "%' " & Filter()

            'Dim q1 = "Select pm.actcode, agency, pm.activity ,  descr As 'Description' ,  pm.um , plan as 'Month Plan', pd.reco as 'Month Reconcile',pm.scope as scope,pp.act as 'Cumm up to date', pp.act as 'Day Progress',  pp.remark as 'Remark' from ProgressMaster pm left join ProgressPlan pd on pm.actcode=pd.actcode   and pd.mon=7 and pd.yr=2018 left join ProgressDetails pp on pm.actcode=pp.actcode where unit=" & rblReportUnit.SelectedValue & " and workarea like'%" & ddlReportWorkArea.SelectedValue & "%' " & filter
            'gvReport.DataSource = getDBTable(q1, "dprdb")
            'gvReport.DataBind()

            Dim startp As DateTime = DateTime.UtcNow.AddDays(-1)
            Dim endp As DateTime = DateTime.UtcNow.AddDays(-1) ' New DateTime(2014, 1, 28)
            Dim CurrD As DateTime = startp
            divDate.InnerHtml = "Report Date:" & endp.ToString("%d.%M.%y")
            Dim enddt = endp ' Year(endp) & "-" & Month(endp).ToString.PadLeft(2, "0") & "-" & Day(endp).ToString.PadLeft(2, "0")

            'Get network data
            q = "select  actcode,  workarea, agency, unit, activity,descr, scope,um, closed, grp from ProgressMaster where (del =0 or del ='' or del is null)  " & Filter & " order by workarea, agency"
            errorPart = "'Get network data" '& q
            Dim nwDT = getDBTable(q, "dprdb")

            If nwDT.Rows.Count = 0 Then
                divMsg.InnerHtml = "No data exist" '& q
                gvReport.DataSource = nwDT
                gvReport.DataBind()
                'Return False
                Exit Sub
            End If
            divMsg.InnerHtml = nwDT.Rows.Count & " Records found for given filters." '& q
            'Get DPR data
            Dim dprDT = getDBTable("select  actcode,  strftime('%d.%m.%Y', progdate) as displaydate, progdate ,act , remark from ProgressDetails where not actcode is null  group by progdate,actcode", "dprdb")
            errorPart = "dprDT"
            'Get cummulative achieved without reconcile
            Dim cummDT = getDBTable("SELECT actcode, ifnull(sum(act),0)  FROM ProgressDetails WHERE  not actcode is null and progdate <= '" & enddt.ToString("yyyy-MM-dd") & "' group by actcode", "dprdb")
            errorPart = "cummDT"
            'Get last montha chieved cummulative  without reconcile
            Dim lastMonthcummDT = getDBTable("SELECT actcode, ifnull(sum(act),0)  FROM ProgressDetails WHERE not actcode is null and progdate <= '" & enddt.AddMonths(-1).ToString("yyyy-MM-dd") & "' group by actcode", "dprdb")

            'Get last monthachieved without reconcile
            Dim lastMonthDT = getDBTable("SELECT actcode, sum(act)  FROM ProgressDetails WHERE not actcode is null and ( cast(strftime('%m',progdate) as decimal) = " & Month(enddt.AddMonths(-1)) & " and cast(strftime('%Y',progdate) as decimal) = " & Year(enddt.AddMonths(-1)) & " ) group by actcode", "dprdb")

            'Get monthly achieved without reconcile
            Dim monthDT = getDBTable("SELECT actcode, sum(act)  FROM ProgressDetails WHERE not actcode is null and ( cast(strftime('%m',progdate) as decimal) = " & Month(enddt) & " and cast(strftime('%Y',progdate) as decimal) = " & Year(enddt) & " ) group by actcode", "dprdb")
            'Get weekly achieved without reconcile
            Dim week1 As Date = New Date(enddt.Year, enddt.Month, 7)
            Dim week2 As Date = New Date(enddt.Year, enddt.Month, 14)
            Dim week3 As Date = New Date(enddt.Year, enddt.Month, 21)
            Dim week4 As Date = New Date(enddt.Year, enddt.Month, Date.DaysInMonth(enddt.Year, enddt.Month))
            Dim week1DT = getDBTable("SELECT actcode, sum(act)  FROM ProgressDetails WHERE not actcode is null and ( progdate  > '" & week1.AddDays(-7).ToString("yyyy-MM-dd") & "' and progdate <= '" & week1.ToString("yyyy-MM-dd") & "' ) group by actcode", "dprdb")
            Dim week2DT = getDBTable("SELECT actcode, sum(act)  FROM ProgressDetails WHERE not actcode is null and ( progdate  > '" & week2.AddDays(-7).ToString("yyyy-MM-dd") & "' and progdate <= '" & week2.ToString("yyyy-MM-dd") & "' ) group by actcode", "dprdb")
            Dim week3DT = getDBTable("SELECT actcode, sum(act)  FROM ProgressDetails WHERE not actcode is null and ( progdate  > '" & week3.AddDays(-7).ToString("yyyy-MM-dd") & "' and progdate <= '" & week3.ToString("yyyy-MM-dd") & "' ) group by actcode", "dprdb")
            Dim week4DT = getDBTable("SELECT actcode, sum(act)  FROM ProgressDetails WHERE not actcode is null and ( progdate  > '" & week4.AddDays(-7).ToString("yyyy-MM-dd") & "' and progdate <= '" & week4.ToString("yyyy-MM-dd") & "' ) group by actcode", "dprdb")
            Dim D21 = getDBTable("SELECT actcode, sum(act)  FROM ProgressDetails WHERE  not actcode is null and ( progdate  <= '" & enddt.AddDays(-21).ToString("yyyy-MM-dd") & "' )  group by actcode", "dprdb")
            errorPart = "week4DT"
            'Get plan month
            Dim targetDT = getDBTable("SELECT actcode, plan  FROM ProgressPlan WHERE  mon = " & Month(enddt) & " and yr = " & Year(enddt) & " group by actcode", "dprdb")

            'Get reconcile up to date, which will be added to cummulative 
            Dim reconcileDT = getDBTable("SELECT actcode, ifnull(sum(reco),0)  FROM ProgressPlan WHERE 1  group by actcode", "dprdb")

            Dim finalDT1 As New System.Data.DataTable()



            '''####### Creating Columns
            '''
            finalDT1.Columns.Add("ActCode")
            finalDT1.Columns.Add("WorkArea")
            finalDT1.Columns.Add("U")
            finalDT1.Columns.Add("Agency")
            finalDT1.Columns.Add("Activity")
            finalDT1.Columns.Add("Descr")
            finalDT1.Columns.Add("UM")
            finalDT1.Columns.Add("Scope")
            finalDT1.Columns.Add("Group")
            finalDT1.Columns.Add("CummReconciled")
            finalDT1.Columns.Add("CummAchWORecon")
            finalDT1.Columns.Add("CummAch")
            finalDT1.Columns.Add("LastMonthCumm")
            finalDT1.Columns.Add("LastMonthAch")
            finalDT1.Columns.Add("MonthTgt")
            finalDT1.Columns.Add("MonthAch")
            finalDT1.Columns.Add("Week1")
            finalDT1.Columns.Add("Week2")
            finalDT1.Columns.Add("Week3")
            finalDT1.Columns.Add("Week4")
            finalDT1.Columns.Add("Cumm_21")
            finalDT1.Columns.Add("Balance")
            While (CurrD <= endp)
                finalDT1.Columns.Add(CurrD.ToString("dd.MM.yy"))
                If CurrD = endp Then finalDT1.Columns.Add("Remarks")
                CurrD = CurrD.AddDays(1)

            End While
            For Each nwRow In nwDT.Rows

                Dim rowStr = ""
                Dim tmpRow = finalDT1.NewRow

                tmpRow("U") = nwRow("unit")
                tmpRow("WorkArea") = nwRow("workarea")
                tmpRow("Agency") = nwRow("agency")
                tmpRow("Activity") = nwRow("activity")
                tmpRow("Descr") = nwRow("descr")
                tmpRow("Group") = nwRow("grp")
                tmpRow("Scope") = nwRow("scope")
                tmpRow("UM") = nwRow("um")
                tmpRow("ActCode") = nwRow("actcode")
                errorPart = " tmpRow(ActCode"
                '' insert cumm achieved data
                Dim cummAchievedRow = cummDT.Select("actcode = " & nwRow("actcode"))
                Dim cummAch As Double = If(cummAchievedRow.Length = 1, cummAchievedRow(0)(1), 0)
                tmpRow("CummAchWORecon") = cummAch.ToString
                '' insert month target data
                Dim cummTargetRow = targetDT.Select("actcode = " & nwRow("actcode"))
                tmpRow("MonthTgt") = If(cummTargetRow.Length = 1, cummTargetRow(0)(1), 0)
                '' insert last month cumm achieved data
                Dim lastmonCummRow = lastMonthcummDT.Select("actcode = " & nwRow("actcode"))
                tmpRow("LastMonthCumm") = If(lastmonCummRow.Length = 1, lastmonCummRow(0)(1), 0)
                '' insert last month achieved data
                Dim lastmonAchRow = lastMonthDT.Select("actcode = " & nwRow("actcode"))
                tmpRow("LastMonthAch") = If(lastmonAchRow.Length = 1, lastmonAchRow(0)(1), 0)
                '' insert month achieved data
                Dim monAchRow = monthDT.Select("actcode = " & nwRow("actcode"))
                tmpRow("MonthAch") = If(monAchRow.Length = 1, monAchRow(0)(1), 0)
                '' insert week achieved data
                Dim week1AchRow = week1DT.Select("actcode = " & nwRow("actcode"))
                tmpRow("week1") = If(week1AchRow.Length = 1, week1AchRow(0)(1), 0)
                Dim week2AchRow = week2DT.Select("actcode = " & nwRow("actcode"))
                tmpRow("week2") = If(week2AchRow.Length = 1, week2AchRow(0)(1), 0)
                Dim week3AchRow = week3DT.Select("actcode = " & nwRow("actcode"))
                tmpRow("week3") = If(week3AchRow.Length = 1, week3AchRow(0)(1), 0)
                Dim week4AchRow = week4DT.Select("actcode = " & nwRow("actcode"))
                tmpRow("week4") = If(week4AchRow.Length = 1, week4AchRow(0)(1), 0)
                Dim D21AchRow = D21.Select("actcode = " & nwRow("actcode"))
                tmpRow("Cumm_21") = If(D21AchRow.Length = 1, D21AchRow(0)(1), 0)
                errorPart = " tmpRow(week4"
                '' insert cumm Reconciled data
                Dim cummRecoRow = reconcileDT.Select("actcode = " & nwRow("actcode"))
                Dim CummReconciled As Double = If(cummRecoRow.Length = 1, cummRecoRow(0)(1), 0)
                tmpRow("CummReconciled") = CummReconciled.ToString
                tmpRow("CummAch") = CummReconciled + cummAch
                tmpRow("Balance") = Double.Parse(If(IsDBNull(nwRow("scope")), 0, nwRow("scope"))) - Double.Parse(If(IsDBNull(tmpRow("CummAch")), 0, tmpRow("CummAch")))
                errorPart = " tmpRow(Balance"
                CurrD = startp
                '## Loop throu all dates for each activity
                While (CurrD <= endp)
                    Dim dr = dprDT.Select(" progdate = '" & CurrD.ToString("yyyy-MM-dd") & "' and actcode = " & nwRow("actcode"))
                    If dr.Length = 1 Then
                        tmpRow(CurrD.ToString("dd.MM.yy")) = dr(0)("act")
                        tmpRow("Remarks") = dr(0)("remark")
                    Else
                        tmpRow(CurrD.ToString("dd.MM.yy")) = 0
                        ' tmpRow(CurrD.ToString("dd.MM.yy")) = If(dprtype = "BHT", "0", "")
                    End If
                    If CurrD = endp Then 'And dr.Length = 1 Then

                        If nwRow("closed").ToString.Contains("1") Then
                            tmpRow("Remarks") = "Completed"
                        End If
                        'ElseIf tmpRow("CummAch").ToString = "0" Then
                        '    tmpRow("Remarks") = "Work Yet to Start" '''Work Yet to Start
                        'Else
                        '    tmpRow("Remarks") = ""
                    End If

                    CurrD = CurrD.AddDays(1)
                End While

                finalDT1.Rows.Add(tmpRow)

            Next


            Dim result1 = From row In finalDT1.AsEnumerable()
                          Group row By _group = New With {
                          Key .Agency = row.Field(Of String)("Agency"),
                         Key .grp = row.Field(Of String)("Group")} Into g = Group
                          Select New With {Key .Agency = _group.Agency, Key .WorkArea = g.Select(Function(x) x.Field(Of String)("WorkArea"))(0), Key .Descr = g.Select(Function(x) x.Field(Of String)("Descr"))(0), Key .UM = g.Select(Function(x) x.Field(Of String)("UM"))(0),
    Key .Scope = g.Sum(Function(x) If(IsDBNull(x("Scope")), 0, x("Scope"))),
   Key .CummAch = g.Sum(Function(x) If(IsDBNull(x("CummAch")), 0, x("CummAch"))), Key .Cumm_21 = g.Sum(Function(x) If(IsDBNull(x("Cumm_21")), 0, x("Cumm_21"))),
    Key .MonthTgt = g.Sum(Function(x) If(IsDBNull(x("MonthTgt")), 0, x("MonthTgt"))),
                         Key .MonthAch = g.Sum(Function(x) If(IsDBNull(x("MonthAch")), 0, x("MonthAch"))),
                         Key .Week1 = g.Sum(Function(x) If(IsDBNull(x("Week1")), 0, x("Week1"))),
                         Key .Week2 = g.Sum(Function(x) If(IsDBNull(x("Week2")), 0, x("Week2"))),
                         Key .Week3 = g.Sum(Function(x) If(IsDBNull(x("Week3")), 0, x("Week3"))),
                         Key .Week4 = g.Sum(Function(x) If(IsDBNull(x("Week4")), 0, x("Week4"))),
                        Key .DayProg = g.Sum(Function(x) If(IsDBNull(x(endp.ToString("dd.MM.yy"))), 0, x(endp.ToString("dd.MM.yy")))),
                         Key .Balance = g.Sum(Function(x) If(IsDBNull(x("Balance")), 0, x("Balance"))),
                               Key .Group = g.Select(Function(x) x.Field(Of String)("Group"))(0)
        }   ',        Key.Content = String.Join(",", g.Select(Function(x) x.Field(Of String)("Agency")))
            ' Dim boundTable As DataTable = result.CopyToDataTable()
            result1.OrderBy(Function(o) (o.Agency)).ToList()
            'gvReportVendor.DataBind()
            Dim dtResult1 = ConvertIEnumerableToDataTable(result1)
            '   dtResult1.Columns.Add("Precast_Avl_Today", GetType(Double), "CummAch - Cumm_21")
            errorPart = " Linq Vendor wise custom report "

            ''' summation for Vendor wise summary
            ''' 

            Dim cols1() As String = {"Agency", "Descr", "Scope", "CummAch", "MonthAch", "DayProg", "Balance", "UM", "Group"}
            '  Dim progdate = endp.ToString("dd.MM.yy")
            Dim mydt = CustomReport(dtResult1).DefaultView.ToTable(True, cols1)  ''Converts ienumerable to datatable
            Dim bhtCol As New System.Data.DataColumn("Cumm/Month/Day")
            bhtCol.Expression = String.Format("{0}+'/'+{1}+'/'+{2}+' '+{3}", "CummAch", "MonthAch", "DayProg", "UM")
            mydt.Columns.Add(bhtCol)
            Dim bhtCol1 As New System.Data.DataColumn("Detail")
            Dim finalcol() As String = {"Detail", "Cumm/Month/Day"}
            bhtCol1.Expression = String.Format("{0}+'-'+{1}", "Agency", "Descr")
            mydt.Columns.Add(bhtCol1)
            gvReportVendorGroup.DataSource = mydt.DefaultView.ToTable(True, finalcol)
            gvReportVendorGroup.DataBind()
            errorPart = " Linq Vendor wise summary"

            ' finalDT1.Columns.Add("Cumm/Day/Balance", GetType(String), "[CummAch] + '" & vbCrLf & "' + [DayProg] + '" & vbCrLf & "' + [Balance]")
            'Dim cols() As String = {"Agency", "Activity", "Descr", "CummAch", "MonthAch", endp.ToString("dd.MM.yy"), "Balance", "UM", "Group"}
            'Dim mydt1 = finalDT1.DefaultView.ToTable(True, cols)
            'mydt1.Columns(endp.ToString("dd.MM.yy")).ColumnName = "DayProg"
            'Dim bhtCol11 As New System.Data.DataColumn("Cumm/Month/Day/Balance")
            'bhtCol11.Expression = String.Format("{0}+'/'+{1}+'/'+{2}+'/'+{3}+' '+{4}", "CummAch", "MonthAch", "DayProg", "Balance", "UM")
            'mydt1.Columns.Add(bhtCol11)
            'Dim bhtCol12 As New System.Data.DataColumn("Detail")
            'Dim finalcol1() As String = {"Detail", "Cumm/Month/Day/Balance"}
            'bhtCol12.Expression = String.Format("{0}+'-'+{1}+' '+{2}", "Agency", "Activity", "Descr")
            'mydt1.Columns.Add(bhtCol12)
            ' gvReport.DataSource = mydt1.DefaultView.ToTable(True, finalcol1)
            Dim qDayProg = "select   activity || ' ' || descr || ' ' || um || ' ' ||  agency as 'Activity'  ,    act as 'DayProg' from ProgressMaster p, ProgressDetails d on p.actcode = d.actcode where not d.actcode is null and progdate = '" & enddt.ToString("yyyy-MM-dd") & "' order by agency"
            gvReport.DataSource = getDBTable(qDayProg, "dprdb")
            gvReport.DataBind()


            Dim dtVendor = CustomReport(dtResult1)
            Dim resultVendor = From row In dtVendor.AsEnumerable()
                               Group row By _group = New With {
                          Key .Descr = row.Field(Of String)("Descr")} Into g = Group
                               Select New With {Key .Descr = _group.Descr, Key .UM = g.Select(Function(x) x.Field(Of String)("UM"))(0),
    Key .Scope = g.Sum(Function(x) If(IsDBNull(x("Scope")), 0, x("Scope"))),
   Key .CummAch = g.Sum(Function(x) If(IsDBNull(x("CummAch")), 0, x("CummAch"))),
                                      Key .MonthTgt = g.Sum(Function(x) If(IsDBNull(x("MonthTgt")), 0, x("MonthTgt"))),
                         Key .MonthAch = g.Sum(Function(x) If(IsDBNull(x("MonthAch")), 0, x("MonthAch"))),
                         Key .Week1 = g.Sum(Function(x) If(IsDBNull(x("Week1")), 0, x("Week1"))),
                         Key .Week2 = g.Sum(Function(x) If(IsDBNull(x("Week2")), 0, x("Week2"))),
                         Key .Week3 = g.Sum(Function(x) If(IsDBNull(x("Week3")), 0, x("Week3"))),
                         Key .Week4 = g.Sum(Function(x) If(IsDBNull(x("Week4")), 0, x("Week4"))),
                       Key .DayProg = g.Sum(Function(x) If(IsDBNull(x("DayProg")), 0, x("DayProg"))),
                         Key .Balance = g.Sum(Function(x) If(IsDBNull(x("Balance")), 0, x("Balance")))
        }   ',        Key.Content = String.Join(",", g.Select(Function(x) x.Field(Of String)("Agency")))
            '     Key .Cumm_21 = g.Sum(Function(x) If(IsDBNull(x("Cumm_21")), 0, x("Cumm_21"))),
            ''''' Getting result using where clause
            ''' Structure erection data
            Dim dtStructureErection = From row In dtResult1.AsEnumerable().Where(Function(x) ((x("Group") = "101" Or x("Group") = "7501" Or x("Group") = "15001" Or x("Group") = "15002" Or x("Group") = "15003")))
                                      Group row By _group = New With {
                      Key .UM = row.Field(Of String)("UM")} Into g = Group
                                      Select New With {Key .Agency = "Structure Erection", Key .UM = g.Select(Function(x) x.Field(Of String)("UM"))(0),
   Key .Scope = g.Sum(Function(x) If(IsDBNull(x("Scope")), 0, x("Scope"))),
                              Key .CummAch = g.Sum(Function(x) If(IsDBNull(x("CummAch")), 0, x("CummAch"))),
                Key .MonthTgt = g.Sum(Function(x) If(IsDBNull(x("MonthTgt")), 0, x("MonthTgt"))),
                         Key .MonthAch = g.Sum(Function(x) If(IsDBNull(x("MonthAch")), 0, x("MonthAch"))),
                         Key .Week1 = g.Sum(Function(x) If(IsDBNull(x("Week1")), 0, x("Week1"))),
                         Key .Week2 = g.Sum(Function(x) If(IsDBNull(x("Week2")), 0, x("Week2"))),
                         Key .Week3 = g.Sum(Function(x) If(IsDBNull(x("Week3")), 0, x("Week3"))),
                         Key .Week4 = g.Sum(Function(x) If(IsDBNull(x("Week4")), 0, x("Week4"))),
                       Key .DayProg = g.Sum(Function(x) If(IsDBNull(x("DayProg")), 0, x("DayProg"))),
                         Key .Balance = g.Sum(Function(x) If(IsDBNull(x("Balance")), 0, x("Balance")))
          } Order By "grp" Descending
            Dim dtResultVendor = ConvertIEnumerableToDataTable(resultVendor)
            Dim RemoteTable = ConvertIEnumerableToDataTable(dtStructureErection)
            Dim row1 As DataRow
            '' Mwerging both tables.
            For Each row1 In RemoteTable.Rows
                dtResultVendor.LoadDataRow(row1.ItemArray, False)
            Next
            ' Dim boundTable As DataTable = result.CopyToDataTable()
            Try
                Dim cols22() As String = {"Descr", "Scope", "CummAch", "MonthAch", "DayProg", "UM"}
                '  Dim progdate = endp.ToString("dd.MM.yy")
                ' Dim resultDT = ConvertIEnumerableToDataTable(resultVendor).DefaultView.ToTable(True, cols22)  ''Converts ienumerable to datatable
                Dim resultDT = dtResultVendor.DefaultView.ToTable(True, cols22)  ''Converts ienumerable to datatable
                Dim bhtCol22 As New System.Data.DataColumn("Scope/Cumm/Month/Day")
                bhtCol22.Expression = String.Format("{0}+'/'+{1}+'/'+{2}+'/'+{3}+' '+{4}", "Scope", "CummAch", "MonthAch", "DayProg", "UM")
                resultDT.Columns.Add(bhtCol22)
                Dim finalcol22() As String = {"Descr", "Scope/Cumm/Month/Day"}
                gvReportTotal.DataSource = resultDT.DefaultView.ToTable(True, finalcol22) '.OrderBy(Function(o) (o.Agency)).ToList()
                gvReportTotal.DataBind()
            Catch ex22 As Exception
                divMsg.InnerHtml = ex22.Message
            End Try

        Catch ex As Exception
                divMsg.InnerHtml = "Error after  " & errorPart & ex.Message & q
        End Try
    End Sub
    Protected Sub ExportToPDF(sender As Object, e As EventArgs)
        Using sw As New StringWriter()
            Using hw As New HtmlTextWriter(sw)
                divDate.RenderControl(hw)
                gvReportVendorGroup.RenderControl(hw)
                hw.WriteLine("<br/>" & vbCrLf)
                gvReportTotal.RenderControl(hw)
                hw.WriteLine("<br/>" & vbCrLf)
                gvReport.RenderControl(hw)
                Dim line = New Phrase("For internal use only. System Generated Report by " & Session("email").ToString & ". © www.bifpcl.com " & vbCrLf & " Timestamp:" & DateTime.UtcNow & " UTC")
                Dim sr As New StringReader(sw.ToString())
                Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
                Dim writer As PdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
                pdfDoc.Open()
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr)
                pdfDoc.Add(line)
                pdfDoc.Close()
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "attachment;filename=DPR" & Now.ToString("%d%M%y") & ".pdf")
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.Write(pdfDoc)
                Response.End()
            End Using
        End Using
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered
    End Sub


End Class
