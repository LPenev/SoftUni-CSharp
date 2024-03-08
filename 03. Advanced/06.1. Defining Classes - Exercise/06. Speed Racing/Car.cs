namespace SpeedRacing
{
    public class Car
    {
		private string model;
		private double fuelAmount;
		private double fuelConsumptionPerKilometer;
		private double travelledDistance;
		private List<Car> cars;

		public Car()
		{
			cars = new List<Car>();
		}

		public Car(string carModel, double carFuelAmount, double carFuelConsumptionPerKilometer )
		{
			this.Model = carModel;
			this.FuelAmount = carFuelAmount;
			this.FuelConsumptionPerKilometer = carFuelConsumptionPerKilometer;
			this.TravelledDistance = 0.0;
		}

        public string Model
		{
			get { return model; }
			set { model = value; }
		}
		public double FuelAmount
		{
			get { return fuelAmount; }
			set { fuelAmount = value; }
		}
		public double FuelConsumptionPerKilometer
		{
			get { return fuelConsumptionPerKilometer;}
			set { fuelConsumptionPerKilometer = value; }
		}
		public double TravelledDistance
		{
			get { return travelledDistance; }
			set { travelledDistance = value; }
		}
        public List<Car> Cars { get; set; }

		public void AddCar(Car car)
		{
			cars.Add(car);
		}

        public void Drive(string carModel, int amountOfKm)
		{
			var selectedCar = cars.FirstOrDefault(x=>x.model == carModel);
			var requidedFuel = selectedCar.FuelConsumptionPerKilometer * amountOfKm;


            if (selectedCar.fuelAmount >= requidedFuel)
			{
				selectedCar.travelledDistance += amountOfKm;
				selectedCar.fuelAmount -= requidedFuel;
			}
			else
			{
                Console.WriteLine("Insufficient fuel for the drive");
            }
		}

		public void PrintCars()
		{
			foreach (var car in cars)
			{
                Console.WriteLine($"{car.model} {car.fuelAmount:f2} {car.TravelledDistance}");
            }
		}
    }
}
