namespace RawData
{
    public class Cargo
    {
		private string cargoType;
		private int cargoWeight;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoType = cargoType;
			this.CargoWeight = cargoWeight;
        }

        public int CargoWeight
        {
			get { return cargoWeight; }
			set { cargoWeight = value; }
		}

		public string CargoType
        {
			get { return cargoType; }
			set { cargoType = value; }
		}
	}
}
