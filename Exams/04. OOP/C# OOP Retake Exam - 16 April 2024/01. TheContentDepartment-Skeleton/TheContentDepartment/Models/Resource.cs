using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class Resource : IResource
    {
        private string name;

        protected Resource(string name, string creator, int priority)
        {
            this.name = name;
            Creator = creator;
            Priority = priority;
            IsTested = false;
            IsApproved = false;
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NameNullOrWhiteSpace);
                }

                name = value; 
            }

        }

        public string Creator { get; private set; }

        public int Priority { get; private set; }

        public bool IsTested { get; private set; }

        public bool IsApproved { get; private set; }

        public void Approve()
        {
            IsTested = !IsTested;
        }

        public void Test()
        {
            IsApproved = true;
        }

        public override string ToString()
        {
            return $"{Name} ({this.GetType().Name}), Created By: {Creator}";
        }
    }
}
