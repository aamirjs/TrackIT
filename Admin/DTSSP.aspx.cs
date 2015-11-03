using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_DTSSP : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    private void LoadData()
    {
        try
        {
            if (txtSearch.Text.Length > 0)
            {
                string search = txtSearch.Text.Split('-')[0].ToString();
                GridView1.DataSource = LLDDAL.GetObjectList(search, 5000, "");
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = LLDDAL.GetFullSPData();
                GridView1.DataBind();
            }
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
            //GridView1.Rows[GridView1.EditIndex].BackColor = System.Drawing.Color.DarkGray;
            LoadData();
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
            LoadData();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string spid = GridView1.DataKeys[e.RowIndex].Value.ToString();
        try
        {

            Label lblspID = (Label)(GridView1.Rows[GridView1.EditIndex].Cells[0].FindControl("lblspID"));
            TextBox txtName = (TextBox)(GridView1.Rows[GridView1.EditIndex].Cells[1].FindControl("txtName"));
            TextBox txtDescription = (TextBox)(GridView1.Rows[GridView1.EditIndex].Cells[1].FindControl("txtDescription"));


            if (LLDDAL.UpdateSPDescription(lblspID.Text, txtDescription.Text) > 0)
                ErrorMessage = "Updated.....";
            else
                ErrorMessage = "No action done.";


            GridView1.EditIndex = -1;
            LoadData();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int currentRowIndex = e.RowIndex;
        try
        {
            Label lblspID = ((Label)GridView1.Rows[currentRowIndex].FindControl("spid"));
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }

    //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    //public static List<DatabaseObject> GetCompletionList(string prefixText, int count, string contextKey)
    //{
    //    return LLDDAL.GetCompletionList(prefixText, count, contextKey);
    //}


    protected void txtNames_TextChanged(object sender, EventArgs e)
    {
        LoadData();        
    }


}
