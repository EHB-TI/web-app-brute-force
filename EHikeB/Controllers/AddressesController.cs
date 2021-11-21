using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EHikeB.Data;
using EHikeB.Models;
using Microsoft.AspNetCore.Identity;

namespace EHikeB.Controllers
{
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Customer> _userManager;

        public AddressesController(ApplicationDbContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            Customer authUser = await _userManager.GetUserAsync(User);
            var applicationDbContext = _context.Addresses.Include(a => a.Location).Where(p => p.CustomerId == authUser.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer authUser = await _userManager.GetUserAsync(User);

            var address = await _context.Addresses
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (address == null || address.CustomerId != authUser.Id)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StreetName,StreetNumber,LocationId,Longitude,Latitude,CustomerId")] Address address)
        {
            if (ModelState.IsValid)
            {

                string zipcode = Request.Form["ZipCode"];
                int myZip = Int32.Parse(zipcode);
                Location myLoc = _context.Locations.Where(p => p.zip == myZip).First();
                if (myLoc == null)
                {
                    myLoc = new Location { city = "", zip = 0000 };
                }
                Customer authUser = await _userManager.GetUserAsync(User);
                address.Location = myLoc;
                address.CustomerId = authUser.Id;
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", address.LocationId);
            return View(address);
        }


        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer authUser = await _userManager.GetUserAsync(User);
            var address = await _context.Addresses
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null || address.CustomerId != authUser.Id)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
