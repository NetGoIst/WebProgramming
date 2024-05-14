using NetGo.Domain.Enums;

namespace NetGo.API.Models
{
    public class CreateElementRequest
    {
        public Guid BodyId { get; set; }
        public ElementType ElementType  { get; set; }
        public string Content { get; set; }
    }
}
