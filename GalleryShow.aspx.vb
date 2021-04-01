Imports Common
Imports dbOp
Imports System.IO
'Imports DotNet.Highcharts
'Imports DotNet.Highcharts.Options
'Imports DotNet.Highcharts.Options.Series
'Imports DotNet.Highcharts.Attributes
'Imports DotNet.Highcharts.Helpers
'Imports DotNet.Highcharts.Enums
'Imports System.Data
'Imports System.Drawing

Partial Class _GalleryShow
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        '  Session("email") = "md_mintu_miah@live.com"
        If Not Page.IsPostBack Then

            If Request.Form.Count = 1 Then
                Dim appsecret = "RPfc9seexb/5FBfy+UEpd9wGbWjmBGEXcQaXpkmZCSg="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2)
            divNotification.InnerHtml = getNotification(1)
            '   divLogin.InnerHtml = showAccount("9383", "Vinod Kumar Kotiya", "vinodkotiya@ntpc.co.in")
            divLogin.InnerHtml = showAccount(Session("email"))


            divMsg.InnerHtml = "Parameters"
            If Not Request.QueryString("imageevent") Is Nothing And Not Request.QueryString("imagedate") Is Nothing Then
                Dim imageevent = Server.UrlDecode(Request.QueryString("imageevent"))
                Dim imagedate = Server.UrlDecode(Request.QueryString("imagedate"))
                loadSlides(imageevent, imagedate)
                divThumbs.Visible = False
                divPics.Visible = True
                divMsg.InnerHtml = "Parameter for album recieved."
            Else
                divThumbs.Visible = True
                divPics.Visible = False
                loadThumbs()
                divMsg.InnerHtml = "Parameter for album not recieved."
            End If

            'If Request.QueryString("mode") = "incident" Then

            'End If
        End If

        executeDB("update hits set view = view+1 where page = 'galleryshow'")
        executeDB("insert into login (eid, log, logintime) values (0, 'Gallery Show Page Access : at " & Now.ToString() & "" & Session("email") & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub
    Sub loadThumbs()
        Dim mydt = getDBTable("select ID, ImageEvent , ImageDate as rawdate, strftime('%d.%m.%Y', ImageDate) as ImageDate1 , imagename, imagepath  from ImageSlider where  cover = 1 and (lock = 0 or lock is null) order by imagedate desc ")

        Dim slide = ""
        Dim slides = ""
        For Each r In mydt.Rows
            Dim total = getDBsingle("select count(id) from ImageSlider where ImageEvent in (select imageevent from ImageSlider where id = " & r("ID") & ")")
            Dim pic = "Galleryshow.aspx?imageevent=" & Server.UrlEncode(r("ImageEvent")) & "&imagedate=" & r("rawdate") & ""
            slide = " <div class='col-sm-3'> " &
                        " <div class='card'>  " &
                         " <a href='" & pic & "' >   <img class='card-img-top' width='350' height='250' src='" & r("ImagePath") & "' alt='" & r("ImageName") & "'> </a> " &
                              "   <div class='card-body'> " &
                               "      <h4 class='card-title mb-3'>" & r("ImageEvent") & "</h4> " &
                                "     <p class='card-text'>" & r("ImageDate1") & " - " & total & " Pics </p> " &
                                " </div> " &
                               " </div> " &
                              "  </div>"
            slides = slides & slide
        Next
        divThumbnails.InnerHtml = slides
    End Sub
    Sub loadSlides(ByVal imageEvent As String, ByVal imagedate As String)
        divHead.InnerHtml = "   <h3 class='mb-3'><button type='button' class='btn btn-primary m-l-10 m-b-10' style='  text-transform: capitalize;'>" & imageEvent & "</button> <button type='button' class='btn btn-primary m-l-10 m-b-10' style='  text-transform: capitalize;'>" & imagedate & "</button>  </h3> "

        Dim mydt = getDBTable("SELECT ID,ImageEvent || ' ' || ImageDate as ImageEvent, lock, ImageName, ImagePath FROM ImageSlider where  ImageEvent like '%" & imageEvent & "%' and ImageDate like '" & imagedate & "'")

        Dim slide = ""
        Dim slides = ""
        For Each r In mydt.Rows
            Dim lock = If(IsDBNull(r("lock")), "0", r("lock").ToString)
            If lock = "1" Then   ''If album is locked then seak for login
                If Not checkAuthorization(Session("email"), "onlybifpcl") Then Response.Redirect("sso/Default.aspx?appid=12343272")
            End If
            slide = "<div>" &
                "<img data-u='image' src='" & r("ImagePath") & "' alt='" & r("ImageName") & "' />" &
      "</div>"
            slides = slides & slide
        Next
        divSlides.InnerHtml = slides

    End Sub
End Class
