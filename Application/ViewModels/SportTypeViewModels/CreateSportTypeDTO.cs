using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.SportTypeViewModels
{
    public class CreateSportTypeDTO
    {
        public string SportName { get; set; }
        public string Icon { get; set; }
        public double CostRate { get; set; }
    }
}
