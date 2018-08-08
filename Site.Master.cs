using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zyx.Security;

namespace DisputeTracking
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Environment.UserName.ToUpper();
            lblDomain.Text = Environment.UserDomainName.ToUpper();
            lblCurrentYear.Text = DateTime.Now.Year.ToString();
        }
    }
}
