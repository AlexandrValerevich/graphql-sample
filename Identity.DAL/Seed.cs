using Identity.DAL.Models;

namespace Identity.DAL;

public static class Seed
{
    public static void SeedDb(this IdentityDbContext context)
    {
        bool hasUsers = context.Users.Any();
        bool hasRoles = context.Roles.Any();

        if (hasUsers && hasRoles)
        {
            return;
        }

        var newUsers = new List<User>{
            new User
            {
                FirstName = "Alexander",
                LastName = "Nesterovich",
                Roles = new List<Role>
                {
                    new Role(){
                        Name = "Admin"
                    },
                    new Role(){
                        Name = "Hasbend"
                    }
                },
            },
            new User
            {
                FirstName = "Viktoria",
                LastName = "Borisenko",
                Roles = new List<Role>
                {
                    new Role(){
                        Name = "Wife"
                    }
                },
            }
        };

        context.AddRange(newUsers);

        context.SaveChanges();
    }
}