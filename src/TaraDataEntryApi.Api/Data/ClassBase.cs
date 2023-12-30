using System.ComponentModel;

namespace TARA.DATAENTRY.API.Data
{
    public class ClassBase
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}