
// EN706 Group Project Database Object Service
//
// This web service supports all of the data objects required.
// Simple read/writes are handled by a generic READDATA and WRITEDATA functions
// All DB READ functions return data as XML documents
// All WRITE functions accept an XML document, parse values and update appropriate tables returning the number of rows updated.

using System;
using System.Xml;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

[WebService(Namespace = "http://en706.remotestuff.co.uk/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class Service : System.Web.Services.WebService
{
    public Service () 
    {
    }

    // Read user profile for a given userID
    [WebMethod]
    public XmlDocument ReadUser(String userId) 
    {
        return AppHelper.ReadData("users",userId);
    }

    // Write user profile for a given user ID
    [WebMethod]
    public XmlDocument WriteUser(String id, String name, String password, String email, int isAdministrator, int hcAllowAccess)
    {
        String userXml = String.Format("<userlist><user><id>{0}</id><name>{1}</name><password>{2}</password><email>{3}</email><isadministrator>{4}</isadministrator><hcallowedaccess>{5}</hcallowedaccess></user></userlist>",id,name,password,email,isAdministrator,hcAllowAccess);
        return AppHelper.WriteData("users", userXml);
    }

    // Verify user password. Returns 0 or 1 for not verified/verifed
    [WebMethod]
    public XmlDocument VerifyPassword(String userId, String password)
    {
        return AppHelper.VerifyPassword(userId, password);
    }

    // Change user password, Requires old password for verification
    [WebMethod]
    public XmlDocument ChangePassword(String userId, String oldPassword, String newPassword)
    {
        return AppHelper.ChangePassword(userId, oldPassword, newPassword);
    }

    //Reaf a list of valid exercise types
    [WebMethod]
    public XmlDocument ReadExerciseTypes()
    {
        return AppHelper.ReadData("exerciseType", "");
    }

    // Read a list of exercises for a given user and between two dates
    [WebMethod]
    public XmlDocument ReadExercise(String userId, String fromDate, String toDate)
    {
        return AppHelper.ReadEvents("exercise", userId, fromDate, toDate);
    }

    // Read a list of user weights for a given user between two dates 
    [WebMethod]
    public XmlDocument ReadWeight(String userId, String fromDate, String toDate)
    {
        return AppHelper.ReadEvents("weight", userId, fromDate, toDate);
    }

    // Write a specific exercise for a given user
    [WebMethod]
    public XmlDocument WriteExercise(String id, String exerciseDate, String email, String exerciseType, int duration)
    {
        String exerciseXml = String.Format("<exerciselist><exercise><id>{0}</id><exercisedate>{1}</exercisedate><email>{2}</email><exercisetype>{3}</exercisetype><duration>{4}</duration></exercise></exerciselist>", id, exerciseDate, email, exerciseType, duration);
        return AppHelper.WriteData("exercise", exerciseXml);
    }

    // Write a wight measurement for a specific user on a given date
    [WebMethod]
    public XmlDocument WriteWeight(String id, String weightDate, String email, int weight)
    {
        String exerciseXml = String.Format("<weightlist><weight><id>{0}</id><weightdate>{1}</weightdate><email>{2}</email><weight>{3}</weight></weight></weightlist>", id, weightDate, email, weight);
        return AppHelper.WriteData("weight", exerciseXml);
    }
    
    // Write to the list of valid exercise types
    [WebMethod]
    public XmlDocument WriteExerciseType(String id, String description)
    {
        String exerciseXml = String.Format("<exercisetypelist><exercisetype><id>{0}</id><exercisetype>{1}</exercisetype></exercisetype></exercisetypelist>", id, description);
        return AppHelper.WriteData("exercisetype", exerciseXml);
    }
}

