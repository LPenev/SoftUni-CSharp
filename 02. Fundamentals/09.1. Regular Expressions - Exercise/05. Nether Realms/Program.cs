using System.Text;
using System.Text.RegularExpressions;

namespace _15._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patternLetters = @"[^0-9+\-*/\.]";
            string patternDamage = @"((\+|\-)?(\d+(\.\d+)?))";
            string patternMultiOrDivision = @"[*/]";
            var demons = new List<Demon>();

            var demonNames = Console.ReadLine()
                .Split(new char[] {',', ' ','\t'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var currentDemon in demonNames)
            {
                
                int demonHealt = 0;
                foreach (Match current in Regex.Matches(currentDemon, patternLetters))
                {
                    demonHealt += char.Parse(current.Value);
                }

                double demonDamage = 0;
                foreach (Match currentDamage in Regex.Matches(currentDemon, patternDamage))
                {
                    demonDamage += double.Parse(currentDamage.Value);
                }

                foreach (Match currentDamage in Regex.Matches(currentDemon, patternMultiOrDivision))
                {
                    if(currentDamage.Value == "*")
                    {
                        demonDamage *= 2;
                    }
                    else
                    {
                        demonDamage /= 2;
                    }
                }

                demons.Add(new Demon(currentDemon, demonHealt, demonDamage));
            }

            // print result
            foreach ( var demon in demons.OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }
        }
    }
    public class Demon
    {
        public Demon(string name, int health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }
}