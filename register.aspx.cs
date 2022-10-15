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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != string.Empty && txtPass.Text != string.Empty)
            {
                if (IsDuplicateRecord())
                {
                    Response.Write("<script>alert('Patient already Exist..')</script>");
                }
                else
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("sp_PatientInsert", con);
                    cmd.Parameters.Clear();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatName", txtName.Text);
                    Session["Rgname"] = txtName.Text;
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@PatAddress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                    cmd.Parameters.AddWithValue("@EmailID", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Pass", txtPass.Text);
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i == 1)
                    {
                        Response.Write("<script>alert('Record is ADDED Successfully')</script>");
                        Server.Transfer("info.aspx ? name ='"+txtName.Text+"'");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error try again...')</script>");
                    }                   
                    
                    //clrcontrol();
                    
                }
            }
            else
            {
                Response.Write("<script>alert('enter valid Email and Password')</script>");
            }
        }

        

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
        private bool IsDuplicateRecord()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from Patient where EmailID = @Email ");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

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
        private void clrcontrol()
        {
            txtName.Text = txtAge.Text = txtCity.Text = txtCountry.Text = txtAddress.Text = txtPass.Text = txtEmail.Text = txtMobile.Text = "";
            txtName.Focus();
        }
        //----insert with procedure------
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
    }
}