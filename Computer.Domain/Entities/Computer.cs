using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Domain.Entities
{
    public class Computer
    {
        public required int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Producer { get; set; } = default!;
        public DateTime ProductionDate { get; set; }
        public ComputerSpecificationDetails SpecificationDetails { get; set; } = default!;
        public string EncodedName { get; private set; } = default!;
        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");
    }
}
