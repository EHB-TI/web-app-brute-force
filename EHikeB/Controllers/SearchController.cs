using EHikeB.Data;
using EHikeB.Models;
using Microsoft.AspNetCore.Http;
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
        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public List<Session> getSessions(string postal, string date)
        //{
        //    _context.Sessions.Where(s => s);
        //}


        // GET: SearchController
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Index(string? postal, string? date)
        {

            return View();
        }
    }
}
