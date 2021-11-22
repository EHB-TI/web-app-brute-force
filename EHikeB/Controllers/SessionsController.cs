using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EHikeB.Data;
using EHikeB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace EHikeB.Controllers
{
    [Authorize]
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Customer> _userManager;


        public SessionsController(ApplicationDbContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: Sessions
        public async Task<IActionResult> Index()
        {
            Customer authUser = await _userManager.GetUserAsync(User);
            List<CustomerSession> customerSessions = _context.CustomerSessions.Where(p => p.CustomerId == authUser.Id).ToList();
            var sessions = new List<Session>();
            foreach (var customerSession in customerSessions)
            {
                var session = _context.Sessions.Where(p => p.SessionID == customerSession.SessionId).FirstOrDefault();
                sessions.Add(session);
            }
            var my_sessions = _context.Sessions.Where(p => p.DriverId == authUser.Id).ToList();
            ViewBag.My_Sessions = my_sessions;
            return View(sessions);

        }

        // GET: Sessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Customer authUser = await _userManager.GetUserAsync(User);


            var session = await _context.Sessions
                .FirstOrDefaultAsync(m => m.SessionID == id);
            if (session == null || session.DriverId != authUser.Id )
            {
                return RedirectToAction("Index");
            }

            session.Car = await _context.Cars.FirstOrDefaultAsync(x => x.ID == session.CarID);
            session.Address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == session.AddressId);




            return View(session);
        }

        // GET: Sessions/Create
        public async Task<IActionResult> CreateAsync()
        {
            Customer authUser = await _userManager.GetUserAsync(User);
            var cars = new SelectList(_context.Cars.Where(x => x.CustomerID == authUser.Id).Select(x => x.Model));


            if (cars == null || cars.Count() <= 0)
            {
                return RedirectToAction("Create", "Cars");
            }

            var addresses = new SelectList(_context.Addresses.Where(x => x.CustomerId == authUser.Id).Select(x => x.StreetName));
            if (addresses == null || addresses.Count() <= 0)
            {
                return RedirectToAction("Create", "Addresses");
            }


            ViewBag.Cars = cars;
            ViewBag.Adress = addresses;

            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("SessionID,StartLocation,EndLocation,StartTime,DeviationTime,Status,PaiementMethod")] Session session)
        {
            Customer authUser = await _userManager.GetUserAsync(User);

            string car_name = Request.Form["car"];
            string street = Request.Form["adress"];

            Car car = await _context.Cars.FirstOrDefaultAsync(x => x.Model == car_name);
            Address adress = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == street);


            if (ModelState.IsValid)
            {

                session.Driver = authUser;
                session.Car = car;
                session.Address = adress;
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            var cars = new SelectList(_context.Cars.Where(x => x.CustomerID == authUser.Id).Select(x => x.Model));


            if (cars == null || cars.Count() <= 0)
            {
                return RedirectToAction("Create", "Cars");
            }

            var addresses = new SelectList(_context.Addresses.Where(x => x.CustomerId == authUser.Id).Select(x => x.StreetName));
            if (addresses == null || addresses.Count() <= 0)
            {
                return RedirectToAction("Create", "Addresses");
            }


            ViewBag.Cars = cars;
            ViewBag.Adress = addresses;


            return View(session);
        }

        

        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .FirstOrDefaultAsync(m => m.SessionID == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(int id)
        {
            return _context.Sessions.Any(e => e.SessionID == id);
        }
    }
}