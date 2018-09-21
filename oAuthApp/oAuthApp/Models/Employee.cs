using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace oAuthApp.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public Nullable<int> Age { get; set; }

        public Nullable<decimal> Salary { get; set; }

        public string worktype { get; set; }
    }
}
