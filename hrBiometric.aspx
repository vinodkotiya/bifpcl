<%@ Page Language="VB" AutoEventWireup="false" CodeFile="hrBiometric.aspx.vb" Inherits="_hrBiometric" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BIFPCL HR Services</title>
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
    <link href="css/theme.css?2" rel="stylesheet" media="all" />

    <!-- Jquery JS-->
    <script src="vendor/jquery-3.2.1.min.js"></script>
  
</head>
<body class="">
       <%--<div id="container">
    <div id="people"></div>
   </div>--%>
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

        <!-- PAGE CONTAINER-->
            <div class="page-content--bgf7">
     <%--<div class="page-container">--%>
           

            <!-- MAIN CONTENT-->
            <div class="main-content" style="padding-top:5px;">

        <div class="section__content section__content--p30">
          <div class="container-fluid">
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
                                        <li class="list-inline-item">HR Dashboard</li>
                                    </ul>
                                </div>
                               <div class="rs-select2--dark rs-select2--sm rs-select2--dark2" style="width:300px;">
                                        <select class="js-select2" name="type">
                                            <option selected="selected">Quick Links</option>
                                            <option value=""><a style="display:block" href="dpr.aspx">Manage Attendance</a></option>
                                            <option value=""><a style="display:block" href="dprIssues.aspx">Leave Reports</a></option>
                                        </select>
                                        <div class="dropDownSelect2"></div>
                                    </div>
                            </div>
                        </div>
                    </div>

            <div class="row">
              <div class="col-md-12">


                <div class="card"  >
                  <div class="card-header">
                    <strong class="card-title">HR Services</strong>
                     <a href="hrBiometric.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>&nbsp; Back</button></a>
                      <a href="upload/HR/notice/BIFPCL300918215828.pdf" target="_blank">  <button type="button" class="btn btn-outline-secondary btn-sm">
                                            <i class="fa fa-lightbulb-o"></i>&nbsp; Help Manual</button> </a>
                  </div>

                  <div class="card-body" >
                   <asp:UpdatePanel ID="upDataEntry" runat="server">
                <Triggers>
                   <%--   <asp:AsyncPostBackTrigger ControlID="txtDate" EventName="txtDate_TextChanged" /> --%>
                      <asp:PostBackTrigger ControlID="btnPreview" />
                     <asp:PostBackTrigger ControlID="btnCancelUpload" />
                     <asp:PostBackTrigger ControlID="btnFinalSubmit" />
                            <%-- <asp:AsyncPostBackTrigger ControlID="ddlResp" EventName="SelectedIndexChanged" />--%>
                      <%-- <asp:AsyncPostBackTrigger ControlID="ddlProject" EventName="SelectedIndexChanged" />--%>
                <%--    <asp:AsyncPostBackTrigger ControlID="ddlUnit" EventName="SelectedIndexChanged" />--%>
                                           </Triggers>
            <ContentTemplate>
                 
                     <div class="vue-misc" id="divUpload" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-auto">
                          <h3 class="mb-3"> Upload Biometric Data </h3>
                             <p>Format: CSV <br />
                                 Order : ID, Name, Date, Check In , Check Out, Absent <br />
                                 If format is wrong data gets corrupt for that duration. You have to again upload it. <br />
                                <b> Attach CSV File and Preview before Final Submit.</b>
                             </p>
                           <%--  <asp:TextBox ID="txtSearch" runat="server" BorderWidth="2px" BorderColor="Black" placeholder="Enter few characters" Width="190"></asp:TextBox> &nbsp;&nbsp; 
                             <asp:Button ID="btnSubmit" runat="server" Text="Go" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  /> 
                            <br /> <br /><asp:RadioButtonList ID="rblType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="2">
                                  <asp:ListItem  Selected="True">Site Office</asp:ListItem>                  
                                <asp:ListItem>Head Office</asp:ListItem>
                                                   <asp:ListItem>Support Staff</asp:ListItem>
                                 <asp:ListItem>Vendors</asp:ListItem>
                                               </asp:RadioButtonList>--%>

                         <asp:Panel ID="pnlEdit" runat="server" Visible="True" class="vinGredientLightblue"> 
                            <br /> <br /> 
                               <asp:FileUpload ID="FileUpload1" runat="server" />
                          
                                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnPreview" runat="server" Text="Upload & Preview" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                 <asp:Button ID="btnFinalSubmit" runat="server"  Text="Final Submit" visible ="False" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />   &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <asp:Button ID="btnCancelUpload" runat="server"  Text="Cancel / Retry Upload" visible ="False"/><br />
                        <div style=" width: 90%;    overflow-x: auto;  overflow-y: auto;  white-space: nowrap;">
    <asp:GridView ID="gvPreview" runat="server" CssClass="mytable" >
    </asp:GridView></div>
   
                   
                              </asp:Panel>
                            
                        </div>
                      </div>
                    </div>
                      <div class="vue-misc" id="divHome" visible="True" runat="server">
                    
                      <div class="row m-t-25">
                          <%-- <div class="col-md-auto" >--%>
                             <div class="col-md-4 col-lg-4">
                             <div class="overview-item overview-item--c1">
                                 <a href="hrBiometric.aspx?mode=myattendance">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-account-o"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>My Attendance</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                 </div>   <div class="col-md-4 col-lg-4">

                                  <div class="overview-item overview-item--c2">
                                 <a href="hrBiometric.aspx?mode=calendar">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-calendar"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Holiday Calendar</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                      </div><div class="col-md-4 col-lg-4">
                         <div class="overview-item overview-item--c4">
                                 <a href="hrBiometric.aspx?mode=leaverequest">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-file"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Leave Request</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                           </div>   <div class="col-md-4 col-lg-4">
                              <div class="overview-item overview-item--c3">
                                 <a href="https://bifpcl.online/spinehrms">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-balance-wallet"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>hrBiometric.aspx?mode=balance</h2>--%>
                                                <span>Leave Balance</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                                </div>   <div class="col-md-4 col-lg-4">
                         <div class="overview-item overview-item--c4">
                                 <a href="https://bifpcl.online/spinehrms">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-sort-asc"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>hrBiometric.aspx?mode=attendance</h2>--%>
                                                <span>Daily Attendance</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                           </div>   <div class="col-md-4 col-lg-4">
                              <div class="overview-item overview-item--c2">
                                 <a href="https://bifpcl.online/spinehrms">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-male-female"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>hrBiometric.aspx?mode=allattendance</h2>--%>
                                                <span>HR Leave Report</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                                </div>   <div class="col-md-4 col-lg-4">
                                              <div class="overview-item overview-item--c4">
                                 <a href="https://bifpcl.online/spinehrms">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-border-color"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>hrBiometric.aspx?mode=manageattendance</h2>--%>
                                                <span>HR Manage Leaves</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                                     </div>   <div class="col-md-4 col-lg-4">
                              <div class="overview-item overview-item--c3">
                                 <a href="hrBiometric.aspx?mode=biometric">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-upload"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Upload Biometric Data</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                                          </div>   
                           <%-- </div>--%>
                          </div>
                          </div>
                   <asp:Panel ID="pnlPrintApp" class="vue-misc"  Visible="false" runat="server">
                      <div class="row">
                         <div class=" col-md-12">
                          <h3 class="mb-3"> Preview Application </h3>
                             <%-- <input class='btn btn-info m-l-10 m-b-10' type="button" onclick="PrintDiv();" value="click to Print" />
                             Note: Take the Print and submit the signed copy to HR.--%>
                            <aside class="profile-nav alt" id="divProfile" runat="server">
                     
                                </aside>
                              <br />&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;<div class="col col-md-3">
                                  <asp:Button ID="btnSubmitPrint"  runat="server" Text="Submit to Print" Visible="True"  class="au-btn au-btn--block au-btn--green m-b-20" />

                                                                          </div>
                             <div class="col col-md-3">
                                  <asp:Button ID="btnModifyPrint"  runat="server" Text="Go back & Modify" Visible="True"  class="au-btn au-btn--block au-btn--blue m-b-20" />

                                                                          </div>

            Note: On submission, data will be saved.Take the print and submit the signed copy to HR after approval of competent authority.
                              <asp:Label ID="Label1" runat="server" Text="" ForeColor="red"></asp:Label>
                        </div>
                      </div>
                        </asp:Panel>
                    <div class="vue-misc" id="divBalance" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-12">
                          <h3 class="mb-3"> Leave Balance </h3>
                           
                             <p> Scroll left to right. Touch enabled.</p>

                             <asp:GridView ID="gvLeaveQuota" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                  <label>Leave Credit Detail</label>  <asp:GridView ID="gvLeaveAccrual"    class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                 <label>Leave Availed Detail: For previous year go to My Attendance</label>   <asp:GridView ID="gvAvailed" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                   
                            
                        </div>
                      </div>
                    </div>
                  <div class="vue-misc" id="divRequest" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-12">
                          <h3 class="mb-3"> Leave Request </h3>
                              <div class="form-horizontal" style="color:black;" >
                                  <div class="row form-group"> 
      <div class="col col-md-3"><label for="text-input" class=" form-control-label">Leave Application No:</label></div>                                           
                     <div class="col col-md-9"> <asp:Label ID="lbID" runat="server" Text="" ForeColor="Green"></asp:Label>
                         </div></div>
                                     <div class="row form-group"> 
      <div class="col col-md-3"><label for="text-input" class=" form-control-label">Leave Type:</label></div>                                           
                     <div class="col col-md-9">   <asp:RadioButtonList ID="rblLeaveType" AutoPostBack="true"  RepeatDirection="Horizontal"   runat="server" >
                               <asp:ListItem Value="Out" Selected="true">Out Station Leave</asp:ListItem>
                                       <asp:ListItem Value="In">In Station Leave</asp:ListItem>
                              </asp:RadioButtonList>
  </div></div>
