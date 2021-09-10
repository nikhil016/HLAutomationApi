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
    public class HoTT_Hotline_Report_RawdataController : Controller
    {
        private HOTTEntities db = new HOTTEntities();

        // GET: HoTT_Hotline_Report_Rawdata
        public ActionResult Index()
        {
            var query = from s in db.HoTT_Hotline_Report_Rawdata
                        select s;

            foreach (var a in query.ToList())
            {
                if (a.Pack_Instruction != null)
                {
                    if (a.Pack_Instruction.Contains("DS"))
                    {
                      ////  a.IR = a.Order_Source_Ref;
                      //  a.ISO = a.Serv_Ord_Num;
                    }
                    else if (a.Pack_Instruction.Contains("/F03/"))
                    {
                        List<string> PIs = new List<string>();
                        PIs = a.Pack_Instruction.Split('/').ToList();
                        //a.IR = PIs[PIs.IndexOf("F03") - 1];
                      //  a.ISO = PIs[PIs.IndexOf("F03") + 1];
                    }
                }

            }

            Dashboard(query);
            return View();
        }

     
        [HttpPost]
        public ActionResult Index(ViewModel objmdel)
            
        {
            if (objmdel.K02_Buyer == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            var query = from s in db.HoTT_Hotline_Report_Rawdata
                        select s;

            if (objmdel.K02_Buyer != null)
            {
                query = query.Where(s=>s.K02_Buyer.Contains(objmdel.K02_Buyer));

            }
            if (objmdel.K03_Buyer != null)
            {
                query = query.Where(s => s.K03_Buyer.Contains(objmdel.K03_Buyer));

            }
            if (objmdel.K04_Buyer != null)
            {
                query = query.Where(s => s.K04_Buyer.Contains(objmdel.K04_Buyer));
            }
            if (objmdel.Org != null)
            {
                query = query.Where(s => s.Org.Contains(objmdel.Org));

            }
            if (objmdel.Tab_Name != null)
            {
                query = query.Where(s => s.Org.Contains(objmdel.Tab_Name));

            }
            if (objmdel.K04_Supplier != null)
            {
                query = query.Where(s => s.Org.Contains(objmdel.K04_Supplier));
            }
            if (objmdel.K03_Supplier != null)
            {
                query = query.Where(s => s.K03_Supplier.Contains(objmdel.K03_Supplier));
            }
            if (objmdel.K04_Supplier != null)
            {
                query = query.Where(s => s.K04_Supplier.Contains(objmdel.K04_Supplier));
            }
            Dashboard(query);
            return View();
        }

        public ActionResult Dashboard(IEnumerable<HoTT_Hotline_Report_Rawdata> queries)
        {
            return View(queries.ToList());
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
