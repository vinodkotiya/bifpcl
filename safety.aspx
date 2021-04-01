<%@ Page Language="VB" AutoEventWireup="false" CodeFile="safety.aspx.vb" Inherits="_safety" %>
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

            <!-- MAIN CONTENT-->
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
                                        <li class="list-inline-item">Safety</li>
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
                            <h1 class="title-4">BIFPCL
                                <span>Safety App</span>
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
                    <div class="row">
              <div class="col-md-12">


                 <div class="vue-misc" id="divHome" visible="True" runat="server">
                       <div class="row">
                       <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="safety.aspx?mode=incidentall">
                            <div class="statistic__item statistic__item--green">
                                <h2 class="number">Incidents/ Clearances</h2>
                                <span class="desc">Report incidents or upload clearances.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-card"  style="opacity:.4"></i>
                                </div>
                            </div>
                            </a>
                        </div>
                            
                       <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="safety.aspx?mode=obsview">
                            <div class="statistic__item statistic__item--red">
                              <h2 class="number">Observation/ Compliance</h2>
                                <span class="desc">Upload pics of observations</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-hospital" style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                               <a style="display:block" href="safety.aspx?mode=incident">
                            <div class="statistic__item statistic__item--orange">
                                <h2 class="number">Recording by Safety Officer</h2>
                                <span class="desc">Safety incidents entry.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-check" style="opacity:.4"></i>
                                </div>
                            </div>
                                    </a>
                        </div>
                             <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="safety.aspx?mode=summary">
                            <div class="statistic__item statistic__item--blue">
                                <h2 class="number"> Reports Summary</h2>
                                <span class="desc">Get the summary.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-receipt"  style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="safety.aspx?mode=nearmiss">
                            <div class="statistic__item statistic__item--red" style="background:#6f42c1">
                                <h2 class="number">Near Miss Incidents</h2>
                                <span class="desc">Datewise list</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-notifications-active" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="safety.aspx?mode=firstaid">
                            <div class="statistic__item statistic__item--red">
                                <h2 class="number">First Aid Incidents</h2>
                                <span class="desc">Datewise list</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-help-outline" style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="safety.aspx?mode=fatal">
                            <div class="statistic__item statistic__item--green">
                                <h2 class="number">Fatal & Major Incidents</h2>
                                <span class="desc">Datewise list</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-hospital"  style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="safety.aspx?mode=minor">
                            <div class="statistic__item statistic__item--red">
                              <h2 class="number">Minor Incidents</h2>
                                <span class="desc">Datewise list</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-hospital" style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="safety.aspx?mode=property">
                            <div class="statistic__item statistic__item--red" style="background:#6f42c1">
                                 <h2 class="number">Property Damage</h2>
                                <span class="desc">Datewise list</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-home" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="safety.aspx?mode=training">
                            <div class="statistic__item statistic__item--red" style="background:#20c997">
                                <h2 class="number">Training Report</h2>
                                <span class="desc">Training by agencies</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-library" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="safety.aspx?mode=reports">
                            <div class="statistic__item statistic__item--blue">
                                <h2 class="number">Safety Documents</h2>
                                <span class="desc">Safety Manual/videos</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-receipt"  style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                    </div>
                
                          </div>
                         <div class="card border border-success" id="divEmergency" visible="True" runat="server">
                                    <div class="card-header">
                                        <strong class="card-title">Emergency Contacts</strong>
                                    </div>
                                    <div class="card-body">
                                        <p class="card-text">For all incidents and events leading to medical treatment following should be contacted as soon as possible.(Click to dial)
                                        </p>
                                        <ul>
                                            <li>Ambulance MSTPP Site <a href="tel:+8801798751272" onclick="call('+8801798751272');" > <i class='fa fa-mobile'></i>  +8801798751272</a> </li>
                                            <li>Fire and Civil Defence Mongla EPZ <a href="tel:+8801759856385" onclick="call('+8801759856385');" > <i class='fa fa-mobile'></i>  +8801759856385 /  </li>
<li>Mongla fire station  <a href="tel:0466275111" onclick="call('0466275111');" > <i class='fa fa-mobile'></i>  0466275111</a> </li>
<li>khulna control room division<a href="tel:041760333" onclick="call('041760333');" > <i class='fa fa-mobile'></i>  041760333</a> </li>
<li>Central control room Dhaka <a href="tel:029555555" onclick="call('029555555');" > <i class='fa fa-mobile'></i>  029555555</a> </li>
                                          <li>DM Security and Admin <a href="tel:+8801678582885" onclick="call('+8801678582885');" > <i class='fa fa-mobile'></i>  +8801678582885</a> </li>
                                            <li>DM Fire and Safety <a href="tel:+8801678582886" onclick="call('+8801678582886');" > <i class='fa fa-mobile'></i>  +8801678582886</a> </li>
                                            <li>Police Fire and Civil Defence <a href="tel:999" onclick="call('999');" > <i class='fa fa-mobile'></i>  999</a> </li>
                                            <li>Government Helpline <a href="tel:333" onclick="call('333');" > <i class='fa fa-mobile'></i>  333</a> </li>
                                            <li>Weather <a href="tel:1090" onclick="call('1090');" > <i class='fa fa-mobile'></i>  1090</a> </li>
                                            <li>Safety Officer BHEL <a href="tel:+8801730719905" onclick="call('+8801730719905');" > <i class='fa fa-mobile'></i>  +8801730719905</a> | <a href="tel:+8801707070149" onclick="call('+8801707070149');" > <i class='fa fa-mobile'></i>  +8801707070149</a> </li>
                                        </ul>
                                    </div>
                                </div>
                       <div class="card"  id="divPics" visible="True" runat="server" >
                  <div class="card-header">
                    <strong class="card-title">Safety Do's & Dont's</strong>
                  </div>

                  <div class="card-body" >
                  
               
                  
                       <div class="vue-misc" id="div1"  runat="server">
                    
                      <div class="row">
                         <div class=" col-md-auto">
