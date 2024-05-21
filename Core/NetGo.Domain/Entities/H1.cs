namespace NetGo.Domain.Entities
{
    public class H1 : Child
    {
        public H1(string? content, Guid? parentId) : base(content, Enums.ElementType.H1, parentId)
        {
        }
    }
}
