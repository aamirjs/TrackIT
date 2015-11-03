using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Collections.Generic;


public partial class Search : System.Web.UI.Page
{
    private string _error;
    
    public string ErrorMessage
    {
        get { return _error; }
        set { _error = value; }
    }


    
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    //public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    //{
    //    return ItemDAL.GetCompletionList(prefixText, count, contextKey);
    //}

    //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    //public static DataSet GetDataSet(string prefixText)
    //{
    //    return ItemDAL.GetDataSet(prefixText);
    //}


    protected void txtNames_TextChanged(object sender, EventArgs e)
    {
        string search = txtNames.Text.Split('-')[0].ToString();
        GridView1.DataSource = ItemDAL.GetItemByCRPRTDR(search);
        GridView1.DataBind();
    }

    
    void LogRun(string message)
    {
        //try
        //{
        //    string filename = DateTime.Now.ToString("dd-MMM-yyyy") + ".txt";
        //    Console.WriteLine(message);
        //    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(Request.PhysicalApplicationPath + filename, true, Encoding.Default))
        //    {
        //        writer.WriteLine(DateTime.Now.ToString() + ":" + message);
        //        writer.Flush();
        //        writer.Close();
        //    }
        //}
        //catch (Exception e)
        //{
        //    ErrorMessage = e.Message;
        //}
    }

}