using System.ComponentModel.DataAnnotations;

namespace TARA.DATAENTRY.API.Data
{
    public class Tag:ClassBase
    {
        [Key]
        public int Id { get; set; }
        public string TagName { get; set; }
        public Guid? TagId { get; set; }
    }
}
