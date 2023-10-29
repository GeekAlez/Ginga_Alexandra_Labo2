using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Ginga_Alexandra_Labo2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]
        public string Title { get; set; }

        public Author? Author { get; set; }
        public int? AuthorID { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        
        public DateTime PublishingDate { get; set; }

        public int? PublisherID { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
        public Publisher? Publisher { get; set; }
    } //navigation property

    

}
