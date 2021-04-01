<%@ Page Language="VB" AutoEventWireup="false" CodeFile="profile.aspx.vb" Inherits="_profile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BIFPCL</title>
     <!-- Required meta tags-->
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="BIFPCL Official Website" />
    <meta name="author" content="Vinod Kotiya" />
    <meta name="keywords" content="NTPC, BIFPCL, Maitree Thermal Power Project, Khulna, Bangladesh India Friendship Power Corporation Limited" />
    <link href='favicon.ico' rel='icon' type='image/x-icon'/>
 
    <!-- Fontfaces CSS-->
    <link href="css/font-face.css" rel="stylesheet" media="all" />
    <link href="vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all" />
    <link href="vendor/font-awesome-5/css/fontawesome-all.min.css" rel="stylesheet" media="all" />
    <link href="vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all" />

    <!-- Bootstrap CSS-->
    <link href="vendor/bootstrap-4.1/bootstrap.min.css" rel="stylesheet" media="all" />

    <!-- Vendor CSS-->
    <link href="vendor/animsition/animsition.min.css" rel="stylesheet" media="all" />
    <link href="vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet" media="all" />
    <link href="vendor/wow/animate.css" rel="stylesheet" media="all" />
    <link href="vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" media="all" />
    <link href="vendor/slick/slick.css" rel="stylesheet" media="all" />
    <link href="vendor/select2/select2.min.css" rel="stylesheet" media="all" />
    <link href="vendor/perfect-scrollbar/perfect-scrollbar.css" rel="stylesheet" media="all" />

    <!-- Main CSS-->
    <link href="css/theme.css" rel="stylesheet" media="all" />

    <!-- Jquery JS-->
    <script src="vendor/jquery-3.2.1.min.js"></script>
     <%-- Highchart plugin--%>
        <%-- <script src="js/highcharts.js"></script>
<script src="js/highcharts-more.js"></script>
<script src="js/exporting.js"></script>--%>

  

