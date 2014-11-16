using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDW_Wellbeing
{
    public partial class ExerciseAdmin : System.Web.UI.Page
    {

        private string newExercise;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(newExercise);
            //Content holds an HTML string which is appended to the DOM.
            string content = "";
            exercises.InnerHtml = "What";
            content = "<h3>Current Exercises</h3><table class=\"table table-striped\"><thead><tr><th>ID</th><th>Name</th></tr></thead><tbody>";
            //Retrieve array of exercises from the database
            Exercise[] exerciseArray = ExerciseFactory.getExerciseTypes();
  
            //For each exercise in the array print it to the exercises DIV on the page.
            foreach (Exercise exercise in exerciseArray)
            {
                if (exercise.name == newExercise)
                {
                    content += "<tr><td>" + exercise.id + "</td><td>" + exercise.name + "       <span class=\"label label-success\">New</span></td></tr>";
                }
                else
                {
                    content += "<tr><td>" + exercise.id + "</td><td>" + exercise.name + "</td></tr>";
                }
             }

            content += "</tbody></table>";
            exercises.InnerHtml = content;
        }

        protected void CreateExercise_Click(object sender, EventArgs e)
        {
            int exerciseExists = 0; 
            
            //validate the input 
            if (ExerciseName.Text == "")
            {
                validate.Attributes["class"] += " has-error";
                addExercise.Text = "Exercise Name: Please enter a name";
            }
            else
            {
                //get exercise list and check if this already exists
                Exercise[] exerciseArray = ExerciseFactory.getExerciseTypes();

                foreach (Exercise exercise in exerciseArray)
                {
                    if (ExerciseName.Text == exercise.name)
                    {
                        exerciseExists = 1; 
                    }
                
                }      
            }

            if (exerciseExists == 1)
            {
                validate.Attributes["class"] += " has-error";
                addExercise.Text = "Exercise Name: Exercise already exists";
            }
            else
            {
                if (ExerciseFactory.createExercise(ExerciseName.Text))
                {
                    this.newExercise = ExerciseName.Text;
                    Response.Redirect(Request.RawUrl);
                }
            }


        }
    }
}