using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Utility;

namespace dNothi.Desktop.UI.CustomMessageBox
{
    public partial class OnlineToggleButton : UserControl
    {
        public OnlineToggleButton()
        {
            InitializeComponent();
        }

        private void onlineButton_Click(object sender, EventArgs e)
        {


            if (InternetConnection.CheckMachineConnection() && onlineButton.IconChar != FontAwesome.Sharp.IconChar.ToggleOn)
            {
                OnlineToggle();
            }
            else
            {
                OfflineToogle();
            }

        }

        public void Toggle()
        {
            if (InternetConnection.Check())
            {
                RealOnlineToggle();
            }
            else
            {
                RealOfflineToogle();
            }
        }

        private void OnlineToggle()
        {
            onlineButton.IconChar = FontAwesome.Sharp.IconChar.ToggleOn;
            onlineButton.IconColor = Color.Green;
            InternetConnection.OfflineMode = false;
            MyToolTip.SetToolTip(onlineButton, "Offline");
        }
        private void RealOnlineToggle()
        {
            onlineButton.IconChar = FontAwesome.Sharp.IconChar.ToggleOn;
            onlineButton.IconColor = Color.Green;
            MyToolTip.SetToolTip(onlineButton, "Offline");
        }
        private void OfflineToogle()
        {
            onlineButton.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
            onlineButton.IconColor = Color.Gray;
            InternetConnection.OfflineMode = true;
            MyToolTip.SetToolTip(onlineButton, "Online");
        }
        private void RealOfflineToogle()
        {
            onlineButton.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
            onlineButton.IconColor = Color.Gray;
            MyToolTip.SetToolTip(onlineButton, "Online");
        }

        private void OnlineToggleButton_Load(object sender, EventArgs e)
        {
            if(InternetConnection.Check())
            {
                OnlineToggle();
            }
            else
            {
                OfflineToogle();
            }
        }
    }
}
