<%@ Page Language="VB" AutoEventWireup="false" CodeFile="gatepass.aspx.vb" Inherits="gatepass" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <!-- Required meta tags-->
    <meta charset="UTF-8" />
     <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
     <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="BIFPCL Official Website" />
    <meta name="author" content="Vinod Kotiya" />
    <meta name="keywords" content="NTPC, BIFPCL, Maitree Thermal Power Project, Khulna, Bangladesh India Friendship Power Corporation Limited" />
    <link href='favicon.ico' rel='icon' type='image/x-icon'/>

    <!-- Title Page-->
    <title>BIFPCL Online Gate Pass System</title>

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
                                        <li class="list-inline-item">Online QR Gate Pass System</li>
                                    </ul>
                                </div>
                               <div class="rs-select2--dark rs-select2--sm rs-select2--dark2" style="width:300px;">
                                        <select class="js-select2" name="type">
                                            <option selected="selected">Quick Links</option>
                                            <option value=""><a style="display:block" href="dpr.aspx">New Pass</a></option>
                                            <option value=""><a style="display:block" href="dprIssues.aspx">Report</a></option>
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
                            <h1 class="title-4">Online
                                <span>QR Gate Pass System</span> 
                            </h1> <   <a href="gatepass.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>&nbsp; Back</button></a>
                      <a href="download.aspx?file=BIFPCL040219024543.pdf" target="_blank">  <button type="button" class="btn btn-outline-secondary btn-sm">
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
                             <a style="display:block" href="gatepass.aspx?mode=new">
                            <div class="statistic__item statistic__item--green">
                                <h2 class="number">Request New Pass</h2>
                                <span class="desc">Provide the details for issuing new gate pass.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-card"  style="opacity:.4"></i>
                                </div>
                            </div>
                            </a>
                        </div>
                            
                      
                        <div class="col-md-6 col-lg-3">
                               <a style="display:block" href="gatepass.aspx?mode=renew">
                            <div class="statistic__item statistic__item--orange">
                                <h2 class="number">Request Renewal</h2>
                                <span class="desc">Apply for Renewal of gate pass.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-ticket-star" style="opacity:.4"></i>
                                </div>
                            </div>
                                    </a>
                        </div>
                             <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="gatepass.aspx?mode=cancel">
                            <div class="statistic__item statistic__item--blue">
                                <h2 class="number">Request Cancellation</h2>
                                <span class="desc">Cancel gate pass request.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-check"  style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="gatepass.aspx?mode=cover">
                            <div class="statistic__item statistic__item--red" style="background:#6f42c1">
                                <h2 class="number">Print cover Letter</h2>
                                <span class="desc">Print covering letter for validation</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-print" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                               <a style="display:block" href="gatepass.aspx?mode=modifytemp">
                            <div class="statistic__item statistic__item--orange">
                                <h2 class="number">Request Temp to Permanent</h2>
                                <span class="desc">Convert Temporary Pass.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-ticket-star" style="opacity:.4"></i>
                                </div>
                            </div>
                                    </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="gatepass.aspx?mode=modify">
                            <div class="statistic__item statistic__item--red">
                                <h2 class="number">Change Pass</h2>
                                <span class="desc">Make Correction in Pass</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-edit" style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="gatepass.aspx?mode=approve">
                            <div class="statistic__item statistic__item--green">
                                <h2 class="number">Approve Gate Pass</h2>
                                <span class="desc">Approve New/Renewal request or Cancel.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-check"  style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="gatepass.aspx?mode=insurance">
                            <div class="statistic__item statistic__item--red">
                                <h2 class="number">Insurance Detail</h2>
                                <span class="desc">Submit insurance details</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-edit" style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="gatepass.aspx?mode=print">
                            <div class="statistic__item statistic__item--red" style="background:#6f42c1">
                                <h2 class="number">Print QR Gate Pass</h2>
                                <span class="desc">Print approved gate pass with QR Code</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-print" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="gatepass.aspx?mode=report">
                            <div class="statistic__item statistic__item--red" style="background:#20c997">
                                <h2 class="number">Compliance Report</h2>
                                <span class="desc">Get various reports for compliance</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-format-list-bulleted" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="gatepass.aspx?mode=admin">
                            <div class="statistic__item statistic__item--blue">
                                <h2 class="number">Admin Section</h2>
                                <span class="desc">Perform Admin Task</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-wrench"  style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                    </div>
                         </asp:Panel>
                         <asp:Panel ID="pnlAdmin" Visible="false" runat="server">
              
                  <div  class="col-md-12" >
                       <h5>Add new Authorisation</h5>
<%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
    &nbsp;&nbsp;&nbsp;  Agency *-><asp:DropDownList AutoPostBack="true" ID="ddlAdminAgency"  DataTextField="agency" DataValueField="agency" runat="server" ></asp:DropDownList>
                      <asp:TextBox Visible="false" ID="txtAdminAgency" runat="server" placeholder="New Agency" />
     <br /><br />  &nbsp;&nbsp;&nbsp; Email ID*  <asp:TextBox ID="txtAdminMail" runat="server" placeholder="Email" /> <br /><br />
         &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;<asp:Button ID="btnAddAuth" runat="server" Text="Add Authorisation" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                    <asp:Label ID="lbAdmin" runat="server" Text=""></asp:Label>  
                      <hr /> <br /><br />
                      <h5>Authorisation Update</h5><p><br />Please maintain the authorisation record up to date. You can't update agaency name as it will affect the report.
                    <br/> After Giving authorisation level on this screen. Another authorisation to that mail id is required to be given for gatepss.aspx webpage. It can be given only by IT admin page control section.</p>
            <asp:GridView ID="GridView1" CssClass="table-responsive table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource2"
                DataKeyNames="uid"  EmptyDataText="No records has been added." Caption="Set 1 to enable set 0 to disable" CaptionAlign="Top">
                <Columns>

                   <%-- <asp:BoundField DataField="activity" HeaderText="Activity" ReadOnly="true" />--%>
                   <%--  <asp:BoundField DataField="progdate" HeaderText="Rep Date" ReadOnly="true" />--%>
                    <%--<asp:BoundField DataField="Scope" HeaderText="Scope" ReadOnly="true" />--%>
                    <asp:BoundField DataField="uid" HeaderText="SN" ReadOnly="true" />
                   <asp:TemplateField HeaderText="Agency" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblvehicle" Width="200" runat="server" Text='<%# Eval("agency")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbvehicle" Width="200"   runat="server"  Text='<%# Bind("agency")%>'   BackColor="YellowGreen"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" ItemStyle-Width="300">
                        <ItemTemplate>
                            <asp:Label ID="lbldriver" Width="300" runat="server" Text='<%# Eval("email")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbdriver" Width="300"   runat="server"  Text='<%# Bind("email")%>'   BackColor="YellowGreen"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Level" ItemStyle-Width="100">
                      <ItemTemplate>
                            <asp:Label ID="lblDel" Width="50" runat="server" Text='<%# Eval("level")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlDel" runat="server"     selectedvalue='<%# Bind("level")%>'>
                                     <asp:ListItem  Value="new" >New/Cancellation/Renewal</asp:ListItem>                  
                                <asp:ListItem Value="approver1">Approver EPC</asp:ListItem>
                                        <asp:ListItem Value="approver2">Approver BIFPCL</asp:ListItem>
                                       <asp:ListItem Value="">NA</asp:ListItem>
                            </asp:DropDownList>
                         
                        </EditItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:gpdb  %>"
                ProviderName="System.Data.SQLite"
                SelectCommand="SELECT uid, agency, email, level from agency where 1 order by agency "
                UpdateCommand="update  agency set   email=@email, level=@level where uid=@uid">

                <UpdateParameters>
                    <asp:Parameter Name="uid" Type="Double" />
                    <asp:Parameter Name="agency" Type="String" />
                      <asp:Parameter Name="email" Type="String" />
                      <asp:Parameter Name="level" Type="String" />
                      </UpdateParameters>
          
                <SelectParameters>
                  <%--   <asp:Parameter Name="milestone" Type="string" />--%>
                   <%--  <asp:Parameter Name="unit" Type="Int32" />--%>
                     <%--<asp:Parameter Name="priority" Type="Int32" />--%>
                </SelectParameters>
            </asp:SqlDataSource>
                       <hr />
                          <asp:TextBox ID="txtCreateID"  placeholder="Create Gate Pass ID" MaxLength="10" Width="200px"  class="au-input au-input--full"  BackColor="burlywood" runat="server" /> 
               &nbsp;       &nbsp;       &nbsp;       &nbsp;                      <asp:Button ID="btnCreateID" Text="Create ID if not exist" runat="server"  style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
                      <br />
                              <asp:Button ID="btnDownloadDB" Text="Download DB" runat="server"  style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
                      &nbsp;&nbsp;&nbsp;  <asp:Button ID="btnIntegrity" Text="Check DB Integrity" runat="server"  style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
                      &nbsp;&nbsp;&nbsp;
                              <asp:Button ID="btnDownloadPIC" Text="Download Picture" runat="server"  style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
                              &nbsp;&nbsp;&nbsp;        <asp:Button ID="btnDeletePics" Text="Delete 10 thousand old Picture" runat="server"  style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
                      <asp:Label ID="lbCreateID" runat="server"></asp:Label>
      
          
        </div>
        </asp:Panel>
                       <asp:Panel ID="pnlUpdateInsurance" Visible="false" runat="server">
              
                  <div  class="col-md-12" >
                       <h5>Add new Insurance Detail</h5>
