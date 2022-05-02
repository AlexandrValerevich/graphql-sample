using HotChocolate;
using HotChocolate.Types;
using Identity.DAL;
using Identity.DAL.Models;

namespace Identity.HotChocolateGQL.GraphQL.Users;

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        base.Configure(descriptor);

        // Description whole object
        descriptor.Description("Represents our user.");

        descriptor.Field(u => u.Id)
                  .Description("Represents the unique Id for the platphorm.");

        descriptor.Field(u => u.FirstName)
                  .Description("Represents the First Name of user.");

        descriptor.Field(u => u.LastName)
                  .Description("Represents the Last Name of user.");

        descriptor.Field(u => u.Roles)
                .ResolveWith<Resolvers>(p => p.GetRoles(default!, default!))
                .UseDbContext<IdentityDbContext>()
                .Description("This is the list of roles.");
    }

    private class Resolvers
    {
        public IQueryable<Role> GetRoles(User user, [ScopedService] IdentityDbContext context)
        {
            return context.Roles.Where(r => r.Users.Contains(user));
        }
    }
}