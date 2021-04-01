<%@ Page Language="VB" AutoEventWireup="false" CodeFile="hrCareer.aspx.vb" Inherits="hrCareer" ValidateRequest="false" %>

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
    <link href='favicon.ico' rel='icon' type='image/x-icon' />

    <!-- Title Page-->
    <title>BIFPCL Careers</title>

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
    <link href='favicon.ico' rel='icon' type='image/x-icon' />
    <style>
        .watermark-image {
            content: "";
            background: url(https://www.bifpcl.com/images/logo_thumb.png) no-repeat;
            background-size: 450px 420px;
            /*opacity: 0.2;*/
            top: 400px;
            left: 660px;
            /*bottom: 0;
  right: 0;*/
            width: 450px;
            height: 420px;
            position: absolute;
            /*z-index: 1;*/
        }
        .blink {
  animation: blinker 2s step-start infinite;
  background-color:yellow;
}

@keyframes blinker {
  50% {
    opacity: 50;
    background-color:deeppink;
  }
}
    </style>
</head>
<body>
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
                        <div class="noti__item js-item-menu" style="margin-left: -100px;" id="divNotificationMobile" runat="server" />
                    </div>

                    <div class="account-wrap" id="divLoginMobile" runat="server">
                    </div>
                </div>
            </div>
            <!-- END HEADER MOBILE -->

            <!-- PAGE CONTENT-->
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
                                            <li class="list-inline-item">Careers</li>
                                        </ul>
                                    </div>
                                    <div class="rs-select2--dark rs-select2--sm rs-select2--dark2" style="width: 300px;">
                                        <select id="divQuickLinks" class="js-select2" name="type" onchange="go()">
                                       
  <option value="" selected="selected">Quick Links</option>
  
                                              <option value="hrCareer.aspx?mode=adminpage">Admin IT</option>
  <option value="hrCareer.aspx?mode=report">0 Reports</option>
<option value="hrCareer.aspx?mode=postjob">1 Post/Edit Job</option> 
<option value="hrCareer.aspx?mode=admin">2 Admin HR</option>  
 <option value="hrCareer.aspx?mode=rating">3 Set Ratings</option>
    <option value="hrCareer.aspx?mode=int">4 Conduct Interview</option>
    <option value="hrCareer.aspx?mode=intDashboard">5 Interviewer Dashboard</option>
    <option value="hrCareer.aspx?mode=reportlive">6 Live Inerview for MD</option>
                                          
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
                             <a name="help"></a><span>Recruitment App</span>
                                </h1>
                                <div class="sufee-alert alert with-close alert-primary fade show">
                                    <a href="hrCareer.aspx">
                                        <button type="button" class="btn btn-link btn-sm">
                                            <%-- <i class="fa fa-link"></i>  Back</button></a>--%>
                                            <a href="upload/HR/manual/BIFPCL130719220909.pdf" target="_blank">
                                                <button type="button" class="btn btn-outline-primary btn-sm">
                                                    <i class="fa fa-lightbulb-o"></i>Instructions PDF</button>
                                            </a>
                                            <a href="upload/HR/manual/BIFPCL160719223052.pdf" target="_blank">
                                                <button type="button" class="btn btn-outline-secondary btn-sm">
                                                    <i class="fa fa-dollar"></i>Payment Process</button>
                                            </a>
                                            <a href="https://youtu.be/kM_Wz9utMK0" target="_blank">
                                                <button type="button" class="btn btn-outline-danger btn-sm">
                                                    <i class="fa fa-rss"></i>Instructions Video(English/Bengali)</button>
                                            </a>

                                            <span class="badge badge-pill badge-warning">Help</span>
                                            For any technical help, please drop a mail to <b><a href="mailto:help@bifpcl.com">Help@bifpcl.com</a></b>
                                </div>
                                <hr class="line-seprate">
                                <asp:Label ID="lbError" runat="server" Text="" ForeColor="red"></asp:Label>

                            </div>
                        </div>
                    </div>
                </section>
                <!-- END WELCOME-->

                <!-- STATISTIC-->
                <section class="statistic statistic2">
                    <div class="container">
                        <asp:Panel ID="pnlHome" Visible="false" runat="server">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="card border border-success">
                                        <div class="card-header">
                                            <strong class="card-title">Updates !!!</strong>
                                        </div>
                                        <div class="card-body" style="text-align: justify;">
                                            <p>All career related information shall be available on this website with frequent updates. It is requested to not send queries and keep checking career section to get updates. </p>
                                            <h4>
                                                <img src="images/loading1.gif" width="50px" />Information for Applicants:</h4>
                                            <ul class="vue-list-inner" id="divUpdates" runat="server"  style="margin-left: 30px;">
                                          
                                             <%--  <b>Update 1:</b> Admit Cards for Post of <b>Electrical & Mechanical Engineers </b> are available. To Download <a href="hrCareer.aspx?mode=printadmit" >Click Here</a>.
                                            
                                            <br />--%>
                                                  <b>Update 1:</b> Results of Written Examination for Post of <b>Electrical & Mechanical Engineers </b> and Admit Cards for Via Voce are available.<a href="hrCareer.aspx?mode=printadmitInt" >Click Here</a>   <%--<a href="hrCareer.aspx?mode=printadmitInt">Click Here</a>--%> .
                                                <br />(Selected candidates have been already notified by SMS/Email).
     </ul>
                                        </div>
                                    </div>
                                    <div class="card border border-secondary" id="divCareer" runat="server">
                                        <div class="card-header">
                                            <strong class="card-title">CAREER OPPORTUNITY IN POWER SECTOR</strong>
                                        </div>
                                        <div class="card-body" id="divOpport" runat="server" style="text-align: justify;">
                                       <%--     Bangladesh-India Friendship Power Company (Pvt.) Limited (BIFPCL), a 50:50 Joint Venture Company of Bangladesh Power Development Board (BPDB), Bangladesh and NTPC Limited(NTPC), India is setting up state of the art 2x660 MW Maitree Super Thermal Power Project at Rampal in Bagerhat District of Bangladesh. To fuel its ambitious growth plan, BIFPCL is looking for promising, energetic and dedicated young engineers for immediate appointment on contract basis to the  posts available on website and invites applications from only Bangladeshi nationals.
                                        <h4>Compensation Package:</h4>
                                            <ul class="vue-list-inner" style="margin-left: 30px;">
                                                <li>Basic Salary, House Rent allowance, Medical Benefits, Bonus, CPF, Gratuity and other Fringe Benefits will be given as per the policy of BIFPCL</li>
                                                <li>Income Tax has to be paid by the employee.</li>
                                            </ul>
                                            <h4>Nature of the Service: </h4>
                                            <p>The service is purely contractual. The initial contract period of the service shall be for 03 (Three) years and is renewable for further period(s) subject to satisfactory performance</p>
                                       --%> </div>
                                    </div>
                                    <div class="card border border-success" id="divHowTo" runat="server">
                                        <div class="card-header">
                                            <strong class="card-title">How to Apply:</strong>
                                        </div>
                                        <div class="card-body" id="divHowToApply" runat="server"  style="text-align: justify;">
                                         <%-- <img src="images/career.png" />
                                            <ol class="vue-ordered" style="margin-left: 10px">
                                                <li>Candidates need to <b>apply online</b> for the posts by visiting <code style="font-weight: bold; font-size: 110%;">https://www.bifpcl.com/hrCareer.aspx</code> .The Online application process will commence from <b>22.07.2019 (Monday)</b> . <a href="#help"><code style="font-weight: bold; font-size: 110%; color: blue;">Click here</code></a> to read Instructions manual or Video.
                             <a href="upload/HR/manual/BIFPCL130719220909.pdf" target="_blank">
                                 <button type="button" class="btn btn-outline-primary btn-sm">
                                     <i class="fa fa-lightbulb-o"></i>Instructions PDF</button>
                             </a>

                                                </li>
                                                <li>Before submitting online application, Candidates must make online payment for <code style="font-weight: bold; font-size: 110%;">BDT. 1000/-</code> payable in favor of <b>“Bangladesh-India Friendship Power Company (Pvt.) Limited” </b>and mention the Transaction ID (Txn. Id) in online application. <a href="upload/HR/manual/BIFPCL160719223052.pdf" target="_blank">Click to Know the Payment Process</a>
                                                    Application shall be rejected on mentioning of wrong or invalid Transaction ID  (Txn. Id).  <a href="upload/HR/manual/BIFPCL160719223052.pdf" target="_blank">
                                                        <button type="button" class="btn btn-outline-secondary btn-sm">
                                                            <i class="fa fa-dollar"></i>Payment Process</button>
                                                    </a>
                                                </li>
                                                <li>Candidates must visit our website <code style="font-weight: bold; font-size: 110%;">https://www.bifpcl.com/hrCareer.aspx</code>, select the job to apply, upload their photograph, Signatures & Attested copy of their Qualifying Degree Certificate. After filling out all details along with payment transaction ID and submitting the application, a <b>UNIQUE APPLICATION NUMBER</b> will be generated.Candidates need to download this filled application which will be in the pdf format, and keep it for future reference. 
                                    </li>

                                                <li>Applications once submitted cannot be corrected. In case of corrections/amendments, candidates will have to fill out another fresh application and follow the same process as explained above.</li>

                                                <li>Incomplete application will not be considered. Only short listed candidates will be contacted.</li>
                                                <li>Candidate must keep the <b>UNIQUE APPLICATION NUMBER</b> for any communication or to download the admit card.</li>
                                                <li>BIFPCL reserves the right to accept or reject any or all applications without assigning any reason whatsoever</li>

                                            </ol>--%>
                                        </div>
                                    </div>
                                    <div class="card border border-primary" id="divTnC" runat="server">
                                        <div class="card-header">
                                            <strong class="card-title">Other General Terms & Conditions:</strong>
                                        </div>
                                        <div class="card-body" id="divTnCApply" runat="server"  style="text-align: justify;">

                                       <%--     <ol class="vue-ordered" style="margin-left: 10px">
                                                <li>These posts are open for Bangladeshi Nationals only. .
                                                </li>
                                                <li>Must have strong Communication Skills in Bengali & English (written & oral) including Computer literacy </li>

                                                <li>No third Division/Class at any stage of the academic career shall be acceptable. </li>
                                                <li>Candidates passed in the grading system must possess at least a GPA 3.5 on a scale of 5.0 & CGPA 3.0 on a scale of 4.0 at all stage of the academic career.
                                                </li>
                                                <li>All eligible qualifications should be from a recognized institution or university</li>
                                                <li>Persons employed in Government/Semi-Government/Autonomous organization(s)/Govt. owned company(ies) should apply through proper channel.</li>
                                                <li>Candidates passed from foreign university(ies)/Institute(s) should have equivalence certificate/result issued from a competent authority recognized by government.</li>
                                                <li>An applicant has to give an undertaking as a part of the application that he/she will join the post, if selected within a period of 02 months from the date of issue of offer letter.</li>
                                                <li>No TA/DA shall be paid for appearing/participating in the recruitment process.</li>
                                                <li>BIFPCL reserves the right to cancel/restrict/enlarge/modify/alter the recruitment/selection process, if need so arises.</li>
                                                <li>BIFPCL reserves the right to shortlist candidates for Written Test/ Interview. Applicants should note that mere fulfillment of minimum eligibility criteria may not ensure consideration for shortlisting for Written Test/Interview. BIFPCL will not entertain any correspondence on this subject and decision of BIFPCL will be final in all matters. </li>
                                                <li>All computations of Age, Experience etc shall be as on last date of submission of application i.e. <b>22nd August 2019</b></li>
                                                <li>In case of departmental candidates, age limit is relaxable</li>
                                                <li>Age limit for sons/grand-sons and daughters/grand-daughters of freedom fighters and martyred freedom fighters shall be 32 years in place of 30 years (wherever applicable). Only at the time of joining (If selected) these candidates have to submit attested copies of certificates issued to Freedom Fighters/ Martyred Freedom Fighters by the appropriate authority. Also, these candidates have to submit certificate (In Original) issued from the respective Union Parishad Chairman/ Ward Commissioner of City Corporation/ Pourashava Mayor/ Counselor; mentioning their relationship with the Freedom Fighters/ Martyred Freedom Fighters.  </li>
                                                <li>Application, downloaded with <b>Unique Application Number</b> must be kept for future reference and for downloading of Admit Card. <b>Do not send any printed copy by Post.</b>
                                                    <br />
                                                   
                                                </li>
                                                <li><b>Last date of receipt of online application is: 22nd August 2019 (11:59 P.M BST) </b></li>
                                            </ol>
                                            <address class="mt-3">
                                                <b>Sd/-</b><br />
                                                <strong>Chief Human Resources Officer</strong>
                                                <br />
                                                Human Resource Department
                                                <br />
                                                BIFPCL
                                            </address>--%>
                                        </div>
                                    </div>
                                </div>
                                <div id="divApply" runat="server" visible="false">
                                    <div class="col-md-12">
                                        <a href="hrCareer.aspx?mode=opening">
                                            <button type="button" class="btn btn-outline-primary btn-lg btn-block">Click here to see Openings & Apply Online</button></a>
                                        <img src="images/arrowright.gif" width="100px" />
                                    </div>
                                    <div class="col-md-6"></div>
                                    <div class="col-md-6">
                                        <a href="hrCareer.aspx?mode=opening">
                                            <button type="button" class="btn btn-outline-primary btn-lg btn-block">বিস্তারিত দেখতে এখানে ক্লিক করুন এবং অনলাইনে আবেদন করুন</button></a>

                                    </div>
                                </div>
                                <div id="divLinks" runat="server" visible="false">
                                    <div class="col-md-6 col-lg-3">
                                        <a style="display: block" href="hrCareer.aspx?mode=opening">
                                            <div class="statistic__item statistic__item--green">
                                                <h2 class="number">Openings & Apply</h2>
                                                <span class="desc">Find Vacancy and Apply.</span>
                                                <div class="icon" style="bottom: 0px; right: 0px;">
                                                    <i class="zmdi zmdi-card" style="opacity: .4"></i>
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                    <div class="col-md-6 col-lg-3">
                                        <a style="display: block" href="hrCareer.aspx?mode=report">
                                            <div class="statistic__item statistic__item--red" style="background: #20c997">
                                                <h2 class="number">Admin Report</h2>
                                                <span class="desc">Get various reports</span>
                                                <div class="icon" style="bottom: 0px; right: 0px;">
                                                    <i class="zmdi zmdi-format-list-bulleted" style="opacity: .4"></i>
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                    <div class="col-md-6 col-lg-3">
                                        <a style="display: block" href="hrCareer.aspx?mode=admin">
                                            <div class="statistic__item statistic__item--blue">
                                                <h2 class="number">Admin Section</h2>
                                                <span class="desc">Perform Admin Task</span>
                                                <div class="icon" style="bottom: 0px; right: 0px;">
                                                    <i class="zmdi zmdi-wrench" style="opacity: .4"></i>
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlConfirm" Visible="false" runat="server">
                            <div class="row">
                                <div class=" col-md-12">
                                    <div class="card border border-success">
                                        <div class="card-header">
                                            <strong class="card-title">Post Details:</strong>
                                            Post ID    
                                            <asp:Label ID="lbConfirmJobID" runat="server" Text="" ForeColor="Green"></asp:Label>

                                        </div>
                                        <div class="card-body" id="divJobDetails" runat="server">
                                            <p class="card-text">
                                                <b>Name of Post</b>:	Demo Post for Testing (IT)
                                                <br />
                                                <b>Qualification</b>:Engineering degree in Quantum Computing 
                                                <br />
                                                <b>Language Proficiency</b>: Africaans
                                                <br />
                                                <b>Experience</b>: 30-50 years
                                                <br />
                                                <b>Skills</b>:•	Knowledge of Network (LAN,WAN,WIFI, Radio Link, Fiber Optic, Configuring VPN, VLAN, NAT, Firewall, Wifi Access Point, Router, Switch, NAS, Windows Server, Load balancer, Unified Threat Management)
                                                <br />

                                            </p>
                                        </div>
                                    </div>
                                    <div class="card">
                                        <%--  <asp:UpdatePanel ID="upId" runat="server" UpdateMode="Conditional">
                                  <Triggers>--%>
                                        <%-- <asp:PostBackTrigger ControlID="lbDownloadWeekly" />--%>
                                        <%--  <asp:AsyncPostBackTrigger ControlID="cbConfirm" EventName="SelectedIndexChanged" />--%>
                                        <%--</Triggers>
                                  <ContentTemplate>--%>

                                        <div class="card-header">
                                            <h4>Confirmation</h4>
                                        </div>
                                        <div class="card-body">
                                            <p class="text-muted m-b-15">
                                                Please ensure you have following things ready before filling up the job application form. 
											<br />
                                                <code>Arrange if you don't have any of these </code>Click on relevent check box:
                                            </p>
                                            <asp:CheckBoxList ID="cbConfirm" runat="server">
                                                <asp:ListItem Value="1">I have scanned copy of my passport size photo in JPG format for attachment.<br /> (আমি সংযুক্তির জন্য JPG বিন্যাসে আমার পাসপোর্ট সাইজ ছবির অনুলিপি স্ক্যান করেছি)  <a href="upload/HR/manual/BIFPCL140719042949.png" target="_blank">  <button type="button" class="btn btn-outline-success btn-sm">
                                            <i class="fa fa-picture-o"></i>  Sample</button> </a> </asp:ListItem>
                                                <asp:ListItem Value="2">I have scanned copy of my signature in JPG format for attachment.<br />(আমি সংযুক্তির জন্য JPG বিন্যাসে আমার স্বাক্ষরের অনুলিপি স্ক্যান করেছি।)   <a href="upload/HR/manual/BIFPCL140719042949.png" target="_blank">  <button type="button" class="btn btn-outline-success btn-sm">
                                            <i class="fa fa-picture-o"></i>  Sample</button> </a></asp:ListItem>
                                                <asp:ListItem Value="3">I have scanned copy of my Qualification Degree in PDF format for attachment.<br />(আমি সংযুক্তির জন্য PDF ফরম্যাটে আমার যোগ্যতা ডিগ্রীর কপি স্ক্যান করেছি।) <a href="upload/HR/manual/BIFPCL140719042949.png" target="_blank">  <button type="button" class="btn btn-outline-success btn-sm">
                                            <i class="fa fa-picture-o"></i>  Sample</button> </a></asp:ListItem>
                                                <asp:ListItem Value="4">I have access to my email account<br />(আমার ইমেইল একাউন্টের অ্যাক্সেস আছে।)</asp:ListItem>
                                                <asp:ListItem Value="5">I have access to my mobile number<br />(আমার মোবাইল নম্বরের অ্যাক্সেস আছে।)</asp:ListItem>
                                                <asp:ListItem Value="6">I have made online payment as mentioned in instruction page and have payment Transaction ID  (Txn. Id). <br />(আমি নির্দেশনা পৃষ্ঠাতে উল্লেখিত নিয়মানুযায়ী পেমেন্ট প্রদান করেছি ও আমার সেই লেনদেনের আইডি আছে।)    <a href="upload/HR/manual/BIFPCL160719223052.pdf" target="_blank">  <button type="button" class="btn btn-outline-secondary btn-sm">
                                            <i class="fa fa-dollar"></i>  Payment Process</button> </a></asp:ListItem>
                                            </asp:CheckBoxList>
                                            <br />
                                            <div class=" col-md-6">
                                                <asp:Button ID="btnConfirm" Text="Confirm & Proceed for Application" runat="server" class="au-btn au-btn--block au-btn--green m-b-20" />
                                            </div>
                                            <br />
                                            <asp:Label ID="lbMessageConfirm" runat="server" Text="" ForeColor="red"></asp:Label><br />

                                        </div>
                                        <%--    </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlOpenings" Visible="false" runat="server">
                            <div class="col-md-12">
                                <h3>Apply against the post</h3>

                                <asp:Label ID="lbMsgOpening" runat="server" Text="No Auth"></asp:Label>
                                <asp:GridView ID="gvOpening" runat="server"
                                    CssClass="table-responsive table table-borderless table-striped  table--no-card m-b-30"
                                    AutoGenerateColumns="false" AllowPaging="False" PageSize="11" AllowCustomPaging="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <%--  <th colspan="6">Category</th>--%>

                                                <tr class="gvHeader">

                                                    <th></th>
                                                    <th>!</th>
                                                    <th>Name of Post</th>
                                                    <th>Post ID</th>
                                                    <th>Age* (Max years)</th>
                                                    <th>No of Post</th>
                                                    <%--   <th>Location</th>--%>
                                                    <%--  <th>Last Date to Apply</th>--%>
                                                    <%-- <th>Details</th>--%>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <td>
                                                    <asp:Button ID="btnEdit" runat="server" Text="View & Apply" class="btn btn-success btn-sm" CommandArgument='<%# Eval("jobid")%>' /></td>
                                                <td><%# Eval("post")%></td>
                                                <td><%# Eval("jobid")%></td>
                                                <td><%# Eval("age")%></td>
                                                <td><%# Eval("noofpost")%></td>
                                                <%--  <td><%# Eval("location")%></td>--%>
                                                <%--   <td><%# Eval("payscale")%></td>--%>
                                                <%-- <td><%# Eval("last_dt")%></td>--%>
                                                <%--   <td><a href='upload/HR/Career/<%#  Eval("file") %>' target='_blank' > View Ad </a></td>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>
                                * Note: Age relaxation applicable as per point 14 of Other General Terms & Conditions given in previous page.
                         <br />

                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlPostJob" Visible="false" runat="server">
                            <div class="col-md-12">
                                <h3>Post Jobs</h3>

                                Select Recruitment Phase:
                                <asp:DropDownList ID="ddlPostPhase" AutoPostBack="true" runat="server">
                                    <asp:ListItem Value="Phase1">Phase1</asp:ListItem>
                                    <asp:ListItem Value="Phase2" Selected="true">Phase2</asp:ListItem>
                                    <asp:ListItem Value="Phase3">Phase3</asp:ListItem>
                                    <asp:ListItem Value="Phase4">Phase4</asp:ListItem>
                                    <asp:ListItem Value="Phase5">Phase5</asp:ListItem>
                                    <asp:ListItem Value="Phase6">Phase6</asp:ListItem>
                                    <asp:ListItem Value="Phase7">Phase7</asp:ListItem>
                                    <asp:ListItem Value="Phase8">Phase8</asp:ListItem>
                                    <asp:ListItem Value="Phase9">Phase9</asp:ListItem>
                                    <asp:ListItem Value="Phase10">Phase10</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:TextBox ID="txtJobPost" placeholder="Name of Post" MaxLength="250" Width="500px" class="au-input au-input--full" runat="server" />
                                <br />
                                <br />
                                <asp:TextBox ID="txtJobDetail" placeholder="Job Qulification" Width="500px" Height="100px" TextMode="multiline" MaxLength="350" class="au-input au-input--full" runat="server" />
                                <br />
                                <br />
                                <asp:TextBox ID="txtJobExp" Text="Prior experience in a Power Sector will be an advantage" placeholder="Experience" Width="500px" Height="100px" TextMode="multiline" MaxLength="350" class="au-input au-input--full" runat="server" />
                                <br />
                                <br />
                                <asp:TextBox ID="txtJobAddQual" Text="NA" placeholder="Additional Qualification" Width="500px" Height="150px" TextMode="multiline" MaxLength="350" class="au-input au-input--full" runat="server" />
                                <br />
                                <br />
                                <asp:TextBox ID="txtJobPrintOrder" placeholder="Print Order" MaxLength="250" Width="150px" class="au-input au-input--full" runat="server" />
                                <br />
                                <br />
                                <asp:TextBox ID="txtJobAge" placeholder="Max Age" MaxLength="250" Width="150px" class="au-input au-input--full" runat="server" />
                                <br />
                                <br />
                                <asp:TextBox ID="txtJobNumbers" placeholder="No Of Post" MaxLength="250" Width="100px" class="au-input au-input--full" runat="server" />
                                <br />
                                <asp:TextBox ID="txtJobPayscale" Text="Basic Salary: 52,000/-" placeholder="Salary" MaxLength="250" Width="500px" class="au-input au-input--full" runat="server" />
                                <label>Last Date to Apply</label>
                                *<asp:TextBox ID="txtJobLastDt" runat="server" MaxLength="15" class="au-input au-input--full" placeholder="Date" Width="200px" />
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd.MM.yyyy" TargetControlID="txtJobLastDt" />
                                <br /> Min Qualification for Rating Formula: <asp:DropDownList ID="ddlMinQual" AutoPostBack="false" runat="server">
                                    <asp:ListItem Value="Diploma" >Diploma</asp:ListItem>
                                    <asp:ListItem Value="Graduate" Selected="true" >Graduate</asp:ListItem>
                                    <asp:ListItem Value="PostGraduate" >Post Graduate</asp:ListItem>
                                    </asp:DropDownList>
                                <%--  <br /> <br />      <label>Attach document of vacancy(Single PDF)</label> 
      <div id="divAttachments" runat="server" /> 
                   
                   <div id="fileatt" runat="server"  >
            <input type="file" name="attachment" runat="server" id="attachment" onchange="document.getElementById('moreUploadsLink').style.display = 'none';"  />
            </div>
      <input type="hidden" value="0" id="fileCount" />
      <div id="fileDiv">
      </div>
      <div id="moreUploadsLink" style="display: none">
            <a href="javascript:addFile();"></a>
      </div>--%>
                                <br />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnUpload_Click" class="au-btn au-btn--block au-btn--green m-b-20" />
                                <asp:Label ID="lbMsgPost" runat="server" Text="" ForeColor="red"></asp:Label>
                                <h5>Post Update</h5>
                                <p>
                                    <br />
                                    Please maintain  record up to date. .</p>
                                <asp:GridView ID="GridView1" CssClass="table-responsive table-striped " runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource2"
                                    DataKeyNames="jobid" EmptyDataText="No records has been added." Caption="Set 1 to enable set 0 to disable" CaptionAlign="Top">
                                    <Columns>
                                        <asp:CommandField ButtonType="Link" ShowEditButton="true" />
                                        <%-- <asp:BoundField DataField="activity" HeaderText="Activity" ReadOnly="true" />--%>
                                        <%--  <asp:BoundField DataField="progdate" HeaderText="Rep Date" ReadOnly="true" />--%>
                                        <%--<asp:BoundField DataField="Scope" HeaderText="Scope" ReadOnly="true" />--%>
                                        <asp:BoundField DataField="jobid" HeaderText="JobID" ReadOnly="true" />
                                        <asp:TemplateField HeaderText="Post" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lblvehicle" Width="200" runat="server" Text='<%# Eval("post")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbvehicle" Width="200" runat="server" Text='<%# Bind("post")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Min Qualification" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMinQual" Width="50" runat="server" Text='<%# Eval("minqual")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlminqualupdate" runat="server" SelectedValue='<%# Bind("minqual")%>'>
                                                    <asp:ListItem Value="Graduate">Graduate</asp:ListItem>
                                                    <asp:ListItem Value="PostGraduate">PostGraduate</asp:ListItem>
                                                </asp:DropDownList>

                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Written Vanue" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_vanue_w" Width="200" runat="server" Text='<%# Eval("vanue_w")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tb_vanue_w" Width="200" runat="server" Text='<%# Bind("vanue_w")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Written Date" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_date_w" Width="200" runat="server" Text='<%# Eval("date_w")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tb_date_w" Width="200" runat="server" Text='<%# Bind("date_w")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Written Time" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_time_w" Width="200" runat="server" Text='<%# Eval("time_w")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tb_time_w" Width="200" runat="server" Text='<%# Bind("time_w")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField HeaderText="Int Vanue" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_vanue_i" Width="200" runat="server" Text='<%# Eval("vanue_i")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tb_vanue_i" Width="200" runat="server" Text='<%# Bind("vanue_i")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Admit Card Issue Date" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_date_i" Width="200" runat="server" Text='<%# Eval("date_i")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tb_date_i" Width="200" runat="server" Text='<%# Bind("date_i")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField HeaderText="Int Time" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_time_i" Width="200" runat="server" Text='<%# Eval("time_i")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tb_time_i" Width="200" runat="server" Text='<%# Bind("time_i")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="phase" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lblphase" Width="200" runat="server" Text='<%# Eval("phase")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbphase" Width="200" runat="server" Text='<%# Bind("phase")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="printorder" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lblprintorder" Width="200" runat="server" Text='<%# Eval("printorder")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbprintorder" Width="200" runat="server" Text='<%# Bind("printorder")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="age" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lblage" Width="200" runat="server" Text='<%# Eval("age")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbage" Width="200" runat="server" Text='<%# Bind("age")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="noofpost" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnoofpost" Width="200" runat="server" Text='<%# Eval("noofpost")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbnoofpost" Width="200" runat="server" Text='<%# Bind("noofpost")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="qual" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lblqual" Width="200" runat="server" Text='<%# Eval("qual")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbqual" Width="200" runat="server" Text='<%# Bind("qual")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="exp" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lblexp" Width="200" runat="server" Text='<%# Eval("exp")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbexp" Width="200" runat="server" Text='<%# Bind("exp")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="addnlqual" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lbladdnlqual" Width="200" runat="server" Text='<%# Eval("addnlqual")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbaddnlqual" Width="200" runat="server" Text='<%# Bind("addnlqual")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Date" ItemStyle-Width="300">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldriver" Width="300" runat="server" Text='<%# Eval("last_dt")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbdriver" Width="300" runat="server" Text='<%# Bind("last_dt")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remove Job" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDel" Width="50" runat="server" Text='<%# Eval("del")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlDel" runat="server" SelectedValue='<%# Bind("del")%>'>
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                </asp:DropDownList>

                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:appsdb  %>"
                                    ProviderName="System.Data.SQLite"
                                    SelectCommand="SELECT jobid, phase, printorder, post,vanue_w, vanue_i, date_w, date_i, time_w, time_i, age, noofpost, qual, exp, addnlqual, last_dt, del, minqual from careers_jobs where phase=@phase order by del asc"
                                    UpdateCommand="update  careers_jobs set   post=@post, vanue_w=@vanue_w,vanue_i=@vanue_i,date_w=@date_w,date_i=@date_i,time_w=@time_w,time_i=@time_i, phase=@phase, printorder=@printorder,  age=@age, noofpost=@noofpost, qual=@qual, exp=@exp, addnlqual=@addnlqual, last_dt=@last_dt, del=@del, minqual=@minqual where jobid=@jobid">

                                    <UpdateParameters>
                                        <asp:Parameter Name="jobid" Type="Double" />
                                        <asp:Parameter Name="post" Type="String" />
                                        <asp:Parameter Name="vanue_w" Type="String" />
                                        <asp:Parameter Name="vanue_i" Type="String" />
                                        <asp:Parameter Name="date_w" Type="String" />
                                        <asp:Parameter Name="date_i" Type="String" />
                                        <asp:Parameter Name="time_w" Type="String" />
                                        <asp:Parameter Name="time_i" Type="String" />
                                        <asp:Parameter Name="phase" Type="String" />
                                        <asp:Parameter Name="printorder" Type="String" />
                                        <asp:Parameter Name="age" Type="String" />
                                        <asp:Parameter Name="noofpost" Type="String" />
                                        <asp:Parameter Name="qual" Type="String" />
                                        <asp:Parameter Name="exp" Type="String" />
                                        <asp:Parameter Name="addnlqual" Type="String" />
                                        <asp:Parameter Name="last_dt" Type="String" />
                                        <asp:Parameter Name="del" Type="String" />
                                         <asp:Parameter Name="minqual" Type="String" />
                                    </UpdateParameters>

                                    <SelectParameters>
                                        <asp:Parameter Name="phase" Type="string" />
                                        <%--  <asp:Parameter Name="unit" Type="Int32" />--%>
                                        <%--<asp:Parameter Name="priority" Type="Int32" />--%>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlPrintApp" Visible="false" runat="server">
                            <div class="row">
                                <div class=" col-md-12">
                                    <h3 class="mb-3">Verify Details </h3>
                                    <%--   <input class='btn btn-info m-l-10 m-b-10' type="button" onclick="PrintDiv();" value="click to Print" />--%>
                             Note: Write down your application Number for future correspondence. Take the Print and submit the documents with application fee.
                            <aside class="profile-nav alt" id="divProfile" runat="server">
                                <%--<section class="card">
                                        <div class="card-header user-header alt bg-light">
                                            <div class="media">
                                                <a href="#">
                                                    <img class="align-self-center rounded-circle mr-3" style="width:85px; height:85px;" alt="" src="images/icon/avatar-01.jpg">
                                                </a>
                                                <div class="media-body">
                                                    <h2 class="text-dark display-6">Jim Doe</h2>
                                                    <p>Project Manager</p>
                                                </div>
                                            </div>
                                        </div>


                                        <ul class="list-group list-group-flush">
                                            <li class="list-group-item">
                                                <code>Mail</code>:xxx
                                            </li>
                                            <li class="list-group-item">
                                                <code>Mail</code>:xxx
                                            </li>
                                              </ul>
   </section>--%>
                            </aside>
                                    <div class="col col-md-3">
                                        <asp:Button ID="btnSubmitPrint" runat="server" Text="Submit & Download PDF" Visible="True" class="au-btn au-btn--block au-btn--green m-b-20" />
                                        <asp:Button ID="btnDownloadPDFAdmin" runat="server" Text="Download PDF" Visible="False" class="au-btn au-btn--block au-btn--green m-b-20" />

                                    </div>
                                    <div class="col col-md-3">
                                        <asp:Button ID="btnModifyPrint" runat="server" Text="Go back & Modify" Visible="True" class="au-btn au-btn--block au-btn--blue m-b-20" />

                                    </div>

                                    Note: On Submit data will be saved and PDF will be downloaded, you can modify at this stage. 
                            
                              <asp:Label ID="Label1" runat="server" Text="" ForeColor="red"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlSuccess" Visible="false" runat="server">
                            <div class="row">
                                <div class=" col-md-12">
                                    <h3 class="mb-3">Application Submitted </h3>
                                    <%--   <input class='btn btn-info m-l-10 m-b-10' type="button" onclick="PrintDiv();" value="click to Print" />--%>
                             Note:  Click on download pdf button to get the PDF for print.
                            <aside class="profile-nav alt" id="divDone" runat="server">
                            </aside>
                                    <div class="col col-md-3">
                                        <asp:Button ID="btnDownloadPDF" runat="server" Text="Download PDF" Visible="True" class="au-btn au-btn--block au-btn--green m-b-20" />

                                    </div>


                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlAdmitCard" Visible="false" runat="server">
                            <div class="row">
                                <div class=" col-md-12">
                                      <asp:Label ID="lbAdmitStage" runat="server" Text="written"></asp:Label>
                                    &nbsp;  &nbsp;  &nbsp;   <asp:Label ID="lbAdmitPhase" runat="server" Text="Phase1"></asp:Label>
                                    <div id="divCheck1" runat="server" visible="true" >
                                    <h3 class="mb-3">Check Result Section </h3>
                                 Watch Help Video <a href="https://youtu.be/BI0AoksFNko" target="_blank">Click Here</a> <br />
                                    <%--   <input class='btn btn-info m-l-10 m-b-10' type="button" onclick="PrintDiv();" value="click to Print" />--%>
                             Note: Enter details -
                                  
                                    <br />
                                    1. Application Unique ID without space
                            <br />
                                    2. Date of Birth in dd.mm.yyyy format
                             <br />
                                    3. Click on Check Result button to see the result. It will download admit card for print (Only applicable for written/interview stage). 
                                          <br />
                                        4. In case of written admit card you have to verify your CGPA marks once again.
<br/>
Note: It is requested to not send follow up mails if you are not selected.
                                    <br />
                                    <br />
                                    <div class="row form-group">
                                        <div class="col col-md-3">
                                            <label for="text-input" class=" form-control-label">Application Unique ID:</label></div>
                                        <div class="col col-md-9" style="display: flex">
                                            <asp:TextBox ID="txtAdmitUID" MaxLength="20" Width="270px" class="form-control" runat="server" /><span style="border-bottom: 2px solid grey; padding-left: 8px; padding-top: 18px; vertical-align: middle; line-height: 1.25; color: black; font-size: 10px;"> As given in application form</span> </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col col-md-3">
                                            <label for="text-input" class=" form-control-label">Date of Birth(dd.mm.yyyy):</label></div>
                                        <div class="col col-md-9">
                                            <asp:TextBox autocomplete="off" ID="txtAdmitDoB" runat="server" MaxLength="15" class="au-input au-input--full"  Width="200px" />
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd.MM.yyyy" TargetControlID="txtAdmitDoB" />

                                        </div>
                                    </div>
                                    <div class="col col-md-3">
                                        <asp:Button ID="btnAdmitPrint" runat="server" Text="Check Result" Visible="True" class="au-btn au-btn--block au-btn--green m-b-20" />

                                    </div>
                                </div>
                                 <div id="divCheck2" runat="server" visible="false" >
                                         <fieldset style="border-style: none dashed dashed dashed; border-width: thin; border-color: #000080; background-color: #FFFFFF;">
                                    <legend style="font-size: 16px; line-height: 1.7; color: #432d2d;"><b>Verify your CGPA to download Admit Card:</b></legend>
                                     <br /> Note: Please provide correct information. Choose NA if not applicable. <br />
                                             Please round off your CGPA. e.g. if your CGPA is 3.41 select 3.4 from the list.  <br /> <br />
                                   &nbsp;&nbsp;&nbsp;  SSC CGPA:        <asp:DropDownList ID="ddlRateSSCC" runat="server"></asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;   HSC CGPA:     <asp:DropDownList ID="ddlRateHSC" runat="server"></asp:DropDownList>
                                   &nbsp;&nbsp;&nbsp;   Graduation GPA:   <asp:DropDownList ID="ddlRateGrad" runat="server"></asp:DropDownList>  
                                  <br /><br />  &nbsp;&nbsp;&nbsp;     Post Graduation GPA:     <asp:DropDownList ID="ddlRatePG" runat="server"></asp:DropDownList>
                                  &nbsp;&nbsp;&nbsp;    Diploma CGPA:     <asp:DropDownList ID="ddlRateDiploma" runat="server"></asp:DropDownList>
                                 <br /> <br />
                                 &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnAdmitPrintRate" Text="Verify & Download Admit Card" runat="server"  Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                    <br />   . <br /> 
                                </fieldset>
                                     </div>
                                    <asp:Label ID="lbAdmitWarn" runat="server" Text="" ForeColor="red"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                        
                        <asp:Panel ID="pnlNewPass" Visible="false" runat="server" BorderWidth="2px" Style="padding: 10px; background: cornsilk; opacity: 0.9; display: block; position: relative;">
                            <div id="divNew" runat="server" />
                            <div class="watermark-image" style="position: absolute; opacity: 0.2;"></div>
                            <p class="text-muted m-b-15">
                                Please read instructions pdf/video given above.Follow these steps: 
											<br />
                                <code>Step1: Attach Picture/Signature from choose file and Click upload button. Step2: Fill Details. Step3: Attach degree certificate and Click Submit </code>
                            </p>

                            <%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
                            <div class="row form-group">
                                <div class="col col-md-3">
                                    <label for="text-input" class=" form-control-label">Unique Application No:</label></div>
                                <div class="col col-md-9">
                                    <asp:Label ID="lbID" runat="server" Text="" ForeColor="Green"></asp:Label>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col col-md-3">
                                    <label for="text-input" class=" form-control-label">Post Detail:</label></div>
                                <div class="col col-md-9">
                                    Post ID:
                                    <asp:Label ID="lbJobID" runat="server" Text="" ForeColor="Green"></asp:Label>
                                    <asp:Label ID="lbNewApprover" runat="server" Text="No Auth"></asp:Label>
                                    <asp:Label ID="lbNewApproverType" runat="server" Text=""></asp:Label>
                                </div>
                            </div>

                            <br />
                            <div id="divPic" runat="server" style="height: 100px; width: 100px;" />
                            <div class="col-md-3" style="display: flex">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>
                            <div class="col-md-6" style="display: flex">
                                <asp:Button ID="btnUpload" Text="Click here to Upload Picture" Width="290px" runat="server" OnClick="UploadFile" class="btn btn-success btn-rounded" />
                                <asp:Label ID="lbPicStatus" runat="server" Text="<i class='fa fa-times'></i>Pic Not Uploaded" ForeColor="Blue"></asp:Label>
                            </div>
                            <div id="divPic1" runat="server" style="height: 50px; width: 100px;" />
                            <div class="col-md-3" style="display: flex">
                                <asp:FileUpload ID="FileUpload2" runat="server" />
                            </div>
                            <div class="col-md-6" style="display: flex">
                                <asp:Button ID="btnUploadSign" Text="Click here to Upload Signature" Width="290px" runat="server" OnClick="UploadFileSign" class="btn btn-success btn-rounded" />
                                <asp:Label ID="lbSignStatus" runat="server" Text="<i class='fa fa-times'></i>Signature Not Uploaded" ForeColor="Blue"></asp:Label>
                            </div>
                            <hr />
                            <button type='button' class='btn btn-danger m-l-10 m-b-10' style='text-transform: capitalize;'>
                                <asp:Label ID="lbBookMessageTop" runat="server" Text="" ForeColor="white"></asp:Label>
                            </button>
                            <div class="form-horizontal" style="color: black;">
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Salutation:</label></div>
                                    <div class="col col-md-9">
                                        <asp:DropDownList ID="ddlNewSalute" runat="server">
                                            <asp:ListItem Value="Mr.">Mr.</asp:ListItem>
                                            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
                                            <asp:ListItem Value="Mrs.">Mrs.</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Name:</label></div>
                                    <div class="col col-md-9" style="display: flex">
                                        <asp:TextBox ID="txtNewName" MaxLength="50" Width="270px" class="form-control" runat="server" /><span style="border-bottom: 2px solid grey; padding-left: 8px; padding-top: 18px; vertical-align: middle; line-height: 1.25; color: black; font-size: 10px;"> Firstname followed by middle & lastname</span> </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Father's Name:</label></div>
                                    <div class="col col-md-9" style="display: flex">
                                        <asp:TextBox ID="txtNewFather" Width="270px" MaxLength="50" class="form-control" runat="server" />
                                        <span style="border-bottom: 2px solid grey; padding-left: 8px; padding-top: 18px; vertical-align: middle; line-height: 1.25; color: black; font-size: 10px;">Firstname followed by middle & lastname</span>  </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Mother's Name:</label></div>
                                    <div class="col col-md-9" style="display: flex">
                                        <asp:TextBox ID="txtNewMother" Width="270px" MaxLength="50" class="form-control" runat="server" />
                                        <span style="border-bottom: 2px solid grey; padding-left: 8px; padding-top: 18px; vertical-align: middle; line-height: 1.25; color: black; font-size: 10px;">Firstname followed by middle & lastname</span>  </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Gender:</label></div>
                                    <div class="col col-md-9">
                                        <asp:DropDownList ID="ddlNewSex" runat="server">
                                            <asp:ListItem Value="Male">Male</asp:ListItem>
                                            <asp:ListItem Value="Female">Female</asp:ListItem>
                                            <asp:ListItem Value="Other">Other</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Date of Birth(dd.mm.yyyy):</label></div>
                                    <div class="col col-md-9">
                                        <asp:TextBox autocomplete="off" ID="txtDoB" runat="server" MaxLength="15" class="au-input au-input--full" Width="200px" />
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd.MM.yyyy" TargetControlID="txtDoB" />

                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Nationality:</label></div>
                                    <div class="col col-md-9">
                                        <asp:DropDownList Enabled="false" ID="ddlNewNation" DataTextField="nationality" DataValueField="nationality" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">NID No:</label></div>
                                    <div class="col col-md-9">
                                        <asp:TextBox ID="txtNewNID" MaxLength="20" onkeypress="if(this.value.length >= this.getAttribute('maxlength')) alert('Max length 20 Character');" Width="300px" class="au-input au-input--full" runat="server" />
                                    </div>
                                </div>
                                <%--<div class="row form-group"> 
      <div class="col col-md-3"><label for="text-input" class=" form-control-label">Do you have Nationality Certificate:</label></div>                                           
                     <div class="col col-md-9">    <asp:RadioButtonList ID="rblNcert" runat="server"  RepeatDirection="Horizontal"  RepeatColumns="4">
                                  <asp:ListItem  Value="No" Selected="true">No</asp:ListItem>                  
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                   </asp:RadioButtonList>  
                       </div> </div>--%>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Communication Address:</label></div>
                                    <div class="col col-md-9">
                                        <asp:TextBox ID="txtNewAddress" MaxLength="200" placeholder="Complete Address" Width="400px" TextMode="MultiLine" Height="80" class="au-input au-input--full" runat="server" />
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">District:</label></div>
                                    <div class="col col-md-9">
                                        <asp:DropDownList ID="ddlDistrict" runat="server">
                                            <asp:ListItem Value="14">B.baria</asp:ListItem>
                                            <asp:ListItem Value="44">Bagerhat</asp:ListItem>
                                            <asp:ListItem Value="15">Bandarban</asp:ListItem>
                                            <asp:ListItem Value="2">Barguna</asp:ListItem>
                                            <asp:ListItem Value="5">Barishal</asp:ListItem>
                                            <asp:ListItem Value="4">Bhola</asp:ListItem>
                                            <asp:ListItem Value="51">Bogura</asp:ListItem>
                                            <asp:ListItem Value="47">C. nawabganj</asp:ListItem>
                                            <asp:ListItem Value="12">Chandpur</asp:ListItem>
                                            <asp:ListItem Value="11">Chattogram</asp:ListItem>
                                            <asp:ListItem Value="42">Chuadanga</asp:ListItem>
                                            <asp:ListItem Value="13">Cox's bazar</asp:ListItem>
                                            <asp:ListItem Value="10">Cumilla</asp:ListItem>
                                            <asp:ListItem Value="24">Dhaka</asp:ListItem>
                                            <asp:ListItem Value="58">Dinajpur</asp:ListItem>
                                            <asp:ListItem Value="31">Faridpur</asp:ListItem>
                                            <asp:ListItem Value="8">Feni</asp:ListItem>
                                            <asp:ListItem Value="60">Gaibandha</asp:ListItem>
                                            <asp:ListItem Value="21">Gazipur</asp:ListItem>
                                            <asp:ListItem Value="28">Gopalganj</asp:ListItem>
                                            <asp:ListItem Value="63">Habiganj</asp:ListItem>
                                            <asp:ListItem Value="27">Jamalpur</asp:ListItem>
                                            <asp:ListItem Value="41">Jashore</asp:ListItem>
                                            <asp:ListItem Value="6">Jhalokathi</asp:ListItem>
                                            <asp:ListItem Value="36">Jhenaidah</asp:ListItem>
                                            <asp:ListItem Value="50">Joypurhat</asp:ListItem>
                                            <asp:ListItem Value="16">Khagrachari</asp:ListItem>
                                            <asp:ListItem Value="35">Khulna</asp:ListItem>
                                            <asp:ListItem Value="19">Kishoreganj</asp:ListItem>
                                            <asp:ListItem Value="56">Kurigram</asp:ListItem>
                                            <asp:ListItem Value="40">Kushtia</asp:ListItem>
                                            <asp:ListItem Value="54">Lalmonirhat</asp:ListItem>
                                            <asp:ListItem Value="9">Laxmipur</asp:ListItem>
                                            <asp:ListItem Value="30">Madaripur</asp:ListItem>
                                            <asp:ListItem Value="38">Magura</asp:ListItem>
                                            <asp:ListItem Value="34">Manikganj</asp:ListItem>
                                            <asp:ListItem Value="43">Meherpur</asp:ListItem>
                                            <asp:ListItem Value="62">Moulvibazar</asp:ListItem>
                                            <asp:ListItem Value="33">Munshiganj</asp:ListItem>
                                            <asp:ListItem Value="22">Mymensingh</asp:ListItem>
                                            <asp:ListItem Value="45">Naogaon</asp:ListItem>
                                            <asp:ListItem Value="37">Narail</asp:ListItem>
                                            <asp:ListItem Value="20">Narayanganj</asp:ListItem>
                                            <asp:ListItem Value="23">Narshingdi</asp:ListItem>
                                            <asp:ListItem Value="46">Natore</asp:ListItem>
                                            <asp:ListItem Value="25">Netrokona</asp:ListItem>
                                            <asp:ListItem Value="55">Nilphamari</asp:ListItem>
                                            <asp:ListItem Value="7">Noakhali</asp:ListItem>
                                            <asp:ListItem Value="49">Pabna</asp:ListItem>
                                            <asp:ListItem Value="59">Panchagarh</asp:ListItem>
                                            <asp:ListItem Value="1">Patuakhali</asp:ListItem>
                                            <asp:ListItem Value="3">Pirojpur</asp:ListItem>
                                            <asp:ListItem Value="29">Rajbari</asp:ListItem>
                                            <asp:ListItem Value="48">Rajshahi</asp:ListItem>
                                            <asp:ListItem Value="17">Rangamati</asp:ListItem>
                                            <asp:ListItem Value="53">Rangpur</asp:ListItem>
                                            <asp:ListItem Value="39">Satkhira</asp:ListItem>
                                            <asp:ListItem Value="32">Shariatpur</asp:ListItem>
                                            <asp:ListItem Value="26">Sherpur</asp:ListItem>
                                            <asp:ListItem Value="52">Sirajganj</asp:ListItem>
                                            <asp:ListItem Value="64">Sunamganj</asp:ListItem>
                                            <asp:ListItem Value="61">Sylhet</asp:ListItem>
                                            <asp:ListItem Value="18">Tangail</asp:ListItem>
                                            <asp:ListItem Value="57">Thakurgaon</asp:ListItem>
                                            <asp:ListItem Value="99">Not in list</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Postal Code:</label></div>
                                    <div class="col col-md-9">
                                        <asp:TextBox ID="txtNewPIN" MaxLength="4" onkeypress="if(this.value.length >= this.getAttribute('maxlength')) alert('Max length 4 Character');" Width="200px" class="au-input au-input--full" runat="server" />
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Permanent Address:</label></div>
                                    <div class="col col-md-9">
                                        <asp:TextBox ID="txtNewAddressP" MaxLength="200" placeholder="Complete Address" Width="400px" TextMode="MultiLine" Height="80" class="au-input au-input--full" runat="server" />
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">District:</label></div>
                                    <div class="col col-md-9">
                                        <asp:DropDownList ID="ddlDistrictP" runat="server">
                                            <asp:ListItem Value="14">B.baria</asp:ListItem>
                                            <asp:ListItem Value="44">Bagerhat</asp:ListItem>
                                            <asp:ListItem Value="15">Bandarban</asp:ListItem>
                                            <asp:ListItem Value="2">Barguna</asp:ListItem>
                                            <asp:ListItem Value="5">Barishal</asp:ListItem>
                                            <asp:ListItem Value="4">Bhola</asp:ListItem>
                                            <asp:ListItem Value="51">Bogura</asp:ListItem>
                                            <asp:ListItem Value="47">C. nawabganj</asp:ListItem>
                                            <asp:ListItem Value="12">Chandpur</asp:ListItem>
                                            <asp:ListItem Value="11">Chattogram</asp:ListItem>
                                            <asp:ListItem Value="42">Chuadanga</asp:ListItem>
                                            <asp:ListItem Value="13">Cox's bazar</asp:ListItem>
                                            <asp:ListItem Value="10">Cumilla</asp:ListItem>
                                            <asp:ListItem Value="24">Dhaka</asp:ListItem>
                                            <asp:ListItem Value="58">Dinajpur</asp:ListItem>
                                            <asp:ListItem Value="31">Faridpur</asp:ListItem>
                                            <asp:ListItem Value="8">Feni</asp:ListItem>
                                            <asp:ListItem Value="60">Gaibandha</asp:ListItem>
                                            <asp:ListItem Value="21">Gazipur</asp:ListItem>
                                            <asp:ListItem Value="28">Gopalganj</asp:ListItem>
                                            <asp:ListItem Value="63">Habiganj</asp:ListItem>
                                            <asp:ListItem Value="27">Jamalpur</asp:ListItem>
                                            <asp:ListItem Value="41">Jashore</asp:ListItem>
                                            <asp:ListItem Value="6">Jhalokathi</asp:ListItem>
                                            <asp:ListItem Value="36">Jhenaidah</asp:ListItem>
                                            <asp:ListItem Value="50">Joypurhat</asp:ListItem>
                                            <asp:ListItem Value="16">Khagrachari</asp:ListItem>
                                            <asp:ListItem Value="35">Khulna</asp:ListItem>
                                            <asp:ListItem Value="19">Kishoreganj</asp:ListItem>
                                            <asp:ListItem Value="56">Kurigram</asp:ListItem>
                                            <asp:ListItem Value="40">Kushtia</asp:ListItem>
                                            <asp:ListItem Value="54">Lalmonirhat</asp:ListItem>
                                            <asp:ListItem Value="9">Laxmipur</asp:ListItem>
                                            <asp:ListItem Value="30">Madaripur</asp:ListItem>
                                            <asp:ListItem Value="38">Magura</asp:ListItem>
                                            <asp:ListItem Value="34">Manikganj</asp:ListItem>
                                            <asp:ListItem Value="43">Meherpur</asp:ListItem>
                                            <asp:ListItem Value="62">Moulvibazar</asp:ListItem>
                                            <asp:ListItem Value="33">Munshiganj</asp:ListItem>
                                            <asp:ListItem Value="22">Mymensingh</asp:ListItem>
                                            <asp:ListItem Value="45">Naogaon</asp:ListItem>
                                            <asp:ListItem Value="37">Narail</asp:ListItem>
                                            <asp:ListItem Value="20">Narayanganj</asp:ListItem>
                                            <asp:ListItem Value="23">Narshingdi</asp:ListItem>
                                            <asp:ListItem Value="46">Natore</asp:ListItem>
                                            <asp:ListItem Value="25">Netrokona</asp:ListItem>
                                            <asp:ListItem Value="55">Nilphamari</asp:ListItem>
                                            <asp:ListItem Value="7">Noakhali</asp:ListItem>
                                            <asp:ListItem Value="49">Pabna</asp:ListItem>
                                            <asp:ListItem Value="59">Panchagarh</asp:ListItem>
                                            <asp:ListItem Value="1">Patuakhali</asp:ListItem>
                                            <asp:ListItem Value="3">Pirojpur</asp:ListItem>
                                            <asp:ListItem Value="29">Rajbari</asp:ListItem>
                                            <asp:ListItem Value="48">Rajshahi</asp:ListItem>
                                            <asp:ListItem Value="17">Rangamati</asp:ListItem>
                                            <asp:ListItem Value="53">Rangpur</asp:ListItem>
                                            <asp:ListItem Value="39">Satkhira</asp:ListItem>
                                            <asp:ListItem Value="32">Shariatpur</asp:ListItem>
                                            <asp:ListItem Value="26">Sherpur</asp:ListItem>
                                            <asp:ListItem Value="52">Sirajganj</asp:ListItem>
                                            <asp:ListItem Value="64">Sunamganj</asp:ListItem>
                                            <asp:ListItem Value="61">Sylhet</asp:ListItem>
                                            <asp:ListItem Value="18">Tangail</asp:ListItem>
                                            <asp:ListItem Value="57">Thakurgaon</asp:ListItem>
                                            <asp:ListItem Value="99">Not in list</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Mobile No:</label></div>
                                    <div class="col col-md-9">
                                        <asp:TextBox ID="txtNewCell" MaxLength="11" onkeypress="if(this.value.length >= this.getAttribute('maxlength')) alert('Max length 11 Character');" placeholder="01234567899" Width="200px" class="au-input au-input--full" runat="server" />
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Phone No(Optional):</label></div>
                                    <div class="col col-md-9">
                                        <asp:TextBox ID="txtNewPhone" MaxLength="30" Width="200px" class="au-input au-input--full" runat="server" />
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Email:</label></div>
                                    <div class="col col-md-9">
                                        <asp:TextBox ID="txtNewEmail" MaxLength="35" Width="200px" class="au-input au-input--full" runat="server" />
                                        <asp:TextBox ID="txtNewEmailConfirm" Placeholder="Confirm Email" MaxLength="35" Width="200px" class="au-input au-input--full" runat="server" />
                                        <span style="border-bottom: 2px solid grey; padding-left: 8px; padding-top: 18px; vertical-align: middle; line-height: 1.25; color: black; font-size: 10px;">Retype email</span>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Qualifications:</label></div>
                                    <div class="col col-md-9">
                                        Educational qualification from higher to lower (Latest first). For HSC & SSC write down main subject. e.g. science,humanities & commerce. Mention year of passing from dropdown.
                                    </div>
                                </div>

                                <div class="row form-group">
                                    1.     
                                    <asp:DropDownList ID="ddlqual1" runat="server">
                                        <asp:ListItem Value="NA">-</asp:ListItem>
                                      <%--  <asp:ListItem Value="B. Sc. Electrical Engineering">B. Sc. Electrical Engg.</asp:ListItem>
                                        <asp:ListItem Value="B. Sc. Mechanical Engineering">B. Sc. Mechanical Engg.</asp:ListItem>--%>
                                        <asp:ListItem Value="Bachelor(3yr) or Equivalent">Bachelor(3yr) or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Bachelor(4yr) or Equivalent ">Bachelor(4yr) or Equivalent </asp:ListItem>
                                        <asp:ListItem Value="Diploma">Diploma</asp:ListItem>
                                        <asp:ListItem Value="Doctorate">Doctorate</asp:ListItem>
                                        <asp:ListItem Value="H.S.C or Equivalent">H.S.C or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Masters or Equivalent">Masters or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Post Doctorate">Post Doctorate</asp:ListItem>
                                        <asp:ListItem Value="S.S.C or Equivalent">S.S.C or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtsub1" placeholder="Degree & Subject" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:TextBox ID="txtInst1" placeholder="Institute" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:TextBox ID="txtUni1" placeholder="University/Board" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:DropDownList ID="ddlyear1" runat="server"></asp:DropDownList>
                                    <asp:TextBox ID="txtgpa1" placeholder="GPA/CGPA/Division" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                </div>

                                <div class="row form-group">
                                    2.     
                                    <asp:DropDownList ID="ddlqual2" runat="server">
                                        <asp:ListItem Value="NA">-</asp:ListItem>
                                        <asp:ListItem Value="Bachelor(3yr) or Equivalent">Bachelor(3yr) or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Bachelor(4yr) or Equivalent ">Bachelor(4yr) or Equivalent </asp:ListItem>
                                        <asp:ListItem Value="Diploma">Diploma</asp:ListItem>
                                        <asp:ListItem Value="Doctorate">Doctorate</asp:ListItem>
                                        <asp:ListItem Value="H.S.C or Equivalent">H.S.C or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Masters or Equivalent">Masters or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Post Doctorate">Post Doctorate</asp:ListItem>
                                        <asp:ListItem Value="S.S.C or Equivalent">S.S.C or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtsub2" placeholder="Degree & Subject" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:TextBox ID="txtInst2" placeholder="Institute" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:TextBox ID="txtUni2" placeholder="University/Board" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:DropDownList ID="ddlyear2" runat="server"></asp:DropDownList>
                                    <asp:TextBox ID="txtgpa2" placeholder="GPA/CGPA/Division" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                </div>

                                <div class="row form-group">
                                    3.     
                                    <asp:DropDownList ID="ddlqual3" runat="server">
                                        <asp:ListItem Value="NA">-</asp:ListItem>
                                        <asp:ListItem Value="Bachelor(3yr) or Equivalent">Bachelor(3yr) or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Bachelor(4yr) or Equivalent ">Bachelor(4yr) or Equivalent </asp:ListItem>
                                        <asp:ListItem Value="Diploma">Diploma</asp:ListItem>
                                        <asp:ListItem Value="Doctorate">Doctorate</asp:ListItem>
                                        <asp:ListItem Value="H.S.C or Equivalent">H.S.C or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Masters or Equivalent">Masters or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Post Doctorate">Post Doctorate</asp:ListItem>
                                        <asp:ListItem Value="S.S.C or Equivalent">S.S.C or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtsub3" placeholder="Degree & Subject" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:TextBox ID="txtInst3" placeholder="Institute" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:TextBox ID="txtUni3" placeholder="University/Board" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:DropDownList ID="ddlyear3" runat="server"></asp:DropDownList>
                                    <asp:TextBox ID="txtgpa3" placeholder="GPA/CGPA/Division" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                </div>
                                <div class="row form-group">
                                    4.     
                                    <asp:DropDownList ID="ddlqual4" runat="server">
                                        <asp:ListItem Value="NA">-</asp:ListItem>
                                        <asp:ListItem Value="Bachelor(3yr) or Equivalent">Bachelor(3yr) or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Bachelor(4yr) or Equivalent ">Bachelor(4yr) or Equivalent </asp:ListItem>
                                        <asp:ListItem Value="Diploma">Diploma</asp:ListItem>
                                        <asp:ListItem Value="Doctorate">Doctorate</asp:ListItem>
                                        <asp:ListItem Value="H.S.C or Equivalent">H.S.C or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Masters or Equivalent">Masters or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Post Doctorate">Post Doctorate</asp:ListItem>
                                        <asp:ListItem Value="S.S.C or Equivalent">S.S.C or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtsub4" placeholder="Degree & Subject" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:TextBox ID="txtInst4" placeholder="Institute" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:TextBox ID="txtUni4" placeholder="University/Board" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:DropDownList ID="ddlyear4" runat="server"></asp:DropDownList>
                                    <asp:TextBox ID="txtgpa4" placeholder="GPA/CGPA/Division" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                </div>
                                <div class="row form-group">
                                    5.     
                                    <asp:DropDownList ID="ddlqual5" runat="server">
                                        <asp:ListItem Value="NA">-</asp:ListItem>
                                        <asp:ListItem Value="Bachelor(3yr) or Equivalent">Bachelor(3yr) or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Bachelor(4yr) or Equivalent ">Bachelor(4yr) or Equivalent </asp:ListItem>
                                        <asp:ListItem Value="Diploma">Diploma</asp:ListItem>
                                        <asp:ListItem Value="Doctorate">Doctorate</asp:ListItem>
                                        <asp:ListItem Value="H.S.C or Equivalent">H.S.C or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Masters or Equivalent">Masters or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Post Doctorate">Post Doctorate</asp:ListItem>
                                        <asp:ListItem Value="S.S.C or Equivalent">S.S.C or Equivalent</asp:ListItem>
                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtsub5" placeholder="Degree & Subject" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:TextBox ID="txtInst5" placeholder="Institute" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:TextBox ID="txtUni5" placeholder="University/Board" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    <asp:DropDownList ID="ddlyear5" runat="server"></asp:DropDownList>
                                    <asp:TextBox ID="txtgpa5" placeholder="GPA/CGPA/Division" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Total Work Experience(As on today):</label></div>
                                    <div class="col col-md-9">
                                        <asp:DropDownList ID="ddlExpYr" runat="server"></asp:DropDownList>
                                        Yr
                          <asp:DropDownList ID="ddlExpMonth" runat="server"></asp:DropDownList>
                                        Month
                         <asp:DropDownList ID="ddlExpDay" runat="server">
                             <asp:ListItem Value="0">0</asp:ListItem>
                             <asp:ListItem Value="7">7</asp:ListItem>
                             <asp:ListItem Value="14">14</asp:ListItem>
                             <asp:ListItem Value="21">21</asp:ListItem>
                         </asp:DropDownList>
                                        Days
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Current/Last Work Experience:</label></div>
                                    <div class="col col-md-9">
                                        Select from list and fill details. Additional work exp. can be submitted in resume.
                                    </div>
                                </div>

                                <div class="row form-group">
                                    <asp:DropDownList ID="ddlExpType" runat="server">
                                        <asp:ListItem Value="No Experience">No Experience</asp:ListItem>
                                        <asp:ListItem Value="Private">Private</asp:ListItem>
                                        <asp:ListItem Value="Government">Government</asp:ListItem>
                                        <asp:ListItem Value="Semi Govt">Semi Govt</asp:ListItem>
                                        <asp:ListItem Value="Autonomous Org">Autonomous Org</asp:ListItem>
                                        <asp:ListItem Value="Govt Owned Company">Govt Owned Company</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtOrg" placeholder="Name of company/organisation" MaxLength="50" Width="290px" class="form-control" runat="server" />
                                    <asp:TextBox ID="txtDesig" placeholder="Designation" MaxLength="50" Width="200px" class="form-control" runat="server" />
                                    From:<asp:TextBox ID="txtDurationFrom" runat="server" autocomplete="off" MaxLength="15" class="au-input au-input--full" Width="150px" />
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd.MM.yyyy" TargetControlID="txtDurationFrom" />
                                    To:<asp:TextBox ID="txtDurationTo" autocomplete="off" runat="server" MaxLength="15" class="au-input au-input--full" Width="150px" />
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd.MM.yyyy" TargetControlID="txtDurationTo" />
                                </div>
                                <div class="row form-group">
                                    Are you currently employed or were employed by BIFPCL:    
                                    <asp:RadioButtonList ID="rblDept" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                        <asp:ListItem Value="No" Selected="true">No    </asp:ListItem>
                                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="row form-group">
                                    Do you have any relative in BIFPCL:    
                                    <asp:RadioButtonList ID="rblRelative" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                        <asp:ListItem Value="No" Selected="true">No</asp:ListItem>
                                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="row form-group">
                                    Are you a son/grand-son or daughter/grand-daughter of freedom fighter(s)/martyred freedom fighter(s) :    
                                    <asp:RadioButtonList ID="rblfreedom" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                        <asp:ListItem Value="No" Selected="true">No     </asp:ListItem>
                                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-3">
                                        <label for="text-input" class=" form-control-label">Online Payment Transaction ID  (Txn. Id)</label></div>
                                    <div class="col col-md-9">
                                        <asp:TextBox ID="txtDD" TextMode="Number" MaxLength="12" Width="200px" class="au-input au-input--full" runat="server" />
                                        <span style="border-bottom: 2px solid grey; padding-left: 8px; padding-top: 18px; vertical-align: middle; line-height: 1.25; color: black; font-size: 10px;">Application will be rejected for wrong Transaction ID  (Txn. Id)</span>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col col-md-12">
                                        <b>Undertaking/Declaration:</b>
                                        <br />
                                        I hereby declare that all the statements made in this application are true, complete and correct to the best of my knowledge and belief. I understand that in the event of any information being found false at any stage or not satisfying the eligibility criteria specified for the post, my candidature/ appointment is liable to be cancelled/terminated. I further undertake that i will join the post, if selected within a period of 2 months from the date of issue of offer letter.     
                                     <asp:RadioButtonList ID="rblDeclare" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                         <asp:ListItem Value="No" Selected="true">Not Agreed   </asp:ListItem>
                                         <asp:ListItem Value="Yes">Agreed</asp:ListItem>
                                     </asp:RadioButtonList>
                                    </div>
                                </div>

                                <%-- <asp:TextBox ID="txtNewIntro"  MaxLength="400"  placeholder="Tell About Yourself" Width="500px" TextMode="MultiLine" Height="80"  class="au-input au-input--full" runat="server" /> 
    <br /><br />     <asp:TextBox ID="txtNewSkills"  MaxLength="200"  placeholder="Skillset" Width="300px" TextMode="MultiLine" Height="80"  class="au-input au-input--full" runat="server" /> 
        <asp:TextBox ID="txtNewAch"  MaxLength="200"  placeholder="Achievement (If Any)" Width="300px" TextMode="MultiLine" Height="80"  class="au-input au-input--full" runat="server" /> 
    <br />  <br />     <asp:TextBox ID="txtNewDegree"  placeholder="Degree" MaxLength="50" Width="300px"  class="au-input au-input--full" runat="server" /> 
       <asp:TextBox ID="txtNeQual"  placeholder="Other Qualification" Width="300px"  MaxLength="100"   class="au-input au-input--full" runat="server" />  
      <br />  <br />     <asp:TextBox ID="txtNewCert"  placeholder="Certificates(if any)" MaxLength="100" Width="300px"  class="au-input au-input--full" runat="server" /> 
       <asp:TextBox ID="txtNewWorkExp"  placeholder="Work Experience" Width="300px"  MaxLength="100"   class="au-input au-input--full" runat="server" />  
       <br />  <br />     <asp:TextBox ID="txtNewReference"  placeholder="References(Name & Contact)" MaxLength="100" Width="300px"  class="au-input au-input--full" runat="server" /> 
       <asp:TextBox ID="txtNewHobby"  placeholder="Hobby/Interest" Width="300px"  MaxLength="100"   class="au-input au-input--full" runat="server" />  
                                --%>
                            </div>
                            <br />
                            <br />
                            <label>Attach Qualifying Degree Certificate Copy (Single PDF)</label>
                            <div id="div1" runat="server" />

                            <asp:FileUpload ID="FileUploadControl" runat="server" />

                            <asp:Label ID="lbInfo" runat="server" Text="" ForeColor="blue"></asp:Label>
                            <asp:Label ID="lbRemark" runat="server" Text="" ForeColor="blue"></asp:Label>
                            <div class=" col-md-6">
                                <asp:Button ID="btnSumbitPass" OnClick="btnSumbitPass_Click" runat="server" Text="Book" Visible="True" class="au-btn au-btn--block au-btn--green m-b-20" />
                            </div>
                            <br />
                            <button type='button' class='btn btn-danger m-l-10 m-b-10' style='text-transform: capitalize;'>
                                <asp:Label ID="lbBookMessage" runat="server" Text="" ForeColor="white"></asp:Label>
                            </button>

                            Mode:
                            <asp:Label ID="lbNewMode" runat="server" Text="New" ForeColor="red"></asp:Label>
                            Phase:
                            <asp:Label ID="lbNewPhase" runat="server" Text="Demo" ForeColor="blue"></asp:Label>
                        </asp:Panel>
                              <asp:Panel ID="pnlAdminPage" Visible="false" runat="server">
                            <div class="col-md-12">
                                <h3>Page Admin Section</h3>

                               
                                <fieldset style="border-style: none dashed dashed dashed; border-width: thin; border-color: #000080; background-color: #FFFFFF;">
                                    <legend style="font-size: 16px; line-height: 1.7; color: #432d2d;"><b>Few Variables Settings:</b></legend>
                                    <br />
                                    written admit  card link >  a href=hrCareer.aspx?mode=printadmit  <br />
                                     interview admit  card link > a href=hrCareer.aspx?mode=printadmitInt <br />
                                    Joining link > a href=hrCareer.aspx?mode=printadmitSel <br />
                                    Updates:     <br />

                                    <asp:TextBox ID="txtUpdates" placeholder="Updates" TextMode="MultiLine" Height="200px" MaxLength="250" Width="800px" class="au-input au-input--full" runat="server" />
                                    <br /><br />
                                    Page Locked for New Application
                                    <asp:RadioButtonList ID="rblPageLock" RepeatDirection="Horizontal" AutoPostBack="true" runat="server">
                                    <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                  </asp:RadioButtonList>
                                    <br />
                                    <br />
                                    Opportunities: <br />
                                    <asp:TextBox ID="txtOpo" placeholder="Opportunities" TextMode="MultiLine" Height="200px" MaxLength="250" Width="800px" class="au-input au-input--full" runat="server" />
                                  <br />
                                    <br />
                                    HowTo Apply:  <br /> <asp:TextBox ID="txtHowto" placeholder="How to apply" TextMode="MultiLine" Height="200px" MaxLength="250" Width="800px" class="au-input au-input--full" runat="server" />
                                    <br />
                                    <br />
                                   Terms & Condition:                          
                                    <br />
                                    <asp:TextBox ID="txtTnC" placeholder="TnC" TextMode="MultiLine" Height="200px" MaxLength="250" Width="800px" class="au-input au-input--full" runat="server" />
                                    <br />
                                    <br />
                                    Variable A: <br />
                                    <asp:TextBox ID="txtvar_a" placeholder="Variable A" MaxLength="250" Width="500px" class="au-input au-input--full" runat="server" />
                                    <br /> &nbsp;&nbsp;&nbsp; <asp:Button ID="btnVar_Submit" Text="Update" runat="server"  Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlAdmin" Visible="false" runat="server">
                            <div class="col-md-12">
                                <h3>Admin Section</h3>

                                Select Recruitment Phase:
                                <asp:DropDownList ID="ddlAdminPhase" DataTextField="phase" DataValueField="phase" AutoPostBack="true" runat="server" />
                                Select Job ID:
                                <asp:DropDownList ID="ddlAdminJob" DataTextField="post" DataValueField="jobid" AutoPostBack="true" runat="server" />
                                <br />
                                <asp:RadioButtonList ID="rblAdminStatus" RepeatDirection="Horizontal" AutoPostBack="true" runat="server">
                                    <asp:ListItem Value="applied" Selected="True">Applied</asp:ListItem>
                                    <asp:ListItem Value="written">Written</asp:ListItem>
                                    <asp:ListItem Value="interview">Interview</asp:ListItem>
                                    <asp:ListItem Value="selected">Selected for Joining</asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                                Bulk Action --->     
                                <asp:Button ID="btnAproveBulk" Text="Qualify Marked Candidates for Written Exam" runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                <asp:Button ID="btnPayBulk" Text="Confirm Payment for Marked Candidates" runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />


                                <asp:Button ID="btnSMSSelectAll" Text="Select All" runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />

                                <br />
                                <br />
                                Single Action --->       
                                <asp:Button ID="btnReject" Text="Move to Prev Stage Single Candidate" runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                <asp:Button ID="btnRejectPay" Text="No Payment for Single Candidate" runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                <br />
                                <br />
                                Assign Roll Number --->       
                                <asp:Button ID="btnAssignRollno" Text="Assign 7 digit Roll No Starts with ->" runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                &nbsp;    <asp:TextBox ID="txtRollno" placeholder="xxxxx" MaxLength="5" Width="90px" runat="server" /> (for selected job id and phase: wait 2min)
                                 
                               
                                <br />
                                 Send SMS/Email --->  
                                <asp:TextBox ID="txtSMS" placeholder="" MaxLength="300" Width="350px" TextMode="MultiLine" Height="80" runat="server" /> 
                                   &nbsp;     &nbsp;     &nbsp;   
                                 <asp:TextBox ID="txtEmail" placeholder="" MaxLength="300" Width="450px" TextMode="MultiLine" Height="80" runat="server" /> 
                                   &nbsp;     &nbsp;     &nbsp;  
                                  <br /> &nbsp;     &nbsp;     &nbsp;   &nbsp;     &nbsp;     &nbsp;   &nbsp;     &nbsp;     &nbsp;   &nbsp;     &nbsp;     &nbsp;  
                                 &nbsp;     &nbsp;     &nbsp;   &nbsp;     &nbsp;     &nbsp;   &nbsp;     &nbsp;     &nbsp;  
                                <asp:Button ID="btnSMS" Enabled="false"  Text="Send SMS to Marked Cand." runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                               &nbsp;     &nbsp;     &nbsp;   &nbsp;     &nbsp;     &nbsp;   &nbsp;     &nbsp;     &nbsp;   &nbsp;     &nbsp;     &nbsp;  
                                <asp:Button ID="btnEmail" Enabled="false"  Text="Send Email to Marked Cand." runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                               
                               
                                <br />
                               
                                Assign Interview Slot --->       
                                
                                &nbsp;    <asp:TextBox ID="txtIntSlotLoc" Text="BIFPCL Conference Hall, Level-6, Borak Unique Heights, 117, Kazi Nazrul Islam Avenue, Dhaka -1000." Height="50"  Width="190px" TextMode="MultiLine" runat="server" /> 
                                  &nbsp;    <asp:TextBox ID="txtIntSlotdate" placeholder="yyyy-mm-dd" MaxLength="10" Width="120px"  runat="server" /> 
                                 <asp:DropDownList ID="ddlIntSltNumber"  AutoPostBack="true" runat="server" >
                                     <asp:ListItem Value="10:00 AM" >First Half</asp:ListItem>
                                    <asp:ListItem Value="02:00 PM">Second Half</asp:ListItem>
                                    </asp:DropDownList>
                                <%--&nbsp;    <asp:TextBox ID="txtIntSlotTime" placeholder="08:30 AM" MaxLength="10" Width="80px" runat="server" /> --%>
                                <asp:Button ID="btnIntSlot" Enabled="false" Text="Update the Slot" runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" /> 
                               
                                <asp:Label ID="lbApprovePass" runat="server" Text="" ForeColor="red"></asp:Label>
                                <hr />
                                <div id="divMsgAdmin" runat="server" />
                                <asp:GridView ID="gvPassApprove" runat="server" HeaderStyle-CssClass="gvHeader" Caption="View Candidates to Approve" CaptionAlign="Left"
                                    CssClass="table-responsive table-striped" AlternatingRowStyle-CssClass="gvAltRow" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <%--  <th colspan="6">Category</th>--%>
                                                <tr class="gvHeader">
                                                    <th></th>
                                                    <th>! aID</th>
                                                    <th>Application ID</th>
                                                     <th>RollNo</th>
                                                    <th>Name</th>
                                                    <th>Cell</th>
                                                    <th>Stage</th>

                                                    <th>Transaction ID</th>
                                                    <th>Pay Confirm</th>
                                                    <th>Pic</th>
                                                    <th>Log</th>

                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <td>
                                                    <asp:CheckBox ID="cbSMSSelect" CssClass="gridCB" runat="server" Text='<%# Eval("aid")%>'></asp:CheckBox></td>
                                                <td><%# Eval("appid")%></td>
                                                <td><%# Eval("rollno")%></td>
                                                <td><%# Eval("name")%></td>
                                                <td><%# Eval("cell")%></td>
                                                <td><%# Eval("stage")%></td>
                                                <td><%# Eval("draft")%></td>
                                                <td><%# Eval("payconfirm")%></td>
                                                <td>
                                                    <img src='https://www.bifpcl.com/upload/HR/Career/<%#  Eval("appid") %>.jpg' alt='<%# Eval("appid")%>' width="50" height="75" /></td>
                                                <td><%# Eval("log")%></td>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div>No Data Available</div>
                                    </EmptyDataTemplate>
                                </asp:GridView>

                             
                            </div>
                        </asp:Panel>
                         <asp:Panel ID="pnlInterDashboard" Visible="false" runat="server">
                            <div class="col-md-12">
                                     <section class="statistic-chart" id="divPIN" runat="server" >
                <div class="container">
                    <div class="row">
                        <div class="col-md-6 col-lg-4">
                            <!-- TOP CAMPAIGN-->
                            <div class="top-campaign">
                       
           <b> <label>Please Enter PIN to proceed:</label></b>
                    <asp:TextBox ID="txtEid" runat="server" placeholder="*******" MaxLength="6" Width="100px"  class="au-input au-input--full"></asp:TextBox> <br /><br />
                
            <asp:Button ID="btnLogin"  class="au-btn au-btn--block au-btn--green m-b-20" runat="server" Text="Sign In" />
       <br /> 
<asp:Label ID="lbLogin" runat="server" Text="Note: Your IP Address and Location are being recorded."></asp:Label>
                </div>
                    </div>
                        </div>
                    </div>
               </section>
                                                            <asp:Panel ID="pnlInterview" Visible="false" runat="server">
                            <div class="col-md-12">
                                <h3>Interviewer Dashboard</h3>      
                                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Button ID="btnIntSignOut" Text="SignOut" runat="server"  Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, black 0%, #fcd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                
                               
                                <div id="divIntProfile" runat="server" />
                                 <asp:Label ID="lbDivInt" runat="server" Text="" ForeColor="red"></asp:Label>
                                     <fieldset style="border-style: none dashed dashed dashed; border-width: thin; border-color: #000080; background-color: #FFFFFF;">
                                    <legend style="font-size: 16px; line-height: 1.7; color: #432d2d;"><b>Give Marks For VIVA VOCE:</b></legend>
                                    <br />
                                         <table>
                                             <tr><td>
                                   &nbsp;&nbsp;&nbsp;  A. General Knowledge & Awareness:   </td><td> 
                                          <asp:RadioButtonList ID="rblIntA" RepeatDirection="Horizontal" AutoPostBack="true" runat="server">
                                    <asp:ListItem Value="1" >1</asp:ListItem>  <asp:ListItem Value="2">2</asp:ListItem><asp:ListItem Value="3" >3</asp:ListItem>
                                                <asp:ListItem Value="4" >4</asp:ListItem>  <asp:ListItem Value="5">5</asp:ListItem><asp:ListItem Value="6" >6</asp:ListItem>
                                                <asp:ListItem Value="7" >7</asp:ListItem>  <asp:ListItem Value="8">8</asp:ListItem>
                                 </asp:RadioButtonList>
                               </td> </tr> <tr><td>
                                   &nbsp;&nbsp;&nbsp;  B. Ability to Communicate in English:    </td><td>  
                                    <asp:RadioButtonList ID="rblIntB" RepeatDirection="Horizontal" AutoPostBack="true" runat="server">
                                    <asp:ListItem Value="1" >1</asp:ListItem>  <asp:ListItem Value="2">2</asp:ListItem><asp:ListItem Value="3" >3</asp:ListItem>
                                                <asp:ListItem Value="4" >4</asp:ListItem>  <asp:ListItem Value="5">5</asp:ListItem><asp:ListItem Value="6" >6</asp:ListItem>
                                                <asp:ListItem Value="7" >7</asp:ListItem>  <asp:ListItem Value="8">8</asp:ListItem><asp:ListItem Value="9" >9</asp:ListItem>
                                 </asp:RadioButtonList>
                                </td> </tr> <tr><td>
                                   &nbsp;&nbsp;&nbsp;   C. Professional Knowledge:     </td><td> 
                                 <asp:RadioButtonList ID="rblIntC" RepeatDirection="Horizontal" AutoPostBack="true" runat="server">
                                    <asp:ListItem Value="1" >1</asp:ListItem>  <asp:ListItem Value="2">2</asp:ListItem><asp:ListItem Value="3" >3</asp:ListItem>
                                                <asp:ListItem Value="4" >4</asp:ListItem>  <asp:ListItem Value="5">5</asp:ListItem><asp:ListItem Value="6" >6</asp:ListItem>
                                                <asp:ListItem Value="7" >7</asp:ListItem>  <asp:ListItem Value="8">8</asp:ListItem><asp:ListItem Value="9" >9</asp:ListItem>
                                 </asp:RadioButtonList>
                                 </td> </tr> <tr><td>
                                    &nbsp;&nbsp;&nbsp;   D. Personality, Confidence & Attitude:   </td><td>   
                                    <asp:RadioButtonList ID="rblIntD" RepeatDirection="Horizontal" AutoPostBack="true" runat="server">
                                    <asp:ListItem Value="1" >1</asp:ListItem>  <asp:ListItem Value="2">2</asp:ListItem><asp:ListItem Value="3" >3</asp:ListItem>
                                                <asp:ListItem Value="4" >4</asp:ListItem>  <asp:ListItem Value="5">5</asp:ListItem><asp:ListItem Value="6" >6</asp:ListItem>
                                                <asp:ListItem Value="7" >7</asp:ListItem>  <asp:ListItem Value="8">8</asp:ListItem><asp:ListItem Value="9" >9</asp:ListItem>
                                 </asp:RadioButtonList>
                                 </td> </tr> <tr><td>  &nbsp;&nbsp;&nbsp; Any Remarks(Optional)</td><td>
                                         <asp:TextBox ID="txtIntRemark" placeholder="" TextMode="MultiLine" Height="100px"  Width="180px" class="au-input au-input--full" runat="server"  />
  </td> </tr> <tr><td>
                                      &nbsp;&nbsp;&nbsp;  Total of Education Qual. (Out of 15) </td> <td><asp:Label ID="lbIntEd" runat="server" Text="0" ForeColor="Blue"></asp:Label>
                                     </td> </tr> <tr><td>
                                     &nbsp;&nbsp;&nbsp;   Total of VIVA VOCE (Out of 35) </td> <td><span class="blink" ><asp:Label ID="lbIntVivavoce" runat="server" style="padding:20px;" Text="0" ForeColor="#f3f0cf"></asp:Label></span>
                                     </td> </tr> <tr><td>
                                    &nbsp;&nbsp;&nbsp;    Sub-Total (Out of 50) </td> <td><asp:Label ID="lbIntTotal" runat="server" Text="0" Font-Bold ="true"  ForeColor="SteelBlue" ></asp:Label>
                                     </td> </tr> <tr><td>
                                 &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnIntSubmit" Text="Submit & Next ->" runat="server"  Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                       </td> </tr>  </table> <br />
                                </fieldset>
                                <asp:Label ID="lbIntName" runat="server" Text="" ForeColor="Purple"></asp:Label>
                                <br /><asp:Label ID="lbIntAppid" runat="server" Text="0" ForeColor="Green" />
                                <asp:Label ID="lbIntError" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </asp:Panel>
                                </div>
                                 </asp:Panel>
                             <asp:Panel ID="pnlIntLive" Visible="false" runat="server">
                            <div class="col-md-12">
                                <h3>Live View Interview</h3>
                  
                                <br />
                                Interview Already Done on:   <asp:DropDownList ID="ddlLiveIntDate" DataTextField="dispdate" DataValueField="venue_i_dt" AutoPostBack="true" runat="server" />
                             &nbsp;&nbsp;&nbsp;&nbsp; 
                                <asp:Button ID="btnLiveRefresh" Text="Refresh" runat="server" CssClass="primary-btn submit-btn"  />
                                  <asp:GridView ID="gvLiveDone" class="table-responsive table--no-card m-b-40 table table-borderless table-striped "  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                            </div>
                        </asp:Panel>
                           <asp:Panel ID="pnlInt" Visible="false" runat="server">
                            <div class="col-md-12">
                                <h3>Conduct Interview</h3>
                                <br />   Select Interview Date:
                                <asp:DropDownList ID="ddlIntDate" DataTextField="dispdate" DataValueField="venue_i_dt" AutoPostBack="true" runat="server" />
                             &nbsp;&nbsp;&nbsp;&nbsp;   Select Slot:
                                <asp:DropDownList ID="ddlIntSlot"  AutoPostBack="true" runat="server" >
                                     <asp:ListItem Value="1" >First Half</asp:ListItem>
                                    <asp:ListItem Value="2">Second Half</asp:ListItem>
                                    </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;   Select Candidate:
                                <asp:DropDownList ID="ddlIntCandidate" DataTextField="cand" DataValueField="appid" AutoPostBack="true" runat="server" />
                               <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Button ID="btnCandRatingPring" Text="Print Rating Sheet for Above Slot" runat="server"  Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, black 0%, #fcd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                            
                              <%--  <br />
                                Direct Load any App ID/Roll No --->       
                                &nbsp;    <asp:TextBox ID="txtIntAppID" placeholder="application id/Roll no" MaxLength="20" Width="200px" runat="server" /> 
                              &nbsp;&nbsp;     <asp:Button ID="btnIntLoad" Text="Load App ID" runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                <br />--%>
                                <div id="divCandProfile" runat="server" />
                                <br />
                                           &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnIntAssign" Text="Send to Interview Room" runat="server"  Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnIntAbsent" Text="Mark Above Candidate Absent" runat="server"  Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                               &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;      <asp:TextBox autocomplete="off" ID="txtNewIntDate" runat="server" MaxLength="15" class="au-input au-input--full" Width="200px" />
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd.MM.yyyy" TargetControlID="txtNewIntDate" />
                                 <asp:DropDownList ID="ddlNewIntSlot"  runat="server" >
                                     <asp:ListItem Value="08:30 AM" >First Half</asp:ListItem>
                                    <asp:ListItem Value="02:00 PM">Second Half</asp:ListItem>
                                    </asp:DropDownList>
                                 <asp:Button ID="btnNewSlot" Text="Change Slot for this candidate" runat="server"  Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                 <br />   <asp:Label ID="lbIntConduct" runat="server" Text="" ForeColor="red"></asp:Label>
                                       
                                <br />
                                <br />
                                Interview Already Scheduled:<asp:Button ID="btnCandRefresh" Text="Refresh" runat="server" CssClass="primary-btn submit-btn"  />
                                  <asp:GridView ID="gvIntdone" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                            </div>
                        </asp:Panel>
                            <asp:Panel ID="pnlRating" Visible="false" runat="server">
                            <div class="col-md-12">
                                <h3>Rating Section</h3>

                                Select Recruitment Phase:
                                <asp:DropDownList ID="ddlRatingPhase" DataTextField="phase" DataValueField="phase" AutoPostBack="true" runat="server" />
                                Select Job ID:
                                <asp:DropDownList ID="ddlRatingJobs" DataTextField="post" DataValueField="jobid" AutoPostBack="true" runat="server" />
                                <br />
                                <asp:RadioButtonList ID="rblRatingStatus" RepeatDirection="Horizontal" AutoPostBack="true" runat="server">
                                    <asp:ListItem Value="applied" >Applied</asp:ListItem>
                                    <asp:ListItem Value="written">Written</asp:ListItem>
                                    <asp:ListItem Value="interview" Selected="True">Interview</asp:ListItem>
                                    <asp:ListItem Value="selected">Selected for Joining</asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                               
                                Direct Update any App ID/Roll No --->       
                                &nbsp;    <asp:TextBox ID="txtRatingAppid" placeholder="application id" MaxLength="20" Width="140px" runat="server" /> 
                              &nbsp;&nbsp;     <asp:Button ID="btnRatingAppidLoad" Text="Load" runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                             &nbsp;&nbsp;   <asp:Button ID="btnRatingPrint" Text="Print Below Rating Sheet" runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                 &nbsp;&nbsp;   <asp:Button ID="btnRatingPrintAll" Text="Print All Rating Sheet" runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                &nbsp;&nbsp;   <asp:Button ID="btnAdmitSinglePrint" Text="Print Below Admitcard" runat="server" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                               
                                <br />
                               
                                                            <hr />
                                <div id="divRatingProfile" runat="server" />
                                 <asp:Label ID="lbRatingMsg" runat="server" Text="" ForeColor="red"></asp:Label>
                                     <fieldset style="border-style: none dashed dashed dashed; border-width: thin; border-color: #000080; background-color: #FFFFFF;">
                                    <legend style="font-size: 16px; line-height: 1.7; color: #432d2d;"><b>Manually Correct The Ratings:</b></legend>
                                    <br />
                                   &nbsp;&nbsp;&nbsp;  SSC CGPA:    
                                    <asp:TextBox ID="txtRateSSC" placeholder=""  Width="80px" class="au-input au-input--full" runat="server"  />
                                   &nbsp;&nbsp;&nbsp;   HSC CGPA:    
                                    <asp:TextBox ID="txtRateHSC" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server"  />
                                   &nbsp;&nbsp;&nbsp;   Graduation GPA:    
                                 <asp:TextBox ID="txtRateGrad" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server" />
                                  <br /><br />  &nbsp;&nbsp;&nbsp;     Post Graduation GPA:    
                                    <asp:TextBox ID="txtRatePG" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server" />
                                  &nbsp;&nbsp;&nbsp;    Diploma CGPA:    
                                    <asp:TextBox ID="txtRateDiploma" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server"  />
                                   
                                 &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnRatingUpdate" Text="Update & Next ->" runat="server"  Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                         <br /><br /> To move without updating the ratings: <br />
                                           &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnRatingPrev" Text="<- Previous Application" runat="server"  Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                             &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnRatingNext" Text="Next Application ->" runat="server"  Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                       
                                </fieldset>
                                <fieldset style="border-style: none dashed dashed dashed; border-width: thin; border-color: #000080; background-color: #FFFFFF;">
                                    <legend style="font-size: 16px; line-height: 1.7; color: #432d2d;"><b>Manually Correct The Interview Marks:</b></legend>
                                    <br />
                                   &nbsp;&nbsp;&nbsp;  I1A:    
                                    <asp:TextBox ID="txtI1a" placeholder=""  Width="80px" class="au-input au-input--full" runat="server"  />
                                   &nbsp;&nbsp;&nbsp;   I1B:    
                                    <asp:TextBox ID="txtI1B" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server"  />
                                   &nbsp;&nbsp;&nbsp;   I1C:    
                                 <asp:TextBox ID="txtI1C" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server" />
                                  &nbsp;&nbsp;&nbsp;     I1D:    
                                    <asp:TextBox ID="txtI1D" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server" />
                                  <br /><br />
                                        &nbsp;&nbsp;&nbsp;  I2A:    
                                    <asp:TextBox ID="txtI2a" placeholder=""  Width="80px" class="au-input au-input--full" runat="server"  />
                                   &nbsp;&nbsp;&nbsp;   I2B:    
                                    <asp:TextBox ID="txtI2B" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server"  />
                                   &nbsp;&nbsp;&nbsp;   I2C:    
                                 <asp:TextBox ID="txtI2C" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server" />
                                  &nbsp;&nbsp;&nbsp;     I2D:    
                                    <asp:TextBox ID="txtI2D" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server" />
                                    <br /><br />
                                        &nbsp;&nbsp;&nbsp;  I3A:    
                                    <asp:TextBox ID="txtI3a" placeholder=""  Width="80px" class="au-input au-input--full" runat="server"  />
                                   &nbsp;&nbsp;&nbsp;   I3B:    
                                    <asp:TextBox ID="txtI3B" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server"  />
                                   &nbsp;&nbsp;&nbsp;   I3C:    
                                 <asp:TextBox ID="txtI3C" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server" />
                                  &nbsp;&nbsp;&nbsp;     I3D:    
                                    <asp:TextBox ID="txtI3D" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server" />
                                 <br /><br />
                                        &nbsp;&nbsp;&nbsp;  I4A:    
                                    <asp:TextBox ID="txtI4a" placeholder=""  Width="80px" class="au-input au-input--full" runat="server"  />
                                   &nbsp;&nbsp;&nbsp;   I4B:    
                                    <asp:TextBox ID="txtI4B" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server"  />
                                   &nbsp;&nbsp;&nbsp;   I4C:    
                                 <asp:TextBox ID="txtI4C" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server" />
                                  &nbsp;&nbsp;&nbsp;     I4D:    
                                    <asp:TextBox ID="txtI4D" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server" />
<br /><br />
                                        &nbsp;&nbsp;&nbsp;  I5A:    
                                    <asp:TextBox ID="txtI5a" placeholder=""  Width="80px" class="au-input au-input--full" runat="server"  />
                                   &nbsp;&nbsp;&nbsp;   I5B:    
                                    <asp:TextBox ID="txtI5B" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server"  />
                                   &nbsp;&nbsp;&nbsp;   I5C:    
                                 <asp:TextBox ID="txtI5C" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server" />
                                  &nbsp;&nbsp;&nbsp;     I5D:    
                                    <asp:TextBox ID="txtI5D" placeholder="" MaxLength="4" Width="80px" class="au-input au-input--full" runat="server" />
                                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnInterviewUpdate" Text="Update." runat="server"  Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                         <asp:Label ID="lbMsgInterviewUpdate" runat="server" Text="" ForeColor="Green"></asp:Label>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlReport" Visible="false" runat="server">
                            <h5>Application Reports</h5>
                            <%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
                            <div style="padding-left: 20px">
                                Select Recruitment Phase:
                                <asp:DropDownList ID="ddlReportPhase" DataTextField="phase" DataValueField="phase" AutoPostBack="true" runat="server" />
                                 Select Post:
                                <asp:DropDownList ID="ddlReportJobID" DataTextField="post" DataValueField="jobid" AutoPostBack="true" runat="server" />
                               
                                <fieldset style="border-style: none dashed dashed dashed; border-width: thin; border-color: #000080; background-color: #FFFFFF;">
                                    <legend style="font-size: 16px; line-height: 1.7; color: #432d2d;"><b>Step 1. Filters:</b></legend>
                                    <%--<asp:DropDownList ID="ddlReportAgency" AutoPostBack="true" DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>
    <br /><label><b>ID Status:</b></label>      <asp:RadioButtonList ID="rblReportStatus" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="3">
                             <asp:ListItem Value="New_A1">New with Approver EPC</asp:ListItem>
        <asp:ListItem Value="New_A2">New with Approver BIFPCL</asp:ListItem>
          <asp:ListItem Value="Renew_A1">ReNew with Approver EPC</asp:ListItem>
        <asp:ListItem Value="Renew_A2">ReNew with Approver BIFPCL</asp:ListItem>
          <asp:ListItem Value="Cancel_A1">Cancel with Approver EPC</asp:ListItem>
        <asp:ListItem Value="Cancel_A2">Cancel with Approver BIFPCL</asp:ListItem>
       <asp:ListItem Value="Approved" Selected="true">Approved ID</asp:ListItem>
      <asp:ListItem Value="Cancelled">Cancelled ID</asp:ListItem>
       <asp:ListItem Value="%">All ID</asp:ListItem>
                                   </asp:RadioButtonList>--%>
                                    <label><b>Report Type:</b></label>
                                    <asp:RadioButtonList ID="rblReportType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="4">
                                        <asp:ListItem Value="application">All Applicants</asp:ListItem>
                                        <asp:ListItem Value="job" Selected="true">Job Posted</asp:ListItem>
                                        <asp:ListItem Value="written">Applicant for Written</asp:ListItem>
                                        <asp:ListItem Value="admit">Admit Card Written D/L </asp:ListItem>
                                        <asp:ListItem Value="admitnot">Admit Card Written Not D/L</asp:ListItem>
                                        <asp:ListItem Value="writtenExcel">Attendance sheet  for Written in Excel</asp:ListItem>
                                        <asp:ListItem Value="interview">Applicant for Interview</asp:ListItem>
<asp:ListItem Value="selected">Applicant for Joining</asp:ListItem>
                                        <asp:ListItem Value="admitInt">Admit Card Interview D/L </asp:ListItem>
                                        <asp:ListItem Value="admitnotInt">Admit Card Interview Not D/L</asp:ListItem>
                                        <asp:ListItem Value="interviewExcel">Attendance sheet  for Interview in Excel</asp:ListItem>
                                        <asp:ListItem Value="admitall">Admit Cards Written PDF All*</asp:ListItem>
                                        <asp:ListItem Value="admitallInt">Admit Cards Interview PDF All*</asp:ListItem>
                                        <asp:ListItem Value="printwritten">Attendance sheet pdf for Written*</asp:ListItem>
                                        <asp:ListItem Value="printinterview">Attendance sheet pdf for Interview*</asp:ListItem>
                                         <asp:ListItem Value="ratinginterview">Rating sheet pdf Manual Interview*</asp:ListItem>
                                          <asp:ListItem Value="paid">List of paid</asp:ListItem>
                                         <asp:ListItem Value="paidUnique">List of paid (unique TxnID)</asp:ListItem>
                                         <asp:ListItem Value="nonpaid">List of unpaid (unique appl.)</asp:ListItem>
                                         <asp:ListItem Value="multi">Multiple application for same TxnID</asp:ListItem>
                                          <asp:ListItem Value="afterinterview">Rating sheet Online Interview</asp:ListItem>
                                          <asp:ListItem Value="afterinterviewpdf">Rating sheet pdf Online Interview*</asp:ListItem>
                                         <asp:ListItem Value="meritsheet">Merit sheet Online Interview</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:Button ID="btnGo" runat="server" Text="Go" Style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%); background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />

                                </fieldset>
                                <br />
                                <fieldset>
                                    <legend style="font-size: 16px; line-height: 1.7; color: #432d2d;"><b>Step 2. Configure Report.</b></legend>
                                    <%--     <asp:LinkButton ID="LinkButton1" runat="server"> <img src="images/xls.gif" width=16 height=16 border=0 align=left /> Click for Excel</asp:LinkButton>
                                    --%>
                                </fieldset>
                            </div>
                            <div id="divReportMessage" runat="server" />
                            <div id="divReportAgency" class="h3" runat="server" />
                            <asp:GridView ID="gvReport" Font-Size="15px" ForeColor="Black" CellPadding="2" CssClass="table-striped" runat="server" />
                            <%--  <div style="overflow-x:auto;width:1200px">
                 <asp:GridView ID="gvReportRaw" Visible="false"  Font-Size="15px" ForeColor="Black"  CellPadding="2" CssClass="table-striped" runat="server" />
           
            </div> --%>
                            <asp:LinkButton ID="lbDownloadSummary" Visible="false" runat="server">Download</asp:LinkButton>
                            <asp:GridView ID="gvReportPic" Visible="false" runat="server" HeaderStyle-CssClass="gvHeader" Caption="View Passes to Approve" CaptionAlign="Left"
                                CssClass="gvRow" AlternatingRowStyle-CssClass="gvAltRow" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%--  <th colspan="6">Category</th>--%>
                                            <tr class="gvHeader">
                                                <th></th>
                                                <th>RollNo</th>
                                                <th>NAME OF APPLICANT</th>
                                                 <th>FATHERs NAME</th>
                                                <th>Interview Slot</th>

                                                 <th>DATE OF BIRTH</th>
                                                <th>NATIONAL ID NUMBER </th>
                                                <%--<th>Age</th>
                                                <th>Marks</th>
                                                <th>Personality(10 Marks)</th>
                                                <th>Attitude(10 Marks)</th>
                                                <th>Intelligence & Alertness/ General Awareness(10 Marks)</th>
                                                <th>Ability to Communicate(10 Marks)</th>
                                                <th>Professional Knowledge (50 Marks)</th>
                                                <th>General Interests (10 Marks)</th>
                                                <th>Total(100 Marks)</th>
                                                <th>Merit</th>--%>
                                                <%--   <th>NATIONAL ID NUMBER</th>--%>
                                               <%-- <th>Post Applied For</th>--%>
                                                <th>Photo</th>
                                                <th>SIGNATURE OF APPLICANT</th>

                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <td><%# Eval("rollno")%></td>
                                            <td><%# Eval("name")%></td>
                                             <td><%# Eval("father")%></td>
                                            <td><%# Eval("slot")%></td>
                                             <td><%# Eval("dob")%></td>
                                            <td><%# Eval("nid")%></td>
                                            <%--<td><%# Eval("age")%></td>
                                            <td><%# Eval("marks")%></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td><%# Eval("merit")%></td>--%>
                                            <%-- <td><%# Eval("idcard")%></td>--%>
                                           <%-- <td><%# Eval("post") & "<br/>" & "<br/>" & "<br/>" & "<br/>" %></td>--%>
                                            <td>
                                                <img src='https://www.bifpcl.com/upload/HR/Career/<%#  Eval("appid") %>.jpg' alt='<%# Eval("appid")%>' width="50" height="75" /></td>
                                            <td><%# Eval("sign")%></td>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div>No Data Available</div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </section>
                <!-- END STATISTIC-->

                <script id="gs-sdk" src='//www.buildquickbots.com/botwidget/v3/demo/static/js/sdk.js?v=3' key="b9ad1fd6-6a0d-418c-a9cf-060471afaa86"></script>

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
            //$('#<%= gvReport.ClientID %>').DataTable();
            var agency = document.getElementById("divReportAgency").innerHTML;
            var groupColumn = 1;
            if ($.fn.dataTable.isDataTable( '#<%= gvReport.ClientID %>')) {
                table = $('#<%= gvReport.ClientID %>').DataTable();
            }
            else {
                var table = $('#<%= gvReport.ClientID %>').DataTable({
                    "scrollX": true,
                    dom: 'Bfrtip',
                    "columnDefs": [{
                        "targets": [0], "visible": false, "searchable": true
                    },
                    {
                        targets: [1],
                        render: function (data, type, row, meta) {
                            data = '<a target=_blank href="hrCareer.aspx?aid=' + row[1] + '&mode=printadmin">' + data + '</a>';
                            return data;
                        }
                    }],
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
                                var logo = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEAAAAA8CAMAAADhV0xWAAAABGdBTUEAALGOfPtRkwAAACBjSFJNAAB6JQAAgIMAAPn/AACA6QAAdTAAAOpgAAA6mAAAF2+SX8VGAAADAFBMVEUAAAAECQYFDwkLCwsJFw0VGhcNIRQQKxkWMB4qKio0NTUdSSshUTAofEQzekhERERLS0tFTFJHXU5OVFpUVFRUXldVWFpbW1tIf1hVa1pXe1xjY2NgamNra2tjdmlzc3NzenZ9d3J7e3tYdopefZZlfpMLmTsRnD8PoD8amUMao0YkgkMin0kwmlEipk0qqlM4qFs2sFw9rGA+smJFjVtEm15OjWJVimJYl2xKqGZKtmtSqW9XuHVhjW9kj3Bpmnd3h3t0lXxipnZiuXtewXtiwn1riodngph4hpN5moN6jqVquYB5qIZ4sohprtt5rM13tdtrxoV2xo17y5GEfXiIhXuQh3+Dg4ODhoqCjoaFioqPh4CPioaLi4uJjZCJm46Kk5iQiYSZkY2Tk5OWmZqclpGemJKbm5uKl6OLmKeJmq6Mn7WTnaWSn62Eo4uKqJOEuJKZqJyWtZ2ap6WauKKimpa9lpanoZujo6OhpqqlqauqpaKtqaWsrKygqbSjtqits7KvvbKzraq2sq2zs7OwuLK3uri5tLG9uLS7u7uEpMiMr8WUq8aWtMaVstObttSBvOGaveOgvt60v8uGxpaG0pmP1aGcxaWV1KSow6+rw7Oi3q+n3LO3xLq12Lus4ri0472Tx+mdwOenxtqtwtCqwdm/wsWzy9q5x9i8zNa5zdi80d2jxOigy+asyuuu1Ouyzu220e251ee80+y+3O+12fC/1vC73fK658PCiYnZi4vTlpbUnZ3dmJjOra3Du7jWp6fUs7PWvr7duLjtjIzmlpbwionmoJ/npaTupaXDw8PAxszHyszJxsPMyMXLy8vFzNPAztjKztLJ1crN09PK19/Vy8rT09PW19jV2dbU2NvY09PY2dbb29vC0uTO2OPE2fHJ3fLW3eLZ3eHC68ja4dzD4fPM5PXV5O3f4uTT4/TU6fbY5vXc6/fc7fjgycnj2trg4N7j4+Pn6Ofp4uHo6Obr6+vk6/Li7Pjl8vrq8/r17e3z8/P0+fz+/v4AAABGOYsjAAABAHRSTlP///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////8AU/cHJQAAAAlwSFlzAAALEgAACxIB0t1+/AAAABl0RVh0U29mdHdhcmUAcGFpbnQubmV0IDQuMC4yMfEgaZUAAAidSURBVFhHjZd/dBRXFce3x1YO64+suDpHtuviaFWoEmKgQOS0QqsJNmoBcfDUsSFjMlorTRpWBu0QmjyB5+/q5pAqgfgLpa31B1YRfyAVVB4k75RiHgVfhbaAUkvDDU4tTHa9b2Z2sxuCx/tHMrP77me+7947976NFf6XMUoIY9HNxHYlgEulFFICgAyMutEX421CAKMSuMMsW3ccXdOlbQsuBZ1QygQAIoVwbNPRLC1lmWnNgVTa1FMMBZFoSZldBsB1zLSTmpMyXIcIzhhIApalmSmDCHGZinEAF59iZZKuwXmwf4GmLoDyjJ00NVeIccGoBDBw7VTaMDEGwFyiVMv1X/70nWsZMjhNOq7hQKWIcgARQHSSJihaEAL50P75jYe/e/8X37/ukERmSrNA8mh9YGUAlA9SYwIAEZG3sh/97KePPPLw/V+9kwAIE4wMLw/mGIACmAncIzDiRa6hwVMnT/xyJ1K+9pntiMgwh0oaOZUB8Pk60TkIp9zd3/sYEv7+r7NnT544sXPnD+6SQNy07Y5pKAIQaug6A8Yi19Au/Pqz+Nd75ukX//M8Qk4+tY4B1w2biqKGIkBKWzckUBk6Fu3Cgd+GF1IeRjvy+NlvYojdhM1k5BgBuLA03QUyzj9/4fd7o6vQjl28eJACT1WZMspmCHCBaiYFWh78wEYqJQU3HDdqJdMQVlQAwLohugVUBKvKbaTys6MXR0dH85wDdU0pxgAMP6D4uvnRujGT2Wz5h8eeP/fSSxcvrpdgJFIQZEIBiOR6RoDr+VJWlkB+ePdvygH+g2eee+7cuX+sBZFkJIijAlCwkxTC6vOQUeYyvO9Ahaynf3769JkzZ3ZwcJJ6EEcFkLaZYFAqIN8HUYzm8O7fVe7r2PceffRXp3/RASKhcxUFBFBwDKRJT4LnFR+PQtSl3Dg+sd7jDz34w5985SBwYqkoIIBx20JIcYEQRSme6kGyUkFgozt+3AHU0nkIkDylM868Uvx8fPlRi7oc7Bo6Py6uynZ850tHVZvBMMYKDjgpF7iX91X/8fziE/H5kH9h/4FL+Pl4FX/9+of4M2bGwmKKFQgknDQQ/Ni3WhyHUOoSDoGL7z22b7/akefh49Qnofkv3nbbp550Mia2yFgBG43lBID8m5q7B0AOdGedPDYlzKf/wv6/KAXgozCV4ICLi7//wXoAy2BcAVgyLYCqb1Y2dw8OAwIG1B3m0+ddQ0KF0fewQBCDf5FkQf6hN2OTTDMRKkhju1bsbEvXoPz34J5s6QWQBPevhhM+3MdCxf9COhlcjW1bc0SgALUIKrF6RGvrvQMSBjdlS8k/TsRoeIX+IKQKstAShOGbAzirAgDVNUw31o2fbVkzIIf5xtbgTmka2v2HSyEgMtwDNTVOuCDYguwAQOwqnD0+PmNN9vMDUioF6s7DtO7d9+dKgDKS9vKMKRU8ADh2WrBAtJ29l5+XfE8zBzWOsJj++Kf9Q3jpEBxUpUqjGZn3GWOGFQJQAs5D9c3Klq6B4fNDm8aCOJTdc9yybM2qWqETjJIadJ6Ttv28i0MEExEADI2HdfDhlm7MwlB3lgfeaKJLeGZDfdJ6TVNHEwMPOCcGDj8ONnALCxgBHJIpOwDA7dmNg9Lj3dmgKpQJ97C3oqFes17bRFzU5VLHwZGfEcIGm1KccupdwEYPqg747dnugfMeFlJX5I8AASsartPM1zfd1YS6KFaGh4i8h11IYAEHADeVltu/5ec3Lm+dO+9vlwa617RG/nmOgI8HgAbyOQXwhcjbho51Da6u2iK+ztgNU6541btPZZfPnVnddgoBzUHAPcc2XMZNq14ztYa1NgY6mNmmafhMuhkTk6AAFKOow+K3Tp869R0zZ1avHtiUXRm8eoDDDhNqWg0pU6tf17Hd81wb51I6pUkXHFeXOBpURwKCJwNx/dunT58xs7p61qo92Y8s3Jz3iKkbukmJ8Ym3IKCJEBeThTUKtqk7mEQajDcE4B6UNb5txowZqAAJzcvnL5hmpNO6nkn2MVRw7eJrr1v7yQ15775TqIw4mEBlUVPFwYY28sT1CoD+NTVz5tTVTSEpTZ+26Nalje+5ozHXm3ufu556W/t39Xl57tmqUCEYbgqAElTH6ZweKqiprX1XXd38xqmvm7ZoydKly5Yty/X09ja23bN6y5b+Xbu2PtFH8TDigRccdQKAOkLByPBNgYLqmppZV79yTt2CBQtuWbJkCQJ6eno+MCXe9m30R8Czz269T63Hk1sJgNUII7ilGxSgpqZ2Vix21aTZi255bwjILZoSjyNg27ZtAaBdqlNcdFoLAXh8Qv8+PjvYQk3dVbFYzHqysa2xre+BXO6N6K4AW7YpBbvaSYtlYzoDzwigCI5lWe4Nyr+mFgEv46fAV+XgH/J0BciFCvrbhUindCfcQAmgBmwio0sxNwji1bFYQrBRH2c+IoSXiBRs69/SgeegjKHbGyLHIqDAzZSepiDvficqeDnugA3lfYEdUHjgk0hB/+bO4RHs+C4vnfNKgAJnmBy09fNm1U6KTVq86oFgLGK6Rg6RqgCw+Z5wSflhdQxQUKdqVQ+yY/YrYq/GNKrjrvSFd3duYTz+ht7eVRskXMBsqUZUsjKASqbKpps077hxPgJu7UOEhM5lPbmbsI5w9+prfEb5cbscEGYTEqaeOHqk6cZ5N9+8uLO9o3FpLte4sF3siR9X/mhlJ+VxgAJFETSuJTUpElIYH23vWN3e3vmFPkNLHgLNQOcRYGPnZGWVANUckmkWZ9BdBXxyMi7Na+JVksc5BojHqW6WHbNDGw8oFCwjmZCgm0AnG2wkm6CTJZ8spCkho9mX/3a7HBBuJMHBSuLJZ8M1CQvvDLNK/WSJFpTbRABEuNgj8AACFw7H1XsjLIu6lT91ijYxQBnOT3GE848dHBJCnaauYFcG/F9WKPwXyceB59vaAI8AAAAASUVORK5CYII=';
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
    <script>
        function go() {
            window.location = $('#divQuickLinks').val();
        }
        $(function () {
            // bind change event to select
            $('#divQuickLinks').on('change', function () {
                var url = $(this).val(); // get selected value
                if (url) { // require a URL
                    window.location = url; // redirect
                }
                return false;
            });
        });
    </script>
    <%--<script type="text/javascript">
        function PrintDiv() {
            var divContents = document.getElementById("divProfile").innerHTML;
            var printWindow = window.open('', '', 'height=600,width=800');
            printWindow.document.write('<html><head><title>Print Application: BIFPCL</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(divContents);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
        }
    </script>--%>
</body>
</html>
