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
                Name = "Liverpool - Juventus",
                OddsForFirstTeam = 1.95,
                OddsForDraw = 3.15,
                OddsForSecondTeam = 2.20,
                StartDate = DateTime.Now
            });

            context.Events.AddOrUpdate(new Event()
            {
                Name = "Grigor Dimitrov - Rafael Nadal",
                OddsForFirstTeam = 2.00,
                OddsForDraw = 3.05,
                OddsForSecondTeam = 2.70,
                StartDate = DateTime.Now.AddDays(3)
            });

            context.Events.AddOrUpdate(new Event()
            {
                Name = "Barcelon - Ludogorets",
                OddsForFirstTeam = 1.01,
                OddsForDraw = 4.20,
                OddsForSecondTeam = 15.20,
                StartDate = DateTime.Now.AddDays(15)
            });

            context.SaveChanges();
        }
    }
}
