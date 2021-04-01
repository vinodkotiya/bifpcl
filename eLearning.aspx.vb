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

Partial Class _eLearning
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        '  Session("email") = "md_mintu_miah@live.com"
        If Not Page.IsPostBack Then
            ' If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343272")
            If Request.Form.Count = 1 Then
                Dim appsecret = "6zUFiCczWuyjJViiLzGBTWiTiKzdhKg5k6mF+22Tnq8="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2)
            divNotification.InnerHtml = getNotification(1)
            '   divLogin.InnerHtml = showAccount("9383", "Vinod Kumar Kotiya", "vinodkotiya@ntpc.co.in")
            divLogin.InnerHtml = showAccount(Session("email"))




            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2)
            divNotification.InnerHtml = getNotification(1)
            '   divLogin.InnerHtml = showAccount("9383", "Vinod Kumar Kotiya", "vinodkotiya@ntpc.co.in")
            divLogin.InnerHtml = showAccount(Session("email"))
            If Not Request.Params("ctype") Is Nothing Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343296")

                If Not checkAuthorization(Session("email"), "onlybifpcl") Then  ''Pass url or onlybifpcl for all bifplc executives
                    divProfile.Visible = False
                    divMsg.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If
                divProfile.Visible = True
                Dim keyword = Server.UrlDecode(Request.Params("ctype"))
                divHead.InnerHtml = "   <h3 class='mb-3'><button type='button' class='btn btn-primary m-l-10 m-b-10' style='  text-transform: capitalize;'>" & keyword & "</button>  </h3> "
                LoadDocStore("eLearn", keyword)
            Else
                divHome.Visible = True
            End If



            ' divHead.InnerHtml = "   <h3 class='mb-3'><button type='button' class='btn btn-primary m-l-10 m-b-10' style='  text-transform: capitalize;'>" & ddlSection.SelectedValue & "</button> <button type='button' class='btn btn-primary m-l-10 m-b-10'  style='  text-transform: capitalize;'>" & ddlDocType.SelectedValue & "</button> </h3> "


            '

        End If

        executeDB("update hits set view = view+1 where page = 'docstore'")
        executeDB("insert into login (eid, log, logintime) values (0, 'DocStore Internal Page Access : at " & Now.ToString() & "" & Session("email") & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
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

    Private Sub gvDocStore_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDocStore.RowDataBound
        Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(1).Text)
        e.Row.Cells(1).Text = decodedText
        e.Row.Cells(1).Attributes.Add("style", "width:600px; word-break:break-all;word-wrap:break-word;")
    End Sub

End Class
