using Microsoft.AspNetCore.Mvc;
using NetGo.API.Models;
using NetGo.Domain.Entities;
using NetGo.Persistence.Contexts;

namespace NetGo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyController : ControllerBase
    {
        readonly NetGoDbContext _context;

        public BodyController(NetGoDbContext context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public IActionResult CreateBody()
        {
            Guid id = _context.Bodies.Add(new()).Entity.Id;
            _context.SaveChanges();
            return Ok(id);
        }

        [HttpPost("[action]")]
        public IActionResult CreateElement(CreateElementRequest createElementRequest)
        {
            Element element = createElementRequest.ElementType switch
            {
                Domain.Enums.ElementType.H1 => new H1(createElementRequest.Content),
                Domain.Enums.ElementType.P => new P(createElementRequest.Content),
                _ => throw new NotImplementedException(),
            };

            Body? body = _context.Bodies.FirstOrDefault(x => x.Id == createElementRequest.BodyId);
            body?.Elements.Add(element);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult GetHtml(Guid bodyId)
        {
            Body? body = _context.Bodies.FirstOrDefault(x => x.Id == bodyId);
            string html = "<!DOCTYPE html><html><body>[[elements]]</body></html>";
            string elements = "";
            body?.Elements.ForEach(x => elements += x.ToHtml());
            html = html.Replace("[[elements]]", elements);
            return Ok(body?.Id);
        }
    }
}
