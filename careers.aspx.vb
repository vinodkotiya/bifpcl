Imports Common
Imports dbOp
Partial Class careers
    Inherits System.Web.UI.Page

    Private Sub dashboardTS_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2, True)
            divNotification.InnerHtml = getNotification(1)
            divNotificationMobile.InnerHtml = getNotification(1, True)
            If Request.Form.Count = 1 Then
                Dim appsecret = "SjY1bBAA5fBIEs2eeJgytb01z6dC/BR479D0jANmlSM="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            divLogin.InnerHtml = showAccount(Session("email"), True)
            divLoginMobile.InnerHtml = showAccount(Session("email"), True)
            divHome.Visible = True
        End If
    End Sub
End Class
