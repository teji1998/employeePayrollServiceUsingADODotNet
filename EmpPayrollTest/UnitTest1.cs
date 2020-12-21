using EmployeePayrollService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
       /* [TestMethod]
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
        }*/

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

        public List<EmployeeModel> AddingDataToList()
        {
            List<EmployeeModel> models = new List<EmployeeModel>();

           // models.Add(new EmployeeModel() { Name="Mango",Basic_Pay=90000,Start_Date= new DateTime(2018, 09, 11),Mobile_number="9878675645",Address="mum",Department="Music",Deductions=900,Taxable_Pay=670,Income_Tax=890,Net_Pay=90000,Gender='F' });
            models.Add(new EmployeeModel() { Name = "Looney", Basic_Pay = 60000, Start_Date = new DateTime(2019, 09, 11), Mobile_number = "9878605645", Address = "mira", Department = "It", Deductions = 1900, Taxable_Pay = 670, Income_Tax = 890, Net_Pay = 90000, Gender = 'M' });
            models.Add(new EmployeeModel() { Name = "black", Basic_Pay = 900000, Start_Date = new DateTime(2017, 09, 11), Mobile_number = "9878695645", Address = "mumbaiii", Department = "Music", Deductions = 900, Taxable_Pay = 670, Income_Tax = 890, Net_Pay = 90000, Gender = 'M' });

            return models;
        }

        /// <summary>
        /// Given details the when added without threading should return equal.
        /// </summary>
        [TestMethod]
        public void givendetails_WhenAddedWithoutThreading_ShouldReturnEqual()
        {
            List<EmployeeModel> listModel = AddingDataToList();
            bool expected = true;
            MultiThreading ops = new MultiThreading();
            Stopwatch stopwatch = new Stopwatch(); //to measure elasped time
            stopwatch.Start();
            bool actual = ops.AddMultipleElementToDB(listModel);
            stopwatch.Stop();
            Console.WriteLine("Time taken to add without thread is :{0} ms", stopwatch.ElapsedMilliseconds);//in milliseconds
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Givendetailses the when added with threading should return equal.
        /// </summary>
        [TestMethod]
        public void givendetails_WhenAddedWithThreading_ShouldReturnEqual()
        {
            List<EmployeeModel> Models = AddingDataToList();
            MultiThreading ops = new MultiThreading();
            bool expected = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool actual = ops.AddEmployeesToDBWithThread(Models);
            stopwatch.Stop();
            Console.WriteLine("Time taken to add without threads is :{0} ms", stopwatch.ElapsedMilliseconds);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Givens the details when added to list without threading.
        /// </summary>
        [TestMethod]
        public void givenDetails_WhenAddedToList_WithoutThreading()
        {
            MultiThreading ops = new MultiThreading();
            List<EmployeeModel> Models = AddingDataToList();
            DateTime startTime = DateTime.Now;
            ops.AddEmployeePayroll(Models);
            DateTime stopTime = DateTime.Now;
            Console.WriteLine("Duration without thread :" + (stopTime - startTime));
        }

        /// <summary>
        /// Givens the details when added to list with threading.
        /// </summary>
        [TestMethod]
        public void givenDetails_WhenAddedToList_WithThreading()
        {
            MultiThreading ops = new MultiThreading();
            List<EmployeeModel> Models = AddingDataToList();
            DateTime startTimeThread = DateTime.Now;
            ops.AddEmployeePayrollwithThread(Models);
            DateTime stopTimethread = DateTime.Now;
            Console.WriteLine("Duration with thread :" + (stopTimethread - startTimeThread));
        }

        public List<EmployeeModel> updateList()
        {
            List<EmployeeModel> updatedList = new List<EmployeeModel>();
            updatedList.Add(new EmployeeModel { Name = "Teju", Address = "Bangkok",Department="Dance" });
            updatedList.Add(new EmployeeModel { Name = "Liam", Address = "Wadala", Department = "Dance" });
            updatedList.Add(new EmployeeModel { Name = "black", Address = "Ktk", Department = "Dance" });
            return updatedList;

        }
        [TestMethod]
        public void givenDetails_WhenUpdatedToListWithThreading_ShouldUpdateTheList()
        {
            List<EmployeeModel> models = updateList();
            bool expected = true;
            MultiThreading ops = new MultiThreading();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool actual = ops.UpdateMultipleEmployeeToDBWithThreading(models);
            stopwatch.Stop();
            Console.WriteLine("Time taken to add to db without threads is :{0} ms", stopwatch.ElapsedMilliseconds);
            Assert.AreEqual(expected, actual);

        }

    }

}



