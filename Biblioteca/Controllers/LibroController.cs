using Capa_Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Authorize]
    public class LibroController : Controller
    {
        private readonly IUsuario mUsuario;
        private readonly ILibro mLibro;
        public LibroController(IUsuario mUsuario, ILibro mLibro)
        {
            this.mUsuario = mUsuario;
            this.mLibro = mLibro;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = mLibro.Details(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            var claim = HttpContext.User.Claims;
            Usuario user = mUsuario.LoggedUser(claim);
            var libroId = mLibro.AddComentario(comentario, user.Id);

            return RedirectToAction("Details", new { id = libroId });
        }
    }
}
