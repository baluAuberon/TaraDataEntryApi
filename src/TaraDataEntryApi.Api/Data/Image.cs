using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TARA.DATAENTRY.API.Data
{
    public class Image
    {
        public Image()
        {
            QuestionImages = new HashSet<QuestionImage>();
        }

        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public int ImageTypeID { get; set; }

        public virtual ICollection<QuestionImage> QuestionImages { get; set; }
    }
}
