using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SDW_Wellbeing
{
    public class Weight
    {
        private List<String> weights;
        public Weight(XmlDocument xdoc)
        {
            weights = new List<String>();
            XmlNodeList nodes = xdoc.SelectNodes("/weightlist/weight");
            foreach (XmlNode node in nodes) {
                String str = "";
                foreach (XmlNode node2 in node.ChildNodes)
                {
                    if ((node2.Name == "id") || (node2.Name == "userid"))
                        continue;
                    str += node2.InnerText + "  ";
                }
                weights.Add(str);
            }
        }
        public String getList() 
        {
            String listOfWeights = "";
            foreach (String str in weights)
            {
                listOfWeights += str + "\n";
            }
            return listOfWeights;
        }
       
    }
}