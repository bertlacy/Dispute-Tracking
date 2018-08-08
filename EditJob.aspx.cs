using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using HelperLib;

namespace DisputeTracking
{
    public partial class EditJob : System.Web.UI.Page
    {
        private string connStringJobs = ConfigurationManager.ConnectionStrings["jobs"].ToString();
        private static int job_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                job_id = int.Parse(Request["job_id"].ToString());
                InitScripts();
                InitControls();
            }
        }
        private void InitScripts()
        {
            dropListScheduleTypes.Attributes.Add("onchange", "Set_ScheduleType('" + dropListScheduleTypes.ClientID + "','" + lblOccurs.ClientID + "','" + panelWeekDays.ClientID + "')");
        }
        private void InitControls()
        {
            //description
            SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "get_job_description",
                                                  new SqlParameter("@job_id", job_id));

            txtDescription.Text = mySqlHelper.ExecuteScalar().ToString();
            mySqlHelper.Close();

            //schedule_types
            mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "list_schedule_types");
            DataSet DS = mySqlHelper.ExecuteDataset();
            mySqlHelper.Close();

            dropListScheduleTypes.DataSource = DS.Tables[0].DefaultView;
            dropListScheduleTypes.DataTextField = DS.Tables[0].Columns[1].Caption;
            dropListScheduleTypes.DataValueField = DS.Tables[0].Columns[0].Caption;
            dropListScheduleTypes.DataBind();

            mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "get_job_schedule_type",
                                        new SqlParameter("@job_id", job_id));

            int schedule_type_id = int.Parse(mySqlHelper.ExecuteScalar().ToString());
            mySqlHelper.Close();

            dropListScheduleTypes.SelectedIndex = schedule_type_id - 1;

            //weekdays
            mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "get_scheduled_weekdays",
                                        new SqlParameter("@job_id", job_id));

            SqlDataReader rdr = mySqlHelper.ExecuteReader();
            while (rdr.Read())
            {
                chkWeekDays.Items[0].Selected = bool.Parse(rdr["Monday"].ToString());
                chkWeekDays.Items[1].Selected = bool.Parse(rdr["Tuesday"].ToString());
                chkWeekDays.Items[2].Selected = bool.Parse(rdr["Wednesday"].ToString());
                chkWeekDays.Items[3].Selected = bool.Parse(rdr["Thursday"].ToString());
                chkWeekDays.Items[4].Selected = bool.Parse(rdr["Friday"].ToString());
                chkWeekDays.Items[5].Selected = bool.Parse(rdr["Saturday"].ToString());
                chkWeekDays.Items[6].Selected = bool.Parse(rdr["Sunday"].ToString());
            }
            mySqlHelper.Close();

            //occurs_at
            mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "get_occurs_at",
                                        new SqlParameter("@job_id", job_id));

            DateTime occurs_at = DateTime.Parse(mySqlHelper.ExecuteScalar().ToString());
            mySqlHelper.Close();
            timeOccurs.Hour = occurs_at.Hour;
            timeOccurs.Minute = occurs_at.Minute;

            //bind step grid
            BindStepGrid();
        }
        private void BindStepGrid()
        {
            SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "list_steps",
                                                  new SqlParameter("@job_id", job_id));
            DataSet DS = mySqlHelper.ExecuteDataset();
            mySqlHelper.Close();

            gridSteps.DataSource = DS.Tables[0].DefaultView;
            gridSteps.DataBind();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == "")
            {
                Response.Write("<script>alert('Description must be populated!');</script>");
                return;
            }

            int monday = 0;
            int tuesday = 0;
            int wednesday = 0;
            int thursday = 0;
            int friday = 0;
            int saturday = 0;
            int sunday = 0;
            bool day_is_selected = false;

            DateTime occurs_at = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, timeOccurs.Hour, timeOccurs.Minute, 0);

            if (dropListScheduleTypes.SelectedValue == "2")  //Weekly
                for (int i = 0; i < chkWeekDays.Items.Count; i++)
                {
                    if (chkWeekDays.Items[i].Selected && chkWeekDays.Items[i].Value == "1")
                    {
                        monday = 1;
                        day_is_selected = true;
                    }
                    if (chkWeekDays.Items[i].Selected && chkWeekDays.Items[i].Value == "2")
                    {
                        tuesday = 1;
                        day_is_selected = true;
                    }
                    if (chkWeekDays.Items[i].Selected && chkWeekDays.Items[i].Value == "3")
                    {
                        wednesday = 1;
                        day_is_selected = true;
                    }
                    if (chkWeekDays.Items[i].Selected && chkWeekDays.Items[i].Value == "4")
                    {
                        thursday = 1;
                        day_is_selected = true;
                    }
                    if (chkWeekDays.Items[i].Selected && chkWeekDays.Items[i].Value == "5")
                    {
                        friday = 1;
                        day_is_selected = true;
                    }
                    if (chkWeekDays.Items[i].Selected && chkWeekDays.Items[i].Value == "6")
                    {
                        saturday = 1;
                        day_is_selected = true;
                    }
                    if (chkWeekDays.Items[i].Selected && chkWeekDays.Items[i].Value == "7")
                    {
                        sunday = 1;
                        day_is_selected = true;
                    }
                }
            if (dropListScheduleTypes.SelectedValue == "2")
                if (!day_is_selected)
                {
                    Response.Write("<script>alert('You must select at least one Day for the Script to run!');</script>");
                    return;
                }

            SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "update_job",
                                                  new SqlParameter("@job_id", job_id),
                                                  new SqlParameter("@schedule_type", dropListScheduleTypes.SelectedItem.Text),
                                                  new SqlParameter("@description", txtDescription.Text),
                                                  new SqlParameter("@monday", monday),
                                                  new SqlParameter("@tuesday", tuesday),
                                                  new SqlParameter("@wednesday", wednesday),
                                                  new SqlParameter("@thursday", thursday),
                                                  new SqlParameter("@friday", friday),
                                                  new SqlParameter("@saturday", saturday),
                                                  new SqlParameter("@sunday", sunday),
                                                  new SqlParameter("@occurs_at", occurs_at));
            mySqlHelper.ExecuteNonQuery();
            mySqlHelper.Close();
            Response.Redirect("Default.aspx");
        }
        protected void btnAddStep_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddStep.aspx?job_id=" + job_id.ToString());
        }
        protected void dropListScheduleTypes_Init(object sender, EventArgs e)
        {
            SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "get_job_schedule_type",
                                                  new SqlParameter("@job_id", Request["job_id"].ToString()));

            int schedule_type_id = int.Parse(mySqlHelper.ExecuteScalar().ToString());
            mySqlHelper.Close();

            switch (schedule_type_id)
            {
                case 1:
                    {
                        lblOccurs.Text = "Occurs every Day";
                        panelWeekDays.Attributes.Add("style", "display: none");
                    } break;
                case 2:
                    {
                        lblOccurs.Text = "Occurs Weekly on every ";
                        panelWeekDays.Attributes.Add("style", "display: ''");
                    } break;
            }
        }
        protected void btnEdit_Click1(object sender, EventArgs e)
        {
            Button edit = sender as Button;
            GridViewRow row = (GridViewRow)edit.NamingContainer;

            Response.Redirect("EditStep.aspx?job_id=" + job_id.ToString() + "&step_id=" +  row.Cells[0].Text);
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            Button edit = sender as Button;
            GridViewRow row = (GridViewRow)edit.NamingContainer;
            int step_id = int.Parse(row.Cells[0].Text);

            SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "delete_step",
                                                  new SqlParameter("@step_id", step_id));
            mySqlHelper.ExecuteNonQuery();
            mySqlHelper.Close();

            Response.Redirect("EditJob.aspx?job_id=" + job_id.ToString());
        }
    }
}