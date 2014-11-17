using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
namespace SDW_Wellbeing
{
    public class WeightModel
    {

        ///////////////////
        //SINGLETON PATTERN
        //////////////////
        private static WeightModel instance;
        public static WeightModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeightModel();
                }
                return instance;
            }
        }
        private WeightModel()
        {
        }
        private List<Weight> weightList= new List<Weight>();
        public List<Weight> getWeight(string userID, string fromDate, string toDate)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(String.Format("http://en706.remotestuff.co.uk/service.asmx/ReadWeight?userId={0}&fromDate={1}&toDate={2}", userID, fromDate, toDate));
            if (xdoc.SelectNodes("/weightlist/weight") == null)
            {
                return null;
            }
            else
            {
                return getWeightList(xdoc);
            }
        }

        public List<Weight> getWeightList(XmlDocument xdoc)
        {
            XmlNodeList nodes = xdoc.SelectNodes("/weightlist/weight");
            foreach (XmlNode node in nodes) {
                Weight w = new Weight();
                w.weightValue = node.SelectSingleNode("weight").InnerText;
                w.date = node.SelectSingleNode("weightdate").InnerText;
                weightList.Add(w);
            }
            return weightList;
        }

        public String getValueList()
        {
            String listOfWeights = "";
            String sepr = "";

            List<Weight> weightListTemp = SortAscending(weightList);
            foreach (Weight w in weightListTemp)
            {
                listOfWeights += sepr + w.weightValue;
                sepr = ",";
            }
            return listOfWeights;
        }
        public String getDatesList()
        {
            String listOfDates = "";
            String sepr = "";
            List<Weight> weightListTemp = SortAscending(weightList);
            foreach (Weight w in weightListTemp)
            {
                listOfDates += string.Format("{0}'{1}'", sepr, w.date);
                sepr = ",";
            }
            return listOfDates;
        }
        public String getList()
        {
            String weightsDates = "";
            List<Weight> weightListTemp = SortAscending(weightList);
            foreach (Weight w in weightListTemp)
            {
                weightsDates += "<tr><td class='datesWeightsTd'>" + w.date + "</td><td class='datesWeightsTd'>" + w.weightValue + "</td></tr>";
            }
            return weightsDates;
        }
        public List<Weight> SortAscending(List<Weight> list)
        {
            list.Sort((a, b) => b.date.CompareTo(a.date));
            return list;
        }
        public bool SaveWeight(String userId, String weightDate, int weight)
        {
            en706.Service svc = new en706.Service();
            XmlNode xdoc = svc.WriteWeight("", weightDate, userId, weight);
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