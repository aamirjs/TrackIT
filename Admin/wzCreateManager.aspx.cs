using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_wzCreateManager : BasePage
{
    public List<User> Requesters = new List<User>();
    public List<WorkshopStatus> WorkshopStatuses = new List<WorkshopStatus>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Wizard1.MoveTo(stpCreateItem);
        }
    }

    protected void btnSaveItem_Click(object sender, EventArgs e)
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

            //ItemDAL.Insert(
            //    ddlItemType.SelectedValue.ToString() + txtItemNo.Text,
            //    txtCRFNumber.Text,
            //    txtTeam.Text,
            //    txtDescription.Text,
            //    txtBuild.Text,
            //    txtRelatedItems.Text,
            //    devs
            //    );
            ErrorMessage = "Item created successfully.";

            //ClearFields();
        } 
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
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
    protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        switch (e.CurrentStepIndex)
        {
            case 1: return;

            case 2: return;

            case 3: return;

            case 4: return;
        }

    }
}
