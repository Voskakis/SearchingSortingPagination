using SearchingSortingPagination.Models;
using System.Data.Entity;

namespace SearchingSortingPagination.Dal
{
    public class MyDatabase: DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public MyDatabase(): base("ONOMA")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Trainer>()
        //        .HasMany(t => t.Categories)
        //        .WithMany(t => t.Trainers)
        //        .Map(m =>
        //        {
        //            m.ToTable("TrainersCategories");
        //            m.MapLeftKey("StudentId");
        //            m.MapRightKey("CategoryId");
        //        });
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}