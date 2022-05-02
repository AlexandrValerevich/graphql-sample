using GraphQL.Types;
using Identity.DAL.Models;
using Identity.NativeGQL.GraphQL.Roles;

namespace Identity.NativeGQL.GraphQL.Users;

public class UserType : ObjectGraphType<User>
{
    public UserType()
    {
        Name = "user";
        Description = "User who existe in our system.";

        Field(u => u.Id).Description("The ID of the User.");
        Field(u => u.FirstName).Description("The First Name of User.");
        Field(u => u.LastName).Description("The Last Name of User.");
        
        Field<ListGraphType<RolesType>>();
    }
}