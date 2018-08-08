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
    public partial class EditStep : System.Web.UI.Page
    {
        private string connStringJobs = ConfigurationManager.ConnectionStrings["jobs"].ToString();
        private static int job_id = 0;
        private static int step_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                job_id = int.Parse(Request["job_id"].ToString());
                step_id = int.Parse(Request["step_id"].ToString());
                InitControls();
            }
        }
        private void InitControls()
        {
            //description
            SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "get_step_description", new SqlParameter("@step_id", step_id));
            txtDescription.Text = mySqlHelper.ExecuteScalar().ToString();
            mySqlHelper.Close();

            //step_types
            mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "list_step_types");
            DataSet DS = mySqlHelper.ExecuteDataset();
            mySqlHelper.Close();

            dropListStepTypes.DataSource = DS.Tables[0].DefaultView;
            dropListStepTypes.DataTextField = DS.Tables[0].Columns[1].Caption;
            dropListStepTypes.DataValueField = DS.Tables[0].Columns[0].Caption;
            dropListStepTypes.DataBind();

            mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "get_step_type", new SqlParameter("@step_id", step_id));

            int step_type_id = int.Parse(mySqlHelper.ExecuteScalar().ToString());
            mySqlHelper.Close();
            dropListStepTypes.SelectedIndex = step_type_id - 1;

            //command
            mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "get_step_command", new SqlParameter("@step_id", step_id));
            txtCommand.Text = mySqlHelper.ExecuteScalar().ToString();
            mySqlHelper.Close();
        }
        protected void btnEditStep_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == "" || txtCommand.Text == "")
            {
                Response.Write("<script>alert('Please fill in every field before saving...')</script>");
                return;
            }

            SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "update_step",
                                                  new SqlParameter("@step_id", step_id),
                                                  new SqlParameter("@step_type", dropListStepTypes.SelectedItem.Text),
                                                  new SqlParameter("@description", txtDescription.Text),
                                                  new SqlParameter("@command", txtCommand.Text));
            mySqlHelper.ExecuteNonQuery();
            mySqlHelper.Close();

            Response.Redirect("EditJob.aspx?job_id=" + job_id.ToString());
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditJob.aspx?job_id=" + job_id.ToString());
        }
    }
}