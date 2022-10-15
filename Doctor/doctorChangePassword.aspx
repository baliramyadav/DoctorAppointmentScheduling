<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Doctor/DoctorSite1.Master" AutoEventWireup="true" CodeBehind="doctorChangePassword.aspx.cs" Inherits="DoctorAppointmentScheduling.Doctor.doctorChangePassword" %>
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
                            <li>Login Page</li>
                        </ol>
                    </div>

                </div>
            </section>
            <!-- End Breadcrumbs Section -->

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-3"> </div>
            <div class="col-sm-6">
                <table border="1" class="table table-responsive-sm">
                    <caption></caption>
                    <tr>
                        <td colspan="2">
                            <h4 style="text-align:center">Change Password</h4>
                        </td>
                    </tr>
                    
                    <tr>
                        <td> Old Password</td>
                        <td> <asp:TextBox ID="txtOldPass" CssClass="form-control" runat="server" TextMode="Password" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td> New Password</td>
                        <td> <asp:TextBox ID="txtNewPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td> Confirm Password</td>
                        <td> <asp:TextBox ID="txtConfirmPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="* password not matched" ControlToCompare="txtNewPass" ControlToValidate="txtConfirmPass" ForeColor="Red"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div id="divmsg" runat="server"> 
                                Hi, <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label> ...
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" Text="Change Password" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="CANCEL" OnClick="btnCancel_Click"/>
                        </td>
                    </tr>

                </table>
            </div>
            <div class="col-sm-3"> </div>
        </div>
    </div>
</asp:Content>
