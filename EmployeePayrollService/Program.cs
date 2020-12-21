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
            //repo.FindingSumOfSalaryByGender();
           // repo.FindingAverageOfSalaryByGender();
            //repo.FindingMinimumOfSalaryByGender();
            //repo.FindingMaximumOfSalaryByGender();
            //repo.CountContactsByGender();
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
            emp.Name = "Pansy";
            emp.Gender = 'F';
            emp.Mobile_number = "98456831234";
            emp.Address = "London";
            emp.Basic_Pay = 700000;
            emp.Department_Id = 5;
            emp.Start_Date = new DateTime(2020, 09, 14);
            // repo.AddEmployeeDetailsToMultipleTables(emp);
            // repo.AddingDepartment(emp);
            //repo.AddingEmployeeDetails(emp);
            /*emp.Employee_Id = 4;
            emp.Department_Id = 6;*/
            //repo.AddingToEmployeeDepartment(emp);
            // repo.GettingEmployeeDetails();

            bool i = true;
            while (i)
            {
                Console.WriteLine("\n");
                Console.WriteLine("1.Sum Of Basic Salary By Gender");
                Console.WriteLine("2.Average Of Basic Salary By Gender");
                Console.WriteLine("3.Minimum Of Basic Salary By Gender");
                Console.WriteLine("4.Maximum Of Basic Salary By Gender");
                Console.WriteLine("5.Count Of Basic Salary By Gender");
                Console.WriteLine("6.Exit");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            repo.FindingSumOfSalaryByGender();
                            break;
                        case 2:
                            repo.FindingAverageOfSalaryByGender();
                            break;
                        case 3:
                            repo.FindingMinimumOfSalaryByGender();
                            break;
                        case 4:
                            repo.FindingMaximumOfSalaryByGender();
                            break;
                        case 5:
                            repo.CountContactsByGender();
                            break;
                        case 6:
                            i = false;
                            break;
                        default:
                            Console.WriteLine("Choose valid option");
                            break;
                    }
                }
                catch (System.FormatException formatException)
                {
                    Console.WriteLine(formatException);
                }
            }

        }
    }
}
