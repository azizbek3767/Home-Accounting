using Microsoft.AspNetCore.Mvc;
using PersonalAccounting.DataAccess;
using PersonalAccounting.Models.Repositories;
using PersonalAccounting.Models;
using PersonalAccounting.ViewModels;
using System.Diagnostics;

namespace PersonalAccounting.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly AppDbContext _dbContext;

        public CategoryController(ILogger<HomeController> logger, ICategoryRepository categoryRepository, AppDbContext dbContext)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            CategoryIndexViewModel viewModel = new CategoryIndexViewModel()
            {
                Categories = _categoryRepository.GetAll()
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel category)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category
                {
                    Type = category.Type,
                    Name = category.Name,
                };
                newCategory = _categoryRepository.Create(newCategory);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Category category = _categoryRepository.Get(id);
            if (category != null)
            {
                CategoryEditViewModel viewModel = new CategoryEditViewModel()
                {
                    Id = category.Id,
                    Type = category.Type,
                    Name = category.Name,
                };
                return View(viewModel);
            }
            else
            {
                return NotFoundView(id);
            }
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditViewModel category)
        {
            if (ModelState.IsValid)
            {
                Category existingCategory = _categoryRepository.Get(category.Id);
                existingCategory.Id = category.Id;
                existingCategory.Type = category.Type;
                existingCategory.Name = category.Name;

                _categoryRepository.Update(existingCategory);
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Category category = _categoryRepository.Get(id);
            if (category != null)
            {
                _categoryRepository.Delete(id);
                return RedirectToAction("index");
            }
            else
            {
                return NotFoundView(id);
            }
        }
        private ViewResult NotFoundView(int id)
        {
            Response.StatusCode = 404;
            return View("NotFound", id);
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
    }
}
