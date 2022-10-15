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
    public partial class appointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    SearchDoctID();
                    //BindSizeRepeater_PageLoad();
                    BindGrid_PageLoad();

                    //btnUpdate.Visible = false;
                    //Divappstatus.Visible = false;
                }
                else
                {
                    Response.Write("<script>alert('session timeout..login again')</script>");
                    Response.Write("logout.aspx");
                }


            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                //SearchDataForUp(Convert.ToInt32(id));
                //Divappstatus.Visible = true;
                Session["remarksID"] = id;
            }
            if (e.CommandName == "delete")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];
                SearchRemarks(Convert.ToInt32(id));

                //btnUpdate.Visible = false;
                //btnAdd.Visible = true;
                //BindSizeRepeater_PageLoad();
            }
            if (e.CommandName == "approved")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '&' });
                string id = commandArgs[0];

                SqlCommand cmd = new SqlCommand("sp_Appointment_ApprovedByDoctor");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", id);

                if (InsertUpdateData2(cmd))
                {
                    Response.Write("<script>alert('Record Approved Successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Error try again...')</script>");
                }
                BindSizeRepeater_PageLoad();
            }
        }
        private void SearchRemarks(int idd)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("select t1.DocRemarks,t1.AppStatus  from Appointment as t1 where t1.ID=@ID", con))
                {
                    cmd.CommandType = CommandType.Text;
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
                            //txtRemarks.Text = ds.Tables[0].Rows[0]["DocRemarks"].ToString();
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

                            //btnAdd.Visible = false;
                            //btnUpdate.Visible = true;

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
        private void SearchDoctID()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("select t1.DocID,t2.EmailID  from Appointment as t1 inner join Doctor as t2 on t1.DocID=t2.DocID where t2.EmailID=@EmailID and t2.DocStatus='YES' ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@EmailID", Session["EmailID"].ToString());
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        da.Fill(ds, "dt");
                        con.Close();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Session["sADocID"] = ds.Tables[0].Rows[0]["DocID"].ToString();

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
                SqlCommand cmd = new SqlCommand("sp_AppointmentSearch_ByDoctor_ID");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DocID", Convert.ToInt32(Session["sADocID"]));
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

        private void BindGrid_PageLoad()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_AppointmentSearch_ByDoctor_ID");
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DocID", Convert.ToInt32(Session["sADocID"]));
                DataTable dt = GetDataByProc(cmd);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid_PageLoad();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid_PageLoad();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid_PageLoad();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label idq = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblID"));
            int id2 = Convert.ToInt32(idq.Text);

            TextBox txtEditDocRemarksUpdate = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEditApDocRemarks");
            DropDownList ddlGV1StatusUpdate = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlGV1ApStatus");

            SqlCommand cmd = new SqlCommand("sp_updateAppRemarksStatus_ByDoctor");
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", id2);
            cmd.Parameters.AddWithValue("@DocRemarks", txtEditDocRemarksUpdate.Text);
            cmd.Parameters.AddWithValue("@AppStatus", ddlGV1StatusUpdate.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@AppStatusID", ddlGV1StatusUpdate.SelectedValue);
            if (InsertUpdateData2(cmd))
            {
                //Response.Write("<script>alert('Record Approved Successfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error try again...')</script>");
            }
            GridView1.EditIndex = -1;
            BindGrid_PageLoad();


        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlEditBindGender = (DropDownList)e.Row.FindControl("ddlGV1ApStatus");

                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                SqlCommand cmd1 = new SqlCommand("select ID,StatusDesc from tblstatus", con1);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                con1.Close();
                if (dt1.Rows.Count > 0)
                {
                    ddlEditBindGender.DataSource = dt1;
                    ddlEditBindGender.DataValueField = "ID";
                    ddlEditBindGender.DataTextField = "StatusDesc";
                    ddlEditBindGender.DataBind();
                    ListItem ddlw3 = new ListItem("Select Option", "-1");
                    ddlEditBindGender.Items.Insert(0, ddlw3);

                    Label lblGenderID = (Label)e.Row.FindControl("lblEditGV1ApStatus");
                    ddlEditBindGender.SelectedValue = lblGenderID.Text;
                }
                else
                {
                    ddlEditBindGender.DataSource = null;
                    ddlEditBindGender.DataBind();

                    ddlEditBindGender.SelectedIndex = -1;
                }
            }
        }


        protected void lnkstatus_Click(object sender, EventArgs e)
        {
            //update appointment status

            //Response.Write("<script>alert('update appointment status')</script>");
            //LinkButton lbtn = (LinkButton)sender;
            //GridViewRow row = (GridViewRow)lbtn.NamingContainer;
            //int QID = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
            //   // SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);           
            //   .
            //    SqlCommand cmd = new SqlCommand("update Appointment set AppStatus=@AppStatus, AppStatusID=@AppStatusID where ID=@ID");
            //cmd.Parameters.AddWithValue("@AppStatus", "Approved");
            //cmd.Parameters.AddWithValue("@AppStatusID", 2);
            //cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(QID));
            //InsertUpdateData(cmd);
            //GridView1.DataBind();
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            //Add remarks
            //Response.Write("<script>alert('Add new remarks')</script>");
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            //View Remaks
            //Response.Write("<script>alert('View remarks')</script>");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "approved")
            {
                //-------------
                LinkButton lnkView = (LinkButton)e.CommandSource;
                string dealId = lnkView.CommandArgument;
                //Response.Write("<script>alert('"+dealId+"')</script>");
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorAppointmentDBConnectionString"].ConnectionString);
                string sql = "select AppStatusID,AppStatus from Appointment where ID=@ID";
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(dealId));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Session["rownumID"] = dr["AppStatus"].ToString();
                    Session["iidd"] = dr["AppStatusID"].ToString();
                }

                dr.Close();
                if(Session["rownumID"].ToString() == "Pending" && Session["iidd"] .ToString()== "1")
                {
                    cmd = new SqlCommand("update Appointment set AppStatus=@AppStatus, AppStatusID=@AppStatusID where ID=@ID");
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@AppStatus", "Approved");
                    cmd.Parameters.AddWithValue("@AppStatusID", 2);
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(dealId));
                    InsertUpdateData(cmd);
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Appointment already approved')</script>");
                }                

            }
        }



        //protected void BindGridView1()
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_allatozappointment");//sp_AppointmentSearch_ByStatus
        //        cmd.Parameters.Clear();               

        //        cmd.Parameters.AddWithValue("@DocEmail", Session["EmailID"].ToString());

        //        DataTable dt = GetDataByProc(cmd);
        //        if (dt.Rows.Count >0)
        //        {
        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();
        //        }
        //        else
        //        {
        //            GridView1.DataSource = null;
        //            GridView1.DataBind();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('" + ex.Message + "')</script>");
        //    }
        //}
    }
}