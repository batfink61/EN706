// Record user weight
// This form records a single instance of weight for the current user
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SDW_Wellbeing.Account
{
    public partial class record_weight : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Verify data before saving
            int weight;
            DateTime tmp;
            if (txtDate.Text == "")
                lblErrorMessage.Text = "Please enter a value for date";
            else if (txtWeight.Text == "")
                lblErrorMessage.Text = "Please enter value for weight";
            else if (!int.TryParse(txtWeight.Text, out weight))
            {
                lblErrorMessage.Text = "Weight should be numeric";
            }
            else if (int.Parse(txtWeight.Text)<1 || int.Parse(txtWeight.Text)>1000)
            {
                lblErrorMessage.Text = "Please weight between 1-1000";
            } 
            else if (!DateTime.TryParse(txtDate.Text, out tmp ))
            {
                lblErrorMessage.Text = "Please enter a valid date";
            }
            else 
            {
                // Save weight using EN706 web service
                // Default user details taken from cookie
                bool ok = WeightModel.Instance.SaveWeight(Request.Cookies["profile"]["name"], txtDate.Text, Int32.Parse(txtWeight.Text));
                if (ok)
                {
                    lblErrorMessage.Text = "Saved Successfully";
                    txtWeight.Text = "";
                    txtDate.Text = "";
                }
                else
                {
                    lblErrorMessage.Text = "Unable to Save";

                }
            }
        }
    }
}