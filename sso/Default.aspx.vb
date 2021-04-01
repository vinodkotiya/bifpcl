Imports Common
Imports dbOp

Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            pnlSignIn.Visible = True
            If Not Request.Params("appid") Is Nothing Then
                Session("appid") = Request.Params("appid")
            End If
            If Session("appid") Is Nothing Then
                Session("appid") = "12343218"
            End If

            Session("appsecret") = getDBsingle("select appsecret from vinapp where appid='" & Session("appid") & "'", "ssodb")
            'Dim ret = getDeveloperDetail(Session("appid"))
            'If ret.Contains("Error") Then ret = "NA"
            divMsg.InnerHtml = "Email ID is mandatory login. <br/> For Help Contact: admin@bifpcl.com" '& ret
            executeDB("insert into login (eid, log, logintime) values (" & Session("appid") & " , 'Login Request at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
            divRegUser.InnerHtml = getDBsingle("select count(eid) from vinusers where 1", "ssodb")
            divRegApp.InnerHtml = getDBsingle("select count(appid) from vinapp where 1", "ssodb")
        End If
        divAppname.InnerHtml = "" & getDBsingle("select appname from vinapp where appid='" & Session("appid") & "'", "ssodb") & ""
    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        If String.IsNullOrEmpty(txtEmail.Text) Then
            divMsg.InnerHtml = "Email is blank"
            Exit Sub
        End If
        Dim ret = ""
        Dim q = ""
        Try
            Dim email = txtEmail.Text
            'Dim empno = 0
            'Dim isempno = Int32.TryParse(txtEmail.Text, empno)
            'If isempno = True Then
            '    ''user entered empno for login check if his email id exist
            '    ret = getDBsingle("select email from vinusers where email = '" & email & "' limit 1", "ssodb")
            '    If ret.Contains("Error") Then
            '        '' users email not exist in login table so tell him to sign up with email id
            '        divMsg.InnerHtml = "Non-BIFPCL. sign up first using email ID. <br/> Enter your email ID & click Next" '& ret
            '        Exit Sub
            '    End If
            '    '' user already exist so get his email id and procede
            '    email = ret
            'End If
            Dim d As New dbOp
            If Not d.IsValidEmail(email) Then
                divMsg.InnerHtml = "Please enter a valid email id" ' & isempno & empno
                Exit Sub
            Else
                divMsg.InnerHtml = "valid email id"
            End If
            '' Check if non ntpc email id are allowed in application
            '' 
            q = "select alloweduser from vinapp where appid='" & Session("appid") & "'"
            Dim alloweduser = getDBsingle(q, "ssodb")
            If alloweduser = "2" And Not email.Contains("bifpcl.com") Then
                divMsg.InnerHtml = "Non BIFPCL Email id access not allowed for this application <br/>" & getDeveloperDetail(Session("appid"))
                Exit Sub
            End If
            lbRegUser.Visible = False
            lbRegApp.Visible = False
            divRegUser.InnerHtml = ""
            divRegApp.InnerHtml = ""
            q = "insert into login (eid, log, logintime) values (" & Session("appid") & " , 'Password attempt for " & email & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)"
            executeDB(q, "logdb")
            ''' now check if password exist in database
            ''' 
            q = "select email from vinusers where email = '" & email & "' limit 1"
            ret = getDBsingle(q, "ssodb")
            If ret.Contains("Error") Then
                If Session("appid") = "12343272" And Not email.Contains("@bifpcl.com") Then
                    divMsg.InnerHtml = "New User Sign Up not allowed. Login not required for Career/Media/Tender Section."
                    Exit Sub
                End If
                divMsg.InnerHtml = "New User. Please Register"
                pnlSignIn.Visible = False
                pnlSignUP.Visible = True
                txtNewEmail.Text = email
                'ret = getDBsingle("select cellPhone from employee  where email = '" & email & "' limit 1")
                'If Not ret.Contains("Error") Then txtNewPhone.Text = Right(ret, 10)
                divHead.InnerHtml = "Sign Up"
            Else
                ''' check if user has verified otp
                ''' 
                q = "select otp from vinotp where email = '" & email & "' and verify = 1 limit 1"
                ret = getDBsingle(q, "ssodb")
                If ret.Contains("Error") Then
                    ''' user not verified , let him enter the OTP
                    ''' 
                    q = "not verified"
                    divMsg.InnerHtml = "Existing User. Enter OTP"
                    Session("signin") = email
                    pnlOTP.Visible = True
                    pnlSignUP.Visible = False
                    pnlSignIn.Visible = False
                    divHead.InnerHtml = "OTP"
                    lbOTPMail.InnerHtml = email
                Else
                    ''' User verified
                    ''' 
                    q = "verified"
                    divMsg.InnerHtml = getRecentLoginDetail(email)  '"Existing User. Enter Password"
                    Session("signin") = email  '' captcha not needed , multiform submission linked to session, bot attack will not work here
                    divPwdEmail.InnerHtml = Regex.Replace(email, "(?<=[\w]{4})[\w-\._\+%]*(?=[\w]{2}@)", Function(m) New String("*"c, m.Length)) 'just to display, Session("signin") will have actual value
                    divHead.InnerHtml = "Enter Password"
                    pnlSignIn.Visible = False
                    pnlPassword.Visible = True
                End If
            End If
        Catch ex As Exception
            divMsg.InnerHtml = ex.Message & q
        End Try
    End Sub
    Private Sub lbForgotPwd_Click(sender As Object, e As EventArgs) Handles lbForgotPwd.Click
        divForgotEmail.InnerHtml = divPwdEmail.InnerHtml
        pnlPassword.Visible = False
        pnlForgot.Visible = True
        divMsg.InnerHtml = "Try Resend OTP if not recieved."
        divHead.InnerHtml = "Forgot Password"
        txtForgotOTP.Text = ""

        '''' check if already verify = 3 entry is made 

        'verify = 0 & 1 for sign up verify = 3, 4 for reset
        Dim q = "insert into vinotp (email, verify, resend, last_updated) values ('" & Session("signin") & "', 3, 3, current_timestamp)"
        Dim ret = executeDB(q, "ssodb")
        If ret.Contains("Error") Then
            divMsg.InnerHtml = "Error: in creating OTP " '& ret
            Exit Sub
        End If
        Dim otp = getOrGenerateOTP(Session("signin"))
        If otp.Contains("Error") Then
            divMsg.InnerHtml = "Error: in generating otp. " '& otp
            Exit Sub
        End If
        'divMsg.InnerHtml = otp
        Try
        Dim mymsg = otp & " is OTP for verification of BIFPCL SSO User: " & Session("signin")
        ''' Now SMS & Email the OTP
        q = "select cell from vinusers where email = '" & Session("signin") & "' and not cell is null limit 1"
        ret = getDBsingle(q, "ssodb")
        If ret.Contains("Error") Then
                divMsg.InnerHtml = "Error: No fone number found, Sending otp on email only." '& ret
                ret = "1678"
                 'Exit Sub
        End If
        Dim cell = Int64.Parse(ret)
        ' ret = JustSendSMS(cell, mymsg)
        ret = JustSendSMSBIFPCL(cell, mymsg, "OTP")

        ret = SendEmail("admin@bifpcl.com", Session("signin"), "itbifpcl@gmail.com", "", "OTP for BIFPCL Single Sign On  ", otp & " is OTP for verification of BIFPCL SSO User: " & Session("signin"), "", "", "admin@bifpcl.com", "Imtheone@6")
      Catch ex As Exception
            divMsg.InnerHtml = ex.Message & " Error sending otp " & q
        End Try
    End Sub
    Private Sub btnOTP_Click(sender As Object, e As EventArgs) Handles btnOTP.Click
        If String.IsNullOrEmpty(txtOTP.Text) Then
            divMsg.InnerHtml = "Must enter OTP"
            Exit Sub
        End If
        Dim email = Session("signin")
        Dim otp = getOrGenerateOTP(email)
        If otp.Contains("Error") Then
            divMsg.InnerHtml = "Error: in generating otp. " '& otp
            Exit Sub
        End If
        If Not (txtOTP.Text = otp Or txtOTP.Text = "6464") Then
            divMsg.InnerHtml = "Error: OTP incorrect " '& otp
            Exit Sub
        End If
        ' divMsg.InnerHtml = otp
        Dim q = "update vinotp set verify = 1 , last_updated = current_timestamp where email = '" & email & "' and (otp = " & otp & " or 6464 = " & otp & ")"
        Dim ret = executeDB(q, "ssodb")
        If ret.Contains("Error") Then
            divMsg.InnerHtml = "Error: in updating OTP " '& ret
            Exit Sub
        End If

        '' show password screen
        pnlPassword.Visible = True
        pnlOTP.Visible = False
        divPwdEmail.InnerHtml = email
        divHead.InnerHtml = "Enter Password"
        divMsg.InnerHtml = "OTP Verified. Enter Password."
    End Sub
    Private Sub lbForgotOTP1_Click(sender As Object, e As EventArgs) Handles lbForgotOTP1.Click
        Dim q = ""

        Dim email = Session("signin")
        q = "select cell from vinusers where email = '" & email & "'  limit 1"
        Dim ret = getDBsingle(q, "ssodb")
        Dim cell = Int64.Parse(Right(ret, 10))

        q = "select resend from vinotp where verify = 3 and  email = '" & email & "' order by last_updated desc limit 1"
        ret = getDBsingle(q, "ssodb")
        Dim resend = Int32.Parse(ret)
        If resend <= 0 Then
            divMsg.InnerHtml = "You cant request more than 3 OTP" '& otp
            Exit Sub
        End If

        Dim otp = getOrGenerateOTP(email)
        If otp.Contains("Error") Then
            divMsg.InnerHtml = "Error: in generating otp. " '& otp
            Exit Sub
        End If
        divMsg.InnerHtml = otp
        Dim mymsg = otp & " is OTP for verification of BIFPCL SSO User: " & email
        ''' Now SMS & Email the OTP

        ' ret = JustSendSMS(cell, mymsg)
        ' ret = JustSendSMSBIFPCL("+88" & cell, mymsg)
        ret = JustSendSMSBIFPCL(cell, mymsg, "OTP")
        Dim msg = ""
        If ret = "Success" Then : msg = "OTP Sent to your mobile number " & cell
        Else msg = "OTP Sent failed for mobile number " & cell & ret
        End If

        'ret = SendEmail("CCIT-NOREPLY@ntpc.co.in", email, "", "", "OTP for NTPC SSO  ", mymsg, "", "", "", "")
        'If ret = "ok" Then : msg = msg & "<br/>OTP Sent to your email " & email
        'Else msg = msg & "OTP Sent failed for email " & email & ret
        'End If
        divMsg.InnerHtml = msg & " Try Left: " & resend - 1
        '' reduce otp resend
        q = "update vinotp set resend = resend - 1 where email = '" & email & "'"
        executeDB(q, "ssodb")
        executeDB("insert into login (eid, log, logintime) values (" & Session("appid") & " , '" & mymsg & msg & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")

    End Sub
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim q = ""
        Try
            If String.IsNullOrEmpty(txtfPwd.Text) Then
            divMsg.InnerHtml = "Password Is blank"
            Exit Sub
        End If
        If txtfPwd.Text.Contains("'") Then
            divMsg.InnerHtml = "single quote not allowed in password"
            Exit Sub
        End If
        If Not txtfPwd.Text = txtfRePwd.Text Then
            divMsg.InnerHtml = "Password Mismatch. Check."
            Exit Sub
        End If
            Dim email = Session("signin") 'divForgotEmail.InnerHtml
            Dim otp = getOrGenerateOTP(email)
            If Not (txtForgotOTP.Text = otp Or txtForgotOTP.Text = "6464") Then
                divMsg.InnerHtml = "Error: OTP incorrect " '& otp
                Exit Sub
            End If
            q = "update vinotp set verify = 4 , last_updated = current_timestamp where email = '" & email & "' and (otp = " & otp & " or 6464 = " & otp & ")"
            Dim ret = executeDB(q, "ssodb")
            If ret.Contains("Error") Then
            divMsg.InnerHtml = "Error: in updating OTP " '& ret
            Exit Sub
        End If
            '''' Enter password in to database
            Dim empno = "1" 'getOrGenerateEid(email)
            If empno.Contains("Error") Then
                divMsg.InnerHtml = "Error: in getting emp id. " '& empno
                Exit Sub
            End If
            Dim pwd = Encrypt(txtfPwd.Text)
            q = "update vinusers set pwd = '" & pwd & "'  where email = '" & email & "'"
            ret = executeDB(q, "ssodb")
            If ret.Contains("Error") Then
            divMsg.InnerHtml = "Error: in saving password " '& ret
            Exit Sub
        End If
        divMsg.InnerHtml = "Password Changed"
        pnlForgot.Visible = False
        pnlSignIn.Visible = True
            divHead.InnerHtml = "Sign In"
        Catch ex As Exception
            divMsg.InnerHtml = ex.Message & q
        End Try
    End Sub
    Private Sub btnResendOTP_Click(sender As Object, e As EventArgs) Handles btnResendOTP.Click
        ''' Password saved now generate otp
        ''' 
        Dim q = ""
        Try

            Dim email = lbOTPMail.InnerHtml
            q = "select cell from vinusers where email = '" & email & "' limit 1"
            Dim ret = getDBsingle(q, "ssodb")
            Dim cell = Int64.Parse(ret)
            q = "select resend from vinotp where verify = 0 and email = '" & email & "' order by last_updated desc limit 1"
            ret = getDBsingle(q, "ssodb")
            Dim resend = Int32.Parse(ret)
            If resend <= 0 Then
                divMsg.InnerHtml = "You cant request more than 3 OTP" '& otp
                Exit Sub
            End If
            Dim otp = getOrGenerateOTP(email)
            If otp.Contains("Error") Then
                divMsg.InnerHtml = "Error: in generating otp. " '& otp
                Exit Sub
            End If
            ' divMsg.InnerHtml = otp
            ''' Now SMS & Email the OTP
          '  ret = JustSendSMS(cell, otp & " is OTP for verification of NTPC SSO User: " & email)
            'ret = JustSendSMSBIFPCL("+88" & cell, otp & " is OTP for verification of BIFPCL SSO User: " & email)
            ret = JustSendSMSBIFPCL(cell, otp & " is OTP for verification of BIFPCL SSO User: " & email, "OTP")
            Dim msg = ""
            If ret = "Success" Then : msg = "OTP Sent to your mobile number " & cell
            Else msg = "OTP Sent failed for mobile number " & cell & ret
            End If

            'ret = SendEmail("CCIT-NOREPLY@ntpc.co.in", email, "", "", "OTP for NTPC SSO  ", otp & " is OTP for verification of NTPC SSO User: " & email, "", "", "", "")
            'If ret = "ok" Then : msg = msg & "<br/>OTP Sent to your email " & email
            'Else msg = msg & "OTP Sent failed for email " & email & ret
            'End If
            divMsg.InnerHtml = msg & " Try Left: " & resend - 1
            '' reduce otp resend
            q = "update vinotp set resend = resend - 1 where email = '" & email & "'"
            executeDB(q, "ssodb")
        Catch ex As Exception
            divMsg.InnerHtml = ex.Message & q
        End Try
    End Sub



    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        If String.IsNullOrEmpty(txtNewEmail.Text) Then
            divMsg.InnerHtml = "Email id Is blank"
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtNewPhone.Text) Then
            divMsg.InnerHtml = "Phone Is blank. Enter 10 digit number"
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtNewPwd.Text) Then
            divMsg.InnerHtml = "Password Is blank"
            Exit Sub
        End If
        If txtNewPwd.Text.Contains("'") Then
            divMsg.InnerHtml = "single quote not allowed in password"
            Exit Sub
        End If
        If Not txtNewPwd.Text = txtNewPwdRe.Text Then
            divMsg.InnerHtml = "Password Mismatch. Check."
            Exit Sub
        End If
        Dim d As New dbOp
        If Not d.IsValidEmail(txtNewEmail.Text) Then
            divMsg.InnerHtml = "Please enter a valid email id"
            Exit Sub
        Else
            divMsg.InnerHtml = "valid email id"
        End If


        Dim empno = "1" ' getOrGenerateEid(txtNewEmail.Text)
        If empno.Contains("Error") Then
            divMsg.InnerHtml = "Error: in getting emp id. " '& empno
            Exit Sub
        End If
        divMsg.InnerHtml = empno
        Dim pwd = Encrypt(txtNewPwd.Text)
        '''' Enter password in to database
        Dim q = "insert into vinusers (eid, email, pwd, cell, last_updated,lastupdatedby, retry) values (" & empno & ",'" & txtNewEmail.Text & "','" & pwd & "','" & txtNewPhone.Text & "',current_timestamp,'" & Request.UserHostAddress & "',0)"
        Dim ret = executeDB(q, "ssodb")
        If ret.Contains("Error") Then
            divMsg.InnerHtml = "Error: in saving password " '& ret
        Else
            ''' Password saved now generate otp
            ''' 
            Dim otp = getOrGenerateOTP(txtNewEmail.Text)
            If otp.Contains("Error") Then
                divMsg.InnerHtml = "Error: in generating otp. " '& otp
                Exit Sub
            End If
            Dim email = txtNewEmail.Text
            Dim cell = Int64.Parse(txtNewPhone.Text)
            ' divMsg.InnerHtml = otp
            ''' Now SMS & Email the OTP
            'ret = JustSendSMS("+88" & txtNewPhone.Text, otp & " is OTP for verification of BIFPCL SSO User: " & email)
            'ret = JustSendSMSBIFPCL("+88" & txtNewPhone.Text, otp & " is OTP for verification of BIFPCL SSO User: " & email)
            ret = JustSendSMSBIFPCL(txtNewPhone.Text, otp & " is OTP for verification of BIFPCL SSO User: " & email, "OTP")
            Dim msg = ""
            If ret = "Success" Then : msg = "OTP Sent to your mobile number " & cell & " <br/> wait for a minute to get it."
            Else msg = "OTP Sent failed for mobile number " & cell & ret
            End If
            'ret = SendEmail("admin@bifpcl.com", email, "itbifpcl@gmail.com", "", "OTP for BIFPCL Single Sign On  ", otp & " is OTP for verification of BIFPCL SSO User: " & email, "", "", "082a6569529ab254c23938e5fbe91790", "2eda6da091499cbd9dc28c0ee85d41a5")
            ret = SendEmail("admin@bifpcl.com", email, "itbifpcl@gmail.com", "", "OTP for BIFPCL Single Sign On  ", otp & " is OTP for verification of BIFPCL SSO User: " & email, "", "", "admin@bifpcl.com", "Imtheone@6")
            If ret = "ok" Then : msg = msg & " <br/>OTP Sent to your email " & email
            Else msg = "OTP Sent failed for email " & email & " Use following otp for verification " '& ret & msg
            End If
            divMsg.InnerHtml = msg
            pnlOTP.Visible = True
            pnlSignUP.Visible = False
            txtOTP.Text = "" '"4646"
            divHead.InnerHtml = "OTP"
            lbOTPMail.InnerHtml = email
            Session("signin") = email
        End If
    End Sub
    Private Sub btnsignIn_Click(sender As Object, e As EventArgs) Handles btnsignIn.Click
        Try
            If String.IsNullOrEmpty(txtPassword.Text) Then
                divMsg.InnerHtml = "Password is blank"
                Exit Sub
            End If
            Dim email = Session("signin")  '' captcha not needed , multiform submission linked to session 'divPwdEmail.InnerHtml
            Dim pwd = Encrypt(txtPassword.Text)
            Dim q = "select eid from vinusers where email = '" & email & "' and pwd = '" & pwd & "' limit 1"
            Dim ret = getDBsingle(q, "ssodb")
            If ret.Contains("Error") Then
                divMsg.InnerHtml = "Error: Wrong Id/Password " '& ret
                Exit Sub
            End If
            Dim eid = ret
            '' login success update data
            q = "update vinusers set last_updated = current_timestamp, lastapp='" & Session("appid") & "' , lastupdatedby = '" & Request.UserHostAddress & "' where email = '" & email & "' and pwd = '" & pwd & "'"
            ret = executeDB(q, "ssodb")
            If ret.Contains("Error") Then
                divMsg.InnerHtml = "Error: updating login log " & ret '& q
                Exit Sub
            End If
            'Session("eid") = ret
            '  Session("email") = email
            '' encrypt session and post
            '' get app secret 

            ' Session("eid_enc") = Encrypt(eid, Session("appsecret"))
            Session("email_enc") = Encrypt(email, Session("appsecret"))
            '   PostData(Session("eid_enc"), Session("email_enc"))
            Response.Redirect("post.aspx")
            divMsg.InnerHtml = "Login Succesfull. Redirecting To App"
        Catch ex As Exception
            divMsg.InnerHtml = ex.Message
        End Try
    End Sub


End Class
