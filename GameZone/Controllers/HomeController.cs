using System.Diagnostics;
using GameZone.Services;

namespace GameZone.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGameService gameService;

    public HomeController(ILogger<HomeController> logger,IGameService gameService)
    {
        _logger = logger;
        this.gameService = gameService;
    }

    public async Task<IActionResult> Index()
    {
        var x = await gameService.GamesWithCategoryAndDevices();
        return View(x);
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
