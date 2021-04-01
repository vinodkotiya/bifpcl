<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dprUpdate.aspx.vb" Inherits="dprUpdate"  EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BIFPCL Daily Progress Report</title>
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
        <asp:HyperLink ID="hl1" runat="server" NavigateUrl="~/dpr.aspx">DPR Entry</asp:HyperLink>
     &nbsp;|&nbsp;  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/dprUpdate.aspx?mode=master">Manage Activity Master</asp:HyperLink>
        &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/dprUpdate.aspx?mode=add">Add New Activity</asp:HyperLink>
        &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/dprUpdate.aspx?mode=plan">Activity Planning</asp:HyperLink>
      &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/dprUpdate.aspx?mode=plan">Activity Reconcile</asp:HyperLink>
       &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/dprUpdate.aspx?mode=report">DPR Reports</asp:HyperLink>
        &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/dprm.aspx">DPR Mobile Report</asp:HyperLink>
                &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/dprIssues.aspx">Milestone/Issue</asp:HyperLink>
           &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/dashboardTS.aspx">Dashboard TS</asp:HyperLink>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
 <Triggers>
   <asp:PostBackTrigger ControlID="lbDownloadWeekly" />
      <asp:PostBackTrigger ControlID="btnGo" />
      <asp:AsyncPostBackTrigger ControlID="cbMistake" EventName="CheckedChanged" />
    <%--  <asp:PostBackTrigger ControlID="btnSMS" />--%>
    </Triggers>
              <ContentTemplate>
        <asp:Panel ID="pnlUpdate" runat="server">
              <h5>Daily Progress Report Manage Activity</h5>
