﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SDW_Wellbeing
{
    public class Exercise
    {
      public Exercise(XmlNode xdoc)
        {
            //name = xdoc.SelectSingleNode("/userlist/user/name").InnerText;
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
    }
}