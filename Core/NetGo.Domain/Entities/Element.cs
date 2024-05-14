using NetGo.Domain.Common;
using NetGo.Domain.Enums;

namespace NetGo.Domain.Entities
{
    public class Element : EntityBase
    {
        public string? Content { get; set; }
        public ElementType Type { get; set; }

        public Element(string? content, ElementType type)
        {
            Content = content;
            Type = type;
        }

        public string ToHtml() => $"<{Type}>{Content}</{Type}>";
    }
}
