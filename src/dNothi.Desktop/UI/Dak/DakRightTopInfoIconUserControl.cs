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

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakRightTopInfoIconUserControl : UserControl
    {
        public DakRightTopInfoIconUserControl()
        {
            InitializeComponent();
        }


        private string _attentionTypeIconValue;
        private string _dakSecurityIconValue;
        private string _dakType;
        private string _dakPriority;
        private int _potrojari;

        private string _dakViewStatus;


        public string dakViewStatus
        {
            get { return _dakViewStatus; }
            set
            {
                _dakViewStatus = value;
                if (value == "New")
                {
                    newDakImagePanel.Visible = true;


                }
                else
                {
                    newDakImagePanel.Visible = false;
                }

            }
        }

        [Category("Custom Props")]
        public int potrojari
        {
            get { return _potrojari; }
            set
            {
                _potrojari = value;



                if (value == 1)
                {
                    potrojariPanel.Visible = true;
                }
                else
                {
                    potrojariPanel.Visible = false;
                }






            }
        }

        [Category("Custom Props")]
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
                    dakPriorityIconPanel.Visible = false;
                }
                else
                {
                    dakPriorityIconPanel.Visible = true;
                    prioriyLabel.Text = priorityName;

                }






            }
        }

        public string _daksource { get; set; }
        public string daksource { 
            get
            {
                return _daksource;
            }
            set
            {
                _daksource = value;
                sourceLabel.Text = value.ToUpper();
            }
                
        }

        [Category("Custom Props")]
        public string dakType
        {



            get { return _dakType; }
            set
            {
                _dakType = value;

                CheckNagorikDakType checkNagorikDakType = new CheckNagorikDakType(value);

                if(checkNagorikDakType.IsNagarik)
                {
                    dakTypePanel.Visible = true;
                }
                else
                {
                    dakTypePanel.Visible = false;
                }

                






            }
        }

        [Category("Custom Props")]
        public string dakSecurityIconValue
        {



            get { return _dakSecurityIconValue; }
            set
            {
                _dakSecurityIconValue = value;

                DakSecurityList dakSecurityList = new DakSecurityList();
                string icon = dakSecurityList.GetDakSecuritiesIcon(value);
                string Name = dakSecurityList.GetDakSecuritiesName(value);

                dakSecurityIcon.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(icon);

                if (Name == "")
                {
                    dakSecurityIconPanel.Visible = false;
                }
                else
                {
                    dakSecurityIconPanel.Visible = true;
                    dakSecurityLabel.Text = Name;
                }






            }
        }




        [Category("Custom Props")]
        public string attentionTypeIconValue
        {



            get { return _attentionTypeIconValue; }
            set
            {
                _attentionTypeIconValue = value;
               
                AttentionTypeList attentionTypeIconList = new AttentionTypeList();
                string Name = attentionTypeIconList.GetAttentionTypeName(value);
                if (Name == "")
                {
                    AttentionTypePanel.Visible = false;
                }
                else
                {
                    AttentionTypePanel.Visible = true;
                    attentionTypeLabel.Text = Name;
                }






            }
        }
    }
}
