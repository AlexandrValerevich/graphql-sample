using GraphQL.Server.Ui.Voyager;
using Identity.HotChocolateGQL.Infrastructure.DependencyInjections;
using Identity.HotChocolateGQL.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("Identity");
builder.Services.AddIdentityDbContext(connectionString);

builder.Services.AddGraphQlConfiguration();

var app = builder.Build();

app.SeedIdentityDb();

app.UseWebSockets();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
{
    GraphQLEndPoint = "/graphql",
    Path = "/graphql-voyager"
});

app.Run();
