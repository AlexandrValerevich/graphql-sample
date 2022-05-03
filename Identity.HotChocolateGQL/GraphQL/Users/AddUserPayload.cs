using Identity.DAL.Models;

namespace Identity.HotChocolateGQL.GraphQL.Users;

// It also we can move to contract file
// becose it is shared responce for our API
public record AddUserPayload(User User);
