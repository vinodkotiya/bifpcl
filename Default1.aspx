<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default1.aspx.vb" Inherits="_Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BIFPCL</title>
     <!-- webmail meta tags-->
    <meta name="google-site-verification" content="CVEaBcnPR9yeJUjbQhLkS67ZL_5k7Ohf1Rlk79gKetY" />
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
    <form id="form1" runat="server">
       <div class="page-wrapper">
        <!-- HEADER MOBILE-->
        <header class="header-mobile d-block d-lg-none">
            <div class="header-mobile__bar">
                <div class="container-fluid">
                    <div class="header-mobile-inner">
                        <a class="logo" href="index.html">
                            <img src="images/icon/logo5.png?1" alt="CoolAdmin" />
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
                    <img src="images/icon/logo5.png?1" alt="Cool Admin" />
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
                                <div class="overview-wrap">
                                    <h2 class="title-1">BIFPCL Overview</h2>
                                    <button class="au-btn au-btn-icon au-btn--blue">
                                      <%--  <i class="zmdi zmdi-plus"></i>--%>Dashboard</button>
                                </div>
                            </div>
                        </div>
                        <div class="row m-t-25">
                            <div class="col-sm-6 col-lg-3">
                                <div class="overview-item overview-item--c1">
                                 <a href="about.aspx?mode=contact">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-account-o"></i>
                                            </div>
                                            <div class="text">
                                                <h2>89</h2>
                                                <span>Manpower</span>
                                            </div>
                                        </div>
                                        <div class="overview-chart">
                                            <canvas id="widgetChart1"></canvas>
                                 
                                        </div>
                                    </div> </a>
                                </div>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <div class="overview-item overview-item--c2">
                                 <a href="dprMiles.aspx">     <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-flare"></i>
                                            </div>
                                            <div class="text">
                                                <h2>8</h2>
                                                <span>Milestones</span>
                                            </div>
                                        </div>
                                        <div class="overview-chart">
                                            <canvas id="widgetChart2"></canvas>
                                        </div>
                                    </div> </a>
                                </div>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <div class="overview-item overview-item--c3">
                                 <a href="dprm.aspx">     <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-calendar-note"></i>
                                            </div>
                                            <div class="text">
                                                <h2>1,086</h2>
                                                <span>DPR</span>
                                            </div>
                                        </div>
                                        <div class="overview-chart">
                                            <canvas id="widgetChart3"></canvas>
                                        </div>
                                    </div> </a>
                                </div>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <div class="overview-item overview-item--c4">
                                    <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-money"></i>
                                            </div>
                                            <div class="text">
                                                <h2>2,007</h2>
                                                <span>Capex(mUSD)</span>
                                            </div>
                                        </div>
                                        <div class="overview-chart">
                                            <canvas id="widgetChart4"></canvas>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="au-card recent-report">
                                    <div class="au-card-inner">
                                        <h3 class="title-2">Intro</h3>
                                       <%-- <div class="chart-info">
                                            <div class="chart-info__left">
                                                <div class="chart-note">
                                                    <span class="dot dot--blue"></span>
                                                    <span>products</span>
                                                </div>
                                                <div class="chart-note mr-0">
                                                    <span class="dot dot--green"></span>
                                                    <span>services</span>
                                                </div>
                                            </div>
                                            <div class="chart-info__right">
                                                <div class="chart-statis">
                                                    <span class="index incre">
                                                        <i class="zmdi zmdi-long-arrow-up"></i>25%</span>
                                                    <span class="label">products</span>
                                                </div>
                                                <div class="chart-statis mr-0">
                                                    <span class="index decre">
                                                        <i class="zmdi zmdi-long-arrow-down"></i>10%</span>
                                                    <span class="label">services</span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="recent-report__chart">
                                            <canvas id="recent-rep-chart"></canvas>
                                        </div>--%>
                                        <div  >
                                        <video autobuffer width="90%" height="90%"  loop="loop"  controls muted >
  <source src="upload/various/video/animation.mp4" type="video/mp4">

  Your browser does not support the video tag.autoplay="autoplay"
