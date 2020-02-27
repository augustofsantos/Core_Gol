using System.Collections.Generic;
using Gol.Business.Notificacoes;

namespace Gol.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}