using Fiap.Criptografia.Web.Models;
using System.Web.Mvc;

namespace Fiap.Criptografia.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("login")]
        public ActionResult Login(string nome, string senha)
        {
            var usuario = Autenticar(nome, senha);

            if (usuario != null)
            {
                TempData["Sucesso"] = "Usuário Logado";
            }
            else
            {
                TempData["Erro"] = "Usuário ou senha inválidos";
            }

            return RedirectPermanent("/");
        }

        public Usuario Autenticar(string nome, string senha)
        {
            var usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.ObterUsuario(nome);

            if (usuario == null)
                return null;

            var cripto = Crypto.Criptografar(usuario.Salt, senha);

            if (usuario.Senha != cripto)
                return null;

            return usuario;

        }
    }
}