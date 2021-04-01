Imports Common
Imports dbOp
Partial Class dashboardTS
    Inherits System.Web.UI.Page

    Private Sub dashboardTS_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2, True)
            divNotification.InnerHtml = getNotification(1)

            divNotificationMobile.InnerHtml = getNotification(1, True)
            Session("email") = "vinodkotiya@bifpcl.com"
            'If Request.Form.Count = 1 Then
            '    Dim appsecret = "eAVMt6AUhNrTVIVK7w4ke/eXNxaIth2ALv8NZ6lTfsg="
            '    Session("email") = Decrypt(Request.Form("email"), appsecret)
            '    '  divBug.InnerHtml = Session("email")
            'End If
            divLogin.InnerHtml = showAccount(Session("email"), True)
            divLoginMobile.InnerHtml = showAccount(Session("email"), True)
        End If
    End Sub
End Class
