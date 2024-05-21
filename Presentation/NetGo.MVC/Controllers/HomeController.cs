using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetGo.Domain.Entities;
using NetGo.MVC.Models;
using NetGo.Persistence.Contexts;
using System.Diagnostics;

namespace NetGo.MVC.Controllers
{
    public class HomeController : Controller
    {
        readonly NetGoDbContext _context;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new NetGoDbContext();
        }

        public IActionResult Index()
        {

            //   Element element = _context.Elements.FirstOrDefault(x=> x.Id == Guid.Parse("7377035c-66cd-47d2-bead-c7d5ac1849e3"))




            Body? body = _context.Bodies.Include(x => x.Parent).FirstOrDefault(x => x.Id == Guid.Parse("1C7DE70B-3987-467D-9BA9-07980351F094"));



            Console.WriteLine($"Count: {body.Parent.Count}");
            string html = "<!DOCTYPE html><html><body>[[elements]]</body></html>";
            string elements = "";
            body?.Parent.ForEach(x => elements += x.ToHtml());


            html = html.Replace("[[elements]]", elements);
            return View((object)html);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateBody()
        {
            _context.Bodies.Add(new() { });
            _context.SaveChanges();
            return View();
        }

        public IActionResult CreateElement()
        {
            Body? body = _context.Bodies.FirstOrDefault(x => x.Id == Guid.Parse("1C7DE70B-3987-467D-9BA9-07980351F094"));
            /*Element element = new Div(null, null);
            body?.Elements.Add(element);*/
            //body?.Elements.Add(new Button("Button", Guid.Parse("445F672D-CB7A-42E7-9BF5-3808AD0C18D9")));
            //body?.Elements.Add(new H1("Hello World", Guid.Parse("445F672D-CB7A-42E7-9BF5-3808AD0C18D9")));
            /*Element element1 = new Div(null, Guid.Parse("445F672D-CB7A-42E7-9BF5-3808AD0C18D9"));
            body?.Elements.Add(element1);*/
            /*Element element2 = new Div(null, Guid.Parse("69332355-EB25-4842-9A4F-3B63AB34DD17"));
            body?.Elements.Add(element2);*/
            //body?.Elements.Add(new H1("Net Go", Guid.Parse("F686584F-3258-4458-AD6E-4BC0016759C6")));
            /*Element element3 = new Div(null, null);
            body?.Elements.Add(element3);*/
            //body?.Elements.Add(new H1("Go Go Go", Guid.Parse("7A497ED3-B6B6-4B03-B8F4-08B16545C24F")));
            body?.Parent.Add(new H1("Bitti", null));

            _context.SaveChanges();

            return View();
        }

        public string ToHtml(List<Child> children, List<Child> parents)
        {
            string elementsHtml = "";
            foreach (Child parent in parents)
            {
                List<Child> grandsons = children.Where(x => x.ParentId == parent.Id).ToList();
                if (grandsons.Count > 0)
                {
                    grandsons.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order));
                    elementsHtml += $"<{parent.Type}>{parent.Content}{ToHtml(children, grandsons)}</{parent.Type}>";
                } else
                {
                    elementsHtml += $"<{parent.Type}>{parent.Content}</{parent.Type}>";
                }
            }
            return elementsHtml;
        }

        public IActionResult GetBody()
        {
            Body? body = _context.Bodies.Include(x => x.Children).FirstOrDefault(x => x.Id == Guid.Parse("1C7DE70B-3987-467D-9BA9-07980351F094"));
            
            List<Child> parents = body?.Children.Where(x => x.ParentId == null).ToList(); // [1, 7, 9]
            parents.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order)); // [1, 7, 9]
            string html = ToHtml(body.Children, parents); // 
            return View();
        }
    }
}