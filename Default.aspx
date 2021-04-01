<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- The above 4 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <!-- Title -->
     <title>BIFPCL</title>
    <meta name="description" content="BIFPCL Official Website" />
    <meta name="author" content="Vinod Kotiya" />
    <meta name="keywords" content="NTPC, NTPC Limited, BIFPCL, Rampal , Rampal Project, Maitree Super Thermal Power Project, Khulna, Bangladesh India Friendship Power Company Private Limited" />
    <link href='favicon.ico' rel='icon' type='image/x-icon'/>
 

    <!-- Favicon -->


    <!-- Core Stylesheet -->
    <link href="customHome/style.css" rel="stylesheet" />

    <!-- Responsive CSS -->
    <link href="customHome/css/responsive.css" rel="stylesheet" />

      <!-- Flying Bird Pure CSS with Divs-->
    <link href="customHome/css/flybird.css" rel="stylesheet" />

    <style>
        .navbar-nav li:hover > ul.dropdown-menu {
    display: block;
      margin-top: -20px;
     
      background-color:#6610f2;
}
.dropdown-submenu {
    position:relative;
   color:white!important;
}
.dropdown-submenu>.dropdown-menu {
    top:0;
    left:100%;
    margin-top:-6px;
    background-color:#6610f2;
}

/* rotate caret on hover */
.dropdown-menu > li > a:hover:after {
    text-decoration: underline;
    transform: rotate(-90deg);
    background-color:#6610f2;
} 

.corner-ribbon{
  width: 200px;
  /*background: #e43;*/
  position: absolute;
  /*top: 25px;
  left: -50px;
  text-align: center;
  line-height: 50px;
  letter-spacing: 1px;*/
  color: #f0f0f0;
  /*transform: rotate(-45deg);
  -webkit-transform: rotate(-45deg);*/
}

/* Custom styles */

.corner-ribbon.sticky{
  position: fixed;
}

.corner-ribbon.shadow{
  box-shadow: 0 0 3px rgba(0,0,0,.3);
}

/* Different positions */

.corner-ribbon.top-left{
  /*top: 25px;*/
  left: -70px;
  /*transform: rotate(-45deg);
  -webkit-transform: rotate(-45deg);*/
}

.corner-ribbon.top-right{
  top: 25px;
  right: -50px;
  left: auto;
  transform: rotate(45deg);
  -webkit-transform: rotate(45deg);
}

.corner-ribbon.bottom-left{
  top: auto;
  bottom: 25px;
  left: -50px;
  transform: rotate(45deg);
  -webkit-transform: rotate(45deg);
}

.corner-ribbon.bottom-right{
  top: auto;
  right: -50px;
  bottom: 25px;
  left: auto;
  transform: rotate(-45deg);
  -webkit-transform: rotate(-45deg);
}

/* Colors */

