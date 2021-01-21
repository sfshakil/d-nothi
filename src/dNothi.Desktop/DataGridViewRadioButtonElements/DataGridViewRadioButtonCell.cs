using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace dNothi.Desktop.DataGridViewRadioButtonElements
{
    public class DataGridViewRadioButtonCell : DataGridViewCheckBoxCell
    {
        public bool Enabled { get; set; }

        // Override the Clone method so that the Enabled property is copied.
        public override object Clone()
        {
            DataGridViewRadioButtonCell cell = (DataGridViewRadioButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        // By default, enable the CheckBox cell.
        public DataGridViewRadioButtonCell()
        {
            this.Enabled = true;
        }
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
 DataGridViewElementStates elementState, object value, object formattedValue, string errorText,
 DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            // Draw the cell background, if specified.
            if ((paintParts & DataGridViewPaintParts.Background) == DataGridViewPaintParts.Background)
            {
                SolidBrush cellBackground = new SolidBrush(cellStyle.BackColor);
                graphics.FillRectangle(cellBackground, cellBounds);
                cellBackground.Dispose();
            }

            // Draw the cell borders, if specified.
            if ((paintParts & DataGridViewPaintParts.Border) == DataGridViewPaintParts.Border)
            {
                PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            }

            // Calculate the area in which to draw the checkBox.
            RadioButtonState state =value!=null && (bool)value == true ? RadioButtonState.CheckedNormal : RadioButtonState.UncheckedNormal;
            Size size = RadioButtonRenderer.GetGlyphSize(graphics, state);
            Point center = new Point(cellBounds.X, cellBounds.Y);
            center.X += (cellBounds.Width - size.Width) / 2;
            center.Y += (cellBounds.Height - size.Height) / 2;

            // Draw the disabled checkBox.
            RadioButtonRenderer.DrawRadioButton(graphics, center, state);
        }


        public enum SelectedStatus
        {
            Selected,
            NoSelected,
            Indeterminate
        }
    }

    public class DataGridViewRadioButtonColumn : DataGridViewCheckBoxColumn
    {
        public DataGridViewRadioButtonColumn()
        {
            this.CellTemplate = new DataGridViewRadioButtonCell();
        }
    }



   

       
    
}
