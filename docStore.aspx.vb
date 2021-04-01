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

Partial Class _docStore
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        '  Session("email") = "md_mintu_miah@live.com"
        If Not Page.IsPostBack Then
            ' If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343272")
            If Request.Form.Count = 1 Then
                Dim appsecret = "R46dtaMpW8bc+OKXw5l5Btcww18A216GCqnBIJnQjNw="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2, True)
            divNotification.InnerHtml = getNotification(1)
            divNotificationMobile.InnerHtml = getNotification(1, True)
            divLogin.InnerHtml = showAccount(Session("email"), True)
            divLoginMobile.InnerHtml = showAccount(Session("email"), True)
            Dim q As String = "Select distinct descr as t, dept as v from dept where 1 order by descr asc"
            ddlSection.DataTextField = "t"
            ddlSection.DataValueField = "v"
            ddlSection.DataSource = getDBTable(q)
            ddlSection.DataBind()
            ddlSection.Items.Add(New ListItem("Show All", "%"))
            ddlSection.SelectedValue = "%"
            q = "Select distinct descr as t, type as v from uploadtype where 1 order by descr asc"
            ddlDocType.DataTextField = "t"
            ddlDocType.DataValueField = "v"
            ddlDocType.DataSource = getDBTable(q)
            ddlDocType.DataBind()
            ddlDocType.Items.Add(New ListItem("Show All", "%"))
            ddlDocType.SelectedValue = "%"
            ' ddlDocType_SelectedIndexChanged(vbNull, EventArgs.Empty)




            ' divHead.InnerHtml = "   <h3 class='mb-3'><button type='button' class='btn btn-primary m-l-10 m-b-10' style='  text-transform: capitalize;'>" & ddlSection.SelectedValue & "</button> <button type='button' class='btn btn-primary m-l-10 m-b-10'  style='  text-transform: capitalize;'>" & ddlDocType.SelectedValue & "</button> </h3> "

            If Not Request.Params("section") Is Nothing And Not Request.Params("doctype") Is Nothing Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343284")

                If Not (checkAuthorization(Session("email"), "onlybifpcl") Or checkAuthorization(Session("email"), "docStore.aspx")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    divProfile.Visible = False
                    divMsg.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Only for BIFPCL Executives."
                    Exit Sub
                End If


                Dim section = Request.Params("section")
                Dim doctype = Request.Params("doctype")
                section = Decrypt(section)
                doctype = Decrypt(doctype)
                ddlSection.SelectedValue = section
                ddlDocType.SelectedValue = doctype
                LoadDocStore(doctype, section)
                divProfile.Visible = True
            Else
                loadThumbs()
            End If


        End If

        executeDB("update hits set view = view+1 where page = 'docstore'")
        executeDB("insert into login (eid, log, logintime) values (0, 'DocStore Internal Page Access : at " & Now.ToString() & "" & Session("email") & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub
    Sub loadThumbs()
        divThumbs.Visible = True
        divUpload.Visible = True
        divStats.Visible = True
        Dim btnType() As String = {"btn-primary", "btn-success", "btn-info", "btn-warning", "btn-danger"}
        Dim q = "select distinct section, descr,  count(section) as no from upload u, dept d where u.section = d.dept group by section order by descr"
        Dim mydt = getDBTable(q)
        Dim i = 0
        Dim str = ""
        For Each r In mydt.Rows
            Dim s = " <button type='button' class='btn " & btnType(i) & " m-l-10 m-b-10'> " &
                "<a style='color:white;' href=docStore.aspx?section=" & HttpUtility.UrlEncode(Encrypt(r("section"))) & "&doctype=" & HttpUtility.UrlEncode(Encrypt("%")) & ">" & r("descr") & "</a>" &
                      "&nbsp;&nbsp;<span class='badge badge-light'> " & r("no") & "</span>" &
                    "</button>"
            str = str & s
            i = i + 1
            If i > (btnType.Length - 1) Then i = 0
        Next
        divSection.InnerHtml = str
        q = "select distinct u.type, descr,  count(u.type) as no from upload u, uploadtype t where u.type = t.type group by u.type order by descr"
        mydt = getDBTable(q)
        i = 0
        str = ""
        For Each r In mydt.Rows
            Dim s = " <button type='button' class='btn " & btnType(i) & " m-l-10 m-b-10'>" &
                   "<a style='color:white;' href=docStore.aspx?section=" & HttpUtility.UrlEncode(Encrypt("%")) & "&doctype=" & HttpUtility.UrlEncode(Encrypt(r("type"))) & ">" & r("descr") & "</a>" &
                      "&nbsp;&nbsp;<span class='badge badge-light'> " & r("no") & "</span>" &
                    "</button>"
            str = str & s
            i = i + 1
            If i > (btnType.Length - 1) Then i = 0
        Next
        divType.InnerHtml = str
    End Sub

    Sub LoadDocStore(ByVal docType As String, ByVal section As String)
        Dim secret = ""
        If cbSecret.Checked Then secret = " and secure = 1"
        Dim q = "select type,  subject as Description, strftime('%d.%m.%Y', docdt) as 'Date', secure, section, filename,  strftime('%d.%m.%Y', last_updated) as 'Upload', downloads as views, '' as 'Size(MB)',lastupdateby as By from upload where exist = 1 and type like '%" & docType & "%' and section like '%" & section & "%' " & secret & " order by docdt desc "
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
    Private Sub ddlDocType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDocType.SelectedIndexChanged
        'Dim q = "Select secret from uploadtype where type ='" & ddlDocType.SelectedValue & "' limit 1"
        'Dim secret = getDBsingle(q)
        'If secret = "1" Then : cbSecret.Checked = True
        'Else : cbSecret.Checked = False
        'End If
        LoadDocStore(ddlDocType.SelectedValue, ddlSection.SelectedValue)
    End Sub

    Private Sub ddlSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSection.SelectedIndexChanged
        LoadDocStore(ddlDocType.SelectedValue, ddlSection.SelectedValue)
    End Sub

    Private Sub cbSecret_CheckedChanged(sender As Object, e As EventArgs) Handles cbSecret.CheckedChanged
        LoadDocStore(ddlDocType.SelectedValue, ddlSection.SelectedValue)
    End Sub
End Class
