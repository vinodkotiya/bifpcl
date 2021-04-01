Imports Common
Imports dbOp
Partial Class wnew
    Inherits System.Web.UI.Page

    Private Sub dashboardTS_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim bday = getDBsingle("select group_concat('&nbsp;<i class=''fa fa-gift''></i>&nbsp;' || name || ' on ' || strftime('%d.%m' ,newdob)) from (select name , dob, strftime('%Y', current_timestamp) || '-' || strftime('%m', dob) || '-' || strftime('%d', dob) as newdob from contacts_New where newdob > current_date  order by newdob asc limit 3)", "hrdb")
            divBday.InnerHtml = "<span class='badge badge-pill badge-success'>Upcoming Birthday:</span><br/>" &
                                        bday

            'If Request.Form.Count = 1 Then
            '    Dim appsecret = "eAVMt6AUhNrTVIVK7w4ke/eXNxaIth2ALv8NZ6lTfsg="
            '    Session("email") = Decrypt(Request.Form("email"), appsecret)
            '    '  divBug.InnerHtml = Session("email")
            'End If

        End If
    End Sub
End Class
