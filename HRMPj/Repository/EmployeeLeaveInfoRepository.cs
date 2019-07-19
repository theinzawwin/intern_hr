using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class EmployeeLeaveInfoRepository : IEmployeeLeaveInfoRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeLeaveInfoRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task Delete(EmployeeLeaveInfo ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();
        }

        public List<EmployeeLeaveInfo> GeEmployeeLeaveList()
        {
            List<EmployeeLeaveInfo> bb = context.EmployeeLeaveInfos.ToList();
            return bb;
        }

        public List<EmployeeLeaveInfo> GetDelete()
        {
            List<EmployeeLeaveInfo> dd = context.EmployeeLeaveInfos.Include(e => e.EmployeeInfo).Include(e => e.LeaveType).ToList();
            return dd;
        }

        public EmployeeLeaveInfo GetDeleteList(long id)
        {
            try
            {
                var com = context.EmployeeLeaveInfos.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeLeaveInfo> GetDetail()
        {
            List<EmployeeLeaveInfo> dd = context.EmployeeLeaveInfos.Include(e => e.EmployeeInfo).Include(e => e.LeaveType).ToList();
            return dd;
        }

        public EmployeeLeaveInfo GetEdit(long? id)
        {
            try
            {
                var com = context.EmployeeLeaveInfos.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.EmployeeLeaveInfos.Any(e => e.Id == id);
            return dd;
        }

        public async Task Save(EmployeeLeaveInfo ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();
        }

        public async Task Update(EmployeeLeaveInfo ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }
    }
}
