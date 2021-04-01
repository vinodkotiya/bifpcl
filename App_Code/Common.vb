Imports Microsoft.VisualBasic

Public Class Common
    Public Shared Function strip(ByVal str As String) As String

        Return Regex.Replace(str, "[\[\]\\\^\$\|\?\/\*\'\+\(\)\{\}%,;><!@#\-\+]", "")
    End Function
    Public Shared Function makemenu(ByVal mobile As Boolean, Optional ByVal sel As Integer = 1, Optional ByVal newDashboard As Boolean = False) As String
        'http://191.254.1.42/cmg/
        Dim a1, a2, a3, a4, a5 As String
        If sel = 1 Then a1 = "active "
        If sel = 2 Then a2 = "active "
        If sel = 3 Then a3 = "active "
        If sel = 4 Then a4 = "active "
        If sel = 5 Then a5 = "active "

        Dim ul = "<ul class='list-unstyled navbar__list'>"
        If mobile Then ul = "<ul class='navbar-mobile__list list-unstyled'>"
        Dim ul1 = "  <ul class='list-unstyled navbar__sub-list js-sub-list'>"
        If mobile Then ul1 = "<ul class='navbar-mobile-sub__list list-unstyled js-sub-list'>"

        Dim color = "black"
        If newDashboard Then
            ul = "<ul class='list-unstyled'>"
            ul1 = "  <ul class='header3-sub-list list-unstyled'>"
            color = "white"
        End If



        Dim temp = ul &
             "<li  class='" & a4 & "'>" &
                         "   <a href ='Default.aspx' style='color:" & color & ";'>" &
                           "     <i Class='fas fa-home'></i>Home</a>" &
                        "</li>" &
                              "<li class='" & a1 & "has-sub'>" &
                           " <a class='js-arrow' href='#'  style='color:" & color & ";'>" &
                              "  <i class='fas fa-bars'></i>About</a>" &
                         ul1 &
                                "<li>" &
                              "      <a href ='about.aspx?mode=company'>Company</a>" &
                                "</li>" &
                                "<li>" &
                                 "   <a href='about.aspx?mode=board'>Board</a>" &
                                "</li>" &
                                "<li>" &
                                  "  <a href='#'>Organogram</a>" &
                                "</li>" &
                                "<li>" &
                                  "  <a href ='about.aspx?mode=faq'>FAQ</a>" &
                                "</li>" &
                                 "<li>" &
                                  "  <a href ='about.aspx?mode=contact'>Contact</a>" &
                                "</li>" &
                           " </ul>" &
                        "</li>" &
                         "<li class='" & a1 & "has-sub'>" &
                           " <a class='js-arrow' href='#'  style='color:" & color & ";' >" &
                              "  <i class='fas fa-tachometer-alt'></i>Projects</a>" &
                         ul1 &
                                "<li>" &
                              "      <a href ='dprMiles.aspx'>Milestone</a>" &
                                "</li>" &
                                "<li>" &
                                 "   <a href='dashboardTS.aspx'>Daily Progress</a>" &
                                "</li>" &
                                 "<li>" &
                                  "  <a href='dashboardTS'>Issues</a>" &
                                "</li>" &
                                "<li>" &
                                  "  <a href ='docstore.aspx'>DocStore</a>" &
                                "</li>" &
                                 "<li>" &
                                 "   <a href='gatepass.aspx'>Gate Pass System</a>" &
                                "</li>" &
                           " </ul>" &
                        "</li>" &
                        "<li class='" & a1 & "has-sub'>" &
                           " <a class='js-arrow' href='#'  style='color:" & color & ";' >" &
                              "  <i class='fas fa-mobile'></i>Apps</a>" &
                         ul1 &
                                "<li>" &
                              "      <a href ='hrBiometric.aspx?mode=attandance'>HR Services</a>" &
                                "</li>" &
                                "<li>" &
                                 "   <a href='hrBiometric.aspx'>Biometric Upload</a>" &
                                "</li>" &
                                "<li>" &
                                  "  <a href='asset.aspx'>Procurement</a>" &
                                "</li>" &
                                "<li>" &
                                  "  <a href ='hrBiometric.aspx?mode=calendar'>Holiday Calander</a>" &
                                "</li>" &
                                  "<li>" &
                                  "  <a href ='vehicle.aspx'>Vehicle Booking</a>" &
                                "</li>" &
                                  "<li>" &
                                  "  <a href ='#'>Guest House Booking</a>" &
                                "</li>" &
                                 "<li>" &
                                  "  <a href ='#'>Notice Board</a>" &
                                "</li>" &
 "<li>" &
                                  "  <a href ='SA/quiz/index.html'>Play Quiz</a>" &
                                "</li>" &
                           " </ul>" &
                        "</li>" &
                         "<!--<li  class='" & a4 & "'>" &
                         "   <a href ='safety.aspx'>" &
                           "     <i Class='fas fa-plus-square'></i>Safety</a>" &
                        "</li>" &
                        "<li class='" & a2 & "'>" &
                           " <a href ='docstoreX.aspx?section=" & HttpUtility.UrlEncode(dbOp.Encrypt("%")) & "&doctype=" & HttpUtility.UrlEncode(dbOp.Encrypt("tender")) & "'>" &
                           "     <i Class='fas fa-tasks'></i>Tenders</a>" &
                          "</li>" &
                       "<li class='" & a3 & "'>" &
                          "  <a href ='docstoreX.aspx?section=" & HttpUtility.UrlEncode(dbOp.Encrypt("PR")) & "&doctype=" & HttpUtility.UrlEncode(dbOp.Encrypt("news")) & "'>" &
                              "  <i Class='fas fa-picture-o'></i>Media</a>" &
                        "</li>" &
                        "<li>" &
                          "  <a href ='docstoreX.aspx?section=" & HttpUtility.UrlEncode(dbOp.Encrypt("HR")) & "&doctype=" & HttpUtility.UrlEncode(dbOp.Encrypt("career")) & "'>" &
                           "     <i Class='fas fa-users'></i>Careers</a>" &
                        "</li>" &
                        "<li>" &
                          "  <a href ='about.aspx?mode=contact'>" &
                           "     <i Class='fas fa-map-marker-alt'></i>Contacts</a>" &
                        "</li> -->" &
                        "<li Class='has-sub'>" &
                           " <a Class='js-arrow' href='#'  style='color:" & color & ";'>" &
                          "      <i Class='fas fa-copy'></i>Reports</a>" &
                          ul1 &
                                "<li>" &
                                   " <a href ='docstoreX.aspx?section=" & HttpUtility.UrlEncode(dbOp.Encrypt("EMG")) & "&doctype=" & HttpUtility.UrlEncode(dbOp.Encrypt("quarter")) & "'>Quarterly Monitoring</a>" &
                                "</li>" &
                                " <li> " &
                           " <a href='docstoreX.aspx?section=" & HttpUtility.UrlEncode(dbOp.Encrypt("common")) & "&doctype=" & HttpUtility.UrlEncode(dbOp.Encrypt("annual")) & "'>Annual Report</a>" &
                                "</li>" &
                            "<li>" &
                                 "   <a href ='docstoreX.aspx?section=" & HttpUtility.UrlEncode(dbOp.Encrypt("EMG")) & "&doctype=" & HttpUtility.UrlEncode(dbOp.Encrypt("eia")) & "'>EIA</a>" &
                                "</li>" &
                                 "<li>" &
                                 "   <a href ='docstoreX.aspx?section=" & HttpUtility.UrlEncode(dbOp.Encrypt("EMG")) & "&doctype=" & HttpUtility.UrlEncode(dbOp.Encrypt("eia")) & "'>Coal Transportation EIA</a>" &
                                "</li>" &
                                 "<li>" &
                                 "   <a href ='docstoreX.aspx?section=" & HttpUtility.UrlEncode(dbOp.Encrypt("COMMON")) & "&doctype=" & HttpUtility.UrlEncode(dbOp.Encrypt("others")) & "'>Others</a>" &
                                "</li>" &
                           " </ul>" &
                        "</li>" &
                                         "  </ul>"

        Return temp
    End Function
    Public Shared Function getNotification(ByVal eid As String, Optional ByVal newDashboard As Boolean = False) As String

        'http://nd2.godesign.ch/examples/extended/icons.html 
        Dim div = "notifi-dropdown js-dropdown"
        Dim extradiv = ""
        If newDashboard Then
            div = "notifi-dropdown notifi-dropdown--no-bor js-dropdown"
            extradiv = "</div>"
        End If
        Dim time = dbOp.getDBsingle("select  strftime('%d.%m.%Y', max(progdate))  as d FROM ProgressDetails where act is not null or act = '' or act = 0 limit 1", "dprdb")
        Dim view = dbOp.getDBsingle("select sum(view) from hits ")
        Dim doc = dbOp.getDBsingle("select type || ' by ' || section || ' uploaded' from upload where 1 order by last_updated desc limit 1  ")
        Dim docdt = dbOp.getDBsingle("select strftime('%d.%m.%Y %H:%m',last_updated)  from upload where 1 order by last_updated desc limit 1  ")
        Dim temp = " <i class='zmdi zmdi-notifications'></i> " &
                                  "      <span class='quantity'>3</span> " &
                                    "         <div class='" & div & "' style='margin-left: 70px;'> " &
                                          "       <div class='notifi__title'> " &
                                               "      <p> You have 3 Notifications</p> " &
                                   "              </div> " &
                                  "               <div class='notifi__item'> " &
                                 "                    <div Class='bg-c1 img-cir img-40'> " &
                                 "                        <i Class='zmdi zmdi-globe'></i> " &
                                 "                    </div> " &
                                "                     <div class='content'> " &
                                  "                       <p> Website last updated</p> " &
                                    "                       <span class='date'>" & time & "</span> " &
                                "                     </div> " &
                                 "                </div> " &
                                 "                <div Class='notifi__item'> " &
                                 "                    <div Class='bg-c2 img-cir img-40'> " &
                                  "                       <i Class='zmdi zmdi-account-box'></i> " &
                                   "                  </div> " &
                                    "                 <div class='content'> " &
                                    "                     <p> Total Visitors</p> " &
                                     "                    <span class='date'>" & view & " , Online: " & System.Web.HttpContext.Current.Application("OnlineUsers") & "</span> " &
                                     "                </div> " &
                                   "              </div> " &
                                    "             <div Class='notifi__item'> " &
                                     "                <div Class='bg-c3 img-cir img-40'> " &
                                      "                   <i Class='zmdi zmdi-file-text'></i> " &
                                      "               </div> " &
                                      "               <div class='content'> " &
                                      "                   <p>" & doc & "</p> " &
                                      "                   <span class='date'>" & docdt & "</span> " &
                                      "               </div> " &
                                       "          </div> " &
                                       "          <div Class='notifi__footer'> " &
                                        "             <a href ='#'>All notifications</a> " &
                                        "         </div> " & extradiv
        Return temp
    End Function
    Public Shared Function showAccount(Optional ByVal email As String = "email@bifpcl.com", Optional ByVal newDashboard As Boolean = False) As String
        Dim div = "account-item clearfix js-item-menu"
        Dim color = "black"
        If newDashboard Then
            div = "account-item account-item--style2 clearfix js-item-menu"
            color = "white"
        End If
        If String.IsNullOrEmpty(email) Then


            Return "<div class='" & div & "'> " &
                             "               <div class='image'> " &
                          "<span onclick=" & Chr(34) & "location.href='sso/Default.aspx?appid=12343272';" & Chr(34) & "><img src='upload/employee/pics/user.png' /> </span> " &
                              "              </div> " &
                               "             <div class='content'> " &
                               "                 <a class='account-dropdown__footer'><span onclick=" & Chr(34) & "location.href='sso/Default.aspx?appid=12343272';" & Chr(34) & ">Login</span></a> " &
                             "               </div> </div>"
        End If
        Dim mydt = dbOp.getDBTable("select name, desig, cell, email,rax, uid from contacts_New where email = '" & email & "'", "hrdb")
        If mydt.Rows.Count = 0 Then
            Dim profilelink = "#"
            If email.Contains("admin@bifpcl.com") Then profilelink = "profile.aspx"
            Return " <div class='" & div & "'> " &
                             "               <div class='image'> " &
                          "<img width=45px height=44px src='upload/employee/pics/user.png' onerror=" & Chr(34) & "this.src='upload/employee/pics/user.png';" & Chr(34) & " /> " &
                              "              </div> " &
                               "             <div class='content'> " &
                               "                 <a Class='js-acc-btn' href='#'>" & email & "</a> " &
                             "               </div> " &
                             "               <div class='account-dropdown js-dropdown'> " &
                             "                   <div Class='info clearfix'> " &
                                   "                    <div class='content'> " &
                                  "                      <h5 Class='name'> " &
                                   "                         <a href='" & profilelink & "'>Unknown</a> " &
                                   "                     </h5> " &
                    "    <span class='email'>" & email & "</span> " &
                           "                         </div> " &
                                  "              </div> " &
                                 "            <div class='account-dropdown__footer'> " &
                                    "                <a href ='profile.aspx?logout=1'> " &
                                    "                    <i class='zmdi zmdi-power'></i>Logout</a> " &
                                    "            </div> " &
                                   "         </div> " &
                                  "      </div> "
        End If

        Dim pic = mydt.Rows(0)("uid") & ".jpg"
        'If Not IO.File.Exists(Server.MapPath("./upload/employee/pics/" & pic)) Then pic = "user.png"

        Dim temp = " <div class='" & div & "'> " &
                             "               <div class='image'> " &
                          "<img width=45px height=44px src='upload/employee/pics/" & pic & "' onerror=" & Chr(34) & "this.src='upload/employee/pics/user.png';" & Chr(34) & " /> " &
                              "              </div> " &
                               "             <div class='content'> " &
                               "                 <a Class='js-acc-btn' href='#'  style='font-size:12px;color:" & color & ";'>" & mydt.Rows(0)("name") & "</a> " &
                             "               </div> " &
                             "               <div class='account-dropdown js-dropdown'> " &
                             "                   <div Class='info clearfix'> " &
                              "                      <div Class='image'> " &
                              "                          <a href='#'> " &
                             "<img width=65px height=65px src='upload/employee/pics/" & pic & "' onerror=" & Chr(34) & "this.src='upload/employee/pics/user.png';" & Chr(34) & " /> " &
                               "                         </a> " &
                                "                    </div> " &
                                "                    <div class='content'> " &
                                  "                      <h5 class='name'> " &
                                   "                         <a href='#'>" & mydt.Rows(0)("name") & "</a> " &
                                   "                     </h5> " &
                    "    <span Class='email'>" & email & "</span> " &
                           "                         </div> " &
                                  "              </div> " &
                                 "               <div class='account-dropdown__body'> " &
                                   "                 <div class='account-dropdown__item'> " &
                                    "                    <a href ='profile.aspx'> " &
                                     "                       <i class='zmdi zmdi-account'></i>Profile</a> " &
                                     "               </div> " &
                                      "              <div class='account-dropdown__item'> " &
                                     "                   <a href ='profile.aspx?mode=change'> " &
                                     "                       <i class='zmdi zmdi-settings'></i>Change Password</a> " &
                                      "              </div> " &
                                      "          </div> " &
                                    "            <div class='account-dropdown__footer'> " &
                                    "                <a href ='profile.aspx?logout=1'> " &
                                    "                    <i class='zmdi zmdi-power'></i>Logout</a> " &
                                    "            </div> " &
                                   "         </div> " &
                                  "      </div> "
        Return temp
    End Function
    Public Shared Function makeappmenu(ByVal url As String, Optional ByVal sel As Integer = 1) As String
        'http://191.254.1.42/cmg/
        Dim a1, a2, a3, a4, a5, a6, a7 As String
        If sel = 1 Then a1 = "class='current'"
        If sel = 2 Then a2 = "class='current'"
        If sel = 3 Then a3 = "class='current'"
        If sel = 4 Then a4 = "class='current'"
        If sel = 5 Then a5 = "class='current'"
        If sel = 6 Then a6 = "class='current'"
        If sel = 7 Then a7 = "class='current'"

        Dim temp = "<ul class='sf-menu'><li ><a href='epace.aspx'>Dashboard</a></li> " &
              " <li " & a1 & "><a href='" & url & "?mode=1'>Basic Information</a></li> " &
                    "<li  " & a2 & "> <a  href='" & url & "?mode=2'>Responsibility</a> </li>" &
                "	<li  " & a3 & ">  <a href ='" & url & "?mode=3'>Tasks/KPA</a></li> " &
                "	<li  " & a4 & ">	<a href ='" & url & "?mode=4' >Self Assessment</a>		</li>" &
                   "	<li  " & a6 & ">	<a href ='" & url & "?mode=6' >Competencies</a>		</li>" &
                       "	<li  " & a7 & ">	<a href ='" & url & "?mode=7' >Attachments</a>		</li>" &
                 "	<li  " & a5 & ">	<a href ='" & url & "?mode=5' >Submit</a>		</li>" &
                  "  <li  " & a1 & ">   <a href='admin.aspx?mode=-1'>Log Out</a>   </li>	</ul>"

        Return temp
    End Function
    Public Shared Function makeappmenuW(ByVal url As String, Optional ByVal sel As Integer = 1) As String
        'http://191.254.1.42/cmg/
        Dim a1, a2, a3, a4, a5, a6, a7 As String
        If sel = 1 Then a1 = "class='current'"
        If sel = 2 Then a2 = "class='current'"
        If sel = 3 Then a3 = "class='current'"
        If sel = 4 Then a4 = "class='current'"
        If sel = 5 Then a5 = "class='current'"
        If sel = 6 Then a6 = "class='current'"
        If sel = 7 Then a7 = "class='current'"

        Dim temp = "<ul class='sf-menu'><li ><a href='epacew.aspx'>Dashboard</a></li> " &
              " <li " & a1 & "><a href='" & url & "?mode=1'>Basic Information</a></li> " &
                "	<li  " & a2 & ">	<a href ='" & url & "?mode=2' >Rating</a>		</li>" &
                 "<li  " & a3 & "> <a  href='" & url & "?mode=3'>Assessment</a> </li>" &
                "	<li  " & a5 & ">	<a href ='" & url & "?mode=5' >Submit</a>		</li>" &
                  "  <li  " & a1 & ">   <a href='admin.aspx?mode=-1'>Log Out</a>   </li>	</ul>"

        Return temp
    End Function
    Public Shared Function makereportmenu(Optional ByVal sel As Integer = 1) As String
        'http://191.254.1.42/cmg/
        Dim a0, a1, a2, a3, a4, a5 As String
        If sel = 0 Then a0 = "class='current'"
        If sel = 1 Then a1 = "class='current'"
        If sel = 2 Then a2 = "class='current'"
        If sel = 3 Then a3 = "class='current'"
        If sel = 4 Then a4 = "class='current'"
        If sel = 5 Then a5 = "class='current'"

        Dim temp = "<ul class='sf-menu'><li " & a0 & "><a href='reports.aspx?mode=0'>Simulate</a></li> " &
                 "<li  " & a1 & "> <a  href='reports.aspx?mode=1'>KPA</a> </li>" &
                 "<li  " & a2 & "> <a  href='reports.aspx?mode=2'>WorkFlow Maintenance</a> </li>" &
                "	<li  " & a3 & ">  <a href ='reports.aspx?mode=3'>Refresh Data</a></li> " &
                "	<li  " & a4 & ">	<a href ='reports.aspx?mode=4' >z</a>		</li>" &
                  "  <li  " & a5 & ">   <a href='reports.aspx?mode=5'>xx</a>   </li>	</ul>"

        Return temp
    End Function
    Public Shared Function makeAdminmenu(ByVal isAdmin As String, Optional ByVal sel As Integer = 1) As String
        'http://191.254.1.42/cmg/
        Dim a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a99, a98, a11, a41, a61 As String
        If sel = 0 Then a0 = "class='current'"
        If sel = 1 Then a1 = "class='current'"
        If sel = 2 Then a2 = "class='current'"
        If sel = 3 Then a3 = "class='current'"
        If sel = 4 Then a4 = "class='current'"
        If sel = 5 Then a5 = "class='current'"
        If sel = 6 Then a6 = "class='current'"
        If sel = 7 Then a7 = "class='current'"
        If sel = 8 Then a8 = "class='current'"
        If sel = 9 Then a9 = "class='current'"
        If sel = 99 Then a99 = "class='current'"
        If sel = 98 Then a98 = "class='current'"
        If sel = 61 Then a61 = "class='current'"
        If sel = 41 Then a41 = "class='current'"
        Dim temp = ""
        If isAdmin = "1" Then
            temp = "<ul class='sf-menu'><li " & a0 & "><a href='admin.aspx?mode=0'>Simulate</a></li> " &
                  "<li " & a98 & "> <a  href='admin.aspx?mode=98'>Support</a> </li>" &
                 "<li  " & a2 & "> <a  href='admin.aspx?mode=2'>WorkFlow</a> </li>" &
                "	<li  " & a3 & ">  <a href ='admin.aspx?mode=3'>Upload</a></li> " &
                "	<li  " & a4 & ">	<a href ='admin.aspx?mode=4' >Bulk Create</a>		</li>" &
                 "	<li  " & a41 & ">	<a href ='admin.aspx?mode=41' >Create</a>		</li>" &
                  "	<li  " & a7 & ">	<a href ='admin.aspx?mode=7' >Delete</a>		</li>" &
                  "  <li  " & a5 & ">   <a href='admin.aspx?mode=5'>Change</a>   </li>	" &
          "  <li  " & a6 & ">   <a href='admin.aspx?mode=6'>PACE Officer</a>   </li>	" &
           "  <li  " & a6 & ">   <a href='admin.aspx?mode=69'>SMS</a>   </li>	" &
           "  <li  " & a61 & ">   <a href='admin.aspx?mode=61'>Proj</a>   </li>	" &
            "  <li  " & a9 & ">   <a href='admin.aspx?mode=9'>Sep</a>   </li>	" &
            "  <li  " & a8 & ">   <a href='admin.aspx?mode=8'>Report</a>   </li>	" &
          "  	</ul>"
        ElseIf isAdmin = "2" Then
            temp = "<ul class='sf-menu'>" &
                  "<li  " & a1 & "> <a  href='Default.aspx?eid=0'>Home</a> </li>" &
                   "<li  " & a98 & "> <a  href='admin.aspx?mode=98'>Support</a> </li>" &
            "<li  " & a2 & "><a href='admin.aspx?mode=2'>WorkFlow</a></li>" &
              "	<li  " & a4 & ">	<a href ='admin.aspx?mode=41' >Create Forms</a>		</li>" &
                "  <li  " & a5 & ">   <a href='admin.aspx?mode=5'>Change Status</a>   </li>	" &
                  "  <li  " & a6 & ">   <a href='admin.aspx?mode=61'>PACE Officer</a>   </li>	" &
         "  <li  " & a9 & ">   <a href='admin.aspx?mode=9'>Seperated</a>   </li>	" &
             "  <li  " & a8 & ">   <a href='admin.aspx?mode=8'>Report</a>   </li>	" &
        " 	</ul>"
        Else
            temp = "<ul class='sf-menu'>" &
                 "<li  " & a1 & "> <a  href='Default.aspx?eid=0'>Home</a> </li>" &
                    "<li  " & a98 & "> <a  href='admin.aspx?mode=98'>Support(E1-E7)</a> </li>" &
                    "<li  " & a2 & "> <a  href='admin.aspx?mode=2'>Workflow(E8+)</a> </li>" &
           "  <li  " & a8 & ">   <a href='admin.aspx?mode=8'>Report(E8+)</a>   </li>	" &
       " 	</ul>"
        End If


        Return temp
    End Function

    Public Shared Function makeAdminmenuW(ByVal isAdmin As String, Optional ByVal sel As Integer = 1) As String
        'http://191.254.1.42/cmg/
        Dim a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a99, a98, a11, a41, a61 As String
        If sel = 0 Then a0 = "class='current'"
        If sel = 1 Then a1 = "class='current'"
        If sel = 2 Then a2 = "class='current'"
        If sel = 3 Then a3 = "class='current'"
        If sel = 4 Then a4 = "class='current'"
        If sel = 5 Then a5 = "class='current'"
        If sel = 6 Then a6 = "class='current'"
        If sel = 7 Then a7 = "class='current'"
        If sel = 8 Then a8 = "class='current'"
        If sel = 9 Then a9 = "class='current'"
        If sel = 99 Then a99 = "class='current'"
        If sel = 98 Then a98 = "class='current'"
        If sel = 61 Then a61 = "class='current'"
        If sel = 41 Then a41 = "class='current'"

        Dim mysubord = ""
        If sel = 991 Then
            a99 = "class='current'"
            mysubord = "	<li >	<a href ='epacew.aspx?mode=0' >My Subord</a>		</li> "
        End If

        Dim temp = ""
        If isAdmin = "1" Then
            temp = "<ul class='sf-menu'><li " & a0 & "><a href='adminw.aspx?mode=0'>Simulate</a></li> " & mysubord &
                 " <li  " & a2 & "> <a  href='adminw.aspx?mode=2'>WorkFlow</a> </li>" &
                "	<li  " & a3 & ">  <a href ='adminw.aspx?mode=3'>Upload</a></li> " &
                "	<li  " & a4 & ">	<a href ='adminw.aspx?mode=4' >Bulk Create</a>		</li>" &
                 "	<li  " & a41 & ">	<a href ='adminw.aspx?mode=41' >Create</a>		</li>" &
                  "	<li  " & a7 & ">	<a href ='adminw.aspx?mode=7' >Delete</a>		</li>" &
                   "  <li  " & a6 & ">   <a href='adminw.aspx?mode=69'>SMS/Email</a>   </li>	" &
            "  <li  " & a8 & ">   <a href='adminw.aspx?mode=8'>Report</a>   </li>	" &
          "  	</ul>"
        ElseIf isAdmin = "2" Then
            temp = "<ul class='sf-menu'>" & " " & mysubord &
                  "<li  " & a1 & "> <a  href='Default.aspx?eid=0'>Home</a> </li>" &
                 "<li  " & a2 & "><a href='adminw.aspx?mode=2'>WorkFlow</a></li>" &
              "	<li  " & a4 & ">	<a href ='adminw.aspx?mode=41' >Create Forms</a>		</li>" &
                      "  <li  " & a6 & ">   <a href='adminw.aspx?mode=69'>SMS/Email</a>   </li>	" &
              "  <li  " & a8 & ">   <a href='adminw.aspx?mode=8'>Report</a>   </li>	" &
        " </ul>"
        Else
            temp = "<ul class='sf-menu'>" & mysubord &
                 " <li  " & a1 & "> <a  href='Default.aspx?eid=0'>Home</a> </li>" &
                   "<li  " & a2 & "> <a  href='adminw.aspx?mode=2'>Workflow(W/S)</a> </li>" &
                           "  <li  " & a6 & ">   <a href='adminw.aspx?mode=69'>SMS/Email</a>   </li>	" &
           "  <li  " & a8 & ">   <a href='adminw.aspx?mode=8'>Report(W/S)</a>   </li>	" &
       "  	</ul>"
        End If


        Return temp
    End Function
    Public Shared Function makeePACEmenu(ByVal sel As String, ByVal workmentab As Boolean, ByVal createnew As Boolean) As String
        Dim a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a99, a98, a11, a41, a61 As String
        If sel = "0" Then a0 = "class='current'"
        If sel = "1" Then a1 = "class='current'"
        If sel = "2" Then a2 = "class='current'"
        If sel = "3" Then a3 = "class='current'"
        If sel = "create" Then a4 = "class='current'"
        Dim tab = ""
        Dim createtab = ""
        If workmentab Then tab = "<li class='current1'> <a href='epacew.aspx?mode=0'>Dashboard (W/S)</a></li>"
        If createnew Then createtab = "  <li  " & a4 & ">   <a href='epace.aspx?mode=create'>Create New Forms(E8+)</a>   </li>	"

        'http://191.254.1.42/cmg/
        Dim temp = "<ul class='sf-menu'><li  " & a0 & "> <a href='epace.aspx?mode=0'>Dashboard (E8+)</a></li> " &
            tab & createtab &
         "  <li  " & a2 & ">   <a href='epace.aspx?mode=2'>Support Message</a>   </li>	" &
        "  <li  " & a3 & ">   <a href='epace.aspx?mode=3'>Help Doc</a>   </li>	" &
                 "  <li >   <a href='admin.aspx?mode=-1'>Log Out</a>   </li>	</ul>"

        Return temp
    End Function
    Public Shared Function makeePACEmenuWS(ByVal sel As String, ByVal dualtab As Boolean) As String
        Dim a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a99, a98, a11, a41, a61 As String
        If sel = "0" Then a0 = "class='current'"
        If sel = "1" Then a1 = "class='current'"
        If sel = "2" Then a2 = "class='current'"
        If sel = "3" Then a3 = "class='current'"
        If sel = "createws" Then a4 = "class='current'"
        Dim tab = ""
        If dualtab Then tab = "<li class='current1'> <a href='epace.aspx?mode=0'>Dashboard (E8+)</a></li>"
        'http://191.254.1.42/cmg/
        Dim temp = "<ul class='sf-menu'> " & tab & "<li  " & a0 & "> <a href='epacew.aspx?mode=0'>Dashboard(W/S)</a></li> " &
            "  <li  " & a4 & ">   <a href='epacew.aspx?mode=createws'>Create Forms(WS)</a>   </li>	" &
               "  <li  " & a2 & ">   <a href='epacew.aspx?mode=2'>Support Message</a>   </li>	" &
        "  <li  " & a3 & ">   <a href='epacew.aspx?mode=3'>Help Doc</a>   </li>	" &
                 "  <li >   <a href='admin.aspx?mode=-1'>Log Out</a>   </li>	</ul>"

        Return temp
    End Function
End Class
