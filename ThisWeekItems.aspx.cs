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

public partial class ThisWeekItems : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            if(!IsPostBack)
                GetThisWeekItems();
    }

    private void GetThisWeekItems()
    {
        gvThisWeekItems.DataSource = ItemDAL.GetThisWeekItems();
        gvThisWeekItems.DataBind();
    }
    protected void gvThisWeekItems_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSet ds = gvThisWeekItems.DataSource as DataSet;
        DataTable dtSortTable = ds.Tables[0];
        if (dtSortTable != null)
        {
            DataView dvSortedView = new DataView(dtSortTable);
            dvSortedView.Sort = e.SortExpression + " " + getSortDirectionString(e.SortDirection);

            gvThisWeekItems.DataSource = dvSortedView;
            gvThisWeekItems.DataBind();
        }
    }
    private string getSortDirectionString(SortDirection _sortDireciton)
    {
        string newSortDirection = String.Empty;
        if (_sortDireciton == SortDirection.Ascending)
        {
            newSortDirection = "ASC";
        }
        else
        {
            newSortDirection = "DESC";
        }
        return newSortDirection;
    }
}
