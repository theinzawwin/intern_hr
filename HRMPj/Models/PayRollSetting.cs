using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("PayRollSetting")]
    public class PayRollSetting
    {
        [Key]
        public long Id { get; set; }
        public Boolean OT { get; set; }
        public Boolean Bonus { get; set; }
        public Boolean LateDebuct { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Tax { get; set; }
        public Boolean Allowance { get; set; }
        public Boolean Saving { get; set; }
        public Boolean Claim { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BasicSalary { get; set; }
        public Boolean Loan { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SavingPerMonth { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public long EmployeeInfoId { get; set; }
        public virtual EmployeeInfo EmployeeInfo { get; set; }
        

    }
}
