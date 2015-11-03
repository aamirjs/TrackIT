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


public class IncidentDAL
{
    private static Database mDatabase = DatabaseFactory.CreateDatabase("dbSigma");

    //public static Incidents GetIncidents()
    //{
    //    //Incidents list = new Incidents();

    //    //DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspIncidentGet");

    //    //using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
    //    //{
    //    //    while (reader.Read())
    //    //    {
    //    //        Incident i = new Incident();
    //    //        i.DtIncidentTime = reader["DtIncidentTime"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["DtIncidentTime"];
    //    //        i.DtUpdateTime = reader["DtUpdateTime"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["DtUpdateTime"];
    //    //        i.IIncidentID = reader["IIncidentID"] == DBNull.Value ? -1 : (Int32)reader["IIncidentID"];
    //    //        i.IIncidentLocationID = reader["IIncidentLocationID"] == DBNull.Value ? -1 : (Int32)reader["IIncidentLocationID"];
    //    //        i.IIncidentStatusID = reader["IIncidentStatusID"] == DBNull.Value ? -1 : (Int32)reader["IIncidentStatusID"];
    //    //        i.IIncidentTypeID = reader["IIncidentTypeID"] == DBNull.Value ? -1 : (Int32)reader["IIncidentTypeID"];
    //    //        i.VcOperationalImpact = reader["VcOperationalImpact"] == DBNull.Value ? "" : (String)reader["VcOperationalImpact"];
    //    //        list.Add(i);
    //    //    }
    //    //}
    //    //return list;
    //}
    public static DataSet GetIncidentsDS()
    {

        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspIncidentsGet");
        return mDatabase.ExecuteDataSet(dbcmd);
    }

    public static DataSet GetIncidentTypes()
    {
        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspIncidentTypesGet");
        return mDatabase.ExecuteDataSet(dbcmd);
    }

