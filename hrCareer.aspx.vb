Imports Common
Imports dbOp
Imports System.IO
Imports System.Drawing           'CoreCompat Image handling

Imports System.Drawing.Drawing2D   'CoreCompat Image handling

Imports System.Drawing.Imaging       'CoreCompat Image handling
Imports System.Data
Imports ClosedXML.Excel

Partial Class hrCareer
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

                Dim pageLocked = "1"
                '' load settings
                Dim q3 = "select updates, locked,opport,howto,tnc, a from careers_var where 1  limit 1"
                Dim mydtP = getDBTable(q3, "appsdb")
                If mydtP.Rows.Count = 0 Then
                    Exit Sub
                End If
                divUpdates.InnerHtml = mydtP.Rows(0)("updates").ToString
                divHowToApply.InnerHtml = mydtP.Rows(0)("howto").ToString
                divOpport.InnerHtml = mydtP.Rows(0)("opport").ToString
                divTnCApply.InnerHtml = mydtP.Rows(0)("tnc").ToString
                pageLocked = mydtP.Rows(0)("locked").ToString

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
                ElseIf Request.Params("mode") = "adminpage" Then
                    If Not (checkAuthorization(Session("email"), "onlybifpcl") And checkAuthorization(Session("email"), "hrCareer.aspx?mode=admin")) Then  ''Pass url or onlybifpcl for all bifplc executives
                        lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives with approver rights.<a href=sso/Default.aspx?appid=12343326>Click here to login</a>"
                        Exit Sub
                    End If
                    pnlAdminPage.Visible = True
                    '' load settings
                    Dim q = "select updates, locked,opport,howto,tnc, a from careers_var where 1  limit 1"
                    Dim mydt = getDBTable(q, "appsdb")
                    If mydt.Rows.Count = 0 Then
                        Exit Sub
                    End If
                    txtUpdates.Text = mydt.Rows(0)("updates").ToString
                    txtHowto.Text = mydt.Rows(0)("howto").ToString
                    txtOpo.Text = mydt.Rows(0)("opport").ToString
                    txtTnC.Text = mydt.Rows(0)("tnc").ToString
                    rblPageLock.SelectedValue = mydt.Rows(0)("locked").ToString
                ElseIf Request.Params("mode") = "rating" Then
                    If Not (checkAuthorization(Session("email"), "onlybifpcl") And checkAuthorization(Session("email"), "hrCareer.aspx?mode=admin")) Then  ''Pass url or onlybifpcl for all bifplc executives
                        lbError.Text = "Your email " & Session("email") & " don't have Authorisaption to Access.<br/> Only for BIFPCL Executives with approver rights.<a href=sso/Default.aspx?appid=12343326>Click here to login</a>"
                        Exit Sub
                    End If
                    pnlRating.Visible = True
                    ddlRatingPhase.DataSource = getDBTable("select distinct phase from careers_jobs where 1 order by phase asc", "appsdb")
                    ddlRatingPhase.DataBind()
                    ddlRatingJobs.DataSource = getDBTable("select jobid, post from careers_jobs where phase = '" & ddlRatingPhase.SelectedValue & "' and del = 0", "appsdb")
                    ddlRatingJobs.DataBind()
                    Session("rateAppID") = getDBsingle("select appid from careers_application where phase = '" & ddlRatingPhase.SelectedValue & "' and stage = '" & rblRatingStatus.SelectedValue & "' limit 1", "appsdb")
                    loadRating()
                    '' load settings
                ElseIf Request.Params("mode") = "reportlive" Then
                    If Not (checkAuthorization(Session("email"), "onlybifpcl") And checkAuthorization(Session("email"), "hrCareer.aspx?mode=admin")) Then  ''Pass url or onlybifpcl for all bifplc executives
                        lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives with approver rights.<a href=sso/Default.aspx?appid=12343326>Click here to login</a>"
                        Exit Sub
                    End If
                    pnlIntLive.Visible = True
                    ddlLiveIntDate.DataSource = getDBTable("select distinct venue_i_dt, strftime('%d.%m.%Y', venue_i_dt) as dispdate  from careers_application where stage = 'interview' and not venue_i_dt is null order by venue_i_dt desc", "appsdb")
                    ddlLiveIntDate.DataBind()
                    Try
                        ddlLiveIntDate.SelectedValue = Now.ToString("yyyy-MM-dd")
                    Catch ex As Exception

                    End Try
                    refreshLive()
                ElseIf Request.Params("mode") = "int" Then
                    If Not (checkAuthorization(Session("email"), "onlybifpcl") And checkAuthorization(Session("email"), "hrCareer.aspx?mode=admin")) Then  ''Pass url or onlybifpcl for all bifplc executives
                        lbError.Text = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives with approver rights.<a href=sso/Default.aspx?appid=12343326>Click here to login</a>"
                        Exit Sub
                    End If
                    pnlInt.Visible = True

                    '' now show rating sheet
                    ' Session("rateAppID") = getDBsingle("select appid from careers_application where phase = 'Phase2' and stage = 'interview' order by merit, jobid asc", "appsdb")

                    'pnlRating.Visible = True
                    ddlIntDate.DataSource = getDBTable("select distinct venue_i_dt, strftime('%d.%m.%Y', venue_i_dt) as dispdate  from careers_application where  stage = 'interview' order by venue_i_dt desc", "appsdb")
                    ddlIntDate.DataBind()
                    Try
                        ddlIntDate.SelectedValue = Now.ToString("yyyy-MM-dd")
                    Catch ex As Exception

                    End Try
                    If DateTime.UtcNow.AddHours(6).TimeOfDay.TotalMinutes < TimeSpan.Parse("14:30").TotalMinutes Then
                        ddlIntSlot.SelectedValue = "08:30 AM"

                    Else
                        ddlIntSlot.SelectedValue = "02:00 PM"
                    End If
                    If Not Request.Params("id") Is Nothing Then
                        Dim q = "delete from career_int where appid = '" & Request.Params("id").ToString & "'"
                        Dim ret = executeDB(q, "appsdb")
                        If ret = "ok" Then
                            lbIntConduct.Text = "Candidate with app id " & Request.Params("id").ToString & " has been removed from interview list "
                        Else
                            lbIntConduct.Text = "Unable to remove Application ID"
                        End If
                    End If
                    refreshCandidate()
                    ' lbIntName.Text = TimeSpan.Parse("14:30").TotalMinutes & " - " & DateTime.UtcNow.AddHours(6).TimeOfDay.TotalMinutes
                    'ddlRatingJobs.DataSource = getDBTable("select jobid, post from careers_jobs where phase = '" & ddlRatingPhase.SelectedValue & "' and del = 0", "appsdb")
                    'ddlRatingJobs.DataBind()
                    'Session("rateAppID") = getDBsingle("select appid from careers_application where phase = '" & ddlRatingPhase.SelectedValue & "' and stage = '" & rblRatingStatus.SelectedValue & "' limit 1", "appsdb")
                    '  loadRatingInterview()
                    '' load settings

                ElseIf Request.Params("mode") = "intDashboard" Then
                    pnlInterDashboard.Visible = True
                    If Session("intDashboard") Is Nothing Then
                        divPIN.Visible = True
                        Exit Sub
                    End If
                    divPIN.Visible = False
                    pnlInterview.Visible = True
                    lbIntName.Text = Session("intDashboard").ToString
                    ''get candidate list
                    Dim q = "select appid from career_int where " & lbIntName.Text & " is null order by last_updated asc limit 1"
                    Dim appid = getDBsingle(q, "appsdb")
                    If appid.Contains("Error") Then
                        lbDivInt.Text = "No candidate has been sent by HR.<a href='hrCareer.aspx?mode=intDashboard'> Refresh</a>"
                        btnIntSubmit.Enabled = False
                        Exit Sub
                    Else
                        lbIntAppid.Text = appid
                        divIntProfile.InnerHtml = loadRatingInterview(appid)
                        calculateVivaVoce()
                    End If


                ElseIf Request.Params("mode") = "apply" Then
                    If pageLocked Then
                        divNew.InnerHtml = " <h3>Page is locked for new application</h3>        "
                        Exit Sub
                    End If
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
                    lbAdmitPhase.Text = getDBsingle("select phase from careers_application where 1 order by aid desc limit 1", "appsdb")
                    pnlAdmitCard.Visible = True
                ElseIf Request.Params("mode") = "printadmitInt" Then
                    executeDB("insert into login (eid, log, logintime) values (0, 'HR Career Report Admit Card Print Interview : at " & Now.ToString() & " - from - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    lbAdmitPhase.Text = getDBsingle("select phase from careers_application where 1 order by aid desc limit 1", "appsdb")
                    pnlAdmitCard.Visible = True
                    lbAdmitStage.Text = "interview"
                ElseIf Request.Params("mode") = "printadmitSel" Then
                    executeDB("insert into login (eid, log, logintime) values (0, 'HR Career Report Admit Card Print Joining: at " & Now.ToString() & " - from - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
                    lbAdmitPhase.Text = getDBsingle("select phase from careers_application where stage='sddlAdminJobelected' order by aid desc limit 1", "appsdb")
                    pnlAdmitCard.Visible = True
                    lbAdmitStage.Text = "selected"
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
                    ddlReportJobID.DataSource = getDBTable("select jobid, post from careers_jobs where phase = '" & ddlReportPhase.SelectedValue & "' and del = 0", "appsdb")
                    ddlReportJobID.DataBind()
                    ddlReportJobID.Items.Add(New ListItem("All Post", "%"))
                    ddlReportJobID.SelectedValue = "%"
                    loadDPR()
                    '  lbAllBooking.Text = q
                ElseIf Request.Params("mode") = "opening" Then
                    'ddlUidNew.Items.Insert(1, "Common Place")
                    '  Exit Sub
                    pnlOpenings.Visible = True
                    loadOpeningGrid()
                ElseIf Request.Params("mode") = "demo" Then
                    pnlHome.Visible = True
                    divApply.Visible = True
                Else
                    If pageLocked = "1" Then
                        divTnC.Attributes.Add("style", "background-image: url(images/closed.png); background-repeat: no-repeat;")
                        divHowTo.Attributes.Add("style", "background-image: url(images/closed.png); background-repeat: no-repeat;")
                        divCareer.Attributes.Add("style", "background-image: url(images/closed.png); background-repeat: no-repeat;")
                        pnlHome.Visible = True
                        'divApply.Visible = True
                    Else
                        pnlHome.Visible = True
                        divApply.Visible = True
                    End If


                    'style="background-image: url(images/closed.png); background-repeat: no-repeat;"
                End If
                executeDB("insert into login (eid, log, logintime) values (0, 'HR Career Page Access : at " & Now.ToString() & " -- " & Request.UserHostAddress & " ', current_timestamp)", "logdb")



            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Sub refreshCandidate()
        Dim q = "select appid, name || ' (' || rollno || ')' as cand from careers_application where venue_i_dt = '" & ddlIntDate.SelectedValue & "' and slot = '" & ddlIntSlot.SelectedValue & "' and not appid in (select appid from career_int) order by merit, jobid asc "
        Dim mydt = getDBTable(q, "appsdb")
        If mydt.Rows.Count = 0 Then
            lbError.Text = "No candidates for given selection"
            Exit Sub
        End If
        lbError.Text = mydt.Rows.Count & " candidates for given selection."
        ddlIntCandidate.DataSource = mydt
        ddlIntCandidate.DataBind()
        '  lbError.Text = q
        divCandProfile.InnerHtml = loadRatingInterview(ddlIntCandidate.SelectedValue)

        q = "select  '' as remove, appid, rollno as name, strftime('%d.%m.%Y %H:%M',ifnull(i1,'1999-11-11')) as 'Int1', strftime('%d.%m.%Y %H:%M',ifnull(i2,'1999-11-11')) as 'Int2',strftime('%d.%m.%Y %H:%M',ifnull(i3,'1999-11-11')) as 'Int3' from career_int  order by last_updated desc limit 100"
        Dim mydt1 = getDBTable(q, "appsdb")
        If mydt1.Rows.Count = 0 Then
            Exit Sub
        End If
        For Each r In mydt1.Rows

            r(0) = "<a href=hrCareer.aspx?mode=int&id=" & r(1) & "> Delete </a>"
        Next
        gvIntDone.DataSource = mydt1
        gvIntDone.DataBind()
    End Sub
    Private Sub gvIntDone_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvIntdone.RowDataBound
        Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(0).Text)
        e.Row.Cells(0).Text = decodedText
    End Sub
    Sub refreshLive()

        '  Dim q = "select  c.rollno,  name as name ,i1a,i1b,i1c,i1d, i1rem , i2a,i2b,i2c,i2d, i2rem , i3a,i3b,i3c,i3d, i3rem, strftime('%d.%m.%Y',venue_i_dt) || ' - ' || venue_i_time as 'slot', i.appid as 'View'  from career_int i, careers_application c where i.appid = c.appid and venue_i_dt = '" & ddlLiveIntDate.SelectedValue & "' order by i.last_updated desc"
        Dim q = "select  c.rollno,  name as name ,i1a,i1b,i1c,i1d, i1rem , i2a,i2b,i2c,i2d, i2rem , i3a,i3b,i3c,i3d, i3rem,i4a,i4b,i4c,i4d, i4rem,i5a,i5b,i5c,i5d, i5rem, strftime('%d.%m.%Y',venue_i_dt) || ' - ' || venue_i_time as 'slot', c.appid as 'View'  from  careers_application c  where stage= 'interview' and c.appid in (select appid from careers_application where venue_i_dt = '" & ddlLiveIntDate.SelectedValue & "' and not i1a =0 union select appid from career_int where i1 is null) order by c.merit desc"
        Dim mydt1 = getDBTable(q, "appsdb")
        If mydt1.Rows.Count = 0 Then
            Exit Sub
        End If
        For Each r In mydt1.Rows

            r("View") = "<a href=hrCareer.aspx?mode=printadmin&aid" & r("View") & "> " & r("View") & " </a>"
            If Not IsDBNull(r("i1a"))  Then
            If r("i1a") = "0" Then
                r("rollno") = "<span style='background-color:pink'>" & r("rollno") & "</span>"
            Else
                r("rollno") = "<span style='background-color:lightgreen'>" & r("rollno") & "</span>"
            End If
            Else
                r("rollno") = "<span style='background-color:pink'>" & r("rollno") & "</span>"
            End If 
        Next
        gvLiveDone.DataSource = mydt1
        gvLiveDone.DataBind()
        lbError.Text = "Last refreshed at: " & Now.ToShortTimeString & " Showing: " & mydt1.Rows.Count & " records"
    End Sub
    Private Sub gvLiveDone_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvLiveDone.RowDataBound
        Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(18).Text)
        e.Row.Cells(18).Text = decodedText
        Dim decodedText1 = HttpUtility.HtmlDecode(e.Row.Cells(0).Text)
        e.Row.Cells(0).Text = decodedText1

    End Sub
    Function loadRatingInterview(ByVal ApplicationID As String) As String
        ' Dim ApplicationID = Session("rateAppID")
        ' txtRatingAppid.Text = ApplicationID

        Dim q = "select salute || ' ' || name || ' s/d ' || father as name ,  rollno, strftime('%d.%m.%Y',dob) as 'Date of Birth', '<a href=/upload/HR/Career/' || resume || '  target=_blank>Attached: View</a>' as degree, qual1 || ' / ' || sub1 || '/ ' || inst1 || ' / ' || uni1 || ' / ' || year1 || ' / ' || gpa1 as 'qualification1',qual2 || ' / ' || sub2 || '/ ' || inst2 || ' / ' || uni2 || ' / ' || year2 || ' / ' || gpa2 as 'qualification2',qual3 || ' / ' || sub3 || '/ ' || inst3 || ' / ' || uni3 || ' / ' || year3 || ' / ' || gpa3 as  'qualification3',qual4 || ' / ' || sub4 || '/ ' || inst4 || ' / ' || uni4 || ' / ' || year4 || ' / ' || gpa4 as  'qualification4',qual5 || ' / ' || sub5 || '/ ' || inst5 || ' / ' || uni5 || ' / ' || year5 || ' / ' || gpa5 as  'qualification5', 'SSC:' || ratessc || ' | HSC:' || ratehsc || ' | Grad:' || rategrad || ' | PostGrad:' || ratepg || ' | Diploma:' || ratediploma as 'Grades' from careers_application where appid = '" & ApplicationID & "' " & " limit 1"
        Dim mydt = getDBTable(q, "appsdb")
        If mydt.Rows.Count = 0 Then
            Return "<b><code>No application ID  found   " & ApplicationID & "</code></b>"

        End If
        Dim liData = ""
        btnRatingUpdate.Enabled = True
        For Each c As DataColumn In mydt.Columns
            If c.ToString.StartsWith("qual") And mydt.Rows(0)(c).ToString.StartsWith("NA") Then Continue For
            liData = liData & "  <li class='list-group-item' style='padding: .1rem .1rem;'> " &
                                              "  <code style='text-transform: capitalize;font-weight: bold;font-size: 100%; color:black;'>" & c.ToString & "</code>: " & mydt.Rows(0)(c).ToString &
                                          "  </li> "
        Next
        Return "<section class='card'> " &
                                      "  <div class='card-header user-header alt bg-light'> " &
                                          "  <div class='media'> " &
                                              "  <a href='#'> " &
                                                  "  <img class='align-self-center rounded-circle mr-3' style='width:85px; height:85px;' alt='' src='" & "/upload/HR/Career/" & ApplicationID & ".jpg?" & Now.Second & "'> " &
                                              "  </a> " &
                                              "  <div class='media-body'> " &
                                                  "  <h2 class='text-dark display-6'>Candidate Detail</h2> " &
                                                  "  <p>Application No: " & ApplicationID & " </p> " &
                                              "  </div> " &
                                          "  </div> " &
                                      "  </div> " &
       "  <ul class='list-group list-group-flush'> " &
                                          liData &
                                            "  </ul> " &
                                 "  </section> "

        '


    End Function
    Sub loadRating()
        Dim ApplicationID = Session("rateAppID")
        txtRatingAppid.Text = ApplicationID

        Dim q = "select rollno, salute || ' ' || name || ' s/d ' || father as name ,  'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as 'Date of Birth', '<a href=/upload/HR/Career/' || resume || '  target=_blank>Attached: View</a>' as degree, qual1 || ' / ' || sub1 || '/ ' || inst1 || ' / ' || uni1 || ' / ' || year1 || ' / ' || gpa1 as 'qualification1',qual2 || ' / ' || sub2 || '/ ' || inst2 || ' / ' || uni2 || ' / ' || year2 || ' / ' || gpa2 as 'qualification2',qual3 || ' / ' || sub3 || '/ ' || inst3 || ' / ' || uni3 || ' / ' || year3 || ' / ' || gpa3 as  'qualification3',qual4 || ' / ' || sub4 || '/ ' || inst4 || ' / ' || uni4 || ' / ' || year4 || ' / ' || gpa4 as  'qualification4',qual5 || ' / ' || sub5 || '/ ' || inst5 || ' / ' || uni5 || ' / ' || year5 || ' / ' || gpa5 as  'qualification5' from careers_application where appid = '" & ApplicationID & "' " & " limit 1"
        Dim mydt = getDBTable(q, "appsdb")
        If mydt.Rows.Count = 0 Then
            divRatingProfile.InnerHtml = "<b><code>No application ID  found   " & ApplicationID & "</code></b>"
            btnRatingUpdate.Enabled = False
            Exit Sub
        End If
        Dim liData = ""
        btnRatingUpdate.Enabled = True
        For Each c As DataColumn In mydt.Columns
            If c.ToString.StartsWith("qual") And mydt.Rows(0)(c).ToString.StartsWith("NA") Then Continue For
            liData = liData & "  <li class='list-group-item'> " &
                                              "  <code style='text-transform: capitalize;font-weight: bold;font-size: 100%; color:black;'>" & c.ToString & "</code>: " & mydt.Rows(0)(c).ToString &
                                          "  </li> "
        Next
        divRatingProfile.InnerHtml = "<section class='card'> " &
                                      "  <div class='card-header user-header alt bg-light'> " &
                                          "  <div class='media'> " &
                                              "  <a href='#'> " &
                                                  "  <img class='align-self-center rounded-circle mr-3' style='width:85px; height:85px;' alt='' src='" & "/upload/HR/Career/" & ApplicationID & ".jpg?" & Now.Second & "'> " &
                                              "  </a> " &
                                              "  <div class='media-body'> " &
                                                  "  <h2 class='text-dark display-6'>Rating Detail</h2> " &
                                                  "  <p>Application No: " & ApplicationID & " </p> " &
                                              "  </div> " &
                                          "  </div> " &
                                      "  </div> " &
       "  <ul class='list-group list-group-flush'> " &
                                          liData &
                                            "  </ul> " &
                                 "  </section> "

        '''################Attempt to get valid ratings from database
        '''
        txtRateSSC.Text = "0"
        txtRateHSC.Text = "0"
        txtRateGrad.Text = "0"
        txtRatePG.Text = "0"
        txtRateDiploma.Text = "0"
        txtI1a.Text = "0"
        txtI1B.Text = "0"
        txtI1C.Text = "0"
        txtI1D.Text = "0"

        txtI2a.Text = "0"
        txtI2B.Text = "0"
        txtI2C.Text = "0"
        txtI2D.Text = "0"

        txtI3a.Text = "0"
        txtI3B.Text = "0"
        txtI3C.Text = "0"
        txtI3D.Text = "0"

        txtI4a.Text = "0"
        txtI4B.Text = "0"
        txtI4C.Text = "0"
        txtI4D.Text = "0"

        txtI5a.Text = "0"
        txtI5B.Text = "0"
        txtI5C.Text = "0"
        txtI5D.Text = "0"


        q = "select qual1, gpa1, qual2,gpa2, qual3,gpa3, qual4,gpa4,qual5,gpa5, ratessc, ratehsc,rategrad,ratepg,ratediploma, stage, i1a,i1b,i1c,i1d,i2a,i2b,i2c,i2d,i3a,i3b,i3c,i3d,i4a,i4b,i4c,i4d,i5a,i5b,i5c,i5d from careers_application where stage = '" & rblRatingStatus.SelectedValue & "' and appid = '" & ApplicationID & "'"
        mydt = getDBTable(q, "appsdb")
        Dim msg = ""
        Dim stage = ""
        If mydt.Rows.Count = 1 Then

            Try
                stage = mydt.Rows(0)("stage").ToString
                For i = 0 To 8 Step 2
                    If mydt.Rows(0)(i).ToString.Contains("S.S.C") Then txtRateSSC.Text = Left(mydt.Rows(0)(i + 1).ToString, 4)
                    If mydt.Rows(0)(i).ToString.Contains("H.S.C") Then txtRateHSC.Text = Left(mydt.Rows(0)(i + 1).ToString, 4)
                    If mydt.Rows(0)(i).ToString.Contains("B. Sc.") Or mydt.Rows(0)(i).ToString.Contains("Bachelor") Then txtRateGrad.Text = Left(mydt.Rows(0)(i + 1).ToString, 4)
                    If mydt.Rows(0)(i).ToString.Contains("Masters") Then txtRatePG.Text = Left(mydt.Rows(0)(i + 1).ToString, 4)
                    If mydt.Rows(0)(i).ToString.Contains("Diploma") Then txtRateDiploma.Text = Left(mydt.Rows(0)(i + 1).ToString, 4)
                    msg = msg & i
                    ''' if rating is already saved restore it.
                    ''' 
                    If Not IsDBNull(mydt.Rows(0)("ratessc")) Then txtRateSSC.Text = mydt.Rows(0)("ratessc").ToString
                    If Not IsDBNull(mydt.Rows(0)("ratehsc")) Then txtRateHSC.Text = mydt.Rows(0)("ratehsc").ToString
                    If Not IsDBNull(mydt.Rows(0)("rategrad")) Then txtRateGrad.Text = mydt.Rows(0)("rategrad").ToString
                    If Not IsDBNull(mydt.Rows(0)("ratepg")) Then txtRatePG.Text = mydt.Rows(0)("ratepg").ToString
                    If Not IsDBNull(mydt.Rows(0)("ratediploma")) Then txtRateDiploma.Text = mydt.Rows(0)("ratediploma").ToString

                Next
                ''' get interview marks
                ''' 
                If Not IsDBNull(mydt.Rows(0)("i5a")) Then txtI5a.Text = mydt.Rows(0)("i5a").ToString
                If Not IsDBNull(mydt.Rows(0)("i5b")) Then txtI5B.Text = mydt.Rows(0)("i5b").ToString
                If Not IsDBNull(mydt.Rows(0)("i5c")) Then txtI5C.Text = mydt.Rows(0)("i5c").ToString
                If Not IsDBNull(mydt.Rows(0)("i5d")) Then txtI5D.Text = mydt.Rows(0)("i5d").ToString
                If Not IsDBNull(mydt.Rows(0)("i4a")) Then txtI4a.Text = mydt.Rows(0)("i4a").ToString
                If Not IsDBNull(mydt.Rows(0)("i4b")) Then txtI4B.Text = mydt.Rows(0)("i4b").ToString
                If Not IsDBNull(mydt.Rows(0)("i4c")) Then txtI4C.Text = mydt.Rows(0)("i4c").ToString
                If Not IsDBNull(mydt.Rows(0)("i4d")) Then txtI4D.Text = mydt.Rows(0)("i4d").ToString
                If Not IsDBNull(mydt.Rows(0)("i3a")) Then txtI3a.Text = mydt.Rows(0)("i3a").ToString
                If Not IsDBNull(mydt.Rows(0)("i3b")) Then txtI3B.Text = mydt.Rows(0)("i3b").ToString
                If Not IsDBNull(mydt.Rows(0)("i3c")) Then txtI3C.Text = mydt.Rows(0)("i3c").ToString
                If Not IsDBNull(mydt.Rows(0)("i3d")) Then txtI3D.Text = mydt.Rows(0)("i3d").ToString
                If Not IsDBNull(mydt.Rows(0)("i2a")) Then txtI2a.Text = mydt.Rows(0)("i2a").ToString
                If Not IsDBNull(mydt.Rows(0)("i2b")) Then txtI2B.Text = mydt.Rows(0)("i2b").ToString
                If Not IsDBNull(mydt.Rows(0)("i2c")) Then txtI2C.Text = mydt.Rows(0)("i2c").ToString
                If Not IsDBNull(mydt.Rows(0)("i2d")) Then txtI2D.Text = mydt.Rows(0)("i2d").ToString
                If Not IsDBNull(mydt.Rows(0)("i1a")) Then txtI1a.Text = mydt.Rows(0)("i1a").ToString
                If Not IsDBNull(mydt.Rows(0)("i1b")) Then txtI1B.Text = mydt.Rows(0)("i1b").ToString
                If Not IsDBNull(mydt.Rows(0)("i1c")) Then txtI1C.Text = mydt.Rows(0)("i1c").ToString
                If Not IsDBNull(mydt.Rows(0)("i1d")) Then txtI1D.Text = mydt.Rows(0)("i1d").ToString
            Catch ex As Exception
                lbRatingMsg.Text = "Error getting data. Manually update." & ex.Message
            End Try
            lbRatingMsg.Text = "Data loaded succesfully.<b>" & stage & "</b>"
        Else
            lbRatingMsg.Text = "Multiple app id found. Quitting"
            Exit Sub
        End If
    End Sub
    Sub loadApprove()
        Dim q = "select distinct appid, aid, name,cell, stage ,draft, ifnull(payconfirm,'No') as payconfirm, log, rollno from careers_application where phase = '" & ddlAdminPhase.SelectedValue & "' and jobid like '%" & ddlAdminJob.SelectedValue & "%' and stage = '" & rblAdminStatus.SelectedValue & "' group by appid"
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
            Dim filter = " and jobid = '" & ddlReportJobID.SelectedValue & "' "
            If ddlReportJobID.SelectedValue = "%" Then filter = " "
            If rblReportType.SelectedValue = "job" Then
                ' q = "select uid,id " & agency & " , strftime('%d.%m.%Y', validity_start) as `Validity Start`,strftime('%d.%m.%Y', validity_end) as `Validity End`, status,   first_apply_by as 'First Apply-By', strftime('%d.%m.%Y',first_issue_dt) as 'First Issue Date', strftime('%d.%m.%Y',last_renewal_apply_dt) as 'Last Renewal Apply', last_renewal_apply_by as 'Renewal Apply By', strftime('%d.%m.%Y',approve1_dt) as 'EPC Approved On', approve1_by as 'EPC Approver', strftime('%d.%m.%Y',approve2_dt) as 'BIFPCL Approved On', approve2_by as 'BIFPCL Approver', strftime('%d.%m.%Y',last_renewal_issue_dt) as 'Last Renewal Date', strftime('%d.%m.%Y',cancel_apply_dt) as 'Cancellation Apply', strftime('%d.%m.%Y',cancel_approve_dt) as 'Cancellation Date' , cancelRemark, strftime('%d.%m.%Y',expelled_dt) as 'Expelled Date' , remark from gatepass where status like '%" & rblReportStatus.SelectedValue & "%' and agency =  '" & ddlReportAgency.SelectedValue & "' order by id desc"
                q = "select printorder, jobid, post, noofpost, age, qual, exp, addnlqual, payscale,vanue_w, vanue_i, date_w, date_i, time_w,time_i from careers_jobs where del = 0 and phase = '" & ddlReportPhase.SelectedValue & "' " & filter & " order by printorder"

            ElseIf rblReportType.SelectedValue = "application" Then
                q = "select aid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit'  and phase = '" & ddlReportPhase.SelectedValue & "' " & filter & " order by aid desc"
            ElseIf rblReportType.SelectedValue = "paid" Then
                q = "select  appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name , draft as 'Txn ID',father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid',  status from careers_application where last_updated > '2019-04-05' and status = 'Submit'  and phase = '" & ddlReportPhase.SelectedValue & "' and payconfirm = 'yes' order by aid desc"

            ElseIf rblReportType.SelectedValue = "paidUnique" Then
                q = "select  appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name , draft as 'Txn ID',father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid',  status from careers_application where last_updated > '2019-04-05' and status = 'Submit'  and phase = '" & ddlReportPhase.SelectedValue & "' and payconfirm = 'yes' and not draft in (select draft from (SELECT draft, COUNT(*) c FROM careers_application where phase='" & ddlReportPhase.SelectedValue & "' and status = 'Submit'  GROUP BY draft HAVING c > 1)) order by aid desc"
            ElseIf rblReportType.SelectedValue = "nonpaid" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,draft as 'Txn ID',father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', status from careers_application where last_updated > '2019-04-05' and status = 'Submit'  and phase = '" & ddlReportPhase.SelectedValue & "' and (payconfirm = 'no' or payconfirm is null) order by aid desc"
            ElseIf rblReportType.SelectedValue = "multi" Then
                q = "select aid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,draft as 'Txn ID',father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', status from careers_application where last_updated > '2019-04-05' and status = 'Submit'  and draft in (select draft from (SELECT draft, COUNT(*) c FROM careers_application where phase='" & ddlReportPhase.SelectedValue & "' and status = 'Submit'  GROUP BY draft HAVING c > 1)) order by draft"
            ElseIf rblReportType.SelectedValue = "written" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'written'  and phase = '" & ddlReportPhase.SelectedValue & "' " & filter & " order by aid desc"
            ElseIf rblReportType.SelectedValue = "writtenExcel" Then
                q = "select distinct appid,appid as 'View',rollno,  salute || ' ' || name as name , '' as picture, '' as 'Signature',father, jobid, post as 'Applied For',sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'written'  and phase = '" & ddlReportPhase.SelectedValue & "' " & filter & " order by rollno asc"
            ElseIf rblReportType.SelectedValue = "interview" Then
                q = "select distinct appid,appid as 'Click to View Application', rollno, merit, jobid, post as 'Applied For', salute || ' ' || name as name ,father, marks, venue_i,	strftime('%d.%m.%Y',venue_i_dt) as venue_i_dt,	venue_i_time, sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'interview'  and phase = '" & ddlReportPhase.SelectedValue & "' " & filter & " order by merit, jobid asc"
            ElseIf rblReportType.SelectedValue = "selected" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'selected'  and phase = '" & ddlReportPhase.SelectedValue & "' " & filter & " order by aid desc"
            ElseIf rblReportType.SelectedValue = "admit" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,action,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'written' and action like 'written%'  and phase = '" & ddlReportPhase.SelectedValue & "' order by aid desc"
            ElseIf rblReportType.SelectedValue = "admitnot" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,action,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'written' and action is null  and phase = '" & ddlReportPhase.SelectedValue & "' order by aid desc"
            ElseIf rblReportType.SelectedValue = "admitInt" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,action,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'interview' and action like 'interview%'  and phase = '" & ddlReportPhase.SelectedValue & "' order by aid desc"
            ElseIf rblReportType.SelectedValue = "admitnotInt" Then
                q = "select distinct appid,appid as 'Click to View Application',jobid, post as 'Applied For', salute || ' ' || name as name ,action,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid', address || ' ' || district || ' Postal Code-' || pin as 'address', deptcand as 'Dept Candidate', freedom as 'Freedom Fighter', draft as 'Pay order', status from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'interview' and action like 'written%'  and phase = '" & ddlReportPhase.SelectedValue & "' order by aid desc"
                '
            ElseIf rblReportType.SelectedValue = "afterinterview" Then
                q = "select distinct venue_i_dt,appid as 'Click to View Application', rollno, strftime('%d.%m.%Y',venue_i_dt) || ' - ' || venue_i_time as 'slot', salute || ' ' || name as name ,i1a,i1b,i1c,i1d, i1rem, i2a,i2b,i2c,i2d, i2rem , i3a,i3b,i3c,i3d, i3rem,i4a,i4b,i4c,i4d, i4rem,i5a,i5b,i5c,i5d, i5rem from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'interview' and appid in (select appid from career_int)  and phase = '" & ddlReportPhase.SelectedValue & "' " & filter & " order by venue_i_dt desc"

            ElseIf rblReportType.SelectedValue = "meritsheet" Then
                exportExcelRating(ddlReportPhase.SelectedValue, ddlReportJobID.SelectedValue)
                Return True
            ElseIf rblReportType.SelectedValue = "writtenExcel1" Or rblReportType.SelectedValue = "interviewExcel" Then
                q = "select distinct appid , replace(post, X'0A', ' ') as post, rollno , salute || ' ' || name as 'name' ,father ,Sex , strftime('%d.%m.%Y',dob) as 'dob', cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) as Age, idcard  ,  appid as 'Photo', '' as 'sign'   from careers_application  where  stage = 'written'  and phase = '" & ddlReportPhase.SelectedValue & "'   order by rollno"
                If rblReportType.SelectedValue = "interviewExcel" Then q = " select distinct appid , replace(c.post, X'0A', ' ') as post, rollno as 'RollNo', salute || ' ' || name as 'name' ,father as 'father',strftime('%d.%m.%Y',venue_i_dt) || ' - ' || venue_i_time as 'slot', strftime('%d.%m.%Y',dob) as 'dob', idcard as 'nid' ,   appid as 'Photo', '' as 'sign', date_w,date_i   from careers_application c, careers_jobs j where c.jobid = j.jobid and stage = 'interview' and c.phase = '" & ddlReportPhase.SelectedValue & "'    order by c.jobid, venue_i_dt, merit,  slot asc"

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
        ElseIf rblReportType.SelectedValue = "afterinterviewpdf" Then
            Response.Redirect("gatepassPrint.aspx?mode=rating3int&phase=" & ddlReportPhase.SelectedValue & "&dt=%&tm=%")
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
            Dim Q1 = "select appid from careers_application where appid = '" & lbID.Text & "'  limit 1"
            Dim ret1 = getDBsingle(Q1, "appsdb")
            ''Insert new data
            If ret1.Contains(lbID.Text) Then
                lbBookMessage.Text = "This Application ID already submitted. Not allowed to submit again. <a href=hrCareer.aspx> Go Back </a>"
                lbBookMessageTop.Text = lbBookMessage.Text
                btnSumbitPass.Enabled = False
                Exit Sub
                'Else
                '    msg = msg & "No such application id exist " & ret1 & Q1
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
            myquery = "insert into careers_jobs(phase, printorder, post, age, noofpost, qual, exp, addnlqual, payscale, issue_dt, detail, last_dt, file, del, minqual, lastupdateby, last_updated) " &
               "values ('" & ddlPostPhase.SelectedValue & "','" & txtJobPrintOrder.Text.Replace("'", "") & "','" & txtJobPost.Text.Replace("'", "") & "','" & txtJobAge.Text.Replace("'", "") & "','" & txtJobNumbers.Text.Replace("'", "") & "','" & txtJobDetail.Text.Replace("'", "") & "','" & txtJobAddQual.Text.Replace("'", "") & "','" & txtJobExp.Text.Replace("'", "") & "','" & txtJobPayscale.Text.Replace("'", "") & "',current_timestamp,'" & txtJobDetail.Text.Replace("'", "") & "','" & dt.ToString("yyyy-MM-dd") & "','" & newFilename & "',0,'" & ddlMinQual.SelectedValue.ToString & "','" & Session("email") & "',current_timestamp )"
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
    Private Sub btnAdmitPrintRate_Click(sender As Object, e As EventArgs) Handles btnAdmitPrintRate.Click
        Dim q = "update careers_application set ratessc = " & ddlRateSSCC.SelectedValue & " , ratehsc =" & ddlRateHSC.SelectedValue & " , rategrad = " & ddlRateGrad.SelectedValue & ", ratepg =" & ddlRatePG.SelectedValue & " , ratediploma = " & ddlRateDiploma.SelectedValue & " where appid = '" & Session("jobAdmitID") & "'"
        Dim ret = executeDB(q, "appsdb")
        If ret = "ok" Then
            lbAdmitWarn.Text = "Rating is updated."
            '' move to next record
            Response.Redirect("gatepassPrint.aspx?mode=admitcard")
        Else
            lbAdmitWarn.Text = "Unable to updated." & ret
        End If
    End Sub
    Private Sub btnAdmitPrint_Click(sender As Object, e As EventArgs) Handles btnAdmitPrint.Click
        If String.IsNullOrEmpty(txtAdmitDoB.Text) Or String.IsNullOrEmpty(txtAdmitUID.Text) Then
            lbAdmitWarn.Text = "Enter details"
            Exit Sub
        End If
        lbAdmitWarn.Text = ""
        '' check dob match with ID
        Session("jobAdmitID") = Trim(txtAdmitUID.Text.Replace("'", ""))
        Session("stageAdmitID") = Trim(lbAdmitStage.Text.Replace("'", ""))

        Dim dob = getDBsingle("select strftime('%d.%m.%Y',dob) as dob from careers_application where appid = " & Session("jobAdmitID") & " limit 1", "appsdb")
        If Not dob = txtAdmitDoB.Text Then
            lbAdmitWarn.Text = "Your DoB " & txtAdmitDoB.Text & " does not match with the DoB entered in application form " & Session("jobAdmitID") & " . Choose DoB from calander in dd.mm.yyyy format."
            Exit Sub
        End If
        '' check shortlisted candidate
        Dim q = "select appid from careers_application where stage = '" & lbAdmitStage.Text & "' and appid = " & Session("jobAdmitID") & " limit 1"
        Dim appid = getDBsingle(q, "appsdb")
        If appid.Contains("Error") Then
            lbAdmitWarn.Text = "Your candidature with application id " & Session("jobAdmitID") & " did not qualify as per the selection criteria.Thank You for exploring career opportunities with BIFPCL.<br/>Wish You Luck For Your Future Endeavours.<br/> <br/>Team-BIFPCL" '& q
            Exit Sub
