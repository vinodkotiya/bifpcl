<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dprIssues.aspx.vb" Inherits="dprIssues"  EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <style>
        tr td {
            padding: 0 !important;
            margin: 0 !important;
        }
    </style>
   <style type="text/css">
      .gvnormal
      {
          background-color:white;
      }
      .gvhighlight
      {
          background-color:#cccccc;
      }
       .EU_TableScroll
        {
            max-height: 800px;
            overflow: auto;
            border:1px solid #ccc;
           
        }
        .EU_DataTable
        {
            border-collapse: collapse;
            width:100%;
        }
            .EU_DataTable tr th
            {
                background-color: #3c454f;
                color: #ffffff;
                padding: 10px 5px 10px 5px;
                border: 1px solid #cccccc;
                font-family: Arial, Helvetica, sans-serif;
                font-size: 12px;
                font-weight: normal;
                text-transform:capitalize;
            }
            .EU_DataTable tr:nth-child(2n+2)
            {
                background-color: #f3f4f5;
            }

            .EU_DataTable tr:nth-child(2n+1) td
            {
               /* background-color: #d6dadf;*/
                color: #454545;
            }
            .EU_DataTable tr td
            {
                padding: 5px 10px 5px 10px;
                color: #454545;
                font-family: Arial, Helvetica, sans-serif;
                font-size: 11px;
                border: 1px solid #cccccc;
                vertical-align: middle;
            }
                .EU_DataTable tr td:first-child
                {
                    text-align: center;
                }
                .group{
                    background-color:darkseagreen;
                }
   </style>
    <link href="vendor/bootstrap-4.1/bootstrap.min.css" rel="stylesheet" />
  <%--  <link href="css/dataTables.responsive.css" rel="stylesheet" />
    <link href="css/datatables.min.css" rel="stylesheet" />--%>
   
 
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
               <%-- <div class="container-fluid">
                    <ul class="navbar-mobile__list list-unstyled">
                        <li class="has-sub">
                            <a class="js-arrow" href="#">
                                <i class="fas fa-tachometer-alt"></i>Dashboard</a>
                            <ul class="navbar-mobile-sub__list list-unstyled js-sub-list">
                                <li>
                                    <a href="index.html">Dashboard 1</a>
                                </li>
                                <li>
                                    <a href="index2.html">Dashboard 2</a>
                                </li>
                                <li>
                                    <a href="index3.html">Dashboard 3</a>
                                </li>
                                <li>
                                    <a href="index4.html">Dashboard 4</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="chart.html">
                                <i class="fas fa-chart-bar"></i>Charts</a>
                        </li>
                        <li>
                            <a href="table.html">
                                <i class="fas fa-table"></i>Tables</a>
                        </li>
                        <li>
                            <a href="form.html">
                                <i class="far fa-check-square"></i>Forms</a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="fas fa-calendar-alt"></i>Calendar</a>
                        </li>
                        <li>
                            <a href="map.html">
                                <i class="fas fa-map-marker-alt"></i>Maps</a>
                        </li>
                        <li class="has-sub">
                            <a class="js-arrow" href="#">
                                <i class="fas fa-copy"></i>Pages</a>
                            <ul class="navbar-mobile-sub__list list-unstyled js-sub-list">
                                <li>
                                    <a href="login.html">Login</a>
                                </li>
                                <li>
                                    <a href="register.html">Register</a>
                                </li>
                                <li>
                                    <a href="forget-pass.html">Forget Password</a>
                                </li>
                            </ul>
                        </li>
                        <li class="has-sub">
                            <a class="js-arrow" href="#">
                                <i class="fas fa-desktop"></i>UI Elements</a>
                            <ul class="navbar-mobile-sub__list list-unstyled js-sub-list">
                                <li>
                                    <a href="button.html">Button</a>
                                </li>
                                <li>
                                    <a href="badge.html">Badges</a>
                                </li>
                                <li>
                                    <a href="tab.html">Tabs</a>
                                </li>
                                <li>
                                    <a href="card.html">Cards</a>
                                </li>
                                <li>
                                    <a href="alert.html">Alerts</a>
                                </li>
                                <li>
                                    <a href="progress-bar.html">Progress Bars</a>
                                </li>
                                <li>
                                    <a href="modal.html">Modals</a>
                                </li>
                                <li>
                                    <a href="switch.html">Switchs</a>
                                </li>
                                <li>
                                    <a href="grid.html">Grids</a>
                                </li>
                                <li>
                                    <a href="fontawesome.html">Fontawesome Icon</a>
                                </li>
                                <li>
                                    <a href="typo.html">Typography</a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>--%>
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
        <asp:HyperLink ID="hl1" runat="server" NavigateUrl="~/dprIssues.aspx?mode=milestone">Milestones Update</asp:HyperLink>
    <div style="background-color:#cbf3d3;display: inline"> &nbsp;|&nbsp;  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/dprIssues.aspx?mode=input_update">Manage Milestone Inputs</asp:HyperLink>
        &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/dprIssues.aspx?mode=input_add">Add New Input</asp:HyperLink>
     </div> <div style="background-color:#ecc4e9;display: inline">    &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="#">Manage Critical Issues</asp:HyperLink>
      &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#">Add Critical Issue</asp:HyperLink>
    </div>   &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/dprIssues.aspx?mode=report">Milestone & Critical Issue Reports</asp:HyperLink>
        &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/dprUpdate.aspx">DPR Section</asp:HyperLink>
           &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/dashboardTS.aspx">Dashboard TS</asp:HyperLink>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
 <Triggers>
  <%-- <asp:PostBackTrigger ControlID="lbDownloadWeekly" />--%>
      <asp:PostBackTrigger ControlID="btnGo" />
   <%--   <asp:AsyncPostBackTrigger ControlID="cbMistake" EventName="CheckedChanged" />--%>
    <%--  <asp:PostBackTrigger ControlID="btnSMS" />--%>
    </Triggers>
              <ContentTemplate>
        <asp:Panel ID="pnlUpdate" Visible="false" runat="server">
              <h5>BIFPCL Milestone Update</h5>

      <asp:RadioButtonList ID="rblUnit" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="2">
                                  <asp:ListItem  Selected="True"  Value="1">U#1</asp:ListItem>                  
                                <asp:ListItem Value="2">U#2</asp:ListItem>
                                   </asp:RadioButtonList>
        
       
   <br />
    <div class="container">
       
        <div class="row">

            <asp:GridView ID="gvDPRDetail" CssClass="table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
                DataKeyNames="milestone,unit" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added." Caption="Set 1 to enable set 0 to disable" CaptionAlign="Top">
                <Columns>

                   <%-- <asp:BoundField DataField="activity" HeaderText="Activity" ReadOnly="true" />--%>
                   <%--  <asp:BoundField DataField="progdate" HeaderText="Rep Date" ReadOnly="true" />--%>
                    <%--<asp:BoundField DataField="Scope" HeaderText="Scope" ReadOnly="true" />--%>
                    <asp:BoundField DataField="milestone" HeaderText="Milestone" ReadOnly="true" />
                     <asp:BoundField DataField="unit" HeaderText="Unit" ReadOnly="true" />
                    <asp:TemplateField HeaderText="L2Date" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lbll2date" Width="200" runat="server" Text='<%# Eval("l2date")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbl2date" Width="200"   runat="server"  Text='<%# Bind("l2date")%>'     BackColor="SkyBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Act/Ant Date" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblact_ant" Width="200" runat="server" Text='<%# Eval("act_ant")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbact_ant" Width="200"   runat="server"  Text='<%# Bind("act_ant")%>'   BackColor="SkyBlue" Font-Bold="false"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="tbact_ant"  /> <br />

                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Achieved" ItemStyle-Width="100">
                      <ItemTemplate>
                            <asp:Label ID="lblDel" Width="50" runat="server" Text='<%# Eval("achieved")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlDel" runat="server"     selectedvalue='<%# Bind("achieved")%>'>
                                     <asp:ListItem  Value="1" >Yes</asp:ListItem>                  
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:DropDownList>
                         
                         <%--   <asp:TextBox ID="tbRegularise" Width="50"  runat="server" Text='<%# Bind("reg")%>'  BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>--%>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="External Date" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblexternal" Width="200" runat="server" Text='<%# Eval("external")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbexternal" Width="200"   runat="server"  Text='<%# Bind("external")%>'   BackColor="YellowGreen"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="Progress" HeaderText="Compln" ReadOnly="true" />--%>
                    <%-- <asp:BoundField DataField="Progdate" HeaderText="Progdate" ReadOnly="true" />--%>
                    <%--  <asp:BoundField  DataField="Cummulative" HeaderText="Cumm" ControlStyle-Font-Bold="true" ControlStyle-BackColor="YellowGreen" ControlStyle-Width="80%"   ApplyFormatInEditMode="true"/>--%>

                    <asp:CommandField ButtonType="Link" ShowEditButton="true" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dprdb  %>"
                ProviderName="System.Data.SQLite"
                SelectCommand="SELECT milestone, unit  ,l2date, act_ant, achieved, external from Milestones  where unit=@unit "
                UpdateCommand="update  Milestones set l2date=@l2date, act_ant=@act_ant, last_updated=@last_updated, lastupdateby = @lastupdateby, external=@external, achieved=@achieved where unit=@unit and milestone=@milestone">

                <UpdateParameters>
                    <asp:Parameter Name="unit" Type="Double" />
                    <asp:Parameter Name="act_ant" Type="String" />
                      <asp:Parameter Name="achieved" Type="String" />
                      <asp:Parameter Name="external" Type="String" />
                     <asp:Parameter Name="last_updated" Type="String" />
                      <asp:Parameter Name="lastupdateby" Type="String" />
                    <asp:Parameter Name="um" Type="String" />
                     <asp:Parameter Name="l2date" Type="String" />
                     <asp:Parameter Name="milestone" Type="String" />
               </UpdateParameters>
          
                <SelectParameters>
                  <%--   <asp:Parameter Name="milestone" Type="string" />--%>
                     <asp:Parameter Name="unit" Type="Int32" />
                     <%--<asp:Parameter Name="priority" Type="Int32" />--%>
                </SelectParameters>
            </asp:SqlDataSource>

          
        </div>
        
    </div>
        </asp:Panel>
                    <asp:Panel ID="PanelUpdateInput" Visible="false" runat="server">
              <h5>Manage Inputs to achieve Milestones</h5>
 <asp:DropDownList ID="ddlMilesInputUpdate" runat="server" AutoPostBack="true"></asp:DropDownList>
      <asp:RadioButtonList ID="rblUnitInputUpdate" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="2">
                                  <asp:ListItem  Selected="True"  Value="1">U#1</asp:ListItem>                  
                                <asp:ListItem Value="2">U#2</asp:ListItem>
                                   </asp:RadioButtonList>
                        <asp:Label ID="lbManageL2Date" runat="server" Text=""></asp:Label>
       
   <br />
    <div class="container">
       
        <div class="row">

            <asp:GridView ID="gvInputUpdate" CssClass="table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource2"
                DataKeyNames="uid" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added. Go to Add New Input." Caption="Update inputs." CaptionAlign="Top">
                <Columns>

                   <%-- <asp:BoundField DataField="activity" HeaderText="Activity" ReadOnly="true" />--%>
                   <%--  <asp:BoundField DataField="progdate" HeaderText="Rep Date" ReadOnly="true" />--%>
                    <%--<asp:BoundField DataField="Scope" HeaderText="Scope" ReadOnly="true" />--%>
                    <asp:BoundField DataField="input" HeaderText="input" ReadOnly="true" />
                    <asp:TemplateField HeaderText="L2Date" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lbll2date" Width="200" runat="server" Text='<%# Eval("l2date")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbl2date" Width="200"   runat="server"  Text='<%# Bind("l2date")%>'     BackColor="SkyBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Act/Ant Date" ItemStyle-Width="200">
                        <ItemTemplate>
                            <asp:Label ID="lblact_ant" Width="200" runat="server" Text='<%# Eval("act_ant")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbact_ant" Width="200"   runat="server"  Text='<%# Bind("act_ant")%>'   BackColor="SkyBlue" Font-Bold="false"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="tbact_ant"  /> <br />

                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Achieved" ItemStyle-Width="100">
                      <ItemTemplate>
                            <asp:Label ID="lblAch" Width="50" runat="server" Text='<%# Eval("achieved")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlAch" runat="server"     selectedvalue='<%# Bind("achieved")%>'>
                                     <asp:ListItem  Value="1" >Yes</asp:ListItem>                  
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:DropDownList>
                         
                         <%--   <asp:TextBox ID="tbRegularise" Width="50"  runat="server" Text='<%# Bind("reg")%>'  BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>--%>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="100">
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
                     <asp:TemplateField HeaderText="Remark" ItemStyle-Width="300">
                        <ItemTemplate>
                            <asp:Label ID="lblRemark" Width="300" runat="server" Text='<%# Eval("remark")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRemark" Width="300" TextMode="MultiLine" height="250"  runat="server"  Text='<%# Bind("remark")%>'     BackColor="SkyBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="Progress" HeaderText="Compln" ReadOnly="true" />--%>
                    <%-- <asp:BoundField DataField="Progdate" HeaderText="Progdate" ReadOnly="true" />--%>
                    <%--  <asp:BoundField  DataField="Cummulative" HeaderText="Cumm" ControlStyle-Font-Bold="true" ControlStyle-BackColor="YellowGreen" ControlStyle-Width="80%"   ApplyFormatInEditMode="true"/>--%>

                    <asp:CommandField ButtonType="Link" ShowEditButton="true" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dprdb  %>"
                ProviderName="System.Data.SQLite"
                SelectCommand="SELECT uid, remark, input, l2date, act_ant, achieved, del from Inputs  where unit=@unit and milestone=@milestone"
                UpdateCommand="update  Inputs set remark = @remark, l2date=@l2date, act_ant=@act_ant, last_updated=@last_updated, lastupdateby = @lastupdateby,  achieved=@achieved, del = @del where uid=@uid">

                <UpdateParameters>
                    <asp:Parameter Name="uid" Type="Double" />
                    <asp:Parameter Name="act_ant" Type="String" />
                      <asp:Parameter Name="achieved" Type="String" />
                      <asp:Parameter Name="last_updated" Type="String" />
                      <asp:Parameter Name="lastupdateby" Type="String" />
                    <asp:Parameter Name="l2date" Type="String" />
                      <asp:Parameter Name="remark" Type="String" />
                    <asp:Parameter Name="del" Type="String" />
               </UpdateParameters>
          
                <SelectParameters>
                     <asp:Parameter Name="milestone" Type="string" />
                     <asp:Parameter Name="unit" Type="Int32" />
                     <%--<asp:Parameter Name="priority" Type="Int32" />--%>
                </SelectParameters>
            </asp:SqlDataSource>

          
        </div>
        
    </div>
        </asp:Panel>
                   <asp:Panel ID="pnlManageIssues" Visible="false" runat="server">
              <h5>Manage Issues for Inputs</h5>
 <asp:DropDownList ID="ddlMilestoneIssueUpdate" runat="server" AutoPostBack="true"></asp:DropDownList> <asp:Label ID="lbManageIssueL2Date" runat="server" Text=""></asp:Label>
      <asp:RadioButtonList ID="rblUnitIssueUpdate" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="2">
                                  <asp:ListItem  Selected="True"  Value="1">U#1</asp:ListItem>                  
                                <asp:ListItem Value="2">U#2</asp:ListItem>
                                   </asp:RadioButtonList>
                      Select Input:  <asp:DropDownList ID="ddlInputUpdate" runat="server" AutoPostBack="true"></asp:DropDownList>
                       
       
   <br />
    <div class="container">
       
        <div class="row">

            <asp:GridView ID="gvIssueUpdate" CssClass="table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource3"
                DataKeyNames="issueid" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added. Go to Add New Issue." Caption="Update issues." CaptionAlign="Top">
                <Columns>

                   <%-- <asp:BoundField DataField="activity" HeaderText="Activity" ReadOnly="true" />--%>
                   <%--  <asp:BoundField DataField="progdate" HeaderText="Rep Date" ReadOnly="true" />--%>
                    <%--<asp:BoundField DataField="Scope" HeaderText="Scope" ReadOnly="true" />--%>
                    <asp:BoundField DataField="issue" HeaderText="issue" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Closing Remark" ItemStyle-Width="300">
                        <ItemTemplate>
                            <asp:Label ID="lblRemark" Width="300" runat="server"  Text='<%# Eval("lastupdateby")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tblRemark" Width="300"   runat="server" TextMode="MultiLine"  Text='<%# Bind("lastupdateby")%>'     BackColor="SkyBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                   
                      <asp:TemplateField HeaderText="Issue Closed" ItemStyle-Width="100">
                      <ItemTemplate>
                            <asp:Label ID="lblAch" Width="50" runat="server" Text='<%# Eval("closed")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlAch" runat="server"     selectedvalue='<%# Bind("closed")%>'>
                                     <asp:ListItem  Value="1" >Yes</asp:ListItem>                  
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:DropDownList>
                         
                         <%--   <asp:TextBox ID="tbRegularise" Width="50"  runat="server" Text='<%# Bind("reg")%>'  BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>--%>
                        </EditItemTemplate>
                    </asp:TemplateField>
                  
                    <%-- <asp:BoundField DataField="Progress" HeaderText="Compln" ReadOnly="true" />--%>
                    <%-- <asp:BoundField DataField="Progdate" HeaderText="Progdate" ReadOnly="true" />--%>
                    <%--  <asp:BoundField  DataField="Cummulative" HeaderText="Cumm" ControlStyle-Font-Bold="true" ControlStyle-BackColor="YellowGreen" ControlStyle-Width="80%"   ApplyFormatInEditMode="true"/>--%>

                    <asp:CommandField ButtonType="Link" ShowEditButton="true" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dprdb  %>"
                ProviderName="System.Data.SQLite"
                SelectCommand="SELECT issueid,  issue, closed, lastupdateby  from Issues  where unit=@unit and milestone=@milestone and input=@input"
                UpdateCommand="update  Issues set  closed = @closed,  last_updated=@last_updated, lastupdateby = @lastupdateby,  closed_dt = current_timestamp where issueid=@issueid">

                <UpdateParameters>
                    <asp:Parameter Name="issueid" Type="Double" />
                    <asp:Parameter Name="issue" Type="String" />
                      <asp:Parameter Name="closed" Type="String" />
                      <asp:Parameter Name="last_updated" Type="String" />
                      <asp:Parameter Name="lastupdateby" Type="String" />
                   </UpdateParameters>
          
                <SelectParameters>
                     <asp:Parameter Name="milestone" Type="string" />
                     <asp:Parameter Name="unit" Type="Int32" />
                     <asp:Parameter Name="input" Type="string" />
                     <%--<asp:Parameter Name="priority" Type="Int32" />--%>
                </SelectParameters>
            </asp:SqlDataSource>

          
        </div>
        
    </div>
        </asp:Panel>
     <asp:Panel ID="pnlAdd" Visible="false" runat="server">
              <h5>Add new Input required to achieve Milestone</h5>
