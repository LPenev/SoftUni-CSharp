namespace _03._News_CodeFirst.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<News> News { get; set; } = new List<News>();
    }
}
