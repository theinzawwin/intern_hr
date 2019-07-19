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
    public class AttendancesController : Controller
    {
        private readonly IEmployeeInfoRepository employeeInfoRepository;
        private readonly IAttendance attendanceRepository;
        public AttendancesController( IEmployeeInfoRepository e,IAttendance a)
        {
            this.attendanceRepository = a;
            this.employeeInfoRepository = e;
        }
        //private readonly ApplicationDbContext _context;

        //public AttendancesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Attendances
        public IActionResult Index()
        {
          //  var applicationDbContext = _context.Attendance.Include(a => a.EmployeeInfo);
            return View(attendanceRepository.GetAttendanceList());
        }

        // GET: Attendances/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var attendance = await _context.Attendance
            //    .Include(a => a.EmployeeInfo)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var attendance = attendanceRepository.GetDetail().FirstOrDefault(m => m.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        public IActionResult Create()
        {
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AttendanceDate,InTime,OutTime,CreatedDate,CreatedBy,EarlyInTime,EarlyOutTime,LateInTime,LateOutTime,EmployeeInfoId")] AttendanceViewModel attendance)
        {
            if (ModelState.IsValid)
            {
                Attendance at = new Attendance()
                {
                    AttendanceDate = attendance.AttendanceDate,
                    InTime = attendance.InTime,
                    OutTime = attendance.OutTime,
                    CreatedBy = attendance.CreatedBy,
                    CreatedDate = attendance.CreatedDate,
                    EarlyInTime = attendance.EarlyInTime,
                    EarlyOutTime = attendance.EarlyOutTime,
                    LateInTime = attendance.LateInTime,
                    LateOutTime = attendance.LateOutTime,
                    EmployeeInfoId = attendance.EmployeeInfoId
                };
                await attendanceRepository.Save(at);
                //_context.Add(attendance);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", attendance.EmployeeInfoId);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var attendance = await _context.Attendance.FindAsync(id);
            var attendance = attendanceRepository.GetEdit(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", attendance.EmployeeInfoId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,AttendanceDate,InTime,OutTime,CreatedDate,CreatedBy,EarlyInTime,EarlyOutTime,LateInTime,LateOutTime,EmployeeInfoId")] Attendance attendance)
        {
            if (id != attendance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(attendance);
                    //await _context.SaveChangesAsync();
                    await attendanceRepository.Update(attendance);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.Id))
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
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", attendance.EmployeeInfoId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var attendance = await _context.Attendance
            //    .Include(a => a.EmployeeInfo)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var attendance = attendanceRepository.GetDelete().FirstOrDefault(m => m.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var attendance = await _context.Attendance.FindAsync(id);
            //_context.Attendance.Remove(attendance);
            //await _context.SaveChangesAsync();
            var attendance = attendanceRepository.GetDeleteList(id);
            await attendanceRepository.Delete(attendance);
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(long id)
        {
            return attendanceRepository.GetExit(id);
        }
    }
}
