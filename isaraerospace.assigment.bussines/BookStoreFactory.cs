using isaraerospace.assigment.bussines.Abstract;
using isaraerospace.assigment.bussines.Concrete;
using isaraerospace.assigment.dal.Concrete;
using isaraerospace.assigment.dal.Concrete.CSV;
using isaraerospace.assigment.entities;

namespace isaraerospace.assigment.bussines
{
    public class BookStoreFactory
    {
        public AbstractBookService Books;
        public BookStoreFactory()
        {

            Books = new BookManager(new GenericRepository<Book>(new BooksDAL()));

        }

    }
}
