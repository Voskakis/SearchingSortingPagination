using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchingSortingPagination.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        [Required(), MaxLength(60), MinLength(1)]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "Characters are not allowed.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(), MaxLength(60), MinLength(1)]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "Characters are not allowed.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Range(0, Double.PositiveInfinity)]
        public decimal Salary { get; set; }

        public DateTime? HireDate { get; set; }

        [Display(Name = "Is Available")]
        public bool isAvailable { get; set; }

        //navigation properties
        [Display(Name = "Categories")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}