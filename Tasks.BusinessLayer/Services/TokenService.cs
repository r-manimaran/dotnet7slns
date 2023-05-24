using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.BusinessLayer.Models;
using Tasks.BusinessLayer.Services.Requests;
using Tasks.BusinessLayer.Services.Responses;

namespace Tasks.BusinessLayer.Services;

public class TokenService : ITokenService
{
    public Task<Tuple<string, string>> GenerateTokenAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveRefreshTokenAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<ValidateRefreshTokenResponse> ValidateRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest)
    {
        throw new NotImplementedException();
    }
}
