using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TreeViewTest : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetBuilds();
            treeView1.CollapseAll();
        }
    }

    private void GetBuilds()
    {

        DataSet PrSet = ItemDAL.GetBuildNames();

        treeView1.Nodes.Clear();

        foreach (DataRow dr in PrSet.Tables[0].Rows)
        {

            TreeNode tnParent = new TreeNode();

            tnParent.Text = dr["Build"].ToString();

            tnParent.Value = dr["Build"].ToString();

            //   tnParent.PopulateOnDemand = true;

            //   tnParent.ToolTip = "Click to get Child";

            //   tnParent.SelectAction = TreeNodeSelectAction.SelectExpand;

            tnParent.Expand();

            //   tnParent.Selected = true;

            treeView1.Nodes.Add(tnParent);

            FillBuildStatuses(tnParent, tnParent.Text);

        }
    }

    private void FillBuildStatuses(TreeNode parent, String Build)
    {
        //parent.Nodes.Clear();
        DataSet ds = ItemDAL.GetStatusByBuild(Build);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            TreeNode child = new TreeNode();

            child.Text = dr["vcStage"].ToString().Trim();

            child.Value = dr["iStage"].ToString().Trim();

            parent.ChildNodes.Add(child);

        }
    }


    protected void treeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        //String Build = "";
        //if (treeView1.SelectedNode.Parent == null)
        //    Build = "X";
        //int StageID = Convert.ToInt32(treeView1.SelectedValue.ToString());

        //ErrorMessage = String.Format("Build={0}  Stage={1}", Build, StageID.ToString());
        //return;
        //GetItemsbyBuildandStatus(StageID, treeView1.SelectedValue.ToString());
    }

    private void GetItemsbyBuildandStatus(int iStage, string vcBuild)
    {
        GridView1.DataSource = ItemDAL.GetItemsByStage(iStage, vcBuild);
        GridView1.DataBind();
    }
}
