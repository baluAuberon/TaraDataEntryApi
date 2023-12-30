using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TARA.DATAENTRY.API.Data.Configuration;

namespace TARA.DATAENTRY.API.Data
{
    public class TARAAuthDbContext : IdentityDbContext<AppUser>
    {
        public TARAAuthDbContext(DbContextOptions<TARAAuthDbContext> options) : base(options)
        {

        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<QuestionCapturing> QuestionCapturings { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<QuestionImage> QuestionImages { get; set; }

   

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Class>().ToTable("Class");
            builder.Entity<Subject>().ToTable("Subject");
            builder.Entity<Lesson>().ToTable("Lesson");
            builder.Entity<Topic>().ToTable("Topic");
            builder.Entity<QuestionCapturing>().ToTable("QuestionCapturing");

            builder.Entity<QuestionImage>().ToTable("QuestionImage");
            builder.Entity<MCQOption>().ToTable("MCQOption");
            builder.Entity<Image>().ToTable("Image");
            builder.Entity<Skill>().ToTable("Skill");
            builder.Entity<Tag>().ToTable("Tag");



            builder.Entity<Class>()
                .HasMany(c => c.Subjects)
                .WithOne(s => s.Class)
                .HasForeignKey(s=>s.ClassId)
                .OnDelete(DeleteBehavior.Cascade);

          
            builder.Entity<Subject>()
                .HasMany(s => s.Lessons)
                .WithOne(l => l.Subject)
                .HasForeignKey(l => l.SubjectId)
               .OnDelete(DeleteBehavior.Cascade);

       



            
            builder.Entity<Lesson>()
                .HasMany(l => l.Topics)
                .WithOne(t=> t.Lesson)
                .HasForeignKey(t => t.LessonID)
                .OnDelete(DeleteBehavior.Cascade);



            // QuestionImage and Image Relationship
            builder.Entity<QuestionImage>()
             .HasOne(qi => qi.Image)
             .WithMany(i => i.QuestionImages)
             .HasForeignKey(qi => qi.ImageId)
             .OnDelete(DeleteBehavior.Cascade);


            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
