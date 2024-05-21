using NetGo.Domain.Enums;

namespace NetGo.Domain.Entities
{
    public class Button : Child
    {


        public Button(string? content, Guid? parentId) : base(content, ElementType.Button, parentId)
        {
        }
    }
}
