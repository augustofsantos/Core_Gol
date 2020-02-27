using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gol.Business.Models;

namespace Gol.Business.Intefaces
{
    public interface ILoginRepository : IRepository<User>
    {
        Task<User> ObterUsuario(string Email, string Senha);
    }
}