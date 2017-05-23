using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostalCode.Controllers
{
    public class StatesController : Controller
    {
        // GET: States
        public ActionResult Index()
        {
            PostalCode.Models.LoadPage lp = new PostalCode.Models.LoadPage();

            return View(lp.LoadFirstList());
        }
      /*  public ActionResult Details(int id)
        {
            PostalCode.Models.LoadPage lp = new PostalCode.Models.LoadPage();
            return View(lp.LoadByState(id));
        }*/

        public ActionResult Details(string name)
        {
            PostalCode.Models.LoadPage lp = new PostalCode.Models.LoadPage();
            return View(lp.LoadByStateName(name));
        }
    }
}