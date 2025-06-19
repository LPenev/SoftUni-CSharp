namespace Horizons.GCommon
{
    public static class ValidationConstants
    {
        public static class Destination
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;

            public const int DescriltionMinLength = 10;
            public const int DescriptionMaxLength = 250;

            public const int PublishedOnLength = 10;
            public const string PublishedOnDateFormat = "dd-MM-yyyy";
        }

        public static class Terrain
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 20;
        }
    }
}
