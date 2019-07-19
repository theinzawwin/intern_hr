using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
  public interface IPayRollSettingRepository
    {
        Task Save(PayRollSetting ot);
        Task Update(PayRollSetting ot);
        Task Delete(PayRollSetting ot);
        List<PayRollSetting> GetPayRollSettingList();
        List<PayRollSetting> GetDetail();
        PayRollSetting GetEdit(long? id);
        List<PayRollSetting> GetDelete();
        PayRollSetting GetDeleteList(long id);
        bool GetExit(long id);
    }
}
