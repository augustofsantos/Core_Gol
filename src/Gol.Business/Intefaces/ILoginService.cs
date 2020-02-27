using Gol.Business.Models;
using System;
using System.Threading.Tasks;

namespace Gol.Business.Intefaces
{
    public interface ILoginService : IDisposable
    {
        Task Adicionar(User login);
    }
}