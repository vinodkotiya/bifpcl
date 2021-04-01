<%@ Page Language="VB" AutoEventWireup="false" CodeFile="vehicle.aspx.vb" Inherits="vehicle" %>
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
    <title>BIFPCL Vehicle Booking</title>

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
                                        <li class="list-inline-item">Vehicle Booking</li>
                                    </ul>
                                </div>
                               <div class="rs-select2--dark rs-select2--sm rs-select2--dark2" style="width:300px;">
                                        <select class="js-select2" name="type">
                                            <option selected="selected">Quick Links</option>
                                            <option value=""><a style="display:block" href="dpr.aspx">New Booking</a></option>
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
                            <h1 class="title-4">Dashboard
                                <span>Vehicle Booking</span> 
                            </h1> <   <a href="vehicle.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>&nbsp; Back</button></a>
                      <a href="upload/HR/manual/BIFPCL190119194930.pdf" target="_blank">  <button type="button" class="btn btn-outline-secondary btn-sm">
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
                    <div class="row">
                       <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="vehicle.aspx?mode=new">
                            <div class="statistic__item statistic__item--green">
                                <h2 class="number">Book a Car</h2>
                                <span class="desc">Provide the details for booking the vehicle.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-car"  style="opacity:.4"></i>
                                </div>
                            </div>
                            </a>
                        </div>
                            
                      
                        <div class="col-md-6 col-lg-3">
                               <a style="display:block" href="vehicle.aspx?mode=mybooking">
                            <div class="statistic__item statistic__item--orange">
                                <h2 class="number">My Bookings</h2>
                                <span class="desc">Request Cancellation or Get booking History.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-ticket-star" style="opacity:.4"></i>
                                </div>
                            </div>
                                    </a>
                        </div>
                            
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="vehicle.aspx?mode=approve">
                            <div class="statistic__item statistic__item--blue">
                                <h2 class="number">Approve Booking</h2>
                                <span class="desc">HR section to approve bookings.</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-check"  style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="vehicle.aspx?mode=approve">
                            <div class="statistic__item statistic__item--red">
                                <h2 class="number">Change Booking</h2>
                                <span class="desc">HR Section to change the vehicle</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-edit" style="opacity:.4"></i>
                                </div>
                            </div>
                                 </a>
                        </div>
                         <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="vehicle.aspx?mode=report">
                            <div class="statistic__item statistic__item--red" style="background:#6f42c1">
                                <h2 class="number">Usage Report</h2>
                                <span class="desc">HR Section to get the reports</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-car-wash" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                        <div class="col-md-6 col-lg-3">
                             <a style="display:block" href="vehicle.aspx?mode=manage">
                            <div class="statistic__item statistic__item--red" style="background:#20c997">
                                <h2 class="number">Manage Vehicle</h2>
                                <span class="desc">HR Section to update vehicle list</span>
                                <div class="icon" style="bottom:0px;right:0px;">
                                    <i class="zmdi zmdi-comment-edit" style="opacity:.4"></i>
                                </div>
                            </div>
                                  </a>
                        </div>
                       
                    </div>
                         </asp:Panel>
                       <asp:Panel ID="pnlUpdateVehicle" Visible="false" runat="server">
              
                  <div class="row">
                      <h5>BIFPCL Vehicle Update</h5><p><br />Please maintain the vehicle record up to date.</p>
            <asp:GridView ID="gvDPRDetail" CssClass="table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
                DataKeyNames="vid"  EmptyDataText="No records has been added." Caption="Set 1 to enable set 0 to disable" CaptionAlign="Top">
                <Columns>
                       <asp:CommandField ButtonType="Link" ShowEditButton="true" />
                   <%-- <asp:BoundField DataField="activity" HeaderText="Activity" ReadOnly="true" />--%>
                   <%--  <asp:BoundField DataField="progdate" HeaderText="Rep Date" ReadOnly="true" />--%>
                    <%--<asp:BoundField DataField="Scope" HeaderText="Scope" ReadOnly="true" />--%>
                    <asp:BoundField DataField="vid" HeaderText="SN" ReadOnly="true" />
                   <asp:TemplateField HeaderText="Vehicle Type/No" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblvehicle" Width="200" runat="server" Text='<%# Eval("vehicle")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbvehicle" Width="200"   runat="server"  Text='<%# Bind("vehicle")%>'   BackColor="YellowGreen"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Driver" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lbldriver" Width="200" runat="server" Text='<%# Eval("driver")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbdriver" Width="200"   runat="server"  Text='<%# Bind("driver")%>'   BackColor="YellowGreen"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Driver Mobile" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lbldrivern" Width="200" runat="server" Text='<%# Eval("driverno")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbdrivern" Width="200"   runat="server"  Text='<%# Bind("driverno")%>'   BackColor="YellowGreen"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Seating" ItemStyle-Width="100">
                      <ItemTemplate>
                            <asp:Label ID="lblSeat" Width="50" runat="server" Text='<%# Eval("seating")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlSeat" runat="server"     selectedvalue='<%# Bind("seating")%>'>
                                     <asp:ListItem  Value="3" >3</asp:ListItem>  
                                       <asp:ListItem  Value="4" >4</asp:ListItem>  
                                <asp:ListItem Value="5">5</asp:ListItem>
                                       <asp:ListItem Value="6">6</asp:ListItem>
                                         <asp:ListItem Value="7">7</asp:ListItem>
                            </asp:DropDownList>
                         
                         <%--   <asp:TextBox ID="tbRegularise" Width="50"  runat="server" Text='<%# Bind("reg")%>'  BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>--%>
                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Remove Vehicle" ItemStyle-Width="100">
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
                    <asp:TemplateField HeaderText="Location" ItemStyle-Width="100">
                      <ItemTemplate>
                            <asp:Label ID="lblloc" Width="50" runat="server" Text='<%# Eval("loc")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlloc" runat="server"     selectedvalue='<%# Bind("loc")%>'>
                                     <asp:ListItem  Value="SO" >Site Office</asp:ListItem>                  
                                <asp:ListItem Value="HO">Head Office</asp:ListItem>
                            </asp:DropDownList>
                         
                         <%--   <asp:TextBox ID="tbRegularise" Width="50"  runat="server" Text='<%# Bind("reg")%>'  BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>--%>
                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="EIC" ItemStyle-Width="100">

                        <ItemTemplate>
                            <asp:Label ID="lblRegularise" Width="50" runat="server" Text='<%# Eval("eic")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlEIC" runat="server"    >
                                     </asp:DropDownList>
                         
                        </EditItemTemplate>
                         
                    </asp:TemplateField>
                 
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:appsdb  %>"
                ProviderName="System.Data.SQLite"
                SelectCommand="SELECT vid,vehicle,driver,driverno,ifnull(seating,3) as seating,del, loc, eic from vehicle "
                UpdateCommand="update  vehicle set vehicle=@vehicle,driver=@driver,driverno=@driverno,seating=@seating,del=@del, loc=@loc, eic = @eic where vid=@vid">

                <UpdateParameters>
                    <asp:Parameter Name="vid" Type="Double" />
                    <asp:Parameter Name="vehicle" Type="String" />
                      <asp:Parameter Name="driver" Type="String" />
                      <asp:Parameter Name="driverno" Type="String" />
                     <asp:Parameter Name="seating" Type="String" />
                      <asp:Parameter Name="del" Type="String" />
                    <asp:Parameter Name="loc" Type="String" />
                     <asp:Parameter Name="eic" Type="String" />
                 </UpdateParameters>
          
                <SelectParameters>
                  <%--   <asp:Parameter Name="milestone" Type="string" />--%>
                   <%--  <asp:Parameter Name="unit" Type="Int32" />--%>
                     <%--<asp:Parameter Name="priority" Type="Int32" />--%>
                </SelectParameters>
            </asp:SqlDataSource>

          
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
                     <asp:Panel ID="pnlCancellation" runat="server" Visible="false" BorderColor="#3333CC" BorderStyle="Groove" BorderWidth="2px"> <br />
              <label>Request ID:</label><asp:Label runat="server" id="lbCancelID"></asp:Label> <br />
           <label>Request:</label> <asp:Label runat="server" id="lbCancelRequest"></asp:Label><br />
           
            <br /> Cancel Remark: <asp:TextBox ID="txtCancelRemark"  class="au-input au-input--full" Width="300" runat="server"></asp:TextBox>
      <br /> <asp:Label ID="lbCancelRemark" runat="server" Text="Confirmation will cancel your booking." ForeColor="red"></asp:Label>
              <br />  
            <asp:Button ID="btnCancel"  cssclass="btn btn-primary m-l-10 m-b-10" runat="server" Text="Confirm Cancel" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:Button ID="btnCancelBack"  cssclass="btn btn-primary m-l-10 m-b-10" runat="server" Text="Back" />
              <br />
              </asp:Panel>

                     <asp:Panel ID="pnlApprove" Visible="false" runat="server">
                           <div class="col-md-12" >
          <asp:Panel ID="pnlAdminEdit" runat="server" Visible="false" BorderColor="#3333CC" BorderStyle="Groove" BorderWidth="2px"> <br />
              <label>Request ID:</label><asp:Label runat="server" id="lblCurrentID"></asp:Label> <br />
           <label>Request:</label> <asp:Label runat="server" id="lblCurrentUser"></asp:Label><br />
           
            <label>Assign Vehicle:</label>
   <asp:DropDownList ID="ddlAssignVehicle" AutoPostBack="true" DataTextField="t" DataValueField ="v" runat="server"></asp:DropDownList>  
              <br /> Remark <asp:TextBox ID="txtAssignRemark"  class="au-input au-input--full" Width="300" runat="server"></asp:TextBox>
      <br /> <asp:Label ID="lbAssign" runat="server" Text="" ForeColor="red"></asp:Label>
              <br />  
            <asp:Button ID="btnAssign"  cssclass="btn btn-primary m-l-10 m-b-10" runat="server" Text="Assign" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:Button ID="btnReject"  cssclass="btn btn-primary m-l-10 m-b-10" runat="server" Text="Reject" />
              <br />
              </asp:Panel>
                               
          <asp:Panel ID="pnlAssign" runat="server" > <%--<br />
              <div class="bottom_to_top"><a href="asset.aspx"> <<-Back...</a></div>
              <label>Filter:</label>  <asp:DropDownList ID="ddlAdminFilter" runat="server" AutoPostBack="true"  DataValueField="id" DataTextField="type"  class="wrapper-dropdown-5"   EnableViewState="true">
      </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nb
             
               &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox  CssClass="au-input" ID="txtSearchID" runat="server" Width="200px" placeholder ="Search Asset ID, PO, Email"></asp:TextBox>
               &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnRefresh" runat="server" Text="Refresh" />--%>
               
               <asp:GridView ID="gvAdminStatus" runat="server" 
  CssClass="table-striped"
  AutoGenerateColumns="false" AllowPaging="False" PageSize="11" AllowCustomPaging="False" >
  <Columns>
    <asp:TemplateField>
      <HeaderTemplate>
      <%--  <th colspan="6">Category</th>--%>
       
        <tr class="gvHeader">
         
            <th></th>
               <th>!</th>
          <th>Reporting Time</th>
             <th>UpTo</th>
              <th>Type</th>
             <th>Request By</th>
          <th>Seats</th>
            <th>Destination </th>
                 <th>Reason </th>
        </tr>
      </HeaderTemplate> 
      <ItemTemplate>
              <td><asp:Button ID="btnEdit" runat="server" Text="Approve"  CommandArgument='<%# Eval("uid")%>' /></td>
        <td><%# Eval("reporting")%></td>
          <td><%# Eval("upto")%></td>
            <td><%# Eval("triptype")%></td>
           <td><%# Eval("eid")%></td>
        <td><%# Eval("seats")%></td>
         <td><%# Eval("destination")%></td>
           <td><%# Eval("remark")%></td>
         
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>

                          </asp:GridView>
               <br /> <asp:Label ID="lbAssignGrid" runat="server" Text="" ForeColor="red"></asp:Label>
               <a name="change"></a>Change or Cancel the Approved Bookings from Here. 
                <asp:GridView ID="gvChangeGrid" runat="server" 
  CssClass="table-striped"
  AutoGenerateColumns="false" AllowPaging="False" PageSize="11" AllowCustomPaging="False" >
  <Columns>
    <asp:TemplateField>
      <HeaderTemplate>
      <%--  <th colspan="6">Category</th>--%>
       
        <tr class="gvHeader">
         
            <th></th>
               <th>!</th>
          <th>Reporting Time</th>
             <th>UpTo</th>
              <th>Type</th>
             <th>Request By</th>
              <th>Assigned Vehicle</th>
          <th>Seats</th>
            <th>Destination </th>
               
        </tr>
      </HeaderTemplate> 
      <ItemTemplate>
              <td><asp:Button ID="btnEdit" runat="server" Text="Change/Cancel"  CommandArgument='<%# Eval("uid")%>' /></td>
        <td><%# Eval("reporting")%></td>
          <td><%# Eval("upto")%></td>
            <td><%# Eval("triptype")%></td>
           <td><%# Eval("eid")%></td>
           <td><%# Eval("vehicle")%></td>
        <td><%# Eval("seats")%></td>
         <td><%# Eval("destination")%></td>
         
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>

                          </asp:GridView>
              </asp:Panel>
      
      </div>
                         </asp:Panel>
                     <asp:Panel ID="pnlReport" Visible="false" runat="server">
                      <div class="row">
                         <div class=" col-md-12">
                          <h3 class="mb-3"> Report for Bookings </h3>
                             <p> Scroll left to right. Touch enabled.</p>
                             <asp:GridView ID="gvAllBookings" class="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning"  runat="server" EmptyDataText="No Records Available"></asp:GridView>
                   
                              <asp:Label ID="lbAllBooking" runat="server" Text="" ForeColor="red"></asp:Label>
                        </div>
                      </div>
                        </asp:Panel>
                      <asp:Panel ID="pnlNewBooking" Visible="false" runat="server" BorderWidth="2px">
              <h5>Enter your booking request</h5>
