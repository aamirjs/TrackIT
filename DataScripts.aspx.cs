using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataScripts : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            //FillDatabases();
            FetchDataScripts();
            //FillUsers();
            txtUpdateDate.Text = "";
            txtUpdateDate.Enabled = false;
        }
        //if (GridView1.EditIndex > -1)
        //{
        //    DatabaseID = Convert.ToInt32(((Label)GridView1.Rows[GridView1.EditIndex].FindControl("lblDatabaseID")).Text);
        //}

    }

    private void FetchDataScripts()
    {
        GridView1.DataSource = DataScriptDAL.FetchDataScripts();
        GridView1.DataBind();
    }
    private void FillCRPRTDR(DropDownList ddl)
    {
        try
        {
            ddl.DataSource = ItemDAL.GetListOfCRPRTDR();
            ddl.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    private void FillUsers(DropDownList ddl)
    {
        try
        {
            ddl.DataSource = ItemDAL.GetUsers();
            ddl.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    private void FillDatabases(DropDownList ddl)
    {
        try
        {
            ddl.DataSource = DataScriptDAL.GetDatabases();
            ddl.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }

    private void FillDataScriptStatus(DropDownList ddl)
    {
        try
        {
            ddl.DataSource = DataScriptDAL.GetDataScriptStatus();
            ddl.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }



    private void DeleteRecord(string histid, string iItemID)
    {
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            DataScriptDAL.InsertDataScript(
                Convert.ToInt32(ddlDimensionNumber.SelectedItem.Value),
                txtScriptName.Text,
                txtModuleName.Text,
                txtDescription.Text,
                txtParameters.Text, 
                Convert.ToInt32(1111111),
                Convert.ToInt32(2222222), 
                cbIsBackEnd.Checked
                ); 

        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
        FetchDataScripts();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ;
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        FetchDataScripts();

        DropDownList ddlDatabase = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("ddlDatabase");
        


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlDatabase = (DropDownList)e.Row.FindControl("ddlDatabase");
            if (ddlDatabase != null)
            {
                FillDatabases(ddlDatabase);
            }

            


            DropDownList ddlLastUpdateBy = (DropDownList)e.Row.FindControl("ddlLastUpdateBy");
            if (ddlLastUpdateBy != null)
            {
                FillUsers(ddlLastUpdateBy);
            }

            DropDownList ddlDimensionNumbers = (DropDownList)e.Row.FindControl("ddlDimensionNumbers");
            if (ddlDimensionNumbers != null)
            {
                FillCRPRTDR(ddlDimensionNumbers);
            }

            DropDownList ddlDataScriptStatus = (DropDownList)e.Row.FindControl("ddlDataScriptStatus");
            if (ddlDataScriptStatus != null)
            {
                FillDataScriptStatus(ddlDataScriptStatus);
            }

            

        }
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        FetchDataScripts();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        
        //ErrorMessage = ((Label)e.Row.FindControl("lblvcDatabase")).Text;


        GridViewRow row = GridView1.Rows[e.RowIndex];
        String DataScriptID = ((Label) row.FindControl("lblDataScriptID")).Text;
        
        String ItemID = ((Label)row.FindControl("lblvcDimensionNumber")).Text;
        ((DropDownList)row.FindControl("ddlDimensionNumbers")).Items.FindByText(ItemID).Selected = true;
        

        String FileName = ((TextBox)row.FindControl("txtvcFileName")).Text;
        String ModuleName = ((TextBox)row.FindControl("txtvcModuleName")).Text;
        String Description = ((TextBox)row.FindControl("txtvcDescription")).Text;
        String Parametres = ((TextBox)row.FindControl("txtvcParametres")).Text;
        //String UpdateDate = ((TextBox)row.FindControl("txtdtUpdateDate")).Text;
        String DatabaseID = ((DropDownList)row.FindControl("ddlDatabase")).SelectedItem.Value;
        Boolean IsBackEnd = ((CheckBox)row.FindControl("cbIsBackEnd")).Checked;
        String DataScriptStatusID = ((DropDownList)row.FindControl("ddlDataScriptStatus")).SelectedItem.Value;

        ErrorMessage = @DataScriptID + "-" + ItemID + "-" + FileName + "-" + ModuleName + "-" + Parametres + "-" + IsBackEnd + "-" + DataScriptStatusID;
        GridView1.EditIndex = -1;

        //DataScriptDAL.UpdateDataScript(
        //    DataScriptID, ItemID, FileName, 
        //    ModuleName, Description, Parametres, 
        //    DatabaseID, IsBackEnd, DataScriptStatusID, 
        //    Request.LogonUserIdentity.Name);

        FetchDataScripts();
        
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}
