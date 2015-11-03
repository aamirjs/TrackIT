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

public partial class ExcelData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowItems();
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        ShowItems();
    }
    protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        ShowItems();        
    }
    private void ShowItems()
    {
        GridView1.DataSource = ItemDAL.GetItemsExcel();
        GridView1.DataBind();
    }
    public static void ExportToSpreadsheet(DataTable table, string name)
    {
        ExportToSpreadsheet();
    }

    public static void ExportToSpreadsheet()
    {
        DataTable table = new DataTable();
        string name ="DTS_Master_List_"+DateTime.Now.ToString("yyyyMMdd");
        string delimiter = ",";

        table = ItemDAL.GetItemsExcel().Tables[0];

        HttpContext context = HttpContext.Current;
        context.Response.Clear();
        foreach (DataColumn column in table.Columns)
        {
            context.Response.Write(column.ColumnName + delimiter);
        }
        context.Response.Write(Environment.NewLine);
        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                context.Response.Write(row[i].ToString().Replace(delimiter, string.Empty) + delimiter);
            }
            context.Response.Write(Environment.NewLine);
        }
        context.Response.ContentType = "text/csv";
        context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + ".csv");
        context.Response.End();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ExportToSpreadsheet();
    }
}
