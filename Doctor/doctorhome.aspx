<%@ Page Title="Doctor Home" Language="C#" MasterPageFile="~/Doctor/DoctorSite1.Master" AutoEventWireup="true" CodeBehind="doctorhome.aspx.cs" Inherits="DoctorAppointmentScheduling.Doctor.doctorhome" %>

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
                    <%--<li>Login Page</li>--%>
                </ol>
            </div>

        </div>
    </section>
    <!-- End Breadcrumbs Section -->
    <div class="container-fluid">
        <div class="header-row" id="header-row" style="padding: 0px; overflow: hidden; height: 300px;">
            <div class="container-fluid" style="padding: 0px;">
                <div class="row">
                    <div class="col-xs-12">
                        <a class="navbar-brand logo" href="doctorhome.aspx">
                            <!-- place your image here -->
                            <img src="../assets/img/apolo.PNG" alt="company logo" style="width: 100%;">
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
