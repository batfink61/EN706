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
        public Weight getWeight(string userID, string fromDate, string toDate)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(String.Format("http://en706.remotestuff.co.uk/service.asmx/ReadWeight?userId={0}&fromDate={1}&toDate={2}", userID, fromDate, toDate));
            if (xdoc.SelectNodes("/weightlist/weight") == null)
            {
                return null;
            }
            else
            {
                return new Weight(xdoc);
            }
        }
    }
}