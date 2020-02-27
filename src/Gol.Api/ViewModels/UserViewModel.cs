using System;
using System.ComponentModel.DataAnnotations;

namespace Gol.Api.ViewModels
{
    public class UserViewModel
    {
        public Guid UsuarioId { get; set; }
        
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
    }
}
