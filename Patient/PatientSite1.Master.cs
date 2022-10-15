using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentScheduling.Patient
{
    public partial class PatientSite1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["UserName"] as string) && (Session["RoleType"].ToString() == "Patient"))
            {
                if (!IsPostBack)
                {
                    if (Session["UserName"] != null && Session["RoleType"].ToString() == "Patient")
                    {
                        if (Session["RoleType"].ToString() == "Patient")
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