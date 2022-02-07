using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BooksModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Column("Book_Name")]
        [Required]
        public string  Name { get; set; }
        
        [Required]
        [Column("Book_Description")]
        public string Description { get; set; }

        [Required]
        [Column("Book_Price",TypeName ="decimal(10,2)")]
        public decimal price  { get; set; }
        
        [Column("Published_Date")]
        public DateTime PublishedOn { get; set; }
        
        [Column("No_of_Pages")]
        public int Pages { get; set; }
        
        [Column("Book_Rating", TypeName = "decimal(5,2)")]
        public decimal Rating { get; set; }

    }
}
