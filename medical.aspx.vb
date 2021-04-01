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

Partial Class _medical
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        '  Session("email") = "md_mintu_miah@live.com"
        If Not Page.IsPostBack Then

            If Request.Form.Count = 1 Then
                Dim appsecret = "8HLXFC/uvO0Wr5aEqzz1icUpTpmoJC443+N1TJHmwck="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2, True)
            divNotification.InnerHtml = getNotification(1)
            divNotificationMobile.InnerHtml = getNotification(1, True)
            divLogin.InnerHtml = showAccount(Session("email"), True)
            divLoginMobile.InnerHtml = showAccount(Session("email"), True)
            gvSummary.DataSource = getDBTable("select  mtype as 'Medical Type', sum(mpersons) as 'Total Persons' from medical where del = 0 group by mtype union select  'Total'  as 'Medical Type', sum(mpersons) as 'Total Persons' from medical where del = 0", "appsdb")
            gvSummary.DataBind()

            If Not Request.QueryString("mode") Is Nothing Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343320")
                divPics.Visible = False
                divEmergency.Visible = False
                divHome.Visible = False
            End If
            Dim Incidenttype = ""
            If Request.QueryString("mode") = "entry" Then
                If (checkAuthorization(Session("email"), "medical.aspx?mode=entry")) Then
                    divIncidentRecording.Visible = True
                    divEditor.Visible = True
                    'gvDPRDetail.DataSource("select ")
                Else
                    lbMsg.Text = "You are not authorised to access this module."
                End If

            ElseIf Request.QueryString("mode") = "report" Then
                divReport.Visible = True

                gvReport.DataSource = getDBTable(" select uid, mtype as 'Medical Type', strftime('%d.%m.%Y',mdate) as 'Date', mpersons as 'Persons', remark as 'Remarks', last_updated, lastupdateby  from medical where  del = 0  order by mdate desc", "appsdb")
                gvReport.DataBind()
                '  //This replaces <td> with <th> And adds the scope attribute
                gvReport.UseAccessibleHeader = True
                ' //This will add the <thead> And <tbody> elements
                gvReport.HeaderRow.TableSection = TableRowSection.TableHeader

                ' //This adds the <tfoot> element. 
                ' //Remove if you don't have a footer row
                gvReport.FooterRow.TableSection = TableRowSection.TableFooter
                '  LoadDocStore("SAFETY", "%")
            End If
        End If

        executeDB("update hits set view = view+1 where page = 'medical'")
        executeDB("insert into login (eid, log, logintime) values (0, 'Medical Page Access : at " & Now.ToString() & "" & Session("email") & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub

    Private Sub gvDPRDetail_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDPRDetail.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then

        '    If (e.Row.RowState And DataControlRowState.Edit) > 0 Then
        '        Dim ddList As DropDownList = CType(e.Row.FindControl("ddlPictures"), DropDownList)
        '        ddList.DataSource = getDBTable("select ImageEvent || '#' || ImageDate as t, ImageEvent || '#' || ImageDate as v from ImageSlider where lastupdateby in (select email from auth where page = 'safety.aspx?mode=incident' ) group by ImageEvent, ImageDate")
        '        ddList.DataTextField = "t"
        '        ddList.DataValueField = "v"
        '        ddList.DataBind()
        '        ddList.Items.Add(New ListItem("Not Uploaded", ""))
        '        Dim dr As DataRowView = TryCast(e.Row.DataItem, DataRowView)
        '        ddList.SelectedValue = dr("Pictures").ToString()
        '    End If
        'End If
    End Sub
    Private Sub gvDPRDetail_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles gvDPRDetail.RowUpdating
        '    Dim ddList As DropDownList = CType(gvDPRDetail.Rows(e.RowIndex).FindControl("ddlPictures"), DropDownList)
        SqlDataSource1.UpdateParameters("lastupdateby").DefaultValue = Session("email")  'ddList.SelectedValue.ToString
        SqlDataSource1.UpdateParameters("last_updated").DefaultValue = Now.ToString("yyyy-MM-dd")
        SqlDataSource1.UpdateParameters("mtype").DefaultValue = rblEditorType.SelectedValue
    End Sub



    Private Sub btnIncidentSubmit_Click(sender As Object, e As EventArgs) Handles btnIncidentSubmit.Click
        If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343320")
        If String.IsNullOrEmpty(txtIncedentDate.Text) Or String.IsNullOrEmpty(txtIncedentVictim.Text) Then
            divMsg.InnerHtml = "Please Enter the fileds"
            Exit Sub
        End If
        Dim dt = DateTime.ParseExact(txtIncedentDate.Text, "dd.M.yyyy", Nothing)
        Dim myquery = "insert into medical(mtype, mdate, mpersons, remark , lastupdateby, last_updated, del) " &
               "values ('" & rblIncedentType.SelectedValue & "','" & dt.ToString("yyyy-MM-dd") & "','" & txtIncedentVictim.Text.Replace("'", "") & "','" & txtIncedentRemark.Text.Replace("'", "") & "','" & Session("email") & "',current_timestamp,0 )"
        If executeDB(myquery, "appsdb") = "ok" Then
            divMsg.InnerHtml = "Record Updated"
            lblID.Text = "Record Updated Succesfully"
            txtIncedentDate.Text = ""
        Else
            lblID.Text = "Error: " & myquery
        End If
    End Sub

    Private Sub rblEditorType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblEditorType.SelectedIndexChanged
        SqlDataSource1.SelectParameters("mtype").DefaultValue = rblEditorType.SelectedValue
    End Sub
End Class
