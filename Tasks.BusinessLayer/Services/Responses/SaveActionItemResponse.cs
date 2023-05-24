using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.BusinessLayer.Models;

namespace Tasks.BusinessLayer.Services.Responses;

public class SaveActionItemResponse:BaseResponse
{
    public ActionItem ActionItem { get; set; }
}
