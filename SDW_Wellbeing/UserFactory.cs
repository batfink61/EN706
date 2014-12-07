using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.Security;

namespace SDW_Wellbeing
{
    public class UserFactory
    {
        public static User getUser(string userID)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("http://en706.remotestuff.co.uk/service.asmx/ReadUser?userid="+ userID);
            if (xdoc.SelectSingleNode("/userlist/user/id") == null)
            {
                return null;
            }
            else
            {
                return new User(xdoc);
            }
        }

        //Bool funtion to check for a userId in the database
        public static Boolean checkForUser(string userID)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("http://en706.remotestuff.co.uk/service.asmx/ReadUser?userid=" + userID);
            
            //if value is empty string then account does not exist else it does.
            if (xdoc.InnerText == "")
            {
                //System.Diagnostics.Debug.WriteLine("false");
                return false;
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("true");
                return true;
            }
        }

        public static Boolean VerifyUser(string userID, string passwd)
        {
            XmlDocument xdoc = new XmlDocument();

            xdoc.Load(String.Format("http://en706.remotestuff.co.uk/service.asmx/VerifyPassword?userId={0}&password={1}", userID, passwd));
            if (xdoc.SelectSingleNode("/response").InnerText == "1" )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool CreateUser(String userName, String email, String password)
        {
            en706.Service svc = new en706.Service();
            XmlNode newuser = svc.WriteUser("",userName,password,email,0,0);
            return (newuser.InnerText == "1");
        }
    }
}