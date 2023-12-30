using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TARA.DATAENTRY.API.Data;
using TARA.DATAENTRY.API.Models.QuestionCapturingDTO;

namespace TARA.DATAENTRY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionCaptureController : ControllerBase
    {
        private readonly TARAAuthDbContext context;
        private readonly IMapper mapper;

        public QuestionCaptureController(TARAAuthDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/QuestionCapturing
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetQuestionCapturings()
        {
            return await context.QuestionCapturings
                .Where(q=>q.IsDeleted == false &&q.IsVerified==false)
    .Join(
                context.Classes,
                q => q.ClassId,
                c => c.Id,
                (q, c) => new { QuestionCapturing = q, Class = c })
    .Join(
                context.Subjects,
                jc => jc.QuestionCapturing.SubjectId,
                s => s.Id,
                (jc, s) => new { jc.QuestionCapturing, jc.Class, Subject = s })
    .Join(
                context.Lessons,
                jcs => jcs.QuestionCapturing.LessonId,
                l => l.Id,
                (jcs, l) => new { jcs.QuestionCapturing, jcs.Class, jcs.Subject, Lesson = l })
    .Join(
                context.Topics,
                jcsl => jcsl.QuestionCapturing.TopicId,
                t => t.Id,
                (jcsl, t) => new
                {
                    QuestionId = jcsl.QuestionCapturing.Id,
                    ClassName = jcsl.Class.ClassName,
                    SubjectName = jcsl.Subject.SubjectName,
                    LessonName = jcsl.Lesson.LessonName,
                    TopicName = t.TopicName
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionCaptureDto>> GetQuestionCapturing(int id)
        {
            var questionCapturing = await context.QuestionCapturings
                .Where(q => !q.IsDeleted && !q.IsVerified && q.Id == id)
                .FirstOrDefaultAsync();

            if (questionCapturing == null)
            {
                return NotFound();
            }

            var question = mapper.Map<QuestionCaptureDto>(questionCapturing);

            var images = await context.QuestionImages
                .Where(qi => qi.QuestionCapturingId == questionCapturing.Id)
                .Select(x => x.ImageId)
                .ToListAsync();

            if (images != null && images.Any())
            {
                var imagelist = await context.Images
                    .Where(i => images.Contains(i.Id))
                    .ToListAsync();

                question.AdditionalImages = imagelist
                    .Where(image => image.ImageTypeID == (int)ImageType.QuestionAdditional)
                    .Select(image => new ImageDto
                    {
                        ImageTypeID = image.ImageTypeID,
                        ImagePath = image.ImagePath
                    })
                    .ToList();

                question.MCQOptions = imagelist
                    .Where(image => image.ImageTypeID == (int)ImageType.MCQOptions)
                    .Select(image => new ImageDto
                    {
                        ImageTypeID = image.ImageTypeID,
                        ImagePath = image.ImagePath
                    })
                    .ToList();

                var mainImage = imagelist
                    .FirstOrDefault(image => image.ImageTypeID == (int)ImageType.QuestionMAIN);

                if (mainImage != null)
                {
                    question.Description = new ImageDto
                    {
                        ImageTypeID = mainImage.ImageTypeID,
                        ImagePath = mainImage.ImagePath
                    };
                }
            }

            return question;
        }


        // POST: api/QuestionCapturing
        [HttpPost]
        public async Task<ActionResult> PostQuestionCapturing(QuestionCaptureDto questionCapturing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentdate = DateTime.UtcNow;

            // Get the username from the JWT token
            string? createdBy = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var newQuestion = new QuestionCapturing
            {
                ClassId = questionCapturing.ClassId,
                SubjectId = questionCapturing.SubjectId,
                LessonId = questionCapturing.LessonId,
                TopicId = questionCapturing.TopicId,
                QuestionTypeId = questionCapturing.QuestionTypeId,
                CreatedBy = createdBy,
                ModifiedBy = createdBy,
                CreatedDate = currentdate,
                ModifiedDate = currentdate,
                IsDeleted = false
            };

            context.QuestionCapturings.Add(newQuestion);
            await context.SaveChangesAsync();

            int questionId = newQuestion.Id;

            // Save the description image
            var descriptionImage = mapper.Map<Image>(questionCapturing.Description);
            context.Images.Add(descriptionImage);
            await context.SaveChangesAsync();

            int descriptionImageId = descriptionImage.Id;

            // Save the QuestionImage for the description image
            context.QuestionImages.Add(new QuestionImage
            {
                QuestionCapturingId = questionId,
                ImageId = descriptionImageId
            });
            await context.SaveChangesAsync();

            // Save additional images
            if (questionCapturing.AdditionalImages != null && questionCapturing.AdditionalImages.Any())
            {
                var additionalImages = questionCapturing.AdditionalImages.Select(
                    imageDto => mapper.Map<Image>(imageDto)).ToList();
                context.Images.AddRange(additionalImages);
                await context.SaveChangesAsync();

                // Save QuestionImages for additional images
                var questionImages = additionalImages.Select(image =>
                    new QuestionImage
                    {
                        QuestionCapturingId = questionId,
                        ImageId = image.Id
                    }).ToList();

                context.QuestionImages.AddRange(questionImages);
                await context.SaveChangesAsync();
            }
            if (questionCapturing.QuestionTypeId == 0)
            {
                if (questionCapturing.MCQOptions != null && questionCapturing.MCQOptions.Any())
                {
                    var mcqOptionImages = questionCapturing.MCQOptions.Select(
                        imageDto => mapper.Map<Image>(imageDto)).ToList();
                    context.Images.AddRange(mcqOptionImages);
                    await context.SaveChangesAsync();

                    // Save QuestionImages for additional images
                    var questionImages = mcqOptionImages.Select(image =>
                        new QuestionImage
                        {
                            QuestionCapturingId = questionId,
                            ImageId = image.Id
                        }).ToList();

                    context.QuestionImages.AddRange(questionImages);
                    await context.SaveChangesAsync();
                }

            }
            // Save the answer image
            var answerMainImage = mapper.Map<Image>(questionCapturing.AnswerMain);
            context.Images.Add(answerMainImage);
            await context.SaveChangesAsync();

            // Save additional answer images
            if (questionCapturing.AdditionalAnswers != null && questionCapturing.AdditionalAnswers.Any())
            {
                var additionalAnswerImage = questionCapturing.AdditionalAnswers.Select(
                    imageDto => mapper.Map<Image>(imageDto)).ToList();
                context.Images.AddRange(additionalAnswerImage);
                await context.SaveChangesAsync();

                // Save QuestionImages for additional images
                var questionImages = additionalAnswerImage.Select(image =>
                    new QuestionImage
                    {
                        QuestionCapturingId = questionId,
                        ImageId = image.Id
                    }).ToList();

                context.QuestionImages.AddRange(questionImages);
                await context.SaveChangesAsync();
            }

            return Ok("Question Uploaded Successfully");
        }


        // PUT: api/QuestionCapturing/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionCapturing(int id, QuestionCapturing questionCapturing)
        {
            if (id != questionCapturing.Id)
            {
                return BadRequest();
            }

            context.Entry(questionCapturing).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionCapturingExists(id))
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

        // DELETE: api/QuestionCapturing/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionCapturing(int id)
        {
            var questionCapturing = await context.QuestionCapturings.FindAsync(id);
            if (questionCapturing == null)
            {
                return NotFound();
            }

            context.QuestionCapturings.Remove(questionCapturing);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionCapturingExists(int id)
        {
            return context.QuestionCapturings.Any(e => e.Id == id);
        }


    }
}
