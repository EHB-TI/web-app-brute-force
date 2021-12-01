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

        public bool checkAvailableSeats(int SessionId)
        {
            Session session = _context.Sessions.Where(p => p.SessionID == SessionId).First();
            Car car = _context.Cars.Where(p => p.ID == session.CarID).First();
            int number = _context.CustomerSessions.Where(p => p.SessionId == SessionId).Count();
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
            bool check = checkAvailableSeats(Join);
            if (!check)
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
            CustomerSession customerSession = new CustomerSession() { SessionId = Join, CustomerId = authUser.Id, Customer = authUser};
            _context.Add(customerSession);
            _context.SaveChanges();
            TempData["AlertBox"] = "Session joined successfully !";
            return View("index");
        }

        // GET: SearchController
        public  ActionResult Index(int? zipCode)
        {
            if (zipCode == null)
            {
                return View();
            }
            List<Session> sessions = _context.Sessions.Where(p => p.Address.Zipcode == zipCode && p.Status == Status.OPEN ).ToList();
            foreach(Session item in sessions)
            {
                if (checkAvailableSeats(item.SessionID) == false)
                {
                    sessions.Remove(item);
                }
                else
                {
                    item.Available = checkAvailableSeats(item.SessionID);
                    item.Car = _context.Cars.Where(p => p.ID == item.CarID).FirstOrDefault();
                    item.Address = _context.Addresses.Where(p => p.Id == item.AddressId).FirstOrDefault();
                }
            }
            return View(sessions);
        }
    }
}
