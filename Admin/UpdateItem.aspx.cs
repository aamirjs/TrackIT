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



public partial class UpdateItem : System.Web.UI.Page
{
    Int32 iItemID;
    private string _error;
    public string ItemName;

    public string ErrorMessage
    {
        get { return _error; }
        set { _error = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FillCRPRTDR();
            FillUsers();
            if (Request.QueryString["Name"] != null)
            {
                ItemName = Request.QueryString["Name"].ToString();
                FillItemDetails(ItemName);
                //Response.Write(iTemName);
                //ddlCRPRTDR.Items.FindByText(ItemName).Selected = true;
                //ddlCRPRTDR_SelectedIndexChanged(ddlCRPRTDR, new EventArgs());
            }

        }

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        //ddlCRPRTDR.Focus();
    }
    private void FillItemDetails(String itemName)
    {
        for (int i = 0; i < cblUsers.Items.Count; i++)
        {
            cblUsers.Items[i].Selected = false;
        }

        try
        {
            //if (ddlCRPRTDR.SelectedIndex >= 0)
            //{
            //    iItemID = Convert.ToInt32(ddlCRPRTDR.SelectedValue.ToString());
            //}
            //else
            //    return;

            Item i = ItemDAL.GetItemByName(itemName);
            //i.OwnedBy = i.OwnedBy.TrimStart(',').TrimEnd(',');
            //txtItemID.Text = i.ItemID.ToString();
            //txtBuild.Text = i.Build_Package;
            //txtChargeNumber.Text = i.ChargeNumber;
            //txtCRFNumber.Text = i.CRF_No;
            //txtCRPRTDR.Text  = i.CRPRTDR;
            //txtCustomerReferenceNumber.Text = i.CustomerReferenceNumber;
            //txtDescription.Text = i.Description;
            //txtDetailedDescription.Text = i.DetailDescription;
            //txtEstimatedEffortHrs.Text = i.EstimatedHours.ToString();
            //txtItemType.Text = i.Type;
            //txtOwnedBy.Text = i.OwnedBy;
            //txtRelatedItems.Text = i.Related_Items;
            //txtTeam.Text = i.Team;            
            //txtPercentComplete.Text = i.PercentComplete.ToString();
            //txtPriority.Text = i.Priority.ToString();
            //txtSeverity.Text = i.Severity.ToString();

            txtActualEffortHrs.Text = i.ActualEffortHours.ToString();
            txtBuild.Text = i.Build_Package;
            txtChargeNumber.Text = i.ChargeNumber;
            txtCRFNumber.Text = i.CRF_No;
            txtCrossGenericRelation.Text = i.CrossGenericRelation;
            txtCRPRTDR.Text = i.CRPRTDR;
            txtCustomerReferenceNumber.Text = i.CustomerReferenceNumber;
            txtDependentRelation.Text = i.DependentRelation;
            txtDescription.Text = i.Description;
            txtDetailedDescription.Text = i.DetailDescription;
            txtEstimatedEffortHrs.Text = i.EstimatedHours.ToString();
            txtItemID.Text = i.ItemID.ToString();
            txtPercentComplete.Text = i.PercentComplete.ToString();
            txtPriority.Text = i.Priority.ToString();
            txtRank.Text = i.Rank.ToString();
            txtRelatedItems.Text = i.Related_Items;
            txtSeverity.Text = i.Severity.ToString();
            txtTeam.Text = i.Team;
            txtItemType.Text = i.Type;
            if(i.DeployDate.Year > 1900)
                txtDeploymentDate.Text = i.DeployDate.ToString();
            if (i.CreateDate.Year > 1900)
                txtCreateDate.Text = i.CreateDate.ToString();
            //i.Comments 	;
            //i.CreateDate 	;
            //i.Developers 	;
            //i.OwnedBy 	;
            //i.ParentID 	;
            //i.PDCRemark	;
            //i.ScheduledDeploymentDate	;
            //i.Status	;
            //i.StatusID	;
            //i.UpdateTime	;


            if (i.OwnedBy.Length > 0)
            {
                String[] userids = i.OwnedBy.Split(',');

                foreach (String s in userids)
                {
                    if (s.Length > 0)
                        cblUsers.Items.FindByText(s).Selected = true;
                }
            }


            ItemName = i.CRPRTDR;
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message + "<br/>" + exc.StackTrace;
        }


    }


