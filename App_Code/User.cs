using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    int iUserID;

    public int UserID
    {
        get { return iUserID; }
        set { iUserID = value; }
    }
    string vcWindowsLogin;

    public string WindowsLogin
    {
        get { return vcWindowsLogin; }
        set { vcWindowsLogin = value; }
    }
    string vcFirstName;

    public string FirstName
    {
        get { return vcFirstName; }
        set { vcFirstName = value; }
    }
    string vcLastName;

    public string LastName
    {
        get { return vcLastName; }
        set { vcLastName = value; }
    }
    string vcEmail;

    public string Email
    {
        get { return vcEmail; }
        set { vcEmail = value; }
    }

    string vcFullName;

    public string FullName
    {
        get { return vcFullName; }
        set { vcFullName = value; }
    }


}
