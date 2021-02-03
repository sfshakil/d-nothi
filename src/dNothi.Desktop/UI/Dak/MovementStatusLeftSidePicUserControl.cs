using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using dNothi.Utility;

namespace dNothi.Desktop.UI.Dak
{
    public partial class MovementStatusLeftSidePicUserControl : UserControl
    {
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
        public MovementStatusLeftSidePicUserControl()
        {
            InitializeComponent();
            SetDefaultFont(this.Controls);
        }

        private MovementStatusDTO _dakMovementStatus;
        private string _decision;

        private string _date;
        private string _dakSecurityIconValue;

        private string _dakPriority;


        public string dakPrioriy
        {
            get { return _dakPriority; }
            set
            {
                _dakPriority = value;


                DakPriorityList dakPriorityList = new DakPriorityList();
                string priorityName = dakPriorityList.GetDakPriorityName(value);


                if (priorityName == "")
                {
                    priorityPanel.Visible = false;
                }
                else
                {
                    priorityPanel.Visible = true;
                    prioriyLabel.Text = priorityName;

                }






            }
        }

        public string dakSecurityIconValue
        {



            get { return _dakSecurityIconValue; }
            set
            {
                _dakSecurityIconValue = value;

                DakSecurityList dakSecurityList = new DakSecurityList();
                string icon = dakSecurityList.GetDakSecuritiesIcon(value);

                dakSecurityIconPanel.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(icon);

                if (dakSecurityIconPanel.BackgroundImage == null)
                {
                    securityPanel.Visible = false;
                }
                else
                {
                    securityPanel.Visible = true;

                }






            }
        }

        public string date
        {
            get { return _date; }
            set { _date = value; dateLabel.Text = value; }
        }

        public string decision
        {
            get { return _decision; }
            set { _decision = value; decisionLabel.Text = value; }
        }
        public MovementStatusDTO movementStatusDTO
        {
            get { return _dakMovementStatus;}
            set
            {
                _dakMovementStatus = value;
                movementStatusdetailsFlowLayoutPanel.Controls.Clear();
                DakMovementStatusListUserControl movementStatusDetailsUserControlSender = new DakMovementStatusListUserControl();

                try
                {
                    movementStatusDetailsUserControlSender.userType = "প্রেরক           :";
                    movementStatusDetailsUserControlSender.userDesignation = value.from.officer;
                    movementStatusDetailsUserControlSender.userDesignation += " (" + value.from.designation + "," + value.from.office_unit + "," + value.from.office + ")";
                    movementStatusdetailsFlowLayoutPanel.Controls.Add(movementStatusDetailsUserControlSender);
                }
                catch
                {

                }

                DakMovementStatusListUserControl movementStatusDetailsUserControlReceiver = new DakMovementStatusListUserControl();

                try
                {
                    movementStatusDetailsUserControlReceiver.userType = "মূল প্রাপক      :";
                    ToDTO toDTO = value.to.FirstOrDefault(a =>a.attention_type == "1" && a.designation_id!=value.from.designation_id);


                    movementStatusDetailsUserControlReceiver.userDesignation = toDTO.officer;
                    movementStatusDetailsUserControlReceiver.userDesignation += " (" + toDTO.designation + "," + toDTO.office_unit + "," + toDTO.office + ")";
                    movementStatusdetailsFlowLayoutPanel.Controls.Add(movementStatusDetailsUserControlReceiver);
                }
                catch
                {

                }

                try
                {
                    string type = "অনুলিপি প্রাপক :";
                    foreach (ToDTO toDTO in value.to.Where(a => a.attention_type != "1"))
                    {
                        DakMovementStatusListUserControl movementStatusDetailsUserControlOnulipi = new DakMovementStatusListUserControl();

                        movementStatusDetailsUserControlOnulipi.userType = type;
                        movementStatusDetailsUserControlOnulipi.userDesignation = toDTO.officer;
                        movementStatusDetailsUserControlOnulipi.userDesignation += " (" + toDTO.designation + "," + toDTO.office_unit + "," + toDTO.office + ")";
                        movementStatusdetailsFlowLayoutPanel.Controls.Add(movementStatusDetailsUserControlOnulipi);
                        type = "";
                    }

                }
                catch
                {

                }

              //  HorizontalLine.Height = descriptionPanel.Height;







            }
        }
    }
}
