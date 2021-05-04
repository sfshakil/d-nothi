using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using dNothi.Services.DakServices;
using dNothi.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakTagForm : Form
    {

        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

     

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam,
                                                 ref TVITEM lParam);

        /// <summary>
        /// Hides the checkbox for the specified node on a TreeView control.
        /// </summary>
        private void HideParentNodeCheckBox(TreeView treeView, TreeNode trNode)
        {

            TVITEM tvi = new TVITEM();
            tvi.hItem = trNode.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            SendMessage(treeView.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);

        }

        public IUserService _userService { get; set; }
        public IDakFolderService _dakFolderService { get; set; }
        public DakTagForm(IUserService userService, IDakFolderService dakFolderService)
        {
            _userService = userService;
            _dakFolderService = dakFolderService;
            InitializeComponent();
        }
        public int _selectedFolderId { get; set; }
        public int dakId { get {return _dakId ; } set { _dakId = value; } }
        public int _dakId { get; set; }
        public int _is_copied_Id { get; set; }
        public int is_copied_Id { get { return _is_copied_Id; } set { _is_copied_Id=value; } }
        public string _dak_Type { get; set; }
        public string dak_Type { get { return _dak_Type; } set { _dak_Type = value; } }

        public string _dak_Sub { get; set; }
        public string dak_Sub { get { return _dak_Sub; } set { _dak_Sub = value; dakSubLabel.Text = value; } }


        public string _selectedFolderName { get; set; }
        public List<DakTagDTO> _dak_Tags { get; set; }
        public List<DakTagDTO> dak_Tags {
            get { return _dak_Tags; }

            set {
                _dak_Tags = value;
                foreach(var dak_tag in value)
                {
                    CheckUncheckTreeNode(personalFolderTreeView.Nodes, true, dak_tag.dak_custom_label_id);
                }
            
            
            } 
        }

        private void CheckUncheckTreeNode(TreeNodeCollection trNodeCollection, bool isCheck, int folder_id)
        {
            foreach (TreeNode trNode in trNodeCollection)
            {
                try
                {
                    if (Convert.ToInt32(trNode.Tag) == folder_id)
                    {

                        if (isCheck)
                        {
                            trNode.Checked = isCheck;
                           
                        }
                        else
                        {
                           
                            trNode.Checked = false;
                        }

                        break;
                    }
                }
                catch
                {

                }

                if (trNode.Nodes.Count > 0)
                    CheckUncheckTreeNode(trNode.Nodes, isCheck, folder_id);
            }
        }

        public int _open_for_all { get; set; }

        public string folderNameWithDakCount(string Name, int count)
        {
            if (count <= 0)
            {
                return Name;
            }
            return Name + "(" + string.Concat(count.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
        }

        public FolderListDataDTO _folderListDataDTO { get; set; }
        public FolderListDataDTO folderListDataDTO
        {
            get { return _folderListDataDTO; }
            set
            {
                _folderListDataDTO = value;

                LoadFolderTree(value);
            }


        }

        private void LoadFolderTree(FolderListDataDTO value)
        {
            if (value.publicFOlder != null && value.publicFOlder.Count > 0)
            {
                foreach (FolderDTO publicFolderDTO in value.publicFOlder)
                {

                    TreeNode childNode = new TreeNode();
                    childNode.Text = folderNameWithDakCount(publicFolderDTO.custom_name, publicFolderDTO.dak_count);
                    childNode.Tag = publicFolderDTO.id;

                    if (publicFolderDTO.parent == 0)
                    {
                        TreeNode treeNode = FindTreeNode(personalFolderTreeView.Nodes, publicFolderDTO.id);
                        if (treeNode != null)
                        {
                            treeNode.Text = folderNameWithDakCount(publicFolderDTO.custom_name, publicFolderDTO.dak_count);
                        }
                        else
                        {
                            personalFolderTreeView.Nodes.OfType<TreeNode>()
                         .FirstOrDefault(node => node.Name.Equals("publicNode")).Nodes.Add(childNode);
                        }



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
                    childNode.Text = folderNameWithDakCount(privateFolder.custom_name, privateFolder.dak_count);
                    childNode.Tag = privateFolder.id;
                

                    if (privateFolder.parent == 0)
                    {


                        TreeNode treeNode = FindTreeNode(personalFolderTreeView.Nodes, privateFolder.id);
                        if (treeNode != null)
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

                        NodeAddinTree(childNode, value._privateFolder, privateFolder.parent);

                    }

                }
            }


            HideParentNodeCheckBox(personalFolderTreeView, personalFolderTreeView.Nodes[0]);
            HideParentNodeCheckBox(personalFolderTreeView, personalFolderTreeView.Nodes[1]);
            HideParentNodeCheckBox(personalFolderTreeView, personalFolderTreeView.Nodes[0]);
        }

        private bool NodeAddinTree(TreeNode childNode, List<FolderDTO> folders, int parentId)
        {
            FolderDTO parentFolder = folders.FirstOrDefault(a => a.id == parentId);

            if (parentFolder != null)
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
                    TreeNode returnNode = FindTreeNode(trNode.Nodes, id);
                    if (returnNode != null)
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
                e.Node.Checked = true;
               
                _selectedFolderId = Convert.ToInt32(personalFolderTreeView.SelectedNode.Tag);

            }
            else
            {

            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            FolderDTO folder = new FolderDTO();


            if (_selectedFolderId == 0)
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
            if (folderListResponse.status == "success")
            {
                folderListDataDTO = folderListResponse.data;
            }

            TreeNode selectedTreeNode = FindTreeNode(personalFolderTreeView.Nodes, _selectedFolderId);
            if (selectedTreeNode != null)
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
            if (_selectedFolderId != 0)
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
                        TreeNode treeNode = FindTreeNode(personalFolderTreeView.Nodes, _selectedFolderId);
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
            if (_selectedFolderId != 0)
            {
                var folder = _folderListDataDTO.publicFOlder.FirstOrDefault(a => a.id == _selectedFolderId);
                if (folder == null)
                {
                    folder = _folderListDataDTO._privateFolder.FirstOrDefault(a => a.id == _selectedFolderId);
                }
                _selectedFolderName = folder.custom_name;
            }




            if (this.ShowDakListButton != null)
                this.ShowDakListButton(sender, e);

            this.Hide();

        }

        private void tagButton_MouseHover(object sender, EventArgs e)
        {
            HoverTagButton();
        }

        private void HoverTagButton()
        {
            if (tagButton.BackColor == Color.FromArgb(137, 80, 252))
            {
                tagButton.BackColor = Color.White;
                tagButton.IconColor = Color.FromArgb(137, 80, 252);
                tagButton.ForeColor = Color.FromArgb(137, 80, 252);
                tagButton.FlatAppearance.BorderColor = Color.FromArgb(137, 80, 252);
 }
            else
            { 
                tagButton.BackColor = Color.FromArgb(137, 80, 252);

                tagButton.IconColor = Color.White;
                tagButton.ForeColor = Color.White;
                tagButton.FlatAppearance.BorderColor = Color.White;

            }
        }

        private void tagButton_MouseLeave(object sender, EventArgs e)
        {
            HoverTagButton();
        }

        public List<int> _selectedFolderIds=new List<int>();



        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler SuccessfullButton;
        private void tagButton_Click(object sender, EventArgs e)
        {
            _selectedFolderIds.Clear();

            SetSelectedFolder(personalFolderTreeView.Nodes);

            if(_selectedFolderIds.Count==0)
            {
                ConditonBoxForm conditonBoxForm = new ConditonBoxForm();

                conditonBoxForm.message = "আপনি কোন ফোল্ডার বাছাই করেন নি। আপনি কি প্রক্রিয়াটি চালিয়ে যেতে চান ?";
                conditonBoxForm.ShowDialog();
                if (conditonBoxForm.Yes)
                {
                    AddSelectedFolderWithThisTag();

                }
            }
            else
            {
                AddSelectedFolderWithThisTag();
            }


            if(_isSuccessfull)
            {
                if (this.SuccessfullButton != null)
                    this.SuccessfullButton(sender, e);
                this.Hide();
            }

           
        }

        public bool _isSuccessfull;
        private void AddSelectedFolderWithThisTag()
        {
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();

            string Folder = "[";

            for(int i=0; i<=_selectedFolderIds.Count - 1; i++)
            {
                if(i!=0)
                {
                    Folder += ",";

                }

                Folder += "\"" + _selectedFolderIds[i] + "\"";
            }

            Folder += "]";

            DakFolderMapResponse dakFolderMapResponse = _dakFolderService.GetDakFolderMapResponse(dakUserParam,_dakId,_is_copied_Id,_dak_Type,Folder, _selectedFolderIds);
            if (dakFolderMapResponse.status == "success" && dakFolderMapResponse.message == "Local")
            {

                SuccessMessage("ইন্টারনেট সংযোগ ফিরে এলে এই ডাকটি ট্যাগ করা হবে!");

                _isSuccessfull = true;

            }
            else if (dakFolderMapResponse.status == "success")
            {

                SuccessMessage("সফলভাবে ডাক ট্যাগ সম্পন্ন হযেছে!");

                _isSuccessfull = true;
               
            }
            else
            {
                ErrorMessage("ডাক ট্যাগ সফল হইনি!");
                _isSuccessfull = false;
            }
        }

        private void SetSelectedFolder(TreeNodeCollection nodes)
        {
           foreach(TreeNode treeNode in nodes)
            {
                if(treeNode.Checked)
                {
                    _selectedFolderIds.Add(Convert.ToInt32(treeNode.Tag));
                }

                if(treeNode.Nodes.Count>0)
                {
                    SetSelectedFolder(treeNode.Nodes);
                }
            }
        }
    }
}
