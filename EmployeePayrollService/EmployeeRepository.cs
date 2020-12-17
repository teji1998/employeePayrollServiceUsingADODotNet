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
        SqlConnection connection = new SqlConnection(connectionString);

        public void GetEmployees()
        {
            try
            {
                EmployeeModel employeePayroll = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select ID ,Name,Basic_Pay, Start_Date ,Gender,Mobile_number,Address , Department ,Deductions,Taxable_Pay ,Income_Tax ,Net_Pay from Employee_Payroll;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    this.connection.Open();
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
                            employeePayroll.Gender = reader.GetChar(11);
                            Console.WriteLine("Id:{0}\n Name:{1},\nBasic_Pay:{2},\nStart_Date:{3},\nMobile_number:{4},\nAddress:{5},\nDepartment:{6},\nDeductions{7},\nTaxable_Pay:{8}" +
                                "\nIncome_Tax:{9},\nNet_Pay:{10},\nGender:{ 4}", employeePayroll.ID, employeePayroll.Name, employeePayroll.Basic_Pay, employeePayroll.Start_Date,
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
                this.connection.Close();
            }
        }

        public bool AddEmployee(EmployeeModel model)
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
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@Mobile_number", model.Mobile_number);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@Taxable_Pay", model.Taxable_Pay);
                    command.Parameters.AddWithValue("@Income_Tax", model.Income_Tax);
                    command.Parameters.AddWithValue("@Net_Pay", model.Net_Pay);
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

        public bool UpdateEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spUpdateEmployees", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    this.connection.Open();
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
                this.connection.Close();
            }
        }


        public void GetEmployeesInDateRange()
        {
            try
            {
                EmployeeModel employeePayroll = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select * from Employee_Payroll Where Start_Date between CAST ('2020-04-14' AS DATE) And  GETDATE();";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
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
                            employeePayroll.Gender = reader.GetChar(11);
                            Console.WriteLine("Id:{0}\n Name:{1},\nBasic_Pay:{2},\nStart_Date:{3},\nMobile_number:{4},\nAddress:{5},\nDepartment:{6},\nDeductions{7},\nTaxable_Pay:{8}" +
                                "\nIncome_Tax:{9},\nNet_Pay:{10},\nGender:{ 4}", employeePayroll.ID, employeePayroll.Name, employeePayroll.Basic_Pay, employeePayroll.Start_Date,
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
                    this.connection.Close();
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

        public void FindingSumOfSalaryByGender()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (this.connection)
                {
                    string query = @" Select Gender,SUM(Basic_Pay) as SUM_OF_SALARY From Employee_Payroll group by Gender";

                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.Gender = dataReader.GetChar(0);
                            model.Basic_Pay = dataReader.GetDouble(1);
                            Console.WriteLine("{0},{1}", model.Gender, model.Basic_Pay);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data is found");
                    }
                    dataReader.Close();
                    this.connection.Close();
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

        public void FindingAverageOfSalaryByGender()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select Gender,AVG(Basic_Pay) from Employee_Payroll group by Gender";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            model.Gender = dataReader.GetChar(0);
                            model.Basic_Pay = dataReader.GetDouble(1);
                            Console.WriteLine("{0},{1}", model.Gender, model.Basic_Pay);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data is found");
                    }
                    dataReader.Close();
                    this.connection.Close();
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

        public void FindingMinimumOfSalaryByGender()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                SqlConnection connection = new SqlConnection(connectionString);
                using (this.connection)
                {
                    string query = @"Select Gender,MIN(Basic_Pay) from Employee_Payroll group by Gender";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Gender = reader.GetChar(0);
                            model.Basic_Pay = reader.GetDouble(1);
                            Console.WriteLine("{0},{1}", model.Gender, model.Basic_Pay);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data is found");
                    }
                    reader.Close();
                    this.connection.Close();
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

        public void FindingMaximumOfSalaryByGender()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                EmployeeModel model = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select Gender,MAX(Basic_Pay) from Employee_Payroll group by Gender";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Gender = reader.GetChar(0);
                            model.Basic_Pay = reader.GetDouble(1);
                            Console.WriteLine("{0},{1}", model.Gender, model.Basic_Pay);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data is found");
                    }
                    reader.Close();
                    this.connection.Close();
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

        public void CountOContactsByGender()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                EmployeeModel model = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select Gender,COUNT(Gender) from Employee_Payroll group by Gender";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
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
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public bool DeleteTheEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("DeleteEmployees", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.Name);
                    this.connection.Open();
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
                this.connection.Close();
            }
        }

        public bool AddingEmployeeDetails(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("EmployeeInfo", this.connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", model.Name);
                    sqlCommand.Parameters.AddWithValue("@Gender", model.Gender);
                    sqlCommand.Parameters.AddWithValue("@Mobile_Number", model.Mobile_number);
                    sqlCommand.Parameters.AddWithValue("@Address", model.Address);
                    this.connection.Open();
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
                this.connection.Close();
            }
        }
        public bool AddingPayRollDetails(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("PayrollData", this.connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Start_Date", model.Start_Date);
                    sqlCommand.Parameters.AddWithValue("@Basic_Pay", model.Basic_Pay);
                    sqlCommand.Parameters.AddWithValue("@Deductions", model.Deductions);
                    sqlCommand.Parameters.AddWithValue("@Income_Tax", model.Income_Tax);
                    sqlCommand.Parameters.AddWithValue("@Taxable_Pay", model.Taxable_Pay);
                    sqlCommand.Parameters.AddWithValue("@Net_Pay", model.Net_Pay);
                    sqlCommand.Parameters.AddWithValue("@employee_id", model.Employee_Id);

                    this.connection.Open();
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
                this.connection.Close();
            }
        }
        public bool AddingDepartment(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("DepartmentInfo", this.connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Department_Name", model.Department);
                    this.connection.Open();
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
                this.connection.Close();
            }
        }
        public bool AddingToEmployeeDepartment(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("Employee_DepartmentInfo", this.connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Employee_Id", model.Employee_Id);
                    sqlCommand.Parameters.AddWithValue("@Department_Id", model.Department_Id);
                    this.connection.Open();
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
                this.connection.Close();
            }
        }
    }
}
