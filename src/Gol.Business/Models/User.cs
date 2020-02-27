using System;

namespace Gol.Business.Models
{
    public class User : Entity
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
