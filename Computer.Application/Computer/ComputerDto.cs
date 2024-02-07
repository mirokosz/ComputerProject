using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Computer.Application.Computer
{
    public class ComputerDto
    {
        public string Name { get; set; } = default!;
        public string Producer { get; set; } = default!;
        public string CPU { get; set; } = default!;
        public string Memory { get; set; } = default!;
        public string GPU { get; set; } = default!;

        public string? EncodedName { get; set; }     

    }
}