<%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
    &nbsp;&nbsp;&nbsp;  Agency *-><asp:DropDownList ID="ddlInsuranceAgency"  DataTextField="agency" DataValueField="agency" runat="server" ></asp:DropDownList>
     <br /><br />  &nbsp;&nbsp;&nbsp; Policy No*  <asp:TextBox ID="txtInsurancePolicy" runat="server" placeholder="Policy No" /> <br /><br />
                &nbsp;&nbsp;&nbsp; No Of Persons Covered*  <asp:TextBox ID="txtInsurancePersons" runat="server" placeholder="Persons" /> <br /><br />
       &nbsp;&nbsp;&nbsp;  Validity Start *<asp:TextBox ID="txtInsuranceValidityStart" runat="server" placeholder="Start Date*" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd.MM.yyyy" TargetControlID="txtInsuranceValidityStart"  /> <br />
<br />
       &nbsp;&nbsp;&nbsp;   Validity End *<asp:TextBox ID="txtInsuranceValidityEnd" runat="server" placeholder="End Date*" />   
         <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd.MM.yyyy" TargetControlID="txtInsuranceValidityEnd"  /> &nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;<asp:Button ID="btnAddInsurance" runat="server" Text="Add Insurance" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                    <asp:Label ID="lbInsuranceMessage" runat="server" Text=""></asp:Label>  
                      <hr /> <br /><br />
                      <h5>Insurance Update</h5><p><br />Please maintain the insurance record up to date.</p>
            <asp:GridView ID="gvDPRDetail" CssClass="table-responsive table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
                DataKeyNames="uid"  EmptyDataText="No records has been added." Caption="Set 1 to enable set 0 to disable" CaptionAlign="Top">
                <Columns>

                   <%-- <asp:BoundField DataField="activity" HeaderText="Activity" ReadOnly="true" />--%>
                   <%--  <asp:BoundField DataField="progdate" HeaderText="Rep Date" ReadOnly="true" />--%>
                    <%--<asp:BoundField DataField="Scope" HeaderText="Scope" ReadOnly="true" />--%>
                    <asp:BoundField DataField="uid" HeaderText="SN" ReadOnly="true" />
                   <asp:TemplateField HeaderText="Agency" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblvehicle" Width="200" runat="server" Text='<%# Eval("agency")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbvehicle" Width="200"   runat="server"  Text='<%# Bind("agency")%>'   BackColor="YellowGreen"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Policy No" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lbldriver" Width="200" runat="server" Text='<%# Eval("policyno")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbdriver" Width="200"   runat="server"  Text='<%# Bind("policyno")%>'   BackColor="YellowGreen"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Validity Start" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblact_ant" Width="200" runat="server" Text='<%# Eval("validity_start")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbact_ant" Width="200"   runat="server"  Text='<%# Bind("validity_start")%>'   BackColor="SkyBlue" Font-Bold="false"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="tbact_ant"  /> <br />

                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Validity End" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblact_ant1" Width="200" runat="server" Text='<%# Eval("validity_end")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbact_ant1" Width="200"   runat="server"  Text='<%# Bind("validity_end")%>'   BackColor="SkyBlue" Font-Bold="false"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="tbact_ant1"  /> <br />

                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Persons Covered" ItemStyle-Width="100">
                      <ItemTemplate>
                            <asp:Label ID="lblSeat" Width="50" runat="server" Text='<%# Eval("persons")%>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                            <asp:TextBox ID="tbdriver1" Width="200"   runat="server"  Text='<%# Bind("persons")%>'   BackColor="YellowGreen"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Remove Policy" ItemStyle-Width="100">
                      <ItemTemplate>
                            <asp:Label ID="lblDel" Width="50" runat="server" Text='<%# Eval("status")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlDel" runat="server"     selectedvalue='<%# Bind("status")%>'>
                                     <asp:ListItem  Value="1" >Yes</asp:ListItem>                  
                                <asp:ListItem Value="0">No</asp:ListItem>
                                       <asp:ListItem Value="">NA</asp:ListItem>
                            </asp:DropDownList>
                         
                         <%--   <asp:TextBox ID="tbRegularise" Width="50"  runat="server" Text='<%# Bind("reg")%>'  BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>--%>
                        </EditItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:gpdb  %>"
                ProviderName="System.Data.SQLite"
                SelectCommand="SELECT uid, agency,policyno,validity_start,validity_end,persons, ifnull(status,0) as status from insurance where 1 order by agency "
                UpdateCommand="update  insurance set  uid = @uid, agency= @agency,policyno=@policyno,validity_start=@validity_start,validity_end=@validity_end,persons=@persons,status=@status where uid=@uid">

                <UpdateParameters>
                    <asp:Parameter Name="uid" Type="Double" />
                    <asp:Parameter Name="agency" Type="String" />
                      <asp:Parameter Name="policyno" Type="String" />
                      <asp:Parameter Name="validity_start" Type="String" />
                     <asp:Parameter Name="validity_end" Type="String" />
                      <asp:Parameter Name="persons" Type="String" />
                    <asp:Parameter Name="status" Type="String" />
                 </UpdateParameters>
          
                <SelectParameters>
                  <%--   <asp:Parameter Name="milestone" Type="string" />--%>
                   <%--  <asp:Parameter Name="unit" Type="Int32" />--%>
                     <%--<asp:Parameter Name="priority" Type="Int32" />--%>
                </SelectParameters>
            </asp:SqlDataSource>
                       
          
        </div>
        </asp:Panel>
                           <asp:Panel ID="pnlCover" Visible="false" runat="server">
                           <div class="col-md-12" >
                               <h3>Print Covering Letter</h3>
                               <asp:radiobuttonlist ID="rblCoverStatus" RepeatDirection="Horizontal"  AutoPostBack="true" runat="server" >
                               <asp:ListItem Value="New" Selected="True" >New</asp:ListItem>
                                       <asp:ListItem Value="Renew">Renewal</asp:ListItem>
                                      <asp:ListItem Value="Cancel">Cancellation</asp:ListItem>
                                   <asp:ListItem Value="Temp">Temporary Pass</asp:ListItem>
                              </asp:radiobuttonlist>
                             
                                &nbsp;&nbsp;&nbsp;  
                         <asp:DropDownList ID="ddlCoverAgency" AutoPostBack="true" DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>

                          &nbsp;       &nbsp;       &nbsp;       &nbsp;         <asp:Button ID="btnPrintCoverLetter" Text="Print Cover Letter for Selected" runat="server"  style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
                              &nbsp;       &nbsp;       &nbsp;       &nbsp;    
                               <asp:Button ID="btnCoverSelectAll" Text="Select All" runat="server"   style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
        
