﻿namespace _03._Minion_Names
{
    internal static class Config
    {
        public const string Database = "MinionsDB";
        public const string Directory = "../../../data/";

        public const string ConnectionString =
            //    @"server=.;Database=MinionsDB;Integrated Security= True;Trusted_Connection=True";
            @"server=127.0.0.1;Database=MinionsDB;uid=sa;password=Password;Integrated Security= false";

    }
}
