<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="DoctorAppointmentScheduling.info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>success</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
            <div style="color:darkseagreen; width:50%; text-align:center; font-size:large">
                <h3>Hi , <asp:Label ID="Label1" runat="server" Text="" ForeColor="RoyalBlue"></asp:Label></h3>
                <p> Your Registration Successfully Completed</p>
                <p style="background-color:antiquewhite; font-size:large"> <asp:LinkButton ID="LinkButton1" PostBackUrl="~/login.aspx" runat="server">Click Here</asp:LinkButton></p>
            </div>
        </div>
    </form>
</body>
</html>
