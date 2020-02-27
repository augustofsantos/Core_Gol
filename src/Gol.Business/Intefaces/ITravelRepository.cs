using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gol.Business.Models;

namespace Gol.Business.Intefaces
{
    public interface ITravelRepository : IRepository<Travel> 
    {
        Task<Travel> ObterViagemPorId(Guid travelId);
    }
}