<%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
     WorkArea-><asp:DropDownList ID="ddlWorkArea" runat="server" AutoPostBack="true"></asp:DropDownList>
      <asp:RadioButtonList ID="rblUnit" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="2">
                                  <asp:ListItem  Selected="True"  Value="1">U#1</asp:ListItem>                  
                                <asp:ListItem Value="2">U#2</asp:ListItem>
                                   </asp:RadioButtonList>
        <asp:CheckBox ID="cbMistake"  AutoPostBack="true" runat="server"  Text="Show Activities which are not tagged I/P or Completed, but Day Progress are being punched. These will come up in Show All Report" /> <br />
           <b>*Note:</b>  "PowerMech", "Power Mech" and "PowerMech " are 3 different agencies. Set 1 for Work In Progress, Set 1 if activity is completed. Set correct Group to get the total. Set 1 for Delete and its progress will not reflect in report.  
            <asp:GridView ID="gvMistake" Visible="true" runat="server"></asp:GridView>
             &nbsp;   &nbsp;   &nbsp;   &nbsp;   &nbsp;  <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" Visible="false"></asp:DropDownList>-
          <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" Visible="false"></asp:DropDownList>
       
   <br />
    <div class="container">
       
        <div class="row">

            <asp:GridView ID="gvDPRDetail" CssClass="table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
                DataKeyNames="Actcode" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added." Caption="Set 1 to enable set 0 to disable" CaptionAlign="Top">
                <Columns>

                   <%-- <asp:BoundField DataField="activity" HeaderText="Activity" ReadOnly="true" />--%>
                   <%--  <asp:BoundField DataField="progdate" HeaderText="Rep Date" ReadOnly="true" />--%>
                    <%--<asp:BoundField DataField="Scope" HeaderText="Scope" ReadOnly="true" />--%>
                    <asp:TemplateField HeaderText="Activity" ItemStyle-Width="100">

                        <ItemTemplate>
                            <asp:Label ID="lblactivity" Width="250" runat="server" Text='<%# Eval("activity")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbactivity" Width="250"  runat="server" Text='<%# Bind("activity")%>'  BackColor="LightBlue" Font-Bold="true"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descr" ItemStyle-Width="100">

                        <ItemTemplate>
                            <asp:Label ID="lblDescr" Width="150" runat="server" Text='<%# Eval("Descr")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbDescr" Width="50"  runat="server" Text='<%# Bind("Descr")%>'  BackColor="LightBlue" Font-Bold="true"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="UM" ItemStyle-Width="100">

                        <ItemTemplate>
                            <asp:Label ID="lblUM" Width="150" runat="server" Text='<%# Eval("um")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbUM" Width="50"  runat="server" Text='<%# Bind("um")%>'  BackColor="LightBlue" Font-Bold="true"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Agency" ItemStyle-Width="100">

                        <ItemTemplate>
                            <asp:Label ID="lblagncy" Width="150" runat="server" Text='<%# Eval("agency")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbagency" Width="100"  runat="server" Text='<%# Bind("agency")%>'  BackColor="LightBlue" Font-Bold="true"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Scope" ItemStyle-Width="100">

                        <ItemTemplate>
                            <asp:Label ID="lblCummulative" Width="100" runat="server" Text='<%# Eval("scope")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbCummulative" Width="100"  runat="server" Text='<%# Bind("scope")%>' type="number" BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Grouping" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblRemark" Width="50" runat="server" Text='<%# Eval("grp")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRemark" Width="50"   runat="server"  Text='<%# Bind("grp")%>'  type="number"   BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Work In Progress" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblPriority" Width="50" runat="server" Text='<%# Eval("priority")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbpriority" Width="50"   runat="server"  Text='<%# Bind("priority")%>'  type="number"   BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Completed" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblclosed" Width="50" runat="server" Text='<%# Eval("closed")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbclosed" Width="50"   runat="server"  Text='<%# Bind("closed")%>'  type="number"   BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lbldel" Width="50" runat="server" Text='<%# Eval("del")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbdel" Width="50"   runat="server"  Text='<%# Bind("del")%>'  type="number"   BackColor="OrangeRed"  Font-Bold="false"></asp:TextBox>
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
                SelectCommand="SELECT actcode, activity  ,descr, um, agency, scope, grp, priority, closed, del from ProgressMaster  where unit=@unit and workarea=@workarea"
                UpdateCommand="update  ProgressMaster set scope=@scope, grp=@grp, priority=@priority, closed=@closed, del = @del, agency = @agency, um = @um, descr = @descr, activity = @activity where actcode=@actcode">

                <UpdateParameters>
                    <asp:Parameter Name="scope" Type="Double" />
                    <asp:Parameter Name="grp" Type="Double" />
                      <asp:Parameter Name="priority" Type="Double" />
                      <asp:Parameter Name="closed" Type="Double" />
                      <asp:Parameter Name="del" Type="Double" />
                     <asp:Parameter Name="agency" Type="String" />
                    <asp:Parameter Name="um" Type="String" />
                     <asp:Parameter Name="descr" Type="String" />
                     <asp:Parameter Name="activity" Type="String" />
               </UpdateParameters>
          
                <SelectParameters>
                     <asp:Parameter Name="workarea" Type="string" />
                     <asp:Parameter Name="unit" Type="Int32" />
                     <%--<asp:Parameter Name="priority" Type="Int32" />--%>
                </SelectParameters>
            </asp:SqlDataSource>

           <%-- plan and Reconcile--%>
               <asp:GridView ID="gvPlan" CssClass="table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource2"
                DataKeyNames="actcode,mon,yr" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added.">
                <Columns>

                    <asp:BoundField DataField="activity" HeaderText="Activity" ReadOnly="true" />
                   <%--  <asp:BoundField DataField="progdate" HeaderText="Rep Date" ReadOnly="true" />--%>
                    <asp:BoundField DataField="mon" HeaderText="Month" ReadOnly="true" />
                    <asp:BoundField DataField="yr" HeaderText="Year" ReadOnly="true" />
                    <asp:BoundField DataField="scope" HeaderText="Scope" ReadOnly="true" />
                     <asp:TemplateField HeaderText="Plan Qty" ItemStyle-Width="100">

                        <ItemTemplate>
                            <asp:Label ID="lblCummulative1" Width="100" runat="server" Text='<%# Eval("plan")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbCummulative1" Width="100"  runat="server" Text='<%# Bind("plan")%>' type="number" BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reconcile Qty" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblRemark1" Width="100" runat="server" Text='<%# Eval("reco")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRemark1" Width="100"   runat="server"  Text='<%# Bind("reco")%>'  type="number"   BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
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
                SelectCommand="SELECT pm.actcode,  pm.activity || ' - ' || descr || ' (' || pm.um || ') ' || agency as activity,pm.um, plan, pd.reco,pm.scope as scope , @mon as mon, @yr as yr from ProgressMaster pm left join ProgressPlan pd on pm.actcode=pd.actcode   and pd.mon=@mon and pd.yr=@yr  where unit=@unit and workarea=@workarea"
                UpdateCommand="replace into  ProgressPlan (plan, reco, actcode,mon,yr) values (@plan, @reco, @actcode, @mon, @yr)">

                <UpdateParameters>
                    <asp:Parameter Name="reco" Type="Double" />
                    <asp:Parameter Name="plan" Type="Double" />
                     <asp:Parameter Name="mon" Type="Int32" />
                     <asp:Parameter Name="yr" Type="Int32" />
               </UpdateParameters>
          
                <SelectParameters>
                     <asp:Parameter Name="workarea" Type="string" />
                     <asp:Parameter Name="unit" Type="Int32" />
                     <asp:Parameter Name="mon" Type="Int32" />
                     <asp:Parameter Name="yr" Type="Int32" />
                     <%--<asp:Parameter Name="priority" Type="Int32" />--%>
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        
    </div>
        </asp:Panel>
     <asp:Panel ID="pnlAdd" Visible="false" runat="server">
              <h5>Daily Progress Report Add Activity</h5>
