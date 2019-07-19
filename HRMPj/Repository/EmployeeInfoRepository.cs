using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class EmployeeInfoRepository : IEmployeeInfoRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeInfoRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public List<EmployeeInfo> GetCreate()
        {
            List<EmployeeInfo> emp = context.EmployeeInfos.Include(e => e.Branch).Include(e => e.Department).Include(e => e.Designation).ToList();
            return emp;
        }

        public List<EmployeeInfo> GetEmployeeInfoList()
        {
            List<EmployeeInfo> bb = context.EmployeeInfos.ToList();
            return bb;
        }

        public async Task Save(EmployeeInfo b)
        {
            context.Add(b);
            await context.SaveChangesAsync();
         }
    }
}
