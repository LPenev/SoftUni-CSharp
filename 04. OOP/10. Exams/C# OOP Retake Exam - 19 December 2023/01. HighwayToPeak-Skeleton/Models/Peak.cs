using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public class Peak : IPeak
    {
        private string name;
        private int elevation;
        private string difficultyLevel;

        public Peak(string name, int elevation, string difficultyLevel)
        {
            this.Name = name;
            this.Elevation = elevation;
            this.DifficultyLevel = difficultyLevel;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);
                }

                this.name = value;
            }
        }

        public int Elevation
        {
            get => elevation;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
                }

                this.elevation = value;
            }
        }

        public string DifficultyLevel
        {
            get => difficultyLevel;
            private set
            {
                this.difficultyLevel = value;
            }
        }

        public override string ToString()
        {
            return $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
        }
    }
}
