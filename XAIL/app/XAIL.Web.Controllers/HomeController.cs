using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SharpArch.Core.PersistenceSupport;
using XAIL.Core;

namespace XAIL.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IRepository<News> newsRepository;

        public HomeController(IRepository<News> newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public ActionResult Index()
        {
            var top2AcademyNews = newsRepository
                .GetAll()
                .OrderByDescending(n => n.CreatedAt)
                .ToList()
                .GetRange(0, 2);

            var top4SummerProgramNews = newsRepository
                .GetAll()
                .OrderByDescending(n => n.CreatedAt)
                .ToList()
                .GetRange(0, 4);

            var homepageViewModel = new HomepageViewModel
                                        {
                                            AcademyNews = top2AcademyNews,
                                            SummerProgramNews = top4SummerProgramNews
                                        };

            return View("Index", homepageViewModel);
        }

        public ActionResult UnderConstruction()
        {
            return View("UnderConstruction");
        }
    }

    public class HomepageViewModel
    {
        public IEnumerable<News> AcademyNews { get; set; }

        public IEnumerable<News> SummerProgramNews { get; set; }
    }
}
