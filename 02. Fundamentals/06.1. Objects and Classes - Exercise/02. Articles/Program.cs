using System.ComponentModel.DataAnnotations;

namespace _11._02._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // var articles = new List<Article>();

            string[] inputArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Article article = new Article(inputArray[0], inputArray[1], inputArray[2]);

           // article.Title = inputArray[0];
           // article.Content = inputArray[1];
           // article.Author = inputArray[2];

           // articles.Add(article);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                switch (command[0])
                {
                    case "Edit":
                        article.Edit(command[1]);
                        break;

                    case "ChangeAuthor":
                        article.ChangeAuthor(command[1]);
                        break;

                    case "Rename":
                        article.Rename(command[1]);
                        break;
                }
            }

            Console.WriteLine(article.ToString());
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
        public Article()
        {

        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string content)
        {
            this.Content = content;
        }

        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }

        public void Rename(string title)
        {
            this.Title = title;
        }

        public override string  ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}