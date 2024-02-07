using AutoMapper;
using Computer.Application.Computer;
using Computer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Application.Mappings
{
    public class ComputerMappingProfile : Profile
    {
        public ComputerMappingProfile()
        {
            CreateMap<ComputerDto, Domain.Entities.Computer>()
                .ForMember(e => e.SpecificationDetails, opt => opt.MapFrom(src => new ComputerSpecificationDetails()
                {
                    CPU = src.CPU,
                    Memory = src.Memory,
                    GPU = src.GPU,
                }));
        }
    }
}
