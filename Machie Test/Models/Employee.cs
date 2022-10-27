using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Machie_Test.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public int Salary { get; set; }
        public string Desgination { get; set; }

        public string Email { get; set; }
    }
}