using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=StudentSystem;User=demo;Password=Demo1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(s =>
            {
                s.Property(s => s.Name)
                    .HasMaxLength(100)
                    .IsUnicode(true)
                    .IsRequired(true);

                s.Property(s => s.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsRequired(false);

                s.Property(s => s.RegisteredOn)
                    .IsRequired(true);

                s.Property(s => s.Birthday)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Course>(c =>
            {
                c.Property(c => c.Name)
                    .HasMaxLength(80)
                    .IsUnicode(true);

                c.Property(c => c.Description)
                    .IsUnicode(true)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Resource>(r => 
            {
                r.Property(r => r.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                r.Property(r => r.Url)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(h => {
                h.Property(h => h.Content)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<StudentCourse>(sc =>
            {
                sc.HasKey(sc=> new {sc.StudentId, sc.CourseId});
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
