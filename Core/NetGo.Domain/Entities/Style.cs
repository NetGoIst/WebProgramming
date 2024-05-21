using NetGo.Domain.Common;
using NetGo.Domain.Enums;

namespace NetGo.Domain.Entities
{
    public class Style : EntityBase
    {
        public Display Display { get; set; }
        public string MyProperty { get; set; }
    }
}
