using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class PayRollSettingViewModel
    {
        public long Id { get; set; }
        public Boolean OT { get; set; }
        public Boolean Bonus { get; set; }
        public Boolean LateDebuct { get; set; }
        public decimal Tax { get; set; }
        public Boolean Allowance { get; set; }
        public Boolean Saving { get; set; }
        public Boolean Claim { get; set; }
        public decimal BasicSalary { get; set; }
        public Boolean Loan { get; set; }
        public decimal SavingPerMonth { get; set; }
        public long EmployeeInfoId { get; set; }
    }

}

