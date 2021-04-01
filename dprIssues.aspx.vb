Imports System.Data
Imports AjaxControlToolkit
Imports dbOp
Imports Common
Imports System.IO

Partial Class dprIssues
    Inherits System.Web.UI.Page
    Private Sub dpr_issues_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim admin = False
        If Not IsPostBack Then
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2, True)
            divNotification.InnerHtml = getNotification(1)
            divNotificationMobile.InnerHtml = getNotification(1, True)
            divLogin.InnerHtml = showAccount(Session("email"), True)
            divLoginMobile.InnerHtml = showAccount(Session("email"), True)
            '<<<<<<<<<########## Login MODULE
            If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343266")
            '########## Login MODULE >>>>>>>>

            'If (Session("email").ToString.Contains("prakashcn") Or Session("email").ToString.Contains("vinodkotiya@bifpcl") Or Session("email").ToString.Contains("rashedul@bifpcl.com") Or Session("email").ToString.Contains("rudayashankar@bifpcl") Or Session("email").ToString.Contains("anupam.kumar")) Then
            '    admin = True
            'End If
            'Dim qry_project As String = "Select distinct pk.project t,pk.project v from Packages pk  where pk.project in (select distinct u.project from Projects_ntpc p, Units u , MileStones m where p.projectname = u.project and u.project=m.project and u.unit = m.unit and milestone= 'COD'  and achieved <>'A' and (u.zerodate ='' or not isnull(u.zerodate)) and p.region not in ('REDG','IJV')) order by pk.project "

            reloadGrid()
            If Request.QueryString("mode") = "input_update" Then
                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                If Not (checkAuthorization(Session("email"), "dprIssues.aspx?mode=input_update")) Then
                    gvDPRDetail.Visible = False
                    diverr.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access Milestone Monitoring System Manage Inputs.<br/> May please contact TS Dept and provide your email id for authorisation."
                    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied Milestone Monitoring System Manage Inputs Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    Exit Sub
                End If
                ''''''##########################################
                'lvDPRMaster.Visible = True
                Dim qry_project As String = "Select distinct milestone as t, milestone as v from Milestones where unit =" & rblUnitInputUpdate.SelectedValue & " order by l2date"
                ddlMilesInputUpdate.DataSource = getDBTable(qry_project, "dprdb")
                ddlMilesInputUpdate.DataTextField = "t"
                ddlMilesInputUpdate.DataValueField = "v"
                ddlMilesInputUpdate.DataBind()

                PanelUpdateInput.Visible = True
                reloadGridManageInput()
                executeDB("insert into login (eid, log, logintime) values (0, 'Access Milestone Monitoring System Manage Inputs Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
            ElseIf Request.QueryString("mode") = "issue_update" Then
                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                If Not (checkAuthorization(Session("email"), "dprIssues.aspx?mode=issue_update")) Then
                    gvDPRDetail.Visible = False
                    diverr.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access Milestone Monitoring System Manage Issues.<br/> May please contact TS Dept and provide your email id for authorisation."
                    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied Milestone Monitoring System Manage Issues Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    Exit Sub
                End If
                ''''''##########################################
                'lvDPRMaster.Visible = True
                Dim qry_project As String = "Select distinct milestone as t, milestone as v from Milestones where unit =" & rblUnitInputUpdate.SelectedValue & " order by l2date"
                ddlMilestoneIssueUpdate.DataSource = getDBTable(qry_project, "dprdb")
                ddlMilestoneIssueUpdate.DataTextField = "t"
                ddlMilestoneIssueUpdate.DataValueField = "v"
                ddlMilestoneIssueUpdate.DataBind()
                ddlInputUpdate.DataSource = getDBTable("select input as t, input as v from Inputs where milestone = '" & ddlMilestoneIssueUpdate.SelectedValue & "' and unit=" & rblUnitIssueUpdate.SelectedValue, "dprdb")
                ddlInputUpdate.DataTextField = "t"
                ddlInputUpdate.DataValueField = "v"
                ddlInputUpdate.DataBind()

                pnlManageIssues.Visible = True
                reloadGridManageIssues()
                executeDB("insert into login (eid, log, logintime) values (0, 'Access Milestone Monitoring System Manage Issues Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

            ElseIf Request.QueryString("mode") = "input_add" Then
                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                If Not (checkAuthorization(Session("email"), "dprIssues.aspx?mode=input_add")) Then
                    gvDPRDetail.Visible = False

                    diverr.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access Milestone Monitoring System Add Inputs.<br/> May please contact TS Dept and provide your email id for authorisation."
                    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied Milestone Monitoring System Add Inputs Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    Exit Sub
                End If
                ''''''##########################################
                pnlAdd.Visible = True
                pnlUpdate.Visible = False
                pnlReport.Visible = False
                Dim qry_project As String = "Select distinct milestone as t, milestone as v from Milestones where unit =" & rblUnitInputUpdate.SelectedValue & " order by l2date"
                ddlAddInputMilestone.DataSource = getDBTable(qry_project, "dprdb")
                ddlAddInputMilestone.DataTextField = "t"
                ddlAddInputMilestone.DataValueField = "v"
                ddlAddInputMilestone.DataBind()
                '   ddlAddWork.SelectedValue = "%"
                'Else
                '    Response.Redirect("dprUpdate.aspx")
                executeDB("insert into login (eid, log, logintime) values (0, 'Access Milestone Monitoring System Add Inputs Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
            ElseIf Request.QueryString("mode") = "issue_add" Then
                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                If Not (checkAuthorization(Session("email"), "dprIssues.aspx?mode=issue_add")) Then
                    gvDPRDetail.Visible = False

                    diverr.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access Milestone Monitoring System Add Issues.<br/> May please contact TS Dept and provide your email id for authorisation."
                    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied Milestone Monitoring System Add Issues Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    Exit Sub
                End If
                ''''''##########################################
                pnlAddIssue.Visible = True
                Dim qry_project As String = "Select distinct milestone as t, milestone as v from Milestones where unit =" & rblUnitInputUpdate.SelectedValue & " order by l2date"
                ddlMilestoneIssueAdd.DataSource = getDBTable(qry_project, "dprdb")
                ddlMilestoneIssueAdd.DataTextField = "t"
                ddlMilestoneIssueAdd.DataValueField = "v"
                ddlMilestoneIssueAdd.DataBind()
                ddlInputIssueAdd.DataSource = getDBTable("select input as t, input as v from Inputs where milestone = '" & ddlMilestoneIssueAdd.SelectedValue & "' and unit=" & rblUnitIssueAdd.SelectedValue, "dprdb")
                ddlInputIssueAdd.DataTextField = "t"
                ddlInputIssueAdd.DataValueField = "v"
                ddlInputIssueAdd.DataBind()
                '   ddlAddWork.SelectedValue = "%"
                'Else
                '    Response.Redirect("dprUpdate.aspx")
                executeDB("insert into login (eid, log, logintime) values (0, 'Access Milestone Monitoring System Add Issue Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

            ElseIf Request.QueryString("mode") = "report" Then
                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                If Not (checkAuthorization(Session("email"), "onlybifpcl") Or checkAuthorization(Session("email"), "dprUpdate.aspx?mode=report")) Then
                    gvDPRDetail.Visible = False
                    diverr.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access DPR.<br/> May please contact TS Dept and provide your email id for authorisation."
                    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied DPR Update Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    Exit Sub
                End If
                ''''''##########################################
                pnlAdd.Visible = False
                pnlUpdate.Visible = False
                pnlReport.Visible = True
                Dim qry_project As String = "Select distinct milestone as t, milestone as v from Milestones where unit =" & rblUnitInputUpdate.SelectedValue & " order by l2date"
                ddlMilestoneReport.DataSource = getDBTable(qry_project, "dprdb")
                ddlMilestoneReport.DataTextField = "t"
                ddlMilestoneReport.DataValueField = "v"
                ddlMilestoneReport.DataBind()
                ddlMilestoneReport.Items.Add(New ListItem("Show All", "%"))
                ddlMilestoneReport.SelectedValue = "%"
                reloadDDL()
                executeDB("insert into login (eid, log, logintime) values (0, 'Access DPR Report Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

            ElseIf Request.QueryString("mode") = "milestone" Then
                ''''#######Authentication Module ##################
                ''''''''Pass url or onlybifpcl for all bifplc executives
                If Not (checkAuthorization(Session("email"), "dprIssues.aspx?mode=milestone")) Then
                    '  gvDPRDetail.Visible = False
                    pnlUpdate.Visible = False
                    diverr.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access this module.<br/> May please contact TS Dept and provide your email id for authorisation."
                    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied Milestone Update Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    Exit Sub
                End If
                ''''''##########################################
                pnlUpdate.Visible = True
                executeDB("insert into login (eid, log, logintime) values (0, 'Access Given Milestone Update Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

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

        ddlInputReport.DataSource = getDBTable("select input as t, input as v from Inputs where milestone like '%" & ddlMilestoneReport.SelectedValue & "%' and unit=" & rblUnitReport.SelectedValue, "dprdb")
        ddlInputReport.DataTextField = "t"
        ddlInputReport.DataValueField = "v"
        ddlInputReport.DataBind()
        ddlInputReport.Items.Add(New ListItem("Show All", "%"))
        ddlInputReport.SelectedValue = "%"
    End Sub
    Private Function loadDPR(ByVal filter As String) As Boolean



        Dim q = ""
        Dim errorPart = ""
        Dim grp = ""
        Try
            If filter = "1" Then
                q = "SELECT milestone as Milestone, unit as Unit  , strftime('%d.%m.%Y',l2date) as 'L2 Date',  strftime('%d.%m.%Y',act_ant) as 'Act/Ant Date', achieved as 'Achieved',  strftime('%d.%m.%Y',external) as 'External Date' from Milestones  where unit= " & rblUnitReport.SelectedValue & " and milestone like '%" & ddlMilestoneReport.SelectedValue & "%'"
            ElseIf filter = "2" Then
                q = "SELECT milestone as Milestone, unit as Unit  , input as Input, strftime('%d.%m.%Y',l2date) as 'L2 Date', strftime('%d.%m.%Y',act_ant) as 'Act/Ant Date', achieved, remark from Inputs    where del = 0 and unit= " & rblUnitReport.SelectedValue & " and milestone like '%" & ddlMilestoneReport.SelectedValue & "%'"
            ElseIf filter = "3" Then
                q = "SELECT   milestone as Milestone, unit as Unit  , input as Input, issue as Issue, closed, lastupdateby as 'Closing Remark'  from Issues  where  unit= " & rblUnitReport.SelectedValue & " and milestone like '%" & ddlMilestoneReport.SelectedValue & "%'"

            End If
            ' divMsg.InnerHtml = q
            Dim myDT = getDBTable(q, "dprdb")

            If myDT.Rows.Count = 0 Then
                myDT = getDBTable("select 'No record found' as NoData from Issues ", "dprdb")
                Return 0
            End If


            ' finalDT1.Merge(result, False)
            gvReport.DataSource = myDT
            gvReport.DataBind()

            '  //This replaces <td> with <th> And adds the scope attribute
            gvReport.UseAccessibleHeader = True
            ' //This will add the <thead> And <tbody> elements
            gvReport.HeaderRow.TableSection = TableRowSection.TableHeader

            ' //This adds the <tfoot> element. 
            ' //Remove if you don't have a footer row
            gvReport.FooterRow.TableSection = TableRowSection.TableFooter


            diverr.InnerHtml = q
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
        SqlDataSource1.UpdateParameters("lastupdateby").DefaultValue = Session("email")
        SqlDataSource1.UpdateParameters("last_updated").DefaultValue = DateTime.UtcNow.ToString
        'Dim priority = 0
        'If cbPriority.Checked Then priority = 1
        'SqlDataSource1.SelectParameters("priority").DefaultValue = priority
        '     SqlDataSource1.SelectCommand = "SELECT pd.progdate as progdate,pm.actcode, 'Maitree #' || pm.unit as project, pm.activity || ' (' || pm.um || ')' as activity,pm.um,pd.progdate,pd.act as Cummulative,pm.scope as scope, round((pd.act / scope)*100,0) || '%' as progress from ProgressMaster pm left join ProgressDetails pd on pm.actcode=pd.actcode   and pd.progdate='" & ddlRepdate.SelectedValue.ToString & "' where unit = 2"
        'Label1.Text = SqlDataSource1.SelectCommand.ToString
    End Sub
    Sub reloadGridManageIssues()
        lbManageIssueL2Date.Text = getDBsingle("select  'Milestone L2 Date: ' || strftime('%d.%m.%Y',l2date) from Milestones where milestone = '" & ddlMilestoneIssueUpdate.SelectedValue & "' and unit=" & rblUnitIssueUpdate.SelectedValue, "dprdb")
        SqlDataSource3.SelectParameters("milestone").DefaultValue = ddlMilestoneIssueUpdate.SelectedValue.ToString
        SqlDataSource3.SelectParameters("unit").DefaultValue = rblUnitIssueUpdate.SelectedValue
        SqlDataSource3.SelectParameters("input").DefaultValue = ddlInputUpdate.SelectedValue.ToString
        ' its remark now SqlDataSource3.UpdateParameters("lastupdateby").DefaultValue = Session("email")
        SqlDataSource3.UpdateParameters("last_updated").DefaultValue = DateTime.UtcNow.ToString
        'Dim priority = 0
        'If cbPriority.Checked Then priority = 1
        'SqlDataSource1.SelectParameters("priority").DefaultValue = priority
        '     SqlDataSource1.SelectCommand = "SELECT pd.progdate as progdate,pm.actcode, 'Maitree #' || pm.unit as project, pm.activity || ' (' || pm.um || ')' as activity,pm.um,pd.progdate,pd.act as Cummulative,pm.scope as scope, round((pd.act / scope)*100,0) || '%' as progress from ProgressMaster pm left join ProgressDetails pd on pm.actcode=pd.actcode   and pd.progdate='" & ddlRepdate.SelectedValue.ToString & "' where unit = 2"
        ' divMsg.InnerHtml = SqlDataSource3.SelectCommand.ToString
    End Sub
    Sub reloadGridManageInput()
        lbManageL2Date.Text = getDBsingle("select  'Milestone L2 Date: ' || strftime('%d.%m.%Y',l2date) from Milestones where milestone = '" & ddlMilesInputUpdate.SelectedValue & "' and unit=" & rblUnitInputUpdate.SelectedValue, "dprdb")

        SqlDataSource2.SelectParameters("milestone").DefaultValue = ddlMilesInputUpdate.SelectedValue.ToString
        SqlDataSource2.SelectParameters("unit").DefaultValue = rblUnitInputUpdate.SelectedValue
        SqlDataSource2.UpdateParameters("lastupdateby").DefaultValue = Session("email")
        SqlDataSource2.UpdateParameters("last_updated").DefaultValue = DateTime.UtcNow.ToString
        'Dim priority = 0
        'If cbPriority.Checked Then priority = 1
        'SqlDataSource1.SelectParameters("priority").DefaultValue = priority
        '     SqlDataSource1.SelectCommand = "SELECT pd.progdate as progdate,pm.actcode, 'Maitree #' || pm.unit as project, pm.activity || ' (' || pm.um || ')' as activity,pm.um,pd.progdate,pd.act as Cummulative,pm.scope as scope, round((pd.act / scope)*100,0) || '%' as progress from ProgressMaster pm left join ProgressDetails pd on pm.actcode=pd.actcode   and pd.progdate='" & ddlRepdate.SelectedValue.ToString & "' where unit = 2"
        ' divMsg.InnerHtml = SqlDataSource2.SelectCommand.ToString
    End Sub

    Private Sub gvDPRDetail_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDPRDetail.RowCommand
        reloadGrid()

    End Sub



    'Private Sub cbPriority_CheckedChanged(sender As Object, e As EventArgs) Handles cbPriority.CheckedChanged
    '    reloadGrid()
    'End Sub











    Private Sub btnAddInput_Click(sender As Object, e As EventArgs) Handles btnAddInput.Click
        Try

            If String.IsNullOrEmpty(txtAddInputL2Date.Text) Or String.IsNullOrEmpty(txtAddInputAct.Text) Then
                divMsg.InnerHtml = "* fields are mandatory"
                Exit Sub
            End If
            Dim dtL2 = DateTime.ParseExact(txtAddInputL2Date.Text, "dd.M.yyyy", Nothing)
            Dim dtAct = DateTime.ParseExact(txtAddInputAct.Text, "dd.M.yyyy", Nothing)
            Dim q = "insert into Inputs (milestone, unit, input,l2date,act_ant, achieved,last_updated, lastupdateby,del) values " &
            "('" & ddlAddInputMilestone.SelectedValue & "','" & rblAddInputUnit.SelectedValue & "','" & txtAddInput.Text.Replace("'", "") & "','" & dtL2.ToString("yyyy-MM-dd") & "','" & dtAct.ToString("yyyy-MM-dd") & "',0, current_timestamp,'" & Session("email") & "',0)"
            If executeDB(q, "dprdb") = "ok" Then
                divMsg.InnerHtml = "Data Inserted succesfully " & Now.TimeOfDay.ToString
                txtAddInput.Text = ""
                txtAddInputAct.Text = ""
            Else
                divMsg.InnerHtml = "Error inserting data " & q
            End If
        Catch ex As Exception
            divMsg.InnerHtml = "Error inserting data " & ex.Message
        End Try
    End Sub
    Private Sub btnAddIssue_Click(sender As Object, e As EventArgs) Handles btnAddIssue.Click
        Try

            If String.IsNullOrEmpty(txtIssue.Text) Then
                divMsg.InnerHtml = "* fields are mandatory"
                Exit Sub
            End If
            If ddlInputIssueAdd.SelectedIndex < 0 Then
                divMsg.InnerHtml = "Input is required. Create one in Add new Input section."
                Exit Sub
            End If
            Dim q = "insert into Issues (milestone, unit, input,issue,closed,create_dt,last_updated, lastupdateby) values " &
            "('" & ddlMilestoneIssueAdd.SelectedValue & "','" & rblUnitIssueAdd.SelectedValue & "','" & ddlInputIssueAdd.SelectedValue & "','" & txtIssue.Text.Replace("'", "") & "',0,current_timestamp,current_timestamp,'')"
            If executeDB(q, "dprdb") = "ok" Then
                divMsg.InnerHtml = "Data Inserted succesfully " & Now.TimeOfDay.ToString
                txtIssue.Text = ""
            Else
                divMsg.InnerHtml = "Error inserting data " & q
            End If
        Catch ex As Exception
            divMsg.InnerHtml = "Error inserting data " & ex.Message
        End Try
    End Sub

    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click
        loadDPR(rblFilter.SelectedValue)
        ' End If



    End Sub


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

        ' gvWeeklyReport.RenderControl(hTextWriter)

        Response.Write(sWriter.ToString())

        Response.End()
        'lblMsg.Text = "Excel created"

        'GridView1.RenderControl(htw)

    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Return
    End Sub



    'Private Sub lbDownloadWeekly_Click(sender As Object, e As EventArgs) Handles lbDownloadWeekly.Click
    '    saveExcel()
    'End Sub

    Private Sub rblUnitInputUpdate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblUnitInputUpdate.SelectedIndexChanged
        reloadGridManageInput()
    End Sub

    Private Sub ddlMilesInputUpdate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMilesInputUpdate.SelectedIndexChanged
        reloadGridManageInput()
    End Sub

    Private Sub ddlAddInputMilestone_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAddInputMilestone.SelectedIndexChanged
        txtAddInputL2Date.Text = getDBsingle("select  strftime('%d.%m.%Y',l2date) from Milestones where milestone = '" & ddlAddInputMilestone.SelectedValue & "' and unit=" & rblAddInputUnit.SelectedValue, "dprdb")
    End Sub

    Private Sub rblAddInputUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblAddInputUnit.SelectedIndexChanged
        txtAddInputL2Date.Text = getDBsingle("select  strftime('%d.%m.%Y',l2date) from Milestones where milestone = '" & ddlAddInputMilestone.SelectedValue & "' and unit=" & rblAddInputUnit.SelectedValue, "dprdb")

    End Sub

    Private Sub rblUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblUnit.SelectedIndexChanged
        SqlDataSource1.SelectParameters("unit").DefaultValue = rblUnit.SelectedValue
        SqlDataSource1.UpdateParameters("unit").DefaultValue = rblUnit.SelectedValue
    End Sub

    Private Sub ddlMilestoneIssueUpdate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMilestoneIssueUpdate.SelectedIndexChanged
        ddlInputUpdate.DataSource = getDBTable("select input as t, input as v from Inputs where milestone = '" & ddlMilestoneIssueUpdate.SelectedValue & "' and unit=" & rblUnitIssueUpdate.SelectedValue, "dprdb")
        ddlInputUpdate.DataTextField = "t"
        ddlInputUpdate.DataValueField = "v"
        ddlInputUpdate.DataBind()
        reloadGridManageIssues()

    End Sub

    Private Sub rblUnitIssueUpdate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblUnitIssueUpdate.SelectedIndexChanged

        ddlInputUpdate.DataSource = getDBTable("select input as t, input as v from Inputs where milestone = '" & ddlMilestoneIssueUpdate.SelectedValue & "' and unit=" & rblUnitIssueUpdate.SelectedValue, "dprdb")
        ddlInputUpdate.DataTextField = "t"
        ddlInputUpdate.DataValueField = "v"
        ddlInputUpdate.DataBind()
        reloadGridManageIssues()
    End Sub

    Private Sub ddlInputUpdate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlInputUpdate.SelectedIndexChanged
        reloadGridManageIssues()
    End Sub

    Private Sub ddlMilestoneIssueAdd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMilestoneIssueAdd.SelectedIndexChanged
        ddlInputIssueAdd.DataSource = getDBTable("select input as t, input as v from Inputs where milestone = '" & ddlMilestoneIssueAdd.SelectedValue & "' and unit=" & rblUnitIssueAdd.SelectedValue, "dprdb")
        ddlInputIssueAdd.DataTextField = "t"
        ddlInputIssueAdd.DataValueField = "v"
        ddlInputIssueAdd.DataBind()
    End Sub

    Private Sub rblUnitIssueAdd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblUnitIssueAdd.SelectedIndexChanged
        ddlInputIssueAdd.DataSource = getDBTable("select input as t, input as v from Inputs where milestone = '" & ddlMilestoneIssueAdd.SelectedValue & "' and unit=" & rblUnitIssueAdd.SelectedValue, "dprdb")
        ddlInputIssueAdd.DataTextField = "t"
        ddlInputIssueAdd.DataValueField = "v"
        ddlInputIssueAdd.DataBind()
    End Sub

    Private Sub ddlMilestoneReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMilestoneReport.SelectedIndexChanged
        reloadDDL()
        btnGo_Click(vbNull, EventArgs.Empty)
    End Sub

    Private Sub rblUnitReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblUnitReport.SelectedIndexChanged
        btnGo_Click(vbNull, EventArgs.Empty)
    End Sub

    Private Sub ddlInputReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlInputReport.SelectedIndexChanged
        btnGo_Click(vbNull, EventArgs.Empty)
    End Sub

    Private Sub rblFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblFilter.SelectedIndexChanged
        btnGo_Click(vbNull, EventArgs.Empty)
    End Sub

    Private Sub gvReport_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvReport.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            If rblFilter.SelectedValue = "2" Then e.Row.Cells(6).Text = e.Row.Cells(6).Text.Replace(ControlChars.Lf, "# <br />")
        End If

    End Sub





    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    If gvReport.Rows.Count > 0 Then

    '        saveExcel()
    '    Else
    '        ' lblMsg.Text = "Please Upload MPP File First."
    '    End If
    'End Sub

End Class
