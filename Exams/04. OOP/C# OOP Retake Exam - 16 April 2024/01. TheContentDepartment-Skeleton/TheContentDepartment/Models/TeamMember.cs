using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class TeamMember : ITeamMember
    {
        private string name;
        private string path;
        private List<string> inProgress;

        public TeamMember(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }

                name = value;
            }
        }

        public string Path
        { 
            get { return path; } 
            protected set { path = value; }
        }

        public IReadOnlyCollection<string> InProgress => inProgress.AsReadOnly();

        public void FinishTask(string resourceName)
        {
            inProgress.Remove(resourceName);
        }

        public void WorkOnTask(string resourceName)
        {
            inProgress.Add(resourceName);
        }
    }
}
