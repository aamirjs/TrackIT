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


public class PDCDAL
{
    private static Database mDatabase = DatabaseFactory.CreateDatabase("dbSigma");

    public static DataSet GetReminders()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspRemindersGet");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public static DataSet RemindersGet()
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspRemindersGet");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }

    public static DataSet ReminderPendingGet()
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspReminderPendingGet");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }



    public static DataSet GetChecklistForItem(int ItemID)
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetChecklistForItem");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }



    public static string ReminderUpdate(int iItemID, int iReminderID, string vcRemindFor, DateTime sdtRemindDate)
    {
        string message = "Success";
        try
        {

            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspReminderUpdate");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iItemID);
            mDatabase.AddInParameter(dbcmd, "@iReminderID", DbType.Int32, iReminderID);
            mDatabase.AddInParameter(dbcmd, "@vcRemindFor", DbType.String, vcRemindFor);
            mDatabase.AddInParameter(dbcmd, "@sdtRemindDate", DbType.DateTime, sdtRemindDate);
            mDatabase.ExecuteScalar(dbcmd);
        }
        catch (Exception exp)
        {
            message = exp.Message + "<br>" + exp.Source + "<br>" + exp.StackTrace;
        }
        return message;
    }

    public static string ReminderInsert(int iItemID, string vcRemindFor, DateTime sdtRemindDate, bool bRecur)
    {
        string message = "Success";
        try
        {

            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspReminderInsert");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iItemID);
            mDatabase.AddInParameter(dbcmd, "@vcRemindFor", DbType.String, vcRemindFor);
            mDatabase.AddInParameter(dbcmd, "@sdtRemindDate", DbType.DateTime, sdtRemindDate);
            mDatabase.AddInParameter(dbcmd, "@bRecur", DbType.Boolean, bRecur);
            mDatabase.ExecuteScalar(dbcmd);
        }
        catch (Exception exp)
        {
            message = exp.Message + "<br>" + exp.Source + "<br>" + exp.StackTrace;
        }
        return message;
    }
    
}



