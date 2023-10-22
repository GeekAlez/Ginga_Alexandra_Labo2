using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ginga_Alexandra_Labo2.Data;
using Ginga_Alexandra_Labo2.Models;

namespace Ginga_Alexandra_Labo2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Ginga_Alexandra_Labo2.Data.Ginga_Alexandra_Labo2Context _context;

        public IndexModel(Ginga_Alexandra_Labo2.Data.Ginga_Alexandra_Labo2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book

                    .Include(b => b.Publisher)
                    .ToListAsync();
            }
        }
    }
}
