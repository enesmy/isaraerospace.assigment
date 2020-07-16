using isaraerospace.assigment.dal.Abstract;
using isaraerospace.assigment.entities;
using System;
using System.Collections.Generic;

namespace isaraerospace.assigment.bussines.Concrete
{
    public class BookManager : Abstract.AbstractBookService
    {

        private IGenericDataRepository<Book> repository = null;

        public BookManager(IGenericDataRepository<Book> repository)
        {
            this.repository = repository;
        }

        public override void Add(Book newBook)
        {
            repository.Add(newBook);
            repository.Save();
        }

        public override void Delete(int line)
        {
            repository.Remove(repository.GetSingle(o => o.ID == line));
            repository.Save();
        }

        public override List<Book> Filter(Func<Book, bool> filter)
        {
            return (List<Book>)repository.GetList(filter);
        }

        public override List<Book> GetAll()
        {
            return (List<Book>)repository.GetAll();
        }

        public override Book GetByBookName(string name)
        {
            return repository.GetSingle(o => o.Title.Contains(name));
        }

        public override List<Book> SearchByName(string Name)
        {
            return (List<Book>)repository.GetList(o => o.Title.Contains(Name));
        }

        public override void Update(Book book)
        {
            var oldbook = repository.GetSingle(o => o.ID == book.ID);
            oldbook.Title = book.Title;
            oldbook.Author = book.Author;
            oldbook.Price = book.Price;
            oldbook.InStock = book.InStock;
            oldbook.Year = book.Year;
            oldbook.Binding = book.Binding;
            oldbook.Description = book.Description;
            repository.Save();
        }
    }
}
