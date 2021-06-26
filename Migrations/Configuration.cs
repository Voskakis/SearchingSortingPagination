namespace SearchingSortingPagination.Migrations
{
    using SearchingSortingPagination.Dal;
    using SearchingSortingPagination.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SearchingSortingPagination.Dal.MyDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyDatabase context)
        {
            context.Trainers.AddOrUpdate(x => new { x.FirstName, x.LastName },
                new Trainer() { FirstName="Kwstas", LastName="Voskakis", Salary=1000000},
                new Trainer() { FirstName="Marios", LastName="Petrou", Salary=4000},
                new Trainer() { FirstName="Melpomenh", LastName="Petrou", Salary=5000},
                new Trainer() { FirstName="Fanis", LastName="Papadopoulos", Salary=5000},
                new Trainer() { FirstName="Nikos", LastName="Sainis", Salary=50000},
                new Trainer() { FirstName="Petros", LastName="Xalias", Salary=32000},
                new Trainer() { FirstName="Giorgos", LastName="Xlemponiaris", Salary=5001},
                new Trainer() { FirstName="Onoufrios", LastName="Sougias", Salary=5000},
                new Trainer() { FirstName="Hector", LastName="Ypotropiazwn", Salary=50000},
                new Trainer() { FirstName="Sofia", LastName="Mpourakla", Salary=45600},
                new Trainer() { FirstName="Sofia", LastName="Koutourou", Salary=35000}
            );
            context.SaveChanges();
        }
    }
}
