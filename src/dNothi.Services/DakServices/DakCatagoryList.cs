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

        private void MakeAllFalse()
        {
            _isInbox = false;
            _isOutbox = false;
            _isArchived = false;
            _isNothijato = false;
            _isNothivukto = false;
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
                else if(_isArchived)
                {
                    Name = "আর্কাইভকৃত ডাক";
                }



                return Name;


            }
        
        }


    }
}
