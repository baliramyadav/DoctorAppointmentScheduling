<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Patient/PatientSite1.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="DoctorAppointmentScheduling.Patient.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- ======= Breadcrumbs Section ======= -->
            <section class="breadcrumbs">
                <div class="container">

                    <div class="d-flex justify-content-between align-items-center">
                        <h2></h2>
                        <ol>
                            <li><a href="index.html">Home</a></li>
                            <li>Login Page</li>
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
                                <p>Patient</p>
                            </div>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <h3 class="alert alert-success">Welcome! </h3>
                            <p></p>

                            <div class="container-fluid" runat="server" id="divupdate">
                                <div class="row">
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label>Name</label>
                                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-sm-3">
                                        <div class="form-group">
                                            <label>Age</label>
                                            <asp:TextBox ID="txtAge" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>

                                     <div class="col-sm-3">
                                        <div class="form-group">
                                            <label>Address</label>
                                            <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-sm-3">
                                        <div class="form-group">
                                            <label>City</label>
                                            <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                 <div class="row">
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label>Country</label>
                                            <asp:TextBox ID="txtCountry" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-sm-3">
                                        <div class="form-group">
                                            <label>Email</label>
                                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-sm-3">
                                        <div class="form-group">
                                            <label>Password</label>
                                            <asp:TextBox ID="txtPass" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-sm-3">
                                        <div class="form-group">
                                            <label>Mobile</label>
                                            <asp:TextBox ID="txtMobile" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                 <div class="row">
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <br />

                                        </div>
                                    </div>
                                </div>

                                 <div class="row">
                                    <div class="col-sm-8">
                                        <div class="form-group">
                                            
                                            <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" Text="UPDATE" OnClick="btnUpdate_Click" />
                                            <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="CANCEL" OnClick="btnCancel_Click"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-12"><br /></div>
                                </div>
                            </div>

                            <div class="container">
                                    
                                    <div class="row">
                                        <div class="table-responsive">
                                            <h5>Your Profile</h5>
                                            <hr />
                                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                <HeaderTemplate>
                                                    <table class="table table-bordered user-list" style="text-align: center; font-size: smaller">
                                                        <thead class=" alert-info">
                                                            <tr>
                                                                <th><span>#</span></th>
                                                                <th><span>Name</span></th>
                                                                <th><span>Age</span></th>
                                                                <th><span>Address</span></th>
                                                                <th><span>City</span></th>
                                                                <th><span>Country</span></th>

                                                                <th><span>Email</span></th>
                                                                <th><span>Password</span></th>
                                                                <th><span>Role</span></th>
                                                                <th><span>Mobile</span></th>
                                                                


                                                                <th>&nbsp;</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>

                                                    <tr>
                                                        <td><%#Eval("PatID") %>  </td>
                                                        <td><%#Eval("PatName") %> </td>
                                                        <td><%#Eval("Age") %> </td>
                                                        <td><%#Eval("PatAddress") %> </td>
                                                        <td><%#Eval("City") %>  </td>
                                                        <td><%#Eval("Country") %>  </td>
                                                        <td><%#Eval("EmailID") %>  </td>
                                                        <td><%#Eval("Pass") %>  </td>
                                                        <td><%#Eval("RoleName") %>  </td>
                                                        <td><%#Eval("Mobile") %>  </td>
                                                        

                                                        <td style="width: 15%;">
                                                            <asp:LinkButton ID="lnkEdit" class="table-link text-primary" runat="server" CommandArgument='<%#Eval("PatID") %>' CommandName="edit" ToolTip="Edit">                                                                            
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"></i>
                                                                                <i class="fa fa-pencil fa-stack-1x fa-inverse"></i>
                                                                            </span>
                                                            </asp:LinkButton>

                                                            <%--<asp:LinkButton ID="lnkDelete" class="table-link text-danger" CommandArgument='<%#Eval("PatID") %>' CommandName="delete" Text="" ToolTip="Delete" runat="server" OnClientClick="return confirm('Do you want to delete this row?');">                                                                           
                                                                            <span class="fa-stack">Delete
                                                                                <i class="fa fa-square fa-stack-2x"> </i>
                                                                                <i class="fa fa-trash fa-stack-1x fa-inverse "></i>
                                                                                
                                                                            </span>                                                                      
                                                            </asp:LinkButton>--%>

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
                                <p>View Patient</p>
                            </div>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <h3 class="alert alert-success">Patient Details! </h3>
                             <div class="container">
                                <div class="row">
                                    <div class="col-sm-12">
                                          <div class="table-responsive">
                                        <asp:TextBox ID="txtFilterGrid1Record" CssClass="form-control" runat="server" placeholder="Search...." onkeyup="Search_Gridview(this)"></asp:TextBox>
                                        <hr />
                                        <asp:GridView ID="GridView1" AutoGenerateColumns="false" Caption="Patient List" CaptionAlign="Top" CssClass="table table-hover" runat="server" Font-Size="8pt">
                                            <Columns>
                                                <asp:BoundField HeaderText="#" DataField="PatID" />
                                                <asp:BoundField HeaderText="Name" DataField="PatName" />
                                                <asp:BoundField HeaderText="Age" DataField="Age" />
                                                <asp:BoundField HeaderText="Address" DataField="PatAddress" />
                                                <asp:BoundField HeaderText="City" DataField="City" />
                                                <asp:BoundField HeaderText="Country" DataField="Country" />

                                                <asp:BoundField HeaderText="Email" DataField="EmailID" />
                                                <asp:BoundField HeaderText="Password" DataField="Pass" />
                                                <asp:BoundField HeaderText="Role" DataField="RoleName" />
                                                <asp:BoundField HeaderText="Mobile" DataField="Mobile" />

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
