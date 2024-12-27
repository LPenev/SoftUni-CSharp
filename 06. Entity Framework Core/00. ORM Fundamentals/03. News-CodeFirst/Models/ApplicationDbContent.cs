using Microsoft.EntityFrameworkCore;

namespace _03._News_CodeFirst.Models
{
    public class ApplicationDbContent : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;User Id=demo;Password=Demo1234;Initial Catalog=NewsCodeFirst;Persist Security Info=True;Encrypt=False;");
        }
    }
}
