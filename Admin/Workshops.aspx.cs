using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Workshops : BasePage
{
    public List<User> Requesters = new List<User>();
    public List<WorkshopStatus> WorkshopStatuses = new List<WorkshopStatus>();

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadWorkshops();
        if (!IsPostBack)
        {
            LoadRequesterList();
            LoadWorkshopStatuses();
            FillCRPRTDR();
        }
    }

    private void LoadWorkshops()
    {
        GridView1.DataSource = WorkshopDAL.GetWorkshops();
        GridView1.DataBind();
    }


    private void LoadWorkshopStatuses()
    {
        WorkshopStatuses = WorkshopDAL.GetWorkshopStatusList();
        ddlWorkshopStatuses.DataSource = WorkshopStatuses;
        ddlWorkshopStatuses.DataBind();
    }

    void LoadRequesterList()
    {
        Requesters = ItemDAL.GetUsers();
        ddlRequesters.DataSource = Requesters;
        ddlRequesters.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblWorkshopID.Text = GridView1.SelectedDataKey.Value.ToString();
        Workshop w = WorkshopDAL.GetWorkshopByID(Convert.ToInt32(lblWorkshopID.Text));
        txtSessionDate.Text = w.SdtDate.ToString();

        //Reset selected items
        ddlRequesters.Items.FindByValue(ddlRequesters.SelectedItem.Value).Selected = false;
        ddlWorkshopStatuses.Items.FindByValue(ddlWorkshopStatuses.SelectedItem.Value).Selected = false;
        ddlCRPRTDR.Items.FindByValue(ddlCRPRTDR.SelectedItem.Value).Selected = false;


        ddlRequesters.Items.FindByValue(w.IRequesterID.ToString()).Selected = true;
        ddlWorkshopStatuses.Items.FindByValue(w.SiWorkshopStatusID.ToString()).Selected = true;
        ddlCRPRTDR.Items.FindByValue(w.IITemID.ToString()).Selected = true;
        btnCreateWorkshop.Enabled = false;

    }
    private void FillCRPRTDR()
    {
        try
        {
            ddlCRPRTDR.DataSource = ItemDAL.GetListOfCRPRTDR();
            ddlCRPRTDR.DataValueField = "ItemID";
            ddlCRPRTDR.DataTextField = "CRPRTDR";
            ddlCRPRTDR.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void btnUpdateWorkshop_Click(object sender, EventArgs e)
    {
        int Workshopid = 0;
        int RequestedByid = 0;
        int itemid = 0;
        String SessionDate = String.Empty;
        int WorkshopStatusid = 0;

        Workshopid = Convert.ToInt32(lblWorkshopID.Text);
        RequestedByid = Convert.ToInt32(ddlRequesters.SelectedValue.ToString());
        itemid = Convert.ToInt32(ddlCRPRTDR.SelectedValue.ToString());
        WorkshopStatusid = Convert.ToInt32(ddlWorkshopStatuses.SelectedValue.ToString());
        SessionDate = txtSessionDate.Text;

        ErrorMessage = WorkshopDAL.WorkshopUpdate(Workshopid, RequestedByid, itemid, SessionDate, WorkshopStatusid);

        LoadWorkshops();
    }
    protected void btnCreateWorkshop_Click(object sender, EventArgs e)
    {
        int RequestedByid = 0;
        int itemid = 0;
        String SessionDate = String.Empty;
        int WorkshopStatusid = 0;

        RequestedByid = Convert.ToInt32(ddlRequesters.SelectedValue.ToString());
        itemid = Convert.ToInt32(ddlCRPRTDR.SelectedValue.ToString());
        WorkshopStatusid = Convert.ToInt32(ddlWorkshopStatuses.SelectedValue.ToString());
        SessionDate = txtSessionDate.Text;

        ErrorMessage = WorkshopDAL.WorkshopInsert(RequestedByid, itemid, SessionDate, WorkshopStatusid);

        LoadWorkshops();
    }
    protected void btnCancelWorkshop_Click(object sender, EventArgs e)
    {
        btnCreateWorkshop.Enabled = true;
        GridView1.SelectedIndex = -1;
        ddlRequesters.SelectedIndex = -1;
        txtSessionDate.Text = "";
    }

}
