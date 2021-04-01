Imports Common
Imports dbOp
Imports System.IO
Imports System.Drawing           'CoreCompat Image handling

Imports System.Drawing.Drawing2D   'CoreCompat Image handling

Imports System.Drawing.Imaging       'CoreCompat Image handling
Imports System.Data
Partial Class dashboardTS
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

            If Request.QueryString("mode") = "cricview" Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343266")

                divHome.Visible = False
                Dim q = "select auth from critical_auth where  email  = '" & Session("email") & "' limit 1"
                Dim ret = getDBsingle(q, "dprdb")
                If Not ret.Contains("1") And Not checkAuthorization(Session("email"), "onlybifpcl") Then
                    divMsg.InnerHtml = "You are not authorised to View. Contact TS for authorisation"
                    divOBSEntry.Visible = False
                    Exit Sub
                End If


                divOBS.Visible = True
                divOBSView.Visible = True

                ddlCricAgency.DataSource = getDBTable("select distinct agency from critical_fdn ", "dprdb")
                ddlCricAgency.DataBind()
                ddlCricAgency.Items.Add(New ListItem("Show All", "%"))
                ddlCricAgency.SelectedValue = "%"
                txtCricDate.Text = getDBsingle("select strftime('%d.%m.%Y', prog_dt) from critical_fdn where 1 order by uid desc limit 1", "dprdb")
                loadCriticalFdn()
            ElseIf Request.QueryString("mode") = "cricentry" Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343266")

                divHome.Visible = False
                Dim q = "select auth from critical_auth where  email  = '" & Session("email") & "' limit 1"
                Dim ret = getDBsingle(q, "dprdb")
                If Not ret.Contains("1") Then
                    divMsg.InnerHtml = "You are not authorised to make Entry. Contact TS for authorisation"
                    divOBSEntry.Visible = False
                    Exit Sub
                End If
                divOBS.Visible = True
                divOBSEntry.Visible = True
                ddlNewAgency.DataSource = getDBTable("select distinct agency from critical_fdn ", "dprdb")
                ddlNewAgency.DataBind()
                ddlNewWorkArea.DataSource = getDBTable("select distinct area from critical_fdn where agency = '" & ddlNewAgency.SelectedValue & "'", "dprdb")
                ddlNewWorkArea.DataBind()
                If Not Request.QueryString("id") Is Nothing Then
                    lbObsID.Text = Request.QueryString("id")
                    ddlNewAgency.Enabled = False
                    ddlNewWorkArea.Enabled = False

                End If
            ElseIf Request.QueryString("mode") = "cricadd" Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343266")
                If Not (checkAuthorization(Session("email"), "dprUpdate.aspx?mode=add")) Then
                    divMsg.InnerHtml = "You are not authorised to make Entry. Contact TS for authorisation"
                    divOBS.Visible = False
                    Exit Sub
                End If
                divHome.Visible = False
                divOBS.Visible = True
                divOBSAgency.Visible = True
            End If

        End If
    End Sub
    Sub loadCriticalFdn()
        Dim dt As Date
        Try

            dt = DateTime.ParseExact(txtCricDate.Text, "dd.M.yyyy", Nothing)
        Catch e As Exception
            dt = New Date(1999, 1, 1)
            txtCricDate.Text = "01.01.1999"
        End Try
        Dim q = "select uid, agency, area,pic, prog, manpower, wrm, remark, last_updated from critical_fdn where agency like '%" & ddlCricAgency.SelectedValue & "%' and prog_dt = '" & dt.ToString("yyyy-MM-dd") & "' "
        Try

            Dim mydt = getDBTable(q, "dprdb")
            gvReportPic.DataSource = mydt
            gvReportPic.DataBind()
            ' lbCricMsg.Text = q
        Catch e As Exception
            lbCricMsg.Text = "Error " & e.Message ' q
        End Try
    End Sub
    Protected Sub UploadFile(sender As Object, e As EventArgs)
        Dim msg = ""
        '    If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343326")
        If String.IsNullOrEmpty(txtCricProg.Text) Then
            lbBookMessageTop.Text = "Progress can't be blank"
            Exit Sub
        End If
        Try

            If FileUpload1.PostedFile IsNot Nothing Then
                Dim uploadDir = "upload/TS/Report/"
                If Not System.IO.Directory.Exists(Server.MapPath(uploadDir)) Then
                    msg = "Creating Path " & uploadDir & "<br/>"
                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir))
                End If

                Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                Dim ext = ".jpg" ' Path.GetExtension(FileName)
                Dim newFilename = "cric" & Now.ToString("dMMyHHmmss") & ext
                FileUpload1.SaveAs(Server.MapPath(uploadDir & "Big" & newFilename))
                Image_resize(uploadDir & "Big" & newFilename, uploadDir & newFilename, 1024)

                If System.IO.File.Exists(Server.MapPath(uploadDir & "Big" & newFilename)) Then
                    System.IO.File.Delete(Server.MapPath(uploadDir & "Big" & newFilename))
                    msg = "Attempt to delete " & uploadDir & "Big" & newFilename
                Else
                    msg = "Not exist " & uploadDir & "Big" & newFilename
                End If
                '  divPic.InnerHtml = "<img src=" & "upload/SAFETY/Report/" & newFilename & "?" & Now.Second & " />"
                lbPicStatus.Text = "Pic Uploaded"

                ''' Now Enter the Data
                ''' 
                Dim q = ""
                Dim dt = DateTime.ParseExact(txtProgDate.Text, "dd.M.yyyy", Nothing)
                If String.IsNullOrEmpty(lbObsID.Text) Then
                    q = "insert into critical_fdn( agency,area,pic,prog, manpower,wrm, remark, prog_dt, last_updated, lastupateby) " &
               "values ('" & ddlNewAgency.SelectedValue & "','" & ddlNewWorkArea.SelectedValue & "','" & newFilename & "','" & txtCricProg.Text.Replace("'", "") & "','" & txtCricManpower.Text.Replace("'", "") & "','','" & txtCricRemark.Text.Replace("'", "") & "','" & dt.ToString("yyyy-MM-dd") & "',current_timestamp,'" & Session("email") & "' )"

                Else
                    q = "update critical_fdn set pic = '" & newFilename & "', prog = '" & txtCricProg.Text.Replace("'", "") & "', manpower='" & txtCricManpower.Text.Replace("'", "") & "', lastupateby ='" & Session("email") & "', last_updated=current_timestamp where uid = '" & lbObsID.Text & "'"
                End If
                If executeDB(q, "dprdb") = "ok" Then
                    msg = msg & "<br/>Record Updated"
                    txtCricProg.Text = ""
                    '  Response.Redirect("safety.aspx?mode=obsview")
                Else
                    msg = msg & "Error: " & q
                End If
            End If

            '  lbBookMessage.Text = "Pic Uploaded" ' msg
            lbBookMessageTop.Text = "Pic Uploaded " & msg 'lbBookMessage.Text
        Catch _ex As Exception
            lbBookMessageTop.Text = "No picture selected for upload" & _ex.Message
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

    Private Sub ddlCricAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCricAgency.SelectedIndexChanged
        loadCriticalFdn()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        loadCriticalFdn()
    End Sub

    Private Sub ddlNewAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlNewAgency.SelectedIndexChanged
        ddlNewWorkArea.DataSource = getDBTable("select distinct area from critical_fdn where agency = '" & ddlNewAgency.SelectedValue & "'", "dprdb")
        ddlNewWorkArea.DataBind()
    End Sub

    Private Sub btnAddAgency_Click(sender As Object, e As EventArgs) Handles btnAddAgency.Click
        If String.IsNullOrEmpty(txtAgency.Text) Or String.IsNullOrEmpty(txtArea.Text) Then
            Exit Sub
        End If
        Dim q = "insert into critical_fdn ( agency,area,prog_dt) values ('" & txtAgency.Text.Replace("'", "") & "','" & txtArea.Text.Replace("'", "") & "','0000-00-00')"
        Dim ret = executeDB(q, "dprdb")
        If ret = "ok" Then
            btnAddAgency.Text = "Added..."
            btnAddAgency.Enabled = False
        End If
    End Sub
End Class
