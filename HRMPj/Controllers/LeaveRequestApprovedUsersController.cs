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
    public class LeaveRequestApprovedUsersController : Controller
    {
        public readonly ILeaveRequestRepository leaveRequestRepository;
        public readonly ILeaveRequestApprovedUserRepository leaveRequestApprovedUserRepository;
        public LeaveRequestApprovedUsersController(ILeaveRequestRepository oi, ILeaveRequestApprovedUserRepository ie)
        {
            this.leaveRequestRepository = oi;
            this.leaveRequestApprovedUserRepository = ie;
        }
        //    private readonly ApplicationDbContext _context;

        //    public LeaveRequestApprovedUsersController(ApplicationDbContext context)
        //    {
        //        _context = context;
        //    }

        // GET: LeaveRequestApprovedUsers
        public IActionResult Index()
        {
           // var applicationDbContext = _context.LeaveRequestApprovedUsers.Include(l => l.LeaveRequest);
            return View(leaveRequestApprovedUserRepository.GetDetail());
        }

        // GET: LeaveRequestApprovedUsers/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveRequestApprovedUser = await _context.LeaveRequestApprovedUsers
            //    .Include(l => l.LeaveRequest)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var leaveRequestApprovedUser = leaveRequestApprovedUserRepository.GetDetail().FirstOrDefault(m => m.Id == id);
            if (leaveRequestApprovedUser == null)
            {
                return NotFound();
            }

            return View(leaveRequestApprovedUser);
        }

        // GET: LeaveRequestApprovedUsers/Create
        public IActionResult Create()
        {
            ViewData["LeaveRequestId"] = new SelectList(leaveRequestRepository.GetLeaveRequestList(), "Id", "Id");
            return View();
        }

        // POST: LeaveRequestApprovedUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApprovedBy,ApprovedLevel,ApprovedStatus,LeaveRequestId")] LeaveRequestApprovedUserViewModel leaveRequestApprovedUser)
        {
            if (ModelState.IsValid)
            {
                LeaveRequestApprovedUser gg = new LeaveRequestApprovedUser()
                {
                    ApprovedBy = leaveRequestApprovedUser.ApprovedBy,
                    ApprovedLevel = leaveRequestApprovedUser.ApprovedLevel,
                    ApprovedStatus = leaveRequestApprovedUser.ApprovedStatus,
                    LeaveRequestId = leaveRequestApprovedUser.LeaveRequestId
                };
                //_context.Add(leaveRequestApprovedUser);
                //await _context.SaveChangesAsync();
                await leaveRequestApprovedUserRepository.Save(gg);
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaveRequestId"] = new SelectList(leaveRequestRepository.GetLeaveRequestList(), "Id", "Id", leaveRequestApprovedUser.LeaveRequestId);
            return View(leaveRequestApprovedUser);
        }

        // GET: LeaveRequestApprovedUsers/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //  var leaveRequestApprovedUser = await _context.LeaveRequestApprovedUsers.FindAsync(id);
            var leaveRequestApprovedUser = leaveRequestApprovedUserRepository.GetEdit(id);
            if (leaveRequestApprovedUser == null)
            {
                return NotFound();
            }
            ViewData["LeaveRequestId"] = new SelectList(leaveRequestRepository.GetLeaveRequestList(), "Id", "Id", leaveRequestApprovedUser.LeaveRequestId);
            return View(leaveRequestApprovedUser);
        }

        // POST: LeaveRequestApprovedUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ApprovedBy,ApprovedLevel,ApprovedStatus,LeaveRequestId")] LeaveRequestApprovedUser leaveRequestApprovedUser)
        {
            if (id != leaveRequestApprovedUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(leaveRequestApprovedUser);
                    //await _context.SaveChangesAsync();
                    await leaveRequestApprovedUserRepository.Update(leaveRequestApprovedUser);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestApprovedUserExists(leaveRequestApprovedUser.Id))
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
            ViewData["LeaveRequestId"] = new SelectList(leaveRequestRepository.GetLeaveRequestList(), "Id", "Id", leaveRequestApprovedUser.LeaveRequestId);
            return View(leaveRequestApprovedUser);
        }

        // GET: LeaveRequestApprovedUsers/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveRequestApprovedUser = await _context.LeaveRequestApprovedUsers
            //    .Include(l => l.LeaveRequest)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var leaveRequestApprovedUser = leaveRequestApprovedUserRepository.GetDelete().FirstOrDefault(m => m.Id == id);
            if (leaveRequestApprovedUser == null)
            {
                return NotFound();
            }

            return View(leaveRequestApprovedUser);
        }

        // POST: LeaveRequestApprovedUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var leaveRequestApprovedUser = await _context.LeaveRequestApprovedUsers.FindAsync(id);
            //_context.LeaveRequestApprovedUsers.Remove(leaveRequestApprovedUser);
            //await _context.SaveChangesAsync();
            var leaveRequestApprovedUser = leaveRequestApprovedUserRepository.GetDeleteList(id);
            await leaveRequestApprovedUserRepository.Delete(leaveRequestApprovedUser);
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveRequestApprovedUserExists(long id)
        {
            return leaveRequestApprovedUserRepository.GetExit(id) ;
        }
    }
}
