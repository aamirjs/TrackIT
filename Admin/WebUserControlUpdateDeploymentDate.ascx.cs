using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 

public partial class AdminWebControls_WebUserControlUpdateDeploymentDate : System.Web.UI.UserControl
{
    private int _ItemID;
    private string _error;

    public DateTime ScheduledDeploymentDate
    {
        get
        {
            if (txtDate.Text == "")
                return new DateTime(1900, 1, 1);
            else
                return DateTime.Parse(txtDate.Text);
        }
        set
        {
                txtDate.Text = value.ToShortDateString();
        }
    }

    public int ItemID
    {
        get { return _ItemID; }
        set
        {
            _ItemID = value;
            txtItemID.Text = _ItemID.ToString();
        }
    }
    public string ErrorMessage
    {
        get { return _error; }
        set { _error = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //Logger.LogRun("Web User Control loading....");
        if (!IsPostBack)
        {
            txtDate.Text = "";
            txtDelayComment.Text = "";
        }
    }

    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Logger.LogRun("Web User Btn Clicked....");
        DateTime ScheduledDeploymentDate = new DateTime();
        Item i = new Item();

        try
        {
            i.ItemID = Int32.Parse(this.txtItemID.Text);
            if (txtDate.Text == "")
            {
                ErrorMessage = "Please select a date";
                return;
            }
            if (txtDelayComment.Text == "")
            {
                ErrorMessage = "Please enter comments.";
                return;
            }

            try
            {
                ScheduledDeploymentDate = DateTime.Parse(txtDate.Text);
            }
            catch (Exception exc)
            {
                ErrorMessage = exc.Message+"<br>The date is invalid.";
                return;
            }
            i.ScheduledDeploymentDate = ScheduledDeploymentDate;
            ItemDAL.UpdateScheduledDeploymentDate(i, txtDelayComment.Text);

            GridView1.DataSource = ItemDAL.GetDelayInformation(i.ItemID);
            GridView1.DataBind();

            txtDelayComment.Text = "";
            //txtDate.Text = "";

        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
}
