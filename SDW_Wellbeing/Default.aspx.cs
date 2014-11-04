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
            if (Password.Text == ConfirmPassword.Text)
            {
                if (UserFactory.CreateUser(UserName.Text, Email.Text, Password.Text))
                {
                    lblMessage.Text = "New user registered";
                }
            }


        }


    }
}
