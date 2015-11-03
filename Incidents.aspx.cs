using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Incidents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtStartDate.Text = new DateTime(DateTime.Now.Year - 1, 1, 1).ToString("MM-dd-yyyy");
            txtEndDate.Text = DateTime.Now.ToString("MM-dd-yyyy");
        }

        FetchIncidents();
    }

    private void FetchIncidents()
    {
        GridView1.DataSource = SWIncidentDAL.SWIncidentsAllGet();
        GridView1.DataBind();
    }
}
