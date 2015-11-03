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
/// <summary>
/// Summary description for Class1
/// </summary>
public class Workshop
{
    private int iWorkshopID;

    public int IWorkshopID
    {
        get { return iWorkshopID; }
        set { iWorkshopID = value; }
    }
    private int iRequesterID;

    public int IRequesterID
    {
        get { return iRequesterID; }
        set { iRequesterID = value; }
    }
    private string vcFirstName;

    public string VcFirstName
    {
        get { return vcFirstName; }
        set { vcFirstName = value; }
    }
    private string vcItemDescription;

    public string VcItemDescription
    {
        get { return vcItemDescription; }
        set { vcItemDescription = value; }
    }
    private string vcCRPRTDR;

    public string VcCRPRTDR
    {
        get { return vcCRPRTDR; }
        set { vcCRPRTDR = value; }
    }
    private int iITemID;

    public int IITemID
    {
        get { return iITemID; }
        set { iITemID = value; }
    }
    private String  sdtDate;

    public String SdtDate
    {
        get { return sdtDate; }
        set { sdtDate = value; }
    }
    private Int16 siWorkshopStatusID;

    public Int16 SiWorkshopStatusID
    {
        get { return siWorkshopStatusID; }
        set { siWorkshopStatusID = value; }
    }
    private string vcWorkshopStatus;

    public string VcWorkshopStatus
    {
        get { return vcWorkshopStatus; }
        set { vcWorkshopStatus = value; }
    }
}

public class WorkshopStatus
{
    private Int16 siWorkshopStatusID;

    public Int16 SiWorkshopStatusID
    {
        get { return siWorkshopStatusID; }
        set { siWorkshopStatusID = value; }
    }
    private String vcDescription;

    public String VcDescription
    {
        get { return vcDescription; }
        set { vcDescription = value; }
    }
}

public class WorkshopDAL
{
    private static Database mDatabase = DatabaseFactory.CreateDatabase("dbSigma");

