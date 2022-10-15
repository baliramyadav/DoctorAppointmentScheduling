<%@ Page Title="Appointment" Language="C#" MasterPageFile="~/Patient/PatientSite1.Master" AutoEventWireup="true" CodeBehind="newappointment.aspx.cs" Inherits="DoctorAppointmentScheduling.Patient.newappointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- ======= Breadcrumbs Section ======= -->
            <section class="breadcrumbs">
                <div class="container">
                    <div class="d-flex justify-content-between align-items-center">
                        <h2></h2>
                        <ol>
                            <li><a href="patienthome.aspx">Home</a></li>
                            <li>Appoinement Page</li>
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
                                <p>New Appointment</p>
                            </div>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <h3 class="alert alert-success">Welcome! </h3>
                            <p>Your Appointment</p>

                            <div class="container-fluid" runat="server" id="divupdate">
                                <div class="row">
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label>Appointment Date</label>
                                            <asp:TextBox ID="txtAppdate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-sm-3">
                                        <div class="form-group">
                                            <label>Appointment Time</label>
                                            <asp:TextBox ID="txtAppTime" CssClass="form-control" runat="server" format="hh:mm tt" TextMode="Time"></asp:TextBox>
                                        </div>
                                    </div>

                                     <div class="col-sm-3">
                                        <div class="form-group">
                                            <label>Select Doctor</label>
                                            <asp:DropDownList ID="ddlDoctor" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="col-sm-3">
                                        <div class="form-group">
                                            <label>Patient</label>
                                            <asp:DropDownList ID="ddlPatient" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                 <div class="row">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label>About Disease</label>
                                            <asp:TextBox ID="txtAboutDisease" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-sm-6" runat="server" id="Divappstatus">
                                        <div class="form-group">
                                            <label>Appointment Status</label>
                                            <asp:DropDownList ID="ddlAppStatus" CssClass="form-control" runat="server">
                                                <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                                <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                                            </asp:DropDownList>
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
                                            <asp:Button ID="btnAdd" CssClass="btn btn-success" runat="server" Text="Create Appoinment" OnClick="btnAdd_Click"  />
                                            <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" Text="UPDATE" OnClick="btnUpdate_Click"  />
                                            <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="CANCEL" OnClick="btnCancel_Click" />
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
                                            <h5>All Patients List</h5>
                                            <hr />
                                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                <HeaderTemplate>
                                                    <table class="table table-bordered user-list" style="text-align: center; font-size: smaller">
                                                        <thead class=" alert-info">
                                                            <tr>
                                                                <th><span>#</span></th>
                                                                <th><span>Date</span></th>
                                                                <th><span>Time</span></th>
                                                                <th><span>Doctor</span></th>
                                                                <th><span>Doctor Email</span></th>
                                                                <th><span>Patient</span></th>

                                                                <th><span>Patient Email</span></th>
                                                                <th><span>Disease Desc</span></th>
                                                                <th><span>Remarks</span></th>
                                                                <th><span>Status</span></th>
                                                                


                                                                <th>&nbsp;Action</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>

                                                    <tr>
                                                        <td><%#Eval("ID") %>  </td>
                                                        <td><%#Eval("AppDate") %> </td>
                                                        <td><%#Eval("AppTime") %> </td>
                                                        <td><%#Eval("DocName") %> </td>
                                                        <td><%#Eval("DocEmail") %>  </td>
                                                        <td><%#Eval("PatName") %>  </td>
                                                        <td><%#Eval("PatEmail") %>  </td>
                                                        <td><%#Eval("AboutDisease") %>  </td>
                                                        <td><%#Eval("DocRemarks") %>  </td>
                                                        <td><%#Eval("AppStatus") %>  </td>
                                                        
                                                        

                                                        <td style="width: 10%;">
                                                            <asp:LinkButton ID="lnkEdit" class="table-link text-primary" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="edit" ToolTip="Edit">                                                                            
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"></i>
                                                                                <i class="fa fa-pencil fa-stack-1x fa-inverse"></i>
                                                                            </span>
                                                            </asp:LinkButton>

                                                            <asp:LinkButton ID="lnkDelete" class="table-link text-danger" CommandArgument='<%#Eval("ID") %>' CommandName="delete" Text="" ToolTip="Delete" runat="server" OnClientClick="return confirm('Do you want to delete this row?');">                                                                           
                                                                            <span class="fa-stack">
                                                                                <i class="fa fa-square fa-stack-2x"> </i>
                                                                                <i class="fa fa-trash fa-stack-1x fa-inverse "></i>
                                                                                
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
                                <p>View Patient</p>
                            </div>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <h3 class="alert alert-success">Patient Details! </h3>
                             <div class="container">
                                <div class="row">
                                    <div class="col-sm-12">
                                          <div class="table-responsive">
                                        
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
</asp:Content>
