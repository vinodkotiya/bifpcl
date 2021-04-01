<%@ Page Language="VB" AutoEventWireup="false" CodeFile="asset.aspx.vb" Inherits="_asset" %>
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
    <link href='favicon.ico' rel='icon' type='image/x-icon'/>
 
    <!-- Fontfaces CSS-->
    <link href="css/font-face.css" rel="stylesheet" media="all" />
    <link href="vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all" />
    <link href="vendor/font-awesome-5/css/fontawesome-all.min.css" rel="stylesheet" media="all" />
    <link href="vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all" />

    <!-- Bootstrap CSS-->
    <link href="vendor/bootstrap-4.1/bootstrap.min.css" rel="stylesheet" media="all" />

    <!-- Vendor CSS-->
  <%--  <link href="vendor/animsition/animsition.min.css" rel="stylesheet" media="all" />--%>
    <link href="vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet" media="all" />
    <link href="vendor/wow/animate.css" rel="stylesheet" media="all" />
    <link href="vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" media="all" />
    <link href="vendor/slick/slick.css" rel="stylesheet" media="all" />
    <link href="vendor/select2/select2.min.css" rel="stylesheet" media="all" />
    <link href="vendor/perfect-scrollbar/perfect-scrollbar.css" rel="stylesheet" media="all" />

    <!-- Main CSS-->
    <link href="css/theme.css?1" rel="stylesheet" media="all" />

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
           <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
       <div class="page-wrapper">
        <!-- HEADER MOBILE-->
        <header class="header-mobile d-block d-lg-none">
            <div class="header-mobile__bar">
                <div class="container-fluid">
                    <div class="header-mobile-inner">
                        <a class="logo" href="index.html">
                            <img src="images/icon/logo5.png" alt="CoolAdmin" />
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
                    <img src="images/icon/logo5.png" alt="Cool Admin" />
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

   
                <div class="card"  >
                  <div class="card-header">
                    <strong class="card-title">Procurement & Contracts</strong>
                         <a href="asset.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>&nbsp; Back</button></a>
                      <a href="upload/CNM/manual/BIFPCL081018045425.pdf" target="_blank">  <button type="button" class="btn btn-outline-secondary btn-sm">
                                            <i class="fa fa-lightbulb-o"></i>&nbsp; Help Manual</button> </a>
                  </div>

                  <div class="card-body" >
                  
               
                    <div class="vue-misc" id="divLogout" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-auto">
                          <h3 class="mb-3"> </h3>
                          <div class="jumbotron">
                           <div class="col-lg-12">
                            Logout Successfull
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                     <div class="vue-misc" id="divProfile" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-auto" >
                       <div id="divHead" runat="server"/>
                              <%--  <asp:Panel ID="pnlHome" runat="server" Visible="false"> --%>
                        <div class="overview-item overview-item--c2">
                                 <a href="asset.aspx?ctype=po">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-receipt"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Create Work Order</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                    <div class="overview-item overview-item--c1">
                                 <a href="asset.aspx?ctype=entry">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-devices"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Asset Entry</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                             
                              <div class="overview-item overview-item--c3">
                                 <a href="asset.aspx?ctype=assign">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-accounts-add"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Asset Assignment</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                              <div class="overview-item overview-item--c4">
                                 <a href="asset.aspx?ctype=report">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-view-dashboard"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Reports</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                 <%--   </asp:Panel>--%>
                               </div>
                    </div> </div>
                                 <div class="vue-misc" id="divAssetBooking" visible="false" runat="server">
                    
                      <div class="row">
                          <div class="col-md-auto" >


    <label class="myformlabel">Owner (Email)* :</label>    <asp:DropDownList ID="ddlUid" DataTextField="t" DataValueField ="v" runat="server"></asp:DropDownList> 
     <label class="myformlabel">PO* :</label> <asp:DropDownList ID="ddlPO" DataTextField="t" DataValueField ="v" runat="server"></asp:DropDownList>  <%--<asp:TextBox ID="txtPO" runat="server"  class="wrapper-dropdown-5"  />--%><br /><br />
   <label class="myformlabel">Asset Type* :</label>  <asp:DropDownList ID="ddlCtype" runat="server" AutoPostBack="true"  DataValueField="id" DataTextField="type"  class="wrapper-dropdown-5"   EnableViewState="true">
      </asp:DropDownList> 
    <label class="myformlabel">Make* :</label>
    <asp:DropDownList ID="ddlMake" runat="server" AutoPostBack="true"  DataValueField="make" DataTextField="make"  class="wrapper-dropdown-5"   EnableViewState="true">
      </asp:DropDownList>
    &nbsp;<asp:TextBox ID="txtMake" runat="server"    CssClass="au-input "    Text="" Width="100px" /><br /><br />
    <label class="myformlabel">Model :</label>   <asp:TextBox ID="txtModel" runat="server"    CssClass="au-input "    />
     <label class="myformlabel">SN* :</label>   <asp:TextBox ID="txtSN" runat="server"    CssClass="au-input "   /><br /><br />
     <label class="myformlabel">Assign Date* :</label>   <asp:TextBox ID="txtDate" runat="server"    CssClass="au-input "    />
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="txtDate"  Format="yyyy-MM-dd"   BehaviorID="calendar1" >
                    </asp:CalendarExtender><br /><br />
    <label class="myformlabel">Asset Detail (Optional) :</label>
    <asp:TextBox ID="txtDescr" runat="server"    CssClass="au-input "   TextMode="MultiLine" placeholder="write down here additional serial number if required or employee or location  details..." Width="600px" Height="70px" />



    <asp:Button ID="btnSubmit" cssclass="btn btn-primary m-l-10 m-b-10"  runat="server" Text="Submit" class="myforminput" />
    <br />
       <div  id="divMsgComplaint" runat="server"  style="font-family: Arial, Helvetica, sans-serif; font-size: small; font-style: normal; color: #ff0000; word-spacing: normal; text-indent: inherit; text-align: justify;"  />



