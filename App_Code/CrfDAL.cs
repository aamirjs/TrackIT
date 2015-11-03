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



public class Department
{
    private Int32 iDepartmentID;

    public Int32 DepartmentID
    {
        get { return iDepartmentID; }
        set { iDepartmentID = value; }
    }
    private String vcDepartment;

    public String DepartmentName
    {
        get { return vcDepartment; }
        set { vcDepartment = value; }
    }
}

public class CRFITStatus
{
    private Int32 iCRFStatusID;

    public Int32 CRFStatusID
    {
        get { return iCRFStatusID; }
        set { iCRFStatusID = value; }
    }
    private String vcCRFStatus;

    public String CRFStatus
    {
        get { return vcCRFStatus; }
        set { vcCRFStatus = value; }
    }
}




public class CrfDAL
{
    private static Database mDatabase = DatabaseFactory.CreateDatabase("dbSigma");


    public static List<Department> GetDepartments()
    {
        List<Department> ds = new List<Department>();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetDepartments");
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                while (reader.Read())
                {
                    //iUserID	vcWindowsLogin	vcFirstName	vcLastName	vcEmail
                    Department i = new Department();
                    i.DepartmentID = reader["iDepartmentID"] == DBNull.Value ? -1 : (int)reader["iDepartmentID"];
                    i.DepartmentName = reader["vcDepartment"] == DBNull.Value ? "" : (string)reader["vcDepartment"];
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


    public static DataSet GetCRFs()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetCRFs");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public static string CRFInsert(
                                    String CRFNumber,
                                    int iDepartmentID, 
                                    String sdtDeploymentDate, 
                                    String dtDeploymentTime, 
                                    String vcDescription 
                                    //int iCRFStatusID
                                    )
    {
        string message = "Success";
        try
        {
            
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspCRFITIns");
            mDatabase.AddInParameter(dbcmd, "@iDepartmentID", DbType.Int32, iDepartmentID);
            mDatabase.AddInParameter(dbcmd, "@sdtDeploymentDate", DbType.DateTime, sdtDeploymentDate);
            mDatabase.AddInParameter(dbcmd, "@dtDeploymentTime", DbType.DateTime, dtDeploymentTime);
            mDatabase.AddInParameter(dbcmd, "@vcDescription", DbType.String, vcDescription);
            mDatabase.AddInParameter(dbcmd, "@vcCRFNo", DbType.String, CRFNumber);
            //mDatabase.AddInParameter(dbcmd, "@iCRFStatusID", DbType.Int32, iCRFStatusID);
            mDatabase.ExecuteScalar(dbcmd);
        }
        catch (Exception exp)
        {
            message = exp.Message + "<br>" + exp.Source + "<br>" + exp.StackTrace;
        }
        return message;
    }

    public static List<CRFITStatus> GetCRFITStatus()
    {
        List<CRFITStatus> ds = new List<CRFITStatus>();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetCRFStatus");
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                while (reader.Read())
                {
                    //iUserID	vcWindowsLogin	vcFirstName	vcLastName	vcEmail
                    CRFITStatus i = new CRFITStatus();
                    i.CRFStatusID = reader["iCRFStatusId"] == DBNull.Value ? Convert.ToInt32(-1) : (Int32)reader["iCRFStatusId"];
                    i.CRFStatus = reader["vcCRFStatus"] == DBNull.Value ? "" : (string)reader["vcCRFStatus"];
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

    public static String DeleteCRFRecord(Int32 CRFID)
    {
        string message = "Record successfully deleted.";
        try
        {

            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspCRFITDel");
            mDatabase.AddInParameter(dbcmd, "@iCRFID", DbType.Int32, CRFID);
            mDatabase.ExecuteScalar(dbcmd);
        }
        catch (Exception exp)
        {
            message = exp.Message + "<br>" + exp.Source + "<br>" + exp.StackTrace;
        }
        return message;
 
    }
}