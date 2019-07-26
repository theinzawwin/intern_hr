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
    public class LeaveRequestsController : Controller
    {
        public readonly ILeaveRequestRepository leaveRequestRepository;
        public readonly ILeaveTypeRepository leaveTypeRepository;
        public LeaveRequestsController(ILeaveRequestRepository oi, ILeaveTypeRepository ie)
        {
            this.leaveRequestRepository = oi;
            this.leaveTypeRepository = ie;
        }
        //private readonly ApplicationDbContext _context;

        //public LeaveRequestsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: LeaveRequests
        public IActionResult Index()
        {
          //  var applicationDbContext = _context.LeaveRequests.Include(l => l.LeaveType);
            return View(leaveRequestRepository.GetDetail());
        }

        // GET: LeaveRequests/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveRequest = await _context.LeaveRequests
            //    .Include(l => l.LeaveType)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var leaveRequest = leaveRequestRepository.GetDetail().FirstOrDefault(m => m.Id == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            ViewData["LeaveTypeId"] = new SelectList(leaveTypeRepository.GetLeaveTypeList(), "Id", "TypeName");
            return View();
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CurrentYear,LeaveFromDate,LeaveToDate,LeaveTotalDay,HalfDay,HalfStatus,Status,Description,UnPaidLeaveStatus,PayRollStatus,LeaveTypeId")] LeaveRequestViewModel leaveRequest)
        {
            if (ModelState.IsValid)
            {
                LeaveRequest ll = new LeaveRequest()
                {
                    CurrentYear = leaveRequest.CurrentYear,
                    LeaveFromDate = leaveRequest.LeaveFromDate,
                    LeaveToDate = leaveRequest.LeaveToDate,
                    LeaveTotalDay = leaveRequest.LeaveTotalDay,
                    HalfDay = leaveRequest.HalfDay,
                    HalfStatus = leaveRequest.HalfStatus,
                    Status = leaveRequest.Status,
                    UnPaidLeaveStatus = leaveRequest.UnPaidLeaveStatus,
                    PayRollStatus = leaveRequest.PayRollStatus,
                    LeaveTypeId = leaveRequest.LeaveTypeId
                };
                //_context.Add(leaveRequest);
                //await _context.SaveChangesAsync();
                await leaveRequestRepository.Save(ll);
                return RedirectToAction(nameof(Index));
}
            ViewData["LeaveTypeId"] = new SelectList(leaveTypeRepository.GetLeaveTypeList(), "Id", "Id", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            var leaveRequest = leaveRequestRepository.GetEdit(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeId"] = new SelectList(leaveTypeRepository.GetLeaveTypeList(), "Id", "Id", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CurrentYear,LeaveFromDate,LeaveToDate,LeaveTotalDay,HalfDay,HalfStatus,Status,Description,UnPaidLeaveStatus,PayRollStatus,LeaveTypeId")] LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(leaveRequest);
                    //await _context.SaveChangesAsync();
                    await leaveRequestRepository.Update(leaveRequest);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.Id))
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
            ViewData["LeaveTypeId"] = new SelectList(leaveTypeRepository.GetLeaveTypeList(), "Id", "Id", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveRequest = await _context.LeaveRequests
            //    .Include(l => l.LeaveType)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var leaveRequest = leaveRequestRepository.GetDelete().FirstOrDefault(m => m.Id == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            //_context.LeaveRequests.Remove(leaveRequest);
            //await _context.SaveChangesAsync();
            var leaveRequest = leaveRequestRepository.GetDeleteList(id);
            await leaveRequestRepository.Delete(leaveRequest);
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveRequestExists(long id)
        {
            return leaveRequestRepository.GetExit(id);
        }
    }
}
