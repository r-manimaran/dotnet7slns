using Microsoft.EntityFrameworkCore;
using System;

namespace BackgroundWithDB;

public class CleanupService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    //private readonly AppDbContext _context;

    //public CleanupService(AppDbContext context)
    //{
    //  //  _context = context;
    //}
    public CleanupService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        /*while(!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(10),stoppingToken);
            var expiredOrders = await _context.Orders
                                            .Where(o => o.Status == OrderStatus.Expired)
                                            .ToListAsync(stoppingToken);
            if(expiredOrders.Count > 0)
            {
                _context.Orders.RemoveRange(expiredOrders);
                await _context.SaveChangesAsync(stoppingToken);
            }
        }*/

        //correct Approach
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            using var scope = _serviceProvider.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var expiredOrders = await _context.Orders
                                            .Where(o => o.Status == OrderStatus.Expired)
                                            .ToListAsync(stoppingToken);
            if (expiredOrders.Count > 0)
            {
                _context.Orders.RemoveRange(expiredOrders);
                await _context.SaveChangesAsync(stoppingToken);
            }
        }

    }
}
