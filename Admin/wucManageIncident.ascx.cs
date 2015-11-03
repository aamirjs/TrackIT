using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_wucManageIncident : System.Web.UI.UserControl
{
    public string ErrorMessage;
    Int32 _ItemID;

    public Int32 ItemID
    {
        get { return _ItemID; }
        set { _ItemID = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Logger.LogRun("     Control is loading............");
        ResetControls();
        ItemID = (Int32)Session["ItemID"];
        Logger.LogRun("     Control loaded session itemid:" + ItemID.ToString());
        GetIncidentInfo(ItemID);
    }

    private void ResetControls()
    {
        Logger.LogRun("     Control has reset all controls.....");
        rbHasIncidentYes.Checked = false;
        rbHotFixedYes.Checked = false;
        rbRolledBackYes.Checked = false;

        rbHasIncidentNo.Checked = false;
        rbHotFixedNo.Checked = false;
        rbRolledBackNo.Checked = false;
        
        txtDescription.Text = "";
    }

    private void GetIncidentInfo(int ItemID)
    {
        //IncidentInfo info = ItemDAL.GetIncidentInfo(ItemID);
        //if (!info.HadIncident.Equals(""))
        //{
        //    if (info.HadIncident.ToLower().Equals("true"))
        //        rbHasIncidentYes.Checked = true;
        //    if (info.HadIncident.ToLower().Equals("false"))
        //        rbHasIncidentNo.Checked = true;
        //}

        //if (!info.WasHotfixed.Equals(""))
        //{
        //    if (info.WasHotfixed.ToLower().Equals("true"))
        //        rbHotFixedYes.Checked = true;
        //    if (info.WasHotfixed.ToLower().Equals("false"))
        //        rbHotFixedNo.Checked = true;
        //}

        //if (!info.WasRolledBack.Equals(""))
        //{
        //    if (info.WasRolledBack.ToLower().Equals("true"))
        //        rbRolledBackYes.Checked = true;
        //    if (info.WasRolledBack.ToLower().Equals("false"))
        //        rbRolledBackNo.Checked = true;
        //}
        
        //txtDescription.Text = info.IncidentDescription;

    }

    protected void btnSaveIncidentInfo_Click(object sender, EventArgs e)
    {
        //bool HadIncident = false; 
        //String IncidentDescription = ""; 
        //int IncidentType = 0; 
        //bool WasRolledBack = false;
        //bool WasHotfixed = false;

        //if (rbHasIncidentYes.Checked)
        //    HadIncident = true;
        //if (rbHasIncidentNo.Checked)
        //    HadIncident = false;

        //if (rbRolledBackYes.Checked)
        //    WasRolledBack = true;
        //if (rbRolledBackNo.Checked)
        //    WasRolledBack = false;

        //if (rbHotFixedYes.Checked)
        //    WasHotfixed = true;
        //if (rbHotFixedNo.Checked)
        //    WasHotfixed = false;

        //int rows = ItemDAL.UpdateIncidentInfo(ItemID, HadIncident, IncidentDescription, IncidentType, WasRolledBack, WasHotfixed);
        //ErrorMessage = rows.ToString() + " have been updated";
    }
}
