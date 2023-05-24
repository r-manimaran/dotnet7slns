using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.BusinessLayer.Services.Requests;

public class RefreshTokenRequest
{
    public int UserId { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
}
