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
using MySql.Data.MySqlClient;
using System.IO;

public class AppHelper
{
	public AppHelper()
	{
	}

    public static XmlDocument ReadData(String dataSetName,String key)
    {
        XmlDocument xdoc = new XmlDocument();
        using (MySqlConnection oconn = new MySqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
        {
            try
            {
                oconn.Open();

                // naming datasets with a 'List' suffix will ensure a meaningfull node container for nodelists (one node per row) 
                // The container node will have the name of the dataset plus List 
                // (E.g. user data will be returned <userList><User>a..</user><user>b..</user></userList>

                DataSet ds = new DataSet(dataSetName+"list");
                MySqlCommand cmd = new MySqlCommand("Read" + dataSetName, oconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pid", key);

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
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
        // But, for expediency of prototype, the SQl command is being built here in the code

        XmlDocument xdoc = new XmlDocument();

        String cols = ""; // contains a CSV list of columns to be updated
        String vals = ""; // contains corresponding values
        String seper = "";
        String lastNodeName = "";

        XmlReader rdr = XmlReader.Create(new StringReader(dataSet));
        while (rdr.Read())
        {
            if (rdr.NodeType == XmlNodeType.Element)
            {
                lastNodeName = rdr.LocalName;
            }
            if (rdr.NodeType == XmlNodeType.Text)
            {
                cols = cols + seper + lastNodeName;
                vals = vals + seper + "'" + rdr.Value.Replace("'", "''") + "'";
                seper = ",";
            }
        }

        using (MySqlConnection oconn = new MySqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
        {
            try
            {
                oconn.Open();

                MySqlCommand cmd = new MySqlCommand(String.Format("REPLACE INTO {0} ({1}) VALUES ({2});SELECT ROW_COUNT();", dataSetName, cols, vals), oconn);
                MySqlDataReader dr = cmd.ExecuteReader();
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
                xdoc.LoadXml(String.Format("<error>{0}: {1}</error>", dataSetName, ex.Message));
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
        XmlDocument xdoc = new XmlDocument();
        using (MySqlConnection oconn = new MySqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
        {
            try
            {
                oconn.Open();

                MySqlCommand cmd = new MySqlCommand("VerifyPassword", oconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("puserid", userId);
                cmd.Parameters.AddWithValue("ppassword", password);

                MySqlDataReader dr = cmd.ExecuteReader();

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
        XmlDocument xdoc = new XmlDocument();
        using (MySqlConnection oconn = new MySqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
        {
            try
            {
                oconn.Open();

                MySqlCommand cmd = new MySqlCommand("ChangePassword", oconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("puserid", userId);
                cmd.Parameters.AddWithValue("poldpassword", oldPassword);
                cmd.Parameters.AddWithValue("pnewpassword", newPassword);

                MySqlDataReader dr = cmd.ExecuteReader();

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
        XmlDocument xdoc = new XmlDocument();
        using (MySqlConnection oconn = new MySqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
        {
            try
            {
                oconn.Open();

                DataSet ds = new DataSet(dataSetName + "list");
                MySqlCommand cmd = new MySqlCommand("Read" + dataSetName, oconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pid", id);
                cmd.Parameters.AddWithValue("pfromdate", fromDate);
                cmd.Parameters.AddWithValue("ptodate", toDate);

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
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
