using GraphQL.Types;
using Identity.DAL.Models;
using Identity.NativeGQL.GraphQL.Users;

namespace Identity.NativeGQL.GraphQL;

public class IdentityQuery : ObjectGraphType
{

    // TODO inject DbContext and change our face returns to real
    public IdentityQuery()
    {
        // Determinate name for our users 
        // to return all our users
        Field<ListGraphType<UserType>>("users",
        resolve: context => new List<User>{
            new User
            {
                Id = 1,
                FirstName = "Alexander",
                LastName = "Nasterovich"
            }
        });

        // Return User by Id 
        Field<UserType>(
                "users",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => new User
                {
                    Id = 1,
                    FirstName = "Alexander",
                    LastName = "Nasterovich"
                });
        
    }
}