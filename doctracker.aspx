<%@ Page Language="VB" AutoEventWireup="false" CodeFile="doctracker.aspx.vb" Inherits="doctracker" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <!-- Required meta tags-->
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="BIFPCL Official Website" />
    <meta name="author" content="Vinod Kotiya" />
    <meta name="keywords"
        content="NTPC, BIFPCL, Maitree Thermal Power Project, Khulna, Bangladesh India Friendship Power Corporation Limited" />
    <link href='favicon.ico' rel='icon' type='image/x-icon' />

    <!-- Title Page-->

    <title>BIFPCL DocTracker App</title>

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
                        <div class="noti__item js-item-menu" style="margin-left:-100px;" id="divNotificationMobile"
                            runat="server" />
                    </div>

                    <div class="account-wrap" id="divLoginMobile" runat="server">

                    </div>
                </div>
            </div>
            <!-- END HEADER MOBILE -->

            <!-- PAGE CONTENT-->
            <div class="page-content--bgf7">
                <!-- BREADCRUMB-->
                <section class="au-breadcrumb2" style="padding-top:3px;padding-bottom:0px;">
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
                                            <li class="list-inline-item">DocTracker</li>
                                        </ul>
                                    </div>
                                    <div class="rs-select2--dark rs-select2--sm rs-select2--dark2" style="width:300px;">
                                          <select id="divQuickLinks" class="js-select2" name="type" onchange="go()">
                                            <option selected="selected">Quick Links</option>
                                              <option value="hrCareer.aspx?mode=new">New</option>
                                              <option value="doctracker.aspx?mode=report">Report</option>
                                              <option value="doctracker.aspx?mode=email">Email</option>
                                            
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
                                    <span>Doc Tracker App</span>
                                </h1>
                                < <a href="doctracker.aspx"> <button type="button" class="btn btn-link btn-sm">
                                        <i class="fa fa-link"></i>&nbsp; Back</button></a>
                                    <a href="upload/HR/manual/doctrackerhelp.pdf" target="_blank"> <button
                                            type="button" class="btn btn-outline-secondary btn-sm">
                                            <i class="fa fa-lightbulb-o"></i>&nbsp; Help Manual</button> </a>
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
                            <div class="card">
                                <div class="card-header">
                                    <strong>Statistics</strong>
                                </div>
                                <div class="card-body" id="divStats" runat="server">

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-lg-3">
                                    <a style="display:block" href="doctracker.aspx?mode=new">
                                        <div class="statistic__item statistic__item--green">
                                            <h2 class="number">Create Doc</h2>
                                            <span class="desc">Provide the details for creating a new doc.</span>
                                            <div class="icon" style="bottom:0px;right:0px;">
                                                <i class="zmdi zmdi-collection-plus" style="opacity:.4"></i>
                                            </div>
                                        </div>
                                    </a>
                                </div>


                                <div class="col-md-6 col-lg-3">
                                    <a style="display:block" href="doctracker.aspx?mode=ack">
                                        <div class="statistic__item statistic__item--orange">
                                            <h2 class="number">Ack/Mark</h2>
                                            <span class="desc">Take Action on Pending docs.</span>
                                            <div class="icon" style="bottom:0px;right:0px;">
                                                <i class="zmdi zmdi-ticket-star" style="opacity:.4"></i>
                                            </div>
                                        </div>
                                    </a>
                                </div>

                                <div class="col-md-6 col-lg-3">
                                    <a style="display:block" href="doctracker.aspx?mode=track">
                                        <div class="statistic__item statistic__item--blue">
                                            <h2 class="number">Track Doc</h2>
                                            <span class="desc">Track any document</span>
                                            <div class="icon" style="bottom:0px;right:0px;">
                                                <i class="zmdi zmdi-check" style="opacity:.4"></i>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                                <%-- <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="vehicle.aspx?mode=approve">
                            <div class="statistic__item statistic__item--red">
                                <h2 class="number">Change Booking</h2>
                                <span class="desc">HR Section to change the vehicle</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-edit" style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>--%>
                                <div class="col-md-6 col-lg-3">
                                    <a style="display:block" href="doctracker.aspx?mode=report">
                                        <div class="statistic__item statistic__item--red" style="background:#6f42c1">
                                            <h2 class="number">Reports</h2>
                                            <span class="desc">Check various reports</span>
                                            <div class="icon" style="bottom:0px;right:0px;">
                                                <i class="zmdi zmdi-view-list-alt" style="opacity:.4"></i>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                                <div class="col-md-6 col-lg-3">
                                    <a style="display:block" href="doctracker.aspx?mode=mydoc">
                                        <div class="statistic__item statistic__item--red" style="background:#20c997">
                                            <h2 class="number">My Documents</h2>
                                            <span class="desc">List of Doc Initiated by you.</span>
                                            <div class="icon" style="bottom:0px;right:0px;">
                                                <i class="zmdi zmdi-comment-edit" style="opacity:.4"></i>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                                    <div class="col-md-6 col-lg-3">
                                    <a style="display:block" href="doctracker.aspx?mode=correct">
                                        <div class="statistic__item statistic__item--red" style="background:#42c920">
                                            <h2 class="number">Course Correct</h2>
                                            <span class="desc">Make correction in Marking.</span>
                                            <div class="icon" style="bottom:0px;right:0px;">
                                                <i class="zmdi zmdi-block-alt" style="opacity:.4"></i>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlSendEmail" Visible="false" runat="server">

                            <div class="row">
                                 <div class=" col-md-12">
                                <h5>Mail DocTracker Report</h5>
                              <br />  <p>Please mail carefully.</p>
                                     File Pending >=  <asp:TextBox ID="txtMailDays" runat="server" Text="3" Width="50px" MaxLength="2" TextMode="Number"  /> Days
                          <asp:RadioButtonList ID="rblMailReport" runat="server" 
                                                RepeatDirection="Horizontal" RepeatColumns="3">
                                                 <asp:ListItem Value="ACK" Selected="true">File Not ACK/Recieved</asp:ListItem>
                                                 <asp:ListItem Value="MARK">File ACK & Pending</asp:ListItem>
                                             </asp:RadioButtonList>
                                     <asp:Button ID="btnMailReport" runat="server" Text="Step1> Go" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                                  <br />  <br /> &nbsp;&nbsp;&nbsp;<asp:Button ID="btnEmail" runat="server" Text="Step2> Mail to MD & Concern" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                             <-- Don't missuse this feature.
                                     <br />
                                      <asp:Label ID="lbEmailList" runat="server" Text=""></asp:Label>
                            <div id="divMsg" runat="server" />
                                <div id="divExport" runat="server">
                                 <asp:Label ID="lbDetail" runat="server" Text=""></asp:Label>
                            
                             <asp:GridView ID="gvAttendance" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                   <div  id="divLeaveType"  runat="server" />

                            </div>
                                     </div>
                                </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlMybooking" Visible="false" runat="server">
                            <div class="row">
                                <div class=" col-md-12">
                                    <h3 class="mb-3"> Track My Documents </h3>
                                    <asp:GridView ID="gvMyDoc" runat="server" CssClass="table-striped"
                                        AutoGenerateColumns="false" AllowPaging="False" PageSize="11"
                                        AllowCustomPaging="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <%--  <th colspan="6">Category</th>--%>

                                                    <tr class="gvHeader">

                                                        <th></th>
                                                        <th>!</th>
                                                        <th style="padding: 4px;">Doc No</th>
                                                        <th style="padding: 4px;">Doc Date</th>
                                                        <th style="padding: 4px;">Doc Type</th>
                                                        <th style="padding: 4px;">Subject</th>
                                                        <th style="padding: 4px;">Ref</th>
                                                        <th style="padding: 4px;">Status</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td
                                                        style="border-color: cornflowerblue;    border-width: 4px;    background-color: beige;    padding: 8px;">
                                                        <asp:Button ID="btnEdit" runat="server" Text="Track"
                                                            CommandArgument='<%# Eval("docno")%>' />
                                                    </td>
                                                    <td style="padding: 8px;"><%# Eval("docno")%></td>
                                                    <td style="padding: 8px;"><%# Eval("docdate")%></td>
                                                    <td style="padding: 8px;"><%# Eval("doctype")%></td>
                                                    <td style="padding: 8px;"><%# Eval("sub")%></td>
                                                    <td style="padding: 8px;"><%# Eval("ref")%></td>
                                                    <td style="padding: 8px;"><%# Eval("status")%></td>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                    <asp:Label ID="lbMybooking" runat="server" Text="" ForeColor="red"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlReport" runat="server" Visible="false" BorderColor="#3333CC"
                            BorderStyle="Groove" BorderWidth="2px"> <br />
                            <div class="row">
                                <div class=" col-md-12">
                                    <h3 class="mb-3"> Reports </h3>

                                    <div style="padding-left:20px">
                                        <fieldset
                                            style=" padding: 20px; border-style: none dashed dashed dashed; border-width: thin; border-color: #000080; background-color: #FFFFFF; ">
                                            <legend style="font-size: 16px;  line-height: 1.7; color: #432d2d;"><b>Step
                                                    1. Filters:</b></legend>
                                            <asp:DropDownList ID="ddlReportDept" AutoPostBack="true" DataTextField="t"
                                                DataValueField="v" runat="server"></asp:DropDownList>
                                            <br />
                                            <label><b>Document Status:</b></label> &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:RadioButtonList ID="rblReportStatus" runat="server" AutoPostBack="true"
                                                RepeatDirection="Vertical" RepeatColumns="1">
                                               <%-- <asp:ListItem Value="Pending" >Pending</asp:ListItem>--%>
                                            
                                               <asp:ListItem Value="ACK" Selected="true">File Not ACK/Recieved</asp:ListItem>
                                                <asp:ListItem Value="MARK">File ACK & Pending</asp:ListItem>
                                                   <asp:ListItem Value="Closed">File Closed</asp:ListItem>
                                            </asp:RadioButtonList>


                                            <asp:Button ID="btnGo" runat="server" Text="Go"
                                                style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);"
                                                CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />

                                        </fieldset>
                                        <br />
                                        <fieldset>
                                            <legend style="font-size: 16px;  line-height: 1.7; color: #432d2d;"><b>Step
                                                    2. Click on Track to get details.</b></legend>
                                              <asp:Label ID="lbMyReport" runat="server" Text="" ForeColor="red"></asp:Label>
                                            <%--     <asp:LinkButton ID="LinkButton1" runat="server"> <img src="images/xls.gif" width=16 height=16 border=0 align=left /> Click for Excel</asp:LinkButton>
              --%>
                                        </fieldset>
                                    </div>

                                    <asp:GridView ID="gvReport" runat="server" CssClass="table-striped"
                                        AutoGenerateColumns="false" AllowPaging="False" PageSize="11"
                                        AllowCustomPaging="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <%--  <th colspan="6">Category</th>--%>

                                                    <tr class="gvHeader">

                                                        <th></th>
                                                        <th>!</th>
                                                        <th style="padding: 4px;">Doc No</th>
                                                        <th style="padding: 4px;">Doc Date</th>
                                                        <th style="padding: 4px;">Doc Type</th>
                                                        <th style="padding: 4px;">Originator</th>
                                                        <th style="padding: 4px;">Dept</th>
                                                        <th style="padding: 4px;">Subject</th>
                                                        <th style="padding: 4px;">Ref</th>
                                                        <th style="padding: 4px;">Status</th>
                                                         <th style="padding: 4px;">Days Pending</th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td
                                                        style="border-color: cornflowerblue;    border-width: 4px;    background-color: beige;    padding: 8px;">
                                                        <asp:Button ID="btnEdit" runat="server" Text="Track"
                                                            CommandArgument='<%# Eval("docno")%>' />
                                                    </td>
                                                    <td style="padding: 8px;"><%# Eval("docno")%></td>
                                                    <td style="padding: 8px;"><%# Eval("docdate")%></td>
                                                    <td style="padding: 8px;"><%# Eval("doctype")%></td>
                                                    <td style="padding: 8px;"><%# Eval("originator")%></td>
                                                    <td style="padding: 8px;"><%# Eval("dept")%></td>
                                                    <td style="padding: 8px;"><%# Eval("sub")%></td>
                                                    <td style="padding: 8px;"><%# Eval("ref")%></td>
                                                    <td style="padding: 8px;"><%# Eval("status")%></td>
                                                    <td style="padding: 8px;"><%# Eval("dp")%></td>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="pnlApprove" Visible="false" runat="server">
                            <div class="col-md-12">


                                <asp:Panel ID="pnlAssign" runat="server"> <%--<br />
              <div class="bottom_to_top"><a href="asset.aspx"> <<-Back...</a></div>
              <label>Filter:</label>  <asp:DropDownList ID="ddlAdminFilter" runat="server" AutoPostBack="true"  DataValueField="id" DataTextField="type"  class="wrapper-dropdown-5"   EnableViewState="true">
      </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nb
             
               &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox  CssClass="au-input" ID="txtSearchID" runat="server" Width="200px" placeholder ="Search Asset ID, PO, Email"></asp:TextBox>
               &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnRefresh" runat="server" Text="Refresh" />--%>
                                    <h5><b>ACK Section:</b>Documents I Need to Acknowledge on Reciept of File</h5>
                                    <asp:GridView ID="gvAdminStatus" runat="server" CssClass="table-striped"
                                        AutoGenerateColumns="false" AllowPaging="False" PageSize="11"
                                        AllowCustomPaging="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <%--  <th colspan="6">Category</th>--%>

                                                    <tr class="gvHeader">

                                                        <th></th>
                                                        <th>!</th>
                                                         <th style="padding: 4px;">Doc No</th>
                                                        <th style="padding: 4px;">Marked To Me On</th>
                                                        <th style="padding: 4px;">Marked By</th>
                                                        <th style="padding: 4px;">Subject</th>
                                                        <th style="padding: 4px;">Dept</th>
                                                        <th style="padding: 4px;">Originator</th>
                                                        <th style="padding: 4px;">Remark </th>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td
                                                        style="border-color: cornflowerblue;    border-width: 4px;    background-color: beige;    padding: 8px;">
                                                        <asp:Button ID="btnEdit" runat="server" Text="Ack"
                                                            CommandArgument='<%# Eval("uid")%>' />
                                                    </td>
                                                     <td style="padding: 8px;"><%# Eval("docno")%></td>
                                                    <td style="padding: 8px;"><%# Eval("markedon")%></td>
                                                    <td style="padding: 8px;"><%# Eval("markedby")%></td>
                                                    <td style="padding: 8px;"><%# Eval("sub")%></td>
                                                    <td style="padding: 8px;"><%# Eval("dept")%></td>
                                                    <td style="padding: 8px;"><%# Eval("by")%></td>
                                                    <td style="padding: 8px;"><%# Eval("remark")%></td>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                    <button type='button' class='btn btn-info m-l-10 m-b-10'
                                        style='  text-transform: capitalize;'>
                                        <asp:Label ID="lbAckMessage" runat="server" Text="" ForeColor="white">
                                        </asp:Label>
                                    </button>
                                    <br />
                                    <asp:Label ID="lbAssignGrid" runat="server" Text="" ForeColor="red"></asp:Label>
                                    <a name="change"></a>
                                    <asp:Panel ID="pnlAdminEdit" runat="server" Visible="false" BorderColor="#3333CC"
                                        BorderStyle="Groove" BorderWidth="2px"> <br />
                                         &nbsp;&nbsp;&nbsp;&nbsp; <label>Doc ID:</label>
                                        <asp:Label runat="server" id="lblCurrentID"></asp:Label> &nbsp;
                                        &nbsp;&nbsp; <label>Row ID:</label>
                                        <asp:Label runat="server" id="lblUID"></asp:Label><br />
                                         &nbsp;&nbsp;&nbsp;&nbsp; <label>Detail:</label>
                                        <asp:Label runat="server" id="lblCurrentUser"></asp:Label><br />

                                        &nbsp;&nbsp;&nbsp;&nbsp;  <label>Mark To:</label>
                                        <asp:DropDownList ID="ddlMarkTo" AutoPostBack="true" DataTextField="t"
                                            DataValueField="v" runat="server"></asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:CheckBox ID="chkAssignMarkTo" AutoPostBack="true" Text="Show All"
                                            runat="server" />
                                        <br />   &nbsp;&nbsp;&nbsp;&nbsp;Remark <asp:TextBox ID="txtAssignRemark" class="au-input au-input--full"
                                            Width="300" runat="server"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lbAssign" runat="server" Text="" ForeColor="red"></asp:Label>
                                        <br />
                                        <asp:Button ID="btnAssign" cssclass="btn btn-primary m-l-10 m-b-10"
                                            runat="server" Text="Mark" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnReject" cssclass="btn btn-primary m-l-10 m-b-10"
                                            runat="server" Text="Cancel" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;| or &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnDummyClose" cssclass="btn btn-warning m-l-10 m-b-10"
                                            runat="server" Text="Close Document" />
                                        <asp:Button ID="btnClose" Visible="false" cssclass="btn btn-info m-l-10 m-b-10"
                                            runat="server" Text="Yes Close Document" />
                                        <asp:Button ID="btnReject1" Visible="false"  cssclass="btn btn-warning m-l-10 m-b-10"
                                            runat="server" Text="Don't Close" />
                                        <b>*To be exercised by final recipient after approval of CA.</b>
                                        <br />
                                    </asp:Panel>
                                    <h5><b>Mark Section:</b>Documents Held up with me to be Marked to Others after
                                        processing</h5>
                                    <asp:GridView ID="gvChangeGrid" runat="server" CssClass="table-striped"
                                        AutoGenerateColumns="false" AllowPaging="False" PageSize="11"
                                        AllowCustomPaging="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <%--  <th colspan="6">Category</th>--%>

                                                    <tr class="gvHeader">

                                                        <th></th>
                                                        <th>!</th>
                                                         <th style="padding: 4px;">Doc No</th>
                                                        <th style="padding: 4px;">Marked To Me On</th>
                                                        <th style="padding: 4px;">I Ack On</th>
                                                       
                                                        <th style="padding: 4px;">Subject</th>
                                                        <th style="padding: 4px;">Dept</th>
                                                        <th style="padding: 4px;">By</th>
                                                        <th style="padding: 4px;">Remark </th>

                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td
                                                        style="border-color: cornflowerblue;    border-width: 4px;    background-color: beige;    padding: 8px;">
                                                        <asp:Button ID="btnEdit" runat="server" Text="Mark"
                                                            CommandArgument='<%# Eval("uid")%>'
                                                            CssClass="btn-success" />
                                                    </td>
                                                      <td style="padding: 8px;"><%# Eval("docno")%></td>
                                                    <td style="padding: 8px;"><%# Eval("markedon")%></td>
                                                    <td style="padding: 8px;"><%# Eval("ackon")%></td>
                                                  
                                                    <td style="padding: 8px;"><%# Eval("sub")%></td>
                                                    <td style="padding: 8px;"><%# Eval("dept")%></td>
                                                    <td style="padding: 8px;"><%# Eval("by")%></td>
                                                    <td style="padding: 8px;"><%# Eval("remark")%></td>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                    <button type='button' class='btn btn-info m-l-10 m-b-10'
                                        style='  text-transform: capitalize;'>
                                        <asp:Label ID="lbMarkMessage" runat="server" Text="" ForeColor="white">
                                        </asp:Label>
                                    </button>
                                </asp:Panel>

                            </div>
                        </asp:Panel>
                          <asp:Panel ID="pnlCourse" Visible="false" runat="server">
                            <div class="col-md-12">


                                <asp:Panel ID="Panel2" runat="server"> 
                                    <asp:Label ID="Label2" runat="server" Text="Here you can make correction in the marking. eg. If physical file is with X but doctracker is showing Y then make the correction here. Only file originator can make this correction." ForeColor="red"></asp:Label>
                                    <a name="change"></a>
                                    <asp:Panel ID="pnlCorrect" runat="server" Visible="false" BorderColor="#3333CC"
                                        BorderStyle="Groove" BorderWidth="2px"> <br />
                                         &nbsp;&nbsp;&nbsp;&nbsp; <label>Doc ID:</label>
                                        <asp:Label runat="server" id="lbCorrectID"></asp:Label> &nbsp;
                                        &nbsp;&nbsp; <label>Row ID:</label>
                                        <asp:Label runat="server" id="lbCorrectRowID"></asp:Label><br />
                                        
                                        &nbsp;&nbsp;&nbsp;&nbsp;  <label>Mark To:</label>
                                        <asp:DropDownList ID="ddlMarkCorrect" AutoPostBack="true" DataTextField="t"
                                            DataValueField="v" runat="server"></asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:CheckBox ID="cbShowAllCorect" AutoPostBack="true" Text="Show All"
                                            runat="server" />
                                       
                                        <br />
                                        <asp:Label ID="Label6" runat="server" Text="" ForeColor="red"></asp:Label>
                                        <br />
                                        <asp:Button ID="btnCorrecTMark" cssclass="btn btn-primary m-l-10 m-b-10"
                                            runat="server" Text="Correction in Marking" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       
                                        <br />
                                    </asp:Panel>
                                    <h5><b>Mark Section:</b>Documents to be corrected by originator only</h5>
                                    <asp:GridView ID="gvCourse" runat="server" CssClass="table-striped"
                                        AutoGenerateColumns="false" AllowPaging="False" PageSize="11"
                                        AllowCustomPaging="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <%--  <th colspan="6">Category</th>--%>

                                                    <tr class="gvHeader">

                                                        <th></th>
                                                        <th>!</th>
                                                         <th style="padding: 4px;">Doc No</th>
                                                        <th style="padding: 4px;">Marked To</th>
                                                        
                                                        <th style="padding: 4px;">Subject</th>
                                                        <th style="padding: 4px;">Remark </th>

                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <td
                                                        style="border-color: cornflowerblue;    border-width: 4px;    background-color: beige;    padding: 8px;">
                                                        <asp:Button ID="btnEdit" runat="server" Text="Correction"
                                                            CommandArgument='<%# Eval("uid")%>'
                                                            CssClass="btn-success" />
                                                    </td>
                                                      <td style="padding: 8px;"><%# Eval("docno")%></td>
                                                    <td style="padding: 8px;"><%# Eval("marktoname")%></td>
                                                  
                                                    <td style="padding: 8px;"><%# Eval("sub")%></td>
                                                     <td style="padding: 8px;"><%# Eval("remark")%></td>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                    <button type='button' class='btn btn-info m-l-10 m-b-10'
                                        style='  text-transform: capitalize;'>
                                        <asp:Label ID="lbCourse" runat="server" Text="" ForeColor="white">
                                        </asp:Label>
                                    </button>
                                </asp:Panel>

                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlTrack" Visible="false" runat="server">
                            <div class="row">
                                <div class=" col-md-12">
                                    <h3 class="mb-3"> Doc Tracking Status </h3>

                                    &nbsp;&nbsp;&nbsp;Doc Tracking No:* &nbsp;&nbsp;
                                    <asp:TextBox ID="txtDocTrackNo" placeholder=" " MaxLength="12" Width="200px"
                                        class="au-input au-input--full" runat="server" />

                                    <br />&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnTrackDoc" runat="server" Text="Track Doc" Visible="True"
                                        class="au-btn au-btn--block au-btn--green m-b-20" />
                                    <button type='button' class='btn btn-danger m-l-10 m-b-10'
                                        style='  text-transform: capitalize;'>
                                        <asp:Label ID="lbDocTrackMessage" runat="server" Text="" ForeColor="white">
                                        </asp:Label>
                                    </button>
                                    <br /><b> <label>Detail:</label>
                                        <asp:Label runat="server" id="lbDocTrackerDetail"></asp:Label>
                                    </b>
                                    <p> Scroll left to right. Touch enabled.</p>
                                    <asp:GridView ID="gvAllBookings"
                                        class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"
                                        runat="server" EmptyDataText="No Records Available"></asp:GridView>

                                    <asp:Label ID="lbAllBooking" runat="server" Text="" ForeColor="red"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlNewBooking" Visible="false" runat="server" BorderWidth="2px">
                            <h5>DocTracking ID Generation</h5>
                            <p class="text-muted m-b-15"><code>Step1:</code> Fill Details. <code>Step2:</code> Submit
                                <code>Step3:</code> Take Print if required </p> <br />&nbsp;&nbsp;&nbsp;
                            <label>Doc Tracker ID</label>
                            <asp:Label ID="lbID" runat="server" Text="" ForeColor="Green"></asp:Label>

                            &nbsp;&nbsp;&nbsp; Doc Type*: &nbsp;&nbsp; <asp:DropDownList ID="ddlNewType" runat="server">
                                <asp:ListItem Value="Technical Approval Notesheet" Selected="True">Technical Approval
                                    Notesheet</asp:ListItem>
                                <asp:ListItem Value="Administrative Approval Notesheet">Administrative Approval
                                    Notesheet</asp:ListItem>
                                <asp:ListItem Value="Technical cum Admin Approval Notesheet">Technical cum Admin
                                    Approval Notesheet</asp:ListItem>
                                <asp:ListItem value="SAP PR">SAP PR</asp:ListItem>
                                <asp:ListItem value="SAP PO">SAP PO</asp:ListItem>
                                <asp:ListItem value="IOM">IOM</asp:ListItem>
                                <asp:ListItem value="Evaluation Report">Evaluation Report</asp:ListItem>
                                <asp:ListItem value="Review Commitee Report">Review Commitee Report</asp:ListItem>
                                <asp:ListItem value="Bidding Document Approval">Bidding Document Approval</asp:ListItem>
                                <asp:ListItem value="Contract Closing Approval">Contract Closing Approval</asp:ListItem>
                                <asp:ListItem value="Other">Other</asp:ListItem>
                            </asp:DropDownList>

                            &nbsp;&nbsp;&nbsp; <asp:radiobuttonlist ID="rblLoc" RepeatDirection="Horizontal"
                                RepeatColumns="4" runat="server">
                                <asp:ListItem Value="HO">Head Office</asp:ListItem>
                                <asp:ListItem value="SO">Site Office</asp:ListItem>
                            </asp:radiobuttonlist>
                            <br />&nbsp;&nbsp;&nbsp; Ref No/SAP No:* &nbsp;&nbsp;
                            <asp:TextBox ID="txtNewRef" placeholder="BIFPCL/" MaxLength="50" Width="200px"
                                class="au-input au-input--full" runat="server" />
                            &nbsp;&nbsp;&nbsp; Doc Date *
                            <asp:TextBox ID="txtNewDate" runat="server" class="au-input au-input--full"
                                placeholder="Date" Width="200px" />
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd.MM.yyyy"
                                TargetControlID="txtNewDate" />

                            <br /> <br />&nbsp;&nbsp;&nbsp; Subject:* &nbsp;&nbsp;
                            <asp:TextBox ID="txtNewSub" placeholder=" " MaxLength="100" Width="600px"
                                class="au-input au-input--full" runat="server" />
                            <br /> <br />
                            &nbsp;&nbsp;&nbsp; My Dept*: &nbsp;&nbsp; <asp:DropDownList ID="ddlDept" DataTextField="t"
                                DataValueField="v" runat="server">
                            </asp:DropDownList> &nbsp;&nbsp;&nbsp; Approving Authority: &nbsp;&nbsp; <asp:DropDownList
                                ID="ddlNewApprover" runat="server">
                                <asp:ListItem Value="md@bifpcl.com" Selected="True">MD</asp:ListItem>
                                <asp:ListItem value="pd@bifpcl.com">PD</asp:ListItem>
                            </asp:DropDownList>
                            <br /> <br />
                            &nbsp;&nbsp; Marked To*: &nbsp;&nbsp; <asp:DropDownList ID="ddlNewMark" DataTextField="t"
                                DataValueField="v" runat="server">
                            </asp:DropDownList> &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="chkMarkTo" AutoPostBack="true" Text="Show All" runat="server" />

                            <br /><br /> &nbsp;&nbsp;&nbsp; Remarks:
                            <asp:TextBox ID="txtNewRemark" class="au-input au-input--full" runat="server"
                                placeholder=" " TextMode="MultiLine" Height="60px" Width="200px" />

                            <br />&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnNewBook" runat="server" Text="Create Doc" Visible="True"
                                class="au-btn au-btn--block au-btn--green m-b-20" />
                            <br /> <button type='button' class='btn btn-danger m-l-10 m-b-10'
                                style='  text-transform: capitalize;'>
                                <asp:Label ID="lbBookMessage" runat="server" Text="" ForeColor="white"></asp:Label>
                            </button>
                        </asp:Panel>
                        <asp:Panel ID="pnlBookPrint" Visible="false" runat="server" BorderWidth="2px">
                            <h5>Success / Take Print</h5>

                            <asp:Label ID="lbBookMessagePrint" runat="server" Text="" ForeColor="Green"></asp:Label>
                            <br /><br />
                            Note: You can also check status from Doc Tracking section with above doc tracker ID.
                        </asp:Panel>
                    </div>
                </section>
                <!-- END STATISTIC-->



                <!-- COPYRIGHT-->
                <section class="p-t-60 p-b-20">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="copyright">
                                    <p>Copyright © 2018 BIFPCL. All rights reserved. Designed by <a
                                            href="https://bifpcl.com">IT BIFPCL</a>.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- END COPYRIGHT-->
            </div>

        </div>


    </form>
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