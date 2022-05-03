using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using Identity.DAL;
using Identity.DAL.Models;
using Identity.HotChocolateGQL.GraphQL.Users;

namespace Identity.HotChocolateGQL.GraphQL;

[GraphQLDescription("Represents the mutations available.")]
public class IdentityMutation
{
    [UseDbContext(typeof(IdentityDbContext))]
    [GraphQLDescription("Adds a platform.")]
    public async Task<AddUserPayload> AddUserAsync(
        AddUserInputs input,
        [ScopedService] IdentityDbContext context,
        // [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken
    )
    {
        Role role = context.Roles.FirstOrDefault(r => r.Name.ToLower()
                                                            .Equals(input.RoleName.ToLower()));

        var user = new User
        {
            Id = default,
            FirstName = input.FirstName,
            LastName = input.LastName,
            Roles = role is not null ? new List<Role> { role } : null,
    };

        context.Users.Add(user);
        await context.SaveChangesAsync(cancellationToken);
        
        //await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), user, cancellationToken);

        return new AddUserPayload(user);
    }

    // [UseDbContext(typeof(IdentityDbContext))]
    // [GraphQLDescription("Adds a role.")]
    // public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input,
    //     [ScopedService] AppDbContext context)
    // {
    //     var command = new Command
    //     {
    //         HowTo = input.HowTo,
    //         CommandLine = input.CommandLine,
    //         PlatformId = input.PlatformId
    //     };

    //     context.Commands.Add(command);
    //     await context.SaveChangesAsync();

    //     return new AddCommandPayload(command);
    // }
}

