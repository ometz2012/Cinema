using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.Users;

namespace Ometz.Cinema.UI.ContentPages.Users
{
    public partial class Payment : System.Web.UI.Page
    {
        String PerformanceID = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PerformanceID = Request.QueryString["PerformanceID"].ToString();
            PaymentControlInput.PerformanceID = this.PerformanceID;
        }
    }
}