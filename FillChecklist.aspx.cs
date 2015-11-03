using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI.HtmlControls;

public partial class FillChecklist : BasePage
{
    short LockedRowCount = 0, UnlockedRowCount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCRPRTDR();
            ddlType.SelectedIndex = 0;
            FillItemChecklist(ddlType.SelectedItem.Value);
        }
        if (ddlCRPRTDR.SelectedIndex == -1)
            ImgLocked.Visible = false;
        else
            ImgLocked.Visible = true;
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
    protected void ddlCRPRTDR_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlType.SelectedIndex < 0)
                ddlType.SelectedIndex = 0;
            FillItemChecklist(ddlType.SelectedItem.Value);
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillItemChecklist(ddlType.SelectedItem.Value);
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    private void FillItemChecklist(String options)
    {
        try
        {
            GridView1.DataSource = ChecklistDAL.GetItemChecklist(Int32.Parse(ddlCRPRTDR.SelectedItem.Value), options);
            GridView1.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (LockedRowCount > UnlockedRowCount)
            ImgLocked.ImageUrl = "~/images/Lock.png";
        else
            ImgLocked.ImageUrl = "~/images/UnLocked.png";

        //ddlCRPRTDR.Focus();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var LabelItemID = e.Row.FindControl("lblItemID") as Label;
                var ImgResponse = e.Row.FindControl("ImgResponse") as Image;
                var ImgLocked = e.Row.FindControl("ImgLocked") as Image;
                var lblResponse = e.Row.FindControl("lblResponse") as Label;
                var lblLocked = e.Row.FindControl("lblLocked") as Label;


                if (LabelItemID != null)
                {
                    if (LabelItemID.Text == "")//Is the entry filled yet.
                    {
                        ImgResponse.ImageUrl = "~/images/not_filled_yellow.png"; ;
                        e.Row.BackColor = System.Drawing.Color.Khaki;
                    }
                    else
                    {
                        if (lblLocked.Text.Equals("True"))
                            //ImgLocked.ImageUrl = "~/images/Lock.png";
                            LockedRowCount++;
                        else
                            UnlockedRowCount++;
                        //ImgLocked.ImageUrl = "~/images/UnLocked.png";

                        if (lblResponse.Text.Equals("Yes"))
                            ImgResponse.ImageUrl = "~/images/yes.jpg";
                        else if (lblResponse.Text.Equals("No"))
                            ImgResponse.ImageUrl = "~/images/no.jpg";
                        else
                            ImgResponse.ImageUrl = "~/images/empty.png";

                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = Environment.StackTrace.GetType().AssemblyQualifiedName + " " + ex.Message;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            //ErrorMessage = "Row Command=" + e.CommandName;
            // If multiple buttons are used in a GridView control, use the
            // CommandName property to determine which button was clicked.
            if (e.CommandName == "Yes" || e.CommandName == "No" || e.CommandName == "Na")
            {
                // Convert the row index stored in the CommandArgument property to an Integer.
                int rowindex = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button clicked 
                // by the user from the Rows collection.      
                GridViewRow row = GridView1.Rows[rowindex];

                // Calculate the new price.
                String EntryID = ((Label)row.FindControl("lblEntryID")).Text;
                String ItemID = ((Label)row.FindControl("lblItemID")).Text;
                String Comment = ((TextBox)row.FindControl("txtComment")).Text;

                // Update the row.
                //GridView1.UpdateRow(index, false);
                if (ItemID.Equals(""))
                    InsertEntry(EntryID, ddlCRPRTDR.SelectedItem.Value, e.CommandName, Comment);
                else
                    UpdateSDChecklistForItem(EntryID, ItemID, e.CommandName, Comment);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = Environment.StackTrace.GetType().AssemblyQualifiedName + " " + ex.Message;
        }
    }
    private void InsertEntry(string EntryID, string ItemID, string UserResponse, string Comment)
    {
        try
        {
            ChecklistDAL.InsertEntry(EntryID, ItemID, UserResponse, Comment);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        FillItemChecklist(ddlType.SelectedItem.Value);

    }
    private void UpdateSDChecklistForItem(String SequenceID, String ItemID, string Response, String Comment)
    {
        try
        {
            ChecklistDAL.UpdateSDChecklistForItem(SequenceID, ItemID, Response, Comment, ddlType.SelectedItem.Value);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

        FillItemChecklist(ddlType.SelectedItem.Value);
    }
    protected void btnFreeze_Click(object sender, EventArgs e)
    {
        try
        {
            ChecklistDAL.ChecklistLockChange(ddlCRPRTDR.SelectedItem.Value, ddlType.SelectedItem.Value, true);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        FillItemChecklist(ddlType.SelectedItem.Value);
    }
    protected void btnUnFreeze_Click(object sender, EventArgs e)
    {
        try
        {
            ChecklistDAL.ChecklistLockChange(ddlCRPRTDR.SelectedItem.Value, ddlType.SelectedItem.Value, false);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        FillItemChecklist(ddlType.SelectedItem.Value);
    }
}
