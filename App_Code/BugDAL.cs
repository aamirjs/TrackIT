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
    /// Summary description for Bug
    /// </summary>
    public class Bug
    {
        int iBugID;

        public int IBugID
        {
            get { return iBugID; }
            set { iBugID = value; }
        }
        int iItemID;

        short _siQACount;

        public short SiQACount
        {
            get { return _siQACount; }
            set { _siQACount = value; }
        }
        short _siUATCount;
        public short SiUATCount
        {
            get { return _siUATCount; }
            set { _siUATCount = value; }
        }
        short _siINTCount;
        public short SiINTCount
        {
            get { return _siINTCount; }
            set { _siINTCount = value; }
        }
        short _siPDCount;
        public short SiPDCount
        {
            get { return _siPDCount; }
            set { _siPDCount = value; }
        }
        
       
        public int IItemID
        {
            get { return iItemID; }
            set { iItemID = value; }
        }
        //int iBugStatusID;

        //public int IBugStatusID
        //{
        //    get { return iBugStatusID; }
        //    set { iBugStatusID = value; }
        //}
        String _vcQAPhase;

        public String vcQAPhaseSumm
        {
            get { return _vcQAPhase; }
            set { _vcQAPhase = value; }
        }
        String _vcUATPhase;

        public String vcUATPhaseSumm
        {
            get { return _vcUATPhase; }
            set { _vcUATPhase = value; }
        }
        String _vcINTPhase;

        public String vcINTPhaseSumm
        {
            get { return _vcINTPhase; }
            set { _vcINTPhase = value; }
        }
        String _PostDepPhase;

        public String vcPostDepPhaseSumm
        {
            get { return _PostDepPhase; }
            set { _PostDepPhase = value; }
        }

        public Bug()
        {
        }
    }
    public class BugsDAL
    {
        private static Database mDatabase = DatabaseFactory.CreateDatabase("dbSigma");
        public static int AddBug(Bug b)
        {
            Int32 rowsAffected = 0;

            try
            {
                DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspAddBug");
                mDatabase.AddInParameter(dbcmd, "@IItemID", DbType.String, b.IItemID);
                mDatabase.AddInParameter(dbcmd, "@VcQAPhaseSumm", DbType.String, b.vcQAPhaseSumm);
                mDatabase.AddInParameter(dbcmd, "@VcUATPhaseSumm", DbType.String, b.vcUATPhaseSumm);
                mDatabase.AddInParameter(dbcmd, "@VcPostDepPhaseSumm", DbType.String, b.vcPostDepPhaseSumm);
                mDatabase.AddInParameter(dbcmd, "@vcIntPhaseSumm", DbType.String, b.vcINTPhaseSumm);

                mDatabase.AddInParameter(dbcmd, "@siQACount", DbType.Int16, b.SiQACount);
                mDatabase.AddInParameter(dbcmd, "@siUATCount", DbType.Int16, b.SiUATCount);
                mDatabase.AddInParameter(dbcmd, "@siPDCount", DbType.Int16, b.SiPDCount);
                mDatabase.AddInParameter(dbcmd, "@siIntCount", DbType.Int16, b.SiINTCount);

                rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsAffected;
        }
        public static int UpdateBug(Bug b)
        {
            Int32 rowsAffected = 0;

            try
            {
                DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspUpdateBug");
                mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, b.IItemID);
                mDatabase.AddInParameter(dbcmd, "@iBugID", DbType.Int32, b.IBugID);
                mDatabase.AddInParameter(dbcmd, "@VcQAPhaseSumm", DbType.String, b.vcQAPhaseSumm);
                mDatabase.AddInParameter(dbcmd, "@VcUATPhaseSumm", DbType.String, b.vcUATPhaseSumm);
                mDatabase.AddInParameter(dbcmd, "@VcINTPhaseSumm", DbType.String, b.vcINTPhaseSumm);
                mDatabase.AddInParameter(dbcmd, "@VcPostDepPhaseSumm", DbType.String, b.vcPostDepPhaseSumm);

                mDatabase.AddInParameter(dbcmd, "@siQACount", DbType.Int16, b.SiQACount);
                mDatabase.AddInParameter(dbcmd, "@siUATCount", DbType.Int16, b.SiUATCount);
                mDatabase.AddInParameter(dbcmd, "@siINTCount", DbType.Int16, b.SiINTCount);
                mDatabase.AddInParameter(dbcmd, "@siPDCount", DbType.Int16, b.SiPDCount);

                rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsAffected;
        }
        public static int DeleteBug(int iBugID)
        {
            int rows = 0;
            try
            {
                DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspDeleteBug");
                mDatabase.AddInParameter(dbcmd, "@iBugID", DbType.Int32, iBugID);
                rows = mDatabase.ExecuteNonQuery(dbcmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rows;
        }
        public static DataSet GetBugsByItem(int iItemID)
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemBugs");
                mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iItemID);
                ds = mDatabase.ExecuteDataSet(dbcmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }
        public static DataSet GetStbBugsStatus()
        {
            DataSet ds = new DataSet();
            try
            {
                DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetStbBugsStatus");
                ds = mDatabase.ExecuteDataSet(dbcmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }


        public static String CheckBugStatus(int ItemID)
        {
            String result = String.Empty;
            try
            {
                DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspCheckBugsStatus");
                mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
                using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
                {
                    if (reader.Read())
                    {
                        result = reader["result"] == DBNull.Value ? String.Empty : (String)reader["result"];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
  