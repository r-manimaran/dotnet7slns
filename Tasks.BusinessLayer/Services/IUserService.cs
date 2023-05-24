using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.BusinessLayer.Services.Requests;
using Tasks.BusinessLayer.Services.Responses;

namespace Tasks.BusinessLayer.Services;

public interface IUserService
{
    Task<SignupResponse> SignupAsync(SignupRequest signupRequest);
    Task<TokenResponse> LoginAsync(LoginRequest loginRequest);
    Task<LogoutResponse> LogoutAsync(int userId);
}
