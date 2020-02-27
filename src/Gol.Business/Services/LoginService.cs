using Gol.Business.Intefaces;
using Gol.Business.Models;
using System.Threading.Tasks;

namespace Gol.Business.Services
{
    public class LoginService : BaseService, ILoginService
    {
        private readonly ILoginRepository _Login;

        public LoginService(ILoginRepository Login,
                              INotificador notificador) : base(notificador)
        {
            _Login = Login;
        }

        public async Task Adicionar(User login)
        {
            if (login == null) return;

            await _Login.Adicionar(login);
        }

        public void Dispose()
        {
            _Login?.Dispose();
        }
    }
}