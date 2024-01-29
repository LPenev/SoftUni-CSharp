namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = inputArray[0];
                string pokemonName = inputArray[1];
                string pokemonElement = inputArray[2];
                int pokemonHealth = int.Parse(inputArray[3]);

                Trainer trainer = trainers.SingleOrDefault(n => n.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);

                    trainer.Pokemons.Add(new(pokemonName, pokemonElement, pokemonHealth));
                    trainers.Add(trainer);
                }
                else
                {
                    trainer.Pokemons.Add(new(pokemonName, pokemonElement, pokemonHealth));
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    trainer.CheckPokemon(input);
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}

