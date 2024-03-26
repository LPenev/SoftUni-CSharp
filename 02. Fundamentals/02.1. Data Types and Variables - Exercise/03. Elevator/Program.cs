int numberOfPeople = int.Parse(Console.ReadLine());
int capacityOfElevator = int.Parse(Console.ReadLine());

// calculations
int result = (int)Math.Ceiling( (double)numberOfPeople / capacityOfElevator);
Console.WriteLine(result);
