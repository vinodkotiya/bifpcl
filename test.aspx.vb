Imports dbOp
Imports Common



Partial Class test
    Inherits System.Web.UI.Page

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = Encrypt("009382")
        Exit Sub
        Dim mydt = getDBTable("select distinct uid, name from biometric ", "hrdb")
        GridView1.DataSource = mydt
        GridView1.DataBind()

        Dim cdt = getDBTable("select  distinct id, name from contacts_New", "hrdb")
        Dim found = ""
        Dim count = 0
        For Each r In mydt.Rows
            For Each c In cdt.Rows
                If c(1).ToString.Contains(r(1).ToString) Then
                    found = found & c(1).ToString & " " & r(1).ToString & "<br/>"
                    count = count + 1
                    Dim q = "update contacts_New set bioid = " & r(0) & " where id=" & c(0)
                    executeDB(q, "hrdb")
                End If
            Next
        Next
        Label1.Text = found & count
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '   Exit Sub
        ' Dim result = JustSendSMSBIFPCL("01734760000,01678582832", "SMS Testing for BIFPCL Login OTP 34453" & Now.ToString, "OTP")
        'Dim email = "vinodkotiya@bifpcl.com"
        Dim result = JustSendSMSBIFPCL("1678582832", "SMS Testing for BIFPCL Login OTP 34453" & Now.ToString, "OTP")

        ' Button2.Text = SendEmail("admin@bifpcl.com", email, "itbifpcl@gmail.com", "", "OTP for BIFPCL SSO  ", "4566 is OTP for verification of NTPC SSO User: " & email, "", "", "082a6569529ab254c23938e5fbe91790", "2eda6da091499cbd9dc28c0ee85d41a5")
        'Dim i = result.IndexOf("api_response_message")
        'If i <> -1 Then
        '    i += 20
        '    Button2.Text = result.Substring(i, 15)

        'End If
        Label1.Text = result '& i '& words(i + 1)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Exit Sub
        Dim today As Date = Date.Today
        While today.DayOfWeek <> DayOfWeek.Wednesday
            Label1.Text = Label1.Text & WeekdayName(today.DayOfWeek, True) & "<br/>"
            today = today.AddDays(1)
        End While
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Exit Sub
        Dim result = JustSendSMSBIFPCL("01734760000,01678582832", "Bulk SMS Testing for BIFPCL Login OTP 34453" & Now.ToString)
        'Dim email = "vinodkotiya@bifpcl.com"
        ' Dim result = JustSendSMSBIFPCL("01678582832", "SMS Testing for BIFPCL Login OTP 34453" & Now.ToString, "OTP")

        ' Button2.Text = SendEmail("admin@bifpcl.com", email, "itbifpcl@gmail.com", "", "OTP for BIFPCL SSO  ", "4566 is OTP for verification of NTPC SSO User: " & email, "", "", "082a6569529ab254c23938e5fbe91790", "2eda6da091499cbd9dc28c0ee85d41a5")
        'Dim i = result.IndexOf("api_response_message")
        'If i <> -1 Then
        '    i += 20
        '    Button2.Text = result.Substring(i, 15)

        'End If
        Label1.Text = result '& i '& words(i + 1)
    End Sub

    Private Sub btnWrittenSMS_Click(sender As Object, e As EventArgs) Handles btnWrittenSMS.Click
        ' Exit Sub
        Dim q = " select distinct appid , replace(c.post, X'0A', ' ') as post, rollno , salute || ' ' || name as name ,Sex , cell,email   from careers_application c, careers_jobs j where c.jobid = j.jobid and stage = 'interview' and c.phase = 'Phase2'  order by rollno desc"
        Dim dt = dbOp.getDBTable(q, "appsdb")
        Dim totalID = dt.Rows.Count
        If dt.Rows.Count < 1 Then

            Label1.Text = "No Records found for requested ID load failed.." '& IDcommaseparated
            Exit Sub
        End If
        Label1.Text = totalID & " Records found for requested ID load.."
        GridView1.DataSource = dt
        GridView1.DataBind()
        Exit Sub
        Dim m = ""
        For Each r In dt.Rows
            ' Dim msg = "Dear Candidate,  Your application for the post of " & r("post") & " is shortlisted for Viva Voce of BIFPCL. Please click on the following link http://tiny.cc/bifpcl to download your Admit Card.   Regards, Team-HR,BIFPCL"
            Dim msg = "Dear Candidate,  You are shortlisted  for  the VIVA VOCE for the post of " & r("post") & " of BIFPCL. Please click on the following link https://cutt.ly/2raqUw2 to download your Admit Card.   Regards, Team-HR,BIFPCL"
            Dim cell = r("cell")
            Dim result = JustSendSMSBIFPCL(cell, msg)
            m = m & cell & " " & msg & " " & result & "<br/>"
            ' Exit For
        Next
        Label1.Text = m
    End Sub

    Private Sub test_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343272")
        If Not (checkAuthorization(Session("email"), "onlybifpcl") And checkAuthorization(Session("email"), "vinadmin.aspx")) Then  ''Pass url or onlybifpcl for all bifplc executives
            Response.Redirect("Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives with approver rights.")
            Exit Sub
        End If
        Response.Write(Decrypt("N1gsTwz9REZa8UN28iHJ4g=="))
    End Sub

    Private Sub btnWrittenEmail_Click(sender As Object, e As EventArgs) Handles btnWrittenEmail.Click
        'Exit Sub
        Dim q = " select distinct appid , replace(c.post, X'0A', ' ') as post, rollno , salute || ' ' || name as name ,Sex , cell,email   from careers_application c, careers_jobs j where c.jobid = j.jobid and stage = 'selected' and c.phase = 'Phase2'  order by rollno desc"
        Dim dt = dbOp.getDBTable(q, "appsdb")
        Dim totalID = dt.Rows.Count
        If dt.Rows.Count < 1 Then

            Label1.Text = "No Records found for requested ID load failed.." '& IDcommaseparated
            Exit Sub
        End If
        Label1.Text = totalID & " Records found for requested ID load.."
        GridView1.DataSource = dt
        GridView1.DataBind()
        Exit Sub
        Dim m = ""
        For Each r In dt.Rows
            '            Dim msg = "Dear Candidate,<br/> <br/>   Your application for the post of " & r("post") & " is shortlisted for Written Test Examination of BIFPCL. <br/> Please visit career section of BIFPCL website to download the Admit Card.  <br/>  Regards,<br/>  Team-HR , BIFPCL " &
            '                "<br/> <br/> link --->  Visit BIFPCL website (www.bifpcl.com). (or Check SMS)" &
            '"<br/> <br/> After opening fill the following details in the fields mentioned: " &
            '"<br/> a) UNIQUE APPLICATION ID" &
            '"<br/> b) YOUR DATE OF BIRTH ( As mentioned in the application)" &
            '"<br/> Click on Submit Button & Download. " &
            '"<br/> Please refer to the instructions on the admit card before appearing for the Written Test Examination."
            '            Dim msg = "Dear Candidate,<br/> <br/>   Based on your Written-Test Examination Results, you are shortlisted  for the Viva Voce for the post of  " & r("post") & "  of BIFPCL. <br/> Please visit career section of BIFPCL website to download the Admit Card.  <br/>  Regards,<br/>  Team-HR , BIFPCL " &
            '                "<br/> <br/> link --->  Visit BIFPCL website (www.bifpcl.com). (or Check SMS)" &
            '"<br/> <br/> After opening fill the following details in the fields mentioned: " &
            '"<br/> a) UNIQUE APPLICATION ID" &
            '"<br/> b) YOUR DATE OF BIRTH ( As mentioned in the application)" &
            '"<br/> Click on Submit Button & Download. Watch help video <a href='https://youtu.be/BI0AoksFNko'>Click Here</a> " &
            '"<br/> Please refer to the instructions on the admit card before appearing for the VIVA VOCE."
            Dim msg = "Dear Candidate,<br/> <br/>   Congratulations !!Your Candidature with Application ID " & r("appid") & " for post  " & r("post") & " is selected to be part of Team-BIFPCL. <br/>  Regards,<br/>  Team-HR , BIFPCL " &
                "Please check your e-mail for Offer of Employment and other details which will be sent soon.<br/> <br/> link --->  Visit BIFPCL website (www.bifpcl.com). (or Check SMS)" &
