using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ginga_Alexandra_Labo2.Data;
using Ginga_Alexandra_Labo2.Models;

namespace Ginga_Alexandra_Labo2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Ginga_Alexandra_Labo2.Data.Ginga_Alexandra_Labo2Context _context;

        public IndexModel(Ginga_Alexandra_Labo2.Data.Ginga_Alexandra_Labo2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Author != null)
            {
                Author = await _context.Author.ToListAsync();
            }
        }
    }
}
