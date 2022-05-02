using HotChocolate;
using HotChocolate.Data;
using Identity.DAL;
using Identity.DAL.Models;

namespace Identity.HotChocolateGQL.GraphQL;

[GraphQLDescription("Represents the queries available.")]
public class IdentityQuery
{
    [UseDbContext(typeof(IdentityDbContext))]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Gets the queryable users.")]
    public IQueryable<User> GetUsers([ScopedService] IdentityDbContext context)
    {
        return context.Users;
    }


    [UseDbContext(typeof(IdentityDbContext))]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Gets the queryable roles.")]
    public IQueryable<Role> GetRoles([ScopedService] IdentityDbContext context)
    {
        return context.Roles;
    }
}
