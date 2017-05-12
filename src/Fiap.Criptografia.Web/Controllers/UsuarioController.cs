using Fiap.Criptografia.Web.Models;
using System.Web.Mvc;

namespace Fiap.Criptografia.Web.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet, Route("cadastro")]
        public ViewResult Cadastro()
        {
            return View();
        }

        [HttpPost, Route("cadastro")]
        public ActionResult Cadastro(Usuario usuario)
        {
            var usuarioRepository = new UsuarioRepository();
            usuarioRepository.Registrar(usuario);

            return Redirect("/");
        }
    }
}