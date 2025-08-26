using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.H15
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private string departament;

        public Employee(string name, decimal salary, string departament)
        {
            this.name = name;
            this.salary = salary;
            this.departament = departament;
        }

        public void ShowDetils()
        {
            Console.WriteLine($"Employee name: {name}");
            Console.WriteLine($"Employee salary: {salary}");
            Console.WriteLine($"Employee departament: {departament}");
        }
    }

}

