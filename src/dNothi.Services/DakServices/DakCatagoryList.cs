using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
   public class DakCatagoryList
    {
        public bool _isInbox { get; set; }
        public bool _isOutbox { get; set; }
        public bool _isNothijato { get; set; }
        public bool _isNothivukto { get; set; }
        public bool _isSorted { get; set; }
        public bool _isKhosra { get; set; }
        public bool _isArchived { get; set; }
        public bool isInbox { get { return _isInbox; }
            set { 
                if(value)
                {
                    MakeAllFalse();
                }
                _isInbox = value; 
            
            } 
        
        }

        public bool isSorted
        {
            get { return _isSorted; }
            set
            {
                if (value)
                {
                    MakeAllFalse();
                }
                _isSorted = value;

            }

        }
        public bool isKhosra
        {
            get { return _isKhosra; }
            set
            {
                if (value)
                {
                    MakeAllFalse();
                }
                _isKhosra = value;

            }

        }

        public void MakeAllFalse()
        {
            _isInbox = false;
            _isOutbox = false;
            _isArchived = false;
            _isNothijato = false;
            _isNothivukto = false;
            _isSorted = false;
            _isKhosra = false;
        }

        public bool isOutbox
        {
            get { return _isOutbox; }
            set
            {
                if (value)
                {
                    MakeAllFalse();
                }
                _isOutbox = value;

            }
        }
        public bool isNothijato {
            get { return _isNothijato; }
            set
            {
                if (value)
                {
                    MakeAllFalse();
                }
                _isNothijato = value;

            }
        }
        public bool isNothivukto {
            get { return _isNothivukto; }
            set
            {
                if (value)
                {
                    MakeAllFalse();
                }
                _isNothivukto = value;

            }
        }
        public bool isArchived {
            get { return _isArchived; }
            set
            {
                if (value)
                {
                    MakeAllFalse();
                }
                _isArchived = value;

            }
        }

        public string Name { get; set; }


        public string GetName { 
            get 
            { 
                if(_isInbox)
                {
                    Name = "আগত ডাক";
                }
                else if(_isOutbox)
                {
                    Name = "প্রেরিত ডাক";
                }
                else if(_isNothijato)
                {
                    Name = "নথিজাত ডাক";
                }
                else if(_isNothivukto)
                {
                    Name = "নথিতে উপস্থাপিত ডাক";
                }
                else if(_isSorted)
                {
                    Name = "বাছাইকৃত ডাক";
                }
                else if(_isArchived)
                {
                    Name = "আর্কাইভকৃত ডাক";
                } 
                else if(_isKhosra)
                {
                    Name = "খসড়া ডাক";
                }



                return Name;


            }
        
        }

        public string GetNameEng
        {
            get
            {
                if (_isInbox)
                {
                    Name = "inbox";
                }
                else if (_isOutbox)
                {
                    Name = "sent";
                }
                else if (_isNothijato)
                {
                    Name = "nothijato";
                }
                else if (_isNothivukto)
                {
                    Name = "nothivukto";
                }
                else if (_isSorted)
                {
                    Name = "sorted";
                }
                else if (_isArchived)
                {
                    Name = "archive";
                }
                else if (_isKhosra)
                {
                    Name = "draft";
                }



                return Name;


            }

        }

        public string SetCategory
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;

                if (SetCategory=="Inbox")
                {
                    MakeAllFalse();
                    _isInbox =true;

                }
                else if (SetCategory == "Forward")
                {
                    MakeAllFalse();
                    _isOutbox = true;

                }
                else if (SetCategory == "Nothijato")
                {
                    MakeAllFalse();
                    _isNothijato = true;

                }
                else if (SetCategory == "Nothivukto")
                {
                    MakeAllFalse();
                    _isNothivukto = true;

                }
                else if (SetCategory == "Archive")
                {
                    MakeAllFalse();
                    _isArchived = true;

                }
                else if (SetCategory == "Sorted")
                {
                    MakeAllFalse();
                    _isSorted = true;

                }
                else if (SetCategory == "Draft")
                {
                    MakeAllFalse();
                    _isKhosra = true;

                }

              



               


            }

        }


    }
}
