namespace _03._News_CodeFirst.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public virtual News News { get; set; }

        public string Author { get; set; }
        public string Content { get; set; }
    }
}
