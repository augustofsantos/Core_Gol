using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gol.Business.Intefaces;
using Gol.Business.Models;
using Gol.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gol.Data.Repository
{
    public class TravelRepository : Repository<Travel>, ITravelRepository
    {
        public TravelRepository(MeuDbContext context) : base(context) { }

        public async Task<Travel> ObterViagemPorId(Guid id)
        {
            return await BuscaUnica(p => p.Id == id);
        }
    }
}