"<br/> <br/> After opening fill the following details in the fields mentioned: " &
"<br/> a) UNIQUE APPLICATION ID" &
"<br/> b) YOUR DATE OF BIRTH ( As mentioned in the application)" &
"<br/> Click on Submit Button. Watch help video <a href='https://youtu.be/BI0AoksFNko'>Click Here</a> "

            Dim mailto = r("email")
            Dim mailcc = "help@bifpcl.com"
            Dim result = SendEmail("admin@bifpcl.com", mailto, mailcc, "", "BIFPCL Recruitment Update: " & r("name"), msg, "", "", "admin@bifpcl.com", "Bifpcl&123")
            m = m & mailto & ", " & " " & result & "<br/>"
            '  Exit For
        Next
        Label1.Text = m
    End Sub

    Private Sub btnDept_Click(sender As Object, e As EventArgs) Handles btnDept.Click
        Exit Sub
        Dim q = " select distinct appid , replace(post, X'0A', ' ') as post, rollno , salute || ' ' || name as name ,Sex , cell,email   from careers_application c, careers_jobs j where c.jobid = j.jobid and stage = 'written'  order by rollno desc"
        Dim dt = dbOp.getDBTable(q, "appsdb")
        Dim totalID = dt.Rows.Count
        If dt.Rows.Count < 1 Then

            Label1.Text = "No Records found for requested ID load failed.." '& IDcommaseparated
            Exit Sub
        End If
        GridView1.DataSource = dt
        GridView1.DataBind()
        Dim m = ""
        For Each r In dt.Rows
            Dim msg = "Dear Candidate,<br/> <br/>   Your application for the post of " & r("post") & " is shortlisted for Written Test Examination of BIFPCL. <br/> Please visit career section of BIFPCL website to download the Admit Card.  <br/>  Regards,<br/>  Team-HR , BIFPCL " &
                "<br/> <br/> link --->  Visit BIFPCL website. (or Check SMS)" &
