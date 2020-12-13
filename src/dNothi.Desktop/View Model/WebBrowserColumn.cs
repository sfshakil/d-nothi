using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.ViewModel
{
    public partial class WebBrowserColumn : DataGridViewColumn
    {
        public WebBrowserColumn()
            : base(new WebBrowserCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a WebBrowserCell.
                if (value != null && !value.GetType().IsAssignableFrom(typeof(WebBrowserCell)))
                {
                    throw new InvalidCastException("Must be a Webbrowser");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class WebBrowserCell : DataGridViewTextBoxCell
    {
        private static readonly WebBrowser _editingControl = new WebBrowser();

        public WebBrowserCell() : base()
        {
        }
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            WebBrowserEditingControl ctl =
                DataGridView.EditingControl as WebBrowserEditingControl;
            //Added later
            ctl.EditingControlFormattedValue = this.Value;

        }

        private static void SetRichTextBoxText(WebBrowser ctl, string text)
        {
            try
            {
                if (text is String)
                {
                    string val = text as string;
                    if (string.IsNullOrEmpty(val) == false)
                        ctl.Url = new Uri(text as string);
                }
                else
                    throw new Exception("Value format incorrect.");
            }
            catch (ArgumentException)
            {
            }
        }
        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that WebBrowserCell uses.
                return typeof(WebBrowserEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that WebBrowserCell contains.
                return typeof(string);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use blank as the default value.
                //return @"F:\Bhagawat.s\Bhagawat_Shinde\Ongoing\WebbrowserInGrid\WebbrowserInGrid\bin\Debug\Result.html";
                return "about:blank";
            }
        }

        private Image GetRtfImage(int rowIndex, object value, bool selected)
        {
            Size cellSize = GetSize(rowIndex);

            if (cellSize.Width < 1 || cellSize.Height < 1)
                return null;

            WebBrowser ctl = null;
            //ctl.ShortcutsEnabled = false;
            if (ctl == null)
            {
                ctl = _editingControl;
                ctl.Size = GetSize(rowIndex);
                // MessageBox.Show("Comming...");
                SetRichTextBoxText(ctl, Convert.ToString(value));
                //ctl.ShortcutsEnabled = false;
            }

            ////if (ctl != null)
            ////{
            ////    // Print the content of RichTextBox to an image.
            ////    Size imgSize = new Size(cellSize.Width - 1, cellSize.Height - 1);
            ////    Image rtfImg = null;

            ////    if (selected)
            ////    {
            ////        // Selected cell state
            ////        ctl.BackColor = DataGridView.DefaultCellStyle.SelectionBackColor;
            ////        ctl.ForeColor = DataGridView.DefaultCellStyle.SelectionForeColor;

            ////        // Print image
            ////        rtfImg = RichTextBoxPrinter.Print(ctl, imgSize.Width, imgSize.Height);

            ////        // Restore RichTextBox control 
            ////        ctl.BackColor = DataGridView.DefaultCellStyle.BackColor;
            ////        ctl.ForeColor = DataGridView.DefaultCellStyle.ForeColor;
            ////        //ctl.ShortcutsEnabled = false;
            ////    }
            ////    else
            ////    {
            ////        rtfImg = RichTextBoxPrinter.Print(ctl, imgSize.Width, imgSize.Height);
            ////    }
            ////    return rtfImg;
            ////}

            //   return null;
            return null;
        }
        /*protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            
            Bitmap bmp = new Bitmap(250, 250);
            _editingControl.DrawToBitmap(bmp, new Rectangle(_editingControl.Location.X, _editingControl.Location.Y, _editingControl.Width, _editingControl.Height));
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, null, null, errorText, cellStyle, advancedBorderStyle, paintParts);
            if (bmp != null)
                graphics.DrawImage(bmp, cellBounds.Left, cellBounds.Top);
        }*/
        #region Handlers of edit events, copyied from DataGridViewTextBoxCell

        private byte flagsState;

        protected override void OnEnter(int rowIndex, bool throughMouseClick)
        {
            base.OnEnter(rowIndex, throughMouseClick);

            if ((base.DataGridView != null) && throughMouseClick)
            {
                this.flagsState = (byte)(this.flagsState | 1);
            }
        }

        protected override void OnLeave(int rowIndex, bool throughMouseClick)
        {
            base.OnLeave(rowIndex, throughMouseClick);

            if (base.DataGridView != null)
            {
                this.flagsState = (byte)(this.flagsState & -2);
            }
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (base.DataGridView != null)
            {
                Point currentCellAddress = base.DataGridView.CurrentCellAddress;

                if (((currentCellAddress.X == e.ColumnIndex) && (currentCellAddress.Y == e.RowIndex)) && (e.Button == MouseButtons.Left))
                {
                    if ((this.flagsState & 1) != 0)
                    {
                        this.flagsState = (byte)(this.flagsState & -2);
                    }
                    else if (base.DataGridView.EditMode != DataGridViewEditMode.EditProgrammatically)
                    {
                        base.DataGridView.BeginEdit(false);
                    }
                }
            }
        }

        public override bool KeyEntersEditMode(KeyEventArgs e)
        {
            return (((((char.IsLetterOrDigit((char)((ushort)e.KeyCode)) && ((e.KeyCode < Keys.F1) || (e.KeyCode > Keys.F24))) || ((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.Divide))) || (((e.KeyCode >= Keys.OemSemicolon) && (e.KeyCode <= Keys.OemBackslash)) || ((e.KeyCode == Keys.Space) && !e.Shift))) && (!e.Alt && !e.Control)) || base.KeyEntersEditMode(e));
        }

        #endregion
    }

    class WebBrowserEditingControl : WebBrowser, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public WebBrowserEditingControl()
        {
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Url.AbsoluteUri;
            }
            set
            {
                if (value is String)
                {
                    string val = value as string;
                    if (string.IsNullOrEmpty(val) == false)
                        this.Url = new Uri(value as string);
                }
                else if (value is Uri)
                    this.Url = value as Uri;
                else
                    throw new Exception("Value format incorrect.");
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
        // method.
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            return dataGridViewWantsInputKey;
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.           
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnNavigated(WebBrowserNavigatedEventArgs e)
        {
            base.OnNavigated(e);
            // Notify the DataGridView that the contents of the cell
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        }

    }
}

