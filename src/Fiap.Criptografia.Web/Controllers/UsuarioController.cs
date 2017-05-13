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
        public ActionResult Cadastro(string nome, string senha)
        {
            var usuario = new Usuario(nome);
            usuario.DefinirSenha(senha);

            var usuarioRepository = new UsuarioRepository();
            usuarioRepository.Registrar(usuario);

            return Redirect("/");
        }
    }
}