<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ocms.aspx.vb" Inherits="ocms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <!-- Required meta tags-->
    <meta charset="UTF-8" />
     <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="BIFPCL Official Website" />
    <meta name="author" content="Vinod Kotiya" />
    <meta name="keywords" content="NTPC, BIFPCL, Maitree Thermal Power Project, Khulna, Bangladesh India Friendship Power Corporation Limited" />
    <link href='favicon.ico' rel='icon' type='image/x-icon'/>

    <!-- Title Page-->
    <title>BIFPCL OCMS</title>

    <!-- Fontfaces CSS-->
    <link href="css/font-face.css" rel="stylesheet" media="all"/>
    <link href="vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all"/>
    <link href="vendor/font-awesome-5/css/fontawesome-all.min.css" rel="stylesheet" media="all"/>
    <link href="vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all"/>

    <!-- Bootstrap CSS-->
    <link href="vendor/bootstrap-4.1/bootstrap.min.css" rel="stylesheet" media="all"/>

    <!-- Vendor CSS-->
    <link href="vendor/animsition/animsition.min.css" rel="stylesheet" media="all"/>
    <link href="vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet" media="all"/>
    <link href="vendor/wow/animate.css" rel="stylesheet" media="all"/>
    <link href="vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" media="all"/>
    <link href="vendor/slick/slick.css" rel="stylesheet" media="all"/>
    <link href="vendor/select2/select2.min.css" rel="stylesheet" media="all"/>
    <link href="vendor/perfect-scrollbar/perfect-scrollbar.css" rel="stylesheet" media="all"/>

    <!-- Main CSS-->
    <link href="css/theme.css" rel="stylesheet" media="all"/>
     <link href='favicon.ico' rel='icon' type='image/x-icon'/>
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
       <div class="page-wrapper">
        <!-- HEADER DESKTOP-->
        <header class="header-desktop3 d-none d-lg-block" style="background:#5d57ea">
            <div class="section__content section__content--p35">
                <div class="header3-wrap">
                    <div class="header__logo">
                        <a class="logo" href="Default.aspx">
                            <img src="images/icon/logo6.png" alt="CoolAdmin" />
                        </a>
                    </div>
                    <div class="header__navbar" id="divSideMenu" runat="server">
                   </div>
                    <div class="header__tool">
                        <div class="header-button-item has-noti js-item-menu">
                             <div class="noti__item js-item-menu" id="divNotification" runat="server" />
                        </div>
            
  <div class="account-wrap" id="divLogin" runat="server">
                
                        </div>
                    </div>
                </div>
            </div>
        </header>
        <!-- END HEADER DESKTOP-->

        <!-- HEADER MOBILE-->
        <header class="header-mobile header-mobile-2 d-block d-lg-none">
            <div class="header-mobile__bar">
                <div class="container-fluid">
                    <div class="header-mobile-inner">
                       <a class="logo" href="Default.aspx">
                            <img src="images/icon/logo6.png" alt="BIFPCL" />
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
                  <div class="container-fluid" id="divMobiSidmenu" runat="server" />
          
            </nav>
        </header>
        <div class="sub-header-mobile-2 d-block d-lg-none">
            <div class="header__tool">
                <div class="header-button-item has-noti js-item-menu">
                    <div class="noti__item js-item-menu" style="margin-left:-100px;" id="divNotificationMobile" runat="server" />
                </div>
             
                <div class="account-wrap" id="divLoginMobile" runat="server">
                 
                </div>
            </div>
        </div>
        <!-- END HEADER MOBILE -->

        <!-- PAGE CONTENT-->
        <div class="page-content--bgf7">
            <!-- BREADCRUMB-->
            <section class="au-breadcrumb2"style="padding-top:3px;padding-bottom:0px;">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="au-breadcrumb-content">
                                <div class="au-breadcrumb-left">
                                    <span class="au-breadcrumb-span">You are here:</span>
                                    <ul class="list-unstyled list-inline au-breadcrumb__list">
                                        <li class="list-inline-item active">
                                            <a href="Default.aspx">Home</a>
                                        </li>
                                        <li class="list-inline-item seprate">
                                            <span>/</span>
                                        </li>
                                        <li class="list-inline-item">Dashboard</li>
                                    </ul>
                                </div>
                               <div class="rs-select2--dark rs-select2--sm rs-select2--dark2" style="width:300px;">
                                        <select class="js-select2" name="type">
                                            <option selected="selected">Quick Links</option>
                                            <option value="">Option 1</option>
                                            <option value="">Option 2</option>
                                        </select>
                                        <div class="dropDownSelect2"></div>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- END BREADCRUMB-->

            <!-- WELCOME-->
            <section class="welcome p-t-10">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <h1 class="title-4">OCMS
                                <span>Online Complaint Management System</span>
                            </h1>
                             <a href="ocms.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>&nbsp; Back</button></a>
                            <hr class="line-seprate">
                        </div>
                    </div>
                </div>
            </section>
            <!-- END WELCOME-->

            <!-- STATISTIC-->
            <section class="statistic statistic2" id="divHome" runat="server">
                <div class="container">
                    <div class="row">
                       
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="ocms.aspx?ctype=1">
                            <div class="statistic__item statistic__item--green">
                                <h2 class="number">PC-Laptop</h2>
                                <span class="desc">Troubleshoot.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-desktop-mac"  style="opacity:.4"></i>
                                </div>
                            </div>
                            </a>
                        </div>
                            
                      
                        <div class="col-md-6 col-lg-3">
                               <a style="display:block" href="ocms.aspx?ctype=2">
                            <div class="statistic__item statistic__item--orange">
                                <h2 class="number">Printers - Toners</h2>
                                <span class="desc">Troubleshoot, Refill.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-print" style="opacity:.4"></i>
                                </div>
                            </div>
                                    </a>
                        </div>
                            
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="ocms.aspx?ctype=4">
                            <div class="statistic__item statistic__item--blue">
                                <h2 class="number">Internet - WiFi</h2>
                                <span class="desc">Not working, slow</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-wifi-alt"  style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="ocms.aspx?ctype=3">
                            <div class="statistic__item statistic__item--red">
                                <h2 class="number">Telephone Line</h2>
                                <span class="desc">Troubleshoot</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-phone" style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                           <div class="col-md-6 col-lg-3">
                               <a style="display:block" href="ocms.aspx?ctype=6">
                            <div class="statistic__item statistic__item--orange">
                                <h2 class="number">Email - Softwares</h2>
                                <span class="desc">Troubleshoot, Backup.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-email" style="opacity:.4"></i>
                                </div>
                            </div>
                                    </a>
                        </div>
                            
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="ocms.aspx?ctype=5">
                            <div class="statistic__item statistic__item--blue">
                                <h2 class="number">ERP</h2>
                                <span class="desc">Yet to come</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-rss"  style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="ocms.aspx?ctype=status">
                            <div class="statistic__item statistic__item--blue">
                                <h2 class="number">Status</h2>
                                <span class="desc">Get Status of Complaint</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-info-outline"  style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="ocms.aspx?ctype=admin">
                            <div class="statistic__item statistic__item--green">
                                <h2 class="number">IT Admin</h2>
                                <span class="desc">Attend Issues.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-account"  style="opacity:.4"></i>
                                </div>
                            </div>
                            </a>
                        </div>
                    </div>
                </div>
            </section>
            <!-- END STATISTIC-->

            <!-- STATISTIC CHART-->
            <section class="statistic-chart">
                <div class="container">
                   <%-- <div class="row">
                        <div class="col-md-12">
                            <h3 class="title-5 m-b-35">statistics</h3>
                        </div>
                    </div>--%>
                    <div class="row">
                      <asp:Panel ID="pnlComplaintBooking" runat="server" Visible="false"> 
            <div id="main1">
                <div class="bottom_to_top"><a href="ocms.aspx?ctype=status"> <<-Click Here to Check Status of Prev Complaints.</a></div>
