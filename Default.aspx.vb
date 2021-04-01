Imports dbOp
Imports Common

Partial Class _Default
    Inherits System.Web.UI.Page
    Private starttime As Integer
    Private endTime As Integer
    Private pageLoadTime As Integer
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        starttime = Environment.TickCount
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        endTime = Environment.TickCount
        pageLoadTime = endTime - starttime
        divPage.InnerHtml = "   <p>Copyright ©2018 Website Designed and Maintained by <a href='www.bifpcl.com' target='_blank'>BIFPCL IT</a> | Page Creation time " & pageLoadTime & " ms </p>"
    End Sub
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            '<########## Login MODULE


            If Request.Form.Count = 1 Then
                Dim appsecret = "OdCsO1iD1OXhU6WqDHlabUyfd/viRpG5RTExYv2L1dc="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            '
            If Not Session("email") Is Nothing Then
                divSignin.InnerHtml = "<a href='profile.aspx'>" & Left(Session("email").ToString, 7) & "..</a>"
                divSignin1.InnerHtml = "<a href='profile.aspx'>" & Left(Session("email").ToString, 7) & "..</a>"
            Else
                divSignin.InnerHtml = "<a href='sso/Default.aspx?appid=12343272'>Login</a>"
                divSignin1.InnerHtml = "<a href='sso/Default.aspx?appid=12343272'>Login</a>"
            End If

            '  divMobiSidmenu.InnerHtml = makemenu(True, 2)
            ' divSideMenu.InnerHtml = makemenu(False, 2)
            'divNotification.InnerHtml = getNotification(1)
            '   divLogin.InnerHtml = showAccount("9383", "Vinod Kumar Kotiya", "vinodkotiya@ntpc.co.in")
            'divLogin.InnerHtml = showAccount(Session("email"))
            loadHighlights()
            loadBoard()
            LoadSlider()
            If Cache("manpower") Is Nothing Then
                Dim m = getDBsingle("select count(name) from contacts_New where del = 0 ", "hrdb")
                Cache.Insert("manpower", m, Nothing, DateTime.Now.AddHours(24.0), TimeSpan.Zero)
            End If
            divManpower.InnerHtml = Cache("manpower").ToString
        End If
        executeDB("update hits set view = view+1 where page = 'home'")
        executeDB("insert into login (eid, log, logintime) values (0, 'Home Page Access : at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub
    Sub loadHighlights()
        If Cache("myhighs") Is Nothing Then
            Dim mydt = getDBTable("select htype, desc, porder from highlight where 1")
            Dim icons() As String = {"ti-star", "ti-pulse", "ti-dashboard", "ti-palette", "ti-crown", "ti-shopping-cart"}
            Dim high = ""
            Dim highs = ""
            For Each r In mydt.Rows
                Dim i = 0
                Try
                    i = Int32.Parse(r(2)) - 1
                    high = icons(i)
                Catch ex As Exception
                    i = 0
                End Try
                high = "   <div class='col-12 col-sm-6 col-lg-4'> " &
                   "  <div class='single-feature'>  " &
                   "      <i class='" & icons(i) & "' aria-hidden='true'></i>  " &
                    "     <h5>" & r(0) & "</h5>  " &
                   "      <p>" & r(1) & "</p>  " &
                   "  </div>  " &
                  "                                               </div>"
                highs = highs & high
            Next
            Cache.Insert("myhighs", highs, Nothing, DateTime.Now.AddHours(1.0), TimeSpan.Zero)
        End If
        divHighLights.InnerHtml = Cache("myhighs").ToString
    End Sub
    Sub LoadSlider()
        If Cache("myslides") Is Nothing Then
            Dim mydt = getDBTable("select ImageEvent , strftime('%d.%m.%Y', ImageDate) as ImageDate1 , imagename, imagepath  from ImageSlider where  cover = 1 and (lock = 0 or lock is null) order by imagedate desc limit 7")

            Dim slide = "     <figure Class='Single-shot'> " &
                        " <a href='kachr.aspx' target=_blank > <img src='images/biddut1.png' height='200' alt='biddut' /> </a>" &
                             "<figcaption style='position: relative;  background: black;  background: rgba(0,0,0,0.75);  color: white;  padding: 0px 0px; top:-20px;  opacity: 0.6;  -webkit-transition: all 0.6s ease;  -moz-transition:    all 0.6s ease;  -o-transition:      all 0.6s ease;'>" &
                              " Biddut Animation</figcaption> " &
                        "</figure>"
            Dim slides = slide
            For Each r In mydt.Rows
                slide = "     <figure Class='Single-shot'> " &
                        " <a href='GalleryShow.aspx' target=_blank > <img src='" & r("ImagePath") & "' height='200' alt='" & r("ImageName") & "' /> </a>" &
                             "<figcaption style='position: relative;  background: black;  background: rgba(0,0,0,0.75);  color: white;  padding: 0px 0px; top:-20px;  opacity: 0.6;  -webkit-transition: all 0.6s ease;  -moz-transition:    all 0.6s ease;  -o-transition:      all 0.6s ease;'>" &
                             r("ImageEvent") & " " & r("ImageDate1") & "</figcaption> " &
                        "</figure>"
                slides = slides & slide
            Next
            Cache.Insert("myslides", slides, Nothing, DateTime.Now.AddHours(1.0), TimeSpan.Zero)
        End If
        divSlide.InnerHtml = Cache("myslides").ToString
    End Sub
    Sub loadBoard()
        Dim names() As String = {"<h5>Mr. Md. Habibur Rahman</h5><p>Secretary, Power Division, MPEMR, GoB and Chairman,BIFPCL</p>", "<h5>Mr.Gurdeep Singh</h5><p>Chairman & Managing Director,NTPC Limited</p>", "<h5>Mr. Md. Belayet Hossain</h5><p>Chairman, BPDB</p>", "<h5>Mr. Md. Nurul Alam</h5><p>Additional Secretary (Development-1),Power Division,MPEMR</p>", "<h5>Engr. Md Mahbubur Rahman</h5><p>Member (Company Affairs), BPDB</p>", "<h5>Mr. C K Mondol</h5><p>Director(Commercial),NTPC</p>", "<h5>Ms. Renu Narang</h5><p>Chief General Manager(Finance),NTPC</p>", "<h5>Engr. Animesh Jain</h5><p>Managing Director,BIFPCL</p>"}
        Dim imgs() As String = {"habib.jpg", "cmd.jpg", "Belayet.jpg", "nurul.jpg", "mahbub.jpg", "mondol.png", "renu.jpg", "ajain.jpg"}
        Dim name = ""
        '<div Class="client-feedback-text text-center">
        '                   <div Class="client-name text-centers">
        '                       <h5> Vinod Kotiya</h5>
        '                       <p> Sr Manager</p>
        '                   </div>
        '               </div>
        Dim Img = ""
        Dim i = 0
        For Each n In names

            Dim pic = imgs(i)
            If Not IO.File.Exists(Server.MapPath("./upload/employee/pics/" & pic)) Then pic = "user.png"
            Img = Img & "<div class='client-thumbnail'> " &
                           " <img src='\upload\employee\pics\" & pic & "' alt='" & n & "'  onerror=" & Chr(34) & "this.src='\upload\employee\pics\user.png';" & Chr(34) & " /> " &
                       " </div>"

            name = name & " <div class='client-feedback-text text-center'> " &
                            "<div class='client-name text-center'>  " &
                           n &
                           " </div> " &
                        "</div>"
            i = i + 1
        Next
        divName.InnerHtml = name
        divPic.InnerHtml = Img
    End Sub
    Sub loadTeam()

        Dim q = "select name, desig, cell, email,rax, id from contacts_New where dept = 'NA' order by printorder"
        If Cache("myTeam") Is Nothing Then
            Dim mydt = getDBTable(q, "hrdb")
            Dim name = ""
            '<div Class="client-feedback-text text-center">
            '                   <div Class="client-name text-center">
            '                       <h5> Vinod Kotiya</h5>
            '                       <p> Sr Manager</p>
            '                   </div>
            '               </div>
            Dim Img = ""
            For Each r In mydt.Rows
                If String.IsNullOrEmpty(r("email")) Then r("email") = "Email NA"
                Dim pic = r("id") & ".jpg"
                If Not IO.File.Exists(Server.MapPath("./upload/employee/pics/" & pic)) Then pic = "user.png"
                Img = Img & "<div class='client-thumbnail'> " &
                           " <img src='\upload\employee\pics\" & pic & "' alt='" & r("name") & "'  onerror=" & Chr(34) & "this.src='\upload\employee\pics\user.png';" & Chr(34) & " /> " &
                       " </div>"

                name = name & " <div class='client-feedback-text text-center'> " &
                            "<div class='client-name text-center'>  " &
                            "    <h5>" & r("name") & "</h5> " &
                             "   <p>" & r("desig") & "</p> " &
                           " </div> " &
                        "</div>"
            Next
            Cache.Insert("myTeam", name, Nothing, DateTime.Now.AddHours(1.0), TimeSpan.Zero)
            Cache.Insert("myTeamPic", Img, Nothing, DateTime.Now.AddHours(1.0), TimeSpan.Zero)
        End If
        divName.InnerHtml = Cache("myTeam").ToString
        divPic.InnerHtml = Cache("myTeamPic").ToString
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If String.IsNullOrEmpty(name.Text) Or String.IsNullOrEmpty(email.Text) Or String.IsNullOrEmpty(message.Text) Then
            lbMessage.Text = "Fields are mendatory"
            Exit Sub
        End If
        If message.Text.Length < 100 Then
            lbMessage.Text = "Your message is too small"
            Exit Sub
        End If
        If email.Text.Contains("bifpcl.com") Then
            lbMessage.Text = "Your IP Address " & Request.UserHostAddress & " has been recorded. You can be booked for misusing the bifpcl email id."
            btnSend.Enabled = False
            Exit Sub
        End If
        lbMessage.Text = "Message Submitted and Mail Sent " & SendEmail("admin@bifpcl.com", "help@bifpcl.com", email.Text, "", "BIFPCL Website Message  by " & name.Text & " from IP " & Request.UserHostAddress.ToString, message.Text & vbCrLf & name.Text & vbCrLf & " Email " & email.Text, "", "", "admin@bifpcl.com", "Imtheone@6") & " Your IP Address " & Request.UserHostAddress & " has been recorded."
        btnSend.Enabled = False
    End Sub
End Class
