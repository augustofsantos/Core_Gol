using System;
using System.Threading.Tasks;
using Gol.Business.Intefaces;
using Gol.Business.Models;

namespace Gol.Business.Services
{
    public class TravelService : BaseService, ITravelService
    {
        private readonly ITravelRepository _travelRepository;

        public TravelService(ITravelRepository travelRepository,
                              INotificador notificador) : base(notificador)
        {
            _travelRepository = travelRepository;
        }

        public async Task Adicionar(Travel Travel)
        {
            if (Travel == null) return;

            await _travelRepository.Adicionar(Travel);
        }

        public async Task Atualizar(Travel Travel)
        {
            if (Travel == null) return;

            await _travelRepository.Atualizar(Travel);
        }

        public async Task Remover(Travel Travel)
        {
            await _travelRepository.Remover(Travel);
        }

        public void Dispose()
        {
            _travelRepository?.Dispose();
        }
    }
}