using GraphQL.Types;
using Identity.DAL.Models;
using Identity.NativeGQL.GraphQL.Users;

namespace Identity.NativeGQL.GraphQL.Roles;

public class RolesType : ObjectGraphType<Role>
{
    public RolesType()
    {

        Name = "role";

        // Defined types our role types
        Field(r => r.Id);
        Field(r => r.Name);

        // Role has ForegnKey to User and we specify it
        // TODO We can add arguments to select set of users
        Field<ListGraphType<UserType>>();
    }
}