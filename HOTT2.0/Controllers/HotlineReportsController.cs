using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HOTT2._0.Models;

namespace HOTT2._0.Controllers
{
    public class HotlineReportsController : Controller
    {
        private HOTTEntities db =new HOTTEntities();

        // GET: HotlineReports
        public ActionResult Index()
        {
            return View(db.HoTT_Hotline_Report_Rawdata.ToList().Take(100));
        }

       
   
 
 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
