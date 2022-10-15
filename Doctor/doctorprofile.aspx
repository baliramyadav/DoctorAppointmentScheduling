<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Doctor/DoctorSite1.Master" AutoEventWireup="true" CodeBehind="doctorprofile.aspx.cs" Inherits="DoctorAppointmentScheduling.Doctor.doctorprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- ======= Breadcrumbs Section ======= -->
    <section class="breadcrumbs">
        <div class="container">

            <div class="d-flex justify-content-between align-items-center">
                <h2></h2>
                <ol>
                    <li><a href="doctorhome.aspx">Home</a></li>
                    <li>Doctor Profile</li>
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
                            <h3 class="alert alert-success">Welcome! Doctor </h3>
                            
                            <div class="container-fluid" id="divupdateForm" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>Doctor Name</label>
                                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" MaxLength="45"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>Qualification</label>
                                            <asp:TextBox ID="txtDegree" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>Doctor Specialist</label>
                                            <asp:DropDownList ID="ddlspecialist" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <label>Available Days</label>

                                            <asp:TextBox ID="txtchkAvailableDays" CssClass="form-control" runat="server"></asp:TextBox>
                                           
                                            <asp:Label ID="lblDays" runat="server" Text="" Font-Bold="true" ForeColor="Blue"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>Available Time Start</label>
                                            <asp:TextBox ID="txtAvaTimeStart" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>Available Time End</label>
                                            <asp:TextBox ID="txtAvaTimeEnd" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>Email</label>
                                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-4">
                                        <div class="form-group">
                                            <label>Password</label>
                                            <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>Confirm Password</label>
                                            <asp:TextBox ID="txtConfirmPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="* Password not match" ControlToCompare="txtPass" ControlToValidate="txtConfirmPass" ForeColor="Red"></asp:CompareValidator>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>Mobile</label>
                                            <asp:TextBox ID="txtMobile" CssClass="form-control" runat="server" TextMode="Number" MaxLength="10"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>City</label>
                                            <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <label>Country</label>
                                            <asp:TextBox ID="txtCountry" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-4" runat="server" id="statusDiv">
                                        <div class="form-group">
                                            <label>Status</label>
                                            <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server">
                                                <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                                <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-8">
                                        <div class="form-group">
                                            <%--<asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" Text="ADD" OnClick="btnAdd_Click" OnClientClick="return Validate()" />--%>
                                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="UPDATE" OnClick="btnUpdate_Click" />
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="CANCEL" OnClick="btnCancel_Click" />
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <br />
                                    </div>
                                </div>
                                
                            </div>
                            <div class="container">
                                    <h3 class="alert alert-primary"></h3>
                                    <div class="row">
                                        <div class="table-responsive">
                                            <h5>All Doctors List</h5>
                                            <hr />
                                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                <HeaderTemplate>
                                                    <table class="table table-bordered user-list" style="text-align: center; font-size: smaller">
                                                        <thead class=" alert-info">
                                                            <tr>
                                                                <th><span>#</span></th>
                                                                <th><span>Name</span></th>
                                                                <th><span>Degree</span></th>
                                                                <th><span>Specialist</span></th>
                                                                <th><span>Days</span></th>
                                                                <th><span>TimeStart</span></th>
                                                                <th><span>TimeEnd</span></th>

                                                                <th><span>Email</span></th>
                                                                <th><span>Password</span></th>
                                                                <th><span>Role</span></th>
                                                                <th><span>Mobile</span></th>
                                                                <th><span>City</span></th>
                                                                <th><span>Country</span></th>


                                                                <th>&nbsp;</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>

                                                    <tr>
                                                        <td><%#Eval("DocID") %>  </td>
                                                        <td><%#Eval("DocName") %> </td>
                                                        <td><%#Eval("DocDegree") %> </td>
                                                        <td><%#Eval("specialistDesc") %> </td>
                                                        <td><%#Eval("AvailableDays") %> </td>
                                                        <td><%#Eval("AvaiTimeStart") %> </td>


                                                        <td><%#Eval("AvaiTimeEnd") %>  </td>
                                                        <td><%#Eval("EmailID") %>  </td>
                                                        <td><%#Eval("Pass") %>  </td>
                                                        <td><%#Eval("RoleName") %>  </td>
                                                        <td><%#Eval("Mobile") %>  </td>
                                                        <td><%#Eval("City") %>  </td>
                                                        <td><%#Eval("Country") %>  </td>

                                                        <td style="width: 15%;">
                                                            <asp:LinkButton ID="lnkEdit" class="table-link text-primary" runat="server" CommandArgument='<%#Eval("DocID") %>' CommandName="edit" ToolTip="Edit">                                                                            
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"></i>
                                                                                <i class="fa fa-pencil fa-stack-1x fa-inverse"></i>
                                                                            </span>
                                                            </asp:LinkButton>

                                                           <%-- <asp:LinkButton ID="lnkDelete" class="table-link text-danger" CommandArgument='<%#Eval("DocID") %>' CommandName="delete" Text="" ToolTip="Delete" runat="server" OnClientClick="return confirm('Do you want to delete this row?');">                                                                           
                                                                            <span class="fa-stack">Delete
                                                                                <%--<i class="fa fa-square fa-stack-2x"> </i>
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
                                <p>View</p>
                            </div>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <h3 class="alert alert-success">View All Doctors </h3>
                            <p></p>
                             <div class="container">
                                <div class="row">
                                    <div class="col-sm-12">
                                          <div class="table-responsive">
                                        <asp:TextBox ID="txtFilterGrid1Record" CssClass="form-control" runat="server" placeholder="Search...." onkeyup="Search_Gridview(this)"></asp:TextBox>
                                        <hr />
                                        <asp:GridView ID="GridView1" AutoGenerateColumns="false" Caption="Doctors List" CaptionAlign="Top" CssClass="table table-hover" runat="server" Font-Size="8pt">
                                            <Columns>
                                                <asp:BoundField HeaderText="#" DataField="DocID" />
                                                <asp:BoundField HeaderText="Name" DataField="DocName" />
                                                <asp:BoundField HeaderText="Degree" DataField="DocDegree" />
                                                <asp:BoundField HeaderText="Specialist" DataField="specialistDesc" />
                                                <asp:BoundField HeaderText="Day" DataField="AvailableDays" />
                                                <asp:BoundField HeaderText="TimeFrom" DataField="AvaiTimeStart" />                                                
                                                <asp:BoundField HeaderText="TimeTo" DataField="AvaiTimeEnd" />

                                                <asp:BoundField HeaderText="Email" DataField="EmailID" />
                                                <asp:BoundField HeaderText="Password" DataField="Pass" />
                                                <asp:BoundField HeaderText="Role" DataField="RoleName" />
                                                <asp:BoundField HeaderText="Mobile" DataField="Mobile" />
                                                <asp:BoundField HeaderText="City" DataField="City" />
                                                <asp:BoundField HeaderText="Country" DataField="Country" />
                                                <asp:BoundField HeaderText="Status" DataField="DocStatus" />
                                                

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