<%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
 <br />&nbsp;&nbsp;&nbsp;  Reporting Date *<asp:TextBox ID="txtNewReporting" runat="server"  class="au-input au-input--full" placeholder="Date" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd.MM.yyyy" TargetControlID="txtNewReporting"  />
                       Reporting Time:   <asp:DropDownList ID="ddlNewTime" AutoPostBack="true" runat="server" ></asp:DropDownList> Releasing Time:
                           <asp:DropDownList ID="ddlNewTimeUpto" AutoPostBack="true" runat="server" ></asp:DropDownList>

<br /><br />  <asp:radiobuttonlist ID="rblNewTrip"  RepeatDirection="Horizontal"  RepeatColumns="4" runat="server" >
                                     <asp:ListItem Selected="true" >Personal</asp:ListItem>                  
                                <asp:ListItem >Official</asp:ListItem>
                            </asp:radiobuttonlist>
  <br />   &nbsp;&nbsp;&nbsp;  Reason:  <asp:TextBox ID="txtNewReason"  class="au-input au-input--full" runat="server" placeholder=" " TextMode="MultiLine" Height="60px" Width="200px" /> 
  <br />
                       &nbsp;&nbsp;&nbsp;    No of Seats required: <asp:DropDownList ID="ddlNewSeat" AutoPostBack="true" runat="server" >
                               <asp:ListItem Value="1">1</asp:ListItem>
                                       <asp:ListItem Value="2">2</asp:ListItem>
                                     <asp:ListItem  Value="3" >3</asp:ListItem>  
                                       <asp:ListItem  Value="4" >4</asp:ListItem>  
                                     <asp:ListItem Value="5">5</asp:ListItem>
                           </asp:DropDownList>

      &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtNewP1" Width="200px"  class="au-input au-input--full" runat="server" placeholder="Name Passenger1" /> 
                <br />  <br />   &nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNewP2" Visible="false"  Width="200px"  class="au-input au-input--full" runat="server" placeholder="Passenger2" /> 
                          &nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtNewP3" Width="200px"   class="au-input au-input--full" Visible="false" runat="server" placeholder="Passenger3" /> 
                <br />  <br />  &nbsp;&nbsp;&nbsp;   <asp:TextBox ID="txtNewP4" Visible="false" Width="200px"   class="au-input au-input--full" runat="server" placeholder="Passenger4" /> 
                          &nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtNewP5" Width="200px"   class="au-input au-input--full" Visible="false" runat="server" placeholder="Passenger5" /> 
  <br /><br />   &nbsp;&nbsp;&nbsp; Address to Report:  <asp:TextBox ID="txtNewAddress"  class="au-input au-input--full" runat="server" placeholder=" " TextMode="MultiLine" Height="60px" Width="200px" /> 
     <br /><br />   &nbsp;&nbsp;&nbsp;  Destination:  <asp:TextBox ID="txtNewDestination"  class="au-input au-input--full" runat="server" placeholder=" " TextMode="MultiLine" Height="60px" Width="200px" /> 
  
         <br />&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;<asp:Button ID="btnNewBook" runat="server" Text="Book" Visible="True"  class="au-btn au-btn--block au-btn--green m-b-20" />
          <br />  <asp:Label ID="lbBookMessage" runat="server" Text="" ForeColor="red"></asp:Label>
         </asp:Panel>
                     <asp:Panel ID="pnlBookPrint" Visible="false" runat="server" BorderWidth="2px">
                          <h5>Success / Take Print</h5>

                         <asp:Label ID="lbBookMessagePrint" runat="server" Text="" ForeColor="Green"></asp:Label>
                         <br /><br />
                         Note: You can also take print from My Bookings Section & You can see the allotted vehicle by HR from My Bookings.
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
</body>
</html>
