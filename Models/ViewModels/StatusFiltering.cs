using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class StatusFiltering
    {
        public eStatus Status { get; set; }

        IEnumerable<Order> Orders { get; set; }
    }
}
