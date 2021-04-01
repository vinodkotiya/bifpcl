Imports Common
Imports dbOp
'Imports DotNet.Highcharts
'Imports DotNet.Highcharts.Options
'Imports DotNet.Highcharts.Options.Series
'Imports DotNet.Highcharts.Attributes
'Imports DotNet.Highcharts.Helpers
'Imports DotNet.Highcharts.Enums
'Imports System.Data
'Imports System.Drawing

Partial Class _About
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2, True)
            divNotification.InnerHtml = getNotification(1)
            divNotificationMobile.InnerHtml = getNotification(1, True)
            divLogin.InnerHtml = showAccount(Session("email"), True)
            divLoginMobile.InnerHtml = showAccount(Session("email"), True)
            If Request.Params("mode") = "company" Then
                divCompany.Visible = True
            ElseIf Request.Params("mode") = "faq" Then
                divFAQ.Visible = True
            ElseIf Request.Params("mode") = "org" Then
                divOrg.Visible = True
            ElseIf Request.Params("mode") = "contact" Then
                If Not Request.Params("bypass") Is Nothing Then

                ElseIf Not (checkAuthorization(Session("email"), "onlybifpcl")) Then
                    divBday.InnerHtml = "Restricted display of contact list. Only for BIFPCL Executives. <br/> BIFPCL Head Office Address:Level-17,Borak Unique Heights, Kazi Nazrul Islam Avenue,Eskaton, Dhaka,1217"
                    divContactList.Visible = False
                    divContact.Visible = True
                    Exit Sub
                End If
                Dim bday = getDBsingle("select group_concat('&nbsp;<i class=''fa fa-gift''></i>&nbsp;' || name || ' on ' || strftime('%d.%m' ,newdob)) from (select name , dob, strftime('%Y', current_timestamp) || '-' || strftime('%m', dob) || '-' || strftime('%d', dob) as newdob from contacts_New where newdob > current_date  order by newdob asc limit 3)", "hrdb")
                divBday.InnerHtml = "<span class='badge badge-pill badge-success'>Upcoming Birthday:</span><br/>" &
                                            bday
                divContact.Visible = True
                loadContact("Site Office")
            Else
                divBoard.Visible = True
            End If

        End If
        executeDB("update hits set view = view+1 where page = 'about'")
        executeDB("insert into login (eid, log, logintime) values (0, 'About Page Access " & Request.Params("mode") & ": at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub
    Sub loadContact(ByVal type As String)
        Dim contacts As String
        'If Cache("contacts" & type) Is Nothing Then

        Dim q = "select name, desig, cell, email,rax, uid, dept, bgrp, org, cell2, whatsapp  from contacts_New where del=0 and dept = 'NA' order by printorder"
        If type = "Head Office" Then
            q = "select name, desig, cell, email,rax, uid, dept, bgrp, org, cell2, whatsapp   from contacts_New where  del=0 and  workarea = 'HO' and not dept = 'Support' order by printorder"
        ElseIf type = "Site Office" Then
            q = "select name, desig, cell, email,rax, uid, dept, bgrp, org, cell2, whatsapp   from contacts_New where  del=0 and  workarea = 'SO' and not dept = 'Support' order by printorder"
        ElseIf type = "Support Staff" Then
            q = "select name, desig, cell, email,rax, uid , dept, bgrp, org, cell2, whatsapp  from contacts_New where   del=0 and  dept = 'Support' order by printorder"
        ElseIf type = "Vendors" Then
            q = "select 'Yet to add' as name,  '' as desig, '' as cell, '' as email,rax, id, dept, bgrp  from contacts_New where  del=0  limit 1 "
        Else
            ''search
            q = "select name, desig, cell, email,rax, uid, dept, bgrp, org, cell2, whatsapp  from contacts_New where  del=0 and  (dept = 'Support' or dept = 'NA') and name like '%" & type & "%' or cell like  '%" & type & "%' or email  like '%" & type & "%' order by printorder"
            type = "Search"
            End If
            divH3.InnerHtml = type & " Contacts"
            Dim mydt = getDBTable(q, "hrdb")
            If mydt.Rows.Count = 0 Then
                contacts = "<div class='au-message__item unread'> " &
                                                       " <div class='au-message__item-inner'> " &
                                                          "    <div class='au-message__item-text'> " &
                                                            "      <div class='avatar-wrap'> " &
                                                            "    </div> " &
                                                             "     <div class='text'> " &
                                                             "         <h5 class='name' style='padding-left: 123px;'>Not Found</h5> " &
                                                              "        <p></p> " &
                                                             "     </div> " &
                                                            "  </div> " &
                                                         "  </div> " &
                                                    "  </div>"
                divContactList.InnerHtml = contacts
                Exit Sub
            End If
            For Each r In mydt.Rows
                If String.IsNullOrEmpty(r("email")) Then r("email") = "Email NA"
            Dim pic = r("uid") & ".jpg"
            If Not IO.File.Exists(Server.MapPath("./upload/employee/pics/" & pic)) Then pic = "user.png"
                Dim online = " online"
                If r("org") = "NTPC" Then online = ""
                Dim contact = "<div class='au-message__item unread'> " &
                                                   " <div class='au-message__item-inner'> " &
                                                      "    <div class='au-message__item-text'> " &
                                                        "      <div class='avatar-wrap" & online & "'> " &
                                                         "         <div class='avatar' style='height: 160px; width: 160px;'> " &
                                                          "            <img src='\upload\employee\pics\" & pic & "' alt='" & r("name") & "'  onerror=" & Chr(34) & "this.src='\upload\employee\pics\user.png';" & Chr(34) & " /> " &
                                                           "       </div> " &
                                                          "    </div> " &
                                                         "     <div class='text'  style='display: inline-block;'> " &
                                                         "         <h5 class='name'>" & r("name") & "</h5> " &
                                                          "        <p>" & r("desig") &
                                                              " <br/>Dept: " & r("dept") & " </a> " &
                                                              " <br/> <a href='tel:" & r("cell") & "' onclick='call(""" & r("cell") & """);' > <i class='fa fa-mobile'></i>&nbsp;&nbsp;" & r("cell") & " </a> " &
                                                                " <br/> <a href='mailto:" & r("email") & "'> <i class='fa fa-envelope'></i>&nbsp;&nbsp;" & r("email") & " </a> " &
                                                           " <br/>Rax: " & r("rax") & " </a> " &
                                                               " <br/>Blood Grp: " & r("bgrp") & " </a> " &
                                                        "</p> " &
                                                         "     </div> " &
                                                        "  </div> " &
                                                     "  </div> " &
                                                "  </div>"
                contacts = contacts & " " & contact
            Next
        'Cache.Insert("contacts" & type, contacts, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
        'End If
        divContactList.InnerHtml = contacts
    End Sub

    Private Sub rblType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblType.SelectedIndexChanged
        If rblType.SelectedValue = "PABX List" Then
            Response.Redirect("upload/various/pabx.pdf")
            Exit Sub
        End If
        loadContact(rblType.SelectedValue)
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        loadContact(txtSearch.Text)
    End Sub
End Class
