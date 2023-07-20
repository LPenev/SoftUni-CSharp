namespace _05._Movie_Ratings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMovies = int.Parse(Console.ReadLine());

            // init vars
            string bestMovieName = string.Empty;
            double bestMovieRating = double.MinValue;

            string worstMovieName = string.Empty;
            double worstMovieRating = double.MaxValue;

            double sumOfRating = 0;

            // calc
            for (int i = 0; i < numberOfMovies; i++)
            {
                string nameOfMovie = Console.ReadLine().Trim();
                double ratingOfMovie = double.Parse(Console.ReadLine());

                if (ratingOfMovie > bestMovieRating)
                {
                    bestMovieRating = ratingOfMovie;
                    bestMovieName = nameOfMovie;
                }
                else if(ratingOfMovie < worstMovieRating)
                {
                    worstMovieRating = ratingOfMovie;
                    worstMovieName = nameOfMovie;
                }

                sumOfRating += ratingOfMovie;
            }

            double avgRating = sumOfRating / numberOfMovies;

            // print result
            Console.WriteLine($"{bestMovieName} is with highest rating: {bestMovieRating:f1}");
            Console.WriteLine($"{worstMovieName} is with lowest rating: {worstMovieRating:f1}");
            Console.WriteLine($"Average rating: {avgRating:f1}");
        }
    }
}
