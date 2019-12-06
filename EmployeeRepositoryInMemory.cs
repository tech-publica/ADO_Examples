using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

public class EmployeeRepositoryInMemory : EmployeeRepository
{
    static EmployeeRepositoryInMemory()
    {
        emps.Add(1, new Employee
        {
            Empid = 1,
            FirstName = "Ciccio",
            LastName = "Pasticcio",
            Sex = "M",
            Salary = 10000

        });

        emps.Add(2, new Employee
        {
            Empid = 2,
            FirstName = "Pico",
            LastName = "De Paperis",
            Sex = "M",
            Salary = 20000

        });

        emps.Add(3, new Employee
        {
            Empid = 3,
            FirstName = "Clarabella",
            LastName = "Clarabellis",
            Sex = "F",
            Salary = 5000

        });
    }
    private static Dictionary<int, Employee> emps = new Dictionary<int, Employee>();




    public IEnumerable<Employee> All()
    {
        return emps.Values;
    }

    public IEnumerable<Employee> AllByLastname(string chars)
    {
        var res =
        emps.Values.Where(e => e.LastName.Contains(chars)).ToList();
        return res;
        // IEnumerable<Employee> byLastName = emps.Values.Where( e => e.LastName.Contains(chars)); 
        // IEnumerable<Employee> byLastNameOrderedByFN = byLastName.OrderByDescending( e => e.FirstName.Length);
        // IEnumerable<Employee> byLastNameOrderedByFNAndBD =  byLastNameOrderedByFNThenBy(e => e.BirthDate);
    }

    public IEnumerable<Employee> AllByLastnameCountry(string chars, string country)
    {
        return emps.Values.Where(e => e.LastName.Contains(chars) && e.Country == country).ToList();
    }

    public Employee ById(int id)
    {
        return emps.Values.SingleOrDefault(e => e.Empid == id);
    }

    public IEnumerable<Employee> ByManagerId(int managerId)
    {
        return emps.Values.Where(e => e.ManagerId == managerId);
    }

    public decimal MaxSalaryBySex(string sex)
    {
        emps.Values.Where(e => e.Sex == sex).Select(e => e.Salary).Aggregate((s1, s2) => s1 >= s2 ? s1 : s2);
        EmployeeStats stats = new EmployeeStats();

     EmployeeStats stats2 =    emps.Values
        .Aggregate(stats, (a, e) => a.Update(e),
          a => {
              a.AvgFemaleSalary = a.SumFemaleSalary/ a.FemaleCounter;
              a.AvgMaleSalary = a.SumMaleSalary / a.MaleCounter;
              return a;
          });
       // stats.AvgMaleSalary = stats.SumMaleSalary / stats.MaleCounter;

        return emps.Values.Where(e => e.Sex == sex).Max(e => e.Salary);
    }

    public decimal TotalSalaryBySex(string sex)
    {
        return emps.Values.Where(e => e.Sex == sex).Select(e => e.Salary).Sum();
    }





    private string F()
    {
        var maxSalaries = emps.Values.GroupBy(e => e.Sex)
            .Select(g => new
            {
                Sex = g.Key,
                MaxSalary = g.Max(e => e.Salary)
            });
        StringBuilder bld = new StringBuilder();
        foreach (var item in maxSalaries)
        {
            bld.Append(item.Sex)
            .Append(" guadagna al max ")
            .Append(item.MaxSalary);
        }
        return bld.ToString();

    }


    public class EmployeeStats
    {
        public decimal MaxFemaleSalary { get; set; }
        public decimal MaxMaleSalary { get; set; }
        public decimal AvgFemaleSalary { get; set; }
        public decimal AvgMaleSalary { get; set; }

        public decimal SumFemaleSalary { get; set; }
        public decimal SumMaleSalary { get; set; }

        public int MaleCounter { get; set; }
        public int FemaleCounter { get; set; }

        public EmployeeStats Update(Employee emp) 
        {
            if(emp.Sex == "F")
            {
                this.FemaleCounter++;
                this.SumFemaleSalary += emp.Salary;
                this.MaxFemaleSalary = this.MaxFemaleSalary >= emp.Salary? this.MaxFemaleSalary : emp.Salary;
            }
            else
            {
                this.MaleCounter++;
                this.SumMaleSalary += emp.Salary;
                this.MaxMaleSalary = this.MaxMaleSalary >= emp.Salary? this.MaxMaleSalary : emp.Salary;
            }
            return this;

        }


    }
}
