using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

/// <summary>
/// Summary description for BuildItems
/// </summary>
public class BuildItems
{
    string _status;

    public string vcStatus
    {
        get { return _status; }
        set { _status = value; }
    }
    int _counts;

    public int iCounts
    {
        get { return _counts; }
        set { _counts = value; }
    }

    int _iStatusID;

    public int iStatusID
    {
        get { return _iStatusID; }
        set { _iStatusID = value; }
    }

	public BuildItems()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