</video>
                                            </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="au-card chart-percent-card">
                                    <div class="au-card-inner">
                                        <h3 class="title-2 tm-b-5">Highlights</h3>
                                       <%-- <div class="row no-gutters">
                                            <div class="col-xl-6">
                                                <div class="chart-note-wrap">
                                                    <div class="chart-note mr-0 d-block">
                                                        <span class="dot dot--blue"></span>
                                                        <span>products</span>
                                                    </div>
                                                    <div class="chart-note mr-0 d-block">
                                                        <span class="dot dot--red"></span>
                                                        <span>services</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-xl-6">
                                                <div class="percent-chart">
                                                    <canvas id="percent-chart"></canvas>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <div class="panel panel-default">
<%--<div class="panel-heading"> <span class="glyphicon glyphicon-list-alt"></span><b>News</b></div>--%>
<div class="panel-body">
<div class="row">
<div class="col-xs-12">
<ul class="demo">

<li class="news-item">
<table cellpadding="4">
<tr>
<td> <i class="zmdi zmdi-flower-alt"></i>
 	Maitree STPP - First Lot of Boiler matetials unloading started at Mongla Port on 12-05-18</td>
</tr>
</table>
</li>

<li class="news-item">
<table cellpadding="4">
<tr>
<td><i class="zmdi zmdi-flower-alt"></i> Notice to Proceed to BHEL issued on 24.04.2017 (Project zero date).</td>
</tr>
</table>
</li>

<li class="news-item">
<table cellpadding="4">
<tr>
<td><i class="zmdi zmdi-flower-alt"></i> <b>Financing</b>: Sovereign Guarantee from GoB received. Financial closure achieved on 09.04.2017.</td>
</tr>
</table>
</li>
<li class="news-item">
<table cellpadding="4">
<tr>
<td><i class="zmdi zmdi-flower-alt"></i>	EIA for Coal Transportation study</td>
</tr>
</table>
</li>
...

