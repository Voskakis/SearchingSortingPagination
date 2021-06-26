namespace SearchingSortingPagination.Migrations
{
    using SearchingSortingPagination.Dal;
    using SearchingSortingPagination.Models;
    using SearchingSortingPagination.Utilities;
    using System;
    using System.Collections.Generic;
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

            foreach (var field in TrainerGenerator.Fields)
            {
                Category category = new Category() { Kind = field };
                if (!context.Categories.Any(c => c.Kind == category.Kind))
                {
                    context.Entry(category).State = EntityState.Added;
                }
            }
            context.SaveChanges();

            TrainerGenerator tg = new TrainerGenerator();
            List<Tuple<string, string>> names = TrainerGenerator.GetFullNames();
            foreach (var fullname in names)
            {
                bool isEmployed = tg.GetChance(0.9);
                Trainer trainer = new Trainer()
                {
                    FirstName = fullname.Item1,
                    LastName = fullname.Item2,
                    HireDate = isEmployed ? (DateTime?)tg.RandDate(new DateTime(1994, 4, 4), DateTime.Now) : null,
                    Salary = isEmployed ? tg.GetMoney() : 0,
                    isAvailable = isEmployed ? tg.GetChance(0.5) : true
                };
                if (!context.Trainers.Any(t => t.FirstName + t.LastName == trainer.FirstName + trainer.LastName))
                {
                    context.Entry(trainer).State = EntityState.Added;
                }
            }
            context.SaveChanges();

            
        }
    }
}
