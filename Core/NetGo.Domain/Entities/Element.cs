using NetGo.Domain.Common;
using NetGo.Domain.Enums;

namespace NetGo.Domain.Entities
{
    public class Element : EntityBase
    {
        public string? Content { get; set; }
        public ElementType Type { get; set; }
        public string? Style { get; set; }
      //  public List<Element>? Children { get; set; }

        public Element(string? content, ElementType type)
        {
            Content = content;
            Type = type;
        }
        public string ToHtml() {
            /*
            if (Children is not null && Children.Any())
            {
                foreach (Element element in Children)
                {
                    Content += element.ToHtml();
                }
            }

            */
            return $"<{Type} class={Style}>{Content}</{Type}>";
        }
    }
}
