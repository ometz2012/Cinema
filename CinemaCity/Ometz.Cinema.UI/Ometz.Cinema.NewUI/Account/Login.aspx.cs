using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.Users;

namespace Ometz.Cinema.UI.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            String SelectedUserName = LoginUser.UserName;
            Guid UserID = new Guid();
            IUser UserServices = new UserServices();
            UserID = UserServices.GetUserID(SelectedUserName);
            Session.Add("UserID", UserID);
        }

    }
}
