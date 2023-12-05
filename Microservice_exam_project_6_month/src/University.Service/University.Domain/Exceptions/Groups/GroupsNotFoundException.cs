namespace University.Domain.Exceptions.Groups
{
    public class GroupsNotFoundException : NotFoundException
    {
        public GroupsNotFoundException()
        {
            this.TitleMessage = "Group not Found !";
        }
    }
}
