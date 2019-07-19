using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
  public  interface ILeaveRequestApprovedUserRepository
    {
        Task Save(LeaveRequestApprovedUser ot);
        Task Update(LeaveRequestApprovedUser ot);
        Task Delete(LeaveRequestApprovedUser ot);
        List<LeaveRequestApprovedUser> GetLeaveRequestList();
        List<LeaveRequestApprovedUser> GetDetail();
        LeaveRequestApprovedUser GetEdit(long? id);
        List<LeaveRequestApprovedUser> GetDelete();
        LeaveRequestApprovedUser GetDeleteList(long id);
        bool GetExit(long id);
    }
}
