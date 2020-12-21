using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeeRepository
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_Payroll_Service;Integrated Security=True";
       

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void GetEmployees()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel employeePayroll = new EmployeeModel();
                using (connection)
                {
                    string query = @"select ID ,Name,Basic_Pay, Start_Date ,Mobile_number,Address , Department ,Deductions,Taxable_Pay ,Income_Tax ,Net_Pay,Gender from Employee_Payroll;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeePayroll.ID = reader.GetInt32(0);
                            employeePayroll.Name = reader.GetString(1);
                            employeePayroll.Basic_Pay = reader.GetDouble(2);
                            employeePayroll.Start_Date = reader.GetDateTime(3);
                            employeePayroll.Mobile_number = reader.GetString(4);
                            employeePayroll.Address = reader.GetString(5);
                            employeePayroll.Department = reader.GetString(6);
                            employeePayroll.Deductions = reader.GetDouble(7);
                            employeePayroll.Taxable_Pay = reader.GetDouble(8);
                            employeePayroll.Income_Tax = reader.GetDouble(9);
                            employeePayroll.Net_Pay = reader.GetDouble(10);
                            employeePayroll.Gender = Convert.ToChar(reader.GetString(11));
                            Console.WriteLine("Id:{0}\n Name:{1},\nBasic_Pay:{2},\nStart_Date:{3},\nMobile_number:{4},\nAddress:{5},\nDepartment:{6},\nDeductions{7},\nTaxable_Pay:{8}" +
                                "\nIncome_Tax:{9},\nNet_Pay:{10},\nGender:{11}", employeePayroll.ID, employeePayroll.Name, employeePayroll.Basic_Pay, employeePayroll.Start_Date,
                                employeePayroll.Mobile_number, employeePayroll.Address, employeePayroll.Department, employeePayroll.Deductions, employeePayroll.Taxable_Pay, employeePayroll.Income_Tax,
                                employeePayroll.Net_Pay, employeePayroll.Gender);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool AddEmployee(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.SpAddEmployeeDetails", connection);
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
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("Number of rows affected : " + result);
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool UpdateEmployee(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spUpdateEmployees", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("Number of rows affected : " + result);
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
                connection.Close();
            }
        }

        /// <summary>
        /// Gets the employees in date range.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void GetEmployeesInDateRange()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel employeePayroll = new EmployeeModel();
                using (connection)
                {
                    string query = @"Select * from Employee_Payroll Where Start_Date between CAST ('2020-04-14' AS DATE) And  GETDATE();";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeePayroll.ID = reader.GetInt32(0);
                            employeePayroll.Name = reader.GetString(1);
                            employeePayroll.Basic_Pay = reader.GetDouble(2);
                            employeePayroll.Start_Date = reader.GetDateTime(3);
                            employeePayroll.Mobile_number = reader.GetString(4);
                            employeePayroll.Address = reader.GetString(5);
                            employeePayroll.Department = reader.GetString(6);
                            employeePayroll.Deductions = reader.GetDouble(7);
                            employeePayroll.Taxable_Pay = reader.GetDouble(8);
                            employeePayroll.Income_Tax = reader.GetDouble(9);
                            employeePayroll.Net_Pay = reader.GetDouble(10);
                            employeePayroll.Gender = Convert.ToChar(reader.GetString(11));
                            Console.WriteLine("Id:{0}\n Name:{1},\nBasic_Pay:{2},\nStart_Date:{3},\nMobile_number:{4},\nAddress:{5},\nDepartment:{6},\nDeductions{7},\nTaxable_Pay:{8}" +
                                "\nIncome_Tax:{9},\nNet_Pay:{10},\nGender:{ 11}", employeePayroll.ID, employeePayroll.Name, employeePayroll.Basic_Pay, employeePayroll.Start_Date,
                                employeePayroll.Mobile_number, employeePayroll.Address, employeePayroll.Department, employeePayroll.Deductions, employeePayroll.Taxable_Pay, employeePayroll.Income_Tax,
                                employeePayroll.Net_Pay, employeePayroll.Gender);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data is found");
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Finding the sum of salary by gender.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void FindingSumOfSalaryByGender()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (connection)
                {
                    string query = @" Select Gender,SUM(Payroll.Basic_Pay) as Sum_salary from Payroll payroll inner join Employee emp 
                        on payroll.Employee_id = emp.Employee_id  group by Gender";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.Gender = Convert.ToChar(dataReader.GetString(0));
                            model.Basic_Pay = dataReader.GetDouble(1);
                            Console.WriteLine("{0},{1}", model.Gender, model.Basic_Pay);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data is found");
                    }
                    dataReader.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Finding the average of salary by gender.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void FindingAverageOfSalaryByGender()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (connection)
                {
                    string query = @"Select Gender,AVG(Payroll.Basic_Pay) as Avg_Pay from Payroll payroll inner join Employee emp
                                    on payroll.Employee_id = emp.Employee_id group by Gender; ";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.Gender = Convert.ToChar(dataReader.GetString(0));
                            model.Basic_Pay = dataReader.GetDouble(1);
                            Console.WriteLine("{0},{1}", model.Gender, model.Basic_Pay);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data is found");
                    }
                    dataReader.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Finding the minimum of salary by gender.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void FindingMinimumOfSalaryByGender()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (connection)
                {
                    string query = @"string query = @Select Gender, MIN(Payroll.Basic_Pay) as Min_Pay from Payroll payroll inner join Employee 
                                                      emp on payroll.Employee_id = emp.Employee_id group by Gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Gender = Convert.ToChar(reader.GetString(0));
                            model.Basic_Pay = reader.GetDouble(1);
                            Console.WriteLine("{0},{1}", model.Gender, model.Basic_Pay);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data is found");
                    }
                    reader.Close();
                   connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        /// <summary>
        /// Finding the maximum of salary by gender.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void FindingMaximumOfSalaryByGender()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (connection)
                {
                    string query = @"Select Gender,MAX(Payroll.Basic_Pay) as Max_Pay from Payroll payroll inner join Employee emp
                                    on payroll.Employee_id = emp.Employee_id group by Gender"; 
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Gender = Convert.ToChar(reader.GetString(0));
                            model.Basic_Pay = reader.GetDouble(1);
                            Console.WriteLine("{0},{1}", model.Gender, model.Basic_Pay);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data is found");
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Counts the contacts by gender.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void CountContactsByGender()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (connection)
                {
                    string query = @"Select Gender,COUNT(Payroll.Basic_Pay) as count from Payroll payroll inner join Employee emp
                                    on payroll.Employee_id = emp.Employee_id group by Gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0) + " " );
                            Console.WriteLine(reader.GetInt32(1));

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data is found");
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool DeleteTheEmployee(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("DeleteEmployees", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.Name);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("Number of rows affected : " + result);
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Adding the employee details to employee table.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool AddingEmployeeDetails(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("EmployeeInfo", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", model.Name);
                    sqlCommand.Parameters.AddWithValue("@Gender", model.Gender);
                    sqlCommand.Parameters.AddWithValue("@Mobile_Number", model.Mobile_number);
                    sqlCommand.Parameters.AddWithValue("@Address", model.Address);
                    connection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Number of rows affected : " + result);
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Adding the pay roll details to payroll table.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool AddingPayRollDetails(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("PayrollData", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Start_Date", model.Start_Date);
                    sqlCommand.Parameters.AddWithValue("@Basic_Pay", model.Basic_Pay);
                    sqlCommand.Parameters.AddWithValue("@Deductions", model.Deductions);
                    sqlCommand.Parameters.AddWithValue("@Income_Tax", model.Income_Tax);
                    sqlCommand.Parameters.AddWithValue("@Taxable_Pay", model.Taxable_Pay);
                    sqlCommand.Parameters.AddWithValue("@Net_Pay", model.Net_Pay);
                    sqlCommand.Parameters.AddWithValue("@employee_id", model.Employee_Id);

                    connection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Number of rows affected : " + result);
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Adding to the department table.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool AddingDepartment(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("DepartmentInfo", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Department_Name", model.Department);
                    connection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Number of rows affected : " + result);
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Adding to employee department table.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool AddingToEmployeeDepartment(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("Employee_DepartmentInfo", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Employee_Id", model.Employee_Id);
                    sqlCommand.Parameters.AddWithValue("@Department_Id", model.Department_Id);
                    connection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Number of rows affected : " + result);
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Getting the employee table details.
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public void GettingEmployeeDetails()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (connection)
                {
                    string query = @"SELECT Employee_Id,Name,Gender,Mobile_number,Address
                                    FROM Employee";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.Employee_Id = dataReader.GetInt32(0);
                            model.Name = dataReader.GetString(1);
                            model.Gender = Convert.ToChar(dataReader.GetString(2));
                            model.Mobile_number = dataReader.GetString(3);
                            model.Address = dataReader.GetString(4);
                            Console.WriteLine("{0},{1},{2},{3},{4}",
                                model.Employee_Id, model.Name, model.Gender,
                                model.Mobile_number, model.Address);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data is found");
                    }
                    dataReader.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        public bool AddEmployeeDetailsToMultipleTables(EmployeeModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spAddEmployeeIntoMultipleTable", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@Mobile_number", model.Mobile_number);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Basic_Pay", model.Basic_Pay);
                    command.Parameters.AddWithValue("@Start_Date", model.Start_Date);
                    command.Parameters.AddWithValue("@Department_Id", model.Department_Id);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("Number of rows affected : " + result);
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
               connection.Close();
            }
        }
    }
}
