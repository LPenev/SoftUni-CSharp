using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private List<string> conqueredPeaks;


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
            private set
            {
                if(value > 10)
                {
                    stamina = 10;
                }
                else if (value < 0)
                {
                    stamina = 0;
                }else
                {
                    stamina = value;
                }
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks;

        public void Climb(IPeak peak)
        {
            throw new NotImplementedException();
        }

        public void Rest(int daysCount)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{nameof(name)} - Name: {Name}, Stamina: {Stamina}");
            sb.AppendLine($"Peaks conquered: no peaks conquered/{peaksCount}");
            return sb.ToString().Trim();
        }
    }
}
