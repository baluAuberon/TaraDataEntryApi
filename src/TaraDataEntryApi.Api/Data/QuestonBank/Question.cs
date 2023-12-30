using System.ComponentModel.DataAnnotations;

namespace TARA.DATAENTRY.API.Data.QuestonBank
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int LessonId { get; set; }
        public int TopicId { get; set; }
        public int QuestionTypeId { get; set; }
    }
}
