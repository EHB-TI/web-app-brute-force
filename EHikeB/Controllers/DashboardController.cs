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

            Car car = new Car();
            car.ID = 1;
            car.Model = "Audi R8";
            car.Seats = 2;
            car.Energy = Energy.BENZINE;
            car.Plate = "1-ret-215";

            Car car2 = new Car();
            car2.ID = 2;
            car2.Model = "Mercedes";
            car2.Seats = 2;
            car2.Energy = Energy.BENZINE;
            car2.Plate = "1-ret-156";

            return  new List<Car> { car, car2 };

           

        }
       public List<Session> getHardCodedSessions()
        {
            Session session= new Session();
            session.SessionID = 1;
            session.Status = Status.OPEN;
            session.StartLocation = "Rue de la comtesse de flandre";
            session.StartTime = DateTime.Now;
            session.EndLocation = "EHB";
            session.DeviationTime = DateTime.Now.AddMinutes(15);

            return new List<Session> {session };
        }
    }
}
