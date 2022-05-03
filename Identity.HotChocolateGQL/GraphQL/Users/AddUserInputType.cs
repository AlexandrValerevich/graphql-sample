using HotChocolate.Types;

namespace Identity.HotChocolateGQL.GraphQL.Users;


// We can create folders with Command and Query names 
// And move our Query and Mutatuion into it
// for implementin CQRS (Command and Query Resposibility Segregation)
public class AddUserInputType : ObjectType<AddUserInputs>
{
    protected override void Configure(IObjectTypeDescriptor<AddUserInputs> descriptor)
    {
        Description = "Represents the input to add for a user.";

        descriptor.Field(userInput => userInput.FirstName)
                  .Description("Represents the new user First Name.");

        descriptor.Field(userInput => userInput.LastName)
                  .Description("Represents the new user Last Name.");

        descriptor.Field(userInput => userInput.RoleName)
                  .Description("Represents the role of new user");
        
        base.Configure(descriptor);
    }
}
