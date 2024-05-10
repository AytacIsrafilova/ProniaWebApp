using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using ProniaWebApp.DAL;
using ProniaWebApp.Models;

namespace ProniaWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        AppDbContext _dbContext;
        IWebHostEnvironment _environment;
        public SliderController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public IActionResult Index()
        {
            List<Slider> sliders=_dbContext.Sliders.ToList();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {

            if (!slider.ImgFile.ContentType.Contains("/image"))
            {
                ModelState.AddModelError("ImgFile", "Formati duzgun daxil edin!");
                return View();
            }
            string filename=slider.ImgFile.FileName;
            string path = _environment.WebRootPath = @"\Upload\Slider" + filename;

            using (FileStream stream= new FileStream(path+filename, FileMode.Create))
            {
                slider.ImgFile.CopyTo(stream);
            }
            slider.ImgUrl = filename;

            if (!ModelState.IsValid)
            {
                return View();
            }
            _dbContext.Sliders.Add(slider);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {

            var slider = _dbContext.Sliders.FirstOrDefault(x => x.Id == id);
            string path = _environment.WebRootPath = @"\Upload\Slider" + slider.ImgUrl;
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            _dbContext.Sliders.Remove(slider);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
