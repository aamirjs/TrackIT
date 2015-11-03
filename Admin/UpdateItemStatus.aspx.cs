using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Collections.Generic;



public partial class UpdateItemStatus : System.Web.UI.Page
{
    public const string TDR = "1";
    public const string CR = "2";
    public const string PR = "3";
    public const string L1 = "4";
    public const string RS = "5";
    public const string GT = "6";
    public const string PD = "7";

    public String SharesPath;


    string _result;

    public string Result
    {
        get { return _result; }
        set { _result = value; }
    }



    Int32 _ItemID;

    public Int32 ItemID
    {
        get { return _ItemID; }
        set { _ItemID = value; }
    }

    public DateTime ScheduledDeploymentDate
    {
        get
        {
            if (txtScheduledDeploymentDate.Text == "")
                return new DateTime(1900, 1, 1);
            else
                return DateTime.Parse(txtScheduledDeploymentDate.Text);
        }
        set
        {
            txtScheduledDeploymentDate.Text = value.ToShortDateString();
        }
    }

    string StatusID;
    private string _error;

    string _CRFNumber;

    public string CRFNumber
    {
        get { return _CRFNumber; }
        set { _CRFNumber = value; }
    }
    string _ItemName;

    public string ItemName
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }

    string _itemTitle;
    public string ItemTitle
    {
        get { return _itemTitle; }
        set { _itemTitle = value; }
    }

    string _Build;
    public string Build
    {
        get { return _Build; }
        set { _Build = value; }
    }
    public string ErrorMessage
    {
        get { return _error; }
        set { _error = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Logger.LogRun("Page loading....");
		SharesPath = ConfigurationManager.AppSettings["SharesPath"].ToString();
        if (!IsPostBack)
        {
            
            FillStatus();
            FillCRPRTDR();
            FillDelayReasons();
            txtComments.Text = "";

            if (Request.QueryString["Name"] != null)
            {
                ItemName = Request.QueryString["Name"].ToString();
                //Response.Write(iTemName);
                ddlCRPRTDR.Items.FindByText(ItemName).Selected = true;
                ddlCRPRTDR_SelectedIndexChanged(ddlCRPRTDR, new EventArgs());
            }
            txtScheduledDeploymentDate.Text = "";
            txtDelayComment.Text = "";
        }
        else
        {
            Session["ItemID"] = Convert.ToInt32(ddlCRPRTDR.SelectedItem.Value);
        }
        ItemID = (Int32)Session["ItemID"];

    }
    private void FillDelayReasons()
    {
        ddlDelayReasons.DataSource = ItemDAL.GetDelayReasons();
        ddlDelayReasons.DataValueField = "iDelayReasonID";
        ddlDelayReasons.DataTextField = "vcDelayReason";
        ddlDelayReasons.DataBind();
    }

    private void FillBugs()
    {
        GridViewBugs.DataSource = ItemDAL.uspGetItemBugs(ItemID);
        GridViewBugs.DataBind();
    }

    private void FillItems()
    {
        GridView1.DataSource = ItemDAL.GetItem();
        GridView1.DataBind();
    }
    private void FillItemFullCycles(int ItemID)
    {
        GridView1.DataSource = ItemDAL.GetItemFullCycles(ItemID);
        GridView1.DataBind();
    }
    private void FillCRPRTDR()
    {
        ddlCRPRTDR.DataSource = ItemDAL.GetListOfCRPRTDR();
        ddlCRPRTDR.DataValueField = "ItemID";
        ddlCRPRTDR.DataTextField = "CRPRTDR";
        ddlCRPRTDR.DataBind();
    }
    private void FillStatus()
    {
        ddlStatus.DataSource = StatusDAL.GetStatuses();
        ddlStatus.DataValueField = "iStatusID";
        ddlStatus.DataTextField = "vcStatus";
        ddlStatus.DataBind();
    }
    private void CheckBugStatus()
    {
        Result = BugsDAL.CheckBugStatus(ItemID);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCRPRTDR.SelectedIndex >= 0)
            {
                ItemID = Convert.ToInt32(ddlCRPRTDR.SelectedValue.ToString());
                StatusID = ddlStatus.SelectedValue.ToString();
            }
            else
            {
                ErrorMessage = "Select an item to update.";
                return;
            }

            Item i = new Item();
            i.StatusID = Int32.Parse(StatusID);
            i.ItemID = ItemID;
            //i.UpdatedBy = this.User.Identity.Name;
            if (txtDate.Text == "")
                txtDate.Text = new DateTime(1900, 1, 1).ToString();
            i.StatusTime = Convert.ToDateTime(txtDate.Text);
            i.Comments = txtComments.Text;


            ErrorMessage = ItemDAL.UpdateItemStatus(i, true);

            FillItemHistory();
            FillItemDetails();
            txtComments.Text = "";
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        //Logger.LogRun("Page PreRender.....");

        if (GridView1.SelectedIndex > 0)
            ddlStatus.SelectedIndex = ((ListControl)(ddlStatus)).Items.IndexOf(((ListControl)(ddlStatus)).Items.FindByValue(StatusID));

        ddlCRPRTDR.Focus();

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //FillItems();
    }
    protected void ddlCRPRTDR_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillItemDetails();
        FillItemHistory();
        gvRemarks.DataSource = null;
        gvPDCRemarks.DataSource = null;
        txtRemark.Text = "";
        txtPDCRemark.Text = "";
        FillRemarks();
        FillPDCRemarks();
        FillBugs();
    }
    private void GetDelayInformation(int itemid)
    {
        gvDepDelays.DataSource = ItemDAL.GetDelayInformation(itemid);
        gvDepDelays.DataBind();
    }
    private void FillItemDetails()
    {
        //Logger.LogRun("Filling Item details....");
        this.Title = ddlCRPRTDR.SelectedItem.Text;
        Item i = ItemDAL.GetItemByID(Convert.ToInt32(ddlCRPRTDR.SelectedItem.Value));
        this.ItemID = i.ItemID;
        Session["ItemID"] = i.ItemID;
        //Logger.LogRun("Session ItemID set to: " + Session["ItemID"].ToString());

        lblCRF.Text = CRFNumber = i.CRF_No;
        lblItemID.Text = i.ItemID.ToString();
        lblItemName.Text = ItemName = i.CRPRTDR;
        lblDescription.Text = ItemTitle = i.Description;
        lblBuild.Text = Build = i.Build_Package;
        lblRelatedItems.Text = i.Related_Items;
        //cbHasIncident.Checked = i.HasIncident;

        if (i.ScheduledDeploymentDate.Year > 2000)
            ScheduledDeploymentDate = i.ScheduledDeploymentDate;

        //this.WebUserControlUpdateDeploymentDate1.ItemID = i.ItemID;

        GetDelayInformation(i.ItemID);

        lblDeveloper.Text = i.OwnedBy.TrimEnd(',').TrimStart(',');

        if (i.CRPRTDR.StartsWith("PR"))
            lblDocRef.Text = i.CRF_No + "-" + PR + "-" + i.CRPRTDR.Substring(i.CRPRTDR.IndexOf('_') + 1) + ": " + ItemTitle;
        if (i.CRPRTDR.StartsWith("CR"))
            lblDocRef.Text = i.CRF_No + "-" + CR + "-" + i.CRPRTDR.Substring(i.CRPRTDR.IndexOf('_') + 1) + ": " + ItemTitle;
        if (i.CRPRTDR.StartsWith("TDR"))
            lblDocRef.Text = i.CRF_No + "-" + TDR + "-" + i.CRPRTDR.Substring(i.CRPRTDR.IndexOf('_') + 1) + ": " + ItemTitle;

        this.Title = i.CRPRTDR;

        FillTicketInformation(i.ItemID);
        CheckBugStatus();

    }
    private void FillItemHistory()
    {
        int ItemID = Int32.Parse(ddlCRPRTDR.SelectedValue.ToString());
        GridView1.DataSource = ItemDAL.GetItemHistory(ItemID, -1);
        GridView1.DataBind();

        GridView2.DataSource = ItemDAL.GetItemFullCycles(Convert.ToInt32(ddlCRPRTDR.SelectedValue.ToString()));
        GridView2.DataBind();
    }
    private void FillRemarks()
    {
        gvRemarks.DataSource = ItemDAL.GetRemarks(ddlCRPRTDR.SelectedValue.ToString());
        gvRemarks.DataBind();
    }
    private void FillPDCRemarks()
    {
        gvPDCRemarks.DataSource = ItemDAL.GetPDCRemarks(ItemID.ToString());
        gvPDCRemarks.DataBind();
    }

    
    protected void btnAddPDCRemark_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCRPRTDR.SelectedIndex >= 0)
            {
                ItemID = Convert.ToInt32(ddlCRPRTDR.SelectedValue.ToString());
            }
            else
            {
                ErrorMessage = "Select an item to add a pdc remark.";
                return;
            }

            Item i = new Item();
            i.ItemID = ItemID;
            if (txtPDCRemark.Text.Trim().Equals(""))
            {
                ErrorMessage = "Please type in pdc remark to add to item";
                return;
            }

            i.PDCRemark = txtPDCRemark.Text.Trim();
            ItemDAL.AddPDCRemark(i);

            FillItemHistory();

            FillRemarks();
            FillPDCRemarks();

            txtPDCRemark.Text = "";
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }



    protected void btnNext_Click(object sender, EventArgs e) {
        try
        {
            if (Request.QueryString["StatusID"] != null)
            {
                int StatusID = Convert.ToInt32(Request.QueryString["StatusID"]);
                String NextItem = ItemDAL.GetNextItem(StatusID, ItemID);
                if (NextItem.Equals("0"))
                {
                    ErrorMessage = "You are already at the last item.";
                }
                else
                {
                    ddlCRPRTDR.SelectedIndex = -1;
                    ddlCRPRTDR.Items.FindByText(NextItem).Selected = true;
                    ddlCRPRTDR_SelectedIndexChanged(ddlCRPRTDR, new EventArgs());
                }
            }

        }
        catch(Exception exx)
        {
            ErrorMessage = exx.Message;
        }

    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["StatusID"] != null)
            {
                int StatusID = Convert.ToInt32(Request.QueryString["StatusID"]);
                String PrevItem = ItemDAL.GetPrevItem(StatusID, ItemID);
                if (PrevItem.Equals("0"))
                {
                    ErrorMessage = "You are already at the first item.";
                }
                else
                {
                    ddlCRPRTDR.SelectedIndex = -1;
                    ddlCRPRTDR.Items.FindByText(PrevItem).Selected = true;
                    ddlCRPRTDR_SelectedIndexChanged(ddlCRPRTDR, new EventArgs());
                }
            }

        }
        catch (Exception exx)
        {
            ErrorMessage = exx.Message;
        }

    }


    protected void btnAddComment_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCRPRTDR.SelectedIndex >= 0)
            {
                ItemID = Convert.ToInt32(ddlCRPRTDR.SelectedValue.ToString());
            }
            else
            {
                ErrorMessage = "Select an item to add a remark.";
                return;
            }

            Item i = new Item();
            i.ItemID = ItemID;
            if (txtRemark.Text.Trim().Equals(""))
            {
                ErrorMessage = "Please type remark to add to item";
                return;
            }

            i.Comments = txtRemark.Text.Trim();
            ItemDAL.AddRemark(i);

            FillItemHistory();

            FillRemarks();

            txtComments.Text = "";
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void gvRemarks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        int currentRowIndex = e.RowIndex;
        string iItemRemarksID = ((Label)gvRemarks.Rows[currentRowIndex].FindControl("lblItemRemarksID")).Text;

        DeleteRemark(iItemRemarksID.ToString(), ItemID.ToString());

        //ErrorMessage = sb.ToString();
    }
    protected void gvPDCRemarks_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        int currentRowIndex = e.RowIndex;
        string PDCRemarkID = ((Label)gvPDCRemarks.Rows[currentRowIndex].FindControl("lblPDCRemarkID")).Text;
        string ItemID = ((Label)gvPDCRemarks.Rows[currentRowIndex].FindControl("lblItemID")).Text;

        DeletePDCRemark(PDCRemarkID, ItemID);

        //ErrorMessage = sb.ToString();
    }

    protected void gvDepDelays_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        try
        {
            int currentRowIndex = e.RowIndex;
            string HistID = ((Label)gvDepDelays.Rows[currentRowIndex].FindControl("lblHistID")).Text;
            string ItemID = ((Label)gvDepDelays.Rows[currentRowIndex].FindControl("lblItemID")).Text;

            ItemDAL.DeleteDelayRecord(HistID, ItemID);
            GetDelayInformation(Convert.ToInt32(ItemID));
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            StringBuilder sb = new StringBuilder();

            int currentRowIndex = e.RowIndex;
            string ItemID = ((Label)GridView1.Rows[currentRowIndex].FindControl("lbliItemID")).Text;
            string HistID = ((Label)GridView1.Rows[currentRowIndex].FindControl("lbliItemHistID")).Text;
            string StatusDate = ((Label)GridView1.Rows[currentRowIndex].FindControl("lblStatusDate")).Text;
            string StatusID = ((Label)GridView1.Rows[currentRowIndex].FindControl("lblStatusID")).Text;


            sb.Append("<br/>currentRowIndex:" + currentRowIndex.ToString());
            sb.Append("<br/>ItemID:" + ItemID);
            sb.Append("<br/>HistID:" + HistID);
            sb.Append("<br/>StatusDate:" + StatusDate);
            sb.Append("<br/>StatusID:" + StatusID);
            if (!(HistID.Length == 0) && !(ItemID.Length == 0))
                DeleteRecord(HistID.ToString(), ItemID.ToString());
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        //ErrorMessage = sb.ToString();
    }
    private void DeleteRecord(string histid, string iItemID)
    {
        ItemDAL.ResetItemHistoryState(histid, iItemID);
        FillItemHistory();
    }
    private void DeleteRemark(string RemarkID, string iItemID)
    {
        ItemDAL.DeleteRemark(RemarkID, iItemID);
        FillRemarks();
    }

    private void DeletePDCRemark(string iPDCRemarkID, string iItemID)
    {
        ItemDAL.DeletePDCRemark(iPDCRemarkID, iItemID);
        FillPDCRemarks();
    }

    
    
    void LogRun(string message)
    {
        try
        {
            string filename = DateTime.Now.ToString("dd-MMM-yyyy") + ".txt";
            Console.WriteLine(message);
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(Request.PhysicalApplicationPath + filename, true, Encoding.Default))
            {
                writer.WriteLine(DateTime.Now.ToString() + ":" + message);
                writer.Flush();
                writer.Close();
            }
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnGeneratePDC_Click(object sender, EventArgs e)
    {
        if (ddlCRPRTDR.SelectedIndex > -1)
        {
            int itemID = Convert.ToInt32(ddlCRPRTDR.SelectedItem.Value);
            ItemDAL.GeneratePDC(itemID);
        }
    }
    protected void btnRequestCRFB_Click(object sender, EventArgs e)
    {
        if (ddlCRPRTDR.SelectedIndex > -1)
        {
            int itemID = Convert.ToInt32(ddlCRPRTDR.SelectedItem.Value);
            ItemDAL.GenerateCRFB(itemID);
        }
    }
    protected void btnUpdateDeploymentDelay_Click(object sender, EventArgs e)
    {
        DateTime ScheduledDeploymentDate = new DateTime();
        Item i = new Item();

        try
        {
            i.ItemID = (Int32)Session["ItemID"]; ;
            if (txtScheduledDeploymentDate.Text == "")
            {
                ErrorMessage = "Please select a date";
                return;
            }
            if (ddlDelayReasons.SelectedValue.ToLower() == "others" && txtDelayComment.Text == "")
            {
                ErrorMessage = "Please enter delay comments when choosing Others option.";
                return;
            }

            try
            {
                ScheduledDeploymentDate = DateTime.Parse(txtScheduledDeploymentDate.Text);
            }
            catch (Exception exc)
            {
                ErrorMessage = exc.Message+"<br> The date is invalid.";
                return;
            }
            i.ScheduledDeploymentDate = ScheduledDeploymentDate;

            String delayReason = null;
            if (ddlDelayReasons.SelectedItem.Text.ToLower() != "others")
                delayReason = ddlDelayReasons.SelectedItem.Text;
            else
                delayReason = ddlDelayReasons.SelectedItem.Text + "-" + txtDelayComment.Text;


            ItemDAL.UpdateScheduledDeploymentDate(i, delayReason);

            gvDepDelays.DataSource = ItemDAL.GetDelayInformation(i.ItemID);
            gvDepDelays.DataBind();

            txtDelayComment.Text = "";
            //txtDate.Text = "";

        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void btnAddTicket_Click(object sender, EventArgs e)
    {
        try
        {
            int iItemID = (Int32)Session["ItemID"];
            if (txtTicket.Text == "")
            {
                ErrorMessage = "Please enter a ticket";
                return;
            }
            int rows = ItemDAL.AddTicket(iItemID, txtTicket.Text);
            ErrorMessage = rows.ToString() + " rows updated.";

            FillTicketInformation(iItemID);

            txtTicket.Text = "";

        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    private void FillTicketInformation(int iItemID)
    {
        GridViewTickets.DataSource = null;
        try
        {
            DataSet ds = ItemDAL.TicketsGet(iItemID);
            if (ds.Tables.Count > 0)
            {
                GridViewTickets.DataSource = ds;
            }
            GridViewTickets.DataBind();


        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message + "<br>" + exc.StackTrace;
        }
    }
    protected void cbCR_CheckedChanged(object sender, EventArgs e)
    {
        GetResultByFilters();
    }
    protected void cbPR_CheckedChanged(object sender, EventArgs e)
    {
        GetResultByFilters();
    }
    protected void cbTDR_CheckedChanged(object sender, EventArgs e)
    {
        GetResultByFilters();
    }
    private void GetResultByFilters()
    {
        String crit = string.Empty;
        if (cbCR.Checked)
            crit = crit + cbCR.Text + ",";
        if (cbPR.Checked)
            crit = crit + cbPR.Text + ",";
        if (cbTDR.Checked)
            crit = crit + cbTDR.Text;

        crit = crit.TrimEnd(',');

        ErrorMessage = crit;
        //return;
        if (crit.Equals(""))
            ddlCRPRTDR.DataSource = ItemDAL.GetListOfCRPRTDR();
        else
            ddlCRPRTDR.DataSource = ItemDAL.GetListOfCRPRTDR(crit);
        ddlCRPRTDR.DataValueField = "ItemID";
        ddlCRPRTDR.DataTextField = "CRPRTDR";
        ddlCRPRTDR.DataBind();

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var ItemHistID = e.Row.FindControl("lbliItemHistID") as Label;


            if (ItemHistID != null)
            {
                if (ItemHistID.Text == "")//Is the entry filled yet.
                {
                    e.Row.BackColor = System.Drawing.Color.Beige;
                }
            }
        }
    }
}
