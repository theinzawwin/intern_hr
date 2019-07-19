using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class LeaveRequestViewModel
    {
        public long Id { get; set; }
        public long CurrentYear { get; set; }
        public DateTime LeaveFromDate { get; set; }
        public DateTime LeaveToDate { get; set; }
        public long LeaveTotalDay { get; set; }
        public string HalfDay { get; set; }
        public string HalfStatus { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string UnPaidLeaveStatus { get; set; }
        public string PayRollStatus { get; set; }
    
        public long LeaveTypeId { get; set; }
     
    }
}
