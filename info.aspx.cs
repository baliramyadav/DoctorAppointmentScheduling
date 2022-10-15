using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentScheduling
{
    public partial class info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Request.QueryString["name"];
            Label1.Text = Session["Rgname"].ToString();
        }
    }
}