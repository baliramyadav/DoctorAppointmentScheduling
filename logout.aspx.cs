using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentScheduling
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["UserID"] != null)
                    {
                        
                    }
                    else
                    {

                    }
                    Session.Abandon();
                    Session.Clear();
                    Session.RemoveAll();
                    
                    System.Threading.Thread.Sleep(100);
                    string currenttime = DateTime.Now.ToShortTimeString();
                   
                    Response.AppendHeader("Refresh", "3;url=home.aspx");
                    // Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}