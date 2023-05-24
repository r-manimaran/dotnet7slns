using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.BusinessLayer.Models;
using Tasks.BusinessLayer.Services.Responses;

namespace Tasks.BusinessLayer.Services;

public interface IActionItemService
{
    Task<GetActionItemsResponse> GetActionItems(int userId);
    Task<SaveActionItemResponse> SaveActionItem(ActionItem actionItem);
    Task<DeleteActionItemResponse> DeleteActionItem(int actionItemId, int userId);
}
