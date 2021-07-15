using dNothi.Desktop.UI.CustomMessageBox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
   public class UIDesignCommonMethod
    {

        public static string copyRightLableText = "© কপিরাইট ২০২১, V :1.08";

        public static void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();
        }
        public static void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

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

        public static void CallAllModulePanel(Button button, UserControl form)
        {
            var modulePanelUserControls = form.Controls.OfType<ModulePanelUserControl>().FirstOrDefault(a => a.Visible == true);

            if (modulePanelUserControls == null)
            {
                Point locationOnForm = button.FindForm().PointToClient(
                button.Parent.PointToScreen(button.Location));


                ModulePanelUserControl modulePanelUserControl = new ModulePanelUserControl();
                // modulePanelUserControl.Location = new Point(locationOnForm.X, locationOnForm.Y + button.Height + 1);

                modulePanelUserControl.Location = new Point(button.Location.X, button.Location.Y);

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
            hideform.Size = parentForm.Size;
            hideform.Opacity = .6;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        public static void CalPopUpWindow(Form form, UserControl parentUc)
        {
            Form hideform = new Form();

            hideform.BackColor = Color.Black;
            hideform.Size = parentUc.Size;
            hideform.Opacity = .6;

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
    }
}
