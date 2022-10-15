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
    public partial class addadmin : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindSizeRepeater();
                txtEmail.Focus();
                btnAdd.Visible = true;
                btnUpdate.Visible = false;

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                if (IsDuplicateRecord())
                {
                    Response.Write("<script>alert('Admin already Exist..')</script>");
                }
                else
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("sp_addAdmin", con);
                    cmd.Parameters.Clear();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Pass", txtPass.Text);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Response.Write("<script>alert('Record is ADDED Successfully')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error try again...')</script>");
                    }
                    con.Close();                    
                    txtEmail.Text = txtName.Text = txtPass.Text = "";
                    BindSizeRepeater();
                }

            }
            else
            {
                Response.Write("<script>alert('Error Validation failed try again...')</script>");
            }
        }
        private bool IsDuplicateRecord()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from tblAdmin where Email = @Email ");
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
        private bool IsFormValid()
        {
            if (txtEmail.Text == string.Empty)
            {
                Response.Write("<script>alert('EmailID is required')</script>");
                txtEmail.Text = string.Empty;
                txtEmail.Focus();
                return false;
            }
            if (txtPass.Text == string.Empty)
            {
                Response.Write("<script>alert('Password is required')</script>");
                txtPass.Text = string.Empty;
                txtPass.Focus();
                return false;
            }
            return true;
        }
        //--------Insert Record with quer---------------
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

        //---GetData by Procedure---------------
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

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                SearchDataForUp(Convert.ToInt32(id));
            }
            if (e.CommandName == "delete")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                SqlCommand cmd = new SqlCommand("sp_DeleteAdminByID");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", id);

                if (InsertUpdateData2(cmd))
                {
                    Response.Write("<script>alert('Record is Deleted Successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error!','Error try again...')</script>");
                }
                btnUpdate.Visible = false;
                btnAdd.Visible = true;
                //PNLisActive.Visible = false;
                BindSizeRepeater();
            }
            if (e.CommandName == "print")
            {

            }
        }
        private void SearchDataForUp(int idd)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("sp_SearchAdminByID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", idd);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        da.Fill(ds, "dt");
                        con.Close();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Session["sAdminID"] = ds.Tables[0].Rows[0]["AdminID"].ToString();
                            txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                            txtPass.TextMode = TextBoxMode.SingleLine;
                            txtPass.Text = ds.Tables[0].Rows[0]["Pass"].ToString();

                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                            // PNLisActive.Visible = true;
                        }
                        else
                        {
                            Response.Write("<script>alert('Error! No Record Found try again...')</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        private void BindSizeRepeater()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SearchAdmin");
                cmd.Parameters.Clear();
                DataTable dt = GetDataByProc(cmd);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {

                SqlCommand cmd = new SqlCommand("sp_UpdateAdmin");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(Session["sAdminID"].ToString()));
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Pass", txtPass.Text);
                
                if (InsertUpdateData2(cmd))
                {
                    Response.Write("<script>alert('Record UPDATED Successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('UPDATED Failed try again...')</script>");
                }
                BindSizeRepeater();
                txtEmail.Text = txtName.Text = txtPass.Text = "";
                btnUpdate.Visible = false;
                btnAdd.Visible = true;

                Session.Remove("sAdminID");


            }
            else
            {
                Response.Write("<script> alert('UPDATED Failed try again...')</script>");
            }
        }
    }
}