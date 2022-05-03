using Identity.DAL;
using Identity.HotChocolateGQL.GraphQL;
using Identity.HotChocolateGQL.GraphQL.Roles;
using Identity.HotChocolateGQL.GraphQL.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.HotChocolateGQL.Infrastructure.DependencyInjections;

public static class ServiceExtentions
{
    public static IServiceCollection AddIdentityDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextFactory<IdentityDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }

    public static IServiceCollection AddGraphQlConfiguration(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType<IdentityQuery>()
            .AddMutationType<IdentityMutation>()
            // .AddSubscriptionType<Subscription>()
            .AddType<UserType>()
            .AddType<AddUserInputType>()
            .AddType<AddUserPayloadType>()
            .AddType<RoleType>()
            //.AddType<AddCommandInputType>()
            //.AddType<AddCommandPayloadType>()
            .AddFiltering()
            .AddSorting();
        //.AddInMemorySubscriptions();

        return services;
    }
}
