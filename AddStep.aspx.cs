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
    public partial class AddStep : System.Web.UI.Page
    {
        private string connStringJobs = ConfigurationManager.ConnectionStrings["jobs"].ToString();
        private static int job_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                job_id = int.Parse(Request["job_id"].ToString());
                InitControls();
            }
        }
        private void InitControls()
        {
            //step_types
            SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "list_step_types");
            DataSet DS = mySqlHelper.ExecuteDataset();

            dropListStepTypes.DataSource = DS.Tables[0].DefaultView;
            dropListStepTypes.DataTextField = DS.Tables[0].Columns[1].Caption;
            dropListStepTypes.DataValueField = DS.Tables[0].Columns[0].Caption;
            dropListStepTypes.DataBind();
        }
        protected void btnAddStep_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == "" || txtCommand.Text == "")
            {
                Response.Write("<script>alert('All fields need to be populated!')</script>");
                return;
            }

            SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "insert_step",
                                                  new SqlParameter("@job_id", job_id),
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