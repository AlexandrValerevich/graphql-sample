namespace Identity.HotChocolateGQL.GraphQL.Users;


// We can move it to our contracts and then rename it in AddUserInputType.
// It can be a shared model for REST API and GraphQL which can have a common
// Service Layer
public record AddUserInputs(string FirstName, string LastName, string RoleName);
