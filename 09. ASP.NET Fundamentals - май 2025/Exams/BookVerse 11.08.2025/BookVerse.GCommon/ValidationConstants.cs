namespace BookVerse.GCommon
{
    public static class ValidationConstants
    {
        public static class Book
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 80;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 250;

            public const int CoverImageUrlMaxLength = 2048;
         
            public const string PublishedOnDateTimeFormat = "dd-MM-yyyy";
        }

        public static class Genre
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 20;
        }

    }
}
