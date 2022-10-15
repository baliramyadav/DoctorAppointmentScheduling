<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DoctorAppointmentScheduling.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
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
    <script src="assets/js/RememberMePassword.js"></script>
</head>
<body id="myPage" onload="showBoth()">
    <form id="form1" runat="server">
        <!-- ======= Top Bar ======= -->
        <div id="topbar" class="d-flex align-items-center fixed-top">
            <div class="container d-flex justify-content-between">
                <div class="contact-info d-flex align-items-center">
                    <i class="bi bi-envelope"></i><a href="#">inamdarmubeen77@gmail.com / ss1721620@gmail.com </a>
                    <i class="bi bi-phone"></i>+91 8999 0976 42 / 8698887367
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

                <h1 class="logo me-auto"><a href="home.aspx">Doctor Appointment System</a></h1>
                <!-- Uncomment below if you prefer to use an image logo -->
                <!-- <a href="index.html" class="logo me-auto"><img src="assets/img/logo.png" alt="" class="img-fluid"></a>-->

                <nav id="navbar" class="navbar order-last order-lg-0">
                    <ul>
                        <li><a class="nav-link scrollto " href="home.aspx">Home</a></li>
                        
                    </ul>
                    <i class="bi bi-list mobile-nav-toggle"></i>
                </nav>
                <!-- .navbar -->

                <a href="register.aspx" class="appointment-btn scrollto"><span class="d-none d-md-inline">Register</span> </a>

            </div>
        </header>
        <!-- End Header -->

        <main id="main">

            <!-- ======= Breadcrumbs Section ======= -->
            <section class="breadcrumbs">
                <div class="container">
                    <div class="d-flex justify-content-between align-items-center">
                        <%--<h2></h2>--%>
                        <ol>
                            <li><a href="home.aspx">Home</a></li>
                            <li>Login Page</li>
                        </ol>
                    </div>

                </div>
            </section>
            <!-- End Breadcrumbs Section -->

           <%-- <section class="inner-page">   </section>--%>
            <div class="container">
                    <%--<p>
          Example inner page template
        </p>--%>

                    <!------------   login form------------------->

                    <%--<section class="vh-100">--%>
                          <div class="cotainer">
                              <p></p>
                        <div class="row justify-content-center">
                            <div class="col-sm-8">
                                <div class="card">
                                    <div class="card-header"><b>Login</b></div>
                                    <div class="card-body">
                                        
                                            <div class="form-group row">
                                                <label for="email_address" class="col-md-4 col-form-label text-md-right">E-Mail Address</label>
                                                <div class="col-md-6">                                                    
                                                    <asp:TextBox ID="txtEmail" class="form-control" runat="server" TextMode="Email"></asp:TextBox>
                                                </div>
                                            </div>
                                        <div class="form-group row"> <br /></div>
                                            <div class="form-group row">
                                                <label for="password" class="col-md-4 col-form-label text-md-right">Password</label>
                                                <div class="col-md-6">
                                                    
                                                    <asp:TextBox ID="txtPassed" class="form-control" runat="server" TextMode="Password" required="true" onfocus="showPass()"></asp:TextBox>
                                                </div>
                                            </div>
                                        <div class="form-group row"> <br /></div>
                                            <div class="form-group row">
                                                <label for="password" class="col-md-4 col-form-label text-md-right">Role</label>
                                                <div class="col-md-6">
                                                    <asp:DropDownList ID="ddlRole" class="form-control" runat="server">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Doctor" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Patient" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                   
                                                </div>
                                            </div>
                                        <div class="form-group row"> <br /></div>
                                            <div class="form-group row">
                                                <div class="col-sm-6 offset-md-4">
                                                    <div class="checkbox">
                                                        <label>                                                            
                                                            <asp:CheckBox ID="chkRememberMe" runat="server" />
                                                            Remember Me
                                       
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                        <div class="form-group row"> <br /></div>
                                            <div class="col-sm-6 offset-md-4">                                              
                                                   
                                                    <asp:Button ID="btnLogin" runat="server" class="btn btn-success btn-sm" Text="Login" OnClick="btnLogin_Click" />
                                                <asp:Button ID="btnReset" runat="server" class="btn btn-danger btn-sm" Text="Reset" OnClick="btnReset_Click" />
                                                &nbsp;
                                                <br />   <span style="display:inline"> <a href="ForgotPassword.aspx" class="btn btn-link">Forgot Your Password? </a>  <a href="register.aspx" class="btn btn-link">New Patient Click Here </a>   </span>                  
                                                
                                                <br />
                                                <asp:Label ID="Label1" CssClass=" form-label" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        
                                        
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <%--</section>--%>


                  


                    <!-------------loginend----------->

                </div>
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
                                 Adam Street
                                <br/>
                                Noida, Uttar Pradesh<br/>
                                India
                                <br/>
                                <br/>
                                <strong>Phone:</strong> +91 8698887367 ,91 8999 0976 42 <br>
                                <strong>Email:</strong> ss1721620@gmail.com inamdarmubeen77@gmail.com<br/>
                            </p>
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
