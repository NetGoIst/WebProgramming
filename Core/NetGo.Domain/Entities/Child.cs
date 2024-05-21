using NetGo.Domain.Common;
using NetGo.Domain.Enums;

namespace NetGo.Domain.Entities
{
    public class Child : Element
    {
        public Child(string? content, ElementType type, Guid? parentId) : base(content, type)
        {
                ParentId = parentId;
        }
        public Guid? ParentId { get; set; }
        public Parent Parent { get; set; }

        public int Order { get; set; }

        
    }
}
