using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class Progress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetProgress();
    }

    private void GetProgress()
    {
        //gvItemsPendingPDC.DataSource = Client.GetPendingPDCItems();
        GridView1.DataSource = ItemDAL.GetProgress();
        GridView1.DataBind();
    }

}
