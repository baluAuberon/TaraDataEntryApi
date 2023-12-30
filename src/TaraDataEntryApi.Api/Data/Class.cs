using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace TARA.DATAENTRY.API.Data
{
    public class Class : ClassBase
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string ClassName { get; set; }

        // Navigation property for one-to-many relationship with subjects
        public virtual ICollection<Subject> Subjects { get; set; }

    }
}
