namespace NetGo.Domain.Entities
{
    public class Element
    {
        public string? Content { get; set; }

        public Element(string? content)
        {
            Content = content;
        }
    }
}