<br /><asp:Label ID="lbCoverType" runat="server" Text="" ForeColor="Green"></asp:Label> <br />
                                 <asp:Label ID="lbMessageCover" runat="server" Text="" ForeColor="red"></asp:Label>
        <asp:GridView ID="gvCover" runat="server" HeaderStyle-CssClass="gvHeader"   Caption="Select pass for cover letter" CaptionAlign="Left"
  CssClass="table-responsive table-striped"  AlternatingRowStyle-CssClass="gvAltRow"  AutoGenerateColumns="false">
  <Columns>    <asp:TemplateField>      <HeaderTemplate>      <%--  <th colspan="6">Category</th>--%>
         <tr class="gvHeader">
          <th></th>
                      <th>! Pass ID</th>
             <th>Name</th>
             <th>Desig</th>
              <th>Validity Start</th>
              <th>End</th>
              <th>Status</th>
                <th>Approved On</th>
             <th>Pic</th>
        </tr>
      </HeaderTemplate> 
      <ItemTemplate>
          <td><asp:checkbox ID="cbSMSSelect"   CssClass="gridCB" runat="server" Text='<%# Eval("id")%>'></asp:checkbox></td>
          <td><%# Eval("name")%></td>
            <td><%# Eval("desig")%></td>
           <td><%# Eval("validity_start")%></td>
           <td><%# Eval("validity_end")%></td>
   <td><%# Eval("status")%></td>
           <td><%# Eval("ApprovedOn")%></td>
          <td><img src='upload/gatepass/<%#  Eval("id") %>.jpg' alt='Eval("id")' width="100" height="150" /></td>
       </ItemTemplate>    </asp:TemplateField>  </Columns>
       <EmptyDataTemplate><div>No Under approval Passes Available for Selected Agency</div></EmptyDataTemplate>    </asp:GridView> 
                         <br /> 
      
      </div>
                         </asp:Panel>
                        <asp:Panel ID="pnlPrint" Visible="false" runat="server">
                           <div class="col-md-12" >
                               <h3>Print Gate Pass</h3>
                               <asp:Label ID="lbApproverPrint" runat="server" Text="" ForeColor="red"></asp:Label>
                                &nbsp;&nbsp;&nbsp;  
                         <asp:DropDownList ID="ddlPrintAgency" AutoPostBack="true" DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>
                                  <asp:DropDownList ID="ddlPrintCompliance" AutoPostBack="true" DataTextField="agency" DataValueField="agency"  runat="server" >
                                      <asp:ListItem Value="%">Compliance</asp:ListItem>
                                       <asp:ListItem Value="Height">Height</asp:ListItem>
                                  </asp:DropDownList>

      <br />      &nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtPrintStart"  placeholder="start ID" TextMode="Number" MaxLength="7" Width="200px"  class="au-input au-input--full" runat="server" /> 
                                &nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtPrintEnd"  placeholder="End ID" TextMode="Number" MaxLength="7" Width="200px"  class="au-input au-input--full" runat="server" /> 
             &nbsp;       &nbsp;       &nbsp;       &nbsp;                      <asp:Button ID="btnSelectID" Text="Select ID in given range" runat="server"  style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
                          &nbsp;       &nbsp;       &nbsp;       &nbsp;         <asp:Button ID="btnPrint" Text="Print Selected" runat="server"  style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
