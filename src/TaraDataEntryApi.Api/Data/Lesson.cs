using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TARA.DATAENTRY.API.Data
{
    public class Lesson : ClassBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LessonName { get; set; }     
        public int SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; }
        // Navigation property for the one-to-many relationship with topics
        public virtual ICollection<Topic> Topics { get; set; }

        // Navigation property for the many-to-one relationship with Subject
   

    }
}