<%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
    &nbsp;&nbsp;&nbsp;  Milestone *-><asp:DropDownList ID="ddlAddInputMilestone" AutoPostBack="true" runat="server" ></asp:DropDownList>
     <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  <asp:RadioButtonList ID="rblAddInputUnit" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="2">
                                  <asp:ListItem  Selected="True"  Value="1">U#1</asp:ListItem>                  
                                <asp:ListItem Value="2">U#2</asp:ListItem>
                                   </asp:RadioButtonList>
       &nbsp;&nbsp;&nbsp; Input Required for Milestone*  <asp:TextBox ID="txtAddInput" runat="server" placeholder="Input" /> <br /><br />
       &nbsp;&nbsp;&nbsp;  L2 Date of Input *<asp:TextBox ID="txtAddInputL2Date" runat="server" placeholder="L2 Date*" Width="200px" />
         <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd.MM.yyyy" TargetControlID="txtAddInputL2Date"  /> <br />
<br /><br />
       &nbsp;&nbsp;&nbsp;   Act / Ant Date of Input *<asp:TextBox ID="txtAddInputAct" runat="server" placeholder="Act/Ant*" />   
         <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd.MM.yyyy" TargetControlID="txtAddInputAct"  /> <br />
<br /><br />
         &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;<asp:Button ID="btnAddInput" runat="server" Text="Add Input" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                         
         </asp:Panel>
                   <asp:Panel ID="pnlAddIssue" Visible="false" runat="server">
              <h5>Add new Critical Issue for Input</h5>