<br /><asp:Label ID="lbPrintMessage" runat="server" Text="" ForeColor="red"></asp:Label>
        <asp:GridView ID="gvPrint" runat="server" HeaderStyle-CssClass="gvHeader"   Caption="View Passes to Approve" CaptionAlign="Left"
  CssClass="gvRow"  AlternatingRowStyle-CssClass="gvAltRow"  AutoGenerateColumns="false">
  <Columns>    <asp:TemplateField>      <HeaderTemplate>      <%--  <th colspan="6">Category</th>--%>
         <tr class="gvHeader">
          <th></th>
                      <th>! Pass ID</th>
             <th>Name</th>
             <th>Desig</th>
              <th>Validity Start</th>
              <th>End</th>
              <th>Status</th>
                <th>Approved On</th>
          <%--   <th>Pic</th>--%>
        </tr>
      </HeaderTemplate> 
      <ItemTemplate>
          <td><asp:checkbox ID="cbSMSSelect"   CssClass="gridCB" runat="server" Text='<%# Eval("id")%>'></asp:checkbox></td>
          <td><%# Eval("name")%></td>
            <td><%# Eval("desig")%></td>
           <td><%# Eval("validity_start")%></td>
           <td><%# Eval("validity_end")%></td>
   <td><%# Eval("status")%></td>
           <td><%# Eval("ApprovedOn")%></td>
         <%-- <td><img src='upload/gatepass/<%#  Eval("id") %>.jpg' alt='Eval("id")' width="100" height="150" /></td>--%>
       </ItemTemplate>    </asp:TemplateField>  </Columns>
       <EmptyDataTemplate><div>No Approved Passes Available for Selected Agency</div></EmptyDataTemplate>    </asp:GridView> 
                         <br /> 
      
      </div>
                         </asp:Panel>
                    <asp:Panel ID="pnlMybooking" Visible="false" runat="server">
                      <div class="row">
                         <div class=" col-md-12">
                          <h3 class="mb-3"> My Bookings </h3>
                             <p> Scroll left to right. Touch enabled.</p>
                             <asp:GridView ID="gvMyBookings" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                   
                              <asp:Label ID="lbMybooking" runat="server" Text="" ForeColor="red"></asp:Label>
                        </div>
                      </div>
                        </asp:Panel>
                      <asp:Panel ID="pnlRenewal" Visible="false" runat="server">
                           <div class="col-md-12" >
                               <h3>Request Renewal of Gate Pass</h3>
                                &nbsp;&nbsp;&nbsp;  
                             <label>Mode:</label><asp:Label ID="lbRenewApprover" runat="server" Text="No Auth"></asp:Label>
                              <asp:DropDownList ID="ddlRenewAgency" AutoPostBack="true" DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>
                            <br />   <asp:Label ID="lbRenewMessage" runat="server" Text="" ForeColor="red"></asp:Label>
        <asp:GridView ID="gvRenewal" runat="server" 
  CssClass="table-responsive table-striped"
  AutoGenerateColumns="false" AllowPaging="False" PageSize="11" AllowCustomPaging="False" >
  <Columns>
    <asp:TemplateField>
      <HeaderTemplate>
      <%--  <th colspan="6">Category</th>--%>
       
        <tr class="gvHeader">
         
            <th></th>
               <th>!</th>
          <th>Pass ID</th>
             <th>Name</th>
             <th>Desig</th>
              <th>Validity Start</th>
              <th>End</th>
              <th>Status</th>
             <%-- <th>Pic</th>--%>
               
        </tr>
      </HeaderTemplate> 
      <ItemTemplate>
              <td><asp:Button ID="btnEdit" runat="server" Text="Renew"  CommandArgument='<%# Eval("id")%>' /></td>
           <td><%# Eval("id")%></td>
       <td><%# Eval("name")%></td>
           <td><%# Eval("desig")%></td>
           <td><%# Eval("validity_start")%></td>
           <td><%# Eval("validity_end")%></td>
           <td><%# Eval("status")%></td>
         <%-- <td><img src='upload/gatepass/<%#  Eval("id") %>.jpg' alt='Eval("id")' width="100" height="150" /></td>--%>
         
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>

                          </asp:GridView>
                         <br /> 
      
      </div>
                         </asp:Panel>
                     <asp:Panel ID="pnlModifyTemp" Visible="false" runat="server">
                           <div class="col-md-12" >
                               <h3>Request Temporary to Normal Gate Pass</h3>
                                &nbsp;&nbsp;&nbsp;  
                             <label>Mode:</label><asp:Label ID="lbModTempApprover" runat="server" Text="No Auth"></asp:Label>
                              <asp:DropDownList ID="ddlModTempAgency" AutoPostBack="true" DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>
                            <br />   <asp:Label ID="lbModTempMessage" runat="server" Text="" ForeColor="red"></asp:Label>
        <asp:GridView ID="gvModifyTemp" runat="server" 
  CssClass="table-responsive table-striped"
  AutoGenerateColumns="false" AllowPaging="False" PageSize="11" AllowCustomPaging="False" >
  <Columns>
    <asp:TemplateField>
      <HeaderTemplate>
      <%--  <th colspan="6">Category</th>--%>
       
        <tr class="gvHeader">
         
            <th></th>
               <th>!</th>
          <th>Pass ID</th>
             <th>Name</th>
             <th>Desig</th>
              <th>Validity Start</th>
              <th>End</th>
              <th>Status</th>
             <%-- <th>Pic</th>--%>
               
        </tr>
      </HeaderTemplate> 
      <ItemTemplate>
              <td><asp:Button ID="btnEdit" runat="server" Text="Apply for Normal"  CommandArgument='<%# Eval("id")%>' /></td>
           <td><%# Eval("id")%></td>
       <td><%# Eval("name")%></td>
           <td><%# Eval("desig")%></td>
           <td><%# Eval("validity_start")%></td>
           <td><%# Eval("validity_end")%></td>
           <td><%# Eval("status")%></td>
         <%-- <td><img src='upload/gatepass/<%#  Eval("id") %>.jpg' alt='Eval("id")' width="100" height="150" /></td>--%>
         
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>

                          </asp:GridView>
                         <br /> 
      
      </div>
                         </asp:Panel>
                          <asp:Panel ID="pnlModify" Visible="false" runat="server">
                           <div class="col-md-12" >
                               <asp:TextBox ID="txtSearchID"  placeholder="ID" MaxLength="10" Width="200px"  class="au-input au-input--full"  BackColor="burlywood" runat="server" /> 
               &nbsp;       &nbsp;       &nbsp;       &nbsp;                      <asp:Button ID="btnSearchID" Text="Show details" runat="server"  style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
      
                               <h3>Make Modification of Gate Pass</h3>
                                &nbsp;&nbsp;&nbsp;  
                             <label>Mode:</label><asp:Label ID="lbModifyApprover" runat="server" Text="No Auth"></asp:Label>
                              <asp:DropDownList ID="ddlMoifyAgency" AutoPostBack="true" DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>
                            <br />   <asp:Label ID="lbModifyMessage" runat="server" Text="" ForeColor="red"></asp:Label>
        <asp:GridView ID="gvModify" runat="server" 
  CssClass="table-responsive table-striped"
  AutoGenerateColumns="false" AllowPaging="False" PageSize="11" AllowCustomPaging="False" >
  <Columns>
    <asp:TemplateField>
      <HeaderTemplate>
      <%--  <th colspan="6">Category</th>--%>
       
        <tr class="gvHeader">
         
            <th></th>
               <th>!</th>
          <th>Pass ID</th>
             <th>Name</th>
             <th>Desig</th>
              <th>Validity Start</th>
              <th>End</th>
              <th>Status</th>
          <%--    <th>Pic</th>--%>
               
        </tr>
      </HeaderTemplate> 
      <ItemTemplate>
              <td><asp:Button ID="btnEdit" runat="server" Text="Modify"  CommandArgument='<%# Eval("id")%>' /></td>
           <td><%# Eval("id")%></td>
       <td><%# Eval("name")%></td>
           <td><%# Eval("desig")%></td>
           <td><%# Eval("validity_start")%></td>
           <td><%# Eval("validity_end")%></td>
           <td><%# Eval("status")%></td>
       <%--   <td><img src='upload/gatepass/<%#  Eval("id") %>.jpg' alt='Eval("id")' width="100" height="150" /></td>--%>
         
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>

                          </asp:GridView>
                         <br /> 
      
      </div>
                         </asp:Panel>
                       <asp:Panel ID="pnlCancellation" Visible="false" runat="server">
                           <div class="col-md-12" >
                               <h3>Request Cancellation of Gate Pass</h3>
                                &nbsp;&nbsp;&nbsp;  
                             <label>Mode:</label><asp:Label ID="lbCancelApprover" runat="server" Text="No Auth"></asp:Label>
                              <asp:DropDownList ID="ddlCancelAgency" AutoPostBack="true" DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>
                            <br />   <asp:Label ID="lbCancelMessage" runat="server" Text="" ForeColor="red"></asp:Label>
        <asp:GridView ID="gvCancel" runat="server" 
  CssClass="table-responsive table-striped"
  AutoGenerateColumns="false" AllowPaging="False" PageSize="11" AllowCustomPaging="False" >
  <Columns>
    <asp:TemplateField>
      <HeaderTemplate>
      <%--  <th colspan="6">Category</th>--%>
       
        <tr class="gvHeader">
         
            <th></th>
               <th>!</th>
          <th>Pass ID</th>
             <th>Name</th>
             <th>Desig</th>
              <th>Validity Start</th>
              <th>End</th>
              <th>Status</th>
          <%--    <th>Pic</th>--%>
               
        </tr>
      </HeaderTemplate> 
      <ItemTemplate>
              <td><asp:Button ID="btnEdit" runat="server" Text="Cancel"  CommandArgument='<%# Eval("id")%>' /></td>
           <td><%# Eval("id")%></td>
       <td><%# Eval("name")%></td>
           <td><%# Eval("desig")%></td>
           <td><%# Eval("validity_start")%></td>
           <td><%# Eval("validity_end")%></td>
           <td><%# Eval("status")%></td>
       <%--   <td><img src='upload/gatepass/<%#  Eval("id") %>.jpg' alt='Eval("id")' width="100" height="150" /></td>--%>
         
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>

                          </asp:GridView>
                         <br /> 
      
      </div>
                         </asp:Panel>
                     <asp:Panel ID="pnlApprove" Visible="false" runat="server">
                           <div class="col-md-12" >
                               <h3>Approve Gate Pass</h3>
                                &nbsp;&nbsp;&nbsp;  
                             <label>Mode:</label><asp:Label ID="lbApprover" runat="server" Text="No Auth"></asp:Label>
                                  &nbsp;&nbsp;<asp:DropDownList ID="ddlApproverAgency" AutoPostBack="true" DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;    <asp:radiobuttonlist ID="rblApproveType" RepeatDirection="Horizontal"  AutoPostBack="true" runat="server" >
                               <asp:ListItem Value="New" Selected="True" >New</asp:ListItem>
                                       <asp:ListItem Value="Renew">Renewal</asp:ListItem>
                                      <asp:ListItem Value="Cancel">Cancellation</asp:ListItem>
                              </asp:radiobuttonlist>
