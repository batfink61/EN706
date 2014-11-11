using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SDW_Wellbeing
{
    public class Weight
    {
        private String weightsCsv;
        private String datesCsv;

        private List<String> weights= new List<String>();
        private List<String> dates = new List<String>();
        public Weight(XmlDocument xdoc)
        {
            XmlNodeList nodes = xdoc.SelectNodes("/weightlist/weight");
            foreach (XmlNode node in nodes) {
                weights.Add(node.SelectSingleNode("weight").InnerText);
                dates.Add(node.SelectSingleNode("weightdate").InnerText);
            }

        }

        public String geValueList()
        {
            String listOfWeights = "";
            String sepr = "";

            foreach (String str in weights)
            {
                listOfWeights += sepr + str;
                sepr = ",";
            }
            return listOfWeights;
        }
        public String getDatesList()
        {
            String listOfDates = "";
            String sepr = "";

            foreach (String str in dates)
            {
                listOfDates += string.Format("{0}'{1}'", sepr, str);
                sepr = ",";
            }
            return listOfDates;
        }
       
    }
}