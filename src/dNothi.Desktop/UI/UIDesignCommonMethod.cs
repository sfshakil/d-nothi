using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Khosra;
using dNothi.Services.DakServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
   public class UIDesignCommonMethod
    {
        public static string copyRightLableText = "© কপিরাইট ২০২১, V:1.15";
        public static readonly List<string> ImageExtensions = new List<string> { ".JPEG", ".JPG", "JPG", "JPE", "BMP", "GIF", "PNG", ".JPE", ".BMP", ".GIF", ".PNG", "IMAGE", "IMG" };
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF", "PDF" };
        public static readonly List<string> ExcelExtension = new List<string> { ".XLS", "XLS" };
        public static readonly List<string> TxtExtension = new List<string> { ".TXT", ".TEXT", "TXT", "TEXT" };
        public static readonly List<string> docExtension = new List<string> { "DOCX", "DOC" };
        public static readonly List<string> PPTExtension = new List<string> { "PPT", "PPTX" };
        public static readonly List<string> CSVExtension = new List<string> { "CSV" };
        public static readonly List<string> AudioExtension = new List<string> { "MP3", "M4P", "MP4" };
        public static String ConvertImageURLToBase64(String url)
        {
            StringBuilder _sb = new StringBuilder();
            try
            {
                Byte[] _byte = GetImage(url);

                _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));

                
            }
            catch {
            }
            return _sb.ToString();
        }

        private static byte[] GetImage(string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }
        public static PrapokDTO GetMulPrapokForOwnDesk(DakUserParam dak_List_User_Param)
        {
            PrapokDTO prapokDTO = new PrapokDTO();

            prapokDTO.designation_bng = dak_List_User_Param.designation;
            prapokDTO.designation_id = dak_List_User_Param.designation_id;
            prapokDTO.employee_id = dak_List_User_Param.employee_record_id.ToString();
            prapokDTO.employee_name_bng = dak_List_User_Param.officer_name;
            prapokDTO.incharge_label = dak_List_User_Param.incharge_label;
            prapokDTO.office = dak_List_User_Param.office;
            prapokDTO.officer = dak_List_User_Param.officer;
            prapokDTO.officer_bng = dak_List_User_Param.officer_name;
            prapokDTO.office_bng = dak_List_User_Param.office_label;
            prapokDTO.office_id = dak_List_User_Param.office_id;
            prapokDTO.officer_id = dak_List_User_Param.officer_id;
            prapokDTO.office_layer_id = dak_List_User_Param.office_unit_id;
            prapokDTO.office_unit_id = dak_List_User_Param.office_unit_id;
            prapokDTO.office_unit_bng = dak_List_User_Param.office_unit;
            prapokDTO.office_unit_bng = dak_List_User_Param.office_unit;
            prapokDTO.unit_name_bng = dak_List_User_Param.office_unit;
            prapokDTO.office_unit_code = dak_List_User_Param.unit_id.ToString();
            return prapokDTO;
        }

       

        public static Form returnForm { get; set; }
        public static void RightSideWindowSet(Form form)
        {
            Screen scr = Screen.FromPoint(form.Location);
            form.Location = new Point(scr.WorkingArea.Right - form.Width, scr.WorkingArea.Top);
            form.Height = scr.WorkingArea.Height;
        }

        public static void SetDefaultFont(Control.ControlCollection collection)
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

        public static void RightSideWindowSet(UserControl userControl)
        {
            Screen scr = Screen.FromPoint(userControl.Location);
            userControl.Location = new Point(scr.WorkingArea.Right - userControl.Width, scr.WorkingArea.Top);
            userControl.Height = scr.WorkingArea.Height;
        }
        public static void ChangeForm(Form newForm, Form currentForm)
        {
           

            if ( newForm.GetType()!=currentForm.GetType())
            {
                currentForm.Hide();
                newForm.ShowDialog();
            }
        }
        public static Image GetImageFromBase64(string imageBase64)
        {

            try
            {
                int firstStringIndex = imageBase64.IndexOf(",") + 1;
                if (firstStringIndex > 0)
                {
                    imageBase64 = imageBase64.Substring(firstStringIndex, imageBase64.Length - firstStringIndex);

                }


                byte[] bytes = Convert.FromBase64String(imageBase64);

                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }

          
        }


        public static string ImageToBase64(Image image, ImageFormat imageFormat)
        {
            using (Image image1 = image)
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image1.Save(m, imageFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }


        public static void ShowSingleAttachment(DakAttachmentDTO dakAttachmentDTO, UserControl parentForm)
        {
            AttachmentViewPopUpForm attachmentViewPopUpForm = new AttachmentViewPopUpForm();
            attachmentViewPopUpForm.dakAttachmentDTO = dakAttachmentDTO;

            CalPopUpWindow(attachmentViewPopUpForm, parentForm);

            
        }
        public static void ShowSingleAttachment(DakAttachmentDTO dakAttachmentDTO, Form parentForm)
        {
            AttachmentViewPopUpForm attachmentViewPopUpForm = new AttachmentViewPopUpForm();
            attachmentViewPopUpForm.dakAttachmentDTO = dakAttachmentDTO;

            CalPopUpWindow(attachmentViewPopUpForm, parentForm);


        }
        public static void ShowMultipleAttachment(DakAttachmentDTO dakAttachmentDTO, List<DakAttachmentDTO> dakAttachmentDTOs, Form parentForm)
        {
            AttachmentViewPopUpForm attachmentViewPopUpForm = new AttachmentViewPopUpForm();
            attachmentViewPopUpForm.dakAttachmentDTO = dakAttachmentDTO;
            attachmentViewPopUpForm.dakAttachmentDTOs = dakAttachmentDTOs;

            attachmentViewPopUpForm.PreviousButton += delegate (object os, EventArgs ev) { Previous(attachmentViewPopUpForm._dakAttachmentDTO, dakAttachmentDTOs, parentForm); };
            attachmentViewPopUpForm.NextButton += delegate (object os, EventArgs ev) { Next(attachmentViewPopUpForm._dakAttachmentDTO, dakAttachmentDTOs, parentForm); };

            CalPopUpWindow(attachmentViewPopUpForm, parentForm);
        }
        public static void Previous(DakAttachmentDTO dakAttachmentDTO, List<DakAttachmentDTO> dakAttachmentDTOs, Form parentForm)
        {
            AttachmentViewPopUpForm attachmentViewPopUpForm = new AttachmentViewPopUpForm();

            attachmentViewPopUpForm.dakAttachmentDTOs = dakAttachmentDTOs;

            if (dakAttachmentDTOs != null)
            {
                for (int i = dakAttachmentDTOs.Count - 1; i >= 0; i--)
                {
                    if (dakAttachmentDTOs[i].attachment_id == dakAttachmentDTO.attachment_id)
                    {
                        if (i == 0)
                        {
                            attachmentViewPopUpForm.dakAttachmentDTO = dakAttachmentDTOs[dakAttachmentDTOs.Count - 1];
                        }

                        else
                        {
                            attachmentViewPopUpForm.dakAttachmentDTO = dakAttachmentDTOs[i - 1];
                        }
                        break;
                    }
                }
            }

            attachmentViewPopUpForm.PreviousButton += delegate (object os, EventArgs ev) { Previous(attachmentViewPopUpForm._dakAttachmentDTO, dakAttachmentDTOs, parentForm); };
            attachmentViewPopUpForm.NextButton += delegate (object os, EventArgs ev) { Next(attachmentViewPopUpForm._dakAttachmentDTO, dakAttachmentDTOs,parentForm); };

            CalPopUpWindow(attachmentViewPopUpForm, parentForm);
        }

        public static void AssignNode(TreeView FromTreeView, TreeView ToTreeView)
        {
            foreach(TreeNode treeNode in FromTreeView.Nodes)
            {
                ToTreeView.Nodes.Add((TreeNode)treeNode.Clone());
            }
        }

        private static void Next(DakAttachmentDTO dakAttachmentDTO, List<DakAttachmentDTO> dakAttachmentDTOs, Form parentForm)
        {
            AttachmentViewPopUpForm attachmentViewPopUpForm = new AttachmentViewPopUpForm();

            attachmentViewPopUpForm.dakAttachmentDTOs = dakAttachmentDTOs;


            if (dakAttachmentDTOs != null)
            {
                for (int i = 0; i <= dakAttachmentDTOs.Count - 1; i++)
                {
                    if (dakAttachmentDTOs[i].attachment_id == dakAttachmentDTO.attachment_id)
                    {
                        if (i == dakAttachmentDTOs.Count - 1)
                        {
                            attachmentViewPopUpForm.dakAttachmentDTO = dakAttachmentDTOs[0];
                        }
                        else
                        {

                            attachmentViewPopUpForm.dakAttachmentDTO = dakAttachmentDTOs[i + 1];
                        }
                        break;
                    }
                }
            }

            attachmentViewPopUpForm.PreviousButton += delegate (object os, EventArgs ev) { Previous(attachmentViewPopUpForm._dakAttachmentDTO, dakAttachmentDTOs,parentForm); };
            attachmentViewPopUpForm.NextButton += delegate (object os, EventArgs ev) { Next(attachmentViewPopUpForm._dakAttachmentDTO, dakAttachmentDTOs,parentForm); };

            CalPopUpWindow(attachmentViewPopUpForm, parentForm);

        }

        public static void BacktoPreviousForm(Form form)
        {
            form.Hide();
            if (UIDesignCommonMethod.returnForm != null)
            {
                var fo = UIDesignCommonMethod.returnForm as Form;
                if (fo.Name == "Note")
                {
                    Note note = fo as Note;
                    note.loadAgainNote();
                }
                UIDesignCommonMethod.returnForm.Show();
            }
            else
            {
                
                var newForm = FormFactory.Create<Dashboard>();
                newForm.ShowDialog();
              
            }

            UIDesignCommonMethod.returnForm = null;
        }

        public static void DownLoadFile(string fileDownloadLink, string fileName )
        {
            WebClient client = new WebClient();
            string folderPath = "";
            FolderBrowserDialog directchoosedlg = new FolderBrowserDialog();
            if (fileDownloadLink != "")
            {
                if (directchoosedlg.ShowDialog() == DialogResult.OK)
                {
                    folderPath = directchoosedlg.SelectedPath;
                    Uri uri = new Uri(fileDownloadLink);
                    //string fileName = System.IO.Path.GetFileName(uri.AbsolutePath);
                    client.DownloadFileAsync(uri, folderPath + "/" + fileName);
                }
            }
        }
        public static void FileIconSet(string value, FontAwesome.Sharp.IconButton btnFile)
        {
            string extUpper = value!=null? value.ToUpperInvariant():string.Empty;

             if (PdfExtensions.Any(a=>extUpper.Contains(a)))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            }
            else if (docExtension.Any(a => extUpper.Contains(a)))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FileWord;
            }
            else if (CSVExtension.Any(a => extUpper.Contains(a)))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FileCsv;
            }
            else if (TxtExtension.Any(a => extUpper.Contains(a)))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FileWord;
            }
            else if (AudioExtension.Any(a => extUpper.Contains(a)))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FileAudio;
            }
            else if (ExcelExtension.Any(a => extUpper.Contains(a)))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            }
            else if (PPTExtension.Any(a => extUpper.Contains(a)))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FilePowerpoint;
            }
            else if (ImageExtensions.Any(a => extUpper.Contains(a)))
            {
                btnFile.Visible = true;
                btnFile.IconChar = FontAwesome.Sharp.IconChar.FileImage;
            }
        }

        public static bool SelectFirstNode(TreeView treeView, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.BackColor == Color.Yellow)
                {
                    treeView.SelectedNode = node;
                    return true;
                }


                if (node.Nodes.Count > 0)
                {
                    if (SelectFirstNode(treeView, node.Nodes))
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public static void CollapseTree(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Collapse();

            }
        }

        public static bool RemoveWhiteNode(TreeView treeView)
        {
            foreach (TreeNode node in treeView.Nodes)
            {

                 if (node.BackColor == Color.White && node.Nodes.Count <=0)
                {
                    node.BackColor = Color.White;

                    continue;
                }

                if (RemoveWhiteNode(treeView))
                    return true;
            }
            return false;
        }


        public static bool SearchRecursive(TreeView treeView, IEnumerable nodes, string searchFor)
        {
            foreach (TreeNode node in nodes)
            {

                if (node.Text.Contains(searchFor) && !String.IsNullOrEmpty(searchFor))
                {

                    if (node.Nodes.Count <= 0 && !node.Parent.IsExpanded)
                    {
                        node.Parent.Expand();
                    }
                    node.BackColor = Color.Yellow;
                }
                else if (node.BackColor == Color.Yellow)
                {
                    node.BackColor = Color.White;

                    if (node.Nodes.Count <= 0 && node.Parent.IsExpanded)
                    {
                        node.Parent.Collapse();
                    }

                }


                if (SearchRecursive(treeView, node.Nodes, searchFor))
                    return true;
            }
            return false;
        }

       

      

        public static void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            //successMessage.Show();
            //var t = Task.Delay(3000); //1 second/1000 ms
            //t.Wait();
            //successMessage.Hide();
            successMessage.Visible=true;
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Visible = false;
        }
        public static void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.Visible = true;
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Visible = false;
            //successMessage.ShowDialog();

        }

        public static void AddRowinTable(TableLayoutPanel tableLayoutPanel, UserControl userControl)
        {

            userControl.Dock = DockStyle.Fill;

            int row = tableLayoutPanel.RowCount++;

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            if (row == 1)
            {
                row = tableLayoutPanel.RowCount++;
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            }
            tableLayoutPanel.Controls.Add(userControl, 0, row);

        }
        public static void AddColumninTable(TableLayoutPanel tableLayoutPanel, UserControl userControl)
        {

            userControl.Dock = DockStyle.Fill;

            int column = tableLayoutPanel.ColumnCount++;

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0f));
            if (column == 1)
            {
                column = tableLayoutPanel.ColumnCount++;
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0f));
            }
            tableLayoutPanel.Controls.Add(userControl, column, 0);

        }
        public static void AddRowinTableNoDock(TableLayoutPanel tableLayoutPanel, UserControl userControl)
        {

           // userControl.Dock = DockStyle.Fill;

            int row = tableLayoutPanel.RowCount++;

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            if (row == 1)
            {
                row = tableLayoutPanel.RowCount++;
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
            }
            tableLayoutPanel.Controls.Add(userControl, 0, row);

        }

        public static void CallAllModulePanel(Button button , Form form)
        {
            var modulePanelUserControls = form.Controls.OfType<ModulePanelUserControl>().FirstOrDefault(a=>a.Visible==true);

            if (modulePanelUserControls == null)
            {
                Point locationOnForm = button.FindForm().PointToClient(
                button.Parent.PointToScreen(button.Location));


                ModulePanelUserControl modulePanelUserControl = new ModulePanelUserControl();
                modulePanelUserControl.Location = new Point(locationOnForm.X, locationOnForm.Y + button.Height + 1);



                form.Controls.Add(modulePanelUserControl);

                modulePanelUserControl.BringToFront();
               

            }
            else
            {
                form.Controls.Remove(modulePanelUserControls);
            }
        }

        public static PermittedPotroResponseMulpotroDTO GetPermittedPotroResponseFromDakAttachmentRespnse(DakAttachmentDTO dakAttachmentDTO)
        {
            PermittedPotroResponseMulpotroDTO permittedPotroResponseMulpotroDTO = new PermittedPotroResponseMulpotroDTO();



            return permittedPotroResponseMulpotroDTO;
        }

        public static void CallAllModulePanel(Button button, UserControl form)
        {
            var modulePanelUserControls = form.Controls.OfType<ModulePanelUserControl>().FirstOrDefault(a => a.Visible == true);

            if (modulePanelUserControls == null)
            {
                Point locationOnForm = button.FindForm().PointToClient(
                button.Parent.PointToScreen(button.Location));


                ModulePanelUserControl modulePanelUserControl = new ModulePanelUserControl();
                // modulePanelUserControl.Location = new Point(locationOnForm.X, locationOnForm.Y + button.Height + 1);

                modulePanelUserControl.Location = new Point(30, 30);

                form.Controls.Add(modulePanelUserControl);

                modulePanelUserControl.BringToFront();


            }
            else
            {
                form.Controls.Remove(modulePanelUserControls);
            }
        }

        public static void NothiModuleClick(Form form)
        {
            form.Hide();
            var nothiForm= FormFactory.Create<Nothi>();
            nothiForm.ShowDialog();
        }
        public static void DakModuleClick(Form form)
        {
            form.Hide();
            var dakForm = FormFactory.Create<Dashboard>();
            dakForm.ShowDialog();
        }

        public static void Border_Color_Blue(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        public static void Table_Cell_Color_Blue(object sender, TableLayoutCellPaintEventArgs e)
        {

            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(203, 225, 248)), e.CellBounds);
        }
        public static void Table_Color_Blue(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }


        public static void Border_Color_Gray(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(235, 237, 243), ButtonBorderStyle.Solid);
        }

        public static void Border_Color_Gray(object sender, TableLayoutCellPaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(235, 237, 243), ButtonBorderStyle.Solid);
        }

        public static Form AttachControlToForm(Control control)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            form.Height = 100;
            form.Controls.Add(control);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            return form;
        }
        public static void CalPopUpWindow(Form form, Form parentForm)
        {
            Form hideform = new Form();

            hideform.BackColor = Color.Black;
            hideform.Size = Screen.PrimaryScreen.WorkingArea.Size;
            hideform.Opacity = .4;
            hideform.ShowInTaskbar = false;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        public static void CalPopUpWindow(Form form, Panel parentForm)
        {
            Form hideform = new Form();

            hideform.BackColor = Color.Black;
            hideform.Size = parentForm.Size;
            hideform.Opacity = .4;
            hideform.ShowInTaskbar = false;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.Location = parentForm.Location;
            //hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        public static void CalPopUpWindow(Form form, UserControl parentUc)
        {
            Form hideform = new Form();

            hideform.BackColor = Color.Black;
            hideform.Size = Screen.PrimaryScreen.WorkingArea.Size;
            hideform.Opacity = .4;
            hideform.ShowInTaskbar = false;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }

        public static Form GetParentsForm(Control controls)
        {
            if (controls.Parent is Form)

            {
                return controls.Parent as Form;
            }
            else
            {
               return GetParentsForm(controls.Parent);
            }
            return null;
        }
        public static void CallShadowWindow(Form form)
        {
            Form hideform = new Form();


            hideform.BackColor = Color.Black;
            hideform.Height = form.Height+10;
            hideform.Width = form.Width+10;
            hideform.Opacity = .6;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }

        public static void CallShadowWindow(UserControl user)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            form.Height = 100;
            form.Controls.Add(user);
            user.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            CallShadowWindow(form);
        }
        public static void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowInTaskbar = false;
            form.TopMost = true;
            form.TopMost = false;
            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }


        public static void dropShadow(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Color[] shadow = new Color[3];
            shadow[0] = Color.FromArgb(181, 181, 181);
            shadow[1] = Color.FromArgb(195, 195, 195);
            shadow[2] = Color.FromArgb(211, 211, 211);
            Pen pen = new Pen(shadow[0]);
            using (pen)
            {
                foreach (Panel p in panel.Controls.OfType<Panel>())
                {
                    Point pt = p.Location;
                    pt.Y += p.Height;
                    for (var sp = 0; sp < 3; sp++)
                    {
                        pen.Color = shadow[sp];
                        e.Graphics.DrawLine(pen, pt.X, pt.Y, pt.X + p.Width - 1, pt.Y);
                        pt.Y++;
                    }
                }
            }
        }

        public static void SearchFromTree(TreeView searchtoTreeView, TreeView searchFromTreeView, string searchText)
        {
            searchtoTreeView.BeginUpdate();

            searchtoTreeView.Nodes.Clear();

            if (!string.IsNullOrEmpty(searchText))
            {
                foreach (TreeNode _parentNode in searchFromTreeView.Nodes)
                {
                    TreeNode parentNode = (TreeNode)_parentNode.Clone();
                    parentNode.Nodes.Clear();
                    foreach (TreeNode _childNode in _parentNode.Nodes)
                    {
                        if (_childNode.Text.StartsWith(searchText))
                        {
                            parentNode.Nodes.Add((TreeNode)_childNode.Clone());
                            parentNode.LastNode.BackColor = Color.Yellow;
                        }
                    }

                    if (parentNode.Nodes.Count > 0)
                    {
                        parentNode.ExpandAll();
                        searchtoTreeView.Nodes.Add(parentNode);
                    }
                }
            }
            else
            {
                foreach (TreeNode _node in searchFromTreeView.Nodes)
                {
                    searchtoTreeView.Nodes.Add((TreeNode)_node.Clone());
                }
            }

            searchtoTreeView.EndUpdate();
        }
    }

   
}
