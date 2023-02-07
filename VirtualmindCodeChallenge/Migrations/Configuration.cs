namespace VirtualmindCodeChallenge.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VirtualmindCodeChallenge.Models.UserModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VirtualmindCodeChallenge.Models.UserModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.users.AddOrUpdate(
                u => u.id,
                new Models.User() { apellido = "Diaz", nombre = "Julian", email = "julian@diaz.com", password = "sarasa0" },
                new Models.User() { apellido = "Perez", nombre = "Juan", email = "juan@diaz.com", password = "sarasa1" },
                new Models.User() { apellido = "Martinez", nombre = "Jose", email = "jose@diaz.com", password = "sarasa2" },
                new Models.User() { apellido = "Diaz2", nombre = "John", email = "john@diaz.com", password = "sarasa3" }
            );
        }
    }
}
