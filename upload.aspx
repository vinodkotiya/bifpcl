<%@ Page Language="VB" AutoEventWireup="false" CodeFile="upload.aspx.vb" Inherits="_upload" %>
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
                    <strong class="card-title">Enter Details...</strong>
                  </div>

                  <div class="card-body" >
                  
               
                   
                     <div class="vue-misc" id="divProfile" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-auto">
                          <h3 class="mb-3"> Upload </h3> 
                                <a href="docStore.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>&nbsp; Back</button></a>
                             <div class="form-group">
                                    <label><b>Section/Dept</b></label>
                              <br />
                             <asp:DropDownList ID="ddlSection" runat="server"  Visible="true"></asp:DropDownList>
                              <br /> 
                         <label><b>Document Type</b></label>
                                  <br />
                             <asp:DropDownList ID="ddlDocType" runat="server" AutoPostBack="true"   Visible="true"></asp:DropDownList> <br />
                                  <label>How Document will be accessed by Users?</label>
                                 <abbr title="Open document will be accessed directly. Access with authentication needs login detail before download. Access with registration needs form to be filled up and email link will be sent to download."><u>Meaning..</u></abbr>
                                 <br />
                                 <asp:RadioButtonList ID="rblSecret" runat="server"  RepeatDirection="Horizontal"  RepeatColumns="3">
                                      <asp:ListItem  Selected="True"  Value="0">Open Access</asp:ListItem>      
                                  <asp:ListItem  Value="1">Access to this document need Authentication</asp:ListItem>                  
                                <asp:ListItem Value="2">Access to this document need registration details</asp:ListItem>
                                   </asp:RadioButtonList>
                                <%-- <asp:CheckBox ID="cbSecret" runat="server" Text="Access to this document need Authentication" />--%> <br />
                                   <label><b>Subject/Description</b></label><br />
                                 <asp:TextBox ID="txtSubject" runat="server" class="au-input au-input--full" ></asp:TextBox> <br /><br /> 
                                    <label><b>Doc Date/Month</b></label><br />
                               <asp:TextBox ID="txtDate" runat="server" class="au-input au-input--full"  Width="100px"></asp:TextBox> 
                               <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd.MM.yyyy" TargetControlID="txtDate"  /> <br />

      <div id="divAttachments" runat="server" /> 
                   
                   <div id="fileatt" runat="server"  >
            <input type="file" name="attachment" runat="server" id="attachment" onchange="document.getElementById('moreUploadsLink').style.display = 'none';"  />
            </div>
      <input type="hidden" value="0" id="fileCount" />
      <div id="fileDiv">
      </div>
      <div id="moreUploadsLink" style="display: none">
            <a href="javascript:addFile();"></a>
      </div> <br />
      <asp:Button ID="btnSubmit" runat="server" Text="Upload" OnClick="btnUpload_Click" class="au-btn au-btn--block au-btn--green m-b-20" /> 
                            </div>
                            <br /> <br />
                             <asp:Label ID="lblID" runat="server" Text=""></asp:Label> 
                   
                        </div>
                      </div>
                    </div>
                      
                   <div id="divMsg" runat="server" />
                       <div class="vue-misc" id="divUpdate" visible="True" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-auto">
                          <h3 class="mb-3"> Correction in your uploads </h3>
                         
                           <div class="col-lg-12">
                          <asp:GridView ID="gvDPRDetail" Width="100%" CssClass="table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
                DataKeyNames="fileid" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added.">
                <Columns>

                     <asp:BoundField DataField="type" HeaderText="Type" ReadOnly="true" />
                      <asp:BoundField DataField="section" HeaderText="Section" ReadOnly="true" />
                      <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="true" />
                   <asp:TemplateField HeaderText="Subject" ItemStyle-Width="170">
                        <ItemTemplate>
                            <asp:Label ID="lblRemark" Width="200" runat="server" Text='<%# Eval("subject")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRemark" Width="200"   runat="server"  Text='<%# Bind("subject")%>'  TextMode="MultiLine"  BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="50">

                        <ItemTemplate>
                            <asp:Label ID="lblDelete" Width="50" runat="server" Text='<%#IIf(Eval("exist") = "1", "No", "Yes")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlDelete" runat="server"  selectedvalue='<%# Bind("exist")%>'  >
                                       <asp:ListItem Value="0">Yes</asp:ListItem>
                                      <asp:ListItem Value="1">No</asp:ListItem>
                                           </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Secure" ItemStyle-Width="50">

                        <ItemTemplate>
                            <asp:Label ID="lblSecure" Width="50" runat="server" Text='<%#IIf(Eval("secure") = "1", "Login", IIf(Eval("secure") = "2", "Registration", "Open"))%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                                  <asp:DropDownList ID="ddlSecure" runat="server"  selectedvalue='<%# Bind("secure")%>'  >
                                        <asp:ListItem Value="0">Open</asp:ListItem>
                                      <asp:ListItem Value="1">Login</asp:ListItem>
                                        <asp:ListItem Value="2">Registration</asp:ListItem>
                                           </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="Progress" HeaderText="Compln" ReadOnly="true" />--%>
                    <%-- <asp:BoundField DataField="Progdate" HeaderText="Progdate" ReadOnly="true" />--%>
                    <%--  <asp:BoundField  DataField="Cummulative" HeaderText="Cumm" ControlStyle-Font-Bold="true" ControlStyle-BackColor="YellowGreen" ControlStyle-Width="80%"   ApplyFormatInEditMode="true"/>--%>

                    <asp:CommandField ButtonType="Link" ShowEditButton="true" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:vindb  %>"
                ProviderName="System.Data.SQLite"
                SelectCommand="select fileid, type, docdt, strftime('%d.%m.%Y', docdt) as 'Date', subject, secure, section, exist from upload where lastupdateby like @lastupdateby order by docdt desc"
                UpdateCommand="update  upload set subject=@subject, exist=@exist, secure=@secure where fileid=@fileid  ">

                <UpdateParameters>
                    <asp:Parameter Name="fileid" Type="Int32" />
                      <asp:Parameter Name="docdt" Type="string" />
                      <asp:Parameter Name="subject" Type="string" />
                </UpdateParameters>
          
                <SelectParameters>
                    <asp:Parameter Name="lastupdateby" Type="string" />
                   
                </SelectParameters>
            </asp:SqlDataSource>
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
    
    
</body>
</html>
