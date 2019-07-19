using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
   public interface IEmployeeInfoRepository
    {
        Task Save(EmployeeInfo b);
        List<EmployeeInfo> GetCreate();
        List<EmployeeInfo> GetEmployeeInfoList();
    }
}