<div class="row form-group"> 
      <div class="col col-md-3"><label for="text-input" class=" form-control-label" id="lbFrom" runat="server">Date of Leaving Station:</label></div>                                           
                     <div class="col col-md-9">  <asp:TextBox ID="txtDt_st_out" runat="server"  MaxLength="15"   class="au-input au-input--full" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd.MM.yyyy" TargetControlID="txtDt_st_out"  />
   <asp:DropDownList ID="ddlout"  runat="server" >
                               <asp:ListItem Value="FN">Forenoon</asp:ListItem>
                                       <asp:ListItem Value="AN" Selected="true">Afternoon</asp:ListItem>
                             </asp:DropDownList>
   </div></div> 
                                  <div class="row form-group"> 
      <div class="col col-md-3"><label for="text-input" class=" form-control-label"  id="lbTo" runat="server">Date of Joining Station:</label></div>                                           
                     <div class="col col-md-9">  <asp:TextBox ID="txtDt_st_in" runat="server"  MaxLength="15"   class="au-input au-input--full" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd.MM.yyyy" TargetControlID="txtDt_st_in"  />
   <asp:DropDownList ID="ddlin"  runat="server" >
                               <asp:ListItem Value="FN" Selected="True" >Forenoon</asp:ListItem>
                                       <asp:ListItem Value="AN">Afternoon</asp:ListItem>
                             </asp:DropDownList>
   </div></div> 
                                  <div class="row form-group"> 
      <div class="col col-md-3"><label for="text-input" class=" form-control-label">Leave Details:</label></div>                                           
                     <div class="col col-md-9">     Give your leave breakup
   </div></div> 
  <div class="row form-group">
                                  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 1.&nbsp; &nbsp;   <asp:DropDownList ID="ddlL1type" DataTextField="leave" DataValueField="type"  runat="server" >
                                      </asp:DropDownList> &nbsp; &nbsp; &nbsp; &nbsp;  <asp:TextBox ID="txtL1From" runat="server"  MaxLength="15" placeholder="From"  class="au-input au-input--full" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd.MM.yyyy" TargetControlID="txtL1From"  />
       &nbsp; &nbsp; &nbsp; &nbsp;  <asp:TextBox ID="txtL1To" runat="server"  MaxLength="15" placeholder="To"  class="au-input au-input--full" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd.MM.yyyy" TargetControlID="txtL1To"  />
                                  </div>
 <div class="row form-group">
                                  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 2.&nbsp; &nbsp;   <asp:DropDownList ID="ddlL2type" DataTextField="leave" DataValueField="type"  runat="server" >
                                      </asp:DropDownList> &nbsp; &nbsp; &nbsp; &nbsp;  <asp:TextBox ID="txtL2From" runat="server"  MaxLength="15" placeholder="From"  class="au-input au-input--full" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd.MM.yyyy" TargetControlID="txtL2From"  />
       &nbsp; &nbsp; &nbsp; &nbsp;  <asp:TextBox ID="txtL2To" runat="server"  MaxLength="15" placeholder="To"  class="au-input au-input--full" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd.MM.yyyy" TargetControlID="txtL2To"  />
                                  </div>
 <div class="row form-group">
                                  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 3.&nbsp; &nbsp;   <asp:DropDownList ID="ddlL3type" DataTextField="leave" DataValueField="type"  runat="server" >
                                      </asp:DropDownList> &nbsp; &nbsp; &nbsp; &nbsp;  <asp:TextBox ID="txtL3From" runat="server"  MaxLength="15" placeholder="From"  class="au-input au-input--full" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender8" runat="server" Format="dd.MM.yyyy" TargetControlID="txtL3From"  />
       &nbsp; &nbsp; &nbsp; &nbsp;  <asp:TextBox ID="txtL3To" runat="server"  MaxLength="15" placeholder="To"  class="au-input au-input--full" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd.MM.yyyy" TargetControlID="txtL3To"  />
                                  </div>