.corner-ribbon.white{background: #f0f0f0; color: #555;}
.corner-ribbon.black{background: #333;}
.corner-ribbon.grey{background: #999;}
.corner-ribbon.blue{background: #39d;}
.corner-ribbon.green{background: #2c7;}
.corner-ribbon.turquoise{background: #1b9;}
.corner-ribbon.purple{background: #95b;}
.corner-ribbon.red{background: #e43;}
.corner-ribbon.orange{background: #e82;}
.corner-ribbon.yellow{background: #ec0;}
    </style>
 
</head>
<body>
    <form id="form1" runat="server">
       <!-- Preloader Start -->
    <div id="preloader">
        <div class="colorlib-load"></div>
    </div>

    <!-- ***** Header Area Start ***** -->
    <header class="header_area animated">
        <div class="container-fluid">
            <div class="row align-items-center">
                <!-- Menu Area Start -->
                <div class="col-12 col-lg-10">
                    <div class="menu_area">
                        <nav class="navbar navbar-expand-lg navbar-light">
                            <!-- Logo -->
                            <a class="navbar-brand" href="#"> <img src="images/icon/logo6.png" alt="BIFPCL Logo" /></a>
                            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#ca-navbar" aria-controls="ca-navbar" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
                            <!-- Menu Area -->
                            <div class="collapse navbar-collapse" id="ca-navbar">
                                <ul class="navbar-nav ml-auto" id="nav">
                                    <li class="nav-item dropdown" ><a class="nav-link dropdown-toggle"  data-toggle="dropdown"  href="#">About</a>
                                        <ul class="dropdown-menu" >
                                             <li class="dropdown-item"><a href="about.aspx?mode=company" style="color:#f5f02f;">Company </a></li>
                                             <li class="dropdown-item"><a href="about.aspx?mode=board" style="color:#f5f02f;">Board </a></li>
                                             <li class="dropdown-item"><a href="#" style="color:#f5f02f;">Organogram</a></li>
                                             <li class="dropdown-item"><a href="about.aspx?mode=faq" style="color:#f5f02f;">FAQ</a></li>
                                                <li class="dropdown-item"><a href="docstoreX.aspx?section=<%=HttpUtility.UrlEncode(dbOp.Encrypt("PR")) %>&doctype=<%=HttpUtility.UrlEncode(dbOp.Encrypt("news")) %>" style="color:#f5f02f;">Media</a></li>
                                            <li class="dropdown-item"><a href="about.aspx?mode=contact" style="color:#f5f02f;">Contact</a></li>
                                        </ul>
                                    </li>
                                     <li class="nav-item dropdown" ><a class="nav-link dropdown-toggle"  data-toggle="dropdown"  href="#">Projects</a>
                                        <ul class="dropdown-menu" >
                                             <li class="dropdown-item"><a href="dashboardTS.aspx" style="color:#f5f02f;">Milestone </a></li>
                                             <li class="dropdown-item"><a href="dashboardTS.aspx" style="color:#f5f02f;">DPR Entry </a></li>
                                             <li class="dropdown-item"><a href="dashboardTS.aspx" style="color:#f5f02f;">DPR Reports</a></li>
                                             <li class="dropdown-item"><a href="dashboardTS.aspx" style="color:#f5f02f;">Critical Issues</a></li>
                                            <li class="dropdown-item"><a href="docstore.aspx" style="color:#f5f02f;">DocStore</a></li>
                                        </ul>
                                    </li>
                                     <li class="nav-item" ><a class="nav-link"   href="#apps">Apps</a>
                                    
                                    </li>
                                    <li class="nav-item"><a class="nav-link" href="erp.aspx">ERP</a></li>
                                      <li class="nav-item"><a class="nav-link" href="http://bifpcl.online/spinehrms/login.aspx" target="_blank">ESS</a></li>
                                    <li class="nav-item"><a class="nav-link" href="docstoreX.aspx?section=<%=HttpUtility.UrlEncode(dbOp.Encrypt("%")) %>&doctype=<%=HttpUtility.UrlEncode(dbOp.Encrypt("tender")) %>">Tenders</a></li>
                                    <li class="nav-item"><a class="nav-link" href="hrCareer.aspx">Careers</a></li>
                                  
                                    <li class="nav-item"><a class="nav-link" href="about.aspx?mode=contact">Contact</a></li>
                                </ul>
                                <div class="sing-up-button d-lg-none" id="divSignin" runat="server" >
                                   
                                </div>
                            </div>
                        </nav>
                    </div>
                </div>
                <!-- Signup btn -->
                <div class="col-12 col-lg-2">
                    <div class="sing-up-button d-none d-lg-block" id="divSignin1" runat="server">
                     </div>
                </div>
            </div>
        </div>
    </header>
    <!-- ***** Header Area End ***** -->

    <!-- ***** Wellcome Area Start ***** -->
    <section class="wellcome_area clearfix" id="home">
      
        <div class="container h-100" style="overflow:hidden;position: relative;">
            <%--  <div class="birdcontainer">--%>
              <div class="bird-container bird-container--one">
      <div class="bird bird--one"></div>
    </div>
    <div class="bird-container bird-container--two">
      <div class="bird bird--two"></div>
    </div>
    <div class="bird-container bird-container--three">
      <div class="bird bird--three"></div>
    </div>
    <div class="bird-container bird-container--four">
      <div class="bird bird--four"></div>
    </div> 
            <div class="row h-100 align-items-center">
                <div class="col-12 col-md">
                    <div class="wellcome-heading" style="margin-bottom: 200px;">
                        <h2>BIFPCL</h2>
                        <h3 style="    z-index: 0; pointer-events: none; ">⚡</h3>
                        <p>Bangladesh India Friendship Power Company (P) Ltd</p>
                        <div class="get-start-area">
                        <!-- Form Start -->
                      <%--  <form action="#" method="post" class="form-inline">
                            <input type="email" class="form-control email" placeholder="name@company.com">
                      --%>    <a  href="about.aspx?mode=company" style="z-index:1000;" onclick="window.location.href='about.aspx?mode=company'"  class="submit" >About</a> 
<br/> <br/>
                               <div id="snackbar">
                                   <div class="corner-ribbon top-left"> <img src="images/new.png" style="height:50px;margin-top: -18px;margin-left: -20px;" /></div>
                                   
                                    <div class="typewriter1">
                                        <%-- Bid submission date has been extended up to 18.12.2019 for <br /> Coal Transportation including Transhipment for 2x660MW Maitree STPP <br /> --%>
                                                                            
Shortlisted candidates can Download Admit cards for the  <br />Viva Voce for the post of Assistant Manager (Chemistry)   <br />and Lab Analyst (Chemistry).
  <a  href="https://www.bifpcl.com/hrCareer.aspx?mode=printadmitInt" style="color: yellow;">Click here !</a>
                                   </div>
                                   </div>
                              <div id="snackbar1">
                               <table> <tr><td>  <img src="images/mujib100.png" style="width:150px;height:120px;"  /> </td><%--<td><div class="countdownwrap"></div></td>--%> 
                                </tr> <tr style="font-size:11px;"><td style="padding-left:0px">     <b>Mujib Year Focal Point</b> <br />     Anwarul Azim, DGM(HR-PR) <br />     01678582841 / azim@bifpcl.com</td></tr></table>
                                   </div>

<br/> <br/> 
                       <%-- </form>--%>
                        <!-- Form End -->
                    </div>
                    </div>
                    
                </div>
            </div>
                 <%-- </div>--%>
        </div>
        <!-- Welcome thumb -->
        <div class="welcome-thumb wow fadeInDown" style="bottom:200px" data-wow-delay="0.5s">
            <img src="customHome/img/bg-img/welcome-img2.png?2" alt="">
        </div>
    </section>
    <!-- ***** Wellcome Area End ***** -->

    <!-- ***** Special Area Start ***** -->
    <section class="special-area bg-white section_padding_100" id="about">
   <!-- ***** Garbage Section ***** -->
  <!-- <div class="row">
                <div class="col-12 col-md-4">
                    <img src=images/mourn.jpg />
                </div>
                  <div class="col-12 col-md-4">
              <img src=images/mourn1.jpeg  style='width:90%; height:50%' />
                </div>
            </div> -->

    <!-- ***** Garbage Area End ***** -->
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <!-- Section Heading Area -->
                    <div class="section-heading text-center">
                        <h2>Maitree Super Thermal Power Project (2X660 MW)</h2>
                        <div class="line-shape"></div>
                    </div>
                </div>
            </div>

            <div class="row">
                <!-- Single Special Area -->
                <div class="col-12 col-md-4">
                    <div class="single-special text-center wow fadeInUp" data-wow-delay="0.2s">
                        <div class="single-icon">
                            <i class="ti-medall" aria-hidden="true"></i>
                        </div>
                        <h4>Beneficiaries</h4>
                        <p>	100% of Generated Power to BPDB of Bangladesh</p>
                    </div>
                </div>
                <!-- Single Special Area -->
                <div class="col-12 col-md-4">
                    <div class="single-special text-center wow fadeInUp" data-wow-delay="0.4s">
                        <div class="single-icon">
                            <i class="ti-money" aria-hidden="true"></i>
                        </div>
                        <h4>Fund</h4>
                        <p>Financing of Main Plant EPC (Turnkey) Package by Indian EXIM Bank</p>
                    </div>
                </div>
                <!-- Single Special Area -->
                <div class="col-12 col-md-4">
                    <div class="single-special text-center wow fadeInUp" data-wow-delay="0.6s">
                        <div class="single-icon">
                            <i class="ti-time" aria-hidden="true"></i>
                        </div>
                        <h4>Schedule</h4>
                        <p>Project is in fast track with completion schedule in 2021</p>
                    </div>
                </div>
            </div>
        </div>
         <!-- ***** Video Area Start ***** -->
    <div class="video-section">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <!-- Video Area Start -->
                    <div class="video-area" style="background-image: url(customHome/img/bg-img/video.jpg);">
                        <div class="video-play-btn">
                            <a href="https://www.youtube.com/watch?v=Iuh0B4n4tE0" class="video_btn"><i class="fa fa-play" aria-hidden="true"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ***** Video Area End ***** -->

    <!-- ***** Cool Facts Area Start ***** -->
    <section class="cool_facts_area clearfix">
        <div class="container">
            <div class="row">
                <!-- Single Cool Fact-->
                <div class="col-12 col-md-3 col-lg-3">
                    <div class="single-cool-fact d-flex justify-content-center wow fadeInUp" data-wow-delay="0.2s">
                        <div class="counter-area">
                            <h3><span class="counter">2</span></h3>
                        </div>
                        <div class="cool-facts-content">
                            <i class="ti-money"></i>
                            <p>CAPEX(bUSD)</p>
                        </div>
                    </div>
                </div>
                <!-- Single Cool Fact-->
                <div class="col-12 col-md-3 col-lg-3">
                    <div class="single-cool-fact d-flex justify-content-center wow fadeInUp" data-wow-delay="0.4s">
                        <div class="counter-area">
                            <h3><span class="counter">13</span></h3>
                        </div>
                        <div class="cool-facts-content">
                            <i class="ti-bar-chart"></i>
                            <p>Milestones</p>
                        </div>
                    </div>
                </div>
                <!-- Single Cool Fact-->
                <div class="col-12 col-md-3 col-lg-3">
                    <div class="single-cool-fact d-flex justify-content-center wow fadeInUp" data-wow-delay="0.6s">
                        <div class="counter-area">
                            <h3><span class="counter" id="divManpower" runat="server">89</span></h3>
                        </div>
                        <div class="cool-facts-content">
                            <i class="ion-person"></i>
                            <p>Manpower</p>
                        </div>
                    </div>
                </div>
                <!-- Single Cool Fact-->
                <div class="col-12 col-md-3 col-lg-3">
                    <div class="single-cool-fact d-flex justify-content-center wow fadeInUp" data-wow-delay="0.8s">
                        <div class="counter-area">
                            <h3><span class="counter">2</span></h3>
                        </div>
                        <div class="cool-facts-content">
                            <i class="ion-ios-star-outline"></i>
                            <p>Units of 660MW</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- ***** Cool Facts Area End ***** -->
        <!-- ***** Awesome Features Start ***** -->
    <section class="awesome-feature-area bg-white section_padding_0_50 clearfix" id="features">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <!-- Heading Text -->
                    <div class="section-heading text-center">
                        <h2>Highlights</h2>
                        <div class="line-shape"></div>
                    </div>
                </div>
            </div>

            <div class="row" id="divHighLights" runat="server">
              
            </div>

        </div>
    </section>
    <!-- ***** Awesome Features End ***** -->
         <!-- ***** Video Area Start ***** -->
    <div class="video-section">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <!-- Video Area Start -->
                    <div class="video-area" style="background-image: url(customHome/img/bg-img/video_february.png);">
                        <div class="video-play-btn">
                            <a href="https://www.youtube.com/watch?v=Cg3VozxZpsg" class="video_btn"><i class="fa fa-play" aria-hidden="true"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- ***** Video Area End ***** -->
          <!-- ***** App Screenshots Area Start ***** -->
    <section class="app-screenshots-area bg-white section_padding_0_100 clearfix" id="screenshot">
        <div class="container">
            <div class="row">

                <div class="col-12 text-center">
                    <!-- Heading Text  -->
                    <div class="section-heading">
                        <h2>Gallery</h2>
                        <div class="line-shape"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <!-- App Screenshots Slides  -->
                    <div id="divSlide" runat="server" class="app_screenshots_slides owl-carousel">
                     
                      
                    </div>

                    
                </div>
            </div>
                <div class="text-center">
                      Animation: <a href="kachr.aspx" target="_blank" >Bizli Animated Series 10 Episodes</a>
                    <%--        | <a href="https://youtu.be/fEp2NTTbVv8" target="_blank" >Power & Energy Week-2018</a>
                            |<a href="https://youtu.be/ZzCV4PYELOc" target="_blank" >Power Week 2018</a>
                            | <a href="https://youtu.be/OiFj3lu3lII" target="_blank" >অর্থ বছরের উন্নয়ন কর্মকান্ড</a>--%>
                    </div>
           
        </div>
    </section>
    <!-- ***** App Screenshots Area End *****====== -->

     

    

     <a name="apps"></a> 
  
    <!-- ***** Pricing Plane Area Start *****==== -->
    <section class="pricing-plane-area section_padding_100_70 clearfix" id="pricing">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <!-- Heading Text  -->
                    <div class="section-heading text-center">
                        <h2>Apps</h2>
                        <div class="line-shape"></div>
                    </div>
                </div>
            </div>

            <div class="row no-gutters">
                <div class="col-12 col-md-6 col-lg-3">
                    <!-- Package Price  -->
                    <div class="single-price-plan active text-center">
                        <!-- Package Text  -->
                        <div class="package-plan">
                            <h5>Important Links</h5>
                           
                        </div>
                        <div class="package-description">
                            <p><a href="http://www.ntpc.co.in" target="_blank">NTPC Limited</a> </p>
                            <p><a href="http://www.bpdb.gov.bd/" target="_blank">BPDB</a> </p>
                             <p><a href="http://www.powerdivision.gov.bd/" target="_blank">Power Division</a> </p>
                            <p><a href="http://mail.google.com" target="_blank">BIFPCL Mail</a> </p>
                             <p><a href="http://www.bifpcl.net" target="_blank">BIFPCL Mirror Website</a> </p>
                              <p><a href="SA/quiz/index.html" target="_blank">Quiz:Know MSTPP</a> </p>
                        </div>
                        <!-- Plan Button  -->
                        <div class="plan-button">
                         <a href="#" target="_blank" >!</a>
                          </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-3">
                    <!-- Package Price  -->
                    <div class="single-price-plan text-center">
                        <!-- Package Text  -->
                        <div class="package-plan" style="    background-color: #f790c9;">
                            <h5>Services</h5>
                            
                        </div>
                        <div class="package-description">
                            <p><a href ='hrBiometric.aspx'>HR Services</a></p>
                            <p><a href='docStore.aspx?section=SSnQBM6RIBdkwFPoIhMimA%3d%3d&doctype=3H88q%2be3xP6p0jxaeyCpRw%3d%3d'>Payment Details</a></p>
                            <p><a href='eLearning.aspx'>e-Learning</a></p>
                                                          <p><a href='safety.aspx'>Safety</a> &nbsp;|&nbsp; <a href='medical.aspx'>Medical</a></p>
                            <p><a href ='bookres.aspx'>Conference Booking</a></p>
                            <p><a href ='ocms.aspx'>Online Complaint</a></p>
                        </div>
                        <!-- Plan Button  -->
                        <div class="plan-button"  >
                            <a href="vehicle.aspx"  style="    background-color: #f790c9;">Vehicle Booking</a>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-3">
                    <!-- Package Price  -->
                    <div class="single-price-plan active text-center">
                        <!-- Package Text  -->
                        <div class="package-plan">
                            <h5>Projects</h5>
                           
                        </div>
                        <div class="package-description">
                            <p> <a href ='dashboardTS.aspx'>Milestone</a></p>
                            <p> <a href='dashboardTS.aspx'>Daily Progress</a> | <a href='dashboardTS.aspx'>Critical Issues</a></p>
                            <p><a href='doctracker.aspx'>Doc Tracker</a></p>
                            <p> <a href ='docStore.aspx'>DocStore</a></p>
                             <p><a href='gatepass.aspx'>QR Gate Pass System</a></p>
                            <p><a href='http://mstpp.online:377773'>IP Camera mstpp.online</a></p>
                        </div>
                        <!-- Plan Button  -->
                        <div class="plan-button">
                            <a href="engineeringdrawing.aspx">Engineering Drawing</a>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-3">
                    <!-- Package Price  -->
                    <div class="single-price-plan text-center">
                        <!-- Package Text  -->
                        <div class="package-plan"  style="    background-color: #f790c9;">
                            <h5>Reports</h5>
                            
                        </div>
                        <div class="package-description">
                            <p><a href ="docstoreX.aspx?section=<%=HttpUtility.UrlEncode(dbOp.Encrypt("EMG")) %>&doctype=<%=HttpUtility.UrlEncode(dbOp.Encrypt("quarter")) %>">Quarterly Monitoring</a></p>
                            <p><a href="docstoreX.aspx?section=<%=HttpUtility.UrlEncode(dbOp.Encrypt("common")) %>&doctype=<%=HttpUtility.UrlEncode(dbOp.Encrypt("annual")) %>">Annual Report</a></p>
                            <p> <a href ='docstoreX.aspx?section=<%=HttpUtility.UrlEncode(dbOp.Encrypt("EMG")) %>&doctype=<%=HttpUtility.UrlEncode(dbOp.Encrypt("eia")) %>'>EIA/Coal Reports</a></p>
                            <p><a href ='docstoreX.aspx?section=<%=HttpUtility.UrlEncode(dbOp.Encrypt("EMG")) %>&doctype=<%=HttpUtility.UrlEncode(dbOp.Encrypt("month")) %>'>Monthly Env Compliance</a></p>
                            <p> <a href ='docstoreX.aspx?section=<%=HttpUtility.UrlEncode(dbOp.Encrypt("hr")) %>&doctype=<%=HttpUtility.UrlEncode(dbOp.Encrypt("noc")) %>'>NOC</a></p>
                              <p> <a href ='medical.aspx'>Medical CSR</a></p>
                        </div>
                        <!-- Plan Button  -->
                        <div class="plan-button" >
                            <a href="#"  style="    background-color: #f790c9;">Employee Section</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- ***** Pricing Plane Area End ***** -->

    <!-- ***** Client Feedback Area Start ***** -->
    <section class="clients-feedback-area bg-white section_padding_100 clearfix" id="testimonials">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-12 col-md-10">
                      <!-- Section Heading Area -->
                    <div class="section-heading text-center">
                        <h2>Our Team</h2>
                        <div class="line-shape"></div>
                    </div>
                    <div class="slider slider-for" id="divName" runat="server">
                        <!-- Client Feedback Text  -->
                       <%-- <div class="client-feedback-text text-center">
                            <div class="client-name text-center">
                                <h5>Vinod Kotiya</h5>
                                <p>Sr Manager</p>
                            </div>
                        </div>--%>
                   
                    </div>
                </div>
                <!-- Client Thumbnail Area -->
                <div class="col-12 col-md-6 col-lg-5">
                    <div class="slider slider-nav"  id="divPic" runat="server">
                        <%--<div class="client-thumbnail">
                            <img src="upload/employee/pics/284.jpg" alt="" />
                        </div>--%>
                       
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- ***** Client Feedback Area End ***** -->

    <!-- ***** CTA Area Start ***** -->
    <section class="our-monthly-membership section_padding_50 clearfix">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-md-8">
                    <div class="membership-description">
                        <h2>Employee Corner</h2>
                        <p>Use Single Sign On to access restricted feature of website..</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="get-started-button wow bounceInDown" data-wow-delay="0.5s">
                        <a href="sso/Default.aspx?appid=12343272">Login</a>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- ***** CTA Area End ***** -->

  
    <!-- ***** Our Team Area End ***** -->
           <!-- Special Description Area -->
        <div class="special_description_area mt-150">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="special_description_img">
                            <img src="customHome/img/bg-img/special.png?1" alt="">
                        </div>
                    </div>
                    <div class="col-lg-6 col-xl-5 ml-xl-auto">
                        <div class="special_description_content">
                            <h2>Get BIFPCL on Mobile</h2>
                            <p>Download the mobile app of BIFPCL to quickly access on your Android or iPhone Devices.</p>
                            <div class="app-download-area">
                                <div class="app-download-btn wow fadeInUp" data-wow-delay="0.2s">
                                    <!-- Google Store Btn -->
                                    <a href="https://play.google.com/store/apps/details?id=appinventor.ai_vinodkotiya.BIFPCL" target="_blank">
                                        <i class="fa fa-android"></i>
                                        <p class="mb-0"><span>available on</span> Google Store</p>
                                    </a>
                                </div>
                                <div class="app-download-btn wow fadeInDown" data-wow-delay="0.4s">
                                    <!-- Apple Store Btn -->
                                    <a href="#">
                                        <i class="fa fa-apple"></i>
                                        <p class="mb-0"><span>available on</span> Apple Store</p>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- ***** Special Area End ***** -->
    <!-- ***** Contact Us Area Start ***** -->
    <section class="footer-contact-area section_padding_100 clearfix" id="contact">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <!-- Heading Text  -->
                    <div class="section-heading"  style="margin-bottom: 0px;">
                        <h2>Get in touch with us!</h2>
                        <div class="line-shape"></div>
                    </div>
                    <div class="footer-text">
                        <p  style="margin-bottom: 0px;">You can contact us in following ways: </p>
                    </div>
                    <b>Bangladesh-India Friendship Power Company (Pvt.) Ltd.</b>
                    <div class="address-text">
                        <p><span>Address:</span>Level-17,Borak Unique Heights,                          Kazi Nazrul Islam Avenue,Eskaton,                                        Dhaka,1217</p>
                    </div>
                    <div class="phone-text">
                        <p><span>Phone:</span> <%--+02-8321607--%>(+88)029341805  <span>Email:</span> admin@bifpcl.com</p>
                    </div>
                   
                    <b>Maitree Super Thermal Power Project (2X660 MW)</b>
                    <div class="address-text">
                        <p><span>Address:</span>‎Sapmari, Rampal Upazila of Bagerhat , Khulna Division, Bangladesh</p>
                    </div>
                    <div class="phone-text">
                        <p><span>Phone:</span> <%--+02-8321607--%>(+88)09610203077 <span>Email:</span> admin@bifpcl.com</p>
                    </div>
                    
                </div>
                <div class="col-md-6">
                    <!-- Form Start-->
                    <div class="contact_from">
                      <%--  <form action="#" method="post">--%>
                            <!-- Message Input Area Start -->
                            <div class="contact_input_area">
                                <div class="row">
                                    <!-- Single Input Area Start -->
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <asp:TextBox ID="name"  class="form-control"  runat="server"  placeholder="Your Name" ></asp:TextBox>
                                            <%--<input type="text" class="form-control" name="name" id="name" placeholder="Your Name" required>--%>
                                        </div>
                                    </div>
                                    <!-- Single Input Area Start -->
                                    <div class="col-md-12">
                                        <div class="form-group">
                                             <asp:TextBox ID="email"  class="form-control"  runat="server"  placeholder="Your E-mail" ></asp:TextBox>
                                        </div>
                                    </div>
                                    <!-- Single Input Area Start -->
                                    <div class="col-12">
                                        <div class="form-group">
                                             <asp:TextBox ID="message"  Height="100px" TextMode="MultiLine" class="form-control"  runat="server"  placeholder="Your Message *" ></asp:TextBox>
                                           <%-- <textarea name="message" class="form-control" id="message" cols="30" rows="4" placeholder="Your Message *" required></textarea>--%>
                                        </div>
                                    </div>
                                    <!-- Single Input Area Start -->
                                    <div class="col-12">
                                        <asp:Button ID="btnSend" class="btn submit-btn" runat="server" Text="Send Now" />
                                       <%-- <button type="submit" class="btn submit-btn">Send Now</button>--%>
                                        <asp:Label ID="lbMessage" runat="server" Text="" ForeColor="red"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <!-- Message Input Area End -->
                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>

    </section>
    <!-- ***** Contact Us Area End  <!-- ***** Footer Area Start ***** -->
    <footer class="footer-social-icon text-center section_padding_70 clearfix">
        <!-- footer logo -->
        <div class="footer-text">
           <img src="images/icon/logo5.png?33" alt="BIFPCL Logo" />
        </div>
        <!-- social icon-->
        <div class="footer-social-icon">
            <a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a>
            <a href="#"><i class="active fa fa-twitter" aria-hidden="true"></i></a>
            <a href="#"> <i class="fa fa-instagram" aria-hidden="true"></i></a>
            <a href="#"><i class="fa fa-google-plus" aria-hidden="true"></i></a>

        </div>
        <div class="footer-menu">
            <nav>
                <ul>
                    <li><a href="#">About</a></li>
                    <li><a href="#">Terms & Conditions</a></li>
                    <li><a href="#">Privacy Policy</a></li>
                    <li><a href="#">Contact</a></li>

                </ul>
                <div id="google_translate_element"></div><script type="text/javascript">
function googleTranslateElementInit() {
  new google.translate.TranslateElement({pageLanguage: 'en', layout: google.translate.TranslateElement.InlineLayout.SIMPLE}, 'google_translate_element');
}
</script><script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
            </nav>
        </div>
        <!-- Foooter Text-->
        <div class="copyright-text" id="divPage" runat="server">
         
        </div>
     
    </footer>
    <!-- ***** Footer Area Start ***** -->
***** -->

   
  
    </form>
      <!-- Jquery-2.2.4 JS -->
    <script src="customHome/js/jquery-2.2.4.min.js"></script>
    <!-- Popper js -->
    <script src="customHome/js/popper.min.js"></script>
    <!-- Bootstrap-4 Beta JS -->
    <script src="customHome/js/bootstrap.min.js"></script>
    <!-- All Plugins JS -->
    <script src="customHome/js/plugins.js"></script>
    <!-- Slick Slider Js-->
    <script src="customHome/js/slick.min.js"></script>
    <!-- Footer Reveal JS -->
    <script src="customHome/js/footer-reveal.min.js"></script>
    <!-- Active JS -->
    <script src="customHome/js/active.js"></script>

    <%--   pop up toast--%>
    <style>
        #snackbar1 {
  
    min-width:130px;
    /*margin-left: -125px;*/
    color: #fff;
    text-align: left;
    border-radius: 2px;
    padding: 16px;
    position: absolute  ;
    z-index: 1;
    /*left:200px;*/
    /*top:100px;*/
      
    font-size: 17px;
  background: rgb(226, 234, 234); /* Fallback for older browsers without RGBA-support */
    background: rgba(236, 231, 231,0.3);
        border-radius:24px 24px 24px 0px;
  }

#snackbar {
    visibility: hidden;
    min-width: 250px;
    margin-left: -125px;
    /*background-color: #333;*/
    color: #fff;
    text-align: center;
    border-radius: 2px;
    padding: 16px;
    position: fixed;
    z-index: 1;
    left:200px;
    top:100px;

    /*bottom: 30px;*/
    font-size: 17px;

   
 
  /*border: 1px solid black;*/
  background: rgb(100, 204, 118); /* Fallback for older browsers without RGBA-support */
    background: rgba(100, 204, 118, 0.2);
        border-radius: 24px 24px 24px 0px;
  }

#snackbar.show {
    visibility: visible;
    -webkit-animation: fadein 0.5s, fadeout 0.5s 0.6s;
    animation: fadein 0.5s, fadeout 0.5s 0.6s;
}

@-webkit-keyframes fadein {
    from {bottom: 0; opacity: 0;} 
    to {bottom: 30px; opacity: 1;}
}

@keyframes fadein {
    from {bottom: 0; opacity: 0;}
    to {bottom: 30px; opacity: 1;}
}

@-webkit-keyframes fadeout {
    from {bottom: 30px; opacity: 1;} 
    to {bottom: 0; opacity: 0;}
}

@keyframes fadeout {
    from {bottom: 30px; opacity: 1;}
    to {bottom: 0; opacity: 0;}
}
@media screen and (max-width: 992px) {
  #snackbar  {
   font-size: 10px;
   margin-left: -210px;
     min-width: 150px;
  }
}
.typewriter {
  overflow: hidden; /* Ensures the content is not revealed until the animation */
  border-left: .5em solid red; /* The typwriter cursor */
  white-space: nowrap; /* Keeps the content on a single line */
  margin: 0 auto; /* Gives that scrolling effect as the typing happens */
  letter-spacing: .15em; /* Adjust as needed */
  /*animation: 
    typing 3.5s steps(40, end),
    blink-caret .75s step-end infinite;*/
  -webkit-animation: flash linear 4s infinite;
	animation: flash linear 4s infinite;
  
}
@-webkit-keyframes flash {
	0% { opacity: 1; } 
	50% { opacity: .1; } 
	100% { opacity: 1; }
}
@keyframes flash {
	0% { opacity: 1; } 
	50% { opacity: .1; } 
	100% { opacity: 1; }
}
/* The typing effect */
@keyframes typing {
  from { width: 0 }
  to { width: 100% }
}

/* The typewriter cursor effect */
@keyframes blink-caret {
  from, to { border-color: transparent }
  50% { border-color: green; }
}
</style>
  <script>
      $( document ).ready(function() {
     var x = document.getElementById("snackbar");
    x.className = "show";
    setTimeout(function(){ x.className = x.className.replace("show", ""); }, 1200000);
});
  </script>

     <%--   pop up toast <div id="snackbar">Some text some message..</div>  --%>

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
  <%--  <script>
        var ringer = {
  countdown_to: "03/17/2020",
  rings: {
    DAYS: {
      s: 86400000, // mseconds in a day,
      max: 365
    },
    HR: {
      s: 3600000, // mseconds per hour,
      max: 24
    },
    MIN: {
      s: 60000, // mseconds per minute
      max: 60
    },
    SEC: {
      s: 1000,
      max: 60
    },
    MICROSEC: {
      s: 10,
      max: 100
    }
  },
  r_count: 4,
  r_spacing: 10, // px
  r_size: 55, // px
  r_thickness: 5, // px
  update_interval: 11, // ms

  init: function() {
    $r = ringer;
    $r.cvs = document.createElement("canvas");

    $r.size = {
      w:
        ($r.r_size + $r.r_thickness) * $r.r_count +
        $r.r_spacing * ($r.r_count - 1),
      h: $r.r_size + $r.r_thickness
    };

    $r.cvs.setAttribute("width", $r.size.w);
    $r.cvs.setAttribute("height", $r.size.h);
    $r.ctx = $r.cvs.getContext("2d");
    $(".countdownwrap").append($r.cvs);
    $r.cvs = $($r.cvs);
    $r.ctx.textAlign = "center";
    $r.actual_size = $r.r_size + $r.r_thickness;
    $r.countdown_to_time = new Date($r.countdown_to).getTime();
    $r.cvs.css({ width: $r.size.w + "px", height: $r.size.h + "px" });
    $r.go();
  },
  ctx: null,
  go: function() {
    var idx = 0;

    $r.time = new Date().getTime() - $r.countdown_to_time;

    for (var r_key in $r.rings) $r.unit(idx++, r_key, $r.rings[r_key]);

    setTimeout($r.go, $r.update_interval);
  },
  unit: function(idx, label, ring) {
    var x,
      y,
      value,
      ring_secs = ring.s;
    value = parseFloat($r.time / ring_secs);
    $r.time -= Math.round(parseInt(value)) * ring_secs;
    value = Math.abs(value);

    x = $r.r_size * 0.5 + $r.r_thickness * 0.5;
    x += +(idx * ($r.r_size + $r.r_spacing + $r.r_thickness));
    y = $r.r_size * 0.5;
    y += $r.r_thickness * 0.5;

    // calculate arc end angle
    var degrees = 360 - value / ring.max * 360.0;
    var endAngle = degrees * (Math.PI / 180);

    $r.ctx.save();

    $r.ctx.translate(x, y);
    $r.ctx.clearRect(
      $r.actual_size * -0.5,
      $r.actual_size * -0.5,
      $r.actual_size,
      $r.actual_size
    );

    // first circle
    $r.ctx.strokeStyle = "rgba(0,133,43,0.9)";
    $r.ctx.beginPath();
    $r.ctx.arc(0, 0, $r.r_size / 2, 0, 2 * Math.PI, 2);
    $r.ctx.lineWidth = $r.r_thickness;
    $r.ctx.stroke();

    // second circle
    $r.ctx.strokeStyle = "rgba(247, 7, 7, 0.9)";
    $r.ctx.beginPath();
    $r.ctx.arc(0, 0, $r.r_size / 2, 0, endAngle, 1);
    $r.ctx.lineWidth = $r.r_thickness;
    $r.ctx.stroke();

    // label
    $r.ctx.fillStyle = "#ffffff";

    $r.ctx.font = "10px Helvetica";
    $r.ctx.fillText(label, 0, 23);
    $r.ctx.fillText(label, 0, 23);

    $r.ctx.font = "bold 30px Helvetica";
    $r.ctx.fillText(Math.floor(value), 0, 10);

    $r.ctx.restore();
  }
};

ringer.init();

    </script>--%>
</body>
</html>

