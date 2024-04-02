using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge.Core
{ 
    public class Controller : IController
    {
        private readonly HashSet<string> diverTypes
            = new HashSet<string>() { typeof(FreeDiver).Name, typeof(ScubaDiver).Name };
        
        private readonly HashSet<string> fishTypes 
            = new HashSet<string>() { typeof(ReefFish).Name, typeof(DeepSeaFish).Name, typeof(PredatoryFish).Name };

        private IRepository<IDiver> divers;
        private IRepository<IFish> fish;

        public Controller()
        {
            divers = new DiverRepository();
            fish = new FishRepository();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            var currentDiver = divers.GetModel(diverName);
            var currentFish = fish.GetModel(fishName);

            if ( currentDiver == null)
            {
                return string.Format(OutputMessages.DiverNotFound, typeof(DiverRepository).Name, diverName);
            }

            if ( currentFish == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            if (currentDiver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (currentDiver.OxygenLevel < currentFish.TimeToCatch)
            {
                currentDiver.Miss(currentFish.TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }

            if (currentDiver.OxygenLevel == currentFish.TimeToCatch)
            {
                if (isLucky)
                {
                    currentDiver.Hit(currentFish);
                    return string.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
                }

                currentDiver.Miss(currentFish.TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }

            currentDiver.Hit(currentFish);
            return string.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
        }

        public string CompetitionStatistics()
        {
            var diversToReport = divers.Models.Where(x => x.HasHealthIssues == false)
                .OrderByDescending(x => x.CompetitionPoints)
                .ThenByDescending(x => x.CompetitionPoints)
                .ThenByDescending(x => x.Catch.Count)
                .ThenBy(x => x.Name);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach(var diver in diversToReport)
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (!this.diverTypes.Contains(diverType))
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if(divers.GetModel(diverName) != null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, typeof(DiverRepository).Name);
            }

            IDiver diver = null;

            if (diverType == typeof(FreeDiver).Name)
            {
                diver = new FreeDiver(diverName);
            }
            else
            {
                diver = new ScubaDiver(diverName);
            }

            divers.AddModel(diver);
            return string.Format(OutputMessages.DiverRegistered, diverName, typeof(DiverRepository).Name);
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();
            var currentDiver = divers.GetModel(diverName);

            sb.AppendLine(currentDiver.ToString());
            sb.AppendLine("Catch Report:");

            foreach(var currentFish in currentDiver.Catch)
            {
                sb.AppendLine(fish.GetModel(currentFish).ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string HealthRecovery()
        {
            var diversHasHealthIssues = divers.Models.Where(x => x.HasHealthIssues == true);
            int counter = 0;

            foreach (var diverHasHealthIssues in diversHasHealthIssues)
            {
                diverHasHealthIssues.UpdateHealthStatus();
                diverHasHealthIssues.RenewOxy();
                counter++;
            }

            return string.Format(OutputMessages.DiversRecovered, counter);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (!this.fishTypes.Contains(fishType))
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (fish.GetModel(fishName) != null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, nameof(FishRepository));
            }

            IFish newFish = null;

            if (fishType == typeof(ReefFish).Name)
            {
                newFish = new ReefFish(fishName, points);
            }
            else if (fishType == typeof(DeepSeaFish).Name)
            {
                newFish = new DeepSeaFish(fishName, points);
            }
            else
            {
                newFish = new PredatoryFish(fishName, points);
            }

            fish.AddModel(newFish);
            return string.Format(OutputMessages.FishCreated, fishName);
        }
    }
}
