using System;
using System.Windows.Forms;

namespace dNothi.Desktop.DataGridViewRadioButtonElements
{
    public class MyDataGridView: DataGridView
    {
        // MyDataGridView.OnGlobalColumnAutoSize implementation
        public void OnGlobalColumnAutoSize(int columnIndex)
        {
            if (columnIndex < -1 || columnIndex >= this.Columns.Count)
            {
                throw new ArgumentOutOfRangeException("columnIndex");
            }
            OnColumnDefaultCellStyleChanged(new DataGridViewColumnEventArgs(this.Columns[columnIndex]));
        }
    }
}