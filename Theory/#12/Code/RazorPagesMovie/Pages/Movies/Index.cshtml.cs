using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
	//Razor pages are derived from PageModel
	//Following convention it has a name [PageNameModel]
	//Here IndexModel
	public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

		//Constructor uses DI
		public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;



        /// <summary>
        /// Search feature
        /// </summary>
        /// <returns></returns>
        //[BindProperty(SupportsGet =true)]
        //public string? SearchString { get; set; }
        //public SelectList? Genres { get; set; }
        //[BindProperty(SupportsGet =true)]
        //public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }


            ////Search feature
            //var movies = from m in _context.Movie
            //             select m;

            //if (!string.IsNullOrEmpty(SearchString))
            //{
            //    movies = movies.Where(s => s.Title.Contains(SearchString));
            //}

            //Movie = await movies.ToListAsync();

            ////  /Movies?searchString=Ghost
        }
    }
}
