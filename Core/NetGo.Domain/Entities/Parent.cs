using NetGo.Domain.Enums;

namespace NetGo.Domain.Entities
{
    public class Parent : Element
    {
        public Parent(string? content, ElementType type) : base(content, type)
        {
        }

        public List<Child> Children { get; set; }
    }
}
