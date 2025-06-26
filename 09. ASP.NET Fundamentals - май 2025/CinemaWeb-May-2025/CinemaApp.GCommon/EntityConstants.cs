namespace CinemaApp.GCommon;

public class EntityConstants
{
    public static class Movie
    {
        public const int TitleMaxLength = 100;
        public const string TitleRequiredErrorMessage = "Title is required";
        public const string TitleMaxLengthErrorMessage = "Title cannot exceed 100 charcters.";
        public const int GenreMaxLength = 50;
        public const string GenreRequiredErrorMessage = "Title is required";
        public const string GenreMaxLengthErrorMessage = "Genre cannot exceed 50 charcters.";
        public const string ReleaseDateRequiredErrorMessage = "Release date is required.";
        public const int DirectorMaxLength = 100;
        public const string DirectorMaxLengthErrorMessage = "Director cannot exceed 100 charcters.";
        public const string DirectorRequiredErrorMessage = "Title is required";
        public const int DescriptionMaxLength = 1000;
        public const string DescriptionMaxLengthErrorMessage = "Description cannot exceed 1000 charcters.";
        public const string DescriptionRequiredErrorMessage = "Title is required";
        public const int DurationMin = 1;
        public const int DurationMax = 300;
        public const string DurationRequiredErrorMessage = "Title is required";
    }
}