</div>
           </div></div>
                        
          <div class="vue-misc" id="divStatus" visible="false" runat="server">
                    
                      <div class="row">
                          <div class="col-md-12" >
              <label>Choose Report:</label>
                <asp:RadioButtonList ID="rblReport" runat="server" AutoPostBack="true"  RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem selected="True"  Value="WO">Work Order</asp:ListItem>                  
                                <asp:ListItem Value="ASSET">Asset</asp:ListItem>
                                             </asp:RadioButtonList>
                <asp:GridView ID="gvStatus" runat="server"  CssClass="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning" >
                    <EmptyDataTemplate><div>No Data Available</div></EmptyDataTemplate></asp:GridView>
            
</div>
           </div></div>
      
        <div class="vue-misc" id="divPO" visible="false" runat="server">
                    
                      <div class="row">
                          <div class="col-md-12" >
            
              <label style="font-weight: 600;">Unique ID *:</label>
                    <asp:label ID="txtvUid"  CssClass="au-input "  runat="server"></asp:label> 
              <label style="font-weight: 600;">Work Order/PO/Award No *:</label>
                    <asp:TextBox ID="txtvPO"  CssClass="au-input "  runat="server"></asp:TextBox> 
                <label style="font-weight: 600;">WO/PO/Award Date *:</label>
                    <asp:TextBox CssClass="au-input" ID="txtvPODate" runat="server"></asp:TextBox> <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="txtvPODate"  Format="yyyy-MM-dd"   BehaviorID="calendar1" >
                    </asp:CalendarExtender> <br /><br />
                 <label style="font-weight: 600;">Package/Work/Purchase Name *:</label>
                    <asp:TextBox ID="txtvDescr"  CssClass="au-input" Width="350px"  runat="server"></asp:TextBox>  <br /><br /> 
               <label style="font-weight: 600;">Vendor/Contractor/Supplier Name *:</label> 
                    <asp:TextBox ID="txtvName"  CssClass="au-input"  runat="server"></asp:TextBox> 
               <label style="font-weight: 600;">Contact:</label>
                    <asp:TextBox ID="txtvContact"  CssClass="au-input"  runat="server"></asp:TextBox> <br /><br />
                            
               <label style="font-weight: 600;">Vendor/Contractor/Supplier Address *:</label> 
                    <asp:TextBox ID="txtvAddress"  CssClass="au-input" TextMode="MultiLine" width="400px" Height="100px" runat="server"></asp:TextBox>   <br /><br /> 
                                <label style="font-weight: 600;">Currency:</label> 
                   <asp:RadioButtonList ID="rblCurrency" runat="server" RepeatDirection="Horizontal"  RepeatColumns="10">
                                  <asp:ListItem Selected="True"  Value="BDT">BDT</asp:ListItem>                  
                                <asp:ListItem Value="INR">INR</asp:ListItem>
                                <asp:ListItem  Value="CY">CY</asp:ListItem>
                                <asp:ListItem  Value="JPY">JPY</asp:ListItem>
                         <asp:ListItem Value="USD">USD</asp:ListItem>
                                <asp:ListItem  Value="EURO">EURO</asp:ListItem>
                                <asp:ListItem  Value="POUND">POUND</asp:ListItem>
                                              </asp:RadioButtonList> <br />
                 <label style="font-weight: 600;">Estimated Cost:</label> 
                    <asp:TextBox ID="txtvECost"  CssClass="au-input"  runat="server" TextMode="Number" ></asp:TextBox> 
               <label style="font-weight: 600;">Award Price:</label>
                    <asp:TextBox ID="txtACost"  CssClass="au-input"  runat="server" TextMode="Number"></asp:TextBox> <br /><br />
                 <label style="font-weight: 600;">Type of Contract:</label> 
                   <asp:RadioButtonList ID="rblvType" runat="server" RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem Selected="True"  Value="S">Supply</asp:ListItem>                  
                                <asp:ListItem Value="S+E">Supply + Erection</asp:ListItem>
                                <asp:ListItem  Value="S+E+C">Supply + Erection + Civil</asp:ListItem>
                                <asp:ListItem  Value="E+C">Erection + Civil</asp:ListItem>
                         <asp:ListItem Value="E">Erection</asp:ListItem>
                                <asp:ListItem  Value="C">Civil</asp:ListItem>
                                <asp:ListItem  Value="CO">Consultancy</asp:ListItem>
                                              </asp:RadioButtonList> <br />
                <label style="font-weight: 600;">Tendering Method:</label> 
                   <asp:RadioButtonList ID="rblvTender" runat="server"  RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem  Selected="True" Value="Single">Single</asp:ListItem>                  
                                <asp:ListItem   Value="Limited">Limited</asp:ListItem>
                                <asp:ListItem Value="Open">Open</asp:ListItem>
                                              </asp:RadioButtonList>
                  <label style="font-weight: 600;">No of Bidders:</label>
                    <asp:TextBox ID="txtvBider"  CssClass="au-input" Width="90px" TextMode="Number" Text="1"  runat="server"></asp:TextBox> <br /><br />
               <label style="font-weight: 600;">Approver:</label>
                    <asp:RadioButtonList ID="rblvApprover" runat="server"  RepeatDirection="Horizontal"  RepeatColumns="4">
                                  <asp:ListItem   Value="PD">PD</asp:ListItem>                  
                                <asp:ListItem Selected="True" Value="MD">MD</asp:ListItem>
                           <asp:ListItem  Value="SC">Sub Committee</asp:ListItem>
                                <asp:ListItem  Value="Board">Board</asp:ListItem>
                                              </asp:RadioButtonList>
                  <label style="font-weight: 600;">Location:</label> 
                   <asp:RadioButtonList ID="rblvLocation" runat="server"  RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem selected="True"  Value="MSTPP">MSTPP</asp:ListItem>                  
                                <asp:ListItem Value="HQ">HQ</asp:ListItem>
                                             </asp:RadioButtonList>
           
               <label style="font-weight: 600;">Completion Schedule:</label> <asp:TextBox ID="txtvInstallDate"  CssClass="au-input" Width="90px" runat="server"></asp:TextBox> 
                     <asp:RadioButtonList ID="rblvSch" runat="server"  RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem selected="True"  Value="Days">Days</asp:ListItem>                  
                                <asp:ListItem Value="Month">Month</asp:ListItem>
                         <asp:ListItem Value="Years">Years</asp:ListItem>
                                             </asp:RadioButtonList> 
            <%-- <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                        TargetControlID="txtvInstallDate"  Format="yyyy-MM-dd"   BehaviorID="calendar2" >
                    </asp:CalendarExtender>--%>
                   <label style="font-weight: 600;">Validity:</label>
                    <asp:TextBox ID="txtvValidity"  CssClass="au-input" runat="server"></asp:TextBox> <br />
            <asp:Button ID="btnCreatePO" cssclass="btn btn-primary m-l-10 m-b-10" runat="server" Text="Create New WO/PO" />
   

           </div>
           </div> </div>
                        <div class="vue-misc" id="divAssign" visible="false" runat="server">
                    
                      <div class="row">
                          <div class="col-md-12" >
          <asp:Panel ID="pnlAdminEdit" runat="server" Visible="false" BorderColor="#3333CC" BorderStyle="Groove" BorderWidth="2px"> <br />
              <label>Asset Assignment:</label><asp:Label runat="server" id="lblCurrentID"></asp:Label> <br />
           <label>Current Owner:</label> <asp:Label runat="server" id="lblCurrentUser"></asp:Label><br />
           
            <label>New Owner:</label>
   <asp:DropDownList ID="ddlUidNew" DataTextField="t" DataValueField ="v" runat="server"></asp:DropDownList>  <br /><br />
              <label>Issue Date:</label>
            <asp:TextBox ID="txtEditDt"  CssClass="au-input"  runat="server" placeholder="" ></asp:TextBox> <br /><br />
               <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                        TargetControlID="txtEditDt"  Format="yyyy-MM-dd"   BehaviorID="calendar2" />
                <br />
           
            <asp:Button ID="btnChange"  cssclass="btn btn-primary m-l-10 m-b-10" runat="server" Text="Assign" />
              </asp:Panel>
          <asp:Panel ID="pnlAssign" runat="server" Visible="false"> <br />
              <div class="bottom_to_top"><a href="asset.aspx"> <<-Back...</a></div>
              <label>Filter:</label>  <asp:DropDownList ID="ddlAdminFilter" runat="server" AutoPostBack="true"  DataValueField="id" DataTextField="type"  class="wrapper-dropdown-5"   EnableViewState="true">
      </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;
             
               &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox  CssClass="au-input" ID="txtSearchID" runat="server" Width="200px" placeholder ="Search Asset ID, PO, Email"></asp:TextBox>
               &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnRefresh" runat="server" Text="Refresh" />
               
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
          <th>Asset ID</th>
             <th>Type</th>
          <th>Make</th>
            <th>Model </th>
             <th>SN </th>
            <th>Detail </th>
             <th>Owner </th>
          <th>Issue Date</th>
            <th>PO</th>
            <th>Log</th>
                
        </tr>
      </HeaderTemplate> 
      <ItemTemplate>
              <td><asp:Button ID="btnEdit" runat="server" Text="Edit"  CommandArgument='<%# Eval("uid")%>' /></td>
        <td><%# Eval("uid")%></td>
           <td><%# Eval("atype")%></td>
        <td><%# Eval("make")%></td>
         <td><%# Eval("model")%></td>
          <td><%# Eval("sn")%></td>
          <td><%# Eval("detail")%></td>
        <td><%# Eval("owner")%></td>
           <td><%# Eval("st_dt")%></td>
           <td><%# Eval("po")%></td>
           <td><%# Eval("chain")%></td>
        
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>

                          </asp:GridView>
              </asp:Panel>
      
      </div>
           </div> </div>
                        </div>
                    
                      
                   <div id="divMsg" runat="server" />
                  </div>
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
    <%--<script src="vendor/animsition/animsition.min.js"></script>--%>
    <script src="vendor/bootstrap-progressbar/bootstrap-progressbar.min.js">
    </script>
    <script src="vendor/counter-up/jquery.waypoints.min.js"></script>
    <script src="vendor/counter-up/jquery.counterup.min.js">
    </script>
   <%-- <script src="vendor/circle-progress/circle-progress.min.js"></script>--%>
    <script src="vendor/perfect-scrollbar/perfect-scrollbar.js"></script>
    <script src="vendor/chartjs/Chart.bundle.min.js"></script>
    <script src="vendor/select2/select2.min.js">
    </script>
 
    <!-- Main JS  Closed because giving problem on Gridview paging with animsition-->
   <%-- <script src="js/main.js"></script>--%>
    <script src="js/miniMain.js"></script>
      
     <%--datatable--%>
     <link href="css/jquery.dataTables.min.css" rel="stylesheet" />
     <%--   <script src="vendor/jquery-3.2.1.min.js"></script>--%>
    <script src="js/datatables/jquery.dataTables.min.js"></script>
    
   
  
  
</body>
</html>
