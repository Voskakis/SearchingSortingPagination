using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchingSortingPagination.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Kind { get; set; }

        //navigation properties
        public ICollection<Trainer> Trainers { get; set; }
    }
}