using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        private int capacity;
        private List<Shark> species;

        public Classifier(int capacity)
        {
            this.Capacity = capacity;
            this.species = new List<Shark>();
        }

        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }
        public int GetCount => species.Count;

        public void AddShark(Shark shark)
        {
            if (GetCount < Capacity)
            {
                if (!species.Contains(shark))
                {
                    species.Add(shark);
                }
            }
        }

        public bool RemoveShark(string kind)
        {
            var seached = species.FirstOrDefault(s => s.Kind == kind);

            return species.Remove(seached);
        }

        public string GetLargestShark()
        {
            var sortedSpeceisByLength = species.OrderByDescending(s => s.Length).ToList();
            var largest = sortedSpeceisByLength.First();

            string result = $"{largest.Kind} shark: {largest.Length}m long.";

            return result;
        }

        public double GetAverageLength()
        {
            var average = species.Average(s => s.Length);

            return average;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{species.Count()} sharks classified:");

            foreach (var shark in species)
            {
                sb.AppendLine($"{shark.Kind} shark: {shark.Length}m long.");
                sb.AppendLine($"Could be spotted in the {shark.Food}, typical menu: {shark.Habitat}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
