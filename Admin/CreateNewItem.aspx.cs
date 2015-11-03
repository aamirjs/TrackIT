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
using System.Collections.Generic;

public partial class _CreateNewItem : BasePage
{
    String vcCRPRTDR = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillUsers();

        if (Request.QueryString["Name"] != null)
        {
            vcCRPRTDR = Request.QueryString["Name"].ToString();
            //GetItemInformation(vcCRPRTDR);
        }


        try
        {
            ErrorMessage = "";
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

    }
    /*
    private void GetItemInformation(string vcCRPRTDR)
    {
        try
        {

            Item i = ItemDAL.GetItemByName(vcCRPRTDR);
            i.OwnedBy = i.OwnedBy.TrimStart(',').TrimEnd(',');
            txtBuild.Text = i.Build_Package;
            txtCRFNumber.Text = i.CRF_No;
            txtDescription.Text = i.Description;
            txtOwnedBy.Text = i.OwnedBy;
            txtRelatedItems.Text = i.Related_Items;
            txtOwnedBy.Text = i.OwnedBy;
            txtTeam.Text = i.Team;
            txtDetailedDescription.Text = i.DetailDescription;
            txtEstimatedEffort.Text = i.EstimatedHours.ToString();
            txtPercentComplete.Text = i.PercentComplete.ToString();
            txtPriority.Text = i.Priority.ToString();
            txtSeverity.Text = i.Severity.ToString();


            //if (i.OwnedBy.Length > 0)
            //{
            //    String[] userids = i.OwnedBy.Split(',');

            //    foreach (String s in userids)
            //    {
            //        cblUsers.Items.FindByText(s).Selected = true;
            //    }
            //}

            //vcCRPRTDR = i.CRPRTDR;
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    * 
    */

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            List<User> devs = new List<User>();

            foreach (ListItem li in cblUsers.Items)
            {
                if (li.Selected)
                {
                    User u = new User();
                    u.UserID = Convert.ToInt32(li.Value);
                    devs.Add(u);
                }
            }

            if (devs.Count == 0)
            {
                ErrorMessage = "Please select the developer(s) before saving the request.";
                return;
            }

            ErrorMessage = ItemDAL.Insert(
                ddlItemType.SelectedItem.Text,
                txtCRFNumber.Text,
                txtTeam.Text,
                txtDescription.Text,
                txtDetailedDescription.Text,
                txtBuild.Text,
                txtRelatedItems.Text,
                devs,
                txtSeverity.Text, 
                txtPriority.Text, 
                txtChargeNumber.Text, 
                txtCustomerReferenceNumber.Text, 
                txtEstimatedEffort.Text, 
                txtPercentComplete.Text
                );
            //ErrorMessage = "Item created successfully.";

            ClearFields();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    private void ClearFields()
    {
        ddlItemType.SelectedIndex = -1;
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
        txtEstimatedEffort.Text = "";
        txtPercentComplete.Text = "";
        txtPriority.Text = "";
        txtSeverity.Text = "";
    }
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
}
