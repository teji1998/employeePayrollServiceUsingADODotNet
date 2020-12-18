using EmployeePayrollService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmpPayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        EmployeeRepository repo = new EmployeeRepository();
        EmployeeModel emp = new EmployeeModel();

        /// <summary>
        /// Given the details when added into employee payroll table should return true.
        /// </summary>
        [TestMethod]
        public void givenDetails_WhenAddedIntoEmployeePayrollTable_ShouldReturnTrue()
        {
            emp.Name = "Liam";
            emp.Basic_Pay = 90000.00;
            emp.Start_Date = new DateTime(2019, 11, 19);
            emp.Mobile_number = "9945670983";
            emp.Address = "England";
            emp.Department = "Music";
            emp.Deductions = 6000.00;
            emp.Taxable_Pay = 3000.00;
            emp.Income_Tax = 2900.00;
            emp.Net_Pay = 87000.00;
            emp.Gender = 'M';
            bool result = repo.AddEmployee(emp);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Given the details when updated in employee payroll table should return true.
        /// </summary>
        [TestMethod]
        public void givenDetails_WhenUpdatedInEmployeePayrollTable_ShouldReturnTrue()
        {
            emp.Name = "Liam";
            emp.Address = "UK";
            emp.Department = "HR";
            bool result = repo.UpdateEmployee(emp);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Given the details when added into employee table should return true.
        /// </summary>
        [TestMethod]
        public void givenDetails_WhenAddedIntoEmployeeTable_ShouldReturnTrue()
        {
            emp.Name = "George";
            emp.Gender = 'M';
            emp.Mobile_number = "7689008765";
            emp.Address = "Wadala";
            bool result = repo.AddingEmployeeDetails(emp);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Given the details when added into payroll table should return true.
        /// </summary>
        [TestMethod]
        public void givenDetails_WhenAddedIntoPayrollTable_ShouldReturnTrue()
        {
            emp.Employee_Id = 4;
            emp.Start_Date = new DateTime(2018, 08, 19);
            emp.Basic_Pay = 60000;
            emp.Deductions = 1000;
            emp.Taxable_Pay = 1300;
            emp.Income_Tax = 2000;
            emp.Net_Pay = 57000;
            bool result = repo.AddingPayRollDetails(emp);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Given the details when added into department table should return true.
        /// </summary>
        [TestMethod]
        public void givenDetails_WhenAddedIntoDepartmentTable_ShouldReturnTrue()
        {
            emp.Department = "Arts";
            bool result = repo.AddingDepartment(emp);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Given the details when added into employee department table should return true.
        /// </summary>
        [TestMethod]
        public void givenDetails_WhenAddedIntoEmployeeDepartmentTable_ShouldReturnTrue()
        {
            emp.Employee_Id = 5;
            emp.Department_Id = 3;
            bool result = repo.AddingToEmployeeDepartment(emp);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Givens the details when added in multiple tables should return true.
        /// </summary>
        [TestMethod]
        public void givenDetails_WhenAddedInMultipleTables_ShouldReturnTrue()
        {
            emp.Name = "Elsa";
            emp.Gender = 'F';
            emp.Mobile_number = "8099234540";
            emp.Address = "Iceland";
            emp.Basic_Pay = 500000;
            emp.Department_Id = 3;
            emp.Start_Date = new DateTime(2019, 1, 13);
            bool result = repo.AddEmployeeDetailsToMultipleTables(emp);
            Assert.IsTrue(result);
        }

    }
}
