namespace SharkTaxonomy
{
    public class Shark
    {
        private string kind;
        private int length;
        private string food;
        private string habitat;

        public Shark(string kind, int length, string food, string habitat)
        {
            this.Kind = kind;
            this.Length = length;
            this.Food = food;
            this.Habitat = habitat;
        }

        public string Kind { get; set; }
        public int Length { get; set; }
        public string Food { get; set; }
        public string Habitat { get; set; }

        public override string ToString()
        {
            return $"{Kind} shark: {Length}m long.{Environment.NewLine}Could be spotted in the {Habitat}, typical menu: {Food}";
        }
    }
}
