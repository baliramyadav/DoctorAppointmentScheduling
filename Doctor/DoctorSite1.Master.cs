using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentScheduling.Doctor
{
    public partial class DoctorSite1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UserName"] as string) && (Session["RoleType"].ToString() == "Doctor"))
            {
                if (!IsPostBack)
                {
                    if (Session["UserName"] != null && Session["RoleType"].ToString() == "Doctor")
                    {
                        if (Session["RoleType"].ToString() == "Doctor")
                        {
                            //lblUserName.Text = "Welcome ";
                            this.lblUserName.Text = string.Format(" {0}", Session["UserName"].ToString());
                            this.lblLoginMemEmail.Text = string.Format(" {0}", Session["UserName"].ToString());
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