<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="DoctorAppointmentScheduling.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signup</title>
     <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />

    <meta content="" name="description" />
    <meta content="" name="keywords" />

    <!-- Favicons -->
    <link href="assets/img/favicon.png" rel="icon">
    <link href="assets/img/apple-touch-icon.png" rel="apple-touch-icon" />

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Raleway:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">

    <!-- Vendor CSS Files -->
    <link href="assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <link href="assets/vendor/animate.css/animate.min.css" rel="stylesheet" />
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />
    <link href="assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet" />
    <link href="assets/vendor/glightbox/css/glightbox.min.css" rel="stylesheet" />
    <link href="assets/vendor/remixicon/remixicon.css" rel="stylesheet" />
    <link href="assets/vendor/swiper/swiper-bundle.min.css" rel="stylesheet" />

    <!-- Template Main CSS File -->
    <link href="assets/css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- ======= Top Bar ======= -->
        <div id="topbar" class="d-flex align-items-center fixed-top">
            <div class="container d-flex justify-content-between">
                <div class="contact-info d-flex align-items-center">
                    <i class="bi bi-envelope"></i><a href="#">ss1721620@gmail.com / inamdarmubeen77@gmail.com</a>
                    <i class="bi bi-phone"></i>+91 8999097642,  8698887367
                </div>
                <div class="d-none d-lg-flex social-links align-items-center">
                    <a href="#" class="twitter"><i class="bi bi-twitter"></i></a>
                    <a href="#" class="facebook"><i class="bi bi-facebook"></i></a>
                    <a href="#" class="instagram"><i class="bi bi-instagram"></i></a>
                    <a href="#" class="linkedin"><i class="bi bi-linkedin"></i></a>
                </div>
            </div>
        </div>

        <!-- ======= Header ======= -->
        <header id="header" class="fixed-top">
            <div class="container d-flex align-items-center">

                <h1 class="logo me-auto"><a href="index.html">Doctor Appointment System</a></h1>
                <!-- Uncomment below if you prefer to use an image logo -->
                <!-- <a href="index.html" class="logo me-auto"><img src="assets/img/logo.png" alt="" class="img-fluid"></a>-->

                <nav id="navbar" class="navbar order-last order-lg-0">
                    <ul>
                        <li><a class="nav-link scrollto " href="home.aspx">Home</a></li>
                        <%--<li><a class="nav-link scrollto" href="#about">About</a></li>
                        <li><a class="nav-link scrollto" href="#services">Services</a></li>
                        <li><a class="nav-link scrollto" href="#departments">Departments</a></li>
                        <li><a class="nav-link scrollto" href="#doctors">Doctors</a></li>--%>
                        <%--<li class="dropdown"><a href="#"><span>Drop Down</span> <i class="bi bi-chevron-down"></i></a>
                            <ul>
                                <li><a href="#">Drop Down 1</a></li>
                                <li class="dropdown"><a href="#"><span>Deep Drop Down</span> <i class="bi bi-chevron-right"></i></a>
                                    <ul>
                                        <li><a href="#">Deep Drop Down 1</a></li>
                                        <li><a href="#">Deep Drop Down 2</a></li>
                                        <li><a href="#">Deep Drop Down 3</a></li>
                                        <li><a href="#">Deep Drop Down 4</a></li>
                                        <li><a href="#">Deep Drop Down 5</a></li>
                                    </ul>
                                </li>
                                <li><a href="#">Drop Down 2</a></li>
                                <li><a href="#">Drop Down 3</a></li>
                                <li><a href="#">Drop Down 4</a></li>
                            </ul>
                        </li>--%>
                        <%--<li><a class="nav-link scrollto" href="#contact">Contact</a></li>--%>
                    </ul>
                    <i class="bi bi-list mobile-nav-toggle"></i>
                </nav>
                <!-- .navbar -->

                <a href="login.aspx" class="appointment-btn scrollto"><span class="d-none d-md-inline">Login</span> </a>

            </div>
        </header>
        <!-- End Header -->

        <main id="main">

            <!-- ======= Breadcrumbs Section ======= -->
            <section class="breadcrumbs">
                <div class="container">

                    <div class="d-flex justify-content-between align-items-center">
                        <h2></h2>
                        <ol>
                            <li><a href="home.aspx">Home</a></li>
                            <li>Login Page</li>
                        </ol>
                    </div>

                </div>
            </section>
            <!-- End Breadcrumbs Section -->

            <section class="inner-page">
                <div class="container">
                    <div class="row">
                       
                        <div class="col-sm-2">

                        </div>
                        <div class="col-sm-8">
                             <h5>Patient Registration</h5>
                            <table class="table table-responsive-sm ">
                                <caption></caption>
                                <tr>
                                    <td><label>Full Name</label></td>
                                    <td> <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td><label>Age</label></td>
                                    <td><asp:TextBox ID="txtAge" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td><label>Address</label></td>
                                    <td><asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td><label>City</label></td>
                                    <td><asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td><label>Country</label></td>
                                    <td><asp:TextBox ID="txtCountry" CssClass="form-control" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td><label>Email</label></td>
                                    <td><asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td><label>Password</label></td>
                                    <td><asp:TextBox ID="txtPass" CssClass="form-control" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td><label>Mobile</label></td>
                                    <td><asp:TextBox ID="txtMobile" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="form-group">
                                            <asp:Button ID="btnAdd" CssClass="btn btn-info" runat="server" Text="Registration" OnClick="btnAdd_Click" />
                                            
                                            <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="CANCEL" OnClick="btnCancel_Click"/>
                                        </div>
                                    </td>
                                </tr>
                            </table>

                            <div class="row">
                                <b>Note:</b> <p class="alert alert-danger">Doctor directly contact Admin for Registration </p> 
                            </div>
                        </div>
                        <div class="col-sm-2">

                        </div>
                    </div>

                </div>
            </section>

        </main>
        <!-- End #main -->

        <!-- ======= Footer ======= -->
        <footer id="footer">

            <div class="footer-top">
                <div class="container">
                    <div class="row">

                        <div class="col-lg-6 col-md-6 footer-contact">
                            <h3>Doctor Appointment</h3>
                            <p>
                                A108 Adam Street
                                <br>
                                Noida, Uttar Pradesh<br>
                                India
                                <br>
                                <br>
                                <strong>Phone:</strong> +91 8999097642,  8698887367<br>
                                <strong>Email:</strong> ss1721620@gmail.com ,inamdarmubeen77@gmail.com<br>
                            </p>
                        </div>

                       

                        <div class="col-lg-3 col-md-6 footer-links">
                            <%--<h4>Our Services</h4>
            <ul>
              <li><i class="bx bx-chevron-right"></i> <a href="#">Web Design</a></li>
              <li><i class="bx bx-chevron-right"></i> <a href="#">Web Development</a></li>
              <li><i class="bx bx-chevron-right"></i> <a href="#">Product Management</a></li>
              <li><i class="bx bx-chevron-right"></i> <a href="#">Marketing</a></li>
              <li><i class="bx bx-chevron-right"></i> <a href="#">Graphic Design</a></li>
            </ul>--%>
                        </div>

                        <div class="col-lg-4 col-md-6 footer-newsletter">
                            <%--<h4>Join Our Newsletter</h4>
            <p>Tamen quem nulla quae legam multos aute sint culpa legam noster magna</p>
            <form action="" method="post">
              <input type="email" name="email"><input type="submit" value="Subscribe">
            </form>--%>
                        </div>

                    </div>
                </div>
            </div>

            <div class="container d-md-flex py-4">

                <div class="me-md-auto text-center text-md-start">
                    <div class="copyright">
                        &copy; Copyright <strong><span>Doctor Appointment Scheduling System</span></strong>. All Rights Reserved
                    </div>
                    <div class="credits">
                        Designed & Created by <a href="#">Mubeen Inamdar & Shoil Shaikh</a>
                    </div>
                </div>
                <div class="social-links text-center text-md-right pt-3 pt-md-0">
                    <a href="#" class="twitter"><i class="bx bxl-twitter"></i></a>
                    <a href="#" class="facebook"><i class="bx bxl-facebook"></i></a>
                    <a href="#" class="instagram"><i class="bx bxl-instagram"></i></a>
                    <a href="#" class="google-plus"><i class="bx bxl-skype"></i></a>
                    <a href="#" class="linkedin"><i class="bx bxl-linkedin"></i></a>
                </div>
            </div>
        </footer>
        <!-- End Footer -->

        <div id="preloader"></div>
        <a href="#" class="back-to-top d-flex align-items-center justify-content-center"><i class="bi bi-arrow-up-short"></i></a>

        <!-- Vendor JS Files -->
        <script src="assets/vendor/purecounter/purecounter_vanilla.js"></script>
        <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="assets/vendor/glightbox/js/glightbox.min.js"></script>
        <script src="assets/vendor/swiper/swiper-bundle.min.js"></script>
        <script src="assets/vendor/php-email-form/validate.js"></script>

        <!-- Template Main JS File -->
        <script src="assets/js/main.js"></script>
    </form>
</body>
</html>
