<%@ Page Language="VB" AutoEventWireup="false" CodeFile="docStore.aspx.vb" Inherits="_docStore" %>
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
        <header class="header-mobile header-mobile-2 d-block d-lg-none"  style="background:#5d57ea">
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
        <!-- PAGE CONTAINER-->
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
                                        <li class="list-inline-item">DocStore</li>
                                    </ul>
                                </div>
                               <div class="rs-select2--dark rs-select2--sm rs-select2--dark2" style="width:300px;">
                                        <select class="js-select2" name="type">
                                            <option selected="selected">Quick Links</option>
                                            <option value=""><a style="display:block" href="upload.aspx">Upload</a></option>
                                           <a style="display:block" href="downloadReg.aspx?mode=stats"> <option value="">Statistics</option></a>
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
                            <h1 class="title-4">DocStore
                                <span>App</span>
                            </h1>
                            <hr class="line-seprate">
                        </div>
                    </div>
                </div>
            </section>
            <!-- END WELCOME-->
          
            <!-- MAIN CONTENT-->
        
   <section class="statistic statistic2">
                <div class="container">
                    <div class="row">
              <div class="col-md-12">
<div class="card" runat="server" id="divUpload" visible="false" >
                  <div class="card-header">
                    <strong>DocStore-Internal</strong>
                  </div>
                  <div class="card-body">
                    <p class="text-muted m-b-15">If you want to
                      <code>upload</code> documents then please click here:</p>

                   <a href="upload.aspx">  <button type="button" class="btn btn-primary m-l-10 m-b-10">Upload Section
                                          </button> </a>
                   
                  </div>
                </div>
   <div class="card" runat="server" id="divThumbs" visible="false">
                  <div class="card-header">
                    <strong>DocStore-View Documents</strong>
                  </div>
                  <div class="card-body">
                    <p class="text-muted m-b-15">You can retrieve the documents Section/Dept-wise or Document type-wise.
                        <br />Choose the
                      <code>Section/ Department</code> :</p>
                       <div  runat="server" id="divSection" />
                   

                     <p class="text-muted m-b-15">  <br />Or Choose the
                      <code>Document type</code> :</p>
                       <div  runat="server" id="divType" />
                  </div>
                </div>
                  <div class="card" runat="server" id="divStats" visible="false" >
                  <div class="card-header">
                    <strong>DocStore-Statistics</strong>
                  </div>
                  <div class="card-body">
                    <p class="text-muted m-b-15">If you want to view download 
                      <code>statics</code> of documents then please click here:</p>

                   <a href="downloadReg.aspx?mode=stats">  <button type="button" class="btn btn-primary m-l-10 m-b-10">Download Statistics
                                          </button> </a>
                   
                  </div>
                </div>
                <div class="card" id="divProfile" visible="false" runat="server" >
                  <div class="card-header">
                    <strong class="card-title">DocStore - Internal</strong>
                      <a href="docStore.aspx"> <button type="button" class="btn btn-link btn-sm">
                                            <i class="fa fa-link"></i>&nbsp; Back</button></a>
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
                     <div class="vue-misc" >
                    
                      <div class="row">
                         <div class=" col-md-auto" >
                              
                       <div id="divHead" runat="server"/>
                           <%--  <div class="form-group">--%>
                              <p class="text-muted m-b-15"> Quick Navigation
                      <code>Optional</code> </p>
                               <label><b>Section/Dept</b></label>
                              <br />
                             <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="true"  Visible="true"></asp:DropDownList>
                              <br /> 
                         <label><b>Document Type</b></label>
                                  <br />
                             <asp:DropDownList ID="ddlDocType" runat="server" AutoPostBack="true"   Visible="true"></asp:DropDownList> <br />
                                 <asp:CheckBox ID="cbSecret" runat="server" AutoPostBack="true" Text="Show locked documents" /> <br />
       
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
       </section>
     
            <!-- END MAIN CONTENT-->
            <!-- END PAGE CONTAINER-->
       
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
                                     { "targets": [0,3,4,5,6], "visible": false, "searchable": true }
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
