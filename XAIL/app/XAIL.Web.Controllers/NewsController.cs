using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NHibernate.Validator.Constraints;
using Paging;
using SharpArch.Core;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Web.NHibernate;
using XAIL.Core;

namespace XAIL.Web.Controllers
{
    public class NewsController : Controller
    {
        private const int defaultPageSize = 2;
        private readonly IRepository<News> newsRepository;

        public NewsController(IRepository<News> newsRepository)
        {
            Check.Require(newsRepository != null, "NewsRepository may not be null"); 
            this.newsRepository = newsRepository;
        }

        public ActionResult Index(int? page)
        {
            var news = newsRepository
                .GetAll()
                .OrderByDescending(n => n.CreatedAt)
                .ToList();

            var currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            return View("Index", news.ToPagedList(currentPageIndex, defaultPageSize));
        }

        public ActionResult Show(int id)
        {
            var news = newsRepository.Get(id);
            return View(news);
        }

        public ActionResult Create()
        {
            var newsViewModel = new NewsFormViewModel();
            return View(newsViewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [HttpPost]
        public ActionResult Create(NewsFormViewModel newsViewModel)
        {
            if (ViewData.ModelState.IsValid)
            {
                var news = new News(newsViewModel.Title) { Body = newsViewModel.Body };
                newsRepository.SaveOrUpdate(news);
                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = "The news was successfully created.";
                return RedirectToAction("Index");
            }

            return View(newsViewModel);
        }

        public ActionResult Edit(int id)
        {
            var news = newsRepository.Get(id);
            var newsViewModel = new NewsFormViewModel
                                    {
                                        Id = news.Id,
                                        Title = news.Title,
                                        Body = news.Body
                                    };
            return View(newsViewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [HttpPost]
        public ActionResult Edit(NewsFormViewModel newsFormViewModel)
        {
            var news = newsRepository.Get(newsFormViewModel.Id);

            if (ViewData.ModelState.IsValid)
            {
                news.Title = newsFormViewModel.Title;
                news.Body = newsFormViewModel.Body;
                newsRepository.SaveOrUpdate(news);
                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = "The news was successfully updated.";
                return RedirectToAction("Index");                
            }
            else
            {
                newsRepository.DbContext.RollbackTransaction();
                return View(newsFormViewModel);
            }
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var resultMessage = "The news was successfully deleted.";
            var newsToDelete = newsRepository.Get(id);

            if (newsToDelete != null)
            {
                newsRepository.Delete(newsToDelete);

                try
                {
                    newsRepository.DbContext.CommitChanges();
                }
                catch
                {
                    resultMessage = "A problem was encountered preventing the news from being deleted. " +
                        "Another item likely depends on this news.";
                    newsRepository.DbContext.RollbackTransaction();
                }
            }
            else
            {
                resultMessage = "The news could not be found for deletion. It may already have been deleted.";
            }

            TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = resultMessage;
            return RedirectToAction("Index");            
        }
    }

    public class NewsFormViewModel
    {
        public int Id { get; set; }

        [NotNullNotEmpty(Message = "Title must be provided")]
        public string Title { get; set; }

        [NotNullNotEmpty(Message = "Body must be provided")]
        public string Body { get; set; }
    }
}
