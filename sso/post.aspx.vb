
Partial Class post
    Inherits System.Web.UI.Page

    Private Sub post_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Session("email_enc") Is Nothing Then
                Response.Write("No Session created")
                Exit Sub
            End If
            Dim collections As New NameValueCollection()
            ' collections.Add("eid", Session("eid_enc"))
            collections.Add("email", Session("email_enc"))
            Dim remoteUrl As String = dbOp.getDBsingle("select appredir from vinapp where appid='" & Session("appid") & "'", "ssodb")

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
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class