<div id="jssor_1" style="position:relative;margin:0 auto;top:0px;left:0px;width:980px;height:480px;overflow:hidden;visibility:hidden;">
        <!-- Loading Screen -->
        <div data-u="loading" class="jssorl-009-spin" style="position:absolute;top:0px;left:0px;width:100%;height:100%;text-align:center;background-color:rgba(0,0,0,0.7);">
            <img style="margin-top:-19px;position:relative;top:50%;width:38px;height:38px;" src="images/spin.svg" />
        </div>
        <div data-u="slides" style="cursor:default;position:relative;top:0px;left:0px;width:980px;height:380px;overflow:hidden;">
            <div>
                <img data-u="image" src="deptpics/safety/0.jpg?1" />
                <img data-u="thumb" src="deptpics/safety/0.jpg?1" />
            </div>
            <div>
                <img data-u="image" src="deptpics/safety/5.jpg" />
                <img data-u="thumb" src="deptpics/safety/5.jpg" />
            </div>
            <div>
                <img data-u="image" src="deptpics/safety/6.jpg" />
                <img data-u="thumb" src="deptpics/safety/6.jpg" />
            </div>
            <div>
                <img data-u="image" src="deptpics/safety/7.jpg" />
                <img data-u="thumb" src="deptpics/safety/7.jpg" />
            </div>
            <div>
                <img data-u="image" src="deptpics/safety/8.jpg" />
                <img data-u="thumb" src="deptpics/safety/8.jpg" />
            </div>
            <div>
                <img data-u="image" src="deptpics/safety/1.jpg" />
                <img data-u="thumb" src="deptpics/safety/1.jpg" />
            </div>
            <div>
                <img data-u="image" src="deptpics/safety/2.jpg" />
                <img data-u="thumb" src="deptpics/safety/2.jpg" />
            </div>
            <div>
                <img data-u="image" src="deptpics/safety/3.jpg" />
                <img data-u="thumb" src="deptpics/safety/3.jpg" />
            </div>
            <div>
                <img data-u="image" src="deptpics/safety/4.jpg" />
                <img data-u="thumb" src="deptpics/safety/4.jpg" />
            </div>
            
        </div>
        <!-- Thumbnail Navigator -->
        <div data-u="thumbnavigator" class="jssort101" style="position:absolute;left:0px;bottom:0px;width:980px;height:100px;background-color:#000;" data-autocenter="1" data-scale-bottom="0.75">
            <div data-u="slides">
                <div data-u="prototype" class="p" style="width:190px;height:90px;">
                    <div data-u="thumbnailtemplate" class="t"></div>
                    <svg viewbox="0 0 16000 16000" class="cv">
                        <circle class="a" cx="8000" cy="8000" r="3238.1"></circle>
                        <line class="a" x1="6190.5" y1="8000" x2="9809.5" y2="8000"></line>
                        <line class="a" x1="8000" y1="9809.5" x2="8000" y2="6190.5"></line>
                    </svg>
                </div>
            </div>
        </div>
        <!-- Arrow Navigator -->
        <div data-u="arrowleft" class="jssora106" style="width:55px;height:55px;top:162px;left:30px;" data-scale="0.75">
            <svg viewbox="0 0 16000 16000" style="position:absolute;top:0;left:0;width:100%;height:100%;">
                <circle class="c" cx="8000" cy="8000" r="6260.9"></circle>
                <polyline class="a" points="7930.4,5495.7 5426.1,8000 7930.4,10504.3 "></polyline>
                <line class="a" x1="10573.9" y1="8000" x2="5426.1" y2="8000"></line>
            </svg>
        </div>
        <div data-u="arrowright" class="jssora106" style="width:55px;height:55px;top:162px;right:30px;" data-scale="0.75">
            <svg viewbox="0 0 16000 16000" style="position:absolute;top:0;left:0;width:100%;height:100%;">
                <circle class="c" cx="8000" cy="8000" r="6260.9"></circle>
                <polyline class="a" points="8069.6,5495.7 10573.9,8000 8069.6,10504.3 "></polyline>
                <line class="a" x1="5426.1" y1="8000" x2="10573.9" y2="8000"></line>
            </svg>
        </div>
    </div>
    <!-- #endregion Jssor Slider End -->
                    </div>
                      </div>
                    </div>
                      </div>
                    </div>

            
                 <div class="vue-misc"  id="divOBS" visible="false" runat="server">
                     <div class="card" >
                  <div class="card-header">
                    <strong class="card-title">Safety Observation & Compliance</strong>
                         <a href="safety.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>  Back</button></a>
                  </div>

                  <div class="card-body" >
                     <div class="vue-misc" >
                    
                      <div class="row">
                         <div class="col-md-12">
                             <div class="form-group" id="divOBSEntry" runat="server" visible="false">
                                   <div class="card-header">   Note: Attach pictures with observations/compliance. </div>
                               <asp:RadioButtonList ID="rblOBS" runat="server" Enabled="false"  RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem  Value="obs" Selected="true" >Observation</asp:ListItem>                  
                                <asp:ListItem Value="com">Compliance</asp:ListItem>
                              </asp:RadioButtonList><asp:Label ID="lbObsID" runat="server" Text=""></asp:Label>
                                         <asp:DropDownList ID="ddlNewAgency"   DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>
                                         <asp:DropDownList ID="ddlNewWorkArea" DataTextField="t" DataValueField="v"  runat="server" ></asp:DropDownList>
                                <br />  <label><b>Description</b></label><br />
                                 <asp:TextBox ID="txtOBS" runat="server" class="au-input au-input--full"  Height="100px" TextMode="MultiLine" ></asp:TextBox> <br /><br /> 
                           
                                  <%--  <br /> <div id="divPic" runat="server" style="height:100px;width:100px;" /> --%>
                          <div class="col-md-3" style="display:flex"> <asp:FileUpload ID="FileUpload1" runat="server"  />