</ul>
</div>
</div>
</div>
<div class="panel-footer"> </div>
</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="au-card au-card--no-shadow au-card--no-pad m-b-40">
                                    <div class="au-card-title" style="background-image:url('images/bg-title-01.jpg');">
                                        <div class="bg-overlay bg-overlay--blue"></div>
                                        <h3>
                                            <i class="zmdi zmdi-cloud-upload"></i>Latest Upload</h3>
                                        <button class="au-btn-plus">
                                            <i class="zmdi zmdi-plus"></i>
                                        </button>
                                    </div>
                                    <div class="au-task js-list-load">
                                        <%--<div class="au-task__title">
                                            <p>Tasks for John Doe</p>
                                        </div>--%>
                                        <div class="au-task-list js-scrollbar3">
                                            <div class="au-task__item au-task__item--danger">
                                                <div class="au-task__item-inner">
                                                    <h5 class="task">
                                                        <a href="#">Synopsis for the month May 2018</a>
                                                    </h5>
                                                    <span class="time">24.05.2018 10:00 AM</span>
                                                </div>
                                            </div>
                                            <div class="au-task__item au-task__item--warning">
                                                <div class="au-task__item-inner">
                                                   <h5 class="task">
                                                        <a href="#">Exception for the month May 2018</a>
                                                    </h5>
                                                    <span class="time">06.05.2018 10:00 AM</span>
                                                </div>
                                            </div>
                                            <div class="au-task__item au-task__item--primary">
                                                <div class="au-task__item-inner">
                                                    <h5 class="task">
                                                        <a href="#">Civil Front Report for the month May 2018</a>
                                                    </h5>
                                                    <span class="time">21.05.2018 10:00 AM</span>
                                                </div>
                                            </div>
                                            <div class="au-task__item au-task__item--success">
                                                <div class="au-task__item-inner">
                                                   <h5 class="task">
                                                        <a href="#">Some Circular</a>
                                                    </h5>
                                                    <span class="time">22.05.2018 10:00 AM</span>
                                                </div>
                                            </div>
                                           
                                        </div>
                                       <%-- <div class="au-task__footer">
                                            <button class="au-btn au-btn-load js-load-btn">load more</button>
                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="au-card au-card--no-shadow au-card--no-pad m-b-40">
                                    <div class="au-card-title" style="background-image:url('images/bg-title-02.jpg');">
                                        <div class="bg-overlay bg-overlay--blue"></div>
                                        <h3>
                                            <i class="fas fa-plus-square"></i>Safety Incident Reporting</h3>
                                        <button class="au-btn-plus">
                                            <i class="zmdi zmdi-plus"></i>
                                        </button>
                                    </div>
                                    <div class="au-inbox-wrap js-inbox-wrap">
                                        <div class="au-message js-list-load">
                                           <%-- <div class="au-message__noti">
                                                <p>You Have
                                                    <span>2</span>

                                                    new messages
                                                </p>
                                            </div>--%>
                                            <div class="au-message-list">
                                                <div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap">
                                                                <div class="avatar">
                                                                    <img src="images/icon/avatar-02.jpg" alt="John Smith">
                                                                </div>
                                                            </div>
                                                            <div class="text">
                                                                <h5 class="name">J Smith</h5>
                                                                <p>Have sent a photo from Boiler Area</p>
                                                            </div>
                                                        </div>
                                                        <div class="au-message__item-time">
                                                            <span>12 Min ago</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap online">
                                                                <div class="avatar">
                                                                    <img src="images/icon/avatar-03.jpg" alt="Nicholas Martinez">
                                                                </div>
                                                            </div>
                                                            <div class="text">
                                                                <h5 class="name">Nicholas Martinez</h5>
                                                                <p>has uploaded a report.</p>
                                                            </div>
                                                        </div>
                                                        <div class="au-message__item-time">
                                                            <span>11:00 PM</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="au-message__item">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap online">
                                                                <div class="avatar">
                                                                    <img src="images/icon/avatar-04.jpg" alt="Michelle Sims">
                                                                </div>
                                                            </div>
                                                            <div class="text">
                                                                <h5 class="name">Michelle Sims</h5>
                                                                <p>sent the message</p>
                                                            </div>
                                                        </div>
                                                        <div class="au-message__item-time">
                                                            <span>Yesterday</span>
                                                        </div>
                                                    </div>
                                                </div>
                                               
                                             
                                            </div>
                                         <%--   <div class="au-message__footer">
                                                <button class="au-btn au-btn-load js-load-btn">load more</button>
                                            </div>--%>
                                        </div>
                                      
                                    </div>
                                </div>
                            </div>
                        </div>
                           <div class="row">
                            <div class="col-lg-6">
                                <div class="au-card recent-report">
                                    <div class="au-card-inner">
                                        <h3 class="title-2">Gallery</h3>
                                       <%-- <div class="chart-info">
                                            <div class="chart-info__left">
                                                <div class="chart-note">
                                                    <span class="dot dot--blue"></span>
                                                    <span>products</span>
                                                </div>
                                                <div class="chart-note mr-0">
                                                    <span class="dot dot--green"></span>
                                                    <span>services</span>
                                                </div>
                                            </div>
                                            <div class="chart-info__right">
                                                <div class="chart-statis">
                                                    <span class="index incre">
                                                        <i class="zmdi zmdi-long-arrow-up"></i>25%</span>
                                                    <span class="label">products</span>
                                                </div>
                                                <div class="chart-statis mr-0">
                                                    <span class="index decre">
                                                        <i class="zmdi zmdi-long-arrow-down"></i>10%</span>
                                                    <span class="label">services</span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="recent-report__chart">
                                            <canvas id="recent-rep-chart"></canvas>
                                        </div>--%>
                                        <div style="max-height: 300px!important;" >
                                        <ul id="pictures-demo">
  <li title="Maitree STPP - First Lot of Boiler matetials -Unloading-Mongla- 12-05-18<a href='#link'></a>">
    <img src="images/slider/1.jpg" alt="demo1_1">
  </li>
  <li title="Maitree STPP - First Lot of Boiler matetials -Unloading-Mongla- 12-05-18">
    <img src="images/slider/2.jpg"   alt="demo1_2">
  </li>
  <li title="Maitree STPP - First Lot of Boiler matetials -Unloading-Mongla- 12-05-18">
    <img src="images/slider/3.jpg"   alt="demo1_3">
  </li>
  <li title="Maitree STPP - First Lot of Boiler matetials -Unloading-Mongla- 12-05-18">
    <img src="images/slider/4.jpg"   alt="demo1_4">
  </li>
