using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace SDW_Wellbeing
{
    public partial class TestGraph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void calEventDate_SelectionChanged(object sender, EventArgs e)
        {
            //fromDate.Text = calEventDate.SelectedDate.ToString("yyyy-MM-dd");
        }
        protected void calEventDate2_SelectionChanged(object sender, EventArgs e)
        {
           // toDate.Text = calEventDate2.SelectedDate.ToString("yyyy-MM-dd");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
            Weight weight = WeightModel.Instance.getWeight(userID.Text, fromDate.Text, toDate.Text);
            if (weight != null)
            {
                message.Text = weight.getList();
            }
            else
            {
                message.Text = "No Weight Information";
            }
             * */
        }
    }
}
