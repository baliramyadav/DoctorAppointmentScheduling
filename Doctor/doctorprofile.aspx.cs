using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DoctorAppointmentScheduling.Doctor
{
    public partial class doctorprofile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    Bindspecialist();
                    BindSizeRepeater_PageLoad();
                    btnUpdate.Visible = false;
                    statusDiv.Visible = false;
                    txtName.Focus();
                }
                else
                {
                    Response.Write("<script>alert('session timeout..login again')</script>");
                    Response.Write("logout.aspx");
                }
            }
        }


        private void Bindspecialist()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Searchspecialist");
                cmd.Parameters.Clear();
                DataTable dt = GetDataByProc(cmd);
                ddlspecialist.DataSource = dt;
                ddlspecialist.DataTextField = "specialistDesc";
                ddlspecialist.DataValueField = "specialistID";
                ddlspecialist.DataBind();
                System.Web.UI.WebControls.ListItem ddlproject = new System.Web.UI.WebControls.ListItem("Select Spacialist", "-1");
                ddlspecialist.Items.Insert(0, ddlproject);
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

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (txtEmail.Text != string.Empty && txtPass.Text != string.Empty)
        //    {
        //        if (IsDuplicateRecord())
        //        {
        //            Response.Write("<script>alert('Doctor already Exist..')</script>");
        //        }
        //        else
        //        {
        //            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
        //            SqlCommand cmd = new SqlCommand("spDoctorInsert", con);
        //            cmd.Parameters.Clear();
        //            if (con.State == ConnectionState.Closed)
        //            {
        //                con.Open();
        //            }

        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@DocName", txtName.Text);
        //            cmd.Parameters.AddWithValue("@DocDegree", txtDegree.Text);
        //            cmd.Parameters.AddWithValue("@specialistID", ddlspecialist.SelectedValue);



        //            cmd.Parameters.AddWithValue("@AvailableDays", txtchkAvailableDays.Text);
        //            cmd.Parameters.AddWithValue("@AvaiTimeStart", txtAvaTimeStart.Text);
        //            cmd.Parameters.AddWithValue("@AvaiTimeEnd", txtAvaTimeEnd.Text);
        //            cmd.Parameters.AddWithValue("@EmailID", txtEmail.Text);
        //            cmd.Parameters.AddWithValue("@Pass", txtPass.Text);
        //            cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
        //            cmd.Parameters.AddWithValue("@City", txtCity.Text);
        //            cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
        //            int i = cmd.ExecuteNonQuery();
        //            if (i == 1)
        //            {
        //                Response.Write("<script>alert('Record is ADDED Successfully')</script>");
        //                lblDays.Text = "";
        //            }
        //            else
        //            {
        //                Response.Write("<script>alert('Error try again...')</script>");
        //            }
        //            con.Close();
        //            txtEmail.Text = txtName.Text = txtPass.Text = "";
        //            clrcontrol();
        //            BindSizeRepeater();
        //        }
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('enter valid Email and Password')</script>");
        //    }
        //}
        private bool IsDuplicateRecord()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from Doctor where EmailID = @Email ");
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != string.Empty && txtPass.Text != string.Empty)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("spDoctorUpdate", con);
                cmd.Parameters.Clear();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DocName", txtName.Text);
                cmd.Parameters.AddWithValue("@DocDegree", txtDegree.Text);
                cmd.Parameters.AddWithValue("@specialistID", ddlspecialist.SelectedValue);



                cmd.Parameters.AddWithValue("@AvailableDays", txtchkAvailableDays.Text);
                cmd.Parameters.AddWithValue("@AvaiTimeStart", txtAvaTimeStart.Text);
                cmd.Parameters.AddWithValue("@AvaiTimeEnd", txtAvaTimeEnd.Text);
                cmd.Parameters.AddWithValue("@EmailID", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Pass", txtPass.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                cmd.Parameters.AddWithValue("@DocStatus", ddlStatus.SelectedValue);
                cmd.Parameters.AddWithValue("@DocID", Convert.ToInt32(Session["sDocID"].ToString()));
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    Response.Write("<script>alert('Record is UPDATED Successfully')</script>");
                    lblDays.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('Error try again...')</script>");
                }
                con.Close();
                txtEmail.Text = txtName.Text = txtPass.Text = "";
               // btnAdd.Visible = false;
                btnUpdate.Visible = false;
                divupdateForm.Visible = false;
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
            clrcontrol();
            btnUpdate.Visible = false;
            //btnAdd.Visible = true;
            divupdateForm.Visible = false;
        }
        private void clrcontrol()
        {
            txtName.Text = txtDegree.Text = txtCity.Text = txtCountry.Text = txtConfirmPass.Text = txtPass.Text = txtEmail.Text = txtAvaTimeStart.Text = txtAvaTimeEnd.Text = "";
            txtchkAvailableDays.Text = "";
            txtMobile.Text = "";
            ddlspecialist.SelectedItem.Text = "Select Spacialist";
            statusDiv.Visible = false;
            ddlStatus.Visible = false;
            divupdateForm.Visible = false;
            txtName.Focus();
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
                SqlCommand cmd = new SqlCommand("sp_deleteDoctor");
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
                divupdateForm.Visible = false;
                //btnAdd.Visible = true;
                //PNLisActive.Visible = false;
                BindSizeRepeater();
            }
            if (e.CommandName == "print")
            {

            }
        }
        private void BindSizeRepeater_PageLoad()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_SearchDoctor");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@status", "SELECT_ByEmail");
                cmd.Parameters.AddWithValue("@EmailID", Session["EmailID"].ToString());
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
                SqlCommand cmd = new SqlCommand("sp_SearchDoctor");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@status", "SELECT_ByEmail");
                cmd.Parameters.AddWithValue("@EmailID", Session["EmailID"].ToString());
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
                using (SqlCommand cmd = new SqlCommand("sp_SearchDoctor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@status", "SELECT_ByID");
                    cmd.Parameters.AddWithValue("@DocID", idd);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        da.Fill(ds, "dt");
                        con.Close();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Session["sDocID"] = ds.Tables[0].Rows[0]["DocID"].ToString();
                            txtName.Text = ds.Tables[0].Rows[0]["DocName"].ToString();
                            txtDegree.Text = ds.Tables[0].Rows[0]["DocDegree"].ToString();
                            Bindspecialist();
                            ddlspecialist.SelectedValue = ds.Tables[0].Rows[0]["specialistID"].ToString();
                            txtchkAvailableDays.Text = ds.Tables[0].Rows[0]["AvailableDays"].ToString();


                            txtAvaTimeStart.Text = ds.Tables[0].Rows[0]["AvaiTimeStart"].ToString();
                            txtAvaTimeEnd.Text = ds.Tables[0].Rows[0]["AvaiTimeEnd"].ToString();
                            txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();

                            txtPass.TextMode = TextBoxMode.SingleLine;
                            txtConfirmPass.TextMode = TextBoxMode.SingleLine;

                            txtPass.Text = ds.Tables[0].Rows[0]["Pass"].ToString();
                            //txtConfirmPass.Text = ds.Tables[0].Rows[0]["Pass"].ToString();
                            txtConfirmPass.Text = txtPass.Text;


                            txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                            txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                            txtCountry.Text = ds.Tables[0].Rows[0]["Country"].ToString();
                            ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["DocStatus"].ToString();


                            statusDiv.Visible = true;
                            ddlStatus.Visible = true;
                            //btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                            divupdateForm.Visible = true;
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
    }
}