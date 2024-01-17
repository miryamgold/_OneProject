using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Entities_.Models
{
    public partial class Employees
    {
        [Key]
        public int id { get; set; }
        public string employee_name { get; set; }
        public int? employee_salary { get; set; }
        public int? employee_age { get; set; }
        public string profile_image { get; set; }
    }
}
