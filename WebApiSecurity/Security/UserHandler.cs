using Microsoft.AspNetCore.Authorization;

namespace WebApiSecurity.Security;

public class UserHandler : AuthorizationHandler<UserRequirement>
{
    private readonly AppRepository _appRepo;

    public UserHandler(AppRepository appRepo)
    {
        _appRepo = appRepo;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRequirement requirement)
    {
        var httpContext = (HttpContext)context.Resource!;
        var userExists = httpContext.Request.RouteValues.TryGetValue("id", out object? userId);

        if (userExists)
        {
            //Get the userId from  the logged in user Claims
            var userIdFromClaims = httpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            int parsedUserId = 0;
            if (userIdFromClaims is not null)
                parsedUserId = int.Parse(userIdFromClaims);


            var user = _appRepo.Users.FirstOrDefault(u => u.Id == parsedUserId);
            if (user!=null && user.Id == parsedUserId) context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }

}
