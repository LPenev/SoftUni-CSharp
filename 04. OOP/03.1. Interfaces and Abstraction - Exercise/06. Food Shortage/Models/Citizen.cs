﻿using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Citizen : IIdentitable, IBirthable, IBuyer
    {
        private const int DefaultFoodBuy = 10;
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthday { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += DefaultFoodBuy;
        }
    }
}