<asp:Button ID="btnApprove" Text="Approve Single" runat="server"  style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
             &nbsp;       &nbsp;       &nbsp;       &nbsp;                  <asp:Button ID="btnAproveBulk" Text="Approve Selected(Bulk)"  runat="server"  style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
             &nbsp;       &nbsp;       &nbsp;       &nbsp;                      <asp:Button ID="btnReject" Text="Reject Single" runat="server" Enabled="false"  style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
          &nbsp;       &nbsp;       &nbsp;       &nbsp; &nbsp;       &nbsp;       &nbsp;       &nbsp; &nbsp;       &nbsp;       &nbsp;       &nbsp; &nbsp;       &nbsp;       &nbsp;       &nbsp; &nbsp;       &nbsp;       &nbsp;       &nbsp; &nbsp;       &nbsp;       &nbsp;       &nbsp; &nbsp;       &nbsp;       &nbsp;       &nbsp; &nbsp;       &nbsp;       &nbsp;       &nbsp;
                               &nbsp;       &nbsp;       &nbsp;       &nbsp;               
                               <asp:Button ID="btnSMSSelectAll" Text="Select All" runat="server"   style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
         <br /> <asp:Label ID="lbApprovePass" runat="server" Text="" ForeColor="red"></asp:Label>
                               <asp:LinkButton ID="lbDownloadApprove" runat="server">Download</asp:LinkButton>
        <asp:GridView ID="gvPassApprove" runat="server" HeaderStyle-CssClass="gvHeader"   Caption="View Passes to Approve" CaptionAlign="Left"
  CssClass="table-responsive table-striped"  AlternatingRowStyle-CssClass="gvAltRow"  AutoGenerateColumns="false">
  <Columns>    <asp:TemplateField>      <HeaderTemplate>      <%--  <th colspan="6">Category</th>--%>
         <tr class="gvHeader">
          <th></th>
                      <th>! Pass ID</th>
             <th>Name</th>
              <th>Agency</th>
             <th>Desig</th>
             <th>Cat</th>
            
             <th>DOB</th>
             <th>NID</th>
              <th>Validity Start</th>
              <th>End</th>
               <th>Pic</th>
              <th>Cross Check</th>
              <th>EPC Approve On</th>
              <th>SubAgency</th>
              <th>Compliance</th>
             <th>Remark</th>
              <th>Status</th>
              
            
        </tr>
      </HeaderTemplate> 
      <ItemTemplate>
          <td><asp:checkbox ID="cbSMSSelect"   CssClass="gridCB" runat="server" Text='<%# Eval("id")%>'></asp:checkbox></td>
          <td><%# Eval("name")%></td>
           <td><%# Eval("agency")%></td>
           <td><%# Eval("desig")%></td>
            <td><%# Eval("cat")%></td>
           
          <td><%# Eval("dob")%></td>
          <td><%# Eval("nid")%></td>
           <td><%# Eval("validity_start")%></td>
           <td><%# Eval("validity_end")%></td>
            <td>-<%--<img src='upload/gatepass/<%#  Eval("id") %>.jpg' alt='Eval("id")' width="100" height="150" />--%></td>
           <td><%# Eval("crosscheck")%></td>
            <td><%# Eval("approve1_dt")%></td>
           <td><%# Eval("subagency")%></td>
           <td><%# Eval("compliance")%></td>
           <td><%# Eval("remark")%></td>
           <td><%# Eval("status")%></td>
        
        
       </ItemTemplate>    </asp:TemplateField>  </Columns>
       <EmptyDataTemplate><div>No Data Available</div></EmptyDataTemplate>    </asp:GridView> 
                
      
      </div>
                         </asp:Panel>
                     <asp:Panel ID="pnlReportInsurance" Visible="false" runat="server">
                      <div class="row">
                         <div class=" col-md-12">
                          <h3 class="mb-3"> Report for Bookings </h3>
                             <p> Scroll left to right. Touch enabled.</p>
                             <asp:GridView ID="gvAllBookings" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                   
                              <asp:Label ID="lbAllBooking" runat="server" Text="" ForeColor="red"></asp:Label>
                        </div>
                      </div>
                        </asp:Panel>
                      <asp:Panel ID="pnlNewPass" Visible="false" runat="server" BorderWidth="2px">
                         <div id="divNew" runat="server" />
<%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
       	<p class="text-muted m-b-15">Please read help manual given above.Follow these steps: 
											<br /><code>Step1:</code> Fill Details. <code>Step2:</code> Attach Picture from choose file and Click upload picture. <code>Step3:</code> Click Green Submit Button </p>  <br />&nbsp;&nbsp;&nbsp;           
                          <label>Gate Pass ID</label> <asp:Label ID="lbID" runat="server" Text="" ForeColor="Green"></asp:Label> <br />
                         

                   &nbsp;&nbsp;&nbsp;        <asp:Label ID="lbNewApprover" runat="server" Text="No Auth"></asp:Label>
                           &nbsp;&nbsp;&nbsp;        <asp:Label ID="lbNewApproverType" runat="server" Text=""></asp:Label>
                          <br /> <div id="divPic" runat="server" style="height:100px;width:100px;" /> <asp:FileUpload ID="FileUpload1" runat="server"  />
