using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TARA.DATAENTRY.API.Data
{
    public class MCQOption:ClassBase
    {
        [Key]
        public int Id { get; set; }
     
        [Required]
        public string OptionName { get; set; }

        [Required]
        [ForeignKey("QuestionCapturing")]
        public int QuestionCapturingId { get; set; }
        public QuestionCapturing QuestionCapturing { get; set; }

        [DefaultValue(false)]
        public bool IsAnswer { get; set; }
    }
}
