using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Models;

namespace SimpleCRUD.Areas
{
    public class IndexModel : PageModel
    {
        private readonly SimpleCRUD.Models.FriendsDbContext _context;

        public IndexModel(SimpleCRUD.Models.FriendsDbContext context)
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
