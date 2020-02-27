using AutoMapper;
using Gol.Api.ViewModels;
using Gol.Business.Intefaces;
using Gol.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Gol.Api.Controllers
{
    [Route("api/travel")]
    public class TravelController : MainController
    {
        private readonly ITravelService _travelService;
        private readonly IMapper _mapper;
        private readonly ITravelRepository _travelRepository;

        public TravelController(INotificador notificador,
                                  ITravelService travelService,
                                  IMapper mapper,
                                  ITravelRepository travelRepository) : base(notificador)
        {
            _travelService = travelService;
            _mapper = mapper;
            _travelRepository = travelRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelViewModel>>> ObterTodos()
        {
            return CustomResponse(_mapper.Map<IEnumerable<TravelViewModel>>(await _travelRepository.ObterTodos()));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TravelViewModel>> ObterPorId(Guid id)
        {
            var obj = await _travelRepository.ObterViagemPorId(id);
            var aux = obj.DataViagem.ToString("yyyy-MM-dd'T'HH:mm");
            var result = _mapper.Map<TravelViewModel>(obj);
            result.DataViagem = aux;

            return CustomResponse(_mapper.Map<TravelViewModel>(result));
        }

        [HttpPost]
        public async Task<ActionResult<TravelViewModel>> Adicionar(TravelViewModel travelViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            Convert.ToDateTime(travelViewModel.DataViagem);
            travelViewModel.TravelId = Guid.NewGuid();
            await _travelService.Adicionar(_mapper.Map<Travel>(travelViewModel));

            return CustomResponse(travelViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, TravelViewModel travelViewModel)
        {
            if (id != travelViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var viagemAtualizacao = await _travelRepository.ObterViagemPorId(id);

            viagemAtualizacao.Nome = travelViewModel.Nome;
            viagemAtualizacao.Origem = travelViewModel.Origem;
            viagemAtualizacao.Destino = travelViewModel.Destino;
            viagemAtualizacao.DataViagem = Convert.ToDateTime(travelViewModel.DataViagem);


            await _travelService.Atualizar(_mapper.Map<Travel>(viagemAtualizacao));

            return CustomResponse(travelViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TravelViewModel>> Excluir(Guid id)
        {
            var travel = await _travelRepository.ObterViagemPorId(id);

            if (travel == null) return NotFound();

            await _travelService.Remover(travel);

            return CustomResponse(travel);
        }
    }
}