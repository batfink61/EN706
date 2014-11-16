// The AppHelper class contains all shared functions.

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Data.SqlClient;
using System.IO;

public class AppHelper
{
	public AppHelper()
	{
	}

    public static XmlDocument ReadData(String dataSetName,String key)
    {
        // Generic READ function will populate a dataset with data read from a table and return this as XML

        XmlDocument xdoc = new XmlDocument();
        using (SqlConnection oconn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
        {
            try
            {
                oconn.Open();

                // naming datasets with a 'List' suffix will ensure a meaningfull node container for nodelists (one node per row) 
                // The container node will have the name of the dataset plus List 
                // (E.g. user data will be returned <userList><User>a..</user><user>b..</user></userList>

                DataSet ds = new DataSet(dataSetName+"list");
                SqlCommand cmd = new SqlCommand("Read" + dataSetName, oconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pid", key);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
                ds.Tables[0].TableName = dataSetName;

                xdoc.LoadXml(ds.GetXml());
            }
            catch (Exception ex)
            {
                xdoc.LoadXml(String.Format("<error>{0},{1}: {2}</error>", dataSetName,key,ex.Message));
            }
            if (oconn.State == ConnectionState.Open)
            {
                oconn.Close();
            }
        }
        return xdoc;
    }

    public static XmlDocument WriteData(String dataSetName, String dataSet)
    {
        // 'datasetname' is the table to be updated
        // 'dataset' is an XML representation of the columns and data

        // Ideally this function would call a stored procedure.
        // SQL commands would not be embedded here in the code.
        // But, for expediency of prototype, a generic SQL command is being built here in the code

        XmlDocument xdoc = new XmlDocument();

        String cols = ""; // contains a CSV list of columns to be updated
        String vals = ""; // contains corresponding values
        String colValSpr = ""; //seperator for col/val field set
        String fieldSetSpr = ""; //seperator for fieldSet variable
        String fieldSet = "";
        String currId = ""; // current id - we'll use this to delete existing matching rows 
                            // Code developed against MyQL, ported to MS SQL but no REPLACE so
                            // for expediency of prototype we'll DELETE matching rows then INSERT
        String lastNodeName = "";

        // First, create a list of fields and values from the XML dataset passed in
        XmlReader rdr = XmlReader.Create(new StringReader(dataSet));
        while (rdr.Read())
        {
            if (rdr.NodeType == XmlNodeType.Element)
            {
                lastNodeName = rdr.LocalName;
            }
            if (rdr.NodeType == XmlNodeType.Text)
            {
                cols = cols + colValSpr+ lastNodeName;
                vals = vals + String.Format("{0}'{1}'", colValSpr, rdr.Value.Replace("'", "''"));
                colValSpr = ",";
                if (lastNodeName == "id")
                {
                    currId = rdr.Value.Replace("'", "''");
                }
                else
                {
                    fieldSet = fieldSet + String.Format("{0}{1}='{2}'", fieldSetSpr, lastNodeName, rdr.Value.Replace("'", "''"));
                    fieldSetSpr = ",";
                }
            }
        }

        // Open the SQL connection and update the appropriate table.
        // If the row ID has been passed then we can INSERT new rows otherwise UPDATE rows on the table that already exist
        using (SqlConnection oconn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
        {
            SqlCommand cmd = new SqlCommand("",oconn);
            try
            {
                oconn.Open();
                SqlDataReader dr;
                if (currId != "")
                {
                    // no current ID so we need to update the table
                    cmd.CommandText = String.Format("UPDATE {0} SET {1} WHERE id='{2}';SELECT @@ROWCOUNT;", dataSetName, fieldSet, currId);
                    dr = cmd.ExecuteReader();
                }
                else
                {
                    // Insert new row(s) as current ID is known
                    cmd.CommandText = String.Format("INSERT INTO {0} ({1}) VALUES ({2});SELECT @@ROWCOUNT;", dataSetName, cols, vals);
                    dr = cmd.ExecuteReader();
                }
                if (dr.Read())
                {
                    xdoc.LoadXml(String.Format("<rowsUpdated>{0}</rowsUpdated>", dr[0].ToString()));
                }
                else
                {
                    xdoc.LoadXml("<rowsUpdated>0</rowsUpdated>");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                // The following returns the SQL command in the error response.
                // This is to help debug the prototype.
                // The production release of code should not return SQL commands
                xdoc.LoadXml(String.Format("<error>{0}: {1} ({2})</error>", dataSetName, ex.Message,cmd.CommandText));
            }
            if (oconn.State == ConnectionState.Open)
            {
                oconn.Close();
            }
        }
        return xdoc;
    }

    public static XmlDocument VerifyPassword(String userId, String password)
    {
        // Specific function to validate the user password.
        // We never expose the password, simply verify against teh data and return true or false

        XmlDocument xdoc = new XmlDocument();
        using (SqlConnection oconn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
        {
            try
            {
                oconn.Open();

                SqlCommand cmd = new SqlCommand("VerifyPassword", oconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("puserid", userId);
                cmd.Parameters.AddWithValue("ppassword", password);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    xdoc.LoadXml("<response>1</response>");
                }
                else
                {
                    xdoc.LoadXml("<response>0</response>");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                xdoc.LoadXml(String.Format("<error>{0},{1}: {2}</error>", "VerifyPassword", userId, ex.Message));
            }
            if (oconn.State == ConnectionState.Open)
            {
                oconn.Close();
            }
        }
        return xdoc;
    }

    public static XmlDocument ChangePassword(String userId, String oldPassword, String newPassword)
    {
        // Change user password.
        // We need existing password to verify the user has authority to instruct a PW change

        XmlDocument xdoc = new XmlDocument();
        using (SqlConnection oconn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
        {
            try
            {
                oconn.Open();

                SqlCommand cmd = new SqlCommand("ChangePassword", oconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("puserid", userId);
                cmd.Parameters.AddWithValue("poldpassword", oldPassword);
                cmd.Parameters.AddWithValue("pnewpassword", newPassword);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    xdoc.LoadXml("<response>1</response>");
                }
                else
                {
                    xdoc.LoadXml("<response>0</response>");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                xdoc.LoadXml(String.Format("<error>{0},{1}: {2}</error>", "ChangePassword", userId, ex.Message));
            }
            if (oconn.State == ConnectionState.Open)
            {
                oconn.Close();
            }
        }
        return xdoc;
    }

    public static XmlDocument ReadEvents(String dataSetName, String id, String fromDate, String toDate)
    {
        // Read a list of events (weights and exercises) for a given date range and user

        XmlDocument xdoc = new XmlDocument();
        using (SqlConnection oconn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
        {
            try
            {
                oconn.Open();

                DataSet ds = new DataSet(dataSetName + "list");
                SqlCommand cmd = new SqlCommand("Read" + dataSetName, oconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pid", id);
                cmd.Parameters.AddWithValue("pfromdate", fromDate);
                cmd.Parameters.AddWithValue("ptodate", toDate);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
                ds.Tables[0].TableName = dataSetName;

                xdoc.LoadXml(ds.GetXml());
            }
            catch (Exception ex)
            {
                xdoc.LoadXml(String.Format("<error>{0},{1},{2}-{3}: {4}</error>", dataSetName, id, fromDate, toDate, ex.Message));
            }
            if (oconn.State == ConnectionState.Open)
            {
                oconn.Close();
            }
        }
        return xdoc;
    }
}
