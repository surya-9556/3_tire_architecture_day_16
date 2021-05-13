using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMVCProject.Models
{
    public class PublicationContext : DbContext
    {
        public PublicationContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author() { Id = 1, Name = "Ramu", About = "Form India" },
                new Author() { Id = 2, Name = "Somu", About = "Freedom Struggle" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = 101, Name = "Freedom India", Price = 124, Author_Id = 1 },
                new Book() { Id = 102, Name = "Freedom Struggle", Price = 150, Author_Id = 2 }
            );
        }
    }
}
