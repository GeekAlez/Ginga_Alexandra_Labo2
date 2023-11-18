﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ginga_Alexandra_Labo2.Data;
using Ginga_Alexandra_Labo2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ginga_Alexandra_Labo2.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class CreateModel :BookCategoriesPageModel
    {
        private readonly Ginga_Alexandra_Labo2.Data.Ginga_Alexandra_Labo2Context _context;

        public CreateModel(Ginga_Alexandra_Labo2.Data.Ginga_Alexandra_Labo2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            /* var authorList = _context.Author.Select(x => new
 {
 x.ID,
 FullName = x.LastName + " " + x.FirstName
 });
*/
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName");
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);

            return Page();
        }




        [BindProperty]
        public Book Book { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            Book.BookCategories = newBook.BookCategories;
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
