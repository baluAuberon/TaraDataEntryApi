using System.ComponentModel.DataAnnotations;

namespace TARA.DATAENTRY.API.Models.Masters
{
    public class ClassDto
    {
        [Required]
        public string ClassName { get; set; }
    }
}
