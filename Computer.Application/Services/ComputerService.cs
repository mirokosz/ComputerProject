using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computer.Domain.Interfaces;
using Computer.Application.Computer;
using AutoMapper;

namespace Computer.Application.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IComputerRepository _computerRepository;
        private readonly IMapper _mapper;
        public ComputerService(IComputerRepository computerRepository, IMapper mapper)
        {
            _computerRepository = computerRepository;
            _mapper = mapper;
        }

        public async Task Create(ComputerDto computerDto)
        {
            var computer = _mapper.Map<Domain.Entities.Computer>(computerDto);  

            computer.EncodeName();
            await _computerRepository.Create(computer);
        }
    }
}