<div id="first1">


<label class="myformlabel">Name :</label>   <asp:Label ID="lblName" runat="server"  CssClass="myformlabel" /> 
       <label class="myformlabel"> , Mobile :</label>   <asp:Label ID="lblMobile" runat="server"  CssClass="myformlabel" /><br /><br />
     <label class="myformlabel">Dept :</label>   <asp:TextBox ID="txtDept" runat="server"  class="wrapper-dropdown-5"  /><br /><br />
   <label class="myformlabel">Complaint Type :</label>  <asp:DropDownList ID="ddlCtype" runat="server" AutoPostBack="true"  DataValueField="id" DataTextField="type"  class="wrapper-dropdown-5"   EnableViewState="true">
      </asp:DropDownList><br /><br />
    <label class="myformlabel">Location :</label>
    <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="true"  DataValueField="lid" DataTextField="loc"  class="wrapper-dropdown-5"   EnableViewState="true">
      </asp:DropDownList><br /><br />
    <label class="myformlabel">Priority(System Generated) :</label>  <asp:DropDownList ID="ddlPriority" runat="server" AutoPostBack="true" class="wrapper-dropdown-5"    EnableViewState="true" Enabled="False">
          <asp:ListItem Value="1">Normal</asp:ListItem>
          <asp:ListItem Value="2">Medium</asp:ListItem>
                   <asp:ListItem Value="3">High</asp:ListItem>
      </asp:DropDownList><br /><br />
    <label class="myformlabel">Complaint Description :</label>
    <asp:TextBox ID="txtDescr" runat="server"  class="au-input au-input--full" TextMode="MultiLine" placeholder="write down the issue here..." />
