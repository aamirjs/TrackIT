using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class PostDeployment : System.Web.UI.Page
{
    public string Message;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetPostDeployment();
    }

    private void GetPostDeployment()
    {
        gvPostDeploymentChecklist.DataSource = ItemDAL.GetPostDeployment();
        gvPostDeploymentChecklist.DataBind();
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string GetDynamicContent(string contextKey)
    {
        return default(string);
    }

    protected void btnRemark_Click(object sender, EventArgs e)
    {
        Message = gvPostDeploymentChecklist.DataKeyNames[0];
    }

    
     

    protected void Page_PreRender(object sender, EventArgs e)
    {
    }

    protected void gvPostDeploymentChecklist_PreRender(object sender, EventArgs e)
    {
    }
    protected void gvPostDeploymentChecklist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 5; i < e.Row.Cells.Count; i++)
        {
            if (e.Row.Cells[i].Text.Equals("") || e.Row.Cells[i].Text.Equals("&nbsp;"))
                e.Row.Cells[i].BackColor = System.Drawing.Color.Black;

            if (e.Row.Cells[i].Text.Equals("-999 Days"))
                e.Row.Cells[i].BackColor = System.Drawing.Color.LightSkyBlue;

            if (e.Row.Cells[i].Text.Contains("Days"))
            {
                //e.Row.Cells[i].Style.Clear();
                e.Row.Cells[i].CssClass = "PendingPDC";
            } 
        }
    }
}
