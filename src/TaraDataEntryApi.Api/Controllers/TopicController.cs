using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TARA.DATAENTRY.API.Data;
using TARA.DATAENTRY.API.Models.Masters;

namespace TARA.DATAENTRY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly TARAAuthDbContext _context;
        private readonly IMapper mapper;

        public TopicController(TARAAuthDbContext context,IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Topic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetTopics()
        {
            return await _context.Topics.ToListAsync();
        }

        // GET: api/Topic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Topic>> GetTopic(int id)
        {
            var topic = await _context.Topics.FindAsync(id);

            if (topic == null)
            {
                return NotFound();
            }

            return topic;
        }
        // GET: api/LessonbySubjectID/5
        [HttpGet("gettopicbylessonid{id}")]
        public async Task<ActionResult<IEnumerable<ClassResponseDto>>> GettopicbyLessonsID(int id)
        {
            var topics = await _context.Topics.Where(s => s.LessonID == id).ToListAsync();
            var resultlist = mapper.Map<List<ClassResponseDto>>(topics);
            if (topics == null)
            {
                return NotFound();
            }

            return resultlist;
        }


        // POST: api/Topic
        [HttpPost]
        public async Task<IActionResult> PostTopic(TopicDto topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentdate = DateTime.UtcNow;
            // Get the username from the JWT token
            string createdBy = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var newTopic = mapper.Map<Topic>(topic);
            newTopic.CreatedBy = createdBy;
            newTopic.ModifiedDate = currentdate;
            newTopic.IsDeleted = false;
            newTopic.CreatedDate = currentdate;
            newTopic.ModifiedBy = createdBy;


            _context.Topics.Add(newTopic);
            await _context.SaveChangesAsync();

            return Ok("Topic Created Successfilly");
        }

        // PUT: api/Topic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(int id, Topic topic)
        {
            if (id != topic.Id)
            {
                return BadRequest();
            }

            _context.Entry(topic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Topic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.Id == id);
        }
    }
}
