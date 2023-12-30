using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TARA.DATAENTRY.API.Data
{
    public class QuestionImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int QuestionCapturingId { get; set; }

        [ForeignKey(nameof(QuestionCapturingId))]
        public virtual QuestionCapturing QuestionCapturing { get; set; }

        [Required]
        public int ImageId { get; set; }

        [ForeignKey(nameof(ImageId))]
        public virtual Image Image { get; set; }
    }
}
