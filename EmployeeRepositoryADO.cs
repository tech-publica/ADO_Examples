using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class EmployeeRepositoryADO : EmployeeRepository
{
    private static readonly string CONN_STRING =
      "Server=127.0.0.1;Database=TSQLFundamentals2008;User Id=sa;Password=1Secure*Password1;";
    private static readonly string SELECT_ALL_EMPLOYEES
    = "SELECT * FROM HR.Employees";
    private static readonly string SELECT_ALL_EMPLOYEES_LASTNAME_LIKE
    = "SELECT * FROM HR.Employees where lastname LIKE @chars";
    public List<Employee> All()
    {
        List<Employee> employees = new List<Employee>();
        using (SqlConnection con = new SqlConnection(CONN_STRING))
        {
            Console.WriteLine(CONN_STRING);
            con.Open();

            Console.WriteLine("got connection");
            SqlCommand cmd = new SqlCommand(SELECT_ALL_EMPLOYEES, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var e = new Employee();
                // int empiId = reader.GetInt32(reader.GetOrdinal("empid"));
                e.Empid = reader.GetFieldValue<Int32>(reader.GetOrdinal("empid"));
                if (reader.IsDBNull(reader.GetOrdinal("mgrid")))
                {
                    e.ManagerId = null;
                }
                else
                {
                    e.ManagerId = reader.GetFieldValue<int?>(reader.GetOrdinal("mgrid"));
                }
                e.FirstName = reader.GetFieldValue<string>(reader.GetOrdinal("firstname"));
                e.LastName = reader.GetFieldValue<string>(reader.GetOrdinal("lastname"));
                e.Address = reader.GetFieldValue<string>(reader.GetOrdinal("address"));
                e.City = reader.GetFieldValue<string>(reader.GetOrdinal("city"));
                e.Country = reader.GetFieldValue<string>(reader.GetOrdinal("country"));
                e.PostalCode = reader.GetFieldValue<string>(reader.GetOrdinal("postalcode"));
                e.Phone = reader.GetFieldValue<string>(reader.GetOrdinal("phone"));
                e.Title = reader.GetFieldValue<string>(reader.GetOrdinal("Title"));
                e.TitleOfCourtesy = reader.GetFieldValue<string>(reader.GetOrdinal("titleofcourtesy"));
                e.BirthDate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("birthdate"));
                e.HireDate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("hiredate"));
                employees.Add(e);
            }
        }
        return employees;
    }

    public List<Employee> AllByLastname(string chars)
    {

        List<Employee> employees = new List<Employee>();
        using (SqlConnection con = new SqlConnection(CONN_STRING))
        {
            Console.WriteLine(CONN_STRING);
            con.Open();
            using (SqlCommand cmd = new SqlCommand(SELECT_ALL_EMPLOYEES_LASTNAME_LIKE, con))
            {
                cmd.Parameters.AddWithValue("@chars", "%" + chars + "%");
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var e = new Employee();
                        // int empiId = reader.GetInt32(reader.GetOrdinal("empid"));
                        e.Empid = reader.GetFieldValue<Int32>(reader.GetOrdinal("empid"));
                        if (reader.IsDBNull(reader.GetOrdinal("mgrid")))
                        {
                            e.ManagerId = null;
                        }
                        else
                        {
                            e.ManagerId = reader.GetFieldValue<int?>(reader.GetOrdinal("mgrid"));
                        }
                        e.FirstName = reader.GetFieldValue<string>(reader.GetOrdinal("firstname"));
                        e.LastName = reader.GetFieldValue<string>(reader.GetOrdinal("lastname"));
                        e.Address = reader.GetFieldValue<string>(reader.GetOrdinal("address"));
                        e.City = reader.GetFieldValue<string>(reader.GetOrdinal("city"));
                        e.Country = reader.GetFieldValue<string>(reader.GetOrdinal("country"));
                        e.PostalCode = reader.GetFieldValue<string>(reader.GetOrdinal("postalcode"));
                        e.Phone = reader.GetFieldValue<string>(reader.GetOrdinal("phone"));
                        e.Title = reader.GetFieldValue<string>(reader.GetOrdinal("Title"));
                        e.TitleOfCourtesy = reader.GetFieldValue<string>(reader.GetOrdinal("titleofcourtesy"));
                        e.BirthDate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("birthdate"));
                        e.HireDate = reader.GetFieldValue<DateTime>(reader.GetOrdinal("hiredate"));
                        employees.Add(e);
                    }
                }
            }
        }
        return employees;
    }

    public IEnumerable<Employee> AllByLastnameCountry(string lastname, string country)
    {
        throw new NotImplementedException();
    }

    public Employee ById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Employee> ByManagerId(int managerId)
    {
        throw new NotImplementedException();
    }

    public decimal MaxSalaryBySex(string sex)
    {
        throw new NotImplementedException();
    }

    public decimal TotalSalaryBySex(string sex)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Employee> EmployeeRepository.All()
    {
        throw new NotImplementedException();
    }

    IEnumerable<Employee> EmployeeRepository.AllByLastname(string lastname)
    {
        throw new NotImplementedException();
    }
}