using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_IncidentManagement : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadIncidents();
        }
    }
    private void LoadIncidents()
    {
        try
        {
            DataTable dt = IncidentDAL.GetIncidentsDS().Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }

    
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        LoadIncidents();
    }

    

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Server.Transfer("ManageIncident.aspx?id=" + GridView1.SelectedValue.ToString());
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        LoadIncidents();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Server.Transfer("ManageIncident.aspx");
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int currentRowIndex = e.RowIndex;
        string IncidentID = ((Label)GridView1.Rows[currentRowIndex].FindControl("lbliIncidentID")).Text;

        DeleteRecord(Convert.ToInt32(IncidentID));
    }

    private void DeleteRecord(int IncidentID)
    {
        IncidentDAL.Delete(IncidentID);
        LoadIncidents();
    }

}
