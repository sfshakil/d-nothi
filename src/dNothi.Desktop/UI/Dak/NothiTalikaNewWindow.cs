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
    public partial class NothiTalikaNewWindow : UserControl
    {
        public NothiTalikaNewWindow()
        {
            InitializeComponent();
        }

        private void btnNothiTalikaCross_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name == "ExtraNothiTalikaForm" )
                    f.Close();
            }
        }
        private string _nothiTalikaHeading;

        [Category("Custom Props")]
        public string nothiTalikaHeading
        {
            get { return _nothiTalikaHeading; }
            set { _nothiTalikaHeading = value; lbNothiTalikaHeading.Text = "নথি তালিকা (" + value + ")"; }
        }
        public void LoadNothiNoteTalikaListinPanel(List<NothiNoteTalikaRecordsDTO> nothiNotetalikaLists)
        {
            lbLengthStart.Text = "১";
            lbLengthEnd.Text = string.Concat(nothiNotetalikaLists.Count.ToString().Select(c => (char)('\u09E6' + c - '0')));
            lbTotalBibechhoPotro.Text = " সর্বমোট: " + string.Concat(nothiNotetalikaLists.Count.ToString().Select(c => (char)('\u09E6' + c - '0')));
            foreach (NothiNoteTalikaRecordsDTO NothiNoteTalikaListDTO in nothiNotetalikaLists)
            {
                NothiTalika nothiTalika = new NothiTalika();
                nothiTalika.nothi = NothiNoteTalikaListDTO.nothi_no + " " + NothiNoteTalikaListDTO.subject;
                nothiTalika.shakha = NothiNoteTalikaListDTO.office_unit;
                nothiTalika.nothi_last_date = NothiNoteTalikaListDTO.created;
                nothiTalika.permitted = Convert.ToString(NothiNoteTalikaListDTO.permitted);
                UIDesignCommonMethod.AddRowinTable(nothiTalikaFlowLayoutPnl, nothiTalika);
            }
        }
    }
}
