using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.BusinessLayer.Models;
using Tasks.BusinessLayer.Services.Requests;
using Tasks.BusinessLayer.Services.Responses;

namespace Tasks.BusinessLayer.Services;

public interface ITokenService
{
    Task<Tuple<string, string>> GenerateTokenAsync(int userId);
    Task<ValidateRefreshTokenResponse> ValidateRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest);
    Task<bool> RemoveRefreshTokenAsync(User user);
}
