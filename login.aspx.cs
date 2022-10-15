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
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BinRole();
                Session.Abandon();
                Session.RemoveAll();
                Label1.Text = "";
                //txtEmail.Focus(); 
                txtEmail.Text = "admin@gamil.com";
                txtPassed.Text = "123";
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["Userpwd"] = txtPassed.Text;
            try
            {
                if (IsFormValid())
                {

                }
                if (ddlRole.SelectedItem.Text == "Admin")
                {
                    AdminLogin();
                    
                }
                else if (ddlRole.SelectedItem.Text == "Doctor")
                {
                   DoctorLogin();
                    
                }
                else if (ddlRole.SelectedItem.Text == "Patient")
                {
                    PatientLogin();
                    
                }
                else
                {
                    Label1.Text = "Please Select Role Type";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
                //UpdateForgetPassTable();

            }
            catch 
            {

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtEmail.Text = txtPassed.Text = Label1.Text = "";
            ddlRole.Text = "Select";
        }
        private void AdminLogin()
        {
            SqlCommand cmd = new SqlCommand("sp_AdminLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Pass", txtPassed.Text.Trim());
            cmd.Parameters.AddWithValue("@RoleID", ddlRole.SelectedValue);
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (chkRememberMe.Checked)
                        {
                            HttpCookie co = new HttpCookie(txtEmail.Text, txtPassed.Text);
                            co.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(co);
                        }
                        if (chkRememberMe.Checked)
                        {
                            HttpCookie co1 = new HttpCookie("erplastid", txtEmail.Text);
                            co1.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(co1);
                            HttpCookie co2 = new HttpCookie("erplastpass", txtPassed.Text);
                            co2.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(co2);
                        }
                        Response.Write("<script>alert('" + dr.GetValue(0).ToString() + "')</script>");
                        Session["EmailID"] = dr.GetValue(0).ToString();
                        Session["RoleType"] = dr.GetValue(1).ToString();
                        Session["UserName"] = dr.GetValue(2).ToString();                        

                    }
                    if (Session["RoleType"].ToString() == "Admin")  //Administrator 
                    {
                       UpdateForgetPassTable();
                        //cmd = new SqlCommand("update tblAdmin set LastLogin=GETDATE() where Email=@email", con);
                        //cmd.Parameters.Clear();
                        //cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        //cmd.ExecuteNonQuery();
                        Response.Redirect("Admin/adminhome.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("~/logout.aspx");
                    }
                }
                else
                {
                    Session.Remove("EmailID"); 
                    Session.Remove("UserName"); Session.Remove("RoleType");
                    txtEmail.Text = string.Empty;
                    txtPassed.Text = string.Empty;
                    Label1.Visible = true;
                    Label1.Text = "Use correct email and password</br>";
                    Response.Write("<script>alert('Invalid UserID or Password...Try again')</script>");
                }
            }
            catch (Exception ex)//Exception ex
            {
                Label1.Visible = true;
                Label1.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        private void DoctorLogin()
        {
            SqlCommand cmd = new SqlCommand("sp_DoctorLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Pass", txtPassed.Text.Trim());
            cmd.Parameters.AddWithValue("@RoleID", ddlRole.SelectedValue);
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (chkRememberMe.Checked)
                        {
                            HttpCookie co = new HttpCookie(txtEmail.Text, txtPassed.Text);
                            co.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(co);
                        }
                        if (chkRememberMe.Checked)
                        {
                            HttpCookie co1 = new HttpCookie("erplastid", txtEmail.Text);
                            co1.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(co1);
                            HttpCookie co2 = new HttpCookie("erplastpass", txtPassed.Text);
                            co2.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(co2);
                        }
                        Response.Write("<script>alert('" + dr.GetValue(0).ToString() + "')</script>");
                        Session["EmailID"] = dr.GetValue(0).ToString();
                        Session["RoleType"] = dr.GetValue(1).ToString();
                        Session["UserName"] = dr.GetValue(2).ToString();

                        //Session["FirstName"] = dr.GetValue(4).ToString();
                        //updateLoginTime();
                        //UploadLastLoginDateTime_AfterLogin();

                    }
                    if (Session["RoleType"].ToString() == "Doctor")  //Administrator 
                    {
                        UpdateForgetPassTable();
                        Response.Redirect("Doctor/doctorhome.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("~/logout.aspx");
                    }
                }
                else
                {
                    Session.Remove("UserID");
                    Session.Remove("UserName"); Session.Remove("RoleType");
                    txtEmail.Text = string.Empty;
                    txtPassed.Text = string.Empty;
                    Label1.Visible = true;
                    Label1.Text = "Use correct email and password</br>";
                    Response.Write("<script>alert('Invalid UserID or Password...Try again')</script>");
                }
            }
            catch (Exception ex)//Exception ex
            {
                Label1.Visible = true;
                Label1.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        private void PatientLogin()
        {
            SqlCommand cmd = new SqlCommand("sp_PatientLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Pass", txtPassed.Text.Trim());
            cmd.Parameters.AddWithValue("@RoleID", ddlRole.SelectedValue);
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (chkRememberMe.Checked)
                        {
                            HttpCookie co = new HttpCookie(txtEmail.Text, txtPassed.Text);
                            co.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(co);
                        }
                        if (chkRememberMe.Checked)
                        {
                            HttpCookie co1 = new HttpCookie("erplastid", txtEmail.Text);
                            co1.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(co1);
                            HttpCookie co2 = new HttpCookie("erplastpass", txtPassed.Text);
                            co2.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(co2);
                        }
                        Response.Write("<script>alert('" + dr.GetValue(0).ToString() + "')</script>");
                        Session["EmailID"] = dr.GetValue(0).ToString();
                        Session["RoleType"] = dr.GetValue(1).ToString();
                        Session["UserName"] = dr.GetValue(2).ToString();
                        
                        //updateLoginTime();
                        //UploadLastLoginDateTime_AfterLogin();

                    }
                    if (Session["RoleType"].ToString() == "Patient")  //Administrator 
                    {
                        UpdateForgetPassTable();
                        Response.Redirect("Patient/patienthome.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("~/logout.aspx");
                    }
                }
                else
                {
                    Session.Remove("EmailID");
                    Session.Remove("UserName"); Session.Remove("RoleType");
                    txtEmail.Text = string.Empty;
                    txtPassed.Text = string.Empty;
                    Label1.Visible = true;
                    Label1.Text = "Use correct email and password</br>";
                    Response.Write("<script>alert('Invalid UserID or Password...Try again')</script>");
                }
            }
            catch (Exception ex)//Exception ex
            {
                Label1.Visible = true;
                Label1.Text = "Something went wrong! Contact your devloper </br>" + ex.Message;
            }
            finally
            {
                con.Close();
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
            if (txtPassed.Text == string.Empty)
            {
                Response.Write("<script>alert('Password is required')</script>");
                txtPassed.Text = string.Empty;
                txtPassed.Focus();
                return false;
            }
            return true;
        }

        private void BinRole()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Role");
                cmd.Parameters.Clear();                
                DataTable dt = GetDataByProc(cmd);
                ddlRole.DataSource = dt;
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleID";
                ddlRole.DataBind();
                System.Web.UI.WebControls.ListItem ddlproject = new System.Web.UI.WebControls.ListItem("Select Role", "-1");
                ddlRole.Items.Insert(0, ddlproject);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "B", "swal('Error!','something went wrong please try again...','warning')", true);
            }
        }

        public DataTable GetDataByProc(SqlCommand cmd)
        {
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
        private void updateadmin()
        {
            SqlCommand cmd = new SqlCommand("update tblAdmin set LastLogin=GETDATE() where Email=@email", con);           
                
            cmd.Parameters.AddWithValue("@email",txtEmail.Text);
            cmd.ExecuteNonQuery();           

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
        public void UpdateForgetPassTable()
        {
            if(IsDuplicateRecord())
            {

            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into Tbl_Login(UserName,EmailId,Pwd) values(@UserName,@EmailId,@Pwd)");
                cmd.Parameters.Clear();
                
                cmd.Parameters.AddWithValue("@UserName", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("@EmailId", Session["EmailID"].ToString());
                cmd.Parameters.AddWithValue("@Pwd", Session["Userpwd"].ToString());
                
                if(InsertUpdateData(cmd))
                {

                }
                else
                {
                    //-------
                }
            }
        }
        private bool IsDuplicateRecord()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select Id,UserName,EmailId,Pwd from Tbl_Login where EmailId=@EmailId ");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EmailId", Session["EmailID"].ToString());

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