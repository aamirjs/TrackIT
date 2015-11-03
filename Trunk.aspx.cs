using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Trunk : BasePage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            System.IO.DirectoryInfo RootDir = new System.IO.DirectoryInfo(@"D:\_ReleaseManagement\_Branches\DTS\Trunk\SRC");
            

            // output the directory into a node
            TreeNode RootNode = OutputDirectory(RootDir, null);

            // add the output to the tree
            TreeView1.Nodes.Add(RootNode);

            TreeView1.CollapseAll();

            TreeView1.SelectedNodeChanged+= new EventHandler(TreeView1_SelectedNodeChanged);
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        
    }

    TreeNode OutputDirectory(System.IO.DirectoryInfo directory, TreeNode parentNode)
    {
        // validate param
        if (directory == null) return null;

        // create a node for this directory
        TreeNode DirNode = new TreeNode(directory.Name);

        // get subdirectories of the current directory
        System.IO.DirectoryInfo[] SubDirectories = directory.GetDirectories();


        // output each subdirectory
        for (int DirectoryCount = 0; DirectoryCount < SubDirectories.Length; DirectoryCount++)
        {
            if(!SubDirectories[DirectoryCount].Extension.Contains(".svn"))
                OutputDirectory(SubDirectories[DirectoryCount], DirNode);
        }

        // output the current directories files
        System.IO.FileInfo[] Files = directory.GetFiles();

        for (int FileCount = 0; FileCount < Files.Length; FileCount++)
        {
            if(Files[FileCount].Extension.EndsWith("cs") || Files[FileCount].Extension.EndsWith("sql"))
            DirNode.ChildNodes.Add(new TreeNode(Files[FileCount].Name));
        }

        // if the parent node is null, return this node
        // otherwise add this node to the parent and return the parent
        if (parentNode == null)
        {
            return DirNode;
        }
        else
        {
            parentNode.ChildNodes.Add(DirNode);
            return parentNode;
        }
    }
    protected void TreeView1_SelectedNodeChanged1(object sender, EventArgs e)
    
    {
        ErrorMessage = TreeView1.SelectedNode.Text;
    }
}
