using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SDW_Wellbeing
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public String weightList="";
        public String dateList="";

        protected void Page_Load(object sender, EventArgs e)
        {
            userID.Text = Request.Cookies["profile"]["name"];
        }
        protected void calEventDate_SelectionChanged(object sender, EventArgs e)
        {
            fromDate.Text = calEventDate.SelectedDate.ToString("yyyy-MM-dd");
        }
        protected void calEventDate2_SelectionChanged(object sender, EventArgs e)
        {
            toDate.Text = calEventDate2.SelectedDate.ToString("yyyy-MM-dd");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Weight weight = WeightModel.Instance.getWeight(userID.Text, fromDate.Text, toDate.Text);
            weightList = weight.geValueList();
            dateList = weight.getDatesList();

        }
    }
}