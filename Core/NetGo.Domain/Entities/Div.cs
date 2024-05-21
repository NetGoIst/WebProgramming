using NetGo.Domain.Enums;

namespace NetGo.Domain.Entities
{
    public class Div : Child
    {
        public Div(string? content, Guid? parentId) : base(content, ElementType.Div, parentId)
        {
        }
    }
}
