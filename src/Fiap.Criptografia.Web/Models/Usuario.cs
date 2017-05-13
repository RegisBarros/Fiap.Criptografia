using System;

namespace Fiap.Criptografia.Web.Models
{
    public class Usuario
    {
        public Usuario(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Salt { get; set; }

        public void DefinirSenha(string senha)
        {
            Salt = Crypto.GerarSalt();

            Senha = Crypto.Criptografar(Salt, senha);
        }
    }
}