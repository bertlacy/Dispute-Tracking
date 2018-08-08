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
    public partial class CreateJob : System.Web.UI.Page
    {
        private string connStringJobs = ConfigurationManager.ConnectionStrings["jobs"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitScripts();
                InitControls();
            }
        }
        private void InitScripts()
        {
            dropListScheduleTypes.Attributes.Add("onchange", "Set_ScheduleType('" + dropListScheduleTypes.ClientID + "','" +
                                                                                    lblOccurs.ClientID + "','" +
                                                                                    panelWeekDays.ClientID + "')");
        }
        private void InitControls()
        {
            //schedule_types
            SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "list_schedule_types");
            DataSet DS = mySqlHelper.ExecuteDataset();
            mySqlHelper.Close();
            dropListScheduleTypes.DataSource = DS.Tables[0].DefaultView;
            dropListScheduleTypes.DataTextField = DS.Tables[0].Columns[1].Caption;
            dropListScheduleTypes.DataValueField = DS.Tables[0].Columns[0].Caption;
            dropListScheduleTypes.DataBind();
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == "")
            {
                Response.Write("<script>alert('Description must be filled!');</script>");
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
                    Response.Write("<script>alert('One day should be selected!');</script>");
                    return;
                }

            SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "insert_job",
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
    }
}