using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class EmployeeLeaveInfoViewModel
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public long TotalDay { get; set; }
        public long RemainDay { get; set; }
        public string CreatedId { get; set; }
       
        public long LeaveTypeId { get; set; }
       
        
        public long EmployeeInfoId { get; set; }
       
    }
}
