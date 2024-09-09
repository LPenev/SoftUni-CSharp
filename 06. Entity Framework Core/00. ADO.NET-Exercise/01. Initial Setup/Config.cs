namespace _01._Initial_Setup
{
    internal static class Config
    {
        public const string Database = "MinionsDB";
        public const string Directory = "../../../data/";

        public const string ConnectionString =
            //    @"server=.;Integrated Security= True;Trusted_Connection=True";
            @"server=127.0.0.1;uid=sa;password=Password;Integrated Security= false";
    }
}