<br /><label>Rax:</label>
 <asp:TextBox ID="txtRax" runat="server"    placeholder="Rax" TextMode="SingleLine" />
     <asp:Label ID="lblEmail" runat="server"  CssClass="myformlabel" />

    <asp:Button ID="btnSubmit"  runat="server"  class="au-btn au-btn--block au-btn--green m-b-20" Text="Submit"  />
    <p>After submit wait 30sec for Mail and SMS. Don't click submit again.</p>
    <br />
       <div  id="divMsgComplaint" runat="server"  style="font-family: Arial, Helvetica, sans-serif; font-size: small; font-style: normal; color: #ff0000; word-spacing: normal; text-indent: inherit; text-align: justify;"  />


</div>
</div>
            </asp:Panel>
          <asp:Panel ID="pnlStatus" runat="server" Visible="false"> <br />
              <label>Complaint Status:</label>
                <asp:GridView ID="gvStatus" runat="server"  CssClass="table-responsive table table-borderless table-striped  table--no-card m-b-30" >
                    <EmptyDataTemplate><div>No Data Available</div></EmptyDataTemplate></asp:GridView>
              </asp:Panel>
        <asp:Panel ID="pnlLogin" runat="server" Visible="false" BorderColor="#3333CC" BorderStyle="Groove" BorderWidth="2px"> 
             <div id="main" style="height:160px;" >
                 <div id="first" style="height:160px;"><br />
            <label>Note: Your IP Address and Location are being recorded.</label><br />
           <b> <label>Please Enter Email ID to procede:</label></b>
                    <asp:TextBox ID="txtEid" runat="server" placeholder="          @bifpcl.com"></asp:TextBox> <br /><br />
                
            <asp:Button ID="btnLogin"  class="au-btn au-btn--block au-btn--green m-b-20" runat="server" Text="Sign In" />
                     </div></div>
            </asp:Panel>
         <asp:Panel ID="pnlAdminLogin" runat="server" Visible="false" BorderColor="#3333CC" BorderStyle="Groove" BorderWidth="2px"> <br />
            <label>Note: Your IP Address and Location are being recorded.</label><br /><br />
            <label>AdminID:</label>
                    <asp:TextBox ID="txtAdminID" runat="server"></asp:TextBox> <br /><br />
             <label>Password:</label>
                    <asp:TextBox ID="txtAdminPwd" runat="server" TextMode="Password"></asp:TextBox> <br /><br />
                
            <asp:Button ID="btnAdminLogin" class="au-btn au-btn--block au-btn--green m-b-20"  runat="server" Text="Sign In" />
            </asp:Panel>
         <asp:Panel ID="pnlNewUser" runat="server" Visible="false" BorderColor="#3333CC" BorderStyle="Groove" BorderWidth="2px"> <br />
            <label>Note: You have to be registered as SCOPE User. Fill in the details..</label><br />
            <label>Employee ID:</label>
                    <asp:TextBox ID="txtNewEid" runat="server"></asp:TextBox> <br /><br />
             <label>Name:</label>
                    <asp:TextBox ID="txtNewName" runat="server"></asp:TextBox> <br /><br />
             <label>Mobile:</label>
                    <asp:TextBox ID="txtNewMobile" runat="server"></asp:TextBox> <br /><br />
             <label>Email:</label>
                    <asp:TextBox ID="txtNewEmail" runat="server"></asp:TextBox> <br /><br />
             <label>Department:</label>
                    <asp:TextBox ID="txtNewDept" runat="server"></asp:TextBox> <br /><br />
                
            <asp:Button ID="btnNewUser" runat="server" Text="Create New User" />
            </asp:Panel>
          <asp:Panel ID="pnlAdminEdit" runat="server" Visible="false" BorderColor="#3333CC" BorderStyle="Groove" BorderWidth="2px"> <br />
              <label>Change Complaint Status:</label> 
            <asp:Label runat="server" id="lblCompID"></asp:Label><br />
            <asp:Label runat="server" id="lblCompDetail"></asp:Label>
              <asp:Label runat="server" id="lblEmailChange"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label runat="server" id="lblMobileChange"></asp:Label><br />
              <label class="myformlabel">Change Complaint Type(Optional):</label>   <asp:DropDownList ID="ddlEdittype" runat="server" AutoPostBack="true"  DataValueField="id" DataTextField="type"  class="wrapper-dropdown-5"   EnableViewState="true">
      </asp:DropDownList>
    <label class="myformlabel">Change Location(Optional):</label>
    <asp:DropDownList ID="ddlEditLocation" runat="server" AutoPostBack="true"  DataValueField="lid" DataTextField="loc"  class="wrapper-dropdown-5"   EnableViewState="true">
      </asp:DropDownList><br /><br />
                <label class="myformlabel">Status: (Use Forward for external AMC/Lexmark/HP etc)</label>  <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" class="wrapper-dropdown-5"    EnableViewState="true">
          <asp:ListItem Value="1">Pending</asp:ListItem>
          <asp:ListItem Value="2">Forward</asp:ListItem>
                   <asp:ListItem Value="3">Closed</asp:ListItem>
      </asp:DropDownList><br /><br />
            <label>Closing Remarks:</label>
            <asp:TextBox ID="txtClosingRemark" runat="server"  class="au-input au-input--full"   placeholder="Please ensure and confirm from user that complaint has been resolved before closing." TextMode="MultiLine" ></asp:TextBox> <br /><br />
                <br />
            <label>Closed By:</label> <asp:DropDownList ID="ddlEditBy" runat="server" AutoPostBack="true"  DataValueField="tech" DataTextField="tech"  class="wrapper-dropdown-5"   EnableViewState="true" />
    <br />
            <asp:Button ID="btnChange" class="au-btn au-btn--block au-btn--green m-b-20" runat="server" Text="Update" />
              </asp:Panel>
          <asp:Panel ID="pnlAdminStatus" runat="server" Visible="false"> <br />
              <label>Filter:</label>  <asp:DropDownList ID="ddlAdminFilter" runat="server" AutoPostBack="true"  class="wrapper-dropdown-5"  EnableViewState="true" BackColor="White">
         <asp:ListItem Value="1,2,3,4,5,6,7,8,9,10" Selected="True" >Show All</asp:ListItem>
                  <asp:ListItem Value="1" >PC-Laptop</asp:ListItem>
          <asp:ListItem Value="2">Printers - Toners</asp:ListItem>
                   <asp:ListItem Value="3">Telephone Line</asp:ListItem>
            <asp:ListItem Value="4">Internet - WiFi</asp:ListItem>
       <asp:ListItem Value="5">ERP</asp:ListItem>
                  <asp:ListItem Value="6">Email - Softwares</asp:ListItem>
      </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;
              <asp:DropDownList ID="ddlAdminCore" runat="server" AutoPostBack="true"  class="wrapper-dropdown-5"  EnableViewState="true" BackColor="White">
           <asp:ListItem Value="%" Selected="True" >Show All</asp:ListItem>
                  <asp:ListItem Value="PreFab" >PreFab</asp:ListItem>
          <asp:ListItem Value="NewOffice">NewOffice</asp:ListItem>
                   <asp:ListItem Value="Accomodation">Accomodation</asp:ListItem>
            <asp:ListItem Value="HeadOffice">HeadOffice</asp:ListItem>
                   <asp:ListItem Value="Site">Site</asp:ListItem>
                   <asp:ListItem Value="Other">Other</asp:ListItem>
                       </asp:DropDownList>
               &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSearchID" runat="server" Width="170px" placeholder ="Search Emp No, Comp ID"></asp:TextBox>
               &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnRefresh"  runat="server" Text="Refresh" />
               
               <asp:GridView ID="gvAdminStatus" runat="server"  HeaderStyle-CssClass="gvHeader"
  CssClass="gvRow"  
  AlternatingRowStyle-CssClass="gvAltRow"
  AutoGenerateColumns="false" AllowPaging="False" PageSize="11" AllowCustomPaging="False" >
  <Columns>
    <asp:TemplateField>
      <HeaderTemplate>
      <%--  <th colspan="6">Category</th>--%>
       
        <tr class="gvHeader">
          <th></th>
           <th>!</th>
          <th>CNo</th>
             <th>Status</th>
         
             <th>Type</th>
          <th width="32%">Description</th>
            <th>Priority </th>
             <th>Date </th>
            <th>Name </th>
             <th>Contact </th>
          <th>Dept</th>
            <th>Location</th>
            <th>Closing Remark</th>
              <th>By</th>
         
        </tr>
      </HeaderTemplate> 
      <ItemTemplate>
                     <td><asp:Button ID="btnEdit" runat="server" Text="Edit"  CommandArgument='<%# Eval("id")%>' /></td>
         <td><%# Eval("id")%></td>
           <td><%# "<img src=images/" + Eval("status") + ".png width=60px />"%></td>

           <td><%# Eval("type")%></td>
        <td><%# Eval("descr")%></td>
        <td><%#  "<img src=images/" + Eval("priority") + ".png width=60px />" %></td>
          <td><%# Eval("Date")%></td>
          <td><%# Eval("name")%></td>
          <td><%# Eval("contact")%></td>
        <td><%# Eval("dept")%></td>
           <td><%# Eval("location")%></td>
           <td><%# Eval("closingremark")%></td>
           <td><%# Eval("tech")%></td>
       
       
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>

                          </asp:GridView>
              </asp:Panel>
      
        <div  id="divMsg" runat="server"  style="font-family: Arial, Helvetica, sans-serif; font-size: small; font-style: normal; color: #ff0000; word-spacing: normal; text-indent: inherit; text-align: justify;"  />

    </div>
                    </div>
             </section>
            <!-- END STATISTIC CHART-->

         

            <!-- COPYRIGHT-->
            <section class="p-t-60 p-b-20">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="copyright">
                                <p>Copyright © 2018 BIFPCL. All rights reserved. Designed by <a href="https://bifpcl.com">IT BIFPCL</a>.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- END COPYRIGHT-->
        </div>

    </div>

   
    </form>
     <!-- Jquery JS-->
    <script src="vendor/jquery-3.2.1.min.js"></script>
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
