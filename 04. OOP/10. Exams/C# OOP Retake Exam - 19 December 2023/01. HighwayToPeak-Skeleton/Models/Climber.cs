using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private List<string> conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            this.Name = name;
            this.Stamina = stamina;
            conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }

                name = value;
            }
        }

        public int Stamina
        {
            get => stamina;
            protected set
            {
                if (value > 10)
                {
                    stamina = 10;
                }
                else if (value < 0)
                {
                    stamina = 0;
                }
                else
                {
                    stamina = value;
                }
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks;

        public void Climb(IPeak peak)
        {
            if (!ConqueredPeaks.Contains(peak.Name))
            {
                conqueredPeaks.Add(peak.Name);
            }
            
            if (peak.Name == "Extreme")
            {
                Stamina -= 6;
            }
            else if (peak.Name == "Hard")
            {
                Stamina -= 4;
            }
            else if (peak.Name == "Moderate")
            {
                Stamina -= 2;
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");

            int currentPeaks = ConqueredPeaks.Count;

            if (currentPeaks < 1)
            {
                sb.AppendLine($"Peaks conquered: no peaks conquered");
            }
            else
            {
                sb.AppendLine($"Peaks conquered: {currentPeaks}");
            }

            return sb.ToString().Trim();
        }
    }
}
