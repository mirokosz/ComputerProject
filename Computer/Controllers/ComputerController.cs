using Computer.Application.Computer;
using Computer.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Computer.Controllers
{
    public class ComputerController : Controller
    {
        private readonly IComputerService _computerService;
        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ComputerDto computer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _computerService.Create(computer);
            return RedirectToAction(nameof(Create));    
        }
    }
}
