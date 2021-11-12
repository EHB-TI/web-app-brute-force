using EHikeB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHikeB.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<Customer> _userManager;
        public DashboardController(UserManager<Customer> userManager)
        {
            _userManager = userManager;
        }

        /*[Authorize]
         */
        public async Task<IActionResult> IndexAsync()
        {
            var customer = await _userManager.GetUserAsync(User);

            var viewModel = new DashboardViewModel();

            viewModel.Cars = getHardcodedCars();
            viewModel.Sessions = getHardCodedSessions();


            return View(viewModel);
        }

        public List<Car> getHardcodedCars()
        {
            return new List<Car>
            {
                new Car(1, "Audi r8", 2, Energy.DIESEL, "1-ret-215", "jsp"),
                new Car(5, "Mercedes Class A", 5, Energy.DIESEL, "1-ret-215", "jsp")
            };

        }
       public List<Session> getHardCodedSessions()
        {
            return new List<Session>
            {
                new Session(1,"rue de la commtesse de flandre","Ehb",DateTime.Today,DateTime.Today.AddHours(1),Status.OPEN),
                new Session(2,"Rue tivoli","Ehb",DateTime.Today,DateTime.Today.AddHours(1),Status.ARCHIVED)
            };
        }
    }
}
