Imports Common
Imports dbOp
Imports System.IO
Imports System.Drawing           'CoreCompat Image handling

Imports System.Drawing.Drawing2D   'CoreCompat Image handling

Imports System.Drawing.Imaging       'CoreCompat Image handling
Imports System.Data
'Imports DotNet.Highcharts
'Imports DotNet.Highcharts.Options
'Imports DotNet.Highcharts.Options.Series
'Imports DotNet.Highcharts.Attributes
'Imports DotNet.Highcharts.Helpers
'Imports DotNet.Highcharts.Enums
'Imports System.Data
'Imports System.Drawing

Partial Class _safety
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        '  Session("email") = "md_mintu_miah@live.com"
        If Not Page.IsPostBack Then

            If Request.Form.Count = 1 Then
                Dim appsecret = "ocuDE7BSss9/C7kEP9xicrtTZ02sV9gf6wuNci1mHfY="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2, True)
            divNotification.InnerHtml = getNotification(1)
            divNotificationMobile.InnerHtml = getNotification(1, True)
            divLogin.InnerHtml = showAccount(Session("email"), True)
            divLoginMobile.InnerHtml = showAccount(Session("email"), True)

            Dim onlyBIFPCL = False
            If Not Request.QueryString("mode") Is Nothing Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343302")
                If (checkAuthorization(Session("email"), "onlybifpcl") Or checkAuthorization(Session("email"), "safety.aspx")) Then
                    'divMsg.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to upload report.<br/> May please contact TS Dept and provide your email id for authorisation."
                    'btnSubmit.Enabled = False
                    'Exit Sub
                    onlyBIFPCL = True
                End If
                divPics.Visible = False
                divEmergency.Visible = False
                divHome.Visible = False
            End If
            Dim Incidenttype = ""
            If Request.QueryString("mode") = "incidentall" Then
                Dim q = "select auth from safety_auth where auth = 'edit' and email  = '" & Session("email") & "' limit 1"
                Dim ret = getDBsingle(q, "appsdb")
                Dim auth = False
                If ret.Contains("edit") Then auth = True
                If checkAuthorization(Session("email"), "onlybifpcl") Or auth Then
                    divIncident.Visible = True
                    loadClearances()
                Else
                    divMsg.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to view this section.<br/> May please contact SAFETY Dept and provide your email id for authorisation."

                End If
            ElseIf Request.QueryString("mode") = "incident" Then

                If (checkAuthorization(Session("email"), "safety.aspx?mode=incident")) Then
                    divIncidentRecording.Visible = True
                    divEditor.Visible = True
                    ddlIncidentPicture.DataSource = getDBTable("select ImageEvent || '#' || ImageDate as t, ImageEvent || '#' || ImageDate as v from ImageSlider where lastupdateby in (select email from auth where page = 'safety.aspx?mode=incident' ) group by ImageEvent")
                    ddlIncidentPicture.DataTextField = "t"
                    ddlIncidentPicture.DataValueField = "v"
                    ddlIncidentPicture.DataBind()
                    ddlIncidentPicture.Items.Add(New ListItem("Not Uploaded", ""))
                    ddlIncidentPicture.SelectedValue = ""

                End If

            ElseIf Request.QueryString("mode") = "nearmiss" And onlyBIFPCL Then
                Incidenttype = "Near Miss Incident"
                loadIncident(Incidenttype)
            ElseIf Request.QueryString("mode") = "firstaid" And onlyBIFPCL Then
                Incidenttype = "First Aid Injury"
                loadIncident(Incidenttype)
            ElseIf Request.QueryString("mode") = "minor" And onlyBIFPCL Then
                Incidenttype = "Minor Accident"
                loadIncident(Incidenttype)
            ElseIf Request.QueryString("mode") = "property" And onlyBIFPCL Then
                Incidenttype = "Property Damage"
                loadIncident(Incidenttype)
            ElseIf Request.QueryString("mode") = "fatal" And onlyBIFPCL Then
                Incidenttype = "Fatal & Major Incidents"
                loadIncident(Incidenttype)
            ElseIf Request.QueryString("mode") = "training" And onlyBIFPCL Then
                loadTraining()
            ElseIf Request.QueryString("mode") = "summary" And onlyBIFPCL Then
                loadSummary()
            ElseIf Request.QueryString("mode") = "reports" And onlyBIFPCL Then
                divReport.Visible = True
                LoadDocStore("SAFETY", "%")
            ElseIf Request.QueryString("mode") = "obsentry" Then
                divOBS.Visible = True
                divOBSEntry.Visible = True
                ddlNewAgency.DataSource = getDBTable("select distinct agency   from agency order by agency asc", "gpdb")
                ddlNewAgency.DataBind()
                Dim qry_project As String = "Select distinct workarea as t, workarea as v from ProgressMaster where unit =1"
                ddlNewWorkArea.DataSource = getDBTable(qry_project, "dprdb")
                ddlNewWorkArea.DataTextField = "t"
                ddlNewWorkArea.DataValueField = "v"
                ddlNewWorkArea.DataBind()
                ddlNewWorkArea.Items.Add(New ListItem("Mechanical SG", "Mechanical SG"))
                ddlNewWorkArea.Items.Add(New ListItem("Mechanical TG", "Mechanical TG"))
                ddlNewWorkArea.Items.Add(New ListItem("MPH", "MPH"))
                ddlNewWorkArea.Items.Add(New ListItem("Electrical", "Electrical"))
                ddlNewWorkArea.Items.Add(New ListItem("C&I", "C&I"))
                ddlNewWorkArea.Items.Add(New ListItem("Township", "Township"))
                ddlNewWorkArea.Items.Add(New ListItem("ESP", "ESP"))
                ddlNewWorkArea.Items.Add(New ListItem("Others", "Others"))
                If Not Request.QueryString("id") Is Nothing Then
                    '' check if he is allowed for compliance
                    Dim q = "select auth from safety_auth where auth = 'observation' and email  = '" & Session("email") & "' limit 1"
                    Dim ret = getDBsingle(q, "appsdb")
                    If Not ret.Contains("observation") Then
                        divMsg.InnerHtml = "You are not authorised to make compliance(safety_auth). ."
                        divOBSEntry.Visible = False
                        Exit Sub
                    End If
                    lbObsID.Text = Request.QueryString("id")
                    rblOBS.SelectedValue = "com"
                    ddlNewWorkArea.Visible = False
                    ddlNewAgency.Visible = False
                    Exit Sub
                End If
                ''' now check if he can add new
                If Not (checkAuthorization(Session("email"), "safety.aspx?mode=obsentry")) Then
                    divOBSEntry.Visible = False
                    divMsg.InnerHtml = "You are not authorised to make new entry(safety.aspx?mode=obsentry). You can only make compliance."
                End If
            ElseIf Request.QueryString("mode") = "obsview" Then
                divOBS.Visible = True
                divOBSView.Visible = True
                Dim mydt = getDBTable("select uid, agency, area,strftime('%d.%m.%Y', st_dt) || ' - ' || detail as detail,pic,strftime('%d.%m.%Y', reply_dt) || ' - ' || reply as reply,replypic,status from safety_obs where del = 0 ", "appsdb")
                gvReportPic.DataSource = mydt
                    gvReportPic.DataBind()

            End If
            End If

        executeDB("update hits set view = view+1 where page = 'safety'")
        executeDB("insert into login (eid, log, logintime) values (0, 'Safety Page Access : at " & Now.ToString() & "" & Session("email") & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub
    Sub loadClearances()
        Dim q = "select strftime('%d.%m.%Y',docdt) as 'Date', subject as 'Description', '<a href=/upload/SAFETY/Report/' || filename || ' target=_blank>View </a>' as 'Document', lastupdateby as 'By' from safety_clearances where exist = 1 order by last_updated"
        Dim mydt = getDBTable(q, "appsdb")
        If mydt.Rows.Count = 0 Then
            divMsg.InnerHtml = "No records"
        End If
        gvClearances.DataSource = mydt
        gvClearances.DataBind()
    End Sub
    Sub loadSummary()
        gvSummary.DataSource = getDBTable("select  type as 'Incident Type', count(uid) as 'Total' from safety_incident where del = 0 group by type", "appsdb")
        gvSummary.DataBind()
        divTotalIncident.InnerHtml = "<b>Incident Details: </b> Total " & getDBsingle("select count(uid) from safety_incident", "appsdb") & " Nos of Incident"
        gvSummaryTraining.DataSource = getDBTable("select  descr as 'Training Type', count(uid) as 'No of Training', sum(persons) as 'Persons Attended', sum(traininghour) as 'Training Hour'  from  safety_training where del = 0 group by descr", "appsdb")
        gvSummaryTraining.DataBind()
        divTotalTraining.InnerHtml = "<b>Training Details: </b> Total " & getDBsingle("select count(uid) from safety_training", "appsdb") & " Nos of Training"
        divSummary.Visible = True
    End Sub
    Sub loadIncident(ByVal incidenttype As String)
        divType.InnerHtml = incidenttype
        Dim filter = "( type = '" & incidenttype & "' )"
        If incidenttype = "Fatal & Major Incidents" Then filter = "( type = 'Fatal' or type = 'Major Accident' )"
        Dim mydt = getDBTable(" select sn as 'S No',strftime('%d.%m.%Y', dt_incident)  as  'Incident Date', `location` as 'Location', `agency` as 'Agency', `victims` , `detail` as 'Nature of work/Incident Details', `rca` as 'RCA Carried Out', `action` as 'Corrective Action', Remarks, Pictures  from safety_incident where  del = 0 and  " & filter & " order by dt_incident desc ", "appsdb")
        For Each r In mydt.Rows
            If r("Pictures").ToString.Contains("#") Then
                Dim v() = r("Pictures").ToString.Split("#")
                Dim pic = "Galleryshow.aspx?imageevent=" & Server.UrlEncode(v(0)) & "&imagedate=" & v(1) & ""
                r("Pictures") = "<b><a href='" & pic & "' target=_blank >" & "View Pics" & "</a></b>"

            Else
                r("Pictures") = "Not Uploaded"
            End If
        Next
        gvIncidents.DataSource = mydt
        gvIncidents.DataBind()
        divIncidents.Visible = True
    End Sub
    Private Sub gvDPRDetail_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDPRDetail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            If (e.Row.RowState And DataControlRowState.Edit) > 0 Then
                Dim ddList As DropDownList = CType(e.Row.FindControl("ddlPictures"), DropDownList)
                ddList.DataSource = getDBTable("select ImageEvent || '#' || ImageDate as t, ImageEvent || '#' || ImageDate as v from ImageSlider where lastupdateby in (select email from auth where page = 'safety.aspx?mode=incident' ) group by ImageEvent, ImageDate")
                ddList.DataTextField = "t"
                ddList.DataValueField = "v"
                ddList.DataBind()
                ddList.Items.Add(New ListItem("Not Uploaded", ""))
                Dim dr As DataRowView = TryCast(e.Row.DataItem, DataRowView)
                ddList.SelectedValue = dr("Pictures").ToString()
            End If
        End If
    End Sub
    Private Sub gvDPRDetail_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles gvDPRDetail.RowUpdating
        Dim ddList As DropDownList = CType(gvDPRDetail.Rows(e.RowIndex).FindControl("ddlPictures"), DropDownList)
        SqlDataSource1.UpdateParameters("Pictures").DefaultValue = ddList.SelectedValue.ToString
    End Sub
    Private Sub gvIncidents_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvIncidents.RowDataBound
        Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(9).Text)
        e.Row.Cells(9).Text = decodedText
        'e.Row.Cells(2).Attributes.Add("style", "width:600px; word-break:break-all;word-wrap:break-word;")
    End Sub
    Sub loadTraining()
        gvTraining.DataSource = getDBTable("  select uid as 'S No', strftime('%d.%m.%Y', `training_dt`) as 'Training Date', `descr` as 'Description', `agency` as 'Agency', duration as 'Training Duration', `persons` as 'Persons Attended', `traininghour` as 'Training Hour', `participants` as 'Participants'  from safety_training where del = 0", "appsdb")
        gvTraining.DataBind()
        divTraining.Visible = True
    End Sub
    Private Sub gvDocStore_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDocStore.RowDataBound
        Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(1).Text)
        e.Row.Cells(1).Text = decodedText
        e.Row.Cells(1).Attributes.Add("style", "width:600px; word-break:break-all;word-wrap:break-word;")
    End Sub
    Sub LoadDocStore(ByVal section As String, ByVal keyword As String)
        Dim secret = " and secure = 1"
        Dim q = "select type,  subject as Description, strftime('%d.%m.%Y', docdt) as 'Date', secure, section, filename,  strftime('%d.%m.%Y', last_updated) as 'Upload', downloads as views, '' as 'Size(MB)',lastupdateby as By from upload where exist = 1 and section like '%" & section & "%' and subject like '" & keyword & "%' " & secret & " order by docdt desc "
        Try
            Dim mydt = getDBTable(q)
            If mydt.Rows.Count = 0 Then
                divMsg.InnerHtml = "No documents found" '& q
                gvDocStore.Visible = False
                Exit Sub
            Else
                divMsg.InnerHtml = mydt.Rows.Count & " documents found"
            End If
            gvDocStore.Visible = True
            For Each r In mydt.Rows
                Dim filepath = "upload/" & r("section") & "/" & r("type") & "/" & r("filename")
                '  r("Description") = "<b><a href='" & filepath & "' target=_blank onclick=fileCount('" & r("filename") & "') >" & r("Description") & "</a></b>"
                r("Description") = "<b><a href='download.aspx?file=" & r("filename") & "' target=_blank onclick=fileCount('" & r("filename") & "') >" & r("Description") & "</a></b>"
                ''' encode in rowbound of gridview
                ''' '' get file size
                ''' 
                Try
                    Dim fs As System.IO.FileInfo = New System.IO.FileInfo(Server.MapPath("~") + filepath)
                    r("Size(MB)") = Math.Round((fs.Length / (1024 * 1024)), 1)
                Catch ex1 As Exception
                    r("Size(MB)") = "NA"
                End Try
            Next

            gvDocStore.DataSource = mydt
            gvDocStore.DataBind()
            '  //This replaces <td> with <th> And adds the scope attribute
            gvDocStore.UseAccessibleHeader = True
            ' //This will add the <thead> And <tbody> elements
            gvDocStore.HeaderRow.TableSection = TableRowSection.TableHeader

            ' //This adds the <tfoot> element. 
            ' //Remove if you don't have a footer row
            gvDocStore.FooterRow.TableSection = TableRowSection.TableFooter
            ' divMsg.InnerHtml = q
        Catch ex As Exception
            divMsg.InnerHtml = q & ex.Message
        End Try
    End Sub


    Protected Sub btnUpload_Click(sender As Object, e As EventArgs)
        If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343302")
        If String.IsNullOrEmpty(txtSubject.Text) Then
            divMsg.InnerHtml = "Please Enter the Subject/Descr"
            Exit Sub
        End If
        If checkForSQLInjection(txtSubject.Text) Then
            divMsg.InnerHtml = "Special character not allowed"
            Exit Sub
        End If
        Dim subject = txtSubject.Text.Replace("'", "")
        Dim newFilename = ""
        Try
            Dim destfolder = "SAFETY" & "/" & "Report" '"vcr"
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
            Dim dt = Now ' DateTime.ParseExact(txtDate.Text, "dd.M.yyyy", Nothing)
            Dim secret = 0
            '   If cbSecret.Checked Then secret = 1
            Dim myquery As String = ""
            If temp.Contains("Successfully") Then
                myquery = "insert into safety_clearances( docdt, subject,  filename, lastupdateby, last_updated,   exist) " &
               "values ('" & dt.ToString("yyyy-MM-dd") & "','" & subject & "','" & newFilename & "','" & Session("email") & "',current_timestamp,1 )"
                If executeDB(myquery, "appsdb") = "ok" Then
                    temp = temp & "Record Updated"
                    'Dim ffMpeg = New NReco.VideoConverter.FFMpegConverter()
                    'ffMpeg.GetVideoThumbnail(Server.MapPath(uploadDir) + fileName, Server.MapPath("./upload/vcr/") + fileName & ".jpg", Rnd(7000)) 'Left(r(0), 8)
                    ' Response.Redirect("vc.aspx?file=success&thumbnailcreated")
                    loadClearances()
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

    Private Sub btnTrainingsubmit_Click(sender As Object, e As EventArgs) Handles btnTrainingsubmit.Click
        If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343302")
        If String.IsNullOrEmpty(txtTrainingDt.Text) Or String.IsNullOrEmpty(txtTrainingAgecy.Text) Or String.IsNullOrEmpty(txtTrainingDesc.Text) Or String.IsNullOrEmpty(txtTrainigDuration.Text) Then
            divMsg.InnerHtml = "Please Enter the fileds"
            Exit Sub
        End If
        Dim dt = DateTime.ParseExact(txtTrainingDt.Text, "dd.M.yyyy", Nothing)
        Dim myquery = "insert into safety_training(training_dt, agency,descr, duration, persons, traininghour, participants, last_updateby, lastupdated, del) " &
               "values ('" & dt.ToString("yyyy-MM-dd") & "','" & txtTrainingAgecy.Text.Replace("'", "") & "','" & txtTrainingDesc.Text.Replace("'", "") & "','" & txtTrainigDuration.Text.Replace("'", "") & "','" & txtTrainingPersons.Text.Replace("'", "") & "','" & txtTrainingHour.Text.Replace("'", "") & "','" & txtTrainingParticipants.Text.Replace("'", "") & "','" & Session("email") & "',current_timestamp,0 )"
        If executeDB(myquery, "appsdb") = "ok" Then
            divMsg.InnerHtml = "Record Updated"
            loadTraining()
        Else
            divMsg.InnerHtml = "Error: " & myquery
        End If

    End Sub

    Private Sub btnIncidentSubmit_Click(sender As Object, e As EventArgs) Handles btnIncidentSubmit.Click
        If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343302")
        If String.IsNullOrEmpty(txtIncedentSNo.Text) Or String.IsNullOrEmpty(txtIncedentAgency.Text) Or String.IsNullOrEmpty(txtIncedentDetail.Text) Or String.IsNullOrEmpty(txtIncedentDate.Text) Then
            divMsg.InnerHtml = "Please Enter the fileds"
            Exit Sub
        End If
        Dim dt = DateTime.ParseExact(txtIncedentDate.Text, "dd.M.yyyy", Nothing)
        Dim myquery = "insert into safety_incident(sn, agency,type,dt_incident,location,victims,detail,rca,action,Pictures,Remarks, lastupdateby, last_updated, del) " &
               "values ('" & txtIncedentSNo.Text.Replace("'", "") & "','" & txtIncedentAgency.Text.Replace("'", "") & "','" & rblIncedentType.SelectedValue & "','" & dt.ToString("yyyy-MM-dd") & "','" & txtIncedentLocation.Text.Replace("'", "") & "','" & txtIncedentVictim.Text.Replace("'", "") & "','" & txtIncedentDetail.Text.Replace("'", "") & "','" & txtInsedentRCA.Text.Replace("'", "") & "','" & txtIncidentAction.Text.Replace("'", "") & "','" & ddlIncidentPicture.SelectedValue & "','" & txtIncidentRemarks.Text.Replace("'", "") & "','" & Session("email") & "',current_timestamp,0 )"
        If executeDB(myquery, "appsdb") = "ok" Then
            divMsg.InnerHtml = "Record Updated"
            lblID.Text = "Record Updated Succesfully"
            txtIncedentSNo.Text = ""
            txtIncedentAgency.Text = ""
        Else
            divMsg.InnerHtml = "Error: " & myquery
        End If
    End Sub

    Private Sub rblEditorType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblEditorType.SelectedIndexChanged
        SqlDataSource1.SelectParameters("incidenttype").DefaultValue = rblEditorType.SelectedValue
    End Sub

    Private Sub gvClearances_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvClearances.RowDataBound
        Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(2).Text)
        e.Row.Cells(2).Text = decodedText
    End Sub

    Protected Sub UploadFile(sender As Object, e As EventArgs)
        Dim msg = ""
        '    If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343326")
        If String.IsNullOrEmpty(txtOBS.Text) Then
            lbBookMessageTop.Text = "Description can't be blank"
            Exit Sub
        End If
        Try

            If FileUpload1.PostedFile IsNot Nothing Then
                Dim uploadDir = "upload/SAFETY/Report/"
                If Not System.IO.Directory.Exists(Server.MapPath(uploadDir)) Then
                    msg = "Creating Path " & uploadDir & "<br/>"
                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir))
                End If

                Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                Dim ext = ".jpg" ' Path.GetExtension(FileName)
                Dim newFilename = rblOBS.Text & Now.ToString("dMMyHHmmss") & ext
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

                If rblOBS.Text = "obs" Then
                    q = "insert into safety_obs( agency,area,detail,st_dt,pic,by, status, del) " &
               "values ('" & ddlNewAgency.SelectedValue & "','" & ddlNewWorkArea.SelectedValue & "','" & txtOBS.Text.Replace("'", "") & "',current_timestamp,'" & newFilename & "','" & Session("email") & "','Open',0 )"

                Else
                    q = "update safety_obs set reply = '" & txtOBS.Text.Replace("'", "") & "', status = 'Closed', replypic='" & newFilename & "', replyby ='" & Session("email") & "', reply_dt=current_timestamp where uid = '" & lbObsID.Text & "'"
                End If
                If executeDB(q, "appsdb") = "ok" Then
                    msg = msg & "<br/>Record Updated"
                    txtOBS.Text = ""
                    Response.Redirect("safety.aspx?mode=obsview")
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
End Class
