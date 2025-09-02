using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.HW_16
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Employee(int id, string name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public virtual decimal CalculateAnnualSalary()
        {
            return Salary * 12;
        }
    }

    public class FullTimeEmployee : Employee
    {
        public decimal Bonus { get; set; }

        public FullTimeEmployee(int id, string name, decimal salary, decimal bonus) : base(id, name, salary)
        {
            Bonus = bonus;
        }

        public override decimal CalculateAnnualSalary() 
        {
            return ((Salary * 12) + (2 * Bonus));
        }
    }

    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }

        public PartTimeEmployee(int id, string name, decimal salary, decimal hourlyBonus) : base(id, name, salary) 
        {
            HourlyRate = hourlyBonus; 
        }

        public override decimal CalculateAnnualSalary()
        {
            return (HourlyRate * Salary * 52);
        }
    }
}
