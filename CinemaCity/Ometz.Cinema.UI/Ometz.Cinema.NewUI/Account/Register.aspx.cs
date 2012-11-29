using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ometz.Cinema.BLL.Users;

namespace Ometz.Cinema.UI.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {

            IUser UserServices = new UserServices();
            UserModelDTO NewUser = new UserModelDTO();
            if (PersonalInfoContainer.FindControl("FirstName") is TextBox)
            {
                NewUser.FirstName = ((TextBox)PersonalInfoContainer.FindControl("FirstName")).Text;
            }
            if (PersonalInfoContainer.FindControl("LastName") is TextBox)
            {
                NewUser.LastName = ((TextBox)PersonalInfoContainer.FindControl("LastName")).Text;
            }
            NewUser.UserName = RegisterUser.UserName;
            NewUser.UserID = UserServices.GetUserID(NewUser.UserName);
            NewUser.personTypeID = UserServices.GetUserType("User");
            NewUser.Password = RegisterUser.Password;
            bool check = UserServices.CreateNewUser(NewUser);

            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

    }
}
