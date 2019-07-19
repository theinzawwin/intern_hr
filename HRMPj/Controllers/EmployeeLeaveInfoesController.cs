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
    public class EmployeeLeaveInfoesController : Controller
    {
        private readonly IEmployeeLeaveInfoRepository employeeLeaveInfoRepository;
        private readonly IEmployeeInfoRepository employeeInfoRepository;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        public EmployeeLeaveInfoesController(IEmployeeLeaveInfoRepository d,IEmployeeInfoRepository e,ILeaveTypeRepository f)
        {
            this.employeeLeaveInfoRepository = d;
            this.employeeInfoRepository = e;
            this.leaveTypeRepository = f;
        }

        //private readonly ApplicationDbContext _context;

        //public EmployeeLeaveInfoesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: EmployeeLeaveInfoes
        public IActionResult Index()
        {
           // var applicationDbContext = _context.EmployeeLeaveInfos.Include(e => e.EmployeeInfo).Include(e => e.LeaveType);
            return View(employeeLeaveInfoRepository.GeEmployeeLeaveList());
        }

        // GET: EmployeeLeaveInfoes/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var employeeLeaveInfo = await _context.EmployeeLeaveInfos
            //    .Include(e => e.EmployeeInfo)
            //    .Include(e => e.LeaveType)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var employeeLeaveInfo = employeeLeaveInfoRepository.GetDetail().FirstOrDefault(m => m.Id == id);
            if (employeeLeaveInfo == null)
            {
                return NotFound();
            }

            return View(employeeLeaveInfo);
        }

        // GET: EmployeeLeaveInfoes/Create
        public IActionResult Create()
        {
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id");
            ViewData["LeaveTypeId"] = new SelectList(leaveTypeRepository.GetLeaveTypeList(), "Id", "Id");
            return View();
        }

        // POST: EmployeeLeaveInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedDate,TotalDay,RemainDay,CreatedId,LeaveTypeId,EmployeeInfoId")] EmployeeLeaveInfoViewModel employeeLeaveInfo)
        {
            if (ModelState.IsValid)
            {
                EmployeeLeaveInfo dd = new EmployeeLeaveInfo()
                {
                    CreatedDate = employeeLeaveInfo.CreatedDate,
                    TotalDay = employeeLeaveInfo.TotalDay,
                    RemainDay = employeeLeaveInfo.RemainDay,
                    CreatedId = employeeLeaveInfo.CreatedId,
                    EmployeeInfoId = employeeLeaveInfo.EmployeeInfoId,
                    LeaveTypeId = employeeLeaveInfo.LeaveTypeId
                };
                //_context.Add(employeeLeaveInfo);
                //await _context.SaveChangesAsync();
                await employeeLeaveInfoRepository.Save(dd);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", employeeLeaveInfo.EmployeeInfoId);
            ViewData["LeaveTypeId"] = new SelectList(leaveTypeRepository.GetLeaveTypeList(), "Id", "Id", employeeLeaveInfo.LeaveTypeId);
            return View(employeeLeaveInfo);
        }

        // GET: EmployeeLeaveInfoes/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var employeeLeaveInfo = await _context.EmployeeLeaveInfos.FindAsync(id);
            var employeeLeaveInfo = employeeLeaveInfoRepository.GetEdit(id);
            if (employeeLeaveInfo == null)
            {
                return NotFound();
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", employeeLeaveInfo.EmployeeInfoId);
            ViewData["LeaveTypeId"] = new SelectList(leaveTypeRepository.GetLeaveTypeList(), "Id", "Id", employeeLeaveInfo.LeaveTypeId);
            return View(employeeLeaveInfo);
        }

        // POST: EmployeeLeaveInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CreatedDate,TotalDay,RemainDay,CreatedId,LeaveTypeId,EmployeeInfoId")] EmployeeLeaveInfo employeeLeaveInfo)
        {
            if (id != employeeLeaveInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(employeeLeaveInfo);
                    //await _context.SaveChangesAsync();
                    await employeeLeaveInfoRepository.Update(employeeLeaveInfo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeLeaveInfoExists(employeeLeaveInfo.Id))
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
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", employeeLeaveInfo.EmployeeInfoId);
            ViewData["LeaveTypeId"] = new SelectList(leaveTypeRepository.GetLeaveTypeList(), "Id", "Id", employeeLeaveInfo.LeaveTypeId);
            return View(employeeLeaveInfo);
        }

        // GET: EmployeeLeaveInfoes/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var employeeLeaveInfo = await _context.EmployeeLeaveInfos
            //    .Include(e => e.EmployeeInfo)
            //    .Include(e => e.LeaveType)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var employeeLeaveInfo = employeeLeaveInfoRepository.GetDelete().FirstOrDefault(m => m.Id == id);

            if (employeeLeaveInfo == null)
            {
                return NotFound();
            }

            return View(employeeLeaveInfo);
        }

        // POST: EmployeeLeaveInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var employeeLeaveInfo = await _context.EmployeeLeaveInfos.FindAsync(id);
            //_context.EmployeeLeaveInfos.Remove(employeeLeaveInfo);
            //await _context.SaveChangesAsync();
            var employeeLeaveInfo = employeeLeaveInfoRepository.GetDeleteList(id);
            await employeeLeaveInfoRepository.Delete(employeeLeaveInfo);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeLeaveInfoExists(long id)
        {
            return employeeLeaveInfoRepository.GetExit(id);
        }
    }
}
