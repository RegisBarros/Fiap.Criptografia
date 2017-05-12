using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace Fiap.Criptografia.Web.Models
{
    public class UsuarioRepository
    {
        private string _filePath = HostingEnvironment.MapPath(@"~/App_Data/usuario.json");

        internal Usuario ObterUsuario(string nome, string senha)
        {
            var usuarios = ObterUsuarios();

            if (usuarios == null)
                return null;

            return usuarios.FirstOrDefault(u => u.Nome == nome && u.Senha == senha);
        }


        internal List<Usuario> ObterUsuarios()
        {
            var json = File.ReadAllText(_filePath);

            var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);

            return usuarios;
        }

        internal void Registrar(Usuario usuario)
        {
            var usuarios = ObterUsuarios();

            if (usuarios != null)
            {
                var maxId = usuarios.Max(p => p.Id);
                usuario.Id = maxId + 1;
            }
            else
            {
                usuarios = new List<Usuario>();
                usuario.Id = 1;
            }

            usuarios.Add(usuario);

            var json = JsonConvert.SerializeObject(usuarios, Formatting.Indented);

            File.WriteAllText(_filePath, json);
        }
    }
}