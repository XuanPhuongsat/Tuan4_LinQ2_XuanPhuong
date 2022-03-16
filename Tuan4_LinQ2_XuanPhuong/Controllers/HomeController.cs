using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan4_LinQ2_XuanPhuong.Models;
using PagedList;

namespace Tuan4_LinQ2_XuanPhuong.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {
            //var all_sach = from s in data.Saches select s;
            //return View(all_sach);
            //return View();
            //----
            if (page == null) page = 1;
            var all_sach = (from s in data.Saches select s).OrderBy(m => m.masach);
            int pagesize = 6;
            int pagenum = page ?? 1;
            return View(all_sach.ToPagedList(pagenum,pagesize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // GET : Order
        MyDataDataContext data = new MyDataDataContext();
        

    }
}