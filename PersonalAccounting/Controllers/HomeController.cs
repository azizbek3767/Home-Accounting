using Microsoft.AspNetCore.Mvc;
using PersonalAccounting.DataAccess;
using PersonalAccounting.Models;
using PersonalAccounting.Models.Repositories;
using PersonalAccounting.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace PersonalAccounting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryTransactionRepository _categoryTransactionRepository;
        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ITransactionRepository transactionRepository, ICategoryRepository categoryRepository, ICategoryTransactionRepository categoryTransactionRepository, AppDbContext dbContext)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
            _categoryTransactionRepository = categoryTransactionRepository;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            double sum = 0;

            foreach(var transaction in _transactionRepository.GetAll())
            {
                if(transaction.Type == ActionTypes.Income)
                {
                    sum += transaction.Amount;
                }
                else
                {
                    sum -= transaction.Amount;
                }
            }

            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Transactions = _transactionRepository.GetAll(),
                Sum = sum,
                Categories= _categoryRepository.GetAll(),
                CategoryTransactions = _categoryTransactionRepository.GetAll(),
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            HomeCreateViewModel viewModel = new HomeCreateViewModel()
            {
                Categories = _categoryRepository.GetAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(HomeCreateViewModel transaction)
        {
            double lastSum = 0;
            if(_dbContext.Transactions.Count() == 0)
            {
                lastSum = 0;
            }
            else
            {
                var lastTransactionId = _dbContext.Transactions.Max(x => x.Id);
                var lastTransaction = _dbContext.Transactions.FirstOrDefault(x => x.Id == lastTransactionId);
                lastSum = lastTransaction.Sum;
            }

            double newSum = 0;

            if(transaction.Type == ActionTypes.Income)
            {
                newSum = lastSum + transaction.Amount;
            }
            else
            {
                newSum = lastSum - transaction.Amount;
            }

            if(newSum < 0)
            {
                ViewBag.ErrorMessage = "У вас недостаточно денег";
                return View("Create");
            }

            if (ModelState.IsValid)
            {
                Transaction newTransaction = new Transaction
                {
                    DateTime = transaction.DateTime,
                    Type = transaction.Type,
                    Category = transaction.Category,
                    Amount = transaction.Amount,
                    Comment = transaction.Comment,
                    Sum = newSum
                };
                newTransaction = _transactionRepository.Create(newTransaction);
                _categoryTransactionRepository.Create(
                        new CategoryTransaction
                        {
                            TransactionId = newTransaction.Id,
                            CategoryId = _dbContext.Categories.Where(x => x.Name == newTransaction.Category).Select(y => y.Id).FirstOrDefault()
                        }
                    );
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Transaction transaction = _transactionRepository.Get(id);
            if (transaction != null)
            {
                HomeEditViewModel viewModel = new HomeEditViewModel()
                {
                    Id = transaction.Id,
                    DateTimeOld = transaction.DateTime,
                    Type = transaction.Type,
                    Category = transaction.Category,
                    Amount = transaction.Amount,
                    Comment = transaction.Comment,
                    Categories = _categoryRepository.GetAll()
                }; 
                return View(viewModel);
            }
            else
            {
                return NotFoundView(id);
            }
        }

        [HttpPost]
        public IActionResult Edit(HomeEditViewModel transaction)
        {
            if (ModelState.IsValid)
            {
                Transaction existingTransaction = _transactionRepository.Get(transaction.Id);
                existingTransaction.Id = transaction.Id;
                existingTransaction.Type = transaction.Type;
                existingTransaction.Category = transaction.Category;
                existingTransaction.Amount = transaction.Amount;
                existingTransaction.Comment = transaction.Comment;

                _transactionRepository.Update(existingTransaction);
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Transaction transaction = _transactionRepository.Get(id);
            if (transaction != null)
            {
                _transactionRepository.Delete(id);
                return RedirectToAction("index");
            }
            else
            {
                return NotFoundView(id);
            }
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
        private ViewResult NotFoundView(int id)
        {
            Response.StatusCode = 404;
            return View("StaffNotFound", id);
        }
    }
}