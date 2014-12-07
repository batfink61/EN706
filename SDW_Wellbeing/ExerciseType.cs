// Exercise type object
// Used within the adminsitration of exercises 
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SDW_Wellbeing
{
    public class ExerciseType
    {
      //constructor takes an xml node for an exerciseType and set the id and name from it
      public ExerciseType(XmlNode xdoc)
        {
            id = xdoc.FirstChild.InnerText;
            name = xdoc.LastChild.InnerText;
        }
        private string _name;
        public string name
        {
            set
            { 
                _name = value;
            }
            get
            { 
                return _name;
            }
        }

        private string _id;
        public string id
        {
            set
            {
                _id = value;
            }
            get
            {
                return _id;
            }

        }
    }
}