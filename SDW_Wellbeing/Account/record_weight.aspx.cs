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
            bool ok = WeightModel.Instance.SaveWeight(Request.Cookies["profile"]["name"],txtDate.Text,Int32.Parse(txtWeight.Text));
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