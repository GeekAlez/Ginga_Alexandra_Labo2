using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ginga_Alexandra_Labo2.Models;

namespace Ginga_Alexandra_Labo2.Data
{
    public class Ginga_Alexandra_Labo2Context : DbContext
    {
        public Ginga_Alexandra_Labo2Context (DbContextOptions<Ginga_Alexandra_Labo2Context> options)
            : base(options)
        {
        }

        public DbSet<Ginga_Alexandra_Labo2.Models.Book> Book { get; set; } = default!;

        public DbSet<Ginga_Alexandra_Labo2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Ginga_Alexandra_Labo2.Models.Author>? Author { get; set; }

        public DbSet<Ginga_Alexandra_Labo2.Models.Category>? Category { get; set; }

        public DbSet<Ginga_Alexandra_Labo2.Models.Member>? Member { get; set; }

        public DbSet<Ginga_Alexandra_Labo2.Models.Borrowing>? Borrowing { get; set; }
    }
}
