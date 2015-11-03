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

public partial class WeeklyDeployment : BasePage
{
    public string Message;



    protected void Page_Load(object sender, EventArgs e)
    {
        GetPostDeployment();
    }

    private void GetPostDeployment()
    {
        //DataTable table = (DataTable)ItemDAL.GetWeeklyDeployments();

        ////ErrorMessage=t.Select("min(TheWeek)").GetValue(0).ToString();
        DataTable dt = (DataTable)ItemDAL.GetWeeklyDeployments();
        for (int y = DateTime.Now.Year; y > 2006; y--)
        {
            for (int i = 52; i > 0; i--)
            {
                DataRow[] rows = dt.Select("TheYear=" + y + " AND TheWeek=" + i + "");
                if (rows != null && (rows.Length > 0) )
                {
                    DataTable dt1 = rows.CopyToDataTable();
                    GridView grid = new GridView();
                    //grid.Width = 1000;
                    grid.CssClass = "mGrid";
                    grid.AlternatingRowStyle.CssClass = "alt";
                    grid.DataSource = dt1;
                    grid.EmptyDataText = "No deployments";
                    grid.ShowHeader = true;
                    grid.DataBind();

                    grid.Rows[0].Cells[0].Width = 50;
                    grid.Rows[0].Cells[1].Width = 50;
                    grid.Rows[0].Cells[2].Width = 300;
                    grid.Rows[0].Cells[3].Width = 50;
                    grid.Rows[0].Cells[4].Width = 50;
                    grid.Rows[0].Cells[5].Width = 50;
                    grid.Rows[0].Cells[6].Width = 50;
                    //grid.Rows[0].Cells[7].Width = 50;
                    //grid.Rows[0].Cells[8].Width = 500;

                    Label label = new Label();
                    label.Text = "Year "+ y.ToString() + " Week " + i.ToString();
                    label.CssClass = "gridHeading";
                    Panel1.Controls.Add(label);
                    Panel1.Controls.Add(grid);
                }
            }
        }
    }

    
    protected void Page_PreRender(object sender, EventArgs e)
    {
    }

}
