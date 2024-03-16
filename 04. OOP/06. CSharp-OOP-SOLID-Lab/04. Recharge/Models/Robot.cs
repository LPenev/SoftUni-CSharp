using System;

namespace Models
{
    public class Robot : Worker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity) : base(id)
        {
            this.capacity = capacity;
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public int CurrentPower
        {
            get { return currentPower; }
            set { currentPower = value; }
        }

        public void Recharge()
        {
            this.CurrentPower = this.capacity;
        }

        public void Work(int hours)
        {
            if (hours > currentPower)
            {
                hours = currentPower;
            }

            base.Work(hours);
            currentPower -= hours;
        }
    }
}