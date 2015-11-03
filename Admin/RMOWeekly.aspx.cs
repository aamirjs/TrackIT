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

public partial class RMOWeekly : System.Web.UI.Page
{
    public int iItemPendingCRFApprovals = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetThisWeekDeployment();
        GetItemsPendingCRFApprovalsA();
        GetItemsPendingCRFApprovalsB();
        GetItemsPendingPropRCAApprovals();
        GetItemsPendingDBAReview();
        GetPDCRequested(); 
    }

  
    private void GetItemsPendingCRFApprovalsA()
    {
        DataTable table = ItemDAL.GetItemPendingCRF_A_Approval().Tables[0];
        gvPendingCRFApprovalsA.DataSource = table;
        gvPendingCRFApprovalsA.DataBind();
    }
    private void GetItemsPendingCRFApprovalsB()
    {
        DataTable table = ItemDAL.GetItemPendingCRF_B_Approval().Tables[0];
        gvPendingCRFApprovalsB.DataSource = table;
        gvPendingCRFApprovalsB.DataBind();
    }

    private void GetItemsPendingPropRCAApprovals()
    {
        gvPendingRCAPropApprovals.DataSource = ItemDAL.GetItemsPendingPropRCAApprovals();
        gvPendingRCAPropApprovals.DataBind();
    }


    private void GetItemsPendingDBAReview()
    {
        gvPendingDBAReview.DataSource = ItemDAL.GetItemsPendingDBAReview();
        gvPendingDBAReview.DataBind();
    }
    
    private void GetThisWeekDeployment()
    {
        gvThisWeekDeps.DataSource = ItemDAL.GetThisWeekDeployments();
        gvThisWeekDeps.DataBind();

        gvDeliveredForDep.DataSource = ItemDAL.GetItemsPendingDeployment();
        gvDeliveredForDep.DataBind();
    }


    private void GetPDCRequested()
    {
        gvItemsPendingPDC.DataSource = ItemDAL.GetPDCRequested();
        gvItemsPendingPDC.DataBind();
    }

}
