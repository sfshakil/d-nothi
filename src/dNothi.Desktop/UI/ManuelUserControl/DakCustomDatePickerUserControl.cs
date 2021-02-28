using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.ManuelUserControl
{
    public partial class DakCustomDatePickerUserControl : UserControl
    {
        public string _date { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }

        public DakCustomDatePickerUserControl()
        {
            InitializeComponent();

            AssignHoverButton(dateListBoxComboPanel.Controls);
        }

        private void AssignHoverButton(ControlCollection controls)
        {
           foreach(Control control in controls)
            {
                control.MouseHover += todayDatePickerButton_MouseHover;
                control.MouseLeave += todayDatePickerButton_MouseLeave;
            }
        }
        
        public event EventHandler OptionClick;

        


           
        
        private void Color_Blue_Border(object sender, PaintEventArgs e)
        {
         
          ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
            
        }

        private void yesterdayDatePickerButton_Click(object sender, EventArgs e)
        {
            _date = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd") + ":" + DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            if (this.OptionClick != null)
                this.OptionClick(sender, e);
        }

        private void todayDatePickerButton_MouseHover(object sender, EventArgs e)
        {
           // ResetAllButtonForeColor(dateListBoxComboPanel.Controls);
            (sender as Button).ForeColor = Color.Blue;
        }

        private void ResetAllButtonForeColor(ControlCollection controls)
        {
            throw new NotImplementedException();
        }

        private void todayDatePickerButton_MouseLeave(object sender, EventArgs e)
        {
           
            (sender as Button).ForeColor = Color.FromArgb(97, 99, 114);
        }

        private void todayDatePickerButton_Click(object sender, EventArgs e)
        {
            _date = DateTime.Now.ToString("yyyy/MM/dd") + ":" + DateTime.Now.ToString("yyyy/MM/dd");
            if (this.OptionClick != null)
                this.OptionClick(sender, e);
        }

        private void lastSevenDaysDatePickerButton_Click(object sender, EventArgs e)
        {
            _date = DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd") + ":" + DateTime.Now.ToString("yyyy/MM/dd");
            if (this.OptionClick != null)
                this.OptionClick(sender, e);
        }

        private void lastThirtyDaysDatePickerButton_Click(object sender, EventArgs e)
        {
            _date = DateTime.Now.AddDays(-29).ToString("yyyy/MM/dd") + ":" + DateTime.Now.ToString("yyyy/MM/dd");
            if (this.OptionClick != null)
                this.OptionClick(sender, e);
        }

        private void thisMonthDatePickerButton_Click(object sender, EventArgs e)
        {
            _date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/1:" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            if (this.OptionClick != null)
                this.OptionClick(sender, e);
        }

        private void lastMonthDatePickerButton_Click(object sender, EventArgs e)
        {
            _date = DateTime.Now.AddMonths(-1).Year.ToString() + "/" + DateTime.Now.AddMonths(-1).Month.ToString() + "/1:" + DateTime.Now.AddMonths(-1).Year.ToString() + "/" + DateTime.Now.AddMonths(-1).Month.ToString() + "/" + DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month);
            if (this.OptionClick != null)
                this.OptionClick(sender, e);

        }

        private void dateListBoxComboPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void customDatePickerButton_Click(object sender, EventArgs e)
        {
            customDatePickerButton.ForeColor = Color.FromArgb(203, 225, 248);
            rangeDatePickerPanel.Visible = true;
            dateFrom = DateTime.Now;
            dateTo = DateTime.Now;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            customDatePickerButton.ForeColor = Color.FromArgb(97, 99, 114);
            rangeDatePickerPanel.Visible = false;
            if (this.OptionClick != null)
                this.OptionClick(sender, e);
        }

        private void monthCalendarFrom_DateSelected(object sender, DateRangeEventArgs e)
        {

           
            if(dateFrom==dateTo)
            {
                if ((sender as MonthCalendar).SelectionStart>dateFrom)
                {
                    dateTo = (sender as MonthCalendar).SelectionStart;

                }
                else
                {
                    dateFrom = (sender as MonthCalendar).SelectionStart;
                }
            }
            else
            {
                dateFrom = dateTo = (sender as MonthCalendar).SelectionStart;
            }

            dateRangeLabel.Text = dateFrom.ToString("yyyy/MM/dd") + "-" + dateTo.ToString("yyyy/MM/dd");
            monthCalendarFrom.SelectionRange= new SelectionRange(dateFrom, dateTo);
            monthCalendarTo.SelectionRange = new SelectionRange(dateFrom, dateTo);

        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            customDatePickerButton.ForeColor = Color.FromArgb(97, 99, 114);
            rangeDatePickerPanel.Visible = false;
            _date = dateFrom.ToString("yyyy/MM/dd") + ":" + dateTo.ToString("yyyy/MM/dd");
            if (this.OptionClick != null)
                this.OptionClick(sender, e);
        }

        private void rangeDatePickerPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
