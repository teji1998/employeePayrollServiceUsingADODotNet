using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    class EmployeeRepository
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
                            employeePayroll.Start_Date = reader.GetString(3);
                            employeePayroll.Gender = reader.GetString(4);
                            employeePayroll.Mobile_number = reader.GetString(5);
                            employeePayroll.Address = reader.GetString(6);
                            employeePayroll.Department = reader.GetString(7);
                            employeePayroll.Deductions = reader.GetDouble(8);
                            employeePayroll.Taxable_Pay = reader.GetDouble(9);
                            employeePayroll.Income_Tax = reader.GetDouble(10);
                            employeePayroll.Net_Pay = reader.GetDouble(11);
                            Console.WriteLine("Id:{0}\n Name:{1},\nBasic_Pay:{2},\nStart_Date:{3},\nGender:{4},\nMobile_number:{5},\nAddress:{6},\nDepartment:{7},\nDeductions{8},\nTaxable_Pay:{9}" +
                                "\nIncome_Tax:{10},\nNet_Pay:{11}", employeePayroll.ID, employeePayroll.Name, employeePayroll.Basic_Pay, employeePayroll.Start_Date, employeePayroll.Gender,
                                employeePayroll.Mobile_number, employeePayroll.Address, employeePayroll.Department, employeePayroll.Deductions, employeePayroll.Taxable_Pay, employeePayroll.Income_Tax,
                                employeePayroll.Net_Pay);
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
    }
}
