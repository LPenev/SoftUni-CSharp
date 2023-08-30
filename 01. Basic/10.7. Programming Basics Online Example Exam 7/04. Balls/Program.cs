namespace _04._Balls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfBalls = int.Parse(Console.ReadLine());

            // init vars 
            int allPointsCollected = 0;
            int numberOfRedBalls = 0;
            int numberOfOrangeBalls = 0;
            int numberOfYellowBalls = 0;
            int numberOfWhiteBalls = 0;
            int numberOfBlackBalls = 0;
            int otherColorsPicked = 0;

            while (numberOfBalls > 0)
            {
                string currentBall = Console.ReadLine().Trim();
                
                switch (currentBall)
                {
                    case "red":
                        allPointsCollected += 5;
                        numberOfRedBalls++;
                        break;

                    case "orange":
                        allPointsCollected += 10;
                        numberOfOrangeBalls++;
                        break;

                    case "yellow":
                        allPointsCollected += 15;
                        numberOfYellowBalls++;
                        break;

                    case "white":
                        allPointsCollected += 20;
                        numberOfWhiteBalls++;
                        break;

                    case "black":
                        allPointsCollected /= 2;
                        numberOfBlackBalls++;
                        break;

                    default:
                        otherColorsPicked++;
                        break;
                }

                numberOfBalls--;
            }

            // output
            Console.WriteLine($"Total points: {allPointsCollected}");
            Console.WriteLine($"Red balls: {numberOfRedBalls}");
            Console.WriteLine($"Orange balls: {numberOfOrangeBalls}");
            Console.WriteLine($"Yellow balls: {numberOfYellowBalls}");
            Console.WriteLine($"White balls: {numberOfWhiteBalls}");
            Console.WriteLine($"Other colors picked: {otherColorsPicked}");
            Console.WriteLine($"Divides from black balls: {numberOfBlackBalls}");
        }
    }
}
