<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Admin/AdminSite1.Master" AutoEventWireup="true" CodeBehind="AdminChangepwd.aspx.cs" Inherits="DoctorAppointmentScheduling.Admin.AdminChangepwd" %>
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
                    <li>Change Password</li>
                </ol>
            </div>

        </div>
    </section>
    <!-- End Breadcrumbs Section -->

    <div class="container-fluid">
        <br />
        <hr />
        <div class="row">
            <div class="col-4">
                <div class="form-group">
                    <label class="alert alert-info">Doctor Passwrod Change</label>
                </div>

                <div class="form-group">
                    <label>Select Doctor</label>
                    <asp:DropDownList ID="ddlDocEmail" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label></label>
                    <asp:TextBox ID="txtDoctorPass" placeholder="Enter New Password" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
                <div class="form-group">
                     <p></p>
                    <asp:Button ID="btnDoctorPass" CssClass="btn btn-success" runat="server" Text="ChangePassword" OnClick="btnDoctorPass_Click" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblDocPass" runat="server" Text=" "></asp:Label>
                </div>

            </div>

            <div class="col-4">
                 <div class="form-group">
                    <label class="alert alert-primary">Patient Passwrod Change</label>
                </div>

                <div class="form-group">
                    <label>Select Patient</label>
                    <asp:DropDownList ID="ddlPatientEmail" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label></label>
                    <asp:TextBox ID="txtPatientPass" placeholder="Enter New Password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                     <p></p>
                    <asp:Button ID="btnPatient" CssClass="btn btn-primary" runat="server" Text="ChangePassword" OnClick="btnPatient_Click" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPatientmsg" runat="server" Text=" "></asp:Label>
                </div>
            </div>

            <div class="col-4">
                 <div class="form-group">
                    <label class="alert alert-warning">Change Your Password</label>
                </div>

                <div class="form-group">
                    <label>Your Email</label>
                    <asp:TextBox ID="txtyourEmail" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label></label>
                    <asp:TextBox ID="txtentermypass" placeholder="Enter New Password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <p></p>
                    <asp:Button ID="btnmypass" CssClass="btn btn-info" runat="server" Text="ChangePassword" OnClick="btnmypass_Click" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblMymsg" runat="server" Text=" "></asp:Label>
                </div>
            </div>

         
        </div>
    </div>
</asp:Content>
