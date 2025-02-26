﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Core_Crud.Models
{
    public class EmpRes
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Salary { get; set; }
        public string City { get; set; }
        [Required]
        public string Dept { get; set; }
    }
}
