using dNothi.Core.Shared;
using System.ComponentModel.DataAnnotations;

namespace dNothi.Core.Entities
{
    public class AppUser : BaseEntity
    {
        [StringLength(200)]
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }

        public bool isRemember { get; set; }
        [StringLength(500)]
        public string Role { get; set; }
    }
}
