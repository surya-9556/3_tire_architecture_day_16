using LearningMVCProject.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVCProject.Services
{
    public class AuthorManager : IReop<Author>
    {
        public PublicationContext _context;
        public ILogger<AuthorManager> _logger;
        public AuthorManager()
        {

        }
        public AuthorManager(PublicationContext context,ILogger<AuthorManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Author t)
        {
            try
            {
                _context.authors.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public void Delete(Author t)
        {
            try
            {
                _context.authors.Remove(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Author Get(int id)
        {
            try
            {
                Author author = _context.authors.FirstOrDefault(a => a.Id == id);
                return author;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Author> GetAll()
        {
            try
            {
                if(_context.authors.Count() == 0)
                {
                    return null;
                }
                return _context.authors.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, Author t)
        {
            Author author = Get(id);
            if(author != null)
            {
                author.Name = t.Name;
                author.About = t.About;
                author.books = t.books;
            }
            _context.SaveChanges();
        }
    }
}
