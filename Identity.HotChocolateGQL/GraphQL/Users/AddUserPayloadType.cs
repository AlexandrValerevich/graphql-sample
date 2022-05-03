using HotChocolate.Types;

namespace Identity.HotChocolateGQL.GraphQL.Users;

public class AddUserPayloadType : ObjectType<AddUserPayload>
{
    protected override void Configure(IObjectTypeDescriptor<AddUserPayload> descriptor)
    {

        Name = "addUserPayload";
        Description = "Represents the payload to return for an user.";

        descriptor.Field(p => p.User).Description("Represents the added user.");
        
        base.Configure(descriptor);
    }
}
