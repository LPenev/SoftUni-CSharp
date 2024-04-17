﻿namespace TheContentDepartment.Models
{
    public class Workshop : Resource
    {
        private const int Priority = 2;

        public Workshop(string name, string creator) : base(name, creator, Priority)
        {
        }
    }
}
