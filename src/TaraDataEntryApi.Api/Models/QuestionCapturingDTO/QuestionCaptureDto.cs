using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TARA.DATAENTRY.API.Data;

namespace TARA.DATAENTRY.API.Models.QuestionCapturingDTO
{
    public class QuestionCaptureDto
    {



        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int LessonId { get; set; }
        public int TopicId { get; set; }
        public int QuestionTypeId { get; set; }
       
        public ImageDto? Description { get; set; }

        public List<ImageDto>? AdditionalImages { get; set; }

        public List<ImageDto>? MCQOptions { get; set; }

        public ImageDto? AnswerMain { get; set; }

        public List<ImageDto>? AdditionalAnswers { get; set; }


        public bool IsVerified { get; set; }
    }
}
