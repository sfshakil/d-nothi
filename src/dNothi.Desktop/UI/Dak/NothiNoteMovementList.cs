using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dNothi.JsonParser.Entity.Nothi.NothiListInboxNoteResponse;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiNoteMovementList : UserControl
    {
        public NothiNoteMovementList()
        {
            InitializeComponent();
            
        }
        public void loadNoteMovement(NoteMovementsListResponse noteMovementsListResponse)
        {
            if (noteMovementsListResponse.data != null)
            {
                if (noteMovementsListResponse.data.total_records > 0)
                {
                    movementViewFLP.Controls.Clear();
                    pnlNoData.Visible = false;
                    loadMovementsinPanel(noteMovementsListResponse.data.records);
                }
                else
                {
                    movementViewFLP.Controls.Clear();
                    pnlNoData.Visible = true;
                }
            }
            else
            {
                movementViewFLP.Controls.Clear();
                pnlNoData.Visible = true;
            }
            
        }

        public void loadMovementsinPanel(List<NoteMovementsRecord> records)
        {
            foreach (NoteMovementsRecord record in records)
            {
                NoteMovement noteMovement = new NoteMovement();
                noteMovement.date = record.other.modified;

                noteMovement.toName = record.to[0].officer;
                noteMovement.toDesignation = record.to[0].designation + ", "+ record.to[0].office_unit+", "+ record.to[0].office;
                
                noteMovement.formName = record.from.officer;
                noteMovement.formDesignation = record.from.designation + ", "+ record.from.office_unit+", "+ record.from.office;

                noteMovement.thumb = record.from.thumb;
                noteMovement.movement_type = record.other.movement_type;

                UIDesignCommonMethod.AddRowinTable(movementViewFLP, noteMovement);
            }
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
    }
}
