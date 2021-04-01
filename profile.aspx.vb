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

Partial Class _profile
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        '   Session("email") = "tanvirahamed@bifpcl.com"
        If Not Page.IsPostBack Then
            If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343272")
            If checkAuthorization(Session("email"), "profile.aspx") Then
                Dim q As String = "Select distinct name || '  ' || workarea as t, email as v from contacts_New where email is not null and email <> '' order by workarea desc, name asc"
                ddlProfile.DataTextField = "t"
                ddlProfile.DataValueField = "v"
                ddlProfile.DataSource = getDBTable(q, "hrdb")
                ddlProfile.DataBind()
                ddlProfile.Visible = True
                txtBIO.Enabled = True
                txtEid.Enabled = True
                rblDel.Enabled = True
            End If
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
                divSideMenu.InnerHtml = makemenu(False, 2)
                divNotification.InnerHtml = getNotification(1)
                '   divLogin.InnerHtml = showAccount("9383", "Vinod Kumar Kotiya", "vinodkotiya@ntpc.co.in")
                divLogin.InnerHtml = showAccount(Session("email"))
                If Request.Params("logout") = "1" Then
                    Session.Clear()
                    Session.Abandon()
                    divLogout.Visible = True
                    Exit Sub
                ElseIf Request.Params("mode") = "change" Then
                    Exit Sub
                End If

                divProfile.Visible = True
                Session("updateemail") = Session("email")
                loadProfile()
            End If

            executeDB("update hits set view = view+1 where page = 'profile'")
        executeDB("insert into login (eid, log, logintime) values (0, 'Profile Page Access : at " & Now.ToString() & "" & Session("updateemail") & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub
    Sub loadProfile()
        Dim mydt = dbOp.getDBTable("select name, desig, bioid, cell, email,rax, id ,uid, workarea, dept, bgrp, org,cell2, whatsapp, strftime('%d.%m.%Y', dob) as dob, eid, del from contacts_New where email = '" & Session("updateemail") & "'", "hrdb")
        If mydt.Rows.Count = 0 Then
            divMsg.InnerHtml = "You are not BIFPCL Employee or your email id has changed. Register again in SSO."
            btnSubmit.Enabled = False
            Exit Sub
        End If
        divMsg.InnerHtml = "You are  BIFPCL Employee."
        btnSubmit.Enabled = True
        txtName.Text = If(IsDBNull(mydt.Rows(0)("name")), "", mydt.Rows(0)("name"))
        txtDesig.Text = If(IsDBNull(mydt.Rows(0)("desig")), "", mydt.Rows(0)("desig"))
        txtCell.Text = If(IsDBNull(mydt.Rows(0)("cell")), "", mydt.Rows(0)("cell"))
        txtemail.Text = If(IsDBNull(mydt.Rows(0)("email")), "", mydt.Rows(0)("email"))
        txtRax.Text = If(IsDBNull(mydt.Rows(0)("rax")), "", mydt.Rows(0)("rax"))
        txtBirthDate.Text = If(IsDBNull(mydt.Rows(0)("dob")), "", mydt.Rows(0)("dob"))
        txtDept.Text = If(IsDBNull(mydt.Rows(0)("dept")), "", mydt.Rows(0)("dept")).replace("NA", "")
        txtBIO.Text = If(IsDBNull(mydt.Rows(0)("bioid")), "", mydt.Rows(0)("bioid")).ToString.Replace("NA", "")
        Dim blood = If(IsDBNull(mydt.Rows(0)("bgrp")), "", mydt.Rows(0)("bgrp"))
        If String.IsNullOrEmpty(blood) Then
            ddlBlood.SelectedValue = "NA"
        Else
            ddlBlood.SelectedValue = blood
        End If

        If txtRax.Text = "0" Then txtRax.Text = ""
        lblID.Text = mydt.Rows(0)("id")
        rblType.SelectedValue = mydt.Rows(0)("workarea")
        rblOrg.SelectedValue = mydt.Rows(0)("org")
        rblDel.SelectedValue = mydt.Rows(0)("del")
        txtEid.Text = If(IsDBNull(mydt.Rows(0)("uid")), "", mydt.Rows(0)("uid")).ToString.Replace("NA", "")
        Dim thefile = lblID.Text & ".jpg"
        '   Image1.ImageUrl = "/upload/employee/pics/" & thefile
        divPic.InnerHtml = "<img src=" & "/upload/employee/pics/" & thefile & "?" & Now.Second & "  onerror=" & Chr(34) & "this.src='upload/employee/pics/user.png';" & Chr(34) & " />"
    End Sub
    Protected Sub UploadFile(sender As Object, e As EventArgs)
        If FileUpload1.HasFile Then
            Dim folderPath As String = Server.MapPath("./upload/employee/pics/")

            'Check whether Directory (Folder) exists.
            If Not Directory.Exists(folderPath) Then
                'If Directory (Folder) does not exists Create it.
                Directory.CreateDirectory(folderPath)
            End If

            'Save the File to the Directory (Folder).
            Dim thefile = txtEid.Text & ".jpg"   'FileUpload1.FileName
            FileUpload1.SaveAs(folderPath & thefile)

            'Display the Picture in Image control.
            '  Image1.ImageUrl = "/upload/employee/pics/" & thefile
            divPic.InnerHtml = "<img src=" & "/upload/employee/pics/" & thefile & "?" & Now.Second & " />"
        Else
            divMsg.InnerHtml = "Please attach a picture"
        End If

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If String.IsNullOrEmpty(txtName.Text) Or String.IsNullOrEmpty(txtDesig.Text) Or String.IsNullOrEmpty(txtemail.Text) Or String.IsNullOrEmpty(txtCell.Text) Then
            divMsg.InnerHtml = "All fields are mandatory"
            Exit Sub
        End If
        Dim dob = DateTime.ParseExact(txtBirthDate.Text, "dd.MM.yyyy", Nothing)
        Dim q = "update contacts_New set name = '" & txtName.Text.Replace("'", "") & "', desig ='" & txtDesig.Text.Replace("'", "") & "', cell = '" & txtCell.Text.Replace("'", "") & "', email = '" & txtemail.Text.Replace("'", "") & "',rax ='" & txtRax.Text.Replace("'", "") & "' , workarea = '" & rblType.SelectedValue & "', dept = '" & txtDept.Text.Replace("'", "") & "', bgrp='" & ddlBlood.SelectedValue & "', org = '" & rblOrg.SelectedValue & "', cell2 = '" & txtCell2.Text.Replace("'", "") & "', whatsapp = '" & txtWhatsapp.Text.Replace("'", "") & "', dob = '" & dob.ToString("yyyy-MM-dd") & "', bioid='" & txtBIO.Text.Replace("'", "") & "', uid = '" & txtEid.Text.Replace("'", "") & "', del = " & rblDel.SelectedValue & "   where email = '" & Session("updateemail") & "'"

        Dim ret = executeDB(q, "hrdb")
        If ret = "ok" Then
            divMsg.InnerHtml = "Data updated sucessfully <a href=default.aspx>Click here to go back</a>" '& q
            btnSubmit.Enabled = False
        Else
            divMsg.InnerHtml = "Data not updaed " & q
        End If
    End Sub

    Private Sub ddlProfile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProfile.SelectedIndexChanged
        Session("updateemail") = ddlProfile.SelectedValue
        loadProfile()
    End Sub
End Class
