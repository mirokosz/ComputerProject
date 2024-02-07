





using Computer.Application.Computer;

namespace Computer.Application.Services
{
    public interface IComputerService
    {
        Task Create(ComputerDto computer);
    }
}