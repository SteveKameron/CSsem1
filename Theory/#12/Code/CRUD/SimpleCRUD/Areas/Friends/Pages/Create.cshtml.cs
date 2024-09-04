using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleCRUD.Models;

namespace SimpleCRUD.Areas
{
    public class CreateModel : PageModel
    {
        private readonly SimpleCRUD.Models.FriendsDbContext _context;

        public CreateModel(SimpleCRUD.Models.FriendsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Friend Friend { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Friends == null || Friend == null)
            {
                return Page();
            }

            _context.Friends.Add(Friend);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
