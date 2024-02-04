using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Domain.Entities
{
    public class ComputerSpecificationDetails
    {
        public string CPU { get; set; } = default!;
        public string Memory { get; set; } = default!;
        public string GPU { get; set; } = default!;
    }
}
