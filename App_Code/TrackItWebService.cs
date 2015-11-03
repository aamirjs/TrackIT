using System;
using System.Collections;
//using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
//using System.Xml.Linq;
using System.Data;
using System.Collections.Generic;


/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class TrackItWebService : System.Web.Services.WebService
{

    public TrackItWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        return ItemDAL.GetCompletionList(prefixText, count, contextKey);
    }

    [WebMethod]
    public List<DatabaseObject> GetObjectList(string prefixText, int count, string contextKey)
    {
        return LLDDAL.GetObjectList(prefixText, count, contextKey);
    }
    
}

