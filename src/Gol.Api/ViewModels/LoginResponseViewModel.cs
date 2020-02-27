using System.Collections.Generic;

namespace Gol.Api.ViewModels
{
    public partial class LoginResponseViewModel
    {
        public class Claim
        {
            public string Value { get; set; }
            public string Type { get; set; }
        }

        public class UserToken
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public IEnumerable<Claim> Claims { get; set; }
        }

        public class LoginResponse
        {
            public string AccessToken { get; set; }
            public double ExpiresIn { get; set; }
            public UserToken UserToken { get; set; }
        }
    }
}