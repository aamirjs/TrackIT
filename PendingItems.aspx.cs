using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class PendingItems : System.Web.UI.Page
{
    public int iItemPendingCRFApprovals = 0;

    //System.ServiceModel.NetTcpBinding binding = null;
    //System.ServiceModel.EndpointAddress address = null;
    //System.ServiceModel.ChannelFactory<InterfaceTrackApplication.ITrackIt> channel = null;
    //InterfaceTrackApplication.ITrackIt Client = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        //binding = new System.ServiceModel.NetTcpBinding();
        //address = new System.ServiceModel.EndpointAddress(ConfigurationManager.AppSettings.Get("nettcpbinding"));
        //channel = new System.ServiceModel.ChannelFactory<InterfaceTrackApplication.ITrackIt>(binding, address);
        //Client = channel.CreateChannel();

        GetItemsPendingDeploymentPreparation();
        //GetItemsPendingCRFApprovals();
        GetItemsPendingPropRCAApprovals();
        //GetItemsPendingToSendCRF();
        GetItemsPendingDBAReview();
        GetThisWekDeployment();
        GetPreviousWeekDeployments(); 
        GetItemsPendingPDC();
        GetItemsPendingDeployment();
        //GetStageSummary();
        //GetCodeSummary();

        GetItemsPendingApprovalA();
        GetItemsPendingApprovalB();
        GetItemsMissingCRFAB();
    }

    private void GetItemsMissingCRFAB()
    {
        gvConflicts.DataSource = ItemDAL.GetConflicts();
        gvConflicts.DataBind();
    }

    private void GetItemsPendingApprovalA()
    {
        gvPendingApprovalA.DataSource = ItemDAL.GetItemPendingCRF_A_Approval();
        gvPendingApprovalA.DataBind();
    }

    private void GetItemsPendingApprovalB()
    {
        gvPendingApprovalB.DataSource = ItemDAL.GetItemPendingCRF_B_Approval();
        gvPendingApprovalB.DataBind();
    }

    //private void GetStageSummary()
    //{
    //    //gvStageSumm.DataSource = Client.GetStageSummary(); //ItemDAL.GetStageSummary();
    //   // gvStageSumm.DataSource = ItemDAL.GetStageSummary();
    //   // gvStageSumm.DataBind();
    //}
    //private void GetCodeSummary()
    //{
    //    //gvStageSumm.DataSource = Client.GetStageSummary(); //ItemDAL.GetStageSummary();
    //    //gvCodeSumm.DataSource = ItemDAL.GetCodeSummary();
    //    //gvCodeSumm.DataBind();
    //}

    private void GetItemsPendingDeploymentPreparation()
    {
        //gvPrepareForDeployment.DataSource = Client.GetItemsPendingDeploymentPreparation();  //ItemDAL.GetItemsPendingDeploymentPreparation();
        gvPrepareForDeployment.DataSource = ItemDAL.GetItemsPendingDeploymentPreparation();
        gvPrepareForDeployment.DataBind();
    }

    private void GetItemsPendingDeployment()
    {
        //gvPendingDeployment.DataSource = Client.GetItemsPendingDeployment();
        gvPendingDeployment.DataSource = ItemDAL.GetItemsPendingDeployment();
        gvPendingDeployment.DataBind();
    }

    //private void GetItemsPendingCRFApprovals()
    //{
    //    //DataTable table = Client.GetItemPendingCRFApprovals().Tables[0];
    //    DataTable table = ItemDAL.GetItemPendingCRFApprovals().Tables[0];
    //    iItemPendingCRFApprovals = table.Rows.Count;
    //    gvPendingCRFApprovals.DataSource = table;
    //    gvPendingCRFApprovals.DataBind();
    //}
    private void GetItemsPendingPropRCAApprovals()
    {
        //gvPendingRCAPropApprovals.DataSource = Client.GetItemsPendingPropRCAApprovals();
        gvPendingRCAPropApprovals.DataSource = ItemDAL.GetItemsPendingPropRCAApprovals();
        gvPendingRCAPropApprovals.DataBind();
    }

    //private void GetItemsPendingToSendCRF()
    //{
    //    //gvPendingToSendCRF.DataSource = Client.GetItemsPendingToSendCRF();
    //    gvPendingToSendCRF.DataSource = ItemDAL.GetItemsPendingToSendCRF();
    //    gvPendingToSendCRF.DataBind();
    //}

    private void GetItemsPendingDBAReview()
    {
        //gvPendingDBAReview.DataSource = Client.GetItemsPendingDBAReview();
        gvPendingDBAReview.DataSource = ItemDAL.GetItemsPendingDBAReview();
        gvPendingDBAReview.DataBind();
    }
    private void GetThisWekDeployment()
    {
        //gvThisWeekDeps.DataSource = Client.GetThisWeekDeployments();
        gvThisWeekDeps.DataSource = ItemDAL.GetThisWeekDeployments();
        gvThisWeekDeps.DataBind();
    }
    private void GetPreviousWeekDeployments()
    {
        //gvPrevWeekDeps.DataSource = Client.GetPrevousWeekDeployments();
        gvPrevWeekDeps.DataSource = ItemDAL.GetPrevousWeekDeployments();
        gvPrevWeekDeps.DataBind();
    }
    private void GetItemsPendingPDC()
    {
        //gvItemsPendingPDC.DataSource = Client.GetPendingPDCItems();
        gvItemsPendingPDC.DataSource = ItemDAL.GetPendingPDCItems();
        gvItemsPendingPDC.DataBind();
    }

}
