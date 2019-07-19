using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class AttendanceViewModel
    {
        public long Id { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime EarlyInTime { get; set; }
        public DateTime EarlyOutTime { get; set; }
        public DateTime LateInTime { get; set; }
        public DateTime LateOutTime { get; set; }
        public long EmployeeInfoId { get; set; }
       
    }
}
