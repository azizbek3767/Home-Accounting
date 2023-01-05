using Microsoft.AspNetCore.Mvc;
using PersonalAccounting.DataAccess;
using PersonalAccounting.Models;
using PersonalAccounting.Models.Repositories;
using PersonalAccounting.ViewModels;
using System.Diagnostics;

namespace PersonalAccounting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransactionRepository _transactionRepository;
        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ITransactionRepository transactionRepository, AppDbContext dbContext)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Transactions = _transactionRepository.GetAll()
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
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
                return RedirectToAction("Index");
            }
            return View();
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