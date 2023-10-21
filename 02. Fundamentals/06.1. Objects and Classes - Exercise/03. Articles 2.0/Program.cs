namespace _11._03._Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                Article article = new Article(inputArray[0], inputArray[1], inputArray[2]);
                articles.Add(article);
            }

            foreach (var current in articles)
            {
                Console.WriteLine($"{current.Title} - {current.Content}: {current.Author}");
            }
        }
    }

    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}