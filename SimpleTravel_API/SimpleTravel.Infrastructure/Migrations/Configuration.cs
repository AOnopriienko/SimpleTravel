namespace SimpleTravel.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SimpleTravel.Infrastructure.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleTravel.Infrastructure.Repositories.Implementation.TripContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SimpleTravel.Infrastructure.Repositories.Implementation.TripContext";
        }

        protected override void Seed(SimpleTravel.Infrastructure.Repositories.Implementation.TripContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Apartments.AddOrUpdate(
                  new Apartment { Id = Guid.NewGuid(), Address = "Kiev", Name = "Premier Palace", TypeId = ApartmentType.Hotel},
                  new Apartment { Id = Guid.NewGuid(), Address = "Sumy", Name = "Radisson", TypeId = ApartmentType.Hotel},
                  new Apartment { Id = Guid.NewGuid(), Address = "New York", Name = "Grand Hayat", TypeId = ApartmentType.Hotel}
                );
        }
    }
}
