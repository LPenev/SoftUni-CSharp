namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car()
        {
            tires = new Tire[4];
        }


        public Car(string model, int speed, int power, int weight, string cargoType, 
            double tire0Pressure, int tire0Age, double tire1Pressure, int tire1Age, 
            double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age)
        {
            this.Model = model;
            this.Engine = new(speed, power);
            this.Cargo = new(weight, cargoType);
            this.Tires = new Tire[4];
            this.Tires[0] = new(tire0Pressure, tire0Age);
            this.Tires[1] = new(tire1Pressure, tire1Age);
            this.Tires[2] = new(tire2Pressure, tire2Age);
            this.Tires[3] = new(tire3Pressure, tire3Age);
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }

    }
}
