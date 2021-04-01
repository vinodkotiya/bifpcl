Imports dbOp
Imports System.IO
Partial Class download
    Inherits System.Web.UI.Page

    Private Sub download_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Try
            If Request.Params("file") Is Nothing Then
                executeDB("insert into login (eid, log, logintime) values (9, 'Download Page Access Unautorised access by:unknown at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
                Response.StatusCode = 404
                Exit Sub
            End If


            Dim file = Request.Params("file").ToString.Replace("'", "")
            Dim q = "Select secure from upload where filename = '" & file & "' limit 1"
            Dim secret = getDBsingle(q)
            If secret = "1" Then
                If Session("email") Is Nothing Then
                    executeDB("insert into login (eid, log, logintime) values (9, 'Download Page Access Denied for " & file & " by:unknown at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
                    Response.Write("You have not logged in to download the file. <a href=default.aspx >Back</a>")
                    Exit Sub
                End If
                'If Not (checkAuthorization(Session("email"), "onlybifpcl") Or checkAuthorization(Session("email"), "dprm.aspx")) Then
                If Not checkAuthorization(Session("email"), "onlybifpcl") Then
                    executeDB("insert into login (eid, log, logintime) values (9, 'Download Page Access Denied for " & file & " by:" & Session("email") & " at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
                    Response.Write("You have not authorised to download the file")
                    Exit Sub
                End If
            ElseIf secret = "2" Then
                ''' if registration done then file shall be opened from mail link with parameter email encrypted.
                If Request.Params("rrg") Is Nothing Then
                    ''go to registration form page
                    executeDB("insert into login (eid, log, logintime) values (9, 'Download Page Access registration required for " & file & " by user at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
                    Response.Write("You need registration to download the file. Redirecting you to registration page.")
                    Response.Redirect("downloadReg.aspx?file=" & file)
                    Exit Sub
                Else
                    Dim email = Request.Params("rrg").ToString.Replace("'", "")
                    executeDB("insert into login (eid, log, logintime) values (9, 'Download Page Access registered user downloaded file " & file & " by encrypted email " & email & " at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
                    q = "update uploadreg set views=views+1 where email = '" & email & "' and filename='" & file & "'"
                    executeDB(q)
                    ''' allow file download
                End If

                End If

            ''if secret = 0        ''' allow file download
            q = "select 'upload/' || section || '/' ||type || '/' || filename from upload where filename = '" & file & "' limit 1"
                Dim filepath = getDBsingle(q)
                If filepath.Contains("Error") Then
                '  Response.StatusCode = 404
                Response.Write("Requested file does not exist. Please check the link.<a href=default.aspx >Back</a>")

                Exit Sub
                End If

                Dim oFileInformation As FileInfo = New FileInfo(Server.MapPath(filepath))
                executeDB("update hits set view = view+1 where page = 'download'")
            executeDB("insert into login (eid, log, logintime) values (9, 'Download Page Access: Secret=" & secret & " for " & file & " by:" & Session("email") & " at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")

            If oFileInformation.Exists Then
                    Response.Clear()
                    Response.AddHeader("Content-Disposition", "attachment; filename=" & oFileInformation.Name)
                    Response.AddHeader("Content-Length", oFileInformation.Length.ToString())
                    Response.ContentType = "application/octet-stream"
                    Response.Flush()
                    Response.WriteFile(oFileInformation.FullName)
                    Response.[End]()
                Else
                    Response.StatusCode = 404
                End If
            'Catch ex As Exception
            '    Response.Write(ex.Message)
            'End Try
        End If
    End Sub
End Class
