using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;

namespace AspNetCore.CookieSample
{
    public static class UseAuthorizeMiddleware
    {

        public static IApplicationBuilder UseAuthorize(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    await next();
                }
                else
                {
                    var user = context.User;
                    if (user?.Identity?.IsAuthenticated ?? false)
                    {
                        await next();
                    }
                    else
                    {
                        await context.ChallengeAsync();
                    }
                }
            });

        }
    }
}
