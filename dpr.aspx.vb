Imports System.Data
Imports AjaxControlToolkit
Imports dbOp
Imports Common
Imports System.IO

Partial Class dpr
    Inherits System.Web.UI.Page
    Private Sub dpr_entry_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Request.QueryString("dprmaster") = 1 Then
        '    'lvDPRMaster.Visible = True
        '    gvDPRDetail.Visible = False
        '    hl1.Text = "<--Back to DPR Entry"
        '    hl1.NavigateUrl = "dpr_entry.aspx"
        'End If
        If Not IsPostBack Then
            '<########## Login MODULE
            If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343266")
            '########## Login MODULE >>>>>>>>
            executeDB("update hits set view = view+1 where page = 'dpr'")
            executeDB("insert into login (eid, log, logintime) values (0, 'DPR Entry Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
            ''''#######Authentication Module ##################
            ''''''''Pass url or onlybifpcl for all bifplc executives
            If Not (checkAuthorization(Session("email"), "dpr.aspx")) Then
                gvDPRDetail.EmptyDataText = "Your email " & Session("email") & " don't have Authorisation to Access DPR.<br/> May please contact TS Dept and provide your email id for authorisation."
                executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied DPR Entry Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                myPanel.Visible = False
                Exit Sub
            End If
            ''''''##########################################

            'If Not (Session("email").ToString.Contains("prakashcn") Or  Session("email").ToString.Contains("vinodkotiya@bifpcl") Or Session("email").ToString.Contains("rashedul@bifpcl.com") Or Session("email").ToString.Contains("rudayashankar@bifpcl") Or Session("email").ToString.Contains("anupam.kumar")) Then
            '    executeDB("insert into login (eid, log, logintime) values (0, 'Access Denied DPR Entry Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
            '    gvDPRDetail.EmptyDataText = "You are not authorised for DPR Entry.<br/><br/> Contact TS Dept for authorisation."
            '    myPanel.Visible = False
            '    Exit Sub
            'End If
            'Dim qry_project As String = "Select distinct pk.project t,pk.project v from Packages pk  where pk.project in (select distinct u.project from Projects_ntpc p, Units u , MileStones m where p.projectname = u.project and u.project=m.project and u.unit = m.unit and milestone= 'COD'  and achieved <>'A' and (u.zerodate ='' or not isnull(u.zerodate)) and p.region not in ('REDG','IJV')) order by pk.project "
            Dim qry_project As String = "Select distinct workarea as t, workarea as v from ProgressMaster where unit =" & rblUnit.SelectedValue
            Dim dt_project As DataTable = getDBTable(qry_project, "dprdb")
            ddlWorkArea.DataSource = dt_project
            ddlWorkArea.DataTextField = "t"
            ddlWorkArea.DataValueField = "v"
            ddlWorkArea.DataBind()
            reloadGrid()

        End If

    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("ondblclick") = Page.ClientScript.GetPostBackClientHyperlink(gvDPRDetail, "Edit$" & e.Row.RowIndex)
            e.Row.Attributes("style") = "cursor:pointer"
        End If
    End Sub

    'Private Sub gvDPRDetail_Load(sender As Object, e As EventArgs) Handles gvDPRDetail.Load
    '    '   gvDPRDetail.HeaderRow.TableSection = TableRowSection.TableHeader
    'End Sub


    Private Sub ddlRepdate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRepdate.SelectedIndexChanged
        'gvDPRDetail.DataSource = getDBTable(SqlDataSource1.SelectCommand)
        'gvDPRDetail.DataBind()
        '    Response.Write(SqlDataSource1.SelectCommand.ToString)
        reloadGrid()

    End Sub

    Private Sub ddlRepdate_Init(sender As Object, e As EventArgs) Handles ddlRepdate.Init
        If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343266")
        For i As Integer = -60 To 0
            '   items.Add(New ListItem(DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"), DateTime.Now.AddDays(i).ToString("yyyy-mm-dd")))
            ddlRepdate.Items.Add(New ListItem(DateTime.UtcNow.AddDays(i).ToString("dd.MM.yyyy"), DateTime.UtcNow.AddDays(i).ToString("yyyy-MM-dd")))
        Next
        '  ddlRepdate.DataSource = items
        ddlRepdate.DataBind()
        ddlRepdate.SelectedValue = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-dd")
        reloadGrid()
        ddlRepdate.Enabled = False
        If (checkAuthorization(Session("email"), "dpr.aspx")) Then
            ddlRepdate.Enabled = True
        End If

        '  
        divMsg.InnerHtml = "<br/>Server Time =" & Now.ToString & " UTC Time=" & DateTime.UtcNow.ToString
    End Sub
    Sub reloadGrid()

        SqlDataSource1.SelectParameters("progdate").DefaultValue = ddlRepdate.SelectedValue.ToString
        SqlDataSource1.SelectParameters("unit").DefaultValue = rblUnit.SelectedValue
        SqlDataSource1.SelectParameters("workarea").DefaultValue = ddlWorkArea.SelectedValue
        SqlDataSource1.UpdateParameters("updateprogdate").DefaultValue = ddlRepdate.SelectedValue.ToString
        Dim priority = 0
        If cbPriority.Checked Then priority = 1
        SqlDataSource1.SelectParameters("priority").DefaultValue = priority
        '     SqlDataSource1.SelectCommand = "SELECT pd.progdate as progdate,pm.actcode, 'Maitree #' || pm.unit as project, pm.activity || ' (' || pm.um || ')' as activity,pm.um,pd.progdate,pd.act as Cummulative,pm.scope as scope, round((pd.act / scope)*100,0) || '%' as progress from ProgressMaster pm left join ProgressDetails pd on pm.actcode=pd.actcode   and pd.progdate='" & ddlRepdate.SelectedValue.ToString & "' where unit = 2"
        'Label1.Text = SqlDataSource1.SelectCommand.ToString
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
    End Sub

    Private Sub cbPriority_CheckedChanged(sender As Object, e As EventArgs) Handles cbPriority.CheckedChanged
        reloadGrid()
    End Sub

    Private Sub ddlWorkArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlWorkArea.SelectedIndexChanged
        reloadGrid()
    End Sub
End Class
