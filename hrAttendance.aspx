<%@ Page Language="VB" AutoEventWireup="false" CodeFile="hrAttendance.aspx.vb" Inherits="hrAttendance"  EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BIFPCL HR Reports</title>
     <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="BIFPCL Official Website" />
    <meta name="author" content="Vinod Kotiya" />
    <meta name="keywords" content="Daily Progress Report, NTPC, BIFPCL, Maitree Thermal Power Project, Khulna, Bangladesh India Friendship Power Corporation Limited" />
    <link href='favicon.ico' rel='icon' type='image/x-icon'/>
 
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
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
         <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
      &nbsp;|&nbsp;  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/hrBiometric.aspx?mode=calendar">Holiday Calendar</asp:HyperLink>
        &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/hrBiometric.aspx?mode=attendance">Daily Attendance</asp:HyperLink>
        &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/hrBiometric.aspx?mode=allattendance">HR Leave Report</asp:HyperLink>
      &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/hrBiometric.aspx?mode=manageattendance">HR Manage Leaves</asp:HyperLink>
       &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/hrBiometric.aspx?mode=biometric">Upload Biometric Data</asp:HyperLink>
          &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/hrAttendance.aspx?mode=checkbio">Check Biometric Mapping</asp:HyperLink>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
 <Triggers>
     <asp:PostBackTrigger ControlID="lbDownloadSummary" />
      <asp:PostBackTrigger ControlID="btnGo" />
    <%--  <asp:AsyncPostBackTrigger ControlID="cbMistake" EventName="CheckedChanged" />--%>
    <%--  <asp:PostBackTrigger ControlID="btnSMS" />--%>
    </Triggers>
              <ContentTemplate>
        <asp:Panel ID="pnlUpdate" runat="server">
              <h5>Manage Holiday Calendar</h5>

    <div class="container">
       
    </div>
        </asp:Panel>
   <asp:Panel ID="pnlBio" runat="server">
              <h5>Check Biometric Mapping</h5>

    <div class="container">
          <p>Biometric Mapping Available</p>
         <asp:GridView ID="gvBio"  Font-Size="15px" ForeColor="Black"  CellPadding="2" CssClass="table-striped" runat="server" />
          <p>Biometric regularly uploaded but Mapping missing for</p>
           <asp:GridView ID="gvBioMissing"  Font-Size="15px" ForeColor="Black"  CellPadding="2" CssClass="table-striped" runat="server" />
          
    </div>
        </asp:Panel>
        <asp:Panel ID="pnlReport" Visible="false" runat="server">
              <h5>Attendance Statement Reports</h5>
<%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
    <div style="padding-left:20px" >
              <fieldset style="border-style: none dashed dashed dashed; border-width: thin; border-color: #000080; background-color: #FFFFFF; ">
                  <legend  style="font-size: 16px;  line-height: 1.7; color: #432d2d;"><b>Step 1. Filters:</b></legend>
 <%-- WorkArea-><asp:DropDownList ID="ddlReportWorkArea" runat="server" AutoPostBack="true"></asp:DropDownList>
                 &nbsp;&nbsp;&nbsp;&nbsp; Agency-><asp:DropDownList ID="ddlReportAgency" runat="server" AutoPostBack="true"></asp:DropDownList>
  --%>    &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButtonList ID="rblOrg" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="4">
                                  <asp:ListItem  Value="NTPC" Selected="true">NTPC</asp:ListItem>                  
                                <asp:ListItem Value="BPDB">BPDB</asp:ListItem>
        <asp:ListItem Value="BIFPCL">BIFPCL</asp:ListItem>
       <asp:ListItem Value="both">BPDB & BIFPCL</asp:ListItem>
                                   </asp:RadioButtonList>
                  <asp:RadioButtonList ID="rblWorkArea" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="4">
                                  <asp:ListItem  Value="%" >All</asp:ListItem>                  
                                <asp:ListItem Value="SO" Selected="true">Site Office</asp:ListItem>
        <asp:ListItem Value="HO">Head Office</asp:ListItem>
                                  </asp:RadioButtonList>
           <%--   <asp:RadioButtonList ID="rblFilter" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="4">
                                  <asp:ListItem  Value="1" >Show Work in Progress</asp:ListItem>                  
                                <asp:ListItem Value="2">Show Completed</asp:ListItem>
                  <asp:ListItem Value="3"  Selected="True" >Show I/P & Completed</asp:ListItem>
                    <asp:ListItem Value="4"  >Show All</asp:ListItem>
                               </asp:RadioButtonList>--%>
                  Start Date:
                <asp:TextBox ID="dt_stTextBox" runat="server" Text="" CssClass="txt100" />
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="dt_stTextBox" Format="dd.MM.yyyy">
                                    </asp:CalendarExtender>
                End Date:
                <asp:TextBox ID="dt_endTextBox" runat="server" Text="" CssClass="txt100" />
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dt_endTextBox"   Format="dd.MM.yyyy" >
                                    </asp:CalendarExtender>
                  <asp:Button ID="btnGo" runat="server" Text="Go" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />  
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:RadioButtonList ID="rblReportDuration" runat="server" 
                             RepeatDirection="Horizontal" Width="550px" AutoPostBack="True" RepeatColumns="3">
                             <asp:ListItem>Monthly</asp:ListItem>
                             <asp:ListItem  Selected="True">Weekly</asp:ListItem>
                           </asp:RadioButtonList> 
                  <asp:CheckBox ID="cbShowTime" Text="Show Time" AutoPostBack="true"  runat="server" />
                    <asp:CheckBox ID="cbOnePunch" Text="Show One Punch" AutoPostBack="true"  runat="server" />
                    <asp:CheckBox ID="chkDownload" Text="Download Biometric" AutoPostBack="true"  runat="server" />
        <%--          <a href="#Areawise">Area-wise Progress</a> |   <a href="#Vendorwise">Agency-wise Progress</a> |   <a href="#Vendorwisegrp">Agency-wise Summary</a>--%>
          <%--   <asp:Button ID="btnSMS" runat="server" Text="Generate SMS" Visible="False" />--%>
                    <asp:BarChart ID="BarChart1" runat="server" ChartHeight="300" ChartWidth = "450"
    ChartType="StackedColumn" ChartTitleColor="#0E426C" Visible = "false"
    CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