</head>
<body class="animsition">
       <div id="container">
    <div id="people"></div>
   </div>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <div class="page-wrapper">
        <!-- HEADER MOBILE-->
        <header class="header-mobile d-block d-lg-none">
            <div class="header-mobile__bar">
                <div class="container-fluid">
                    <div class="header-mobile-inner">
                        <a class="logo" href="index.html">
                            <img src="images/icon/logo5.png" alt="CoolAdmin" />
                        </a>
                        <button class="hamburger hamburger--slider" type="button">
                            <span class="hamburger-box">
                                <span class="hamburger-inner"></span>
                            </span>
                        </button>
                    </div>
                </div>
            </div>
            <nav class="navbar-mobile">
                <div class="container-fluid" id="divMobiSidmenu" runat="server">
                    
                </div>
            </nav>
        </header>
        <!-- END HEADER MOBILE-->

        <!-- MENU SIDEBAR-->
        <aside class="menu-sidebar d-none d-lg-block">
            <div class="logo">
                <a href="#">
                    <img src="images/icon/logo5.png" alt="Cool Admin" />
                </a>
            </div>
            <div class="menu-sidebar__content js-scrollbar1">
                <nav class="navbar-sidebar" id="divSideMenu" runat="server">
                 
                </nav>
            </div>
        </aside>
        <!-- END MENU SIDEBAR-->

        <!-- PAGE CONTAINER-->
        <div class="page-container">
            <!-- HEADER DESKTOP-->
             <header class="header-desktop" style="height: 50px;">
                <div class="section__content section__content--p30" style="top:30px">
                    <div class="container-fluid">
                        <div class="header-wrap">
                            <%--<form class="form-header" action="" method="POST">
                                <input class="au-input au-input--xl" type="text" name="search" placeholder="Search for datas &amp; reports..." />
                                <button class="au-btn--submit" type="submit" style="height: 43px;">
                                    <i class="zmdi zmdi-search"></i>
                                </button>
                            </form>--%>
                            <div class="header-button" style="margin-top: 1px;" >
                                <div class="noti-wrap" >
                                   <%-- <div class="noti__item js-item-menu">
                                        <i class="zmdi zmdi-comment-more"></i>
                                        <span class="quantity">1</span>
                                        <div class="mess-dropdown js-dropdown">
                                            <div class="mess__title">
                                                <p>You have 2 news message</p>
                                            </div>
                                            <div class="mess__item">
                                                <div class="image img-cir img-40">
                                                    <img src="images/icon/avatar-06.jpg" alt="Michelle Moreno" />
                                                </div>
                                                <div class="content">
                                                    <h6>Michelle Moreno</h6>
                                                    <p>Have sent a photo</p>
                                                    <span class="time">3 min ago</span>
                                                </div>
                                            </div>
                                            <div class="mess__item">
                                                <div class="image img-cir img-40">
                                                    <img src="images/icon/avatar-04.jpg" alt="Diane Myers" />
                                                </div>
                                                <div class="content">
                                                    <h6>Diane Myers</h6>
                                                    <p>You are now connected on message</p>
                                                    <span class="time">Yesterday</span>
                                                </div>
                                            </div>
                                            <div class="mess__footer">
                                                <a href="#">View all messages</a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="noti__item js-item-menu">
                                        <i class="zmdi zmdi-email"></i>
                                        <span class="quantity">1</span>
                                        <div class="email-dropdown js-dropdown">
                                            <div class="email__title">
                                                <p>You have 3 New Emails</p>
                                            </div>
                                            <div class="email__item">
                                                <div class="image img-cir img-40">
                                                    <img src="images/icon/avatar-06.jpg" alt="Cynthia Harvey" />
                                                </div>
                                                <div class="content">
                                                    <p>Meeting about new dashboard...</p>
                                                    <span>Cynthia Harvey, 3 min ago</span>
                                                </div>
                                            </div>
                                            <div class="email__item">
                                                <div class="image img-cir img-40">
                                                    <img src="images/icon/avatar-05.jpg" alt="Cynthia Harvey" />
                                                </div>
                                                <div class="content">
                                                    <p>Meeting about new dashboard...</p>
                                                    <span>Cynthia Harvey, Yesterday</span>
                                                </div>
                                            </div>
                                            <div class="email__item">
                                                <div class="image img-cir img-40">
                                                    <img src="images/icon/avatar-04.jpg" alt="Cynthia Harvey" />
                                                </div>
                                                <div class="content">
                                                    <p>Meeting about new dashboard...</p>
                                                    <span>Cynthia Harvey, April 12,,2018</span>
                                                </div>
                                            </div>
                                            <div class="email__footer">
                                                <a href="#">See all emails</a>
                                            </div>
                                        </div>
                                    </div>--%>
                                    <div class="noti__item js-item-menu" id="divNotification" runat="server">
                                       
                                        </div>
                                    </div>
                                </div>
                                <div class="account-wrap" id="divLogin" runat="server">
                                 
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </header>
            <!-- HEADER DESKTOP-->

            <!-- MAIN CONTENT-->
            <div class="main-content">
        <div class="section__content section__content--p30">
          <div class="container-fluid">
            <div class="row">
              <div class="col-md-12">


                <div class="card"  >
                  <div class="card-header">
                    <strong class="card-title">My Profile</strong>
                  </div>

                  <div class="card-body" >
                  
               
                    <div class="vue-misc" id="divLogout" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-auto">
                          <h3 class="mb-3"> </h3>
                          <div class="jumbotron">
                           <div class="col-lg-12">
                            Logout Successfull
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                     <div class="vue-misc" id="divProfile" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-auto">
                          <h3 class="mb-3"> Update </h3> 
                              <div class="form-group">
                             <asp:DropDownList ID="ddlProfile" runat="server" AutoPostBack="true" Visible="false"></asp:DropDownList>
                              <br /> <div id="divPic" runat="server" style="height:100px;width:100px;" /> <asp:FileUpload ID="FileUpload1" runat="server"  />
