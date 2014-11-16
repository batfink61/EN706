using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDW_Wellbeing
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }



        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (Password.Text == "")
            {
                lblMessage.Text = "Please enter a Password";
            }
            else if(Password.Text != ConfirmPassword.Text)
            {
                lblMessage.Text = "Please enter a Password";
            }
            else if (Email.Text == "")
            {
                lblMessage.Text = "Please enter a email address";
            }
            else if (ConfirmPassword.Text == "")
            {
                lblMessage.Text = "Please cofirm your password";
            }
            else if (Password.Text.Length <= 6)
            {
                lblMessage.Text = "Password must be at least 7 characters long";
            }
            else
            {
                if (UserFactory.CreateUser(UserName.Text, Email.Text, Password.Text))
                {
                    lblMessage.Text = "New user registered";
                }
            }

        }


    }
}
