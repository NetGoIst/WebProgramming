using NetGo.Domain.Common;

namespace NetGo.Domain.Entities
{
    public class Body : EntityBase
    {
        public List<Element> Elements { get; set; }

        public Body()
        {
            Elements = new List<Element>();
        }
    }
}
