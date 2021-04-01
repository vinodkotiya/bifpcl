Imports Common
Imports dbOp
Imports System.Data
Partial Class doctracker
    Inherits System.Web.UI.Page

    Private Sub dashboardTS_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2, True)
            divNotification.InnerHtml = getNotification(1)
            divNotificationMobile.InnerHtml = getNotification(1, True)
            If Request.Form.Count = 1 Then
                Dim appsecret = "9jcMbhTSucjaxN3R5ErOtVxhuZcXm3IZ4o1QqjI+eZA="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            If Not Request.QueryString("mode") Is Nothing Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343338")
            End If
            divLogin.InnerHtml = showAccount(Session("email"), True)
            divLoginMobile.InnerHtml = showAccount(Session("email"), True)
            Dim total = getDBsingle("select count(docno) from doctracker_m where 1", "appsdb")
            Dim pending = getDBsingle("select count(docno) from doctracker_m where status = 'Pending'", "appsdb")
            Dim closed = getDBsingle("select count(docno) from doctracker_m where status = 'Closed'", "appsdb")
            Dim ackByme = getDBsingle("select count(uid) from  doctracker_m m  join doctracker d on m.docno = d.docno where  state = 'Held' and markto = '" & Session("email") & "' and ackdate is null order by markdate desc", "appsdb")
            Dim pendingWithme = getDBsingle("select count(uid) from  doctracker_m m  join doctracker d on m.docno = d.docno where  state = 'Held' and markto = '" & Session("email") & "' and markto = ackby order by markdate desc", "appsdb")
            Dim notAckAweek = getDBsingle("select count(m.docno) from  doctracker_m m  join doctracker d on m.docno = d.docno where  state = 'Held' and ackdate is null and round(julianday(current_timestamp)-julianday(markdate)) >= 7", "appsdb")
            Dim pendingAweek = getDBsingle("select count(m.docno)  from  doctracker_m m  join doctracker d on m.docno = d.docno where  state = 'Held'  and markto = ackby and round(julianday(current_timestamp)-julianday(markdate)) >=  7", "appsdb")

            divStats.InnerHtml = " <p class='text-muted m-b-15'> <code> Break-up and non-compliance can be seen in reports. <code></p>" &
                  "   <button type='button' class='btn btn-primary m-l-10 m-b-10'><a href='#' style='color:white;'> Total Docs <span class='badge badge-light'>" & total & "</a></span></button>  " &
                 "  <button type='button' class='btn btn-success  m-l-10 m-b-10'><a href='#' style='color:white;'>Total Pending <span class='badge badge-light'>" & pending & "</a></span></button>  " &
                  "  <button type='button' class='btn btn-info  m-l-10 m-b-10'><a href='#' style='color:white;'>Total Closed <span class='badge badge-light'>" & closed & "</a></span></button>  " &
                   " || <button type='button' class='btn btn-success  m-l-10 m-b-10'><a href='doctracker.aspx?mode=ack' style='color:white;'> Pending ACK with Me <span class='badge badge-light'>" & ackByme & "</a></span></button>  " &
                    "  <button type='button' class='btn btn-info  m-l-10 m-b-10'><a href='doctracker.aspx?mode=ack' style='color:white;'>Pending with Me <span class='badge badge-light'>" & pendingWithme & "</a></span></button>  " &
                     " <br/> <button type='button' class='btn btn-warning  m-l-10 m-b-10'><a href='doctracker.aspx?mode=report' style='color:black;'> <span class='badge badge-light'>" & notAckAweek & "</a></span> files not ACK for more than a week </button>  " &
                    "  <button type='button' class='btn btn-warning  m-l-10 m-b-10'><a href='doctracker.aspx?mode=report' style='color:black;'><span class='badge badge-light'>" & pendingAweek & "</a></span> files pending more than a week </button>  "

            If Request.Params("mode") = "email" Then
                '  Session("email") = "cfo@bifpcl.com"
                If Not (checkAuthorization(Session("email"), "onlybifpcl") And checkAuthorization(Session("email"), "doctracker.aspx?mode=email")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                pnlSendEmail.Visible = True
            ElseIf Request.Params("mode") = "new" Then
                If Not (checkAuthorization(Session("email"), "onlybifpcl")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                pnlNewBooking.Visible = True
                Dim mydt = getDBTable("select name || ', ' || desig as t, email as v from contacts_New where printorder < 8 and del = 0 order by printorder asc", "hrdb")
                ddlNewMark.DataSource = mydt
                ddlNewMark.DataBind()
                ddlNewMark.Items.Insert(0, "Select Where File will go?")
                Dim q As String = "Select distinct descr as t, dept as v from dept where 1 order by descr asc"
                ddlDept.DataSource = getDBTable(q)
                ddlDept.DataBind()
                lbID.Text = Now.ToString("yddMMHHmmss")
                'Dim time As DateTime = New DateTime(2000, 1, 1, 3, 0, 0)
                'Dim endtime As DateTime = New DateTime(2000, 1, 1, 23, 30, 0)
                'Dim timeupto As DateTime = New DateTime(2000, 1, 1, 8, 0, 0)
                'While time <= endtime
                '    'ddlNewTime.Items.Add(New ListItem(time.ToString("HH:mm tt"), time.ToString("HH:mm")))
                '    'If time > timeupto Then ddlNewTimeUpto.Items.Add(New ListItem(time.ToString("HH:mm tt"), time.ToString("HH:mm")))
                '    'time = time.AddMinutes(60)
                'End While
            ElseIf Request.Params("mode") = "mydoc" Then
                If Not (checkAuthorization(Session("email"), "onlybifpcl")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                pnlMybooking.Visible = True
                Dim q = "select docno, docdate, doctype, sub , ref, status from doctracker_m where originator = '" & Session("email") & "' order by docdate desc, status desc"
                Dim mydt = getDBTable(q, "appsdb")
                If mydt.Rows.Count = 0 Then
                    lbMybooking.Text = "You have not created any file in Doc Tracker. Go to Create New Doc"
                    Exit Sub
                End If
                'For Each r In mydt.Rows
                '    If r(0) = "0" Or r("Booking Status") = "Canceled" Or r("Booking Status") = "Rejected" Then
                '        r(0) = "-"
                '    Else
                '        r(0) = "<a href=vehicle.aspx?mode=cancel&id=" & r(0) & "> Cancel </a>"
                '    End If
                '    r(1) = "<a href=gatepassPrint.aspx?mode=vehicle&id=" & r(1) & "> Print </a>"
                'Next
                gvMyDoc.DataSource = mydt
                gvMyDoc.DataBind()

            ElseIf Request.Params("mode") = "report" Then
                If Not (checkAuthorization(Session("email"), "onlybifpcl")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                pnlReport.Visible = True
                Dim mydt = getDBTable("Select distinct descr as t, dept as v from dept where 1 order by descr asc")
                ddlReportDept.DataSource = mydt
                ddlReportDept.DataBind()
                ddlReportDept.Items.Add(New ListItem("Show All", "%"))
                ddlReportDept.SelectedValue = "%"
                loadReport()
            ElseIf Request.Params("mode") = "track" Then
                If Not (checkAuthorization(Session("email"), "onlybifpcl")) Then ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                pnlTrack.Visible = True
                If Not Request.Params("id") Is Nothing Then
                    Dim docid = Request.Params("id").ToString.Replace("'", "")
                    txtDocTrackNo.Text = docid
                    '   Dim q = "select strftime('%d.%m.%Y %H:%M',DATETIME(d.markdate,'+6 hours')) as 'Marked On',strftime('%d.%m.%Y %H:%M',d.ackdate) as ackon, marktoname as  'File with', d.state as Status,  d.remark as Remark from  doctracker_m m  join doctracker d on m.docno = d.docno where  m.docno = '" & docid.Replace("'", "") & "' order by markdate desc"
                    Dim q = "select strftime('%d.%m.%Y %H:%M',DATETIME(d.markdate,'+6 hours')) as 'Marked On',strftime('%d.%m.%Y %H:%M',DATETIME(d.ackdate,'+6 hours')) as 'Ack On', marktoname as  'File with', d.state as Status,  d.remark as Remark from  doctracker d  where  docno = '" & docid.Replace("'", "") & "'  union select strftime('%d.%m.%Y',docdate) as  'Marked On',strftime('%d.%m.%Y',docdate) as ackon, oname as  'File with', 'Fwd' as Status,  remark as Remark from doctracker_m where docno = '" & docid.Replace("'", "") & "'  "
                    Dim mydt = getDBTable(q, "appsdb")
                    If mydt.Rows.Count = 0 Then
                        lbDocTrackMessage.Text = "Given Doc Tracker Number can not be found. Please come from Reports or My Doc Section."
                        Exit Sub
                    Else
                        lbDocTrackMessage.Text = ""
                    End If
                    Dim filedetail = getDBsingle("select sub || ' - ' || dept || ', ' || oname || ' (' || status || ')' as detail from doctracker_m where docno = '" & docid & "' limit 1", "appsdb")
                    ''' See if file is not ACK
                    ''' 
                    Dim fileAckPending = getDBsingle("select marktoname from doctracker where ackdate is null and docno = " & docid & " order by ackdate desc limit 1", "appsdb")
                    Dim fileAckPendingMessage = "File is already recieved. ACK Done"
                    If Not fileAckPending.Contains("Error") Then
                        fileAckPendingMessage = "File is under Transit or Yet to be recieved by " & fileAckPending & " , ACK not done."
                    End If

                    ''' See if file is  ACK but not marked
                    ''' 
                    Dim fileMarkPending = getDBsingle("select ackbyname from doctracker where not ackdate is null and docno = " & docid & " order by ackdate desc limit 1", "appsdb")
                    Dim fileMarkPendingMessage = "File is already recieved. ACK Done"
                    If Not fileMarkPending.Contains("Error") Then
                        fileMarkPendingMessage = "File is Pending with " & fileMarkPending & "."
                    Else
                        fileMarkPendingMessage = "File is Pending with Originator"
                    End If

                    gvAllBookings.DataSource = mydt
                    gvAllBookings.DataBind()

                    If Not filedetail.Contains("(Closed)") Then
                        lbDocTrackerDetail.Text = filedetail & "<br/><button type='button' class='btn btn-primary m-l-10 m-b-10'>ACK Status</button>" & fileAckPendingMessage &
                        "<br/><button type='button' class='btn btn-primary m-l-10 m-b-10'>Mark Status</button>" & fileMarkPendingMessage
                    Else
                        lbDocTrackerDetail.Text = filedetail & "<br/><button type='button' class='btn btn-info m-l-10 m-b-10'>ACK/Mark Status</button> File is Closed."
                    End If

                End If


            ElseIf Request.Params("mode") = "ack" Then
                Dim q = ""
                If Not (checkAuthorization(Session("email"), "onlybifpcl")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                Try
                    Dim mydt = getDBTable("select name || ', ' || desig as t, email as v from contacts_New where printorder < 8 and del = 0 order by printorder asc", "hrdb")
                    ddlMarkTo.DataSource = mydt
                    ddlMarkTo.DataBind()
                    ddlMarkTo.Items.Insert(0, "Select Where File will go?")
                    pnlApprove.Visible = True
                    q = "select uid, strftime('%d.%m.%Y',d.markdate) as markedon, m.docno, '' as markedby, sub, dept, m.oname as by, d.remark from  doctracker_m m  join doctracker d on m.docno = d.docno where  state = 'Held' and markto = '" & Session("email") & "' and ackdate is null order by markdate desc"
                    Dim mydt1 = getDBTable(q, "appsdb")
                    If mydt1.Rows.Count = 0 Then
                        lbAckMessage.Text = "No document is marked to you for Ack/Reciept."
                    Else
                        lbAckMessage.Text = "Please Ack/Reciept the above documents."
                    End If
                    For Each r In mydt1.Rows
                        q = "select ackbyname from doctracker where not ackdate is null and docno = '" & r("docno") & "' order by ackdate desc limit 1"
                        Dim markedby = getDBsingle(q, "appsdb")
                        If markedby.Contains("Error") Then
                            r("markedby") = r("by")
                        Else
                            r("markedby") = markedby
                        End If
                    Next
                    gvAdminStatus.DataSource = mydt1
                    gvAdminStatus.DataBind()
                    q = "select uid, strftime('%d.%m.%Y',d.markdate) as markedon,strftime('%d.%m.%Y',d.ackdate) as ackon, m.docno, sub, dept, m.oname as by, d.remark from  doctracker_m m  join doctracker d on m.docno = d.docno where  state = 'Held' and markto = '" & Session("email") & "' and markto = ackby order by markdate desc"
                    Dim mydt2 = getDBTable(q, "appsdb")
                    If mydt2.Rows.Count = 0 Then
                        lbMarkMessage.Text = "No document is Held up by you for Marking to Others."
                    Else
                        lbMarkMessage.Text = "Please take action on above documents and Mark to others."
                    End If
                    gvChangeGrid.DataSource = mydt2

                    gvChangeGrid.DataBind()
                Catch ex As Exception
                    lbMarkMessage.Text = "Error " & q
                End Try
            ElseIf Request.Params("mode") = "correct" Then
                Dim q = ""
                If Not (checkAuthorization(Session("email"), "onlybifpcl")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                Try
                    Dim mydt = getDBTable("select name || ', ' || desig as t, email as v from contacts_New where printorder < 8 and del = 0 order by printorder asc", "hrdb")
                    ddlMarkCorrect.DataSource = mydt
                    ddlMarkCorrect.DataBind()
                    ddlMarkCorrect.Items.Insert(0, "Select Where File will go?")
                    pnlCourse.Visible = True

                    q = "select uid, marktoname, m.docno, sub, dept, m.oname as by, d.remark from  doctracker_m m  join doctracker d on m.docno = d.docno where  state = 'Held' and originator = '" & Session("email") & "' order by markdate desc"
                    Dim mydt2 = getDBTable(q, "appsdb")
                    If mydt2.Rows.Count = 0 Then
                        lbCourse.Text = "No document is created by you for making correction.."
                    Else
                        lbCourse.Text = "You can correct only above documents." '& q
                    End If
                    gvCourse.DataSource = mydt2

                    gvCourse.DataBind()
                Catch ex As Exception
                    lbCourse.Text = "Error " '& q
                End Try
            Else
                pnlHome.Visible = True
            End If
        End If
    End Sub
    Sub loadReport()
        Dim q = ""
        Try
            q = "select docno, strftime('%d.%m.%Y',docdate) as docdate, doctype, oname as originator, dept, sub , ref, status, '-' as dp from doctracker_m where status = '" & rblReportStatus.SelectedValue & "' and dept like '%" & ddlReportDept.SelectedValue & "%' order by docdate desc, status desc"
            If rblReportStatus.SelectedValue = "ACK" Then
                q = "select m.docno as docno, strftime('%d.%m.%Y',m.docdate) as docdate, doctype, oname as originator, dept, sub , ref, status || ' - Yet to ACK by ' || marktoname as status, round(julianday(current_timestamp)-julianday(markdate)) as dp from  doctracker_m m  join doctracker d on m.docno = d.docno where  state = 'Held' and ackdate is null and dept like '%" & ddlReportDept.SelectedValue & "%'  order by markdate desc"
            ElseIf rblReportStatus.SelectedValue = "MARK" Then
                q = "select m.docno as docno, strftime('%d.%m.%Y',m.docdate) as docdate, doctype, oname as originator, dept, sub , ref, status || ' - ACK done by ' || marktoname as status, round(julianday(current_timestamp)-julianday(ackdate)) as dp from  doctracker_m m  join doctracker d on m.docno = d.docno where  state = 'Held'  and markto = ackby and dept like '%" & ddlReportDept.SelectedValue & "%'  order by markdate desc"
            End If
            Dim mydt = getDBTable(q, "appsdb")
            If mydt.Rows.Count = 0 Then
                lbMyReport.Text = "No records found for given  filter."
                '   Exit Sub
            End If
            lbMyReport.Text = mydt.Rows.Count & " Nos of Records found for given filter."
            gvReport.DataSource = mydt
            gvReport.DataBind()
        Catch ex As Exception
            lbMyReport.Text = "Error " & ex.Message & q
        End Try
    End Sub
    Private Sub gvAdminStatus_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvAdminStatus.RowCommand
        Dim value = e.CommandArgument.ToString()
        'lblCurrentID.Text = value
        'Dim request = getDBsingle("select eid || ' has requested on ' || strftime('%d.%m.%Y %H:%M',reporting) || ' <b>' || seats || '</b> No of Seat <br/> at ' || source || ' Reporting Address and going to ' || destination || ' - ' || occupants || 'are Passengers. Reason: ' ||  ifnull(remark,'') from vehiclebook where uid = '" & value & "' limit 1", "appsdb")
        'lblCurrentUser.Text = request
        'pnlAdminEdit.Visible = True
        Dim q = "update doctracker set ackdate = current_timestamp, ackby = '" & Session("email") & "', ackbyname = marktoname where uid = " & value
        If executeDB(q, "appsdb") = "ok" Then
            Response.Redirect("doctracker.aspx?mode=ack")
        Else
            lbAckMessage.Text = "Error updating the record"
        End If
    End Sub
    Private Sub gvChangeGrid_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvChangeGrid.RowCommand
        Dim value = e.CommandArgument.ToString()
        'lblCurrentID.Text = value
        'Dim request = getDBsingle("select eid || ' has requested on ' || strftime('%d.%m.%Y %H:%M',reporting) || ' <b>' || seats || '</b> No of Seat <br/> at ' || source || ' Reporting Address and going to ' || destination || ' - ' || occupants || 'are Passengers. Reason: ' ||  ifnull(remark,'') from vehiclebook where uid = '" & value & "' limit 1", "appsdb")
        'lblCurrentUser.Text = request
        'pnlAdminEdit.Visible = True
        lblUID.Text = value
        Dim request = getDBsingle("select docno from doctracker where uid = '" & value & "' limit 1", "appsdb")
        lblCurrentID.Text = request
        lblCurrentUser.Text = getDBsingle("select sub || ' ' || dept || ' ' || oname as detail from doctracker_m where docno = '" & request & "' limit 1", "appsdb")
        pnlAdminEdit.Visible = True

    End Sub

    Private Sub btnNewBook_Click(sender As Object, e As EventArgs) Handles btnNewBook.Click
        Try
            If Session("email") Is Nothing Then
                Response.Redirect("Default.aspx")
            End If

            If rblLoc.SelectedIndex < 0 Then
                lbBookMessage.Text = "Select Head Office/Site Office"
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtNewDate.Text) Or String.IsNullOrEmpty(txtNewSub.Text) Or String.IsNullOrEmpty(txtNewSub.Text) Or String.IsNullOrEmpty(txtNewRef.Text) Then
                lbBookMessage.Text = "All * fields are mandatory"
                Exit Sub
            End If

            If ddlNewMark.SelectedItem.Text.Contains("Select") Then
                lbBookMessage.Text = "Select to whom your file will go?"
                Exit Sub
            End If
            'Dim occupants = txtNewP1.Text.Replace("'", "") & ", " & vbCrLf & txtNewP2.Text.Replace("'", "") & ", " & vbCrLf & txtNewP3.Text.Replace("'", "") & ", " & vbCrLf & txtNewP4.Text.Replace("'", "") & ", " & vbCrLf & txtNewP5.Text.Replace("'", "")
            Dim docDate = DateTime.ParseExact(txtNewDate.Text, "dd.M.yyyy", Nothing)
            Dim name = getDBsingle("select name from contacts_New where email = '" & Session("email") & "' limit 1", "hrdb")
            Dim msg = Session("email") & " has created doc number " & lbID.Text & " ,Go to https://bifpcl.com/doctracker.aspx to acknowledge."
            Dim q = "insert into doctracker_m (docno, doctype,ref,sub,docdate,dept,loc,originator,oname, approver,remark,last_updated,lastupdateby,status) values " &
            "('" & lbID.Text & "','" & ddlNewType.SelectedValue & "','" & txtNewRef.Text.Replace("'", "") & "','" & txtNewSub.Text.Replace("'", "") & "','" & docDate.ToString("yyyy-MM-dd") & "','" & ddlDept.SelectedValue & "','" & rblLoc.SelectedValue & "','" & Session("email") & "', '" & name & "','" & ddlNewApprover.SelectedValue & "','" & txtNewRemark.Text.Replace("'", "") & "',current_timestamp,'" & Session("email") & "','Pending')"

            Dim q2 = "insert into doctracker (docno, markto,marktoname,markdate,remark, state) values " &
            "('" & lbID.Text & "','" & ddlNewMark.SelectedValue & "','" & ddlNewMark.SelectedItem.Text & "',current_timestamp,'" & txtNewRemark.Text.Replace("'", "") & "', 'Held')"
            Dim ok1 = executeDB(q, "appsdb")
            Dim ok2 = executeDB(q2, "appsdb")
            If ok1 = "ok" And ok2 = "ok" Then
                lbBookMessage.Text = "Doc Tracker ID <b>" & lbID.Text & "</b> Generated succesfully on  " & Now.ToString & " Master Update = " & ok1 & "  Tracker update = " & ok2 & "<br/> You can check status from My Docs."
                '  txtNewP1.Text = ""
                '' get approver mails
                'q = "select group_concat(email, ',') from auth where page ='vehicle.aspx?mode=approve' "
                'Dim emaillist = getDBsingle(q)
                'Dim emaillistQuoted As String = String.Join(",", emaillist.Split(","c).[Select](Function(x) String.Format("'{0}'", x)).ToList())
                'q = "select group_concat(cell,',') from contacts_New where email in (" & emaillistQuoted & ")"
                'Dim mobilelist = getDBsingle(q, "hrdb")
                'Dim maxuid = getDBsingle("select max(uid) from vehiclebook", "appsdb")
                'lbBookMessage.Text = lbBookMessage.Text & "<br/>Message sent to " & mobilelist & JustSendSMSBIFPCL(mobilelist, msg) & " <br/><br/> You can cancel the request from My Bookings Section.<br/> <b>Click here To take <a href=gatepassPrint.aspx?mode=vehicle&id=" & maxuid & "> Print </a></b>"

                pnlBookPrint.Visible = True
                lbBookMessagePrint.Text = lbBookMessage.Text
                pnlNewBooking.Visible = False
            Else
                lbBookMessage.Text = "Error inserting data master=" & ok1 & " tracker = " & ok2
            End If
        Catch ex As Exception
            lbBookMessage.Text = "Error inserting data " & ex.Message
        End Try
    End Sub

    'Private Sub ddlAssignVehicle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAssignVehicle.SelectedIndexChanged
    '    Dim reqdate = getDBsingle("select strftime('%Y-%m-%d',reporting) from vehiclebook where  uid = " & lblCurrentID.Text, "appsdb")
    '    Dim alreadyengagedVehicleID = getDBsingle("select group_concat(vehicle) from vehiclebook where not vehicle is null and strftime('%Y-%m-%d',reporting) = '" & reqdate & "'", "appsdb")
    '    If alreadyengagedVehicleID.Contains("Error") Then
    '        ''no vehicle assigned on this date
    '        lbAssign.Text = "No vehicle assigned on this date" & alreadyengagedVehicleID
    '    Else
    '        Dim vids As String() = alreadyengagedVehicleID.Split(","c)
    '        If vids.Contains(ddlAssignVehicle.SelectedValue) Then
    '            lbAssign.Text = "Selected vehicle " & ddlAssignVehicle.SelectedValue & " is already engaged in requested date. You may check seats or choose other vehicle." '& alreadyengagedVehicleID
    '            Dim oldrequest = getDBsingle("select eid || ' has booked <b>' || seats || '</b> No of Seat  at ' || source || '  and going to ' || destination  from vehiclebook where vehicle = '" & ddlAssignVehicle.SelectedValue & "' and strftime('%Y-%m-%d',reporting) = '" & reqdate & "' limit 1", "appsdb")
    '            lbAssign.Text = lbAssign.Text & "<br/>" & oldrequest
    '        Else
    '            lbAssign.Text = "Selected vehicle " & ddlAssignVehicle.SelectedValue & " is not engaged in requested date. You may safely assign vehicle." '& alreadyengagedVehicleID
    '        End If

    '    End If
    'End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        If ddlMarkTo.SelectedItem.Text.Contains("Select") Then
            lbAssign.Text = "Select to whom your file will go?"
            Exit Sub
        End If

        Dim q = "update doctracker set state = 'Fwd' where uid = " & lblUID.Text
        Dim q2 = "insert into doctracker (docno, markto,marktoname,markdate,remark, state) values " &
            "('" & lblCurrentID.Text & "','" & ddlMarkTo.SelectedValue & "','" & ddlMarkTo.SelectedItem.Text & "',current_timestamp,'" & txtAssignRemark.Text.Replace("'", "") & "', 'Held')"
        Dim ok1 = executeDB(q, "appsdb")
        Dim ok2 = executeDB(q2, "appsdb")
        If ok1 = "ok" And ok2 = "ok" Then
            Response.Redirect("doctracker.aspx?mode=ack")
        Else
            lbAssign.Text = "Error marking the document data master=" & ok1 & " tracker = " & ok2
        End If
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim q = "update doctracker set state = 'Closed', remark = '" & txtAssignRemark.Text.Replace("'", "") & "' where uid = " & lblUID.Text
        Dim q2 = "update doctracker_m set status = 'Closed' where docno = '" & lblCurrentID.Text & "'"
        Dim ok1 = executeDB(q, "appsdb")
        Dim ok2 = executeDB(q2, "appsdb")
        If ok1 = "ok" And ok2 = "ok" Then
            Response.Redirect("doctracker.aspx?mode=ack")
        Else
            lbAssign.Text = "Error marking the document data master=" & ok2 & " tracker = " & ok1
        End If
    End Sub
    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        pnlAdminEdit.Visible = False
    End Sub

    'Private Sub gvMyBookings_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvMyBookings.RowDataBound
    '    Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(0).Text)
    '    e.Row.Cells(0).Text = decodedText
    '    Dim decodedText1 = HttpUtility.HtmlDecode(e.Row.Cells(1).Text)
    '    e.Row.Cells(1).Text = decodedText1
    'End Sub







    Private Sub chkMarkTo_CheckedChanged(sender As Object, e As EventArgs) Handles chkMarkTo.CheckedChanged
        If Not chkMarkTo.Checked Then
            Dim mydt = getDBTable("select name || ', ' || desig as t, email as v from contacts_New where del = 0 and printorder < 8 order by printorder asc", "hrdb")
            ddlNewMark.DataSource = mydt
            ddlNewMark.DataBind()
            ddlNewMark.Items.Insert(0, "Select Where File will go?")
        Else
            Dim mydt = getDBTable("select name || ', ' || desig as t, email as v from contacts_New where del = 0  order by workarea, printorder asc", "hrdb")
            ddlNewMark.DataSource = mydt
            ddlNewMark.DataBind()
            ddlNewMark.Items.Insert(0, "Select Where File will go?")
        End If
    End Sub

    Private Sub chkAssignMarkTo_CheckedChanged(sender As Object, e As EventArgs) Handles chkAssignMarkTo.CheckedChanged
        If Not chkAssignMarkTo.Checked Then
            Dim mydt = getDBTable("select name || ', ' || desig as t, email as v from contacts_New where del = 0 and printorder < 8 order by printorder asc", "hrdb")
            ddlMarkTo.DataSource = mydt
            ddlMarkTo.DataBind()
        Else
            Dim mydt = getDBTable("select name || ', ' || desig as t, email as v from contacts_New where del = 0  order by workarea, printorder asc", "hrdb")
            ddlMarkTo.DataSource = mydt
            ddlMarkTo.DataBind()
        End If
    End Sub

    Private Sub btnTrackDoc_Click(sender As Object, e As EventArgs) Handles btnTrackDoc.Click
        If String.IsNullOrEmpty(txtDocTrackNo.Text) Then
            lbDocTrackMessage.Text = "Please enter Doc Tracker Number"
            Exit Sub
        End If

        Response.Redirect("doctracker.aspx?mode=track&id=" & txtDocTrackNo.Text)
    End Sub

    Private Sub gvMyDoc_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvMyDoc.RowCommand
        Dim value = e.CommandArgument.ToString()
        Response.Redirect("doctracker.aspx?mode=track&id=" & value)

    End Sub

    Private Sub ddlReportDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlReportDept.SelectedIndexChanged
        loadReport()
    End Sub

    Private Sub rblReportStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblReportStatus.SelectedIndexChanged
        loadReport()
    End Sub

    Private Sub gvReport_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvReport.RowCommand
        Dim value = e.CommandArgument.ToString()
        Response.Redirect("doctracker.aspx?mode=track&id=" & value)

    End Sub

    Private Sub btnDummyClose_Click(sender As Object, e As EventArgs) Handles btnDummyClose.Click
        btnClose.Visible = True
        btnReject1.Visible = True
        btnDummyClose.Visible = False
    End Sub

    Private Sub btnReject1_Click(sender As Object, e As EventArgs) Handles btnReject1.Click
        btnClose.Visible = False
        btnReject1.Visible = False
        btnDummyClose.Visible = True
        '  pnlAdminEdit.Visible = False
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        loadReport()

    End Sub
    Function download2Mail(ByVal filename As String, ByVal extralog As String, Optional ByVal test As Integer = 1)
        Try
            Dim log = "<small>Log:<br/> Daemon Report Maker Invoked by " & Session("email") & " at " & Now.ToString
            'Dim q = "insert into sms (sms_dt,smscount) select current_date,0    WHERE not  EXISTS (select * from sms where sms_dt = current_date)"
            'Dim ret = executeDB(q)
            ' Change the Header Row back to white color
            'gvAttendance.HeaderRow.Style.Add("background-color", "#FFFFFF")
            ''  gvAttendance.HeaderRow.BackColor = Color.White
            'For Each cell As TableCell In gvAttendance.HeaderRow.Cells
            '    cell.BackColor = gvAttendance.HeaderStyle.BackColor
            'Next
            'For Each row As GridViewRow In gvAttendance.Rows
            '    ' row.BackColor = Color.White
            '    For Each cell As TableCell In row.Cells
            '        If row.RowIndex Mod 2 = 0 Then
            '            cell.BackColor = gvAttendance.AlternatingRowStyle.BackColor
            '        Else
            '            cell.BackColor = gvAttendance.RowStyle.BackColor
            '        End If
            '        ' cell.CssClass = "textmode"
            '    Next
            'Next

            'style to format numbers to string
            ' Dim style As String = "<style> .textmode { } </style>"
            log = log & vbCrLf & "<br/>Report Grid plotted in memory at " & Now.ToString()


            'Dim path As String = Server.MapPath("~/upload/HR/Attendance/")
            'If Not System.IO.Directory.Exists(path) Then
            '    System.IO.Directory.CreateDirectory(path)
            'End If
            Dim report = ""
            ' If Not System.IO.File.Exists(path & filename) Then
            log = log & vbCrLf & "<br/>Report path verification done at " & Now.ToString()
            Using sw As New System.IO.StringWriter()
                Using hw As New HtmlTextWriter(sw)
                    '  Dim writer As System.IO.StreamWriter = System.IO.File.CreateText(path & filename)
                    Try
                        '            writer.WriteLine("BIFPCL Attendance Online Report " & Now.ToString("dd.MM.yyyy"))
                        '            writer.WriteLine("_")
                        divExport.RenderControl(hw)
                        'gvAttendance.RenderControl(hw)
                        'divLeaveType.RenderControl(hw)
                        report = sw.ToString & "<br/> Report Generated at:" & Now.ToString()
                        '        writer.WriteLine(sw.ToString())
                        '            'writer.WriteLine("_")
                        '            'writer.WriteLine(divAttandance.InnerHtml.ToString)
                        '            'writer.WriteLine("This is a system generated report. Real time status can be seen at url http://cc.ntpclakshya.co.in/hrap/report.aspx")
                        '            writer.Close()
                        '            hw.Dispose()
                        '            sw.Dispose()
                        log = log & vbCrLf & "<br/>Report Rendering done at " & Now.ToString()
                    Catch ex As Exception
                        'writer.WriteLine(ex.Message)
                        'writer.Close()
                        hw.Dispose()
                        sw.Dispose()
                    End Try

                End Using
            End Using
            'divMsg.InnerHtml = "xls file generated" & vbCrLf & divMsg.InnerHtml
            'Else
            '    divMsg.InnerHtml = "xls file already exist" & vbCrLf & divMsg.InnerHtml
            'End If

            Dim mailcc = "md@bifpcl.com, vinodkotiya@bifpcl.com,rokeya.khatun@bifpcl.com,tanvirahamed@bifpcl.com  "
            Dim mailto = lbEmailList.Text & "dilipsingh01@bifpcl.com  "
            'Dim mydt = getDBTable("select email from employee where empno in (select distinct eid from kpa_hr  where 1 )")
            'Dim emailpace = ""
            'For Each r In mydt.Rows
            '    emailpace = emailpace & r(0) & ","
            'Next
            log = log & vbCrLf & "<br/>Fetch email list at " & Now.ToString()
            If test = 0 Then

                mailto = "admin@bifpcl.com"
                mailcc = "vinodkotiya@gmail.com"
            End If
            log = log & vbCrLf & "<br/>Attempt E-Mail Sending at " & Now.ToString()
            log = log & vbCrLf & "<br/>ReportMaker Daemon Hibernation starts at " & Now.ToString() & "<br/>" & extralog
            Dim msg = "Dear Ma'm/Sir " & vbCrLf & vbCrLf &
                "<br/><br/>This is system generated DocTracker Status Report to help you in providing the long pending documents status. <br/> File originator and concerned persons are requested to take action. <br/><b>Note: Originators can make the course correction of file directly if it is wrongly marked.</b>" & vbCrLf &
                "<br/>Real time status can be seen at url <a href=https://www.bifpcl.com/doctracker.aspx target=_blank>BIFPCL.com</a> " &
                "" & report & " <br/> " & log
            ' Dim ret = SendEmail("admin@bifpcl.com", mailto, mailcc, "", "BIFPCL Daily Attendance Report  ", msg, "", "", "admin@bifpcl.com", "d@d")
            Dim ret = SendEmail("admin@bifpcl.com", mailto, mailcc, "", "BIFPCL DocTracker Status - " & rblMailReport.SelectedItem.Text & ": Pending Days(" & txtMailDays.Text & ") on " & Now.ToString("dd-MM-yyyy"), msg, "", "", "admin@bifpcl.com", "Bifpcl&123")

            divMsg.InnerHtml = "html file  mailed " & log & ret & filename & vbCrLf & divMsg.InnerHtml
            'q = "update   sms set reportlog = '" & "Email Status:" & ret & vbCrLf & divMsg.InnerHtml & "' where sms_dt = current_date"
            'Dim ret1 = executeDB(q)
            'divMsg.InnerHtml = "Todays Report emailed " & ret1 & " from " & Request.UserHostAddress & vbCrLf & log & divMsg.InnerHtml
            'Session("EmailAttempt" + Now.ToString("dd-MM-yyyy")) = True
            btnEmail.Text = "Mail sent to All"
            btnEmail.Enabled = False
        Catch e1 As Exception
            divMsg.InnerHtml = divMsg.InnerHtml & e1.Message
        End Try
    End Function
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Return
    End Sub
    Private Sub btnEmail_Command(sender As Object, e As CommandEventArgs) Handles btnEmail.Command
        download2Mail("test1.html", "", 1)
    End Sub

    Private Sub rblMailReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblMailReport.SelectedIndexChanged
        mailReport()
    End Sub
    Sub mailReport()
        Dim q = ""
        Try
            If rblMailReport.SelectedValue = "ACK" Then
                q = "select m.docno as 'DocNo', strftime('%d.%m.%Y',m.docdate) as 'Doc Date',  oname as Originator, Dept, Sub ,  status || ' - Yet to ACK by ' || marktoname as Status, round(julianday(current_timestamp)-julianday(markdate)) as 'Days Pending', originator as omail, markto from  doctracker_m m  join doctracker d on m.docno = d.docno where  state = 'Held' and ackdate is null and round(julianday(current_timestamp)-julianday(markdate)) >= " & txtMailDays.Text & "   order by markdate desc"
            ElseIf rblMailReport.SelectedValue = "MARK" Then
                q = "select m.docno as 'DocNo', strftime('%d.%m.%Y',m.docdate) as 'Doc Date',  oname as Originator, Dept, Sub ,  status || ' - ACK done by ' || marktoname as Status, round(julianday(current_timestamp)-julianday(ackdate)) as 'Days Pending', originator as omail, markto from  doctracker_m m  join doctracker d on m.docno = d.docno where  state = 'Held'  and markto = ackby and round(julianday(current_timestamp)-julianday(markdate)) >=  " & txtMailDays.Text & "  order by markdate desc"
            End If
            Dim mydt = getDBTable(q, "appsdb")
            If mydt.Rows.Count = 0 Then
                lbDetail.Text = "No records found for given  filter."
                '   Exit Sub
            End If
            Dim emaillist = ""
            For Each r In mydt.Rows
                If Not emaillist.Contains(r("markto").ToString) Then
                    emaillist = emaillist & r("markto") & ","
                End If
                If Not emaillist.Contains(r("omail").ToString) Then
                    emaillist = emaillist & r("omail") & ", "
                End If

            Next
            lbEmailList.Text = emaillist
            lbDetail.Text = mydt.Rows.Count & " Nos of Records found for given filter." '& q
            gvAttendance.DataSource = mydt
            gvAttendance.DataBind()
        Catch ex As Exception
            lbDetail.Text = "Error " & ex.Message & q
        End Try
    End Sub



    Private Sub btnMailReport_Click(sender As Object, e As EventArgs) Handles btnMailReport.Click
        mailReport()
    End Sub

    Private Sub gvCourse_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCourse.RowCommand
        Dim value = e.CommandArgument.ToString()
        'lblCurrentID.Text = value
        'Dim request = getDBsingle("select eid || ' has requested on ' || strftime('%d.%m.%Y %H:%M',reporting) || ' <b>' || seats || '</b> No of Seat <br/> at ' || source || ' Reporting Address and going to ' || destination || ' - ' || occupants || 'are Passengers. Reason: ' ||  ifnull(remark,'') from vehiclebook where uid = '" & value & "' limit 1", "appsdb")
        'lblCurrentUser.Text = request
        'pnlAdminEdit.Visible = True
        lbCorrectRowID.Text = value
        Dim request = getDBsingle("select docno from doctracker where uid = '" & value & "' limit 1", "appsdb")
        lbCorrectID.Text = request
        pnlCorrect.Visible = True

    End Sub

    Private Sub cbShowAllCorect_CheckedChanged(sender As Object, e As EventArgs) Handles cbShowAllCorect.CheckedChanged
        If Not cbShowAllCorect.Checked Then
            Dim mydt = getDBTable("select name || ', ' || desig as t, email as v from contacts_New where del = 0 and printorder < 8 order by printorder asc", "hrdb")
            ddlMarkCorrect.DataSource = mydt
            ddlMarkCorrect.DataBind()
        Else
            Dim mydt = getDBTable("select name || ', ' || desig as t, email as v from contacts_New where del = 0  order by workarea, printorder asc", "hrdb")
            ddlMarkCorrect.DataSource = mydt
            ddlMarkCorrect.DataBind()
        End If
    End Sub

    Private Sub btnCorrecTMark_Click(sender As Object, e As EventArgs) Handles btnCorrecTMark.Click
        If ddlMarkCorrect.SelectedItem.Text.Contains("Select") Then
            ' lbAssign.Text = "Select to whom your file will go?"
            Exit Sub
        End If

        Dim q = "update doctracker set state = 'Fwd', ackdate=markdate,ackby=markto,ackbyname=marktoname where uid = " & lbCorrectRowID.Text
        Dim q2 = "insert into doctracker (docno, markto,marktoname,markdate,remark, state) values " &
            "('" & lbCorrectID.Text & "','" & ddlMarkCorrect.SelectedValue & "','" & ddlMarkCorrect.SelectedItem.Text & "',current_timestamp,'Correction in Marking.', 'Held')"
        Dim ok1 = executeDB(q, "appsdb")
        Dim ok2 = executeDB(q2, "appsdb")
        If ok1 = "ok" And ok2 = "ok" Then
            Response.Redirect("doctracker.aspx?mode=correct")
        Else
            lbAssign.Text = "Error marking the document data master=" & ok1 & " tracker = " & ok2
        End If
    End Sub
End Class
