using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace Fiap.Criptografia.Web.Models
{
    public class UsuarioRepository
    {
        private string _filePath = HostingEnvironment.MapPath(@"~/App_Data/usuario.json");

        internal List<Usuario> ObterUsuarios()
        {
            var json = File.ReadAllText(_filePath);

            var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);

            return usuarios;
        }

        internal void Registrar(Usuario usuario)
        {
            var usuarios = ObterUsuarios();

            if (usuarios == null)
                usuarios = new List<Usuario>();

            usuarios.Add(usuario);

            var json = JsonConvert.SerializeObject(usuarios, Formatting.Indented);

            File.WriteAllText(_filePath, json);
        }
    }
}