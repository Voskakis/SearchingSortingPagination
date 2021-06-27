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
            List<Category> categories = new List<Category>(TrainerGenerator.Fields.Length);

            foreach (var field in TrainerGenerator.Fields)
            {
                categories.Add(new Category() { Kind = field });
                    //context.Entry(category).State = EntityState.Added;
            }

            List<Trainer> trainers = new List<Trainer>(101);
            TrainerGenerator tg = new TrainerGenerator();
            List<Tuple<string, string>> names = TrainerGenerator.GetFullNames();
            int troll_meter = 0;
            foreach (var fullname in names)
            {
                if (troll_meter++ > 200) break;
                bool isEmployed = tg.GetChance(0.9);
                
                Trainer trainer = new Trainer()
                {
                    FirstName = fullname.Item1,
                    LastName = fullname.Item2,
                    HireDate = isEmployed ? (DateTime?)tg.RandDate(new DateTime(1994, 4, 4), DateTime.Now) : null,
                    Salary = isEmployed ? tg.GetMoney() : 0,
                    isAvailable = isEmployed ? tg.GetChance(0.5) : true
                };
                trainer.Categories = new List<Category>();
                foreach (var category in categories)
                {
                    if (tg.GetChance(0.1)) {
                        trainer.Categories.Add(category);
                    }
                }
                trainers.Add(trainer);
            }

            foreach (var category in categories)
            {
                context.Categories.AddOrUpdate(x => x.Kind, category);
            }

            foreach (var trainer in trainers)
            {
                context.Trainers.AddOrUpdate(x => new { x.FirstName, x.LastName }, trainer);
            }

            context.SaveChanges();
        }
    }
}
