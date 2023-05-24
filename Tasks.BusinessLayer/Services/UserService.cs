using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.BusinessLayer.Services.Requests;
using Tasks.BusinessLayer.Services.Responses;

namespace Tasks.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        public Task<TokenResponse> LoginAsync(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public Task<LogoutResponse> LogoutAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<SignupResponse> SignupAsync(SignupRequest signupRequest)
        {
            throw new NotImplementedException();
        }
    }
}
