using System.Linq;
using System.Web.Mvc;
using NHibernate.Validator.Constraints;
using SharpArch.Core;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Web.NHibernate;
using XAIL.Core;

namespace XAIL.Web.Controllers
{
    public class NewsCategoriesController : Controller
    {
        private readonly IRepository<NewsCategory> newsCategoryRepository;

        public NewsCategoriesController(IRepository<NewsCategory> newsCategoryRepository)
        {
            Check.Require(newsCategoryRepository != null, "NewsCategoryRepository may not be null"); 
            this.newsCategoryRepository = newsCategoryRepository;
        }        
        
        public ActionResult Index()
        {
            var categories = newsCategoryRepository
                .GetAll()
                .OrderBy(nc => nc.Name)
                .ToList();           

            return View("Index", categories);
        }

        public ActionResult Create()
        {
            var newsViewModel = new NewsCategoryFormViewModel();
            return View(newsViewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [HttpPost]
        public ActionResult Create(NewsCategoryFormViewModel newsCategoryViewModel)
        {
            if (ViewData.ModelState.IsValid)
            {
                var newsCategory = new NewsCategory(newsCategoryViewModel.Name);
                newsCategoryRepository.SaveOrUpdate(newsCategory);
                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = "The news category was successfully created.";
                return RedirectToAction("Index");
            }

            return View(newsCategoryViewModel);
        }

        public ActionResult Edit(int id)
        {
            var category = newsCategoryRepository.Get(id);
            var newsCategoryViewModel = new NewsCategoryFormViewModel
            {
                Id = category.Id,
                Name = category.Name,
            };

            return View(newsCategoryViewModel);
        }

        [ValidateAntiForgeryToken]
        [Transaction]
        [HttpPost]
        public ActionResult Edit(NewsCategoryFormViewModel newsCategoryViewModel)
        {
            var news = newsCategoryRepository.Get(newsCategoryViewModel.Id);

            if (ViewData.ModelState.IsValid)
            {
                news.Name = newsCategoryViewModel.Name;
                newsCategoryRepository.SaveOrUpdate(news);
                TempData[ControllerEnums.GlobalViewDataProperty.PageMessage.ToString()] = "The news was successfully updated.";
                return RedirectToAction("Index");
            }

            newsCategoryRepository.DbContext.RollbackTransaction();
            return View(newsCategoryViewModel);
        }
    }

    public class NewsCategoryFormViewModel
    {
        public int Id { get; set; }

        [NotNullNotEmpty(Message = "Category Name must be provided")]
        public string Name { get; set; }
    }
}
