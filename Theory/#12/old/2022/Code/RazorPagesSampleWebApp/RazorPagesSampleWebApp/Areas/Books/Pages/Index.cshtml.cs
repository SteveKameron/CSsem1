using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSampleWebApp;

namespace RazorPagesSampleWebApp.Pages.Areas.Books
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesSampleWebApp.CSharpBooksContext _context;

        public IndexModel(RazorPagesSampleWebApp.CSharpBooksContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Book = await _context.Books.ToListAsync();
            }
        }
    }
}
