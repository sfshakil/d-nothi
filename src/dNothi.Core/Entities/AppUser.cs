using dNothi.Core.Shared;

namespace dNothi.Core.Entities
{
    public class AppUser:BaseEntity
    {
    public string Name { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
  }
}
