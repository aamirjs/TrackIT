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

public partial class GetItemsByStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillStatus();
        }
        //if (Request.Params["StatusID"] != null)
        //{
        //    ddlStatus.Items.FindByValue(Request.Params["StatusID"].ToString()).Selected = true;
        //    GetItems();
        //    Request.QueryString["StatusID"] = null;
        //}
    }

    private void FillStatus()
    {
        ddlStatus.DataSource = StatusDAL.GetStatuses();
        ddlStatus.DataValueField = "iStatusID";
        ddlStatus.DataTextField = "vcStatus";
        ddlStatus.DataBind();
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetItems();
    }

    private void GetItems()
    {
        GridView1.DataSource = ItemDAL.SearchByStatusID(ddlStatus.SelectedValue.ToString());
        GridView1.DataBind();
    }
}