<%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
    &nbsp;&nbsp;&nbsp;  WorkArea *-><asp:DropDownList ID="ddlAddWork" runat="server" AutoPostBack="true"></asp:DropDownList>
       &nbsp;&nbsp;&nbsp;   <asp:TextBox ID="txtAddWorkArea" runat="server" Visible="false" placeholder="Work Area" Width="200px" /> 
     &nbsp;&nbsp;&nbsp;  <asp:RadioButtonList ID="rblAddUnit" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="2">
                                  <asp:ListItem  Selected="True"  Value="1">U#1</asp:ListItem>                  
                                <asp:ListItem Value="2">U#2</asp:ListItem>
                                   </asp:RadioButtonList>
       &nbsp;&nbsp;&nbsp;   <asp:TextBox ID="txtAddAgency" runat="server" placeholder="Agency Name*" /> <br /><br />
       &nbsp;&nbsp;&nbsp;   <asp:TextBox ID="txtAddActivity" runat="server" placeholder="Activity*" Width="200px" /> <br /><br />
       &nbsp;&nbsp;&nbsp;   <asp:TextBox ID="txtAddDescr" runat="server" placeholder="Description*" /> <br /><br />
       &nbsp;&nbsp;&nbsp;   <asp:TextBox ID="txtAddScope" runat="server" placeholder="Scope*"  TextMode="Number" /> <br /><br />
       &nbsp;&nbsp;&nbsp;    <asp:TextBox ID="txtAddUM" runat="server" placeholder="UM*"   /> <br /><br />
        &nbsp;&nbsp;&nbsp;    <asp:TextBox ID="txtAddGroup" runat="server" placeholder="Group"  TextMode="Number" /> <br /><br />
        &nbsp;&nbsp;&nbsp;    <asp:TextBox ID="txtAddPriority" runat="server" placeholder="Priority"  TextMode="Number" /> <br /><br />
            &nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;<asp:Button ID="btnAddActivity" runat="server" Text="Add Activity" Visible="True" style="background-image: -moz-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);   background-image: -webkit-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);    background-image: -ms-linear-gradient(0deg, #3e69fe 0%, #4cd4e3 100%);" CssClass="primary-btn submit-btn d-inline-flex align-items-center mr-10" />
                         
         </asp:Panel>
        <asp:Panel ID="pnlReport" Visible="false" runat="server">
              <h5>Daily Progress Reports</h5>
