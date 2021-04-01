<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dashboardTS.aspx.vb" Inherits="dashboardTS" %>
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
    <title>BIFPCL Dashboard TS</title>

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
        <header class="header-mobile header-mobile-2 d-block d-lg-none"  style="background:#5d57ea">
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
                                            <option value=""><a style="display:block" href="dpr.aspx">DPR Entry</a></option>
                                            <option value=""><a style="display:block" href="dprIssues.aspx">Manage Inputs</a></option>
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
                            <h1 class="title-4">Dashboard
                                <span>TS</span>
                            </h1>
                            <hr class="line-seprate">
                        </div>
                    </div>
                </div>
            </section>
            <!-- END WELCOME-->

            <!-- STATISTIC-->
            <section class="statistic statistic2">
                <div class="container">
                    <div class="row"  id="divHome" runat="server">
                     
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="dprm.aspx">
                            <div class="statistic__item statistic__item--green">
                                <h2 class="number">Mobile DPR</h2>
                                <span class="desc">Get the daily progress report on mobile.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-smartphone"  style="opacity:.4"></i>
                                </div>
                            </div>
                            </a>
                        </div>
                            
                      
                        <div class="col-md-6 col-lg-3">
                               <a style="display:block" href="dprUpdate.aspx?mode=report">
                            <div class="statistic__item statistic__item--orange">
                                <h2 class="number">DPR Reports</h2>
                                <span class="desc">Get the detailed daily progress report.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-view-column" style="opacity:.4"></i>
                                </div>
                            </div>
                                    </a>
                        </div>
                            
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="dpr.aspx">
                            <div class="statistic__item statistic__item--blue">
                                <h2 class="number">DPR Entry</h2>
                                <span class="desc">Feed the daily progress into the system.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-calendar-note"  style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                           <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="dashboardTS.aspx?mode=cricview">
                            <div class="statistic__item statistic__item--red" style="background:#20c997">
                                <h2 class="number">Critical Foundation</h2>
                                <span class="desc">Daily Progress</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-view-headline" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="dprmiles.aspx">
                            <div class="statistic__item statistic__item--red">
                                <h2 class="number">Milestone</h2>
                                <span class="desc">See the project milestone</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-trending-up" style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="dprIssues.aspx?mode=input_update">
                            <div class="statistic__item statistic__item--red" style="background:#6f42c1">
                                <h2 class="number">Major Inputs</h2>
                                <span class="desc">Manage the Inputs for Milestones</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-calendar" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="#">
                            <div class="statistic__item statistic__item--red" style="background:#20c997">
                                <h2 class="number">Critical Issue</h2>
                                <span class="desc">Manage the Issues for Inputs</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-view-headline" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="dprIssues.aspx?mode=report">
                            <div class="statistic__item statistic__item--red" style="background:#ffc107">
                                <h2 class="number">Milestone Reports</h2>
                                <span class="desc">Get Milestone, Inputs, Critical Issues report</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-view-web" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="#">
                            <div class="statistic__item statistic__item--red" style="background:#6c757d">
                                <h2 class="number">Supply Status</h2>
                                <span class="desc">Get detailed report for supply</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-widgets" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="mgmt.aspx">
                            <div class="statistic__item statistic__item--orange" >
                                <h2 class="number">Board Members' Dashboard</h2>
                                <span class="desc">Only for board member's</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-eye" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="mgmt.aspx?mode=edit">
                            <div class="statistic__item statistic__item--blue" >
                                <h2 class="number">Edit Dashboard</h2>
                                <span class="desc">Only for BIFPCL TS</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-lock" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                    </div>
                    <div id="divMsg" runat="server" />
                </div>
            </section>
            <!-- END STATISTIC-->
            <section class="statistic statistic2">
                <div class="container">
                    <div class="row">
               <div class="vue-misc"  id="divOBS" visible="false"  runat="server">
                     <div class="card" >
                  <div class="card-header">
                    <strong class="card-title">Critical Foundation Daily Monitoring</strong>
                         <a href="dashboardTS.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>  Back</button></a> <br />
                        <a href="dashboardTS.aspx?mode=cricentry" >Enter Progress </a> |   <a href="dashboardTS.aspx?mode=cricview" >View Progress </a>  | <a href="dashboardTS.aspx?mode=cricadd" >Add Agency </a>
                  </div>

                  <div class="card-body" >
                     <div class="vue-misc" >
                    
                      <div class="row">
                         <div class="col-md-12">
                             <div class="form-group" id="divOBSEntry" runat="server" visible="false">
                                   <div class="card-header">   Note: Attach pictures with progress/manpower count. </div>
                             <%--  <asp:RadioButtonList ID="rblOBS" runat="server" Enabled="false"  RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem  Value="obs" Selected="true" >Observation</asp:ListItem>                  
                                <asp:ListItem Value="com">Compliance</asp:ListItem>
                              </asp:RadioButtonList>--%><asp:Label ID="lbObsID" runat="server" Text=""></asp:Label>
                                         <asp:DropDownList ID="ddlNewAgency"  AutoPostBack="true"   DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>
                                       <br />  &nbsp;   <asp:DropDownList ID="ddlNewWorkArea" DataTextField="area" DataValueField="area"  runat="server" ></asp:DropDownList>
                                   &nbsp; &nbsp; &nbsp; &nbsp;     <asp:TextBox ID="txtProgDate" runat="server" placeholder="dd.mm.yyyy" class="au-input au-input--full" Width="150px" ></asp:TextBox> 
                                      <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd.MM.yyyy" TargetControlID="txtProgDate"  /> 
                               
                                <br />  <label><b>Day Progress</b></label><br />
                                     <asp:TextBox ID="txtCricProg" runat="server" class="au-input au-input--full"   ></asp:TextBox> <br />
                                   <br />  <label><b>Manpower Count</b></label><br />
                                     <asp:TextBox ID="txtCricManpower" runat="server" class="au-input au-input--full"  ></asp:TextBox> <br />
                               <br />  <%--<label><b>Weekly Progress</b></label><br />
                                     <asp:TextBox ID="txtCricWrm" runat="server" class="au-input au-input--full"   ></asp:TextBox> <br />
                             --%>
                              <label><b>Remarks</b></label><br />   <asp:TextBox ID="txtCricRemark" runat="server" class="au-input au-input--full"  Height="60px" TextMode="MultiLine" ></asp:TextBox> <br /><br /> 
                           
                                  <%--  <br /> <div id="divPic" runat="server" style="height:100px;width:100px;" /> --%>
                          <div class="col-md-3" style="display:flex"> <asp:FileUpload ID="FileUpload1" runat="server"  />
