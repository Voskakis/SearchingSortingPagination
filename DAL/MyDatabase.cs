using SearchingSortingPagination.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SearchingSortingPagination.Dal
{
    public class MyDatabase: DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        public MyDatabase(): base("ONOMA")
        {

        }
    }
}