<asp:Button ID="btnUpload" Text="Upload Picture" runat="server" OnClick="UploadFile" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10"  />
<asp:Label ID="lbPicStatus" runat="server" Text="Pic Not Uploaded" ForeColor="Blue"></asp:Label>
<hr />
                        <button type='button' class='btn btn-danger m-l-10 m-b-10' style='  text-transform: capitalize;'>
                                                     <asp:Label ID="lbBookMessageTop" runat="server" Text="" ForeColor="white"></asp:Label>
                            </button>
              <br /> &nbsp;&nbsp;&nbsp;  <asp:RadioButtonList ID="rblNewPassType" style="display:inline-block" runat="server"  RepeatDirection="Horizontal"  RepeatColumns="3">
                                <asp:ListItem Value="T" >Temporary (7 Days) Pass&nbsp;&nbsp;</asp:ListItem> 
                               <asp:ListItem Value="P" Selected="true">Long Validity Pass</asp:ListItem>
                                 </asp:RadioButtonList><br />&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtNewName"  placeholder="Name" MaxLength="50" Width="200px"  class="au-input au-input--full" runat="server" /> 
  &nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtNewFather"  placeholder="Father" Width="200px"  MaxLength="50"   class="au-input au-input--full" runat="server" />  
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:RadioButtonList ID="rblCorona" style="display:inline-block" runat="server"  RepeatDirection="Horizontal"  RepeatColumns="3">
                                <asp:ListItem Value="PC" Selected="true">Post-Corona</asp:ListItem> 
                               <asp:ListItem Value="NA" >NA</asp:ListItem>
                                 </asp:RadioButtonList>
              <br />  <br /> &nbsp;&nbsp;&nbsp;   Sex: <asp:DropDownList ID="ddlNewSex" AutoPostBack="true" runat="server" >
                               <asp:ListItem Value="Male">Male</asp:ListItem>
                                       <asp:ListItem Value="Female">Female</asp:ListItem>
                                     <asp:ListItem  Value="Trans" >Other</asp:ListItem>  
                              </asp:DropDownList>
 &nbsp;&nbsp;&nbsp;  <label>Date of Birth </label> *<asp:TextBox ID="txtDoB" runat="server"  MaxLength="15"   class="au-input au-input--full" placeholder="Date" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd.MM.yyyy" TargetControlID="txtDoB"  />
  
  <br />  <br />&nbsp;&nbsp;&nbsp;  Nationality * <asp:DropDownList ID="ddlNewNation" DataTextField="nationality" DataValueField="nationality"  runat="server" ></asp:DropDownList>
                           &nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtNewNID"  MaxLength="50"  placeholder="NID/Passport No*" Width="200px"  class="au-input au-input--full" runat="server" /> 
                           <asp:Label ID="lblDuplicate" runat="server" ForeColor="PaleVioletRed" />
                        <br />    <br />&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtNewVillage"  MaxLength="20"  placeholder="Village" Width="200px"  class="au-input au-input--full" runat="server" /> 
  &nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtNewPO"  placeholder="Post Office" Width="200px"  MaxLength="20"  class="au-input au-input--full" runat="server" />  
            
                          &nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtNewPS"  MaxLength="20"  placeholder="Police Station" Width="200px"  class="au-input au-input--full" runat="server" /> 
   <br /> <br />&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtNewDistrict"  MaxLength="20"  placeholder="District" Width="200px"  class="au-input au-input--full" runat="server" />  
                     &nbsp;&nbsp;&nbsp;      <asp:TextBox ID="txtNewCell"  placeholder="Contact No"  MaxLength="20"  Width="200px"  class="au-input au-input--full" runat="server" />  
              &nbsp;&nbsp;&nbsp;   <asp:DropDownList ID="ddlBlood" runat="server">
                                        <asp:ListItem Value="NA">Select Blood Group</asp:ListItem>
                                      <asp:ListItem>A+</asp:ListItem>
                                       <asp:ListItem>A-</asp:ListItem>
                                       <asp:ListItem>B+</asp:ListItem>
                                       <asp:ListItem>B-</asp:ListItem>
                                       <asp:ListItem>O+</asp:ListItem>
                                       <asp:ListItem>O-</asp:ListItem>
                                       <asp:ListItem>AB+</asp:ListItem>
                                       <asp:ListItem>AB-</asp:ListItem>
                                  </asp:DropDownList>
  <br />  <br />
                           &nbsp;&nbsp;&nbsp;    Main Agency: <asp:DropDownList ID="ddlNewVendor"  runat="server" >
                               <asp:ListItem Value="BHEL">BHEL</asp:ListItem>
                                       <asp:ListItem Value="BIFPCL">BIFPCL</asp:ListItem>
                                 </asp:DropDownList>
                          &nbsp;&nbsp;&nbsp;  Agency * <asp:DropDownList ID="ddlNewAgency" AutoPostBack="true"  DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>
                       &nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtNewSubAgency"  MaxLength="20"  placeholder="Sub Agency" Width="200px"  class="au-input au-input--full" runat="server" />  
            <br />  <br />                             &nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtNewDesig"  MaxLength="20"  placeholder="Designation" Width="200px"  class="au-input au-input--full" runat="server" /> 
                             &nbsp;&nbsp;&nbsp;   <asp:DropDownList ID="ddlNewCat" runat="server">
                                        <asp:ListItem Value="NA">Select Category</asp:ListItem>
                                      <asp:ListItem>UNSKILLED</asp:ListItem>
                                       <asp:ListItem>SEMISKILLED</asp:ListItem>
                                       <asp:ListItem>SKILLED</asp:ListItem>
                                       <asp:ListItem>HIGHLYSKILLED</asp:ListItem>
                                       <asp:ListItem>SUPERVISOR</asp:ListItem>
                                       <asp:ListItem>ENGINEER</asp:ListItem>
                                       <asp:ListItem>OTHERS</asp:ListItem>
                                 </asp:DropDownList>
                              &nbsp;&nbsp;&nbsp;   <asp:DropDownList ID="ddlNewWorkArea" DataTextField="t" DataValueField="v"  runat="server" ></asp:DropDownList>
      &nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlNewCompliance" AutoPostBack="true" DataTextField="agency" DataValueField="agency"  runat="server" >
                                      <asp:ListItem Value="">Compliance</asp:ListItem>
                                       <asp:ListItem Value="Height">Height</asp:ListItem>
           <asp:ListItem Value="Others">Others</asp:ListItem>
                                  </asp:DropDownList>
                          <asp:Label ID="lbNewAge" runat="server" />
      <br />  <br />
                          &nbsp;&nbsp;&nbsp;  <label>Pre Test Date* </label> <asp:TextBox ID="txtNewPreTestDate" runat="server"  MaxLength="15"   class="au-input au-input--full" placeholder="Date" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd.MM.yyyy" TargetControlID="txtNewPreTestDate"  />
  
                          &nbsp;&nbsp;&nbsp;  <label>Post Test Date(14D)* </label> <asp:TextBox ID="txtNewPostTestDate" runat="server"  MaxLength="15"   class="au-input au-input--full" placeholder="Date" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender10" runat="server" Format="dd.MM.yyyy" TargetControlID="txtNewPostTestDate"  />
                           &nbsp;&nbsp;&nbsp;  <label>Temperature(eg. 96.7)* </label> <asp:TextBox ID="txtNewTemperature" runat="server"  MaxLength="5"   class="au-input au-input--full" placeholder="F" Width="70px" />
                         <br />  <br />
                          &nbsp;&nbsp;&nbsp;  <label>Validity Start </label> *<asp:TextBox ID="txtNewValidityStart" runat="server"  MaxLength="15"   class="au-input au-input--full" placeholder="Date" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd.MM.yyyy" TargetControlID="txtNewValidityStart"  />
  
                          &nbsp;&nbsp;&nbsp;  <label>Validity End </label> *<asp:TextBox ID="txtNewValidityEnd" runat="server"  MaxLength="15"   class="au-input au-input--full" placeholder="Date" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd.MM.yyyy" TargetControlID="txtNewValidityEnd"  />
   &nbsp;&nbsp;&nbsp;  <asp:DropDownList ID="ddlNewChangeStatus" Visible="false" runat="server">
                                        <asp:ListItem Value="NA">Change Status of Pass</asp:ListItem>
                                        <asp:ListItem Value="Temp">Temporary</asp:ListItem>
        <asp:ListItem Value="Approved">Approved</asp:ListItem>
        <asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
                                       <asp:ListItem Value="Cancel_A2">Cancel with BIFPCL</asp:ListItem>
         <asp:ListItem Value="Cancel_A1">Cancel with EPC</asp:ListItem>
          <asp:ListItem Value="Renew_A2">Renew with BIFPCL</asp:ListItem>
                                       <asp:ListItem Value="Renew_A1">Renew with EPC</asp:ListItem>
        <asp:ListItem Value="New_A2">New with BIFPCL</asp:ListItem>
                                        <asp:ListItem Value="New_A1">New with EPC</asp:ListItem>
           <asp:ListItem Value="Deleted">Expelled the Pass</asp:ListItem>
                                  </asp:DropDownList>
                          <asp:RadioButtonList ID="rblNewCancelRemark" Visible="false" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="3">
                                <asp:ListItem Value="Gate Pass Surrendered" >Gate Pass Surrendered</asp:ListItem>
        <asp:ListItem Value="Gate Pass Lost/No FIR">Gate Pass Lost/No FIR</asp:ListItem>
          <asp:ListItem Value="Gate Pass Lost/FIR Done">Gate Pass Lost/FIR Done</asp:ListItem>
                                <asp:ListItem Value="NA">NA</asp:ListItem>
                               <asp:ListItem Value="Red" Selected="true" >Change GP Red</asp:ListItem>
                              <asp:ListItem Value="Green" >Change GP Green</asp:ListItem>
                                 </asp:RadioButtonList>
                           <br />  <br />
                            &nbsp;&nbsp;&nbsp; <label>Visa No </label> <asp:TextBox ID="txtNewVisa"  MaxLength="50"  placeholder="VISA No" Width="200px"  class="au-input au-input--full" runat="server" />  
                          &nbsp;&nbsp;&nbsp;  <label>Visa Expiry Date </label> <asp:TextBox ID="txtNewVisaExp" runat="server"  MaxLength="15"   class="au-input au-input--full" placeholder="Date" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender8" runat="server" Format="dd.MM.yyyy" TargetControlID="txtNewVisaExp"  />
  
                          <br />  <br />
                           &nbsp;&nbsp;&nbsp;    Mode: <asp:Label ID="lbNewMode" runat="server" Text="New" ForeColor="red"></asp:Label>
                         &nbsp;&nbsp;&nbsp;  <asp:Label ID="lbInfo" runat="server" Text="" ForeColor="blue"></asp:Label>
                            &nbsp;&nbsp;&nbsp;  <asp:Label ID="lbRemark" runat="server" Text="" ForeColor="blue"></asp:Label>
         <br />&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;<asp:Button ID="btnSumbitPass" runat="server" Text="Book" Visible="True"  class="au-btn au-btn--block au-btn--green m-b-20" />
          <br />&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;
                          <button type='button' class='btn btn-danger m-l-10 m-b-10' style=' white-space: normal;  text-transform: capitalize;'>
                              <asp:Label ID="lbBookMessage" runat="server" Text="" ForeColor="white"></asp:Label>
                              </button>
                       <br />   <button type='button' class='btn btn-info m-l-10 m-b-10' style=' white-space: normal;  text-transform: capitalize;'>
                              <asp:Label ID="lbInsuranceDetail" runat="server" Text="Insurance Detail" ForeColor="white"></asp:Label>
                              </button>
                           <asp:GridView ID="gvInsuranceDetail"  Font-Size="15px" ForeColor="Black"  CellPadding="2" CssClass="table-responsive table-striped" runat="server" />
           

         </asp:Panel>
        <asp:Panel ID="pnlReport" Visible="false" runat="server">
              <h5>Gate Pass Reports</h5>
