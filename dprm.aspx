<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dprm.aspx.vb" Inherits="_dprm" %>

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
       <div class="page-wrapper">
       

       

            <!-- HEADER DESKTOP-->
            <!-- HEADER DESKTOP-->
        <header class="header-desktop3 d-none d-lg-block" style="background:#5d57ea">
            <div class="section__content section__content--p35">
                <div class="header3-wrap">
                    <div class="header__logo">
                        <a class="logo" href="Default.aspx">
                            <img src="images/icon/logo6.png" alt="CoolAdmin" />
                        </a>
                    </div>
                    <div class="header__navbar" id="divSidemenu" runat="server">
                    
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
            <!-- HEADER DESKTOP-->
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
        <div class="section__content section__content--p30">
          <div class="container-fluid">
            <div class="row">
              <div class="col-md-12">


                <div class="card"  >
                  <div class="card-header">
                          <%-- <p><a href="dprUpdate.aspx?mode=report" >Detail Report</a> | <a href="dpr.aspx">DPR Entry</a>  |  <a href="#" onClick="window.location.reload()" > Refresh</a> | <asp:LinkButton ID="lbPDF" runat="server" OnClick="ExportToPDF"  >PDF</asp:LinkButton> <br />>Showing work in progress including completed</p> 
                 
                   --%>
                      <h3 class="title-2 m-b-40">Mobile DPR</h3>
                      <p><a href="dprUpdate.aspx?mode=report" >Detail Report</a> | <a href="dpr.aspx">DPR Entry</a>  |  <a href="#" onClick="window.location.reload()" > Refresh</a> | <asp:LinkButton ID="lbPDF" runat="server" OnClick="ExportToPDF"  >PDF</asp:LinkButton> <br />>Showing work in progress including completed</p> 
                      <a href="https://www.bifpcl.com/upload/TS/Dashboard/cric.pdf" target="_blank"><button type="button" class="btn btn-outline-primary btn-sm">
                                            <i class="fa fa-lightbulb-o"></i>&nbsp; Critical Issues</button> </a>
                      <a href="https://www.bifpcl.com/upload/TS/Dashboard/synopsis.pdf" target="_blank">  <button type="button" class="btn btn-outline-secondary btn-sm">
                                            <i class="fa fa-bars"></i>&nbsp; Project Synopsis & Implementation Program</button> </a>
                      <a href="#video" >  <button type="button" class="btn btn-outline-danger btn-sm">
                                            <i class="fa fa-rss"></i>&nbsp; Progress Video</button> </a>
                      <a href="https://www.bifpcl.com/upload/TS/Dashboard/photo.pdf" target="_blank" >  <button type="button" class="btn btn-outline-warning btn-sm">
                                            <i class="fa fa-camera"></i>&nbsp; Progress Photographs</button> </a>
                      <%-- <p><a href="#" >Critical Issues</a> | <a href="#" >Progress Photographs</a> | <a href="#video" >Progress Video</a></p>--%>
                   </div>

                  <div class="card-body" >
                  
                  
                    <div class="vue-misc" id="divBoard" visible="True" runat="server">
                    
                      <div class="row">
                          <div class="col-lg-9">
                                <%--<h2 class="title-1 m-b-25">Daily Site Progress</h2>--%>
                               <strong class="card-title" id="divDate" runat="server">Daily Progress Report</strong>
                                   <asp:GridView  ID="gvReportVendorGroup" CssClass="table-striped"  runat="server"></asp:GridView>
                              <br />
                                        <asp:GridView  ID="gvReportTotal"  CaptionAlign="Left" CssClass="table-striped"  runat="server"></asp:GridView>
                        
                          
                              <div id="divMsg" runat="server"></div>
                              <div id="divBug" runat="server"></div>
                            </div>
                      </div>
                    </div>
                   
                  </div>

                      <div class="statistic-chart-1">
                              <a name="video"></a>   <h3 class="title-3 m-b-30">Latest Progress Video</h3>
                                <div class="chart-wrap">
                          <iframe width="560" height="315" src="https://www.youtube-nocookie.com/embed/OXEKEkREKCw?rel=0" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>      </div>
                                <div class="statistic-chart-1-note">
                                    <span class="big">July</span>
                                    <span>' 2019</span>
                                </div>

                           <h3 class="title-3 m-b-30">Showing Last Day Progress Area: </h3>
                                <div class="chart-wrap">
                             <%--<asp:GridView class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  ID="gvReport" runat="server"></asp:GridView>--%>
                               <asp:GridView  class="table-striped" ID="gvReport" runat="server">
                                   <EmptyDataTemplate>No Records found for last day</EmptyDataTemplate>
                               </asp:GridView>
                                    
                                 <%--   <div class="statistic-chart-1-note">
                                    <span class="big">July</span>
                                    <span>' 2019</span>
                                </div>--%>
                            </div>

                            </div>
                               
                      
              


              </div>
            </div>
          </div>
        </div>
      </div>
            <!-- END MAIN CONTENT-->
      
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
