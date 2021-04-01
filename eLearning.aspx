<%@ Page Language="VB" AutoEventWireup="false" CodeFile="eLearning.aspx.vb" Inherits="_eLearning" %>
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
                   <button type="button" class="btn btn-info">
                                            <i class="fa fa-lightbulb-o"></i>&nbsp; e-Learning</button>
                         <a href="eLearning.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>&nbsp; Back</button></a>
                  </div>

                  <div class="card-body" >
                  <p class="card-text">Please select the content you would like to read:
                                        </p>
               
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
                             <div class="vue-misc" id="divHome" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-auto" >
                       <div id="div2" runat="server"/>
                              <%--  <asp:Panel ID="pnlHome" runat="server" Visible="false"> --%>
                        <div class="overview-item overview-item--c2">
                                 <a href="eLearning.aspx?ctype=boiler">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-fire"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Boiler</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                    <div class="overview-item overview-item--c1">
                                 <a href="eLearning.aspx?ctype=TG">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-flash"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Turbine</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                             
                              <div class="overview-item overview-item--c3">
                                 <a href="eLearning.aspx?ctype=CHP & AHP">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-landscape"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>CHP & AHP</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                              <div class="overview-item overview-item--c4">
                                 <a href="eLearning.aspx?ctype=Electrical">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-battery-flash"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Electrical</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                 <div class="overview-item overview-item--c1">
                                 <a href="eLearning.aspx?ctype=Civil">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-roller"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Civil</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                 <div class="overview-item overview-item--c2">
                                 <a href="eLearning.aspx?ctype=ESP">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-toys"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>ESP</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                 <div class="overview-item overview-item--c3">
                                 <a href="eLearning.aspx?ctype=Water">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-grain"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Water System</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                 <div class="overview-item overview-item--c4">
                                 <a href="eLearning.aspx?ctype=FGD">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-texture"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>FGD</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                 <div class="overview-item overview-item--c1">
                                 <a href="eLearning.aspx?ctype=Project">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-format-align-right"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Project Schedule</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                               <div class="overview-item overview-item--c3">
                                 <a href="safety.aspx?mode=reports">   <div class="overview__inner">
                                        <div class="overview-box clearfix">
                                            <div class="icon">
                                                <i class="zmdi zmdi-receipt"></i>
                                            </div>
                                            <div class="text">
                                              <%--  <h2>89</h2>--%>
                                                <span>Safety Documents</span>
                                            </div>
                                        </div>
                                       
                                    </div> </a>
                                </div>
                                 <%--   </asp:Panel>--%>
                               </div>
                    </div> </div>
                     <div class="vue-misc" id="divProfile" visible="false" runat="server">
                    
                      <div class="row">
                         <div class=" col-md-auto" >
                              
                       <div id="divHead" runat="server"/>
                           <%--  <div class="form-group">--%>
                             
      <asp:GridView ID="gvDocStore" Font-Size="15px" ForeColor="Black"   CellPadding="2" CssClass="table-responsive table--no-card m-b-40 table table-borderless table-striped table-earning" runat="server" /><%-- table-earning--%>
                          
                          <%-- </div>--%>
                            <br /> <br />
                             <asp:Label ID="lblID" runat="server" Text=""></asp:Label> 
                   
                        </div>
                      </div>
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
     <%--   <script src="vendor/jquery-3.2.1.min.js"></script>--%>
  <%--  for date time sorting--%>
      <script src="js/datatables/moment.min.js"></script>
    <script src="js/datatables/jquery.dataTables.min.js"></script>
    <script src="js/datatables/datetime-moment.js"></script>
  
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
    <script type="text/javascript">

    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_endRequest(function () {
        createDataTable();
    });

    createDataTable();

        function createDataTable() {
          
             $.fn.dataTable.moment('DD.MM.YYYY');
            //$('#<%= gvDocStore.ClientID %>').DataTable();

            var groupColumn = 0;
            if ( $.fn.dataTable.isDataTable( '#<%= gvDocStore.ClientID %>' ) ) {
    table = $('#<%= gvDocStore.ClientID %>').DataTable();
}
            else {
                var table = $('#<%= gvDocStore.ClientID %>').DataTable({
                    "aaSorting": [ [0,'desc'] ],
                         responsive:true,
                    "columnDefs": [     { "width": "5%","targets": 1 },
                                     { "targets": [0,3,4,5,6,9], "visible": false, "searchable": true }
                    ],
                                 dom: 'Bfrtip',
                "displayLength": 50
                //"drawCallback": function (settings) {
                //    var api = this.api();
                //    var rows = api.rows({ page: 'current' }).nodes();
                //    var last = null;

                //    api.column(groupColumn, { page: 'current' }).data().each(function (group, i) {
                //        if (last !== group) {
                //            $(rows).eq(i).before(
                //                '<tr class="group"><td colspan="3">' + group + '</td></tr>'
                //            );

                //            last = group;
                //        }
                //    });
                //}
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
</script>
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
