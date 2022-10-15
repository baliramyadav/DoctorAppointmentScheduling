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
    public partial class newappointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    Binddoctor();
                    Bindpatient();
                    BindSizeRepeater_PageLoad();
                    btnUpdate.Visible = false;
                    Divappstatus.Visible = false;                    
                }
                else
                {
                    Response.Write("<script>alert('session timeout..login again')</script>");
                }


            }
        }
       
     
        private void clrcontrol()
        {
            txtAppdate.Text = txtAppTime.Text = txtAppdate.Text =txtAboutDisease.Text= "";
            ddlDoctor.SelectedIndex = 0;
            ddlPatient.SelectedIndex = 0;
            Divappstatus.Visible = false;
        }
        private void Binddoctor()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetDoctor");
                cmd.Parameters.Clear();
                ddlDoctor.DataSource = GetDataByProc(cmd);
                ddlDoctor.DataTextField = "DocName";
                ddlDoctor.DataValueField = "DocID";
                ddlDoctor.DataBind();
                System.Web.UI.WebControls.ListItem ddlproject = new System.Web.UI.WebControls.ListItem("Select Option", "-1");
                ddlDoctor.Items.Insert(0, ddlproject);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");                
            }
        }
        private void Bindpatient()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_getPatient_byEmail");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EmailID", Session["EmailID"].ToString());

                ddlPatient.DataSource = GetDataByProc(cmd);
                ddlPatient.DataTextField = "PatName";
                ddlPatient.DataValueField = "PatID";
                ddlPatient.DataBind();
                System.Web.UI.WebControls.ListItem ddlproject = new System.Web.UI.WebControls.ListItem("Select Option", "-1");
                ddlPatient.Items.Insert(0, ddlproject);
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
        private void BindSizeRepeater_PageLoad()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_AppointmentSearch_ByEmail");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PatEmail", Session["EmailID"].ToString());
                DataTable dt = GetDataByProc(cmd);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                //GridView1.DataSource = dt;
                //GridView1.DataBind();
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
                SqlCommand cmd = new SqlCommand("sp_AppointmentSearch_ByEmail");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PatEmail", Session["EmailID"].ToString());
                DataTable dt = GetDataByProc(cmd);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                //GridView1.DataSource = dt;
                //GridView1.DataBind();
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
            if(ddlDoctor.SelectedItem.Text!= "Select Option" && ddlPatient.SelectedItem.Text!= "Select Option" && txtAppdate.Text!=string.Empty && txtAppTime.Text!=string.Empty )
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("sp_AppointmentInsert", con);
                cmd.Parameters.Clear();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AppDate", txtAppdate.Text);
                cmd.Parameters.AddWithValue("@AppTime", txtAppTime.Text);
                cmd.Parameters.AddWithValue("@DocID", ddlDoctor.SelectedValue);
                cmd.Parameters.AddWithValue("@PatID", ddlPatient.SelectedValue);
                cmd.Parameters.AddWithValue("@AboutDisease", txtAboutDisease.Text);
                cmd.Parameters.AddWithValue("@AppStatus", "Pending");
                
                cmd.Parameters.AddWithValue("@CreatedBy", Session["EmailID"].ToString());
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    Response.Write("<script>alert('Appointment created Successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error try again...')</script>");
                }
                con.Close();
                
                clrcontrol();
                BindSizeRepeater();
            }
            else
            {
                Response.Write("<script>alert('Data Validation issue')</script>");
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
                using (SqlCommand cmd = new SqlCommand("sp_AppointmentSearch_ByID", con))
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
                            Session["sAppID"] = ds.Tables[0].Rows[0]["ID"].ToString();

                            DateTime dt1;
                            DateTime.TryParse(ds.Tables[0].Rows[0]["AppDate"].ToString(), out dt1);
                            txtAppdate.Text = dt1.ToString("yyyy-MM-dd");

                            //txtAppdate.Text = ds.Tables[0].Rows[0]["AppDate"].ToString();
                            //DateTime dt2;
                            //DateTime.TryParse(ds.Tables[0].Rows[0]["AppTime"].ToString(), out dt2);
                            //txtAppTime.Text = dt2.ToString("hh:mm:ss tt");



                            txtAppTime.Text = ds.Tables[0].Rows[0]["AppTime"].ToString();

                            ddlDoctor.SelectedValue = ds.Tables[0].Rows[0]["DocID"].ToString();
                            ddlPatient.SelectedValue = ds.Tables[0].Rows[0]["PatID"].ToString();
                            
                            ddlAppStatus.SelectedValue = ds.Tables[0].Rows[0]["AppStatus"].ToString();
                            txtAboutDisease.Text = ds.Tables[0].Rows[0]["AboutDisease"].ToString();


                            btnAdd.Visible = false;
                            btnUpdate.Visible = true;
                            
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
                SqlCommand cmd = new SqlCommand("sp_AppointmentDelete_ByID");
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
                BindSizeRepeater();
            }
            if (e.CommandName == "print")
            {

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ddlDoctor.SelectedItem.Text != "Select Option" && ddlPatient.SelectedItem.Text != "Select Option" && txtAppdate.Text != string.Empty && txtAppTime.Text != string.Empty)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("sp_Appointment_Update", con);
                cmd.Parameters.Clear();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AppDate", txtAppdate.Text);
                cmd.Parameters.AddWithValue("@AppTime", txtAppTime.Text);
                cmd.Parameters.AddWithValue("@DocID", ddlDoctor.SelectedValue);
                cmd.Parameters.AddWithValue("@PatID", ddlPatient.SelectedValue);
                cmd.Parameters.AddWithValue("@AboutDisease", txtAboutDisease.Text);
                cmd.Parameters.AddWithValue("@AppStatus", "Pending");

                cmd.Parameters.AddWithValue("@CreatedBy", Session["EmailID"].ToString());
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(Session["sAppID"].ToString()));
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i == 1)
                {
                    Response.Write("<script>alert('Appointment Updated Successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error try again...')</script>");
                }                
                btnUpdate.Visible = false;
                btnAdd.Visible = true;                
                BindSizeRepeater();
                clrcontrol();
            }
            else
            {
                Response.Write("<script>alert('Data Validation issue')</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clrcontrol(); 
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
        }
    }
}