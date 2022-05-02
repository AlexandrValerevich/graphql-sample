
using Identity.DAL;

namespace Identity.HotChocolateGQL.Infrastructure.Helpers;

public static class SeedDb
{
    public static WebApplication SeedIdentityDb(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<IdentityDbContext>();
        context.SeedDb();
 
        return app;
    }
}