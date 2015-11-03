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


public class CCBDAL
{
    private static Database mDatabase = DatabaseFactory.CreateDatabase("dbSigma");


    public static DataSet GetCCBItems(string crit)
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetCCBItems");
            mDatabase.AddInParameter(dbcmd, "@vcCriteria", DbType.String, crit);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }
}
