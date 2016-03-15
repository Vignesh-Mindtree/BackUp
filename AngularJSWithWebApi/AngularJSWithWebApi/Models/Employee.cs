using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSWithWebApi.Models
{
    public class Employee
    {
        public string MId { get; set; }
        public string Name { get; set; }
        public string IG { get; set; }

        public List<Employee> GetAll()
        {
            return
                new List<Employee>
                {
                    new Employee { MId = "M1032545", Name = "Vignesh Nagendran", IG = "TTH" },
                    new Employee { MId = "M1032546", Name = "Subroto Bagchi", IG = "COO" },
                    new Employee { MId = "M1032547", Name = "KrishnaKumar Natarajan", IG = "CEO" }
                };
        }

        public Employee GetByMId(string mId)
        {
            return  GetAll().FirstOrDefault(employee => employee.MId == mId);
        }

        public Employee GetByName(string name)
        {
            return GetAll().FirstOrDefault(employee => employee.Name == name);
        }

        public List<Employee> Create( Employee employee)
        {
            var employees = GetAll();
            employees.Add(employee);
        }
    }
}