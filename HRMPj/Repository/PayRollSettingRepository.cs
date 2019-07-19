using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class PayRollSettingRepository : IPayRollSettingRepository
    {
        private readonly ApplicationDbContext context;

        public PayRollSettingRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task Delete(PayRollSetting ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();

        }

        public List<PayRollSetting> GetDelete()
        {
            List<PayRollSetting> a = context.PayRollSettings.Include(p => p.EmployeeInfo).ToList();
            return a;
        }

        public PayRollSetting GetDeleteList(long id)
        {
            try
            {
                var com = context.PayRollSettings.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PayRollSetting> GetDetail()
        {
            List<PayRollSetting> a = context.PayRollSettings.Include(p => p.EmployeeInfo).ToList();
            return a;
        }

        public PayRollSetting GetEdit(long? id)
        {
            try
            {
                var com = context.PayRollSettings.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.PayRollSettings.Any(e => e.Id == id);
            return dd;
        }

        public List<PayRollSetting> GetPayRollSettingList()
        {
            List<PayRollSetting> bb = context.PayRollSettings.ToList();
            return bb;
        }

        public async Task Save(PayRollSetting ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();
        }

        public async Task Update(PayRollSetting ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }
    }
}
