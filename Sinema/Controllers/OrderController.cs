using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sinema.ViewModels;

namespace Sinema.Controllers
{
    public class OrderController : Controller
    {
        [Authorize]
        public IActionResult MakeOrder(Schedule session, string filmName, int row, int place)
        {
            ViewBag.Session = session;
            ViewBag.FilmName = filmName;
            ViewBag.Row = row;
            ViewBag.Place = place;
            return View();
        }
    }
}
