using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class LeaveRequestApprovedUserRepository : ILeaveRequestApprovedUserRepository
    {
        private readonly ApplicationDbContext context;

        public LeaveRequestApprovedUserRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public async Task Delete(LeaveRequestApprovedUser ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();
        }

        public List<LeaveRequestApprovedUser> GetDelete()
        {

            List<LeaveRequestApprovedUser> lt = context.LeaveRequestApprovedUsers.Include(l => l.LeaveRequest).ToList();
            return lt;
        }

        public LeaveRequestApprovedUser GetDeleteList(long id)
        {
            try
            {
                var com = context.LeaveRequestApprovedUsers.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LeaveRequestApprovedUser> GetDetail()
        {
            List<LeaveRequestApprovedUser> lt = context.LeaveRequestApprovedUsers.Include(l => l.LeaveRequest).ToList();
            return lt;
        }

        public LeaveRequestApprovedUser GetEdit(long? id)
        {
            try
            {
                var com = context.LeaveRequestApprovedUsers.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.LeaveRequestApprovedUsers.Any(e => e.Id == id);
            return dd;
        }

        public List<LeaveRequestApprovedUser> GetLeaveRequestList()
        {
            List<LeaveRequestApprovedUser> bb = context.LeaveRequestApprovedUsers.ToList();
            return bb;
        }

        public async Task Save(LeaveRequestApprovedUser ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();
        }

        public async Task Update(LeaveRequestApprovedUser ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }
    }
}
