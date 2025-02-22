using Caarta.Models;
using Caarta.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Caarta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDeckService _deckService;

        public HomeController(ILogger<HomeController> logger, IDeckService deckService)
        {
            _logger = logger;
            _deckService = deckService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _deckService.GetAllAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