    //private void FillCRPRTDR()
    //{
    //    try
    //    {
    //        ddlCRPRTDR.DataSource = ItemDAL.GetListOfCRPRTDR();
    //        ddlCRPRTDR.DataValueField = "ItemID";
    //        ddlCRPRTDR.DataTextField = "CRPRTDR";
    //        ddlCRPRTDR.DataBind();
    //    }
    //    catch (Exception exc)
    //    {
    //        ErrorMessage = exc.Message;
    //    }
    //}
    private void FillUsers()
    {
        try
        {
            cblUsers.DataSource = ItemDAL.GetUsers();
            cblUsers.DataValueField = "UserID";
            cblUsers.DataTextField = "FirstName";
            cblUsers.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("UpdateItemStatus.aspx?Name=" + ItemName + "");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //if (ddlCRPRTDR.SelectedIndex >= 0)
            //{
            //    iItemID = ddlCRPRTDR.SelectedValue.ToString();
            //    //StatusID = ddlStatus.SelectedValue.ToString();
            //}
            //else
            //{
            //    ErrorMessage = "Select an item to update.";
            //    return;
            //}

            Item i = new Item();

            int ActualEffortHours = -1;
            Int32.TryParse(txtActualEffortHrs.Text, out ActualEffortHours);
            i.ActualEffortHours = ActualEffortHours;    

            i.Build_Package = txtBuild.Text;
            i.ChargeNumber = txtChargeNumber.Text;
            //i.Comments = ""; //NA here
            //i.CreateDate = ""; //NA here
            i.CRF_No = txtCRFNumber.Text;
            i.CrossGenericRelation = txtCrossGenericRelation.Text;
            i.CRPRTDR = txtCRPRTDR.Text;
            i.CustomerReferenceNumber = txtCustomerReferenceNumber.Text;
            i.DependentRelation = txtDependentRelation.Text;

            DateTime deployDate = new DateTime();
            DateTime.TryParse(txtDeploymentDate.Text, out deployDate);
            if(deployDate.Year > 1900)
                i.DeployDate = deployDate;

            i.Description = txtDescription.Text;
            i.DetailDescription = txtDetailedDescription.Text;
            //i.Developers = "na";//na here
            //i.EstimatedHours = Int32.Parse(txtEstimatedEffortHrs.Text);

            int EstimatedHours = -1;
            Int32.TryParse(txtEstimatedEffortHrs.Text, out EstimatedHours);
            if (EstimatedHours != null)
                i.EstimatedHours = EstimatedHours;
            else
                i.EstimatedHours = -1;    

            
            
            
            i.ItemID = Int32.Parse(txtItemID.Text);
            //i.OwnedBy =  = "na";//na here
            //i.ParentID = "not used"// nsa here
            //i.PDCRemark
            //i.PercentComplete = Int32.Parse(txtPercentComplete.Text);

            int PercentComplete = -1;
            Int32.TryParse(txtPercentComplete.Text, out PercentComplete);
            if (PercentComplete != null)
                i.PercentComplete = PercentComplete;
            else
                i.PercentComplete = -1; 


            //i.Priority = Int16.Parse(txtPriority.Text);
            short Priority = -1;
            short.TryParse(txtPriority.Text, out Priority);
            if (Priority != null)
                i.Priority = Priority;
            else
                i.Priority = (short)-1; 

            
            
            //i.Rank = Int32.Parse(txtRank.Text);
            Decimal Rank = 0;
            Decimal.TryParse(txtRank.Text, out Rank);
            if (Rank != null)
                i.Rank = Rank;
            else
                i.Rank = -1; 

            
            
            i.Related_Items = txtRelatedItems.Text;
            //i.ScheduledDeploymentDate

            //i.Severity = Int16.Parse(txtSeverity.Text);
            short Severity = -1;
            short.TryParse(txtSeverity.Text, out Severity);
            if (Severity != null)
                i.Severity = Severity;
            else
                i.Severity = (short)-1; 
            
            
            
            //i.Status
            //i.StatusID
            i.Team = txtTeam.Text;
            i.Type = txtItemType.Text;
            //i.UpdateTime

            i.Developers = new List<User>();

            foreach (ListItem li in cblUsers.Items)
            {
                if (li.Selected)
                {
                    User u = new User();
                    u.UserID = Convert.ToInt32(li.Value);
                    i.Developers.Add(u);
                }
            }

            int rowsAffected = ItemDAL.UpdateItemDetails(i);
            ErrorMessage = String.Format("{0} row(s) updated.", rowsAffected);
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }

    }
    //protected void ddlCRPRTDR_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        FillItemDetails();
    //    }
    //    catch (Exception exc)
    //    {
    //        ErrorMessage = exc.Message;
    //    }
    //}
    private void ClearFields()
    {
        txtItemType.Text = "";
        txtBuild.Text = "";
        txtCRFNumber.Text = "";
        txtDescription.Text = "";
        txtOwnedBy.Text = "";
        txtRelatedItems.Text = "";
        txtTeam.Text = "";
        cblUsers.SelectedIndex = -1;
        txtChargeNumber.Text = "";
        txtCustomerReferenceNumber.Text = "";
        txtDetailedDescription.Text = "";
        txtEstimatedEffortHrs.Text = "";
        txtActualEffortHrs.Text = "";
        txtPercentComplete.Text = "";
        txtPriority.Text = "";
        txtSeverity.Text = "";
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
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
}
