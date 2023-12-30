using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class SubjectController : ControllerBase
    {
        private readonly TARAAuthDbContext context;
        private readonly IMapper mapper;

        public SubjectController(TARAAuthDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        // GET: api/Subject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            return await context.Subjects.ToListAsync();
        }

        // GET: api/Subject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }
        // GET: api/Subject/5
        [HttpGet("getsubjecstbyclassid/{id}")]
        public async Task<ActionResult<IEnumerable<ClassResponseDto>>> GetSubjecstByClassId(int id)
        {
            var subjects = await context.Subjects.Where(s=>s.ClassId==id).ToListAsync();
            var resultlist = mapper.Map<List<ClassResponseDto>>(subjects);
            if (subjects == null)
            {
                return NotFound();
            }

            return resultlist;
        }

        // POST: api/Subject
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<SubjectResponseDto>> PostSubject(SubjectDto subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentdate = DateTime.UtcNow;
            // Get the username from the JWT token
            string createdBy = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var newSubject = mapper.Map<Subject>(subject);
            newSubject.CreatedBy = createdBy;
            newSubject.ModifiedDate = currentdate;
            newSubject.IsDeleted = false;
            newSubject.CreatedDate = currentdate;
            newSubject.ModifiedBy = createdBy;


            context.Subjects.Add(newSubject);
            await context.SaveChangesAsync();
            var response = mapper.Map<SubjectResponseDto>(newSubject);
            return Ok(response);

        }

        // PUT: api/Subject/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            context.Entry(subject).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
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

        // DELETE: api/Subject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            context.Subjects.Remove(subject);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectExists(int id)
        {
            return context.Subjects.Any(e => e.Id == id);
        }
    }
}
