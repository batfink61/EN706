using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;

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

            int formError = 0;
            //Regex to check validity of email address
            Regex re = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$",
                  RegexOptions.IgnoreCase);
            //reset error messages 
            EmailError.Text = "";
            //Set email to lowercase to avoid case errors
            UserID.Text.ToLower();

            //Email validation
            if (UserID.Text == "")
            {
                EmailError.Text = "Please enter a email address";
                formError = 1;
            }
            else if (!re.IsMatch(UserID.Text))
            {
                EmailError.Text = "Please enter a valid email address";
                formError = 1;
            }
            //Check to see if email is in database
            else if ( ! UserFactory.checkForUser(UserID.Text))
            {
                EmailError.Text = "Not recognised please check";
                formError = 1;
            }

            //Password Validation
            if (Password.Text == "")
            {
                PasswordError.Text = "Please enter a password";
                formError = 1;
            }
       
            //No errors
            if(formError == 0)
            {
                //Verify uder and set cookie
                if (UserFactory.VerifyUser(UserID.Text, Password.Text))
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
                else
                {
                    lblMessage.Text = "Credentials not recognised";
                }
            }
            else if(formError == 1)
            {
                lblMessage.Text = "Please check the form";
            }


        }

        protected void UserID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
