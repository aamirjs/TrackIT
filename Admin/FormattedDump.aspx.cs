using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_FormattedDump : BasePage
{
    public const string TDR = "1";
    public const string CR = "2";
    public const string PR = "3";

    protected void Page_Load(object sender, EventArgs e)
    {
        //GetCCBItems();
    }

    //private void GetCCBItems()
    //{
        //gvItems.DataSource = CCBDAL.GetCCBItems();
        //gvItems.DataBind();
    //}
    protected void cbCR_CheckedChanged(object sender, EventArgs e)
    {
        GetResultByFilters();
    }
    protected void cbPR_CheckedChanged(object sender, EventArgs e)
    {
        GetResultByFilters();
    }
    protected void cbTDR_CheckedChanged(object sender, EventArgs e)
    {
        GetResultByFilters();
    }
    private void GetResultByFilters()
    {
        String crit = string.Empty;
        if (cbCR.Checked)
            crit = crit + cbCR.Text + ",";
        if (cbPR.Checked)
            crit = crit + cbPR.Text + ",";
        if (cbTDR.Checked)
            crit = crit + cbTDR.Text;

        crit = crit.TrimEnd(',');

        ErrorMessage = crit;
        //return;
        if (!crit.Equals(""))
            gvItems.DataSource = CCBDAL.GetCCBItems(crit);

        gvItems.DataBind();

    }

    public void ExportToSpreadsheet()
    {
        string delimiter = ",";

        string name = "";
        DataTable table = new DataTable();
        if (cbCR.Checked)
        {
            table = CCBDAL.GetCCBItems("CR").Tables[0];
            name = "Formatted_Dump_CR_" + DateTime.Now.ToString("yyyyMMdd");
        }
        if (cbPR.Checked)
        {
            table = CCBDAL.GetCCBItems("PR").Tables[0];
            name = "Formatted_Dump_PR_" + DateTime.Now.ToString("yyyyMMdd");
        }
        if (cbTDR.Checked)
        {
            table = CCBDAL.GetCCBItems("TDR").Tables[0];
            name = "Formatted_Dump_TDR_" + DateTime.Now.ToString("yyyyMMdd");
        }

        

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


    protected void btnImport_Click1(object sender, EventArgs e)
    {
        ExportToSpreadsheet();
    }
}
