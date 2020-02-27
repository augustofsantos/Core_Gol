using AutoMapper;
using Gol.Api.ViewModels;
using Gol.Business.Intefaces;
using Gol.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gol.Api.Controllers
{
    [Route("api/user")]
    public class LoginController : MainController
    {
        public IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILoginRepository _LoginRepository;

        public LoginController(IConfiguration config,
                                      IMapper mapper,
                                      INotificador notificador,
                                      ILoginRepository loginRepository) : base(notificador)
        {
            _configuration = config;
            _mapper = mapper;
            _LoginRepository = loginRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserViewModel>> Login(UserViewModel loginViewModel)
        {
            if (loginViewModel != null && loginViewModel.Email != null && loginViewModel.Senha != null)
            {
                var user = await GetUser(loginViewModel);

                if (user != null)
                {
                    var token = GeraToken(GeraClaims(user));

                    var response = new LoginResponseViewModel.LoginResponse
                    {
                        AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                        ExpiresIn = 0,
                        UserToken = new LoginResponseViewModel.UserToken
                        {
                            Id = user.UsuarioId.ToString(),
                            Email = user.Email
                        }
                    };

                    return CustomResponse(response);
                }
                else
                {
                    return CustomResponse();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<UserViewModel>> Adicionar(UserViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            loginViewModel.UsuarioId = Guid.NewGuid();
            await _LoginRepository.Adicionar(_mapper.Map<User>(loginViewModel));
            return CustomResponse(loginViewModel);
        }

        private async Task<UserViewModel> GetUser(UserViewModel login)
        {
            var response = _mapper.Map<UserViewModel>(await _LoginRepository.ObterUsuario(login.Email, login.Senha));

            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        private Claim[] GeraClaims(UserViewModel user)
        {
            return new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", user.UsuarioId.ToString()),
                new Claim("Name", user.Nome),
                new Claim("Email", user.Email)
            };
        }

        private JwtSecurityToken GeraToken(Claim[] claims)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
        }
    }
}
