using AutoMapper;
using MediatR;
using Computer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Application.Computer.Queries.GetAllComputers
{
    internal class GetAllComputersQueryHandler : IRequestHandler<GetAllComputersQuery, IEnumerable<ComputerDto>>
    {
        private readonly IComputerRepository _computerRepository;
        private readonly IMapper _mapper;

        public GetAllComputersQueryHandler(IComputerRepository computerRepository, IMapper mapper)
        {
            _computerRepository = computerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ComputerDto>> Handle(GetAllComputersQuery request, CancellationToken cancellationToken)
        {
            var computers = await _computerRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ComputerDto>>(computers);


            return dtos;
        }
    }
}
