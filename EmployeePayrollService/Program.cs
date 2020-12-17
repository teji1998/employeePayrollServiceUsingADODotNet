using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the employee payroll service !!!!");
            EmployeeRepository repo = new EmployeeRepository();
            repo.GetEmployees();
        }
    }
}
