Imports Common
Imports dbOp
Imports System.IO
Imports System.Drawing           'CoreCompat Image handling

Imports System.Drawing.Drawing2D   'CoreCompat Image handling

Imports System.Drawing.Imaging       'CoreCompat Image handling
Imports System.Data

Partial Class erp
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
        ''    update careers_application Set marks = (Select t2.marks FROM merit t2 WHERE t2.rollno1 = rollno) 
        'WHERE
        'EXISTS( SELECT * FROM merit t2 WHERE t2.rollno1 = rollno)
        Try
            If Not Page.IsPostBack Then
                divMobiSidmenu.InnerHtml = makemenu(True, 2)
                divSideMenu.InnerHtml = makemenu(False, 2, True)
                divNotification.InnerHtml = getNotification(1)
                divNotificationMobile.InnerHtml = getNotification(1, True)
                If Request.Form.Count = 1 Then
                    Dim appsecret = "j2Pmxpcap0qC1rol1gm69s4RdE0IAEaEkY7hHv3zQMs="
                    Session("email") = Decrypt(Request.Form("email"), appsecret)
                    '  divBug.InnerHtml = Session("email")
                End If
                'If Not Request.QueryString("mode") Is Nothing Then
                '    If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343326&modenothing")
                'End If
                divLogin.InnerHtml = "<div class='account-item account-item--style2 clearfix js-item-menu' onclick=alert('Login_not_required_To_Apply_Read_Instructions_First');> <div class='image'> <span ><img src='upload/employee/pics/user.png'> </span>               </div>              <div class='content'>                  <a class='account-dropdown__footer'><span>Login</span></a>                </div> </div>" 'showAccount(Session("email"), True)
                divLoginMobile.InnerHtml = "<div class='account-item account-item--style2 clearfix js-item-menu' onclick=alert('Login_not_required_To_Apply_Read_Instructions_First');>  <div class='image'> <span><img src='upload/employee/pics/user.png'> </span>               </div>              <div class='content'>                  <a class='account-dropdown__footer'><span>Login</span></a>                </div> </div>" 'showAccount(Session("email"), True)
                If Request.Params("mode") = "postjob" Then
                    If Not (checkAuthorization(Session("email"), "onlybifpcl") And checkAuthorization(Session("email"), "hrCareer.aspx?mode=admin")) Then  ''Pass url or onlybifpcl for all bifplc executives
                        lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives with approver rights.<a href=sso/Default.aspx?appid=12343326>Click here to login</a>"
                        Exit Sub
                    End If
                    pnlPostJob.Visible = True
                    SqlDataSource2.SelectParameters("phase").DefaultValue = ddlPostPhase.SelectedValue.ToString
                ElseIf Request.Params("mode") = "admin" Then
                    If Not (checkAuthorization(Session("email"), "onlybifpcl") And checkAuthorization(Session("email"), "hrCareer.aspx?mode=admin")) Then  ''Pass url or onlybifpcl for all bifplc executives
                        lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives with approver rights.<a href=sso/Default.aspx?appid=12343326>Click here to login</a>"
                        Exit Sub
                    End If
                    pnlAdmin.Visible = True
                    ddlAdminPhase.DataSource = getDBTable("select distinct phase from careers_jobs where 1", "appsdb")
                    ddlAdminPhase.DataBind()
                    ddlAdminJob.DataSource = getDBTable("select jobid, post from careers_jobs where phase = '" & ddlAdminPhase.SelectedValue & "' and del = 0", "appsdb")
                    ddlAdminJob.DataBind()
                    loadApprove()
                    '' load settings
                    Dim q = "select venue_w, date_w, venue_i, date_i, a from careers_var where 1  limit 1"
                    Dim mydt = getDBTable(q, "appsdb")
                    If mydt.Rows.Count = 0 Then
                        Exit Sub
                    End If
                    txtVarvenue_w.Text = mydt.Rows(0)("venue_w").ToString
                    txtVarvenue_i.Text = mydt.Rows(0)("venue_i").ToString
                    txtDate_w.Text = mydt.Rows(0)("date_w").ToString
                    txtDate_i.Text = mydt.Rows(0)("date_i").ToString
                    txtvar_a.Text = mydt.Rows(0)("a").ToString
                ElseIf Request.Params("mode") = "apply" Then
                    Exit Sub
                    pnlNewPass.Visible = True
                    divNew.InnerHtml = " <h3>Job Application</h3>        "
                    Dim maxuid = Math.Round(Rnd() * 10) 'getDBsingle("select max(aid) + 1 from careers_application where 1  limit 1", "appsdb")
                    lbID.Text = Now.ToString("dMMyHHmmss") & maxuid.ToString
                    lbJobID.Text = Request.Params("id")
                    lbNewApprover.Text = getDBsingle("select post from careers_jobs where jobid = " & lbJobID.Text & " limit 1", "appsdb")
                    If lbNewApprover.Text.Contains("Error") Then
                        lbNewApprover.Text = "No such job exist"
                        btnSumbitPass.Enabled = False
                    End If
                    ddlNewNation.DataSource = getDBTable("select nationality   from nationality", "gpdb")
                    ddlNewNation.DataBind()
                    btnSumbitPass.Text = "Attach & Submit Application"
                    lbNewMode.Text = "New"  ''It will be New or Edit
                    ''' Now chck aditional parameter for single approve
                    ''' 
                    For yr = 2019 To 1990 Step -1
                        ddlyear1.Items.Add(New ListItem(yr, yr))
                        ddlyear2.Items.Add(New ListItem(yr, yr))
                        ddlyear3.Items.Add(New ListItem(yr, yr))
                        ddlyear4.Items.Add(New ListItem(yr, yr))
                        ddlyear5.Items.Add(New ListItem(yr, yr))
                    Next
                    For yr = 20 To 0 Step -1
                        ddlExpYr.Items.Add(New ListItem(yr, yr))
                        If yr < 12 Then ddlExpMonth.Items.Add(New ListItem(yr, yr))
                    Next
                    ddlExpYr.SelectedValue = 0
                    ddlExpMonth.SelectedValue = 0
                    lbNewPhase.Text = getDBsingle("select phase from careers_jobs where 1 order by jobid desc limit 1 ", "appsdb")
                ElseIf Request.Params("mode") = "confirm" Then
                    pnlConfirm.Visible = True
                    lbConfirmJobID.Text = Request.Params("id")
                    ' Dim filename = getDBsingle("select file from careers_jobs where jobid = " & lbConfirmJobID.Text, "appsdb")
                    '   cbConfirm.Items.Add(New ListItem("I have made demand draft as mentioned in <a href='hrcareer.aspx' > Job Detail </a> given in instruction page", "6"))
                    '  lbMybooking.Text = q
                    loadJobDetail(Request.Params("id"))
                ElseIf Request.Params("mode") = "print" Then
                    pnlPrintApp.Visible = True
                    'lbConfirmJobID.Text = Request.Params("id")
                    'Dim filename = getDBsingle("select file from careers_jobs where jobid = " & lbConfirmJobID.Text, "appsdb")
                    'cbConfirm.Items.Add(New ListItem("I have made demand draft as mentioned in <a href='upload/HR/Career/" & filename & "' target='_blank' > Job Detail </a>", "6"))
                    ' Dim aIDEnc = Encrypt(Request.Params("aid"))
                    Dim applicationID = Request.Params("aid") ' Session("aid") Decrypt(HttpUtility.UrlDecode(Request.Params("aid")))
                    loadProfile(applicationID, "new")
                ElseIf Request.Params("mode") = "printadmin" Then
                    If Not (checkAuthorization(Session("email"), "onlybifpcl") And checkAuthorization(Session("email"), "hrCareer.aspx?mode=admin")) Then  ''Pass url or onlybifpcl for all bifplc executives
                        lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for HR Executives.<a href=Default.aspx>Click here to login</a>"
                        Exit Sub
                    End If
                    pnlPrintApp.Visible = True
                    Dim applicationID = Request.Params("aid") ' Session("aid") Decrypt(HttpUtility.UrlDecode(Request.Params("aid")))
                    loadProfile(applicationID, "Submit")
                    btnDownloadPDFAdmin.Visible = True
                    btnSubmitPrint.Visible = False
                    btnModifyPrint.Visible = False
                ElseIf Request.Params("mode") = "printadmit" Then
                    executeDB("insert into login (eid, log, logintime) values (0, 'HR Career Report Admit Card Print : at " & Now.ToString() & " - from - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

                    pnlAdmitCard.Visible = True
                ElseIf Request.Params("mode") = "printadmitInt" Then
                    executeDB("insert into login (eid, log, logintime) values (0, 'HR Career Report Admit Card Print Interview : at " & Now.ToString() & " - from - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

                    pnlAdmitCard.Visible = True
                    lbAdmitStage.Text = "interview"
                ElseIf Request.Params("mode") = "modify" Then

                    'lbConfirmJobID.Text = Request.Params("id")
                    'Dim filename = getDBsingle("select file from careers_jobs where jobid = " & lbConfirmJobID.Text, "appsdb")
                    'cbConfirm.Items.Add(New ListItem("I have made demand draft as mentioned in <a href='upload/HR/Career/" & filename & "' target='_blank' > Job Detail </a>", "6"))
                    ' Dim aIDEnc = Encrypt(Request.Params("aid"))
                    Dim applicationID = Session("jobAppID")  ' Session("aid") Decrypt(HttpUtility.UrlDecode(Request.Params("aid")))
                    Dim maxuid = getDBsingle("select max(aid) + 1 from careers_application where 1  limit 1", "appsdb")
                    lbID.Text = applicationID ' Now.ToString("dMMyHHmmss") & maxuid
                    reloadGPData(applicationID)
                    lbNewMode.Text = "Modify"
                    lbNewPhase.Text = getDBsingle("select phase from careers_jobs where 1 order by jobid desc limit 1 ", "appsdb")
                ElseIf Request.Params("mode") = "done" Then
                    pnlSuccess.Visible = True
                    loadSuccess()
                ElseIf Request.Params("mode") = "report" Then
                    If Not (checkAuthorization(Session("email"), "onlybifpcl") And checkAuthorization(Session("email"), "hrCareer.aspx?mode=admin")) Then  ''Pass url or onlybifpcl for all bifplc executives
                        lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for HR Executives.<a href=sso/Default.aspx?appid=12343326>Click here to login</a>"
                        Exit Sub
                    End If
                    executeDB("insert into login (eid, log, logintime) values (0, 'HR Career Report Page Access : at " & Now.ToString() & " - " & Session("email").ToString & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

                    pnlReport.Visible = True
                    ddlReportPhase.DataSource = getDBTable("select distinct phase from careers_jobs where 1 order by jobid desc", "appsdb")
                    ddlReportPhase.DataBind()
                    loadDPR()
                    '  lbAllBooking.Text = q
                ElseIf Request.Params("mode") = "opening" Then
                    'ddlUidNew.Items.Insert(1, "Common Place")
                    '  Exit Sub
                    pnlOpenings.Visible = True
                    loadOpeningGrid()
                ElseIf Request.Params("mode") = "demo" Then
                    pnlHome.Visible = True
                Else
                    pnlHome.Visible = True
                    'divApply.Visible = True

                    'style="background-image: url(images/closed.png); background-repeat: no-repeat;"
                End If
                executeDB("insert into login (eid, log, logintime) values (0, 'HR Career Page Access : at " & Now.ToString() & " -- " & Request.UserHostAddress & " ', current_timestamp)", "logdb")



            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Sub loadApprove()
        Dim q = "select distinct appid, aid, name,cell, stage ,draft, ifnull(payconfirm,'No') as payconfirm, log from careers_application where phase = '" & ddlAdminPhase.SelectedValue & "' and jobid = '" & ddlAdminJob.SelectedValue & "' and stage = '" & rblAdminStatus.SelectedValue & "' group by appid"
        Dim mydt = getDBTable(q, "appsdb")
        gvPassApprove.DataSource = mydt
        gvPassApprove.DataBind()
        divMsgAdmin.InnerHtml = "Showing " & mydt.Rows.Count & " records for " & rblAdminStatus.SelectedItem.Text & " Candidate in  " & ddlAdminJob.SelectedItem.Text &
            " " '& q
    End Sub
    Sub loadJobDetail(ByVal jobid As String)
        Dim detail = "<p class='card-text'>"
        Dim q = "select jobid, post, noofpost, age, qual, exp, addnlqual, payscale,location,file from careers_jobs where del = 0 and jobid = '" & jobid & "' limit 1"
        Dim mydt = getDBTable(q, "appsdb")
        If mydt.Rows.Count = 0 Then
            divProfile.InnerHtml = "No job ID found to load " & jobid
            Exit Sub
        End If
        detail = detail & "<b>Name of Post</b>:	" & mydt.Rows(0)("post").ToString & " <br />" &
            "<b>Maximum age limit:</b>:	" & mydt.Rows(0)("age").ToString & " Years<br />" &
            "<b>No of Post</b>:	" & mydt.Rows(0)("noofpost").ToString & " <br />" &
             "<b>Qualification</b>:	" & mydt.Rows(0)("qual").ToString & " <br />" &
                "<b>Experience</b>:	" & mydt.Rows(0)("exp").ToString & " <br />" &
                  "<b>Additional Qualification</b>:	" & mydt.Rows(0)("addnlqual").ToString & " <br />" &
                  "<b>Remuneration</b>:	" & mydt.Rows(0)("payscale").ToString & " <br />"

        '   "<b>Job Location</b>:	" & mydt.Rows(0)("location").ToString & " <br />" &

        divJobDetails.InnerHtml = detail & "</p>"
    End Sub
    Sub loadSuccess()
        Dim ApplicationId = Session("jobAppID")
        If Session("jobAppID") Is Nothing Then
            divDone.InnerHtml = "Your session expired. No application ID found. If you have application ID send mail to email id mentioned above to get the PDF."
            Exit Sub
        End If
        Dim jobdetail = getDBsingle("select post from careers_jobs where jobid in (select jobid from careers_application where appid = " & ApplicationId & ") limit 1", "appsdb")
        Dim lidata = "<li class='list-group-item'> <img src=images/loading.gif width=100px height=100px /> <h4>Your application with Unique Application Number " & ApplicationId & " has been submitted succesfully. </h4> Note down this number for future correspondence. Please download the PDF by clicking on the button. </li> "
        divDone.InnerHtml = "<section class='card'> " &
                                     "  <div class='card-header user-header alt bg-light'> " &
                                         "  <div class='media'> " &
                                             "  <a href='#'> " &
                                                 "  <img class='align-self-center rounded-circle mr-3' style='width:85px; height:85px;' alt='' src='" & "/upload/HR/Career/" & ApplicationId & ".jpg?" & Now.Second & "'> " &
                                             "  </a> " &
                                             "  <div class='media-body'> " &
                                                 "  <h2 class='text-dark display-6'>Applicantion Generated</h2> " &
                                                 "  <p>Application No: " & ApplicationId & " <br/> Post Applied:" & jobdetail & "</p> " &
                                             "  </div> " &
                                         "  </div> " &
                                     "  </div> " &
      "  <ul class='list-group list-group-flush'> " &
                                         lidata &
                                           "  </ul> " &
"  </section> "
        '   Response.Redirect("gatepassPrint.aspx?mode=application")
    End Sub
    Sub loadProfile(ByVal applicationID As String, ByVal status As String)
        Session("jobAppID") = applicationID
        Dim filter = ""
        If status = "new" Then
            filter = " and status = 'new' "
        ElseIf status = "Submit" Then
            filter = " and status = 'Submit' "
        End If
        Dim q = "select salute || ' ' || name as name ,father, mother, sex as 'Gender', 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as 'Date of Birth', idcard as 'NID No', address || ' ' || district || ' Postal Code-' || pin as 'Communication Address',addressp || ' ' || districtp as 'Permanent Address',ncert as 'Total Work Experience',exptype || ' Sector' as 'Current/Last Work Exp', org || ', '|| desig  || ', From ' || durationfrom || ' To ' || durationto as 'Company:' ,deptcand as 'Are you currently employed or were employed by BIFPCL',freedom as 'Are you a son/grand-son or daughter/grand-daughter of freedom fighter(s)/martyred freedom fighter(s)', draft as 'Online Payment Transaction ID', '<a href=/upload/HR/Career/' || resume || '  target=_blank>Attached: View</a>' as degree, qual1 || ' / ' || sub1 || '/ ' || inst1 || ' / ' || uni1 || ' / ' || year1 || ' / ' || gpa1 as 'qualification1',qual2 || ' / ' || sub2 || '/ ' || inst2 || ' / ' || uni2 || ' / ' || year2 || ' / ' || gpa2 as 'qualification2',qual3 || ' / ' || sub3 || '/ ' || inst3 || ' / ' || uni3 || ' / ' || year3 || ' / ' || gpa3 as  'qualification3',qual4 || ' / ' || sub4 || '/ ' || inst4 || ' / ' || uni4 || ' / ' || year4 || ' / ' || gpa4 as  'qualification4',qual5 || ' / ' || sub5 || '/ ' || inst5 || ' / ' || uni5 || ' / ' || year5 || ' / ' || gpa5 as  'qualification5' from careers_application where appid = '" & applicationID & "' " & filter & " limit 1"
        Dim mydt = getDBTable(q, "appsdb")
        If mydt.Rows.Count = 0 Then
            divProfile.InnerHtml = "<b><code>No application ID with status " & status & " found for preview and submit  " & applicationID & "</code></b>"
            btnSubmitPrint.Visible = False
            btnModifyPrint.Visible = False
            Exit Sub
        End If
        Dim liData = ""

        For Each c As DataColumn In mydt.Columns
            If c.ToString.StartsWith("qual") And mydt.Rows(0)(c).ToString.StartsWith("NA") Then Continue For
            liData = liData & "  <li class='list-group-item'> " &
                                              "  <code style='text-transform: capitalize;font-weight: bold;font-size: 100%; color:black;'>" & c.ToString & "</code>: " & mydt.Rows(0)(c).ToString &
                                          "  </li> "
        Next
        Dim jobdetail = getDBsingle("select post from careers_jobs where jobid in (select jobid from careers_application where appid = " & applicationID & ") limit 1", "appsdb")
        divProfile.InnerHtml = "<section class='card'> " &
                                      "  <div class='card-header user-header alt bg-light'> " &
                                          "  <div class='media'> " &
                                              "  <a href='#'> " &
                                                  "  <img class='align-self-center rounded-circle mr-3' style='width:85px; height:85px;' alt='' src='" & "/upload/HR/Career/" & applicationID & ".jpg?" & Now.Second & "'> " &
                                              "  </a> " &
                                              "  <div class='media-body'> " &
                                                  "  <h2 class='text-dark display-6'>Applicant Detail</h2> " &
                                                  "  <p>Application No: " & applicationID & " <br/> Post Applied:" & jobdetail & "</p> " &
                                              "  </div> " &
                                          "  </div> " &
                                      "  </div> " &
       "  <ul class='list-group list-group-flush'> " &
                                          liData &
                                            "  </ul> " &
                                            "  <li class='list-group-item'> " &
                                            "<img class='align-self-center mr-3' style='width:150px; height:85px;' alt='' src='" & "/upload/HR/Career/s" & applicationID & ".jpg?" & Now.Second & "'> </li>" &
                                              "  <li class='list-group-item'>I confirm above details are correct. (You can still modify for correction. After Submit no changes will be possible.)</li>" &
 "  </section> "
    End Sub
    Private Function loadDPR() As Boolean
        lbDownloadSummary.Visible = False
        gvReportPic.Visible = False
        gvReport.Visible = True
        Dim q = ""
        Dim errorPart = ""
        Try
            If rblReportType.SelectedValue = "job" Then
                ' q = "select uid,id " & agency & " , strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, status,   first_apply_by as 'First Apply-By', strftime('%d.%m.%Y',first_issue_dt) as 'First Issue Date', strftime('%d.%m.%Y',last_renewal_apply_dt) as 'Last Renewal Apply', last_renewal_apply_by as 'Renewal Apply By', strftime('%d.%m.%Y',approve1_dt) as 'EPC Approved On', approve1_by as 'EPC Approver', strftime('%d.%m.%Y',approve2_dt) as 'BIFPCL Approved On', approve2_by as 'BIFPCL Approver', strftime('%d.%m.%Y',last_renewal_issue_dt) as 'Last Renewal Date', strftime('%d.%m.%Y',cancel_apply_dt) as 'Cancellation Apply', strftime('%d.%m.%Y',cancel_approve_dt) as 'Cancellation Date' , cancelRemark, strftime('%d.%m.%Y',expelled_dt) as 'Expelled Date' , remark from gatepass where status like '%" & rblReportStatus.SelectedValue & "%' and agency =  '" & ddlReportAgency.SelectedValue & "' order by id desc"
                q = "select printorder, jobid, post, noofpost, age, qual, exp, addnlqual, payscale,vanue_w, vanue_i, date_w, date_i, time_w,time_i from careers_jobs where del = 0 and phase = '" & ddlReportPhase.SelectedValue & "' order by printorder"

            ElseIf rblReportType.SelectedValue = "application" Then
                q = "select aid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit'  and phase = '" & ddlReportPhase.SelectedValue & "' order by aid desc"

            ElseIf rblReportType.SelectedValue = "written" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'written'  and phase = '" & ddlReportPhase.SelectedValue & "' order by aid desc"
            ElseIf rblReportType.SelectedValue = "interview" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'interview'  and phase = '" & ddlReportPhase.SelectedValue & "' order by aid desc"

            ElseIf rblReportType.SelectedValue = "admit" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,action,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'written' and action like 'written%'  and phase = '" & ddlReportPhase.SelectedValue & "' order by aid desc"
            ElseIf rblReportType.SelectedValue = "admitnot" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,action,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'written' and action is null  and phase = '" & ddlReportPhase.SelectedValue & "' order by aid desc"
            ElseIf rblReportType.SelectedValue = "admitInt" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,action,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'interview' and action like 'interview%'  and phase = '" & ddlReportPhase.SelectedValue & "' order by aid desc"
            ElseIf rblReportType.SelectedValue = "admitnotInt" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,action,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'interview' and action like 'written%'  and phase = '" & ddlReportPhase.SelectedValue & "' order by aid desc"

            ElseIf rblReportType.SelectedValue = "writtenExcel" Or rblReportType.SelectedValue = "interviewExcel" Then
                q = "select distinct appid , replace(post, X'0A', ' ') as post, rollno , salute || ' ' || name as 'name' ,father ,Sex , strftime('%d.%m.%Y',dob) as 'dob', cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) as Age, idcard  ,  appid as 'Photo', '' as 'sign'   from careers_application  where  stage = 'written'  and phase = '" & ddlReportPhase.SelectedValue & "'   order by rollno"
                If rblReportType.SelectedValue = "interviewExcel" Then q = "select distinct appid , replace(post, X'0A', ' ') as post, rollno , salute || ' ' || name as 'name' ,father ,Sex , strftime('%d.%m.%Y',dob) as 'dob',cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) as Age, idcard  ,  merit,marks,   appid as 'Photo', '' as 'sign',qual1 || ' / ' || sub1 || '/ ' || inst1 || ' / ' || uni1 || ' / ' || year1 || ' / ' || gpa1 as 'qualification1'   from careers_application   where  stage = 'interview'  and phase = '" & ddlReportPhase.SelectedValue & "'   order by rollno"
                lbDownloadSummary.Visible = True
                gvReportPic.Visible = True
                gvReport.Visible = False
                Dim myDT = getDBTable(q, "appsdb")
                gvReportPic.DataSource = myDT
                gvReportPic.DataBind()
                divReportMessage.InnerHtml = "Showing " & rblReportType.SelectedItem.Text & " <code><b>" & myDT.Rows.Count & "</b></code> Records found for given filters." '& q
                Return False
            ElseIf rblReportType.SelectedValue = "interview" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'interview'  and phase = '" & ddlReportPhase.SelectedValue & "'   order by aid desc"

            End If

            ' diverr.InnerHtml = q
            Dim nwDT = getDBTable(q, "appsdb")

            If nwDT.Rows.Count = 0 Then
                divReportMessage.InnerHtml = "No data exist" '& q
                gvReport.DataSource = nwDT
                gvReport.DataBind()
                Return False
            End If

            divReportMessage.InnerHtml = "Showing " & rblReportType.SelectedItem.Text & " <code><b>" & nwDT.Rows.Count & "</b></code> Records found for given filters." '& q

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

        Response.AddHeader("content-disposition", "attachment; filename=cover" & Now.ToString("ddMy") & ".xls")

        Response.ContentType = "application/excel"

        Dim sWriter As New System.IO.StringWriter()

        Dim hTextWriter As New HtmlTextWriter(sWriter)

        gvReportPic.RenderControl(hTextWriter)

        Response.Write(sWriter.ToString())

        Response.End()
        'lblMsg.Text = "Excel created"

        'GridView1.RenderControl(htw)

    End Sub


    Sub reloadGPData(ByVal appid As String)
        pnlNewPass.Visible = True
        divNew.InnerHtml = " <h3>Job Application</h3>        "

        ' lbJobID.Text = Request.Params("id")
        ddlNewNation.DataSource = getDBTable("select nationality   from nationality", "gpdb")
        ddlNewNation.DataBind()
        btnSumbitPass.Text = "Submit Application"
        lbNewMode.Text = "Modify"  ''It will be New or Edit
        ''' Now chck aditional parameter for single approve
        ''' 
        For yr = 2019 To 1990 Step -1
            ddlyear1.Items.Add(New ListItem(yr, yr))
            ddlyear2.Items.Add(New ListItem(yr, yr))
            ddlyear3.Items.Add(New ListItem(yr, yr))
            ddlyear4.Items.Add(New ListItem(yr, yr))
            ddlyear5.Items.Add(New ListItem(yr, yr))
        Next
        For yr = 20 To 0 Step -1
            ddlExpYr.Items.Add(New ListItem(yr, yr))
            If yr < 12 Then ddlExpMonth.Items.Add(New ListItem(yr, yr))
        Next
        ddlExpYr.SelectedValue = 0
        ddlExpMonth.SelectedValue = 0

        Dim q = "select appid,jobid,email,salute,name,father,mother,sex,idcard,ncert,cell,phone, strftime('%d.%m.%Y',dob) as dob,address,pin,district,addressp,districtp,workexp,exptype, org,desig,durationfrom,durationto,deptcand,freedom, relative,post, draft, resume,last_updated,lastupdateby,status,del, qual1, inst1, uni1,sub1, year1, gpa1,qual2, inst2, uni2,sub2, year2, gpa2,qual3, inst3, uni3,sub3, year3, gpa3,qual4, inst4, uni4,sub4, year4, gpa4,qual5, inst5, uni5,sub5, year5, gpa5 from careers_application where appid = '" & appid & "' and status = 'new' limit 1"
        Try
            Dim mydt = dbOp.getDBTable(q, "appsdb")
            If mydt.Rows.Count < 1 Then
                lbBookMessage.Text = "No Records found for requested ID with status new.. load failed.After final submission Modification not possible. Go back and fill another form."
                lbID.Text = ""
                btnSumbitPass.Enabled = False
                Exit Sub
            End If
            lbJobID.Text = If(IsDBNull(mydt.Rows(0)("jobid")), "", mydt.Rows(0)("jobid"))
            lbNewApprover.Text = If(IsDBNull(mydt.Rows(0)("post")), "", mydt.Rows(0)("post")) 'getDBsingle("select post from careers_jobs where jobid = " & lbJobID.Text & " limit 1", "appsdb")

            txtNewEmail.Text = If(IsDBNull(mydt.Rows(0)("email")), "", mydt.Rows(0)("email"))
            txtNewEmailConfirm.Text = txtNewEmail.Text
            txtNewName.Text = If(IsDBNull(mydt.Rows(0)("name")), "", mydt.Rows(0)("name"))
            txtNewCell.Text = If(IsDBNull(mydt.Rows(0)("cell")), "", mydt.Rows(0)("cell"))
            txtNewFather.Text = If(IsDBNull(mydt.Rows(0)("father")), "", mydt.Rows(0)("father"))
            txtNewMother.Text = If(IsDBNull(mydt.Rows(0)("mother")), "", mydt.Rows(0)("mother"))
            txtNewNID.Text = If(IsDBNull(mydt.Rows(0)("idcard")), "", mydt.Rows(0)("idcard"))
            txtDoB.Text = If(IsDBNull(mydt.Rows(0)("dob")), "", mydt.Rows(0)("dob"))
            txtNewPhone.Text = If(IsDBNull(mydt.Rows(0)("phone")), "", mydt.Rows(0)("phone"))
            txtNewAddress.Text = If(IsDBNull(mydt.Rows(0)("address")), "", mydt.Rows(0)("address")).ToString
            txtNewAddressP.Text = If(IsDBNull(mydt.Rows(0)("addressp")), "", mydt.Rows(0)("addressp")).ToString
            txtNewPIN.Text = If(IsDBNull(mydt.Rows(0)("pin")), "", mydt.Rows(0)("pin"))
            txtOrg.Text = If(IsDBNull(mydt.Rows(0)("org")), "", mydt.Rows(0)("org"))
            txtDesig.Text = If(IsDBNull(mydt.Rows(0)("desig")), "", mydt.Rows(0)("desig")).ToString
            txtDurationFrom.Text = If(IsDBNull(mydt.Rows(0)("durationfrom")), "", mydt.Rows(0)("durationfrom"))
            txtDurationTo.Text = If(IsDBNull(mydt.Rows(0)("durationto")), "", mydt.Rows(0)("durationto")).ToString
            txtDD.Text = If(IsDBNull(mydt.Rows(0)("draft")), "", mydt.Rows(0)("draft")).ToString
            '  lbInfo.Text = "Applied on " & applyDate & " By " & applyBy

            Dim sex = If(IsDBNull(mydt.Rows(0)("sex")), "", mydt.Rows(0)("sex"))
            If String.IsNullOrEmpty(sex) Then
                ddlNewSex.SelectedValue = "Male"
            Else
                ddlNewSex.SelectedValue = sex
            End If
            Dim district = If(IsDBNull(mydt.Rows(0)("district")), "", mydt.Rows(0)("district"))
            If String.IsNullOrEmpty(district) Then
                ddlDistrict.SelectedValue = "Dhaka"
            Else
                ddlDistrict.SelectedValue = district
            End If
            Dim districtp = If(IsDBNull(mydt.Rows(0)("districtp")), "", mydt.Rows(0)("districtp"))
            If String.IsNullOrEmpty(districtp) Then
                ddlDistrictP.SelectedValue = "Dhaka"
            Else
                ddlDistrictP.SelectedValue = districtp
            End If
            Dim exptype = If(IsDBNull(mydt.Rows(0)("exptype")), "", mydt.Rows(0)("exptype"))
            If String.IsNullOrEmpty(exptype) Then
                ddlExpType.SelectedValue = "No Experience"
            Else
                ddlExpType.SelectedValue = exptype
            End If
            divPic.InnerHtml = "<img src=" & "/upload/HR/Career/" & appid & ".jpg?" & Now.Second & "   onerror=" & Chr(34) & "this.src='\upload\employee\pics\user.png';" & Chr(34) & "  />"
            lbPicStatus.Text = "<i class='fa fa-check'></i>Pic Uploaded"
            divPic1.InnerHtml = "<img src=" & "/upload/HR/Career/s" & appid & ".jpg?" & Now.Second & "   onerror=" & Chr(34) & "this.src='\upload\employee\pics\user.png';" & Chr(34) & "  />"
            lbSignStatus.Text = "<i class='fa fa-check'></i>Sign Uploaded"
            lbBookMessage.Text = " id= " & lbID.Text & " Loaded succesfully. You can make changes before submission."
        Catch ex As Exception
            lbBookMessage.Text = "Error in LoadGPData " & ex.Message & " id= " & lbID.Text & q
        End Try
    End Sub


    Sub loadOpeningGrid()
        Dim q = "select jobid, post, noofpost, age, payscale,location,file from careers_jobs where del = 0 and phase in (select phase from careers_jobs where 1 order by jobid desc limit 1 ) order by printorder asc "
        Dim mydt = getDBTable(q, "appsdb")
        lbMsgOpening.Text = mydt.Rows.Count & " Openings found "
        gvOpening.DataSource = mydt
        gvOpening.DataBind()
        'lbCancelMessage.text 
    End Sub


    Protected Sub UploadFile(sender As Object, e As EventArgs)
        Dim msg = ""
        '    If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343326")
        Try

            If FileUpload1.PostedFile IsNot Nothing Then
                Dim uploadDir = "upload/HR/Career/"
                If Not System.IO.Directory.Exists(Server.MapPath(uploadDir)) Then
                    msg = "Creating Path " & uploadDir & "<br/>"
                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir))
                End If

                Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                Dim validFileTypes As String() = {"bmp", "gif", "png", "jpg", "jpeg"}
                Dim ext As String = Path.GetExtension(FileName)
                Dim isValidFile As Boolean = False
                For i As Integer = 0 To validFileTypes.Length - 1
                    If ext = "." & validFileTypes(i) Then
                        isValidFile = True
                        Exit For
                    End If
                Next
                If Not isValidFile Then
                    lbBookMessage.Text = "Picture should be JPG format only" ' msg
                    lbBookMessageTop.Text = lbBookMessage.Text
                End If
                ext = ".jpg" ' Path.GetExtension(FileName)
                Dim newFilename = lbID.Text & ext
                FileUpload1.SaveAs(Server.MapPath(uploadDir & "Big" & newFilename))
                Image_resize(uploadDir & "Big" & newFilename, uploadDir & newFilename, 200)

                If System.IO.File.Exists(Server.MapPath(uploadDir & "Big" & newFilename)) Then
                    System.IO.File.Delete(Server.MapPath(uploadDir & "Big" & newFilename))
                    msg = "Attempt to delete " & uploadDir & "Big" & newFilename
                Else
                    msg = "Not exist " & uploadDir & "Big" & newFilename
                End If
                divPic.InnerHtml = "<img src=" & "/upload/HR/Career/" & newFilename & "?" & Now.Second & " />"
                lbPicStatus.Text = "<i class='fa fa-check'></i>Pic Uploaded"
            End If

            lbBookMessage.Text = "<i class='fa fa-check'></i>Last Action > Pic Uploaded" ' msg
            lbBookMessageTop.Text = lbBookMessage.Text
        Catch _ex As Exception
            lbBookMessage.Text = _ex.Message
        End Try

    End Sub
    Protected Sub UploadFileSign(sender As Object, e As EventArgs)
        Dim msg = ""
        '    If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343326")
        Try

            If FileUpload2.PostedFile IsNot Nothing Then
                Dim uploadDir = "upload/HR/Career/"
                If Not System.IO.Directory.Exists(Server.MapPath(uploadDir)) Then
                    msg = "Creating Path " & uploadDir & "<br/>"
                    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir))
                End If

                Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                Dim validFileTypes As String() = {"bmp", "gif", "png", "jpg", "jpeg"}
                Dim ext As String = Path.GetExtension(FileName)
                Dim isValidFile As Boolean = False
                For i As Integer = 0 To validFileTypes.Length - 1
                    If ext = "." & validFileTypes(i) Then
                        isValidFile = True
                        Exit For
                    End If
                Next
                If Not isValidFile Then
                    lbBookMessage.Text = "Sign should be JPG format only" ' msg
                    lbBookMessageTop.Text = lbBookMessage.Text
                End If
                ext = ".jpg" ' Path.GetExtension(FileName)
                Dim newFilename = "s" & lbID.Text & ext
                FileUpload2.SaveAs(Server.MapPath(uploadDir & "Big" & newFilename))
                Image_resize(uploadDir & "Big" & newFilename, uploadDir & newFilename, 200)

                If System.IO.File.Exists(Server.MapPath(uploadDir & "Big" & newFilename)) Then
                    System.IO.File.Delete(Server.MapPath(uploadDir & "Big" & newFilename))
                    msg = "Attempt to delete " & uploadDir & "Big" & newFilename
                Else
                    msg = "Not exist " & uploadDir & "Big" & newFilename
                End If
                divPic1.InnerHtml = "<img src=" & "/upload/HR/Career/" & newFilename & "?" & Now.Second & " />"
                lbSignStatus.Text = "<i class='fa fa-check'></i>Sign Uploaded"
            End If

            lbBookMessage.Text = "<i class='fa fa-check'></i>Last Action > Sign Uploaded" ' msg
            lbBookMessageTop.Text = lbBookMessage.Text
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








    Private Sub rblReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblReportType.SelectedIndexChanged
        If rblReportType.SelectedValue = "printwritten" Then
            Response.Redirect("gatepassPrint.aspx?mode=attendance&stage=written&phase=" & ddlReportPhase.SelectedValue)
        ElseIf rblReportType.SelectedValue = "printinterview" Then
            Response.Redirect("gatepassPrint.aspx?mode=attendance&stage=interview&phase=" & ddlReportPhase.SelectedValue)
        ElseIf rblReportType.SelectedValue = "ratinginterview" Then
            Response.Redirect("gatepassPrint.aspx?mode=rating&stage=interview&phase=" & ddlReportPhase.SelectedValue)

        ElseIf rblReportType.SelectedValue = "admitall" Then
            Response.Redirect("gatepassPrint.aspx?mode=admitcardall&stage=written&phase=" & ddlReportPhase.SelectedValue)
        ElseIf rblReportType.SelectedValue = "admitallInt" Then
            Response.Redirect("gatepassPrint.aspx?mode=admitcardall&stage=interview&phase=" & ddlReportPhase.SelectedValue)
        Else
            loadDPR()
        End If
    End Sub



    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        loadDPR()
    End Sub






    'Private Sub lbDownloadSummary_Click(sender As Object, e As EventArgs) Handles lbDownloadSummary.Click
    '    saveExcel()
    '    ' Export()
    'End Sub
    'Sub saveExcel()
    '    ' Change the Header Row back to white color
    '    gvReportPic.HeaderRow.Style.Add("background-color", "#FFFFFF")

    '    ' This loop is used to apply stlye to cells based on particular row
    '    'For Each gvrow As GridViewRow In gvReport.Rows
    '    '    gvrow.BackColor = Drawing.Color.White

    '    '    If gvrow.Cells(4).Text = "True" Then
    '    '        gvrow.BackColor = Drawing.Color.Yellow
    '    '        'For k As Integer = 0 To gvrow.Cells.Count - 1
    '    '        '    gvrow.Cells(k).Style.Add("background-color", "#EFF3FB")
    '    '        'Next
    '    '    End If
    '    'Next

    '    Response.ClearContent()

    '    Response.AddHeader("content-disposition", "attachment; filename=newpass" & Now.ToString("ddMy") & ".xls")

    '    Response.ContentType = "application/excel"

    '    Dim sWriter As New System.IO.StringWriter()

    '    Dim hTextWriter As New HtmlTextWriter(sWriter)

    '    gvReportPic.RenderControl(hTextWriter)

    '    Response.Write(sWriter.ToString())

    '    Response.End()
    '    'lblMsg.Text = "Excel created"

    '    'GridView1.RenderControl(htw)

    'End Sub
    'Sub Export()
    '    Response.Clear()
    '    Response.Buffer = True
    '    Response.AddHeader("content-disposition", "attachment;filename=GridViewImage.xls")
    '    Response.Charset = ""
    '    Response.ContentType = "application/vnd.ms-excel"
    '    Dim sw As StringWriter = New StringWriter()
    '    Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
    '    For i As Integer = 0 To gvReportPic.Rows.Count - 1
    '        Dim row As GridViewRow = gvReportPic.Rows(i)
    '        row.Attributes.Add("class", "textmode")
    '    Next
    '    gvReportPic.RenderControl(hw)
    '    Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
    '    Response.Write(style)
    '    Response.Output.Write(sw.ToString())
    '    Response.Flush()
    '    Response.End()
    'End Sub


    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        Return
    End Sub






    Protected Sub btnSumbitPass_Click(sender As Object, e As EventArgs)
        '     If Session("email") Is Nothing Then Response.Redirect("Default.aspx")
        Dim msg = ""
        lbBookMessage.Text = ""
        Dim reattach = " Reattach the Qualifying Degree."
        If rblDeclare.SelectedItem.Text = "Not Agreed" Then
            lbBookMessage.Text = "You have not agreed to the undertaking / declaration." & reattach
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If lbPicStatus.Text.Contains("Not") Or lbSignStatus.Text.Contains("Not") Then
            lbBookMessage.Text = "Picture/Signature Not Uploaded"
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtNewName.Text) Then
            lbBookMessage.Text = "Name can't be blank. " & reattach
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtNewFather.Text) Then
            lbBookMessage.Text = "Father can't be blank. " & reattach
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDoB.Text) Then
            lbBookMessage.Text = "Date of Birth can't be blank. " & reattach
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtNewNID.Text) Then
            lbBookMessage.Text = "NID No can't be blank. " & reattach
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDD.Text) Then
            lbBookMessage.Text = "Transaction ID can't be blank or invalid. " & reattach
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtNewAddress.Text) Or String.IsNullOrEmpty(txtNewCell.Text) Then
            lbBookMessage.Text = "Address/Contact can't be blank. " & reattach
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If Not (txtNewEmail.Text = txtNewEmailConfirm.Text) Or String.IsNullOrEmpty(txtNewEmail.Text) Then
            lbBookMessage.Text = "Email ID Mismatch. " & reattach
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtgpa1.Text) Or ddlqual1.SelectedItem.Text = "-" Then
            lbBookMessage.Text = "Qualification 1 can't be blank. " & reattach
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        'If String.IsNullOrEmpty(txtNewValidityStart.Text) Or String.IsNullOrEmpty(txtNewValidityEnd.Text) Then
        '    If lbNewMode.Text = "Modify" Then  ''put dummy dates
        '        txtNewValidityStart.Text = "01.01.2000"
        '        txtNewValidityEnd.Text = "01.01.2001"
        '    Else
        '        lbBookMessage.Text = "Validity can't be blank"
        '        lbBookMessageTop.Text = lbBookMessage.Text
        '        Exit Sub
        '    End If
        'End If

        'Dim validity_start = DateTime.ParseExact(txtNewValidityStart.Text, "dd.M.yyyy", Nothing)
        'Dim validity_end = DateTime.ParseExact(txtNewValidityEnd.Text, "dd.M.yyyy", Nothing)
        Dim destfolder = "HR" & "/" & "Career" '"vcr"
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
        fileName = System.IO.Path.GetFileName(FileUploadControl.FileName)
        '' Check for Exception should only be word
        'pdf True AND TRUE AND TRUE
        'doc TRUE AND FALSE AND TRUE

        If String.IsNullOrEmpty(fileName) Then
            lbBookMessage.Text = "Please attach your qualifying degree certificate..."
            lbBookMessageTop.Text = lbBookMessage.Text
            Exit Sub
        End If
        Dim ext = Path.GetExtension(fileName)
        Dim newFilename = "BIFPCL" & lbID.Text & ext
        If newFilename.Trim().Length > 0 Then
            'uploadFile.SaveAs(Server.MapPath("./Others/") + fileName)
            FileUploadControl.SaveAs(Server.MapPath(uploadDir) + newFilename)

            temp = temp & "<img src='images/ok.png' />Successfully Uploaded: " & newFilename & " <br/>" & Now.ToString
            msg = msg & temp
        End If
        Dim dob = DateTime.ParseExact(txtDoB.Text, "dd.M.yyyy", Nothing)
        '  Dim age = Math.Floor(Now.Subtract(dob).TotalDays / 365)
        Dim exp = ddlExpYr.SelectedValue + ddlExpMonth.SelectedValue * 12 + ddlExpDay.SelectedValue
        Dim expText = ddlExpYr.SelectedValue & " Year " & ddlExpMonth.SelectedValue & " Month " + ddlExpDay.SelectedValue & " Day(s)"
        Dim durationFrom = txtDurationFrom.Text
        Dim durationTo = txtDurationTo.Text
        If lbNewMode.Text = "New" Then
            ' msg = "Insert"
            '''Check if application already exist
            '''
            Dim Q1 = "select appid from careers_application where appid = '" & lbID.Text & "' and status = 'Submit' limit 1"
            Dim ret1 = getDBsingle(Q1, "appsdb")
            ''Insert new data
            If ret1.Contains(lbID.Text) Then
                lbBookMessage.Text = "This Application ID already submitted. Not allowed to submit again"
                lbBookMessageTop.Text = lbBookMessage.Text
                btnSumbitPass.Enabled = False
                Exit Sub
            End If

            Dim q = "insert into careers_application (appid,jobid,phase, email,salute,name,father,mother,sex,idcard,ncert,cell,phone,dob,address,pin,district,addressp,districtp,workexp,exptype, org,desig,durationfrom,durationto,deptcand,freedom, relative, post, draft, resume,last_updated,lastupdateby,status,del, qual1, inst1, uni1,sub1, year1, gpa1,qual2, inst2, uni2,sub2, year2, gpa2,qual3, inst3, uni3,sub3, year3, gpa3,qual4, inst4, uni4,sub4, year4, gpa4,qual5, inst5, uni5,sub5, year5, gpa5)" &
                " values ('" & lbID.Text & "','" & lbJobID.Text & "','" & lbNewPhase.Text & "','" & txtNewEmail.Text.Replace("'", "") & "','" & ddlNewSalute.SelectedValue & "','" & txtNewName.Text.Replace("'", "") & "','" & txtNewFather.Text.Replace("'", "") & "','" & txtNewMother.Text.Replace("'", "") & "','" & ddlNewSex.SelectedValue & "','" & txtNewNID.Text.Replace("'", "") & "','" & expText & "','" & txtNewCell.Text.Replace("'", "") & "','" & txtNewPhone.Text.Replace("'", "") & "','" & dob.ToString("yyyy-MM-dd") & "','" & txtNewAddress.Text.Replace("'", "") & "','" & txtNewPIN.Text.Replace("'", "") & "','" & ddlDistrict.SelectedItem.Text.Replace("'", "") & "','" & txtNewAddressP.Text.Replace("'", "") & "','" & ddlDistrictP.SelectedItem.Text.Replace("'", "") & "'," &
        "'" & exp & "','" & ddlExpType.SelectedValue & "','" & txtOrg.Text.Replace("'", "") & "','" & txtDesig.Text.Replace("'", "") & "','" & durationFrom & "','" & durationTo & "','" & rblDept.SelectedValue & "','" & rblfreedom.SelectedValue & "','" & rblRelative.SelectedValue & "','" & lbNewApprover.Text & "','" & txtDD.Text.Replace("'", "") & "','" & newFilename & "'," &
        " current_timestamp,'" & Request.UserHostAddress & "','new','0'," &
        "'" & ddlqual1.SelectedValue & "','" & txtInst1.Text.Replace("'", "") & "','" & txtUni1.Text.Replace("'", "") & "','" & txtsub1.Text.Replace("'", "") & "','" & ddlyear1.SelectedValue & "','" & txtgpa1.Text.Replace("'", "") & "'," &
         "'" & ddlqual2.SelectedValue & "','" & txtInst2.Text.Replace("'", "") & "','" & txtUni2.Text.Replace("'", "") & "','" & txtsub2.Text.Replace("'", "") & "','" & ddlyear2.SelectedValue & "','" & txtgpa2.Text.Replace("'", "") & "'," &
          "'" & ddlqual3.SelectedValue & "','" & txtInst3.Text.Replace("'", "") & "','" & txtUni3.Text.Replace("'", "") & "','" & txtsub3.Text.Replace("'", "") & "','" & ddlyear3.SelectedValue & "','" & txtgpa3.Text.Replace("'", "") & "'," &
           "'" & ddlqual4.SelectedValue & "','" & txtInst4.Text.Replace("'", "") & "','" & txtUni4.Text.Replace("'", "") & "','" & txtsub4.Text.Replace("'", "") & "','" & ddlyear4.SelectedValue & "','" & txtgpa4.Text.Replace("'", "") & "'," &
            "'" & ddlqual5.SelectedValue & "','" & txtInst5.Text.Replace("'", "") & "','" & txtUni5.Text.Replace("'", "") & "','" & txtsub5.Text.Replace("'", "") & "','" & ddlyear5.SelectedValue & "','" & txtgpa5.Text.Replace("'", "") & "')"
            ' msg = msg '& q
            Dim ret = executeDB(q, "appsdb")
            If Not ret.Contains("error") Then
                msg = msg & "Data inserted .. Redirecting to Print Page"
                lbBookMessage.Text = msg
                txtNewName.Text = ""
                txtNewNID.Text = ""
                lbPicStatus.Text = "Pic Not Uploaded"
                btnSumbitPass.Enabled = False
                btnUpload.Enabled = False
                Response.Redirect("hrCareer.aspx?aid=" & lbID.Text & "&mode=print")
            Else
                msg = msg & "Error inserting data " & ret & q.Replace("careers_application", "ca").Replace("appid", "jobid")
            End If
        ElseIf lbNewMode.Text = "Modify" Then
            Dim q = "update careers_application set jobid ='" & lbJobID.Text & "',email='" & txtNewEmail.Text.Replace("'", "") & "',salute='" & ddlNewSalute.SelectedValue & "',name='" & txtNewName.Text.Replace("'", "") & "',father='" & txtNewFather.Text.Replace("'", "") & "',mother='" & txtNewMother.Text.Replace("'", "") & "',sex='" & ddlNewSex.SelectedValue & "',idcard='" & txtNewNID.Text.Replace("'", "") & "',ncert='" & expText & "',cell='" & txtNewCell.Text.Replace("'", "") & "',phone='" & txtNewPhone.Text.Replace("'", "") & "',dob='" & dob.ToString("yyyy-MM-dd") & "',address='" & txtNewAddress.Text.Replace("'", "") & "',pin='" & txtNewPIN.Text.Replace("'", "") & "',district='" & ddlDistrict.SelectedItem.Text & "',addressp='" & txtNewAddressP.Text.Replace("'", "") & "',districtp='" & ddlDistrictP.SelectedItem.Text & "',workexp='" & exp & "',exptype='" & ddlExpType.SelectedValue & "', org='" & txtOrg.Text.Replace("'", "") & "',desig='" & txtDesig.Text.Replace("'", "") & "',durationfrom='" & durationFrom & "',durationto='" & durationTo & "',deptcand='" & rblDept.SelectedValue & "',freedom='" & rblfreedom.SelectedValue & "', post='" & lbNewApprover.Text & "',relative='" & rblRelative.SelectedValue & "', draft='" & txtDD.Text.Replace("'", "") & "', resume='" & newFilename & "',last_updated = current_timestamp,lastupdateby='" & Request.UserHostAddress & "',status= 'new',del='0', qual1='" & ddlqual1.SelectedValue & "', inst1='" & txtInst1.Text.Replace("'", "") & "', uni1='" & txtUni1.Text.Replace("'", "") & "',sub1='" & txtsub1.Text.Replace("'", "") & "', year1='" & ddlyear1.SelectedValue & "', gpa1='" & txtgpa1.Text.Replace("'", "") & "',qual2='" & ddlqual2.SelectedValue & "', inst2='" & txtInst2.Text.Replace("'", "") & "', uni2='" & txtUni2.Text.Replace("'", "") & "',sub2='" & txtsub2.Text.Replace("'", "") & "', year2='" & ddlyear2.SelectedValue & "', gpa2='" & txtgpa2.Text.Replace("'", "") & "',qual3='" & ddlqual3.SelectedValue & "', inst3='" & txtInst3.Text.Replace("'", "") & "', uni3='" & txtUni3.Text.Replace("'", "") & "',sub3='" & txtsub3.Text.Replace("'", "") & "', year3='" & ddlyear3.SelectedValue & "', gpa3='" & txtgpa3.Text.Replace("'", "") & "',qual4='" & ddlqual4.SelectedValue & "', inst4='" & txtInst4.Text.Replace("'", "") & "', uni4='" & txtUni4.Text.Replace("'", "") & "',sub4='" & txtsub4.Text.Replace("'", "") & "', year4='" & ddlyear4.SelectedValue & "', gpa4='" & txtgpa4.Text.Replace("'", "") & "',qual5='" & ddlqual5.SelectedValue & "', inst5='" & txtInst5.Text.Replace("'", "") & "', uni5='" & txtUni5.Text.Replace("'", "") & "',sub5='" & txtsub5.Text.Replace("'", "") & "', year5='" & ddlyear5.SelectedValue & "', gpa5='" & txtgpa5.Text.Replace("'", "") & "' where appid = '" & lbID.Text & "'"

            msg = msg & q
            Dim ret = executeDB(q, "appsdb")
            If Not ret.Contains("error") Then
                msg = msg & "Data Updated .. Redirecting to Print Page"
                lbBookMessage.Text = msg
                txtNewName.Text = ""
                txtNewNID.Text = ""
                lbPicStatus.Text = "Pic Not Uploaded"
                btnSumbitPass.Enabled = False
                btnUpload.Enabled = False
                Response.Redirect("hrCareer.aspx?aid=" & lbID.Text & "&mode=print")
            Else
                msg = msg & "Error updating data " & ret '& q
            End If

        End If
        lbBookMessage.Text = msg
        lbBookMessageTop.Text = lbBookMessage.Text
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs)
        If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343302")
        If String.IsNullOrEmpty(txtJobPost.Text) Or String.IsNullOrEmpty(txtJobLastDt.Text) Then
            lbMsgPost.Text = "Please Enter the job detail"
            Exit Sub
        End If
        If checkForSQLInjection(txtJobPost.Text) Then
            lbMsgPost.Text = "Special character not allowed"
            Exit Sub
        End If
        Dim subject = txtJobPost.Text.Replace("'", "")
        Dim newFilename = ""
        Try
            'Dim destfolder = "HR" & "/" & "Career" '"vcr"
            '' lblStatus.Text = "Uploading..."
            'System.Threading.Thread.Sleep(2000)
            Dim temp As String = ""
            ''####### Create Directory
            'Dim uploadDir As String = ""

            'uploadDir = "./upload/" & destfolder & "/"    'upload/cmg/govt/


            'If Not System.IO.Directory.Exists(Server.MapPath(uploadDir)) Then
            '    temp = "Creating Path " & uploadDir & "<br/>"
            '    System.IO.Directory.CreateDirectory(Server.MapPath(uploadDir))
            'End If

            ''###### Upload File

            'Dim fileName As String = "" 'ddlUploadType.SelectedValue
            'Dim uploadFiles As HttpFileCollection = Request.Files
            'For i As Integer = 0 To uploadFiles.Count - 1
            '    Dim uploadFile As HttpPostedFile = uploadFiles(i)
            '    fileName = System.IO.Path.GetFileName(uploadFile.FileName)
            '    '' Check for Exception should only be word
            '    'pdf True AND TRUE AND TRUE
            '    'doc TRUE AND FALSE AND TRUE

            '    If String.IsNullOrEmpty(fileName) Then
            '        lbMsgPost.Text = "Please attach a file..."
            '        Exit Sub
            '    End If
            '    'remove spaces
            '    '  fileName = Left(txtSubject.Text, 6) & Now.Day & Now.Second  'fileName.Replace(" ", "_")
            '    'fileName = fileName.Replace("/", "_")
            '    'fileName = fileName.Replace("\", "_")
            '    '   fileName = strip(fileName)
            '    ''remove single quotes , / , \ 
            '    'fileName = fileName.Replace("'", "_")
            '    Dim ext = Path.GetExtension(fileName)
            '    newFilename = "BIFPCL" & Now.ToString("ddMMyHHmmss") & ext
            '    If newFilename.Trim().Length > 0 Then
            '        'uploadFile.SaveAs(Server.MapPath("./Others/") + fileName)
            '        uploadFile.SaveAs(Server.MapPath(uploadDir) + newFilename)

            '        temp = temp & "<img src='images/ok.png' />Successfully Uploaded: " & newFilename & " <br/>"

            '    End If
            'Next
            Dim dt = DateTime.ParseExact(txtJobLastDt.Text, "dd.M.yyyy", Nothing)
            Dim myquery As String = ""
            ' If temp.Contains("Successfully") Then
            myquery = "insert into careers_jobs(phase, printorder, post, age, noofpost, qual, exp, addnlqual, payscale, issue_dt, detail, last_dt, file, del, lastupdateby, last_updated) " &
               "values ('" & ddlPostPhase.SelectedValue & "','" & txtJobPrintOrder.Text.Replace("'", "") & "','" & txtJobPost.Text.Replace("'", "") & "','" & txtJobAge.Text.Replace("'", "") & "','" & txtJobNumbers.Text.Replace("'", "") & "','" & txtJobDetail.Text.Replace("'", "") & "','" & txtJobAddQual.Text.Replace("'", "") & "','" & txtJobExp.Text.Replace("'", "") & "','" & txtJobPayscale.Text.Replace("'", "") & "',current_timestamp,'" & txtJobDetail.Text.Replace("'", "") & "','" & dt.ToString("yyyy-MM-dd") & "','" & newFilename & "',0,'" & Session("email") & "',current_timestamp )"
            If executeDB(myquery, "appsdb") = "ok" Then
                temp = temp & "Record Updated"
                btnSubmit.Enabled = False

                'Dim ffMpeg = New NReco.VideoConverter.FFMpegConverter()
                'ffMpeg.GetVideoThumbnail(Server.MapPath(uploadDir) + fileName, Server.MapPath("./upload/vcr/") + fileName & ".jpg", Rnd(7000)) 'Left(r(0), 8)
                ' Response.Redirect("vc.aspx?file=success&thumbnailcreated")
            Else
                temp = temp & "Error: " & myquery
            End If
            'Else
            '    temp = temp & "Unable to upload. Try Again.<br/>" & fileName
            'End If
            lbMsgPost.Text = temp & "<br/><a href='hrCareer.aspx?mode=admin'>Click here to upload more </a>" ' & myquery

        Catch e1 As Exception
            lbMsgPost.Text = e1.Message
        End Try

    End Sub

    Private Sub gvOpening_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvOpening.RowCommand
        Dim value = e.CommandArgument.ToString()
        '   lbCancelMessage.Text = value
        Response.Redirect("hrCareer.aspx?id=" & value & "&mode=confirm")
    End Sub

    Private Sub cbConfirm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConfirm.SelectedIndexChanged
        'Try
        '    Dim i = 0
        '    For Each item As ListItem In cbConfirm.Items
        '        If item.Selected Then i = i + 1
        '    Next
        '    If i = 6 Then
        '        btnConfirm.Enabled = True
        '    Else
        '        btnConfirm.Enabled = False
        '    End If
        '    lbMessageConfirm.Text = i & " requirement confirmed "
        'Catch ex As Exception
        '    lbMessageConfirm.Text = ex.Message
        'End Try
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim i = 0
        For Each item As ListItem In cbConfirm.Items
            If item.Selected Then i = i + 1
        Next
        If i = 6 Then
            Response.Redirect("hrCareer.aspx?id=" & lbConfirmJobID.Text & "&mode=apply")
        Else
            lbMessageConfirm.Text = "All requirement must be confirmed "
        End If

    End Sub
    Private Sub btnSubmitPrint_Click(sender As Object, e As EventArgs) Handles btnSubmitPrint.Click
        Dim q = "update careers_application set status='Submit', stage = 'applied' where appid = '" & Session("jobAppID") & "'"
        Dim ret = executeDB(q, "appsdb")
        If Not ret.Contains("error") Then
            divProfile.InnerHtml = "status updated .. Redirecting to Print Page"
            Response.Redirect("hrCareer.aspx?mode=done")

        Else
            divProfile.InnerHtml = "status updated Error " & ret & q
        End If

    End Sub



    Private Sub btnModifyPrint_Click(sender As Object, e As EventArgs) Handles btnModifyPrint.Click
        Response.Redirect("hrCareer.aspx?mode=modify")
    End Sub

    Private Sub btnDownloadPDF_Click(sender As Object, e As EventArgs) Handles btnDownloadPDF.Click
        Response.Redirect("gatepassPrint.aspx?mode=application")

    End Sub

    Private Sub btnDownloadPDFAdmin_Click(sender As Object, e As EventArgs) Handles btnDownloadPDFAdmin.Click
        Response.Redirect("gatepassPrint.aspx?mode=application")
    End Sub

    Private Sub btnAdmitPrint_Click(sender As Object, e As EventArgs) Handles btnAdmitPrint.Click
        If String.IsNullOrEmpty(txtAdmitDoB.Text) Or String.IsNullOrEmpty(txtAdmitUID.Text) Then
            lbAdmitWarn.Text = "Enter details"
            Exit Sub
        End If
        lbAdmitWarn.Text = ""
        '' check dob match with ID
        Session("jobAdmitID") = Trim(txtAdmitUID.Text.Replace("'", ""))
        Dim dob = getDBsingle("select strftime('%d.%m.%Y',dob) as dob from careers_application where appid = " & Session("jobAdmitID") & " limit 1", "appsdb")
        If Not dob = txtAdmitDoB.Text Then
            lbAdmitWarn.Text = "Your DoB " & txtAdmitDoB.Text & " does not match with the DoB entered in application form " & Session("jobAdmitID") & " . Choose DoB from calander in dd.mm.yyyy format."
            Exit Sub
        End If
        '' check shortlisted candidate
        Dim appid = getDBsingle("select appid from careers_application where stage = '" & lbAdmitStage.Text & "' and appid = " & Session("jobAdmitID") & " limit 1", "appsdb")
        If appid.Contains("Error") Then
            lbAdmitWarn.Text = "Your Application ID " & Session("jobAdmitID") & " does not qualified for selection criteria. Thanks for showing your intrest in BIFPCL. Better luck next time !!!"
            Exit Sub
        End If
        executeDB("update careers_application set action = '" & lbAdmitStage.Text & " Admit card printed " & Now.ToString & "' where appid = " & Session("jobAdmitID") & "", "appsdb")
        executeDB("insert into login (eid, log, logintime) values (0, 'HR Career Admit Card Print : at " & Now.ToString() & " - for AppID " & Session("jobAdmitID") & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

        Response.Redirect("gatepassPrint.aspx?mode=admitcard")
    End Sub

    Private Sub ddlReportPhase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlReportPhase.SelectedIndexChanged
        loadDPR()
    End Sub

    Private Sub ddlPostPhase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPostPhase.SelectedIndexChanged
        SqlDataSource2.SelectParameters("phase").DefaultValue = ddlPostPhase.SelectedValue.ToString

    End Sub

    Private Sub ddlAdminPhase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAdminPhase.SelectedIndexChanged
        ddlAdminJob.DataSource = getDBTable("select jobid, post from careers_jobs where phase = '" & ddlAdminPhase.SelectedValue & "' and del = 0", "appsdb")
        ddlAdminJob.DataBind()
        loadApprove()
    End Sub

    Private Sub ddlAdminJob_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAdminJob.SelectedIndexChanged
        loadApprove()
    End Sub

    Private Sub rblAdminStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblAdminStatus.SelectedIndexChanged
        loadApprove()
        If rblAdminStatus.SelectedValue = "applied" Then
            btnAproveBulk.Text = "Qualify Marked Candidates for Written Exam"
        ElseIf rblAdminStatus.SelectedValue = "written" Then
            btnAproveBulk.Text = "Qualify Marked Candidates for Interview"
        ElseIf rblAdminStatus.SelectedValue = "interview" Then
            btnAproveBulk.Text = "Qualify Marked Candidates for Joining"
        ElseIf rblAdminStatus.SelectedValue = "selected" Then
            btnAproveBulk.Text = "No Action"
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
            lbApprovePass.Text = "Select something first"
            Exit Sub
        End If
        msg = i & " records to be updated. "
        uids = uids & " 0"
        lbApprovePass.Text = msg & uids
        Dim stage = "written"
        If rblAdminStatus.SelectedValue = "applied" Then
            stage = "written"
        ElseIf rblAdminStatus.SelectedValue = "written" Then
            stage = "interview"
        ElseIf rblAdminStatus.SelectedValue = "interview" Then
            stage = "selected"
        ElseIf rblAdminStatus.SelectedValue = "selected" Then
            lbApprovePass.Text = "Button won't work here.."
            Exit Sub
        End If
        Dim q = "update careers_application set stage = '" & stage & "' , log =  '> " & stage & "' || ifnull(log,'') where aid in(" & uids & ")"
        Dim ret = executeDB(q, "appsdb")
        If Not ret.Contains("error") Then
            msg = msg & "Action Done for  " & i & " no of Candidates. " & stage & " for " & uids ' <a href=gatepass.aspx?mode=approve>Click here to approve again</a>"
            '  btnAproveBulk.Enabled = False
            loadApprove()
        Else
            lbApprovePass.Text = msg & "Error " & ret '& q
        End If
        lbApprovePass.Text = msg '& q
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
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
            lbApprovePass.Text = "Select something first"
            Exit Sub
        End If
        If i > 1 Then
            lbApprovePass.Text = "Select single item for action"
            Exit Sub
        End If
        msg = i & " records to be updated. "
        uids = uids & " 0"
        Dim stage = "written"
        If rblAdminStatus.SelectedValue = "applied" Then
            lbApprovePass.Text = "Button won't work here.."
            Exit Sub
        ElseIf rblAdminStatus.SelectedValue = "written" Then
            stage = "applied"
        ElseIf rblAdminStatus.SelectedValue = "interview" Then
            stage = "written"
        ElseIf rblAdminStatus.SelectedValue = "selected" Then
            stage = "interview"
        End If
        Dim q = "update careers_application set stage = '" & stage & "' , log =  '> " & stage & "' || ifnull(log,'') where aid in(" & uids & ")"
        Dim ret = executeDB(q, "appsdb")
        If Not ret.Contains("error") Then
            msg = msg & "Action Done for  " & i & " no of Candidate. " & stage & " for " & uids ' <a href=gatepass.aspx?mode=approve>Click here to approve again</a>"
            '  btnAproveBulk.Enabled = False
            loadApprove()
        Else
            lbApprovePass.Text = msg & "Error " & ret '& q
        End If
        lbApprovePass.Text = msg '& q
    End Sub

    Private Sub btnPayBulk_Click(sender As Object, e As EventArgs) Handles btnPayBulk.Click
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
            lbApprovePass.Text = "Select something first"
            Exit Sub
        End If
        msg = i & " records to be updated. "
        uids = uids & " 0"
        lbApprovePass.Text = msg & uids

        Dim q = "update careers_application set payconfirm = 'yes' , log =  '> paid: Yes ' || ifnull(log,'') where aid in(" & uids & ")"
        Dim ret = executeDB(q, "appsdb")
        If Not ret.Contains("error") Then
            msg = msg & "Action Done for  " & i & " no of Candidates.  for paid: Yes " & uids ' <a href=gatepass.aspx?mode=approve>Click here to approve again</a>"
            '  btnAproveBulk.Enabled = False
            loadApprove()
        Else
            lbApprovePass.Text = msg & "Error " & ret '& q
        End If
        lbApprovePass.Text = msg '& q
    End Sub

    Private Sub btnRejectPay_Click(sender As Object, e As EventArgs) Handles btnRejectPay.Click
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
            lbApprovePass.Text = "Select something first"
            Exit Sub
        End If
        If i > 1 Then
            lbApprovePass.Text = "Select single item for action"
            Exit Sub
        End If
        msg = i & " records to be updated. "
        uids = uids & " 0"
        Dim q = "update careers_application set payconfirm = 'no' , log =  '> paid: No ' || ifnull(log,'') where aid in(" & uids & ")"
        Dim ret = executeDB(q, "appsdb")
        If Not ret.Contains("error") Then
            msg = msg & "Action Done for  " & i & " no of Candidates.  for paid: No " & uids ' <a href=gatepass.aspx?mode=approve>Click here to approve again</a>"
            '  btnAproveBulk.Enabled = False
            loadApprove()
        Else
            lbApprovePass.Text = msg & "Error " & ret '& q
        End If
        lbApprovePass.Text = msg '& q
    End Sub

    Private Sub btnVar_Submit_Click(sender As Object, e As EventArgs) Handles btnVar_Submit.Click
        Dim q = "update careers_var set venue_w = '" & txtVarvenue_w.Text.Replace("'", "") & "', " &
            "venue_i = '" & txtVarvenue_i.Text.Replace("'", "") & "', " &
              "date_w = '" & txtDate_w.Text.Replace("'", "") & "', " &
               "a = '" & txtvar_a.Text.Replace("'", "") & "', " &
                "date_i = '" & txtDate_i.Text.Replace("'", "") & "' where 1"

        Dim ret = executeDB(q, "appsdb")
        If ret = "ok" Then
            btnVar_Submit.Text = "Record updated..."
            btnVar_Submit.Enabled = False
        End If
        'lbApprovePass.Text = q
    End Sub
End Class
