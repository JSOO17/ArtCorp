using ArtCorp.Domain.Utils;
using ArtCorp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ArtCorp.Infrastructure.Data.Tests
{
    public static class DbContextPrepare
    {
        public static ArtPortContext Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ArtPortContext>()
                                                .UseInMemoryDatabase("food")
                                                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            return new ArtPortContext(optionsBuilder.Options);
        }

        public static async Task CleanUp(ArtPortContext context)
        {
            await context.Database.EnsureDeletedAsync();
        }

        public static async Task SeedDatabase(ArtPortContext context)
        {
            await context.Roles.AddRangeAsync(new List<Role>()
            {
               new Role
               {
                   Name = "Artist"
               },
               new Role
               {
                   Name = "Client"
               }
            });

            await context.Users.AddRangeAsync(new List<User>()
            {
                new User
                {
                    Names = "Yunenfi",
                    Lastnames = "Duran",
                    Document = "341331",
                    TypeDocument = TypesDocument.Cedula,
                    Username = "Takoyaki",
                    Email = "takoyaki@gmail.com",
                    Avatar = "img.png",
                    Cellphone = "+12313",
                    Password = "volcano",
                    RoleId = 1
                },
                 new User
                {
                    Names = "Pepito",
                    Lastnames = "Perezz",
                    Document = "341331",
                    TypeDocument = TypesDocument.Cedula,
                    Username = "Takoyaki",
                    Email = "user@gmail.com",
                    Avatar = "img.png",
                    Cellphone = "+12313333",
                    Password = "fajgrnvia",
                    RoleId = 1
                }
            });

            await context.SaveChangesAsync();
        }
    }
}