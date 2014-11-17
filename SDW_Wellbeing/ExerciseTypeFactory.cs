using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.Security;

namespace SDW_Wellbeing
{
    public class ExerciseTypeFactory
    {
        //Returns an array of type exercise containing all exercise types held within the database.
        public static ExerciseType[] getExerciseTypes()
        {
            //create new service
            en706.Service svc = new en706.Service();
            XmlNode exerciseListXML = svc.ReadExerciseTypes();
            int count = exerciseListXML.ChildNodes.Count;
            ExerciseType[] exerciseArray = new ExerciseType[count];

            int i = 0;
            foreach (XmlNode xdoc in exerciseListXML)
            {
                System.Diagnostics.Debug.WriteLine(i);
                exerciseArray[i] = new ExerciseType(xdoc);     
                i++;
            }

           return exerciseArray;
        }

       
        //Adds a new exercise type to the database
        public static bool createExercise( String exerciseName)
        {
            en706.Service svc = new en706.Service();
            XmlNode newExercise = svc.WriteExerciseType("",exerciseName);
            return (newExercise.InnerText == "1");
        }
    }



}