</div> <div class="col-md-6"  style="display:flex"> <asp:Button ID="btnUpload" Enabled="True" Text="Submit and Upload Picture" Width="290px" runat="server" OnClick="UploadFile"  class="au-btn au-btn--block au-btn--green m-b-20" />
<asp:Label ID="lbPicStatus" runat="server" Text="" ForeColor="Blue"></asp:Label>
</div> <hr />
                        <button type='button' class='btn btn-danger m-l-10 m-b-10' style='  text-transform: capitalize;'>
                                                     <asp:Label ID="lbBookMessageTop" runat="server" Text="" ForeColor="white"></asp:Label>
                            </button>
                    </div>
                             <div  id="divOBSView" runat="server" visible="false" >
                         &nbsp; &nbsp; &nbsp; &nbsp;       <asp:DropDownList ID="ddlCricAgency" AutoPostBack="true"    DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>
                                &nbsp; &nbsp; &nbsp; &nbsp;     <asp:TextBox ID="txtCricDate" runat="server" placeholder="dd.mm.yyyy" class="au-input au-input--full" Width="150px" ></asp:TextBox> 
                                      <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd.MM.yyyy" TargetControlID="txtCricDate"  /> 
                                  &nbsp; &nbsp; &nbsp; &nbsp;         
                                  <asp:Button ID="btnGo" runat="server" Text="Go" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />  
         <br /> <asp:Label ID="lbCricMsg" runat="server" Text="" ForeColor="red"></asp:Label>
                                 <asp:LinkButton ID="lbDownloadSummary"  Visible="false"  runat="server">Download</asp:LinkButton> 
              <asp:GridView ID="gvReportPic"  runat="server" HeaderStyle-CssClass="gvHeader"   Caption="Edit to change" CaptionAlign="Left"
  CssClass="table-responsive table table-borderless table-striped  table--no-card m-b-30"   AlternatingRowStyle-CssClass="gvAltRow"  AutoGenerateColumns="false">
  <Columns>    <asp:TemplateField>      <HeaderTemplate>      <%--  <th colspan="6">Category</th>--%>
         <tr class="gvHeader">
          <th></th>
                 <%--     <th> SN</th>--%>
           
             <th>Agency</th>
             <th>Area</th>
             <th>Day Progress</th>
             <th>Manpower</th>
             <%--<th>WRM Weekly Progress</th>--%>
            <th>Picture</th>
               <th>Remark</th>
             <th>Time Stamp</th>
                 <th> Edit</th>
           </tr>
      </HeaderTemplate> 
      <ItemTemplate>
        <%--   <td><%# Eval("uid")%></td>--%>
          <td><%# Eval("agency")%></td>
            <td><%# Eval("area")%></td>
            <td><%# Eval("prog")%></td>
           <td><%# Eval("manpower")%></td>
<%--          <td><%# Eval("wrm") & "<br/>" & "<br/>" & "<br/>" & "<br/>" %></td>--%>
            <td><a href='upload/TS/Report/<%#  Eval("pic") %>' target='_blank'><img src='upload/SAFETY/Report/<%#  Eval("pic") %>' alt='<%# Eval("pic")%>' width="50" height="75" /></a></td>
             <td><%# Eval("remark")%></td>
           <td><%# Eval("last_updated")%></td>
             <td><%#"<a href='dashboardTS.aspx?mode=cricentry&id=" & Eval("uid") & "' target='_blank'>Edit</a>" %></td>
        
      </ItemTemplate>    </asp:TemplateField>  </Columns>
       <EmptyDataTemplate><div>No Data Available</div></EmptyDataTemplate>    </asp:GridView> 
                                 </div>
                     <div id="divOBSAgency" runat="server" visible="false" >
                         * Enter correct spelling of Agency : Modification not possible <br />
                          <asp:TextBox ID="txtAgency" runat="server" placeholder="Sub Agency Name" class="au-input au-input--full" Width="200px" ></asp:TextBox> 
                    &nbsp; &nbsp; &nbsp; &nbsp;         <asp:TextBox ID="txtArea" runat="server" placeholder="Work Area" class="au-input au-input--full" Width="150px" ></asp:TextBox> 
                                  &nbsp; &nbsp; &nbsp; &nbsp;         
                                  <asp:Button ID="btnAddAgency" runat="server" Text="Submit" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />  
       
                         </div>
                        </div>
                      </div>
                    </div>
                       </div> </div>
                </div>
          
                        </div>
                    </div>
                </section>
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
