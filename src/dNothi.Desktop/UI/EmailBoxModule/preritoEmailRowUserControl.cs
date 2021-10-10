using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.EmailBoxModule
{
    public partial class preritoEmailRowUserControl : UserControl
    {


        public string _sub { get; set; }
        public string sub {
            get
            {
                return _sub;
            }
            set
            {
                _sub = value;
                subLabel.Text = value;
            }
        }
        public string _nothiNo { get; set; }
        public string nothiNo
        {
            get
            {
                return _nothiNo;
            }
            set
            {
                _nothiNo = value;
                nothiNoLabel.Text = value;
                nothiNoLabel.Visible = nothiNoHeaderLabel.Visible = true;



            }
        }

        public string _type { get; set; }
        public string type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                typeLabel.Text =(value=="Daptorik")? "দাপ্তরিক":"নাগরিক";
                typeLabel.Visible = typeHeaderLabel.Visible = true;



            }
        }

        public string _sharokNo { get; set; }
        public string sharokNo
        {
            get
            {
                return _sharokNo;
            }
            set
            {
                _sharokNo = value;
                sharokNoLabel.Text = ConversionMethod.EngDigittoBanDigit(value);
                sharokNoLabel.Visible = sharokHeaderlabel.Visible = true;



            }
        }

        public string _sender { get; set; }
        public string sender
        {
            get
            {
                return _sender;
            }
            set
            {
                _sender = value;
                senderNameLabel.Text = value;
            }
        }

        public string _activityInfo { get; set; }
        public string activityInfo
        {
            get
            {
                return _activityInfo;
            }
            set
            {
                _activityInfo = value;
                activityInfoLabel.Text = value;
            }
        }


        public string _receiver { get; set; }
        public string receiver
        {
            get
            {
                return _receiver;
            }
            set
            {
                _receiver = value;
                receiverLabel.Text = value;
            }
        }

        public string _mailDate { get; set; }
        public string mailDate
        {
            get
            {
                return _mailDate;
            }
            set
            {
                _mailDate = value;

                String engDate = ConversionMethod.BanglaDigittoEngDigit(value);
                DateTime dateTime = Convert.ToDateTime(engDate);
                mailDateLabel.Text = ConversionMethod.EngDigittoBanDigit(dateTime.ToString("dd-MM-yyyy HH:mm:ss"));

                
            }
        }



        public preritoEmailRowUserControl()
        {
            InitializeComponent();
        }

        private void Border_Color_Gray(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Gray(sender, e);
        }
    }
}
