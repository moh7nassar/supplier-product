using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(maximumLength:40, MinimumLength =3, ErrorMessage ="Please enter Supplier's name.")]
        [Display(Prompt ="Please enter at least 3 characters.")]
        [Column("nvarchar(40)")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        //Navigation
        public ICollection<Order> Orders { get; set; }
    }
}
