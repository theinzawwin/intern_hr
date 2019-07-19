using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class LeaveRequestApprovedUserViewModel
    {
        public long Id { get; set; }
        public string ApprovedBy { get; set; }
        public long ApprovedLevel { get; set; }
        public string ApprovedStatus { get; set; }
     
        public long LeaveRequestId { get; set; }
    
    }
}
