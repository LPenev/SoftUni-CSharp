using System.ComponentModel.DataAnnotations;

namespace _03._News_CodeFirst.Models
{
    public class News
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
