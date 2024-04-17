using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class ContentMember : TeamMember
    {
        public ContentMember(string name, string path) : base(name, path)
        {
            if(path != "CSharp" &&  path != "JavaScript" &&  path != "Python" && path != "Java")
            {
                throw new ArgumentException(ExceptionMessages.PathIncorrect, path);
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Path} path. Currently working on {InProgress.Count} tasks.";
        }
    }
}
