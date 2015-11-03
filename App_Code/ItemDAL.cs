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


public class ItemDAL
{
    private static Database mDatabase = DatabaseFactory.CreateDatabase("dbSigma");


    public static DataSet GetIncidents()
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetIncidents");
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


    public static DataSet GetBuildSummary()
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetBuildSummary");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }


    public static void GeneratePDC(int ItemID)
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGeneratePDC");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static string UpdateItemStatus(Item i, bool SendUpdate)
    {
        string message = "Success";
        try
        {

            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspUpdateItemStatus");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, i.ItemID);
            mDatabase.AddInParameter(dbcmd, "@iStatusID", DbType.Int32, i.StatusID);
            mDatabase.AddInParameter(dbcmd, "@dtStatusTime", DbType.DateTime, i.StatusTime);
            mDatabase.AddInParameter(dbcmd, "@vcOwner", DbType.String, "");
            mDatabase.AddInParameter(dbcmd, "@vcComments", DbType.String, i.Comments);
            mDatabase.AddInParameter(dbcmd, "@bSendUpdate", DbType.Boolean, SendUpdate);
            mDatabase.ExecuteScalar(dbcmd);

            //message = Convert.ToString(mDatabase.GetParameterValue(dbcmd, "@vcErrorMessage"));
        }
        catch (Exception exp)
        {
            message = exp.Message + "<br>" + exp.Source + "<br>" + exp.StackTrace;
        }
        return message;
    }

    //public static string UpdateItemStatus(Item i)
    //{
    //    string message = "Success";
    //    try
    //    {

    //        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspUpdateItemStatus");
    //        mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, i.ItemID);
    //        mDatabase.AddInParameter(dbcmd, "@iStatusID", DbType.Int32, i.StatusID);
    //        mDatabase.AddInParameter(dbcmd, "@dtStatusTime", DbType.DateTime, i.dtStatusTime);
    //        mDatabase.AddInParameter(dbcmd, "@vcOwner", DbType.String, "");
    //        mDatabase.AddInParameter(dbcmd, "@vcComments", DbType.String, i.Comments);
    //        //mDatabase.AddOutParameter(dbcmd, "@vcErrorMessage", DbType.String, 1000);
    //        mDatabase.ExecuteScalar(dbcmd);

