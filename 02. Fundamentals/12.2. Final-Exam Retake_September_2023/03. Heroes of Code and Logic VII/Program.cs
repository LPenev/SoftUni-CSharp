using System.Data;

namespace _13._Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var heros = new List<Hero>();
            var numberOfHeros = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfHeros; i++)
            {
                var hero = Console.ReadLine().Split(" ");
                var nameOfHero = hero[0];
                var heroMana = int.Parse(hero[1]);
                var heroHitPoints = int.Parse(hero[2]);

                heros.Add(new Hero(nameOfHero, heroMana, heroHitPoints));
            }

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArray = input.Split(" - ");
                string command = inputArray[0];
                string heroName = inputArray[1];

                var currentHero = heros.FirstOrDefault(x => x.Name == heroName);

                switch (command)
                {
                    case "CastSpell":
                        int manaPointsNeed = int.Parse(inputArray[2]);
                        string spellName = inputArray[3];
                        if (currentHero.HeroMana - manaPointsNeed < 0)
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                        else
                        {
                            currentHero.HeroMana -= manaPointsNeed;
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {currentHero.HeroMana} MP!");
                        }
                        break;

                    case "TakeDamage":
                        int damage = int.Parse(inputArray[2]);
                        string attacker = inputArray[3];
                        currentHero.HeroPoints -= damage;

                        if (currentHero.HeroPoints > 0)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currentHero.HeroPoints} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            heros.Remove(currentHero);
                        }
                        break;

                    case "Recharge":

                        int rechargeAmount = int.Parse(inputArray[2]);
                        var currentHeroMana = currentHero.HeroMana;

                        if (currentHeroMana + rechargeAmount > 200)
                        {
                            rechargeAmount = 200 - currentHeroMana;
                        }

                        currentHero.HeroMana += rechargeAmount;
                        Console.WriteLine($"{heroName} recharged for {rechargeAmount} MP!");
                        break;

                    case "Heal":
                        int healAmount = int.Parse(inputArray[2]);
                        int currentHeroPoints = currentHero.HeroPoints;
                        if (currentHeroPoints + healAmount > 100)
                        {
                            healAmount = 100 - currentHeroPoints;
                        }
                        currentHero.HeroPoints += healAmount;
                        Console.WriteLine($"{heroName} healed for {healAmount} HP!");
                        break;
                }
            }

            // print result
            foreach (var hero in heros)
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($"HP: {hero.HeroPoints}");
                Console.WriteLine($"MP: {hero.HeroMana}");
            }
        }
    }
    public class Hero
    {
        public Hero(string heroName, int heroPoints, int heroMana)
        {
            this.Name = heroName;
            this.HeroPoints = heroPoints;
            this.HeroMana = heroMana;
        }
        public string Name { get; set; }
        public int HeroPoints { get; set; }
        public int HeroMana { get; set; }
    }
}
