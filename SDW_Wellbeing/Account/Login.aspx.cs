using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SDW_Wellbeing.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (UserID.Text == "")
            {
                validate.Attributes["class"] += " has-error";
                EmailLabel.Text = "Exercise Name: Please enter a name";
                
            }
            else if (Password.Text == "")
            {
            }

            else if (UserFactory.VerifyUser(UserID.Text, Password.Text))
            {
                //FormsAuthentication.SetAuthCookie(UserID.Text, true);

                HttpCookie cookie = Request.Cookies["profile"];
                if (cookie == null)
                {
                    cookie = new HttpCookie("profile");
                }
                cookie["name"] = UserID.Text;
                Response.Cookies.Add(cookie);

                FormsAuthentication.RedirectFromLoginPage(UserID.Text, false);
            }
        }

        protected void UserID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
