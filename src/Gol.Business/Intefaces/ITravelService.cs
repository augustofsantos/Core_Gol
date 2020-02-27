using System;
using System.Threading.Tasks;
using Gol.Business.Models;

namespace Gol.Business.Intefaces
{
    public interface ITravelService : IDisposable
    {
        Task Adicionar(Travel travel);
        Task Atualizar(Travel travel);
        Task Remover(Travel travel);
    }
}