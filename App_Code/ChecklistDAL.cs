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
using System.Text;


public class ChecklistDAL
{
    private static Database mDatabase = DatabaseFactory.CreateDatabase("dbSigma");


    public static int UpdateSDChecklistForItem(String EntryID, String ItemID, String UserResponse, String Comment, String vcOwner)
    {
        Int32 rowsAffected = 0;

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspChecklistForItemUpdate");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            mDatabase.AddInParameter(dbcmd, "@iEntryID", DbType.Int32, EntryID);
            mDatabase.AddInParameter(dbcmd, "@vcResponse", DbType.String, UserResponse);
            mDatabase.AddInParameter(dbcmd, "@vcOwner", DbType.String, vcOwner);
            mDatabase.AddInParameter(dbcmd, "@vcComment", DbType.String, Comment);
            rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rowsAffected;
    }
    public static object GetItemChecklist(int iItemID, string Owner)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspChecklisttForItemGet");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iItemID);
            mDatabase.AddInParameter(dbcmd, "@vcOwner", DbType.String, Owner);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public static int InsertEntry(string EntryID, string ItemID, String UserResponse, string Comment)
    {
        Int32 rowsAffected = 0;

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspChecklistEntryInsert");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            mDatabase.AddInParameter(dbcmd, "@iEntryID", DbType.Int32, EntryID);
            mDatabase.AddInParameter(dbcmd, "@vcResponse", DbType.String, UserResponse);
            mDatabase.AddInParameter(dbcmd, "@vcComment", DbType.String, Comment);
            rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rowsAffected;
    }

    public static int ChecklistLockChange(string iItemID, string vcOwner, bool Locked)
    {
        Int32 rowsAffected = 0;

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspChecklistLockChange");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iItemID);
            mDatabase.AddInParameter(dbcmd, "@vcOwner", DbType.String, vcOwner);
            mDatabase.AddInParameter(dbcmd, "@bLockToggle", DbType.Boolean, Locked);
            rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rowsAffected;
    }
}




