using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class SupplierReport
    {

        public string Name { get; set; }

        public IEnumerable<Supplier> Suppliers { get; set; }
    }
}
