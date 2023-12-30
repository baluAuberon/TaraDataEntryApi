using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TARA.DATAENTRY.API.Data
{
    public class Topic : ClassBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TopicName { get; set; }

      
        public int LessonID { get; set; }

        [ForeignKey(nameof(LessonID))]
        public virtual Lesson Lesson { get; set; }
    }
}
