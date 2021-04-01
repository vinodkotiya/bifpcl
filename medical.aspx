<%@ Page Language="VB" AutoEventWireup="false" CodeFile="medical.aspx.vb" Inherits="_medical" %>

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
    <link href='favicon.ico' rel='icon' type='image/x-icon' />

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
<body>
    <div id="container">
        <div id="people"></div>
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="page-wrapper">
            <!-- HEADER DESKTOP-->
            <header class="header-desktop3 d-none d-lg-block" style="background: #5d57ea">
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
            <header class="header-mobile header-mobile-2 d-block d-lg-none" style="background: #5d57ea">
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
                        <div class="noti__item js-item-menu" style="margin-left: -100px;" id="divNotificationMobile" runat="server" />
                    </div>

                    <div class="account-wrap" id="divLoginMobile" runat="server">
                    </div>
                </div>
            </div>
            <!-- END HEADER MOBILE -->

            <!-- MAIN CONTENT-->
            <div class="page-content--bgf7">
                <!-- BREADCRUMB-->
                <section class="au-breadcrumb2" style="padding-top: 3px; padding-bottom: 0px;">
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
                                            <li class="list-inline-item">Medical</li>
                                        </ul>
                                    </div>
                                    <div class="rs-select2--dark rs-select2--sm rs-select2--dark2" style="width: 300px;">
                                        <select class="js-select2" name="type">
                                            <option selected="selected">Quick Links</option>
                                            <option value=""><a style="display: block" href="dpr.aspx">DPR Entry</a></option>
                                            <option value=""><a style="display: block" href="dprIssues.aspx">Manage Inputs</a></option>
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
                                <span>Medical</span>
                                    <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
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


                                <div class="card" id="divPics" visible="True" runat="server">
                                    <div class="card-header">
                                        <strong class="card-title">BIFPCL Medical App</strong>
                                    </div>

                                    <div class="card-body">
                                        <div class="card-header">
                                            <strong class="card-title">Medical Statistics</strong>
                                        </div>
                                        <div class="card-body">
                                            <div class="card border border-danger" id="div2" visible="True" runat="server">
                                                <asp:GridView ID="gvSummary" class="table-responsive table-striped " runat="server" EmptyDataText="No Records Available"></asp:GridView>
                                            </div>
                                        </div>
                                        <div class="card border border-success" id="divEmergency" visible="True" runat="server">
                                            <div class="card-header">
                                                <strong class="card-title">Emergency Contacts</strong>
                                            </div>
                                            <div class="card-body">
                                                <p class="card-text">
                                                    For all incidents and events leading to medical treatment following should be contacted as soon as possible.(Click to dial)
                                                </p>
                                                <ul>
                                                    <li>Ambulance MSTPP Site <a href="tel:+8801798751272" onclick="call('+8801798751272');"><i class='fa fa-mobile'></i>&nbsp;&nbsp;+8801798751272</a> </li>
                                                    <li>BIFPCL Doctors     <a href="tel:+8801678582868" onclick="call('+8801678582868');"><i class='fa fa-mobile'></i>&nbsp;&nbsp;+8801678582868</a> | <a href="tel:+8801678582899" onclick="call('+8801678582899');"><i class='fa fa-mobile'></i>&nbsp;&nbsp;+8801678582899</a> </li>
                                                    <li>Ambulance Addin Hospital <a href="tel:+8801713488421" onclick="call('+8801713488421');"><i class='fa fa-mobile'></i>&nbsp;&nbsp;+8801713488421</a> </li>
                                                    <li>Rampal Upazila Health Complex (Rampal,Bagerhat) <a href="tel:+8801730624576" onclick="call('+8801730624576');"><i class='fa fa-mobile'></i>&nbsp;&nbsp;+8801730624576</a> </li>
                                                    <li>Khulna Medical College Hospital (Khulna)     <a href="tel:+88041761509" onclick="call('+88041761509');"><i class='fa fa-mobile'></i>&nbsp;&nbsp;+88041761509</a> | <a href="tel:+880465756011" onclick="call('+880465756011');"><i class='fa fa-mobile'></i>&nbsp;&nbsp;+880465756011</a> </li>
                                                    <li>City Medical College Hospital (Khulna) <a href="tel:+8801999099099" onclick="call('+8801999099099');"><i class='fa fa-mobile'></i>&nbsp;&nbsp;+8801999099099</a> </li>
                                                    <li>AFC Fortis Hospital (Khulna) <a href="tel:+8801787668171" onclick="call('+8801787668171');"><i class='fa fa-mobile'></i>&nbsp;&nbsp;+8801787668171</a> </li>
                                                    <li>Gazi Medical College Hospital (Khulna) <a href="tel:+8801779197645" onclick="call('+8801779197645');"><i class='fa fa-mobile'></i>&nbsp;&nbsp;+8801779197645</a> </li>
                                                    <li>Mongla Port Hospital <a href="tel:+880466275261" onclick="call('+880466275261');"><i class='fa fa-mobile'></i>&nbsp;&nbsp;+880466275261</a> | <a href="tel:+8801707070149" onclick="call('+8801707070149');"><i class='fa fa-mobile'></i>&nbsp;&nbsp;+8801707070149</a> </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="vue-misc" id="divHome" visible="True" runat="server">

                                            <div class="row m-t-25">
                                                <div class="col-md-4 col-lg-4">
                                                    <div class="overview-item overview-item--c1">
                                                        <a href="medical.aspx?mode=entry">
                                                            <div class="overview__inner">
                                                                <div class="overview-box clearfix">
                                                                    <div class="icon">
                                                                        <i class="zmdi zmdi-alert-circle-o"></i>
                                                                    </div>
                                                                    <div class="text">
                                                                        <%--  <h2>89</h2>--%>
                                                                        <span>Enter Medical Records</span>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </a>
                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-lg-4">
                                                    <div class="overview-item overview-item--c2">
                                                        <a href="medical.aspx?mode=report">
                                                            <div class="overview__inner">
                                                                <div class="overview-box clearfix">
                                                                    <div class="icon">
                                                                        <i class="zmdi zmdi-hospital"></i>
                                                                    </div>
                                                                    <div class="text">
                                                                        <%--  <h2>89</h2>--%>
                                                                        <span>Medical Reports</span>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </a>
                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-lg-4">
                                                    <div class="overview-item overview-item--c1">
                                                        <a href="docstoreX.aspx?section=<%=HttpUtility.UrlEncode(dbOp.Encrypt("Medical")) %>&doctype=<%=HttpUtility.UrlEncode(dbOp.Encrypt("%")) %>">
                                                            <div class="overview__inner">
                                                                <div class="overview-box clearfix">
                                                                    <div class="icon">
                                                                        <i class="zmdi zmdi-library"></i>
                                                                    </div>
                                                                    <div class="text">
                                                                        <%--  <h2>89</h2>--%>
                                                                        <span>Medical Documents</span>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="vue-misc" id="div1" runat="server">

                                            <div class="row">
                                                <div class=" col-md-auto">
                                                    <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 980px; height: 880px; overflow: hidden; visibility: hidden;">
                                                        <!-- Loading Screen -->
                                                        <div data-u="loading" class="jssorl-009-spin" style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; text-align: center; background-color: rgba(0,0,0,0.7);">
                                                            <img style="margin-top: -19px; position: relative; top: 50%; width: 38px; height: 38px;" src="images/spin.svg" />
                                                        </div>
                                                        <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 980px; height: 780px; overflow: hidden;">
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/31.jpg?1" />
                                                                <img data-u="thumb" src="deptpics/medical/31.jpg?1" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/46.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/46.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/47.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/47.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/48.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/48.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/32.jpg?1" />
                                                                <img data-u="thumb" src="deptpics/medical/32.jpg?1" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/33.jpg?1" />
                                                                <img data-u="thumb" src="deptpics/medical/33.jpg?1" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/34.jpg?1" />
                                                                <img data-u="thumb" src="deptpics/medical/34.jpg?1" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/35.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/35.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/36.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/36.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/37.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/37.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/38.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/38.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/39.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/39.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/40.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/40.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/41.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/41.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/42.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/42.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/43.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/43.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/45.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/45.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/10.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/10.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/11.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/11.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/12.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/12.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/13.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/13.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/14.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/14.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/15.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/15.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/16.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/16.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/17.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/17.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/18.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/18.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/19.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/19.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/20.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/20.jpg" />
                                                            </div>
                                                            
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/22.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/22.jpg" />
                                                            </div>
                                                            
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/23.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/23.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/24.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/24.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/25.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/25.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/26.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/26.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/27.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/27.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/28.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/28.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/29.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/29.jpg" />
                                                            </div>
                                                            <div>
                                                                <img data-u="image" src="deptpics/medical/30.jpg" />
                                                                <img data-u="thumb" src="deptpics/medical/30.jpg" />
                                                            </div>
                                                        </div>

                                                        <%-- </div>--%>
                                                        <!-- Thumbnail Navigator -->
                                                        <div data-u="thumbnavigator" class="jssort101" style="position: absolute; left: 0px; bottom: 0px; width: 980px; height: 100px; background-color: #000;" data-autocenter="1" data-scale-bottom="0.75">
                                                            <div data-u="slides">
                                                                <div data-u="prototype" class="p" style="width: 190px; height: 90px;">
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
                                                        <div data-u="arrowleft" class="jssora106" style="width: 55px; height: 55px; top: 162px; left: 30px;" data-scale="0.75">
                                                            <svg viewbox="0 0 16000 16000" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;">
                                                                <circle class="c" cx="8000" cy="8000" r="6260.9"></circle>
                                                                <polyline class="a" points="7930.4,5495.7 5426.1,8000 7930.4,10504.3 "></polyline>
                                                                <line class="a" x1="10573.9" y1="8000" x2="5426.1" y2="8000"></line>
                                                            </svg>
                                                        </div>
                                                        <div data-u="arrowright" class="jssora106" style="width: 55px; height: 55px; top: 162px; right: 30px;" data-scale="0.75">
                                                            <svg viewbox="0 0 16000 16000" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;">
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



                                <div class="vue-misc" id="divIncidentRecording" visible="false" runat="server">
                                    <div class="card">
                                        <div class="card-header">
                                            <strong class="card-title">Medical Recording by Doctors</strong>
                                            <a href="medical.aspx">
                                                <button type="button" class="btn btn-link btn-sm">
                                                    <i class="fa fa-link"></i>&nbsp; Back</button></a>
                                        </div>

                                        <div class="card-body">
                                            <div class="vue-misc">

                                                <div class="row">
                                                    <div class=" col-md-auto">
                                                        <div class="form-group">
                                                            <div class="card-header">Note: Select the type of medical consultancy </div>
                                                            <label><b>Type</b></label><br />
                                                            <asp:RadioButtonList ID="rblIncedentType" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
                                                                <asp:ListItem Value="Regular Camp">Regular Camp</asp:ListItem>
                                                                <asp:ListItem Value="Daily OPD" Selected="true">Daily OPD</asp:ListItem>
                                                                <asp:ListItem Value="Monthly Camp">Monthly Camp</asp:ListItem>
                                                                <asp:ListItem Value="Boat Medical Camp">Boat Medical Camp</asp:ListItem>
                                                                <asp:ListItem Value="Labour Colony Camp">Labour Colony Camp</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            <label><b>Date</b></label><br />
                                                            <asp:TextBox ID="txtIncedentDate" runat="server" class="au-input au-input--full" Width="100px"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd.MM.yyyy" TargetControlID="txtIncedentDate" />
                                                            <br />

                                                            <label><b>No Of Patients</b></label><br />
                                                            <asp:TextBox ID="txtIncedentVictim" runat="server" TextMode="number" MaxLength="5" class="au-input au-input--full"></asp:TextBox>
                                                            <br />
                                                            <label><b>Remarks</b></label><br />
                                                            <asp:TextBox ID="txtIncedentRemark" runat="server" TextMode="multiline" Height="250" class="au-input au-input--full"></asp:TextBox>
                                                            <br />
                                                            <br />

                                                            <br />

                                                            <br />
                                                            <asp:Button ID="btnIncidentSubmit" runat="server" Text="Submit" class="au-btn au-btn--block au-btn--green m-b-20" />
                                                        </div>
                                                        <asp:Label ID="lblID" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        <br />


                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="vue-misc" id="divEditor" visible="false" runat="server">
                                    <div class="card">
                                        <div class="card-header">
                                            <strong class="card-title">Medical Record Update</strong>

                                        </div>

                                        <div class="card-body">
                                            <div class="vue-misc">
                                                <label><b>Type</b></label><br />
                                                <asp:RadioButtonList ID="rblEditorType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="3">
                                                    <asp:ListItem Value="Regular Camp">Regular Camp</asp:ListItem>
                                                                <asp:ListItem Value="Daily OPD" Selected="true">Daily OPD</asp:ListItem>
                                                                <asp:ListItem Value="Monthly Camp">Monthly Camp</asp:ListItem>
                                                                <asp:ListItem Value="Boat Medical Camp">Boat Medical Camp</asp:ListItem>
                                                                <asp:ListItem Value="Labour Colony Camp">Labour Colony Camp</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <div class="row" style="overflow-x: scroll; overflow-y: hidden;">
                                                    <div class=" col-md-auto">
                                                        <asp:GridView ID="gvDPRDetail" Width="100%" CssClass="table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
                                                            DataKeyNames="uid" EmptyDataText="No records has been added.">
                                                            <Columns>
                                                                <asp:CommandField ButtonType="Link" ShowEditButton="true" />
                                                                <asp:TemplateField HeaderText="Date" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRemark" Width="100" runat="server" Text='<%# Eval("mdate")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="tbRemark" Width="100" runat="server" Text='<%# Bind("mdate")%>' TextMode="MultiLine" BackColor="LightBlue" Font-Bold="false"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <%-- <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="true" />--%>

                                                                <asp:TemplateField HeaderText="Persons" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLocation" Width="100" runat="server" Text='<%# Eval("mpersons")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="tbLocation" Width="100" runat="server" Text='<%# Bind("mpersons")%>' BackColor="LightBlue" Font-Bold="false"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbldetail" Width="400" runat="server" Text='<%# Eval("remark")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="tbdetail" Width="300" Height="250" runat="server" Text='<%# Bind("remark")%>' TextMode="MultiLine" BackColor="LightBlue" Font-Bold="false"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDel" Width="50" runat="server" Text='<%# Eval("del")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:DropDownList ID="ddlDel" runat="server" SelectedValue='<%# Bind("del")%>'>
                                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
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
                                                            SelectCommand=" select uid, mdate, mpersons, remark, del  from medical where  mtype = @mtype   order by mdate desc "
                                                            UpdateCommand="replace  into medical (uid, mtype, mdate, mpersons, remark, del,last_updated, lastupdateby) values(@uid, @mtype, @mdate, @mpersons, @remark, @del,@last_updated, @lastupdateby) ">

                                                            <UpdateParameters>
                                                                <asp:Parameter Name="uid" Type="Int32" />
                                                                <asp:Parameter Name="mdate" Type="string" />
                                                                <asp:Parameter Name="mpersons" Type="string" />
                                                                <asp:Parameter Name="remark" Type="string" />
                                                                <asp:Parameter Name="del" Type="string" />
                                                                <asp:Parameter Name="lastupdateby" Type="string" />
                                                                <asp:Parameter Name="mtype" Type="string" />
                                                                <asp:Parameter Name="last_updated" Type="string" />
                                                            </UpdateParameters>

                                                            <SelectParameters>
                                                                <asp:Parameter Name="mtype" Type="string" />

                                                            </SelectParameters>
                                                        </asp:SqlDataSource>


                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="divMsg" runat="server" />

                                <div class="vue-misc" id="divReport" visible="false" runat="server">

                                    <div class="row">
                                        <div class="col-md-auto" style="max-width:1200px;">
                                            <div class="card" style="max-width:1200px;">
                                                <div class="card-header">
                                                    <strong class="card-title">Medical Reports</strong>
                                                    <a href="medical.aspx">
                                                        <button type="button" class="btn btn-link btn-sm">
                                                            <i class="fa fa-link"></i>&nbsp; Back</button></a>
                                                </div>
                                                <%-- <button type="button" class="btn btn-outline-primary">
                                            <i class="fa fa-star"></i>&nbsp; Safety Documents</button>  --%>
                                                <div id="divHead" runat="server" />
                                                <%--  <div class="form-group">--%>

                                                <asp:GridView ID="gvReport" Font-Size="15px" ForeColor="Black" CellPadding="2" CssClass="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning" runat="server" />
                                                <%-- table-earning--%>

                                                <%-- </div>--%>
                                                <br />
                                                <br />
                                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>

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


    <%-- Image    Slider--%>
    <script src="js/jssor.slider-27.4.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {

            var jssor_1_SlideshowTransitions = [
                { $Duration: 800, x: 0.3, $During: { $Left: [0.3, 0.7] }, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, x: -0.3, $SlideOut: true, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, x: -0.3, $During: { $Left: [0.3, 0.7] }, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, x: 0.3, $SlideOut: true, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, y: 0.3, $During: { $Top: [0.3, 0.7] }, $Easing: { $Top: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, y: -0.3, $SlideOut: true, $Easing: { $Top: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, y: -0.3, $During: { $Top: [0.3, 0.7] }, $Easing: { $Top: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, y: 0.3, $SlideOut: true, $Easing: { $Top: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, x: 0.3, $Cols: 2, $During: { $Left: [0.3, 0.7] }, $ChessMode: { $Column: 3 }, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, x: 0.3, $Cols: 2, $SlideOut: true, $ChessMode: { $Column: 3 }, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, y: 0.3, $Rows: 2, $During: { $Top: [0.3, 0.7] }, $ChessMode: { $Row: 12 }, $Easing: { $Top: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, y: 0.3, $Rows: 2, $SlideOut: true, $ChessMode: { $Row: 12 }, $Easing: { $Top: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, y: 0.3, $Cols: 2, $During: { $Top: [0.3, 0.7] }, $ChessMode: { $Column: 12 }, $Easing: { $Top: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, y: -0.3, $Cols: 2, $SlideOut: true, $ChessMode: { $Column: 12 }, $Easing: { $Top: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, x: 0.3, $Rows: 2, $During: { $Left: [0.3, 0.7] }, $ChessMode: { $Row: 3 }, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, x: -0.3, $Rows: 2, $SlideOut: true, $ChessMode: { $Row: 3 }, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, x: 0.3, y: 0.3, $Cols: 2, $Rows: 2, $During: { $Left: [0.3, 0.7], $Top: [0.3, 0.7] }, $ChessMode: { $Column: 3, $Row: 12 }, $Easing: { $Left: $Jease$.$InCubic, $Top: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, x: 0.3, y: 0.3, $Cols: 2, $Rows: 2, $During: { $Left: [0.3, 0.7], $Top: [0.3, 0.7] }, $SlideOut: true, $ChessMode: { $Column: 3, $Row: 12 }, $Easing: { $Left: $Jease$.$InCubic, $Top: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, $Delay: 20, $Clip: 3, $Assembly: 260, $Easing: { $Clip: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, $Delay: 20, $Clip: 3, $SlideOut: true, $Assembly: 260, $Easing: { $Clip: $Jease$.$OutCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, $Delay: 20, $Clip: 12, $Assembly: 260, $Easing: { $Clip: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
                { $Duration: 800, $Delay: 20, $Clip: 12, $SlideOut: true, $Assembly: 260, $Easing: { $Clip: $Jease$.$OutCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 }
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
            from {
                transform: rotate(0deg);
            }

            to {
                transform: rotate(360deg);
            }
        }

        /*jssor slider arrow skin 106 css*/
        .jssora106 {
            display: block;
            position: absolute;
            cursor: pointer;
        }

            .jssora106 .c {
                fill: #fff;
                opacity: .3;
            }

            .jssora106 .a {
                fill: none;
                stroke: #000;
                stroke-width: 350;
                stroke-miterlimit: 10;
            }

            .jssora106:hover .c {
                opacity: .5;
            }

            .jssora106:hover .a {
                opacity: .8;
            }

            .jssora106.jssora106dn .c {
                opacity: .2;
            }

            .jssora106.jssora106dn .a {
                opacity: 1;
            }

            .jssora106.jssora106ds {
                opacity: .3;
                pointer-events: none;
            }

        /*jssor slider thumbnail skin 101 css*/
        .jssort101 .p {
            position: absolute;
            top: 0;
            left: 0;
            box-sizing: border-box;
            background: #000;
        }

            .jssort101 .p .cv {
                position: relative;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                border: 2px solid #000;
                box-sizing: border-box;
                z-index: 1;
            }

        .jssort101 .a {
            fill: none;
            stroke: #fff;
            stroke-width: 400;
            stroke-miterlimit: 10;
            visibility: hidden;
        }

        .jssort101 .p:hover .cv, .jssort101 .p.pdn .cv {
            border: none;
            border-color: transparent;
        }

        .jssort101 .p:hover {
            padding: 2px;
        }

            .jssort101 .p:hover .cv {
                background-color: rgba(0,0,0,6);
                opacity: .35;
            }

            .jssort101 .p:hover.pdn {
                padding: 0;
            }

                .jssort101 .p:hover.pdn .cv {
                    border: 2px solid #fff;
                    background: none;
                    opacity: .35;
                }

        .jssort101 .pav .cv {
            border-color: #fff;
            opacity: .35;
        }

        .jssort101 .pav .a, .jssort101 .p:hover .a {
            visibility: visible;
        }

        .jssort101 .t {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            border: none;
            opacity: .6;
        }

        .jssort101 .pav .t, .jssort101 .p:hover .t {
            opacity: 1;
        }
    </style>
    <%-- slider image
    --%>
    <%--datatable--%>
    <link href="css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="vendor/jquery-3.2.1.min.js"></script>
    <script src="js/datatables/jquery.dataTables.min.js"></script>

    <%-- show hide columns --%>
    <script src="js/datatables/dataTables.buttons.min.js"></script>
    <script src="js/datatables/buttons.colVis.min.js"></script>
    <link href="js/datatables/buttons.dataTables.min.css" rel="stylesheet" />
    <%--Export button--%>
    <script src="js/datatables/buttons.flash.min.js"></script>
    <script src="js/datatables/buttons.html5.min.js"></script>
    <script src="js/datatables/buttons.print.min.js"></script>
    <script src="js/datatables/jszip.min.js"></script>
    <script src="js/datatables/pdfmake.min.js"></script>
    <script src="js/datatables/vfs_fonts.js"></script>
    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            createDataTable();
        });

        createDataTable();

        function createDataTable() {
            //$('#<%= gvReport.ClientID %>').DataTable();
            var agency = 'Medical Report';
            var groupColumn = 1;
            if ($.fn.dataTable.isDataTable( '#<%= gvReport.ClientID %>')) {
                table = $('#<%= gvReport.ClientID %>').DataTable();
            }
            else {
                var table = $('#<%= gvReport.ClientID %>').DataTable({
                    "scrollX": true,
                    dom: 'Bfrtip',
                    "columnDefs": [{ "targets": [0], "visible": false, "searchable": true }
                    ],
                    buttons: [
                        {
                            extend: 'print',
                            exportOptions: {
                                columns: ':visible',
                            },
                            customize: function (win) {
                                $(win.document.body)
                                    .css('font-size', '10pt')
                       <%-- .prepend(
                           'Work Area: ' + '#<%= ddlReportWorkArea.SelectedItem.ToString  %>' +   ' | Agency: ' + '#<%= ddlReportAgency.SelectedItem.ToString  %>'  + '<img src="images/icon/logo5.png" style="position:absolute; top:0; left:0;" />'
                        );--%>

                                $(win.document.body).find('table').addClass('display').css('font-size', '9px');
                                $(win.document.body).find('tr:nth-child(odd) td').each(function (index) {
                                    $(this).css('background-color', '#D0D0D0');
                                });
                                $(win.document.body).find('h1').css('text-align', 'center');
                            }
                        },
                        'copy',
                        {
                            extend: 'excelHtml5',
                            exportOptions: {
                                columns: ':visible',
                                stripHtml: false
                            },
                            title: function () { return 'Bangladesh-India Friendship Power Company(Pvt.) LTD (A JV of  BPDB & NTPC Ltd.)' + '\n'; },
                            messageTop: agency,
                            messageBottom: ' Generated from www.bifpcl.com'
                        },
                        {
                            extend: 'pdfHtml5',
                            exportOptions: {
                                columns: ':visible',
                                stripHtml: true
                            },
                            pageSize: 'A2',
                            title: function () { return 'Bangladesh-India Friendship Power Company(Pvt.) LTD (A JV of  BPDB & NTPC Ltd.)' + '\n'; },
                            customize: function (doc, config) {
                                doc.styles.title = {
                                    color: 'blue', fontSize: '16', background: 'white', alignment: 'center'
                                }
                                var tableNode;
                                for (i = 0; i < doc.content.length; ++i) {
                                    if (doc.content[i].table !== undefined) {
                                        tableNode = doc.content[i];
                                        break;
                                    }
                                }

                                var rowIndex = 0;
                                var tableColumnCount = tableNode.table.body[rowIndex].length;

                                if (tableColumnCount > 10) {
                                    doc.pageOrientation = 'landscape';
                                }
                                //      doc.content.splice(1, 0, {
                                ////           text: [
                                ////                 { text: 'I am loving dataTable and PdfMake \n',bold:true,fontSize:15 },
                                ////                 { text: 'You can control everything.',italics:true,fontSize:12 }
                                ////],
                                //  margin: [ 0, 0, 0, 5 ],
                                //  alignment: 'left',
                                //  image: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEAAAAA8CAMAAADhV0xWAAAABGdBTUEAALGOfPtRkwAAACBjSFJNAAB6JQAAgIMAAPn/AACA6QAAdTAAAOpgAAA6mAAAF2+SX8VGAAADAFBMVEUAAAAECQYFDwkLCwsJFw0VGhcNIRQQKxkWMB4qKio0NTUdSSshUTAofEQzekhERERLS0tFTFJHXU5OVFpUVFRUXldVWFpbW1tIf1hVa1pXe1xjY2NgamNra2tjdmlzc3NzenZ9d3J7e3tYdopefZZlfpMLmTsRnD8PoD8amUMao0YkgkMin0kwmlEipk0qqlM4qFs2sFw9rGA+smJFjVtEm15OjWJVimJYl2xKqGZKtmtSqW9XuHVhjW9kj3Bpmnd3h3t0lXxipnZiuXtewXtiwn1riodngph4hpN5moN6jqVquYB5qIZ4sohprtt5rM13tdtrxoV2xo17y5GEfXiIhXuQh3+Dg4ODhoqCjoaFioqPh4CPioaLi4uJjZCJm46Kk5iQiYSZkY2Tk5OWmZqclpGemJKbm5uKl6OLmKeJmq6Mn7WTnaWSn62Eo4uKqJOEuJKZqJyWtZ2ap6WauKKimpa9lpanoZujo6OhpqqlqauqpaKtqaWsrKygqbSjtqits7KvvbKzraq2sq2zs7OwuLK3uri5tLG9uLS7u7uEpMiMr8WUq8aWtMaVstObttSBvOGaveOgvt60v8uGxpaG0pmP1aGcxaWV1KSow6+rw7Oi3q+n3LO3xLq12Lus4ri0472Tx+mdwOenxtqtwtCqwdm/wsWzy9q5x9i8zNa5zdi80d2jxOigy+asyuuu1Ouyzu220e251ee80+y+3O+12fC/1vC73fK658PCiYnZi4vTlpbUnZ3dmJjOra3Du7jWp6fUs7PWvr7duLjtjIzmlpbwionmoJ/npaTupaXDw8PAxszHyszJxsPMyMXLy8vFzNPAztjKztLJ1crN09PK19/Vy8rT09PW19jV2dbU2NvY09PY2dbb29vC0uTO2OPE2fHJ3fLW3eLZ3eHC68ja4dzD4fPM5PXV5O3f4uTT4/TU6fbY5vXc6/fc7fjgycnj2trg4N7j4+Pn6Ofp4uHo6Obr6+vk6/Li7Pjl8vrq8/r17e3z8/P0+fz+/v4AAABGOYsjAAABAHRSTlP///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////8AU/cHJQAAAAlwSFlzAAALEgAACxIB0t1+/AAAABl0RVh0U29mdHdhcmUAcGFpbnQubmV0IDQuMC4yMfEgaZUAAAidSURBVFhHjZd/dBRXFce3x1YO64+suDpHtuviaFWoEmKgQOS0QqsJNmoBcfDUsSFjMlorTRpWBu0QmjyB5+/q5pAqgfgLpa31B1YRfyAVVB4k75RiHgVfhbaAUkvDDU4tTHa9b2Z2sxuCx/tHMrP77me+7947976NFf6XMUoIY9HNxHYlgEulFFICgAyMutEX421CAKMSuMMsW3ccXdOlbQsuBZ1QygQAIoVwbNPRLC1lmWnNgVTa1FMMBZFoSZldBsB1zLSTmpMyXIcIzhhIApalmSmDCHGZinEAF59iZZKuwXmwf4GmLoDyjJ00NVeIccGoBDBw7VTaMDEGwFyiVMv1X/70nWsZMjhNOq7hQKWIcgARQHSSJihaEAL50P75jYe/e/8X37/ukERmSrNA8mh9YGUAlA9SYwIAEZG3sh/97KePPPLw/V+9kwAIE4wMLw/mGIACmAncIzDiRa6hwVMnT/xyJ1K+9pntiMgwh0oaOZUB8Pk60TkIp9zd3/sYEv7+r7NnT544sXPnD+6SQNy07Y5pKAIQaug6A8Yi19Au/Pqz+Nd75ukX//M8Qk4+tY4B1w2biqKGIkBKWzckUBk6Fu3Cgd+GF1IeRjvy+NlvYojdhM1k5BgBuLA03QUyzj9/4fd7o6vQjl28eJACT1WZMspmCHCBaiYFWh78wEYqJQU3HDdqJdMQVlQAwLohugVUBKvKbaTys6MXR0dH85wDdU0pxgAMP6D4uvnRujGT2Wz5h8eeP/fSSxcvrpdgJFIQZEIBiOR6RoDr+VJWlkB+ePdvygH+g2eee+7cuX+sBZFkJIijAlCwkxTC6vOQUeYyvO9Ahaynf3769JkzZ3ZwcJJ6EEcFkLaZYFAqIN8HUYzm8O7fVe7r2PceffRXp3/RASKhcxUFBFBwDKRJT4LnFR+PQtSl3Dg+sd7jDz34w5985SBwYqkoIIBx20JIcYEQRSme6kGyUkFgozt+3AHU0nkIkDylM868Uvx8fPlRi7oc7Bo6Py6uynZ850tHVZvBMMYKDjgpF7iX91X/8fziE/H5kH9h/4FL+Pl4FX/9+of4M2bGwmKKFQgknDQQ/Ni3WhyHUOoSDoGL7z22b7/akefh49Qnofkv3nbbp550Mia2yFgBG43lBID8m5q7B0AOdGedPDYlzKf/wv6/KAXgozCV4ICLi7//wXoAy2BcAVgyLYCqb1Y2dw8OAwIG1B3m0+ddQ0KF0fewQBCDf5FkQf6hN2OTTDMRKkhju1bsbEvXoPz34J5s6QWQBPevhhM+3MdCxf9COhlcjW1bc0SgALUIKrF6RGvrvQMSBjdlS8k/TsRoeIX+IKQKstAShOGbAzirAgDVNUw31o2fbVkzIIf5xtbgTmka2v2HSyEgMtwDNTVOuCDYguwAQOwqnD0+PmNN9vMDUioF6s7DtO7d9+dKgDKS9vKMKRU8ADh2WrBAtJ29l5+XfE8zBzWOsJj++Kf9Q3jpEBxUpUqjGZn3GWOGFQJQAs5D9c3Klq6B4fNDm8aCOJTdc9yybM2qWqETjJIadJ6Ttv28i0MEExEADI2HdfDhlm7MwlB3lgfeaKJLeGZDfdJ6TVNHEwMPOCcGDj8ONnALCxgBHJIpOwDA7dmNg9Lj3dmgKpQJ97C3oqFes17bRFzU5VLHwZGfEcIGm1KccupdwEYPqg747dnugfMeFlJX5I8AASsartPM1zfd1YS6KFaGh4i8h11IYAEHADeVltu/5ec3Lm+dO+9vlwa617RG/nmOgI8HgAbyOQXwhcjbho51Da6u2iK+ztgNU6541btPZZfPnVnddgoBzUHAPcc2XMZNq14ztYa1NgY6mNmmafhMuhkTk6AAFKOow+K3Tp869R0zZ1avHtiUXRm8eoDDDhNqWg0pU6tf17Hd81wb51I6pUkXHFeXOBpURwKCJwNx/dunT58xs7p61qo92Y8s3Jz3iKkbukmJ8Ym3IKCJEBeThTUKtqk7mEQajDcE4B6UNb5txowZqAAJzcvnL5hmpNO6nkn2MVRw7eJrr1v7yQ15775TqIw4mEBlUVPFwYY28sT1CoD+NTVz5tTVTSEpTZ+26Nalje+5ozHXm3ufu556W/t39Xl57tmqUCEYbgqAElTH6ZweKqiprX1XXd38xqmvm7ZoydKly5Yty/X09ja23bN6y5b+Xbu2PtFH8TDigRccdQKAOkLByPBNgYLqmppZV79yTt2CBQtuWbJkCQJ6eno+MCXe9m30R8Czz269T63Hk1sJgNUII7ilGxSgpqZ2Vix21aTZi255bwjILZoSjyNg27ZtAaBdqlNcdFoLAXh8Qv8+PjvYQk3dVbFYzHqysa2xre+BXO6N6K4AW7YpBbvaSYtlYzoDzwigCI5lWe4Nyr+mFgEv46fAV+XgH/J0BciFCvrbhUindCfcQAmgBmwio0sxNwji1bFYQrBRH2c+IoSXiBRs69/SgeegjKHbGyLHIqDAzZSepiDvficqeDnugA3lfYEdUHjgk0hB/+bO4RHs+C4vnfNKgAJnmBy09fNm1U6KTVq86oFgLGK6Rg6RqgCw+Z5wSflhdQxQUKdqVQ+yY/YrYq/GNKrjrvSFd3duYTz+ht7eVRskXMBsqUZUsjKASqbKpps077hxPgJu7UOEhM5lPbmbsI5w9+prfEb5cbscEGYTEqaeOHqk6cZ5N9+8uLO9o3FpLte4sF3siR9X/mhlJ+VxgAJFETSuJTUpElIYH23vWN3e3vmFPkNLHgLNQOcRYGPnZGWVANUckmkWZ9BdBXxyMi7Na+JVksc5BojHqW6WHbNDGw8oFCwjmZCgm0AnG2wkm6CTJZ8spCkho9mX/3a7HBBuJMHBSuLJZ8M1CQvvDLNK/WSJFpTbRABEuNgj8AACFw7H1XsjLIu6lT91ijYxQBnOT3GE848dHBJCnaauYFcG/F9WKPwXyceB59vaAI8AAAAASUVORK5CYII='
                                //      });

                                //Remove the title created by datatTables
                                //doc.content.splice(0,1);
                                //Create a date string that we use in the footer. Format is dd-mm-yyyy
                                var now = new Date();
                                var jsDate = now.getDate() + '-' + (now.getMonth() + 1) + '-' + now.getFullYear();
                                // Logo converted to base64
                                // var logo = getBase64FromImageUrl('https://datatables.net/media/images/logo.png');
                                // The above call should work, but not when called from codepen.io
                                // So we use a online converter and paste the string in.
                                // Done on http://codebeautify.org/image-to-base64-converter
                                // It's a LONG string scroll down to see the rest of the code !!!
                                var logo = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEAAAAA8CAMAAADhV0xWAAAABGdBTUEAALGOfPtRkwAAACBjSFJNAAB6JQAAgIMAAPn/AACA6QAAdTAAAOpgAAA6mAAAF2+SX8VGAAADAFBMVEUAAAAECQYFDwkLCwsJFw0VGhcNIRQQKxkWMB4qKio0NTUdSSshUTAofEQzekhERERLS0tFTFJHXU5OVFpUVFRUXldVWFpbW1tIf1hVa1pXe1xjY2NgamNra2tjdmlzc3NzenZ9d3J7e3tYdopefZZlfpMLmTsRnD8PoD8amUMao0YkgkMin0kwmlEipk0qqlM4qFs2sFw9rGA+smJFjVtEm15OjWJVimJYl2xKqGZKtmtSqW9XuHVhjW9kj3Bpmnd3h3t0lXxipnZiuXtewXtiwn1riodngph4hpN5moN6jqVquYB5qIZ4sohprtt5rM13tdtrxoV2xo17y5GEfXiIhXuQh3+Dg4ODhoqCjoaFioqPh4CPioaLi4uJjZCJm46Kk5iQiYSZkY2Tk5OWmZqclpGemJKbm5uKl6OLmKeJmq6Mn7WTnaWSn62Eo4uKqJOEuJKZqJyWtZ2ap6WauKKimpa9lpanoZujo6OhpqqlqauqpaKtqaWsrKygqbSjtqits7KvvbKzraq2sq2zs7OwuLK3uri5tLG9uLS7u7uEpMiMr8WUq8aWtMaVstObttSBvOGaveOgvt60v8uGxpaG0pmP1aGcxaWV1KSow6+rw7Oi3q+n3LO3xLq12Lus4ri0472Tx+mdwOenxtqtwtCqwdm/wsWzy9q5x9i8zNa5zdi80d2jxOigy+asyuuu1Ouyzu220e251ee80+y+3O+12fC/1vC73fK658PCiYnZi4vTlpbUnZ3dmJjOra3Du7jWp6fUs7PWvr7duLjtjIzmlpbwionmoJ/npaTupaXDw8PAxszHyszJxsPMyMXLy8vFzNPAztjKztLJ1crN09PK19/Vy8rT09PW19jV2dbU2NvY09PY2dbb29vC0uTO2OPE2fHJ3fLW3eLZ3eHC68ja4dzD4fPM5PXV5O3f4uTT4/TU6fbY5vXc6/fc7fjgycnj2trg4N7j4+Pn6Ofp4uHo6Obr6+vk6/Li7Pjl8vrq8/r17e3z8/P0+fz+/v4AAABGOYsjAAABAHRSTlP///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////8AU/cHJQAAAAlwSFlzAAALEgAACxIB0t1+/AAAABl0RVh0U29mdHdhcmUAcGFpbnQubmV0IDQuMC4yMfEgaZUAAAidSURBVFhHjZd/dBRXFce3x1YO64+suDpHtuviaFWoEmKgQOS0QqsJNmoBcfDUsSFjMlorTRpWBu0QmjyB5+/q5pAqgfgLpa31B1YRfyAVVB4k75RiHgVfhbaAUkvDDU4tTHa9b2Z2sxuCx/tHMrP77me+7947976NFf6XMUoIY9HNxHYlgEulFFICgAyMutEX421CAKMSuMMsW3ccXdOlbQsuBZ1QygQAIoVwbNPRLC1lmWnNgVTa1FMMBZFoSZldBsB1zLSTmpMyXIcIzhhIApalmSmDCHGZinEAF59iZZKuwXmwf4GmLoDyjJ00NVeIccGoBDBw7VTaMDEGwFyiVMv1X/70nWsZMjhNOq7hQKWIcgARQHSSJihaEAL50P75jYe/e/8X37/ukERmSrNA8mh9YGUAlA9SYwIAEZG3sh/97KePPPLw/V+9kwAIE4wMLw/mGIACmAncIzDiRa6hwVMnT/xyJ1K+9pntiMgwh0oaOZUB8Pk60TkIp9zd3/sYEv7+r7NnT544sXPnD+6SQNy07Y5pKAIQaug6A8Yi19Au/Pqz+Nd75ukX//M8Qk4+tY4B1w2biqKGIkBKWzckUBk6Fu3Cgd+GF1IeRjvy+NlvYojdhM1k5BgBuLA03QUyzj9/4fd7o6vQjl28eJACT1WZMspmCHCBaiYFWh78wEYqJQU3HDdqJdMQVlQAwLohugVUBKvKbaTys6MXR0dH85wDdU0pxgAMP6D4uvnRujGT2Wz5h8eeP/fSSxcvrpdgJFIQZEIBiOR6RoDr+VJWlkB+ePdv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';
                                // A documentation reference can be found at
                                // https://github.com/bpampuch/pdfmake#getting-started
                                // Set page margins [left,top,right,bottom] or [horizontal,vertical]
                                // or one number for equal spread
                                // It's important to create enough space at the top for a header !!!
                                doc.pageMargins = [20, 60, 20, 30];
                                // Set the font size fot the entire document
                                doc.defaultStyle.fontSize = 12;
                                // Set the fontsize for the table header
                                doc.styles.tableHeader.fontSize = 13;
                                doc.styles.title.fontSize = 16;
                                // Create a header object with 3 columns
                                // Left side: Logo
                                // Middle: brandname
                                // Right side: A document title
                                var vintitle = 'Bangladesh-India Friendship Power Company(Pvt.) LTD (A JV of  BPDB & NTPC Ltd.)' + '\n';
                                var leave = document.getElementById("divLeaveType").innerHTML;

                                doc['header'] = (function () {
                                    return {
                                        columns: [
                                            {
                                                image: logo,
                                                width: 60,
                                                margin: [10, 0, 50, 10]
                                            },
                                            {
                                                alignment: 'left',
                                                italics: true,
                                                text: 'BIFPCL',
                                                fontSize: 18,
                                                margin: [10, 0]
                                            },
                                            //                          {
                                            //alignment: 'center',
                                            //italics: true,
                                            //text: vintitle,
                                            //                              fontSize: 12,
                                            //                              background: 'white',
                                            //                              margin: [100,0]
                                            //},
                                            {
                                                alignment: 'right',
                                                fontSize: 14,
                                                text: 'www.bifpcl.com'
                                            }
                                        ],
                                        margin: 20
                                    }
                                });
                                // Create a footer object with 2 columns
                                // Left side: report creation date
                                // Right side: current page and total pages
                                doc['footer'] = (function (page, pages) {
                                    return {
                                        columns: [
                                            {
                                                alignment: 'left',
                                                //  text: ['Note: System generated report. Created on: ', { text: jsDate.toString() }, { text: '\n \n \n \n Md. Oziur Rahman \n Dy. Manager, HR \n \n \n \n DGM(HR) \n \n \n DPD' }],  //,
                                                text: sign,
                                                fontSize: 14
                                            },
                                            {
                                                alignment: 'center',
                                                text: leave //['page ', { text: page.toString() },	' of ',	{ text: pages.toString() }]
                                            }
                                        ],
                                        margin: [100, -170]  //left , bottom
                                    }
                                });
                                // Change dataTable layout (Table styling)
                                // To use predefined layouts uncomment the line below and comment the custom lines below
                                // doc.content[0].layout = 'lightHorizontalLines'; // noBorders , headerLineOnly
                                var objLayout = {};
                                objLayout['hLineWidth'] = function (i) { return .5; };
                                objLayout['vLineWidth'] = function (i) { return .5; };
                                objLayout['hLineColor'] = function (i) { return '#aaa'; };
                                objLayout['vLineColor'] = function (i) { return '#aaa'; };
                                objLayout['paddingLeft'] = function (i) { return 4; };
                                objLayout['paddingRight'] = function (i) { return 4; };
                                doc.content[0].layout = objLayout;


                            }
                        }, 'colvis'
                    ],
                    "displayLength": 50,
                    "drawCallback": function (settings) {
                        var api = this.api();
                        var rows = api.rows({ page: 'current' }).nodes();
                        var last = null;

                        //api.column(groupColumn, { page: 'current' }).data().each(function (group, i) {
                        //    if (last !== group) {
                        //        $(rows).eq(i).before(
                        //            '<tr class="group"><td colspan="5">' + group + '</td></tr>'
                        //        );

                        //        last = group;
                        //    }
                        //});
                    }
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

        // Function to convert an img URL to data URL
        function getBase64FromImageUrl(url) {
            var img = new Image();
            img.crossOrigin = "anonymous";
            img.onload = function () {
                var canvas = document.createElement("canvas");
                canvas.width = this.width;
                canvas.height = this.height;
                var ctx = canvas.getContext("2d");
                ctx.drawImage(this, 0, 0);
                var dataURL = canvas.toDataURL("image/png");
                return dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
            };
            img.src = url;
        }
    </script>
</body>
</html>
