using System;

namespace _11._01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = 
            { 
                "Excellent product.",
                "Such a great product.", "I always use that product.", "Best product of its category.",
                "Exceptional product.", "I can't live without this product."
            };

            string[] events = 
            {
                "Now I feel good.",
                "I have succeeded with this product.", "Makes miracles.I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

            int inputCount = int.Parse(Console.ReadLine());

            Random random = new Random();

            for (int i = 0; i < inputCount; i++)
            {
                string phrase = phrases[random.Next(phrases.Length-1)];
                string event1 = events[random.Next(events.Length-1)];
                string author = authors[random.Next(authors.Length-1)];
                string city = cities[random.Next(cities.Length-1)];

                Console.WriteLine($"{phrase} {event1} {author} – {city}.");
            }
        }
    }
}