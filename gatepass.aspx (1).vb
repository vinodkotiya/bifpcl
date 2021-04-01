Imports Common
Imports dbOp
Imports System.IO
Imports System.Drawing           'CoreCompat Image handling

Imports System.Drawing.Drawing2D   'CoreCompat Image handling

Imports System.Drawing.Imaging       'CoreCompat Image handling
Imports Ionic.Zip
Partial Class gatepass
    Inherits System.Web.UI.Page

    Private Sub dashboardTS_Load(sender As Object, e As EventArgs) Handles Me.Load
        '''Copy from other table  UPDATE gatepass 
        'Set cancel_approve_dt = (Select t2.cancel_dt FROM cancel t2 WHERE t2.id1 = id) , status = 'Cancelled'
        '      WHERE
        'EXISTS ( SELECT * FROM cancel t2 WHERE t2.id1= id)
        '    UPDATE gatepass 
        '    Set validity_start = (Select t2.validity_start FROM valids t2 WHERE t2.id1 = id) 
        'WHERE
        '    '    EXISTS( SELECT * FROM valids t2 WHERE t2.id1= id)
        '    UPDATE gatepass 
        '    Set validity_end = (Select t2.validity_end FROM valide t2 WHERE t2.id1 = id) 
        'WHERE
        '    EXISTS( SELECT * FROM valide t2 WHERE t2.id1= id)

        If Not Page.IsPostBack Then
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2, True)
            divNotification.InnerHtml = getNotification(1)
            divNotificationMobile.InnerHtml = getNotification(1, True)
            If Request.Form.Count = 1 Then
                Dim appsecret = "+bcfyOWS1ofItYlDWSlADw/cKBI/zOZtJ4j9svLRwEM="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            If Not Request.QueryString("mode") Is Nothing Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343314")
            End If
            divLogin.InnerHtml = showAccount(Session("email"), True)
            divLoginMobile.InnerHtml = showAccount(Session("email"), True)
            Dim newApprover = getDBsingle("select agency from agency where email = '" & Session("email") & "' and level='new' limit 1", "gpdb")

            Dim approver1 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver1' limit 1", "gpdb")
            If Not approver1.Contains("Error") Then newApprover = "Approver EPC"

            Dim approver2 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver2' limit 1", "gpdb")
            If Not approver2.Contains("Error") Then newApprover = "Approver BIFPCL"

            If Request.Params("mode") = "insurance" Then
                If Not (checkAuthorization(Session("email"), "onlybifpcl") And checkAuthorization(Session("email"), "gatepass.aspx?mode=approve") And newApprover.Contains("BIFPCL")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "i Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives with approver rights. "
                    Exit Sub
                End If
                ddlInsuranceAgency.DataSource = getDBTable("select distinct agency   from agency order by agency asc", "gpdb")
                ddlInsuranceAgency.DataBind()
                pnlUpdateInsurance.Visible = True
            ElseIf Request.Params("mode") = "admin" Then
                If Not ((checkAuthorization(Session("email"), "onlybifpcl") And checkAuthorization(Session("email"), "gatepass.aspx?mode=approve") And newApprover.Contains("BIFPCL"))) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "ad Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives with approver rights.NewApprover=" & newApprover & " ap2 " & checkAuthorization(Session("email"), "onlybifpcl") & checkAuthorization(Session("email"), "gatepass.aspx?mode=approve")
                    Exit Sub
                End If
                ddlAdminAgency.DataSource = getDBTable("select distinct agency   from agency order by agency asc", "gpdb")
                ddlAdminAgency.DataBind()
                ddlAdminAgency.Items.Add(New ListItem("Add New Agency", "NA"))
                pnlAdmin.Visible = True
            ElseIf Request.Params("mode") = "new" Or Request.Params("mode") = "Renewal" Or Request.Params("mode") = "Cancellation" Or Request.Params("mode") = "Change" Then
                If newApprover.Contains("Error") Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "n Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                pnlNewPass.Visible = True
                divNew.InnerHtml = " <h3>Request New Pass</h3>             <h5>Enter details</h5>"
                lbID.Text = getDBsingle("select gpID  from gpID where 1 limit 1", "gpdb")
                '' now increament id for next session
                executeDB("update gpID set gpID = gpID + 1", "gpdb")
                ddlNewNation.DataSource = getDBTable("select nationality   from nationality", "gpdb")
                ddlNewNation.DataBind()
                ddlNewAgency.DataSource = getDBTable("select distinct agency   from agency order by agency asc", "gpdb")
                ddlNewAgency.DataBind()
                If Not (newApprover.Contains("Approver EPC") Or newApprover.Contains("BIFPCL")) Then
                    ddlNewAgency.SelectedValue = newApprover
                    ddlNewAgency.Enabled = False
                End If
                Dim qry_project As String = "Select distinct workarea as t, workarea as v from ProgressMaster where unit =1"
                ddlNewWorkArea.DataSource = getDBTable(qry_project, "dprdb")
                ddlNewWorkArea.DataTextField = "t"
                ddlNewWorkArea.DataValueField = "v"
                ddlNewWorkArea.DataBind()
                ddlNewWorkArea.Items.Add(New ListItem("C&I", "C&I"))
                ddlNewWorkArea.Items.Add(New ListItem("Cooling Tower Civil", "Cooling Tower Civil"))
                ddlNewWorkArea.Items.Add(New ListItem("Cooling Tower 1A", "Cooling Tower 1A"))
                ddlNewWorkArea.Items.Add(New ListItem("Cooling Tower 1B", "Cooling Tower 1B"))
                ddlNewWorkArea.Items.Add(New ListItem("Cooling Tower 2A", "Cooling Tower 2A"))
                ddlNewWorkArea.Items.Add(New ListItem("Cooling Tower 2B", "Cooling Tower 2B"))
                ddlNewWorkArea.Items.Add(New ListItem("Electrical", "Electrical"))
                ddlNewWorkArea.Items.Add(New ListItem("ESP1", "ESP1"))
                ddlNewWorkArea.Items.Add(New ListItem("ESP2", "ESP2"))
                ddlNewWorkArea.Items.Add(New ListItem("EOT Cranes", "EOT Cranes"))
                ddlNewWorkArea.Items.Add(New ListItem("Mechanical SG1", "Mechanical SG1"))
                ddlNewWorkArea.Items.Add(New ListItem("Mechanical SG2", "Mechanical SG2"))
                ddlNewWorkArea.Items.Add(New ListItem("Mechanical TG1", "Mechanical TG1"))
                ddlNewWorkArea.Items.Add(New ListItem("Mechanical TG2", "Mechanical TG2"))
                ddlNewWorkArea.Items.Add(New ListItem("MPH", "MPH"))
                ddlNewWorkArea.Items.Add(New ListItem("Material Yard", "Material Yard"))
                ddlNewWorkArea.Items.Add(New ListItem("Pkg 9B(AHP/CHP/MISC) CIVIL", "Pkg 9B(AHP/CHP/MISC) CIVIL"))
                ddlNewWorkArea.Items.Add(New ListItem("PKG 10A(MPH) CIVIL", "PKG 10A(MPH) CIVIL"))
                ddlNewWorkArea.Items.Add(New ListItem("PKG A(BOILER & AUX) MECH", "PKG A(BOILER & AUX) MECH"))
                ddlNewWorkArea.Items.Add(New ListItem("PKG 11A(IDCT)", "PKG 11A(IDCT)"))
                ddlNewWorkArea.Items.Add(New ListItem("PKG 11A(IDCT 1A)", "PKG 11A(IDCT 1A)"))
                ddlNewWorkArea.Items.Add(New ListItem("PKG 11A(IDCT 1B)", "PKG 11A(IDCT 1B)"))
                ddlNewWorkArea.Items.Add(New ListItem("PKG 11A(IDCT 2A)", "PKG 11A(IDCT 2A)"))
                ddlNewWorkArea.Items.Add(New ListItem("PKG 11A(IDCT 2B)", "PKG 11A(IDCT 2B)"))
                ddlNewWorkArea.Items.Add(New ListItem("Roads Drains", "Roads Drains"))
                ddlNewWorkArea.Items.Add(New ListItem("Reclaimer Pkg", "Reclaimer Pkg"))
                ddlNewWorkArea.Items.Add(New ListItem("Stacker Pkg", "Stacker Pkg"))
                ddlNewWorkArea.Items.Add(New ListItem("Stacker & Reclaimer Pkg", "Stacker & Reclaimer Pkg"))

                ddlNewWorkArea.Items.Add(New ListItem("Township", "Township"))

                ddlNewWorkArea.Items.Add(New ListItem("Others", "Others"))
                btnSumbitPass.Text = "submit Request"
                lbNewMode.Text = "New"  ''It will be New or Edit

                ''' Now chck aditional parameter for single approve
                ''' 
                If Not Request.Params("id") Is Nothing Then
                    lbNewMode.Text = "Edit"  ''It will be New or Edit
                    lbID.Text = Request.Params("id")
                    If Not Request.Params("approvetype") Is Nothing Then
                        divNew.InnerHtml = " <h3>Approve(Renewal/Cancellation) Pass</h3>             <h5>Enter details</h5>"
                        lbNewApproverType.Text = Request.Params("approvetype")
                        ' Dim approver1 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver1' limit 1", "gpdb")
                        ' If Not approver1.Contains("Error") Then lbNewApprover.Text = "Approver EPC"

                        ' Dim approver2 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver2' limit 1", "gpdb")
                        ' If Not approver2.Contains("Error") Then lbNewApprover.Text = "Approver BIFPCL"
                        lbNewApprover.Text = newApprover
                        If Not (lbNewApprover.Text.Contains("BIFPCL") Or lbNewApprover.Text.Contains("EPC")) Then
                            btnSumbitPass.Enabled = False
                            lbBookMessage.Text = "No authorisation to approve"
                            Exit Sub
                        End If
                        If Request.Params("approvetype").ToString.Contains("Cancel") Then rblNewCancelRemark.Visible = True

                        btnSumbitPass.Text = "Approve Request"
                    End If
                    ''''' further extend this for renewal/cancellation/Modification request if coming with ID
                    '''

                    If Request.Params("mode").Contains("Renewal") Then
                        divNew.InnerHtml = " <h3>Request for Renewal Pass</h3>             <h5>Enter details</h5>"
                        lbNewMode.Text = "Renewal"
                        btnSumbitPass.Text = "Submit for Renewal"
                    ElseIf Request.Params("mode").ToString.Contains("Change") Then
                        divNew.InnerHtml = " <h3>Change Pass</h3>             <h5>Enter details</h5>"
                        lbNewMode.Text = "Modify"
                        btnSumbitPass.Text = "Submit with Change"
                        txtNewValidityStart.Enabled = False
                        txtNewValidityEnd.Enabled = False
                        ddlNewChangeStatus.Visible = True
                        rblNewCancelRemark.Visible = True
                        '  Response.Redirect("google.com")
                    ElseIf Request.Params("mode").Contains("Cancellation") Then
                        divNew.InnerHtml = " <h3>Request for Cancellation Pass</h3>             <h5>Enter details</h5>"
                        lbNewMode.Text = "Cancellation"
                        btnSumbitPass.Text = "Submit for Cancellation"
                        btnUpload.Enabled = False
                        rblNewCancelRemark.Visible = True
                    End If
                    divPic.InnerHtml = "<img src=" & "/upload/gatepass/" & lbID.Text & ".jpg?" & Now.Second & "   onerror=" & Chr(34) & "this.src='\upload\employee\pics\user.png';" & Chr(34) & "  />"
                    lbPicStatus.Text = "Pic Uploaded"
                    reloadGPData(lbNewApproverType.Text)



                End If
                loadInsurance() '' Show insurance info at bottom
            ElseIf Request.Params("mode") = "mybooking" Then
                If Not (checkAuthorization(Session("email"), "onlybifpcl")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "m Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                pnlMybooking.Visible = True
                Dim q = "select strftime('%d.%m.%Y %H:%M',reporting) as 'Reporting Time', seats as 'No of Seat',  v.vehicle as 'Vehicle', driver as Driver, driverno as 'Driver No', status as 'Booking Status', source as 'Reporting Address', destination, occupants as 'Passengers' from vehiclebook b left outer join vehicle v on b.vehicle = v.vid where eid = '" & Session("email") & "' order by reporting desc"
                gvMyBookings.DataSource = getDBTable(q, "appsdb")
                gvMyBookings.DataBind()
                '  lbMybooking.Text = q
            ElseIf Request.Params("mode") = "report" Then
                If newApprover.Contains("Error") Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "r Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                pnlReport.Visible = True
                ddlReportAgency.DataSource = getDBTable("select distinct agency   from agency order by agency asc", "gpdb")
                ddlReportAgency.DataBind()
                ddlReportAgency.Items.Add(New ListItem("Show All", "%"))
                If Not (newApprover.Contains("Approver EPC") Or newApprover.Contains("BIFPCL")) Then
                    ddlReportAgency.SelectedValue = newApprover
                    ddlReportAgency.Enabled = False
                End If
                loadDPR()
                '  lbAllBooking.Text = q
            ElseIf Request.Params("mode") = "approve" Then
                If Not checkAuthorization(Session("email"), "gatepass.aspx?mode=approve") Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "a Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                'ddlUidNew.Items.Insert(1, "Common Place")
                If Request.Params("click") = "new" Then
                    rblApproveType.SelectedValue = "New"
                ElseIf Request.Params("click") = "renew" Then
                    rblApproveType.SelectedValue = "Renew"
                ElseIf Request.Params("click") = "cancel" Then
                    rblApproveType.SelectedValue = "Cancel"
                End If
                pnlApprove.Visible = True
                ddlApproverAgency.DataSource = getDBTable("select distinct agency   from agency order by agency asc", "gpdb")
                ddlApproverAgency.DataBind()
                ddlApproverAgency.Items.Add(New ListItem("Show All", "%"))
                ddlApproverAgency.SelectedValue = "%"
                '   Dim q = "select uid, strftime('%d.%m.%Y %H:%M',reporting) as reporting , eid , seats ,   destination from vehiclebook where status = 'new' order by reporting desc"
                '' get level
                '  Dim approver1 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver1' limit 1", "gpdb")
                '  If Not approver1.Contains("Error") Then lbApprover.Text = "Approver EPC"

                ' Dim approver2 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver2' limit 1", "gpdb")
                ' If Not approver2.Contains("Error") Then lbApprover.Text = "Approver BIFPCL"
                lbApprover.Text = newApprover
                loadApproveGrid()
            ElseIf Request.Params("mode") = "renew" Then
                If newApprover.Contains("Error") Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "rn Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                'ddlUidNew.Items.Insert(1, "Common Place")
                pnlRenewal.Visible = True
                ddlRenewAgency.DataSource = getDBTable("select distinct agency   from agency order by agency asc", "gpdb")
                ddlRenewAgency.DataBind()
                If Not (newApprover.Contains("Approver EPC") Or newApprover.Contains("BIFPCL")) Then
                    ddlRenewAgency.SelectedValue = newApprover
                    ddlRenewAgency.Enabled = False
                End If
                If Not Request.Params("agency") Is Nothing Then
                    ddlRenewAgency.SelectedValue = Server.UrlDecode(Request.Params("agency").ToString)
                End If
                ' Dim approver1 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver1' limit 1", "gpdb")
                ' If Not approver1.Contains("Error") Then lbRenewApprover.Text = "Approver EPC"

                ' Dim approver2 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver2' limit 1", "gpdb")
                ' If Not approver2.Contains("Error") Then lbRenewApprover.Text = "Approver BIFPCL"
                lbRenewApprover.Text = newApprover
                loadRenewalGrid()
            ElseIf Request.Params("mode") = "cancel" Then
                If newApprover.Contains("Error") Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "c Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                'ddlUidNew.Items.Insert(1, "Common Place")
                pnlCancellation.Visible = True
                ddlCancelAgency.DataSource = getDBTable("select distinct agency   from agency order by agency asc", "gpdb")
                ddlCancelAgency.DataBind()
                If Not (newApprover.Contains("Approver EPC") Or newApprover.Contains("BIFPCL")) Then
                    ddlCancelAgency.SelectedValue = newApprover
                    ddlCancelAgency.Enabled = False
                End If
                If Not Request.Params("agency") Is Nothing Then
                    ddlCancelAgency.SelectedValue = Server.UrlDecode(Request.Params("agency").ToString)
                End If
                '  Dim approver1 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver1' limit 1", "gpdb")
                ' If Not approver1.Contains("Error") Then lbCancelApprover.Text = "Approver EPC"

                ' Dim approver2 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver2' limit 1", "gpdb")
                ' If Not approver2.Contains("Error") Then lbCancelApprover.Text = "Approver BIFPCL"
                lbCancelApprover.Text = newApprover
                loadCancelGrid()
            ElseIf Request.Params("mode") = "modify" Then
                If Not checkAuthorization(Session("email"), "gatepass.aspx?mode=approve") Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "m Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for login with approver rights."
                    Exit Sub
                End If
                'ddlUidNew.Items.Insert(1, "Common Place")
                pnlModify.Visible = True
                ddlMoifyAgency.DataSource = getDBTable("select distinct agency   from agency order by agency asc", "gpdb")
                ddlMoifyAgency.DataBind()
                If Not Request.Params("agency") Is Nothing Then
                    ddlMoifyAgency.SelectedValue = Server.UrlDecode(Request.Params("agency").ToString)
                End If
                ' Dim approver1 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver1' limit 1", "gpdb")
                'If Not approver1.Contains("Error") Then lbModifyApprover.Text = "Approver EPC"

                ' Dim approver2 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver2' limit 1", "gpdb")
                ' If Not approver2.Contains("Error") Then lbModifyApprover.Text = "Approver BIFPCL"
                lbModifyApprover.Text = newApprover
                loadModifyGrid()
            ElseIf Request.Params("mode") = "print" Then
                If newApprover.Contains("Error") Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "p Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                'ddlUidNew.Items.Insert(1, "Common Place")
                pnlPrint.Visible = True
                '   Dim q = "select uid, strftime('%d.%m.%Y %H:%M',reporting) as reporting , eid , seats ,   destination from vehiclebook where status = 'new' order by reporting desc"
                '' get level
                ' Dim approver1 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver1' limit 1", "gpdb")
                ' If Not approver1.Contains("Error") Then lbApproverPrint.Text = "Approver EPC"

                ' Dim approver2 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver2' limit 1", "gpdb")
                'If Not approver2.Contains("Error") Then lbApproverPrint.Text = "Approver BIFPCL"
                lbApproverPrint.Text = newApprover
                ddlPrintAgency.DataSource = getDBTable("select distinct agency   from agency order by agency asc", "gpdb")
                ddlPrintAgency.DataBind()
                If Not (newApprover.Contains("Approver EPC") Or newApprover.Contains("BIFPCL")) Then
                    ddlPrintAgency.SelectedValue = newApprover
                    ddlPrintAgency.Enabled = False
                End If
                loadPrintGrid()
            ElseIf Request.Params("mode") = "cover" Then
                If newApprover.Contains("Error") Then  ''Pass url or onlybifpcl for all bifplc executives
                    lbError.Text = "c Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                'ddlUidNew.Items.Insert(1, "Common Place")
                pnlCover.Visible = True
                '   Dim q = "select uid, strftime('%d.%m.%Y %H:%M',reporting) as reporting , eid , seats ,   destination from vehiclebook where status = 'new' order by reporting desc"
                '' get level
                ' Dim approver1 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver1' limit 1", "gpdb")
                ' If Not approver1.Contains("Error") Then lbApproverPrint.Text = "Approver EPC"

                ' Dim approver2 = getDBsingle("select level from agency where email = '" & Session("email") & "' and level='approver2' limit 1", "gpdb")
                'If Not approver2.Contains("Error") Then lbApproverPrint.Text = "Approver BIFPCL"
                ddlCoverAgency.DataSource = getDBTable("select distinct agency   from agency order by agency asc", "gpdb")
                ddlCoverAgency.DataBind()
                lbCoverType.Text = "EPC"
                If Not (newApprover.Contains("Approver EPC") Or newApprover.Contains("BIFPCL")) Then
                    ddlCoverAgency.SelectedValue = newApprover
                    ddlCoverAgency.Enabled = False
                    lbCoverType.Text = "Agency"
                End If
                loadCoverGrid()
            Else
                pnlHome.Visible = True
                Dim total = getDBsingle("select count(id) from gatepass where 1", "gpdb")
                Dim approved = getDBsingle("select count(id) from gatepass where status = 'Approved'", "gpdb")
                Dim epc_new = getDBsingle("select count(id) from gatepass where status = 'New_A1'", "gpdb")
                Dim epc_renew = getDBsingle("select count(id) from gatepass where status = 'Renew_A1'", "gpdb")
                Dim epc_Cancel = getDBsingle("select count(id) from gatepass where status = 'Cancel_A1'", "gpdb")
                Dim bifpc_new = getDBsingle("select count(id) from gatepass where status = 'New_A2'", "gpdb")
                Dim bifpc_renew = getDBsingle("select count(id) from gatepass where status = 'Renew_A2'", "gpdb")
                Dim bifpc_Cancel = getDBsingle("select count(id) from gatepass where status = 'Cancel_A2'", "gpdb")
                divStats.InnerHtml = " <p class='text-muted m-b-15'>Total <code>GatePass</code> in system <code>" & total & "</code>. Valid Pass <code>" & approved & "</code>. For break-up goto reports. </p>" &
                  " EPC Pending:  <button type='button' class='btn btn-primary m-l-10 m-b-10'><a href='gatepass.aspx?mode=approve&click=new' style='color:white;'> New <span class='badge badge-light'>" & epc_new & "</a></span></button>  " &
                 "  <button type='button' class='btn btn-success  m-l-10 m-b-10'><a href='gatepass.aspx?mode=approve&click=renew' style='color:white;'> Renew <span class='badge badge-light'>" & epc_renew & "</a></span></button>  " &
                  "  <button type='button' class='btn btn-info  m-l-10 m-b-10'><a href='gatepass.aspx?mode=approve&click=cancel' style='color:white;'> Cancel <span class='badge badge-light'>" & epc_Cancel & "</a></span></button>  " &
                   " BIFPCL Pending:  <button type='button' class='btn btn-primary m-l-10 m-b-10'><a href='gatepass.aspx?mode=approve&click=new' style='color:white;'> New <span class='badge badge-light'>" & bifpc_new & "</a></span></button>  " &
                 "  <button type='button' class='btn btn-success  m-l-10 m-b-10'><a href='gatepass.aspx?mode=approve&click=renew' style='color:white;'> Renew <span class='badge badge-light'>" & bifpc_renew & "</a></span></button>  " &
                  "  <button type='button' class='btn btn-info  m-l-10 m-b-10'><a href='gatepass.aspx?mode=approve&click=cancel' style='color:white;'> Cancel <span class='badge badge-light'>" & bifpc_Cancel & "</a></span></button>  "
            End If
        End If
    End Sub
    Sub loadInsurance()
        Try
            Dim q = "Select policyno, strftime('%d.%m.%Y',validity_start) as 'Validity Start', strftime('%d.%m.%Y',validity_end) as 'Validity End', persons as 'Total Covered' from insurance where agency like '" & ddlNewAgency.SelectedItem.Text & "'"
            gvInsuranceDetail.DataSource = getDBTable(q, "gpdb")
            gvInsuranceDetail.DataBind()
            Dim approved = Int32.Parse(getDBsingle("Select count(id) from gatepass where agency like '" & ddlNewAgency.SelectedItem.Text & "' and status = 'Approved' limit 1", "gpdb"))
            Dim Cancelled = Int32.Parse(getDBsingle("Select count(id) from gatepass where agency like '" & ddlNewAgency.SelectedItem.Text & "' and status = 'Cancelled' limit 1", "gpdb"))
            Dim under_cancelA1 = Int32.Parse(getDBsingle("Select count(id) from gatepass where  agency like '" & ddlNewAgency.SelectedItem.Text & "' and (status = 'Cancel_A1' ) limit 1", "gpdb"))
            Dim under_cancelA2 = Int32.Parse(getDBsingle("Select count(id) from gatepass where  agency like '" & ddlNewAgency.SelectedItem.Text & "' and ( status = 'Cancel_A2') limit 1", "gpdb"))
            Dim underApplyNew = Int32.Parse(getDBsingle("Select count(id) from gatepass where agency like '" & ddlNewAgency.SelectedItem.Text & "' and status like 'new%' limit 1", "gpdb"))
            Dim underApplyRenew = Int32.Parse(getDBsingle("Select count(id) from gatepass where agency like '" & ddlNewAgency.SelectedItem.Text & "' and status like 'renew%' limit 1", "gpdb"))
            Dim underApply = underApplyNew + underApplyRenew
            Dim totalPass = Int32.Parse(getDBsingle("Select count(id) from gatepass where agency like '" & ddlNewAgency.SelectedItem.Text & "' limit 1", "gpdb"))


            Dim TotalCovered = Int32.Parse(getDBsingle("Select sum(persons) from insurance where agency like '" & ddlNewAgency.SelectedItem.Text & "' limit 1", "gpdb"))
            Dim margin = TotalCovered - approved - under_cancelA1 - under_cancelA2
            Dim marginX = margin - underApply
            Dim margint = "<span style='background:green'>" & margin & "</span>"
            Dim marginXt = "<span style='background:green'>" & marginX & "</span>"
            If margin < 0 Then margint = "<span style='background:red'>" & margin & "</span>"
            If marginX < 0 Then marginXt = "<span style='background:red'>" & marginX & "</span>"
            lbInsuranceDetail.Text = "Insurance Details for " & ddlNewAgency.SelectedItem.Text & ": Total Pass=" & totalPass & ", Cancelled Pass= " & Cancelled & ", <br/> Insurance Taken [X]= " & TotalCovered & ", Approved Pass(excl. N/R/UC) [Y]= " & approved & ", Under Approval(New-" & underApplyNew.ToString & "/Renew-" & underApplyRenew.ToString & ") [Z]= " & underApply & ", Under Cancellation [C " & under_cancelA1.ToString & " + " & under_cancelA2.ToString & "]=" & under_cancelA1 + under_cancelA2 & ", Margin [X-Y-C=M]= " & margint & ", Margin if Under Approval is accepted [M-Z]=" & marginXt
        Catch ex As Exception
            lbInsuranceDetail.Text = "Error Insurance calculation. Check Insurance details for Agency: " & ddlNewAgency.SelectedItem.Text & ex.Message
        End Try
    End Sub
    Private Function loadDPR() As Boolean
        Dim q = ""
        Dim errorPart = ""
        Try
            Dim dateFilter = ""

            If (Not rblReportDTCol.SelectedValue = "No") And (Not String.IsNullOrEmpty(txtReportStDate.Text) And Not String.IsNullOrEmpty(txtReportEndDate.Text)) Then
                Dim st_dt = DateTime.ParseExact(txtReportStDate.Text, "dd.M.yyyy", Nothing)
                Dim end_dt = DateTime.ParseExact(txtReportEndDate.Text, "dd.M.yyyy", Nothing)
                'If rblReportStatus.SelectedValue = "Approved" Then dateFilter = " and (approve2_dt between '" & st_dt.ToString("yyyy-MM-dd") & "' and '" & end_dt.ToString("yyyy-MM-dd") & "' ) "
                'If rblReportStatus.SelectedValue = "Cancelled" Then dateFilter = " and (cancel_approve_dt between '" & st_dt.ToString("yyyy-MM-dd") & "' and '" & end_dt.ToString("yyyy-MM-dd") & "' ) "
                dateFilter = " and (" & rblReportDTCol.SelectedValue & " between '" & st_dt.ToString("yyyy-MM-dd") & "' and '" & end_dt.ToString("yyyy-MM-dd") & "' ) "
            End If
            gvReport.Visible = True
            gvReportPic.Visible = False
            lbDownloadSummary.Visible = False
            divReportAgency.InnerHtml = ddlReportAgency.SelectedItem.Text
            Dim qPart1 = ""
            Dim agency = ""
            If rblReportType.SelectedValue = "ID" Then
                If ddlReportAgency.SelectedValue = "%" Then
                    'If rblReportStatus.SelectedValue = "Approved" Or rblReportStatus.SelectedValue = "Cancelled" Then
                    '    divReportMessage.InnerHtml = "Show All Not allowed for this report"
                    'End If
                    agency = ", agency "
                End If
                If rblReportStatus.SelectedValue = "Cancelled" Then qPart1 = " , strftime('%d.%m.%Y',first_apply_dt) as 'First Apply', first_apply_by as 'First Apply By', strftime('%d.%m.%Y',first_issue_dt) as 'First Issue Date', strftime('%d.%m.%Y',last_renewal_apply_dt) as 'Last Renewal Apply', last_renewal_apply_by as 'Renewal Apply By', strftime('%d.%m.%Y',approve1_dt) as 'EPC Approved On', approve1_by as 'EPC Approver', strftime('%d.%m.%Y',approve2_dt) as 'BIFPCL Approved On', approve2_by as 'BIFPCL Approver', strftime('%d.%m.%Y',last_renewal_issue_dt) as 'Last Renewal Date', strftime('%d.%m.%Y',cancel_approve_dt) as 'Cancellation Date', cancelRemark "
                If rblReportStatus.SelectedValue = "Approved" Then qPart1 = " , strftime('%d.%m.%Y',approve2_dt) as 'Approve2 Date',  last_renewal_issue_dt as 'Last Renewal Date' "
                q = "select uid,id " & agency & " ,  name , father , sex , age ,strftime('%d.%m.%Y',ifnull(dob,'1900-01-01')) as 'DoB' , 'Village: ' || ifnull(village,'') || ' PO:' || ifnull(po,'') || ' PS:' || ifnull(ps,'') || 'Dist:' || ifnull(district,'') as 'Address', nationality as 'Nationality', nid as 'NID/Passport',  desig, cat ,strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, visa, strftime('%d.%m.%Y', ifnull(visaexp,'1999-01-01')) as visaexp,  mainagency as 'Work Partner', subagency, compliance, status, area " & qPart1 & " ,remark from gatepass where status like '%" & rblReportStatus.SelectedValue & "%' and agency like  '%" & ddlReportAgency.SelectedValue & "%' " & dateFilter & " order by id desc"
            ElseIf rblReportType.SelectedValue = "log" Then
                ' q = "select uid,id " & agency & " , strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, status,   first_apply_by as 'First Apply-By', strftime('%d.%m.%Y',first_issue_dt) as 'First Issue Date', strftime('%d.%m.%Y',last_renewal_apply_dt) as 'Last Renewal Apply', last_renewal_apply_by as 'Renewal Apply By', strftime('%d.%m.%Y',approve1_dt) as 'EPC Approved On', approve1_by as 'EPC Approver', strftime('%d.%m.%Y',approve2_dt) as 'BIFPCL Approved On', approve2_by as 'BIFPCL Approver', strftime('%d.%m.%Y',last_renewal_issue_dt) as 'Last Renewal Date', strftime('%d.%m.%Y',cancel_apply_dt) as 'Cancellation Apply', strftime('%d.%m.%Y',cancel_approve_dt) as 'Cancellation Date' , cancelRemark, strftime('%d.%m.%Y',expelled_dt) as 'Expelled Date' , remark from gatepass where status like '%" & rblReportStatus.SelectedValue & "%' and agency =  '" & ddlReportAgency.SelectedValue & "' order by id desc"
                q = "select uid,id " & agency & " , strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, status, first_apply_dt as 'First Apply',  first_apply_by as 'First Apply By', first_issue_dt as 'First Issue Date', last_renewal_apply_dt as 'Last Renewal Apply', last_renewal_apply_by as 'Renewal Apply By', approve1_dt as 'EPC Approved On', approve1_by as 'EPC Approver', approve2_dt as 'BIFPCL Approved On', approve2_by as 'BIFPCL Approver', last_renewal_issue_dt as 'Last Renewal Date', cancel_apply_dt as 'Cancellation Apply', cancel_approve_dt as 'Cancellation Date' , cancelRemark, expelled_dt as 'Expelled Date' , remark from gatepass where status like '%" & rblReportStatus.SelectedValue & "%' and agency =  '" & ddlReportAgency.SelectedValue & "' order by id desc"
            ElseIf rblReportType.SelectedValue = "due" Then
                qPart1 = " , approve2_dt as 'Approve2 Date', last_renewal_issue_dt as 'Last Renewal Date' "
                q = "select uid,id,   agency ,  name , father , sex , age , 'Village: ' || ifnull(village,'') || ' PO:' || ifnull(po,'') || ' PS:' || ifnull(ps,'') || 'Dist:' || ifnull(district,'') as 'Address', nationality as 'Nationality', nid as 'NID/Passport',  desig, cat ,strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, mainagency as 'Work Partner', status " & qPart1 & " ,remark from gatepass where status like '%" & rblReportStatus.SelectedValue & "%' and agency like   '%" & ddlReportAgency.SelectedValue & "%' and validity_end < current_date  order by id desc"
            ElseIf rblReportType.SelectedValue = "Red" Then
                q = "select uid,id , agency ,  name , father , nid as 'NID/Passport',  desig, strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, status , cancelremark, last_updated from gatepass where agency like  '%" & ddlReportAgency.SelectedValue & "%' and cancelRemark = 'Red' " & dateFilter & "  order by id desc"
            ElseIf rblReportType.SelectedValue = "Green" Then
                q = "select uid,id , agency ,  name , father , nid as 'NID/Passport',  desig, strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, status , cancelremark, last_updated from gatepass where agency like  '%" & ddlReportAgency.SelectedValue & "%' and cancelRemark = 'Green' " & dateFilter & "  order by id desc"

            ElseIf rblReportType.SelectedValue = "duplicate" Then
                q = "select uid,Id, COUNT(*) c, agency ,  name , father , nid as 'NID/Passport',  desig, strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, status , cancelremark, last_updated from gatepass GROUP BY id HAVING c > 1"
            ElseIf rblReportType.SelectedValue = "samenid" Then
                q = "select nid,Id,  agency ,  name , father , nid as 'NID/Passport',  strftime('%d.%m.%Y', dob) as `DoB`, desig, strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, status , last_updated from gatepass where not (status = 'Cancelled'  or status = 'Deleted') and nid in( select nid from (SELECT nid, COUNT(*) c FROM gatepass where  not (status = 'Cancelled'  or status = 'Deleted')  GROUP BY nid HAVING c > 1) ) order by nid"
            ElseIf rblReportType.SelectedValue = "samedob" Then
                q = "select dob,Id, agency ,  name , father , nid as 'NID/Passport',   strftime('%d.%m.%Y', dob) as `DoB`, desig, strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, status , last_updated from gatepass where not (status = 'Cancelled'  or status = 'Deleted') and dob in( select dob from (SELECT dob, COUNT(*) c FROM gatepass where  not (status = 'Cancelled'  or status = 'Deleted')  GROUP BY dob HAVING c > 1) ) order by dob"
            ElseIf rblReportType.SelectedValue = "samename" Then
                q = "select name,Id, agency ,  name , father , nid as 'NID/Passport',   strftime('%d.%m.%Y', dob) as `DoB`, desig, strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, status , last_updated from gatepass where not (status = 'Cancelled'  or status = 'Deleted') and name in( select name from (SELECT name, COUNT(*) c FROM gatepass where  not (status = 'Cancelled'  or status = 'Deleted')  GROUP BY name HAVING c > 1) ) order by name"
            ElseIf rblReportType.SelectedValue = "samefather" Then
                q = "select father, Id, agency ,  name , father , nid as 'NID/Passport',   strftime('%d.%m.%Y', dob) as `DoB`, desig, strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, status , last_updated from gatepass where not (status = 'Cancelled'  or status = 'Deleted') and father in( select father from (SELECT father, COUNT(*) c FROM gatepass where  not (status = 'Cancelled'  or status = 'Deleted') GROUP BY father HAVING c > 1) ) order by father"

            ElseIf rblReportType.SelectedValue = "Insurance" Then
                Dim ag = ddlReportAgency.SelectedItem.Text
                If ag = "Show All" Then ag = "%"
                q = "select agency, uid, agency, policyno, strftime('%d.%m.%Y',validity_start) as 'Validity Start', strftime('%d.%m.%Y',validity_end) as 'Validity End', persons as 'Total Covered' from insurance where agency like '%" & ag & "%' order by agency"
            ElseIf rblReportType.SelectedValue = "InsuranceDue" Then
                q = "select agency, agency, policyno, persons, strftime('%d.%m.%Y', validity_start) as vStart, strftime('%d.%m.%Y', validity_end) as vEnd from insurance where persons > 0 and Cast ((JulianDay(validity_end) - JulianDay(current_date)) As Integer) < 15 order by agency"

            ElseIf rblReportType.SelectedValue = "photo" Then
                q = "select distinct id as id1, id, name,agency, status, '' as pic from gatepass where id is not null and agency = '" & ddlReportAgency.SelectedValue & "'"
            ElseIf rblReportType.SelectedValue = "agency" Then
                q = "select distinct agency, count(id) as totalpass from gatepass where agency in (select agency from agency) group by agency "
                Dim agDT = getDBTable(q, "gpdb")
                dateFilter = ""
                If Not String.IsNullOrEmpty(txtReportStDate.Text) And Not String.IsNullOrEmpty(txtReportEndDate.Text) Then
                    Dim st_dt = DateTime.ParseExact(txtReportStDate.Text, "dd.M.yyyy", Nothing)
                    Dim end_dt = DateTime.ParseExact(txtReportEndDate.Text, "dd.M.yyyy", Nothing)
                    dateFilter = " and (approve2_dt between '" & st_dt.ToString("yyyy-MM-dd") & "' and '" & end_dt.ToString("yyyy-MM-dd") & "' ) "
                End If
                q = "select agency, status, count(id) as 'Total ID' from gatepass where agency in (select agency from agency) " & dateFilter & "  group by agency, status order by agency"
                Dim cummDT = getDBTable(q, "gpdb")
                    q = "select agency, sum(persons) from insurance where 1 group by agency"
                    Dim insuranceDT = getDBTable(q, "gpdb")
                    q = "select agency, count(id) as 'Total ID' from gatepass where agency in (select agency from agency) and compliance = 'Height' group by agency order by agency"
                Dim heightDT = getDBTable(q, "gpdb")
                q = "select agency, count(id) as 'Total ID' from gatepass where agency in (select agency from agency) and status = 'Approved'  group by agency order by agency"
                Dim dueRenewalDT = getDBTable(q, "gpdb")
                q = "select agency, count(id) as 'Total ID' from gatepass where agency in (select agency from agency) and cancelRemark = 'Red' group by agency order by agency"
                Dim redDT = getDBTable(q, "gpdb")
                q = "select agency, count(id) as 'Total ID' from gatepass where agency in (select agency from agency) and cancelRemark = 'Green' group by agency order by agency"
                Dim greenDT = getDBTable(q, "gpdb")
                q = "select agency, count(id) as 'Total ID' from gatepass where agency in (select agency from agency) and status = 'Approved'  and (cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) > 1 and  cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) < 25) group by agency order by agency"
                Dim L25DT = getDBTable(q, "gpdb")
                q = "select agency, count(id) as 'Total ID' from gatepass where agency in (select agency from agency) and status = 'Approved'  and (cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) > 24 and  cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) < 45) group by agency order by agency"
                Dim U45DT = getDBTable(q, "gpdb")
                q = "select agency, count(id) as 'Total ID' from gatepass where agency in (select agency from agency) and status = 'Approved'  and (cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) > 44 and  cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) < 55) group by agency order by agency"
                Dim U55DT = getDBTable(q, "gpdb")
                q = "select agency, count(id) as 'Total ID' from gatepass where agency in (select agency from agency) and status = 'Approved' and (cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) > 54 and  cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) < 100) group by agency order by agency"
                Dim G55DT = getDBTable(q, "gpdb")

                Dim finalDT1 As New System.Data.DataTable()
                    finalDT1.Columns.Add("SN")
                    finalDT1.Columns.Add("Agency")
                    finalDT1.Columns.Add("Totalpass")
                    finalDT1.Columns.Add("Insurance")
                finalDT1.Columns.Add("ApprovedPass")
                finalDT1.Columns.Add("RevApprovedPass")
                finalDT1.Columns.Add("HeightWork")
                finalDT1.Columns.Add("DueForRenewal")
                finalDT1.Columns.Add("RedPass")
                finalDT1.Columns.Add("GreenPass")
                finalDT1.Columns.Add("EPCPendingNew")
                    finalDT1.Columns.Add("BIFPCLPendingNew")
                    finalDT1.Columns.Add("EPCPendingReNew")
                    finalDT1.Columns.Add("BIFPCLPendingReNew")
                    finalDT1.Columns.Add("EPCPendingCancel")
                    finalDT1.Columns.Add("BIFPCLPendingCancel")
                finalDT1.Columns.Add("Cancelled")
                finalDT1.Columns.Add("L25")
                finalDT1.Columns.Add("U45")
                finalDT1.Columns.Add("U55")
                finalDT1.Columns.Add("G55")
                Dim i = 0
                For Each nwRow In agDT.Rows

                    Dim rowStr = ""
                    Dim tmpRow = finalDT1.NewRow
                    i = i + 1
                    tmpRow("SN") = i
                    tmpRow("Agency") = nwRow("agency")
                    tmpRow("Totalpass") = nwRow("totalpass")
                    Dim cummApprovedRow = cummDT.Select("agency = '" & nwRow("agency") & "' and status = 'Approved'")
                    Dim cummApproved As Double = If(cummApprovedRow.Length = 1, cummApprovedRow(0)(2), 0)
                    tmpRow("ApprovedPass") = cummApproved.ToString
                    Dim EPCPendingNewRow = cummDT.Select("agency = '" & nwRow("agency") & "' and status = 'New_A1'")
                    Dim EPCPendingNew As Double = If(EPCPendingNewRow.Length = 1, EPCPendingNewRow(0)(2), 0)
                    tmpRow("EPCPendingNew") = EPCPendingNew.ToString
                    Dim BIFPCLPendingNewRow = cummDT.Select("agency = '" & nwRow("agency") & "' and status = 'New_A2'")
                    Dim BIFPCLPendingNew As Double = If(BIFPCLPendingNewRow.Length = 1, BIFPCLPendingNewRow(0)(2), 0)
                    tmpRow("BIFPCLPendingNew") = BIFPCLPendingNew.ToString
                    Dim EPCPendingReNewRow = cummDT.Select("agency = '" & nwRow("agency") & "' and status = 'Renew_A1'")
                    Dim EPCPendingReNew As Double = If(EPCPendingReNewRow.Length = 1, EPCPendingReNewRow(0)(2), 0)
                    tmpRow("EPCPendingReNew") = EPCPendingReNew.ToString
                    Dim BIFPCLPendingReNewRow = cummDT.Select("agency = '" & nwRow("agency") & "' and status = 'Renew_A2'")
                    Dim BIFPCLPendingReNew As Double = If(BIFPCLPendingReNewRow.Length = 1, BIFPCLPendingReNewRow(0)(2), 0)
                    tmpRow("BIFPCLPendingReNew") = BIFPCLPendingReNew.ToString
                    Dim EPCPendingCancelRow = cummDT.Select("agency = '" & nwRow("agency") & "' and status = 'Cancel_A1'")
                    Dim EPCPendingCancel As Double = If(EPCPendingCancelRow.Length = 1, EPCPendingCancelRow(0)(2), 0)
                    tmpRow("EPCPendingCancel") = EPCPendingCancel.ToString
                    Dim BIFPCLPendingCancelRow = cummDT.Select("agency = '" & nwRow("agency") & "' and status = 'Cancel_A2'")
                    Dim BIFPCLPendingCancel As Double = If(BIFPCLPendingCancelRow.Length = 1, BIFPCLPendingCancelRow(0)(2), 0)
                    tmpRow("BIFPCLPendingCancel") = BIFPCLPendingCancel.ToString
                    Dim CancelledRow = cummDT.Select("agency = '" & nwRow("agency") & "' and status = 'Cancelled'")
                    Dim Cancelled As Double = If(CancelledRow.Length = 1, CancelledRow(0)(2), 0)
                    tmpRow("Cancelled") = Cancelled.ToString
                    Dim insuranceRow = insuranceDT.Select("agency = '" & nwRow("agency") & "' ")
                    Dim insurance As Double = If(insuranceRow.Length = 1, insuranceRow(0)(1), 0)
                    tmpRow("insurance") = insurance.ToString
                    Dim HeightWorkRow = heightDT.Select("agency = '" & nwRow("agency") & "' ")
                    Dim HeightWork As Double = If(HeightWorkRow.Length = 1, HeightWorkRow(0)(1), 0)
                    tmpRow("HeightWork") = HeightWork.ToString
                    Dim DueForRenewalRow = dueRenewalDT.Select("agency = '" & nwRow("agency") & "' ")
                    Dim DueForRenewal As Double = If(DueForRenewalRow.Length = 1, DueForRenewalRow(0)(1), 0)
                    tmpRow("DueForRenewal") = DueForRenewal.ToString
                    Dim redRow = redDT.Select("agency = '" & nwRow("agency") & "' ")
                    Dim red As Double = If(redRow.Length = 1, redRow(0)(1), 0)
                    tmpRow("RedPass") = red.ToString
                    Dim greenRow = greenDT.Select("agency = '" & nwRow("agency") & "' ")
                    Dim green As Double = If(greenRow.Length = 1, greenRow(0)(1), 0)
                    tmpRow("GreenPass") = green.ToString

                    Dim L25Row = L25DT.Select("agency = '" & nwRow("agency") & "' ")
                    Dim L25 As Double = If(L25Row.Length = 1, L25Row(0)(1), 0)
                    tmpRow("L25") = L25.ToString
                    Dim U45Row = U45DT.Select("agency = '" & nwRow("agency") & "' ")
                    Dim U45 As Double = If(U45Row.Length = 1, U45Row(0)(1), 0)
                    tmpRow("U45") = U45.ToString
                    Dim U55Row = U55DT.Select("agency = '" & nwRow("agency") & "' ")
                    Dim U55 As Double = If(U55Row.Length = 1, U55Row(0)(1), 0)
                    tmpRow("U55") = U55.ToString
                    Dim G55Row = G55DT.Select("agency = '" & nwRow("agency") & "' ")
                    Dim G55 As Double = If(G55Row.Length = 1, G55Row(0)(1), 0)
                    tmpRow("G55") = G55.ToString

                    tmpRow("RevApprovedPass") = Int32.Parse(tmpRow("ApprovedPass")) + Int32.Parse(tmpRow("EPCPendingReNew")) + Int32.Parse(tmpRow("BIFPCLPendingReNew"))
                    finalDT1.Rows.Add(tmpRow)
                Next

                Dim totalsRow = finalDT1.NewRow
                For Each col As Data.DataColumn In finalDT1.Columns
                    If Not col.ColumnName = "Agency" Then
                        Dim colTotal As Integer = 0
                        For Each row In finalDT1.Rows
                            colTotal = (colTotal + Int32.Parse(row(col).ToString))
                        Next
                        totalsRow(col.ColumnName) = colTotal
                    End If
                Next

                finalDT1.Rows.Add(totalsRow)

                gvReport.DataSource = finalDT1
                    gvReport.DataBind()
                    gvReport.UseAccessibleHeader = True
                    gvReport.HeaderRow.TableSection = TableRowSection.TableHeader
                    gvReport.FooterRow.TableSection = TableRowSection.TableFooter
                    Return True
                ElseIf rblReportType.SelectedValue = "agencynation" Then
                    q = "select distinct agency, count(id) as totalpass from gatepass where agency in (select agency from agency) and status = 'Approved' group by agency "
                Dim agDT = getDBTable(q, "gpdb")
                q = "select agency, cat,  count(id) as 'Total ID' , nationality from gatepass where agency in (select agency from agency) and status = 'Approved'   group by agency, cat, nationality order by agency"
                Dim cummDT = getDBTable(q, "gpdb")
                q = "select agency, sum(persons) from insurance where 1 group by agency"
                Dim finalDT1 As New System.Data.DataTable()
                finalDT1.Columns.Add("SN")
                finalDT1.Columns.Add("Agency")
                finalDT1.Columns.Add("TotalpassApproved")
                finalDT1.Columns.Add("UNSKILLED_IN")
                finalDT1.Columns.Add("UNSKILLED_BD")
                finalDT1.Columns.Add("SEMISKILLED_IN")
                finalDT1.Columns.Add("SEMISKILLED_BD")
                finalDT1.Columns.Add("SKILLED_IN")
                finalDT1.Columns.Add("SKILLED_BD")
                finalDT1.Columns.Add("HIGHLYSKILLED_IN")
                finalDT1.Columns.Add("HIGHLYSKILLED_BD")
                finalDT1.Columns.Add("Manpower_Other")
                Dim i = 0
                For Each nwRow In agDT.Rows

                    Dim rowStr = ""
                    Dim tmpRow = finalDT1.NewRow
                    i = i + 1
                    tmpRow("SN") = i
                    tmpRow("Agency") = nwRow("agency")
                    tmpRow("TotalpassApproved") = nwRow("totalpass")
                    Dim UNSKILLED_INRow = cummDT.Select("agency = '" & nwRow("agency") & "' and cat = 'UNSKILLED' and nationality like 'Indian'")
                    Dim UNSKILLED_IN As Double = If(UNSKILLED_INRow.Length = 1, UNSKILLED_INRow(0)(2), 0)
                    tmpRow("UNSKILLED_IN") = UNSKILLED_IN.ToString
                    Dim SKILLED_INRow = cummDT.Select("agency = '" & nwRow("agency") & "' and cat = 'SKILLED' and nationality like 'Indian'")
                    Dim SKILLED_IN As Double = If(SKILLED_INRow.Length = 1, SKILLED_INRow(0)(2), 0)
                    tmpRow("SKILLED_IN") = SKILLED_IN.ToString
                    Dim SEMISKILLED_INRow = cummDT.Select("agency = '" & nwRow("agency") & "' and cat = 'SEMISKILLED' and nationality like 'Indian'")
                    Dim SEMISKILLED_IN As Double = If(SEMISKILLED_INRow.Length = 1, SEMISKILLED_INRow(0)(2), 0)
                    tmpRow("SEMISKILLED_IN") = SEMISKILLED_IN.ToString
                    Dim HIGHLYSKILLED_INRow = cummDT.Select("agency = '" & nwRow("agency") & "' and cat = 'HIGHLYSKILLED' and nationality like 'Indian'")
                    Dim HIGHLYSKILLED_IN As Double = If(HIGHLYSKILLED_INRow.Length = 1, HIGHLYSKILLED_INRow(0)(2), 0)
                    tmpRow("HIGHLYSKILLED_IN") = HIGHLYSKILLED_IN.ToString
                    Dim UNSKILLED_BDRow = cummDT.Select("agency = '" & nwRow("agency") & "' and cat = 'UNSKILLED' and nationality like 'Bangladeshi'")
                    Dim UNSKILLED_BD As Double = If(UNSKILLED_BDRow.Length = 1, UNSKILLED_BDRow(0)(2), 0)
                    tmpRow("UNSKILLED_BD") = UNSKILLED_BD.ToString
                    Dim SKILLED_BDRow = cummDT.Select("agency = '" & nwRow("agency") & "' and cat = 'SKILLED' and nationality like 'Bangladeshi'")
                    Dim SKILLED_BD As Double = If(SKILLED_BDRow.Length = 1, SKILLED_BDRow(0)(2), 0)
                    tmpRow("SKILLED_BD") = SKILLED_BD.ToString
                    Dim SEMISKILLED_BDRow = cummDT.Select("agency = '" & nwRow("agency") & "' and cat = 'SEMISKILLED' and nationality like 'Bangladeshi'")
                    Dim SEMISKILLED_BD As Double = If(SEMISKILLED_BDRow.Length = 1, SEMISKILLED_BDRow(0)(2), 0)
                    tmpRow("SEMISKILLED_BD") = SEMISKILLED_BD.ToString
                    Dim HIGHLYSKILLED_BDRow = cummDT.Select("agency = '" & nwRow("agency") & "' and cat = 'HIGHLYSKILLED' and nationality like 'Bangladeshi'")
                    Dim HIGHLYSKILLED_BD As Double = If(HIGHLYSKILLED_BDRow.Length = 1, HIGHLYSKILLED_BDRow(0)(2), 0)
                    tmpRow("HIGHLYSKILLED_BD") = HIGHLYSKILLED_BD.ToString
                    tmpRow("Manpower_Other") = (Int32.Parse(nwRow("totalpass")) - (UNSKILLED_IN + SKILLED_IN + SEMISKILLED_IN + HIGHLYSKILLED_IN + UNSKILLED_BD + SKILLED_BD + SEMISKILLED_BD + HIGHLYSKILLED_BD)).ToString
                    finalDT1.Rows.Add(tmpRow)
                Next
                gvReport.DataSource = finalDT1
                gvReport.DataBind()
                gvReport.UseAccessibleHeader = True
                gvReport.HeaderRow.TableSection = TableRowSection.TableHeader
                gvReport.FooterRow.TableSection = TableRowSection.TableFooter
                Return True
            End If

            ' diverr.InnerHtml = q
            Dim nwDT = getDBTable(q, "gpdb")
            If rblReportType.SelectedValue = "photo" Then
                For Each r In nwDT.Rows
                    Dim file_name As String = Server.MapPath("./upload/gatepass/") + r("id").ToString + ".jpg"
                    r("pic") = File.Exists(file_name).ToString.Replace("True", "Yes").Replace("False", "No")
                Next
            End If
            ''' Showing different report with photograph
            If rblReportStatus.SelectedValue = "New_A1" Then
                gvReportPic.Visible = True
                lbDownloadSummary.Visible = True
                gvReport.Visible = False
                gvReportPic.DataSource = nwDT
                gvReportPic.DataBind()
                Return False
            End If

            If nwDT.Rows.Count = 0 Then
                divReportMessage.InnerHtml = "No data exist" '& q
                gvReport.DataSource = nwDT
                gvReport.DataBind()
                Return False
            End If

            divReportMessage.InnerHtml = "Showing " & rblReportType.SelectedItem.Text & " having " & rblReportStatus.SelectedItem.Text & " status " & nwDT.Rows.Count & " Records found For given filters." '& q

            errorPart = " Linq Vendor Grand Total wise custom report "

            ' finalDT1.Merge(result, False)
            gvReport.DataSource = nwDT
            gvReport.DataBind()

            '  //This replaces <td> with <th> And adds the scope attribute
            gvReport.UseAccessibleHeader = True
            ' //This will add the <thead> And <tbody> elements
            gvReport.HeaderRow.TableSection = TableRowSection.TableHeader

            ' //This adds the <tfoot> element. 
            ' //Remove if you don't have a footer row
            gvReport.FooterRow.TableSection = TableRowSection.TableFooter
        Catch ex As Exception
            divReportMessage.InnerHtml = "Error after  " & errorPart & ex.Message '& q
        End Try
    End Function

    Sub loadPrintGrid()
        Dim q = "Select uid,id, name, approve2_dt As 'ApprovedOn',desig,nid, strftime('%d.%m.%Y', validity_start) as validity_start,strftime('%d.%m.%Y', validity_end) as validity_end, status from gatepass where status = 'Approved' and agency like  '" & ddlPrintAgency.SelectedValue & "' and compliance like '" & ddlPrintCompliance.SelectedValue & "' order by id desc"
        gvPrint.DataSource = getDBTable(q, "gpdb")
        gvPrint.DataBind()
    End Sub
    Sub loadCoverGrid()
        Dim status = ""
        If lbCoverType.Text = "Agency" Then
            status = " (status = '" & rblCoverStatus.SelectedValue & "_A1' or status = '" & rblCoverStatus.SelectedValue & "_A2' )"
        ElseIf lbCoverType.Text = "EPC" Then
            status = " status = '" & rblCoverStatus.SelectedValue & "_A2' "
        End If
        Dim q = "select uid,id, name, approve2_dt as 'ApprovedOn',desig,nid, strftime('%d.%m.%Y', validity_start) as validity_start,strftime('%d.%m.%Y', validity_end) as validity_end, status from gatepass where " & status & " and agency like  '" & ddlCoverAgency.SelectedValue & "' order by id , status desc"
        Dim mydt = getDBTable(q, "gpdb")
        If mydt.Rows.Count = 0 Then
            lbMessageCover.Text = "No data found for " & ddlCoverAgency.SelectedValue & " status " & status
            gvCover.DataSource = mydt
            gvCover.DataBind()
            Exit Sub
        End If
        lbMessageCover.Text = mydt.Rows.Count & " records found for " & ddlCoverAgency.SelectedValue & " status " & status
        gvCover.DataSource = mydt
        gvCover.DataBind()
    End Sub
    Sub reloadGPData(ByVal status As String)
        Dim q = ""
        Try
            Dim qPart1 = " ,first_apply_by as apply_by , first_apply_dt as apply_dt"
            If lbNewApproverType.Text = "New" Then
                qPart1 = " ,first_apply_by as apply_by, strftime('%d.%m.%Y',first_apply_dt) as apply_dt "
            ElseIf lbNewApproverType.Text = "Renew" Then
                qPart1 = " ,last_renewal_apply_by as apply_by, strftime('%d.%m.%Y',last_renewal_apply_dt) as apply_dt "
            ElseIf lbNewApproverType.Text = "Cancellation" Then
                qPart1 = " ,last_renewal_apply_by as apply_by, strftime('%d.%m.%Y',last_renewal_apply_dt) as apply_dt "
            End If
            q = "select id,sn,name,father,sex,age,strftime('%d.%m.%Y',dob) as dob,nationality,nid,mainagency,agency,subagency,desig,cat,status,mainagency,village,po,ps,district,cell,bgroup,area, strftime('%d.%m.%Y',validity_start) as validity_start,strftime('%d.%m.%Y',validity_end) as validity_end, visa, strftime('%d.%m.%Y',visaexp) as visaexp, cancelremark, last_updated,lastupdateby, compliance " & qPart1 & " from gatepass where id = " & lbID.Text & " limit 1"
            Dim mydt = dbOp.getDBTable(q, "gpdb")
            If mydt.Rows.Count < 1 Then
                lbBookMessage.Text = "No Records found for requested ID load failed.."
                btnSumbitPass.Enabled = False
                Exit Sub
            End If
            txtNewName.Text = If(IsDBNull(mydt.Rows(0)("name")), "", mydt.Rows(0)("name"))
            txtNewDesig.Text = If(IsDBNull(mydt.Rows(0)("desig")), "", mydt.Rows(0)("desig"))
            txtNewCell.Text = If(IsDBNull(mydt.Rows(0)("cell")), "", mydt.Rows(0)("cell"))
            txtNewFather.Text = If(IsDBNull(mydt.Rows(0)("father")), "", mydt.Rows(0)("father"))
            txtNewNID.Text = If(IsDBNull(mydt.Rows(0)("nid")), "", mydt.Rows(0)("nid"))
            txtDoB.Text = If(IsDBNull(mydt.Rows(0)("dob")), "", mydt.Rows(0)("dob"))
            lbNewAge.Text = If(IsDBNull(mydt.Rows(0)("age")), "", mydt.Rows(0)("age")) & " Yrs."
            txtNewSubAgency.Text = If(IsDBNull(mydt.Rows(0)("subagency")), "", mydt.Rows(0)("subagency")).replace("NA", "")
            txtNewVillage.Text = If(IsDBNull(mydt.Rows(0)("village")), "", mydt.Rows(0)("village")).ToString.Replace("NA", "")
            txtNewPO.Text = If(IsDBNull(mydt.Rows(0)("po")), "", mydt.Rows(0)("po")).ToString.Replace("NA", "")
            txtNewPS.Text = If(IsDBNull(mydt.Rows(0)("ps")), "", mydt.Rows(0)("ps")).ToString.Replace("NA", "")
            txtNewDistrict.Text = If(IsDBNull(mydt.Rows(0)("district")), "", mydt.Rows(0)("district")).ToString.Replace("NA", "")
            txtNewValidityStart.Text = If(IsDBNull(mydt.Rows(0)("validity_start")), "", mydt.Rows(0)("validity_start")).ToString.Replace("NA", "")
            txtNewValidityEnd.Text = If(IsDBNull(mydt.Rows(0)("validity_end")), "", mydt.Rows(0)("validity_end")).ToString.Replace("NA", "")
            txtNewVisa.Text = If(IsDBNull(mydt.Rows(0)("visa")), "", mydt.Rows(0)("visa")).ToString.Replace("NA", "")
            txtNewVisaExp.Text = If(IsDBNull(mydt.Rows(0)("visaexp")), "", mydt.Rows(0)("visaexp")).ToString.Replace("NA", "")

            Dim applyDate = If(IsDBNull(mydt.Rows(0)("apply_dt")), "", mydt.Rows(0)("apply_dt")).ToString.Replace("NA", "")
            Dim applyBy = If(IsDBNull(mydt.Rows(0)("apply_by")), "", mydt.Rows(0)("apply_by")).ToString.Replace("NA", "")
            Dim myStatus = If(IsDBNull(mydt.Rows(0)("status")), "", mydt.Rows(0)("status")).ToString.Replace("NA", "")
            lbInfo.Text = "Applied on " & applyDate & " By " & applyBy
            If Not String.IsNullOrEmpty(txtNewValidityStart.Text) Then lbRemark.Text = "Validity from " & txtNewValidityStart.Text & " to " & txtNewValidityEnd.Text
            If lbNewMode.Text = "Modify" Then ddlNewChangeStatus.SelectedValue = myStatus
            Dim blood = If(IsDBNull(mydt.Rows(0)("bgroup")), "", mydt.Rows(0)("bgroup"))
            Dim cat = If(IsDBNull(mydt.Rows(0)("cat")), "", mydt.Rows(0)("cat"))
            Dim cancelremark = If(IsDBNull(mydt.Rows(0)("cancelremark")), "", mydt.Rows(0)("cancelremark"))
            If String.IsNullOrEmpty(blood) Then
                ddlBlood.SelectedValue = "NA"
            Else
                ddlBlood.SelectedValue = blood
            End If
            If String.IsNullOrEmpty(cat) Then
                ddlNewCat.SelectedValue = "NA"
            Else
                ddlNewCat.SelectedValue = cat
            End If
            If String.IsNullOrEmpty(cancelremark) Then
                rblNewCancelRemark.SelectedValue = "Green"
            Else
                rblNewCancelRemark.SelectedValue = cancelremark
            End If
            Dim sex = If(IsDBNull(mydt.Rows(0)("sex")), "", mydt.Rows(0)("sex"))
            If String.IsNullOrEmpty(sex) Then
                ddlNewSex.SelectedValue = "Male"
            Else
                ddlNewSex.SelectedValue = sex
            End If
            Dim nationality = If(IsDBNull(mydt.Rows(0)("nationality")), "", mydt.Rows(0)("nationality"))
            If String.IsNullOrEmpty(nationality) Then
                ddlNewNation.SelectedValue = "Bangladeshi"
            Else
                ddlNewNation.SelectedValue = nationality
            End If
            Dim mainagency = If(IsDBNull(mydt.Rows(0)("mainagency")), "", mydt.Rows(0)("mainagency"))
            If String.IsNullOrEmpty(mainagency) Then
                ddlNewVendor.SelectedValue = "BHEL"
            Else
                ddlNewVendor.SelectedValue = mainagency
            End If
            Dim agency = If(IsDBNull(mydt.Rows(0)("agency")), "", mydt.Rows(0)("agency"))
            If String.IsNullOrEmpty(agency) Then
                ddlNewAgency.SelectedValue = "BHEL"
            Else
                ddlNewAgency.SelectedValue = agency
            End If
            Dim compliance = If(IsDBNull(mydt.Rows(0)("compliance")), "", mydt.Rows(0)("compliance"))
            If String.IsNullOrEmpty(compliance) Then
                ddlNewCompliance.SelectedValue = "BHEL"
            Else
                ddlNewCompliance.SelectedValue = compliance
            End If
            Dim area = If(IsDBNull(mydt.Rows(0)("area")), "", mydt.Rows(0)("area"))
            If String.IsNullOrEmpty(area) Then
                ddlNewWorkArea.SelectedValue = "Chimney"
            Else
                ddlNewWorkArea.SelectedValue = area
            End If
            Dim duplicate = getDBsingle("select group_concat (id || ' (' || status || ' - ' || agency || ') ') from gatepass where nid = '" & txtNewNID.Text & "' and not id = " & lbID.Text, "gpdb")
            lblDuplicate.Text = duplicate
            lbBookMessage.Text = " id= " & lbID.Text & " for " & agency & " Loaded succesfully. You can make changes before approval."
        Catch ex As Exception
            lbBookMessage.Text = "Error in LoadGPData " & ex.Message & " id= " & lbID.Text & q
        End Try
    End Sub
    Private Sub rblApproveType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblApproveType.SelectedIndexChanged
        loadApproveGrid()
    End Sub
    Sub loadApproveGrid()
        Dim status = ""
        Dim qPart1 = ", remark "
        If rblApproveType.SelectedValue = "New" Then
            If lbApprover.Text.Contains("EPC") Then status = "New_A1"
            If lbApprover.Text.Contains("BIFPCL") Then status = "New_A2"
            btnApprove.Text = "Approve Single"
            btnAproveBulk.Text = "Approve Selected (Bulk)"
        ElseIf rblApproveType.SelectedValue = "Renew" Then
            If lbApprover.Text.Contains("EPC") Then status = "Renew_A1"
            If lbApprover.Text.Contains("BIFPCL") Then status = "Renew_A2"
            btnApprove.Text = "Renew Single"
            btnAproveBulk.Text = "Renew Selected (Bulk)"
        ElseIf rblApproveType.SelectedValue = "Cancel" Then
            If lbApprover.Text.Contains("EPC") Then status = "Cancel_A1"
            If lbApprover.Text.Contains("BIFPCL") Then status = "Cancel_A2"
            btnApprove.Text = "Cancel Single"
            btnAproveBulk.Text = "Cancel Selected (Bulk)"
            qPart1 = ", cancelRemark as remark "
        End If
        Dim q = "select uid,id, name, agency,desig,nid,strftime('%d.%m.%Y', dob) as dob, strftime('%d.%m.%Y', approve1_dt) as approve1_dt, '' as crosscheck, strftime('%d.%m.%Y', validity_start) as validity_start,strftime('%d.%m.%Y', validity_end) as validity_end" & qPart1 & ", status, subagency, cat, compliance from gatepass where status = '" & status & "' and agency like '" & ddlApproverAgency.SelectedValue & "' order by id desc"
        Dim mydt = getDBTable(q, "gpdb")
        For Each r In mydt.Rows
            Dim duplicate = getDBsingle("select group_concat (id || ' (' || status || ' - ' || substr(agency,1,12) || '..) ') from gatepass where nid = '" & r("nid") & "' and not id = " & r("id"), "gpdb")
            r("crosscheck") = duplicate
        Next
        lbApprovePass.Text = mydt.Rows.Count & " Passes avilable for " & rblApproveType.SelectedItem.Text & " approval"
        gvPassApprove.DataSource = myDT
        gvPassApprove.DataBind()

    End Sub
    Sub loadRenewalGrid()
        Dim q = "select uid,id, name, agency,desig,nid, strftime('%d.%m.%Y', validity_start) as validity_start,strftime('%d.%m.%Y', validity_end) as validity_end, status from gatepass where status = 'Approved' and agency like '" & ddlRenewAgency.SelectedValue & "' order by last_updated desc"
        Dim mydt = getDBTable(q, "gpdb")
        lbRenewMessage.Text = mydt.Rows.Count & " Records found "
        gvRenewal.DataSource = mydt
        gvRenewal.DataBind()

    End Sub
    Sub loadCancelGrid()
        Dim q = "select uid,id, name, agency,desig,nid, strftime('%d.%m.%Y', validity_start) as validity_start,strftime('%d.%m.%Y', validity_end) as validity_end, status from gatepass where status = 'Approved' and agency like '" & ddlCancelAgency.SelectedValue & "' order by last_updated desc"
        Dim mydt = getDBTable(q, "gpdb")
        lbCancelMessage.Text = mydt.Rows.Count & " Records found "
        gvCancel.DataSource = mydt
        gvCancel.DataBind()
        'lbCancelMessage.text 
    End Sub
    Sub loadModifyGrid()
        Dim q = "select uid,id, name, agency,desig,nid, strftime('%d.%m.%Y', validity_start) as validity_start,strftime('%d.%m.%Y', validity_end) as validity_end, status from gatepass where status = 'Approved' and agency like '" & ddlMoifyAgency.SelectedValue & "' order by last_updated desc"
        Dim mydt = getDBTable(q, "gpdb")
        lbModifyApprover.Text = mydt.Rows.Count & " Records found "
        gvModify.DataSource = mydt
        gvModify.DataBind()
        'lbCancelMessage.text 
    End Sub

    Protected Sub UploadFile(sender As Object, e As EventArgs)
        Dim msg = ""
        If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343272")
        Try

            If FileUpload1.PostedFile IsNot Nothing Then
                Dim uploadDir = "upload/gatepass/"
                If Not System.IO.Directory.Exists(Server.MapPath(uploadDir)) Then
                    msg = "Creating Path " & uploadDir & "<br/>"
                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir))
                End If

                Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                Dim ext = ".jpg" ' Path.GetExtension(FileName)
                Dim newFilename = lbID.Text & ext
                FileUpload1.SaveAs(Server.MapPath(uploadDir & "Big" & newFilename))
                Image_resize(uploadDir & "Big" & newFilename, uploadDir & newFilename, 200)

                If System.IO.File.Exists(Server.MapPath(uploadDir & "Big" & newFilename)) Then
                    System.IO.File.Delete(Server.MapPath(uploadDir & "Big" & newFilename))
                    msg = "Attempt to delete " & uploadDir & "Big" & newFilename
                Else
                    msg = "Not exist " & uploadDir & "Big" & newFilename
                End If
                divPic.InnerHtml = "<img src=" & "/upload/gatepass/" & newFilename & "?" & Now.Second & " />"
                lbPicStatus.Text = "Pic Uploaded"
            End If

            lbBookMessage.Text = "Pic Uploaded" ' msg
        Catch _ex As Exception
            lbBookMessage.Text = _ex.Message
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

    Private Sub btnSumbitPass_Click(sender As Object, e As EventArgs) Handles btnSumbitPass.Click
        If Session("email") Is Nothing Then Response.Redirect("Default.aspx")
        Dim msg = ""
        If String.IsNullOrEmpty(txtNewName.Text) Then
            lbBookMessage.Text = "Name can't be blank"
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtNewFather.Text) Then
            lbBookMessage.Text = "Father can't be blank"
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDoB.Text) Then
            lbBookMessage.Text = "Date of Birth can't be blank"
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtNewNID.Text) Then
            lbBookMessage.Text = "NID/Passport can't be blank"
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtNewVillage.Text) Or String.IsNullOrEmpty(txtNewPO.Text) Or String.IsNullOrEmpty(txtNewPS.Text) Or String.IsNullOrEmpty(txtNewDistrict.Text) Or String.IsNullOrEmpty(txtNewCell.Text) Then
            lbBookMessage.Text = "Address/Contact can't be blank"
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtNewValidityStart.Text) Or String.IsNullOrEmpty(txtNewValidityEnd.Text) Then
            If lbNewMode.Text = "Modify" Then  ''put dummy dates
                txtNewValidityStart.Text = "01.01.2000"
                txtNewValidityEnd.Text = "01.01.2001"
            Else
                lbBookMessage.Text = "Validity can't be blank"
                lbBookMessageTop.Text = lbBookMessage.Text
                Exit Sub
            End If
        End If
        If String.IsNullOrEmpty(txtNewDesig.Text) Then
            lbBookMessage.Text = "Designation can't be blank"
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        Dim validity_start = DateTime.ParseExact(txtNewValidityStart.Text, "dd.M.yyyy", Nothing)
        Dim validity_end = DateTime.ParseExact(txtNewValidityEnd.Text, "dd.M.yyyy", Nothing)
        Dim visaexp = ""
        If Not String.IsNullOrEmpty(txtNewVisaExp.Text) Then
            Dim visaexpDate = DateTime.ParseExact(txtNewVisaExp.Text, "dd.M.yyyy", Nothing)
            visaexp = visaexpDate.ToString("yyyy-MM-dd")
        End If
        If validity_start > validity_end Then
            lbBookMessage.Text = "Check validity dates"
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        Dim dob = DateTime.ParseExact(txtDoB.Text, "dd.M.yyyy", Nothing)
        Dim age = Math.Floor(Now.Subtract(dob).TotalDays / 365)
        If lbNewMode.Text = "New" Then
            ' msg = "Insert"
            If lbPicStatus.Text.Contains("Not") Then
                lbBookMessage.Text = "Picture Not Uploaded"
                lbBookMessageTop.Text = lbBookMessage.Text
                Exit Sub
            End If
            ''Insert new data 
            Dim q = "select id from gatepass where id = '" & lbID.Text & "'"
            Dim id = getDBsingle(q, "gpdb")
            If id = lbID.Text Then
                lbBookMessage.Text = "Gate pass ID already exist. Please reAttach and reUpload the photo. A New ID is generated"
                lbPicStatus.Text = "Pic Not Uploaded"
                lbBookMessageTop.Text = lbBookMessage.Text
                lbID.Text = getDBsingle("select max(id)+ 1  from gatepass where not id = ''", "gpdb")
                Exit Sub
            End If
            Dim status = "New_A1"
            If ddlNewVendor.SelectedValue = "BIFPCL" Then status = "New_A2"
            q = "insert into gatepass (id,sn,name,father,sex,age,dob,nationality,nid,mainagency,agency,subagency,desig, cat,compliance,status,mainagency,village,po,ps,district,cell,bgroup,area, validity_start,validity_end,last_updated,lastupdateby,first_apply_by, first_apply_dt, visa, visaexp)" &
                " values('" & lbID.Text & "','1','" & txtNewName.Text.Replace("'", "") & "','" & txtNewFather.Text.Replace("'", "") & "','" & ddlNewSex.SelectedValue & "','" & age & "','" & dob.ToString("yyyy-MM-dd") & "','" & ddlNewNation.SelectedValue & "','" & txtNewNID.Text.Replace("'", "") & "','" & ddlNewVendor.SelectedValue & "','" & ddlNewAgency.SelectedValue & "','" & txtNewSubAgency.Text.Replace("'", "") & "','" & txtNewDesig.Text.Replace("'", "") & "','" & ddlNewCat.SelectedValue & "','" & ddlNewCompliance.SelectedValue & "','" & status & "','" & ddlNewVendor.SelectedValue & "' " &
                ", '" & txtNewVillage.Text.Replace("'", "") & "','" & txtNewPO.Text.Replace("'", "") & "','" & txtNewPS.Text.Replace("'", "") & "','" & txtNewDistrict.Text.Replace("'", "") & "','" & txtNewCell.Text.Replace("'", "") & "','" & ddlBlood.SelectedValue & "','" & ddlNewWorkArea.SelectedValue & "','" & validity_start.ToString("yyyy-MM-dd") & "','" & validity_end.ToString("yyyy-MM-dd") & "',current_timestamp,'" & Session("email") & "','" & Session("email") & "',current_timestamp,'" & txtNewVisa.Text.Replace("'", "") & "','" & visaexp & "' )"
            Dim ret = executeDB(q, "gpdb")
            If Not ret.Contains("error") Then
                msg = msg & "Data inserted. Note Down ID <b>" & lbID.Text & "</b> <a href=gatepass.aspx?mode=new>Click here for next entry</a>"
                lbBookMessage.Text = msg
                txtNewName.Text = ""
                txtNewNID.Text = ""
                lbPicStatus.Text = "Pic Not Uploaded"
                btnSumbitPass.Enabled = False
                btnUpload.Enabled = False
            Else
                lbBookMessage.Text = msg & "Error " & ret & q
            End If
        ElseIf lbNewMode.Text = "Edit" Then
            lbBookMessage.Text = "Update"
            Dim status = lbNewApproverType.Text ' New or Renew or cancellation
            Dim newstatus = ""
            Dim qPart1 = ""
            Dim qPart2 = "" ''for last_renewal_issue_dt
            If lbNewApprover.Text.Contains("EPC") Then
                newstatus = status & "_A2" 'New_A2 or Renew_A2 or Cancellation_A2
                qPart1 = " , approve1_dt = current_timestamp, approve1_by = '" & Session("email") & "' "
            ElseIf lbNewApprover.Text.Contains("BIFPCL") Then
                newstatus = "Approved"
                If status.Contains("Renew") Then qPart2 = ", last_renewal_issue_dt = current_timestamp "
                If status = "New" Then qPart2 = ", first_issue_dt = current_timestamp "
                If status = "Cancel" Then
                    qPart2 = ", cancel_approve_dt = current_timestamp , cancelremark = '" & rblNewCancelRemark.SelectedValue & "' "
                    newstatus = "Cancelled"
                End If
                qPart1 = " , approve2_dt = current_timestamp, approve2_by = '" & Session("email") & "' "
            End If

            Dim q = "update gatepass set name = '" & txtNewName.Text.Replace("'", "") & "',father='" & txtNewFather.Text.Replace("'", "") & "',sex='" & ddlNewSex.SelectedValue & "',age='" & age & "',dob='" & dob.ToString("yyyy-MM-dd") & "',nationality='" & ddlNewNation.SelectedValue & "',nid='" & txtNewNID.Text.Replace("'", "") & "',mainagency='" & ddlNewVendor.SelectedValue & "'," &
                "agency='" & ddlNewAgency.SelectedValue & "',subagency='" & txtNewSubAgency.Text.Replace("'", "") & "',desig='" & txtNewDesig.Text.Replace("'", "") & "', cat ='" & ddlNewCat.SelectedValue & "',status = '" & newstatus & "',mainagency='" & ddlNewVendor.SelectedValue & "',village='" & txtNewVillage.Text.Replace("'", "") & "',po='" & txtNewPO.Text.Replace("'", "") & "',ps='" & txtNewPS.Text.Replace("'", "") & "',district='" & txtNewDistrict.Text.Replace("'", "") & "'," &
                "cell='" & txtNewCell.Text.Replace("'", "") & "',bgroup='" & ddlBlood.SelectedValue & "',area='" & ddlNewWorkArea.SelectedValue & "',compliance = '" & ddlNewCompliance.SelectedValue & "', validity_start='" & validity_start.ToString("yyyy-MM-dd") & "',validity_end='" & validity_end.ToString("yyyy-MM-dd") & "', visa = '" & txtNewVisa.Text.Replace("'", "") & "', visaexp = '" & visaexp & "',last_updated= current_timestamp,lastupdateby = '" & Session("email") & "'" & qPart1 & qPart2 & " where id =" & lbID.Text
            '' update existing data
            Dim ret = executeDB(q, "gpdb")
            If Not ret.Contains("error") Then
                msg = msg & "Approval Done for  " & lbID.Text & " " ' <a href=gatepass.aspx?mode=approve>Click here to approve again</a>"
                '  btnAproveBulk.Enabled = False
                msg = msg & "<a href=gatepass.aspx?mode=approve&click=" & status.ToString.ToLower & ">Click here to go back</a>"
                lbBookMessage.Text = msg
                lbPicStatus.Text = "Pic Not Uploaded"
                btnSumbitPass.Enabled = False
                btnUpload.Enabled = False
            Else
                lbBookMessage.Text = msg & "Error " & ret '& q
            End If
            '  If Request.Params("request").Contains("Renewal") Then
        ElseIf lbNewMode.Text = "Renewal" Then

            Dim newRemark = "Validity from " & txtNewValidityStart.Text & " to " & txtNewValidityEnd.Text
            If newRemark = lbRemark.Text Then
                lbBookMessage.Text = "You have not changed validity dates..."
                lbBookMessageTop.Text = lbBookMessage.Text
                Exit Sub
            End If

            Dim qPart1 = " , last_renewal_apply_dt = current_timestamp, last_renewal_apply_by = '" & Session("email") & "' "
            Dim status = "Renew_A1"
            If ddlNewVendor.SelectedValue = "BIFPCL" Then status = "Renew_A2"

            Dim q = "update gatepass set name = '" & txtNewName.Text.Replace("'", "") & "',father='" & txtNewFather.Text.Replace("'", "") & "',sex='" & ddlNewSex.SelectedValue & "',age='" & age & "',dob='" & dob.ToString("yyyy-MM-dd") & "',nationality='" & ddlNewNation.SelectedValue & "',nid='" & txtNewNID.Text.Replace("'", "") & "',mainagency='" & ddlNewVendor.SelectedValue & "'," &
                "agency='" & ddlNewAgency.SelectedValue & "',subagency='" & txtNewSubAgency.Text.Replace("'", "") & "',desig='" & txtNewDesig.Text.Replace("'", "") & "', cat ='" & ddlNewCat.SelectedValue & "',status = '" & status & "',mainagency='" & ddlNewVendor.SelectedValue & "',village='" & txtNewVillage.Text.Replace("'", "") & "',po='" & txtNewPO.Text.Replace("'", "") & "',ps='" & txtNewPS.Text.Replace("'", "") & "',district='" & txtNewDistrict.Text.Replace("'", "") & "'," &
                "cell='" & txtNewCell.Text.Replace("'", "") & "',bgroup='" & ddlBlood.SelectedValue & "',area='" & ddlNewWorkArea.SelectedValue & "',compliance = '" & ddlNewCompliance.SelectedValue & "', validity_start='" & validity_start.ToString("yyyy-MM-dd") & "',validity_end='" & validity_end.ToString("yyyy-MM-dd") & "', visa = '" & txtNewVisa.Text.Replace("'", "") & "', visaexp = '" & visaexp & "',last_updated= current_timestamp,lastupdateby = '" & Session("email") & "'" & qPart1 & ", remark =  '> " & lbRemark.Text & "' || ifnull(remark,'') where id =" & lbID.Text
            '' update existing data
            Dim ret = executeDB(q, "gpdb")
            If Not ret.Contains("error") Then
                msg = msg & "Renewal Request Submitted  for  " & lbID.Text & " " ' <a href=gatepass.aspx?mode=approve>Click here to approve again</a>"
                '  btnAproveBulk.Enabled = False
                msg = msg & "<a href=gatepass.aspx?mode=renew&agency=" & Server.UrlEncode(ddlNewAgency.SelectedValue) & ">Click here to go back</a>"
                lbBookMessage.Text = msg
                lbPicStatus.Text = "Pic Not Uploaded"
                btnSumbitPass.Enabled = False
                btnUpload.Enabled = False
            Else
                lbBookMessage.Text = msg & "Error " & ret '& q
            End If

        ElseIf lbNewMode.Text = "Cancellation" Then
            Dim status = "Cancel_A1"
            If ddlNewVendor.SelectedValue = "BIFPCL" Then status = "Cancel_A2"
            Dim q = "update gatepass set cancel_apply_dt = current_timestamp, cancelremark = '" & rblNewCancelRemark.SelectedValue & "', status ='" & status & "', last_updated= current_timestamp,lastupdateby = '" & Session("email") & "' , remark =  '> " & lbRemark.Text & "' || ifnull(remark,'') where id =" & lbID.Text
            '' update existing data
            Dim ret = executeDB(q, "gpdb")
            If Not ret.Contains("error") Then
                msg = msg & "Cancellation Request Submitted  for  " & lbID.Text & " " ' <a href=gatepass.aspx?mode=approve>Click here to approve again</a>"
                '  btnAproveBulk.Enabled = False
                msg = msg & "<a href=gatepass.aspx?mode=cancel&agency=" & Server.UrlEncode(ddlNewAgency.SelectedValue) & ">Click here to go back</a>"
                lbBookMessage.Text = msg
                lbPicStatus.Text = "Pic Not Uploaded"
                btnSumbitPass.Enabled = False
                btnUpload.Enabled = False
            Else
                lbBookMessage.Text = msg & "Error " & ret '& q
            End If
        ElseIf lbNewMode.Text = "Modify" Then

            Dim newRemark = "> Gate Pass data changed on " & Now.ToString & " Status " & ddlNewChangeStatus.SelectedItem.Text & " by " & Session("email")
            If ddlNewChangeStatus.SelectedValue = "NA" Then
                lbBookMessage.Text = "Pass status not changed"
                Exit Sub
            End If
            Dim qPart2 = ""
            If ddlNewChangeStatus.SelectedValue = "Deleted" Then
                qPart2 = " , expelled_dt = '" & Now.ToString("yyyy-MM-dd") & "' "
            End If

            Dim q = "update gatepass set name = '" & txtNewName.Text.Replace("'", "") & "',father='" & txtNewFather.Text.Replace("'", "") & "',sex='" & ddlNewSex.SelectedValue & "',age='" & age & "',dob='" & dob.ToString("yyyy-MM-dd") & "',nationality='" & ddlNewNation.SelectedValue & "',nid='" & txtNewNID.Text.Replace("'", "") & "',mainagency='" & ddlNewVendor.SelectedValue & "'," &
                "agency='" & ddlNewAgency.SelectedValue & "',subagency='" & txtNewSubAgency.Text.Replace("'", "") & "',desig='" & txtNewDesig.Text.Replace("'", "") & "', cat ='" & ddlNewCat.SelectedValue & "',mainagency='" & ddlNewVendor.SelectedValue & "',village='" & txtNewVillage.Text.Replace("'", "") & "',po='" & txtNewPO.Text.Replace("'", "") & "',ps='" & txtNewPS.Text.Replace("'", "") & "',district='" & txtNewDistrict.Text.Replace("'", "") & "'," &
                " cancelremark = '" & rblNewCancelRemark.SelectedValue & "', cell='" & txtNewCell.Text.Replace("'", "") & "',bgroup='" & ddlBlood.SelectedValue & "',area='" & ddlNewWorkArea.SelectedValue & "',compliance = '" & ddlNewCompliance.SelectedValue & "', last_updated= current_timestamp, visa = '" & txtNewVisa.Text.Replace("'", "") & "', visaexp = '" & visaexp & "',lastupdateby = '" & Session("email") & "', remark =  '> " & newRemark & "' || ifnull(remark,''), status = '" & ddlNewChangeStatus.SelectedValue & "' " & qPart2 & " where id =" & lbID.Text
            '' update existing data
            Dim ret = executeDB(q, "gpdb")
            If Not ret.Contains("error") Then
                msg = msg & "Modification done  for  " & lbID.Text & " " ' <a href=gatepass.aspx?mode=approve>Click here to approve again</a>"
                '  btnAproveBulk.Enabled = False
                msg = msg & "<a href=gatepass.aspx?mode=modify&agency=" & Server.UrlEncode(ddlNewAgency.SelectedValue) & ">Click here to go back</a>"
                lbBookMessage.Text = msg
                lbPicStatus.Text = "Pic Not Uploaded"
                btnSumbitPass.Enabled = False
                btnUpload.Enabled = False
            Else
                lbBookMessage.Text = msg & "Error " & ret '& q
            End If

        End If
        lbBookMessageTop.Text = lbBookMessage.Text
    End Sub

    Private Sub btnAproveBulk_Click(sender As Object, e As EventArgs) Handles btnAproveBulk.Click
        Dim msg = ""
        If Session("email") Is Nothing Then Response.Redirect("Default.aspx")
        Dim uids = ""
        Dim i = 0
        For Each item As GridViewRow In gvPassApprove.Rows
            Dim cb = TryCast(item.Cells(0).FindControl("cbSMSSelect"), CheckBox)
            If cb.Checked Then
                uids = uids & " " & cb.Text & ", " 'item.Cells(1).Text
                i = i + 1
            End If
        Next
        If i = 0 Then
            lbApprovePass.Text = "Select something to approve"
            Exit Sub
        End If
        msg = i & " records to be approved. "
        uids = uids & " 0"
        Dim status = rblApproveType.SelectedValue ' New or Renew
        '''#####
        '''



        Dim newstatus = ""
        Dim qPart1 = ""
        Dim qPart2 = "" ''for last_renewal_issue_dt
        If lbApprover.Text.Contains("EPC") Then
            newstatus = status & "_A2" 'New_A2 or Renew_A2 or Cancel_A2
            qPart1 = " , approve1_dt = current_timestamp, approve1_by = '" & Session("email") & "' "
        ElseIf lbApprover.Text.Contains("BIFPCL") Then
            newstatus = "Approved"
            If status.Contains("Renew") Then qPart2 = ", last_renewal_issue_dt = current_timestamp "
            If status = "New" Then qPart2 = ", first_issue_dt = current_timestamp "
            If status = "Cancel" Then
                qPart2 = ", cancel_approve_dt = current_timestamp "
                newstatus = "Cancelled"
            End If
            qPart1 = " , approve2_dt = current_timestamp, approve2_by = '" & Session("email") & "' "
        End If


        Dim q = "update gatepass set status = '" & newstatus & "' " & qPart1 & qPart2 & " ,   last_updated = current_timestamp, lastupdateby = '" & Session("email") & "'  where  id in ( " & uids & " )"
        Dim ret = executeDB(q, "gpdb")
        If Not ret.Contains("error") Then
            msg = msg & "Approval Done for  " & i & " no of Passes. " & newstatus & " for " & uids ' <a href=gatepass.aspx?mode=approve>Click here to approve again</a>"
            '  btnAproveBulk.Enabled = False
            loadApproveGrid()
        Else
            lbApprovePass.Text = msg & "Error " & ret '& q
        End If
        lbApprovePass.Text = msg '& q
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim msg = ""
        If Session("email") Is Nothing Then Response.Redirect("Default.aspx")
        Dim uids = ""
        Dim i = 0
        For Each item As GridViewRow In gvPassApprove.Rows
            Dim cb = TryCast(item.Cells(0).FindControl("cbSMSSelect"), CheckBox)
            If cb.Checked Then
                uids = uids & cb.Text  'item.Cells(1).Text
                i = i + 1
            End If
        Next
        If i = 0 Then
            lbApprovePass.Text = "Select something to approve"
            Exit Sub
        End If
        If i > 1 Then
            lbApprovePass.Text = "Select single item to approve"
            Exit Sub
        End If
        lbApprovePass.Text = uids & " can be approved now ."
        Response.Redirect("gatepass.aspx?mode=new&id=" & uids & "&approvetype=" & rblApproveType.SelectedValue)
    End Sub

    Private Sub ddlPrintAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPrintAgency.SelectedIndexChanged
        loadPrintGrid()
    End Sub

    Private Sub btnSelectID_Click(sender As Object, e As EventArgs) Handles btnSelectID.Click
        If String.IsNullOrEmpty(txtPrintStart.Text) Or String.IsNullOrEmpty(txtPrintEnd.Text) Then
            lbPrintMessage.Text = "Please enter start and end Gate Pass ID to select in one go"
            Exit Sub
        End If
        Dim idstart = Convert.ToInt32(txtPrintStart.Text)
        Dim idend = Convert.ToInt32(txtPrintEnd.Text)
        Dim sel = 0
        For Each item As GridViewRow In gvPrint.Rows
            Dim cb = TryCast(item.Cells(0).FindControl("cbSMSSelect"), CheckBox)
            sel = Convert.ToInt32(cb.Text)
            If (sel >= idstart And sel <= idend) Or (sel <= idstart And sel >= idend) Then
                cb.Checked = True
            Else
                cb.Checked = False
            End If
        Next
        lbPrintMessage.Text = idstart & " to " & idend & " selected " & sel
    End Sub
    Private Sub btnPrintCoverLetter_Click(sender As Object, e As EventArgs) Handles btnPrintCoverLetter.Click
        If Session("email") Is Nothing Then Response.Redirect("Default.aspx")
        Dim i = 0
        Dim printID As New List(Of String)
        For Each item As GridViewRow In gvCover.Rows
            Dim cb = TryCast(item.Cells(0).FindControl("cbSMSSelect"), CheckBox)
            If cb.Checked Then
                printID.Add(cb.Text)  'item.Cells(1).Text
                i = i + 1
            End If
        Next
        If i = 0 Then
            lbMessageCover.Text = "Select something to print"
            Exit Sub
        End If
        lbMessageCover.Text = printID.Count & " can be printed now ."
        Session("printCoverID") = printID
        Response.Redirect("gatepassPrint.aspx?mode=cover&type=" & lbCoverType.Text & "&agency=" & HttpUtility.UrlEncode(ddlCoverAgency.SelectedValue) & "&passtype=" & rblCoverStatus.SelectedValue)
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If Session("email") Is Nothing Then Response.Redirect("Default.aspx")
        Dim i = 0
        Dim printID As New List(Of String)
        For Each item As GridViewRow In gvPrint.Rows
            Dim cb = TryCast(item.Cells(0).FindControl("cbSMSSelect"), CheckBox)
            If cb.Checked Then
                printID.Add(cb.Text)  'item.Cells(1).Text
                i = i + 1
            End If
        Next
        If i = 0 Then
            lbPrintMessage.Text = "Select something to print"
            Exit Sub
        End If
        lbPrintMessage.Text = printID.Count & " can be printed now ."
        Session("printID") = printID
        Response.Redirect("gatepassPrint.aspx")
    End Sub

    Private Sub rblReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblReportType.SelectedIndexChanged
        If rblReportType.SelectedValue = "ID" Or rblReportType.SelectedValue = "Red" Or rblReportType.SelectedValue = "due" Then
            If rblReportType.SelectedValue = "ID" Or rblReportType.SelectedValue = "due" Then rblReportStatus.Visible = True
            rblReportDTCol.Visible = True
        Else
            rblReportStatus.Visible = False
            rblReportDTCol.Visible = False
        End If
        loadDPR()
    End Sub

    Private Sub rblReportStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblReportStatus.SelectedIndexChanged
        loadDPR()
    End Sub

    Private Sub ddlReportAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlReportAgency.SelectedIndexChanged
        loadDPR()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        loadDPR()
    End Sub

    Private Sub gvRenewal_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvRenewal.RowCommand
        Dim value = e.CommandArgument.ToString()
        lbRenewMessage.Text = value
        Response.Redirect("gatepass.aspx?id=" & value & "&mode=Renewal")
    End Sub

    Private Sub ddlRenewAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRenewAgency.SelectedIndexChanged
        loadRenewalGrid()
    End Sub

    Private Sub ddlCancelAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCancelAgency.SelectedIndexChanged
        loadCancelGrid()
    End Sub
    Private Sub gvModify_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvModify.RowCommand
        Dim value = e.CommandArgument.ToString()
        lbCancelMessage.Text = value
        Response.Redirect("gatepass.aspx?id=" & value & "&mode=Change")
    End Sub
    Private Sub gvCancel_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCancel.RowCommand
        Dim value = e.CommandArgument.ToString()
        lbCancelMessage.Text = value
        Response.Redirect("gatepass.aspx?id=" & value & "&mode=Cancellation")
    End Sub
    Private Sub lbDownloadSummary_Click(sender As Object, e As EventArgs) Handles lbDownloadSummary.Click
        saveExcel()
        ' Export()
    End Sub
    Sub saveExcel()
        ' Change the Header Row back to white color
        gvReportPic.HeaderRow.Style.Add("background-color", "#FFFFFF")

        ' This loop is used to apply stlye to cells based on particular row
        'For Each gvrow As GridViewRow In gvReport.Rows
        '    gvrow.BackColor = Drawing.Color.White

        '    If gvrow.Cells(4).Text = "True" Then
        '        gvrow.BackColor = Drawing.Color.Yellow
        '        'For k As Integer = 0 To gvrow.Cells.Count - 1
        '        '    gvrow.Cells(k).Style.Add("background-color", "#EFF3FB")
        '        'Next
        '    End If
        'Next

        Response.ClearContent()

        Response.AddHeader("content-disposition", "attachment; filename=newpass" & Left(ddlReportAgency.SelectedValue, 7) & Now.ToString("ddMy") & ".xls")

        Response.ContentType = "application/excel"

        Dim sWriter As New System.IO.StringWriter()

        Dim hTextWriter As New HtmlTextWriter(sWriter)

        gvReportPic.RenderControl(hTextWriter)

        Response.Write(sWriter.ToString())

        Response.End()
        'lblMsg.Text = "Excel created"

        'GridView1.RenderControl(htw)

    End Sub
    Sub Export()
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=GridViewImage.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As StringWriter = New StringWriter()
        Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
        For i As Integer = 0 To gvReportPic.Rows.Count - 1
            Dim row As GridViewRow = gvReportPic.Rows(i)
            row.Attributes.Add("class", "textmode")
        Next
        gvReportPic.RenderControl(hw)
        Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub
    Sub saveExcelApprove()
        ' Change the Header Row back to white color

        Response.ClearContent()

        Response.AddHeader("content-disposition", "attachment; filename=approve" & Now.ToString("ddMy") & ".xls")

        Response.ContentType = "application/excel"

        Dim sWriter As New System.IO.StringWriter()

        Dim hTextWriter As New HtmlTextWriter(sWriter)

        gvPassApprove.RenderControl(hTextWriter)

        Response.Write(sWriter.ToString())

        Response.End()
        'lblMsg.Text = "Excel created"

        'GridView1.RenderControl(htw)

    End Sub



    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Return
    End Sub

    Private Sub ddlNewAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlNewAgency.SelectedIndexChanged
        loadInsurance() '' Show insurance info at bottom
    End Sub

    Private Sub btnAddInsurance_Click(sender As Object, e As EventArgs) Handles btnAddInsurance.Click
        If Session("email") Is Nothing Then Response.Redirect("Default.aspx")
        If String.IsNullOrEmpty(txtInsurancePolicy.Text) Or String.IsNullOrEmpty(txtInsurancePersons.Text) Or String.IsNullOrEmpty(txtInsuranceValidityEnd.Text) Or String.IsNullOrEmpty(txtInsuranceValidityStart.Text) Then Exit Sub
        Dim validityStart = DateTime.ParseExact(txtInsuranceValidityStart.Text, "dd.M.yyyy", Nothing)
        Dim validityEnd = DateTime.ParseExact(txtInsuranceValidityEnd.Text, "dd.M.yyyy", Nothing)

        Dim q = "insert into insurance (agency,policyno,persons,validity_start,validity_end,status) " &
            "values ('" & ddlInsuranceAgency.SelectedValue & "','" & txtInsurancePolicy.Text.Replace("'", "") & "','" & txtInsurancePersons.Text & "','" & validityStart.ToString("yyyy-MM-dd") & "','" & validityEnd.ToString("yyyy-MM-dd") & "','0')"
        If executeDB(q, "gpdb") = "ok" Then
            lbInsuranceMessage.Text = "Policy added succesfully"
            txtInsurancePolicy.Text = ""
        Else
            lbInsuranceMessage.Text = "Error Policy not added"
        End If
    End Sub

    Private Sub btnAddAuth_Click(sender As Object, e As EventArgs) Handles btnAddAuth.Click
        If Session("email") Is Nothing Then Response.Redirect("Default.aspx")
        If String.IsNullOrEmpty(txtAdminMail.Text) Then Exit Sub
        Dim agency = ddlAdminAgency.SelectedValue
        If ddlAdminAgency.SelectedValue = "NA" Then
            agency = txtAdminAgency.Text
        End If
        Dim q = "insert into agency (agency,email,level) " &
           "values ('" & agency & "','" & txtAdminMail.Text.Replace("'", "") & "','new')"
        If executeDB(q, "gpdb") = "ok" Then
            lbAdmin.Text = "Authorisation added succesfully"
            txtAdminMail.Text = ""
        Else
            lbInsuranceMessage.Text = "Error auth not added"
        End If
    End Sub

    Private Sub ddlAdminAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAdminAgency.SelectedIndexChanged
        If ddlAdminAgency.SelectedValue = "NA" Then
            txtAdminAgency.Visible = True
        Else
            txtAdminAgency.Visible = False
        End If
    End Sub

    Private Sub btnSearchID_Click(sender As Object, e As EventArgs) Handles btnSearchID.Click
        If String.IsNullOrEmpty(txtSearchID.Text) Then
            lbModifyMessage.Text = "Enter ID"
            Exit Sub
        End If
        Dim q = "select id from gatepass where id = '" & txtSearchID.Text & "' limit 1"
        Dim id = getDBsingle(q, "gpdb")
        If id = txtSearchID.Text Then
            Response.Redirect("gatepass.aspx?id=" & txtSearchID.Text & "&mode=Change")
        Else
            lbModifyMessage.Text = "Gate Pass ID not exist. "
        End If



        'q = "insert into gatepass (id,name, father, sex, age,nationality,mainagency,agency, validity_start,validity_end,status)" &
        '    " values ('" & txtSearchID.Text.Replace("'", "") & "','NA','NA','MALE','35','BANGLADESHI','BHEL','DIPON GULF','2000-01-01','2002-01-01','Cancelled')"

        'Dim ret = executeDB(q, "gpdb")
        'If ret = "ok" Then
        '    lbModifyMessage.Text = "Gate Pass ID Created "
        '    ' txtSearchID.Text = ""
        'Else
        '    lbModifyMessage.Text = "Gate Pass ID not Created " & q
        'End If

    End Sub

    Private Sub btnCreateID_Click(sender As Object, e As EventArgs) Handles btnCreateID.Click
        If String.IsNullOrEmpty(txtCreateID.Text) Then
            lbCreateID.Text = "Enter ID"
            Exit Sub
        End If
        Dim q = "select id from gatepass where id = '" & txtCreateID.Text & "'"
        Dim id = getDBsingle(q, "gpdb")
        If id = txtCreateID.Text Then
            lbCreateID.Text = "Gate pass ID exist "
            Exit Sub
        End If

        q = "insert into gatepass (id,name, father, sex, age,nationality,mainagency,agency, validity_start,validity_end,status)" &
            " values ('" & txtCreateID.Text.Replace("'", "") & "','NA','NA','MALE','35','BANGLADESHI','BHEL','DIPON GULF','2000-01-01','2002-01-01','Cancelled')"

        Dim ret = executeDB(q, "gpdb")
        If ret = "ok" Then
            lbCreateID.Text = "Gate PAss ID Created "
            txtCreateID.Text = ""
        Else
            lbCreateID.Text = "Gate PAss ID not Created " & q
        End If
    End Sub
    Private Sub btnSMSSelectAll_Click(sender As Object, e As EventArgs) Handles btnSMSSelectAll.Click
        If btnSMSSelectAll.Text = "Select All" Then
            For Each item As GridViewRow In gvPassApprove.Rows
                Dim cb = TryCast(item.Cells(0).FindControl("cbSMSSelect"), CheckBox)
                cb.Checked = True
            Next
            btnSMSSelectAll.Text = "UnSelect All"
        Else
            For Each item As GridViewRow In gvPassApprove.Rows
                Dim cb = TryCast(item.Cells(0).FindControl("cbSMSSelect"), CheckBox)
                cb.Checked = False
            Next
            btnSMSSelectAll.Text = "Select All"
        End If
    End Sub

    Private Sub rblCoverStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblCoverStatus.SelectedIndexChanged
        loadCoverGrid()
    End Sub

    Private Sub btnCoverSelectAll_Click(sender As Object, e As EventArgs) Handles btnCoverSelectAll.Click
        If btnCoverSelectAll.Text = "Select All" Then
            For Each item As GridViewRow In gvCover.Rows
                Dim cb = TryCast(item.Cells(0).FindControl("cbSMSSelect"), CheckBox)
                cb.Checked = True
            Next
            btnCoverSelectAll.Text = "UnSelect All"
        Else
            For Each item As GridViewRow In gvCover.Rows
                Dim cb = TryCast(item.Cells(0).FindControl("cbSMSSelect"), CheckBox)
                cb.Checked = False
            Next
            btnCoverSelectAll.Text = "Select All"
        End If
    End Sub

    Private Sub ddlCoverAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCoverAgency.SelectedIndexChanged
        loadCoverGrid()
    End Sub

    Private Sub ddlMoifyAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMoifyAgency.SelectedIndexChanged
        loadModifyGrid()
    End Sub

    Private Sub lbDownloadApprove_Click(sender As Object, e As EventArgs) Handles lbDownloadApprove.Click
        saveExcelApprove()
    End Sub

    Private Sub ddlPrintCompliance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPrintCompliance.SelectedIndexChanged
        loadPrintGrid()
    End Sub

    Private Sub ddlApproverAgency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlApproverAgency.SelectedIndexChanged
        loadApproveGrid()
    End Sub

    Private Sub btnIntegrity_Click(sender As Object, e As EventArgs) Handles btnIntegrity.Click
        Dim msg = ""
        Dim ret = getDBsingle("PRAGMA INTEGRITY_CHECK", "gpdb")
        msg = msg & "<br/>Gate Pass DB " & ret
        lbCreateID.Text = msg
    End Sub

    Private Sub btnDownloadDB_Click(sender As Object, e As EventArgs) Handles btnDownloadDB.Click
        Dim zipName As String
        Dim path = Server.MapPath("~/App_Data/")
        Using zip As New ZipFile()
            zip.AlternateEncodingUsage = ZipOption.AsNecessary
            zip.Password = "bifpcl&123"
            ' zip.AddDirectoryByName("Files")
            Dim filesToZip As New System.Collections.Generic.List(Of String)()

            filesToZip.Add(path & "gp.db")

            For Each filepath As String In filesToZip
                zip.AddFile(filepath, "Files")

            Next
            Response.Clear()
            Response.BufferOutput = False
            zipName = [String].Format("Backup_{0}.zip", "ogps" & DateTime.Now.ToString("ddMMMyyyy")) 'DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")
            Response.ContentType = "application/zip"
            Response.AddHeader("content-disposition", "attachment; filename=" + zipName)
            zip.Save(Response.OutputStream)
            ' zip.Save(path & zipName)
            Response.[End]()
            lbCreateID.Text = "Zip File created " & zipName


        End Using

        '   Response.Redirect(path & zipName)
    End Sub

    Private Sub btnDownloadPIC_Click(sender As Object, e As EventArgs) Handles btnDownloadPIC.Click
        'Dim zipName As String
        ''  Dim path = Server.MapPath("/upload/gatepass/")
        'Using zip As New ZipFile()
        '    zip.AlternateEncodingUsage = ZipOption.AsNecessary
        '    'zip.Password = "bifpcl&123"
        '    zip.AddDirectoryByName("Files")
        '    Dim files As New List(Of ListItem)()

        '    Dim filePaths As String() = Directory.GetFiles(Server.MapPath("/upload/gatepass/"))
        '    For Each file As String In filePaths
        '        files.Add(New ListItem(Path.GetFileName(file), file))
        '    Next


        '    For Each f In files
        '        zip.AddFile(f.Text, "Files")

        '    Next

        '    Response.Clear()
        '    Response.BufferOutput = False
        '    zipName = [String].Format("BackupPIC_{0}.zip", "ogps" & DateTime.Now.ToString("ddMMMyyyy")) 'DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")
        '    Response.ContentType = "application/zip"
        '    Response.AddHeader("content-disposition", "attachment; filename=" + zipName)
        '    zip.Save(Response.OutputStream)
        '    ' zip.Save(path & zipName)
        '    Response.[End]()
        '    lbCreateID.Text = "Zip File created " & zipName


        'End Using
    End Sub


End Class
