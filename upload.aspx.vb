Imports Common
Imports dbOp
Imports System.IO
'Imports DotNet.Highcharts
'Imports DotNet.Highcharts.Options
'Imports DotNet.Highcharts.Options.Series
'Imports DotNet.Highcharts.Attributes
'Imports DotNet.Highcharts.Helpers
'Imports DotNet.Highcharts.Enums
'Imports System.Data
'Imports System.Drawing

Partial Class _upload
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        '  Session("email") = "md_mintu_miah@live.com"
        If Not Page.IsPostBack Then
            If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343284")
            If Not (checkAuthorization(Session("email"), "onlybifpcl") Or checkAuthorization(Session("email"), "docStore.aspx")) Then  ''Pass url or onlybifpcl for all bifplc executives
                divProfile.Visible = False
                divUpdate.Visible = False
                divMsg.InnerHtml = "Unauthorised Access. Only available for BIFPCL Executives."
                Exit Sub
            End If
            Dim q As String = "Select distinct descr as t, dept as v from dept where 1 order by descr asc"
            ddlSection.DataTextField = "t"
            ddlSection.DataValueField = "v"
            ddlSection.DataSource = getDBTable(q)
            ddlSection.DataBind()
            q = "Select distinct descr as t, type as v from uploadtype where 1 order by descr asc"
            ddlDocType.DataTextField = "t"
            ddlDocType.DataValueField = "v"
            ddlDocType.DataSource = getDBTable(q)
            ddlDocType.DataBind()
            ddlDocType_SelectedIndexChanged(vbNull, EventArgs.Empty)

            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2)
            divNotification.InnerHtml = getNotification(1)
            '   divLogin.InnerHtml = showAccount("9383", "Vinod Kumar Kotiya", "vinodkotiya@ntpc.co.in")
            divLogin.InnerHtml = showAccount(Session("email"))
            If Not (checkAuthorization(Session("email"), "onlybifpcl") Or checkAuthorization(Session("email"), "upload.aspx")) Then  ''Pass url or onlybifpcl for all bifplc executives  ''Pass url or onlybifpcl for all bifplc executives
                divProfile.Visible = False
                divMsg.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                Exit Sub
            End If
            SqlDataSource1.SelectParameters("lastupdateby").DefaultValue = Session("email")
            If Session("email") = "vinodkotiya@bifpcl.com" Then SqlDataSource1.SelectParameters("lastupdateby").DefaultValue = "%"
            If checkAuthorization(Session("email"), "upload.aspx") Then SqlDataSource1.SelectParameters("lastupdateby").DefaultValue = "%"
                divProfile.Visible = True

            End If

            executeDB("update hits set view = view+1 where page = 'upload'")
        executeDB("insert into login (eid, log, logintime) values (0, 'Upload Page Access : at " & Now.ToString() & "" & Session("email") & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub
    Private Sub ddlDocType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDocType.SelectedIndexChanged
        Dim q = "Select secret from uploadtype where type ='" & ddlDocType.SelectedValue & "' limit 1"
        Dim secret = getDBsingle(q)
        If secret = "1" Then : rblSecret.SelectedValue = 1
        Else : rblSecret.SelectedValue = 0
        End If
        'divMsg.InnerHtml = q
    End Sub


    Protected Sub btnUpload_Click(sender As Object, e As EventArgs)
        If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343284")
        If String.IsNullOrEmpty(txtSubject.Text) Then
            divMsg.InnerHtml = "Please Enter the Subject/Descr"
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDate.Text) Then
            divMsg.InnerHtml = "Please Enter the Document Date"
            Exit Sub
        End If
        If checkForSQLInjection(txtSubject.Text) Then
            divMsg.InnerHtml = "Special character not allowed eg:  delete, table, update"
            Exit Sub
        End If
        Dim subject = txtSubject.Text.Replace("'", "")
        Dim newFilename = ""
        Try
            Dim destfolder = ddlSection.SelectedValue & "/" & ddlDocType.SelectedValue  '"vcr"
            ' lblStatus.Text = "Uploading..."
            System.Threading.Thread.Sleep(2000)
            Dim temp As String = ""
            '####### Create Directory
            Dim uploadDir As String = ""

            uploadDir = "./upload/" & destfolder & "/"    'upload/cmg/govt/


            If Not System.IO.Directory.Exists(Server.MapPath(uploadDir)) Then
                temp = "Creating Path " & uploadDir & "<br/>"
                System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir))
            End If

            '###### Upload File

            Dim fileName As String = "" 'ddlUploadType.SelectedValue
            Dim uploadFiles As HttpFileCollection = Request.Files
            For i As Integer = 0 To uploadFiles.Count - 1
                Dim uploadFile As HttpPostedFile = uploadFiles(i)
                fileName = System.IO.Path.GetFileName(uploadFile.FileName)
                '' Check for Exception should only be word
                'pdf True AND TRUE AND TRUE
                'doc TRUE AND FALSE AND TRUE

                If String.IsNullOrEmpty(fileName) Then
                    divMsg.InnerHtml = "Please attach a file..."
                    Exit Sub
                End If
                'remove spaces
                '  fileName = Left(txtSubject.Text, 6) & Now.Day & Now.Second  'fileName.Replace(" ", "_")
                'fileName = fileName.Replace("/", "_")
                'fileName = fileName.Replace("\", "_")
                '   fileName = strip(fileName)
                ''remove single quotes , / , \ 
                'fileName = fileName.Replace("'", "_")
                Dim ext = Path.GetExtension(fileName)
                newFilename = "BIFPCL" & Now.ToString("ddMMyHHmmss") & ext
                If newFilename.Trim().Length > 0 Then
                    'uploadFile.SaveAs(Server.MapPath("./Others/") + fileName)
                    uploadFile.SaveAs(Server.MapPath(uploadDir) + newFilename)

                    temp = temp & "<img src='images/ok.png' />Successfully Uploaded: " & newFilename & " <br/>"

                End If
            Next
            Dim dt = DateTime.ParseExact(txtDate.Text, "dd.M.yyyy", Nothing)
            Dim secret = rblSecret.SelectedValue
            '  If cbSecret.Checked Then secret = 1
            Dim myquery As String = ""
            If temp.Contains("Successfully") Then
                myquery = "insert into upload(type, docdt, subject, secure, section, filename, lastupdateby, last_updated, downloads,  exist) " &
               "values ('" & ddlDocType.SelectedValue & "','" & dt.ToString("yyyy-MM-dd") & "','" & subject & "'," & secret & ",'" & ddlSection.SelectedValue & "','" & newFilename & "','" & Session("email") & "',current_timestamp,1,1 )"
                If executeDB(myquery) = "ok" Then
                    temp = temp & "Record Updated. <a href='docstore.aspx'> <button type='button' class='btn btn-primary m-l-10 m-b-10'>Go to docStore</button> </a>"
                    'Dim ffMpeg = New NReco.VideoConverter.FFMpegConverter()
                    'ffMpeg.GetVideoThumbnail(Server.MapPath(uploadDir) + fileName, Server.MapPath("./upload/vcr/") + fileName & ".jpg", Rnd(7000)) 'Left(r(0), 8)
                    ' Response.Redirect("vc.aspx?file=success&thumbnailcreated")
                Else
                    temp = temp & "Error: " & myquery
                End If
            Else
                temp = temp & "Unable to upload. Try Again.<br/>" & fileName
            End If
            divMsg.InnerHtml = temp & "<br/>" '& myquery

        Catch e1 As Exception
            divMsg.InnerHtml = e1.Message
        End Try

    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("ondblclick") = Page.ClientScript.GetPostBackClientHyperlink(gvDPRDetail, "Edit$" & e.Row.RowIndex)
            e.Row.Attributes("style") = "cursor:pointer"
        End If
    End Sub
End Class
