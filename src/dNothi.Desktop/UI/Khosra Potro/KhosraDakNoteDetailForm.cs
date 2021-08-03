using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Khosra_Potro
{
    public partial class KhosraDakNoteDetailForm : Form
    {
        IUserService _userService { get; set; }
        IOnuchhedListServices _onuchhedList { get; set; }
        ISingleOnucchedServices _singleOnucched { get; set; }


        public string _noteSubject;
       [Category("Custom Props")]
        public string noteSubject
        {
            get { return _noteSubject; }
            set { _noteSubject = value; lbNoteSubject.Text = value; }
        }
        private bool _khosra;
        public void Khoshra()
        {

            _khosra = true;
        }

        public KhosraDakNoteDetailForm( IUserService userService, IOnuchhedListServices onuchhedList, ISingleOnucchedServices singleOnucched)
        {
          
         
            _userService = userService;
            _onuchhedList = onuchhedList;
            _singleOnucched = singleOnucched;
           
            InitializeComponent();
          
        }


       
        public void loadNoteOnucced(int nothiid, int note_id, NoteNothiDTO noteNothiDTO, NothiListAllRecordsDTO nothiListAllRecordsDTO)
        {
            try
            {
                var _dakuserparam = _userService.GetLocalDakUserParam();

                //NoteAllListResponse allNoteList = _nothiNoteTalikaServices.GetNoteListAll(_dakuserparam, nothiListRecords.id);
                OnucchedListResponse onucchedList = _onuchhedList.GetAllOnucchedList(_dakuserparam, nothiid, note_id);
                if (onucchedList == null)
                {
                   
                }
                else
                {
                    if (onucchedList.data.total_records > 0)
                    {
                        int flag = 0;
                        onuchhedFLP.Visible = true;
                        onuchhedFLP.Controls.Clear();
                        noteHeaderPanel.Width = 990;
                        noteHeaderPanel.Height = 426;
                        var onuchhedNo = "0";
                        int totalOnuchhed = 0;
                       

                        OnucchedListDataRecordDTO last = onucchedList.data.records.Last();
                        foreach (OnucchedListDataRecordDTO onucchedsingleListRec in onucchedList.data.records)
                        {
                            int[] sequence_onuchhed_id = onucchedsingleListRec.sequence_onucched_ids.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                            int[] sequence_onuchhed_no = onucchedsingleListRec.onucched_no.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                            totalOnuchhed = totalOnuchhed + sequence_onuchhed_no.Length;
                            var zip = sequence_onuchhed_id.Zip(sequence_onuchhed_no, (onuchhed_id, onuchhed_no) => new { onuchhed_id, onuchhed_no });
                            foreach (var z in zip)
                            {
                                flag++;
                                SingleOnucchedResponse singleOnucched = new SingleOnucchedResponse();
                                try
                                {
                                     singleOnucched = _singleOnucched.GetSingleOnucched(_dakuserparam, nothiid, note_id, z.onuchhed_id);

                                }
                                catch
                                {
                                    continue;
                                }
                                if (singleOnucched.data.total_records > 0)
                                {
                                    var rec = singleOnucched.data.records;
                                    onuchhedNo = onucchedsingleListRec.onucched_no;
                                    lbNoteTotl1.Text = "নোটঃ " + nothiListAllRecordsDTO.desk.note_count;
                                    lbNoteSubject.Text = _noteSubject;
                                    lbNothiLastDate.Text = nothiListAllRecordsDTO.nothi.last_note_date;


                                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                    var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                    if (rec[0].attachment.Count > 0)
                                    {
                                        separateOnucched.totalFileNo = rec[0].attachment.Count.ToString();
                                        foreach (AttachmentDTO attachment in rec[0].attachment)
                                        {
                                            separateOnucched.fileAddInFilePanel(attachment);

                                        }
                                    }
                                    else
                                    {
                                        separateOnucched.filePnaeloff();
                                    }
                                    separateOnucched.office = onucchedsingleListRec.employee_name + " " + onucchedsingleListRec.created;
                                    separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), z.onuchhed_no.ToString());
                                    separateOnucched.createDate = onucchedsingleListRec.created;
                                    separateOnucched.onucchedId = z.onuchhed_id;

                                    try
                                    {
                                        separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(rec[0].onucched.note_description));
                                    }
                                    catch
                                    {

                                    }
                                    foreach (SingleOnucchedRecordSignatureDTO singleRecSignature in rec[0].signature)
                                    {
                                        separateOnucched.loadOnuchhedSignature(singleRecSignature);
                                    }

                                    if (totalOnuchhed == flag && onucchedsingleListRec.Equals(last))
                                    {
                                        separateOnucched.lastopenOnuchhed();
                                    }
                                    separateOnucched.ButtonVisibleFromKasra();
                                    //onuchhedFLP.Controls.Add(separateOnucched);
                                    UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);

                                }
                            }
                        }


                    }
                    else
                    {
                        noteHeaderPanel.Width = 990;
                        noteHeaderPanel.Height = 81;
                        //lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                        //lbNoteSubject.Text = list.note_subject_sub_text;
                        //lbNothiLastDate.Text = list.date;

                        onuchhedFLP.Visible = false;

                     


                    }
                }

               
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }

       
        public void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();
        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }
        private void DakNothiteUposthapitoForm_Load(object sender, EventArgs e)
        {

            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            this.Height = scr.WorkingArea.Height;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void detailPanelDropDownButton_Click(object sender, EventArgs e)
        {
            //if (detailsNothiSearcPanel.Visible)
            //{
            //    detailsNothiSearcPanel.Visible = false;
            //}
            //else
            //{
            //    detailsNothiSearcPanel.Visible = true;
            //}
        }

        private void BorderBlueColor(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);


        }
    }
}
