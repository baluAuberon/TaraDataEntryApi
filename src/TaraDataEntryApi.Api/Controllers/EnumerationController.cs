using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TARA.DATAENTRY.API.Data;

namespace TARA.DATAENTRY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumerationController : ControllerBase
    {
        [HttpGet("getimagetypes")]
        public async Task<ActionResult<IEnumerable<Object>>> GetImageType()
        {
           return Enum.GetValues(typeof(ImageType))
                .Cast<ImageType>()
                .Select(e => new { ID = (int)e, Name = e.ToString() })
                            .ToList(); 
        }

        [HttpGet("getquestiontypes")]
        public async Task<ActionResult<IEnumerable<Object>>> GetQuestionType()
        {
            return Enum.GetValues(typeof(QuestionType))
                 .Cast<QuestionType>()
                 .Select(e => new { ID = (int)e, Name = e.ToString() })
                             .ToList();
        }
    }
}