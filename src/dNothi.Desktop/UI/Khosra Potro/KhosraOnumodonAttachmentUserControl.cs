using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Khosra;
using dNothi.Utility;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class KhosraOnumodonAttachmentUserControl : UserControl
    {
        public PermittedPotroResponseRecordDTO _permittedPotroResponseRecordDTO { get; set; }
        public PermittedPotroResponseRecordDTO permittedPotroResponseRecordDTO {
            
            get
            {
                return _permittedPotroResponseRecordDTO; 
            }
            set
            {
                attachmentListTableLayoutPanel.Controls.Clear();
                _permittedPotroResponseRecordDTO = value;
                if(value != null)
                {
                    nothiNameLabel.Text =value.basic.sarok_no+"-"+value.basic.subject;
                    if(value.mulpotro!=null)
                    {
                        value.mulpotro.nothi_potro_id = value.basic.id;
                        KhosraSingleAttachmentUserControl khosramuplotroUserControl = new KhosraSingleAttachmentUserControl();
                        //value.mulpotro.user_file_name= value.basic.sarok_no + "-" + value.basic.subject;
                        khosramuplotroUserControl.permittedPotroResponseMulpotroDTO = value.mulpotro;

                        khosramuplotroUserControl.checkButtonClick += delegate (object sender, EventArgs e) { Check_ButtonClick(sender, e, khosramuplotroUserControl._permittedPotroResponseMulpotroDTO, khosramuplotroUserControl.isChecked); };


                        UIDesignCommonMethod.AddRowinTable(attachmentListTableLayoutPanel, khosramuplotroUserControl);
                    }


                    if(value.attachment != null && value.attachment.Count>0)
                    {
                        SetAttachmentCount(value.attachment.Count);
                        foreach(var attachment in value.attachment)
                        {
                            attachment.nothi_potro_id = value.basic.id;
                            KhosraSingleAttachmentUserControl khosraAttachmentUserControl = new KhosraSingleAttachmentUserControl();
                            khosraAttachmentUserControl.permittedPotroResponseMulpotroDTO = attachment;
                            khosraAttachmentUserControl.checkButtonClick += delegate (object sender, EventArgs e) { Check_ButtonClick(sender, e, khosraAttachmentUserControl._permittedPotroResponseMulpotroDTO, khosraAttachmentUserControl.isChecked); };

                            UIDesignCommonMethod.AddRowinTable(attachmentListTableLayoutPanel, khosraAttachmentUserControl);

                        }
                    }
                    else
                    {
                        SetAttachmentCount(0);
                    }
                }
            }
                
                
                
        
        }
        public PermittedPotroResponseMulpotroDTO selectedPermittedPotroResponseMulpotroDTO { get; set; }
        public bool isPotroSelected;
        public event EventHandler checkButtonClick;
        private void Check_ButtonClick(object sender, EventArgs e, PermittedPotroResponseMulpotroDTO permittedPotroResponseMulpotroDTO, bool isChecked)
        {
            selectedPermittedPotroResponseMulpotroDTO = permittedPotroResponseMulpotroDTO;
            isPotroSelected = isChecked;
            if (this.checkButtonClick != null)
                this.checkButtonClick(sender, e);
        }

        private void SetAttachmentCount(int count)
        {
           if(count ==0)
            {
                attachmentCountLabel.Text = "কোনো সংযুক্তি নেই";
            }
            else
            {
                attachmentCountLabel.Text = "সংযুক্তিঃ "+ConversionMethod.EngDigittoBanDigit(count.ToString());
                allSelectPanel.Visible = true;
            }
        }

        public bool _isChecked { get; set; }
        public bool isChecked {
            get { return _isChecked; }
            set
            {
                _isChecked = value;


                var khosraSelectedAttachmentRows = attachmentListTableLayoutPanel.Controls.OfType<KhosraSingleAttachmentUserControl>().ToList();
                if(khosraSelectedAttachmentRows != null && khosraSelectedAttachmentRows.Count>0)
                {
                    //khosraSelectedAttachmentRows.Where(a => a.isChecked = value);
                    foreach (var singleRow in khosraSelectedAttachmentRows)
                    {
                        singleRow.isChecked = isChecked;
                    }
                }

            }

        }

        public KhosraOnumodonAttachmentUserControl()
        {
            InitializeComponent();
        }

        private void allSelectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = allSelectCheckBox.Checked;
        }
    }
}
