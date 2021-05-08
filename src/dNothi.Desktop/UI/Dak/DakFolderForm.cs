using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
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
        public IUserService _userService { get; set; }
        public IDakFolderService _dakFolderService { get; set; }
        public DakFolderForm(IUserService userService, IDakFolderService dakFolderService)
        {
            _userService = userService;
            _dakFolderService = dakFolderService;
            InitializeComponent();
        }
        public int _selectedFolderId { get; set; }
        public string _selectedFolderName { get; set; }
        public int _open_for_all { get; set; }

        public string folderNameWithDakCount(string Name, int count)
        {
            if(count<=0)
            {
                return Name;
            }
            return Name+"("+ string.Concat(count.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
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
            //if(value.publicFOlder!=null && value.publicFOlder.Count>0)
            //{
            //    foreach(FolderDTO publicFolderDTO in value.publicFOlder)
            //    {
                    
            //        TreeNode childNode = new TreeNode();
            //       childNode.Text= folderNameWithDakCount(publicFolderDTO.custom_name, publicFolderDTO.dak_count);
            //        childNode.Tag = publicFolderDTO.id;

            //        if (publicFolderDTO.parent==0)
            //        {
            //            TreeNode treeNode = FindTreeNode(personalFolderTreeView.Nodes, publicFolderDTO.id);
            //            if (treeNode != null)
            //            {
            //                treeNode.Text = folderNameWithDakCount(publicFolderDTO.custom_name, publicFolderDTO.dak_count);
            //            }
            //            else
            //            {
            //                personalFolderTreeView.Nodes.OfType<TreeNode>()
            //             .FirstOrDefault(node => node.Name.Equals("publicNode")).Nodes.Add(childNode);
            //            }


                      
            //        }
            //        else
            //        {
            //            NodeAddinTree(childNode, value.publicFOlder, publicFolderDTO.parent);
            //        }
                  



            //    }
            //}

            

            if (value._privateFolder.Count > 0)
            {
                foreach (FolderDTO privateFolder in value._privateFolder)
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = folderNameWithDakCount(privateFolder.custom_name, privateFolder.dak_count);
                    childNode.Tag = privateFolder.id;

                    if (privateFolder.parent == 0)
                    {


                        TreeNode treeNode = FindTreeNode(personalFolderTreeView.Nodes, privateFolder.id);
                        if(treeNode != null)
                        {
                            treeNode.Text = folderNameWithDakCount(privateFolder.custom_name, privateFolder.dak_count);
                        }
                        else
                        {
                            personalFolderTreeView.Nodes.OfType<TreeNode>()
                        .FirstOrDefault(node => node.Name.Equals("privateNode")).Nodes.Add(childNode);

                        }







                    }
                    else
                    {

                        NodeAddinTree(childNode,value._privateFolder,privateFolder.parent);

                    }

                }
            }
        }

        private bool NodeAddinTree(TreeNode childNode, List<FolderDTO> folders, int  parentId)
        {
            FolderDTO parentFolder = folders.FirstOrDefault(a => a.id == parentId);

            if(parentFolder != null)
            {
                var checkChildNode = FindTreeNode(personalFolderTreeView.Nodes, Convert.ToInt32(childNode.Tag));
                if (checkChildNode == null)
                {
                    var parentNode = FindTreeNode(personalFolderTreeView.Nodes, parentId);

                    if (parentNode == null)
                    {


                        TreeNode treeNode = new TreeNode();
                        treeNode.Text = folderNameWithDakCount(parentFolder.custom_name, parentFolder.dak_count);
                        treeNode.Tag = parentFolder.id;

                       if (!NodeAddinTree(treeNode, folders, parentFolder.parent))
                        {
                            return false;
                        }
                        else
                        {
                            treeNode.Nodes.Add(childNode);     
                        }
                    }
                    else
                    {
                        parentNode.Nodes.Add(childNode);
                    }

               

                }
                else
                {
                    checkChildNode.Text = childNode.Text;
                }

                return true;
            }
            else
            {
                return false;
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
                   
                    if(personalFolderTreeView.SelectedNode.Name.ToString()== "privateNode")
                    {
                        _open_for_all = 0;
                    }
                    else
                    {
                        _open_for_all = 1;
                    }


                }
                else
                {
                    editButton.Visible = true;
                    deleteButton.Visible = true;
                    dakListButton.Visible = true;
                }
                _selectedFolderId = Convert.ToInt32(personalFolderTreeView.SelectedNode.Tag);

            }
            else
            {

            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            FolderDTO folder = new FolderDTO();


            if(_selectedFolderId ==0)
            {
                folder.open_for_all = _open_for_all;
                folder.parent = _selectedFolderId;
                folder.id = _selectedFolderId;
            }

            else
            {
                folder = null;
                folder = _folderListDataDTO.publicFOlder.FirstOrDefault(a => a.id == _selectedFolderId);

                if (folder == null)
                {
                    folder = _folderListDataDTO._privateFolder.FirstOrDefault(a => a.id == _selectedFolderId);
                }
            }



            var folderCreatePopUpForm = FormFactory.Create<FolderCreatePopUpForm>();
            //folderCreatePopUpForm.folderName = folder.custom_name;
            folderCreatePopUpForm.folderDTO = folder;



            folderCreatePopUpForm.SaveButtonClick += delegate (object senderSaveButton, EventArgs eventSaveButton) { SaveorUpdate(); };


            CalPopUpWindow(folderCreatePopUpForm);
        }

        private void SaveorUpdate()
        {
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            FolderListResponse folderListResponse = _dakFolderService.GetFolderList(dakUserParam);
            if(folderListResponse.status=="success")
            {
                folderListDataDTO = folderListResponse.data;
            }

            TreeNode selectedTreeNode = FindTreeNode(personalFolderTreeView.Nodes, _selectedFolderId);
            if(selectedTreeNode !=null)
            {
                personalFolderTreeView.SelectedNode = selectedTreeNode;
                selectedTreeNode.Expand();
            }

        }

        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();

            Screen scr = Screen.FromPoint(this.Location);
            hideform.BackColor = Color.Black;
            hideform.Size = scr.WorkingArea.Size;
            hideform.Opacity = .6;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }

        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }

        private void sliderCrossButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            
              
               var folder = _folderListDataDTO.publicFOlder.FirstOrDefault(a => a.id == _selectedFolderId);

                if (folder == null)
                {
                    folder = _folderListDataDTO._privateFolder.FirstOrDefault(a => a.id == _selectedFolderId);
                }
            



            var folderCreatePopUpForm = FormFactory.Create<FolderCreatePopUpForm>();
            folderCreatePopUpForm.folderName = folder.custom_name;
            folderCreatePopUpForm.folderDTO = folder;
            folderCreatePopUpForm.selectedFolderId = folder.id;



            folderCreatePopUpForm.SaveButtonClick += delegate (object senderSaveButton, EventArgs eventSaveButton) { SaveorUpdate(); };


            CalPopUpWindow(folderCreatePopUpForm);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(_selectedFolderId !=0)
            {
               
                ConditonBoxForm conditonBoxForm = new ConditonBoxForm();

                conditonBoxForm.message = "অপনি কি ফোল্ডার টি মুছে ফেলতে চান?";
                conditonBoxForm.ShowDialog();
                if (conditonBoxForm.Yes)
                {
                    DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                    DakFolderDeleteResponse dakFolderDeleteResponse = _dakFolderService.GetDakFolderDeleteResponse(dakUserParam, _selectedFolderId);

                    if (dakFolderDeleteResponse.status == "success")
                    {
                       
                        SuccessMessage("ফোল্ডার টির নাম সফলভাবে মুছে ফেলা হযেছে!");
                        TreeNode treeNode=FindTreeNode(personalFolderTreeView.Nodes, _selectedFolderId);
                        treeNode.Remove();


                        SaveorUpdate();
                        
                    }
                    else
                    {
                        ErrorMessage("ফোল্ডার টির নাম মুছে ফেলা সফল হইনি!");
                    }


                }
            }
        }

        public void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();
        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ShowDakListButton;
        private void dakListButton_Click(object sender, EventArgs e)
        {
             if(_selectedFolderId !=0)
            {
                var folder = _folderListDataDTO.publicFOlder.FirstOrDefault(a => a.id == _selectedFolderId);
                if(folder == null)
                {
                    folder=_folderListDataDTO._privateFolder.FirstOrDefault(a => a.id == _selectedFolderId);
                }
                _selectedFolderName = folder.custom_name;
            }

           


            if (this.ShowDakListButton != null)
                this.ShowDakListButton(sender, e);

            this.Hide();
        
      }
    }
}
