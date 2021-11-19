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
        // GET: SearchController
        public ActionResult Index()
        {
            return View();
        }

    }
}
