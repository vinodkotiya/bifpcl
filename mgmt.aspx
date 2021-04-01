<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mgmt.aspx.vb" Inherits="mgmt" %>
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
                            <h1 class="title-4">Board Members'
                                <span>Dashboard</span>
                            </h1>
                            <hr class="line-seprate">
                        </div>
                    </div>
                </div>
            </section>
            <!-- END WELCOME-->

           <section class="statistic-chart" id="divPIN" runat="server" >
                <div class="container">
                    <div class="row">
                        <div class="col-md-6 col-lg-4">
                            <!-- TOP CAMPAIGN-->
                            <div class="top-campaign">
                       
           <b> <label>Please Enter PIN to proceed:</label></b>
                    <asp:TextBox ID="txtEid" runat="server" placeholder="*****" MaxLength="4" Width="100px"  class="au-input au-input--full"></asp:TextBox> <br /><br />
                
            <asp:Button ID="btnLogin"  class="au-btn au-btn--block au-btn--green m-b-20" runat="server" Text="Sign In" />
       <br /> <h3>Or</h3>
                                Click to use <a href="sso/Default.aspx?appid=12343266"> BIFPCL Login</a> <br /> <br/>
<asp:Label ID="lbLogin" runat="server" Text="Note: Your IP Address and Location are being recorded."></asp:Label>
                </div>
                    </div>
                        </div>
                    </div>
               </section>
            <!-- STATISTIC CHART-->
            <section class="statistic-chart" id="divChart" runat="server" visible="false">
                <div class="container">
                    <div class="row">
                        <%--<div class="col-md-12">
                            <h3 class="title-5 m-b-35">statistics</h3>
                        </div>--%>
                    </div>
                    <div class="row">
                            <div class="col-md-6 col-lg-4">
                            <!-- TOP CAMPAIGN-->
                            <div class="top-campaign">
                                <h3 class="title-3 m-b-30">Major Highlights</h3>
                                <div class="table-responsive">
                                    <table class="table table-top-campaign">
                                        <tbody id="divHigh" runat="server">
                                           
                                            
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!-- END TOP CAMPAIGN-->
                        </div>
                            <div class="col-md-6 col-lg-4">
                            <!-- CHART PERCENT-->
                            <div class="chart-percent-2">
                                <h3 class="title-3 m-b-30" id="divFinProgress"></h3>
                                <div class="chart-wrap">
                                    <canvas id="percent-chart4"></canvas>
                                    <div id="chartjs-tooltip">
                                        <table></table>
                                    </div>
                                </div>
                                <div class="chart-info">
                                    <div class="chart-note">
                                        <span class="dot dot--blue"></span>
                                        <span id="divFinApproved"></span>
                                    </div>
                                    <div class="chart-note">
                                        <span class="dot dot--red"></span>
                                        <span id="divFinRemaining"></span>
                                    </div>
                                </div>
                            </div>
                            <!-- END CHART PERCENT-->
                        </div>
                            <div class="col-md-6 col-lg-4">
                            <!-- CHART PERCENT-->
                            <div class="chart-percent-2">
                                <h3 class="title-3 m-b-30" id="divDrawProgress"></h3>
                                <div class="chart-wrap">
                                    <canvas id="percent-chart3"></canvas>
                                    <div id="chartjs-tooltip3">
                                        <table></table>
                                    </div>
                                </div>
                                <div class="chart-info">
                                    <div class="chart-note">
                                        <span class="dot dot--blue"></span>
                                        <span id="divDrawApprove"></span>
                                    </div>
                                    <div class="chart-note">
                                        <span class="dot dot--red"></span>
                                        <span id="divDrawRemaining"></span>
                                    </div>
                                </div>
                            </div>
                            <!-- END CHART PERCENT-->
                        </div>
                    
                     <div class="col-md-6 col-lg-4">
                            <!-- TOP CAMPAIGN-->
                            <div class="top-campaign">
                                <h3 class="title-3 m-b-30">Critical Issues</h3>
                                <div class="table-responsive">
                                    <table class="table table-top-campaign">
                                        <tbody id="divCritIssue" runat="server">
                                          
                                            
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!-- END TOP CAMPAIGN-->
                        </div>
                            <div class="col-md-6 col-lg-4">
                            <!-- TOP CAMPAIGN-->
                            <div class="top-campaign">
                                <h3 class="title-3 m-b-30">Daily Progress</h3>
                                         <asp:GridView  ID="gvReportTotal"  CaptionAlign="Left" Font-Size="14px" CssClass="table-striped"  runat="server">

                                         </asp:GridView>
                        
                            </div>
                            <!-- END TOP CAMPAIGN-->
                        </div>
                                 <div class="col-md-6 col-lg-4">
                            <!-- TOP CAMPAIGN-->
                            <div class="top-campaign">
                                <h3 class="title-3 m-b-30">Community Development</h3>
                                <div class="table-responsive">
                                    <table class="table table-top-campaign">
                                        <tbody id="divCDA" runat="server">
                                          
                                        
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!-- END TOP CAMPAIGN-->
                        </div>
                    </div>
                </div>
            </section>
          
            <!-- END STATISTIC CHART-->
              <!-- DATA TABLE-->
            <section class="p-t-20" id="divMiles" runat="server" visible="false">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="title-5 m-b-35">Milestones</h3>
                    <div class="table-responsive m-b-40">
                                    <table class="table table-borderless table-data3">
                                        <thead>
                                            <tr>
                                                <th>MILESTONES</th>
                                                <th>U#1 (Months from NTP)</th>
                                                <th>Actual</th>
                                                <th>U#2 (Months from NTP)</th>
                                                <th>Actual</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>NTP</td>
                                                <td>April’ 2017 (0)</td>
                                                <td class="process">April’ 2017</td>
                                                <td>-</td>
                                                <td>-</td>
                                            </tr>
                                             <tr>
                                                <td>START SITE MOBILISATION</td>
                                                <td>May’ 2017(1)</td>
                                                <td  class="process">May’ 2017</td>
                                                <td class="denied">-</td>
                                                <td>-</td>
                                            </tr>
                                            <tr>
                                                <td>START BOILER ERECTION</td>
                                                <td>June’ 2018(14)</td>
                                                <td  class="process">June’ 2018</td>
                                                <td>Dec ’2018(20)</td>
                                                <td  class="process">Dec ’2018</td>
                                            </tr>
                                            <tr>
                                                <td>START STEAM TURBINE GENERATOR(STG) ERECTION</td>
                                                <td>April’ 2019(24)</td>
                                                <td  class="denied">-</td>
                                                <td>Oct’ 2019(30)</td>
                                                <td  class="denied">-</td>
                                            </tr>
                                            <tr>
                                                <td>BOILER HYDRO TEST</td>
                                                <td>July’ 2019(27)</td>
                                                <td  class="denied">-</td>
                                                <td>Jan’ 2020(33)</td>
                                                <td  class="denied">-</td>
                                            </tr>
                                            <tr>
                                                <td>FIRST FIRE (BLU)</td>
                                               <td>April’ 2020(36)</td>
                                                <td  class="denied">-</td>
                                                <td>Oct’ 2020(42)</td>
                                                <td  class="denied">-</td>
                                            </tr>
                                            <tr>
                                                <td>COMPLETION OF STEAM BLOWING</td>
                                                  <td>July’ 2020(39)</td>
                                                <td  class="denied">-</td>
                                                <td>Jan’ 2021(45)</td>
                                                <td  class="denied">-</td>
                                            </tr>
                                             <tr>
                                                <td>FIRST SYNCHRONISATION </td>
                                                  <td>Sept’ 2020(41)</td>
                                                <td  class="denied">-</td>
                                                <td>Mar’ 2021(47)</td>
                                                <td  class="denied">-</td>
                                            </tr>
                                             <tr>
                                                <td>RELIABILITY TEST RUN</td>
                                                  <td>Jan’ 2021(45)</td>
                                                <td  class="denied">-</td>
                                                <td>Jul’ 2021(51)</td>
                                                <td  class="denied">-</td>
                                            </tr>
                                             <tr>
                                                <td>PROVISIONAL ACCEPTANCE CERTIFICATE</td>
                                                  <td>Feb’ 2021(46)</td>
                                                <td  class="denied">-</td>
                                                <td>Aug’ 2021(52)</td>
                                                <td  class="denied">-</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- END DATA TABLE-->

             <!-- STATISTIC-->
            <section class="statistic statistic2" id="divLinks" runat="server" visible="false">
                <div class="container">
                    <div class="row">
                       
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block"  target="_blank" href="https://www.bifpcl.com/upload/TS/Dashboard/synopsis.pdf">
                            <div class="statistic__item statistic__item--green">
                                <h2 class="number">Synopsis</h2>
                                <span class="desc">Get the project synopsis.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-smartphone"  style="opacity:.4"></i>
                                </div>
                            </div>
                            </a>
                        </div>
                            
                      
                        
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block"  target="_blank" href="https://www.bifpcl.com/upload/TS/Dashboard/photo.pdf">
                            <div class="statistic__item statistic__item--blue">
                                <h2 class="number">Progress Photographs</h2>
                                <span class="desc">Click here to see</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-calendar-note"  style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                     <%--   <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="#" target="_blank" >
                            <div class="statistic__item statistic__item--red">
                                <h2 class="number">Community Development</h2>
                                <span class="desc">Medical Camps & CD Activities</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-money" style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>--%>
                           <div class="col-md-12">
                                Latest Video (Bi-Monthly)
            <div class="chart-wrap">
                          <iframe width="560" height="315" src="https://www.youtube-nocookie.com/embed/IpVZggqz-AY?rel=0" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen=""></iframe>      </div>
          <br /><div id="divMsg" runat="server"></div>
                               </div>
                    </div>
                </div>
            </section>
            <!-- END STATISTIC-->
                 <section class="statistic-chart" id="divEdit" visible="false" runat="server" >
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 col-lg-12">
                            <!-- TOP CAMPAIGN-->
                            <div class="top-campaign">
                                 <h3>Update Management Dashboard</h3>

                                Select Section to Update:
                                <asp:DropDownList ID="ddlPostPhase" AutoPostBack="true" runat="server">
                                    <asp:ListItem Value="high">Highlight</asp:ListItem>
                                    <asp:ListItem Value="cric" Selected="true">Critical Issues</asp:ListItem>
                                    <asp:ListItem Value="cda">Community Development</asp:ListItem>
                                     <asp:ListItem Value="eng">Engineering Progress</asp:ListItem>
                                     <asp:ListItem Value="fin">Finance Progress</asp:ListItem>
                                    <asp:ListItem Value="synopsis">Synopsis Upload</asp:ListItem>
                                    <asp:ListItem Value="critical">Critical Issues Upload</asp:ListItem>
                                    <asp:ListItem Value="photo">Project Photographs Upload</asp:ListItem>
                                   </asp:DropDownList>
                            <asp:GridView ID="GridView1" CssClass="table-responsive table-striped " runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource2"
                                    DataKeyNames="uid" EmptyDataText="No records has been added." Caption="Set 1 to enable set 0 to disable" CaptionAlign="Top">
                                    <Columns>
                                        <asp:CommandField ButtonType="Link" ShowEditButton="true" />
                                        <%-- <asp:BoundField DataField="activity" HeaderText="Activity" ReadOnly="true" />--%>
                                        <%--  <asp:BoundField DataField="progdate" HeaderText="Rep Date" ReadOnly="true" />--%>
                                        <%--<asp:BoundField DataField="Scope" HeaderText="Scope" ReadOnly="true" />--%>
                                        <asp:BoundField DataField="uid" HeaderText="uid" ReadOnly="true" />
                                        <asp:TemplateField HeaderText="PrintOrder" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lblvehicle" Width="200" runat="server" Text='<%# Eval("printorder")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbvehicle" Width="200" runat="server" Text='<%# Bind("printorder")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Detail" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_vanue_w" Width="200" runat="server" Text='<%# Eval("desc")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tb_vanue_w" Width="200" runat="server" Text='<%# Bind("desc")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Timeline" ItemStyle-Width="200">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_date_w" Width="200" runat="server" Text='<%# Eval("timeline")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tb_date_w" Width="200" runat="server" Text='<%# Bind("timeline")%>' BackColor="YellowGreen" Font-Bold="false"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                       
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dprdb  %>"
                                    ProviderName="System.Data.SQLite"
                                    SelectCommand="SELECT uid,printorder, desc,timeline from dashboard where type=@type order by printorder asc"
                                    UpdateCommand="update  dashboard set   desc=@desc, timeline=@timeline, printorder=@printorder where uid=@uid">

                                    <UpdateParameters>
                                        <asp:Parameter Name="uid" Type="Double" />
                                        <asp:Parameter Name="desc" Type="String" />
                                        <asp:Parameter Name="timeline" Type="String" />
                                        <asp:Parameter Name="printorder" Type="String" />
                                        </UpdateParameters>

                                    <SelectParameters>
                                        <asp:Parameter Name="type" Type="string" />
                                        <%--  <asp:Parameter Name="unit" Type="Int32" />--%>
                                        <%--<asp:Parameter Name="priority" Type="Int32" />--%>
                                    </SelectParameters>
                                </asp:SqlDataSource>
          <asp:Panel ID="divUpload" runat="server">
               <label>Attach Single PDF</label>
                            <div id="divUploadMsg" runat="server" />

                            <asp:FileUpload ID="FileUploadControl" runat="server" />

                            <asp:Label ID="lbInfo" runat="server" Text="" ForeColor="blue"></asp:Label>
                            <asp:Label ID="lbRemark" runat="server" Text="" ForeColor="blue"></asp:Label>
                            <div class=" col-md-6">
                                <asp:Button ID="btnSumbitPass" OnClick="btnSumbitPass_Click" runat="server" Text="Upload" Visible="True" class="au-btn au-btn--block au-btn--green m-b-20" />
                            </div>
          </asp:Panel>
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
    <script>

        
        try {
            
            $.ajax({
                type: "POST",
                url: "vinservice.asmx/getDBSingleX",
                data: "{type:'ENG'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                   drawings(data.d)
        },
        error: function() {
            alert('Error occured');
        }
            });

            $.ajax({
                type: "POST",
                url: "vinservice.asmx/getDBSingleX",
                data: "{type:'EPC'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                   finance(data.d)
        },
        error: function() {
            alert('Error occured');
        }
            });
       
            function drawings(data) {
                 var approved = data;
         //  console.log(approved);
          $('#divDrawApprove').text("Approved Drawing: " + approved);
            $('#divDrawRemaining').text("Remaining Drawing: " + (6951 - approved));
              $('#divDrawProgress').text("Engineering Progress " + (approved/6951 * 100).toFixed(2) + "%");
           

    // Percent Chart 2
    var ctx = document.getElementById("percent-chart3");
    if (ctx) {
      ctx.height = 209;
      var myChart = new Chart(ctx, {
        type: 'doughnut',
        data: {
          datasets: [
            {
              label: "Drawing",
              data: [approved, 6951-approved],
              backgroundColor: [
                '#00b5e9',
                '#fa4251'
              ],
              hoverBackgroundColor: [
                '#00b5e9',
                '#fa4251'
              ],
              borderWidth: [
                0, 0
              ],
              hoverBorderColor: [
                'transparent',
                'transparent'
              ]
            }
          ],
          labels: [
            'Approved',
            'Remaining'
          ]
        },
        options: {
          maintainAspectRatio: false,
          responsive: true,
          cutoutPercentage: 87,
          animation: {
            animateScale: true,
            animateRotate: true
          },
          legend: {
            display: false,
            position: 'bottom',
            labels: {
              fontSize: 14,
              fontFamily: "Poppins,sans-serif"
            }

          },
          tooltips: {
            titleFontFamily: "Poppins",
            xPadding: 15,
            yPadding: 10,
            caretPadding: 0,
            bodyFontSize: 16,
          }
        }
      });
            }
}
            function finance(data) {
            var epcExecuted = data;
            $('#divFinApproved').text("EPC Executed " + epcExecuted + " USD Mn");
            $('#divFinRemaining').text("EPC Remaining " + (1495 - epcExecuted) + " USD Mn");
              $('#divFinProgress').text("Financial Progress " + (epcExecuted/1495 * 100).toFixed(2) + "%");

            var ctx = document.getElementById("percent-chart4");
    if (ctx) {
      ctx.height = 209;
      var myChart = new Chart(ctx, {
        type: 'doughnut',
        data: {
          datasets: [
            {
              label: "Capex",
              data: [549, 946],
              backgroundColor: [
                '#00b5e9',
                '#fa4251'
              ],
              hoverBackgroundColor: [
                '#00b5e9',
                '#fa4251'
              ],
              borderWidth: [
                0, 0
              ],
              hoverBorderColor: [
                'transparent',
                'transparent'
              ]
            }
          ],
          labels: [
            'Executed',
            'Remaining'
          ]
        },
        options: {
          maintainAspectRatio: false,
          responsive: true,
          cutoutPercentage: 87,
          animation: {
            animateScale: true,
            animateRotate: true
          },
          legend: {
            display: false,
            position: 'bottom',
            labels: {
              fontSize: 14,
              fontFamily: "Poppins,sans-serif"
            }

          },
          tooltips: {
            titleFontFamily: "Poppins",
            xPadding: 15,
            yPadding: 10,
            caretPadding: 0,
            bodyFontSize: 16,
          }
        }
      });
                }
                }
  } catch (error) {
    console.log(error);
  }
    </script>
    <!-- Main JS-->
    <script src="js/main.js"></script>
</body>
</html>
