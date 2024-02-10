using Computer.Application.Computer;
using Computer.Application.Computer.Queries.GetAllComputers;
using Computer.Application.Computer.Commands.CreateComputer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Computer.Application.Computer.Queries.GetComputerByEncodedName;
using Computer.Application.Computer.Commands.EditComputer;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Computer.Controllers
{
    public class ComputerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ComputerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            var computers = await _mediator.Send(new GetAllComputersQuery());
            return View(computers);
        }


        [Route("Computer/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetComputerByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("Computer/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetComputerByEncodedNameQuery(encodedName));
            EditComputerCommand model = _mapper.Map<EditComputerCommand>(dto);
            return View(model);
        }

        [HttpPost]
        [Route("Computer/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditComputerCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);

            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateComputerCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));    
        }
    }
}
