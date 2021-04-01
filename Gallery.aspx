<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Gallery.aspx.vb" Inherits="Gallery" %>

<!DOCTYPE html>  
  
<html>  
<head runat="server">  
    <title>Carousel Slider</title>  
    <meta charset="utf-8">  
    <meta name="viewport" content="width=device-width, initial-scale=1">  
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">  
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>  
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>  
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/dataTables.bootstrap4.min.css" />  
    <script src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>  
    <script src="https://cdn.datatables.net/1.10.16/js/dataTables.bootstrap4.min.js"></script>  
    <script type="text/javascript">  
        $(document).ready(function () {  
            $("#GridView1").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();  
        });  
    </script>  
    <style>  
        .carousel-inner img {  
            width: 100%;  
            height: 350px;  
             max-width: none;
        }  
    </style>  
</head>  
<body>  
    <form id="form1" runat="server">  
        <div class="container">  
            <h4 class="text-capitalize text-center">BIFPCL Picture Slider Upload</h4>  
            <div id="myCarousel" class="carousel slide" data-ride="carousel">  
                <div class="carousel-inner" role="listbox">  
                    <asp:Repeater ID="Repeater1" runat="server">  
                        <ItemTemplate>  
                            <div class="carousel-item <%#GetActiveClass(Container.ItemIndex) %>">  
                                <img alt="<%#Eval("ImageName")%>" src="<%#Eval("ImagePath")%>" />  
                            </div>  
                        </ItemTemplate>  
                    </asp:Repeater>  
                </div>  
                <a class="carousel-control-prev" href="#myCarousel" data-slide="prev" role="button">  
                    <span class="carousel-control-prev-icon"></span>  
                </a>  
                <a class="carousel-control-next" href="#myCarousel" data-slide="next" role="button">  
                    <span class="carousel-control-next-icon"></span>  
                </a>  
            </div>  
        </div>  
        <div class="container">  
            <div class="card" style="margin-bottom: 15px">  
                <div class="card-header bg-primary">  
                    <strong class="card-title text-uppercase text-white">carousel Slider Images Upload Preview</strong>  
                </div>  
                <div class="card-body">  
                  1. Choose Gallery:  <asp:DropDownList ID="ddlGallery" runat="server" AutoPostBack="true" ></asp:DropDownList> <br />
                 2. Add Image to Selected Gallery or Create New Gallery  <button type="button" style="margin-bottom:10px;" class="btn btn-primary rounded-0" data-target="#AddImage" data-toggle="modal">Add Images</button>  

                <br />    * Optional    <asp:Button ID="btnLock" runat="server" Text="Lock selected Album" CssClass="btn btn-primary rounded-0"  /> 
                                                   <asp:Button ID="btnUnlock" runat="server" Text="UnLock selected Album" CssClass="btn btn-primary rounded-0"  /> 
                                      (Locked album needs login to view)     
                    <div class="modal fade" id="AddImage">  
                        <div class="modal-dialog">  
                            <div class="modal-content">  
                                <div class="modal-header">  
                                    <h4 class="modal-title">Upload Picture</h4>  
                                    <button type="button" class="close" data-dismiss="modal">×</button>  
                                </div>  
                                <div class="modal-body">  
                                    <div class="row">  
                                        <div class="col-md-8">  
                                            <div class="form-group">  
                                                         <asp:TextBox ID="txtEvent" runat="server" class="au-input au-input--full"  Width="200px" placeholder="Event Name"></asp:TextBox> <br />   
                                                <asp:TextBox ID="txtDate" runat="server" class="au-input au-input--full"  Width="100px" placeholder="dd.mm.yyyy"></asp:TextBox> 
                                                <br />
                                                Image Quality:<asp:RadioButtonList ID="rblSize" class="au-input au-input--full" runat="server" RepeatDirection="Horizontal"  RepeatColumns="3">
                                  <asp:ListItem  Value="1024" Selected="True" >1024</asp:ListItem>                  
                                <asp:ListItem Value="2048">2048</asp:ListItem>
                  <asp:ListItem Value="4096"   >4096</asp:ListItem>
                               </asp:RadioButtonList>
                                                                                    <br />   <label>Choose Slider Image</label>  

                                                <div class="custom-file">  
                                                    <asp:FileUpload ID="SliderFileUpload" runat="server" CssClass="custom-file-input" />  
                                                    <label class="custom-file-label"></label>  
                                                </div>  
  
                                            </div>  
                                        </div>  
                                    </div>  
                                </div>  
                                <div class="modal-footer">  
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary rounded-0" OnClick="btnUpload_Click" />  
                                    <button type="button" class="btn btn-danger rounded-0" data-dismiss="modal">Cancel</button>  
                                </div>  
                            </div>  
                        </div>  
                    </div>  
                    <asp:GridView ID="GridView1" DataKeyNames="ID" ShowHeaderWhenEmpty="true" HeaderStyle-CssClass="bg-primary text-white" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">  
                        <Columns>  
                            <asp:BoundField DataField="Id" HeaderText="ID" />  
                              <asp:BoundField DataField="ImageEvent" HeaderText="Event Name" />  
                            <asp:BoundField DataField="ImageName" HeaderText="Image Name" />  
                            <asp:ImageField DataImageUrlField="ImagePath" ControlStyle-CssClass="img-thumbnail" ControlStyle-Width="100" ControlStyle-Height="60" HeaderText="Image" />  
                             <asp:CommandField ShowDeleteButton="True" ButtonType="Button"   />
                            <asp:TemplateField>
              <ItemTemplate>
                      <asp:LinkButton ID="btnCover" runat="server" CommandArgument='<%#Eval("ID")%>' OnCommand="btnCover" Text="Make Cover">
                      </asp:LinkButton>
               </ItemTemplate>
        </asp:TemplateField>
                        </Columns>  
                        <EmptyDataTemplate>No Record Available <b>Click Add New Image to add Record</b></EmptyDataTemplate>  
                    </asp:GridView>  
                    <div id="divMsg" runat="server" />
                </div>  
            </div>  
        </div>  
    </form>  
</body>  
</html>    
