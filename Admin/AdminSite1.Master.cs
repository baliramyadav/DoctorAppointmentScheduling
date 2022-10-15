using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DoctorAppointmentScheduling.Admin
{
    public partial class AdminSite1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Session["UserName"] as string) && (Session["RoleType"].ToString() == "Admin"))
            {
                if (!IsPostBack)
                {
                    if (Session["UserName"] != null && Session["RoleType"].ToString() == "Admin")
                    {
                        if (Session["RoleType"].ToString() == "Admin")
                        {
                            //lblUserName.Text = "Welcome ";
                            this.lblUserName.Text = string.Format(" {0}", Session["UserName"].ToString());
                        }
                        else
                        {
                           
                        }
                                               
                    }
                    else
                    {
                        Response.Redirect("~/logout.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/logout.aspx");
            }
        }
    }
}