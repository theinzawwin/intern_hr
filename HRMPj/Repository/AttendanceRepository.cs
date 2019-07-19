using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class AttendanceRepository : IAttendance
    {
        private readonly ApplicationDbContext context;

        public AttendanceRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task Delete(Attendance ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();
        }

        public List<Attendance> GetAttendanceList()
        {
            List<Attendance> bb = context.Attendances.ToList();
            return bb;
        }

        public List<Attendance> GetDelete()
        {
            List<Attendance> lt = context.Attendances.Include(a => a.EmployeeInfo).ToList();
            return lt;
        }

        public Attendance GetDeleteList(long id)
        {
            try
            {
                var com = context.Attendances.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Attendance> GetDetail()
        {
            List<Attendance> lt = context.Attendances.Include(a => a.EmployeeInfo).ToList();
            return lt;
        }

        public Attendance GetEdit(long? id)
        {
            try
            {
                var com = context.Attendances.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.Attendances.Any(e => e.Id == id);
            return dd;
        }

        public async Task Save(Attendance ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();
        }

        public async Task Update(Attendance ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }
    }
}
