Imports Common
Imports dbOp
Imports System.IO
Imports System.Data
'Imports DotNet.Highcharts
'Imports DotNet.Highcharts.Options
'Imports DotNet.Highcharts.Options.Series
'Imports DotNet.Highcharts.Attributes
'Imports DotNet.Highcharts.Helpers
'Imports DotNet.Highcharts.Enums
'Imports System.Data
'Imports System.Drawing

Partial Class _downloadReg
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
            If Request.Params("mode") = "stats" Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343284")

                If Not (checkAuthorization(Session("email"), "downloadReg.aspx?mode=stats")) Then  ''Pass url or onlybifpcl for all bifplc executives
                    divMsg.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access.<br/> Request auth from admin."
                    Exit Sub
                End If
                divReport.Visible = True
                LoadReg()
            ElseIf Not Request.Params("file") Is Nothing Then
                divRegistration.Visible = True
                Dim file = Request.Params("file").ToString.Replace("'", "")

                Dim q = "Select subject from upload where filename = '" & file & "' limit 1"
                Dim subject = getDBsingle(q)
                If subject.StartsWith("Error") Then Response.Redirect("Default.aspx")
                divFile.InnerHtml = "Note: Enter registration detail to get download link on email for <br/> <a href=#>" & subject & "</a>"

            End If


            executeDB("update hits set view = view+1 where page = 'safety'")
            executeDB("insert into login (eid, log, logintime) values (0, 'Registration and statistic Page Access : at " & Now.ToString() & "" & Session("email") & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
            '   loadChart()
        End If
    End Sub



    Private Sub btnIncidentSubmit_Click(sender As Object, e As EventArgs) Handles btnIncidentSubmit.Click
        If String.IsNullOrEmpty(txtPerson.Text) Or String.IsNullOrEmpty(txtAddress.Text) Or String.IsNullOrEmpty(txtEmail.Text) Or String.IsNullOrEmpty(txtCell.Text) Or String.IsNullOrEmpty(txtAgency.Text) Then
            divMsg.InnerHtml = "Please Enter the fileds"
            Exit Sub
        End If
        ' Dim dt = DateTime.ParseExact(txtIncedentDate.Text, "dd.M.yyyy", Nothing)
        Dim file = Request.Params("file").ToString.Replace("'", "")
        Dim myquery = "insert into uploadReg(filename, agency,address,person,email,cell,dor,lastupdateby,views) " &
               "values ('" & file & "','" & txtAgency.Text.Replace("'", "") & "','" & txtAddress.Text.Replace("'", "") & "','" & txtPerson.Text.Replace("'", "") & "','" & txtEmail.Text.Replace("'", "") & "','" & txtCell.Text.Replace("'", "") & "',current_timestamp,'" & Request.UserHostAddress & "',0 )"
        If executeDB(myquery) = "ok" Then

            btnIncidentSubmit.Enabled = False
            txtAgency.Text = ""
            ''' Send email
            ''' 
            Dim mailto = txtEmail.Text
            Dim mailcc = "admin@bifpcl.com"
            Dim msg = "Dear Ma'm/Sir " & vbCrLf & vbCrLf &
               "<br/><br/>Please find the download link:" & vbCrLf &
               "<br/> <a href=https://www.bifpcl.com/download.aspx?file=" & file & "&rrg=" & txtEmail.Text & " target=_blank>https://www.bifpcl.com/download.aspx?file=" & file & "&rrg=" & txtEmail.Text & "</a> " &
               " <br/> In case of difficulty. Please copy & paste the link in browser address bar. For support drop a mailto vinodkotiya@bifpcl.com"
            Dim ret = SendEmail("admin@bifpcl.com", mailto, mailcc, "", "BIFPCL Download link for " & txtEmail.Text, msg, "", "", "admin@bifpcl.com", "Imtheone@6")
            lblID.Text = "Record Updated & download link emailed at " & txtEmail.Text & ret & "<br/> In case of difficulty drop a mail from your registered eemail id to vinodkotiya@bifpcl.com to get the link."
        Else
            divMsg.InnerHtml = "Error: " & myquery
        End If
    End Sub

    Sub LoadReg()
        Dim q = "select u.subject, 'https://www.bifpcl.com/download.aspx?file=' || u.filename || '&rrg=' || email as 'Link', agency,address,person,email,cell,dor as 'Reg date',views from uploadreg r, upload u where u.filename = r.filename order by dor desc"
        Try
            Dim mydt = getDBTable(q)
            If mydt.Rows.Count = 0 Then
                divMsg.InnerHtml = "No registration found" '& q
                gvDocStore.Visible = False
                Exit Sub
            Else
                divMsg.InnerHtml = mydt.Rows.Count & " registration done"
            End If
            gvDocStore.Visible = True
            For Each r In mydt.Rows

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
End Class
