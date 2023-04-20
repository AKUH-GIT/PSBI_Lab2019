using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CConnection
/// </summary>
public class CConnection
{
    public SqlConnection cn = null;

    public CConnection()
    {
        //
        // TODO: Add constructor logic here
        //

        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnStr"].ConnectionString);
    }


    public void MConnOpen()
    {
        try
        {
            cn.Open();
        }

        catch (Exception ex)
        {

        }
    }


    public void MConnClose()
    {
        try
        {
            cn.Close();
        }

        catch (Exception ex)
        {

        }
    }
}