Else
If lbAdmitStage.Text.Contains("selected") Then
 lbAdmitWarn.Text = "Congratulations !!Your Candidature with Application ID " & Session("jobAdmitID") & " is selected to be part of Team-BIFPCL.<br/>Please check your e-mail for Offer of Employment and other details.<br/><br/>Team-BIFPCL"
 Exit Sub
 End If
        End If
        executeDB("update careers_application set action = '" & lbAdmitStage.Text & " Admit card printed " & Now.ToString & "' where appid = " & Session("jobAdmitID") & "", "appsdb")
        executeDB("insert into login (eid, log, logintime) values (0, 'HR Career Admit Card Print : at " & Now.ToString() & " - for AppID " & Session("jobAdmitID") & " - " & Request.UserHostAddress & " ', current_timestamp)", "logdb")
        lbAdmitWarn.Text = "Congratulations! Your Admid Card Downloaded."
        If lbAdmitStage.Text.Contains("written") Then
            lbAdmitWarn.Text = "Congratulations !!Your Candidature with Application ID " & Session("jobAdmitID") & " is selected for written examintation. Verify your CGPA details to download Admit Card."
            divCheck1.Visible = False
            divCheck2.Visible = True
            For yr = 3.0 To 5.0 Step 0.1
                ddlRateSSCC.Items.Add(New ListItem(yr, yr))
                ddlRateHSC.Items.Add(New ListItem(yr, yr))
                ddlRateDiploma.Items.Add(New ListItem(yr, yr))
                ddlRateGrad.Items.Add(New ListItem(yr, yr))
                ddlRatePG.Items.Add(New ListItem(yr, yr))
            Next
            ddlRateSSCC.Items.Add(New ListItem("NA", 0))
            ddlRateHSC.Items.Add(New ListItem("NA", 0))
            ddlRateDiploma.Items.Add(New ListItem("NA", 0))
            ddlRateGrad.Items.Add(New ListItem("NA", 0))
            ddlRatePG.Items.Add(New ListItem("NA", 0))
            ddlRateSSCC.SelectedValue = 0
            ddlRateHSC.SelectedValue = 0
            ddlRateDiploma.SelectedValue = 0
            ddlRateGrad.SelectedValue = 0
            ddlRatePG.SelectedValue = 0
            Exit Sub
        End If
        Response.Redirect("gatepassPrint.aspx?mode=admitcard")
    End Sub

    Private Sub ddlReportPhase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlReportPhase.SelectedIndexChanged
        ddlReportJobID.DataSource = getDBTable("select jobid, post from careers_jobs where phase = '" & ddlReportPhase.SelectedValue & "' and del = 0", "appsdb")
        ddlReportJobID.DataBind()
        ddlReportJobID.Items.Add(New ListItem("All Post", "%"))
        ddlReportJobID.SelectedValue = "%"
        loadDPR()
    End Sub

    Private Sub ddlPostPhase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPostPhase.SelectedIndexChanged
        SqlDataSource2.SelectParameters("phase").DefaultValue = ddlPostPhase.SelectedValue.ToString

    End Sub

    Private Sub ddlAdminPhase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAdminPhase.SelectedIndexChanged
        ddlAdminJob.DataSource = getDBTable("select jobid, post from careers_jobs where phase = '" & ddlAdminPhase.SelectedValue & "' and del = 0", "appsdb")
        ddlAdminJob.DataBind()
        ddlAdminJob.Items.Add(New ListItem("Show All","%"))
        loadApprove()
    End Sub

    Private Sub ddlAdminJob_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAdminJob.SelectedIndexChanged
        loadApprove()
    End Sub

    Private Sub rblAdminStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblAdminStatus.SelectedIndexChanged
        loadApprove()
        btnSMS.Enabled = False
        btnEmail.Enabled = False
        btnIntSlot.Enabled = False
        If rblAdminStatus.SelectedValue = "applied" Then
            btnAproveBulk.Text = "Qualify Marked Candidates for Written Exam"
        ElseIf rblAdminStatus.SelectedValue = "written" Then
            btnAproveBulk.Text = "Qualify Marked Candidates for Interview"
            btnSMS.Enabled = True
            btnEmail.Enabled = True
            txtSMS.Text = "Dear r(name)" & vbCrLf & "  Your application r(appid) for the post of r(post) is shortlisted for Written Test Examination of BIFPCL. " & vbCrLf & " Please visit career section of BIFPCL website to download the Admit Card.  " & vbCrLf & " Regards, Team-HR , BIFPCL "
            txtEmail.Text = "Dear r(name),<br/> <br/>   Your application r(appid) for the post of  r(post) is shortlisted for Written Test Examination of BIFPCL. <br/> Please visit career section of BIFPCL website to download the Admit Card.  <br/>  Regards,<br/>  Team-HR , BIFPCL " &
                "<br/> <br/> link --->  Visit BIFPCL website (www.bifpcl.com). (or Check SMS)" &
