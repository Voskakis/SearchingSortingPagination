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
        
    }
}