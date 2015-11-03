using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Collections.ObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Text;

public class DatabaseObject
{
    string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    string _description;

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    Int64 _spid;

    public Int64 SPID
    {
        get { return _spid; }
        set { _spid = value; }
    }

    string _updated;
    public string Updated
    {
        get { return _updated; }
        set { _updated = value; }
    }
}


public class LLDDAL
{
    private static Database mDatabase = DatabaseFactory.CreateDatabase("dbSigma");
    public static int UpdateSPDescription(string spid, string description)
    {
        Int32 rowsAffected = 0;

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspUpdateSPDescription");
            mDatabase.AddInParameter(dbcmd, "@spid", DbType.String, spid);
            mDatabase.AddInParameter(dbcmd, "@description", DbType.String, description);
            rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rowsAffected;
    }
    public static List<DatabaseObject> GetFullSPData()
    {
        List<DatabaseObject> list = new List<DatabaseObject>();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetFullSPData");
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                while (reader.Read())
                {
                    DatabaseObject o = new DatabaseObject();
                    o.SPID = reader["spid"] == DBNull.Value ? 0 : (Int64)reader["spid"];
                    o.Name = reader["name"] == DBNull.Value ? "" : (String)reader["name"];
                    o.Description = reader["description"] == DBNull.Value ? "" : (String)reader["description"];
                    o.Updated = reader["Updated"] == DBNull.Value ? "" : (String)reader["Updated"]; 
                    list.Add(o);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return list;
    }
    public static List<DatabaseObject> GetObjectList(string prefixText, int count, string contextKey)
    {

        List<DatabaseObject> list = new List<DatabaseObject>();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetFullSPData");
            mDatabase.AddInParameter(dbcmd, "@vcprefixText", DbType.String, prefixText);
            mDatabase.AddInParameter(dbcmd, "@iCount", DbType.Int32, count);
            mDatabase.AddInParameter(dbcmd, "@vcContextKey", DbType.String, contextKey);
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                while (reader.Read())
                {
                    DatabaseObject o = new DatabaseObject();
                    o.SPID = reader["spid"] == DBNull.Value ? 0 : (Int64)reader["spid"];
                    o.Name = reader["name"] == DBNull.Value ? "" : (String)reader["name"];
                    o.Description = reader["description"] == DBNull.Value ? "" : (String)reader["description"];
                    o.Updated = reader["Updated"] == DBNull.Value ? "" : (String)reader["Updated"];
                    list.Add(o);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return list;
    }


}
