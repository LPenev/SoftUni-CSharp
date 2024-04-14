using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private IRepository<IPeak> peaks;
        private IRepository<IClimber> climbers;
        private IBaseCamp baseCamp;
        private HashSet<string> difficultyLevels;

        public Controller()
        {
            peaks = new PeakRepository();
            climbers = new ClimberRepository();
            baseCamp = new BaseCamp();
            difficultyLevels = new HashSet<string>() { "Extreme", "Hard", "Moderate" };
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (peaks.Get(name) != null)
            {
                return String.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            if (!difficultyLevels.Contains(difficultyLevel))
            {
                return String.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }

            peaks.Add(new Peak(name, elevation, difficultyLevel));
            return String.Format(OutputMessages.PeakIsAllowed, name, nameof(PeakRepository));
        }

        public string AttackPeak(string climberName, string peakName)
        {
            if (climbers.Get(climberName) == null)
            {
                return String.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            if (peaks.Get(peakName) == null)
            {
                return String.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!baseCamp.Residents.Contains(climberName))
            {
                return String.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            var currentPeak = peaks.Get(peakName);
            var currentClimber = climbers.Get(climberName);

            if (currentPeak.DifficultyLevel == "Extreme" && currentClimber.GetType().Name == "NaturalClimber")
            {
                return String.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            baseCamp.LeaveCamp(climberName);
            currentClimber.Climb(currentPeak);

            if (currentClimber.Stamina < 1)
            {
                return String.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }

            baseCamp.ArriveAtCamp(climberName);
            return String.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
        }

        public string BaseCampReport()
        {
            if (baseCamp.Residents.Count < 1)
            {
                return String.Format(OutputMessages.NoClimbersAtBaseCamp);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseCamp residents:");

            foreach (var climberName in baseCamp.Residents)
            {
                var currentClimber = climbers.Get(climberName);
                sb.AppendLine($"Name: {currentClimber.Name}, Stamina: {currentClimber.Stamina}, Count of Conquered Peaks: {currentClimber.ConqueredPeaks.Count}");
            }

            return sb.ToString().Trim();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!baseCamp.Residents.Contains(climberName))
            {
                return String.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            var currentClimber = climbers.Get(climberName);

            if (currentClimber.Stamina == 10)
            {
                return String.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }

            currentClimber.Rest(daysToRecover);
            return String.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (climbers.Get(name) != null)
            {
                return String.Format(OutputMessages.ClimberCannotBeDuplicated, name, nameof(ClimberRepository));
            }

            IClimber currentClimber = null;

            if (!isOxygenUsed)
            {
                currentClimber = new NaturalClimber(name);
            }
            else
            {
                currentClimber = new OxygenClimber(name);
            }

            climbers.Add(currentClimber);
            baseCamp.ArriveAtCamp(name);

            return String.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }

        public string OverallStatistics()
        {
            List<IClimber> reportClimbers = climbers.All.OrderByDescending(p => p.ConqueredPeaks.Count).ThenBy(n => n.Name).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");

            foreach (var climber in reportClimbers)
            {
                sb.AppendLine($"{climber.ToString()}");
                var climberPeaks = new List<IPeak>();

                foreach (string currentPeakName in climber.ConqueredPeaks)
                {
                    climberPeaks.Add(peaks.Get(currentPeakName));
                }
                
                foreach (var currentPeak in climberPeaks.OrderByDescending(x=>x.Elevation))
                {
                    sb.AppendLine(currentPeak.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
