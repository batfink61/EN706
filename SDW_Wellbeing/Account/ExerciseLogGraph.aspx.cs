using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDW_Wellbeing.Account
{
    //Generates both an Exercise diary and a graph for the exercises
    public partial class ExerciseManagement : System.Web.UI.Page
    {
        public String durationList = "";
        public String dateList = "";
        private String endTable = "</table>";
        private String beginTable = "<table class='datesWeightsTable'><th class='datesWeightsTh'>Dates</th><th class='datesWeightsTh'>Duration</th>";
        public String dateExerciseTable = "";
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
                message.Text = "Please enter a value for the 'from date'";
            }
            else if (toDate.Text == "")
            {
                message.Text = "Please enter value for the 'to date'weight";
            }
            else
            {
                //Get list of exercises
                List<Exercise> exerciseLists = ExerciseModel.Instance.getExercise(Request.Cookies["profile"]["name"], fromDate.Text, toDate.Text);
                if (exerciseLists != null)
                {
                    //Generate json data for graph
                    durationList = ExerciseModel.Instance.getDurationList();
                    dateList = ExerciseModel.Instance.getDatesList();

                    //Generate diary information
                    dateExerciseTable = beginTable + ExerciseModel.Instance.getList() + endTable;

                    //Generate html/css style for graph
                    graph = "<div id='Div3' style='min-width: 310px; height: 400px; margin: 0 auto'></div>";

                }
                else
                {
                    message.Text = "No Exercise Information";
                }
            }
        }
    }
}