<%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
    <div style="padding-left:20px" >
              <fieldset style="border-style: none dashed dashed dashed; border-width: thin; border-color: #000080; background-color: #FFFFFF; ">
                  <legend  style="font-size: 16px;  line-height: 1.7; color: #432d2d;"><b>Step 1. Filters:</b></legend>
 <asp:DropDownList ID="ddlReportAgency" AutoPostBack="true" DataTextField="agency" DataValueField="agency"  runat="server" ></asp:DropDownList>
    <br />
                     <label><b>Report Type:</b></label>    <asp:RadioButtonList ID="rblReportType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="6">
                                  <asp:ListItem Selected="true"  Value="ID" >* ID Status</asp:ListItem>                  
                                <asp:ListItem Value="Insurance" >Insurance</asp:ListItem>
                          <asp:ListItem Value="InsuranceDue" >Insurance Due</asp:ListItem>
        <asp:ListItem Value="photo">ID without Photo</asp:ListItem>
                     <asp:ListItem Value="log">Log</asp:ListItem>
                    <asp:ListItem Value="due">ID due for Renewal</asp:ListItem>
                           <asp:ListItem Value="duplicate">Duplicate ID</asp:ListItem>
                       <asp:ListItem Value="agency">Agencywise Summary *</asp:ListItem>
                          <asp:ListItem Value="agencynation">Agencywise Nationality Summary</asp:ListItem>
                  <asp:ListItem Value="Red">Red Pass *</asp:ListItem>
                          <asp:ListItem Value="Green">Green Pass *</asp:ListItem>
                          <asp:ListItem Value="PC">Post Corona *</asp:ListItem>
                          <asp:ListItem Value="samenid">Similar ID</asp:ListItem>
                          <asp:ListItem Value="samedob">Same DoB</asp:ListItem>
                          <asp:ListItem Value="samename">Same Name</asp:ListItem>
                          <asp:ListItem Value="samefather">Same Fathername</asp:ListItem>
                                  </asp:RadioButtonList>
                  <label><b>*ID Status:</b></label>  &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButtonList ID="rblReportStatus" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="3">
                             <asp:ListItem Value="New_A1">New with Approver EPC</asp:ListItem>
        <asp:ListItem Value="New_A2">New with Approver BIFPCL</asp:ListItem>
          <asp:ListItem Value="Renew_A1">ReNew with Approver EPC</asp:ListItem>
        <asp:ListItem Value="Renew_A2">ReNew with Approver BIFPCL</asp:ListItem>
          <asp:ListItem Value="Cancel_A1">Cancel with Approver EPC</asp:ListItem>
        <asp:ListItem Value="Cancel_A2">Cancel with Approver BIFPCL</asp:ListItem>
                         <asp:ListItem Value="Cancel_A">Under Cancellation(EPC + BIFPCL)</asp:ListItem>
       <asp:ListItem Value="Approved" Selected="true">Approved ID</asp:ListItem>
      <asp:ListItem Value="Cancelled">Cancelled ID</asp:ListItem>
       <asp:ListItem Value="%">Any Status</asp:ListItem>
                       <asp:ListItem Value="ApprovedValid" >Valid GP(TS)</asp:ListItem>
                       <asp:ListItem Value="Temp" >Temporary Pass</asp:ListItem>
                                   </asp:RadioButtonList>
           
               <label><b>Date Filter *:</b></label>     <asp:RadioButtonList ID="rblReportDTCol" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="7">
                    <asp:ListItem Selected="true"  Value="No">No Date Filter</asp:ListItem>             
                   <asp:ListItem  Value="first_apply_dt" >First Apply Date</asp:ListItem> 
                      <asp:ListItem  Value="last_renewal_apply_dt" >Renewal Apply Date</asp:ListItem> 
                                <asp:ListItem Value="approve1_dt" >EPC Approval Date</asp:ListItem>
        <asp:ListItem Value="approve2_dt">BIFPCL Approval Date</asp:ListItem>
                     <asp:ListItem Value="last_renewal_issue_dt">Last Renewal Issue Date</asp:ListItem>
                    <asp:ListItem Value="cancel_approve_dt">Cancellation Date</asp:ListItem>
                        <asp:ListItem Value="last_updated">Last Updated</asp:ListItem>
                                  </asp:RadioButtonList>
                   Start:
                <asp:TextBox ID="txtReportStDate" runat="server" placeholder="" Text="" Width="200"  class="au-input au-input--full"  />
                <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtReportStDate" Format="dd.MM.yyyy">
                                    </asp:CalendarExtender>
                End:
                <asp:TextBox ID="txtReportEndDate" runat="server" Text="" Width="200"  class="au-input au-input--full"  />
                <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtReportEndDate"   Format="dd.MM.yyyy" >
                                    </asp:CalendarExtender>
                   <asp:Button ID="btnGo" runat="server" Text="Go" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />  
           
