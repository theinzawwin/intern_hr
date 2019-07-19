using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{

    [Table("EmployeeLeaveInfo")]
    public class EmployeeLeaveInfo
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public long TotalDay { get; set; }
        public long RemainDay { get; set; }
        public string CreatedId { get; set; }
        [ForeignKey("LeaveTypeId")]
        public long LeaveTypeId { get; set; }
        public virtual LeaveType LeaveType { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public long EmployeeInfoId { get; set; }
        public virtual EmployeeInfo EmployeeInfo { get; set; }
    }
}
