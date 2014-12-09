using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SDW_Wellbeing
{
    //Generates both a Weight diary and a graph for the weights
    public partial class WebForm1 : System.Web.UI.Page
    {
        public String weightList="";
        public String dateList="";
        private String endTable = "</table>";
        private String beginTable = "<table class='datesWeightsTable'><th class='datesWeightsTh'>Dates</th><th class='datesWeightsTh'>Weights</th>";
        public String dateWeightTable = "";
        public String graph = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
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
            //Validation Code
            if (fromDate.Text == "")
            {
                message1.Text = "Please enter a value for the 'from date'";
            }
            else if (toDate.Text == "")
            {
                message1.Text = "Please enter value for the 'to date'weight";
            }
            else
            {
                //Get list of weights
                List<Weight> weightLists = WeightModel.Instance.getWeight(Request.Cookies["profile"]["name"], fromDate.Text, toDate.Text);
                if (weightLists != null)
                {
                    //Generate json data for graph
                    weightList = WeightModel.Instance.getValueList();
                    dateList = WeightModel.Instance.getDatesList();

                    //Generate diary information
                    dateWeightTable = beginTable + WeightModel.Instance.getList() + endTable;

                    //Generate html/css style for graph
                    graph = "<div id='Div2' style='min-width: 310px; height: 400px; margin: 0 auto'></div>";

                }
                else
                {
                    message.Text = "No Weight Information";
                }
            }
        }
    }
}