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
                Id = 1,
                FirstName = "Alexander",
                LastName = "Nesterovich",
                Roles = new List<Role>
                {
                    new Role(){
                        Id = 1,
                        Name = "Admin"
                    },
                    new Role(){
                        Id =2,
                        Name = "Hasbend"
                    }
                },
            },
            new User
            {
                Id = 2,
                FirstName = "Viktoria",
                LastName = "Borisenko",
                Roles = new List<Role>
                {
                    new Role(){
                        Id = 3,
                        Name = "Wife"
                    }
                },
            }
        };

        context.AddRange(newUsers);

        context.SaveChanges();
    }
}