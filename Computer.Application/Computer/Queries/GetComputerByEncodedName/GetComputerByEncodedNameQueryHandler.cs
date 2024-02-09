using AutoMapper;
using Computer.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Application.Computer.Queries.GetComputerByEncodedName
{
    public class GetComputerByEncodedNameQueryHandler : IRequestHandler<GetComputerByEncodedNameQuery, ComputerDto>
    {
        private readonly IComputerRepository _computerRepository;
        private readonly IMapper _mapper;

        public GetComputerByEncodedNameQueryHandler(IComputerRepository computerRepository, IMapper mapper)
        {
            _computerRepository = computerRepository;
            _mapper = mapper;
        }
        public async Task<ComputerDto> Handle(GetComputerByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var computer = await _computerRepository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<ComputerDto>(computer);

            return dto;
        }
    }
}
