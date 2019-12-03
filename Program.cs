using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace ADOExamples
{
    class Program
    {
       

        static void Main(string[] args)
        {
            var repo = new EmployeeRepository();
            var employees = repo.AllByLastname("e");
            foreach (var item in employees)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

        }
    }
}
