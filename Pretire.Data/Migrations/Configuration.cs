namespace Pretire.Data.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pretire.Data.PretireDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pretire.Data.PretireDataContext context)
        {
            context.GrowthTypes.AddOrUpdate(
                new GrowthTypeEntity() { Id = 1, Name = "No Growth" },
                new GrowthTypeEntity() { Id = 2, Name = "Flat Amount" },
                new GrowthTypeEntity() { Id = 3, Name = "Percentage" }
            );

            context.TaxCodes.AddOrUpdate(
                new TaxCodeEntity()
                {
                    Id = 1,
                    Name = "USASocialSecurity",
                    Brackets = new List<TaxBracketEntity>()
                    {
                        new TaxBracketEntity() { LowerBound = 0, UpperBound = 118500, TaxRate = .062M },
                        new TaxBracketEntity() { LowerBound = 118500, UpperBound = null, TaxRate = 0 }
                    }
                },
                new TaxCodeEntity()
                {
                    Id = 2,
                    Name = "USAMedicare",
                    Brackets = new List<TaxBracketEntity>()
                    {
                        new TaxBracketEntity() { LowerBound = 0, UpperBound = null, TaxRate = .0145M }
                    }
                }, 
                new TaxCodeEntity()
                {
                    Id = 3,
                    Name = "USASingleIncome",
                    Brackets = new List<TaxBracketEntity>()
                    {
                        new TaxBracketEntity() { LowerBound = 0, UpperBound = 9275, TaxRate = .1M },
                        new TaxBracketEntity() { LowerBound = 9275, UpperBound = 37650, TaxRate = .15M },
                        new TaxBracketEntity() { LowerBound = 37650, UpperBound = 91150, TaxRate = .25M },
                        new TaxBracketEntity() { LowerBound = 91150, UpperBound = 190150, TaxRate = .28M },
                        new TaxBracketEntity() { LowerBound = 190150, UpperBound = 413350, TaxRate = .33M },
                        new TaxBracketEntity() { LowerBound = 413350, UpperBound = 415050, TaxRate = .35M },
                        new TaxBracketEntity() { LowerBound = 415050, UpperBound = null, TaxRate = .396M }
                    }
                }
            );
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
        }
    }
}
