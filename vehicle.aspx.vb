Imports Common
Imports dbOp
Imports System.Data
Partial Class vehicle
    Inherits System.Web.UI.Page

    Private Sub dashboardTS_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2, True)
            divNotification.InnerHtml = getNotification(1)
            divNotificationMobile.InnerHtml = getNotification(1, True)
            If Request.Form.Count = 1 Then
                Dim appsecret = "zTNfzUc1gh/Q++F5rHoTNuS0ZO3qHpzTJ/iDqjHe7uM="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            If Not Request.QueryString("mode") Is Nothing Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343308")
            End If
            divLogin.InnerHtml = showAccount(Session("email"), True)
            divLoginMobile.InnerHtml = showAccount(Session("email"), True)
            If Request.Params("mode") = "manage" Then
                If Not (checkAuthorization(Session("email"), "onlybifpcl") Or checkAuthorization(Session("email"), "vehicle.aspx?mode=approve")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                pnlUpdateVehicle.Visible = True
            ElseIf Request.Params("mode") = "new" Then
                If Not (checkAuthorization(Session("email"), "onlybifpcl")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                pnlNewBooking.Visible = True
                Dim time As DateTime = New DateTime(2000, 1, 1, 3, 0, 0)
                Dim endtime As DateTime = New DateTime(2000, 1, 1, 23, 30, 0)
                Dim timeupto As DateTime = New DateTime(2000, 1, 1, 8, 0, 0)
                While time <= endtime
                    ddlNewTime.Items.Add(New ListItem(time.ToString("HH:mm tt"), time.ToString("HH:mm")))
                    If time > timeupto Then ddlNewTimeUpto.Items.Add(New ListItem(time.ToString("HH:mm tt"), time.ToString("HH:mm")))
                    time = time.AddMinutes(60)
                End While
            ElseIf Request.Params("mode") = "mybooking" Then
                If Not (checkAuthorization(Session("email"), "onlybifpcl")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                pnlMybooking.Visible = True
                Dim q = "select  case when reporting > current_timestamp then '' || uid else '0' end as Action, cast(uid as text) as Print, strftime('%d.%m.%Y %H:%M',reporting) as 'Reporting Time', seats as 'No of Seat',  v.vehicle as 'Vehicle', driver as Driver, driverno as 'Driver No', aremark as 'Approver Remark', status as 'Booking Status', triptype, remark as reason, source as 'Reporting Address', destination, occupants as 'Passengers' from vehiclebook b left outer join vehicle v on b.vehicle = v.vid where eid = '" & Session("email") & "' order by reporting desc"
                Dim mydt = getDBTable(q, "appsdb")
                If mydt.Rows.Count = 0 Then
                    Exit Sub
                End If
                For Each r In mydt.Rows
                    If r(0) = "0" Or r("Booking Status") = "Canceled" Or r("Booking Status") = "Rejected" Then
                        r(0) = "-"
                    Else
                        r(0) = "<a href=vehicle.aspx?mode=cancel&id=" & r(0) & "> Cancel </a>"
                    End If
                    r(1) = "<a href=gatepassPrint.aspx?mode=vehicle&id=" & r(1) & "> Print </a>"
                Next
                gvMyBookings.DataSource = mydt
                gvMyBookings.DataBind()
                '  lbMybooking.Text = q
            ElseIf Request.Params("mode") = "cancel" Then
                If Not (checkAuthorization(Session("email"), "onlybifpcl")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                If Request.Params("id") Is Nothing Then Exit Sub
                pnlCancellation.Visible = True
                lbCancelID.Text = Request.Params("id")
                Dim request1 = getDBsingle("select eid || ' has requested on ' || strftime('%d.%m.%Y %H:%M',reporting) || ' <b>' || seats || '</b> No of Seat <br/> at ' || source || ' Reporting Address and going to ' || destination || ' - ' || occupants || 'are Passengers' from vehiclebook where uid = '" & lbCancelID.Text & "' limit 1", "appsdb")
                lbCancelRequest.Text = request1
            ElseIf Request.Params("mode") = "report" Then
                If Not checkAuthorization(Session("email"), "vehicle.aspx?mode=approve") Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                pnlReport.Visible = True
                Dim q = "select strftime('%d.%m.%Y %H:%M',reporting) as 'Reporting Time', eid as 'Request By', seats as 'No of Seat', remark as 'Reason',  v.vehicle as 'Vehicle', driver as Driver, driverno as 'Driver No', aremark as 'Approver Remark', status as 'Booking Status', triptype, source as 'Reporting Address', destination, occupants as 'Passengers' from vehiclebook b left outer join vehicle v on b.vehicle = v.vid where 1 order by reporting desc"
                gvAllBookings.DataSource = getDBTable(q, "appsdb")
                gvAllBookings.DataBind()
                '  lbAllBooking.Text = q
            ElseIf Request.Params("mode") = "approve" Then
                If Not checkAuthorization(Session("email"), "vehicle.aspx?mode=approve") Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                ddlAssignVehicle.DataSource = getDBTable("select seating || ' seater ' || vehicle || ' ' || driver || ' ' || driverno as t, vid as v from vehicle where del = 0", "appsdb")
                ddlAssignVehicle.DataBind()
                ddlAssignVehicle.Items.Insert(0, "Select vehicle")
                'ddlUidNew.Items.Insert(1, "Common Place")
                pnlApprove.Visible = True
                Dim q = "select uid, strftime('%d.%m.%Y %H:%M',reporting) as reporting , strftime('%H:%M',returning) as upto , triptype, eid , seats ,   destination, remark from vehiclebook where status = 'new' order by last_updated desc"
                gvAdminStatus.DataSource = getDBTable(q, "appsdb")
                gvAdminStatus.DataBind()
                q = "select uid, strftime('%d.%m.%Y %H:%M',reporting) as reporting , strftime('%H:%M',returning) as upto , triptype, eid , seats ,   destination, v.vehicle from vehiclebook b, vehicle v where v.vid = b.vehicle and status = 'Approved' order by last_updated desc"
                gvChangeGrid.DataSource = getDBTable(q, "appsdb")
                gvChangeGrid.DataBind()
            Else
                pnlHome.Visible = True
            End If
        End If
    End Sub
    Private Sub gvAdminStatus_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvAdminStatus.RowCommand
        Dim value = e.CommandArgument.ToString()
        lblCurrentID.Text = value
        Dim request = getDBsingle("select eid || ' has requested on ' || strftime('%d.%m.%Y %H:%M',reporting) || ' <b>' || seats || '</b> No of Seat <br/> at ' || source || ' Reporting Address and going to ' || destination || ' - ' || occupants || 'are Passengers. Reason: ' ||  ifnull(remark,'') from vehiclebook where uid = '" & value & "' limit 1", "appsdb")
        lblCurrentUser.Text = request
        pnlAdminEdit.Visible = True

    End Sub
    Private Sub gvChangeGrid_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvChangeGrid.RowCommand
        Dim value = e.CommandArgument.ToString()
        lblCurrentID.Text = value
        Dim request = getDBsingle("select eid || ' has requested on ' || strftime('%d.%m.%Y %H:%M',reporting) || ' <b>' || seats || '</b> No of Seat <br/> at ' || source || ' Reporting Address and going to ' || destination || ' - ' || occupants || 'are Passengers. Reason: ' ||  ifnull(remark,'') from vehiclebook where uid = '" & value & "' limit 1", "appsdb")
        lblCurrentUser.Text = request
        pnlAdminEdit.Visible = True

    End Sub
    Private Sub ddlNewSeat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlNewSeat.SelectedIndexChanged
        txtNewP2.Visible = True
        txtNewP3.Visible = True
        txtNewP4.Visible = True
        txtNewP5.Visible = True
        If ddlNewSeat.SelectedValue = "1" Then
            txtNewP2.Visible = False
            txtNewP3.Visible = False
            txtNewP4.Visible = False
            txtNewP5.Visible = False
        ElseIf ddlNewSeat.SelectedValue = "2" Then
            txtNewP3.Visible = False
            txtNewP4.Visible = False
            txtNewP5.Visible = False
        ElseIf ddlNewSeat.SelectedValue = "3" Then
            txtNewP4.Visible = False
            txtNewP5.Visible = False
        ElseIf ddlNewSeat.SelectedValue = "4" Then
            txtNewP5.Visible = False
        End If
    End Sub

    Private Sub btnNewBook_Click(sender As Object, e As EventArgs) Handles btnNewBook.Click
        Try
            If Session("email") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If

            If String.IsNullOrEmpty(txtNewReporting.Text) Or String.IsNullOrEmpty(txtNewAddress.Text) Or String.IsNullOrEmpty(txtNewDestination.Text) Or String.IsNullOrEmpty(txtNewP1.Text) Then
                lbBookMessage.Text = "All fields are mendatory"
                Exit Sub
            End If
            Dim occupants = txtNewP1.Text.Replace("'", "") & ", " & vbCrLf & txtNewP2.Text.Replace("'", "") & ", " & vbCrLf & txtNewP3.Text.Replace("'", "") & ", " & vbCrLf & txtNewP4.Text.Replace("'", "") & ", " & vbCrLf & txtNewP5.Text.Replace("'", "")
            Dim reporting = DateTime.ParseExact(txtNewReporting.Text, "dd.M.yyyy", Nothing)
            Dim msg = Session("email") & " has requested vehicle on " & reporting & " ," & ddlNewSeat.SelectedValue & " seats. Go to https://bifpcl.com/vehicle.aspx to approve."
            Dim q = "insert into vehiclebook (eid,reporting,seats,occupants, status, source,destination,last_updated, lastupdateby, triptype, returning, remark) values " &
            "('" & Session("email") & "','" & reporting.ToString("yyyy-MM-dd") & " " & ddlNewTime.SelectedValue & "','" & ddlNewSeat.SelectedValue & "','" & occupants & "','new','" & txtNewAddress.Text.Replace("'", "") & "','" & txtNewDestination.Text.Replace("'", "") & "', current_timestamp,'" & Session("email") & "','" & rblNewTrip.SelectedValue & "','" & reporting.ToString("yyyy-MM-dd") & " " & ddlNewTimeUpto.SelectedValue & "','" & txtNewReason.Text.Replace("'", "") & "')"
            If executeDB(q, "appsdb") = "ok" Then
                lbBookMessage.Text = "Booking requested succesfully <br/> You will recieve SMS on approval" & Now.TimeOfDay.ToString & "<br/>"
                txtNewP1.Text = ""
                '' get approver mails
                q = "select group_concat(email, ',') from auth where page ='vehicle.aspx?mode=approve' "
                Dim emaillist = getDBsingle(q)
                Dim emaillistQuoted As String = String.Join(",", emaillist.Split(","c).[Select](Function(x) String.Format("'{0}'", x)).ToList())
                q = "select group_concat(cell,',') from contacts_New where email in (" & emaillistQuoted & ")"
                Dim mobilelist = getDBsingle(q, "hrdb")
                Dim maxuid = getDBsingle("select max(uid) from vehiclebook", "appsdb")
                lbBookMessage.Text = lbBookMessage.Text & "<br/>Message sent to " & mobilelist & JustSendSMSBIFPCL(mobilelist, msg) & " <br/><br/> You can cancel the request from My Bookings Section.<br/> <b>Click here To take <a href=gatepassPrint.aspx?mode=vehicle&id=" & maxuid & "> Print </a></b>"

                pnlBookPrint.Visible = True
                lbBookMessagePrint.Text = lbBookMessage.Text
                pnlNewBooking.Visible = False
            Else
                    lbBookMessage.Text = "Error inserting data " & q
            End If
        Catch ex As Exception
            lbBookMessage.Text = "Error inserting data " & ex.Message
        End Try
    End Sub

    Private Sub ddlAssignVehicle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAssignVehicle.SelectedIndexChanged
        Dim reqdate = getDBsingle("select strftime('%Y-%m-%d',reporting) from vehiclebook where  uid = " & lblCurrentID.Text, "appsdb")
        Dim alreadyengagedVehicleID = getDBsingle("select group_concat(vehicle) from vehiclebook where not vehicle is null and strftime('%Y-%m-%d',reporting) = '" & reqdate & "'", "appsdb")
        If alreadyengagedVehicleID.Contains("Error") Then
            ''no vehicle assigned on this date
            lbAssign.Text = "No vehicle assigned on this date" & alreadyengagedVehicleID
        Else
            Dim vids As String() = alreadyengagedVehicleID.Split(","c)
            If vids.Contains(ddlAssignVehicle.SelectedValue) Then
                lbAssign.Text = "Selected vehicle " & ddlAssignVehicle.SelectedValue & " is already engaged in requested date. You may check seats or choose other vehicle." '& alreadyengagedVehicleID
                Dim oldrequest = getDBsingle("select eid || ' has booked <b>' || seats || '</b> No of Seat  at ' || source || '  and going to ' || destination  from vehiclebook where vehicle = '" & ddlAssignVehicle.SelectedValue & "' and strftime('%Y-%m-%d',reporting) = '" & reqdate & "' limit 1", "appsdb")
                lbAssign.Text = lbAssign.Text & "<br/>" & oldrequest
            Else
                lbAssign.Text = "Selected vehicle " & ddlAssignVehicle.SelectedValue & " is not engaged in requested date. You may safely assign vehicle." '& alreadyengagedVehicleID
            End If

        End If
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        If ddlAssignVehicle.SelectedItem.Text.Contains("Select") Then
            lbAssign.Text = "Select a vehicle to assign"
            Exit Sub
        End If
        Dim q = "update vehiclebook set status = 'Approved', vehicle = " & ddlAssignVehicle.SelectedValue & ", last_updated=current_timestamp, lastupdateby='" & Session("email") & "', aremark='" & txtAssignRemark.Text.Replace("'", "") & "' where uid =" & lblCurrentID.Text
        Dim ret = executeDB(q, "appsdb")
        If ret = "ok" Then
            q = "select uid, strftime('%d.%m.%Y %H:%M',reporting) as reporting , strftime('%H:%M',returning) as upto , triptype, eid , seats ,   destination, remark from vehiclebook where status = 'new' order by reporting desc"
            gvAdminStatus.DataSource = getDBTable(q, "appsdb")
            gvAdminStatus.DataBind()
            pnlAdminEdit.Visible = False
            '' send SMS
            Dim emailid = getDBsingle("select eid from vehiclebook where uid =" & lblCurrentID.Text, "appsdb")
            Dim mobile = getDBsingle("select cell from contacts_New where email = '" & emailid & "'", "hrdb")
            Dim mailto = emailid
            Dim mailcc = Session("email")
            Dim msg = "Dear Ma'm/Sir " & vbCrLf & vbCrLf &
                "<br/><br/>Your vehicle request approved " & ddlAssignVehicle.SelectedItem.Text & txtAssignRemark.Text & vbCrLf &
                "<br/>You can also check driver details in My Booking section at url <a href=https://www.bifpcl.com/vehicle.aspx target=_blank>BIFPCL.com</a> " &
                " <br/> "
            Dim retMail = SendEmail("admin@bifpcl.com", mailto, mailcc, "", "Vehicle Booking Approved  ", msg, "", "", "admin@bifpcl.com", "Bifpcl&123")

            lbAssignGrid.Text = "Vehicle assigned. Msg Sent " & mobile & JustSendSMSBIFPCL(mobile, "Your vehicle request approved " & ddlAssignVehicle.SelectedItem.Text & txtAssignRemark.Text) & " email Sent " & retMail

        Else
            lbAssign.Text = "Error assigning vehicle" ' & q
        End If
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Dim q = "update vehiclebook set status = 'Rejected', last_updated=current_timestamp, lastupdateby='" & Session("email") & "' where uid =" & lblCurrentID.Text
        Dim ret = executeDB(q, "appsdb")
        If ret = "ok" Then
            q = "select uid, strftime('%d.%m.%Y %H:%M',reporting) as reporting , strftime('%H:%M',returning) as upto , triptype, eid , seats ,   destination, remark from vehiclebook where status = 'new' order by reporting desc"
            gvAdminStatus.DataSource = getDBTable(q, "appsdb")
            gvAdminStatus.DataBind()
            pnlAdminEdit.Visible = False
            '' send SMS
            Dim emailid = getDBsingle("select eid from vehiclebook where uid =" & lblCurrentID.Text, "appsdb")
            Dim mobile = getDBsingle("select  cell from contacts_New where email = '" & emailid & "'", "hrdb")
            lbAssignGrid.Text = "Vehicle request rejected. Msg Sent " & mobile & JustSendSMSBIFPCL(mobile, "Your vehicle request rejected ")
        Else
            lbAssign.Text = "Error assigning vehicle" ' & q
        End If
    End Sub

    Private Sub gvMyBookings_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvMyBookings.RowDataBound
        Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(0).Text)
        e.Row.Cells(0).Text = decodedText
        Dim decodedText1 = HttpUtility.HtmlDecode(e.Row.Cells(1).Text)
        e.Row.Cells(1).Text = decodedText1
    End Sub

    Private Sub btnCancelBack_Click(sender As Object, e As EventArgs) Handles btnCancelBack.Click
        Response.Redirect("vehicle.aspx?mode=mybooking")
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim q = "update vehiclebook set status = 'Canceled', last_updated=current_timestamp, aremark='" & txtCancelRemark.Text.Replace("'", "") & "', lastupdateby='" & Session("email") & "' where uid =" & lbCancelID.Text
        Dim ret = executeDB(q, "appsdb")
        If ret = "ok" Then

            '' send SMS
            '' get approver mails
            q = "select group_concat(email, ',') from auth where page ='vehicle.aspx?mode=approve' "
            Dim emaillist = getDBsingle(q)
            Dim emaillistQuoted As String = String.Join(",", emaillist.Split(","c).[Select](Function(x) String.Format("'{0}'", x)).ToList())
            q = "select group_concat(cell,',') from contacts_New where email in (" & emaillistQuoted & ")"
            Dim mobilelist = getDBsingle(q, "hrdb")

            lbCancelRemark.Text = "Vehicle canceled. Msg Sent to approvers. " & mobilelist & JustSendSMSBIFPCL(mobilelist, "Vehicle booking " & lbCancelID.Text & " cancelled by " & Session("email") & " Assigned/Requested seat is free now.")
            btnCancel.Enabled = False
        Else
            lbCancelRemark.Text = "Error cancelling vehicle" ' & q
        End If
    End Sub
    Private Sub gvDPRDetail_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDPRDetail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            If (e.Row.RowState And DataControlRowState.Edit) > 0 Then
                Dim ddList As DropDownList = CType(e.Row.FindControl("ddlEIC"), DropDownList)
                ddList.DataSource = getDBTable("Select name,email from contacts_New where printorder < 10 and workarea = 'SO' order by printorder asc", "hrdb")
                ddList.DataTextField = "name"
                ddList.DataValueField = "email"
                ddList.DataBind()
                ddList.Items.Add(New ListItem("-", "-"))
                Dim dr As DataRowView = TryCast(e.Row.DataItem, DataRowView)
                ddList.SelectedValue = dr("eic").ToString()
            End If
        End If
    End Sub

    Private Sub gvDPRDetail_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles gvDPRDetail.RowUpdating
        Dim ddList As DropDownList = CType(gvDPRDetail.Rows(e.RowIndex).FindControl("ddlEIC"), DropDownList)
        SqlDataSource1.UpdateParameters("eic").DefaultValue = ddList.SelectedValue.ToString
        'Dim lbLog As Label = CType(gvDPRDetail.Rows(e.RowIndex).FindControl("lblLog"), Label)
        'SqlDataSource1.UpdateParameters("log").DefaultValue = "Leave Assigned " & ddList.SelectedValue.ToString & " on " & Now.ToString() & vbCrLf & lbLog.Text
    End Sub


End Class
