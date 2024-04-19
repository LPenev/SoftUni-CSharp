using System.Text;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        private ResourceRepository resources;
        private MemberRepository members;

        public Controller()
        {
            resources = new ResourceRepository();
            members = new MemberRepository();
        }

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            var resource = resources.TakeOne(resourceName);

            if (resource.IsTested == false)
            {
                return string.Format(OutputMessages.ResourceNotTested, resourceName);
            }

            var teamLeader = members.Models.FirstOrDefault(m => m.Path == "Master");

            if (isApprovedByTeamLead)
            {
                resource.Approve();
                teamLeader.FinishTask(resourceName);
                return string.Format(OutputMessages.ResourceApproved, teamLeader.Name, resource.Name);
            }
            else
            {
                resource.Test();
                return string.Format(OutputMessages.ResourceReturned, teamLeader.Name, resource.Name);
            }
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (resourceType != "Exam" && resourceType != "Workshop" && resourceType != "Presentation")
            {
                return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
            }

            ITeamMember teamMember = members.Models.FirstOrDefault(x => x.Path == path);

            if (teamMember == null)
            {
                return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
            }

            if (teamMember.InProgress.Contains(resourceName))
            {
                return string.Format(OutputMessages.ResourceExists, resourceName);
            }

            IResource resource;
            string creatorName = teamMember.Name;

            if (resourceType == nameof(Exam))
            {
                resource = new Exam(resourceName, creatorName);
            }
            else if (resourceType == nameof(Workshop))
            {
                resource = new Workshop(resourceName, creatorName);
            }
            else
            {
                resource = new Presentation(resourceName, creatorName);
            }

            resources.Add(resource);
            teamMember.WorkOnTask(resourceName);

            return string.Format(OutputMessages.ResourceCreatedSuccessfully, creatorName, resourceType, resourceName);
        }

        public string DepartmentReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Finished Tasks:");

            foreach(var resource in resources.Models.Where(x=>x.IsApproved))
            {
                sb.AppendLine($"--{resource.ToString()}");
            }

            sb.AppendLine("Team Report:");

            var TeamLeader = members.Models.FirstOrDefault(x => x.Path == "Master");
            
                sb.AppendLine($"--{TeamLeader.ToString()}");

                foreach (var member in members.Models.Where(x=>x.Path != "Master"))
                {
                    sb.AppendLine(member.ToString());
                }

            return sb.ToString().Trim();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            if (memberType != "TeamLead" && memberType != "ContentMember")
            {
                return string.Format(OutputMessages.MemberTypeInvalid, memberType);
            }

            if (members.Models.Any(x => x.Path == path))
            {
                return string.Format(OutputMessages.PositionOccupied);
            }

            if (members.Models.Any(x => x.Name == memberName))
            {
                return string.Format(OutputMessages.MemberExists, memberName);
            }

            ITeamMember member;

            if (memberType == nameof(TeamLead))
            {
                member = new TeamLead(memberName, path);
            }
            else
            {
                member = new ContentMember(memberName, path);
            }

            members.Add(member);
            return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
        }

        public string LogTesting(string memberName)
        {
            var member = members.TakeOne(memberName);
            
            if (member == null)
            {
                return string.Format(OutputMessages.WrongMemberName);
            }

            var resourceNotTestet = resources.Models
                .Where(x => x.Creator == memberName)
                .Where(x => x.IsTested == false)
                .OrderBy(x => x.Priority)
                .FirstOrDefault();

            if (resourceNotTestet == null)
            {
                return string.Format(OutputMessages.NoResourcesForMember, memberName);
            }

            ITeamMember teamLeader = members.Models.FirstOrDefault(x => x.Path == "Master");

            resourceNotTestet.Test();
            member.FinishTask(resourceNotTestet.Name);
            teamLeader.WorkOnTask(resourceNotTestet.Name);

            return string.Format(OutputMessages.ResourceTested, resourceNotTestet.Name);
        }
    }
}
