using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.BusinessLayer.Models;
using Tasks.BusinessLayer.Services.Responses;

namespace Tasks.BusinessLayer.Services;

public class ActionItemService : IActionItemService
{
    private readonly AppDbContext _appDbContext;

    public ActionItemService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <summary>
    /// Get All ActioItem for the user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<GetActionItemsResponse> GetActionItems(int userId)
    {
        var actionItems = await _appDbContext.ActionItems.Where(o => o.UserId == userId).ToListAsync();
        
        if(actionItems.Count == 0)
        {
            return new GetActionItemsResponse
            {
                IsSuccess = false,
                Error = "No ActionItems found for this user",
                ErrorCode = "T04"
            };
        }
        return new GetActionItemsResponse
        {
            IsSuccess=true,
            ActionItems = actionItems
        };
    }

    /// <summary>
    /// Save ActionItem to Database
    /// </summary>
    /// <param name="actionItem"></param>
    /// <returns></returns>
    public async Task<SaveActionItemResponse> SaveActionItem(ActionItem actionItem)
    {
        await _appDbContext.ActionItems.AddAsync(actionItem);
        var saveResponse = await _appDbContext.SaveChangesAsync();
        if(saveResponse >= 0)
        {
            return new SaveActionItemResponse
            {
                IsSuccess=true,
                ActionItem = actionItem
            };
        }
        return new SaveActionItemResponse
        {
            IsSuccess = false,
            Error = "Unable to save ActionItem",
            ErrorCode = "T05"
        };
    }

    /// <summary>
    /// Delete the ActionItem Associated with the user
    /// </summary>
    /// <param name="actionItemId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<DeleteActionItemResponse> DeleteActionItem(int actionItemId, int userId)
    {
        var actionItem = await _appDbContext.ActionItems.FindAsync(actionItemId);
        if (actionItem == null)
        {
            return new DeleteActionItemResponse
            {
                IsSuccess = false,
                Error = "ActionItem not found",
                ErrorCode = "T01"
            };

        }
        if (actionItem.UserId != userId)
            {
                return new DeleteActionItemResponse
                {
                    IsSuccess = false,
                    Error = "You don't have access to delete this ActionItem",
                    ErrorCode = "T02"
                };
            }

            _appDbContext.ActionItems.Remove(actionItem);
            var saveResponse = await _appDbContext.SaveChangesAsync();
            if (saveResponse >= 0)
            {
                return new DeleteActionItemResponse
                {
                    IsSuccess=true,
                    ActionItemId = actionItem.Id
                };
            }
            return new DeleteActionItemResponse
            {
                IsSuccess = false,
                Error="Unable to Delete the actionItem",
                ErrorCode="T03"
            };
        }
    }
