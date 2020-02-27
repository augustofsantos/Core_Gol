using Gol.Business.Intefaces;
using Gol.Business.Models;
using Gol.Data.Context;
using System.Threading.Tasks;

namespace Gol.Data.Repository
{
    public class LoginRepository : Repository<User>, ILoginRepository
    {
        public LoginRepository(MeuDbContext context) : base(context) { }

        public async Task<User> ObterUsuario(string Email, string Senha)
        {
            return await BuscaUnica(p => p.Email == Email && p.Senha == Senha);
        }
    }
}