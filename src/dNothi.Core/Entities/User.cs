
using dNothi.Core.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace dNothi.Core.Entities
{
    public class User : BaseEntity
    {
        [StringLength(500)]
        public string username { get; set; }
        [StringLength(500)]
        public string user_alias { get; set; }
        public bool active { get; set; }
        public int employee_record_id { get; set; }
        public int userid { get; set; }

        [MaxLength]
        public string SignBase64 { get; set; }

        [MaxLength]
        public string doptor_token { get; set; }
    }
}