</div> <div class="col-md-6"  style="display:flex"> <asp:Button ID="btnUpload" Enabled="True" Text="Submit and Upload Picture" Width="290px" runat="server" OnClick="UploadFile"  class="au-btn au-btn--block au-btn--green m-b-20" />
<asp:Label ID="lbPicStatus" runat="server" Text="" ForeColor="Blue"></asp:Label>
</div> <hr />
                        <button type='button' class='btn btn-danger m-l-10 m-b-10' style='  text-transform: capitalize;'>
                                                     <asp:Label ID="lbBookMessageTop" runat="server" Text="" ForeColor="white"></asp:Label>
                            </button>
                    </div>
                            <br /> <br />
                             <div  id="divOBSView" runat="server" visible="false" >
                                 <a href="safety.aspx?mode=obsentry" >Add New Observation +</a>
                                 <asp:LinkButton ID="lbDownloadSummary"  Visible="false"  runat="server">Download</asp:LinkButton> 
              <asp:GridView ID="gvReportPic"  runat="server" HeaderStyle-CssClass="gvHeader"   Caption="Edit to comply" CaptionAlign="Left"
  CssClass="table-responsive table table-borderless table-striped  table--no-card m-b-30"   AlternatingRowStyle-CssClass="gvAltRow"  AutoGenerateColumns="false">
  <Columns>    <asp:TemplateField>      <HeaderTemplate>      <%--  <th colspan="6">Category</th>--%>
         <tr class="gvHeader">
          <th></th>
                      <th> SN</th>
                <th> Edit</th>
             <th>Agency</th>
             <th>Area</th>
             <th>Observation</th>
             <th>Picture</th>
             <th>Compliance</th>
            <th>Picture</th>
               <th>Status</th>
            
           </tr>
      </HeaderTemplate> 
      <ItemTemplate>
           <td><%# Eval("uid")%></td>
           <td><%#IIf(Eval("status") = "Open", "<a href='safety.aspx?mode=obsentry&id=" & Eval("uid") & "' target='_blank'>Comply</a>", "-") %></td>
          <td><%# Eval("agency")%></td>
            <td><%# Eval("area")%></td>
           <td><%# Eval("detail")%></td>
           <td><a href='upload/SAFETY/Report/<%#  Eval("pic") %>' target='_blank'><img src='upload/SAFETY/Report/<%#  Eval("pic") %>' alt='<%# Eval("pic")%>' width="50" height="75" /> </a></td>
         <td><%# Eval("reply") & "<br/>" & "<br/>" & "<br/>" & "<br/>" %></td>
            <td><a href='upload/SAFETY/Report/<%#  Eval("replypic") %>' target='_blank'><img src='upload/SAFETY/Report/<%#  Eval("replypic") %>' alt='<%# Eval("replypic")%>' width="50" height="75" /></a></td>
             <td><%# Eval("status")%></td>
      </ItemTemplate>    </asp:TemplateField>  </Columns>
       <EmptyDataTemplate><div>No Data Available</div></EmptyDataTemplate>    </asp:GridView> 
                                 </div>
                   
                        </div>
                      </div>
                    </div>
                       </div> </div>
                </div>
                       <div class="vue-misc"  id="divIncident" visible="false" runat="server">
                     <div class="card" >
                  <div class="card-header">
                    <strong class="card-title">Safety Incident Reporting by Executives</strong>
                         <a href="safety.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>  Back</button></a>
                  </div>

                  <div class="card-body" >
                     <div class="vue-misc" >
                    
                      <div class="row">
                         <div class=" col-md-auto">
                             <div class="form-group">
                                   <div class="card-header">   Note: Attach picture or clearances pdf with description. </div>
                              
                                  <label><b>Location/Description</b></label><br />
                                 <asp:TextBox ID="txtSubject" runat="server" class="au-input au-input--full" ></asp:TextBox> <br /><br /> 
                            
      <div id="divAttachments" runat="server" /> 
                   
                   <div id="fileatt" runat="server"  >
            <input type="file" name="attachment" runat="server" id="attachment" onchange="document.getElementById('moreUploadsLink').style.display = 'none';"  />
            </div>
      <input type="hidden" value="0" id="fileCount" />
      <div id="fileDiv">
      </div>
      <div id="moreUploadsLink" style="display: none">
            <a href="javascript:addFile();"></a>
      </div> <br />
      <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnUpload_Click" class="au-btn au-btn--block au-btn--green m-b-20" /> 
                            </div>
                            <br /> <br />
                               <asp:GridView ID="gvClearances"  Font-Size="15px" ForeColor="Black"  CellPadding="2" CssClass="table-responsive table table-borderless table-striped  table--no-card m-b-30" runat="server" />
           
                   
                        </div>
                      </div>
                    </div>
                       </div> </div>
                </div>
                    <div class="vue-misc"  id="divIncidentRecording" visible="false" runat="server">
                     <div class="card" >
                  <div class="card-header">
                    <strong class="card-title">Safety Incident Recording by Safety Officer</strong>
                       
                  </div>

                  <div class="card-body" >
                     <div class="vue-misc" >
                    
                      <div class="row">
                         <div class=" col-md-auto">
                               <div class="form-group">
                               <div class="card-header">   Note: Upload the picture in Gallery before entering the Data. <a href="Gallery.aspx" target="_blank"> Click for Gallery</a> </div>
                                  <label><b>S No</b></label><br />
                                  <asp:TextBox ID="txtIncedentSNo" runat="server" class="au-input au-input--full"  Width="100px"></asp:TextBox> 
                              <br />
                          <label><b>Agency</b></label><br />
                                 <asp:TextBox ID="txtIncedentAgency" runat="server" class="au-input au-input--full" ></asp:TextBox> <br />
                                   <label><b>Type of Incident</b></label><br />
                                <asp:RadioButtonList ID="rblIncedentType" runat="server"  RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem  Value="Fatal" >Fatal</asp:ListItem>                  
                                <asp:ListItem Value="Major Accident">Major Accident</asp:ListItem>
                  <asp:ListItem Value="Minor Accident" >Minor Accident</asp:ListItem>
                    <asp:ListItem Value="Near Miss Incident"  Selected="True"  >Near Miss Incident</asp:ListItem>
                                    <asp:ListItem Value="First Aid Injury"  >First Aid Injury</asp:ListItem>
                                    <asp:ListItem Value="Property Damage"  >Property Damage</asp:ListItem>
                               </asp:RadioButtonList>
                                  <label><b>Date of Incident</b></label><br />
                                 <asp:TextBox ID="txtIncedentDate" runat="server" class="au-input au-input--full" Width="100px" ></asp:TextBox> 
                                      <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd.MM.yyyy" TargetControlID="txtIncedentDate"  /> <br />
                                 
                                  <label><b>Location</b></label><br />
                                 <asp:TextBox ID="txtIncedentLocation" runat="server" class="au-input au-input--full" ></asp:TextBox> <br />
                                 
                                  <label><b>Victim Details</b></label><br />
                                 <asp:TextBox ID="txtIncedentVictim" runat="server" class="au-input au-input--full" ></asp:TextBox> <br />
                                  <label><b>Nature of work/Incident Details</b></label><br />
                                 <asp:TextBox ID="txtIncedentDetail" runat="server" class="au-input au-input--full"  TextMode="MultiLine" Width="500px" Height="200px"></asp:TextBox> <br />
                                  <label><b>RCA Carried Out</b></label><br />
                                 <asp:TextBox ID="txtInsedentRCA" runat="server" class="au-input au-input--full"  TextMode="MultiLine" Width="500px" Height="200px"></asp:TextBox> <br />
                                  <label><b>Corrective Action</b></label><br />
                                 <asp:TextBox ID="txtIncidentAction" runat="server" class="au-input au-input--full"  TextMode="MultiLine" Width="500px" Height="200px"></asp:TextBox> <br />
                                  <label><b>Remarks</b></label><br />
                                 <asp:TextBox ID="txtIncidentRemarks" runat="server" class="au-input au-input--full"  TextMode="MultiLine" Width="500px" Height="100px"></asp:TextBox> <br />
                                  <label><b>Picture</b></label><br />
                                  <asp:DropDownList ID="ddlIncidentPicture" runat="server"    /><br />
                                 
                                 <br /> 
                            
     <br />
      <asp:Button ID="btnIncidentSubmit" runat="server" Text="Submit"  class="au-btn au-btn--block au-btn--green m-b-20" /> 
                            </div>
                             <asp:Label ID="lblID" runat="server" Text=""></asp:Label> 
                            <br /> <br />
                            
                   
                        </div>
                      </div>
                    </div>
                       </div> </div>
                </div>
                      <div class="vue-misc"  id="divEditor" visible="false" runat="server">
                     <div class="card" >
                  <div class="card-header">
                    <strong class="card-title">Safety Incident Editor</strong>
                         <a href="safety.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>  Back</button></a>
                  </div>

                  <div class="card-body" >
                     <div class="vue-misc" >
                    <label><b>Select Type of Incident</b></label><br />
                                <asp:RadioButtonList ID="rblEditorType" runat="server" AutoPostBack="true"  RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem  Value="Fatal" >Fatal</asp:ListItem>                  
                                <asp:ListItem Value="Major Accident">Major Accident</asp:ListItem>
                  <asp:ListItem Value="Minor Accident" >Minor Accident</asp:ListItem>
                    <asp:ListItem Value="Near Miss Incident"  Selected="True"  >Near Miss Incident</asp:ListItem>
                                    <asp:ListItem Value="First Aid Injury"  >First Aid Injury</asp:ListItem>
                                    <asp:ListItem Value="Property Damage"  >Property Damage</asp:ListItem>
                               </asp:RadioButtonList>
                      <div class="row" style=" overflow-x: scroll;  overflow-y: hidden;  ">
                         <div class=" col-md-auto" >
                           <asp:GridView ID="gvDPRDetail" Width="100%" CssClass="table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
                DataKeyNames="uid"     EmptyDataText="No records has been added.">
                <Columns>
                     <asp:CommandField ButtonType="Link" ShowEditButton="true" />
                    <asp:TemplateField HeaderText="S No" ItemStyle-Width="100">

                        <ItemTemplate>
                            <asp:Label ID="lblCummulative" Width="50" runat="server" Text='<%# Eval("sn")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbCummulative" Width="50" runat="server" Text='<%# Bind("sn")%>' type="number" BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Incident Date" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblRemark" Width="100" runat="server" Text='<%# Eval("dt_incident")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRemark" Width="100"   runat="server"  Text='<%# Bind("dt_incident")%>'  TextMode="MultiLine"  BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="true" />--%>
                    <asp:TemplateField HeaderText="Type of Incident" ItemStyle-Width="100">

                        <ItemTemplate>
                            <asp:Label ID="lblType" Width="50" runat="server" Text='<%# Eval("type")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlType" runat="server"     selectedvalue='<%# Bind("type")%>'>
                                     <asp:ListItem  Value="Fatal" >Fatal</asp:ListItem>                  
                                <asp:ListItem Value="Major Accident">Major Accident</asp:ListItem>
                  <asp:ListItem Value="Minor Accident" >Minor Accident</asp:ListItem>
                    <asp:ListItem Value="Near Miss Incident"  >Near Miss Incident</asp:ListItem>
                                    <asp:ListItem Value="First Aid Injury"  >First Aid Injury</asp:ListItem>
                                    <asp:ListItem Value="Property Damage"  >Property Damage</asp:ListItem>
                              </asp:DropDownList>
                         
                         <%--   <asp:TextBox ID="tbRegularise" Width="50"  runat="server" Text='<%# Bind("reg")%>'  BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>--%>
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Pictures" ItemStyle-Width="100">

                        <ItemTemplate>
                            <asp:Label ID="lblPictures" Width="50" runat="server" Text='<%# Eval("Pictures")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlPictures" runat="server"    >
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
                    <asp:TemplateField HeaderText="Location" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblLocation" Width="100" runat="server" Text='<%# Eval("location")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbLocation" Width="100"   runat="server"  Text='<%# Bind("location")%>'    BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Agency" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblagency" Width="100" runat="server" Text='<%# Eval("agency")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbagency" Width="100"   runat="server"  Text='<%# Bind("agency")%>'    BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Victims" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblvictims" Width="100" runat="server" Text='<%# Eval("victims")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbvictims" Width="100"   runat="server"  Text='<%# Bind("victims")%>'   BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Incident Details" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lbldetail" Width="400" runat="server" Text='<%# Eval("detail")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbdetail" Width="300"  Height="250"  runat="server"  Text='<%# Bind("detail")%>'  TextMode="MultiLine"  BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="RCA Carried Out" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblrca" Width="400" runat="server" Text='<%# Eval("rca")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbrca" Width="300"  Height="250"   runat="server"  Text='<%# Bind("rca")%>'  TextMode="MultiLine"  BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Corrective Action" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblaction" Width="400" runat="server" Text='<%# Eval("action")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbaction" Width="300"  Height="250"   runat="server"  Text='<%# Bind("action")%>'  TextMode="MultiLine"  BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblRemarks" Width="400" runat="server" Text='<%# Eval("Remarks")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRemarks" Width="300" Height="250"    runat="server"  Text='<%# Bind("Remarks")%>'  TextMode="MultiLine"  BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="100">
                      <ItemTemplate>
                            <asp:Label ID="lblDel" Width="50" runat="server" Text='<%# Eval("del")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlDel" runat="server"     selectedvalue='<%# Bind("del")%>'>
                                     <asp:ListItem  Value="1" >Yes</asp:ListItem>                  
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:DropDownList>
                         
                         <%--   <asp:TextBox ID="tbRegularise" Width="50"  runat="server" Text='<%# Bind("reg")%>'  BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>--%>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="Progress" HeaderText="Compln" ReadOnly="true" />--%>
                    <%-- <asp:BoundField DataField="Progdate" HeaderText="Progdate" ReadOnly="true" />--%>
                    <%--  <asp:BoundField  DataField="Cummulative" HeaderText="Cumm" ControlStyle-Font-Bold="true" ControlStyle-BackColor="YellowGreen" ControlStyle-Width="80%"   ApplyFormatInEditMode="true"/>--%>

                   
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:appsdb  %>"
                ProviderName="System.Data.SQLite"
                SelectCommand=" select uid, sn , type, dt_incident, `location` , `agency` , `victims` , `detail` , `rca` , `action` , Remarks, Pictures, del  from safety_incident where  del = 0 and   type = @incidenttype   order by dt_incident desc "
                UpdateCommand="replace  into safety_incident (uid, sn , type, dt_incident,`location` , `agency` , `victims` , `detail` , `rca` , `action` , Remarks, Pictures, del) values(@uid, @sn , @type, @dt_incident, @location , @agency , @victims , @detail , @rca , @action , @Remarks, @Pictures, @del) ">

                <UpdateParameters>
                    <asp:Parameter Name="uid" Type="Int32" />
                      <asp:Parameter Name="sn" Type="string" />
                      <asp:Parameter Name="type" Type="string" />
                     <asp:Parameter Name="dt_incident" Type="string" />
                     <asp:Parameter Name="location" Type="string" />
                     <asp:Parameter Name="agency" Type="string" />
                     <asp:Parameter Name="victims" Type="string" />
                     <asp:Parameter Name="detail" Type="string" />
                     <asp:Parameter Name="rca" Type="string" />
                     <asp:Parameter Name="action" Type="string" />
                     <asp:Parameter Name="Remarks" Type="string" />
                     <asp:Parameter Name="Pictures" Type="string" />
                     <asp:Parameter Name="del" Type="string" />
                </UpdateParameters>
          
                <SelectParameters>
                    <asp:Parameter Name="incidenttype" Type="string" />
                   
                </SelectParameters>
            </asp:SqlDataSource>
                            
                   
                        </div>
                      </div>
                    </div>
                       </div> </div>
                </div>
                   <div id="divMsg" runat="server" />
               
                    <div class="vue-misc" id="divReport" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-auto" >
                               <div class="card" >
                              <div class="card-header">
                    <strong class="card-title">Safety Reports</strong>
                         <a href="safety.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>  Back</button></a>
                  </div>
                           <%-- <button type="button" class="btn btn-outline-primary">
                                            <i class="fa fa-star"></i>  Safety Documents</button>  --%>
                       <div id="divHead" runat="server"/>
                           <%--  <div class="form-group">--%>
                             
      <asp:GridView ID="gvDocStore" Font-Size="15px" ForeColor="Black"   CellPadding="2" CssClass="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning" runat="server" /><%-- table-earning--%>
                          
                          <%-- </div>--%>
                            <br /> <br />
                             <asp:Label ID="Label1" runat="server" Text=""></asp:Label> 
                   </div>
                        </div>
                      </div>
                    </div>
                       
                   <div class="vue-misc"  id="divIncidents" visible="false" runat="server">
                     <div class="card" >
                  <div class="card-header" >
                    <strong class="card-title"  id="divType" runat="server">Fatal & Major Incidents</strong>
                       <a href="safety.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>  Back</button></a>
                  </div>

                  <div class="card-body" >
                     <div class="vue-misc" >
                    
                      <div class="row">
                         <div class=" col-md-12">
                                               <asp:GridView ID="gvIncidents" class="table-responsive table-striped "  runat="server" EmptyDataText="No Records Available"></asp:GridView>
           </div>
                         
                      </div>
                    </div>
                       </div> </div>
                </div>
                     <div class="vue-misc"  id="divSummary" visible="false" runat="server">
                     <div class="card" >
                  <div class="card-header" >
                    <strong class="card-title"  id="Strong1" runat="server">Summery of Incidents & Trainings</strong>
                       <a href="safety.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>  Back</button></a>
                  </div>

                  <div class="card-body" >
                     <div class="vue-misc" >
                    
                      <div class="row">
                         <div class=" col-md-12">
                           <div id="divTotalIncident" runat="server" /> <br />
                                               <asp:GridView ID="gvSummary" class="table-responsive table-striped "  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                             <br />
                              <div id="divTotalTraining" runat="server" /> <br />
                                                                  <asp:GridView ID="gvSummaryTraining" class="table-responsive table-striped "  runat="server" EmptyDataText="No Records Available"></asp:GridView>
         
           </div>
                         
                      </div>
                    </div>
                       </div> </div>
                </div>
                     <div class="vue-misc"  id="divTraining" visible="false" runat="server">
                     <div class="card" >
                  <div class="card-header">
                    <strong class="card-title">Safety Training Details</strong>
                       <a href="safety.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>  Back</button></a>
                  </div>

                  <div class="card-body" >
                     <div class="vue-misc" >
                    
                      <div class="row">
                         <div class=" col-md-12">
                                               <asp:GridView ID="gvTraining" class="table-responsive table-striped "  runat="server" EmptyDataText="No Records Available"></asp:GridView>
           </div><div class=" col-md-auto">
                             <div class="form-group">
                               <div class="card-header">    <strong class="card-title">Training Recording</strong> </div>
                                  <label><b>Date of Training</b></label><br />
                                  <asp:TextBox ID="txtTrainingDt" runat="server" class="au-input au-input--full"  Width="100px"></asp:TextBox> 
                               <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd.MM.yyyy" TargetControlID="txtTrainingDt"  /> <br />
                          <label><b>Agency</b></label><br />
                                 <asp:TextBox ID="txtTrainingAgecy" runat="server" class="au-input au-input--full" ></asp:TextBox> <br />
                                   <label><b>Detail of Training</b></label><br />
                                 <asp:TextBox ID="txtTrainingDesc" runat="server" class="au-input au-input--full" ></asp:TextBox> <br />
                                  <label><b>Training Duration</b></label><br />
                                 <asp:TextBox ID="txtTrainigDuration" runat="server" class="au-input au-input--full" ></asp:TextBox> <br />
                                 
                                  <label><b>Persons Attended</b></label><br />
                                 <asp:TextBox ID="txtTrainingPersons" runat="server" class="au-input au-input--full" ></asp:TextBox> <br />
                                 
                                  <label><b>Total Training Man Hour</b></label><br />
                                 <asp:TextBox ID="txtTrainingHour" runat="server" class="au-input au-input--full" ></asp:TextBox> <br />
                                  <label><b>Participants Detail</b></label><br />
                                 <asp:TextBox ID="txtTrainingParticipants" runat="server" class="au-input au-input--full" ></asp:TextBox> <br />
                                <%--    <label><b>Remarks</b></label><br />
                                 <asp:TextBox ID="txtTrainingRemarks" runat="server" class="au-input au-input--full"  TextMode="MultiLine" Width="500px" Height="100px"></asp:TextBox> <br />
                                --%>
                                 <br /> 
                            
     <br />
      <asp:Button ID="btnTrainingsubmit" runat="server" Text="Submit"  class="au-btn au-btn--block au-btn--green m-b-20" /> 
                            </div>
                            <br /> <br />
                             <asp:Label ID="Label5" runat="server" Text=""></asp:Label> 
                   
                        </div>
                      </div>
                    </div>
                       </div> </div>
                </div>
              </div>
            </div>
          </div>
        </section>

      </div>
            <!-- END MAIN CONTENT-->
            <!-- END PAGE CONTAINER-->
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
   
       <script language='Javascript' type="text/javascript">
      function addFile() {
            var ni = document.getElementById("fileDiv");
            var objFileCount = document.getElementById("fileCount");
            var num = (document.getElementById("fileCount").value - 1) + 2;
            objFileCount.value = num;
            var newdiv = document.createElement("div");
            var divIdName = "file" + num + "Div";
            newdiv.setAttribute("id", divIdName);
            newdiv.innerHTML = '<input type="file" name="attachment" id="attachment"/><a href="#" onclick="javascript:removeFile(' + divIdName + ');">Remove </a>';
            ni.appendChild(newdiv);
      }

      function removeFile(divName) {
            var d = document.getElementById("fileDiv");
      d.removeChild(divName);
}
</script>
   <%-- Image    Slider--%>
     <script src="js/jssor.slider-27.4.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {

            var jssor_1_SlideshowTransitions = [
              {$Duration:800,x:0.3,$During:{$Left:[0.3,0.7]},$Easing:{$Left:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,x:-0.3,$SlideOut:true,$Easing:{$Left:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,x:-0.3,$During:{$Left:[0.3,0.7]},$Easing:{$Left:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,x:0.3,$SlideOut:true,$Easing:{$Left:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,y:0.3,$During:{$Top:[0.3,0.7]},$Easing:{$Top:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,y:-0.3,$SlideOut:true,$Easing:{$Top:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,y:-0.3,$During:{$Top:[0.3,0.7]},$Easing:{$Top:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,y:0.3,$SlideOut:true,$Easing:{$Top:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,x:0.3,$Cols:2,$During:{$Left:[0.3,0.7]},$ChessMode:{$Column:3},$Easing:{$Left:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,x:0.3,$Cols:2,$SlideOut:true,$ChessMode:{$Column:3},$Easing:{$Left:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,y:0.3,$Rows:2,$During:{$Top:[0.3,0.7]},$ChessMode:{$Row:12},$Easing:{$Top:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,y:0.3,$Rows:2,$SlideOut:true,$ChessMode:{$Row:12},$Easing:{$Top:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,y:0.3,$Cols:2,$During:{$Top:[0.3,0.7]},$ChessMode:{$Column:12},$Easing:{$Top:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,y:-0.3,$Cols:2,$SlideOut:true,$ChessMode:{$Column:12},$Easing:{$Top:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,x:0.3,$Rows:2,$During:{$Left:[0.3,0.7]},$ChessMode:{$Row:3},$Easing:{$Left:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,x:-0.3,$Rows:2,$SlideOut:true,$ChessMode:{$Row:3},$Easing:{$Left:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,x:0.3,y:0.3,$Cols:2,$Rows:2,$During:{$Left:[0.3,0.7],$Top:[0.3,0.7]},$ChessMode:{$Column:3,$Row:12},$Easing:{$Left:$Jease$.$InCubic,$Top:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,x:0.3,y:0.3,$Cols:2,$Rows:2,$During:{$Left:[0.3,0.7],$Top:[0.3,0.7]},$SlideOut:true,$ChessMode:{$Column:3,$Row:12},$Easing:{$Left:$Jease$.$InCubic,$Top:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,$Delay:20,$Clip:3,$Assembly:260,$Easing:{$Clip:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,$Delay:20,$Clip:3,$SlideOut:true,$Assembly:260,$Easing:{$Clip:$Jease$.$OutCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,$Delay:20,$Clip:12,$Assembly:260,$Easing:{$Clip:$Jease$.$InCubic,$Opacity:$Jease$.$Linear},$Opacity:2},
              {$Duration:800,$Delay:20,$Clip:12,$SlideOut:true,$Assembly:260,$Easing:{$Clip:$Jease$.$OutCubic,$Opacity:$Jease$.$Linear},$Opacity:2}
            ];

            var jssor_1_options = {
              $AutoPlay: 1,
              $SlideshowOptions: {
                $Class: $JssorSlideshowRunner$,
                $Transitions: jssor_1_SlideshowTransitions,
                $TransitionsOrder: 1
              },
              $ArrowNavigatorOptions: {
                $Class: $JssorArrowNavigator$
              },
              $ThumbnailNavigatorOptions: {
                $Class: $JssorThumbnailNavigator$,
                $SpacingX: 5,
                $SpacingY: 5
              }
            };

            var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

            /*#region responsive code begin*/

            var MAX_WIDTH = 980;

            function ScaleSlider() {
                var containerElement = jssor_1_slider.$Elmt.parentNode;
                var containerWidth = containerElement.clientWidth;

                if (containerWidth) {

                    var expectedWidth = Math.min(MAX_WIDTH || containerWidth, containerWidth);

                    jssor_1_slider.$ScaleWidth(expectedWidth);
                }
                else {
                    window.setTimeout(ScaleSlider, 30);
                }
            }

            ScaleSlider();

            $(window).bind("load", ScaleSlider);
            $(window).bind("resize", ScaleSlider);
            $(window).bind("orientationchange", ScaleSlider);
            /*#endregion responsive code end*/
        });
    </script>
    <style>
        /*jssor slider loading skin spin css*/
        .jssorl-009-spin img {
            animation-name: jssorl-009-spin;
            animation-duration: 8s;
            animation-iteration-count: infinite;
            animation-timing-function: linear;
        }

        @keyframes jssorl-009-spin {
            from { transform: rotate(0deg); }
            to { transform: rotate(360deg); }
        }

        /*jssor slider arrow skin 106 css*/
        .jssora106 {display:block;position:absolute;cursor:pointer;}
        .jssora106 .c {fill:#fff;opacity:.3;}
        .jssora106 .a {fill:none;stroke:#000;stroke-width:350;stroke-miterlimit:10;}
        .jssora106:hover .c {opacity:.5;}
        .jssora106:hover .a {opacity:.8;}
        .jssora106.jssora106dn .c {opacity:.2;}
        .jssora106.jssora106dn .a {opacity:1;}
        .jssora106.jssora106ds {opacity:.3;pointer-events:none;}

        /*jssor slider thumbnail skin 101 css*/
        .jssort101 .p {position: absolute;top:0;left:0;box-sizing:border-box;background:#000;}
        .jssort101 .p .cv {position:relative;top:0;left:0;width:100%;height:100%;border:2px solid #000;box-sizing:border-box;z-index:1;}
        .jssort101 .a {fill:none;stroke:#fff;stroke-width:400;stroke-miterlimit:10;visibility:hidden;}
        .jssort101 .p:hover .cv, .jssort101 .p.pdn .cv {border:none;border-color:transparent;}
        .jssort101 .p:hover{padding:2px;}
        .jssort101 .p:hover .cv {background-color:rgba(0,0,0,6);opacity:.35;}
        .jssort101 .p:hover.pdn{padding:0;}
        .jssort101 .p:hover.pdn .cv {border:2px solid #fff;background:none;opacity:.35;}
        .jssort101 .pav .cv {border-color:#fff;opacity:.35;}
        .jssort101 .pav .a, .jssort101 .p:hover .a {visibility:visible;}
        .jssort101 .t {position:absolute;top:0;left:0;width:100%;height:100%;border:none;opacity:.6;}
        .jssort101 .pav .t, .jssort101 .p:hover .t{opacity:1;}
    </style>
   <%-- slider image
    --%>
    <%--datatable--%>
     <link href="css/jquery.dataTables.min.css" rel="stylesheet" />
     <%--   <script src="vendor/jquery-3.2.1.min.js"></script>--%>
  <%--  for date time sorting--%>
      <script src="js/datatables/moment.min.js"></script>
    <script src="js/datatables/jquery.dataTables.min.js"></script>
    <script src="js/datatables/datetime-moment.js"></script>
  
    <%-- show hide columns 
    <script src="js/datatables/dataTables.buttons.min.js"></script>
    <script src="js/datatables/buttons.colVis.min.js"></script>
    <link href="js/datatables/buttons.dataTables.min.css" rel="stylesheet" />
  --Export button
    <script src="js/datatables/buttons.flash.min.js"></script>
    <script src="js/datatables/buttons.html5.min.js"></script>
    <script src="js/datatables/buttons.print.min.js"></script>
    <script src="js/datatables/jszip.min.js"></script>
    <script src="js/datatables/pdfmake.min.js"></script>
    <script src="js/datatables/vfs_fonts.js"></script>--%>
    <%--<script>
        $(document).ready(function () {
             $("#gvReport").prepend( $("<thead></thead>").append( $(this).find("tr:first") ) ).dataTable();
   $('#gvReport').DataTable();
} );
    </script>--%>
    <script type="text/javascript">

    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_endRequest(function () {
        createDataTable();
    });

    createDataTable();

        function createDataTable() {
          
             $.fn.dataTable.moment('DD.MM.YYYY');
            //$('#<%= gvDocStore.ClientID %>').DataTable();

            var groupColumn = 0;
            if ( $.fn.dataTable.isDataTable( '#<%= gvDocStore.ClientID %>' ) ) {
    table = $('#<%= gvDocStore.ClientID %>').DataTable();
}
            else {
                var table = $('#<%= gvDocStore.ClientID %>').DataTable({
                    "aaSorting": [ [0,'desc'] ],
                         responsive:true,
                    "columnDefs": [     { "width": "5%","targets": 1 },
                                     { "targets": [0,2,3,4,5,6,9], "visible": false, "searchable": true }
                    ],
                                 dom: 'Bfrtip',
                "displayLength": 50
                //"drawCallback": function (settings) {
                //    var api = this.api();
                //    var rows = api.rows({ page: 'current' }).nodes();
                //    var last = null;

                //    api.column(groupColumn, { page: 'current' }).data().each(function (group, i) {
                //        if (last !== group) {
                //            $(rows).eq(i).before(
                //                '<tr class="group"><td colspan="3">' + group + '</td></tr>'
                //            );

                //            last = group;
                //        }
                //    });
                //}
                });
                 
        }
    // Order by the grouping
    //$('#example tbody').on( 'click', 'tr.group', function () {
    //    var currentOrder = table.order()[0];
    //    if ( currentOrder[0] === groupColumn && currentOrder[1] === 'asc' ) {
    //        table.order( [ groupColumn, 'desc' ] ).draw();
    //    }
    //    else {
    //        table.order( [ groupColumn, 'asc' ] ).draw();
    //    }
    //} );



    }
</script>
     <!-- File download counter ajax call --> 
   <script  type="text/javascript">
       function fileCount(name) {
         //  alert('');
            $.ajax({
                type: "POST",
                url: "vinservice.asmx/updatefileCount",
                data: "{filename:'" + name + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                error: OnError
            });
       }
       function OnSuccess(data, status) {
        // alert(data.d);  //no need to display on success
           //  $x("#testcontainer").html(data.d);
         //  $("#divNotify").html('success ' + data.d);
       }
       function OnError(request, status, error) {
          // alert('error ' + request.statusText);
             $("#divMsg").html('error ' + request.statusText);
         }
        </script>
</body>
</html>
