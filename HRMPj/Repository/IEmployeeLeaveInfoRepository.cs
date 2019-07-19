using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
   public interface IEmployeeLeaveInfoRepository 
    {
        Task Save(EmployeeLeaveInfo ot);
        Task Update(EmployeeLeaveInfo ot);
        Task Delete(EmployeeLeaveInfo ot);
        List<EmployeeLeaveInfo> GeEmployeeLeaveList();
        List<EmployeeLeaveInfo> GetDetail();
        EmployeeLeaveInfo GetEdit(long? id);
        List<EmployeeLeaveInfo> GetDelete();
        EmployeeLeaveInfo GetDeleteList(long id);
        bool GetExit(long id);
    }
}
