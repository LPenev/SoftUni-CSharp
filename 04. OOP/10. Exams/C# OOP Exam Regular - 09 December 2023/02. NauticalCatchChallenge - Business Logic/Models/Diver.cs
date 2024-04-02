using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> @catchs;
        private double competitionPoints = 0;
        private bool hasHealthIssues = false;

        protected Diver(string name, int oxygenLevel)
        {
            this.Name = name;
            this.OxygenLevel = oxygenLevel;
            @catchs = new List<string>();
            competitionPoints = 0;
            hasHealthIssues = false;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }

                name = value;
            }
        }

        public int OxygenLevel
        {
            get { return oxygenLevel; }
            protected set
            {
                if (value <= 0)
                {
                    hasHealthIssues = true;
                    oxygenLevel = 0;
                }
                else
                {
                    oxygenLevel = value;
                }
            }
        }

        public IReadOnlyCollection<string> Catch
        {
            get { return catchs.AsReadOnly(); }
        }

        public double CompetitionPoints
        {
            get { return Math.Round(competitionPoints, 1); }
            private set { competitionPoints = value; }
        }

        public bool HasHealthIssues
        {
            get { return hasHealthIssues; }
            private set { hasHealthIssues = value; }
        }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            catchs.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            hasHealthIssues = !hasHealthIssues;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {this.Catch.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
