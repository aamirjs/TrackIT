//using System;
//using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.Collections.Generic;
//using System.Data.SqlClient;

///// <summary>
///// Summary description for Item
///// </summary>
//public class Item
//{
//    int _ID;

//    public int ID
//    {
//        get { return _ID; }
//        set { _ID = value; }
//    }
//    string _CRF_No;

//    public string CRF_No
//    {
//        get { return _CRF_No; }
//        set { _CRF_No = value; }
//    }
//    string _CRPRTDR;
//    public string CRPRTDR
//    {
//        get { return _CRPRTDR; }
//        set { _CRPRTDR = value; }
//    }



//    string _Team;
//    public string Team
//    {
//        get { return _Team; }
//        set { _Team = value; }
//    }


//    string _Descriptionx;
//    public string Description
//    {
//        get { return _Descriptionx; }
//        set { _Descriptionx = value; }
//    }


//    //DateTime _Development_Completed;
//    //public DateTime Development_Completed
//    //{
//    //    get { return _Development_Completed; }
//    //    set { _Development_Completed = value; }
//    //}



//    //DateTime _RCA_submitted_for_approval;
//    //public DateTime RCA_submitted_for_approval
//    //{
//    //    get { return _RCA_submitted_for_approval; }
//    //    set { _RCA_submitted_for_approval = value; }
//    //}


//    //DateTime _RCA_approved;
//    //public DateTime RCA_approved
//    //{
//    //    get { return _RCA_approved; }
//    //    set { _RCA_approved = value; }
//    //}

//    //DateTime _DBA_Review_Start;
//    //public DateTime DBA_Review_Start
//    //{
//    //    get { return _DBA_Review_Start; }
//    //    set { _DBA_Review_Start = value; }
//    //}

//    //DateTime _DBA_Review_Finish;
//    //public DateTime DBA_Review_Finish
//    //{
//    //    get { return _DBA_Review_Finish; }
//    //    set { _DBA_Review_Finish = value; }
//    //}

//    //DateTime _Delivered_to_QA;
//    //public DateTime Delivered_to_QA
//    //{
//    //    get { return _Delivered_to_QA; }
//    //    set { _Delivered_to_QA = value; }
//    //}

//    //DateTime _QA_Testing_Start;
//    //public DateTime QA_Testing_Start
//    //{
//    //    get { return _QA_Testing_Start; }
//    //    set { _QA_Testing_Start = value; }
//    //}

//    //DateTime _QA_Testing_Finish;
//    //public DateTime QA_Testing_Finish
//    //{
//    //    get { return _QA_Testing_Finish; }
//    //    set { _QA_Testing_Finish = value; }
//    //}

//    //DateTime _UAT_Testing;
//    //public DateTime UAT_Testing
//    //{
//    //    get { return _UAT_Testing; }
//    //    set { _UAT_Testing = value; }
//    //}

//    //DateTime _User_Guide_Requested;
//    //public DateTime User_Guide_Requested
//    //{
//    //    get { return _User_Guide_Requested; }
//    //    set { _User_Guide_Requested = value; }
//    //}

//    //DateTime _User_Guide_Completed;
//    //public DateTime User_Guide_Completed
//    //{
//    //    get { return _User_Guide_Completed; }
//    //    set { _User_Guide_Completed = value; }
//    //}

//    //DateTime _CRF_Sent;
//    //public DateTime CRF_Sent
//    //{
//    //    get { return _CRF_Sent; }
//    //    set { _CRF_Sent = value; }
//    //}

//    //DateTime _CRF_Approval_Date;
//    //public DateTime CRF_Approval_Date
//    //{
//    //    get { return _CRF_Approval_Date; }
//    //    set { _CRF_Approval_Date = value; }
//    //}

//    //DateTime _Integration_Testing;
//    //public DateTime Integration_Testing
//    //{
//    //    get { return _Integration_Testing; }
//    //    set { _Integration_Testing = value; }
//    //}

//    //DateTime _Production_Delivery_Date;
//    //public DateTime Production_Delivery_Date
//    //{
//    //    get { return _Production_Delivery_Date; }
//    //    set { _Production_Delivery_Date = value; }
//    //}

//    //DateTime _Deployment_Request_Date;
//    //public DateTime Deployment_Request_Date
//    //{
//    //    get { return _Deployment_Request_Date; }
//    //    set { _Deployment_Request_Date = value; }
//    //}

//    string _Build_Package;
//    public string Build_Package
//    {
//        get { return _Build_Package; }
//        set { _Build_Package = value; }
//    }

//    string _Related_Items;
//    public string Related_Items
//    {
//        get { return _Related_Items; }
//        set { _Related_Items = value; }
//    }

//    string _Status;
//    public string Status
//    {
//        get { return _Status; }
//        set { _Status = value; }
//    }

//    DateTime _dtStatusTime;
//    public DateTime dtStatusTime
//    {
//        get { return _dtStatusTime; }
//        set { _dtStatusTime = value; }
//    }

//    public Item()
//    { }
//}
//public class ItemDAL
//{
//    public ItemDAL() { }

//    


//}