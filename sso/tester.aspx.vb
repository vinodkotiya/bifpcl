Imports dbOp
Imports Common

Partial Class tester
    Inherits System.Web.UI.Page

    Private Sub _tester_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim mydt = getDBTable("select appredir as v, appredir as t from testapp where 1", "ssodb")
            If mydt.Rows.Count > 0 Then
                ddlApps.DataSource = mydt
                ddlApps.DataBind()
            End If

            ddlApps.Items.Add(New ListItem("Select your registered app", "select"))
            ddlApps.SelectedValue = "select"
        End If
        divAppname.InnerHtml = "Test Login"
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If ddlApps.SelectedValue = "select" Or String.IsNullOrEmpty(txtEmp.Text) Or String.IsNullOrEmpty(txtMyPwd.Text) Then
            divMsg.InnerHtml = "Enter All Fields"
            Exit Sub
        End If
        Dim app = ddlApps.SelectedValue
        '' match password
        Dim q = "select appredir from testapp where pwdapp = '" & txtMyPwd.Text & "' and appredir = '" & app & "' limit 1"
        Dim ret = getDBsingle(q, "ssodb")
        If ret.Contains("Error") Then
            divMsg.InnerHtml = "Password didnt match" & q
            Exit Sub
        Else
            q = "select appsecret from testapp where pwdapp = '" & txtMyPwd.Text & "' and appredir = '" & app & "' limit 1"
            ret = getDBsingle(q, "ssodb")
            If Not ret.Contains("Error") Then
                Dim appsecret = ret
                Dim collections As New NameValueCollection()
                Dim eid = Encrypt(txtEmp.Text, appsecret)
                'Dim email = getDBsingle("select email from employee where empno = '" & txtEmp.Text.PadLeft(6, "0") & "' limit 1")
                'Dim EmailId = Encrypt(email, appsecret)
                'Dim empname = Encrypt("SSO Tester", appsecret)
                'Dim Dept = Encrypt("SSO Dept", appsecret)
                'Dim Location = Encrypt("SSO Del", appsecret)
                'Dim Mobile = Encrypt("9999999", appsecret)

                'collections.Add("EmpId", eid)
                'collections.Add("EmailId", EmailId)
                'collections.Add("EmpName", empname)
                'collections.Add("Dept", Dept)
                'collections.Add("Location", Location)
                'collections.Add("Mobile", Mobile)
                collections.Add("email", eid)
                Dim remoteUrl As String = app

                Dim html As String = "<html><head>"
                html += "</head><body onload='document.forms[0].submit()'>"
                html += String.Format("<form name='PostForm' method='POST' action='{0}'>", remoteUrl)
                For Each key As String In collections.Keys
                    html += String.Format("<input name='{0}' type='text' value='{1}'>", key, collections(key))
                Next
                html += "</form></body></html>"
                Response.Clear()
                Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1")
                Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1")
                Response.Charset = "ISO-8859-1"
                Response.Write(html)
                Response.End()
            End If
        End If
    End Sub

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        If String.IsNullOrEmpty(txtAppSecret.Text) Or String.IsNullOrEmpty(txtRedirURL.Text) Or String.IsNullOrEmpty(txtPwd.Text) Then
            divMsg.InnerHtml = "Enter All Fields"
            Exit Sub
        End If

        Dim q = "insert into testapp (appsecret, appredir, pwdapp) values ('" & txtAppSecret.Text & "','" & txtRedirURL.Text & "','" & txtPwd.Text & "')"
        If executeDB(q, "ssodb") = "ok" Then
            divMsg.InnerHtml = "App Aded"
            Response.Redirect("tester.aspx")
        Else
            divMsg.InnerHtml = "App Failed " & q
        End If

    End Sub
End Class
