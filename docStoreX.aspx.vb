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

Partial Class _docStoreX
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        '  Session("email") = "md_mintu_miah@live.com"
        If Not Page.IsPostBack Then
            ' If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343272")

            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2, True)
            divNotification.InnerHtml = getNotification(1)
            divNotificationMobile.InnerHtml = getNotification(1, True)
            divLogin.InnerHtml = showAccount(Session("email"), True)
            divLoginMobile.InnerHtml = showAccount(Session("email"), True)
            If Request.Params("section") Is Nothing Or Request.Params("doctype") Is Nothing Then
                divProfile.Visible = False
                divMsg.InnerHtml = "Unauthorised Access"
                Exit Sub
            End If
            Dim section =  Request.Params("section")
            Dim doctype = Request.Params("doctype")
            section = Decrypt(section)
            doctype = Decrypt(doctype)
            divHead.InnerHtml = "   <h3 class='mb-3'><button type='button' class='btn btn-primary m-l-10 m-b-10' style='  text-transform: capitalize;'>" & section & "</button> <button type='button' class='btn btn-primary m-l-10 m-b-10'  style='  text-transform: capitalize;'>" & doctype & "</button> </h3> "



            divProfile.Visible = True
            LoadDocStore(doctype, section)
        End If

        executeDB("update hits set view = view+1 where page = 'docstore'")
        executeDB("insert into login (eid, log, logintime) values (0, 'DocStore External Page Access : at " & Now.ToString() & "" & Session("email") & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub


    Sub LoadDocStore(ByVal docType As String, ByVal section As String)
        Dim mydt = getDBTable("select type, strftime('%d.%m.%Y', docdt), subject as Description, secure, section, filename, lastupdateby as By, strftime('%d.%m.%Y', last_updated) as 'Upload', downloads as views, '' as 'Size(MB)' from upload where exist = 1 and not secure=1 and type like '%" & docType & "%' and section like '%" & section & "%' order by docdt desc ")
        If mydt.Rows.Count = 0 Then
            divMsg.InnerHtml = "No documents found"
            Exit Sub
        Else
            divMsg.InnerHtml = mydt.Rows.Count & " documents found"
        End If
        For Each r In mydt.Rows
            Dim filepath = "upload/" & r("section") & "/" & r("type") & "/" & r("filename")
            ' r("Description") = "<b><a href='" & filepath & "' target=_blank onclick=fileCount('" & r("filename") & "') >" & r("Description") & "</a></b>"
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
    End Sub

    Private Sub gvDocStore_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDocStore.RowDataBound
        Dim decodedText = HttpUtility.HtmlDecode(e.Row.Cells(2).Text)
        e.Row.Cells(2).Text = decodedText
        e.Row.Cells(2).Attributes.Add("style", "width:600px; word-break:break-all;word-wrap:break-word;")
    End Sub
End Class
