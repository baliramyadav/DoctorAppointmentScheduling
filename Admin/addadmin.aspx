<%@ Page Title="add new admin" Language="C#" MasterPageFile="~/Admin/AdminSite1.Master" AutoEventWireup="true" CodeBehind="addadmin.aspx.cs" Inherits="DoctorAppointmentScheduling.Admin.addadmin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- ======= Breadcrumbs Section ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <div class="d-flex justify-content-between align-items-center">
                <h2></h2>
                <ol>
                    <li><a href="index.html">Admin</a></li>
                    <li>Add New Admin</li>
                </ol>
            </div>

        </div>
    </section>
    <!-- End Breadcrumbs Section -->
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server">
                        <HeaderTemplate>
                            <div style="float: left; font-size: 15px;">
                                <p>Home</p>
                            </div>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <h3 class="alert alert-success">Add New Admin!  </h3>
                            <p></p>
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>Name</label>
                                        <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>Email</label>
                                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>Password</label>
                                        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>


                            </div>
                            
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <p></p>
                                        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" Text="Add Admin" OnClick="btnAdd_Click" />
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnUpdate_Click"  />

                                    </div>
                                </div>
                            </div>
                            <div class="row"><br /><hr /></div>
                            <div class="container">
                                <h3 class="alert alert-primary">  </h3>
                                <div class="row">
                                     <div class="table-responsive">
                                            <h5>All Admin List</h5>
                                            <hr />
                                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                <HeaderTemplate>
                                                    <table class="table table-bordered user-list" style="text-align: center;">
                                                        <thead class=" alert-info">
                                                            <tr>
                                                                <th><span>#</span></th>
                                                                <th><span>Name</span></th>
                                                                <th><span>Email</span></th>
                                                                <th><span>Password</span></th>
                                                                <th><span>Role</span></th>
                                                                <th><span>Lastlogin</span></th>
                                                                <th><span>CreatedDate</span></th>
                                                                
                                                                <th>&nbsp;</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>

                                                    <tr>
                                                        <td><%#Eval("AdminID") %>  </td>
                                                        <td><%#Eval("Name") %> </td>
                                                        <td><%#Eval("Email") %> </td>
                                                        <td><%#Eval("Pass") %> </td>
                                                        <td><%#Eval("RoleName") %> </td>
                                                        <td><%#Eval("LastLogin") %> </td>
                                                        

                                                        <td><%#Eval("CreatedDate") %>  </td>

                                                        <td style="width: 10%;">
                                                            <asp:LinkButton ID="lnkEdit" class="table-link text-primary" runat="server" CommandArgument='<%#Eval("AdminID") %>' CommandName="edit">                                                                            
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"></i>
                                                                                <i class="fa fa-pencil fa-stack-1x fa-inverse"></i>up
                                                                            </span>
                                                            </asp:LinkButton>

                                                            <asp:LinkButton ID="lnkDelete" class="table-link text-danger" CommandArgument='<%#Eval("AdminID") %>' CommandName="delete" Text="delete" ToolTip="Delete" runat="server" OnClientClick="return confirm('Do you want to delete this row?');">                                                                           
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"></i>
                                                                                <i class="fa fa-trash-o fa-stack-1x fa-inverse"></i>
                                                                                
                                                                            </span>                                                                        
                                                            </asp:LinkButton>

                                                        </td>
                                                    </tr>

                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tbody>
                                                        </table>
                                                </FooterTemplate>
                                            </asp:Repeater>

                                        </div>
                                </div>
                                
                            </div>

                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server">
                        <HeaderTemplate>
                            <div style="float: left; font-size: 15px;">
                                <p>View</p>
                            </div>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <h3 class="alert alert-success">View Admin Record!  </h3>
                            <p></p>
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-12">
                                          <div class="table-responsive">
                                        <asp:TextBox ID="txtFilterGrid1Record" CssClass="form-control" runat="server" placeholder="Search...." onkeyup="Search_Gridview(this)"></asp:TextBox>
                                        <hr />
                                        <asp:GridView ID="GridView1" AutoGenerateColumns="false" Caption="Admin List" CaptionAlign="Top" CssClass="table table-hover" runat="server" Font-Size="8pt">
                                            <Columns>
                                                <asp:BoundField HeaderText="#" DataField="AdminID" />
                                                <asp:BoundField HeaderText="Name" DataField="Name" />
                                                <asp:BoundField HeaderText="Email" DataField="Email" />
                                                <asp:BoundField HeaderText="Password" DataField="Pass" />
                                                <asp:BoundField HeaderText="Role" DataField="RoleName" />
                                                <asp:BoundField HeaderText="LastLogin" DataField="LastLogin" />                                                
                                                <asp:BoundField HeaderText="CreatedDate" DataField="CreatedDate" />
                                            </Columns>
                                        </asp:GridView>
                                        <hr />
                                    </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>




                </ajaxToolkit:TabContainer>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=GridView1.ClientID %>");
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }
    </script>
</asp:Content>
