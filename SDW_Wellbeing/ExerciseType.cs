// Exercise type object (Factory which serves weight recording and exercise events as ICalEvents)
// The Calendar uses the EN706 web service to access data objects (End point defined in web.config)
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