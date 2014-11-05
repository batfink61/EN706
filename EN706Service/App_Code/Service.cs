
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
using MySql.Data.MySqlClient;
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

    [WebMethod]
    public XmlDocument ReadUser(String userId) 
    {
        return AppHelper.ReadData("user",userId);
    }

    [WebMethod]
    public XmlDocument WriteUser(String id, String name, String password, String email, int isAdministrator, int hcAllowAccess)
    {
        String userXml = String.Format("<userlist><user><id>{0}</id><name>{1}</name><password>{2}</password><email>{3}</email><isadministrator>{4}</isadministrator><hcallowedaccess>{5}</hcallowedaccess></user></userlist>",id,name,password,email,isAdministrator,hcAllowAccess);
        return AppHelper.WriteData("user", userXml);
    }

    [WebMethod]
    public XmlDocument VerifyPassword(String userId, String password)
    {
        return AppHelper.VerifyPassword(userId, password);
    }

    [WebMethod]
    public XmlDocument ChangePassword(String userId, String oldPassword, String newPassword)
    {
        return AppHelper.ChangePassword(userId, oldPassword, newPassword);
    }

    [WebMethod]
    public XmlDocument ReadExerciseTypes()
    {
        return AppHelper.ReadData("exerciseType", "");
    }

    [WebMethod]
    public XmlDocument ReadExercise(String userId, String fromDate, String toDate)
    {
        return AppHelper.ReadEvents("exercise", userId, fromDate, toDate);
    }

    [WebMethod]
    public XmlDocument ReadWeight(String userId, String fromDate, String toDate)
    {
        return AppHelper.ReadEvents("weight", userId, fromDate, toDate);
    }

    [WebMethod]
    public XmlDocument WriteExercise(String id, String exerciseDate, String userId, String exerciseType, int duration)
    {
        String exerciseXml = String.Format("<exerciselist><exercise><id>{0}</id><exercisedate>{1}</exercisedate><userid>{2}</userid><exercisetype>{3}</exercisetype><duration>{4}</duration></exercise></exerciselist>", id, exerciseDate, userId, exerciseType, duration);
        return AppHelper.WriteData("exercise", exerciseXml);
    }

    [WebMethod]
    public XmlDocument WriteWeight(String id, String weightDate, String userId, int weight)
    {
        String exerciseXml = String.Format("<weightlist><weight><id>{0}</id><weightdate>{1}</weightdate><userid>{2}</userid><weight>{3}</weight></weight></weightlist>", id, weightDate, userId, weight);
        return AppHelper.WriteData("weight", exerciseXml);
    }
    
    [WebMethod]
    public XmlDocument WriteExerciseType(String id, String description)
    {
        String exerciseXml = String.Format("<exercisetypelist><exercisetype><id>{0}</id><exercisetype>{1}</exercisetype></exercisetype></exercisetypelist>", id, description);
        return AppHelper.WriteData("exercisetype", exerciseXml);
    }
}

