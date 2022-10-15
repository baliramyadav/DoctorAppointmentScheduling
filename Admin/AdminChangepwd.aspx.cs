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
    public partial class AdminChangepwd : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    BindDoctor();
                    BindPatient();
                    txtyourEmail.Text = Session["EmailID"].ToString();
                    lblMymsg.Text = lblDocPass.Text = lblPatientmsg.Text = "";

                }
                else
                {
                    Response.Write("<script>alert('session timeout..login again')</script>");
                    Response.Write("logout.aspx");
                }
            }
        }
        private void BindDoctor()
        {
            try
            {
                lblMymsg.Text = lblDocPass.Text = lblPatientmsg.Text = "";
                SqlCommand cmd = new SqlCommand("select DocID,EmailID from Doctor order by EmailID");
                cmd.Parameters.Clear();
                DataTable dt = GetData1(cmd);
                ddlDocEmail.DataSource = dt;
                ddlDocEmail.DataTextField = "EmailID";
                ddlDocEmail.DataValueField = "DocID";
                ddlDocEmail.DataBind();
                System.Web.UI.WebControls.ListItem ddlproject = new System.Web.UI.WebControls.ListItem("Select Doctor", "-1");
                ddlDocEmail.Items.Insert(0, ddlproject);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        private void BindPatient()
        {
            try
            {
                lblMymsg.Text = lblDocPass.Text = lblPatientmsg.Text = "";
                SqlCommand cmd = new SqlCommand("select distinct PatID, EmailID from Patient");
                cmd.Parameters.Clear();
                DataTable dt = GetData1(cmd);
                ddlPatientEmail.DataSource = dt;
                ddlPatientEmail.DataTextField = "EmailID";
                ddlPatientEmail.DataValueField = "PatID";
                ddlPatientEmail.DataBind();
                System.Web.UI.WebControls.ListItem ddlproject = new System.Web.UI.WebControls.ListItem("Select Spacialist", "-1");
                ddlPatientEmail.Items.Insert(0, ddlproject);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

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

        protected void btnDoctorPass_Click(object sender, EventArgs e)
        {
            if (txtDoctorPass.Text != string.Empty && ddlDocEmail.SelectedItem.Text != "Select Doctor")
            {
                lblMymsg.Text = lblDocPass.Text = lblPatientmsg.Text = "";
                SqlCommand cmd = new SqlCommand("update Doctor set Pass=@Pass where EmailID=@Email");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Pass", txtDoctorPass.Text);
                cmd.Parameters.AddWithValue("@EmailID", ddlDocEmail.SelectedItem.Text);
                if (InsertUpdateData(cmd))
                {
                    lblDocPass.Text = "Your Password change successfully";
                    lblDocPass.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblDocPass.Text = "Your Password not change Error";
                    lblDocPass.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblDocPass.Text = "Your Password not change Error";
                lblDocPass.ForeColor = System.Drawing.Color.Red;
            }                
        }

        protected void btnPatient_Click(object sender, EventArgs e)
        {
            if(txtPatientPass.Text!=string.Empty && ddlPatientEmail.SelectedItem.Text!= "Select Patient")
            {
                lblMymsg.Text = lblDocPass.Text = lblPatientmsg.Text = "";
                SqlCommand cmd = new SqlCommand("update Patient set Pass=@Pass where EmailID=@Email");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Pass", txtPatientPass.Text);
                cmd.Parameters.AddWithValue("@Email", ddlPatientEmail.SelectedItem.Text);
                if (InsertUpdateData(cmd))
                {
                    lblPatientmsg.Text = "Your Password change successfully";
                    lblPatientmsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblPatientmsg.Text = "Your Password not change Error";
                    lblPatientmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblPatientmsg.Text = "Your Password not change Error";
                lblPatientmsg.ForeColor = System.Drawing.Color.Red;
            }
            
        }

        protected void btnmypass_Click(object sender, EventArgs e)
        {
            if(txtyourEmail.Text!=string.Empty && txtentermypass.Text!=string.Empty)
            {
                lblMymsg.Text = lblDocPass.Text = lblPatientmsg.Text = "";
                SqlCommand cmd = new SqlCommand("update tblAdmin set Pass=@Pass where Email=@Email");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Pass", txtentermypass.Text);
                cmd.Parameters.AddWithValue("@Email", txtyourEmail.Text);
                if (InsertUpdateData(cmd))
                {
                    lblMymsg.Text = "Your Password change successfully";
                    lblMymsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMymsg.Text = "Your Password not change Error";
                    lblMymsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMymsg.Text = "Your Password not change Error";
                lblMymsg.ForeColor = System.Drawing.Color.Red;
            }
            
        }
       
        public Boolean InsertUpdateData(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
            cmd.CommandType = CommandType.Text;
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
    }
}