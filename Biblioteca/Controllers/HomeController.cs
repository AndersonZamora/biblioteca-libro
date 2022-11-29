using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILibro mLibro;
        public HomeController(ILibro mLibro)
        {
            this.mLibro = mLibro;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = mLibro.GetLibros();
            return View(model);
        }
    }
}