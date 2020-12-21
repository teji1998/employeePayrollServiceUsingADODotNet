using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class MultiThreading
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_Payroll_Service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool addEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("dbo.SpAddEmployeeDetails", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Basic_Pay", model.Basic_Pay);
                    command.Parameters.AddWithValue("@Start_Date", model.Start_Date);
                    command.Parameters.AddWithValue("@Mobile_number", model.Mobile_number);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@Taxable_Pay", model.Taxable_Pay);
                    command.Parameters.AddWithValue("@Income_Tax", model.Income_Tax);
                    command.Parameters.AddWithValue("@Net_Pay", model.Net_Pay);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (!result.Equals(0))
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool AddMultipleElementToDB(List<EmployeeModel> Models)
        {
            foreach (EmployeeModel employee in Models)
            {
                Console.WriteLine("Employee being added:" + employee.Name);
                bool result = addEmployee(employee);
                Console.WriteLine("Employee Added:" + employee.Name);
                if (result == false)
                {
                    return false;
                }
            }
            return true;
        }


        public List<EmployeeModel> listemployeeModel = new List<EmployeeModel>();
        public void AddEmployeePayroll(List<EmployeeModel> listemployeeModel)
        {
            listemployeeModel.ForEach(employeeData =>
            {
                Console.WriteLine("Employee begin: " + employeeData.Name);
                this.AddEmployee(employeeData);
                Console.WriteLine("employee Added : " + employeeData.Name);
            });
            Console.WriteLine(this.listemployeeModel.ToString());
        }

        public void AddEmployee(EmployeeModel employeeData)
        {
            listemployeeModel.Add(employeeData);
        }

        public void AddEmployeePayrollwithTheard(List<EmployeeModel> listemployeeModel)
        {
            listemployeeModel.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {

                    Console.WriteLine("Employee begin: " + employeeData.Name);
                    this.AddEmployee(employeeData);
                    Console.WriteLine("employee Added : " + employeeData.Name);
                });
                thread.Start();
            });
            Console.WriteLine(this.listemployeeModel.Count);
        }
    }
}
