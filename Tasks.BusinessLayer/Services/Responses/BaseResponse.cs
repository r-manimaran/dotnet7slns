using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tasks.BusinessLayer.Services.Responses;

public class BaseResponse
{
    [JsonIgnore()]
    public bool IsSuccess { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ErrorCode { get; set; }
    [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
    public string Error { get; set; }
}
