using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ginga_Alexandra_Labo2.Data;
using Ginga_Alexandra_Labo2.Models;
using System.Net;
//using Ginga_Alexandra_Labo2.Data.Ginga_Alexandra_Labo2Context;

namespace Ginga_Alexandra_Labo2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Ginga_Alexandra_Labo2.Data.Ginga_Alexandra_Labo2Context _context;


        public IndexModel(Ginga_Alexandra_Labo2.Data.Ginga_Alexandra_Labo2Context context)
        {
            _context = context;
            // return Page;
        }
        public IList<Book> Book { get; set; }
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();

            BookD.Books = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();

            if (id != null)
            {

                BookID = id.Value;
                Book book = BookD.Books.FirstOrDefault(b => b.ID == id.Value);
                //.Where(i => i.ID == id.Value).Single();
                if (book != null)
                {
                    BookD.Categories = book.BookCategories.Select(s => s.Category);
                }
            }
        }
    }

}
   