</asp:BarChart>
</fieldset>
                <br />
                 <fieldset><legend style="font-size: 16px;  line-height: 1.7; color: #432d2d;"><b>Step 2. Configure Report.</b></legend>
             <%--     <asp:LinkButton ID="LinkButton1" runat="server"> <img src="images/xls.gif" width=16 height=16 border=0 align=left /> Click for Excel</asp:LinkButton>
              --%>    </fieldset>
        </div>
            <asp:GridView ID="gvReport"  Font-Size="15px" ForeColor="Black"  CellPadding="2" CssClass="table-striped" runat="server" />
               <div  id="divLeaveType"  runat="server" />
          <label> <b>Notes:</b></label> 
             <asp:GridView ID="gvLog"  Font-Size="15px" ForeColor="Black"  CellPadding="2" CssClass="table-striped" runat="server" >
                 <EmptyDataTemplate>No leave change request found for selected period.</EmptyDataTemplate>
                 </asp:GridView>
             <label> <b>Leave Summary Report:</b></label> <asp:LinkButton ID="lbDownloadSummary" runat="server">Download</asp:LinkButton> 
            <asp:GridView ID="gvSummary"  Font-Size="15px" ForeColor="Black"  CellPadding="2" CssClass="table-striped" runat="server" >
                 <EmptyDataTemplate>No leave change request found for selected period.</EmptyDataTemplate>
                 </asp:GridView>
            <div id="divtitle" runat="server" />
         
         </asp:Panel>
          <div id="divMsg" runat="server" />
                    <div id="diverr" runat="server" />
                   </ContentTemplate>
    </asp:UpdatePanel>
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
                    "columnDefs": [    { "targets": [0,1], "visible": false, "searchable": true }
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
                          title: function () { return 'Bangladesh-India Friendship Power Company(Pvt.) LTD (A JV of  BPDB & NTPC Ltd.)' + '\n' + 'Attendence Statement of Executives for ' + document.getElementById('<%= dt_stTextBox.ClientID %>').value + ' - ' +  document.getElementById('<%= dt_endTextBox.ClientID %>').value; },
                        messageTop: 'BIFPCL Online Absentee Statement',
                messageBottom: 'A - Absent,CL - Casual Leave,CSL - Compensatary Leave,CH - Closed Holiday,CHPL - Commuted Half Pay Leave,EL - Earn Leave,GH - General Holiday,HPL - Half Pay Leave,JL - Joining Leave,OD - On Duty,P - Present,PN - Present on official duty at NTPC,PL - Paternity Leave,RH - Resticted Holiday,SL - Sick Leave,SAL - Special Additional Leave,TI - Tour in India,TD - Tour Domestic,OP - Optional Leave,WO - Weekly Off,LL - Lieu Leave,CLH - Casual Leave Half Day,PNR - Punch not recorded,TF - Training Foreign,TB - Training Bangladesh'
                 },
                    {
                        extend: 'pdfHtml5',
                       exportOptions: {
                            columns: ':visible',
                            stripHtml: true
                        },
                        pageSize: 'A2',
                         title: function () { return 'Bangladesh-India Friendship Power Company(Pvt.) LTD (A JV of  BPDB & NTPC Ltd.)' + '\n' + 'Attendence Statement of Executives for ' + document.getElementById('<%= dt_stTextBox.ClientID %>').value + ' - ' +  document.getElementById('<%= dt_endTextBox.ClientID %>').value; },
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
                            var vintitle = 'Bangladesh-India Friendship Power Company(Pvt.) LTD (A JV of  BPDB & NTPC Ltd.)' + '\n' + 'Attendence Statement of Executives ' + now.getMonth + ' - ' + now.getFullYear;  //document.getElementById('<%= dt_stTextBox.ClientID %>').value + ' - ' + document.getElementById('<%= dt_endTextBox.ClientID %>').value ;
                            var leave = document.getElementById("divLeaveType").innerHTML;
                            var workarea = jQuery('#<%= rblWorkArea.ClientID %> input:checked').val();
                            console.log(workarea);
                            var sign = 'Note: System generated report. Created on: ' + jsDate.toString() + '\n \n \n \n Mujtaba Tabrez \n Sr. Manager, HR  \n \n CHRO \n \n  MD ';
                            if (workarea == 'SO') {
                                sign = 'Note: System generated report. Created on: ' + jsDate.toString() + '\n \n \n \n Md. Oziur Rahman \n Dy. Manager, HR \n \n  DGM(HR) \n \n  DPD ';
                            }
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