"<br/> <br/> After opening fill the following details in the fields mentioned: " &
"<br/> a) UNIQUE APPLICATION ID" &
"<br/> b) YOUR DATE OF BIRTH ( As mentioned in the application)" &
"<br/> Click on Submit Button & Download. " &
"<br/> Please refer to the instructions on the admit card before appearing for the Written Test Examination."
        ElseIf rblAdminStatus.SelectedValue = "interview" Then
            btnIntSlot.Enabled = True
            btnAproveBulk.Text = "Qualify Marked Candidates for Joining"
            btnSMS.Enabled = True
            btnEmail.Enabled = True
            txtSMS.Text = "Dear r(name)" & vbCrLf & "   Based on your Written-Test Examination Results, your application r(appid) is shortlisted  for the Viva Voce for the post of r(post) of BIFPCL. " & vbCrLf & " Please visit career section of BIFPCL website to download the Admit Card.  " & vbCrLf & " Regards,  Team-HR , BIFPCL "
            txtEmail.Text = "Dear  r(name),<br/> <br/>   Based on your Written-Test Examination Results, your application r(appid) is shortlisted  for the Viva Voce for the post of  r(post)  of BIFPCL. <br/> Please visit career section of BIFPCL website to download the Admit Card.  <br/>  Regards,<br/>  Team-HR , BIFPCL " &
                "<br/> <br/> link --->  Visit BIFPCL website (www.bifpcl.com). (or Check SMS)" &
