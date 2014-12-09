using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SDW_Wellbeing
{
    /// <summary>
    /// The Exercise Model class provides a higher level unified model interface to the Web Service
    /// uses the FACADE PATTERN
    /// </summary>
    public class ExerciseModel
    {
            ///////////////////
        //SINGLETON PATTERN
        //////////////////
        private static ExerciseModel instance;
        public static ExerciseModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExerciseModel();
                }
                return instance;
            }
        }
        private ExerciseModel()
        {
        }
        private List<Exercise> exerciseList= new List<Exercise>();
        public List<Exercise> getExercise(string userID, string fromDate, string toDate)
        {
            XmlDocument xdoc = new XmlDocument();
            en706.Service srv = new en706.Service();
            xdoc.LoadXml(srv.ReadExercise(userID, fromDate,toDate).OuterXml);
            if (xdoc.SelectNodes("/exerciselist/exercise") == null)
            {
                return null;
            }
            else
            {
                return getExerciseList(xdoc);
            }
        }

        public List<Exercise> getExerciseList(XmlDocument xdoc)
        {
            XmlNodeList nodes = xdoc.SelectNodes("/exerciselist/exercise");
            foreach (XmlNode node in nodes) {
                Exercise e = new Exercise();
                e.type = node.SelectSingleNode("exercisetype").InnerText;
                e.date = node.SelectSingleNode("exercisedate").InnerText;
                e.duration = node.SelectSingleNode("duration").InnerText;
                exerciseList.Add(e);
            }
            return exerciseList;
        }

        public String getTypeList()
        {
            String listOfTypes = "";
            String sepr = "";

            List<Exercise> exerciseListTemp = SortAscending(exerciseList);
            foreach (Exercise e in exerciseListTemp)
            {
                listOfTypes += sepr + e.type;
                sepr = ",";
            }
            return listOfTypes;
        }
        public String getDatesList()
        {
            String listOfDates = "";
            String sepr = "";
            List<Exercise> exerciseListTemp = SortAscending(exerciseList);
            foreach (Exercise e in exerciseListTemp)
            {
                listOfDates += string.Format("{0}'{1}'", sepr, e.date);
                sepr = ",";
            }
            return listOfDates;
        }
        public String getDurationList()
        {
            String listOfDuration = "";
            String sepr = "";
            List<Exercise> exerciseListTemp = SortAscending(exerciseList);
            foreach (Exercise e in exerciseListTemp)
            {
                listOfDuration += string.Format("{0}{1}", sepr, e.duration);
                sepr = ",";
            }
            return listOfDuration;
        }
        public String getList()
        {
            String exerciseString = "";
            List<Exercise> ExerciseListTemp = SortAscending(exerciseList);
            foreach (Exercise e in ExerciseListTemp)
            {
                exerciseString += "<tr><td class='datesExercisesTd'>" + e.date + "</td><td class='datesExercisesTd'>" + e.duration + "</td></tr>";
            }
            return exerciseString;
        }
        public List<Exercise> SortAscending(List<Exercise> list)
        {
            list.Sort((a, b) => b.date.CompareTo(a.date));
            return list;
        }
        public bool SaveExercise(String userId, String exerciseDate, String exercise, int duration)
        {
            en706.Service svc = new en706.Service();
            XmlNode xdoc = svc.WriteExercise("", exerciseDate, userId, exercise, duration);
            if (xdoc.InnerText=="1")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    
    }
}