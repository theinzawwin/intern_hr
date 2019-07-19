using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("LeaveRequest")]
    public class LeaveRequest
    {
        [Key]
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
        [ForeignKey("LeaveTypeId")]
        public long LeaveTypeId { get; set; }
        public virtual LeaveType LeaveType { get; set; }
        public ICollection<LeaveRequestApprovedUser> LeaveRequestApprovedUser { get; set; }
    }
}
