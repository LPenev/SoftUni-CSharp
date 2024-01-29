namespace RawData
{
    public class Tire
    {
		private double tirePressure;
		private int tireAge;

        public Tire(double tirePressure, int tireAge)
        {
            this.TirePressure = tirePressure;
			this.TireAge = tireAge;
        }

		public int TireAge
        {
			get { return tireAge; }
			set { tireAge = value; }
		}

		public double TirePressure
        {
			get { return tirePressure; }
			set { tirePressure = value; }
		}
	}
}
