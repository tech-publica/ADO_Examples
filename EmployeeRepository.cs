using System.Collections.Generic;

public interface EmployeeRepository
{
    Employee ById(int id);
    IEnumerable<Employee> All();
    IEnumerable<Employee> AllByLastname(string lastname);
    IEnumerable<Employee> AllByLastnameCountry(string lastname, string country);
    IEnumerable<Employee> ByManagerId(int managerId);
    decimal TotalSalaryBySex(string sex);
    decimal MaxSalaryBySex(string sex);


}