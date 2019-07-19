using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext context;

        public LeaveRequestRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public async Task Delete(LeaveRequest ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();
        }

        public List<LeaveRequest> GetDelete()
        {
            List<LeaveRequest> lt = context.LeaveRequests.Include(l => l.LeaveType).ToList();
            return lt;
        }

        public LeaveRequest GetDeleteList(long id)
        {
            try
            {
                var com = context.LeaveRequests.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LeaveRequest> GetDetail()
        {
            List<LeaveRequest> lt = context.LeaveRequests.Include(l => l.LeaveType).ToList();
            return lt;
        }

        public LeaveRequest GetEdit(long? id)
        {
            try
            {
                var com = context.LeaveRequests.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.LeaveRequests.Any(e => e.Id == id);
            return dd;
        }

        public List<LeaveRequest> GetLeaveRequestList()
        {
            List<LeaveRequest> bb = context.LeaveRequests.ToList();
            return bb;
        }

        public async Task Save(LeaveRequest ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();
        }

        public async Task Update(LeaveRequest ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }
    }

}

