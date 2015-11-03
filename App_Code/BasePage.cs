using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BasePage
/// </summary>


public class BasePage : System.Web.UI.Page
{
    private string _error;

    public string ErrorMessage
    {
        get { return _error; }
        set { _error = value; }
    }

    public BasePage()
    {
       
    }
}
