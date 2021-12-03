using EHikeB.Data;
using EHikeB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHikeB.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Customer> _userManager;
        public SearchController(ApplicationDbContext context, UserManager<Customer> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public bool checkAvailableSeats(Session session)
        {
            Car car = _context.Cars.Where(p => p.ID == session.CarID).First();
            int number = _context.CustomerSessions.Where(p => p.SessionId == session.SessionID).Count();
            if(number == car.Seats-1)
            {
                return false;
            }
            return true;
        }
        public bool checkJoined(Session session, Customer customer)
        {
            if(_context.CustomerSessions.Where(p => p.SessionId == session.SessionID && p.CustomerId == customer.Id).ToList().Count() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<ActionResult> Join(int Join)
        {
            var session = _context.Sessions.Where(s => s.SessionID == Join).First();
            if (!checkAvailableSeats(session))
            {
                TempData["AlertBox"] = "Session already full";
                return View("index");
            }
            Customer authUser = await _userManager.GetUserAsync(User);
            if(checkJoined(session, authUser))
            {
                TempData["AlertBox"] = "Session already joined";
                return View("index");
            }
            CustomerSession customerSession = new CustomerSession() { SessionId = Join, CustomerId = authUser.Id, Customer = authUser, Session = session};
            _context.Add(customerSession);
            _context.SaveChanges();
            TempData["AlertBox"] = "Session joined successfully !";
            return View("index");
        }

        public async Task<ActionResult> Leave(int Leave)
        {
            var session = _context.Sessions.Where(s => s.SessionID == Leave).First();
            Customer authUser = await _userManager.GetUserAsync(User);
            if (!checkJoined(session, authUser))
            {
                return View("index");
            }
            CustomerSession customerSession = _context.CustomerSessions.Where(p => p.SessionId == session.SessionID && p.CustomerId == authUser.Id).First();
            _context.Remove(customerSession);
            _context.SaveChanges();
            TempData["AlertBox"] = "Session left successfully !";
            return View("index");
        }

        // GET: SearchController
        public async Task<ActionResult> Index(int? zipCode)
        {
            if (zipCode == null)
            {
                return View();
            }
            Customer authUser = await _userManager.GetUserAsync(User);
            List<Session> sessions = _context.Sessions.Where(p => p.Address.Zipcode == zipCode && p.Status == Status.OPEN && p.DriverId != authUser.Id ).ToList();
            foreach(Session item in sessions)
            {
                if (checkAvailableSeats(item) == false)
                {
                    sessions.Remove(item);
                }
                else
                {
                    item.Available = !checkJoined(item, authUser);
                    item.Car = _context.Cars.Where(p => p.ID == item.CarID).FirstOrDefault();
                    item.Address = _context.Addresses.Where(p => p.Id == item.AddressId).FirstOrDefault();
                }
            }
            return View(sessions);
        }
    }
}
