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
    public class LeasonController : ControllerBase
    {
        private readonly TARAAuthDbContext context;
        private readonly IMapper mapper;

        public LeasonController(TARAAuthDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        // GET: api/Lesson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lesson>>> GetLessons()
        {
            return await context.Lessons.ToListAsync();
        }

        // GET: api/Lesson/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> GetLesson(int id)
        {
            var lesson = await context.Lessons.FindAsync(id);

            if (lesson == null)
            {
                return NotFound();
            }

            return lesson;
        }
        // GET: api/LessonbySubjectID/5
        [HttpGet("getleasonsbysubjectid/{id}")]
        public async Task<ActionResult<IEnumerable<ClassResponseDto>>> GetLessonsBySubjectID(int id)
        {
            var subjects = await context.Lessons.Where(s => s.SubjectId == id).ToListAsync();
            var resultlist = mapper.Map<List<ClassResponseDto>>(subjects);
            if (subjects == null)
            {
                return NotFound();
            }

            return resultlist;
        }

        // POST: api/Lesson
        [HttpPost]
         public async Task<IActionResult> PostLesson(LessonDto lesson)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentdate = DateTime.UtcNow;
            // Get the username from the JWT token
            string createdBy = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var newLeson = mapper.Map<Lesson>(lesson);
            newLeson.CreatedBy = createdBy;
            newLeson.ModifiedDate = currentdate;
            newLeson.IsDeleted = false;
            newLeson.CreatedDate = currentdate;
            newLeson.ModifiedBy = createdBy;


            context.Lessons.Add(newLeson);
            await context.SaveChangesAsync();
           
            return Ok("Lesson Created Successfilly");
        }

        // PUT: api/Lesson/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLesson(int id, Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return BadRequest();
            }

            context.Entry(lesson).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
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

        // DELETE: api/Lesson/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var lesson = await context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            context.Lessons.Remove(lesson);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessonExists(int id)
        {
            return context.Lessons.Any(e => e.Id == id);
        }
    }
}
