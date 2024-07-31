using Katalog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Katalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/Resimler/{folderName}")]
        public IActionResult Resimler(string folderName)
        {
            if (string.IsNullOrWhiteSpace(folderName))
            {
                return BadRequest("Klasör adý belirtilmedi.");
            }


            var _imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", folderName);

            if (!Directory.Exists(_imagesPath))
            {
                return NotFound("Klasör bulunamadý.");
            }

            // Get image files
            var imageFiles = Directory.GetFiles(_imagesPath)
                .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png"))
                .Select(file => $"/images/{folderName}/{Path.GetFileName(file)}")
                .ToList();
            ViewData["FolderName"] = folderName;
            return View(imageFiles);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
