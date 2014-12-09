// User class defines instance of a user
// Instantiated using the UserFactory
//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SDW_Wellbeing
{
    public class User
    {
        public User(XmlNode xdoc)
        {
            name = xdoc.SelectSingleNode("/userlist/user/name").InnerText;
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
        private string _email;
        public string email
        {
            set
            {
                _email = value;
            }
            get
            {
                return _email;
            }

        }
    }
}