<%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
    &nbsp;&nbsp;&nbsp;  Milestone *-><asp:DropDownList ID="ddlMilestoneIssueAdd" AutoPostBack="true" runat="server" ></asp:DropDownList>
     <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;  <asp:RadioButtonList ID="rblUnitIssueAdd" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="2">
                                  <asp:ListItem  Selected="True"  Value="1">U#1</asp:ListItem>                  
                                <asp:ListItem Value="2">U#2</asp:ListItem>
                                   </asp:RadioButtonList>
             &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;           Select Input:  <asp:DropDownList ID="ddlInputIssueAdd" runat="server" AutoPostBack="true"></asp:DropDownList>
                      <br /> <br/>
       &nbsp;&nbsp;&nbsp; Critical Issue*  <asp:TextBox ID="txtIssue" runat="server" placeholder="issue" Width="300" TextMode="MultiLine" Height="100" /> <br /><br />
        &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;<asp:Button ID="btnAddIssue" runat="server" Text="Add Issue" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                         
         </asp:Panel>
        <asp:Panel ID="pnlReport" Visible="false" runat="server">
              <h5>Milestone, Input and Critical Issue Reports</h5>
<%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
    <div style="padding-left:20px" >
              <fieldset style="border-style: none dashed dashed dashed; border-width: thin; border-color: #000080; background-color: #FFFFFF; ">
                  <legend  style="font-size: 16px;  line-height: 1.7; color: #432d2d;"><b>Step 1. Filters:</b></legend>
  <asp:DropDownList ID="ddlMilestoneReport" runat="server" AutoPostBack="true"></asp:DropDownList> <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
      <asp:RadioButtonList ID="rblUnitReport" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="2">
                                  <asp:ListItem  Selected="True"  Value="1">U#1</asp:ListItem>                  
                                <asp:ListItem Value="2">U#2</asp:ListItem>
                                   </asp:RadioButtonList>
                      Select Input:  <asp:DropDownList ID="ddlInputReport" runat="server" AutoPostBack="true"></asp:DropDownList>
                  
                 
                                  <asp:BarChart ID="BarChart1" runat="server" ChartHeight="300" ChartWidth = "450"
    ChartType="StackedColumn" ChartTitleColor="#0E426C" Visible = "false"
    CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
