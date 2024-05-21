using NetGo.Domain.Common;

namespace NetGo.Domain.Entities
{
    public class Body : EntityBase
    {
        public List<Child> Children { get; set; }

        public Body()
        {
            Children = new List<Child>();
        }
    }
}
