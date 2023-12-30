using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TARA.DATAENTRY.API.Data
{
    public class QuestionCapturing:ClassBase
    {

        [Key]
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int LessonId { get; set; }
        public int TopicId { get; set; }
        public int QuestionTypeId { get; set; }
        [DefaultValue(false)]
        public bool IsVerified { get; set; }


        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }

        [ForeignKey("LessonId")]
        public virtual Lesson Lesson { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }
        public virtual ICollection<QuestionImage> QuestionImages { get; set; }
    }
}