"<br/> <br/> After opening fill the following details in the fields mentioned: " &
"<br/> a) UNIQUE APPLICATION ID" &
"<br/> b) YOUR DATE OF BIRTH ( As mentioned in the application)" &
"<br/> Click on Submit Button & Download. " &
"<br/> Please refer to the instructions on the admit card before appearing for the Written Test Examination."
            Dim mailto = r("email")
            Dim mailcc = "help@bifpcl.com"
            '  Dim result = SendEmail("admin@bifpcl.com", mailto, mailcc, "", "BIFPCL Recruitment Update: " & r("name"), msg, "", "", "admin@bifpcl.com", "Imtheone@6")
            m = m & mailto & ", " ' & " " & result & "<br/>"
            ' Exit For
        Next
        Label1.Text = m & "<br/>" ' & msg
    End Sub

    Private Sub btnBio_Click(sender As Object, e As EventArgs) Handles btnBio.Click
        'Dim axCZKEM1 As New zkemkeeper.CZKEM
        'Dim bIsConnected = axCZKEM1.Connect_Net("10.8.215.4", 4370)
        'Label1.Text = bIsConnected.ToString
        Dim mydt = dbOp.getDBTable("select id, uid from contacts_New where del = 0", "hrdb")
        For Each r In mydt.Rows
            If System.IO.File.Exists(Server.MapPath("/upload/employee/pics/" & r(0) & ".jpg")) Then
                System.IO.File.Move(Server.MapPath("/upload/employee/pics/" & r(0) & ".jpg"), Server.MapPath("/upload/employee/pics/" & r(1) & ".jpg"))
            End If

        Next

    End Sub
End Class
