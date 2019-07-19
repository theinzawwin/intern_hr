using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("LeaveRequestApprovedUser")]
    public class LeaveRequestApprovedUser
    {
        [Key]
        public long Id { get; set; }
        public string ApprovedBy { get; set; }
        public long ApprovedLevel { get; set; }
        public string ApprovedStatus { get; set; }
        [ForeignKey("LeaveRequestId")]
        public long LeaveRequestId { get; set; }
        public virtual LeaveRequest LeaveRequest { get; set; }
    }
}
