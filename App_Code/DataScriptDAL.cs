using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Collections.ObjectModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;

/// <summary>
/// Summary description for Item
/// </summary>
/// 


public class DataScriptDAL
{
    private static Database mDatabase = DatabaseFactory.CreateDatabase("dbSigma");


    public static DataSet FetchDataScripts()
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspDataScriptsFetch");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }

    public static Int32 InsertDataScript(
            Int32 ItemID, 
            String vcFileName ,
            String vcModuleName ,
            String vcDescription ,
            String vcParametres ,
            Int32 iDatabaseID,
            Int32 iUserID,
            bool bIsBackEnd 
    )
    {
        DataSet ds = new DataSet();
        Int32 iDataScriptID = -1;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspDataScriptInsert");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            mDatabase.AddInParameter(dbcmd, "@vcFileName", DbType.String, vcFileName);
            mDatabase.AddInParameter(dbcmd, "@vcModuleName", DbType.String, vcModuleName);
            mDatabase.AddInParameter(dbcmd, "@vcDescription", DbType.String, vcDescription);
            mDatabase.AddInParameter(dbcmd, "@vcParametres", DbType.String, vcParametres);
            mDatabase.AddInParameter(dbcmd, "@iDatabaseID", DbType.Int32, iDatabaseID);
            mDatabase.AddInParameter(dbcmd, "@iUserID", DbType.Int32, iUserID);
            mDatabase.AddInParameter(dbcmd, "@bIsBackEnd", DbType.Boolean, bIsBackEnd);

            mDatabase.AddOutParameter(dbcmd, "@iDataScriptID", DbType.Int32, 0);

            mDatabase.ExecuteNonQuery(dbcmd);
            iDataScriptID = Convert.ToInt32(mDatabase.GetParameterValue(dbcmd, "@iDataScriptID"));
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return iDataScriptID;
    }

    public static object GetDatabases()
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetDatabases");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }

    public static object GetDataScriptStatus()
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetDataScriptStatus");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }



    public static String UpdateDataScript(
        string DataScriptID, 
        string ItemID, 
        string FileName, 
        string ModuleName, 
        string Description, 
        string Parametres, 
        string DatabaseID, 
        bool IsBackEnd, 
        string DataScriptStatusID,
        String UpdatedBy
        )
    {
        string message = "Success";
        try
        {

            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspUpdateDataScript");
            mDatabase.AddInParameter(dbcmd, "@iDataScriptID", DbType.Int32, DataScriptID);
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            mDatabase.AddInParameter(dbcmd, "@vcFileName", DbType.String, FileName);
            mDatabase.AddInParameter(dbcmd, "@vcModuleName", DbType.String, ModuleName);
            mDatabase.AddInParameter(dbcmd, "@vcDescription", DbType.String, Description);
            mDatabase.AddInParameter(dbcmd, "@vcParametres", DbType.String, Parametres);
            mDatabase.AddInParameter(dbcmd, "@iDatabaseID", DbType.Int32, DatabaseID);
            mDatabase.AddInParameter(dbcmd, "@bisBackend", DbType.Boolean, IsBackEnd);
            mDatabase.AddInParameter(dbcmd, "@iDataScriptStatusID", DbType.Int32, DataScriptStatusID);
            mDatabase.AddInParameter(dbcmd, "@vcWindowsLogin", DbType.String, UpdatedBy);
            mDatabase.ExecuteScalar(dbcmd);
        }
        catch (Exception exp)
        {
            message = exp.Message + "<br>" + exp.Source + "<br>" + exp.StackTrace;
        }
        return message;
    }
}




