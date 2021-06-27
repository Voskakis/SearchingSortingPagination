using System.Collections.Generic;

namespace SearchingSortingPagination.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Kind { get; set; }

        //navigation properties
        public virtual ICollection<Trainer> Trainers { get; set; }
        public Category()
        {

        }
    }
}