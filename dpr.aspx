<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dpr.aspx.vb" Inherits="dpr"  EnableEventValidation="false" %>

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
        body { 
	font-size: 1.05em;
	line-height: 1.25em;
	font-family: Helvetica Neue, Helvetica, Arial;
	background: #f9f9f9;
	color: #555;
}


    </style>
   
    <link href="vendor/bootstrap-4.1/bootstrap.min.css" rel="stylesheet" />
  <%--  <link href="css/dataTables.responsive.css" rel="stylesheet" />
    <link href="css/datatables.min.css" rel="stylesheet" />--%>
    
   
     
   
</head>
<body>
    <form id="form1" runat="server">
   
        <section>
        <asp:HyperLink ID="hl1" runat="server" NavigateUrl="~/dpr.aspx">DPR Entry</asp:HyperLink>
     &nbsp;|&nbsp;  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/dprUpdate.aspx?mode=master">Manage Activity Master</asp:HyperLink>
        &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/dprUpdate.aspx?mode=add">Add New Activity</asp:HyperLink>
        &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/dprUpdate.aspx?mode=plan">Activity Planning</asp:HyperLink>
      &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/dprUpdate.aspx?mode=plan">Activity Reconcile</asp:HyperLink>
       &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/dprUpdate.aspx?mode=report">DPR Reports</asp:HyperLink>
          &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/dprm.aspx">DPR Mobile Report</asp:HyperLink>
           &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
       <asp:panel ID="myPanel" runat="server">
        <h5>Daily Progress Report</h5>
 Choose Date-><asp:DropDownList ID="ddlRepdate" runat="server" AutoPostBack="true"></asp:DropDownList>
     WorkArea-><asp:DropDownList ID="ddlWorkArea" runat="server" AutoPostBack="true"></asp:DropDownList>
      <asp:RadioButtonList ID="rblUnit" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  RepeatColumns="2">
                                  <asp:ListItem  Selected="True"  Value="1">U#1</asp:ListItem>                  
                                <asp:ListItem Value="2">U#2</asp:ListItem>
                                   </asp:RadioButtonList>
        <asp:CheckBox ID="cbPriority"  AutoPostBack="true" runat="server" Checked="true" Text="Show Work in Progress" />
       
   </asp:panel><br />
    <div class="container">
       
        <div class="row">

            <asp:GridView ID="gvDPRDetail" Width="100%" CssClass="table-striped" runat="server" AutoGenerateColumns="false" DataSourceID="SqlDataSource1"
                DataKeyNames="Actcode" OnRowDataBound="OnRowDataBound" EmptyDataText="No records has been added.">
                <Columns>

                    <asp:BoundField DataField="Activity" HeaderText="Activity" ReadOnly="true" />
                   <%--  <asp:BoundField DataField="progdate" HeaderText="Rep Date" ReadOnly="true" />--%>
                    <asp:BoundField DataField="Scope" HeaderText="Scope" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Day Progress" ItemStyle-Width="100">

                        <ItemTemplate>
                            <asp:Label ID="lblCummulative" Width="50" runat="server" Text='<%# Eval("Cummulative")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbCummulative" Width="50"  runat="server" Text='<%# Bind("Cummulative")%>' type="number" BackColor="YellowGreen" Font-Bold="true"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remark" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblRemark" Width="200" runat="server" Text='<%# Eval("remark")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRemark" Width="200"   runat="server"  Text='<%# Bind("remark")%>'  TextMode="MultiLine"  BackColor="LightBlue"  Font-Bold="false"></asp:TextBox>
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
                SelectCommand="SELECT strftime('%d.%m.%Y', pd.progdate) as progdate,pm.actcode, 'Maitree #' || pm.unit as project, pm.activity || ' - ' || descr || ' (' || pm.um || ') ' || agency as activity,pm.um,pd.progdate,pd.act as Cummulative, pd.remark,pm.scope as scope from ProgressMaster pm left join ProgressDetails pd on pm.actcode=pd.actcode   and pd.progdate=@progdate  where unit=@unit and priority=@priority and workarea=@workarea and  (closed is null or not closed = 1) and (del =0 or del ='' or del is null)"
                UpdateCommand="REPLACE INTO  ProgressDetails(actcode,progdate,act,remark) VALUES (@actcode,@updateprogdate,@Cummulative,@remark)">

                <UpdateParameters>
                    <asp:Parameter Name="actcode" Type="Int32" />
                    <asp:Parameter Name="Cummulative" Type="Double" />
                      <asp:Parameter Name="updateprogdate" Type="string" />
                      <asp:Parameter Name="remark" Type="string" />
                </UpdateParameters>
          
                <SelectParameters>
                    <asp:Parameter Name="progdate" Type="string" />
                     <asp:Parameter Name="workarea" Type="string" />
                     <asp:Parameter Name="unit" Type="Int32" />
                     <asp:Parameter Name="priority" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <div id="divMsg" runat="server" />
        </div>
       
    </div>
            </section>

    </form>
   <script src="vendor/jquery-3.2.1.min.js"></script>
    <%--<script src="js/datatables.min.js"></script>
     <script src="js/dataTables.responsive.js"></script>
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
</body>

</html>
