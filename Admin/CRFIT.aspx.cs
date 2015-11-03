using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CRFIT : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCRF(); 
            LoadHours();
            LoadMinutes();
            LoadAMPM();
            LoadDepartments();
            LoadStatus();
        }
    }

    private void LoadStatus()
    {
        ddlStatus.DataSource = CrfDAL.GetCRFITStatus();
        ddlStatus.DataBind();
    }

    private void LoadDepartments()
    {
        ddlDepartments.DataSource = CrfDAL.GetDepartments();
        ddlDepartments.DataBind();
    }

    private void LoadAMPM()
    {
        ddlAMPM.Items.Add("AM");
        ddlAMPM.Items.Add("PM");
    }

    private void LoadMinutes()
    {
        for (int i = 0; i < 60; i++)
        {
            ddlMM.Items.Add(i.ToString().PadLeft(2,'0'));
        }
    }

    private void LoadHours()
    {
        for (int i = 0; i < 12; i++)
        {
            ddlHH.Items.Add(i.ToString().PadLeft(2, '0'));
        }
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        int iDepartmentID;
        String DeploymentDate;
        String DeploymentTime;
        String vcDescription;
        String CRFNumber;
        //int iCRFStatusID;


        iDepartmentID = Convert.ToInt32( ddlDepartments.SelectedItem.Value);
        DeploymentDate = txtDeploymentDate.Text;
        DeploymentTime = ddlHH.SelectedItem.Value + ":" + ddlMM.SelectedItem.Value + ddlAMPM.SelectedItem.Value;
        vcDescription = txtDecription.Text;
        CRFNumber = txtCRF.Text;
        //iCRFStatusID = Convert.ToInt32(ddlStatus.SelectedItem.Value);


        String result = CrfDAL.CRFInsert(
            CRFNumber,
            iDepartmentID, 
            DeploymentDate, 
            DeploymentTime, 
            vcDescription//, 
            //iCRFStatusID
            );


        LoadCRF();
        ClearControla();

    }

    private void LoadCRF()
    {
        GridView1.DataSource = CrfDAL.GetCRFs();
        GridView1.DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //int iDepartmentID;
        //String DeploymentDate;
        //String DeploymentTime;
        //String vcDescription;
        ////int iCRFStatusID;
        //String CRF;

        //CRF = txtCRF.Text;
        //iDepartmentID = Convert.ToInt32(ddlDepartments.SelectedItem.Value);
        //DeploymentDate = txtDeploymentDate.Text;
        //DeploymentTime = ddlHH.SelectedItem.Value + ":" + ddlMM.SelectedItem.Value + "AM";
        //vcDescription = txtDecription.Text;
        ////iCRFStatusID = Convert.ToInt32(ddlStatus.SelectedItem.Value);


        //String result = CrfDAL.CRFInsert(
        //    CRF,
        //    iDepartmentID,
        //    DeploymentDate,
        //    DeploymentTime,
        //    vcDescription//, 
        //    //iCRFStatusID
        //    );


        LoadCRF();
        ClearControla();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        LoadCRF();
    }

    void ClearControla()
    {
        txtCRF.Text = "";
        txtDecription.Text = "";
        txtDeploymentDate.Text = "";
        ddlAMPM.SelectedIndex = -1;
        ddlDepartments.SelectedIndex = -1;
        ddlHH.SelectedIndex = -1;
        ddlMM.SelectedIndex = -1;
        ddlStatus.SelectedIndex = -1;
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        String CRFID = ((Label)GridView1.SelectedRow.FindControl("lblCRFId")).Text;
        String DepID = ((Label)GridView1.SelectedRow.FindControl("lblDepartmentID")).Text;
        String DeploymentDate = ((Label)GridView1.SelectedRow.FindControl("lblDeploymentDate")).Text;
        String DeploymentTime = ((Label)GridView1.SelectedRow.FindControl("lblDeploymentTime")).Text;
        String CRFNO = ((Label)GridView1.SelectedRow.FindControl("lblCRFNo")).Text;
        String Description = ((Label)GridView1.SelectedRow.FindControl("lblDescription")).Text;

        ErrorMessage = String.Format("CRFID={0}  DEPID={1}  DEPDATE={2}  DEPTIME{3}", CRFID, DepID, DeploymentDate, DeploymentTime);
        ddlDepartments.SelectedIndex = -1;
        ddlDepartments.Items.FindByValue(DepID).Selected = true;


        txtCRF.Text = CRFNO;
        txtDecription.Text = Description;

        txtDeploymentDate.Text = DeploymentDate;

        //string[] Time = DeploymentTime.Split(':');

        //int hh = Convert.ToInt32(Time[0]);
        //int offset =  hh % 12;
        //Time[0] = offset.ToString();

        //ddlHH.SelectedIndex = -1;
        //ddlHH.Items.FindByValue(offset.ToString()).Selected = true;

        //ddlMM.SelectedIndex = -1;
        //ddlMM.Items.FindByValue(Time[1]).Selected = true;

        //if (hh >= 12)
        //    ddlAMPM.Text = "PM";
        //else
        //    ddlAMPM.Text = "AM";

        

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int currentRowIndex = e.RowIndex;
        String CRFID = ((Label)GridView1.Rows[currentRowIndex].FindControl("lblCRFId")).Text;
        //ErrorMessage = String.Format("CRFID={0}  ", CRFID);
        ErrorMessage = CrfDAL.DeleteCRFRecord(Convert.ToInt32(CRFID));
        LoadCRF();
    }
}
