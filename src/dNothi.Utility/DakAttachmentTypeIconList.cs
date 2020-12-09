using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Utility
{
   public class DakAttachmentTypeIconList
    {
        public List<DakAttachmentIcon> _dakAttachmentIcons = new List<DakAttachmentIcon>();
        public DakAttachmentTypeIconList()
        {
            _dakAttachmentIcons.Add(new DakAttachmentIcon("0", "pdf", "PDF_File_Icon"));
            _dakAttachmentIcons.Add(new DakAttachmentIcon("1", "image", "Image_File_Icon"));
            _dakAttachmentIcons.Add(new DakAttachmentIcon("2", "Default", "Other_File_Icon"));
          


        }

        public string GetDakAttachmentTypeIcon(string Name)
        {
            string lowerCaseName = Name.ToLower();
           if(lowerCaseName.Contains(_dakAttachmentIcons[0]._typeName))
            {
                return _dakAttachmentIcons[0]._icon;
            }
            else if(lowerCaseName.Contains(_dakAttachmentIcons[1]._typeName))
            {
                return _dakAttachmentIcons[1]._icon;
            }
           else
            {
                return _dakAttachmentIcons[2]._icon;
            }

        }
      
    }
    public class DakAttachmentIcon
    {

        public string _id { get; set; }
        public string _typeName { get; set; }
        public string _icon { get; set; }

        public DakAttachmentIcon(string id, string typeName, string icon)
        {
            _id = id;
            _typeName = typeName;
            _icon = icon;
        }


    }
}

