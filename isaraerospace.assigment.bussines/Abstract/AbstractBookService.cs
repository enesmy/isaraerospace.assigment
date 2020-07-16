using isaraerospace.assigment.entities;
using System;
using System.Collections.Generic;

namespace isaraerospace.assigment.bussines.Abstract
{
    public abstract class AbstractBookService
    {
        public abstract Book GetByBookName(string name);
        public abstract List<Book> GetAll();
        public abstract List<Book> SearchByName(string Name);
        public abstract List<Book> Filter(Func<Book, bool> filter);
        public abstract void Add(Book newBook);
        public abstract void Update(Book book);
        public abstract void Delete(int line);
    }
}
