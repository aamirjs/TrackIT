using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

public partial class Admin_ManageIncident : BasePage
{
    string Mode = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            Mode = "U";
            pnlCreate.Visible = true;
            pnlStatus.Visible = true;
            pnlFileUpload.Visible = false;

        }
        else
        {
            Mode = "C";
            pnlCreate.Visible = true;
            pnlStatus.Visible = false;
            pnlFileUpload.Visible = true;
        }


        if (!IsPostBack)
        {
            LoadincidentStatus();
            LoadIncidentTypes();
            if (Mode == "U")
                GetIncidentDetail(Request.QueryString["ID"]);
        }
    }
    private void LoadincidentStatus()
    {
        ddlIncidentStatus.DataSource = IncidentDAL.GetIncidentStatusList();
        ddlIncidentStatus.DataBind();

    }
    private void GetIncidentDetail(string IIncidentID)
    {
        Incident i = IncidentDAL.GetIncidentDetailByID(IIncidentID);

        lblIncidentID.Text = i.IIncidentID.ToString();
        txtIncidentNumber.Text = i.VCIncidentNumber;
        ddlincidentTypes.Items.FindByText(i.VCIncidentType).Selected = true;

        LoadIncidentLocations(i.VCIncidentType);

        ddlincidentLocations.Items.FindByText(i.VCIncidentLocation).Selected = true;
        ddlincidentTypes.Items.FindByText(i.VCIncidentType).Selected = true;

        LoadIncidentsByLocation();

        ddlIncident.Items.FindByText(i.VCIncident).Selected = true;
        ddlImpact.Items.FindByText(i.VCImpact).Selected = true;
        txtIncidentDate.Text = i.DTincidentDate.ToString("dd-MMM-yyyy");
        txtincidentTime.Text = i.DTIncidentTime.ToString("hh:mm");
        txtDescription.Text = i.VCDescription;

        GetIncidentHistory(IIncidentID);

    }
    private void GetIncidentHistory(string IIncidentID)
    {
        GridView1.DataSource = IncidentDAL.GetIncidentHistory(IIncidentID);
        GridView1.DataBind();
    }
    private void UpdateIncidentDetail()
    {
        Incident i = new Incident();
        try
        {
            i.IIncidentID = Convert.ToInt32(lblIncidentID.Text);
            i.VCIncidentNumber = txtIncidentNumber.Text;
            i.VCIncidentType = ddlincidentTypes.SelectedItem.Value;
            i.VCIncidentLocation = ddlincidentLocations.SelectedItem.Value;
            i.VCIncidentType = ddlincidentTypes.SelectedItem.Value;
            i.VCIncident = ddlIncident.SelectedItem.Value;
            i.VCImpact = ddlImpact.SelectedItem.Value;
            i.DTincidentDate = Convert.ToDateTime(txtincidentTime.Text);
            i.VCDescription = txtDescription.Text;

            if (IncidentDAL.UpdateIncidentDetail(i))
                ErrorMessage = "Success: Details updated.";
            else
                ErrorMessage = "Error: Update failed.";
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }

    }
    private void LoadIncidentTypes()
    {
        try
        {
            ddlincidentLocations.Items.Clear();
            ddlIncident.Items.Clear();
            ddlincidentTypes.DataSource = IncidentDAL.GetIncidentTypes();
            ddlincidentTypes.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    private void LoadIncidentLocations(string incidentType)
    {
        try
        {
            ddlIncident.Items.Clear();
            ddlincidentLocations.DataSource = IncidentDAL.GetIncidentLocations(incidentType);
            ddlincidentLocations.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    private void LoadIncidentsByLocation()
    {
        try
        {
            string incidentType = ddlincidentTypes.SelectedItem.Text;
            string Location = ddlincidentLocations.SelectedItem.Text;
            ddlIncident.DataSource = IncidentDAL.LoadIncidentsByLocation(incidentType, Location);
            ddlIncident.DataBind();
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void ddlincidentTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadIncidentLocations(ddlincidentTypes.SelectedItem.Text);
    }
    protected void ddlincidentLocations_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadIncidentsByLocation();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Mode == "U")
            UpdateIncidentDetail();
        else
            InsertIncidentDetail();

        //Server.Transfer("IncidentManagement.aspx");

    }
    private void InsertIncidentDetail()
    {

        string vcIncidentType = String.Empty;
        string vcIncidentLocation = String.Empty;
        string vcIncident = String.Empty;
        string vcImpact = String.Empty;
        String dtincidentDate = String.Empty;
        String dtIncidentTime = String.Empty;
        String vcDescription = String.Empty;
        String vcIncidentNumber = String.Empty;
        int IncidentID = 0; 

        try
        {
            vcIncidentNumber = txtIncidentNumber.Text; 
            vcIncidentType = ddlincidentTypes.SelectedItem.Value;
            vcIncidentLocation = ddlincidentLocations.SelectedItem.Value;
            vcIncident = ddlIncident.SelectedItem.Value;
            vcImpact = ddlImpact.SelectedItem.Value;
            vcDescription = txtDescription.Text;
            dtincidentDate = txtIncidentDate.Text;
            dtIncidentTime = txtincidentTime.Text;



            IncidentID = IncidentDAL.CreateIncident(
                vcIncidentNumber,
                vcIncidentType,
                vcIncidentLocation,
                vcIncident,
                vcImpact,
                vcDescription,
                dtincidentDate,
                dtIncidentTime
                );


            InsertIncidentFiles(IncidentID);
            ErrorMessage = "Success: Incident create.";

        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }

    }
    protected void btnUpdateStatus_Click(object sender, EventArgs e)
    {
        try
        {
            IncidentDAL.UpdateIncidentStatus(ddlIncidentStatus.SelectedItem.Value, lblIncidentID.Text);
            GetIncidentHistory(txtIncidentNumber.Text);
        }
        catch (Exception exc)
        {
            ErrorMessage = exc.Message;
        }
    }
    protected void btnCancelStatus_Click(object sender, EventArgs e)
    {
        Server.Transfer("IncidentManagement.aspx");
    }
    protected void InsertIncidentFiles(int IncidentID)
    {
        string filepath = ConfigurationManager.AppSettings["PathToSaveFiles"].ToString();
        HttpFileCollection uploadedFiles = Request.Files;

        for (int i = 0; i < uploadedFiles.Count; i++)
        {
            HttpPostedFile userPostedFile = uploadedFiles[i];

            try
            {
                if (userPostedFile.ContentLength > 0)
                {
                    String outFolder = filepath + "\\" + IncidentID.ToString();
                    System.IO.Directory.CreateDirectory(outFolder);

                    Label1.Text += "<u>File #" + (i + 1) +
                       "</u><br>";
                    Label1.Text += "File Content Type: " +
                       userPostedFile.ContentType + "<br>";
                    Label1.Text += "File Size: " +
                       userPostedFile.ContentLength + "kb<br>";
                    Label1.Text += "File Name: " +
                       userPostedFile.FileName + "<br>";

                    userPostedFile.SaveAs(outFolder + "\\" +
                       System.IO.Path.GetFileName(userPostedFile.FileName));

                    Label1.Text += "Location where saved: " +
                       outFolder + "\\" +
                       System.IO.Path.GetFileName(userPostedFile.FileName) +
                       "<p>";

                    IncidentDAL.InsertIncidentFile(IncidentID, outFolder + "\\" + System.IO.Path.GetFileName(userPostedFile.FileName));

                }
            }
            catch (Exception Ex)
            {
                Label1.Text += "Error: <br>" + Ex.Message;
            }
        }    
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("IncidentManagement.aspx");
    }
}
