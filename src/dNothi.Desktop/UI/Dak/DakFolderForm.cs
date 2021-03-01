using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakFolderForm : Form
    {
        public DakFolderForm()
        {
            InitializeComponent();
        }

        public FolderListDataDTO _folderListDataDTO { get; set; }
        public FolderListDataDTO folderListDataDTO { get { return _folderListDataDTO; } 
            set {
                _folderListDataDTO = value;

                LoadFolderTree(value);
            } 
        
        
        }

        private void LoadFolderTree(FolderListDataDTO value)
        {
            if(value.publicFOlder.Count>0)
            {
                foreach(FolderDTO publicFolderDTO in value.publicFOlder)
                {
                    
                    TreeNode childNode = new TreeNode();
                    childNode.Text = publicFolderDTO.custom_name;
                    childNode.Tag = publicFolderDTO.id;

                    if (publicFolderDTO.parent==0)
                    {
                        personalFolderTreeView.Nodes.OfType<TreeNode>()
                         .FirstOrDefault(node => node.Name.Equals("publicNode")).Nodes.Add(childNode);




                      //  personalFolderTreeView.Nodes.IndexOf(parentNode1.Index).Add(childNode);

                      
                    }
                    else
                    {
                        NodeAddinTree(childNode, value.publicFOlder, publicFolderDTO.parent);
                    }
                  



                }
            }

            

            if (value._privateFolder.Count > 0)
            {
                foreach (FolderDTO privateFolder in value._privateFolder)
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = privateFolder.custom_name;
                    childNode.Tag = privateFolder.id;

                    if (privateFolder.parent == 0)
                    {
                       personalFolderTreeView.Nodes.OfType<TreeNode>()
                         .FirstOrDefault(node => node.Name.Equals("privateNode")).Nodes.Add(childNode);




                      


                    }
                    else
                    {

                        NodeAddinTree(childNode,value._privateFolder,privateFolder.parent);

                    }

                }
            }
        }

        private void NodeAddinTree(TreeNode childNode, List<FolderDTO> folders, int  parentId)
        {
            var checkChildNode = FindTreeNode(personalFolderTreeView.Nodes, Convert.ToInt32(childNode.Tag));
            if (checkChildNode == null)
            { 
                var parentNode = FindTreeNode(personalFolderTreeView.Nodes, parentId);

                if (parentNode == null)
                {
                    FolderDTO folder = folders.FirstOrDefault(a => a.id == parentId);
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = folder.custom_name;
                    treeNode.Tag = folder.id;

                    NodeAddinTree(treeNode, folders, folder.parent);
                }

                parentNode.Nodes.Add(childNode);
                
            }
        }

        private TreeNode FindTreeNode(TreeNodeCollection treeNodes, int id)
        {
            
            foreach (TreeNode trNode in treeNodes)
            {
                if (Convert.ToInt32(trNode.Tag) == id)
                {


                    return trNode;
                   

                }

                if (trNode.Nodes.Count > 0)
                {
                    TreeNode returnNode=FindTreeNode(trNode.Nodes, id);
                    if(returnNode !=null)
                    {
                        return returnNode;
                    }
                }
                   
            }

            return null;
        }
        private void BlueBorder(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(235, 237, 243), ButtonBorderStyle.Solid);

        }

        private void personalFolderTreeView_MouseClick(object sender, MouseEventArgs e)
        {
            
            
        }

        private void personalFolderTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void DakFolderForm_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            SetDefaultFont(this.Controls);
        }

        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {




                if (ctrl.Font.Style != FontStyle.Regular)
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);

                }
                else
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size);
                }




                SetDefaultFont(ctrl.Controls);
            }

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            personalFolderTreeView.ExpandAll();
        }

        private void personalFolderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (personalFolderTreeView.SelectedNode != null)
            {
                addButton.Visible = true;
                if (Convert.ToInt32(personalFolderTreeView.SelectedNode.Tag) == 0)
                {
                    editButton.Visible = false;
                    deleteButton.Visible = false;
                    dakListButton.Visible = false;

                }
                else
                {
                    editButton.Visible = true;
                    deleteButton.Visible = true;
                    dakListButton.Visible = true;
                }
            }
            else
            {

            }
        }
    }
}
