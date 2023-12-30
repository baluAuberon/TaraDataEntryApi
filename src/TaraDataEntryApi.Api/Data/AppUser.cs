using Microsoft.AspNetCore.Identity;

namespace TARA.DATAENTRY.API.Data
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
    }
}
