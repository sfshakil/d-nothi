using dNothi.JsonParser.Entity.Nothi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class OnumoditoPodobi : UserControl
    {
        public OnumoditoPodobi()
        {
            InitializeComponent();
        }

        private void btnNothiTypeCross_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "Note")
                    f.Close();
            }
        }
        List<onumodonDataRecordDTO> records = new List<onumodonDataRecordDTO>();
        public void GetNothiInboxRecords(List<onumodonDataRecordDTO> onumodonList)
        {


            records = onumodonList;

            if (onumodonList.Count > 0)
            {
                records = onumodonList.OrderByDescending(a => a.layer_index).ThenBy(a => a.route_index).ToList();
                var groupLevel = records.GroupBy(a => a.layer_index);
                foreach (var group in groupLevel)
                {



                    NothiOnumodonLevel nothiOnumodonRow = new NothiOnumodonLevel();
                    nothiOnumodonRow.level = group.Key.ToString();
                    nothiOnumodonRow.layerIndex = group.Key;
                    nothiOnumodonRow.isFromNothiNextStep = true;
                    //nothiOnumodonRow.CheckBoxButton += delegate (object sender, EventArgs e) { CheckboxOfficer_ButtonClick(sender, e, nothiOnumodonRow._designationId, nothiOnumodonRow._isChecked); };







                    foreach (var officer in group)
                    {

                        nothiOnumodonRow.AddNewOfficerFromNothiNextStep(officer.officer, officer.designation_id, officer.designation + "," + officer.office_unit + "," + officer.nothi_office_name, officer.route_index, 1);


                    }

                    nothiOnumodonListFlowLayoutPanel.Controls.Add(nothiOnumodonRow);



                }
            }



        }
    }
}
