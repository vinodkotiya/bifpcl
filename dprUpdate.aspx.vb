Imports System.Data
Imports AjaxControlToolkit
Imports dbOp
Imports Common
Imports System.IO

Partial Class dprUpdate
    Inherits System.Web.UI.Page
    Private Sub dpr_entry_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim admin = False
        If Not IsPostBack Then

            '<<<<<<<<<########## Login MODULE
            If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343266")
            '########## Login MODULE >>>>>>>>

            'If (Session("email").ToString.Contains("prakashcn") Or Session("email").ToString.Contains("vinodkotiya@bifpcl") Or Session("email").ToString.Contains("rashedul@bifpcl.com") Or Session("email").ToString.Contains("rudayashankar@bifpcl") Or Session("email").ToString.Contains("anupam.kumar")) Then
            '    admin = True
            'End If
            'Dim qry_project As String = "Select distinct pk.project t,pk.project v from Packages pk  where pk.project in (select distinct u.project from Projects_ntpc p, Units u , MileStones m where p.projectname = u.project and u.project=m.project and u.unit = m.unit and milestone= 'COD'  and achieved <>'A' and (u.zerodate ='' or not isnull(u.zerodate)) and p.region not in ('REDG','IJV')) order by pk.project "
            Dim qry_project As String = "Select distinct workarea as t, workarea as v from ProgressMaster where unit =" & rblUnit.SelectedValue
            ddlWorkArea.DataSource = getDBTable(qry_project, "dprdb")
            ddlWorkArea.DataTextField = "t"
            ddlWorkArea.DataValueField = "v"
            ddlWorkArea.DataBind()
            reloadGrid()
            gvPlan.Visible = False
            If Request.QueryString("mode") = "plan" Then
                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                If Not (checkAuthorization(Session("email"), "dprUpdate.aspx?mode=plan")) Then
                    gvDPRDetail.Visible = False
                    gvPlan.Visible = False
                    diverr.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access DPR.<br/> May please contact TS Dept and provide your email id for authorisation."
                    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied DPR Update Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    Exit Sub
                End If
                ''''''##########################################
                'lvDPRMaster.Visible = True
                gvDPRDetail.Visible = False
                gvPlan.Visible = True
                ddlMonth.Visible = True
                ddlYear.Visible = True
                'ddlMonth.Items.Add(New ListItem("dfdfd", 1))
                For i = 1 To 12 Step 1
                    '   items.Add(New ListItem(DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"), DateTime.Now.AddDays(i).ToString("yyyy-mm-dd")))
                    ddlMonth.Items.Add(New ListItem(MonthName(i), i))
                Next
                '  ddlRepdate.DataSource = items
                '  ddlMonth.DataBind()
                ddlMonth.SelectedValue = Now.Month

                For i = 2017 To Now.Year Step 1
                    '   items.Add(New ListItem(DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"), DateTime.Now.AddDays(i).ToString("yyyy-mm-dd")))
                    ddlYear.Items.Add(New ListItem(i, i))
                Next
                '  ddlRepdate.DataSource = items
                ddlYear.DataBind()
                ddlYear.SelectedValue = Now.Year
                reloadGridPlan()
                executeDB("insert into login (eid, log, logintime) values (0, 'Access DPR Activity Planning Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

            ElseIf Request.QueryString("mode") = "report" Then
                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                If Not (checkAuthorization(Session("email"), "onlybifpcl") Or checkAuthorization(Session("email"), "dprUpdate.aspx?mode=report")) Then
                    gvDPRDetail.Visible = False
                    gvPlan.Visible = False
                    diverr.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access DPR.<br/> May please contact TS Dept and provide your email id for authorisation."
                    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied DPR Update Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    Exit Sub
                End If
                ''''''##########################################
                pnlAdd.Visible = False
                pnlUpdate.Visible = False
                pnlReport.Visible = True
                rblReportDuration_SelectedIndexChanged(vbNull, EventArgs.Empty)
                reloadDDL()
                executeDB("insert into login (eid, log, logintime) values (0, 'Access DPR Report Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

            ElseIf Request.QueryString("mode") = "add" Then
                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                If Not (checkAuthorization(Session("email"), "dprUpdate.aspx?mode=add")) Then
                    gvDPRDetail.Visible = False
                    gvPlan.Visible = False
                    diverr.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access DPR.<br/> May please contact TS Dept and provide your email id for authorisation."
                    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied DPR Update Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    Exit Sub
                End If
                ''''''##########################################
                pnlAdd.Visible = True
                pnlUpdate.Visible = False
                pnlReport.Visible = False
                Dim q As String = "Select distinct workarea as t, workarea as v from ProgressMaster where 1"
                ddlAddWork.DataTextField = "t"
                ddlAddWork.DataValueField = "v"
                ddlAddWork.DataSource = getDBTable(q, "dprdb")
                ddlAddWork.DataBind()
                ddlAddWork.Items.Add(New ListItem("Add new work area", "%"))
                '   ddlAddWork.SelectedValue = "%"
                'Else
                '    Response.Redirect("dprUpdate.aspx")
                executeDB("insert into login (eid, log, logintime) values (0, 'Access DPR Activity Addition Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
            ElseIf Request.QueryString("mode") = "master" Then
                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                If Not (checkAuthorization(Session("email"), "dprUpdate.aspx?mode=master")) Then
                    gvDPRDetail.Visible = False
                    gvPlan.Visible = False
                    diverr.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access DPR.<br/> May please contact TS Dept and provide your email id for authorisation."
                    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied DPR Update Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    Exit Sub
                End If
                ''''''##########################################
            End If
            'If admin = False Then
            '    gvDPRDetail.Visible = False
            '    gvPlan.Visible = False
            '    divMsg.InnerHtml = "You are not authorised for this section."
            '    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied DPR Update Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

            'End If
        End If

    End Sub
    Sub reloadDDL()
        Dim q As String = "Select distinct workarea as t, workarea as v from ProgressMaster where unit like '%" & rblReportUnit.SelectedValue & "%'"
        ddlReportWorkArea.DataTextField = "t"
        ddlReportWorkArea.DataValueField = "v"
        ddlReportWorkArea.DataSource = getDBTable(q, "dprdb")
        ddlReportWorkArea.DataBind()
        ddlReportWorkArea.Items.Add(New ListItem("Show All", "%"))
        ddlReportWorkArea.SelectedValue = "%"
        q = "Select distinct agency as t, agency as v from ProgressMaster where unit like '%" & rblReportUnit.SelectedValue & "%'"
        ddlReportAgency.DataTextField = "t"
        ddlReportAgency.DataValueField = "v"
        ddlReportAgency.DataSource = getDBTable(q, "dprdb")
        ddlReportAgency.DataBind()
        ddlReportAgency.Items.Add(New ListItem("Show All", "%"))
        ddlReportAgency.SelectedValue = "%"
    End Sub
    Private Function loadDPR(ByVal startdate As Date, ByVal enddate As Date, ByVal filter As String, Optional ByVal dprtype As String = "DPR") As Boolean



        Dim q = ""
        Dim errorPart = ""
        Dim grp = ""
        Try
            If rblFilter.SelectedValue = 1 Then
                filter = " and priority=1 "
            ElseIf rblFilter.SelectedValue = 2 Then
                filter = " and closed=1 "
            ElseIf rblFilter.SelectedValue = 3 Then
                filter = " and (priority=1  or closed=1) "
            ElseIf rblFilter.SelectedValue = 4 Then
                filter = "  and 1 "
            End If

            Dim selected As List(Of ListItem) = cblGroup.Items.Cast(Of ListItem)().Where(Function(li) li.Selected).ToList()
            Dim commaseparatedvalue = String.Join(", ", From item In selected Select item.Value)
            'diverr.InnerHtml = commaseparatedvalue
            'Return False
            If commaseparatedvalue.Contains("%") Then
                grp = ""
            Else
                grp = " and grp in ( " & commaseparatedvalue & ") "
            End If

            filter = "  and unit like'%" & rblReportUnit.SelectedValue & "%' and workarea like'%" & ddlReportWorkArea.SelectedValue & "%' " & " and agency like'%" & ddlReportAgency.SelectedValue & "%' " & filter & grp

            'Dim q1 = "Select pm.actcode, agency, pm.activity ,  descr As 'Description' ,  pm.um , plan as 'Month Plan', pd.reco as 'Month Reconcile',pm.scope as scope,pp.act as 'Cumm up to date', pp.act as 'Day Progress',  pp.remark as 'Remark' from ProgressMaster pm left join ProgressPlan pd on pm.actcode=pd.actcode   and pd.mon=7 and pd.yr=2018 left join ProgressDetails pp on pm.actcode=pp.actcode where unit=" & rblReportUnit.SelectedValue & " and workarea like'%" & ddlReportWorkArea.SelectedValue & "%' " & filter
            'gvReport.DataSource = getDBTable(q1, "dprdb")
            'gvReport.DataBind()

            Dim startp As DateTime = startdate  'New DateTime(2013, 12, 1)
            Dim endp As DateTime = enddate ' New DateTime(2014, 1, 28)
            Dim CurrD As DateTime = startp

            Dim enddt = endp ' Year(endp) & "-" & Month(endp).ToString.PadLeft(2, "0") & "-" & Day(endp).ToString.PadLeft(2, "0")

            'Get network data
            q = "select  actcode,  workarea, agency, unit, activity,descr, scope,um, closed, grp from ProgressMaster where (del =0 or del ='' or del is null)  " & filter & " order by workarea, agency"
            ' divMsg.InnerHtml = q
            Dim nwDT = getDBTable(q, "dprdb")

            If nwDT.Rows.Count = 0 Then
                divMsg.InnerHtml = "No data exist" '& q
                gvReport.DataSource = nwDT
                gvReport.DataBind()
                Return False
            End If
            divMsg.InnerHtml = nwDT.Rows.Count & " Records found for given filters." '& q
            'Get DPR data
            Dim dprDT = getDBTable("select  actcode,  strftime('%d.%m.%Y', progdate) as displaydate, progdate ,act , remark from ProgressDetails where not actcode is null   group by progdate,actcode", "dprdb")
            errorPart = "dprDT"
            'Get cummulative achieved without reconcile
            ' q = "SELECT actcode, ifnull(sum(act),0)  FROM ProgressDetails WHERE progdate >= '" & CurrD.ToString("yyyy-MM-dd") & "' and progdate <= '" & enddt.ToString("yyyy-MM-dd") & "' group by actcode"
            'If CurrD = enddt Then
            q = "SELECT actcode, ifnull(sum(act),0)  FROM ProgressDetails WHERE not actcode is null and progdate <= '" & enddt.ToString("yyyy-MM-dd") & "' group by actcode"
            Dim cummDT = getDBTable(q, "dprdb")
            'Get cummulative achieved for selected period without reconcile
            q = "SELECT actcode, ifnull(sum(act),0)  FROM ProgressDetails WHERE not actcode is null and (progdate >= '" & CurrD.ToString("yyyy-MM-dd") & "' and progdate <= '" & enddt.ToString("yyyy-MM-dd") & "' ) group by actcode"
            If CurrD = enddt Then q = "SELECT actcode, ifnull(sum(act),0)  FROM ProgressDetails WHERE not actcode is null and progdate <= '" & enddt.ToString("yyyy-MM-dd") & "' group by actcode"
            Dim cummPeriodDT = getDBTable(q, "dprdb")

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
            Dim D21 = getDBTable("SELECT actcode, sum(act)  FROM ProgressDetails WHERE not actcode is null and ( progdate  <= '" & enddt.AddDays(-18).ToString("yyyy-MM-dd") & "' ) group by actcode", "dprdb")
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
            finalDT1.Columns.Add("CummPeriod")
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
                Dim cummAchievedPeriodRow = cummPeriodDT.Select("actcode = " & nwRow("actcode"))
                Dim cummAchPeriod As Double = If(cummAchievedPeriodRow.Length = 1, cummAchievedPeriodRow(0)(1), 0)
                tmpRow("cummPeriod") = cummAchPeriod.ToString
                tmpRow("Balance") = Double.Parse(If(IsDBNull(nwRow("scope")), 0, nwRow("scope"))) - Double.Parse(If(IsDBNull(tmpRow("CummAch")), 0, tmpRow("CummAch")))
                errorPart = " tmpRow(Balance"
                CurrD = startp
                '## Loop through all dates for each activity
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
            ''' summation for activity wise
            ''' 

            Dim result = From row In finalDT1.AsEnumerable()
                         Group row By _group = New With {Key .Id = row.Field(Of String)("WorkArea"),
                          Key .Agency = row.Field(Of String)("Agency"),
                         Key .grp = row.Field(Of String)("Group")} Into g = Group
                         Select New With {Key .WorkArea = _group.Id, Key .Agency = _group.Agency, Key .Descr = g.Select(Function(x) x.Field(Of String)("Descr"))(0), Key .UM = g.Select(Function(x) x.Field(Of String)("UM"))(0),
    Key .Scope = g.Sum(Function(x) If(IsDBNull(x("Scope")), 0, x("Scope"))),
   Key .CummAch = g.Sum(Function(x) If(IsDBNull(x("CummAch")), 0, x("CummAch"))),
                                       Key .Cumm_21 = g.Sum(Function(x) If(IsDBNull(x("Cumm_21")), 0, x("Cumm_21"))),
 Key .MonthTgt = g.Sum(Function(x) If(IsDBNull(x("MonthTgt")), 0, x("MonthTgt"))),
                         Key .MonthAch = g.Sum(Function(x) If(IsDBNull(x("MonthAch")), 0, x("MonthAch"))),
                         Key .Week1 = g.Sum(Function(x) If(IsDBNull(x("Week1")), 0, x("Week1"))),
                         Key .Week2 = g.Sum(Function(x) If(IsDBNull(x("Week2")), 0, x("Week2"))),
                         Key .Week3 = g.Sum(Function(x) If(IsDBNull(x("Week3")), 0, x("Week3"))),
                         Key .Week4 = g.Sum(Function(x) If(IsDBNull(x("Week4")), 0, x("Week4"))),
                          Key .DayProg = g.Sum(Function(x) If(IsDBNull(x(endp.ToString("dd.MM.yy"))), 0, x(endp.ToString("dd.MM.yy")))),
                         Key .Balance = g.Sum(Function(x) If(IsDBNull(x("Balance")), 0, x("Balance")))
        }   ',        Key.Content = String.Join(",", g.Select(Function(x) x.Field(Of String)("Agency")))
            ' Dim boundTable As DataTable = result.CopyToDataTable()
            gvReportSummary.DataSource = result
            gvReportSummary.DataBind()
            errorPart = " Linq activity wise"
            ''' summation for Vendor wise
            ''' 

            Dim result1 = From row In finalDT1.AsEnumerable()
                          Group row By _group = New With {
                          Key .Agency = row.Field(Of String)("Agency"),
                         Key .grp = row.Field(Of String)("Group")} Into g = Group
                          Select New With {Key .Agency = _group.Agency, Key .Group = g.Select(Function(x) x.Field(Of String)("Group"))(0), Key .Descr = g.Select(Function(x) x.Field(Of String)("Descr"))(0), Key .UM = g.Select(Function(x) x.Field(Of String)("UM"))(0),
    Key .Scope = g.Sum(Function(x) If(IsDBNull(x("Scope")), 0, x("Scope"))),
   Key .CummAch = g.Sum(Function(x) If(IsDBNull(x("CummAch")), 0, x("CummAch"))),
                                       Key .Cumm_21 = g.Sum(Function(x) If(IsDBNull(x("Cumm_21")), 0, x("Cumm_21"))),
  Key .MonthTgt = g.Sum(Function(x) If(IsDBNull(x("MonthTgt")), 0, x("MonthTgt"))),
                         Key .MonthAch = g.Sum(Function(x) If(IsDBNull(x("MonthAch")), 0, x("MonthAch"))),
                         Key .Week1 = g.Sum(Function(x) If(IsDBNull(x("Week1")), 0, x("Week1"))),
                         Key .Week2 = g.Sum(Function(x) If(IsDBNull(x("Week2")), 0, x("Week2"))),
                         Key .Week3 = g.Sum(Function(x) If(IsDBNull(x("Week3")), 0, x("Week3"))),
                         Key .Week4 = g.Sum(Function(x) If(IsDBNull(x("Week4")), 0, x("Week4"))),
                        Key .DayProg = g.Sum(Function(x) If(IsDBNull(x(endp.ToString("dd.MM.yy"))), 0, x(endp.ToString("dd.MM.yy")))),
                         Key .Balance = g.Sum(Function(x) If(IsDBNull(x("Balance")), 0, x("Balance")))
         }   ',        Key.Content = String.Join(",", g.Select(Function(x) x.Field(Of String)("Agency")))
            ' Dim boundTable As DataTable = result.CopyToDataTable()
            result1 = result1.OrderBy(Function(o) (o.Agency)).ToList()

            Dim dtResult1 = ConvertIEnumerableToDataTable(result1)
            'dtResult1.Columns.Add("Precast_Avl_Today", GetType(Double), "CummAch - Cumm_21")
            'dtResult1.Columns("Precast_Avl_Today").SetOrdinal(7)
            gvReportVendor.DataSource = dtResult1
            gvReportVendor.DataBind()
            errorPart = " Linq Agency wise  report "
            '''###########################################################################
            '''##############################
            ''' '''##############################  CUSTOM REPORT
            '''###########################################################################
            '''
            ''' Now “ Precast available  for Driving 
            ''' 'Precast available for Driving Today(Of a Particular Type/of a particular agency**) = Cumulative Precast figure as of (-21 days’ date)- Cumulative Pile driving as on date
            ''' 
            Try
                Dim drivingDTI = From row In dtResult1.AsEnumerable().Where(Function(x) ((x("Group") = "350" Or x("Group") = "450" Or x("Group") = "1616" Or x("Group") = "1717" Or x("Group") = "1818" Or x("Group") = "1919" Or x("Group") = "2121")))
                                 Group row By _group = New With {
                      Key .Agency = row.Field(Of String)("Agency"),
                            Key .grp = row.Field(Of String)("Group")} Into g = Group
                                 Select New With {Key .Agency = _group.Agency, Key .Descr = g.Select(Function(x) x.Field(Of String)("Descr")), Key .UM = g.Select(Function(x) x.Field(Of String)("UM"))(0),
   Key .Scope = g.Sum(Function(x) If(IsDBNull(x("Scope")), 0, x("Scope"))),
 Key .Cumm_21 = g.Sum(Function(x) If(IsDBNull(x("Cumm_21")), 0, x("Cumm_21"))),
                                   Key .CummAch = g.Sum(Function(x) If(IsDBNull(x("CummAch")), 0, x("CummAch"))),
                          Key .grp = _group.grp
       } Order By "grp" Descending   ',        Key.Content = String.Join(", ", g.Select(Function(x) x.Field(Of String)("Agency")))
                ' Dim boundTable As DataTable = result.CopyToDataTable()
                Dim drivingDT = ConvertIEnumerableToDataTable(drivingDTI)
                drivingDT.Columns.Add("Precast_Avl_Today", GetType(Double), "Cumm_21-CummAch")
                drivingDT.Columns("Precast_Avl_Today").SetOrdinal(6)
                ''' DATA MANIPULATION
                '''  Store 350, 450, 20,21 figure of CummAch agency 
                Dim removeRow As New List(Of Integer)
                For Each r In drivingDT.Rows
                    Dim dr = drivingDT.Select("Agency='vinod' AND grp='3502'")
                    If r("grp") = "1616" Then dr = drivingDT.Select("Agency='Dipon' AND grp='350'")
                    If r("grp") = "1717" Then dr = drivingDT.Select("Agency='Dipon' AND grp='450'")
                    If r("grp") = "1818" Then dr = drivingDT.Select("Agency='Keller' AND grp='350'")
                    If r("grp") = "1919" Then dr = drivingDT.Select("Agency='Keller' AND grp='450'")
                    'If r("grp") = "2020" Then dr = drivingDT.Select("Agency='PowerMech' AND grp='350'")
                    If r("grp") = "2121" Then dr = drivingDT.Select("Agency='PowerMech' AND grp='450'")
                    '''Now copy cumaach figure in to sets
                    If dr.Length > 0 Then
                        r("CummAch") = dr(0).Field(Of Integer)("CummAch")
                        r("Agency") = r("Agency") & " - " & dr(0).Field(Of String)("grp").ToString
                        '' Now store which remove the rows
                        removeRow.Add(drivingDT.Rows.IndexOf(dr(0)))
                    End If
                Next
                removeRow.Sort()  ''sort ascending order
                removeRow.Reverse()  '' sord descending order to remove highest index first
                For Each rindex In removeRow
                    drivingDT.Rows.RemoveAt(rindex)  '' now delete rows
                Next
                gvDriving.DataSource = drivingDT
                gvDriving.DataBind()

            Catch ex As Exception
                diverr.InnerHtml = " Error in calculating Precast available  for Driving " & ex.Message
            End Try
            errorPart = " Precast available  for Driving "
            '''4# summation for Work wise summary grand total
            '''  ###########################################################
            '''  '''######################################### CustomReport function
            Dim dtVendor = CustomReport(dtResult1)

                gvReportVendorGroup.DataSource = dtVendor  ''Converts ienumerable to datatable
                gvReportVendorGroup.DataBind()
                errorPart = " Linq Agency wise summary"

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
            gvReportTotal.DataSource = dtResultVendor 'dtResultVendor

            gvReportTotal.DataBind()
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


            '''''####################################### WEEKLY REPORT
            '''
            errorPart = "Making weekly report"

            Dim weeklyResult = From row In finalDT1.AsEnumerable()
                               Order By row.Field(Of String)("U") Ascending, row.Field(Of String)("WorkArea") Ascending, row.Field(Of String)("Activity") Ascending
                               Group row By _group = New With {Key .Id = row.Field(Of String)("WorkArea"),
                                   Key .U = row.Field(Of String)("U"),
                                Key .Activity = row.Field(Of String)("Activity")} Into g = Group
                               Select New With {Key .WorkArea = _group.Id, Key .U = _group.U, Key .Activity = _group.Activity, Key .Descr = g.Select(Function(x) x.Field(Of String)("Descr"))(0), Key .UM = g.Select(Function(x) x.Field(Of String)("UM"))(0),
   Key .Scope = g.Sum(Function(x) If(IsDBNull(x("Scope")), 0, x("Scope"))),
  Key .CummAch = g.Sum(Function(x) If(IsDBNull(x("CummAch")), 0, x("CummAch"))),
                                      Key .WeekTotal = g.Sum(Function(x) If(IsDBNull(x("cummPeriod")), 0, x("cummPeriod"))),
Key .Balance = g.Sum(Function(x) If(IsDBNull(x("Balance")), 0, x("Balance"))),
                                   Key .Remarks = String.Join(",", g.Select(Function(x) x.Field(Of String)("Remarks")))
       }
            ',        Key.Content = String.Join(",", g.Select(Function(x) x.Field(Of String)("Agency")))
            ' Dim boundTable As DataTable = result.CopyToDataTable()



            gvWeeklyReport.DataSource = weeklyResult
            gvWeeklyReport.DataBind()
        Catch ex As Exception
            diverr.InnerHtml = "Error after  " & errorPart & ex.Message & q
        End Try
    End Function

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("ondblclick") = Page.ClientScript.GetPostBackClientHyperlink(gvDPRDetail, "Edit$" & e.Row.RowIndex)
            e.Row.Attributes("style") = "cursor: pointer"
        End If
    End Sub

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
    Sub reloadGrid()

        'SqlDataSource1.SelectParameters("progdate").DefaultValue = ddlRepdate.SelectedValue.ToString
        SqlDataSource1.SelectParameters("unit").DefaultValue = rblUnit.SelectedValue
        SqlDataSource1.SelectParameters("workarea").DefaultValue = ddlWorkArea.SelectedValue
        'Dim priority = 0
        'If cbPriority.Checked Then priority = 1
        'SqlDataSource1.SelectParameters("priority").DefaultValue = priority
        '     SqlDataSource1.SelectCommand = "SELECT pd.progdate as progdate,pm.actcode, 'Maitree #' || pm.unit as project, pm.activity || ' (' || pm.um || ')' as activity,pm.um,pd.progdate,pd.act as Cummulative,pm.scope as scope, round((pd.act / scope)*100,0) || '%' as progress from ProgressMaster pm left join ProgressDetails pd on pm.actcode=pd.actcode   and pd.progdate='" & ddlRepdate.SelectedValue.ToString & "' where unit = 2"
        'Label1.Text = SqlDataSource1.SelectCommand.ToString
    End Sub
    Private Sub cbMistake_CheckedChanged(sender As Object, e As EventArgs) Handles cbMistake.CheckedChanged
        If cbMistake.Checked Then
            gvMistake.Visible = True
            gvMistake.DataSource = getDBTable("select d.actcode, progdate, act , workarea, agency, activity,descr from ProgressDetails d left join ProgressMaster m on d.actcode = m.actcode where d.actcode in (select actcode from ProgressMaster where (not priority = 1 and not closed = 1))", "dprdb")
            gvMistake.DataBind()

        Else
            gvMistake.Visible = False
        End If
        divMsg.InnerHtml = "checked" & Now
    End Sub
    Sub reloadGridPlan()

        'SqlDataSource1.SelectParameters("progdate").DefaultValue = ddlRepdate.SelectedValue.ToString
        SqlDataSource2.SelectParameters("unit").DefaultValue = rblUnit.SelectedValue
        SqlDataSource2.SelectParameters("workarea").DefaultValue = ddlWorkArea.SelectedValue
        SqlDataSource2.SelectParameters("mon").DefaultValue = ddlMonth.SelectedValue
        SqlDataSource2.SelectParameters("yr").DefaultValue = ddlYear.SelectedValue
        SqlDataSource2.UpdateParameters("mon").DefaultValue = ddlMonth.SelectedValue
        SqlDataSource2.UpdateParameters("yr").DefaultValue = ddlYear.SelectedValue
        'Dim priority = 0
        'If cbPriority.Checked Then priority = 1
        'SqlDataSource1.SelectParameters("priority").DefaultValue = priority
        '     SqlDataSource1.SelectCommand = "SELECT pd.progdate as progdate,pm.actcode, 'Maitree #' || pm.unit as project, pm.activity || ' (' || pm.um || ')' as activity,pm.um,pd.progdate,pd.act as Cummulative,pm.scope as scope, round((pd.act / scope)*100,0) || '%' as progress from ProgressMaster pm left join ProgressDetails pd on pm.actcode=pd.actcode   and pd.progdate='" & ddlRepdate.SelectedValue.ToString & "' where unit = 2"
        ' divMsg.InnerHtml = SqlDataSource2.SelectCommand.ToString
    End Sub

    Private Sub gvDPRDetail_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDPRDetail.RowCommand
        reloadGrid()

    End Sub

    Private Sub rblUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblUnit.SelectedIndexChanged
        Dim qry_project As String = "Select distinct workarea as t, workarea as v from ProgressMaster where unit =" & rblUnit.SelectedValue
        Dim dt_project As DataTable = getDBTable(qry_project, "dprdb")
        ddlWorkArea.DataSource = dt_project
        ddlWorkArea.DataTextField = "t"
        ddlWorkArea.DataValueField = "v"
        ddlWorkArea.DataBind()
        reloadGrid()
        reloadGridPlan()

    End Sub

    'Private Sub cbPriority_CheckedChanged(sender As Object, e As EventArgs) Handles cbPriority.CheckedChanged
    '    reloadGrid()
    'End Sub

    Private Sub ddlWorkArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlWorkArea.SelectedIndexChanged

        reloadGrid()
        reloadGridPlan()

    End Sub



    Private Sub ddlMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMonth.SelectedIndexChanged
        reloadGridPlan()
    End Sub

    Private Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        reloadGridPlan()
    End Sub

    Private Sub ddlReportWorkArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlReportWorkArea.SelectedIndexChanged

        btnGo_Click(vbNull, EventArgs.Empty)
    End Sub
    Private Sub ddlReportAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlReportAgency.SelectedIndexChanged
        btnGo_Click(vbNull, EventArgs.Empty)
    End Sub
    Private Sub rblReportUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblReportUnit.SelectedIndexChanged
        reloadDDL()
        btnGo_Click(vbNull, EventArgs.Empty)
    End Sub

    Private Sub rblFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblFilter.SelectedIndexChanged
        btnGo_Click(vbNull, EventArgs.Empty)
    End Sub

    Private Sub ddlAddWork_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAddWork.SelectedIndexChanged
        If ddlAddWork.SelectedValue = "%" Then
            txtAddWorkArea.Visible = True
        Else
            txtAddWorkArea.Visible = False
        End If
    End Sub

    Private Sub btnAddActivity_Click(sender As Object, e As EventArgs) Handles btnAddActivity.Click
        Try
            If ddlAddWork.SelectedValue = "%" And String.IsNullOrEmpty(txtAddWorkArea.Text) Then
                divMsg.InnerHtml = "work area is blank"
                Exit Sub
            End If
            Dim workarea = ddlAddWork.SelectedValue

            If ddlAddWork.SelectedValue = "%" And Not String.IsNullOrEmpty(txtAddWorkArea.Text) Then
                workarea = txtAddWorkArea.Text
            End If

            If String.IsNullOrEmpty(txtAddActivity.Text) Or String.IsNullOrEmpty(txtAddAgency.Text) Or String.IsNullOrEmpty(txtAddDescr.Text) Or String.IsNullOrEmpty(txtAddScope.Text) Or String.IsNullOrEmpty(txtAddUM.Text) Then
                divMsg.InnerHtml = "* fields are mandatory"
                Exit Sub
            End If
            Dim q = "insert into ProgressMaster (workarea, agency, unit,activity,descr, scope,um, grp,priority,closed,del) values " &
            "('" & workarea.Replace("'", "") & "','" & txtAddAgency.Text.Replace("'", "") & "'," & rblAddUnit.SelectedValue.Replace("'", "") & ",'" & txtAddActivity.Text.Replace("'", "") & "','" & txtAddDescr.Text.Replace("'", "") & "'," & txtAddScope.Text.Replace("'", "") & ",'" & txtAddUM.Text.Replace("'", "") & "'," & txtAddGroup.Text.Replace("'", "") & "," & txtAddPriority.Text.Replace("'", "") & ",0,0)"
            If executeDB(q, "dprdb") = "ok" Then
                divMsg.InnerHtml = "Data Inserted succesfully " & Now.TimeOfDay.ToString
                txtAddDescr.Text = ""
                txtAddScope.Text = ""
            Else
                divMsg.InnerHtml = "Error inserting data " & q
            End If
        Catch ex As Exception
            divMsg.InnerHtml = "Error inserting data " & ex.Message
        End Try
    End Sub
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
            divWeek.InnerHtml = st_dt.ToString("dd.MM.yyyy") & " To " & end_dt.ToString("dd.MM.yyyy")
            loadDPR(st_dt, end_dt, "1")
            ' End If

        Else
            divMsg.InnerHtml = "Date range not proper."
        End If


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
        'gvReport.HeaderRow.Style.Add("background-color", "#FFFFFF")

        '' This loop is used to apply stlye to cells based on particular row
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

        Response.AddHeader("content-disposition", "attachment; filename=weekly" & Now.ToString("ddMy") & ".xls")

        Response.ContentType = "application/excel"

        Dim sWriter As New System.IO.StringWriter()

        Dim hTextWriter As New HtmlTextWriter(sWriter)

        gvWeeklyReport.RenderControl(hTextWriter)

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
        Dim lastprogressdate = getDBsingle("select  strftime('%d.%m.%Y', max(progdate))  as d FROM ProgressDetails where act is not null or act = '' or act = 0 limit 1", "dprdb") 'Now.AddDays(-1)
        If lastprogressdate.Contains("Too") Then lastprogressdate = "01.06.2018"
        Dim prevDay As Date = DateTime.ParseExact(lastprogressdate, "dd.MM.yyyy", Nothing)
        If sel = "Monthly" Then
            Dim lastmonth As Date = New Date(prevDay.Year, prevDay.Month, 1)

            dt_stTextBox.Text = lastmonth.ToString("dd.MM.yyyy")
            dt_endTextBox.Text = prevDay.ToString("dd.MM.yyyy")

            loadDPR(lastmonth, prevDay, "1")

        ElseIf sel = "Weekly" Then
            Dim lastweek As Date = prevDay.AddDays(-7)
            Dim firstweek As Date = New Date(prevDay.Year, prevDay.Month, 7)
            '  If prevDay < firstweek Then lastweek = New Date(prevDay.Year, prevDay.Month, 1)
            Dim sunday As Date = Date.Today
            While (sunday.DayOfWeek <> DayOfWeek.Sunday)
                sunday = sunday.AddDays(-1)
            End While
            Dim saturday As Date = Date.Today
            While (saturday.DayOfWeek <> DayOfWeek.Saturday)
                saturday = saturday.AddDays(1)
            End While

            dt_stTextBox.Text = sunday.ToString("dd.MM.yyyy") ' lastweek.ToString("dd.MM.yyyy")
            dt_endTextBox.Text = saturday.ToString("dd.MM.yyyy") ' prevDay.ToString("dd.MM.yyyy")
            divWeek.InnerHtml = sunday.ToString("dd.MM.yyyy") & " To " & saturday.ToString("dd.MM.yyyy")
            ' loadDPR(lastweek, prevDay, "1")
            loadDPR(sunday, saturday, "1")

        ElseIf sel = "Last Progress" Then

                dt_stTextBox.Text = lastprogressdate
            dt_endTextBox.Text = lastprogressdate
            loadDPR(prevDay, prevDay, "1", "Last")
            'If sel = "Last Progress" Then btnSMS.Visible = True
            'If sel = "Email" Then
            '    btnEmail.Visible = True
            '    txtSMS.Visible = True
            '    txtSMS.Text = ""
            '    DisplayMessage("Enter email id seperated with Commas")
            'End If

            'DisplayMessage(lastprogressdate)
            'ElseIf sel = "Up to Hydro Test Report" Then
            '    Dim lastprogressdate = getDBsingle("select  date_format(max(activity_dt),'%d.%m.%Y')  as d FROM `DPR` d, NetworkMaster n WHERE d.network=n.network and n.active = 1 and n.network = " & Session("network") & " group by d.network limit 1") 'Now.AddDays(-1)
            '    Dim prevDay As Date = DateTime.ParseExact(lastprogressdate, "dd.MM.yyyy", Nothing)
            '    dt_stTextBox.Text = lastprogressdate
            '    dt_endTextBox.Text = lastprogressdate
            '    loadDPR(Session("network"), prevDay, prevDay, "1", "BHT")
            'ElseIf sel = "Up to Hydro Test Report(Compiled)" Then
            '    makeCompiledReportuptoBHT()

            'ElseIf sel = "SMS Report" Then
            '    Dim lastprogressdate = getDBsingle("select  date_format(max(activity_dt),'%d.%m.%Y')  as d FROM `DPR` d, NetworkMaster n WHERE d.network=n.network and n.active = 1 and n.network = " & Session("network") & " group by d.network limit 1") 'Now.AddDays(-1)
            '    Dim prevDay As Date = DateTime.ParseExact(lastprogressdate, "dd.MM.yyyy", Nothing)
            '    dt_stTextBox.Text = lastprogressdate
            '    dt_endTextBox.Text = lastprogressdate
            '    loadDPR(Session("network"), prevDay, prevDay, "sms = 1")

        End If
    End Sub

    Private Sub lbDownloadWeekly_Click(sender As Object, e As EventArgs) Handles lbDownloadWeekly.Click
        saveExcel()
    End Sub




    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    If gvReport.Rows.Count > 0 Then

    '        saveExcel()
    '    Else
    '        ' lblMsg.Text = "Please Upload MPP File First."
    '    End If
    'End Sub

End Class
