using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    class EmployeeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Basic_Pay { get; set; }
        public string Start_Date { get; set; }
        public string Gender { get; set; }
        public string Mobile_number { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public double Deductions { get; set; }
        public double Taxable_Pay { get; set; }
        public double Income_Tax { get; set; }
        public double Net_Pay { get; set; }
    }
}

