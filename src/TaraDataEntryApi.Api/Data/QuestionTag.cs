using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TARA.DATAENTRY.API.Data
{
    public class QuestionTag
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("QuestionCapturing")]
        public int QuestionID { get; set; }
        public  QuestionCapturing? QuestionCapturing { get; set; }
        [ForeignKey("Tag")]
        public int TagID { get; set; }
        public Tag? Tag { get; set; }
    }
}