    public static List<Workshop> GetWorkshops()
    {
        List<Workshop> ds = new List<Workshop>();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetWorkshops");
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                while (reader.Read())
                {
                    //iUserID	vcWindowsLogin	vcFirstName	vcLastName	vcEmail
                    Workshop i = new Workshop();
                    i.IWorkshopID = reader["iWorkshopID"] == DBNull.Value ? -1 : (int)reader["iWorkshopID"];
                    i.IRequesterID = reader["iRequesterID"] == DBNull.Value ? -1 : (int)reader["iRequesterID"];
                    i.VcFirstName = reader["vcFirstName"] == DBNull.Value ? "" : (string)reader["vcFirstName"];
                    i.VcItemDescription = reader["vcItemDescription"] == DBNull.Value ? "" : (string)reader["vcItemDescription"];
                    i.VcCRPRTDR = reader["vcCRPRTDR"] == DBNull.Value ? "" : (string)reader["vcCRPRTDR"];
                    i.IITemID = reader["iITemID"] == DBNull.Value ? -1 : (int)reader["iITemID"];
                    string strDate = reader["sdtDate"] == DBNull.Value ? "" : reader["sdtDate"].ToString();
                    //                    i.SdtDate = strDate == "" ? new DateTime(1900, 1, 1) :  (DateTime)reader["sdtDate"];
                    i.SdtDate = reader["SdtDate"] == DBNull.Value ? "" : (string)reader["SdtDate"];
                    i.SiWorkshopStatusID = reader["siWorkshopStatusID"] == DBNull.Value ? Convert.ToInt16(-1) : (Int16)reader["siWorkshopStatusID"];
                    i.VcWorkshopStatus = reader["vcWorkshopStatus"] == DBNull.Value ? "" : (string)reader["vcWorkshopStatus"];
                    ds.Add(i);

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static Workshop GetWorkshopByID(int WorkshopID)
    {
        Workshop w = null;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetWorkshopByID");
            mDatabase.AddInParameter(dbcmd, "@iWorkshopID", DbType.Int32, WorkshopID);
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                if (reader.Read())
                {
                    //iUserID	vcWindowsLogin	vcFirstName	vcLastName	vcEmail
                    w = new Workshop();
                    w.IWorkshopID = reader["iWorkshopID"] == DBNull.Value ? -1 : (int)reader["iWorkshopID"];
                    w.IRequesterID = reader["iRequesterID"] == DBNull.Value ? -1 : (int)reader["iRequesterID"];
                    w.VcFirstName = reader["vcFirstName"] == DBNull.Value ? "" : (string)reader["vcFirstName"];
                    w.VcItemDescription = reader["vcItemDescription"] == DBNull.Value ? "" : (string)reader["vcItemDescription"];
                    w.VcCRPRTDR = reader["vcCRPRTDR"] == DBNull.Value ? "" : (string)reader["vcCRPRTDR"];
                    w.IITemID = reader["iITemID"] == DBNull.Value ? -1 : (int)reader["iITemID"];
                    string strDate = reader["sdtDate"] == DBNull.Value ? "" : reader["sdtDate"].ToString();
                    w.SdtDate = reader["SdtDate"] == DBNull.Value ? "" : (string)reader["SdtDate"];
                    w.SiWorkshopStatusID = reader["siWorkshopStatusID"] == DBNull.Value ? Convert.ToInt16(-1) : (Int16)reader["siWorkshopStatusID"];
                    w.VcWorkshopStatus = reader["vcWorkshopStatus"] == DBNull.Value ? "" : (string)reader["vcWorkshopStatus"];
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return w;

    }
    public static string WorkshopInsert(int iRequesterID, int iItemID, string sdtDate, int siWorkshopStatusID)
    {
        string message = "Success";
        try
        {
            //iWorkshopID	iRequesterID	iItemID	sdtDate	siWorkshopStatusID	dtUpdateTime

            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspInsertWorkshop");
            mDatabase.AddInParameter(dbcmd, "@iRequesterID", DbType.Int32, iRequesterID);
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iItemID);
            if (sdtDate.Trim().Equals(""))
                mDatabase.AddInParameter(dbcmd, "@sdtDate", DbType.DateTime, DBNull.Value);
            else
                mDatabase.AddInParameter(dbcmd, "@sdtDate", DbType.DateTime, sdtDate);
            mDatabase.AddInParameter(dbcmd, "@siWorkshopStatusID", DbType.String, siWorkshopStatusID);
            mDatabase.ExecuteScalar(dbcmd);
        }
        catch (Exception exp)
        {
            message = exp.Message + "<br>" + exp.Source + "<br>" + exp.StackTrace;
        }
        return message;
    }
    public static string WorkshopUpdate(int iWorkshopID, int iRequesterID, int iItemID, string sdtDate, int siWorkshopStatusID)
    {
        string message = "Success";
        try
        {
            //iWorkshopID	iRequesterID	iItemID	sdtDate	siWorkshopStatusID	dtUpdateTime

            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspUpdateWorkshop");
            mDatabase.AddInParameter(dbcmd, "@iWorkshopID", DbType.Int32, iWorkshopID);
            mDatabase.AddInParameter(dbcmd, "@iRequesterID", DbType.Int32, iRequesterID);
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iItemID);
            if(sdtDate.Trim().Equals(""))
                mDatabase.AddInParameter(dbcmd, "@sdtDate", DbType.DateTime, DBNull.Value);
            else
                mDatabase.AddInParameter(dbcmd, "@sdtDate", DbType.DateTime, sdtDate);
            mDatabase.AddInParameter(dbcmd, "@siWorkshopStatusID", DbType.String, siWorkshopStatusID);
            mDatabase.ExecuteScalar(dbcmd);
        }
        catch (Exception exp)
        {
            message = exp.Message + "<br>" + exp.Source + "<br>" + exp.StackTrace;
        }
        return message;
    }
    public static DataSet GetWorkshopStatusesDS()
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetWorkshopStatuses");
            //mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iItemID);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }
    public static List<WorkshopStatus> GetWorkshopStatusList()
    {
        List<WorkshopStatus> ds = new List<WorkshopStatus>();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetWorkshopStatuses");
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                while (reader.Read())
                {
                    //iUserID	vcWindowsLogin	vcFirstName	vcLastName	vcEmail
                    WorkshopStatus i = new WorkshopStatus();
                    i.SiWorkshopStatusID = reader["siWorkshopStatusID"] == DBNull.Value ? Convert.ToInt16(-1) : (Int16)reader["siWorkshopStatusID"];
                    i.VcDescription = reader["vcDescription"] == DBNull.Value ? "" : (string)reader["vcDescription"];
                    ds.Add(i);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
}