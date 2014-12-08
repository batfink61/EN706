using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.Security;
using System.Configuration;

namespace SDW_Wellbeing
{
    public class UserFactory
    {
        public static User getUser(string userID)
        {
            XmlDocument xdoc = new XmlDocument();
            en706.Service srv = new en706.Service();

            xdoc.Load(srv.ReadUser(userID).ToString());
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
            en706.Service srv = new en706.Service();
            xdoc.LoadXml(srv.ReadUser(userID).OuterXml);            
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

        // Verify password does not read password - simply pass user id and pw
        // to web service and it returns boolean (0/1)
        public static Boolean VerifyUser(string userID, string passwd)
        {
            XmlDocument xdoc = new XmlDocument();
            en706.Service srv = new en706.Service();
            xdoc.LoadXml(srv.VerifyPassword(userID,passwd).OuterXml);
            if (xdoc.SelectSingleNode("/response").InnerText == "1" )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Create user uses the web service to write new user details
        public static bool CreateUser(String userName, String email, String password)
        {
            en706.Service svc = new en706.Service();
            XmlNode newuser = svc.WriteUser("",userName,password,email,0,0);
            return (newuser.InnerText == "1");
        }
    }
}