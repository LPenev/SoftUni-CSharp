﻿using BorderControl.Models.Intrefaces;

namespace BorderControl.Models
{
    public class Robot : IIdentitable
    {
        public Robot(string name, string id) 
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; private set; }
        public string Id { get; private set; }
    }
}
