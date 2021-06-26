using System;
using System.Collections.Generic;

namespace SearchingSortingPagination.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public bool isAvailable { get; set; }

        //navigation properties
        public virtual ICollection<Category> Categories { get; set; }
    }
}