using Microsoft.EntityFrameworkCore;
using Repository;

public class BookController
{
    IRepository<Book> db;

    public BookController(IRepository<Book> repository)//+DI
    {
        db = repository;    
    }
}