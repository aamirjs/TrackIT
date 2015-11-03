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

public partial class Reminders : BasePage
{
    public string Message;
    Int32 ItemID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCRPRTDR();
        }
        GetReminders();        
    }
    private void FillCRPRTDR()
    {
        ddlCRPRTDR.DataSource = ItemDAL.GetListOfCRPRTDR();
        ddlCRPRTDR.DataValueField = "ItemID";
        ddlCRPRTDR.DataTextField = "CRPRTDR";
        ddlCRPRTDR.DataBind();
    }
    protected void ddlCRPRTDR_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void btnAddReminder_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCRPRTDR.SelectedIndex < 0)
            {
                ErrorMessage = "Select and item.";
                return;
            }
            if (txtReminderDate.Text == "")
            {
                ErrorMessage = "Reminder date is missing.";
                return;
            }
            if (txtRemindFor.Text == "")
            {
                ErrorMessage = "What should I remind you about?";
                return;
            }
            ItemID = Convert.ToInt32(ddlCRPRTDR.SelectedItem.Value);
            PDCDAL.ReminderInsert(ItemID, txtRemindFor.Text, Convert.ToDateTime(txtReminderDate.Text), cbRecur.Checked);
            GetReminders();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }

    }

    private void GetReminders()
    {
        GridView1.DataSource = PDCDAL.GetReminders();
        GridView1.DataBind();
    }
}
