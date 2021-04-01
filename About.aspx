<%@ Page Language="VB" AutoEventWireup="false" CodeFile="About.aspx.vb" Inherits="_About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BIFPCL</title>
     <!-- Required meta tags-->
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="BIFPCL Official Website" />
    <meta name="author" content="Vinod Kotiya" />
   <meta name="keywords" content="NTPC, NTPC Limited, BIFPCL, Rampal , Rampal Project, Maitree Super Thermal Power Project, Khulna, Bangladesh India Friendship Power Company Private Limited" />
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
     <%-- Highchart plugin--%>
        <%-- <script src="js/highcharts.js"></script>
<script src="js/highcharts-more.js"></script>
<script src="js/exporting.js"></script>--%>

       <%-- Organogram--%>
    <%-- <script src="Scripts/getorgchart.js"></script>
    <link href="Scripts/getorgchart.css" rel="stylesheet" />
     <script type="text/javascript">
        var peopleElement = document.getElementById("people");
        var orgChart = new getOrgChart(peopleElement, {
            primaryFields: ["name", "title", "phone", "mail"],
            photoFields: ["image"],
            dataSource: [
                { id: 1, parentId: null, name: "Amber McKenzie", title: "CEO", phone: "678-772-470", mail: "lemmons@jourrapide.com", adress: "Atlanta, GA 30303", image: "images/f-11.jpg" },
                { id: 2, parentId: 1, name: "Ava Field", title: "Paper goods machine setter", phone: "937-912-4971", mail: "anderson@jourrapide.com", image: "images/f-10.jpg" },
                { id: 3, parentId: 1, name: "Evie Johnson", title: "Employer relations representative", phone: "314-722-6164", mail: "thornton@armyspy.com", image: "images/f-9.jpg" },
                { id: 4, parentId: 1, name: "Paul Shetler", title: "Teaching assistant", phone: "330-263-6439", mail: "shetler@rhyta.com", image: "images/f-5.jpg" },
                { id: 5, parentId: 2, name: "Rebecca Francis", title: "Welding machine setter", phone: "408-460-0589", image: "images/f-4.jpg" },
                { id: 6, parentId: 2, name: "Rebecca Randall", title: "Optometrist", phone: "801-920-9842", mail: "JasonWGoodman@armyspy.com", image: "images/f-8.jpg" },
                { id: 7, parentId: 2, name: "Spencer May", title: "System operator", phone: "Conservation scientist", mail: "hodges@teleworm.us", image: "images/f-7.jpg" },
                { id: 8, parentId: 6, name: "Max Ford", title: "Budget manager", phone: "989-474-8325", mail: "hunter@teleworm.us", image: "images/f-6.jpg" },
                { id: 9, parentId: 7, name: "Riley Bray", title: "Structural metal fabricator", phone: "479-359-2159", image: "images/f-3.jpg" },
                { id: 10, parentId: 7, name: "Callum Whitehouse", title: "Radar controller", phone: "847-474-8775", image: "images/f-2.jpg" }
            ]
        });
    </script>--%>
  <%--<script type="text/javascript" language="javascript">
     
      $(document).ready(function () {
         
          $.ajax({
              type: "POST",
              url: "vinservice.asmx/ogramdata",
              contentType: 'application/json; charset=utf-8',
              dataType: 'json',
              success: function (data) {
                  var source = data.d  ;
                 console.log( source );
              var json = $.parseJSON(source);
             
                
                     var peopleElement = document.getElementById("people");
                     var orgChart = new getOrgChart(peopleElement, {
                         boxSizeInPercentage: {
                             minBoxSize: {
                                 width: 5,
                                 height: 5
                             },
                             boxSize: {
                                 width: 11,
                                 height: 70
                             },
                             maxBoxSize: {
                                 width: 100,
                                 height: 100
                             }
                         },
                         theme: "cassandra",
                        // theme: "myCustomTheme",
                         enableZoom: true,
                         enableEdit: false,
                         enableSearch: true,
                         enableMove: true,
                         enableGridView: false,
                         enableDetailsView: false,
                         enablePrint : false,
                         primaryFields: ["Name", "Title","Work","Phone"],
                         photoFields: ["image"],
                         orientation: getOrgChart.RO_TOP,
                         expandToLevel : 2,
                         layout: getOrgChart.MIXED_HIERARCHY_RIGHT_LINKS,
                         siblingSeparation: 20,
                     //    subtreeSeparation: 200,
                     
                         dataSource: json
                 
                     });
                        
                         
                
               },
               error: function (r) {
                   alert("Failed  :" + r.d);
               }

           });
           
                   
       });

      </script>--%>
    <%-- Organogram--%>

