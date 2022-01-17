using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Display(Name ="Supplier")]
        public int SupplierId { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        public int Quantity { get; set; }

        [Display(Name ="Total Price")]
        public double TotalPrice { get; set; }

        public eStatus Status { get; set; }

        public Supplier Supplier { get; set; }

        public Product Product { get; set; }
    }
}
