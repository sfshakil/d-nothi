using dNothi.JsonParser.Entity.Nothi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
   public class NothiOnumodonSealParam
    {
        public int id { get; set; }
        public int office_id { get; set; }
        public int officer_id { get; set; }
        public int office_unit_id { get; set; }
        public int designation_id { get; set; }
        public string nothi_office_name { get; set; }
        public string office { get; set; }
        public string office_unit { get; set; }
        public string designation { get; set; }
        public string level_name { get; set; }
        public int designation_level { get; set; }

      
        public int is_strict_route { get; set; }
        public int route_index { get; set; }
        public int max_transaction_day { get; set; }
        public int layer_index { get; set; }
       
       

        public void ConvertDTOtoReques(onumodonDataRecordDTO onumodonDataRecordDTO)
        {
            if (onumodonDataRecordDTO.id != 0) { this.id = onumodonDataRecordDTO.id; }
            this.office_unit_id = onumodonDataRecordDTO.office_unit_id;
            this.designation_id = onumodonDataRecordDTO.designation_id;
            if (onumodonDataRecordDTO.nothi_office_name == null) 
            {
                this.nothi_office_name = onumodonDataRecordDTO.officer;
            }
            else
            {
                this.nothi_office_name = onumodonDataRecordDTO.nothi_office_name;
            } 
            
            this.office = onumodonDataRecordDTO.office;
            this.office_unit = onumodonDataRecordDTO.office_unit;
            this.designation = onumodonDataRecordDTO.designation;
            this.designation_level = onumodonDataRecordDTO.designation_level;
            this.is_strict_route = onumodonDataRecordDTO.is_strict_route;
            this.route_index = onumodonDataRecordDTO.route_index;
            this.max_transaction_day = onumodonDataRecordDTO.max_transaction_day;
            this.layer_index = onumodonDataRecordDTO.layer_index;
            this.office_id = onumodonDataRecordDTO.office_id;
            this.officer_id = onumodonDataRecordDTO.officer_id;
            this.level_name = onumodonDataRecordDTO.level_name;
        }
       
    }
}
