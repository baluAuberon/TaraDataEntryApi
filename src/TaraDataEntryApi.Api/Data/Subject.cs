using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TARA.DATAENTRY.API.Data
{
    public class Subject : ClassBase
    { 
    
        [Key]
        public int Id { get; set; }

        [Required]
        public string SubjectName { get; set; }
        
        public int ClassId { get; set; }

        [ForeignKey(nameof(ClassId))]
        public virtual Class Class { get; set; }

        // Navigation property for the one-to-many relationship with lessons
        public virtual ICollection<Lesson> Lessons { get; set; }

        // Navigation property for the many-to-one relationship with Class
      

    }
}
