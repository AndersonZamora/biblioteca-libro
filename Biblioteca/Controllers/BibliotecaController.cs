using Capa_Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        private readonly IBiblioteca mBiblioteca;
        private readonly IUsuario mUsuario;
        public BibliotecaController(IBiblioteca mBiblioteca, IUsuario mUsuario)
        {

            this.mBiblioteca = mBiblioteca;
            this.mUsuario = mUsuario;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var claim = HttpContext.User.Claims;

            Usuario user = mUsuario.LoggedUser(claim);

            var model = mBiblioteca.GetList(user.Id);

            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            var claim = HttpContext.User.Claims;

            Usuario user = mUsuario.LoggedUser(claim);

            var biblioteca = mBiblioteca.CretateNew(libro, user.Id);

            mBiblioteca.AddDB(biblioteca);

            TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            var claim = HttpContext.User.Claims;

            Usuario user = mUsuario.LoggedUser(claim);

            mBiblioteca.MarcarComoLeyendo(libroId, user.Id);

            TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            var claim = HttpContext.User.Claims;

            Usuario user = mUsuario.LoggedUser(claim);

            mBiblioteca.MarcarComoTerminado(libroId, user.Id);

            TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }
    }
}
