using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using HelperLib;

namespace DisputeTracking
{
    public partial class _Default : System.Web.UI.Page
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DisputeTracking"].ToString();
        private string ConnectionStringAsync = ConfigurationManager.ConnectionStrings["DisputeTrackingAsync"].ToString();

        private static int dispute_ref_id = 0;
        public string activeFlag = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    BindPartnerIDDropDown();
                    BindPartnerNameDropDown();
                    BindOwnerDropDown();
                    BindStatusDropDown();
                    BindPartnerIDDropDownAcct();
                    BindPartnerNameDropDownAcct();
                    BindOwnerDropDownAcct();
                    BindStatusDropDownAcct();
                    TestLabel.Text = "";
                    ErrorMessage.Text = "";
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "";
                    ErrorMessage.Text = "Error - " + ex.Message.ToString();
                }
                
            }

            if (rbIn.Checked) { AccountUpdatePanel.Visible = false; } else { OrderUpdatePanel.Visible = false; }

            lblDaysOpen.Text = string.Format("{0:n0}", GetDaysOpen(GetLevel(), "open"));
            lblDaysClosed.Text = string.Format("{0:n0}", GetDaysOpen(GetLevel(), "closed"));
            lblMaxDaysOpen.Text = GetOldestCount(GetLevel());
        }

        #region Radio Buttons

        public void rbIn_CheckedChanged(object sender, EventArgs e)
        {
            AccountUpdatePanel.Visible = false;
            OrderUpdatePanel.Visible = true;
            ErrorMessage.Text = "";
            //BindPartnerIDDropDown();
            //BindPartnerNameDropDown();
            //BindOwnerDropDown();
            //BindStatusDropDown();
        }

        public void rbOut_CheckedChanged(object sender, EventArgs e)
        {
            AccountUpdatePanel.Visible = true;
            OrderUpdatePanel.Visible = false;
            ErrorMessage.Text = "";
            //BindPartnerIDDropDownAcct();
            //BindPartnerNameDropDownAcct();
            //BindOwnerDropDownAcct();
            //BindStatusDropDownAcct();
        }

        #endregion

        #region Drop Downs

        public void BindPartnerIDDropDown()
        {
            string region = "I";
            activeFlag = "Y";

            SqlHelper mySqlHelper = new SqlHelper(ConnectionString, CommandType.StoredProcedure, "dbo.dpDTPartnerID", new SqlParameter("@Region", region));
            DataSet PartnerDataSet = new DataSet();
            PartnerDataSet = mySqlHelper.ExecuteDataset();
            mySqlHelper.Close();

            PartnerDropDown.DataSource = PartnerDataSet;
            PartnerDropDown.DataTextField = PartnerDataSet.Tables[0].Columns["PartnerID"].ToString();
            PartnerDropDown.DataValueField = PartnerDataSet.Tables[0].Columns["PartnerID"].ToString();
            
            PartnerDropDown.DataBind();

            PartnerDropDown.Items.Insert(0, new ListItem("", ""));
        }

        public void BindPartnerIDDropDownAcct()
        {
            string region = "O";
            activeFlag = "Y";

            SqlHelper mySqlHelper2 = new SqlHelper(ConnectionString, CommandType.StoredProcedure, "dbo.dpDTPartnerID", new SqlParameter("@Region", region));
            DataSet PartnerDataSet = new DataSet();
            PartnerDataSet = mySqlHelper2.ExecuteDataset();
            mySqlHelper2.Close();

            DDPartnerIDAcct.DataSource = PartnerDataSet;
            DDPartnerIDAcct.DataTextField = PartnerDataSet.Tables[0].Columns["PartnerID"].ToString();
            DDPartnerIDAcct.DataValueField = PartnerDataSet.Tables[0].Columns["PartnerID"].ToString();

            DDPartnerIDAcct.DataBind();

            DDPartnerIDAcct.Items.Insert(0, new ListItem("", ""));
        }

        public void BindPartnerNameDropDown()
        {
            string region = "I";
            activeFlag = "Y";

            SqlHelper mySqlHelper3 = new SqlHelper(ConnectionString, CommandType.StoredProcedure, "dbo.dpDTPartnerName", new SqlParameter("@Region", region));
            DataSet PartnerDataSet = new DataSet();
            PartnerDataSet = mySqlHelper3.ExecuteDataset();
            mySqlHelper3.Close();

            PartnerNameDropDown.DataSource = PartnerDataSet;
            PartnerNameDropDown.DataTextField = PartnerDataSet.Tables[0].Columns["PartnerName"].ToString();
            PartnerNameDropDown.DataValueField = PartnerDataSet.Tables[0].Columns["PartnerName"].ToString();
                 
            PartnerNameDropDown.DataBind();
                   
            PartnerNameDropDown.Items.Insert(0, new ListItem("", ""));
        }

        public void BindPartnerNameDropDownAcct()
        {
            string region = "O";
            activeFlag = "Y";

            SqlHelper mySqlHelper4 = new SqlHelper(ConnectionString, CommandType.StoredProcedure, "dbo.dpDTPartnerName", new SqlParameter("@Region", region));
            DataSet PartnerDataSet = new DataSet();
            PartnerDataSet = mySqlHelper4.ExecuteDataset();
            mySqlHelper4.Close();

            DDPartnerNameAcct.DataSource = PartnerDataSet;
            DDPartnerNameAcct.DataTextField = PartnerDataSet.Tables[0].Columns["PartnerName"].ToString();
            DDPartnerNameAcct.DataValueField = PartnerDataSet.Tables[0].Columns["PartnerName"].ToString();

            DDPartnerNameAcct.DataBind();

            DDPartnerNameAcct.Items.Insert(0, new ListItem("", ""));
        }

        public void BindOwnerDropDown()
        {
            string region = "I";

            SqlHelper mySqlHelper5 = new SqlHelper(ConnectionString, CommandType.StoredProcedure, "dbo.dpDTOwner", new SqlParameter("@Region", region));
            DataSet PartnerDataSet = new DataSet();
            PartnerDataSet = mySqlHelper5.ExecuteDataset();
            mySqlHelper5.Close();

            OwnerDropDown.DataSource = PartnerDataSet;
            OwnerDropDown.DataTextField = PartnerDataSet.Tables[0].Columns["OwnerName"].ToString();
            OwnerDropDown.DataValueField = PartnerDataSet.Tables[0].Columns["CUID"].ToString();

            OwnerDropDown.DataBind();

            OwnerDropDown.Items.Insert(0, new ListItem("", ""));
        }

        public void BindOwnerDropDownAcct()
        {
            string region = "O";

            SqlHelper mySqlHelper6 = new SqlHelper(ConnectionString, CommandType.StoredProcedure, "dbo.dpDTOwner", new SqlParameter("@Region", region));
            DataSet PartnerDataSet = new DataSet();
            PartnerDataSet = mySqlHelper6.ExecuteDataset();
            mySqlHelper6.Close();

            DDOwnerIDAcct.DataSource = PartnerDataSet;
            DDOwnerIDAcct.DataTextField = PartnerDataSet.Tables[0].Columns["OwnerName"].ToString();
            DDOwnerIDAcct.DataValueField = PartnerDataSet.Tables[0].Columns["CUID"].ToString();

            DDOwnerIDAcct.DataBind();

            DDOwnerIDAcct.Items.Insert(0, new ListItem("", ""));
        }

        public void BindStatusDropDown()
        {
            StatusDropDown.Items.Clear();

            StatusDropDown.Items.Insert(0, new ListItem("Closed", "Closed"));
            StatusDropDown.Items.Insert(0, new ListItem("Open", "Open"));
            StatusDropDown.Items.Insert(0, new ListItem("", ""));
        }

        public void BindStatusDropDownAcct()
        {
            DDStatusAcct.Items.Clear();
            DDStatusAcct.Items.Insert(0, new ListItem("Closed", "Closed"));
            DDStatusAcct.Items.Insert(0, new ListItem("Open", "Open"));
            DDStatusAcct.Items.Insert(0, new ListItem("", ""));
            
        }

        #endregion

        #region Dashboard Numbers

        public string GetDaysOpen(string inputLevel, string inputStatus)
        {
            try
            { 
                SqlHelper mySqlHelper = new SqlHelper(ConnectionString, CommandType.StoredProcedure, "dbo.pDTGetOpenClosedCount", new SqlParameter("@Level", inputLevel),
                                                                                                                                  new SqlParameter("@Status", inputStatus));
                string returnString = mySqlHelper.ExecuteScalar().ToString();
                mySqlHelper.Close();

                return returnString;
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "";
                ErrorMessage.Text = "Error - " + ex.Message.ToString();
                return "N/A";
            }
        }

        public string GetOldestCount(string inputLevel)
        {
            try
            {
                SqlHelper mySqlHelper = new SqlHelper(ConnectionString, CommandType.StoredProcedure, "dbo.pDTGetOldestDisputeCount", new SqlParameter("@Level", inputLevel));
                string returnString = mySqlHelper.ExecuteScalar().ToString();
                mySqlHelper.Close();

                return returnString;
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "";
                ErrorMessage.Text = "Error - " + ex.Message.ToString();
                return "N/A";
            }
        }

        #endregion

        #region Helpers

        public string GetLevel()
        {
            if (rbIn.Checked)
            {
                return "I";
            }
            else
            {
                return "O";
            }
        }

        public void ShowSnackBar()
        {
            string s = "function ShowSnackbar()  { var x = document.getElementById('snackbar'); x.className = 'show'; setTimeout(function () { x.className = x.className.replace('show', ''); }, 3000); }";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", s);
            Response.Write(s);
        }

        public void GetFieldValues()
        {
            try
            {
                #region Get all text boxes and drop downs, if they are populated or not

                // Order Level (default)
                if (rbIn.Checked)
                {
                    string strOrder = tbOrder.Text.Length == 0 ? "" : tbOrder.Text.ToString();
                    string strBANBTN = tbBANBTN.Text.Length == 0 ? "" : tbBANBTN.Text.ToString();
                    string strCustomerID = tbCustomerName.Text.Length == 0 ? "" : tbCustomerName.Text.ToString();
                    string strDisputeID = tbDisputeID.Text.Length == 0 ? "" : tbDisputeID.Text.ToString();

                    string strPartnerDD = PartnerDropDown.SelectedItem.Text.Length == 0 ? "" : PartnerDropDown.SelectedValue.ToString();
                    string strPartnerNameDD = PartnerNameDropDown.SelectedItem.Text.Length == 0 ? "" : PartnerNameDropDown.SelectedValue.ToString();
                    string strOwnerDD = OwnerDropDown.SelectedItem.Text.Length == 0 ? "" : OwnerDropDown.SelectedItem.Text.ToString();
                    string strStatusDD = StatusDropDown.SelectedItem.Text.Length == 0 ? "" : StatusDropDown.SelectedItem.Text.ToString();

                    var listAll = new List<string>();

                    if (strOrder != "") listAll.Add("Order = " + strOrder.ToString());
                    if (strBANBTN != "") listAll.Add("BAN/BTN = " + strBANBTN.ToString());
                    if (strDisputeID != "") listAll.Add("Dispute ID = " + strDisputeID.ToString());
                    if (strCustomerID != "") listAll.Add("Customer ID = " + strCustomerID.ToString());

                    if (strPartnerDD != "") listAll.Add("Partner ID = " + strPartnerDD.ToString());
                    if (strPartnerNameDD != "") listAll.Add("Partner Name = " + strPartnerNameDD.ToString());
                    if (strOwnerDD != "") listAll.Add("Owner = " + strOwnerDD.ToString());
                    if (strStatusDD != "") listAll.Add("Status = " + strStatusDD.ToString());

                    TestLabel.Text = "";

                    while (listAll.Count > 0)
                    {
                        if (listAll.Count == 1)
                        {
                            TestLabel.Text = listAll.ToString();
                        }
                        else
                        {
                            foreach (string item in listAll)
                            {
                                if (item.Length > 0)
                                {
                                    TestLabel.Text += item.ToString() + ", ";
                                }
                            }

                            // Remove last comma from strings > 1
                            TestLabel.Text = TestLabel.Text.Substring(0, (TestLabel.Text.Length - 1));
                        }
                    }
                }
                else
                { 
                    // Account Level

                    string strAccountAcct = tbAccount.Text.Length == 0 ? "" : tbAccount.Text.ToString();
                    string strDisputeIDAcct = tbDisputeIDAcct.Text.Length == 0 ? "" : tbDisputeIDAcct.Text.ToString();
                    string strCustomerIDAcct = tbCustomerNameAcct.Text.Length == 0 ? "" : tbCustomerNameAcct.Text.ToString();
                    string strSubmitDateAcct = tbSubmitDateAcct.Text.Length == 0 ? "" : tbSubmitDateAcct.Text.ToString();
                    string strSaleDateAcct = tbSaleDateAcct.Text.Length == 0 ? "" : tbSaleDateAcct.Text.ToString();

                    string strPartnerIDDDAcct = DDPartnerIDAcct.SelectedItem.Text.Length == 0 ? "" : DDPartnerIDAcct.SelectedValue.ToString();
                    string strPartnerNameDDAcct = DDPartnerNameAcct.SelectedItem.Text.Length == 0 ? "" : DDPartnerNameAcct.SelectedValue.ToString();
                    string strOwnerIDDDAcct = DDOwnerIDAcct.SelectedItem.Text.Length == 0 ? "" : DDOwnerIDAcct.SelectedValue.ToString();
                    string strStatusDDAcct = DDStatusAcct.SelectedItem.Text.Length == 0 ? "" : DDStatusAcct.SelectedValue.ToString();

                    var listAllAcct = new List<string>();

                    if (strAccountAcct != "") listAllAcct.Add("Account = " + strAccountAcct.ToString());
                    if (strDisputeIDAcct != "") listAllAcct.Add("Dispute ID = " + strDisputeIDAcct.ToString());
                    if (strCustomerIDAcct != "") listAllAcct.Add("Customer Name = " + strCustomerIDAcct.ToString());
                    if (strSubmitDateAcct != "") listAllAcct.Add("Submit Date = " + strSubmitDateAcct.ToString());
                    if (strSaleDateAcct != "") listAllAcct.Add("Sale Date = " + strSaleDateAcct.ToString());

                    if (strPartnerIDDDAcct != "") listAllAcct.Add("Partner ID = " + strPartnerIDDDAcct.ToString());
                    if (strPartnerNameDDAcct != "") listAllAcct.Add("Partner Name = " + strPartnerNameDDAcct.ToString());
                    if (strOwnerIDDDAcct != "") listAllAcct.Add("Owner ID = " + strOwnerIDDDAcct.ToString());
                    if (strStatusDDAcct != "") listAllAcct.Add("Status = " + strStatusDDAcct.ToString());

                    TestLabel.Text = "";

                    if (listAllAcct.Count > 1)
                    {
                        foreach (string item in listAllAcct)
                        {
                            if (item.Length > 0)
                            {
                                TestLabel.Text += item.ToString() + ", ";
                            }
                        }
                        //string TestMessage = TestLabel.Text.ToString();
                        //TestMessage = TestMessage.Substring(0, (TestMessage.Length - 1));
                        //TestLabel.Text = TestMessage;
                    }
                    else
                    {
                        foreach (string item in listAllAcct)
                        {
                            if (item.Length > 0)
                            {
                                TestLabel.Text += item.ToString();
                            }
                        }
                    }
                }
                
                #endregion

                #region Only get text boxes with values

                //var listAll = new List<string>();

                //var TextBoxList = (Page.Master.FindControl("MainContent") as ContentPlaceHolder).Controls.OfType<TextBox>();
                ////var LabelList = (Page.Master.FindControl("MainContent") as ContentPlaceHolder).Controls.OfType<Label>();

                //foreach (Control childc in TextBoxList)
                //{
                //    if ((childc is TextBox) && (((TextBox)childc).Text.Length > 0))
                //    {
                //        listAll.Add(((TextBox)childc).Text.ToString());
                //        TestLabel.Text += ((TextBox)childc).Text.ToString() + ",";
                //    }
                //}

                #endregion
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "";
                ErrorMessage.Text = "Error - " + ex.Message.ToString();
                return;
            }
        }

        #endregion

        #region Clear Click

        public void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "";
                ErrorMessage.Text = "Error - " + ex.Message.ToString();
                return;
            }

        }

        public void ClearFields()
        {
            if (rbIn.Checked)
            {
                tbOrder.Text = "";
                tbBANBTN.Text = "";
                tbCustomerName.Text = "";
                tbDisputeID.Text = "";

                BindPartnerIDDropDown();
                BindPartnerNameDropDown();
                BindOwnerDropDown();
                BindStatusDropDown();
            }
            else
            {
                tbAccount.Text = "";
                tbCustomerNameAcct.Text = "";
                tbDisputeIDAcct.Text = "";
                tbSubmitDateAcct.Text = "";
                tbSaleDateAcct.Text = "";

                BindPartnerIDDropDownAcct();
                BindPartnerNameDropDownAcct();
                BindOwnerDropDownAcct();
                BindStatusDropDownAcct();
            }

            GridPanel.Visible = false;
            ErrorMessage.Text = "";
            return;
        }

        #endregion

        #region Reresh Click

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            ErrorMessage.Text = "";
            TestLabel.Text = "";
            //Response.Redirect("~/Default.aspx");
        }

        #endregion

        #region Search Click

        public void btnSearch_Click(object sender, EventArgs e)
        {
            ErrorMessage.Text = "";
            TestLabel.Text = "";

            if (rbIn.Checked)
            {
                string strOrder = tbOrder.Text.Length > 0 ? tbOrder.Text.ToString() : "";
                string strBANBTN = tbBANBTN.Text.Length > 0 ? tbBANBTN.Text.ToString() : "";
                string strCustomerName = tbCustomerName.Text.Length > 0 ? tbCustomerName.Text.ToString() : "";
                string strDisputeID = tbDisputeID.Text.Length > 0 ? tbDisputeID.Text.ToString() : "";

                string strPartnerID = PartnerDropDown.SelectedItem.Text.Length > 0 ? PartnerDropDown.SelectedItem.Text.ToString() : "";
                string strPartnerName = PartnerNameDropDown.SelectedItem.Text.Length > 0 ? PartnerNameDropDown.SelectedItem.Text.ToString() : "";
                string strOwner = OwnerDropDown.SelectedItem.Text.Length > 0 ? OwnerDropDown.SelectedItem.Text.ToString() : "";
                string strStatus = StatusDropDown.SelectedItem.Text.Length > 0 ? StatusDropDown.SelectedItem.Text.ToString() : "";

                if ((strOrder == "") && (strBANBTN == "") && (strCustomerName == "") && (strDisputeID == "") && (strPartnerID == "") && (strPartnerName == "") && (strOwner == "") && (strStatus == ""))
                {
                    ErrorMessage.Text = "Our code for reading minds is still in development, please enter at least one value to Search on...";
                    return;
                }

                try
                {
                    // UPDATE THIS TO PASS ALL FIELDS VALUES AS ARGUMENTS
                    BindDisputeGrid();
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "";
                    ErrorMessage.Text = "Error - " + ex.Message.ToString();
                    return;
                }
            }
            else
            {
                string strAccount = tbAccount.Text.Length > 0 ? tbAccount.Text.ToString() : "";
                string strCustomerNameAcct = tbCustomerNameAcct.Text.Length > 0 ? tbCustomerNameAcct.Text.ToString() : "";
                string strDisputeIDAcct = tbDisputeIDAcct.Text.Length > 0 ? tbDisputeIDAcct.Text.ToString() : "";

                string strSubmitDateAcct = tbSubmitDateAcct.Text.Length > 0 ? tbSubmitDateAcct.Text.ToString() : "";
                string strSaleDateAcct = tbSaleDateAcct.Text.Length > 0 ? tbSaleDateAcct.Text.ToString() : "";

                string strPartnerIDAcct = PartnerDropDown.SelectedItem.Text.Length > 0 ? DDPartnerIDAcct.SelectedItem.Text.ToString() : "";
                string strPartnerNameAcct = DDPartnerNameAcct.SelectedItem.Text.Length > 0 ? DDPartnerNameAcct.SelectedItem.Text.ToString() : "";
                string strOwnerAcct = DDOwnerIDAcct.SelectedItem.Text.Length > 0 ? DDOwnerIDAcct.SelectedItem.Text.ToString() : "";
                string strStatusAcct = DDStatusAcct.SelectedItem.Text.Length > 0 ? DDStatusAcct.SelectedItem.Text.ToString() : "";

                if ((strAccount == "") && (strCustomerNameAcct == "") && (strDisputeIDAcct == "") && (strSubmitDateAcct == "") && (strSaleDateAcct == "") && (strPartnerIDAcct == "") && (strPartnerNameAcct == "") && (strOwnerAcct == "") && (strStatusAcct == ""))
                {
                    ErrorMessage.Text = "Our code for reading minds is still in development, please enter at least one value to Search on...";
                    return;
                }

                try
                {
                    // UPDATE THIS TO PASS ALL FIELDS VALUES AS ARGUMENTS
                    BindDisputeGrid();
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "";
                    ErrorMessage.Text = "Error - " + ex.Message.ToString();
                    return;
                }
            }
        }

        #endregion

        #region Bind Disputes Grid (Search Results)

        private void BindDisputeGrid()
        {
            if (rbIn.Checked)
            {
                // UPDATE THIS TO READ ARGUMENTS IN AND JUST PASS IT TO THE STORED PROC SINCE THE PREVIOUS METHOD IS ALREADY EVAULATING WHETHER THESE FIELDS HAVE VALUES OR NOT...
                string strOrder = tbOrder.Text.Length > 0 ? tbOrder.Text.ToString() : "";
                string strBANBTN = tbBANBTN.Text.Length > 0 ? tbBANBTN.Text.ToString() : "";
                string strCustomerName = tbCustomerName.Text.Length > 0 ? tbCustomerName.Text.ToString() : "";
                string strDisputeID = tbDisputeID.Text.Length > 0 ? tbDisputeID.Text.ToString() : "";

                string strPartnerID = PartnerDropDown.SelectedItem.Text.Length > 0 ? PartnerDropDown.SelectedItem.Text.ToString() : "";
                string strPartnerName = PartnerNameDropDown.SelectedItem.Text.Length > 0 ? PartnerNameDropDown.SelectedItem.Text.ToString() : "";
                string strOwner = OwnerDropDown.SelectedItem.Text.Length > 0 ? OwnerDropDown.SelectedItem.Text.ToString() : "";
                string strStatus = StatusDropDown.SelectedItem.Text.Length > 0 ? StatusDropDown.SelectedItem.Text.ToString() : "";

                try
                {
                    SqlHelper mySqlHelperBindDisputes = new SqlHelper(ConnectionString, CommandType.StoredProcedure, "dbo.pDTGetDisputeSummary", new SqlParameter("@Region", "I"),
                                                                                                                                                 new SqlParameter("@Order", strOrder),
                                                                                                                                                 new SqlParameter("@BANBTN", strBANBTN),
                                                                                                                                                 new SqlParameter("@CustomerName", strCustomerName),
                                                                                                                                                 new SqlParameter("@DisputeID", strDisputeID),
                                                                                                                                                 new SqlParameter("@SubmittedDt", ""),
                                                                                                                                                 new SqlParameter("@PartnerID", strPartnerID),
                                                                                                                                                 new SqlParameter("@PartnerName", strPartnerName),
                                                                                                                                                 new SqlParameter("@Owner", strOwner),
                                                                                                                                                 new SqlParameter("@Status", strStatus));

                    DataSet DisputesDataSet = mySqlHelperBindDisputes.ExecuteDataset();
                    mySqlHelperBindDisputes.Close();

                    DisputesGrid.DataSource = DisputesDataSet.Tables[0].DefaultView;
                    DisputesGrid.DataBind();

                    if (DisputesGrid.Rows.Count != 0)
                    {
                        int recordCount = DisputesGrid.Rows.Count;
                        GridPanel.Visible = true;
                        lblSearchCount.Text = string.Format("{0:n0}", recordCount.ToString());
                    }
                    else
                    {
                        ErrorMessage.Text = "";
                        ErrorMessage.Text = "No records returned from Search criteria.";
                        GridPanel.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "";
                    ErrorMessage.Text = "Error - " + ex.Message.ToString();
                    return;
                }
            }
            else
            {
                string strAccount = tbAccount.Text.Length > 0 ? tbAccount.Text.ToString() : "";
                string strCustomerNameAcct = tbCustomerNameAcct.Text.Length > 0 ? tbCustomerNameAcct.Text.ToString() : "";
                string strDisputeIDAcct = tbDisputeIDAcct.Text.Length > 0 ? tbDisputeIDAcct.Text.ToString() : "";

                string strSubmitDateAcct = tbSubmitDateAcct.Text.Length > 0 ? tbSubmitDateAcct.Text.ToString() : "";
                string strSaleDateAcct = tbSaleDateAcct.Text.Length > 0 ? tbSaleDateAcct.Text.ToString() : "";

                string strPartnerIDAcct = DDPartnerIDAcct.SelectedItem.Text.Length > 0 ? DDPartnerIDAcct.SelectedItem.Text.ToString() : "";
                string strPartnerNameAcct = DDPartnerNameAcct.SelectedItem.Text.Length > 0 ? DDPartnerNameAcct.SelectedItem.Text.ToString() : "";
                string strOwnerAcct = DDOwnerIDAcct.SelectedItem.Text.Length > 0 ? DDOwnerIDAcct.SelectedItem.Text.ToString() : "";
                string strStatusAcct = DDStatusAcct.SelectedItem.Text.Length > 0 ? DDStatusAcct.SelectedItem.Text.ToString() : "";

                try
                {
                    SqlHelper mySqlHelperBindDisputesAcct = new SqlHelper(ConnectionString, CommandType.StoredProcedure, "dbo.pDTGetDisputeSummary", new SqlParameter("@Region", "O"),
                                                                                                                                                     new SqlParameter("@Order", strAccount),
                                                                                                                                                     new SqlParameter("@CustomerName", strCustomerNameAcct),
                                                                                                                                                     new SqlParameter("@DisputeID", strDisputeIDAcct),
                                                                                                                                                     new SqlParameter("@SubmittedDt", strSubmitDateAcct),
                                                                                                                                                     new SqlParameter("@SaleDate", strSaleDateAcct),
                                                                                                                                                     new SqlParameter("@PartnerID", strPartnerIDAcct),
                                                                                                                                                     new SqlParameter("@PartnerName", strPartnerNameAcct),
                                                                                                                                                     new SqlParameter("@Owner", strOwnerAcct),
                                                                                                                                                     new SqlParameter("@Status", strStatusAcct));

                    DataSet DS = mySqlHelperBindDisputesAcct.ExecuteDataset();
                    mySqlHelperBindDisputesAcct.Close();
                    DisputesGrid.DataSource = DS.Tables[0].DefaultView;
                    DisputesGrid.DataBind();

                    if (DisputesGrid.Rows.Count != 0)
                    {
                        int recordCount = DisputesGrid.Rows.Count;
                        GridPanel.Visible = true;
                        lblSearchCount.Text = string.Format("{0:n0}", recordCount.ToString());
                    }
                    else
                    {
                        ErrorMessage.Text = "";
                        ErrorMessage.Text = "No records returned from Search criteria.";
                        GridPanel.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = "";
                    ErrorMessage.Text = "Error - " + ex.Message.ToString();
                    return;
                }
            }
        }

        #endregion

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //Button edit = sender as Button;
            //GridViewRow row = (GridViewRow)edit.NamingContainer;

            //Response.Redirect("EditJob.aspx?job_id=" + row.Cells[0].Text);
        }
        protected void btnEnableDisable_Click(object sender, EventArgs e)
        {
            //Button edit = sender as Button;
            //GridViewRow row = (GridViewRow)edit.NamingContainer;
            //job_id = int.Parse(row.Cells[0].Text);

            //SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "get_job_enabled_status", new SqlParameter("@job_id", job_id));
            //bool enabled = bool.Parse(mySqlHelper.ExecuteScalar().ToString());
            //mySqlHelper.Close();

            //if (enabled)
            //{
            //    mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "disable_job", new SqlParameter("@job_id", job_id));
            //    mySqlHelper.ExecuteNonQuery();
            //    mySqlHelper.Close();
            //}
            //else
            //{
            //    mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "enable_job", new SqlParameter("@job_id", job_id));
            //    mySqlHelper.ExecuteNonQuery();
            //    mySqlHelper.Close();
            //}
            //BindJobGrid();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Button edit = sender as Button;
            //GridViewRow row = (GridViewRow)edit.NamingContainer;
            //job_id = int.Parse(row.Cells[0].Text);

            //SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "delete_job", new SqlParameter("@job_id", job_id));
            //mySqlHelper.ExecuteNonQuery();
            //mySqlHelper.Close();
            //BindJobGrid();
        }
        protected void btnRun_Click(object sender, EventArgs e)
        {
            //Button edit = sender as Button;
            //GridViewRow row = (GridViewRow)edit.NamingContainer;
            //job_id = int.Parse(row.Cells[0].Text);

            //SqlHelper mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "get_job_running_status", new SqlParameter("@job_id", job_id));
            //bool is_running = bool.Parse(mySqlHelper.ExecuteScalar().ToString());
            //mySqlHelper.Close();

            ////if (is_running)
            ////{
            ////    Response.Write("<script>alert('Script is still running...')</script>");
            ////    return;
            ////}

            //if (is_running)
            //{
            //    ErrorMessage.Text = "";
            //    ErrorMessage.Text = "Warning: Script ID " + job_id + " is still running...";
            //}

            //try
            //{
            //    mySqlHelper = new SqlHelper(connStringJobs, CommandType.StoredProcedure, "execute_job", new SqlParameter("@job_id", job_id));
            //    mySqlHelper.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    ErrorMessage.Text = "";
            //    ErrorMessage.Text = "Error - " + ex.Message.ToString();
            //    return;
            //}

            //BindJobGrid();

            ////string s = "function ShowSnackbar()  { var x = document.getElementById('snackbar'); x.className = 'show'; setTimeout(function () { x.className = x.className.replace('show', ''); }, 3000); }";
            ////Page.ClientScript.RegisterStartupScript(this.GetType(), "", s);
            ////Response.Write(s);

            //ScriptManager.RegisterStartupScript(Page, GetType(), "test", "ShowSnackbar();", true);
        }
    }
}
