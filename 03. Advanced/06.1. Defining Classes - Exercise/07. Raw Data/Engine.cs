namespace RawData
{
    public class Engine
    {
		private int speed;
		private int power;

        public Engine(int engineSpeed, int enginePower)
		{
			this.Speed = engineSpeed;
			this.Power = enginePower;
		}

		public int Speed
        {
			get { return speed; }
			set { speed = value; }
		}
		public int Power
        {
			get { return power; }
			set { power = value; }
		}
	}
}
