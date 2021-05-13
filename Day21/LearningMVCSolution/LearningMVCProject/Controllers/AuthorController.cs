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
    public class AuthorController : Controller
    {
        private ILogger<AuthorController> _logger;
        private IReop<Author> _repo;
        public AuthorController(IReop<Author> repo,ILogger<AuthorController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<Author> authors = _repo.GetAll().ToList();
            return View(authors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            _repo.Add(author);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Author author = _repo.Get(id);
            return View(author);
        }
        [HttpPost]
        public IActionResult edit(int id, Author author)
        {
            _repo.Update(id, author);
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Deltete(Author author)
        {
            _repo.Delete(author);
            return RedirectToAction("Index");
        }
    }
}
