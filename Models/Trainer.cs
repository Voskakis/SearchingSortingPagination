﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchingSortingPagination.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        [Required(), MaxLength(60), MinLength(1)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,60}$", ErrorMessage = "Characters are not allowed.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(), MaxLength(60), MinLength(1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        public decimal Salary { get; set; }


        public DateTime? HireDate { get; set; }

        [Display(Name = "Is Available")]
        public bool isAvailable { get; set; }

        //navigation properties
        public virtual ICollection<Category> Categories { get; set; }
    }
}