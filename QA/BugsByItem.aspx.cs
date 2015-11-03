using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class BugsByItem : BasePage
{
    String ItemID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCRPRTDR();
            if (Request.QueryString["ItemID"] != null)
            {
                ItemID = Request.QueryString["ItemID"].ToString();
                //Response.Write(iTemName);
                ddlCRPRTDR.Items.FindByValue(ItemID).Selected = true;
                ddlCRPRTDR_SelectedIndexChanged(ddlCRPRTDR, new EventArgs());
            }

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
    protected void ddlCRPRTDR_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillData();
            GridView1.EditIndex = -1;
            txtQACount.Text = "";
            txtQAPhaseComment.Text = "";
            txtUATCount.Text = "";
            txtUATPhaseComment.Text = "";
            txtIntCount.Text = "";
            txtIntPhaseComment.Text = "";
            txtPDCount.Text = "";
            txtPostDepPhaseComment.Text = "";
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
            GridView1.DataSource = BugsDAL.GetBugsByItem(ItemID);
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
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int IBugID = (int)GridView1.DataKeys[e.RowIndex].Value;
        try
        {

            Label LabelItemID = (Label)(GridView1.Rows[GridView1.EditIndex].Cells[0].FindControl("lbliItemID"));
            TextBox txtQAPhaseSumm = (TextBox)(GridView1.Rows[GridView1.EditIndex].Cells[1].FindControl("txtQAPhaseSumm"));
            TextBox txtUATPhaseSumm = (TextBox)(GridView1.Rows[GridView1.EditIndex].Cells[1].FindControl("txtUATPhaseSumm"));
            TextBox txtIntPhaseSumm = (TextBox)(GridView1.Rows[GridView1.EditIndex].Cells[1].FindControl("txtINTPhaseSumm"));
            TextBox txtPostDepPhaseSumm = (TextBox)(GridView1.Rows[GridView1.EditIndex].Cells[1].FindControl("txtPostDepPhaseSumm"));

            TextBox txtQACount = (TextBox)(GridView1.Rows[GridView1.EditIndex].Cells[1].FindControl("txtQACount"));
            TextBox txtUATCount = (TextBox)(GridView1.Rows[GridView1.EditIndex].Cells[1].FindControl("txtUATCount"));
            TextBox txtINTCount = (TextBox)(GridView1.Rows[GridView1.EditIndex].Cells[1].FindControl("txtINTCount"));
            TextBox txtPostDepCount = (TextBox)(GridView1.Rows[GridView1.EditIndex].Cells[1].FindControl("txtPostDepCount"));

            Bug b = new Bug();
            b.IBugID = IBugID;
            b.IItemID = Convert.ToInt32(LabelItemID.Text);
            b.vcQAPhaseSumm = txtQAPhaseSumm.Text;
            b.vcUATPhaseSumm = txtUATPhaseSumm.Text;
            b.vcINTPhaseSumm = txtIntPhaseSumm.Text;
            b.vcPostDepPhaseSumm = txtPostDepPhaseSumm.Text;
            b.SiQACount = Convert.ToInt16(txtQACount.Text);
            b.SiUATCount = Convert.ToInt16(txtUATCount.Text);
            b.SiINTCount = Convert.ToInt16(txtINTCount.Text);
            b.SiPDCount = Convert.ToInt16(txtPostDepCount.Text);


            if (BugsDAL.UpdateBug(b) > 0)
                ErrorMessage = "Record inserted successfully.";
            else
                ErrorMessage = "No record inserted.";


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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlBugStatus");
                if (ddl != null)
                {
                    ddl.DataSource = BugsDAL.GetStbBugsStatus();
                    ddl.DataBind();
                }
            }
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Bug b = new Bug();
        try
        {
            b.IItemID = Convert.ToInt32(ddlCRPRTDR.SelectedValue.ToString());
            b.vcQAPhaseSumm = txtQAPhaseComment.Text;
            b.vcUATPhaseSumm = txtUATPhaseComment.Text;
            b.vcPostDepPhaseSumm = txtPostDepPhaseComment.Text;
            b.vcINTPhaseSumm = txtIntPhaseComment.Text;

            b.SiQACount = Convert.ToInt16(txtQACount.Text);
            b.SiUATCount = Convert.ToInt16(txtUATCount.Text);
            b.SiPDCount = Convert.ToInt16(txtPDCount.Text);
            b.SiINTCount = Convert.ToInt16(txtIntCount.Text);

            if (BugsDAL.AddBug(b) > 0)
                ErrorMessage = "Record inserted successfully.";
            else
                ErrorMessage = "No record inserted.";

            ClearFields();
            FillData();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }

    }

    private void ClearFields()
    {

        txtQAPhaseComment.Text = "";
        txtUATPhaseComment.Text = "";
        txtPostDepPhaseComment.Text = "";
        txtIntPhaseComment.Text = "";

        txtQACount.Text = "";
        txtUATCount.Text = "";
        txtPDCount.Text = "";
        txtIntCount.Text = "";

    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
    }
    private void DeleteRecord(Int32 iBugID)
    {
        try
        {
            BugsDAL.DeleteBug(iBugID);
            FillData();
            GridView1.EditIndex = -1;
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

            Label LabelBugID = ((Label)GridView1.Rows[currentRowIndex].FindControl("lbliBugID"));

            DeleteRecord(Convert.ToInt32(LabelBugID.Text));

        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
}
