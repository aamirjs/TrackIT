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
/// Summary description for ItemIncident
/// </summary>
/// 



public class SWIncidentDAL
{
    private static Database mDatabase = DatabaseFactory.CreateDatabase("dbSigma");
    public SWIncidentDAL()
    {
    }
    public static int SWIncidentDelete(int iIncidentID)
    {
        int rows = 0;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspSWIncidentDel");
            mDatabase.AddInParameter(dbcmd, "@iIncidentID", DbType.Int32, iIncidentID);
            rows = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return rows;
    }

    public static int SWIncidentInsert(
        int ItemID, 
        String IncidentDescription,
        String IncidentNumber,
        DateTime IncidentDate,
        bool HasIncident,
        bool WasRolledBack,
        bool WasHotfixed)

    {
        Int32 rowsAffected = 0;

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspSWIncidentInsert");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            mDatabase.AddInParameter(dbcmd, "@vcIncidentDescription", DbType.String, IncidentDescription);
            mDatabase.AddInParameter(dbcmd, "@vcIncidentNumber", DbType.String, IncidentNumber);
            mDatabase.AddInParameter(dbcmd, "@sdtIncidentDate", DbType.DateTime, IncidentDate);
            mDatabase.AddInParameter(dbcmd, "@bHasIncident", DbType.Boolean, HasIncident);
            mDatabase.AddInParameter(dbcmd, "@bHotfixed", DbType.Boolean, WasHotfixed);
            mDatabase.AddInParameter(dbcmd, "@bRolledBack", DbType.Boolean, WasRolledBack);
            rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rowsAffected;
    }

   
    public static DataSet SWIncidentByItemGet(int ItemID)
    {
        DataSet list = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspSWIncidentByItemGet");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);

            list = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return list;
    }

    public static int SWIncidentUpdate(
        int IncidentID,
        bool HadIncident,
        String IncidentDescription,
        int IncidentType,
        bool WasRolledBack,
        bool WasHotfixed,
        String IncidentNumber,
        DateTime IncidentDate
        )
    {
        Int32 rowsAffected = 0;

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspSWIncidentUpdate");
            mDatabase.AddInParameter(dbcmd, "@iIncidentID", DbType.Int32, IncidentID);
            mDatabase.AddInParameter(dbcmd, "@bHasIncident", DbType.Boolean, HadIncident);
            mDatabase.AddInParameter(dbcmd, "@vcIncidentNumber", DbType.String, IncidentNumber);
            mDatabase.AddInParameter(dbcmd, "@sdtIncidentDate", DbType.DateTime, IncidentDate);
            mDatabase.AddInParameter(dbcmd, "@vcIncidentDescription", DbType.String, IncidentDescription);
            mDatabase.AddInParameter(dbcmd, "@bRolledBack", DbType.Boolean, WasRolledBack);
            mDatabase.AddInParameter(dbcmd, "@bHotfixed", DbType.Boolean, WasHotfixed);
            rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rowsAffected;
    }
    

    public static ItemIncident SWIncidentByIncidentIDGet(int IncidentID)
    {
        ItemIncident incident = new ItemIncident();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspSWIncidentByIncidentIDGet");
            mDatabase.AddInParameter(dbcmd, "@iIncidentID", DbType.Int32, IncidentID);

            IDataReader reader = mDatabase.ExecuteReader(dbcmd);
            if (reader.Read())
            {
                incident.IIncidentID = reader["IIncidentID"] == DBNull.Value ? -1 : (int)reader["IIncidentID"];
                incident.IItemID = reader["IItemID"] == DBNull.Value ? -1 : (int)reader["IItemID"];
                incident.VcCRFNumber = reader["vcCRFNumber"] == DBNull.Value ? "" : (string)reader["vcCRFNumber"];
                incident.VcCRPRTDR = reader["vcCRPRTDR"] == DBNull.Value ? "" : (string)reader["vcCRPRTDR"];
                incident.VcDescription = reader["vcDescription"] == DBNull.Value ? "" : (string)reader["vcDescription"];
                incident.VcBuildPackage = reader["vcBuildPackage"] == DBNull.Value ? "" : (String)reader["vcBuildPackage"];
                incident.BHasIncident = reader["BHasIncident"] == DBNull.Value ? null : (bool?)reader["BHasIncident"];
                incident.BRolledBack = reader["BRolledBack"] == DBNull.Value ? null : (bool?)reader["BRolledBack"];
                incident.BHotfixed = reader["BHotfixed"] == DBNull.Value ? null : (bool?)reader["BHotfixed"];
                incident.vcIncidentNumber = reader["vcIncidentNumber"] == DBNull.Value ? "" : (string)reader["vcIncidentNumber"];
                incident.sdtIncidentDate = reader["sdtIncidentDate"] == DBNull.Value ? null : (DateTime?)reader["sdtIncidentDate"];
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return incident;
    }

    public static DataSet SWIncidentsAllGet()
    {
        DataSet list = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspSWIncidentsAllGet");
            list = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return list;
    }
}



public class ItemIncident
{
    String incidentNumber;

    public String vcIncidentNumber
    {
        get { return incidentNumber; }
        set { incidentNumber = value; }
    }
    DateTime? incidentDate;

    public DateTime? sdtIncidentDate
    {
        get
        {
            if (incidentDate.HasValue)
                return incidentDate;
            else
                return null;
        }
        set { incidentDate = value; }
    }



    Int32 iIncidentID;

    public Int32 IIncidentID
    {
        get { return iIncidentID; }
        set { iIncidentID = value; }
    }
    Int32 iItemID;

    public Int32 IItemID
    {
        get { return iItemID; }
        set { iItemID = value; }
    }
    String vcCRFNumber;

    public String VcCRFNumber
    {
        get { return vcCRFNumber; }
        set { vcCRFNumber = value; }
    }
    String vcCRPRTDR;

    public String VcCRPRTDR
    {
        get { return vcCRPRTDR; }
        set { vcCRPRTDR = value; }
    }
    String vcDescription;

    public String VcDescription
    {
        get { return vcDescription; }
        set { vcDescription = value; }
    }
    String vcBuildPackage;

    public String VcBuildPackage
    {
        get { return vcBuildPackage; }
        set { vcBuildPackage = value; }
    }
    bool? bHasIncident;

    public bool? BHasIncident
    {
        get 
        {
            if (bHasIncident.HasValue)
                return bHasIncident;
            else
                return null;
        }
        set { bHasIncident = value; }
    }
    bool? bRolledBack;

    public bool? BRolledBack
    {
        get
        {
            if (bRolledBack.HasValue)
                return bRolledBack;
            else
                return null;
        }
        set { bRolledBack = value; }
    }
    bool? bHotfixed;

    public bool? BHotfixed
    {
        get
        {
            if (bHotfixed.HasValue)
                return bHotfixed;
            else
                return null;
        }
        set { bHotfixed = value; }
    }	
    


    String iNextItemID;
    public String NextItemID
    {
        get { return iNextItemID; }
        set { iNextItemID = value; }
    }
}