using AutoMapper;
using Computer.Application.Computer;
using Computer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computer.Application.Computer.Commands.EditComputer;

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

            CreateMap<Domain.Entities.Computer, ComputerDto>()
                .ForMember(dto => dto.GPU, opt => opt.MapFrom(src => src.SpecificationDetails.GPU))
                .ForMember(dto => dto.Memory, opt => opt.MapFrom(src => src.SpecificationDetails.Memory))
                .ForMember(dto => dto.CPU, opt => opt.MapFrom(src => src.SpecificationDetails.CPU));
            CreateMap<ComputerDto, EditComputerCommand>();

        }
    }
}
