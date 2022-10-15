using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DoctorAppointmentScheduling
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlDataReader dr;
                try
                {
                    //Here we will check from the passed querystring that if the email id/username and generated unique code is same then the panel for resetting password will be visible otherwise not
                    cmd = new SqlCommand("select UserName,EmailId,UniqueCode from Tbl_Login where UniqueCode=@uniqueCode and (EmailId=@emailid or UserName=@username)", con);
                    cmd.Parameters.AddWithValue("@uniqueCode", Convert.ToString(Request.QueryString["uCode"]));
                    cmd.Parameters.AddWithValue("@emailid", Convert.ToString(Request.QueryString["emailId"]));
                    cmd.Parameters.AddWithValue("@username", Convert.ToString(Request.QueryString["uName"]));

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        ResetPwdPanel.Visible = true;
                    }
                    else
                    {
                        ResetPwdPanel.Visible = false;
                        lblExpired.Text = "Reset password link has expired.It was for one time use only";
                        return;
                    }
                    dr.Close();
                    dr.Dispose();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error Occured: " + ex.Message.ToString();
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();
                }
            }
        }
        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            try
            {   // Here we will update the new password and also set the unique code to null so that it can be used only for once.
                cmd = new SqlCommand("update Tbl_Login set UniqueCode='',Pwd=@pwd where UniqueCode=@uniqueCode and (EmailId=@emailid or UserName=@username)", con);
                cmd.Parameters.AddWithValue("@uniqueCode", Convert.ToString(Request.QueryString["uCode"]));
                cmd.Parameters.AddWithValue("@emailid", Convert.ToString(Request.QueryString["emailId"]));
                cmd.Parameters.AddWithValue("@username", Convert.ToString(Request.QueryString["uName"]));
                cmd.Parameters.AddWithValue("@pwd", txtNewPwd.Text.Trim());
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                lblStatus.Text = "Your password has been updated successfully.";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                txtNewPwd.Text = string.Empty;
                txtConfirmPwd.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error Occured : " + ex.Message.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
    }
}