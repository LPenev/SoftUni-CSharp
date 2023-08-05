using System;

namespace favoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfFilm = Console.ReadLine();
            int counterFilms = 0;
            int favoriteFilmPoints = 0;
            string favoriteFilmName = "";

            while (nameOfFilm != "STOP")
            {
                int sumPoints = 0;
                counterFilms++;
                if(counterFilms == 7) { Console.WriteLine("The limit is reached."); break; }
                int lengthNameOfFim = nameOfFilm.Length;
                for(int i = 0; i < lengthNameOfFim; i++)
                {
                    char ch = nameOfFilm[i];
                    sumPoints += (int)ch;
                    if((int)ch < 91 && (int)ch > 64) { sumPoints -= nameOfFilm.Length; } 
                    else if((int)ch < 123 && (int)ch > 96) { sumPoints -= (nameOfFilm.Length * 2); }
                }
                if(sumPoints > favoriteFilmPoints)
                {
                    favoriteFilmPoints = sumPoints;
                    favoriteFilmName = nameOfFilm;
                }
                nameOfFilm = Console.ReadLine() ;
            }
            
            Console.WriteLine($"The best movie for you is {favoriteFilmName} with {favoriteFilmPoints} ASCII sum.");
        }
    }
}