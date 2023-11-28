namespace _3._02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();
            int shoots = 0;

            while (input != "end" && input != "End" && input != "END")
            {
                int shoot = int.Parse(input);
                if (shoot < 0 || shoot >= targets.Length)
                {

                }
                else if (targets[shoot] != -1)
                {
                    int currentShoot = targets[shoot];
                    targets[shoot] = -1;
                    shoots++;

                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] <= currentShoot && targets[i] != -1)
                        {
                            targets[i] += currentShoot;
                        }
                        else if (targets[i] > currentShoot && targets[i] != -1)
                        {
                            targets[i] -= currentShoot;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Shot targets: {0} -> {1}", shoots, string.Join(" ", targets));
        }
    }
}