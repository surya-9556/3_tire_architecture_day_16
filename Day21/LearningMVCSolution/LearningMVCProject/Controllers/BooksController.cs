using LearningMVCProject.Models;
using LearningMVCProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVCProject.Controllers
{
    public class BooksController : Controller
    {
        private ILogger<BooksController> _logger;
        private IReop<Book> _repo;
        public BooksController(IReop<Book> reop, ILogger<BooksController> logger)
        {
            _repo = reop;
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<Book> books = _repo.GetAll().ToList();
            return View(books);
        }

    }
}