<asp:Button ID="btnUpload" Text="Change Picture" runat="server" OnClick="UploadFile" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
<hr />
                          &nbsp;&nbsp;    <asp:TextBox ID="txtName" runat="server" class="au-input au-input--full" placeholder="Name" Width="190"></asp:TextBox> <br /><br /> &nbsp;&nbsp; 
                               <asp:TextBox ID="txtDesig" runat="server" class="au-input au-input--full" placeholder="Designation" Width="190"></asp:TextBox> <br /><br /> &nbsp;&nbsp; 
                               <asp:TextBox ID="txtCell" runat="server" class="au-input au-input--full" MaxLength="11" TextMode="Number"  placeholder="11 digit Phone Number" Width="190"></asp:TextBox><br /> <br /> &nbsp;&nbsp; 
                                   <asp:TextBox ID="txtCell2" runat="server" class="au-input au-input--full" MaxLength="13"  Width="250" placeholder="Alternate Phone Number with code"></asp:TextBox><br /> <br /> &nbsp;&nbsp; 
                                   <asp:TextBox ID="txtWhatsapp" runat="server" class="au-input au-input--full" MaxLength="13"   Width="250" placeholder="whatsapp number with code"></asp:TextBox><br /> <br /> &nbsp;&nbsp; 
                               <asp:TextBox ID="txtemail" runat="server" class="au-input au-input--full" placeholder="Email" Width="230"></asp:TextBox><br /> <br /> &nbsp;&nbsp; 
                              <asp:TextBox ID="txtRax" runat="server" class="au-input au-input--full" MaxLength="7" TextMode="Number"  placeholder="Rax Number" Width="100"></asp:TextBox> <br /><br /> &nbsp;&nbsp; 
                                     <asp:TextBox ID="txtDept" runat="server" class="au-input au-input--full" placeholder="Department" Width="290"></asp:TextBox><br /> <br /> &nbsp;&nbsp; 
                                   <asp:DropDownList ID="ddlBlood" runat="server">
                                        <asp:ListItem Value="NA">Select Blood Group</asp:ListItem>
                                      <asp:ListItem>A+</asp:ListItem>
                                       <asp:ListItem>A-</asp:ListItem>
                                       <asp:ListItem>B+</asp:ListItem>
                                       <asp:ListItem>B-</asp:ListItem>
                                       <asp:ListItem>O+</asp:ListItem>
                                       <asp:ListItem>O-</asp:ListItem>
                                       <asp:ListItem>AB+</asp:ListItem>
                                       <asp:ListItem>AB-</asp:ListItem>
                                  </asp:DropDownList>
                             <asp:RadioButtonList ID="rblType" runat="server" AutoPostBack="false" RepeatDirection="Horizontal"  RepeatColumns="2">
                                  <asp:ListItem   Value="SO">Site Office</asp:ListItem>                  
                                <asp:ListItem Value="HO">Head Office</asp:ListItem>
                                       </asp:RadioButtonList>
                          Parent Org: <asp:RadioButtonList ID="rblOrg" runat="server" AutoPostBack="false" RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem   Value="BIFPCL">BIFPCL</asp:ListItem>                  
                                <asp:ListItem Value="NTPC">NTPC</asp:ListItem>
                              <asp:ListItem Value="BPDB">BPDB</asp:ListItem>
                                       </asp:RadioButtonList>
                           Birth Date      <asp:TextBox style="border-width:2px; border-color:black;" class="au-input au-input--full" ID="txtBirthDate" runat="server" Text="" CssClass="txt100" />
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtBirthDate" Format="dd.MM.yyyy">
                                    </asp:CalendarExtender> <br />
                                    <asp:TextBox ID="txtBIO" Enabled="false" runat="server" class="au-input au-input--full" MaxLength="5" TextMode="Number"  placeholder="bio id" Width="190"></asp:TextBox><br /> &nbsp;&nbsp; 
   <asp:TextBox ID="txtEid" Enabled="false" runat="server" class="au-input au-input--full" MaxLength="8"   placeholder="emp id" Width="290"></asp:TextBox><br /> <br /> &nbsp;&nbsp; 
                                  <asp:RadioButtonList ID="rblDel" Enabled="false" runat="server" AutoPostBack="false" RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem   Value="0">On roll</asp:ListItem>                  
                                <asp:ListItem Value="1">Separated</asp:ListItem>
                                       </asp:RadioButtonList> <br />
                             <asp:Button ID="btnSubmit"  runat="server" Text="Update" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  /> 
                            <br /> <br />
                                  </div>
                             <asp:Label ID="lblID" runat="server" Text=""></asp:Label> 
                   
                        </div>
                      </div>
                    </div>
                      
                   <div id="divMsg" runat="server" />
                  </div>
                </div>


              </div>
            </div>
          </div>
        </div>

      </div>
            <!-- END MAIN CONTENT-->
            <!-- END PAGE CONTAINER-->
        </div>

    </div>
    </form>

    
    
    <!-- Bootstrap JS-->
    <script src="vendor/bootstrap-4.1/popper.min.js"></script>
    <script src="vendor/bootstrap-4.1/bootstrap.min.js"></script>
    <!-- Vendor JS       -->
    <script src="vendor/slick/slick.min.js">
    </script>
    <script src="vendor/wow/wow.min.js"></script>
    <script src="vendor/animsition/animsition.min.js"></script>
    <script src="vendor/bootstrap-progressbar/bootstrap-progressbar.min.js">
    </script>
    <script src="vendor/counter-up/jquery.waypoints.min.js"></script>
    <script src="vendor/counter-up/jquery.counterup.min.js">
    </script>
    <script src="vendor/circle-progress/circle-progress.min.js"></script>
    <script src="vendor/perfect-scrollbar/perfect-scrollbar.js"></script>
    <script src="vendor/chartjs/Chart.bundle.min.js"></script>
    <script src="vendor/select2/select2.min.js">
    </script>
 
    <!-- Main JS-->
    <script src="js/main.js"></script>
   

    
    
</body>
</html>
