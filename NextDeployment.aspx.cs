using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NextDeployment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetScheduledDeployments();
    }

    private void GetScheduledDeployments()
    {
        gvScheduledDeployment.DataSource = ItemDAL.GetScheduledDeployments();
        gvScheduledDeployment.DataBind();
    }

}
