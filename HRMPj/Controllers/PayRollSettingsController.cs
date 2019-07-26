using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMPj.Data;
using HRMPj.Models;
using HRMPj.Repository;

namespace HRMPj.Controllers
{
    public class PayRollSettingsController : Controller
    {
        private readonly IEmployeeInfoRepository employeeInfoRepository;
        private readonly IPayRollSettingRepository payRollSettingRepository;
        public PayRollSettingsController(IEmployeeInfoRepository e, IPayRollSettingRepository a)
        {
            this.payRollSettingRepository = a;
            this.employeeInfoRepository = e;

        }
        //private readonly ApplicationDbContext _context;

        //public PayRollSettingsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: PayRollSettings
        public IActionResult Index()
        {
           // var applicationDbContext = _context.PayRollSettings.Include(p => p.EmployeeInfo);
            return View(payRollSettingRepository.GetDetail());
        }

        // GET: PayRollSettings/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var payRollSetting = await _context.PayRollSettings
            //    .Include(p => p.EmployeeInfo)
            //   .FirstOrDefaultAsync(m => m.Id == id);
            var payRollSetting = payRollSettingRepository.GetDetail().FirstOrDefault(m => m.Id == id);
            if (payRollSetting == null)
            {
                return NotFound();
            }

            return View(payRollSetting);
        }

        // GET: PayRollSettings/Create
        public IActionResult Create()
        {
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName");
            return View();
        }

        // POST: PayRollSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OT,Bonus,LateDebuct,Tax,Allowance,Saving,Claim,BasicSalary,Loan,SavingPerMonth,EmployeeInfoId")] PayRollSettingViewModel payRollSetting)
        {
            if (ModelState.IsValid)
            {
                PayRollSetting pp = new PayRollSetting()
                {
                    OT = payRollSetting.OT,
                    BasicSalary = payRollSetting.BasicSalary,
                    Bonus = payRollSetting.Bonus,
                    LateDebuct = payRollSetting.LateDebuct,
                    Tax = payRollSetting.Tax,
                    Allowance = payRollSetting.Allowance,
                    Saving = payRollSetting.Saving,
                    Claim = payRollSetting.Claim,
                    Loan = payRollSetting.Loan,
                    SavingPerMonth = payRollSetting.SavingPerMonth,
                    EmployeeInfoId = payRollSetting.EmployeeInfoId
                };
                await payRollSettingRepository.Save(pp);
                //_context.Add(payRollSetting);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", payRollSetting.EmployeeInfoId);
            return View(payRollSetting);
        }

        // GET: PayRollSettings/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var payRollSetting = await _context.PayRollSettings.FindAsync(id);
            var payRollSetting = payRollSettingRepository.GetEdit(id);

            if (payRollSetting == null)
            {
                return NotFound();
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", payRollSetting.EmployeeInfoId);
            return View(payRollSetting);
        }

        // POST: PayRollSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,OT,Bonus,LateDebuct,Tax,Allowance,Saving,Claim,BasicSalary,Loan,SavingPerMonth,EmployeeInfoId")] PayRollSetting payRollSetting)
        {
            if (id != payRollSetting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(payRollSetting);
                    //await _context.SaveChangesAsync();
                    await payRollSettingRepository.Update(payRollSetting);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayRollSettingExists(payRollSetting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", payRollSetting.EmployeeInfoId);
            return View(payRollSetting);
        }

        // GET: PayRollSettings/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var payRollSetting = await _context.PayRollSettings
            //    .Include(p => p.EmployeeInfo)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var payRollSetting = payRollSettingRepository.GetDelete().FirstOrDefault(m => m.Id == id);
            if (payRollSetting == null)
            {
                return NotFound();
            }

            return View(payRollSetting);
        }

        // POST: PayRollSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var payRollSetting = await _context.PayRollSettings.FindAsync(id);
            //_context.PayRollSettings.Remove(payRollSetting);
            //await _context.SaveChangesAsync();
            var payRollSetting = payRollSettingRepository.GetDeleteList(id);
            await payRollSettingRepository.Delete(payRollSetting);
            return RedirectToAction(nameof(Index));
        }

        private bool PayRollSettingExists(long id)
        {
            return payRollSettingRepository.GetExit(id) ;
        }
    }
}
