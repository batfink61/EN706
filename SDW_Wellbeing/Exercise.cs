using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SDW_Wellbeing
{
    public class Exercise
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
        private string _type;
        public string type
        {
            set
            {
                _type = value;
            }
            get
            {
                return _type;
            }

        }
        private string _duration;
        public string duration
        {
            set
            {
                _duration = value;
            }
            get
            {
                return _duration;
            }

        }
        public override string ToString()
        {
            return base.ToString() + " " + this._date + " " + this._type + " " + this._duration;

        }
    }
}