"<br/> <br/> After opening fill the following details in the fields mentioned: " &
"<br/> a) UNIQUE APPLICATION ID" &
"<br/> b) YOUR DATE OF BIRTH ( As mentioned in the application)" &
"<br/> Click on Submit Button & Download. Watch help video <a href='https://youtu.be/BI0AoksFNko'>Click Here</a> " &
"<br/> Please refer to the instructions on the admit card before appearing for the VIVA VOCE."
        ElseIf rblAdminStatus.SelectedValue = "selected" Then
            btnAproveBulk.Text = "No Action"
            btnSMS.Enabled = True
            btnEmail.Enabled = True
            txtSMS.Text = "Dear r(name)" & vbCrLf & "    Congratulations !!Your Candidature with Application ID  r(appid) for post  r(post) is selected to be part of Team-BIFPCL.  " & vbCrLf & " Details shall be sent on Email.  " & vbCrLf & " Regards, Team-HR , BIFPCL "
            txtEmail.Text = "Dear  r(name),<br/> <br/>   Congratulations !!Your Candidature with Application ID  r(appid) for post  r(post) is selected to be part of Team-BIFPCL. <br/>  Regards,<br/>  Team-HR , BIFPCL " &
                "Please check your e-mail for Offer of Employment and other details which will be sent soon.<br/> <br/> link --->  Visit BIFPCL website (www.bifpcl.com). (or Check SMS)" &
