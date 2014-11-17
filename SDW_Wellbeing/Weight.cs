using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SDW_Wellbeing
{
    public class Weight
    {
        private string _date;
        public string date
        {
            set
            {
                _date = value;
            }
            get
            {
                return _date;
            }

        }
        private string _weightValue;
        public string weightValue
        {
            set
            {
                _weightValue = value;
            }
            get
            {
                return _weightValue;
            }

        }
        public override string ToString()
        {
            return base.ToString() + " " + this.date;

        }
    }  
}