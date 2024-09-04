using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUDExample.Models;

namespace CRUDExample.Areas
{
    public class IndexModel : PageModel
    {
        private readonly CRUDExample.Models.FriendsDbContext _context;

        public IndexModel(CRUDExample.Models.FriendsDbContext context)
        {
            _context = context;
        }

        public IList<Friend> Friend { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Friends != null)
            {
                Friend = await _context.Friends.ToListAsync();
            }
        }
    }
}
