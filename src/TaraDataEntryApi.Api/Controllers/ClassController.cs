using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text.Json;
using TARA.DATAENTRY.API.Data;
using TARA.DATAENTRY.API.Exceptions;
using TARA.DATAENTRY.API.Models.Masters;

namespace TARA.DATAENTRY.API.Controllers
{
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ClassController : ControllerBase
    {
        private readonly TARAAuthDbContext context;
        private readonly IMapper mapper;

        public ClassController(TARAAuthDbContext context, IHttpContextAccessor httpContextAccessor,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/getclasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassResponseDto>>> GetClasses()
        {
             var classes= await context.Classes
                .Where(c => !c.IsDeleted)
                .ToListAsync();
            var resultlist=mapper.Map<List<ClassResponseDto>>(classes);
          
 
            return Ok(resultlist);
        }
        // GET: api/getclasses
        [HttpGet("getclassesdetails")]
        public async Task<ActionResult<IEnumerable<Class>>> GetClassesDetails()
        {
            var classes = await context.Classes
     .Where(c => !c.IsDeleted)
      // Include topics related to each lesson
     .ToListAsync();


            var jsonSettings = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var jsonString = JsonSerializer.Serialize(classes, jsonSettings);

            // Convert the JSON string back to objects
            var result = JsonSerializer.Deserialize<List<Class>>(jsonString, jsonSettings);

            return Ok(result);
        }

        // GET: api/classes/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassResponseDto>> GetClassById(int id)
        {
            var classEntity = await context.Classes.FindAsync(id);


            if (classEntity == null || classEntity.IsDeleted)
            {
                throw new NotFoundException(nameof(GetClassById), id);
            }
            var resultlist = mapper.Map<ClassResponseDto>(classEntity);
            return resultlist;
        }


        // GET: api/classes/1
        [HttpGet("getclassdetailsbyid/{id}")]
        public async Task<ActionResult<Class>> GetClassDetailsById(int id)
        {
            var classEntity = await context.Classes.FindAsync(id);

            if (classEntity == null || classEntity.IsDeleted)
            {
                throw new NotFoundException(nameof(GetClassDetailsById), id);
            }

            return classEntity;
        }

        // POST: api/classes
        [HttpPost]
        
        public async Task<ActionResult<ClassResponseDto>> CreateClass([FromBody] ClassDto classDto)
        {//
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentdate = DateTime.UtcNow;
            // Get the username from the JWT token
            string createdBy = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var newClass = mapper.Map<Class>(classDto);
            newClass.CreatedBy = createdBy;
            newClass.ModifiedDate= currentdate;
            newClass.IsDeleted = false;
            newClass.CreatedDate = currentdate;
            newClass.ModifiedBy = createdBy;

            context.Classes.Add(newClass);
            await context.SaveChangesAsync();
            var classResponse = mapper.Map<ClassResponseDto>(newClass);
            return Ok(classResponse);
        }

        // PUT: api/classes/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, [FromBody] ClassDto classDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classEntity = await context.Classes.FindAsync(id);

            if (classEntity == null || classEntity.IsDeleted)
            {
                throw new NotFoundException(nameof(UpdateClass), id);
               
            }
            // Get the username from the JWT token
           
            string modifiedBy = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            classEntity.ClassName = classDto.ClassName;
            classEntity.ModifiedBy = modifiedBy;
            classEntity.ModifiedDate = DateTime.UtcNow;
            // Update additional properties as needed

            context.Entry(classEntity).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/classes/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var classEntity = await context.Classes.FindAsync(id);

            if (classEntity == null || classEntity.IsDeleted)
            {
                return NotFound();
            }

            classEntity.IsDeleted = true;

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
