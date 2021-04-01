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

Partial Class _asset
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343272")

            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2)
            divNotification.InnerHtml = getNotification(1)
            If Request.Form.Count = 1 Then
                Dim appsecret = "Nmhm97dkTg1g0qQH+VF2oM5n727mQ7+YOAVmT7hxElY="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            divLogin.InnerHtml = showAccount(Session("email"))
            divMsg.InnerHtml = Session("email")
            If Not Request.QueryString("ctype") Is Nothing Then
                If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343290")
            End If

            Dim section = Request.Params("section")
            Dim doctype = Request.Params("doctype")
            'section = Decrypt(section)
            'doctype = Decrypt(doctype)
            divHead.InnerHtml = "   <h3 class='mb-3'><button type='button' class='btn btn-primary m-l-10 m-b-10' style='  text-transform: capitalize;'>" & section & "</button> <button type='button' class='btn btn-primary m-l-10 m-b-10'  style='  text-transform: capitalize;'>" & doctype & "</button> </h3> "

            divPO.Visible = False
            divAssetBooking.Visible = False
            divAssign.Visible = False
            pnlAssign.Visible = False
            If Request.Params("ctype") Is Nothing Then
                divProfile.Visible = True
                'If Cache("wall") Is Nothing Then
                '    Cache.Insert("wall", getWallofFame(), Nothing, DateTime.Now.AddMinutes(10.0), TimeSpan.Zero)
                'End If
                ''divWallofFame.InnerHtml = Cache("wall").ToString

            Else
                'admin

                If Request.Params("ctype") = "entry" Then
                    divHead.InnerHtml = "   <h3 class='mb-3'><button type='button' class='btn btn-primary m-l-10 m-b-10' style='  text-transform: capitalize;'>Asset</button> <button type='button' class='btn btn-primary m-l-10 m-b-10'  style='  text-transform: capitalize;'>Entry</button> </h3> "

                    loadAssetEntryForm()
                    divAssetBooking.Visible = True

                ElseIf Request.Params("ctype") = "po" Then
                    'loadAssetEntryForm()
                    divHead.InnerHtml = "   <h3 class='mb-3'><button type='button' class='btn btn-primary m-l-10 m-b-10' style='  text-transform: capitalize;'>PO</button> <button type='button' class='btn btn-primary m-l-10 m-b-10'  style='  text-transform: capitalize;'>Creation</button> </h3> "

                    txtvUid.Text = getDBsingle("select max(uid)+1 From asset_vendor where 1 limit 1", "appsdb")
                    divPO.Visible = True
                ElseIf Request.Params("ctype") = "assign" Then
                    divAssign.Visible = True
                    divHead.InnerHtml = "   <h3 class='mb-3'><button type='button' class='btn btn-primary m-l-10 m-b-10' style='  text-transform: capitalize;'>Asset</button> <button type='button' class='btn btn-primary m-l-10 m-b-10'  style='  text-transform: capitalize;'>Assignment</button> </h3> "

                    ddlAdminFilter.DataSource = getDBTable("select id,type from asset_type where 1", "appsdb")
                    ddlAdminFilter.DataBind()
                    ddlAdminFilter.Items.Insert(0, "%")
                    ddlUidNew.DataSource = getDBTable("select email as v, name as t from contacts_New where not email is null order by name", "hrdb")
                    ddlUidNew.DataBind()
                    ddlUidNew.Items.Insert(0, "Stores")
                    ddlUidNew.Items.Insert(1, "Common Place")
                    pnlAssign.Visible = True
                    loadAdminStatus("", "%")
                    'loadAssetEntryForm()
                    'pnlAssetBooking.Visible = True
                    'ElseIf Not Request.Params("ctype") = "admin" Then

                    '    LinkButton1.Visible = True
                    '        If Request.Params("ctype") = "status" Then
                    '        pnlAssetBooking.Visible = False
                    '        pnlStatus.Visible = True
                    '            loadStatus(Session("eid"))
                    '            Exit Sub
                    '        End If
                    '    pnlAssetBooking.Visible = False
                ElseIf Request.Params("ctype") = "report" Then
                    '  LinkButton1.Visible = True
                    divHead.InnerHtml = "   <h3 class='mb-3'><button type='button' class='btn btn-primary m-l-10 m-b-10' style='  text-transform: capitalize;'>Asset</button> <button type='button' class='btn btn-primary m-l-10 m-b-10'  style='  text-transform: capitalize;'>Report</button> </h3> "

                    divStatus.Visible = True
                    loadStatus("")


                End If
            End If

        End If

        executeDB("update hits set view = view+1 where page = 'asset'")
        executeDB("insert into login (eid, log, logintime) values (0, 'Asset Page Access : at " & Now.ToString() & "" & Session("email") & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Session("Assetadminid") Is Nothing Then
            Response.Redirect(Request.RawUrl)
            Exit Sub
        End If
        Dim searchid = ""
        If Not String.IsNullOrEmpty(txtSearchID.Text) Then searchid = " (uid = '" & txtSearchID.Text & "' or owner = '" & txtSearchID.Text & "'  or po like '%" & txtSearchID.Text & "%') and "

        loadAdminStatus(searchid, ddlAdminFilter.SelectedItem.Text)

    End Sub
    Public Function loadStatus(ByVal eid As String)
        Dim q = ""
        If rblReport.SelectedValue = "WO" Then
            q = "select uid, po,vendor,vcontact,podate,install_dt,validity,descr,type, ecost,acost,tender,bids,location,approver,last_updated, lastupdateby,del from asset_vendor where del = 0 order by uid desc"
        Else
            q = "select uid  , atype, make, model, cast(sn as text) as sn, detail, owner, st_dt , po, chain from asset_detail where 1 order by last_updated desc"
        End If
        gvStatus.DataSource = getDBTable(q, "appsdb")
        gvStatus.DataBind()

    End Function
    Public Function loadAdminStatus(ByVal searchID As String, ByVal atype As String)

        Dim q = "select uid  , atype, make, model, cast(sn as text) as sn, detail, owner, st_dt , po, chain from asset_detail where " &
           searchID & " atype  like '%" & atype & "%' order by uid limit 200" &
            ""
        '"union select id , type, descr, tech, cast(priority as text) as priority, strftime('%d.%m.%Y %H:%M', datetime(st_dt,'+330 Minute')) as 'Date', status, name || ' (' || eid || ')' as name , contact,dept, location, closingremark from ocms where not status = 'Pending' and typeid in (" & groupid & ") and location like '%" & loc & "%' order by status desc, priority desc, st_dt asc "
        'divMsg.InnerHtml = q
        ' Return 1
        gvAdminStatus.DataSource = getDBTable(q, "appsdb")
        gvAdminStatus.DataBind()

    End Function
    Public Function loadAssetEntryForm()
        ddlUid.DataSource = getDBTable("select email as v, name as t from contacts_New where not email is null order by name", "hrdb")
        ddlUid.DataBind()
        ddlUid.Items.Insert(0, "Stores")
        ddlCtype.DataSource = getDBTable("select id,type from asset_type where 1", "appsdb")
        ddlCtype.DataBind()
        ' ddlCtype.SelectedValue = assettype
        ddlPO.DataSource = getDBTable("select po as v, po || '-' || vendor as t  from asset_vendor where 1 order by po desc", "appsdb")
        ddlPO.DataBind()
        ddlMake.DataSource = getDBTable("select distinct make from asset_detail where 1", "appsdb")
        ddlMake.DataBind()
        ddlMake.Items.Insert(0, "Not in the list")
        ddlMake.SelectedValue = getDBsingle("select make from asset_detail where 1 order by last_updated desc limit 1", "appsdb")
        txtModel.Text = getDBsingle("select model from asset_detail where 1 order by last_updated desc limit 1", "appsdb")
        If txtModel.Text.Contains("Error") Then txtModel.Text = ""
        divMsgComplaint.InnerHtml = "Your IP Address is:" & Request.UserHostAddress
    End Function



    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim make = ddlMake.SelectedValue
        If ddlMake.SelectedIndex = 0 Then
            make = txtMake.Text
        End If
        If String.IsNullOrEmpty(make) Or String.IsNullOrEmpty(txtSN.Text) Or String.IsNullOrEmpty(txtDate.Text) Then
            divMsgComplaint.InnerHtml = "Please enter the * fields..."
            Exit Sub
        End If



        Dim q = "insert into asset_detail (atype,make,model,sn,owner,st_dt,po, last_updated, chain, detail) values(" &
                          " '" & ddlCtype.SelectedItem.Text & "', '" & make.Replace("'", " ") & "', '" & txtModel.Text.Replace("'", " ") & "', '" & txtSN.Text.Replace("'", " ") & "','" & ddlUid.SelectedValue & "', '" &
                        txtDate.Text.Replace("'", " ") & "', '" & ddlPO.SelectedValue & "', current_timestamp, 'Asset Created','" & txtDescr.Text & "')"
        divMsgComplaint.InnerHtml = q
        Dim ret = executeDB(q, "appsdb")
        If ret.Contains("Error") Then
            divMsg.InnerHtml = "Unable to submit " & ret & q
            Exit Sub
        End If


        ''create message


        Response.Redirect("asset.aspx")
        'End Try
    End Sub
    Private Sub btnCreatePO_Click(sender As Object, e As EventArgs) Handles btnCreatePO.Click
        If Session("email") Is Nothing Then
            Response.Redirect("asset.aspx")
        End If
        If String.IsNullOrEmpty(txtvPO.Text) Or String.IsNullOrEmpty(txtvPODate.Text) Or String.IsNullOrEmpty(txtvName.Text) Or String.IsNullOrEmpty(txtvDescr.Text) Or String.IsNullOrEmpty(txtACost.Text) Or String.IsNullOrEmpty(txtvECost.Text) Or String.IsNullOrEmpty(txtvInstallDate.Text) Or String.IsNullOrEmpty(txtvBider.Text) Then
            divMsg.InnerHtml = "All fields are mendatory..."
            Exit Sub
        End If



        Dim q = "insert into asset_vendor (po,vendor,vcontact,podate,install_dt,validity,descr,type, ecost,acost,tender,bids,location,approver,last_updated, lastupdateby,del,address, curr) values(" &
                          " '" & txtvPO.Text.Replace("'", " ") & "', '" & txtvName.Text.Replace("'", " ") & "', '" & txtvContact.Text.Replace("'", " ") & "', '" & txtvPODate.Text.Replace("'", " ") & "','" & txtvInstallDate.Text & " " & rblvSch.SelectedValue & "', '" &
                        txtvValidity.Text.Replace("'", " ") & "', '" & txtvDescr.Text.Replace("'", " ") & "','" & rblvType.SelectedValue & "','" & txtvECost.Text.Replace("'", " ") & "','" & txtACost.Text.Replace("'", " ") & "'," &
                        "'" & rblvTender.SelectedValue & "','" & txtvBider.Text.Replace("'", " ") & "','" & rblvLocation.SelectedValue & "','" & rblvApprover.SelectedValue & "',current_timestamp,'" & Session("email") & "',0 ,'" & txtvAddress.Text.Replace("'", "") & "', '" & rblCurrency.SelectedValue & "'  )"
        ' divMsgComplaint.InnerHtml = q
        Dim ret = executeDB(q, "appsdb")
        If ret.Contains("Error") Then
            divMsg.InnerHtml = "Unable to submit " & ret & q
            Exit Sub
        Else
            divMsg.InnerHtml = "Data Submitted succesfully. Checkout in report section."
            txtvUid.Text = getDBsingle("select max(uid)+1 From asset_vendor where 1 limit 1", "appsdb")
            txtvDescr.Text = ""
            txtvPODate.Text = ""
            txtvPO.Text = ""
        End If


        ''create message


        ' Response.Redirect("asset.aspx")
    End Sub

    'Private Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
    '    Session.Clear()
    '    Session.Abandon()
    '    Response.Redirect("Default.aspx")
    'End Sub

    Private Sub gvAdminStatus_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvAdminStatus.RowCommand
        Dim value = e.CommandArgument.ToString()
        lblCurrentID.Text = value
        Dim owner = getDBsingle("select name || ' ' || dept || ' ' || cell2 from  ntpcemp where eid in (select owner from asset_detail where uid = " & value & ") limit 1", "appsdb")
        If owner.Contains("Error") Then owner = "IT Dept"
        lblCurrentUser.Text = owner
        pnlAdminEdit.Visible = True

    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        If String.IsNullOrEmpty(txtEditDt.Text) Then
            divMsg.InnerHtml = "Enter Issue date"
            Exit Sub
        End If
        Dim q = "update asset_detail set owner = '" & ddlUidNew.SelectedValue & "', st_dt = '" & txtEditDt.Text & "', chain = chain || ' > ' ||  cast(owner as text) || ' ' || st_dt || ' ' where uid=" & lblCurrentID.Text
        Dim ret = executeDB(q, "appsdb")
        If ret.Contains("Error") Then
            divMsg.InnerHtml = "Unable to update" & ret & q
            Exit Sub
        End If
        'divMsg.InnerHtml = q
        Response.Redirect("asset.aspx?ctype=assign&ret=" & ret)
    End Sub

    Private Sub gvStatus_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvStatus.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    e.Row.Cells(3).Text = "<img src=images/" & e.Row.Cells(3).Text & ".png width=40px />"
        '    e.Row.Cells(5).Text = "<img src=images/" & e.Row.Cells(5).Text & ".png width=40px />"
        'End If

    End Sub

    Private Sub gvAdminStatus_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvAdminStatus.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then


            'If e.Row.Cells(11).ToString.Contains("Closed") Then
            '    Dim btnEdit = e.Row.FindControl("btnEdit")

            '    btnEdit.Visible = False
            '    '   e.Row.BackColor = Drawing.Color.LightGreen
            'End If
        End If
    End Sub

    Private Sub rblReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblReport.SelectedIndexChanged
        loadStatus("")
    End Sub
End Class
