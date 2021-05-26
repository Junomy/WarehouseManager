using Microsoft.AspNetCore.Identity;
namespace DAL.Entities
{
    public class Admin : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
