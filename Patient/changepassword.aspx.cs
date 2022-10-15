using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DoctorAppointmentScheduling.Patient
{
    public partial class changepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    lblEmail.Text = "";
                    divmsg.Visible = false;
                }
                else
                {
                    Response.Write("<script>alert('session timeout..login again')</script>");
                }


            }
        }

        

        //protected void txtOldPass_TextChanged(object sender, EventArgs e)
        //{
        //    if(IsDuplicateRecord())
        //    {
                
        //    }
        //    else
        //    {
        //        divmsg.Visible = true;
        //        Response.Write("<script>alert('Old Password Not Matched')</script>");
        //        lblEmail.Text = Session["EmailID"].ToString() +" ! "+ "Password does not match with our database records.";
        //        lblEmail.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        public DataTable GetDataByProc(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                string aa = ex.Message;
                return null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }
        private bool IsDuplicateRecord()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select EmailID,Pass from Patient where EmailID = @Email  and Pass=@Pass");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Email", Session["EmailID"].ToString());
                cmd.Parameters.AddWithValue("@Pass", txtOldPass.Text );

                DataTable dt = GetData1(cmd);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }

        public Boolean InsertUpdateData2(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string aa = ex.Message;
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        //---GetData by SQL Query---------------
        public DataTable GetData1(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
            DataTable dt = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtOldPass.Text!=string.Empty && txtNewPass.Text!=string .Empty)
            {
                if(IsDuplicateRecord())
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("sp_changePassPatient", con);
                    cmd.Parameters.Clear();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmailID", Session["EmailID"].ToString());
                    cmd.Parameters.AddWithValue("@Pass", txtNewPass.Text);

                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                        Response.Write("<script>alert(' UPDATE Successfully')</script>");
                        lblEmail.Text = Session["EmailID"].ToString() + " " + "Password has been changed successfully.";
                        lblEmail.ForeColor = System.Drawing.Color.SeaGreen;
                    }
                    else
                    {
                        Response.Write("<script>alert('Error try again...')</script>");
                        lblEmail.Text = "Enter valid Password .";
                        lblEmail.ForeColor = System.Drawing.Color.Red;
                    }
                    con.Close();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Password try again.. ')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('validation issue ')</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtOldPass.Text = txtNewPass.Text = "";
        }
    }
}