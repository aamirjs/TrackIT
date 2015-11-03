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


public partial class MasterPage2 : System.Web.UI.MasterPage
{
    private string _userName;
    //private ElementInformation _ElementInformation = null;
    public string connectedTo =  "";
//    string ApplicationPath;

    String _ApplicationRoot;

    public String ApplicationRoot
    {
        get { return _ApplicationRoot; }
        set { _ApplicationRoot = value; }
    }


    public string Build
    {
        get { return Application["Build"].ToString(); }
    }

 
    public string UserName
    {
        get { return _userName; }
        set 
        { 
            _userName = value;
            //lblUser.Text = value;
        }
    }
	
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //GetBuilds();
                GetConnectedDatabase();
                _ApplicationRoot = Request.Url.Scheme + "://" + Request.Url.Host + Request.ApplicationPath;
                GetUrlList();
            }
            UserName = Request.LogonUserIdentity.Name;

            //lnkTRAPS.HRef = ConfigurationManager.AppSettings["TRAPS"];
            
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
    private void GetUrlList()
    {
        //UrlList1.DataSource = ItemDAL.GetStageSummary();
        
        //UrlList1.DataBind();
    }
    private void GetConnectedDatabase()
    {
        // string constring = ConfigurationManager.ConnectionStrings["dbSigma"].ConnectionString;
        // _ElementInformation = ConfigurationManager.ConnectionStrings["dbSigma"].ElementInformation;
        // constring = constring.Substring(constring.IndexOf("="));
        // constring = constring.Substring(1, 15);
        // connectedTo = constring;
    }


}
