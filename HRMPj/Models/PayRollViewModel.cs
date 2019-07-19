using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class PayRollViewModel
    {
        public long Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal OTFee { get; set; }
        public decimal TotalAllowence { get; set; }
        public decimal Bonus { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal LateDebuct { get; set; }
        public decimal PenaltyFee { get; set; }
        public decimal TaxFee { get; set; }
        public decimal Saving { get; set; }
        public decimal NetPay { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string PrintStatus { get; set; }
        public string Claim { get; set; }

      
        public long EmployeeInfoId { get; set; }
        
    }
}
