// Home page.
// Displays the main calendar with options to record weights/exercise
// External health and wellbeing links are displayed too
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace SDW_Wellbeing
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Register new new
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            
            int formError = 0;
            //Regex to check validity of email address
            Regex re = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$",
                  RegexOptions.IgnoreCase);
            //reset error messages
            lblMessage.Text = "";
            UserNameError.Text = "";
            EmailError.Text = "";
            //Set email to lowercase to avoid case errors
            Email.Text.ToLower();
     
            //User name validation
            if (UserName.Text == "")
            {
                UserNameError.Text = "Please enter a username";
                formError = 1;
            }

            //Email validation
            if (Email.Text == "")
            {
                EmailError.Text = "Please enter a email address";
                formError = 1;
            }
            else if( ! re.IsMatch(Email.Text))
            {
                EmailError.Text = "Please enter a valid email address";
                formError = 1;
            }
            //Checks to see if email is already in the database
            else if (UserFactory.checkForUser(Email.Text))
            {
                EmailError.Text = "This email address already has an account";
                formError = 1;
            }
            
            //Password Validation
            if (Password.Text == "")
            {
                PasswordError.Text = "Please enter a password";
                formError = 1;
            }
            else if (Password.Text.Length <= 6)
            {
                PasswordError.Text = "Password must be at least 7 characters long";
                formError = 1;
            }
            
            if (ConfirmPassword.Text == "")
            {
                ConfirmPasswordError.Text = "Please confirm password";
                formError = 1;
            }
            else if(Password.Text != ConfirmPassword.Text)
            {
                PasswordError.Text = "Passwords do not match";
                ConfirmPasswordError.Text = "Passwords do not match";
                formError = 1;
            }
            else if (Password.Text.Length <= 6)
            {
                ConfirmPasswordError.Text = "Password must be at least 7 characters long";
                formError = 1;
            }
            
            //If no forms errors create new user account
            if (formError == 0)
            {
                if (UserFactory.CreateUser(UserName.Text, Email.Text, Password.Text))
                {
                    lblMessage.Text = "New user registered";
                }
            }
            else
            {
                lblMessage.Text = "Please check the form";
            }

        }


    }
}