</head>
<body class="animsition">
       <div id="container">
    <div id="people"></div>
   </div>
    <form id="form1" runat="server">
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
        <section class="page-content--bgf7">
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
                                        <li class="list-inline-item">About</li>
                                    </ul>
                                </div>
                               <div class="rs-select2--dark rs-select2--sm rs-select2--dark2" style="width:300px;">
                                        <select class="js-select2" name="type">
                                            <option selected="selected">Quick Links</option>
                                            <option value=""><a style="display:block" href="dpr.aspx">Company</a></option>
                                            <option value=""><a style="display:block" href="dprIssues.aspx">Board</a></option>
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
                            <h1 class="title-4">About
                                <span>Us</span>
                            </h1>
                            <hr class="line-seprate">
                        </div>
                    </div>
                </div>
            </section>
            <!-- END WELCOME-->

            <!-- STATISTIC-->

            <!-- MAIN CONTENT-->
       <section class="statistic statistic2">
                <div class="container">
            <div class="row">
              <div class="col-md-12">


                   <div id="divCompany" visible="false" runat="server">
                  <div class="card border border-primary">
                                    <div class="card-header">
                                        <strong class="card-title">Company</strong>
                                    </div>
                                    <div class="card-body">
                                        <p class="card-text">Bangladesh India Friendship Power Company Ltd (50:50 JV between NTPC &Bangladesh Power Development Board (BPDB)
                                        </p>
                                    </div>
                                </div>
                    <div class="card border border-success">
                                    <div class="card-header">
                                        <strong class="card-title">Project</strong>
                                    </div>
                                    <div class="card-body">
                                        <p class="card-text">Maitree Super Thermal Power Project (2Ã—660 MW)
                                        </p>
                                    </div>
                                </div>

                     <div class="card border border-primary">
                                    <div class="card-header">
                                        <strong class="card-title">Documents Signed</strong>
                                    </div>
                                    <div class="card-body">
                                       <ul class="card-text">
<li style="text-align: justify;"><strong>11.01.2010</strong><strong>: </strong>MoU signed between Govt of India &Govt of Bangladesh, to enhance traditional ties of friendship between the two countries through development of economic cooperation.Â·</li>
<li style="text-align: justify;"><strong>30.08.2010: </strong>MoU signed between NTPC & BPDB to form a JV Company (JVC) through 50:50 equity participation for setting up a 2Ã—660 MW coal based power project at Khulna in Bangladesh.</li>
<li style="text-align: justify;">Â <strong>29.01.2012: </strong>JV Agreement signed between NTPC & BPDB.</li>
<li style="text-align: justify;">Â <strong>31.10.2012: </strong>Joint Venture Company Bangladesh India Friendship Power Company (Pvt.) Limited (BIFPCL) incorporated.</li>
<li style="text-align: justify;"><strong>02.12.2012: </strong>FR finalized.</li>
<li style="text-align: justify;"><strong>20.04.2013:Â </strong>Power Purchase Agreements(PPA), Implementation Agreements(IA) and Supplementary Joint Venture Agreement(SJVA) signed at Dhaka in presence of Secy(Power) of GoI&Govt of Bangladesh, CMD-NTPC & Chairman-BPDB.</li>
</ul>
                                        
                                    </div>
                                </div>
                       <div class="card border border-success">  <div class="card-header">
                                        <strong class="card-title">Location</strong>  </div>     <div class="card-body">
                                        <p class="card-text"><strong>Upazila</strong><strong>:</strong>Rampal;<strong>Division</strong>: Khulna;<strong>District</strong>:Bagerhat,BangladeshThe site is located about 23 km southward of Khulna City and 14 km north of Mongla Port.
                                        </p>     </div>      </div>
                        <div class="card border border-primary"> <div class="card-header">
                                        <strong class="card-title">Nearest Railhead / Airport</strong>  </div> <div class="card-body">
                                        <p class="card-text">36 km from Khulna Junction Rly Stn105 km from Jessore Airport,12 kms from proposed Khan Jahan Ali Airport.
                                        </p>     </div></div>
                        <div class="card border border-success">  <div class="card-header">
                                        <strong class="card-title">Approved Capacity</strong>  </div>     <div class="card-body">
                                        <p class="card-text">1320 MW (2 units of 660 MW each)
                                        </p>     </div>      </div>
                        <div class="card border border-primary"> <div class="card-header">
                                        <strong class="card-title">Beneficiaries</strong>  </div> <div class="card-body">
                                        <p class="card-text">100% Power to BPDB of Bangladesh
                                        </p>     </div></div>
                        <div class="card border border-success">  <div class="card-header">
                                        <strong class="card-title">Power Evacuation System</strong>  </div>     <div class="card-body">
                                        <p class="card-text">Generation Step up voltage is 400 KV, 400 KV Double Circuit (D/C) Line to connect Dhaka ring main. 220 KV Double Circuit (D/C) Line to connect to Khulna substation.
                                        </p>     </div>      </div>
                        <div class="card border border-primary"> <div class="card-header">
                                        <strong class="card-title">Financing of Main Plant EPC Package</strong>  </div> <div class="card-body">
                                        <p class="card-text">Financing of Main Plant EPC (Turnkey) Package is being done by Indian EXIM Bank
                                        </p>     </div></div>
                        <div class="card border border-success">  <div class="card-header">
                                        <strong class="card-title">Land Requirement </strong>  </div>     <div class="card-body">
                                        <p class="card-text">915.5 acres of land available for the project. Land is owned by BPDB for which land lease agreement under signing with BPDB.
                                        </p>     </div>      </div>
                        <div class="card border border-primary"> <div class="card-header">
                                        <strong class="card-title">Water Source </strong>  </div> <div class="card-body">
                                        <p class="card-text">Saline water from Pussur River for meeting cooling water requirement. Sweet water required for meeting the potable water, plant service water, cycle makeup (DM water), etc, shall be produced using Desalination process from saline water through Reverse Osmosis process.
                                        </p>     </div></div>
                        <div class="card border border-success">  <div class="card-header">
                                        <strong class="card-title">Fuel</strong>  </div>     <div class="card-body">
                                        <p class="card-text">Usage of imported coal envisaged for the project.
                                        </p>     </div>      </div>
                        <div class="card border border-primary"> <div class="card-header">
                                        <strong class="card-title">EIA Study </strong>  </div> <div class="card-body">
                                        <p class="card-text">EIA report has been approved by DOE (Dept of Environment), Bangladesh on 05.08.2013.
                                        </p>     </div></div>
                        <div class="card border border-success">  <div class="card-header">
                                        <strong class="card-title">Tendering for Main Plant </strong>  </div>     <div class="card-body">
                                        <p class="card-text">NIT for Main Plant EPC Package done on 12.02.15. Bids opened on 22.09.15. Recommendation for Award of EPC Contract approved by BIFPCL Board on 23.12.15.NOA issued to M/s BHEL on 31.01.2016.
                                        </p>     </div>      </div>
                        <div class="card border border-primary"> <div class="card-header">
                                        <strong class="card-title">Synchronisation Schedule</strong>  </div> <div class="card-body">
                                        <p class="card-text">Synchronisation of U#1 in 41 months from zero date which shall commence on issuance of Notice to Proceed after achieving Financial Closure
                                        </p>     </div></div>
                       
 </div> <%--close divcompany--%>
               
                  
           
               
                    <div class="vue-misc" id="divBoard" visible="false" runat="server">
                     <div class="card"  >
                  <div class="card-header">
                    <strong class="card-title">About Company</strong>
                  </div>

                  <div class="card-body" >
                      <div class="row">
                         <div class=" col-md-auto">
                          <h3 class="mb-3"> </h3>
                          <div class="jumbotron">
                           <div class="col-lg-12">
                                <div class="au-card au-card--no-shadow au-card--no-pad m-b-40">
                                    <div class="au-card-title" style="background-image:url('images/bg-title-02.jpg');">
                                        <div class="bg-overlay bg-overlay--blue"></div>
                                        <h3>
                                            <i class="zmdi zmdi-comment-text"></i>Board</h3>
                                       
                                    </div>
                                    <div class="au-inbox-wrap js-inbox-wrap">
                                        <div class="au-message js-list-load">
                                           <%-- <div class="au-message__noti">
                                                <p>You Have
                                                    <span>2</span>

                                                    new messages
                                                </p>
                                            </div>--%>
                                            <div class="au-message-list" style="height:auto;">
                                                <div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap">
                                                                <div class="avatar" style="height: 160px; width: 160px;">
                                                                    <img src="\upload\employee\pics\chairman1.jpg" alt="Habibur">
                                                                </div>
                                                            </div>
                                                            <div class="text"  style='padding-left: 123px;'>
                                                                <h5 class="name"  >Mr. Md. Habibur Rahman</h5>
                                                                <p>Secretary, Power Division, GoB and Chairman,BIFPCL</p>
                                                            </div>
                                                        </div>
                                                       
                                                    </div>
                                                </div>
                                                 <div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap">
                                                                <div class="avatar" style="height: 160px; width: 160px;">
                                                                    <img src="\upload\employee\pics\cmd.jpg" alt="Mr.Gurdeep Singh">
                                                                </div>
                                                            </div>
                                                            <div class="text"  style='padding-left: 123px;'>
                                                                <h5 class="name"  >Mr.Gurdeep Singh</h5>
                                                                <p>Chairman & Managing Director,NTPC Limited</p>
                                                            </div>
                                                        </div>
                                                       
                                                    </div>
                                                </div>
                                                <%-- <div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap">
                                                                <div class="avatar" style="height: 160px; width: 160px;">
                                                                    <img src="\upload\employee\pics\Belayet.jpg" alt="Mr. Md. Belayet Hossain">
                                                                </div>
                                                            </div>
                                                            <div class="text"  style="padding-left: 123px;">
                                                                <h5 class="name">Mr. Md. Belayet Hossain</h5>
                                                                <p>Chairman, BPDB</p>
                                                            </div>
                                                        </div>
                                                       
                                                    </div>
                                                </div>--%>
                                                 <div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap">
                                                                <div class="avatar" style="height: 160px; width: 160px;">
                                                                    <img src="\upload\employee\pics\Belayet.jpg" alt="Mr. Md. Belayet Hossain">
                                                                </div>
                                                            </div>
                                                            <div class="text"  style="padding-left: 123px;">
                                                                <h5 class="name">Mr. Md. Belayet Hossain</h5>
                                                                <p>Chairman, BPDB</p>
                                                            </div>
                                                        </div>
                                                       
                                                    </div>
                                                </div>
                                                 <div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap">
                                                                <div class="avatar" style="height: 160px; width: 160px;">
                                                                    <img src="\upload\employee\pics\alam1.png?1" alt="Mr. Md. Nurul Alam">
                                                                </div>
                                                            </div>
                                                            <div class="text">
                                                                <h5 class="name"  style="padding-left: 123px;">Mr. Mohammed Shafiqullah</h5>
                                                                <p>Additional Secretary (Development-1),Power Division,MPEMR</p>
                                                            </div>
                                                        </div>
                                                       
                                                    </div>
                                                </div>
                                                 <div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap">
                                                                <div class="avatar" style="height: 160px; width: 160px;">
                                                                    <img src="\upload\employee\pics\mondol.png" alt="NTPC Dir">
                                                                </div>
                                                            </div>
                                                            <div class="text">
                                                                <h5 class="name"  style="padding-left: 123px;">Mr. C. K. Mondol</h5>
                                                                <p>Director(Commercial),NTPC</p>
                                                            </div>
                                                        </div>
                                                       
                                                    </div>
                                                </div>
                                                 <div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap">
                                                                <div class="avatar" style="height: 160px; width: 160px;">
                                                                    <img src="\upload\employee\pics\rahman.jpg" alt="Engr. Md Mahbubur Rahman">
                                                                </div>
                                                            </div>
                                                            <div class="text">
                                                                <h5 class="name"  style="padding-left: 123px;">Ms. Nurun Nahar Begum</h5>
                                                                <p>Member (Company Affairs), BPDB</p>
                                                            </div> 
                                                        </div>
                                                       
                                                    </div>
                                                </div>
                                                 <div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap">
                                                                <div class="avatar" style="height: 160px; width: 160px;">
                                                                    <img src="\upload\employee\pics\renu.jpg" alt="Ms. Renu Narang">
                                                                </div>
                                                            </div>
                                                            <div class="text"  style="padding-left: 123px;">
                                                                <h5 class="name">Ms. Renu Narang</h5>
                                                                <p>General Manager (Finance),NTPC</p>
                                                            </div>
                                                        </div>
                                                       
                                                    </div>
                                                </div>
                                                <div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap">
                                                                <div class="avatar" style="height: 160px; width: 160px;">
                                                                    <img src="\upload\employee\pics\anand.jpg" alt="Engr. Naresh Anand">
                                                                </div>
                                                            </div>
                                                            <div class="text"  style="padding-left: 123px;">
                                                                <h5 class="name">Engr. Naresh Anand</h5>
                                                                <p>Managing Director,BIFPCL</p>
                                                            </div>
                                                        </div>
                                                       
                                                    </div>
                                                </div>
                                               <%-- <div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap">
                                                                <div class="avatar" style="height: 160px; width: 160px;">
                                                                    <img src="\upload\employee\pics\pandey.jpg" alt="S C Pandey">
                                                                </div>
                                                            </div>
                                                            <div class="text" style="padding-left: 123px;">
                                                                <h5 class="name">Mr. S. C. Pandey</h5>
                                                                <p>Project Director, MSTPP</p>
                                                            </div>
                                                        </div>
                                                       
                                                    </div>
                                                </div>--%>
                                             
                                             
                                            </div>
                                         <%--   <div class="au-message__footer">
                                                <button class="au-btn au-btn-load js-load-btn">load more</button>
                                            </div>--%>
                                        </div>
                                     
                                    </div>
                                </div>
                            </div>
                          </div>
                        </div>
                      </div>
 <a href="mgmt.aspx" > Board Member's Dashboard </a>
                    </div>
                         </div></div>
                     <div class="vue-misc" id="divContact" visible="false" runat="server">
                     <div class="card"  >
                  <div class="card-header">
                    <strong class="card-title">About Company</strong>
                  </div>

                  <div class="card-body" >
                      <div class="row">
                         <div class=" col-md-auto">
                          <h3 class="mb-3"> Search Contacts </h3>
                             <asp:TextBox ID="txtSearch" runat="server" BorderWidth="2px" BorderColor="Black" placeholder="Enter few characters" Width="190"></asp:TextBox> Â Â  
                             <asp:Button ID="btnSubmit" runat="server" Text="Go" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  /> 
                            <br /> <br /><asp:RadioButtonList ID="rblType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="2">
                                  <asp:ListItem  Selected="True">Site Office</asp:ListItem>                  
                                <asp:ListItem>Head Office</asp:ListItem>
                                                   <asp:ListItem>Support Staff</asp:ListItem>
                                 <asp:ListItem>Vendors</asp:ListItem>
                                 <asp:ListItem>PABX List</asp:ListItem>
                                               </asp:RadioButtonList>
                             <div id="divBday" runat="server" class="sufee-alert alert with-close alert-success alert-dismissible fade show">
											<%--<span class="badge badge-pill badge-success">Upcoming Birthday:</span>
											You successfully read this important alert.--%>
											<button type="button" class="close" data-dismiss="alert" aria-label="Close">
												<span aria-hidden="true">Ã—</span>
											</button>
										</div>
                          <div class="jumbotron">
                           <div class="col-lg-12">
                                <div class="au-card au-card--no-shadow au-card--no-pad m-b-40">
                                    <div class="au-card-title" style="background-image:url('images/bg-title-02.jpg');">
                                        <div class="bg-overlay bg-overlay--blue"></div>
                                        <h3 id="divH3" runat ="server">
                                           Head Office</h3>
                                       
                                    </div>
                                    <div class="au-inbox-wrap js-inbox-wrap">
                                        <div class="au-message js-list-load">
                                           <%-- <div class="au-message__noti">
                                                <p>You Have
                                                    <span>2</span>

                                                    new messages
                                                </p>
                                            </div>--%>
                                            <div class="au-message-list" id="divContactList" runat="server" style="height:auto;">
                                                <%--<div class="au-message__item unread">
                                                    <div class="au-message__item-inner">
                                                        <div class="au-message__item-text">
                                                            <div class="avatar-wrap">
                                                                <div class="avatar" style="height: 160px; width: 160px;">
                                                                    <img src="\upload\employee\pics\kaikaus.jpg" alt="Dr. Ahmad Kaikaus" />
                                                                </div>
                                                            </div>
                                                            <div class="text">
                                                                <h5 class="name"  style="padding-left: 123px;">Dr. Ahmad Kaikaus</h5>
                                                                <p>Secretary, Power Division, MPEMR and Chairman,BIFPCL</p>
                                                            </div>
                                                        </div>
                                                       
                                                    </div>
                                                </div>--%>
                                             
                                            </div>
                                         <%--   <div class="au-message__footer">
                                                <button class="au-btn au-btn-load js-load-btn">load more</button>
                                            </div>--%>
                                        </div>
                                      
                                    </div>
                                </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                      </div>
                      </div>  
                       <div class="vue-misc" id="divFAQ" visible="false" runat="server">
                     <div class="card"  >
                  <div class="card-header">
                    <strong class="card-title">FAQ</strong>
                  </div>

                  <div class="card-body" >
                      <div class="row">
                          <h3>
Frequently Asked Question </h3>
  <br/><br/>Q1: Is the plant location at safe distance from the Sundarbans and the World
Heritage site? <br/>
A1: Yes, the project is located at a safe distance from the Sundarbans and the
World Heritage site.
The proposed project location is approximately 14 km away from the nearest
boundary of Sundarbans and about 65 km from the nearest world heritage site.
  <br/><br/>Q2: Will the Proposed Project result rise of local temperature due to heat radiation
from the Chimney? <br/>
A2: The proposed project will not result in rise of local temperature due to heat
radiation from the Chimney.
The temperature of the flue gas at the stack outlet would be around 60 Â°C as the
wet lime stone based Flue Gas Desulphurization (FGD) system is envisaged in
the flue gas path. Further, 275 mtr high Chimney is envisaged. Moreover, there is
no topographical barrier of heat dispersion like mountain/hilly area, dense city,
tallest building, etc within the 20 km of the plant location that may trap the heat
and cause rise of local temperature.
  <br/><br/>Q3: Will the coal dust to be generated from coal stockyard be dispersed in nearby
area and community? <br/>
A3: NoCoal dust will be dispersed in nearby area and community.
Following technical measures have been incorporated to achieve this:
ïƒ˜ The entire Coal stock yard and coal conveying system will be covered.
ïƒ˜ Plain water dust suppression system at stock pile and dry fog dust suppression
system at feeding and discharge point of conveyor will also be provided which
will further reduce the fugitive dust within covered conveyor gallery and transfer
point.
  <br/><br/>Q4: Will the Coal dust to be generated during coal transportation pollute air quality of
Sundarbans? <br/>
A4: No, the air quality of Sundarbans will not be polluted.
Coal transportation shall be done through environment friendly modern covered
vessels.
  <br/><br/>Q5: Will the emitted ash from the power plant pollute air quality of Sundarbans and as
well as nearby community? <br/>
A5: No, the air quality of Sundarbans and the nearby community shall not be
polluted due to ash emission from the power plant.
First of all imported high GCV coal with low ash content will be used in the
project for power generation. Highly efficient Electro Static Precipitator (ESP) of
latest proven technology with 99.9% efficiency shall be used to limit Suspended
Particulate Matter (SPM) emission in the flue gas,within the World Bank / IFC
specified standard of 50mg/NM3
(against local regulation for SPM 150 mg/NM3
),
at the outlet of the Chimney.
In addition to this, theBottom ashgenerated from the project shall be collected
and managed by an efficient and modern dry ash collection and management
system to avoid effect on environment.
Further, arrangements are being made for 100% utilization of ash generated
from the project. Hence, there is hardly any chance of fugitive / emitted ash from
the project to get adversely affect environment.
  <br/><br/>Q6: Will the emission of SOx and NOx pollute the air quality of the Sundarbans as
well as the nearby locality? <br/>
A6: No, the emission of SOx and NOx from the power plant shall not pollute the air
quality of the Sundarbans as well as the nearby locality.
First of all, High GCV, very low sulphur content coal will be used in the project
for power generation which will, ab-initio limit the SOx production to a low
quantum. Also, advanced low NOx burners are being installed in the plant to
reduce the NOx generation to a lower level.
To further reduce SOx in the flue gas to be emitted from the chimney, a
modern wet-limestone based Flue Gas Desulphurization System (FGD) is being
installed.
These measures will collectively reduce the SOx and NOx emission from the
plant to low level and keep it within the stringent limits prescribed by World Bank
/ IFC Standard.
   <br/><br/>Q7: Is there any scope of utilizing ash in Bangladesh? <br/>
A7: Yes, there is huge scope of utilizing ash in Bangladesh in an environment
friendly way, especially in the cement manufacturing, brick manufacturing and
construction industries.
At present the cement companies import ash from nearby countries. Brick fields
use soil for brick manufacturing. Supplying ash to these industries will not only
ensure large scale utilization of ash in Bangladesh, it will help Bangladesh
economy in multiple ways too.
BIFPCL floated an Expression of Interest (EOI) from cement industries in this
regard and EOI received for more than 4 times of estimated ash production
from 2x660 MW Maitree STPP. Hence, market survey also support the fact that
100% ash generated in the project shall easily be consumed in cement
industriesitself. <br/><br/>
  Q8: There is no firm commitment that the EMP would be implemented. There must
be a strong monitoring team comprising of concerned authorities, civil society
and local representatives. <br/>
A8: Implementations of EMP would be the key for successful implementation and
operation of the Rampal Thermal Power plant. BIFPCL being a responsible
organization is committed for implementation of EMP.
There would be an international External Monitoring Agency (supported by
government enforcement agencies and reputed international organization) to
carry out independent monitoring and auditing of implementation of EMP. The
agency will have both national and international environmental experts,
representatives from DOE, Forest Department, MPA, two international
environmental organization and shall carryout intermittent third party monitoring
and auditing of the project. They will also carry out annual third party auditing of
EMP and make further modifications, if required.
  <br/><br/>Q9: Will the power plant release heavy metal? <br/>
A9: No, the power plant will not release heavy metal to impact the environment
adversely.
The possible source of heavy metal could be coal. Concentration of heavy metal
in coal being imported will be negligible.
Moreover, heavy metal like Hg will be absorbed in ash as normal phenomena
which will be captured by highly efficient (99.9%) ESP and then managed for
safe utilisation. And further, the wet limestone technology based FGD
downstream will remove remaining reactive Hg from the flue gas before it gets
emitted from the chimney.
Similarly modern dry bottom ash technology is being used for collection and
management of bottom ash in environment friendly way.
  <br/><br/>Q10: Will the power plant cause Acid rain? <br/>
A10: No, due to very low emission of SOx and NOX and use of 275 Mtr tall chimney,
there is no likelihood of this power plant causing acid rain.
First of all, low sulphur content coal shall be used for the project. Further, the
plant will have FGD (Flue Gas Desulphurization) system which will remove SOx
(efficiency of FGD is more than 95%) from flue gas.275 meters high chimney to
further disperse the treated and cleansed flue gas to a wider range to further
dilute and reduce the impact on the environment.
  <br/><br/>Q11: Is there any plan to fill or encroach the Maidara River and Passur River? <br/>
A11: No, there is no plan to fill or encroach the Maidara and Passur River.
  <br/><br/>Q12: Is there any plan to build coal silo / stockyard in Sundarbans / Akram Points? <br/>
A12: No, there is no plan to build coal silo / stockyard in any location of the
Sundarbans/ Akram Point.
Coal will be transshipped directly from the mother vessel to the lighters in a
closed / covered and environmentally benign way. The coal stockyard
constructed at plant siteshall be fully covered.
  <br/><br/>Q13: Will the coal transportation through Passur river cause damage to Sundarbans? <br/>
A13: No. EIA study has been conducted in this regard and it has been established
that coal transportation through Passurriverwill not cause damage to
Sundarbans.
Due consideration has been taken in designingthe coal logistics and
transportation methodology and systems pertaining to this project in an
environment friendly manner.
Imported coal will be shipped through the existing maritime channel of Mongla
Port Authority in Passurriver. This is an established channel being used for
many decades now for movement of ships / barges.
Daily requirement of coal is estimated to be 12000Ton. BIFPCL plans to use
upto 12000Ton size modern sea-worthy vessel (â€œmini-shipâ€), tailor made with
covered hatches as per IMO classifying norms, designed for zero effluent
discharge, low SOx emission, low noise , low speed, night vision and GPS, with
recessed lighting and no horn operation. This will obviate the possibility of
pollution of Passur channel.
Coal will be transported through these environmental friendly Lighters (â€œmini
shipsâ€) upto jetty. Further, these lighters will ply through a designated channel in
a very wide river, under the guidance of Pilot boats with experienced Pilots of
Mongla Port Authority for the entire stretch within the Passur river to eliminate
the possibility of any accident (aground / collision etc.).
  <br/><br/>Q14: Will there be any discharge of heated water from the plant? <br/>
A14: No, heated water from the plant shall not be discharged in the river.
Aclosed cycle cooling watersystem with cooling towers is envisaged and only a
miniscule quantum of water (less than 0.05% of the leanest flow of the river
during lean season) shall be drawn from the river as make-up water.The cooling
water, after circulation in the plant shall be cooled in cooling towers and will be
reused.After repeated recirculation some part of the recirculating water, after
cooling shall be taken out of the closed system and sent back to the river.
Temperature of this water shall never be more than two degree Centigrade
(2ï‚°C) above the river water temperature at the edge of mixing zone which is as
per stringent IFC norms.
  <br/><br/>Q15: Will the project cause water pollution in the Passur River? <br/>
A15: A closed cycle cooling water system with cooling towers is envisaged which
means there will be no thermal pollution. Further, effluent water of the project
shall be thoroughly treated in Effluent Treatment plant (ETP) within the project,
before it goes to the Central Monitoring Basin. The quality of treated effluents
will be monitored at this central monitoring basin to ensure that the negligible
quantum of water (as compared to the water volume in the Passurriver) goes to
the river complying all the environment norms.
Hence, there will be no pollution in the river.
  <br/><br/>Q16: Will there be any Black smog over the atmosphere of locality and the
Sundarbans? <br/>
A16: No, there will not be any formation of black smogover the atmosphere of locality
and the Sundarbans.
ïƒ¼ The project is designed to satisfy emission standards as contained inthe
stringent IFC/WB standard.
ïƒ¼ The flue gas will be emitted from the stack of 275m height to avoid the
atmospheric layer of thermal inversion. Hence thechances of formation of
black smog is negligible.
ïƒ¼ There is no topographical barrier like hills, dense city, etc in and around
the project location that may trap air pollutants.
ïƒ¼ The project area is prone to high velocity wind which helps in wider
dispersion of the flue coming out of the chimney at that height and also
helps in scavenging. Cyclone and depression (common in the region)
hinder long term trapping of the air pollutants.
  <br/><br/>Q17: Will the electricity to be produced from the power plant (proposed) be exported
to India? <br/>
A17: No, the electricity produced from the power plant shall not be exported to India.
The entire electricity generated from Maitree STPP will be off-taken by
Bangladesh Power Development Board and used in Bangladesh only.
  <br/><br/>Q18: What would be the share of NTPC, India in the proposed Power Plant? <br/>
A18: The proposed power plant (Maitree STPP) is being developed by BangladeshIndia
Friendship Power Company (BIFPCL). This is a Bangladeshi company and
is incorporated in Dhaka. BIFPCL has been co-promoted by BPDB of
Bangladesh and NTPC Ltd. of India with equal (50:50) equity investment.
  <br/><br/>Q19: Who (Bangladesh or India) will operate the Power Plant? <br/>
A19: BIFPCL will operate the power plant.
  <br/><br/>Q20: Will the top most and important positions of the management be reserved for
India / NTPC? <br/>
A20: No, it is not correct that the top most and important positions of the management
will be reserved for India / NTPC.
BIFPCL is a Bangladeshi company incorporated in Dhaka. The current Chairman
of the Company is the Secretary (Power Division), Govt. of Bangladesh. The MD
is a professional on deputation from NTPC Ltd. Rest of the Board members
have been inducted ensuring equal representation from BPDB of Bangladesh
and NTPC of India, in conformity with their equal (50:50) equity ownership of
this Joint Venture Company.
Most of the officers / managerial staff will be recruited in Bangladesh and will be
selected based on their experience and qualification in the relevant area.
  <br/><br/>Q21: Who will pay back the loan to be used for the proposed Power Plant? <br/>
A21: As the loan is issued to BIFPCL for the construction of the proposed 2x660W
Maitree Power Plant Project,BIFPCL will pay back the loan.
  <br/><br/>Q22: Will there be any employment opportunity of local people and affected people in
the project construction and operation? <br/>
A22: Yes, there will be employment opportunity of local people and affected people in
the project construction and operation period.
As this region is underdeveloped, opportunity of trade and employment is very
limited. Besides direct employment in BIFPCL, there will also be a huge
opportunity to the local people for business and other indirect employment
opportunities.
Moreover, electricity generation being a mother industry, this Power plant will
usher in economic growth in that locality in particular and the country in general,
creating many downstream / related industries. This will give impetus to growth
and generate employment opportunities for the people of Bangladesh.
  <br/><br/>Q23: Will the produced power be supplied to the locality? <br/>
A23: Power generated from the project will be fed to the grid and the further
distribution will be done by Govt. of Bangladesh. This power will be used as
base load station for Bangladesh and help the Govt. achieve its target of
â€œelectricity for allâ€ by 2021. This will automatically ensure electricity supply to the
locality.
  <br/><br/>Q24: Will the company take any social welfare activities program? <br/>
A24: Yes,the company will take many social welfare activities/ programs for the local
peopleand community.
Despite the fact that the Company is yet to start generation, BIFPCL has already
taken up several CSR related activities like:
ïƒ˜ Free Medical facility to local people.
ïƒ˜ Recognition and Encouragement to Local meritorious students.
ïƒ˜ Vocational training for local women for empowerment.
ïƒ˜ Computer training to local youth for employability etc.
Moreover, GoB has already declared to develop a Social welfare fund for the
benefit of local people by way of imposing CESS @ 3 Paise per unit of power
generation from the Power Plant. This is expected to create a kitty with annual
fund injection of the order of approximately BDT 30 Crore (i.e. BDT 300Million).
BIFPCLshall take up different social welfare activities for the local people from
this fund, in consultation with GoB.
  <br/><br/>Q25: Public consultation meeting is being conducted after commencing the
construction work? <br/>
A25: Public disclosure and consultation was also done in line with DoE stipulations
at the time of EIA approval process.
Major construction activity for the project is yet to commence. Presently
activities of initial infrastructure are in progress. Public consultation meetings
have been/ are being organized at site from time to time after the
commencement of initial infrastructure activities at site.
  <br/><br/>Q26: The project is located in prime land of capture fish. The plant will destroy the
capture fish of the area.
A26: No, the plant will not destroy the capture fish of that area.
No fresh water fish pond existed within the project boundary and only few
creeks for shrimp farming were occupied.
The project location was finalized after due study of alternative sites and this site
was found to be the most suitable. Land for the project was acquired by Govt. of
Bangladesh on behalf of BPDB as per the extant rules.
  <br/><br/>Q27: The project will destroy the Sundarbans that took ages to grow.
A27: No, the project shall not destroy the Sundarbans as perceived.
While carrying out the Initial Environment Examination (IEE) and Environmental
Impact Assessment (EIA) study of the project, effect on Sundarbans was
especially kept under special consideration. BIFPCL is fully aware of the
significance of Sundarbansand its World Heritage Site and committed to provide
an environment friendly solution in order to add 1320MW electricity to the grid
for the people of Bangladesh without causing any adverse effect on
Sundarbans.
To ensure that, the project would havea â€œState of the Artâ€ Technology that
includes, Ultra Super Critical boiler technology, FGD unit for SOx control,
advanced Low NOx burner, highly efficient ESP for Particulate Matter emission
control, closed cycle cooling water system to minimize water consumption and
to prevent thermal pollution, ETP to prevent water pollution. The plant has been
designed to meet the emission standards prescribed in World Bank/IFCguideline
which is most stringent.
More over the predominant wind flow direction acts as a natural shield for
Sundarbans.
In addition, there would be plantation of upto 5.0 lac trees, regular
environmental monitoring, continuous research and development.
The major cause for shrinkage of Sundarbans has been the human interference
due to dependence of poor people on the forest for livelihood. Rampal project
would certainly create high growth opportunities and shall reduce dependence
on Sundarbans for livelihood.
Rampal project would create high growth opportunities in the region and shall
reduce dependence on Sundarbans for livelihood.
  <br/><br/>Q28: Environmental effect on Sundarbans during operation of the plant has not been
mentioned in EIA.
A28: No, all possible impacts have been identified and projected in the EIA for PreConstruction,
Construction and Post-Construction/Operational period. The
environmental effects during operation of the plant and EMP measures have
been outlined in Chapter 10 (Mitigation of impact) of the EIA reportwhich is
already available in the BIFPCL website.
  <br/><br/>Q29: The Proposed Power Plant would ruin the bio-diversity of Sundarbans.
A29: No, the project will have no adverse effect on the Biodiversity of Sundarbans
and its World Heritage Site. Extensive studies, surveys and researches have
been performed regarding the bio-diversity of Sundarbans to identify all possible
impacts that might occur. Accordingly, there are Mitigation Measures as well as
Environmental Management Plan (EMP) suggested in the EIA reportto prevent
the bio-diversity of Sundarbans from any harm as the outcome of those
extensive studies. All mitigation measures and EMP provided in the EIA report
shall be implemented properly in all phases of the project.
The project will have no adverse effect on the Biodiversity of Sundarbans. The
Environmental Management Plan (EMP) as provided in the EIA report shall be
implemented properly in all phases of the project.
  <br/><br/>Q30: Land of the minority people has been acquired.
A30: No, there has not been any deficit caused to the minority people regarding land
acquisition. The entire acquired land is vacant low land, mostly used for shrimp
farming.
Moreover, the project location was finalized after due study of alternative sites
and this site was found to be most suitable. Land for the project was acquired by
Govt. of Bangladesh on behalf of BPDB as per the extant rules.
  <br/><br/>Q31: Project site has been selected before approval of EIA.
A31: As per the law of Bangladesh, a proponent should get land acquired or owned
before getting EIA approval from DoE. EIA approval needed for starting of
construction activities of a project. Therefore as per the extant rules of GoB the
site was identified and Initial Environment Examination (IEE) Study was carried
out. Application for site clearance certificate alongwith IEE was submitted to
DoE and Site/Location clearance certificate was issued by DoE on 23.05.2011
upon evaluation of alternative sites reported in IEE.
  <br/><br/>Q32: Less negative effect of the Power plant on Sundarbans has been shown in EIA
study.
A32: The EIA study has been conducted following the ToR approved by DoE.
Extensive studies, surveys and researches have been performed regarding to
identify all possible impacts that might occur due to this project. The approach
and methodology adopted for this study complies with the DoE and World Bank
/ IFC guidelines of Environmental Impact Assessment. EIA includes
comprehensive study with detail investigation as per the procedure defined in
ECR 1997. The international standardized multidisciplinary approaches &tools
and techniques of Physical, Water resources, Agriculture, Land and soil,
Fisheries, Ecology and Socio-economic surveys and investigation were
adopted. Based on the above scientific study, effect of the plant on Sundarbans
has been found to be minimal.
  <br/><br/>Q33: It is planned to construct 2600 MW Power Plant at Rampal. But the EIA study
has been carried out for 1320 MW? <br/>
A33: GoB has planned to set up a 1320 MW coal based thermal power plant in
phase-I at Rampal. Therefore, EIA study has been carried out for 1320 MW
STPP. At present there is no proposal to set up any additional thermalpower
plant at Rampal.
  <br/><br/>Q34: Sound effects of the Construction equipment, machineries and vehicles have
not been considered.
A34: All the potential sources of noise during pre-construction, construction and
operation stages have been identified in the EIA report. These have been
considered and are presented in the EIA report with impacts and EMP during
construction period. The projectâ€™s planted greenbelt and boundary wall will act
as noise barrier as well. All the equipment inside the plant area shall operate
within the specified sound level meeting the environmental norms.
  <br/><br/>Q35: During Cyclonic weather, wind may flow in any direction. At that time and during
winter flue gas from the Power Plant will destroy the Sundarbans.
A35: No, Sundarbans will not be harmed by any means due to the emission from the
project at any season.
Firstly, BIFPCL will use imported coal having High Gross Caloric Value (GCV),
very low sulphur content, in the project for power generation which will limit the
SOx production to a low quantum at source. Also, advanced low NOx burners
are being installed in the plant to reduce the NOx generation to a substantially
lower level.
Keeping the negative impact upon Sundarbans in consideration, for further
reduction ofSOx in the flue gas to be emitted from the chimney, a modern wetlimestone
based Flue Gas Desulphurization System (FGD) is being installed.
Moreover, during Cyclonic weather the emitted flue gas will be quickly dispersed
due to high speed and turbulenceof wind. The nearest tip of Sundarbans is at 14
Km Southeast of the plant stack. During winter air flows from North to south.
However, due to 275 M high Chimney, flue gas will disseminate before reaching
Sundarbans. Therefore, the proposed project should not pose any threats as to
destruction of the Sundarbans.
T
  <br/><br/>Q36: The Passur and the Sibsa Rivers carry the nutrients for the plants and animals
of Sundarbans. But due to withdrawal of huge amount of water from the Passur
River by the proposed power plant nutrients would be trapped at the upstream
of the river and consequently, Sundarbans would be deprived from valuable
nutrients. As a result Sundarbans would be destroyed.
A36: A closed cycle cooling water system has been envisaged for the project which
would minimize the water requirement. Approximately 0.05% of the lean period
flow of the Pussur River would be withdrawn by the proposed power plant (2.5
m3
/sec of available 6000 m3
/sec). Keeping in view the small quantity of intake
water, trapping of nutrients at upstream of river as apprehended would not be
there and Sundarbans would not be deprived of valuable nutrients. Moreover
Pussuris atidal river.
  <br/><br/>Q37: Salt free water will be used after removal of salt in the proposed Rampal Project.
However, the process of removal of salt is costly. It is questionable whether
there will be enough arrangement to remove salt from water.
A37: Desalination plant is aprerequisite for any thermal power plants.Saline water
cannot be used as cooling water as the primary effect of salt water is to increase
corrosion rates of metal in the cooling tower and cooling system. It also
decreases thermal performance. Therefore, there is provision for Reverse
osmosis as well as De-mineralization plant in our specificationand it would be
implemented to meet project requirements. This is a proven technology and is
being used worldwide for ages.
  <br/><br/>Q38: Fly ash contains toxic heavy minerals like Arsenic, Lead, Mercury, Vanadium,
Selenium, Beryllium, Cadmium, Selenium, Radium etc. These minerals will
contaminate the soil and ground water by leaching.
A38: The BIFPCL will use imported coal with high GCV, low ash, low Sulphur content.
The concentration of toxic minerals / metals in coal is minimal and are present
as trace elements. High efficiency ESP (for capturing of Fly ash), modern dry
bottom ash handling and collection technology is being implemented. The ash
(both bottom ash and fly ash) will be collected in dry form. Fly ash will be
pneumatically conveyed from ESP hopper through conveying pipeline. Bottom
ash will be conveyed through closed pipe conveyer from dry bottom ash system
at boiler area. The entire ash will thereafter be collected in closed silo fitted with
bag filter and unloaded to closed truck/ closed barges through pneumatic
conveying pipe for further transportation to ash utility industry.
In case when 100% ash will not be utilized, provision of discharge of ash to
contingency ash pond (developed with properly designed impermeable layers to
prevent leaching / seepage) through High concentration slurry disposal system
is there. The settled high concentrated slurry shall convert to ash stone thus
creating an impervious layer in the ash pond. Hence there will be zero water
leakage to surface and ground water system and Hazardous components shall
remain embedded.
Therefore there is no scope of contamination of heavy metal into the ground
water.
  <br/><br/>Q39: Due to movement of Vehicle and during operation of the plant, noise will be
produced. Moreover, during unloading and transporting of coal noise would also
be created. Would the green belt be able to mitigate noise pollution? <br/>
A39: Yes, the green belt be able to mitigate noise pollution. All the equipment inside
the plant area shall operate within the specified sound level meeting the
environmental norms and the Green belt will further assist in preventing the
spread of the noise beyond the plant boundary. Additionally the project has
been designed to meet/better IFC guidelines with respect to the noise generated
from all possible sources. As far as noise pollution due to coal
unloading/transportation is concerned, BIFPCL shall be using vessels complying
to IMO norms which shall be of low noise type.
  <br/><br/>Q40: Aerosol dispersed from the Cooling tower is favorable for growth of bacteria
causing pneumonia of the local people.<br/>
A40: Cooling Tower shall be equipped with mist eliminator which will arrest aerosol
from the Cooling Tower. Thus there will be no scope for bacterial infection and
hence it will not cause pneumonia to the local people.
  <br/><br/>Q41: Due to lighterage of coal at Akram point, water and air of Sundarbans will be
polluted.<br/>
A41: No, Sundarbans will not be harmed due to the transportation of coal.
The trans-shipment of Coal will be done by environment friendly Floating
Transfer Station (FTS), which will have anti spillage plate, dust suppression
system, covered conveyer belt as inbuilt mitigation measures. So chances of
water and air pollution are very remote.<br/>
  <br/><br/>Q42: Wave created by the coal carrying ships will erode the river bank.
A42: No, the effect of few coal carrying ships on the river bank is fairly insignificant.
Coal will be transported through the existing Maritime route of Mongla port, which
is being used for decades and the vessels plying through MPA route shall follow
all the rules as stipulated by MPA. On an average only one coal carrying vessel
shall ply across the River Passur per day.
Keeping into consideration, the number of vessels plying across the Passur
channel at present, impact due to Rampal project will be very insignificant.
  <br/><br/>Q43: Search Light of the Ship will disturb the wild animals of Sundarbans.<br/>
A43: As per the daily requirement of coal BIFPCL plans to use on an average one
numberof modern sea-worthy vessel (â€œmini-shipâ€), tailor made as per IMO
classifying norms, environmental friendly and designed for zero effluent
discharge, low SOx emission, low noise pollution, night vision and GPS. Coal
will be transportedthrough the existing Maritime route of Mongla port, which is
being used for decades and thevesselsplying through MPA route shall follow all
the rules as stipulated by MPA. Hence there will be negligible impact on the wild
life of Sundarbans.
  <br/><br/>Q44: People are very concerned on the cost of production of electricity at Rampal. If
all suggested EMP is implemented cost would go up which may not be
affordable to the people.<br/>
A44: BIFPCL is committed to provide reliable,environmentfriendly and affordable
power to the people of Bangladesh.
Modern technology/equipment are being used to make this project safe &
Environment friendly and the cost of these measures have been included in the
EPC contract. Approximately, 70-80% of the project cost will be covered through
a long term loan with very low spread, from Indian bank.
Financial analysis of the project has been carried out taking the aforementioned
aspects as well as the EMP into account. It has been found that the project is
not only economically viable, it is going to be one of the cheapest power plant of
its kind in Bangladesh and hence will be consistent with the objective of
generating affordable power.
  <br/><br/>
                          </div>
                           </div>
                           </div>
                      </div>
                         <div class="vue-misc" id="divOrg" visible="true" runat="server">
                    
                      <div class="row">
                           <div id="people"></div>
                      <%--    <div id="container">
    <div id="people"></div>
   </div><canvas id="chart" width="800" height="600" ></canvas>--%>
                          </div>
                             </div>
                  </div>
              
            </div>
        </div>
      </section>
            <!-- END MAIN CONTENT-->
            <!-- END PAGE CONTAINER-->
       
    </section>
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
   
    <script>
         function call(phoneNumberToCall) {
             // Call the random number
            window.open("tel:" + phoneNumberToCall);

        }
    </script>
    
    
</body>
</html>

