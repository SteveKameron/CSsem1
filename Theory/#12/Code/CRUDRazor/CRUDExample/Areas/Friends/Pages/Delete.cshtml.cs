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
    public class DeleteModel : PageModel
    {
        private readonly CRUDExample.Models.FriendsDbContext _context;

        public DeleteModel(CRUDExample.Models.FriendsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Friend Friend { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends.FirstOrDefaultAsync(m => m.Id == id);

            if (friend == null)
            {
                return NotFound();
            }
            else 
            {
                Friend = friend;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Friends == null)
            {
                return NotFound();
            }
            var friend = await _context.Friends.FindAsync(id);

            if (friend != null)
            {
                Friend = friend;
                _context.Friends.Remove(Friend);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
