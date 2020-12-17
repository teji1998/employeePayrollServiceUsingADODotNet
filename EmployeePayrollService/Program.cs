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
            /*emp.Name = "Liam";
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
            emp.Department = "Production";*/
            // repo.UpdateEmployee(emp);
            //repo.GetEmployeesInDateRange();
            repo.FindingSumOfSalaryByGender();
           // repo.FindingAverageOfSalaryByGender();
            //repo.FindingMinimumOfSalaryByGender();
            //repo.FindingMaximumOfSalaryByGender();
            //repo.CountOContactsByGender();
            // emp.Name = "Liam";
            // repo.DeleteTheEmployee(emp);
            /*emp.Start_Date = new DateTime(2020,04,14);
            emp.Basic_Pay = 90000;
            emp.Deductions = 6000;
            emp.Taxable_Pay = 3000;
            emp.Income_Tax = 2900;
            emp.Net_Pay = 87000;
            emp.Employee_Id = 4;*/
            //repo.AddingPayRollDetails(emp);
            emp.Name = "Pierre";
            emp.Gender = 'M';
            emp.Mobile_number = "9949831234";
            emp.Address = "Paris";
            emp.Department = "IOT";
            // repo.AddingDepartment(emp);
            //repo.AddingEmployeeDetails(emp);
            emp.Employee_Id = 4;
            emp.Department_Id = 6;
            //repo.AddingToEmployeeDepartment(emp);
           // repo.GettingEmployeeDetails();
        }
    }
}
