using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDW_Wellbeing.Account
{
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
            //userID.Text = Request.Cookies["profile"]["name"];
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
            List<Exercise> exerciseLists = ExerciseModel.Instance.getExercise(Request.Cookies["profile"]["name"], fromDate.Text, toDate.Text);
            if (exerciseLists != null)
            {
                durationList = ExerciseModel.Instance.getDurationList();
                dateList = ExerciseModel.Instance.getDatesList();
                dateExerciseTable = beginTable + ExerciseModel.Instance.getList() + endTable;
                graph = "<div id='Div3' style='min-width: 310px; height: 400px; margin: 0 auto'></div>";

            }
            else
            {
                message.Text = "No Exercise Information";
            }
        }
    }
}