using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnyOffice.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult TestData(int page, int rows)
        {
            List<object> list = new List<object>();
            for (var i = 0; i < 1000; i++)
            {
                list.Add(new { Id = i + 1, FullName = "张奎爱柯静_" + (i + 1), UserName = "Quaider_" + (i + 1) });
            }

            int count = list.Count();

            list = list.Skip((page - 1)*rows).Take(rows).ToList();

            var model = new { rows = list, total = count };

            return Json(model);
        }

    }
}
