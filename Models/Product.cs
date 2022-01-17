using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3, ErrorMessage = "Please enter Supplier's name.")]
        [Display(Prompt = "Please enter at least 3 characters.")]
        [Column("nvarchar(40)")]
        public string Title { get; set; }

        [DataType(DataType.Currency)]
        [Range(0.00, 1000.00, ErrorMessage = "Product's price should be no more than 1000!")]
        public double Price { get; set; }


        public string Photo { get; set; } = "headphone.png";

        public ICollection<Order> Orders { get; set; }
    }
}
