using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SWIncident : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCRPRTDR();
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ddlCRPRTDR.Focus();
    }
    private void FillCRPRTDR()
    {
        try
        {
            ddlCRPRTDR.DataSource = ItemDAL.GetListOfCRPRTDR();
            ddlCRPRTDR.DataValueField = "ItemID";
            ddlCRPRTDR.DataTextField = "CRPRTDR";
            ddlCRPRTDR.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }

    protected void btnSaveIncidentInfo_click(object sender, EventArgs e)
    {
       
    }
    private void ResetControls()
    {
        //Logger.LogRun("     Control has reset all controls.....");
        rbHasIncidentYes.Checked = false;
        rbHotFixedYes.Checked = false;
        rbRolledBackYes.Checked = false;

        rbHasIncidentNo.Checked = false;
        rbHotFixedNo.Checked = false;
        rbRolledBackNo.Checked = false;

        txtIncidentDescription.Text = "";
        txtincidentDate.Text = "";
        txtincidentNumber.Text = "";
    }
    private void GetIncidentInfo(int ItemID)
    {
        ////Logger.LogRun("     Control has called GetIncidentInfo()");
        //List<IncidentInfo> info = ItemIncidentDAL.GetIncidentInfo(ItemID);
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

    protected void ddlCRPRTDR_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillData();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    private void FillData()
    {
        try
        {
            int ItemID = Convert.ToInt32(ddlCRPRTDR.SelectedItem.Value);
            GridView1.DataSource = SWIncidentDAL.SWIncidentByItemGet(ItemID);
            GridView1.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = e.NewEditIndex;
            FillData();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = -1;
            FillData();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DropDownList ddl = (DropDownList)e.Row.FindControl("ddlBugStatus");
            //    if (ddl != null)
            //    {
            //        ddl.DataSource = BugsDAL.GetStbBugsStatus();
            //        ddl.DataBind();
            //    }
            //}
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (GridView1.SelectedIndex < 0)
            {
                ErrorMessage = "Nothing to update";
                return;
            }


            Int32 IncidentID = Convert.ToInt32(GridView1.SelectedDataKey.Value.ToString());

            bool hadincident = false;
            int incidenttype = 0;
            bool wasrolledback = false;
            bool washotfixed = false;

            if (rbHasIncidentYes.Checked)
                hadincident = true;
            if (rbHasIncidentNo.Checked)
                hadincident = false;

            if (rbRolledBackYes.Checked)
                wasrolledback = true;
            if (rbRolledBackNo.Checked)
                wasrolledback = false;

            if (rbHotFixedYes.Checked)
                washotfixed = true;
            if (rbHotFixedNo.Checked)
                washotfixed = false;

            string incidentdescription = txtIncidentDescription.Text;

            int rows = SWIncidentDAL.SWIncidentUpdate(
                                    IncidentID, 
                                    hadincident, 
                                    incidentdescription, 
                                    incidenttype, 
                                    wasrolledback, 
                                    washotfixed,
                                    txtincidentNumber.Text,
                                    Convert.ToDateTime(txtincidentDate.Text)
                                    );
            ErrorMessage = rows.ToString() + " row(s) updated";
            //GetIncidentInfo(IncidentID);
            ResetControls();
            GridView1.SelectedIndex = -1;
            FillData();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }

    }

    private void DeleteRecord(Int32 iIncidentID)
    {
        try
        {
            SWIncidentDAL.SWIncidentDelete(iIncidentID);
            FillData();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int currentRowIndex = e.RowIndex;
        try
        {

            Label lbliIncidentID = ((Label)GridView1.Rows[currentRowIndex].FindControl("lbliIncidentID"));

            DeleteRecord(Convert.ToInt32(lbliIncidentID.Text));

        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 IncidentID = Convert.ToInt32(GridView1.SelectedDataKey.Value.ToString());
        GetIncidentByIncidentID(IncidentID);

    }
    private void GetIncidentByIncidentID(Int32 IncidentID)
    {
        try
        {
            int ItemID = Convert.ToInt32(ddlCRPRTDR.SelectedItem.Value);
            ItemIncident incident = SWIncidentDAL.SWIncidentByIncidentIDGet(IncidentID);
            if (incident.BHasIncident.HasValue)
            {
                if (incident.BHasIncident.Value == true)
                    rbHasIncidentYes.Checked = true;
                else
                    rbHasIncidentNo.Checked = true;
            }

            if (incident.BHotfixed.HasValue)
            {
                if (incident.BHotfixed.Value == true)
                    rbHotFixedYes.Checked = true;
                else
                    rbHotFixedNo.Checked = true;
            }
            if (incident.BRolledBack.HasValue)
            {
                if (incident.BRolledBack.Value == true)
                    rbRolledBackYes.Checked = true;
                else
                    rbRolledBackNo.Checked = true;
            }
            txtIncidentDescription.Text = incident.VcDescription;
            if(incident.sdtIncidentDate.HasValue)
                txtincidentDate.Text = incident.sdtIncidentDate.Value.ToString();


            txtincidentNumber.Text = incident.vcIncidentNumber;    
        
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            Int32 ItemID = Convert.ToInt32(ddlCRPRTDR.SelectedItem.Value.ToString());

            bool hadincident = false;
            //int incidenttype = 0;
            bool wasrolledback = false;
            bool washotfixed = false;

            if (rbHasIncidentYes.Checked)
                hadincident = true;
            if (rbHasIncidentNo.Checked)
                hadincident = false;

            if (rbRolledBackYes.Checked)
                wasrolledback = true;
            if (rbRolledBackNo.Checked)
                wasrolledback = false;

            if (rbHotFixedYes.Checked)
                washotfixed = true;
            if (rbHotFixedNo.Checked)
                washotfixed = false;

            string incidentdescription = txtIncidentDescription.Text;
            string IncidentNumber = txtincidentNumber.Text;
            DateTime IncidentDate = DateTime.Parse(txtincidentDate.Text);

            int rows = SWIncidentDAL.SWIncidentInsert(ItemID, 
                incidentdescription, 
                IncidentNumber,
                IncidentDate,
                hadincident, 
                wasrolledback, 
                washotfixed);
            ErrorMessage = rows.ToString() + " row(s) updated";
            //GetIncidentInfo(IncidentID);
            ResetControls();
            GridView1.SelectedIndex = -1;
            FillData();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
}
