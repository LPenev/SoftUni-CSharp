namespace _05._Godzilla_vs._Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // input data
            double budget = double.Parse(Console.ReadLine());
            int statisti = int.Parse(Console.ReadLine());
            double oblekloCena = double.Parse(Console.ReadLine());
            // Calc dekor
            double dekor = budget * 0.1;

            // Calc cena obleklo
            oblekloCena = oblekloCena * statisti;

            // Check statisti
            if (statisti > 150)
            {
                // discount 10% ot cenata na oblekloto
                oblekloCena *= 0.9;
            }

            // Calc Budget
            double razhodi = dekor + oblekloCena;

            // show result
            if (budget < razhodi)
            {
                // kogato parite ne dostigat
                razhodi -= budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {razhodi:f2} leva more.");
            }
            else
            {
                // kogato parite dostigat
                budget -= razhodi;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget:f2} leva left.");
            }
        }
    }
}
