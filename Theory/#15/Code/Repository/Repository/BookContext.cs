using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions opt) : base(opt)
        { }
        public DbSet<Book> Books { get; set; }
    }
}
