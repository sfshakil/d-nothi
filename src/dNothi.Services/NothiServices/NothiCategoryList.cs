using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
   public class NothiCategoryList
    {
        public bool _isAll { get; set; }
        public bool _isInbox { get; set; }
        public bool _isOutbox { get; set; }


        private void MakeAllFalse()
        {
            _isInbox = false;
            _isOutbox = false;
            _isAll = false;
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
        public bool isAll
        {
            get { return _isAll; }
            set
            {
                if (value)
                {
                    MakeAllFalse();
                }
                _isAll = value;

            }
        }

        public bool isInbox
        {
            get { return _isInbox; }
            set
            {
                if (value)
                {
                    MakeAllFalse();
                }
                _isInbox = value;

            }

        }
        public string Category { get; set; }
        public string GetCategory
        {
            get
            {
                if (_isInbox)
                {
                    Category = "Agoto";
                }
                else if (_isOutbox)
                {
                    Category = "Prerito";
                }
                else if (_isAll)
                {
                    Category = "All";
                }
                


                return Category;


            }

        }
    }
}
