using HotChocolate;
using HotChocolate.Types;
using Identity.DAL;
using Identity.DAL.Models;

namespace Identity.HotChocolateGQL.GraphQL.Roles;

public class RoleType : ObjectType<Role>
{
    protected override void Configure(IObjectTypeDescriptor<Role> descriptor)
    {
        base.Configure(descriptor);

        // Description whole object
        descriptor.Description("Represents our user.");

        descriptor.Field(r => r.Id)
                  .Description("Represents the unique Id for the role.");

        descriptor.Field(r => r.Name)
                  .Description("Represents the Name of role.");

        descriptor.Field(r => r.Users)
                .ResolveWith<Resolvers>(p => p.GetUsers(default!, default!))
                .UseDbContext<IdentityDbContext>()
                .Description("This is the list of user who have this role.");
    }

    private class Resolvers
    {
        public IQueryable<User> GetUsers(Role role, [ScopedService] IdentityDbContext context)
        {
            return context.Users.Where(u => u.Roles.Contains(role));
        }
    }
}