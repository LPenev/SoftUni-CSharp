namespace CinemaApp.Data.Common
{
    public static class EntityConstants
    {
        public static class Movie
        {
            /// <summary>
            /// Movie Title should be at least 2 characters and up to 100 characters.
            /// </summary>
            public const int TitleMinLength = 2;
            public const string TitleMinLengthMessage = "Title must be at least 2 characters.";

            /// <summary>
            /// Movie Title should be able to store text with length up to 100 characters.
            /// </summary>
            public const int TitleMaxLength = 100;
            public const string TitleMaxLengthErrorMessage = "Title cannot exceed 100 charcters.";
            
            public const string TitleRequiredErrorMessage = "Title is required";

            /// <summary>
            /// Genre must be at least 3 characters.
            /// </summary>
            public const int GenreMinLength = 3;
            public const string GenreMinLengthMessage = "Genre must be at least 3 characters.";

            /// <summary>
            /// Movie Genre should be able to store text with length up to 50 characters.
            /// </summary>
            public const int GenreMaxLength = 50;
            public const string GenreMaxLengthErrorMessage = "Genre cannot exceed 50 charcters.";

            public const string GenreRequiredErrorMessage = "Title is required";

            /// <summary>
            /// Director name must be at least 2 characters.
            /// </summary>
            public const int DirectorNameMinLength = 2;
            public const string DirectorNameMinLengthMessage = "Director name must be at least 2 characters.";

            /// <summary>
            /// Movie Director should be able to store text with length up to 100 characters.
            /// </summary>
            public const int DirectorNameMaxLength = 100;
            public const string DirectorMaxLengthErrorMessage = "Director cannot exceed 100 charcters.";
            
            public const string DirectorRequiredErrorMessage = "Title is required";

            /// <summary>
            /// Movie Description must be at least 10 characters.
            /// </summary>
            public const int DescriptionMinLength = 10;
            public const string DescriptionMinLengthMessage = "Description must be at least 10 characters.";

            /// <summary>
            /// Movie Description should be able to store text with length up to 1000 characters.
            /// </summary>
            public const int DescriptionMaxLength = 1000;
            public const string DescriptionMaxLengthErrorMessage = "Description cannot exceed 1000 charcters.";
            
            public const string DescriptionRequiredErrorMessage = "Title is required";
            
            /// <summary>
            /// Movie Duration should be between 1 and 300 minutes.
            /// </summary>
            public const int DurationMin = 1;

            /// <summary>
            /// Movie Duration should be between 1 and 300 minutes.
            /// </summary>
            public const int DurationMax = 300;
            public const string DurationRangeMessage = "Duration must be between 1 and 300 minutes.";
            public const string DurationRequiredErrorMessage = "Title is required";

            /// <summary>
            /// Maximum allowed length for image URL.
            /// </summary>
            public const int ImageUrlMaxLength = 2048;
            public const string ImageUrlMaxLengthMessage = "Image URL cannot exceed 2048 characters.";



            public const string ReleaseDateRequiredErrorMessage = "Release date is required.";
            public const string ReleaseDateFormat = "yyyy-MM-dd";
            public const string WebDateFormat = "dd/MM/yyyy";
        }

        public static class Cinema
        {
            /// <summary>
            /// Cinema Name must be at least 2 characters.
            /// </summary>
            public const int NameMinLength = 2;

            /// <summary>
            /// Cinema Name should be able to store text with length up to 80 characters.
            /// </summary>
            public const int NameMaxLength = 80;

            /// <summary>
            /// Cinema Location must be at least 2 characters.
            /// </summary>
            public const int LocationMinLength = 2;

            /// <summary>
            /// Cinema Location should be able to store text with length up to 50 characters.
            /// </summary>
            public const int LocationMaxLength = 50;
        }

        public static class CinemaMovie
        {
            public const int AvailableTicketsDefaultValue = 0;
            public const int ShowtimeMaxLength = 5;
            public const string ShowtimeFormat = "{hh}:{mm}";
        }

        public static class Ticket
        {
            public const string PriceSqlType = "decimal(18, 6)";
        }
    }
}