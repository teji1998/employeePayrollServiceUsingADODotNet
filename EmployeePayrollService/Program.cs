using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the employee payroll service !!!!");
            EmployeeRepository repo = new EmployeeRepository();
            EmployeeModel emp = new EmployeeModel();
           // repo.GetEmployees();
            emp.Name = "Liam";
            emp.Basic_Pay = 90000;
            emp.Start_Date = "22/2/2019";
            emp.Gender = "Male";
            emp.Mobile_number = "9945670983";
            emp.Address = "England";
            emp.Department = "Music";
            emp.Deductions = 6000;
            emp.Taxable_Pay = 3000;
            emp.Income_Tax = 2900;
            emp.Net_Pay = 87000;
            // repo.AddEmployee(emp);
            emp.Name = "Liam";
            emp.Address = "UK";
            emp.Department = "Production";
            // repo.UpdateEmployee(emp);
            //repo.GetEmployeesInDateRange();
            //repo.FindingSumOfSalaryByGender();
            repo.FindingAverageOfSalaryByGender();
            
        }
    }
}