</fieldset>
                <br />
                 <fieldset><legend style="font-size: 16px;  line-height: 1.7; color: #432d2d;"><b>Step 2. Configure Report.</b></legend>
             <%--     <asp:LinkButton ID="LinkButton1" runat="server"> <img src="images/xls.gif" width=16 height=16 border=0 align=left /> Click for Excel</asp:LinkButton>
              --%>    </fieldset>
        </div>
             <div id="divReportMessage" runat="server" />
               <div id="divReportAgency" class="h3" runat="server" />
            <asp:GridView ID="gvReport"  Font-Size="15px" ForeColor="Black"  CellPadding="2" CssClass="table-striped" runat="server" />
          <%--  <div style="overflow-x:auto;width:1200px">
                 <asp:GridView ID="gvReportRaw" Visible="false"  Font-Size="15px" ForeColor="Black"  CellPadding="2" CssClass="table-striped" runat="server" />
           
            </div> --%>
            <asp:LinkButton ID="lbDownloadSummary" Visible="false" runat="server">Download</asp:LinkButton> 
              <asp:GridView ID="gvReportPic" Visible="false" runat="server" HeaderStyle-CssClass="gvHeader"   Caption="View Passes to Approve" CaptionAlign="Left"
  CssClass="gvRow"  AlternatingRowStyle-CssClass="gvAltRow"  AutoGenerateColumns="false">
  <Columns>    <asp:TemplateField>      <HeaderTemplate>      <%--  <th colspan="6">Category</th>--%>
         <tr class="gvHeader">
          <th></th>
                      <th> Pass ID</th>
             <th>Name</th>
             <th>Father</th>
             <th>Gender</th>
             <th>Age</th>
             <th>Address</th>
              <th>Nationality</th>
               <th>NID/Passport</th>
             <th>Desig</th>
              <th>Validity Start</th>
              <th>End</th>
              <th>Status</th>
                 <th>Pic</th>
         
           </tr>
      </HeaderTemplate> 
      <ItemTemplate>
           <td><%# Eval("id")%></td>
          <td><%# Eval("name")%></td>
            <td><%# Eval("father")%></td>
           <td><%# Eval("sex")%></td>
           <td><%# Eval("age")%></td>
           <td><%# Eval("address")%></td>
          <td><%# Eval("nationality")%></td>
           <td><%# Eval("NID/Passport")%></td>
           <td><%# Eval("desig")%></td>
           <td><%# Eval("Validity Start")%></td>
           <td><%# Eval("Validity End")%></td>
           <td><%# Eval("Status")%></td>
             <td><img src='https://www.bifpcl.com/upload/gatepass/<%#  Eval("id") %>.jpg' alt='<%# Eval("id")%>' width="100" height="150" /></td>
        
      </ItemTemplate>    </asp:TemplateField>  </Columns>
       <EmptyDataTemplate><div>No Data Available</div></EmptyDataTemplate>    </asp:GridView> 
         
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
            if ( $.fn.dataTable.isDataTable( '#<%= gvReport.ClientID %>' ) ) {
    table = $('#<%= gvReport.ClientID %>').DataTable();
}
            else {
                var table = $('#<%= gvReport.ClientID %>').DataTable({
                    "scrollX": true,
                    dom: 'Bfrtip',
                    "columnDefs": [    { "targets": [0], "visible": false, "searchable": true }
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
                          title: function () { return 'Bangladesh-India Friendship Power Company(Pvt.) LTD (A JV of  BPDB & NTPC Ltd.)' + '\n' ; },
                        messageTop: agency,
                messageBottom:' Generated from www.bifpcl.com'
                 },
                    {
                        extend: 'pdfHtml5',
                       exportOptions: {
                            columns: ':visible',
                            stripHtml: true
                        },
                        pageSize: 'A2',
                        title: function () { return 'Bangladesh-India Friendship Power Company(Pvt.) LTD (A JV of  BPDB & NTPC Ltd.)' + '\n';  },
                        customize: function (doc, config) {
                             doc.styles.title = {
                                      color: 'blue',   fontSize: '16',background: 'white', alignment: 'center'
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
                      //  image: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEAAAAA8CAMAAADhV0xWAAAABGdBTUEAALGOfPtRkwAAACBjSFJNAAB6JQAAgIMAAPn/AACA6QAAdTAAAOpgAAA6mAAAF2+SX8VGAAADAFBMVEUAAAAECQYFDwkLCwsJFw0VGhcNIRQQKxkWMB4qKio0NTUdSSshUTAofEQzekhERERLS0tFTFJHXU5OVFpUVFRUXldVWFpbW1tIf1hVa1pXe1xjY2NgamNra2tjdmlzc3NzenZ9d3J7e3tYdopefZZlfpMLmTsRnD8PoD8amUMao0YkgkMin0kwmlEipk0qqlM4qFs2sFw9rGA+smJFjVtEm15OjWJVimJYl2xKqGZKtmtSqW9XuHVhjW9kj3Bpmnd3h3t0lXxipnZiuXtewXtiwn1riodngph4hpN5moN6jqVquYB5qIZ4sohprtt5rM13tdtrxoV2xo17y5GEfXiIhXuQh3+Dg4ODhoqCjoaFioqPh4CPioaLi4uJjZCJm46Kk5iQiYSZkY2Tk5OWmZqclpGemJKbm5uKl6OLmKeJmq6Mn7WTnaWSn62Eo4uKqJOEuJKZqJyWtZ2ap6WauKKimpa9lpanoZujo6OhpqqlqauqpaKtqaWsrKygqbSjtqits7KvvbKzraq2sq2zs7OwuLK3uri5tLG9uLS7u7uEpMiMr8WUq8aWtMaVstObttSBvOGaveOgvt60v8uGxpaG0pmP1aGcxaWV1KSow6+rw7Oi3q+n3LO3xLq12Lus4ri0472Tx+mdwOenxtqtwtCqwdm/wsWzy9q5x9i8zNa5zdi80d2jxOigy+asyuuu1Ouyzu220e251ee80+y+3O+12fC/1vC73fK658PCiYnZi4vTlpbUnZ3dmJjOra3Du7jWp6fUs7PWvr7duLjtjIzmlpbwionmoJ/npaTupaXDw8PAxszHyszJxsPMyMXLy8vFzNPAztjKztLJ1crN09PK19/Vy8rT09PW19jV2dbU2NvY09PY2dbb29vC0uTO2OPE2fHJ3fLW3eLZ3eHC68ja4dzD4fPM5PXV5O3f4uTT4/TU6fbY5vXc6/fc7fjgycnj2trg4N7j4+Pn6Ofp4uHo6Obr6+vk6/Li7Pjl8vrq8/r17e3z8/P0+fz+/v4AAABGOYsjAAABAHRSTlP///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////8AU/cHJQAAAAlwSFlzAAALEgAACxIB0t1+/AAAABl0RVh0U29mdHdhcmUAcGFpbnQubmV0IDQuMC4yMfEgaZUAAAidSURBVFhHjZd/dBRXFce3x1YO64+suDpHtuviaFWoEmKgQOS0QqsJNmoBcfDUsSFjMlorTRpWBu0QmjyB5+/q5pAqgfgLpa31B1YRfyAVVB4k75RiHgVfhbaAUkvDDU4tTHa9b2Z2sxuCx/tHMrP77me+7947976NFf6XMUoIY9HNxHYlgEulFFICgAyMutEX421CAKMSuMMsW3ccXdOlbQsuBZ1QygQAIoVwbNPRLC1lmWnNgVTa1FMMBZFoSZldBsB1zLSTmpMyXIcIzhhIApalmSmDCHGZinEAF59iZZKuwXmwf4GmLoDyjJ00NVeIccGoBDBw7VTaMDEGwFyiVMv1X/70nWsZMjhNOq7hQKWIcgARQHSSJihaEAL50P75jYe/e/8X37/ukERmSrNA8mh9YGUAlA9SYwIAEZG3sh/97KePPPLw/V+9kwAIE4wMLw/mGIACmAncIzDiRa6hwVMnT/xyJ1K+9pntiMgwh0oaOZUB8Pk60TkIp9zd3/sYEv7+r7NnT544sXPnD+6SQNy07Y5pKAIQaug6A8Yi19Au/Pqz+Nd75ukX//M8Qk4+tY4B1w2biqKGIkBKWzckUBk6Fu3Cgd+GF1IeRjvy+NlvYojdhM1k5BgBuLA03QUyzj9/4fd7o6vQjl28eJACT1WZMspmCHCBaiYFWh78wEYqJQU3HDdqJdMQVlQAwLohugVUBKvKbaTys6MXR0dH85wDdU0pxgAMP6D4uvnRujGT2Wz5h8eeP/fSSxcvrpdgJFIQZEIBiOR6RoDr+VJWlkB+ePdv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'
                      //      });

                  	//Remove the title created by datatTables
						//doc.content.splice(0,1);
						//Create a date string that we use in the footer. Format is dd-mm-yyyy
						var now = new Date();
						var jsDate = now.getDate()+'-'+(now.getMonth()+1)+'-'+now.getFullYear();
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
						doc.pageMargins = [20,60,20,30];
						// Set the font size fot the entire document
						doc.defaultStyle.fontSize = 12;
						// Set the fontsize for the table header
                            doc.styles.tableHeader.fontSize = 13;
          doc.styles.title.fontSize = 16;
						// Create a header object with 3 columns
						// Left side: Logo
						// Middle: brandname
						// Right side: A document title
                            var vintitle = 'Bangladesh-India Friendship Power Company(Pvt.) LTD (A JV of  BPDB & NTPC Ltd.)' + '\n' ;
                            var leave = document.getElementById("divLeaveType").innerHTML;
                            
						doc['header']=(function() {
							return {
								columns: [
									{
										image: logo,
                                        width: 60,
                                        margin: [10,0,50,10]
									},
									{
										alignment: 'left',
										italics: true,
										text: 'BIFPCL',
										fontSize: 18,
										margin: [10,0]
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
						doc['footer']=(function(page, pages) {
							return {
								columns: [
									{
										alignment: 'left',
                                      //  text: ['Note: System generated report. Created on: ', { text: jsDate.toString() }, { text: '\n \n \n \n Md. Oziur Rahman \n Dy. Manager, HR \n \n \n \n DGM(HR) \n \n \n DPD' }],  //,
                                        text:sign,
                                         fontSize: 14
									},
									{
										alignment: 'center',
										text:leave //['page ', { text: page.toString() },	' of ',	{ text: pages.toString() }]
									}
								],
								margin: [100,-170]  //left , bottom
							}
						});
						// Change dataTable layout (Table styling)
						// To use predefined layouts uncomment the line below and comment the custom lines below
						// doc.content[0].layout = 'lightHorizontalLines'; // noBorders , headerLineOnly
						var objLayout = {};
						objLayout['hLineWidth'] = function(i) { return .5; };
						objLayout['vLineWidth'] = function(i) { return .5; };
						objLayout['hLineColor'] = function(i) { return '#aaa'; };
						objLayout['vLineColor'] = function(i) { return '#aaa'; };
						objLayout['paddingLeft'] = function(i) { return 4; };
						objLayout['paddingRight'] = function(i) { return 4; };
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
        canvas.width =this.width;
        canvas.height =this.height;
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