</ul>
                                            </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="au-card chart-percent-card">
                                    <div class="au-card-inner">
                                        <h3 class="title-2 tm-b-5">Events</h3>
                                      
                                        <div class="panel panel-default">
<%--<div class="panel-heading"> <span class="glyphicon glyphicon-list-alt"></span><b>News</b></div>--%>
<div class="panel-body">
<div class="row">
<div class="col-xs-12">
<ul class="demo">

<li class="news-item">
<table cellpadding="4">
<tr>
<td> <i class="zmdi zmdi-flower-alt"></i>
 	Maitree STPP - First Lot of Boiler matetials unloading started at Mongla Port on 12-05-18</td>
</tr>
</table>
</li>

<li class="news-item">
<table cellpadding="4">
<tr>
<td><i class="zmdi zmdi-flower-alt"></i> Notice to Proceed to BHEL issued on 24.04.2017 (Project zero date).</td>
</tr>
</table>
</li>

<li class="news-item">
<table cellpadding="4">
<tr>
<td><i class="zmdi zmdi-flower-alt"></i> <b>Financing</b>: Sovereign Guarantee from GoB received. Financial closure achieved on 09.04.2017.</td>
</tr>
</table>
</li>
<li class="news-item">
<table cellpadding="4">
<tr>
<td><i class="zmdi zmdi-flower-alt"></i>	EIA for Coal Transportation study</td>
</tr>
</table>
</li>
...

