<%@ Page Language="VB" AutoEventWireup="false" CodeFile="downloadReg.aspx.vb" Inherits="_downloadReg" %>
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


         
                    <div class="vue-misc"  id="divRegistration" visible="false" runat="server">
                     <div class="card" >
                  <div class="card-header">
                    <strong class="card-title">BIFPCL Download Registration</strong>
                       
                  </div>

                  <div class="card-body" >
                     <div class="vue-misc" >
                    
                      <div class="row">
                         <div class=" col-md-auto">
                               <div class="form-group">
                               <div class="card-header" id="divFile" runat="server">   </div>
                      
                          <label><b>Company Name</b></label><br />
                                 <asp:TextBox ID="txtAgency" runat="server" MaxLength="30" class="au-input au-input--full" ></asp:TextBox> <br />
                                   <label><b>Address</b></label><br />
                                 <asp:TextBox ID="txtAddress" runat="server" MaxLength="150" class="au-input au-input--full"  TextMode="MultiLine" Width="500px" Height="100px"></asp:TextBox> <br />
                                
                                  <label><b>Contact Person</b></label><br />
                                 <asp:TextBox ID="txtPerson" runat="server" MaxLength="30" class="au-input au-input--full" ></asp:TextBox> <br />
                                 
                                  <label><b>Email Address</b></label><br />
                                 <asp:TextBox ID="txtEmail" runat="server" MaxLength="40" class="au-input au-input--full" ></asp:TextBox> <br />
                                  <label><b>Mobile Number</b></label><br />
                                 <asp:TextBox ID="txtCell" placeholder="+88011111111" MaxLength="15" runat="server" class="au-input au-input--full" ></asp:TextBox> <br />
                                 
                                 <br /> 
                            
     <br />
      <asp:Button ID="btnIncidentSubmit" runat="server" Text="Submit"  class="au-btn au-btn--block au-btn--green m-b-20" />
                                   <br />
                                  
                            </div>
                             <asp:Label ID="lblID" Cssclass="btn btn-primary m-l-10 m-b-10"  runat="server" Text=""></asp:Label> 
                            <br /> <br />
                             For any query contact vinodkotiya@bifpcl.com
                   
                        </div>
                      </div>
                    </div>
                       </div> </div>
                </div>
                    
                   <div id="divMsg" runat="server" />
               
                    <div class="vue-misc" id="divReport" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-12" >
                               <div class="card" >
                              <div class="card-header">
                    <strong class="card-title">Download Stats</strong>
                         <a href="docStore.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>&nbsp; Back</button></a>
                  </div>
                           <%-- <button type="button" class="btn btn-outline-primary">
                                            <i class="fa fa-star"></i>&nbsp; Safety Documents</button>  --%>
                       <div id="divHead" runat="server"/>
                           <%--  <div class="form-group">--%>
                             
      <asp:GridView ID="gvDocStore" Font-Size="15px" ForeColor="Black"   CellPadding="2" class="table-responsive table-striped" runat="server" /><%-- table-earning--%>
                          
                          <%-- </div>--%>
                            <br /> <br />
                             <asp:Label ID="Label1" runat="server" Text=""></asp:Label> 
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
  
    --%>
    <%--datatable--%>
   <%--  <link href="css/jquery.dataTables.min.css" rel="stylesheet" />--%>
     <%--   <script src="vendor/jquery-3.2.1.min.js"></script>--%>
  <%--  for date time sorting--%>
     <%-- <script src="js/datatables/moment.min.js"></script>
    <script src="js/datatables/jquery.dataTables.min.js"></script>
    <script src="js/datatables/datetime-moment.js"></script>--%>
  
    <%-- show hide columns 
    <script src="js/datatables/dataTables.buttons.min.js"></script>
    <script src="js/datatables/buttons.colVis.min.js"></script>
    <link href="js/datatables/buttons.dataTables.min.css" rel="stylesheet" />
  --Export button
    <script src="js/datatables/buttons.flash.min.js"></script>
    <script src="js/datatables/buttons.html5.min.js"></script>
    <script src="js/datatables/buttons.print.min.js"></script>
    <script src="js/datatables/jszip.min.js"></script>
    <script src="js/datatables/pdfmake.min.js"></script>
    <script src="js/datatables/vfs_fonts.js"></script>--%>
    <%--<script>
        $(document).ready(function () {
             $("#gvReport").prepend( $("<thead></thead>").append( $(this).find("tr:first") ) ).dataTable();
   $('#gvReport').DataTable();
} );
    </script>--%>
   
     <!-- File download counter ajax call --> 
   <script  type="text/javascript">
       function fileCount(name) {
         //  alert('');
            $.ajax({
                type: "POST",
                url: "vinservice.asmx/updatefileCount",
                data: "{filename:'" + name + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                error: OnError
            });
       }
       function OnSuccess(data, status) {
        // alert(data.d);  //no need to display on success
           //  $x("#testcontainer").html(data.d);
         //  $("#divNotify").html('success ' + data.d);
       }
       function OnError(request, status, error) {
          // alert('error ' + request.statusText);
             $("#divMsg").html('error ' + request.statusText);
         }
        </script>
</body>
</html>
