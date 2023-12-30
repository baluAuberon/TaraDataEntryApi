using TARA.DATAENTRY.API.Data;

namespace TARA.DATAENTRY.API.Models.Masters
{
    public class SubjectResponseDto: ClassBase
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int ClassId { get; set; }    
    }

}
