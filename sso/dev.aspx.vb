Imports Common
Imports dbOp

Partial Class _dev
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' pnlSignIn.Visible = True
            'If Not Session("email") Is Nothing Then
            '    lbEmail.Text = Session("email")
            'Else
            '    Response.Redirect("Default.aspx")
            'End If

            'wSISKY2/p8j4P1iyqppUEhhvWfFfzqi/WlrqHbr+1rQ=
            '12343218
            If Request.Form.Count > 0 Then
                Dim appsecret = "mbhNLqSIfA0tnV1m4yNCBKjlZUns8F6PNbd8AnaNcGs="
                ' Dim eid = Decrypt(Request.Form("eid"), appsecret)
                'lblEid.Text =
                'lblEmail.Text =
                ' divMsg.InnerHtml = "<p>eid=" & Session("eid") & " Email: " & Decrypt(Request.Form("email"), appsecret) & "</p>"
                Session("devemail") = Decrypt(Request.Form("email"), appsecret)
                'If Session("redirectafterlogin") Is Nothing Then
                '    Response.Redirect("Default.aspx")
                'Else
                '    Response.Redirect(Session("redirectafterlogin"))
                'End If
            End If

            If Session("devemail") Is Nothing Then

                Response.Redirect("Default.aspx?appid=12343218")
            End If
            lbEmail.Text = Session("devemail")
            loadDDL()

        End If

    End Sub
    Sub loadDDL()
        Dim mydt = getDBTable("select appid as v, appname as t from vinapp where email ='" & Session("devemail") & "'", "ssodb")
        ddlApps.DataSource = mydt
        ddlApps.DataBind()
        ddlApps.Items.Add(New ListItem("Select your registered app", "select"))
        ddlApps.Items.Add(New ListItem("Register a new app", "new"))
        ddlApps.SelectedValue = "new"
        If mydt.Rows.Count > 0 Then ddlApps.SelectedValue = "select"
        If Session("devemail").contains("vinodkotiya") Then
            gvUsers.DataSource = getDBTable("select email , cell , last_updated, lastupdatedby, retry, lastapp from vinusers where eid = 1", "ssodb")
            gvUsers.DataBind()
        End If
    End Sub

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        If String.IsNullOrEmpty(txtApp.Text) Then
            divMsg.InnerHtml = "Enter App Name"
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAppUrl.Text) Then
            divMsg.InnerHtml = "Enter App URL"
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtRedirURL.Text) Then
            divMsg.InnerHtml = "Enter App Redirection URL after login"
            Exit Sub
        End If
        Dim appid = 123452
        Dim q = "select max(appid) from vinapp where 1 "
        Dim ret = ""
        ''only for signup else update existing
        If String.IsNullOrEmpty(txtAppID.Text) Then
            ret = getDBsingle(q, "ssodb")
            If Not ret.Contains("Error") Then appid = Int64.Parse(ret) + 6
            txtAppID.Text = appid
        Else
            appid = txtAppID.Text
        End If
        Dim alloweduser = IIf(cbUsers.Checked = False, "1", "2")
        txtAppSecret.Text = Encrypt(appid, lbEmail.Text & Now.Second)

        q = "replace into vinapp (appid, appsecret,email, appname, appurl, appredir, last_updated,lastupdatedby,alloweduser) values ( " & appid & ", '" & txtAppSecret.Text & "', '" & lbEmail.Text & "', '" & txtApp.Text & "', '" & txtAppUrl.Text & "', '" & txtRedirURL.Text & "', current_timestamp,'" & Request.UserHostAddress & "', '" & alloweduser & "')"
        ret = executeDB(q, "ssodb")
        If ret = "ok" Then
            divMsg.InnerHtml = "App ID & App Secret Updated, change this in your code. Keep it with yourself."
            loadDDL()
        Else
            divMsg.InnerHtml = "Fail to generate App ID & App Secret Updated."
        End If
    End Sub

    Private Sub ddlApps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlApps.SelectedIndexChanged
        divMsg.InnerHtml = ""
        If ddlApps.SelectedValue = "new" Then
            btnSignUp.Text = "Register"
            divMsg.InnerHtml = "Enter the details to register your app"
            txtApp.Text = ""
            txtAppUrl.Text = ""
            txtRedirURL.Text = ""
            txtAppID.Text = ""
            txtAppSecret.Text = ""
            Exit Sub
        End If
        If ddlApps.SelectedValue = "select" Then
            divMsg.InnerHtml = "Select the app from dropdown"

            Exit Sub
        End If
        Dim mydt = getDBTable("select   appsecret,appurl, appredir, alloweduser from vinapp where appid = " & ddlApps.SelectedValue, "ssodb")
        txtApp.Text = ddlApps.SelectedItem.ToString
        txtAppID.Text = ddlApps.SelectedValue
        txtAppSecret.Text = mydt.Rows(0)(0)
        txtAppUrl.Text = mydt.Rows(0)(1)
        txtRedirURL.Text = mydt.Rows(0)(2)
        If mydt.Rows(0)(3) = "1" Then : cbUsers.Checked = False
        Else cbUsers.Checked = True
        End If
        btnSignUp.Text = "Update"
    End Sub

    Private Sub btnFone_Click(sender As Object, e As EventArgs) Handles btnFone.Click
        Dim q = "select cell , email from contacts_New"
        Dim mydt = getDBTable(q, "hrdb")
        Dim msg = ""
        For Each r In mydt.Rows
            Dim q1 = "update vinusers set cell = '" & r("cell").ToString & "' where cell is null and email = '" & r("email").ToString & "'"
            msg = msg & executeDB(q1, "ssodb")
        Next
        divMsg.InnerHtml = msg
    End Sub
End Class
