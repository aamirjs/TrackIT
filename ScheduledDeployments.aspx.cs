using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScheduledDeployments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            GetDepCounts();
    }

    private void GetDepCounts()
    {
        GridView1.DataSource = DepDatesDAL.DeploymentCountsGet();
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDeploymentsOnDate(GridView1.SelectedDataKey.Value.ToString());
    }

    private void GetDeploymentsOnDate(String DateSelected)
    {
        GridView2.DataSource = DepDatesDAL.ScheduledDeploymentsByDateGet(DateSelected);
        GridView2.DataBind();    
    }
}
