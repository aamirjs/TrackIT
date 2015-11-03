using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.IO;
/// <summary>
/// Summary description for Logger
/// </summary>
public class Logger
{
	public Logger()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //        Response.Write(Request.PhysicalApplicationPath);
    public static void LogRun(string message)
    {
        try
        {
            string filename = DateTime.Now.ToString("dd-MMM-yyyy") + ".txt";
            Console.WriteLine(message);
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(HttpContext.Current.Request.PhysicalApplicationPath + filename, true, Encoding.Default))
            {
                writer.WriteLine(DateTime.Now.ToString() + ":" + message);
                writer.Flush();
                writer.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void LogCallerInfo(HttpContext context)
    {
    }



    public static string ReadKey(string p)
    {
        if (ConfigurationManager.AppSettings[p] == null)
            return "Unknown AppSettings[" + p + "]";
        else
        return ConfigurationManager.AppSettings[p].ToString();
    }

    
}
