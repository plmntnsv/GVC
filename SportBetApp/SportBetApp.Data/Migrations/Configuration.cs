namespace SportBetApp.Data.Migrations
{
    using SportBetApp.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SportBetApp.Data.SportBetAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportBetApp.Data.SportBetAppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Events.AddOrUpdate(new Event()
            {
                Id = 1,
                Name = "Liverpool - Juventus",
                OddsForFirstTeam = 1.95,
                OddsForDraw = 3.15,
                OddsForSecondTeam = 2.20,
                StartDate = DateTime.Now
            });

            context.Events.AddOrUpdate(new Event()
            {
                Id = 2,
                Name = "Grigor Dimitrov - Rafael Nadal",
                OddsForFirstTeam = 2.00,
                OddsForDraw = 3.05,
                OddsForSecondTeam = 2.70,
                StartDate = DateTime.Now.AddDays(3)
            });

            context.Events.AddOrUpdate(new Event()
            {
                Id = 3,
                Name = "Barcelona - Ludogorets",
                OddsForFirstTeam = 1.01,
                OddsForDraw = 4.20,
                OddsForSecondTeam = 15.20,
                StartDate = DateTime.Now.AddDays(15)
            });

            context.Events.AddOrUpdate(new Event()
            {
                Id = 4,
                Name = "Chelsea - Manchester United",
                OddsForFirstTeam = 1.70,
                OddsForDraw = 4.00,
                OddsForSecondTeam = 3.70,
                StartDate = DateTime.Now.AddDays(4)
            });

            context.Events.AddOrUpdate(new Event()
            {
                Id = 5,
                Name = "Real Madrid - Levante",
                OddsForFirstTeam = 1.12,
                OddsForDraw = 9.00,
                OddsForSecondTeam = 21.00,
                StartDate = DateTime.Now
            });

            context.Events.AddOrUpdate(new Event()
            {
                Id = 6,
                Name = "Roma - Spal",
                OddsForFirstTeam = 1.33,
                OddsForDraw = 5.50,
                OddsForSecondTeam = 8.50,
                StartDate = DateTime.Now.AddDays(15)
            });

            context.SaveChanges();
        }
    }
}
