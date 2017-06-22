using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShouYe()
        {
            return View();
        }
        public JsonResult send(string message)
        {
            var context = GlobalHost.ConnectionManager.GetConnectionContext<MyConnection1>();
            //aaa.Connection.Send(message);
            message = message.Replace("玫瑰花","<img src='../../Image/mgh.png' style='width:30px; height: 50px'></img>");
            context.Connection.Broadcast(message);
            return Json(new { a = "success" }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult H5()
        {
            return View();
        }
    }
}