<%-- Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>--%>
    <div style="padding-left:20px" >
              <fieldset style="border-style: none dashed dashed dashed; border-width: thin; border-color: #000080; background-color: #FFFFFF; ">
                  <legend  style="font-size: 16px;  line-height: 1.7; color: #432d2d;"><b>Step 1. DPR Filters:</b></legend>
  WorkArea-><asp:DropDownList ID="ddlReportWorkArea" runat="server" AutoPostBack="true"></asp:DropDownList>
                 &nbsp;&nbsp;&nbsp;&nbsp; Agency-><asp:DropDownList ID="ddlReportAgency" runat="server" AutoPostBack="true"></asp:DropDownList>
      &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButtonList ID="rblReportUnit" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem  Value="1">U#1</asp:ListItem>                  
                                <asp:ListItem Value="2">U#2</asp:ListItem>
           <asp:ListItem  Selected="True"  Value="%">Both</asp:ListItem>
                                   </asp:RadioButtonList>
              <asp:RadioButtonList ID="rblFilter" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="4">
                                  <asp:ListItem  Value="1" >Show Work in Progress</asp:ListItem>                  
                                <asp:ListItem Value="2">Show Completed</asp:ListItem>
                  <asp:ListItem Value="3"  Selected="True" >Show I/P & Completed</asp:ListItem>
                    <asp:ListItem Value="4"  >Show All</asp:ListItem>
                               </asp:RadioButtonList>
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
                             <asp:ListItem >Monthly</asp:ListItem>
                             <asp:ListItem>Weekly</asp:ListItem>
                            <%-- <asp:ListItem>Projects</asp:ListItem>
                             <asp:ListItem>Vendors</asp:ListItem>--%>
                             <asp:ListItem Selected="True">Last Progress</asp:ListItem> 
                          <%--    <asp:ListItem>Download</asp:ListItem>
                               <asp:ListItem >Email</asp:ListItem>--%>
                         </asp:RadioButtonList> 
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBoxList ID="cblGroup" runat="server" RepeatDirection="Horizontal"  RepeatColumns="8">
                                  <asp:ListItem  Value="900">900</asp:ListItem>                  
                                  <asp:ListItem  Value="760">760</asp:ListItem>  
                          <asp:ListItem  Value="600">600</asp:ListItem>                  
                          <asp:ListItem  Value="450">450</asp:ListItem>   
                        <asp:ListItem  Value="350">350</asp:ListItem>   
            <asp:ListItem  Selected="True"  Value="%">Show All</asp:ListItem>
                                   </asp:CheckBoxList>
                  <a href="#Areawise">Area-wise Progress</a> |   <a href="#Vendorwise">Agency-wise Progress</a> |   <a href="#Vendorwisegrp">Agency-wise Summary</a> |   <a href="#weekly">Weekly Report</a>
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
            <a name="Areawise">2#Area-wise Progress</a> 
<asp:GridView ID="gvReportSummary"  Font-Size="14px" ForeColor="Black"  CssClass="table-striped" runat="server" />
             <a name="Vendorwise">3#Agency-wise Progress</a> 
<asp:GridView ID="gvReportVendor"  Font-Size="14px" ForeColor="Black"  CssClass="table-striped" runat="server" />
             <a name="Vendorwisegrp">Agency-wise  Precast available  for Driving  {Custom reports onward}</a> 
<asp:GridView ID="gvDriving"  Font-Size="14px" ForeColor="Black"  CssClass="table-striped" runat="server" />
             <a name="Vendorwisegrp">4#Agency-wise Summary</a> 
<asp:GridView ID="gvReportVendorGroup"  Font-Size="14px" ForeColor="Black"  CssClass="table-striped" runat="server" />
             <a name="Vendorwisegrp">5#Total Summary</a> 
<asp:GridView ID="gvReportTotal"  Font-Size="14px" ForeColor="Black"  CssClass="table-striped" runat="server" />

             <a name="weekly">6#Weekly Report</a> <div id="divWeek" runat="server" > Click on Weekly option to Generate </div> | <asp:LinkButton ID="lbDownloadWeekly" runat="server">Download</asp:LinkButton>
<asp:GridView ID="gvWeeklyReport"  Font-Size="14px" ForeColor="Black"  CssClass="table-striped" runat="server" />
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
                "columnDefs": [
                    { "visible": false, "targets": groupColumn },
                    { "targets": [0,2, 8, 9, 10, 12,13,14,15,16,17,18,19,20], "visible": false, "searchable": false }
                ],
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

                    api.column(groupColumn, { page: 'current' }).data().each(function (group, i) {
                        if (last !== group) {
                            $(rows).eq(i).before(
                                '<tr class="group"><td colspan="5">' + group + '</td></tr>'
                            );

                            last = group;
                        }
                    });
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
