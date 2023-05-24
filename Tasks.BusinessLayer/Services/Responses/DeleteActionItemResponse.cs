using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tasks.BusinessLayer.Services.Responses;

public class DeleteActionItemResponse:BaseResponse
{
    [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingDefault)]
    public int ActionItemId { get; set; }
}
