
using System.Threading.Tasks;
using GameZone.Services;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IDeviceService _deviceService;
        private readonly IGameService _gameService;

        public GamesController(ICategoryService categoryService
                                ,IDeviceService deviceService
                                ,IGameService gameService)
        {
            this._categoryService = categoryService;
            this._deviceService = deviceService;
            _gameService = gameService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetCategoriesOrdereds();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            var devices = await _deviceService.GetAll();
            ViewBag.Devices = new SelectList(devices, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameVM model,List<IFormFile> files)
        {
            
            if (ModelState.IsValid)
            {

                string CoverPath = await _gameService.GameCoverPath(model.Cover);
                var Game = new Game()
                {
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    Cover = CoverPath,
                    Description = model.Description,
                    GameDevices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
                };
              await  _gameService.Insert(Game);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryService.GetCategoriesOrdereds();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            var devices = await _deviceService.GetAll();
            ViewBag.Devices = new SelectList(devices, "Id", "Name");
            return View(model);
        }
    }
}