    //        //message = Convert.ToString(mDatabase.GetParameterValue(dbcmd, "@vcErrorMessage"));
    //    }
    //    catch (Exception exp)
    //    {
    //        message = exp.Message + "<br>" + exp.Source + "<br>" + exp.StackTrace;
    //    }
    //    return message;
    //}
    public static DataSet GetItemHistoryByCRPRTDR(string vcCRPRTDR)
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemHistByCRPRTDR");
            mDatabase.AddInParameter(dbcmd, "@vcCRPRTDR", DbType.String, vcCRPRTDR);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }
    public static DataSet GetItemHistory(Int32 iItemID, Int32 StatusID )
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemStates");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iItemID);
            mDatabase.AddInParameter(dbcmd, "@iStatusID", DbType.Int32, StatusID);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }
    public static int ResetItemHistoryState(string HistoryID, String itemID)
    {
        int rows = 0;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspResetItemHistoryState");
            mDatabase.AddInParameter(dbcmd, "@iItemHistID", DbType.Int32, (HistoryID == "" ? -1 : Convert.ToInt32(HistoryID)));
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, Convert.ToInt32(itemID));
            rows = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return rows;
    }

    public static int DeleteDelayRecord(string HistID, String ItemID)
    {
        int rows = 0;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspDeleteDelayRecord");
            mDatabase.AddInParameter(dbcmd, "@DeploymentDelayHistID", DbType.Int32, Convert.ToInt32(HistID));
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, Convert.ToInt32(ItemID));
            rows = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return rows;
    }

    public static int DeleteRemark(string RemarkID, String itemID)
    {
        int rows = 0;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspDeleteRemark");
            mDatabase.AddInParameter(dbcmd, "@iItemRemarksID", DbType.Int32, (RemarkID == "" ? -1 : Convert.ToInt32(RemarkID)));
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, Convert.ToInt32(itemID));
            rows = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return rows;
    }
    public static int DeletePDCRemark(string iPDCRemarkID, String itemID)
    {
        int rows = 0;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPDCRemarkDel");
            mDatabase.AddInParameter(dbcmd, "@iPDCRemarkID", DbType.Int32, (iPDCRemarkID == "" ? -1 : Convert.ToInt32(iPDCRemarkID)));
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, Convert.ToInt32(itemID));
            rows = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return rows;
    }
    
    public static int DeleteItemHistory(string iItemID)
    {
        int rows = 0;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspDeleteItemStatusHistory");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iItemID);
            rows = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return rows;
    }
    public static string Insert(
        String TypeOfItem,
        String CRF,
        String Team,
        String Description,
        String Detailedscription,
        String Build,
        String RelatedItems, 
        List<User> DevList,
        String Severity, 
        String Priority, 
        String ChargeNumber, 
        String CustomerReferenceNumber,
        String EstimatedEffortHours, 
        String PercentComplete
        )
    {
        String vcNewSequence = "";
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspCreateItem");
            mDatabase.AddInParameter(dbcmd, "@vcTypeOfItem", DbType.String, TypeOfItem);
            mDatabase.AddInParameter(dbcmd, "@vcCRFNumber", DbType.String, CRF);
            mDatabase.AddInParameter(dbcmd, "@vcTeam", DbType.String, Team);
            mDatabase.AddInParameter(dbcmd, "@vcDescription", DbType.String, Description);
            mDatabase.AddInParameter(dbcmd, "@vcDetailDescription", DbType.String, Detailedscription);
            mDatabase.AddInParameter(dbcmd, "@vcBuildPackage", DbType.String, Build);
            mDatabase.AddInParameter(dbcmd, "@vcRelatedItems", DbType.String, RelatedItems);
            mDatabase.AddInParameter(dbcmd, "@siSeverity", DbType.Int16, Severity);
            mDatabase.AddInParameter(dbcmd, "@siPriority", DbType.Int16, Priority);
            mDatabase.AddInParameter(dbcmd, "@siEstimatedHours", DbType.Int16, EstimatedEffortHours);
            mDatabase.AddInParameter(dbcmd, "@siPercentComplete", DbType.Int16, PercentComplete);
            mDatabase.AddInParameter(dbcmd, "@vcChargeNumber", DbType.String, ChargeNumber);
            mDatabase.AddInParameter(dbcmd, "@vcCustRefNumber", DbType.String, CustomerReferenceNumber);
            //mDatabase.AddInParameter(dbcmd, "@ActualEffort", DbType.String, ActualEffort);

            StringBuilder developers = new StringBuilder();
            developers.Append("<ROOT>");
            foreach (User obj in DevList)
            {
                //developers.Append("<dev devID=\"" + obj.UserID + "\" itemid=\"" + _CRPRTDR + "\"></dev>");
                developers.Append("<dev devID=\"" + obj.UserID + "\" ></dev>");
            }
            developers.Append("</ROOT>");
            mDatabase.AddInParameter(dbcmd, "@vcOwnedBy", DbType.String, developers.ToString());


            mDatabase.AddOutParameter(dbcmd, "@vcNewSequence", DbType.String, 10);
            mDatabase.ExecuteNonQuery(dbcmd);
            vcNewSequence = mDatabase.GetParameterValue(dbcmd, "@vcNewSequence").ToString();
        }
        catch (Exception ex)
        {
            vcNewSequence = ex.Message;
        }
        return vcNewSequence;
    }
    public static void Delete(int _ID)
    {
        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspDeleteItem");
        mDatabase.AddInParameter(dbcmd, "@ID", DbType.Int32, _ID);
        mDatabase.ExecuteNonQuery(dbcmd);
    }
    public static List<Item> GetListOfCRPRTDR()
    {
        List<Item> list = new List<Item>();

        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetCRPRTDR");

        using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
        {
            while (reader.Read())
            {
                Item i = new Item();
                i.CRPRTDR = reader["vcCRPRTDR"] == DBNull.Value ? "" : (string)reader["vcCRPRTDR"];
                i.ItemID = reader["iItemID"] == DBNull.Value ? -1 : (int)reader["iItemID"];
                list.Add(i);
            }
        }
        return list;
    }
    public static List<Item> GetListOfCRPRTDR(string criteria)
    {
        List<Item> list = new List<Item>();

        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetCRPRTDRFil");
        mDatabase.AddInParameter(dbcmd, "@vcCriteria", DbType.String, criteria);
        using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
        {
            while (reader.Read())
            {
                Item i = new Item();
                i.CRPRTDR = reader["vcCRPRTDR"] == DBNull.Value ? "" : (string)reader["vcCRPRTDR"];
                i.ItemID = reader["iItemID"] == DBNull.Value ? -1 : (int)reader["iItemID"];
                list.Add(i);
            }
        }
        return list;
    }

    public static DataSet GetCRPRTDRDataSet()
    {
        List<Item> list = new List<Item>();

        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetCRPRTDR");

        DataSet ds = new DataSet();
        ds = mDatabase.ExecuteDataSet(dbcmd);
        return ds;
    }
    public static DataSet GetCRPRTDRByBuild(String Build)
    {
        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetCRPRTDRByBuild");
        mDatabase.AddInParameter(dbcmd, "@vcBuild", DbType.Int32, Build);
        DataSet ds = new DataSet();
        ds = mDatabase.ExecuteDataSet(dbcmd);
        return ds;
    }
    public static DataSet GetItem()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItems");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static List<Item> SearchItemByBuild(string Build)
    {
        List<Item> list = new List<Item>();
        DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspSearchByBuild");
        IDataReader reader = mDatabase.ExecuteReader(dbcmd);
        while (reader.Read())
        {
            Item item = new Item();
            item.ItemID = reader["iItemID"] == DBNull.Value ? -1 : (int)reader["iItemID"];
            item.Build_Package = reader["vcBuildPackage"] == DBNull.Value ? "" : (String)reader["vcBuildPackage"];
            item.CRF_No = reader["vcCRFNumber"] == DBNull.Value ? "" : (string)reader["vcCRFNumber"];
            item.CRPRTDR = reader["vcCRPRTDR"] == DBNull.Value ? "" : (string)reader["vcCRPRTDR"];
            item.Description = reader["vcDescription"] == DBNull.Value ? "" : (string)reader["vcDescription"];
            item.Related_Items = reader["vcRelatedItems"] == DBNull.Value ? "" : (String)reader["vcRelatedItems"];
            item.Team = reader["vcTeam"] == DBNull.Value ? "" : (String)reader["vcTeam"];
            item.Status = reader["vcStatus"] == DBNull.Value ? "" : (string)reader["vcStatus"];
            item.StatusTime = reader["dtStatusTime"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtStatusTime"];
            list.Add(item);
        }

        return list;
    }
    public static DataSet GetItemByCRPRTDR(string CRPRTDR)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemByCRPRTDR");
            mDatabase.AddInParameter(dbcmd, "@vcCRPRTDR", DbType.String, CRPRTDR);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetBuildItemStatus()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspBuildSummary");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetBuildNames()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspBuildGet");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static List<Item> SearchByItemID(string itemID)
    {
        List<Item> list = new List<Item>();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspSearchItems");
            mDatabase.AddInParameter(dbcmd, "@vcItemID", DbType.String, itemID);
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {

                while (reader.Read())
                {
                    Item item = new Item();
                    item.ItemID = reader["iItemID"] == DBNull.Value ? -1 : (int)reader["iItemID"];
                    item.Build_Package = reader["vcBuildPackage"] == DBNull.Value ? "" : (String)reader["vcBuildPackage"];
                    item.CRF_No = reader["vcCRFNumber"] == DBNull.Value ? "" : (string)reader["vcCRFNumber"];
                    item.CRPRTDR = reader["vcCRPRTDR"] == DBNull.Value ? "" : (string)reader["vcCRPRTDR"];
                    item.Description = reader["vcDescription"] == DBNull.Value ? "" : (string)reader["vcDescription"];
                    item.Related_Items = reader["vcRelatedItems"] == DBNull.Value ? "" : (String)reader["vcRelatedItems"];
                    item.Team = reader["vcTeam"] == DBNull.Value ? "" : (String)reader["vcTeam"];
                    item.Status = reader["vcStatus"] == DBNull.Value ? "" : (string)reader["vcStatus"];
                    item.StatusID = reader["iStatusID"] == DBNull.Value ? -1 : (int)reader["iStatusID"];
                    item.StatusTime = reader["dtStatusTime"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtStatusTime"];
                    list.Add(item);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return list;
    }
    public static DataSet SearchByStatusID(string iStatusID)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspSearchByStatusID");
            mDatabase.AddInParameter(dbcmd, "@iStatusID", DbType.Int32, Convert.ToInt32(iStatusID));
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetStatusByBuild(string Build)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetStatusByBuild");
            mDatabase.AddInParameter(dbcmd, "@vcBuild", DbType.String, Build);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet SearchByStatusIDInRange(string iStatusID, string from, string To)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspSearchByStatusIDInRange");
            mDatabase.AddInParameter(dbcmd, "@iStatusID", DbType.Int32, Convert.ToInt32(iStatusID));
            mDatabase.AddInParameter(dbcmd, "@vcFromDate", DbType.DateTime, from);
            mDatabase.AddInParameter(dbcmd, "@vcToDate", DbType.DateTime, To);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetNewlyCreatedItems(int rows)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspNewlyCreatedItems");
            mDatabase.AddInParameter(dbcmd, "iCount", DbType.Int32, rows);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }



    public static int UpdateItemDetails(Item i)
    {
        Int32 rowsAffected = 0;

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspUpdateItemDetails");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, i.ItemID);
            //mDatabase.AddInParameter(dbcmd, "@vcTypeOfItem", DbType.String, i.Type);
            mDatabase.AddInParameter(dbcmd, "@vcCRFNumber", DbType.String, i.CRF_No);
            mDatabase.AddInParameter(dbcmd, "@vcDescription", DbType.String, i.Description);
            mDatabase.AddInParameter(dbcmd, "@vcDetailDescription", DbType.String, i.DetailDescription);
            mDatabase.AddInParameter(dbcmd, "@vcBuildPackage", DbType.String, i.Build_Package);
            mDatabase.AddInParameter(dbcmd, "@vcRelatedItems", DbType.String, i.Related_Items);
            mDatabase.AddInParameter(dbcmd, "@iEstimatedHours", DbType.Int32, i.EstimatedHours);
            mDatabase.AddInParameter(dbcmd, "@siSeverity", DbType.Int16, i.Severity);
            mDatabase.AddInParameter(dbcmd, "@siPriority", DbType.Int16, i.Priority);
            //mDatabase.AddInParameter(dbcmd, "@dcRank", DbType.Decimal, i.Rank);
            mDatabase.AddInParameter(dbcmd, "@iPercentComplete", DbType.Int32, i.PercentComplete);

            if(i.DeployDate.Year > 1900)
                mDatabase.AddInParameter(dbcmd, "@dtDeployDate", DbType.DateTime, i.DeployDate);

            mDatabase.AddInParameter(dbcmd, "@vcCrossGenericRelation", DbType.String, i.CrossGenericRelation);
            mDatabase.AddInParameter(dbcmd, "@vcDependentRelation", DbType.String, i.DependentRelation);
            mDatabase.AddInParameter(dbcmd, "@vcChargeNumber", DbType.String, i.ChargeNumber);
            mDatabase.AddInParameter(dbcmd, "@vcCustRefNumber", DbType.String, i.CustomerReferenceNumber);
            mDatabase.AddInParameter(dbcmd, "@iActualEffortHours", DbType.Int32, i.ActualEffortHours);



            StringBuilder developers = new StringBuilder();
            developers.Append("<ROOT>");
            foreach (User obj in i.Developers)
            {
                developers.Append("<dev devID=\"" + obj.UserID + "\" itemid=\"" + i.ItemID + "\"></dev>");
            }
            developers.Append("</ROOT>");
            mDatabase.AddInParameter(dbcmd, "@vcTeam", DbType.String, i.Team);
            mDatabase.AddInParameter(dbcmd, "@vcOwnedBy", DbType.String, developers.ToString());

            rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rowsAffected;
    }
    public static DataSet GetItemDetailDataSet(String ItemID)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemDetails");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }

    public static DataSet GetDelayInformation(Int32 ItemID)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetDelayInformation");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }
    
    public static int AddTicket(int ItemID, String TicketNumber)
    {
        DataSet ds = new DataSet();
        int rows = 0;
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspAddTicket");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            mDatabase.AddInParameter(dbcmd, "@vcTicketNumber", DbType.String, TicketNumber);
            rows = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rows;        
    }
    

    public static DataSet TicketsGet(int ItemID)
    {
        DataSet ds = new DataSet();
        try
        {

            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspTicketsByItem");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);

            StringBuilder Tickets = new StringBuilder();


            int count = 0;
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                while (reader.Read())
                {
                    Tickets.Append("'"+(String)reader["vcTicketNumber"].ToString()+"',");
                    count++;
                }
            }


            if (count > 0)
            {
                String tickets = Tickets.ToString().TrimEnd(',');

                Database mDatabaseOTRS = DatabaseFactory.CreateDatabase("OTRS");
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OTRS"].ConnectionString);

                string Sql = @"SELECT T.tn Ticket#,TS.name State,U.first_name +  ' '+ U.last_name Who,Convert(varchar,T.change_time, 106) AS [When]
                            FROM [DXBCSCSTGDB02].OTRS.dbo.ticket_state AS TS WITH (nolock) JOIN 
                            [DXBCSCSTGDB02].OTRS.dbo.[tickeT ] AS T WITH (nolock) ON T.ticket_state_id = TS.id INNER JOIN
                            [DXBCSCSTGDB02].OTRS.dbo.users U WITH (nolock) ON U.id = T.change_by
                            WHERE T.tn IN (" + tickets + ")";
                ds = mDatabaseOTRS.ExecuteDataSet(CommandType.Text, Sql);
                foreach (DataRow r in ds.Tables[0].Rows) {
                    string Ticket = r["Ticket#"].ToString();
                    string State = r["State"].ToString();
                    string when = r["When"].ToString();
                    String who = r["Who"].ToString();

//                    if (State.Equals("Closed Successfully"))
//                    {

//                        DataSet ds2 = ItemDAL.GetItemHistory(ItemID, 36);
//                        if (ds2.Tables[0].Rows[0]["iItemHistID"] == null)
//                        {

//                            Item i = new Item();
//                            i.ItemID = ItemID;
//                            i.StatusID = 36; //Close HD Ticket Done
//                            i.dtStatusTime = DateTime.Parse(when);
//                            i.Comments = who;

//                            UpdateItemStatus(i, false);
//                        }
//                    }
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }



    public static Item GetItemByName(String CRPRTDR)
    {
        Item item = new Item();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemByName");
            mDatabase.AddInParameter(dbcmd, "@vcCRPRTDR", DbType.String, CRPRTDR);
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                if (reader.Read())
                {
                    item.ItemID = reader["iItemID"] == DBNull.Value ? -1 : (int)reader["iItemID"];
                    item.Type = reader["vcItemType"] == DBNull.Value ? "" : (String)reader["vcItemType"];
                    item.NumberSequence = reader["iNumberSequence"] == DBNull.Value ? -1 : (int)reader["iNumberSequence"];
                    item.CRPRTDR = reader["vcCRPRTDR"] == DBNull.Value ? "" : (String)reader["vcCRPRTDR"];
                    item.CRF_No = reader["vcCRFNumber"] == DBNull.Value ? "" : (String)reader["vcCRFNumber"];
                    item.Description = reader["vcDescription"] == DBNull.Value ? "" : (String)reader["vcDescription"];
                    item.DetailDescription = reader["vcDetailDescription"] == DBNull.Value ? "" : (String)reader["vcDetailDescription"];
                    item.Build_Package = reader["vcBuildPackage"] == DBNull.Value ? "" : (String)reader["vcBuildPackage"];
                    item.Related_Items = reader["vcRelatedItems"] == DBNull.Value ? "" : (String)reader["vcRelatedItems"];
                    item.StatusID = reader["iStatusID"] == DBNull.Value ? -1 : (int)reader["iStatusID"];
                    item.StatusTime = reader["dtStatusTime"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtStatusTime"];
                    item.OwnedBy = reader["vcOwnedBy"] == DBNull.Value ? "" : (String)reader["vcOwnedBy"];
                    item.UpdateTime = reader["dtUpdateTime"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtUpdateTime"];
                    item.ParentID = reader["iParentID"] == DBNull.Value ? -1 : (int)reader["iParentID"];
                    item.ScheduledDeploymentDate = reader["sdtScheduledDeploymentDate"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["sdtScheduledDeploymentDate"];
                    item.EstimatedHours = reader["iEstimatedHours"] == DBNull.Value ? -1 : (int)reader["iEstimatedHours"];
                    item.Severity = reader["siSeverity"] == DBNull.Value ? (short)-1 : (Int16)reader["siSeverity"];
                    item.Priority = reader["siPriority"] == DBNull.Value ? (short)-1 : (Int16)reader["siPriority"];
                    item.Rank = reader["dcRank"] == DBNull.Value ? (Decimal)0.00 : (Decimal)reader["dcRank"];
                    item.PercentComplete = reader["iPercentComplete"] == DBNull.Value ? -1 : (int)reader["iPercentComplete"];
                    item.DeployDate = reader["dtDeployDate"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtDeployDate"];
                    item.CrossGenericRelation = reader["vcCrossGenericRelation"] == DBNull.Value ? "" : (String)reader["vcCrossGenericRelation"];
                    item.DependentRelation = reader["vcDependentRelation"] == DBNull.Value ? "" : (String)reader["vcDependentRelation"];
                    item.ChargeNumber = reader["vcChargeNumber"] == DBNull.Value ? "" : (String)reader["vcChargeNumber"];
                    item.CustomerReferenceNumber = reader["vcCustRefNumber"] == DBNull.Value ? "" : (String)reader["vcCustRefNumber"];
                    item.ActualEffortHours = reader["iActualEffortHours"] == DBNull.Value ? -1 : (int)reader["iActualEffortHours"];
                    item.CreateDate = reader["dtCreateDate"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtCreateDate"];
                    item.Team = reader["vcTeam"] == DBNull.Value ? "" : (String)reader["vcTeam"];

                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return item;
    }
    public static Item GetItemByID(int ItemID)
    {
        Item item = new Item();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemByID");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                if (reader.Read())
                {
                    item.ItemID = reader["iItemID"]== DBNull.Value ? -1 : (int)reader["iItemID"];
                    item.Type = reader["vcItemType"] == DBNull.Value ? "" : (String)reader["vcItemType"];
                    item.NumberSequence = reader["iNumberSequence"] == DBNull.Value ? -1 : (int)reader["iNumberSequence"];
                    item.CRPRTDR = reader["vcCRPRTDR"] == DBNull.Value ? "" : (String)reader["vcCRPRTDR"];
                    item.CRF_No = reader["vcCRFNumber"] == DBNull.Value ? "" : (String)reader["vcCRFNumber"];
                    item.Description = reader["vcDescription"] == DBNull.Value ? "" : (String)reader["vcDescription"];
                    item.DetailDescription = reader["vcDetailDescription"] == DBNull.Value ? "" : (String)reader["vcDetailDescription"];
                    item.Build_Package = reader["vcBuildPackage"] == DBNull.Value ? "" : (String)reader["vcBuildPackage"];
                    item.Related_Items = reader["vcRelatedItems"] == DBNull.Value ? "" : (String)reader["vcRelatedItems"];
                    item.StatusID = reader["iStatusID"] == DBNull.Value ? -1 : (int)reader["iStatusID"];
                    item.StatusTime = reader["dtStatusTime"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtStatusTime"];
                    item.OwnedBy = reader["vcOwnedBy"] == DBNull.Value ? "" : (String)reader["vcOwnedBy"];
                    item.UpdateTime = reader["dtUpdateTime"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtUpdateTime"];
                    item.ParentID = reader["iParentID"] == DBNull.Value ? -1 : (int)reader["iParentID"];
                    item.ScheduledDeploymentDate = reader["sdtScheduledDeploymentDate"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["sdtScheduledDeploymentDate"];
                    item.EstimatedHours = reader["iEstimatedHours"] == DBNull.Value ? -1 : (int)reader["iEstimatedHours"];
                    item.Severity = reader["siSeverity"] == DBNull.Value ? (short)-1 : (Int16)reader["siSeverity"];
                    item.Priority = reader["siPriority"] == DBNull.Value ? (short)-1 : (Int16)reader["siPriority"];
                    item.Rank = reader["dcRank"] == DBNull.Value ? (Decimal)0.00 : (Decimal)reader["dcRank"];
                    item.PercentComplete = reader["iPercentComplete"] == DBNull.Value ? -1 : (int)reader["iPercentComplete"];
                    item.DeployDate = reader["dtDeployDate"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtDeployDate"];
                    item.CrossGenericRelation = reader["vcCrossGenericRelation"] == DBNull.Value ? "" : (String)reader["vcCrossGenericRelation"];
                    item.DependentRelation = reader["vcDependentRelation"] == DBNull.Value ? "" : (String)reader["vcDependentRelation"];
                    item.ChargeNumber = reader["vcChargeNumber"] == DBNull.Value ? "" : (String)reader["vcChargeNumber"];
                    item.CustomerReferenceNumber = reader["vcCustRefNumber"] == DBNull.Value ? "" : (String)reader["vcCustRefNumber"];
                    item.ActualEffortHours = reader["iActualEffortHours"] == DBNull.Value ? -1 : (int)reader["iActualEffortHours"];
                    item.CreateDate = reader["dtCreateDate"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtCreateDate"];
                    item.Team = reader["vcTeam"] == DBNull.Value ? "" : (String)reader["vcTeam"];

                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return item;
    }
    public static DataSet GetItemsExcel()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemsExcel");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetItemPendingCRFApprovals()
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPendingCRFApprovals");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }
    public static DataSet GetItemsPendingPropRCAApprovals()
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPendingPropRCAApprovals");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }
    public static DataSet GetItemsPendingToSendCRF()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPendingToSendCRF");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetItemsPendingDBAReview()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPendingDBAReview");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetTypeCounts()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetTypeCounts");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetItemsDump(string type)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemsDump");
            mDatabase.AddInParameter(dbcmd, "@vcType", DbType.String, type);
            ds = mDatabase.ExecuteDataSet(dbcmd);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetPrevousWeekDeployments()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPrevWeekDeployment");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetThisWeekDeployments()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspThisWeekDeployment");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetPendingPDCItems()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPendingPDCItems");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetPendingPDCTickets()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPendingPDCTickets");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public static DataSet GetThisWeekItems()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspItemMovedThisWeek");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetItemsPendingDeployment()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspItemsPendingDeployment");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static int AddRemark(Item i)
    {
        Int32 rowsAffected = 0;

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspAddRemarks");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, i.ItemID);
            mDatabase.AddInParameter(dbcmd, "@vcRemark", DbType.String, i.Comments);
            rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rowsAffected;
    }

    public static int AddPDCRemark(Item i)
    {
        Int32 rowsAffected = 0;

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPDCRemarkIns");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, i.ItemID);
            mDatabase.AddInParameter(dbcmd, "@vcRemark", DbType.String, i.PDCRemark);
            rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rowsAffected;
    }
    public static int UpdatePDCRemark(int iPDCRemarkID, int iItemID, string Remark)
    {
        Int32 rowsAffected = 0;

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPDCRemarkUpd");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iPDCRemarkID);
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iItemID);
            mDatabase.AddInParameter(dbcmd, "@vcRemark", DbType.String, Remark);
            rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rowsAffected;
    }



    public static DataSet GetRemarks(string p)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetRemarks");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, p);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    
    public static DataSet GetPDCRemarks(string ItemID)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPDCRemarkGet");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet ItemsNotMergedInTrunk()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspItemsNotMergedInTrunk");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetPostDeployment()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPostDeployment");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet ViewAllItems()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspViewAllItems");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetPreDeployment()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPreDeployment");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetItemsPendingDeploymentPreparation()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPendingDeploymentPreparation");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataTable GetItemsByStage(int iStage, String Build)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspItemsByStage");
            mDatabase.AddInParameter(dbcmd, "@iStage", DbType.Int32, iStage);
            mDatabase.AddInParameter(dbcmd, "@vcBuild", DbType.String, Build);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds.Tables[0];
    }
    public static DataTable GetItemsByCode(string code)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspItemsByStatusCode");
            mDatabase.AddInParameter(dbcmd, "@StatusCode", DbType.String, code);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds.Tables[0];
    }
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {

        List<string> list = new List<string>();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspSearchItemName");
            mDatabase.AddInParameter(dbcmd, "@vcprefixText", DbType.String, prefixText);
            mDatabase.AddInParameter(dbcmd, "@iCount", DbType.Int32, count);
            mDatabase.AddInParameter(dbcmd, "@vcContextKey", DbType.String, contextKey);
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                while (reader.Read())
                {
                    //item.ItemID = reader["iItemID"] == DBNull.Value ? -1 : (int)reader["iItemID"];
                    //item.Build_Package = reader["vcBuildPackage"] == DBNull.Value ? "" : (String)reader["vcBuildPackage"];
                    //item.CRF_No = reader["vcCRFNumber"] == DBNull.Value ? "" : (string)reader["vcCRFNumber"];
                    list.Add(reader["vcResult"] == DBNull.Value ? "" : (string)reader["vcResult"]);
                    //item.Description = reader["vcDescription"] == DBNull.Value ? "" : (string)reader["vcDescription"];
                    //item.Related_Items = reader["vcRelatedItems"] == DBNull.Value ? "" : (String)reader["vcRelatedItems"];
                    //item.Team = reader["vcTeam"] == DBNull.Value ? "" : (String)reader["vcTeam"];
                    //item.StatusID = reader["iStatusID"] == DBNull.Value ? -1 : (int)reader["iStatusID"];
                    //item.dtStatusTime = reader["dtStatusTime"] == DBNull.Value ? new DateTime(1900, 1, 1) : (DateTime)reader["dtStatusTime"];
                    //item.OwnedBy = reader["vcOwnedBy"] == DBNull.Value ? "" : (String)reader["vcOwnedBy"];
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return list.ToArray();
    }
    public static DataSet GetDataSet(string prefixText)
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetDataSet");
            mDatabase.AddInParameter(dbcmd, "@vcprefixText", DbType.String, prefixText);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetPDCRequested()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetPDCRequested");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static List<StageSummary> GetStageSummary()
    {
        List<StageSummary> list = new List<StageSummary>();
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspItemsStageSumm");
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                while (reader.Read())
                {
                    StageSummary pg = new StageSummary();
                    pg.Stage = reader["vcStage"] == DBNull.Value ? "" : (string)reader["vcStage"];
                    pg.StageID = reader["iStage"] == DBNull.Value ? -1 : (int)reader["iStage"];
                    pg.Total = reader["Total"] == DBNull.Value ? -1 : (int)reader["Total"];
                    list.Add(pg);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return list;
    }
    public static DataSet GetRecentUpdates()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetRecentUpdates");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetItemsPendingCRFARaise()
    {
        //uspPendingCRFA
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspPendingRaiseCRF_A");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetItemPendingCRF_B_Approval()
    {
        //uspPendingCRFA
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspItemPendingCRF_B_Approval");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetItemPendingCRF_A_Approval()
    {
        //uspPendingCRFA
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspItemPendingCRF_A_Approval");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetCodeSummary()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspCodeStatus");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetConflicts()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemsMissingCRFAB");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetItemsMissingCRFAB()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemsMissingCRFAB");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    public static DataSet GetScheduledDeployments()
    {
        DataSet ds = new DataSet();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetScheduledItemsForDeployment");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    
    public static List<User> GetUsers()
    {
        List<User> ds = new List<User>();
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetUsers");
            using (IDataReader reader = mDatabase.ExecuteReader(dbcmd))
            {
                while (reader.Read())
                {
                    //iUserID	vcWindowsLogin	vcFirstName	vcLastName	vcEmail
                    User i = new User();
                    i.UserID = reader["iUserID"] == DBNull.Value ? -1 : (int)reader["iUserID"];
                    i.WindowsLogin = reader["vcWindowsLogin"] == DBNull.Value ? "" : (string)reader["vcWindowsLogin"];
                    i.FirstName = reader["vcFirstName"] == DBNull.Value ? "" : (string)reader["vcFirstName"];
                    i.LastName = reader["vcLastName"] == DBNull.Value ? "" : (string)reader["vcLastName"];
                    i.Email = reader["vcEmail"] == DBNull.Value ? "" : (string)reader["vcEmail"];
                    i.FullName = reader["vcFullName"] == DBNull.Value ? "" : (string)reader["vcFullName"];

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
    public static DataSet GetItemFullCycles(int iItemID)
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemFullCycles");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, iItemID);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }
    public static DataSet GetItemsbyBuildandStatus(string Build, string Status)
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemsbyBuildandStatus");
            mDatabase.AddInParameter(dbcmd, "@vcBuild", DbType.String, Build);
            mDatabase.AddInParameter(dbcmd, "@iStatusID", DbType.Int32, Status);
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }

    public static void GenerateCRFB(int itemID)
    {
        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGenerateCRFB");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, itemID);
            mDatabase.ExecuteScalar(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    public static int UpdateScheduledDeploymentDate(Item i, String DelayComments)
    {
        Int32 rowsAffected = 0;

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspUpdateDeploymentDate");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, i.ItemID);
            mDatabase.AddInParameter(dbcmd, "@dtScheduledDeploymentDate", DbType.DateTime, i.ScheduledDeploymentDate);
            mDatabase.AddInParameter(dbcmd, "@vcDelayComment", DbType.String, DelayComments);
            rowsAffected = mDatabase.ExecuteNonQuery(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rowsAffected;
    }




    public static DataSet GetProgress()
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspProgress");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }

    public static object GetDelayReasons()
    {
        DataSet ds = new DataSet();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetDelayReasons");
            ds = mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }

    public static DataTable GetWeeklyDeployments()
    {
        DataTable ds = new DataTable();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspWeeklyDeploymentsGet");
            ds = mDatabase.ExecuteDataSet(dbcmd).Tables[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
        
    }

    public static object uspGetItemBugs(int ItemID)
    {
        DataTable ds = new DataTable();

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetItemBugs");
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            mDatabase.ExecuteDataSet(dbcmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }

    public static String GetNextItem(int StatusID, int ItemID)
    {
        DataTable dt = new DataTable();
        String NextItem = "";

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetNextItem");
            mDatabase.AddInParameter(dbcmd, "@iStatusID", DbType.Int32, StatusID);
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            mDatabase.AddOutParameter(dbcmd, "@NextItem", DbType.String, 10);

            mDatabase.ExecuteNonQuery(dbcmd);
            NextItem = mDatabase.GetParameterValue(dbcmd, "@NextItem").ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return NextItem;
    }
    public static String GetPrevItem(int StatusID, int ItemID)
    {
        DataTable dt = new DataTable();
        String NextItem = "";

        try
        {
            DbCommand dbcmd = mDatabase.GetStoredProcCommand("uspGetPrevItem");
            mDatabase.AddInParameter(dbcmd, "@iStatusID", DbType.Int32, StatusID);
            mDatabase.AddInParameter(dbcmd, "@iItemID", DbType.Int32, ItemID);
            mDatabase.AddOutParameter(dbcmd, "@PrevItem", DbType.String, 10);

            mDatabase.ExecuteNonQuery(dbcmd);
            NextItem = mDatabase.GetParameterValue(dbcmd, "@PrevItem").ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return NextItem;
    }

}

public class IncidentInfo
{


    String bHadIncident;

    public String HadIncident
    {
        get { return bHadIncident; }
        set { bHadIncident = value; }
    }
    String incidentDescription;

    public String IncidentDescription
    {
        get { return incidentDescription; }
        set { incidentDescription = value; }
    }
    String incidentType;

    public String IncidentType
    {
        get { return incidentType; }
        set { incidentType = value; }
    }
    String bWasRolledBack;

    public String WasRolledBack
    {
        get { return bWasRolledBack; }
        set { bWasRolledBack = value; }
    }
    String bWasHotfixed;

    public String WasHotfixed
    {
        get { return bWasHotfixed; }
        set { bWasHotfixed = value; }
    }

}

public class StageSummary
{
    int _StageID;
    string _Stage;
    int _Total;

    public int StageID
    {
        get { return _StageID; }
        set { _StageID = value; }
    }
    public string Stage
    {
        get { return _Stage; }
        set { _Stage = value; }
    }
    public int Total
    {
        get { return _Total; }
        set { _Total = value; }
    }
}

public class Item
{
    Int32 _ItemID;

    public Int32 ItemID
    {
        get { return _ItemID; }
        set { _ItemID = value; }
    }
    String _Type;

    public String Type
    {
        get { return _Type; }
        set { _Type = value; }
    }
    Int32 _NumberSequence;

    public Int32 NumberSequence
    {
        get { return _NumberSequence; }
        set { _NumberSequence = value; }
    }
    String _CRPRTDR;

    public String CRPRTDR
    {
        get { return _CRPRTDR; }
        set { _CRPRTDR = value; }
    }
    String _CRF_No;

    public String CRF_No
    {
        get { return _CRF_No; }
        set { _CRF_No = value; }
    }
    String _Description;

    public String Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    String _DetailDescription;

    public String DetailDescription
    {
        get { return _DetailDescription; }
        set { _DetailDescription = value; }
    }
    String _Build_Package;

    public String Build_Package
    {
        get { return _Build_Package; }
        set { _Build_Package = value; }
    }
    String _Related_Items;

    public String Related_Items
    {
        get { return _Related_Items; }
        set { _Related_Items = value; }
    }
    Int32 _StatusID;

    public Int32 StatusID
    {
        get { return _StatusID; }
        set { _StatusID = value; }
    }
    String _Status;

    public String Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    
    DateTime _StatusTime;

    public DateTime StatusTime
    {
        get { return _StatusTime; }
        set { _StatusTime = value; }
    }
    String _OwnedBy;

    public String OwnedBy
    {
        get { return _OwnedBy; }
        set { _OwnedBy = value; }
    }
    DateTime _UpdateTime;

    public DateTime UpdateTime
    {
        get { return _UpdateTime; }
        set { _UpdateTime = value; }
    }
    Int32 _ParentID;

    public Int32 ParentID
    {
        get { return _ParentID; }
        set { _ParentID = value; }
    }
    DateTime _ScheduledDeploymentDate;

    public DateTime ScheduledDeploymentDate
    {
        get { return _ScheduledDeploymentDate; }
        set { _ScheduledDeploymentDate = value; }
    }
    Int32 _EstimatedHours;

    public Int32 EstimatedHours
    {
        get { return _EstimatedHours; }
        set { _EstimatedHours = value; }
    }
    Int16 _Severity;

    public Int16 Severity
    {
        get { return _Severity; }
        set { _Severity = value; }
    }
    Int16 _Priority;

    public Int16 Priority
    {
        get { return _Priority; }
        set { _Priority = value; }
    }

    Decimal _Rank;

    public Decimal Rank
    {
        get { return _Rank; }
        set { _Rank = value; }
    }
    Int32 _PercentComplete;

    public Int32 PercentComplete
    {
        get { return _PercentComplete; }
        set { _PercentComplete = value; }
    }
    DateTime _DeployDate;

    public DateTime DeployDate
    {
        get { return _DeployDate; }
        set { _DeployDate = value; }
    }
    String _CrossGenericRelation;

    public String CrossGenericRelation
    {
        get { return _CrossGenericRelation; }
        set { _CrossGenericRelation = value; }
    }
    String _DependentRelation;

    public String DependentRelation
    {
        get { return _DependentRelation; }
        set { _DependentRelation = value; }
    }
    String _ChargeNumber;

    public String ChargeNumber
    {
        get { return _ChargeNumber; }
        set { _ChargeNumber = value; }
    }
    String _CustomerReferenceNumber;

    public String CustomerReferenceNumber
    {
        get { return _CustomerReferenceNumber; }
        set { _CustomerReferenceNumber = value; }
    }
    Int32 _ActualEffortHours;

    public Int32 ActualEffortHours
    {
        get { return _ActualEffortHours; }
        set { _ActualEffortHours = value; }
    }
    DateTime _CreateDate;

    public DateTime CreateDate
    {
        get { return _CreateDate; }
        set { _CreateDate = value; }
    }
    String _Team;

    public String Team
    {
        get { return _Team; }
        set { _Team = value; }
    }

    String _Comments;

    public String Comments
    {
        get { return _Comments; }
        set { _Comments = value; }
    }

    List<User> developers;

    public List<User> Developers
    {
        get { return developers; }
        set { developers = value; }
    }

    string _PDCRemark;
    public string PDCRemark
    {
        get { return _PDCRemark; }
        set { _PDCRemark = value; }
    }

    public Item(){

    }



}