</asp:BarChart>
</fieldset>
                <br />
                 <fieldset><legend style="font-size: 16px;  line-height: 1.7; color: #432d2d;"><b>Step 2. Configure Report.</b></legend>
             <%--     <asp:LinkButton ID="LinkButton1" runat="server"> <img src="images/xls.gif" width=16 height=16 border=0 align=left /> Click for Excel</asp:LinkButton>
              --%>    </fieldset>
          <asp:RadioButtonList ID="rblFilter" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="4">
                                  <asp:ListItem  Value="1" Selected="true" >Milestone Report</asp:ListItem>                  
                                <asp:ListItem Value="2">Input required for milestone</asp:ListItem>
                <%--  <asp:ListItem Value="3"  >Critical Issues Report</asp:ListItem>--%>
                               </asp:RadioButtonList>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="btnGo" Width="50px" runat="server" Text="Go" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />  

        </div>
            <asp:GridView ID="gvReport"  Font-Size="15px" ForeColor="Black"  CellPadding="2" CssClass="table-striped" runat="server" />
             </asp:Panel>
          <div id="divMsg" runat="server" />
                    <div id="diverr" runat="server" />
                   </ContentTemplate>
    </asp:UpdatePanel>
             </div>
             </div>
    </form>
   <script src="vendor/jquery-3.2.1.min.js"></script>
    <%--<script src="js/datatables.min.js"></script>
     <script src="js/dataTables.responasive.js"></script>
     <script src="js/jquery.dataTables.min.js"></script>
    <script src="js/dataTables.bootstrap.min.js"></script>--%>
    <script>
        $(document).ready(function () {
            
          <%--  $('#<%=gvDPRDetail.ClientID %>').DataTable({
                             responsive: true,
                             bSort: false,
                             "searching": false,
                             "bPaginate": false,
            });--%>
            <%-- $('#<%=lvDPRMaster.ClientID %>').DataTable({
                             responsive: true
            });--%>
         
        });
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

            var groupColumn = 1;
            if ( $.fn.dataTable.isDataTable( '#<%= gvReport.ClientID %>' ) ) {
    table = $('#<%= gvReport.ClientID %>').DataTable();
}
            else {
                var table = $('#<%= gvReport.ClientID %>').DataTable({
                 dom: 'Bfrtip',
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
                        title: function () { return 'Bangladesh-India Friendship Power Company(Pvt.) LTD (A JV of  BPDB & NTPC Ltd.)' + '\n' + ' BIFPCL Online DPR System ';},
                        messageTop: 'DPR Report for selected period',
                messageBottom: 'This is a system generated report. Copyright: www.bifpcl.com'
                 },
                    {
                        extend: 'pdf',
                        exportOptions: {
                            columns: ':visible',
                            stripHtml: true
                        },
                        pageSize: 'A4',
                        customize: function (doc, config) {
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
                        }
                    }, 'colvis'
                ],
                "order": [[groupColumn, 'asc']],
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
    $('#example tbody').on( 'click', 'tr.group', function () {
        var currentOrder = table.order()[0];
        if ( currentOrder[0] === groupColumn && currentOrder[1] === 'asc' ) {
            table.order( [ groupColumn, 'desc' ] ).draw();
        }
        else {
            table.order( [ groupColumn, 'asc' ] ).draw();
        }
    } );



    }
</script>
</body>

</html>