"<br/> <br/> After opening fill the following details in the fields mentioned: " &
"<br/> a) UNIQUE APPLICATION ID" &
"<br/> b) YOUR DATE OF BIRTH ( As mentioned in the application)" &
"<br/> Click on Submit Button. Watch help video <a href='https://youtu.be/BI0AoksFNko'>Click Here</a> "
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
    Private Sub btnIntSlot_Click(sender As Object, e As EventArgs) Handles btnIntSlot.Click
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

        Dim q = "update careers_application set venue_i = '" & txtIntSlotLoc.Text.Replace("'", "") & "',venue_i_dt = '" & txtIntSlotdate.Text.Replace("'", "") & "',venue_i_time = '" & ddlIntSltNumber.SelectedValue.ToString & "',slot = '" & ddlIntSltNumber.SelectedIndex + 1 & "' , log =  '> interview slot assigned ' || ifnull(log,'') where aid in(" & uids & ")"
        Dim ret = executeDB(q, "appsdb")
        If Not ret.Contains("error") Then
            msg = msg & "Action Done for  " & i & " no of Candidates. " & "" & " for " & uids ' <a href=gatepass.aspx?mode=approve>Click here to approve again</a>"
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
    Private Sub btnSMS_Click(sender As Object, e As EventArgs) Handles btnSMS.Click
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
        msg = i & " records to be used. "
        uids = uids & " 0"
        lbApprovePass.Text = msg & uids

        Dim q = " select  appid ,  post, rollno , salute || ' ' || name as name ,Sex , cell,email   from careers_application where aid in(" & uids & ")"
        Dim dt = dbOp.getDBTable(q, "appsdb")
        Dim totalID = dt.Rows.Count
        If totalID < 1 Then

            lbApprovePass.Text = "No Records found for requested ID load failed.." '& IDcommaseparated
            Exit Sub
        End If
        Dim m = ""
        For Each r In dt.Rows
            ' Dim msg = "Dear Candidate,  Your application for the post of " & r("post") & " is shortlisted for Viva Voce of BIFPCL. Please click on the following link http://tiny.cc/bifpcl to download your Admit Card.   Regards, Team-HR,BIFPCL"
            Dim message = txtSMS.Text.Replace("r(post)", r("post").ToString).Replace("r(name)", r("name").ToString).Replace("r(appid)", r("appid").ToString)
            Dim cell = r("cell").ToString
            Dim result = JustSendSMSBIFPCL(cell, message)
            m = m & cell & " " & message & " " & result & "<br/>"
            ' Exit For
        Next
        lbApprovePass.Text = "SMS Status <br/>" & msg & m
    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
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
        msg = i & " records to be used. "
        uids = uids & " 0"
        lbApprovePass.Text = msg & uids

        Dim q = " select  appid ,  post, rollno , salute || ' ' || name as name ,Sex , cell,email   from careers_application where aid in(" & uids & ")"
        Dim dt = dbOp.getDBTable(q, "appsdb")
        Dim totalID = dt.Rows.Count
        If totalID < 1 Then

            lbApprovePass.Text = "No Records found for requested ID load failed.." '& IDcommaseparated
            Exit Sub
        End If
        Dim m = ""
        For Each r In dt.Rows
            ' Dim msg = "Dear Candidate,  Your application for the post of " & r("post") & " is shortlisted for Viva Voce of BIFPCL. Please click on the following link http://tiny.cc/bifpcl to download your Admit Card.   Regards, Team-HR,BIFPCL"
            Dim message = txtEmail.Text.Replace("r(post)", r("post").ToString).Replace("r(name)", r("name").ToString).Replace("r(appid)", r("appid").ToString)
            Dim mailto = r("email")
            Dim mailcc = "help@bifpcl.com"
            Dim result = SendEmail("admin@bifpcl.com", mailto, mailcc, "", "BIFPCL Recruitment Update: " & r("name"), message, "", "", "admin@bifpcl.com", "Bifpcl&123")
            m = m & mailto & ", " & " " & result & "<br/>" '& message
        Next
        lbApprovePass.Text = "Email Success <br/>" & msg & m
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
        Dim q = "update careers_var set updates = '" & txtUpdates.Text.Replace("'", "") & "', " &
            "opport = '" & txtOpo.Text.Replace("'", "") & "', " &
              "howto = '" & txtHowto.Text.Replace("'", "") & "', " &
               "tnc = '" & txtTnC.Text.Replace("'", "") & "', " &
                "locked = '" & rblPageLock.SelectedValue & "' where 1"

        Dim ret = executeDB(q, "appsdb")
        If ret = "ok" Then
            btnVar_Submit.Text = "Record updated..."
            btnVar_Submit.Enabled = False
        End If
        'lbApprovePass.Text = q
    End Sub

    Private Sub btnAssignRollno_Click(sender As Object, e As EventArgs) Handles btnAssignRollno.Click
        If String.IsNullOrEmpty(txtRollno.Text) Then
            divMsgAdmin.InnerHtml = "Roll no blank"
            Exit Sub

        End If
        Dim q = "select distinct  aid from careers_application where phase = '" & ddlAdminPhase.SelectedValue & "' and jobid = '" & ddlAdminJob.SelectedValue & "' and stage = '" & rblAdminStatus.SelectedValue & "' group by appid"
        Dim mydt = getDBTable(q, "appsdb")
        Dim rollno = ""
        Dim i = 0
        Dim msg = ""
        Dim err = ""
        For Each a In mydt.Rows
            i = i + 1
            rollno = txtRollno.Text & i.ToString.PadLeft(4, "0")
            q = "update careers_application set rollno = '" & rollno & "' where aid = " & a(0).ToString
            Dim ret = executeDB(q, "appsdb")
            If ret = "ok" Then
                msg = msg & rollno & ", "
            Else
                err = err & ret & rollno & ", Quitting after " & a(0).ToString
                Exit For
            End If
        Next
        divMsgAdmin.InnerHtml = "Showing " & mydt.Rows.Count & " records for " & rblAdminStatus.SelectedItem.Text & " Candidate in  " & ddlAdminJob.SelectedItem.Text & " Success " & msg & " error " & err

    End Sub

    Private Sub btnRatingAppidLoad_Click(sender As Object, e As EventArgs) Handles btnRatingAppidLoad.Click
        Dim appid = getDBsingle("select appid from careers_application where appid = '" & txtRatingAppid.Text & "' or rollno = '" & txtRatingAppid.Text & "' and phase = '" & ddlRatingPhase.SelectedValue & "' limit 1", "appsdb")
        If appid.Contains("Error") Then
            lbRatingMsg.Text = "No Appid or Rollnumber found in " & ddlRatingPhase.SelectedValue
            divRatingProfile.InnerHtml = ""
            btnRatingUpdate.Enabled = False
            btnInterviewUpdate.Enabled = False
            Exit Sub
        End If
        btnRatingUpdate.Enabled = True
        btnInterviewUpdate.Enabled = True
        Session("rateAppID") = appid
        loadRating()
    End Sub

    Private Sub btnRatingNext_Click(sender As Object, e As EventArgs) Handles btnRatingNext.Click
        nextRecord()

    End Sub
    Sub nextRecord()
        Dim q = "select appid from careers_application where phase = '" & ddlRatingPhase.SelectedValue & "' and stage = '" & rblRatingStatus.SelectedValue & "' and jobid = '" & ddlRatingJobs.SelectedValue & "' and aid > (select aid from careers_application where appid = " & Session("rateAppID") & " and stage = '" & rblRatingStatus.SelectedValue & "'  limit 1) order by aid asc limit 1"
        Dim appid = getDBsingle(q, "appsdb")
        If appid.Contains("Error") Then
            divRatingProfile.InnerHtml = "<b><code>No application ID  found   </code></b>"
            btnRatingUpdate.Enabled = False
            lbRatingMsg.Text = "Unable to load next application for phase = " & ddlRatingPhase.SelectedValue & " and jobid = " & ddlRatingJobs.SelectedValue & ". Check filters"
        Else
            Session("rateAppID") = appid
            ' btnRatingPrev.Text = q
            loadRating()
        End If
    End Sub

    Private Sub btnRatingPrev_Click(sender As Object, e As EventArgs) Handles btnRatingPrev.Click
        Dim q = "select appid from careers_application where phase = '" & ddlRatingPhase.SelectedValue & "' and stage = '" & rblRatingStatus.SelectedValue & "' and jobid = '" & ddlRatingJobs.SelectedValue & "' and aid < (select aid from careers_application where appid = " & Session("rateAppID") & " and stage = '" & rblRatingStatus.SelectedValue & "'  limit 1)  order by aid desc limit 1"
        Dim appid = getDBsingle(q, "appsdb")
        If appid.Contains("Error") Then
            divRatingProfile.InnerHtml = "<b><code>No application ID  found   </code></b>"
            btnRatingUpdate.Enabled = False
            lbRatingMsg.Text = "Unable to load next application for phase = " & ddlRatingPhase.SelectedValue & " and jobid = " & ddlRatingJobs.SelectedValue & ". Check filters"
        Else
            Session("rateAppID") = appid
            '  btnRatingPrev.Text = q
            loadRating()
        End If
    End Sub
    Private Sub btnInterviewUpdate_Click(sender As Object, e As EventArgs) Handles btnInterviewUpdate.Click
        If String.IsNullOrEmpty(txtI1a.Text) Or String.IsNullOrEmpty(txtI1B.Text) Or String.IsNullOrEmpty(txtI1C.Text) Or String.IsNullOrEmpty(txtI1D.Text) Or String.IsNullOrEmpty(txtI2a.Text) Or String.IsNullOrEmpty(txtI2B.Text) Or String.IsNullOrEmpty(txtI2C.Text) Or String.IsNullOrEmpty(txtI2D.Text) Or String.IsNullOrEmpty(txtI3a.Text) Or String.IsNullOrEmpty(txtI3B.Text) Or String.IsNullOrEmpty(txtI3C.Text) Or String.IsNullOrEmpty(txtI3D.Text) Then
            lbRatingMsg.Text = "Some rating is blank. Please enter 0."
            Exit Sub
        End If
        ''try to get double value
        Dim i1a = 0
        Dim i1b = 0
        Dim i1c = 0
        Dim i1d = 0
        Dim i2a = 0
        Dim i2b = 0
        Dim i2c = 0
        Dim i2d = 0
        Dim i3a = 0
        Dim i3b = 0
        Dim i3c = 0
        Dim i3d = 0
        Dim i4a = 0
        Dim i4b = 0
        Dim i4c = 0
        Dim i4d = 0
        Dim i5a = 0
        Dim i5b = 0
        Dim i5c = 0
        Dim i5d = 0
        Try
            i1a = Int32.Parse(txtI1a.Text)
            i1b = Int32.Parse(txtI1B.Text)
            i1c = Int32.Parse(txtI1C.Text)
            i1d = Int32.Parse(txtI1D.Text)
            i2a = Int32.Parse(txtI2a.Text)
            i2b = Int32.Parse(txtI2B.Text)
            i2c = Int32.Parse(txtI2C.Text)
            i2d = Int32.Parse(txtI2D.Text)
            i3a = Int32.Parse(txtI3a.Text)
            i3b = Int32.Parse(txtI3B.Text)
            i3c = Int32.Parse(txtI3C.Text)
            i3d = Int32.Parse(txtI3D.Text)
            i4a = Int32.Parse(txtI4a.Text)
            i4b = Int32.Parse(txtI4B.Text)
            i4c = Int32.Parse(txtI4C.Text)
            i4d = Int32.Parse(txtI4D.Text)
            i5a = Int32.Parse(txtI5a.Text)
            i5b = Int32.Parse(txtI5B.Text)
            i5c = Int32.Parse(txtI5C.Text)
            i5d = Int32.Parse(txtI5D.Text)
        Catch ex As Exception
            lbMsgInterviewUpdate.Text = "Wrong data somewhere."
            Exit Sub
        End Try

        lbMsgInterviewUpdate.Text = "All data is valid to save."
        Dim q = "update careers_application set i1a = " & i1a & ",i1b=" & i1b & ",i1c=" & i1c & ",i1d=" & i1d & ", i2a=" & i2a & ",i2b=" & i2b & ",i2c=" & i2c & ",i2d=" & i2d & ", i3a=" & i3a & ",i3b=" & i3b & ",i3c=" & i3c & ",i3d=" & i3d & ", I4a=" & i4a & ",I4b=" & i4b & ",I4c=" & i4c & ",I4d=" & i4d & " , I5a=" & i5a & ",I5b=" & i5b & ",I5c=" & i5c & ",I5d=" & i5d & " where appid = '" & Session("rateAppID") & "'"
        Dim ret = executeDB(q, "appsdb")
        If ret.Contains("Error") Then
            lbMsgInterviewUpdate.Text = "Unable toupdate interview marks." '& ret
        Else
            lbMsgInterviewUpdate.Text = "Candidate interview marks updated. Load Another."
        End If
    End Sub
    Private Sub btnRatingUpdate_Click(sender As Object, e As EventArgs) Handles btnRatingUpdate.Click
        If String.IsNullOrEmpty(txtRateSSC.Text) Or String.IsNullOrEmpty(txtRateHSC.Text) Or String.IsNullOrEmpty(txtRateGrad.Text) Or String.IsNullOrEmpty(txtRatePG.Text) Or String.IsNullOrEmpty(txtRateDiploma.Text) Then
            lbRatingMsg.Text = "Some rating is blank. Please enter 0."
            Exit Sub
        End If
        ''try to get double value
        Dim ssc = 0.0
        Dim hsc = 0.0
        Dim grad = 0.0
        Dim pg = 0.0
        Dim diploma = 0.0
        Try
            ssc = Double.Parse(txtRateSSC.Text)
        Catch ex As Exception
            lbRatingMsg.Text = "Wrong data in SSC."
            Exit Sub
        End Try
        Try
            hsc = Double.Parse(txtRateHSC.Text)
        Catch ex As Exception
            lbRatingMsg.Text = "Wrong data in HSC."
            Exit Sub
        End Try
        Try
            grad = Double.Parse(txtRateGrad.Text)
        Catch ex As Exception
            lbRatingMsg.Text = "Wrong data in Graduation."
            Exit Sub
        End Try
        Try
            pg = Double.Parse(txtRatePG.Text)
        Catch ex As Exception
            lbRatingMsg.Text = "Wrong data in Post Graduation."
            Exit Sub
        End Try
        Try
            diploma = Double.Parse(txtRateDiploma.Text)
        Catch ex As Exception
            lbRatingMsg.Text = "Wrong data in Diploma."
            Exit Sub
        End Try
        lbRatingMsg.Text = "All data is valid to save."
        If ssc > 5 Or hsc > 5 Or grad > 4 Or pg > 4 Or diploma > 5 Then
            lbRatingMsg.Text = "Rating is higher somewhere. Please check."
            Exit Sub
        End If
        ''' Insert data now
        ''' 
        Dim q = "update careers_application set ratessc = " & ssc & " , ratehsc =" & hsc & " , rategrad = " & grad & ", ratepg =" & pg & " , ratediploma = " & diploma & " where appid = '" & Session("rateAppID") & "'"
        Dim ret = executeDB(q, "appsdb")
        If ret = "ok" Then
            lbRatingMsg.Text = "Rating is updated."
            '' move to next record
            nextRecord()
        Else
            lbRatingMsg.Text = "Unable to updated." & ret
        End If
    End Sub

    Private Sub btnRatingPrint_Click(sender As Object, e As EventArgs) Handles btnRatingPrint.Click
        'Response.Redirect("gatepassPrint.aspx?mode=rating&stage=interview&phase=" & ddlRatingPhase.SelectedValue & "&appid=" & txtRatingAppid.Text)
        Response.Redirect("gatepassPrint.aspx?mode=rating3int&phase=" & ddlRatingPhase.SelectedValue & "&dt=%&tm=%&appid=" & txtRatingAppid.Text)
    End Sub

    Private Sub btnRatingPrintAll_Click(sender As Object, e As EventArgs) Handles btnRatingPrintAll.Click
        'Response.Redirect("gatepassPrint.aspx?mode=rating&stage=interview&phase=" & ddlRatingPhase.SelectedValue)
        Response.Redirect("gatepassPrint.aspx?mode=rating3int&phase=" & ddlRatingPhase.SelectedValue & "&dt=%&tm=%")
    End Sub

    Private Sub btnAdmitSinglePrint_Click(sender As Object, e As EventArgs) Handles btnAdmitSinglePrint.Click
        Session("jobAdmitID") = Trim(txtRatingAppid.Text.Replace("'", ""))
        Session("stageAdmitID") = Trim(rblRatingStatus.SelectedValue.ToString.Replace("'", ""))
        Response.Redirect("gatepassPrint.aspx?mode=admitcard")
    End Sub

    Private Sub rblRatingStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblRatingStatus.SelectedIndexChanged
        Session("rateAppID") = getDBsingle("select appid from careers_application where phase = '" & ddlRatingPhase.SelectedValue & "' and jobid = '" & ddlRatingJobs.SelectedValue & "'  and stage = '" & rblRatingStatus.SelectedValue & "' limit 1", "appsdb")
        loadRating()
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrEmpty(txtEid.Text) Then
            lbLogin.Text = "Please enter your 6 digit PIN"
            Exit Sub
        End If
        If checkID(txtEid.Text.Replace("'", "")) Then
            Session("intDashboard") = Left(txtEid.Text, 2)
            executeDB("insert into login (eid, log, logintime) values (0, 'HR Career Interview Dashboard Page Access by " & Session("intDashboard").ToString & " : at " & Now.ToString() & " -- " & Request.UserHostAddress & " ', current_timestamp)", "logdb")

            Response.Redirect("hrCareer.aspx?mode=intDashboard")
        Else
            lbLogin.Text = "Please enter your 6 digit PIN"
            Exit Sub

        End If
    End Sub
    Function checkID(ByVal eid As String) As Boolean
        If eid = "i15732" Or eid = "i21973" Or eid = "i32044" Or eid = "i47602" Or eid = "i51760" Then
            Return True

        Else
            Return False
        End If
    End Function

    Private Sub ddlIntDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlIntDate.SelectedIndexChanged
        refreshCandidate()
    End Sub

    Private Sub ddlIntSlot_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlIntSlot.SelectedIndexChanged
        refreshCandidate()
    End Sub

    Private Sub ddlIntCandidate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlIntCandidate.SelectedIndexChanged
        divCandProfile.InnerHtml = loadRatingInterview(ddlIntCandidate.SelectedValue)
        btnIntAssign.Text = "Send " & ddlIntCandidate.SelectedItem.Text & " to Interview Room."
    End Sub

    Private Sub btnIntAssign_Click(sender As Object, e As EventArgs) Handles btnIntAssign.Click
        Dim q = "replace into career_int (last_updated, appid,rollno) values (current_timestamp,'" & ddlIntCandidate.SelectedValue & "','" & ddlIntCandidate.SelectedItem.Text & "')"
        Dim ret = executeDB(q, "appsdb")
        If ret.Contains("Error") Then
            lbIntConduct.Text = "Candidate already scheduled." '& ret
        Else
            lbIntConduct.Text = "Candidate has been queued."
            refreshCandidate()
        End If
    End Sub

    Private Sub btnCandRefresh_Click(sender As Object, e As EventArgs) Handles btnCandRefresh.Click
        refreshCandidate()
    End Sub

    Private Sub rblIntA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblIntA.SelectedIndexChanged
        calculateVivaVoce()
    End Sub

    Private Sub rblIntB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblIntB.SelectedIndexChanged
        calculateVivaVoce()
    End Sub

    Private Sub rblIntC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblIntC.SelectedIndexChanged
        calculateVivaVoce()
    End Sub

    Private Sub rblIntD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblIntD.SelectedIndexChanged
        calculateVivaVoce()
    End Sub
    Sub calculateVivaVoce()
        If lbIntAppid.Text = "0" Then Exit Sub
        '' load total marks
        Dim q = "select ratessc, ratehsc,rategrad,ratepg,ratediploma  from careers_application where  appid = '" & lbIntAppid.Text & "' and stage = 'interview'  limit 1"

        Dim dt = getDBTable(q, "appsdb")
        If dt.Rows.Count = 0 Then
            lbIntError.Text = "No data " & q
            Exit Sub
        End If
        Dim ratessc = If(IsDBNull(dt.Rows(0)("ratessc")), 0.0, Double.Parse(dt.Rows(0)("ratessc").ToString))
        Dim ratehsc = If(IsDBNull(dt.Rows(0)("ratehsc")), 0.0, Double.Parse(dt.Rows(0)("ratehsc").ToString))
        Dim rategrad = If(IsDBNull(dt.Rows(0)("rategrad")), 0.0, Double.Parse(dt.Rows(0)("rategrad").ToString))
        Dim ratepg = If(IsDBNull(dt.Rows(0)("ratepg")), 0.0, Double.Parse(dt.Rows(0)("ratepg").ToString))
        Dim ratediploma = If(IsDBNull(dt.Rows(0)("ratediploma")), 0.0, Double.Parse(dt.Rows(0)("ratediploma").ToString))
        Dim hscOrDip = ratehsc
        If ratehsc = 0 Then hscOrDip = Math.Round(ratediploma * 1.25, 2)
        Dim totalEd = Math.Round(ratessc + hscOrDip + (1.25 * rategrad), 2)
        lbIntEd.Text = totalEd.ToString

        Dim a = 0
        Dim b = 0
        Dim c = 0
        Dim d = 0

        Int32.TryParse(rblIntA.SelectedValue, a)
        Int32.TryParse(rblIntB.SelectedValue, b)
        Int32.TryParse(rblIntC.SelectedValue, c)
        Int32.TryParse(rblIntD.SelectedValue, d)

        ' Int32.TryParse(lbIntEd.Text, totled)
        Dim total = a + b + c + d
        lbIntVivavoce.Text = total.ToString
        lbIntTotal.Text = (total + totalEd).ToString
    End Sub

    Private Sub btnIntSubmit_Click(sender As Object, e As EventArgs) Handles btnIntSubmit.Click
        If Session("intDashboard") Is Nothing Then Response.Redirect("hrCareer.aspx?mode=intDashboard")
        If rblIntA.SelectedIndex < 0 Then
            lbIntVivavoce.Text = "Marks for point A not given."
            Exit Sub
        End If
        If rblIntB.SelectedIndex < 0 Then
            lbIntVivavoce.Text = "Marks for point B not given."
            Exit Sub
        End If
        If rblIntC.SelectedIndex < 0 Then
            lbIntVivavoce.Text = "Marks for point C not given."
            Exit Sub
        End If
        If rblIntD.SelectedIndex < 0 Then
            lbIntVivavoce.Text = "Marks for point D not given."
            Exit Sub
        End If
        '' All is ok
        Dim int = lbIntName.Text
        Dim q = "update careers_application set " & int & "a = '" & rblIntA.SelectedValue & "',  " & int & "b = '" & rblIntB.SelectedValue & "',  " & int & "c = '" & rblIntC.SelectedValue & "',  " & int & "d = '" & rblIntD.SelectedValue & "',  " & int & "rem = '" & txtIntRemark.Text.Replace("'", "") & "' where appid = '" & lbIntAppid.Text & "'"
        Dim ret = executeDB(q, "appsdb")
        If ret = "ok" Then
            '' move to next record
            'Now update interview slot
            q = "update career_int set " & int & " = current_timestamp where appid = '" & lbIntAppid.Text & "'"
            ret = executeDB(q, "appsdb")
            If ret = "ok" Then
                Response.Redirect("hrCareer.aspx?mode=intDashboard")
            Else
                lbError.Text = "Viva voce marks updated but interview slot failed to update."
            End If
        Else
            lbError.Text = "Viva voce marks not updated."
        End If
    End Sub

    Private Sub btnIntSignOut_Click(sender As Object, e As EventArgs) Handles btnIntSignOut.Click
        Session.Clear()
        Session.Abandon()
        Response.Redirect("hrCareer.aspx?mode=intDashboard")
    End Sub

    Private Sub btnCandRatingPring_Click(sender As Object, e As EventArgs) Handles btnCandRatingPring.Click
        Response.Redirect("gatepassPrint.aspx?mode=rating3int&phase=Phase2&dt=" & ddlIntDate.SelectedValue & "&tm=" & ddlIntSlot.SelectedValue)
    End Sub

    Private Sub btnIntAbsent_Click(sender As Object, e As EventArgs) Handles btnIntAbsent.Click
        Dim q = "update careers_application set i1a = 0,i1b=0,i1c=0,i1d=0, i1rem='absent', i2a=0,i2b=0,i2c=0,i2d=0, i2rem = 'absent' , i3a=0,i3b=0,i3c=0,i3d=0, i3rem='absent', i4a=0,i4b=0,i4c=0,i4d=0, i4rem='absent', i5a=0,i5b=0,i5c=0,i5d=0, i5rem='absent' where appid = '" & ddlIntCandidate.SelectedValue & "'"
        Dim ret = executeDB(q, "appsdb")
        If ret.Contains("Error") Then
            lbIntConduct.Text = "Unable to mark absent." '& ret
        Else
            lbIntConduct.Text = "Candidate has been marked absent. Interviewer marks deleted(if any)"
            refreshCandidate()
        End If
    End Sub

    Private Sub btnNewSlot_Click(sender As Object, e As EventArgs) Handles btnNewSlot.Click
        If String.IsNullOrEmpty(txtNewIntDate.Text) Then
            lbIntConduct.Text = "Enter date"
            Exit Sub
        End If
        Try
            Dim dob = DateTime.ParseExact(txtNewIntDate.Text, "dd.M.yyyy", Nothing)

            Dim q = "update careers_application set venue_i_dt = '" & dob.ToString("yyyy-MM-dd") & "', venue_i_time = '" & ddlNewIntSlot.SelectedValue & "', slot = " & (ddlNewIntSlot.SelectedIndex + 1).ToString & "  where appid = '" & ddlIntCandidate.SelectedValue & "'"
            Dim ret = executeDB(q, "appsdb")
            If ret.Contains("Error") Then
                lbIntConduct.Text = "Unable to update slot." '& ret
            Else
                lbIntConduct.Text = "Candidate slot has been changed."
                refreshCandidate()
            End If
        Catch ex As Exception
            lbIntConduct.Text = "Enter date in dd.mm.yyyy"
        End Try
    End Sub

    Private Sub btnLiveRefresh_Click(sender As Object, e As EventArgs) Handles btnLiveRefresh.Click
        refreshLive()

    End Sub

    Private Sub ddlLiveIntDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlLiveIntDate.SelectedIndexChanged
        refreshLive()
    End Sub
    Sub exportExcelRating(ByVal phase As String, ByVal jobid As String)
        If jobid = "%" Then
            divReportMessage.InnerHtml = "Please select a post."
            Exit Sub
        End If
        Dim q = "select rollno, salute || ' ' || name as name ,marks, (i1a+i1b+i1c+i1d) as I1,  (i2a+i2b+i2c+i2d) as I2,  (i3a+i3b+i3c+i3d) as I3,(i4a+i4b+i4c+i4d) as I4,(i5a+i5b+i5c+i5d) as I5, ratessc, i1rem || ' '|| i2rem || ' ' || i4rem ' ' || i5rem ' ' || i3rem as remark, ratehsc,rategrad,ratepg,ratediploma from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'interview' and jobid = '" & jobid & "' and not i1a =0 and phase = '" & phase & "' order by venue_i_dt desc"
        Dim dt As DataTable = getDBTable(q, "appsdb")
        Using wb As New XLWorkbook()
            Dim ws = wb.Worksheets.Add("worksheet")
            If dt.Rows.Count = 0 Then
                divReportMessage.InnerHtml = "No records found"
                Exit Sub
            End If
            '' do calculation
            Dim finalDT As New System.Data.DataTable()
            finalDT.Columns.Add("SN")
            finalDT.Columns.Add("rollno")
            finalDT.Columns.Add("name")
            finalDT.Columns.Add("written")
            finalDT.Columns.Add("ed1")
            finalDT.Columns.Add("i1")
            finalDT.Columns.Add("t1")
            finalDT.Columns.Add("ed2")
            finalDT.Columns.Add("i2")
            finalDT.Columns.Add("t2")
            finalDT.Columns.Add("ed3")
            finalDT.Columns.Add("i3")
            finalDT.Columns.Add("t3")
            finalDT.Columns.Add("subtotal")
            finalDT.Columns.Add("avg")
            finalDT.Columns.Add("final")
            finalDT.Columns.Add("merit")
            finalDT.Columns.Add("remark")
            Dim sn = 1
            For Each r In dt.Rows
                Dim tmpRow = finalDT.NewRow
                Dim ratessc = If(IsDBNull(r("ratessc")), 0.0, Double.Parse(r("ratessc").ToString))
                Dim ratehsc = If(IsDBNull(r("ratehsc")), 0.0, Double.Parse(r("ratehsc").ToString))
                Dim rategrad = If(IsDBNull(r("rategrad")), 0.0, Double.Parse(r("rategrad").ToString))
                Dim ratepg = If(IsDBNull(r("ratepg")), 0.0, Double.Parse(r("ratepg").ToString))
                Dim ratediploma = If(IsDBNull(r("ratediploma")), 0.0, Double.Parse(r("ratediploma").ToString))
                Dim hscOrDip = ratehsc
                If ratehsc = 0 Then hscOrDip = ratediploma * 1.25
                Dim totalEd = Math.Round(ratessc + hscOrDip + (1.25 * rategrad), 2)
                tmpRow("ed1") = totalEd

                tmpRow("SN") = sn
                sn = sn + 1
                tmpRow("rollno") = r("rollno")
                tmpRow("name") = r("name")
                Dim written = If(IsDBNull(r("marks")), 0.0, Double.Parse(r("marks").ToString))
                tmpRow("written") = written
                tmpRow("ed1") = totalEd
                tmpRow("i1") = r("i1")
                Dim t1 = totalEd + If(IsDBNull(r("i1")), 0.0, Double.Parse(r("i1").ToString))
                tmpRow("t1") = t1
                tmpRow("ed2") = totalEd
                tmpRow("i2") = r("i2")
                Dim t2 = totalEd + If(IsDBNull(r("i2")), 0.0, Double.Parse(r("i2").ToString))
                tmpRow("t2") = t2
                tmpRow("ed3") = totalEd
                tmpRow("i3") = r("i3")
                Dim t3 = totalEd + If(IsDBNull(r("i3")), 0.0, Double.Parse(r("i3").ToString))
                tmpRow("t3") = t3
                Dim subtotal = t1 + t2 + t3
                tmpRow("subtotal") = subtotal
                Dim avg = Math.Round(subtotal / 3, 2)
                tmpRow("avg") = avg
                tmpRow("final") = (written / 2) + avg
                tmpRow("merit") = 1
                tmpRow("remark") = r("remark")
                finalDT.Rows.Add(tmpRow)
            Next
            finalDT.DefaultView.Sort = "final DESC"
            finalDT = finalDT.DefaultView.ToTable
            Dim m = 1
            For Each r In finalDT.Rows
                r("merit") = m
                m = m + 1
            Next
            ' Adding HeaderRow.
            Dim j = 1
            For Each column In finalDT.Columns
                ws.Cell(1, j).SetValue(column.ColumnName)
                j = j + 1
            Next
            Dim i = 0
            For Each r In finalDT.Rows
                For k As Integer = 0 To finalDT.Columns.Count - 1
                    ws.Cell((i + 2), k + 1).SetValue(r(k))

                    If r("merit").ToString().ToUpper() = "1" Then
                        ' Changing color to green.
                        ws.Cell((i + 2), k + 1).Style.Fill.BackgroundColor = XLColor.GreenPigment
                    ElseIf r("merit").ToString().ToUpper() = "2" Then
                        ' Changing color to green.
                        ws.Cell((i + 2), k + 1).Style.Fill.BackgroundColor = XLColor.Yellow
                    Else
                        ws.Cell((i + 2), k + 1).Style.Fill.BackgroundColor = XLColor.BrilliantRose
                    End If
                Next
                i = i + 1
            Next
            ' Adding DataRows.


            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=merit" + jobid + DateTime.Now.ToString("ddMMyyyy") + ".xlsx")
            Using MyMemoryStream As New MemoryStream()
                wb.SaveAs(MyMemoryStream)
                MyMemoryStream.WriteTo(Response.OutputStream)
                Response.Flush()
                Response.[End]()
            End Using
        End Using
    End Sub

    Private Sub ddlReportJobID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlReportJobID.SelectedIndexChanged
        loadDPR()
    End Sub

    Private Sub ddlRatingPhase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRatingPhase.SelectedIndexChanged
        ddlRatingJobs.DataSource = getDBTable("select jobid, post from careers_jobs where phase = '" & ddlRatingPhase.SelectedValue & "' and del = 0", "appsdb")
        ddlRatingJobs.DataBind()
        rblRatingStatus_SelectedIndexChanged(vbNull, EventArgs.Empty)

    End Sub

    Private Sub ddlRatingJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRatingJobs.SelectedIndexChanged
        rblRatingStatus_SelectedIndexChanged(vbNull, EventArgs.Empty)
    End Sub
End Class