    public static DataSet GetIncidentLocations(string incidentType)
    {
        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspIncidentLocationsGet");
        mDatabase.AddInParameter(dbcmd, "@vcIncidentType", DbType.String, incidentType);
        return mDatabase.ExecuteDataSet(dbcmd);
    }
    public static DataSet LoadIncidentsByLocation(string incidentType, string Location)
    {
        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspincidentByLocationGet");
        mDatabase.AddInParameter(dbcmd, "@vcIncidentType", DbType.String, incidentType);
        mDatabase.AddInParameter(dbcmd, "@vcLocation", DbType.String, Location);
        return mDatabase.ExecuteDataSet(dbcmd);
    }
    public static Int32 CreateIncident(
        String vcIncidentNumber,
        String vcIncidentType,
        String vcIncidentLocation,
        String vcIncident,
        String vcImpact,
        String vcDescription,
        String dtincidentDate,
        String dtincidentTime
        )
    {
        Int32 iIncidentID = 0;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspIncidentIns");
            mDatabase.AddInParameter(dbcmd, "@vcIncidentNumber", DbType.String, vcIncidentNumber);
            mDatabase.AddInParameter(dbcmd, "@vcIncidentType", DbType.String, vcIncidentType);
            mDatabase.AddInParameter(dbcmd, "@vcIncidentLocation", DbType.String, vcIncidentLocation);
            mDatabase.AddInParameter(dbcmd, "@vcIncident", DbType.String, vcIncident);
            mDatabase.AddInParameter(dbcmd, "@vcImpact", DbType.String, vcImpact);
            mDatabase.AddInParameter(dbcmd, "@vcDescription", DbType.String, vcDescription);
            mDatabase.AddInParameter(dbcmd, "@dtincidentDate", DbType.String, dtincidentDate);
            mDatabase.AddInParameter(dbcmd, "@dtincidentTime", DbType.String, dtincidentTime);
            mDatabase.AddOutParameter(dbcmd, "@iIncidentID", DbType.Int32, 0);

            mDatabase.ExecuteNonQuery(dbcmd);
            iIncidentID = Convert.ToInt32(mDatabase.GetParameterValue(dbcmd, "@iIncidentID"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return iIncidentID;
    }


    public static bool InsertIncidentFile(
        int iIncidentID,
        String vcPath)
    {
        bool done = false;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspIncidentFileIns");
            mDatabase.AddInParameter(dbcmd, "@iIncidentID", DbType.Int32, iIncidentID);
            mDatabase.AddInParameter(dbcmd, "@vcPath", DbType.String, vcPath);
            mDatabase.ExecuteNonQuery(dbcmd);
            done = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return done;
    }



    public static void Delete(int iIncidentID)
    {
        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspDeleteIncidentByID");
        mDatabase.AddInParameter(dbcmd, "@iIncidentID", DbType.Int32, iIncidentID);
        mDatabase.ExecuteNonQuery(dbcmd);
    }

    public static Incident GetIncidentDetailByID(string p)
    {

        /*
         *   iIncidentID	vcIncidentType	    vcIncidentLocation	
             vcIncident	    vcImpact	        vcDescription	
         *   dtincidentDate	iIncidentStatusID	dtUpdateTime 
         */


        Incident obj = new Incident();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspIncidentGetByID");
            mDatabase.AddInParameter(dbcmd, "@iIncidentID", DbType.Int32, p);

            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                if (reader.Read())
                {
                    obj.IIncidentID = reader["iIncidentID"] == DBNull.Value ? -1 : (int)reader["iIncidentID"];
                    obj.VCIncidentNumber = reader["VCIncidentNumber"] == DBNull.Value ? "" : (string)reader["VCIncidentNumber"];
                    obj.VCIncidentType = reader["vcIncidentType"] == DBNull.Value ? "" : (string)reader["vcIncidentType"];
                    obj.VCIncidentLocation = reader["vcIncidentLocation"] == DBNull.Value ? "" : (string)reader["vcIncidentLocation"];
                    obj.VCIncident = reader["vcIncident"] == DBNull.Value ? "" : (string)reader["vcIncident"];
                    obj.VCImpact = reader["vcImpact"] == DBNull.Value ? "" : (string)reader["vcImpact"];
                    obj.VCDescription = reader["vcDescription"] == DBNull.Value ? "" : (string)reader["vcDescription"];
                    obj.DTincidentDate = reader["dtincidentDate"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtincidentDate"];
                    obj.DTIncidentTime = reader["DTIncidentTime"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["DTIncidentTime"];
                    obj.IIncidentStatusID = reader["iIncidentStatusID"] == DBNull.Value ? -1 : (int)reader["iIncidentStatusID"];
                    obj.DtUpdateTime = reader["dtUpdateTime"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtUpdateTime"];

                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return obj;
    }

    public static bool UpdateIncidentDetail(Incident i)
    {
        bool done = false;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspUpdateIncidentDetail");
            mDatabase.AddInParameter(dbcmd, "@IIncidentID", DbType.Int32, i.IIncidentID);
            mDatabase.AddInParameter(dbcmd, "@vcIncidentNumber", DbType.String, i.VCIncidentNumber);
            mDatabase.AddInParameter(dbcmd, "@vcIncidentType", DbType.String, i.VCIncidentType);
            mDatabase.AddInParameter(dbcmd, "@vcIncidentLocation", DbType.String, i.VCIncidentLocation);
            mDatabase.AddInParameter(dbcmd, "@vcIncident", DbType.String, i.VCIncident);
            mDatabase.AddInParameter(dbcmd, "@vcImpact", DbType.String, i.VCImpact);
            mDatabase.AddInParameter(dbcmd, "@vcDescription", DbType.String, i.VCDescription);
            mDatabase.AddInParameter(dbcmd, "@dtincidentDate", DbType.String, i.DTincidentDate);
            mDatabase.ExecuteNonQuery(dbcmd);
            done = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return done;
    }

    public static DataSet GetIncidentStatusList()
    {
        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspIncidentStatusListGet");
        return mDatabase.ExecuteDataSet(dbcmd);
    }

    public static bool UpdateIncidentStatus(string IncidentStatusID, string IncidentID)
    {
        bool done = false;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspIncidentStatusUpd");
            mDatabase.AddInParameter(dbcmd, "@IIncidentID", DbType.Int32, IncidentID);
            mDatabase.AddInParameter(dbcmd, "@iIncidentStatusID", DbType.Int32, IncidentStatusID);
            mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return done;
    }

    public static object GetIncidentHistory(string IncidentID)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspIncidentHistoryGet");
            mDatabase.AddInParameter(dbcmd, "@IIncidentID", DbType.Int32, IncidentID);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
}