</ul>
</div>
</div>
</div>
<div class="panel-footer"> </div>
</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                            <div class="row">
                            <div class="col-lg-9">
                                <h2 class="title-1 m-b-25">Latest News</h2>
                                <div class="table-responsive table--no-card m-b-40">
                                    <table class="table table-borderless table-striped table-earning">
                                        <thead>
                                            <tr>
                                                <th>Headlines</th>
                                               
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td> <a href="http://energybangla.com/bifpcl-providing-free-medical-services-at-rampal/" target="_blank" > BIFPCL Providing Free Medical Services At Rampal Oct 19, 2017 </a></td>
                                              </tr>
                                            <tr>
                                                <td><a href="http://www.newagebd.net/article/45384/govt-takes-mega-project-for-development-of-mongla-port" target="_blank" >Govt takes mega project for development of Mongla Port Jul 7, 2018</a></td>
                                               
                                            </tr>
                                            <tr>
                                                <td><a href="https://www.dailypioneer.com/columnists/oped/energy-cooperation-stabilising-region.html" target="_blank" >Energy cooperation stabilising region. Jan 25, 2018</td>
                                              
                                               
                                            </tr>
                                           
                                            
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <h2 class="title-1 m-b-25">IP Cameras</h2>
                                <div class="au-card au-card--bg-blue au-card-top-countries m-b-40">
                                    <div class="au-card-inner">
                                        <div class="table-responsive">
                                            <table class="table table-top-countries">
                                                <tbody>
                                                    <tr>
                                                        <td>Cam1</td>
                                                        <td class="text-right">Up</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Cam2</td>
                                                        <td class="text-right">Up</td>
                                                    </tr>
                                                   
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                            <div class="row m-t-25">
                                  <div class="col-sm-6 col-lg-3">
                                <div class="overview-item overview-item--c3">
                                  <a href="dpr.aspx" target="_blank" >   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-chart"></i>
                                            </div>
                                            <div class="text">
                                                <h4  style="    font-weight: 300;    color: #fff;    font-size: 18px;    line-height: 1;    margin-bottom: 5px;">DPR</h4>
                                                <span></span>
                                            </div>
                                        </div>
                                      
                                    </div> </a>
                                </div>
                            </div>
                                  <div class="col-sm-6 col-lg-3">
                                <div class="overview-item overview-item--c4">
                                  <a href="bifpcl.com/webmail" target="_blank" > <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-email"></i>
                                            </div>
                                            <div class="text">
                                                <h4  style="    font-weight: 300;    color: #fff;    font-size: 18px;    line-height: 1;    margin-bottom: 5px;"> Email</h4>
                                                <span></span>
                                            </div>
                                        </div>
                                       
                                    </div></a> 
                                </div>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <div class="overview-item overview-item--c1">
                                    <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-account-o"></i>
                                            </div>
                                            <div class="text">
                                                <h4  style="    font-weight: 300;    color: #fff;    font-size: 18px;    line-height: 1;    margin-bottom: 5px;">DocTracker</h4>
                                                <span></span>
                                            </div>
                                        </div>
                                       
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <div class="overview-item overview-item--c2">
                                    <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-shopping-basket"></i>
                                            </div>
                                            <div class="text">
                                                <h4 style="    font-weight: 300;    color: #fff;    font-size: 18px;    line-height: 1;    margin-bottom: 5px;">Assets</h4>
                                                <span></span>
                                            </div>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <div class="overview-item overview-item--c3">
                                    <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-mood"></i>
                                            </div>
                                            <div class="text">
                                                <h4  style="    font-weight: 300;    color: #fff;    font-size: 18px;    line-height: 1;    margin-bottom: 5px;">Leave</h4>
                                                <span></span>
                                            </div>
                                        </div>
                                      
                                    </div>
                                </div>
                            </div>
                          
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="copyright">
                                    <p>Copyright © 2018 BIFPCL. All rights reserved. AJAX | HTML5 | Cache Enabled | Page Rendering time.</p>
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
   <%-- Slideshow--%>
<script src="js/slippry.min.js"></script>
  <link href="css/slippry.css" rel="stylesheet" />
    <script type="text/javascript">
        jQuery('#pictures-demo').slippry({
            // general elements & wrapper
            slippryWrapper: '<div class="sy-box pictures-slider" />', // wrapper to wrap everything, including pager

            // options
            adaptiveHeight: false, // height of the sliders adapts to current slide
            captions: false, // Position: overlay, below, custom, false

            // pager
            pager: false,

            // controls
            controls: false,
            autoHover: false,

            // transitions
            transition: 'kenburns', // fade, horizontal, kenburns, false
            kenZoom: 140,
            speed: 2000 // time the transition takes (ms)
        });
    </script>
     <%-- Slideshow--%>
    <!-- Main JS-->
    <script src="js/main.js"></script>
    
     <%-- news--%>
    <script src="js/jquery.bootstrap.newsbox.min.js"></script>
        <script type="text/javascript">
$(function () {
$(".demo").bootstrapNews({
newsPerPage: 4,
navigation: true,
autoplay: true,
direction:'up', // up or down
animationSpeed: 'normal',
newsTickerInterval: 4000, //4 secs
pauseOnHover: true,
onStop: null,
onPause: null,
onReset: null,
onPrev: null,
onNext: null,
onToDo: null
});
});
</script>
    
</body>
</html>
