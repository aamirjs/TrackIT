using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

public class stbStatus
{
    int iStatusID;
    public int IStatusID
    {
        get { return iStatusID; }
        set { iStatusID = value; }
    }
    string vcStatus;
    public string VcStatus
    {
        get { return vcStatus; }
        set { vcStatus = value; }
    }
    public stbStatus()
    {
    }
}



public class StatusDAL
{
     private static Database mDatabase = DatabaseFactory.CreateDatabase("dbSigma");
	public StatusDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataSet GetStatuses()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspstbStatusGet");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
}