<div class="row form-group"> 
      <div class="col col-md-3"><label for="text-input" class=" form-control-label">Purpose of Leave:</label></div>                                           
                     <div class="col col-md-9">        <asp:TextBox ID="txtPurpose"    MaxLength="50"  Width="200px"  class="au-input au-input--full" runat="server" />  
          </div></div>
                                  <div class="row form-group"> 
      <div class="col col-md-3"><label for="text-input" class=" form-control-label">Address during  leave period:</label></div>                                           
                     <div class="col col-md-9">        <asp:TextBox ID="txtAddress"    MaxLength="100"  Width="300px"  class="au-input au-input--full" runat="server" />  
          </div></div>
                                  <div class="row form-group"> 
      <div class="col col-md-3"><label for="text-input" class=" form-control-label">Remark:</label></div>                                           
                     <div class="col col-md-9">        <asp:TextBox ID="txtRemark"    MaxLength="100"  Width="300px"  class="au-input au-input--full" runat="server" />  
          </div></div>
                                   <br />&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;<div class="col col-md-3"><asp:Button ID="btnSumbitLeaveRequest" OnClick="btnSumbitLeaveRequest_Click" runat="server" Text="Preview the details" Visible="True"  class="au-btn au-btn--block au-btn--green m-b-20" /></div>
          <br />&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;
                          <button type='button' class='btn btn-danger m-l-10 m-b-10' style='  text-transform: capitalize;'>
                              <asp:Label ID="lbRequestMessage" runat="server" Text="" ForeColor="white"></asp:Label>
                              </button>
                                  Mode: <asp:Label ID="lbMode" runat="server" Text="New" ForeColor="BLUE"></asp:Label>
                                  </div>

                               <p> Previous Leave Requests: Scroll left to right. Touch enabled.</p>
                             <asp:GridView ID="gvLeaveRequest" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                   
                            
                        </div>
                      </div>
                    </div>
                     <div class="vue-misc" id="divCalendar" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-12">
                          <h3 class="mb-3"> Holiday Calendar </h3>
                              <asp:RadioButtonList ID="rblHolidayOrg" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem  Value="NTPC" Selected="true">NTPC</asp:ListItem>                  
                                <asp:ListItem Value="BPDB">BPDB & BIFPCL</asp:ListItem>
                                   </asp:RadioButtonList>
                              <asp:RadioButtonList ID="rblHolidayLoc" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem  Value="SO" Selected="true">Site Office</asp:ListItem>                  
                                <asp:ListItem Value="HO">Head Office</asp:ListItem>
                                   </asp:RadioButtonList>
                             <p> Scroll left to right. Touch enabled.</p>
                             <asp:GridView ID="gvCalendar" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                   
                            
                        </div>
                      </div>
                    </div>
                          <div class="vue-misc" id="divAttandance" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-12">
                          <h3 class="mb-3"> Daily Attendance </h3>
                             <p> </p>
                             <div style="border-color:blue;border-width:2px;">
                             <asp:TextBox ID="txtDate" runat="server" BorderWidth="1"  BorderColor="Black"  AutoPostBack="True"  ></asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd.MM.yyyy" TargetControlID="txtDate"  />
                           <%--  <asp:TextBox ID="txtSearch" runat="server" BorderWidth="2px" BorderColor="Black" placeholder="Enter few characters" Width="190"></asp:TextBox> &nbsp;&nbsp; 
                             <asp:Button ID="btnSubmit" runat="server" Text="Go" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  /> 
                          --%>  <br /> <br /><asp:RadioButtonList ID="rblType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem   Value="SO">Site Office</asp:ListItem>                  
                                <asp:ListItem Value="HO">Head Office</asp:ListItem>
                                <asp:ListItem Selected="True" Value="%">Both</asp:ListItem>
                                              </asp:RadioButtonList>
                             <asp:CheckBox ID="cbAbsent"  AutoPostBack="true" runat="server" Checked="false" Text="Only Show Absent/Leave/Tour" />
                             &nbsp;&nbsp;&nbsp;<asp:Button ID="btnShowAttandance" runat="server" Text="Go" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                             </div><br />
                             <p> Scroll left to right. Touch enabled.</p>
                                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnEmail" runat="server" Text="Mail to MD" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                             <-- Don't missuse this feature. Your name will also go on email to MD with report.
                             <div id="divExport" runat="server">
                                 <asp:Label ID="lbDetail" runat="server" Text=""></asp:Label>
                             <br /> Office time: 09:00 to 18:00
                             <br />
                          <span style='background-color: green; color: white;'>   Present  (Before 09:15 and Onwards 18:00)   </span>       <br />
                          <span style='background-color: yellow; color: black;'>   Compensate Clock out (Between 09:15 to 09:30) </span>         <br />
                           <span style='background-color: red; color: white;'>  Apply OD/Leave (After 09:30 or Before 18:00)  </span>     <br />
                             
                             <asp:GridView ID="gvAttendance" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                   <div  id="divLeaveType"  runat="server" />
                                 </div>
                        </div>
                      </div>
                    </div>
                        <div class="vue-misc" id="divMyAttendance" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-12">
                          <h3 class="mb-3"> My Attendance </h3>
                             <p> Select the month </p>
                             <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true"></asp:DropDownList>
                           <br />   <asp:CheckBox ID="cbMyabsent"  AutoPostBack="true" runat="server" Checked="false" Text="Only Show Absent/Leave/Tour" />
                                <%--  <asp:TextBox ID="txtSearch" runat="server" BorderWidth="2px" BorderColor="Black" placeholder="Enter few characters" Width="190"></asp:TextBox> &nbsp;&nbsp; 
                             <asp:Button ID="btnSubmit" runat="server" Text="Go" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  /> 
                          --%>  &nbsp;&nbsp;&nbsp;<%--<asp:Button ID="btnMygo" runat="server" Text="Go" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />--%>
                             <br /><asp:Label ID="lbMy" runat="server" Text=""></asp:Label>
                        
                              <br />
                             Office time: 09:00 to 18:00
                             <br />
                          <span style='background-color: green; color: white;'>   Present  (Before 09:15 and Onwards 18:00)   </span>       <br />
                          <span style='background-color: yellow; color: black;'>   Compensate Clock out (Between 09:15 to 09:30) </span>         <br />
                           <span style='background-color: red; color: white;'>  Apply OD/Leave (After 09:30 or Before 18:00)  </span>     <br />
                                  <p> Scroll left to right. Touch enabled.  </p>
                             <asp:GridView ID="gvMyattendance" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                     <div  id="divMyLeaveType"  runat="server" />
                           <h3 class="mb-3"> Leaves Availed </h3>
                             <p>July Onwards</p>
                                           <asp:GridView ID="gvLeavesAvailed" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                 
                        </div>
                      </div>
                    </div>
                  <div class="vue-misc" id="divAllAttendance" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-12">
                          <h3 class="mb-3"> HR Reports </h3>
                             <button type="button" onclick="alert('Already showing');" class="btn btn-primary btn-sm">
                                            <i class="fa fa-star"></i>&nbsp; HR Leave Report</button>
                           <a href="hrAttendance.aspx?mode=report">  <button type="button" class="btn btn-success btn-sm">
                                            <i class="fa fa-magic"></i>&nbsp; Absentee Statement</button></a>
                             <a href="hrAttendance.aspx?mode=checkbio"> <button type="button" class="btn btn-warning btn-sm">
                                            <i class="fa fa-map-marker"></i>&nbsp; Biometric Mapping</button> </a>
                             <p> Select Employee and Month </p>
                               <asp:DropDownList ID="ddlProfile" runat="server" AutoPostBack="true" ></asp:DropDownList>
                              <br /> 
                             <asp:DropDownList ID="ddlMonthAll" runat="server" AutoPostBack="true"></asp:DropDownList>
                               <asp:CheckBox ID="cbAllAbsent"  AutoPostBack="true" runat="server" Checked="false" Text="Only Show Absent/Leave/Tour" />
                             <div id="divPic" runat="server" style="height:100px;width:100px;" />
                                <%--  <asp:TextBox ID="txtSearch" runat="server" BorderWidth="2px" BorderColor="Black" placeholder="Enter few characters" Width="190"></asp:TextBox> &nbsp;&nbsp; 
                             <asp:Button ID="btnSubmit" runat="server" Text="Go" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  /> 
                          --%>   &nbsp;&nbsp;&nbsp;<%--<asp:Button ID="btnMygo" runat="server" Text="Go" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />--%>
                             <br /><asp:Label ID="lbMyall" runat="server" Text=""></asp:Label>
                           
                              <br />
                             Office time: 09:00 to 18:00
                             <br />
                          <span style='background-color: green; color: white;'>   Present  (Before 09:15 and Onwards 18:00)   </span>       <br />
                          <span style='background-color: yellow; color: black;'>   Compensate Clock out (Between 09:15 to 09:30) </span>         <br />
                           <span style='background-color: red; color: white;'>  Apply OD/Leave (After 09:30 or Before 18:00)  </span>     <br />
                               <p> Scroll left to right. Touch enabled.</p>
                             <asp:GridView ID="gvAllAttendance" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                   
                            
                        </div>
                      </div>
                    </div>
                 <div class="vue-misc" id="divManageAttendance" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-lg-12">
                          <h3 class="mb-3"> HR Manage Leave</h3>
                              <asp:Panel ID="pnlAccrual" Visible="false"  runat="server">
                                  <h5>All Employee Section</h5>
                                 <asp:Label ID="lbMessage" runat="server" Text="Note:Assign  for all employees having joining date prior to 1st Jan. For new joinee take care seperately. (Click and wait for 30 Sec)"></asp:Label>
                               <br />     <asp:Button ID="btnAssignCL" Text="Assign CL/RH"  cssclass="btn btn-primary m-l-10 m-b-10" runat="server"  />
                                 <asp:Button ID="btnAssignNTPCApr" Enabled="false" Text="Assign EL/SAL/HPL (NTPC)"  cssclass="btn btn-primary m-l-10 m-b-10" runat="server"  />
                                  <asp:Button ID="btnAssignNTPCOct"  Enabled="false" Text="Assign EL/SAL/HPL (NTPC)"  cssclass="btn btn-primary m-l-10 m-b-10" runat="server"  />
                             </asp:Panel>
                              <h5>Individual Employee Section</h5>
                             <p> Select Employee and Month </p>
                             <asp:RadioButtonList ID="rblOrg" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem  Value="NTPC" Selected="true">NTPC</asp:ListItem>                  
                                <asp:ListItem Value="BPDB">BPDB</asp:ListItem>
                                   <asp:ListItem Value="BIFPCL">BIFPCL</asp:ListItem>
                                   </asp:RadioButtonList>
                               <asp:DropDownList ID="ddlManageProfile" runat="server" AutoPostBack="true" ></asp:DropDownList>
                              <br /> 
                             <asp:DropDownList ID="ddlManageMonth" runat="server" AutoPostBack="true"></asp:DropDownList>
                        <%--       <asp:CheckBox ID="cbManageAbsent"  AutoPostBack="true" runat="server" Checked="false" Text="Only Show Absent/Leave/Tour" />--%>
                             <div id="divPic2" runat="server" style="height:100px;width:100px;" />
                                <%--  <asp:TextBox ID="txtSearch" runat="server" BorderWidth="2px" BorderColor="Black" placeholder="Enter few characters" Width="190"></asp:TextBox> &nbsp;&nbsp; 
                             <asp:Button ID="btnSubmit" runat="server" Text="Go" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  /> 
                          --%>   &nbsp;&nbsp;&nbsp;<%--<asp:Button ID="btnMygo" runat="server" Text="Go" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />--%>
                             <br /><asp:Label ID="lbManage" runat="server" Text=""></asp:Label>
                                   <asp:DropDownList ID="ddlFutureDate" runat="server" ></asp:DropDownList>
                                 &nbsp;&nbsp;&nbsp;<asp:Button ID="btnFutureDateAdd" runat="server" Text="Add selected date for future leave" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                         <asp:Label ID="lbLocation" runat="server" Text="" />
                               <asp:GridView ID="gvDPRDetail" Width="100%" CssClass="table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
                DataKeyNames="uid,dt" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added.">
                <Columns>

                   <%--  <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="true" />--%>
                       <asp:TemplateField HeaderText="Date" ItemStyle-Width="180">
                     <ItemTemplate>
                            <asp:Label ID="lblDate"  runat="server" Text='<%# showHoliday(Eval("Date"))%>'></asp:Label>
                        </ItemTemplate>
                            </asp:TemplateField>
                      <asp:BoundField DataField="In" HeaderText="In" ReadOnly="true" />
                      <asp:BoundField DataField="Out" HeaderText="Out" ReadOnly="true" />
                    <%-- <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="true" />--%>
                    <asp:TemplateField HeaderText="Regularizing Indicator" ItemStyle-Width="100">

                        <ItemTemplate>
                            <asp:Label ID="lblRegularise" Width="50" runat="server" Text='<%# Eval("leavetype")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlRegularise" runat="server"    >
                                     <%-- selectedvalue='<%# Bind("reg")%>' <asp:ListItem Value="OD">On Duty</asp:ListItem>
                                      <asp:ListItem Value="CL">Caual Leave</asp:ListItem>
                                       <asp:ListItem Value="CL1/2">Half CL</asp:ListItem>
                                       <asp:ListItem Value="RH">Restricted Holiday</asp:ListItem>
                                        <asp:ListItem Value="GH">Government Holiday</asp:ListItem>
                                       <asp:ListItem Value="EL">Earned Leave</asp:ListItem>
                                       <asp:ListItem Value="SAL">SAL</asp:ListItem>
                                        <asp:ListItem Value="-">-</asp:ListItem>
                               --%>   </asp:DropDownList>
                         
                         <%--   <asp:TextBox ID="tbRegularise" Width="50"  runat="server" Text='<%# Bind("reg")%>'  BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>--%>
                        </EditItemTemplate>
                         
                    </asp:TemplateField>
                     
                    <%-- <asp:BoundField DataField="Progress" HeaderText="Compln" ReadOnly="true" />--%>
                    <%-- <asp:BoundField DataField="Progdate" HeaderText="Progdate" ReadOnly="true" />--%>
                    <%--  <asp:BoundField  DataField="Cummulative" HeaderText="Cumm" ControlStyle-Font-Bold="true" ControlStyle-BackColor="YellowGreen" ControlStyle-Width="80%"   ApplyFormatInEditMode="true"/>--%>

                    <asp:CommandField ButtonType="Link" ShowEditButton="true" />
                     <asp:TemplateField HeaderText="Log" ItemStyle-Width="180">
                     <ItemTemplate>
                            <asp:Label ID="lblLog"  runat="server" Text='<%# Eval("log")%>'></asp:Label>
                        </ItemTemplate>
                            </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hrdb  %>"
                ProviderName="System.Data.SQLite"
                SelectCommand="select b.uid,c.name, ifnull(reg,'-') as reg, strftime('%d.%m.%Y',dt) as Date, dt, intime as 'In', outtime as 'Out',  (CASE WHEN absent = 1 THEN 'Absent' ELSE 'Present' END) as Status, ifnull(reg,'-') as 'Regularizing Indicator' , l.leavetype, log from contacts_new c left outer join biometric b on c.bioid = b.uid left outer join leaveavailed l on b.uid = l.uid and b.dt = l.leavedt where email=@email and (dt >= @st_dt  and  dt <= @end_dt )    order by dt asc"
                UpdateCommand="replace  into leaveavailed (uid, leavedt, leavetype, log) values(@uid,@dt,@reg, @log) ">

                <UpdateParameters>
                    <asp:Parameter Name="uid" Type="Int32" />
                      <asp:Parameter Name="dt" Type="string" />
                      <asp:Parameter Name="reg" Type="string" />
                       <asp:Parameter Name="log" Type="string" />
                </UpdateParameters>
          
                <SelectParameters>
                    <asp:Parameter Name="email" Type="string" />
                     <asp:Parameter Name="st_dt" Type="string" />
                     <asp:Parameter Name="end_dt" Type="string" />
                    
                </SelectParameters>
            </asp:SqlDataSource>
                             <br />
                             Office time: 09:00 to 18:00
                             <br />
                          <span style='background-color: green; color: white;'>   Present  (Before 09:15 and Onwards 18:00)   </span>       <br />
                          <span style='background-color: yellow; color: black;'>   Compensate Clock out (Between 09:15 to 09:30) </span>         <br />
                           <span style='background-color: red; color: white;'>  Apply OD/Leave (After 09:30 or Before 18:00)  </span>     <br />
                           <asp:GridView ID="gvLeaveQuotaManage" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                  <label>Leave Credit Detail</label>  <asp:GridView ID="gvLeaveAccrualManage"    class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                   
                        </div>
                      </div>
                    </div>
                       <div id="divMsg" runat="server" />
                 </ContentTemplate>
               
               </asp:UpdatePanel>
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
   <%-- <script src="vendor/animsition/animsition.min.js"></script>--%>
    <script src="vendor/bootstrap-progressbar/bootstrap-progressbar.min.js">
    </script>
    <script src="vendor/counter-up/jquery.waypoints.min.js"></script>
    <script src="vendor/counter-up/jquery.counterup.min.js">
    </script>
   <%-- <script src="vendor/circle-progress/circle-progress.min.js"></script>--%>
    <script src="vendor/perfect-scrollbar/perfect-scrollbar.js"></script>
    <script src="vendor/chartjs/Chart.bundle.min.js"></script>
    <script src="vendor/select2/select2.min.js">
    </script>
 
    <!-- Main JS-->
    <!-- Main JS  Closed because giving problem on Gridview paging with animsition-->
   <%-- <script src="js/main.js"></script>--%>
    <script src="js/miniMain.js"></script>

   <%-- <script language="javascript" type="text/javascript">
        function PrintMyAttendance() {
            var printContent = document.getElementById
            ('<%= gvMyattendance.ClientID %>');
            var printWindow = window.open("HR Attendance", 
            "Print My Attendance", 'left=50000,top=50000,width=0,height=0');
            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
        }
    </script>--%>
      <%--  <script type="text/javascript">
        function PrintDiv() {
            var divContents = document.getElementById("divProfile").innerHTML;
            var printWindow = window.open('', '', 'height=600,width=800');
            printWindow.document.write('<html><head><title>Print Leave Application: BIFPCL</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(divContents);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
        }
    </script>--%>
</body>
</html>
