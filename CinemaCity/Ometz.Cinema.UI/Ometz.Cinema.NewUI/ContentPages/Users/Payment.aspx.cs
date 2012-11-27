using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ometz.Cinema.UI.ContentPages.Users
{
    public partial class Payment : System.Web.UI.Page
    {
        String PerformanceID = null;
        String UserID = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PerformanceID = Request.QueryString["PerformanceID"].ToString();
            //this.UserID = Session["UserID"].ToString();
            this.UserID = "e441de1f-9877-4074-bcd7-7b46bf3a7143";

            PaymentControlInput.PerformanceID = this.PerformanceID;
            PaymentControlInput.UserID = this.UserID;
        }
    }
}