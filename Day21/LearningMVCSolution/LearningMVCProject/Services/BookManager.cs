using LearningMVCProject.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVCProject.Services
{
    public class BookManager : IReop<Book>
    {
        public PublicationContext _context;
        public ILogger<BookManager> _Logger;
        public BookManager(PublicationContext context,ILogger<BookManager> logger)
        {
            _context = context;
            _Logger = logger;
        }
        public void Add(Book t)
        {
            try
            {
                _context.books.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
        }

        public void Delete(Book t)
        {
            try
            {
                _context.books.Remove(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
        }

        public Book Get(int id)
        {
            try
            {
                Book book = _context.books.FirstOrDefault(b => b.Id == id);
                return book;
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Book> GetAll()
        {
            try
            {
                if (_context.books.Count() == 0)
                {
                    return null;
                }
                return _context.books.ToList();
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, Book t)
        {
            Book book = Get(id);
            if(book != null)
            {
                book.Name = t.Name;
                book.Price = t.Price;
            }
            _context.SaveChanges();
        }
    }
}
