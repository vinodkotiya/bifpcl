Imports dbOp
Imports System.IO
Imports System.Drawing           'CoreCompat Image handling

Imports System.Drawing.Drawing2D   'CoreCompat Image handling

Imports System.Drawing.Imaging       'CoreCompat Image handling
Partial Class Gallery
    Inherits System.Web.UI.Page

    Private Sub Gallery_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343272")
                If Not (checkAuthorization(Session("email"), "onlybifpcl") Or checkAuthorization(Session("email"), "Gallery.aspx")) Then
                    divMsg.InnerHtml = "Module is only for BIFPCL Employees..Upload button disabled"
                    btnUpload.Enabled = False
                    Exit Sub
                End If
                divMsg.InnerHtml = "Loading Gallery"
                bindddl()
                BindGridView()
                BindImageRepeater()
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Sub bindddl()
        Dim q = "select ImageEvent || '#' || ImageDate as t, ImageEvent || '#' || ImageDate as v from ImageSlider where lastupdateby='" & Session("email") & "'  group by ImageEvent,ImageDate order by ImageDate desc"
        If (checkAuthorization(Session("email"), "Gallery.aspx")) Then
            q = "select ImageEvent || '#' || ImageDate as t, ImageEvent || '#' || ImageDate as v from ImageSlider where 1  group by ImageEvent,ImageDate order by ImageDate desc"
        End If
        ddlGallery.DataSource = getDBTable(q)
            ddlGallery.DataTextField = "t"
            ddlGallery.DataValueField = "v"
            ddlGallery.DataBind()

        '  txtDate.Text = v(1)
    End Sub
    Private Sub BindGridView()
        Try
            Dim v() = ddlGallery.SelectedValue.Split("#")
            GridView1.DataSource = getDBTable("SELECT ID,ImageEvent || ' ' || ImageDate as ImageEvent, ImageName, ImagePath FROM ImageSlider where  ImageEvent like '" & v(0) & "' and ImageDate like '" & v(1) & "'")
            GridView1.DataBind()
        Catch ex As Exception
            divMsg.InnerHtml = "Error in bind grid view" & ex.Message
        End Try
    End Sub

    Protected Function GetActiveClass(ByVal ItemIndex As Integer) As String
        If ItemIndex = 0 Then
            Return "active"
        Else
            Return ""
        End If
    End Function

    Private Sub BindImageRepeater()
        Try
            Dim v() = ddlGallery.SelectedValue.Split("#")
            Repeater1.DataSource = getDBTable("SELECT ID,ImageEvent || ' ' || ImageDate as ImageEvent, ImageName, ImagePath FROM ImageSlider where  ImageEvent like '" & v(0) & "' and ImageDate like '" & v(1) & "'")
            Repeater1.DataBind()
        Catch ex As Exception
            divMsg.InnerHtml = "Error in bind image repeater" & ex.Message & ddlGallery.SelectedValue
        End Try
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343272")
        Try

            If SliderFileUpload.PostedFile IsNot Nothing Then
                Dim uploadDir = "upload/various/pics/"
                If Not System.IO.Directory.Exists(Server.MapPath(uploadDir)) Then
                    divMsg.InnerHtml = "Creating Path " & uploadDir & "<br/>"
                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir))
                End If

                Dim FileName As String = Path.GetFileName(SliderFileUpload.PostedFile.FileName)
                Dim ext = Path.GetExtension(FileName)
                Dim newFilename = "BIFPCL" & Now.ToString("ddMMyHHmmss") & ext
                SliderFileUpload.SaveAs(Server.MapPath(uploadDir & "Big" & newFilename))
                Image_resize(uploadDir & "Big" & newFilename, uploadDir & newFilename, rblSize.SelectedValue)
                ''farzi call o unlock
                ''  Image_resize("upload/various/pics/test.jpg", "upload/various/pics/test1.jpg", 1024)
                Dim dt = DateTime.ParseExact(txtDate.Text, "dd.M.yyyy", Nothing)

                Dim q = "insert into ImageSlider(ImageName,ImagePath, ImageDate, ImageEvent, last_updated,lastupdateby) " &
                " values('" & newFilename & "','" & uploadDir & newFilename & "','" & dt.ToString("yyyy-MM-dd") & "','" & txtEvent.Text.Replace("'", "") & "',current_timestamp,'" & Session("email") & "')  "
                If executeDB(q) = "ok" Then
                    BindGridView()
                    BindImageRepeater()
                    If System.IO.File.Exists(Server.MapPath(uploadDir & "Big" & newFilename)) Then
                        System.IO.File.Delete(Server.MapPath(uploadDir & "Big" & newFilename))
                        divMsg.InnerHtml = "Attempt to delete " & uploadDir & "Big" & newFilename
                        bindddl()
                    Else
                        divMsg.InnerHtml = "Not exist " & uploadDir & "Big" & newFilename
                    End If
                Else
                    divMsg.InnerHtml = "Error in insert data " & q
                End If
            End If

        Catch _ex As Exception
            divMsg.InnerHtml = _ex.Message
        End Try
    End Sub
    Private Sub Image_resize(ByVal input_Image_Path As String, ByVal output_Image_Path As String, ByVal new_Width As Integer)
        Const quality As Long = 50L
        Dim source_Bitmap As Bitmap = New Bitmap(Server.MapPath(input_Image_Path))
        Dim dblWidth_origial As Double = source_Bitmap.Width
        Dim dblHeigth_origial As Double = source_Bitmap.Height
        Dim relation_heigth_width As Double
        relation_heigth_width = dblHeigth_origial / dblWidth_origial
        Dim new_Height As Integer = CInt((new_Width * relation_heigth_width))
        If dblWidth_origial < dblHeigth_origial Then  'portrit
            relation_heigth_width = dblWidth_origial / dblHeigth_origial
            new_Height = new_Width
            new_Width = CInt((new_Height * relation_heigth_width))
        End If

        Dim new_DrawArea = New Bitmap(new_Width, new_Height)

        Using graphic_of_DrawArea = Graphics.FromImage(new_DrawArea)
            graphic_of_DrawArea.CompositingQuality = CompositingQuality.HighSpeed
            graphic_of_DrawArea.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphic_of_DrawArea.CompositingMode = CompositingMode.SourceCopy
            graphic_of_DrawArea.DrawImage(source_Bitmap, 0, 0, new_Width, new_Height)

            Using output = System.IO.File.Open(Server.MapPath(output_Image_Path), FileMode.Create)
                Dim qualityParamId = Encoder.Quality
                Dim encoderParameters = New EncoderParameters(1)
                encoderParameters.Param(0) = New EncoderParameter(qualityParamId, quality)
                Dim codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(Function(c) c.FormatID = ImageFormat.Jpeg.Guid)
                new_DrawArea.Save(output, codec, encoderParameters)
                output.Close()
            End Using

            graphic_of_DrawArea.Dispose()
        End Using

        source_Bitmap.Dispose()
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim item As String = e.Row.Cells(1).Text

            For Each button As Button In e.Row.Cells(3).Controls.OfType(Of Button)()

                If button.CommandName = "Delete" Then
                    button.Attributes("onclick") = "if(!confirm('Do you want to delete " & item & "?')){ return false; };"
                End If

            Next
        End If
    End Sub

    'Private Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
    '    Dim value = e.CommandArgument.ToString()
    '    If e.CommandName = "Delete" Then
    '        divMsg.InnerHtml = "Deleting" '& index
    '    End If

    'End Sub

    Private Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim msg = ""
        Dim index = GridView1.DataKeys(e.RowIndex).Value.ToString
        '   Dim item As String = e.Row.Cells(index).Text
        divMsg.InnerHtml = "Deleting" & index
        Dim newFilename = getDBsingle("select ImageName from ImageSlider where ID =" & index)

        Dim q = "delete from ImageSlider where ID =" & index
        If executeDB(q) = "ok" Then
            msg = msg & "Deleted from database <br/>"
        Else
            msg = msg & "Delete failed from database <br/>"
        End If
        If System.IO.File.Exists(Server.MapPath("upload/various/pics/" & newFilename)) Then
            System.IO.File.Delete(Server.MapPath("upload/various/pics/" & newFilename))
            msg = msg & "Attempt to delete " & "upload/various/pics/" & newFilename
        Else
            msg = msg & "Not exist " & "upload/various/pics/" & newFilename
        End If
        divMsg.InnerHtml = msg
        BindGridView()
    End Sub


    Private Sub ddlGallery_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlGallery.SelectedIndexChanged
        Dim v() = ddlGallery.SelectedValue.Split("#")
        txtEvent.Text = v(0)
        BindGridView()
        BindImageRepeater()
    End Sub


    Protected Sub btnCover(sender As Object, e As CommandEventArgs)
        Dim item As String = e.CommandArgument
        divMsg.InnerHtml = item
        Dim q = "update ImageSlider set cover = 0 where imageevent in (select imageevent from ImageSlider where ID =" & item & " )  ; update ImageSlider set cover = 1 where ID =" & item
        If executeDB(q) = "ok" Then
            divMsg.InnerHtml = "Made cover for ID =" & item
        Else
            divMsg.InnerHtml = "failed cover for ID =" & item
        End If
    End Sub

    Private Sub btnLock_Click(sender As Object, e As EventArgs) Handles btnLock.Click
        Dim v() = ddlGallery.SelectedValue.Split("#")
        Dim q = "update ImageSlider set lock = 1 where ImageEvent like '" & v(0) & "' and ImageDate like '" & v(1) & "'"
        If executeDB(q) = "ok" Then
            divMsg.InnerHtml = "locked album for ImageEvent like '" & v(0) & "' and ImageDate like '" & v(1) & "'"
        Else
            divMsg.InnerHtml = "failed cover for ImageEvent like '" & v(0) & "' and ImageDate like '" & v(1) & "'"
        End If
    End Sub

    Private Sub btnUnlock_Click(sender As Object, e As EventArgs) Handles btnUnlock.Click
        Dim v() = ddlGallery.SelectedValue.Split("#")
        Dim q = "update ImageSlider set lock = 0 where ImageEvent like '" & v(0) & "' and ImageDate like '" & v(1) & "'"
        If executeDB(q) = "ok" Then
            divMsg.InnerHtml = "locked album for ImageEvent like '" & v(0) & "' and ImageDate like '" & v(1) & "'"
        Else
            divMsg.InnerHtml = "failed cover for ImageEvent like '" & v(0) & "' and ImageDate like '" & v(1) & "'"
        End If
    End Sub
End Class
