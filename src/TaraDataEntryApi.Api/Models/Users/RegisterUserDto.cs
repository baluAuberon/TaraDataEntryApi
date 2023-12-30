using System.ComponentModel.DataAnnotations;

namespace TARA.DATAENTRY.API.Models.Users
{
    public class RegisterUserDto:LoginDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
       
        public string[] Roles { get; set; }

    }
}
