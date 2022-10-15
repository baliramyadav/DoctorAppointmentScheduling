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
    public partial class patient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    BindSizeRepeater_PageLoad();
                    btnUpdate.Visible = false;
                    btnAdd.Visible = true;
                    txtName.Focus();
                }
                else
                {
                    Response.Write("<script>alert('session timeout..login again')</script>");
                }
               

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
            txtName.Text = txtAge.Text = txtCity.Text = txtCountry.Text = txtAddress.Text = txtPass.Text = txtEmail.Text  = txtMobile.Text = "";
            txtName.Focus();
        }

        private void BindSizeRepeater_PageLoad()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PatientSearchAll");
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
        private void BindSizeRepeater()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PatientSearchAll");
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
        private void SearchDataForUp(int idd)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("sp_PatientSearch_ByID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();                    
                    cmd.Parameters.AddWithValue("@PatID", idd);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        da.Fill(ds, "dt");
                        con.Close();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Session["sPatID"] = ds.Tables[0].Rows[0]["PatID"].ToString();
                            txtName.Text = ds.Tables[0].Rows[0]["PatName"].ToString();
                            txtAge.Text = ds.Tables[0].Rows[0]["age"].ToString();
                             
                            txtAddress.Text = ds.Tables[0].Rows[0]["PatAddress"].ToString();
                            txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                            txtCountry.Text = ds.Tables[0].Rows[0]["Country"].ToString();
                            txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();

                            txtPass.TextMode = TextBoxMode.SingleLine; 
                            txtPass.Text = ds.Tables[0].Rows[0]["Pass"].ToString();
                            txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();

                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                            txtName.Focus();
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
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@PatAddress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                    cmd.Parameters.AddWithValue("@EmailID", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Pass", txtPass.Text);
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);                    
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                        Response.Write("<script>alert('Record is ADDED Successfully')</script>");                         
                    }
                    else
                    {
                        Response.Write("<script>alert('Error try again...')</script>");
                    }
                    con.Close();
                    txtEmail.Text = txtName.Text = txtPass.Text = "";
                    clrcontrol();
                    BindSizeRepeater();
                }
            }
            else
            {
                Response.Write("<script>alert('enter valid Email and Password')</script>");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text!=string.Empty && txtAge.Text!=string.Empty && txtCity.Text!="" && txtCountry.Text!="" && txtEmail.Text != string.Empty && txtPass.Text != string.Empty)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("sp_PatientUpdate", con);
                cmd.Parameters.Clear();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatName", txtName.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@PatAddress", txtAddress.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                cmd.Parameters.AddWithValue("@EmailID", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Pass", txtPass.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@PatID", Convert.ToInt32(Session["sPatID"].ToString()));
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    Response.Write("<script>alert('Record is UPDATE Successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error try again...')</script>");
                }
                con.Close();
                txtEmail.Text = txtName.Text = txtPass.Text = "";
                btnAdd.Visible = true;
                btnUpdate.Visible = false;
                clrcontrol();
                BindSizeRepeater();
            }
            else
            {
                Response.Write("<script>alert('enter valid Email and Password')</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            clrcontrol();
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
                SqlCommand cmd = new SqlCommand("sp_PatientDelete");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PatID", id);

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
                BindSizeRepeater();
            }
            if (e.CommandName == "print")
            {

            }
        }
    }
}