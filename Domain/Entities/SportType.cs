using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SportType : BaseEntity
    {
        public string SportName { get; set; }
        public string? Icon { get; set; }
        public double? CostRate { get; set; }
    }
}
