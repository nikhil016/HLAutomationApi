using HOTT2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.IO;
using System.Web.Script.Serialization;



namespace HOTT2._0.Controllers
{
    //[Route("api/[controller]/")]
    public class HoTT_Hotline_Report_ValueController : ApiController
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        private HOTTEntities db = new HOTTEntities();
        public HoTT_Hotline_Report_ValueController()
        {
            // Add the following code
            // problem will be solved
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/HoTT_Hotline_Report_Value

        [HttpGet]
        [Route("api/HoTT_Hotline_Report_Value")]
        public IHttpActionResult GetHoTT_Hotline_Report_Rawdata()
        {
            List<ProcLanding> HL = new List<ProcLanding>();
            List<SpotFire_PLMData> PLMData = new List<SpotFire_PLMData>();
            var dataContext = new PetaPoco.Database("ConnStr");
            try
            {
                HL = dataContext.Query<ProcLanding>(";exec HL_Dashboard @0", 1).ToList();
                //PLMData = dataContext.Query<SpotFire_PLMData>("Select * from SpotFire_PLMData").ToList();
                //var query = from person in HL
                //            join pet in PLMData on person.ISO equals pet.ORDER into gj
                //            from subpet in gj.DefaultIfEmpty()
                //            select new
                //            {
                //                tab_Name = person.Tab_Name,
                //                isplit = person.IsSplit,
                //                backlog_Instr = person.Backlog_Instr,
                //                org = person.Org,
                //                priority_Code = person.Priority_Code,
                //                ord_Dt = person.Ord_Dt,
                //                promise_Date = person.Promise_Date,
                //                order_Num = person.Order_Num,
                //                serv_Ord_Num = person.Serv_Ord_Num,
                //                order_Source_Ref = person.Order_Source_Ref,
                //                pack_Instruction = person.Pack_Instruction,
                //                ship_Instruction = person.Ship_Instruction,
                //                PackageComments = person.Package_comments,
                //                SpcRemarks = person.Remarks,
                //                status = person.STATUS,
                //                item_Name = person.Item_Name,
                //                req_Qty = person.Req_Qty,
                //                reserved_Qty = person.Reserved_Qty,
                //                iR = person.IR,
                //                iSO = person.ISO,
                //                NewlineNumber = person.NewLine_Number,
                //                Factory_Date = person.Factory_Date,
                //                Factory_QTY = person.Factory_Qty,
                //                color_code = person.ColorCode,
                //                sourceOrg = subpet.ORG ?? string.Empty,
                //                shipToOrg = subpet.SHIP_TO_ORG ?? string.Empty,
                //                spIR = subpet.CUST_ORD_NUM ?? string.Empty,
                //                spISO = subpet.ORDER ?? string.Empty,
                //                spLine = subpet.LINE ?? string.Empty,
                //                spItem = subpet.ITEM ?? string.Empty,
                //                spOrdQty = subpet.ORD_QTY ?? string.Empty,
                //                spPickStatus = subpet.PICK_STATUS ?? string.Empty,
                //                LastUpdateDate = person.DataTimestamp
                //            };

                return Json(new { Orders = HL.ToList() });
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        // not in use
        [HttpGet]
        [Route("api/Filter")]
        public IHttpActionResult Filter(ViewModel objmdel)
        {


            var query = from s in db.HoTT_Hotline_Report_Rawdata
                        select s;

            if (objmdel.K02_Buyer != null)
            {
                query = query.Where(s => s.K02_Buyer.Contains(objmdel.K02_Buyer));

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
                query = query.Where(s => s.Tab_Name.Contains(objmdel.Tab_Name));

            }
            if (objmdel.K02_Supplier != null)
            {
                query = query.Where(s => s.K02_Supplier.Contains(objmdel.K02_Supplier));
            }
            if (objmdel.K03_Supplier != null)
            {
                query = query.Where(s => s.K03_Supplier.Contains(objmdel.K03_Supplier));
            }
            if (objmdel.K04_Supplier != null)
            {
                query = query.Where(s => s.K04_Supplier.Contains(objmdel.K04_Supplier));
            }
            return Ok(query);
        }

        [HttpGet]
        public IHttpActionResult getDataByOrderNoLineNo(ViewModel objmdel)
        {
            var query = from s in db.HoTT_Hotline_Report_Rawdata
                        select s;
            query = query.Where(x => x.Order_Num == objmdel.OrderNo && x.Line_Number == objmdel.Lineno);
            return Ok(query);
        }

        [HttpGet]
        [Route("api/PostRemarks")] //orderNum,lineno,comments
        public IHttpActionResult PostRemarks(string orderNum, string lineno, string comments,  int Type, string Item_Name)
        {
            string date = System.DateTime.Now.AddHours(15).ToString("MM/dd/yyyy HH:mm:ss");
            string str = "";
            var dataContext = new PetaPoco.Database("ConnStr");
            try
            {
                //if (ValidateUser()) { 
                if (Type == 1)//Spc Remarks 
                    str = "insert into Hott_packingInstruction(orderno,linenumber,SpcRemarks,SpcUpdateDate,SpcUser,item_name) values('" + orderNum + "','" + lineno + "','" + comments + "','" + date + "','" + GetUser(0) + "','" + Item_Name + "')";
                else//Pack  Instructions
                    str = "insert into Hott_packingInstruction(orderno,linenumber,comments,dateadded,PackUser,item_name) values('" + orderNum + "','" + lineno + "','" + comments + "','" + date + "','" + GetUser(0) + "','" + Item_Name + "')";
                int aa = dataContext.Execute(str);
                return Json(new { Orders = "User Comments Posted Successfully!!" });
                //}
                //else
                //return Json(new { Orders = "User is not authorized to post Comments!! " });
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        [Route("api/SetCIRF")] //orderNum,lineno,comments
        public IHttpActionResult SetCIRF(string orderNum, string lineno, string CIRFType, string CIRFID, string ReceiveDate, string CustomerName, string Status, string Item)
        {
            string str = "", str1 = "";
            try
            {
                str = "insert into  tbl_FactoryDate(ordernumber,line_number,cirftype,cirfid,ReceiveDate, EndCustomerName,Item_Name,status)";
                str += " values('" + orderNum + "','" + lineno + "','" + CIRFType + "','" + CIRFID + "'," + ReceiveDate + ",'" + CustomerName + "','" + Item + "','" + Status + "')";
                str1 = "update tbl_FactoryDate with(updlock) set CIRFType = '" + CIRFType + "',CIRFID = '" + CIRFID + "',ReceiveDate ='" + ReceiveDate + "', EndCustomerName='" + CustomerName + "' where OrderNumber = '" + orderNum + "' and Line_Number = '" + lineno + "'";

                string newsql = "if NOT EXISTS(select 1 from tbl_FactoryDate where ordernumber='" + orderNum + "' and line_number='" + lineno + "')";
                newsql += "BEGIN " + str + " END ELSE BEGIN " + str1 + "  END";

                var dataContext = new PetaPoco.Database("ConnStr");
                dataContext.Execute(newsql);
                return Json(new
                {
                    Orders = "Successfully Updated"
                });
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        [Route("api/ItemDetails")]
        public IHttpActionResult ItemDetails(string tab_Name, string item_Name)
        {
            var dataContext = new PetaPoco.Database("ConnStr");
          try
            {
                List<HLData> HL = new List<HLData>();
                string[] tabname = tab_Name.Split(',');
                foreach(var name in tabname){
                    List<HLData> HL1 = new List<HLData>();
                    HL1= dataContext.Query<HLData>(";exec HL_Dashboard @0, @1, @2  ", 5, null, name).ToList();
                    HL.AddRange(HL1);

                }
                return Json(new
                {
                    Orders = HL.ToList()
                });
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpGet]
        [Route("api/GetUser")]
        public string GetUser(int type)
        {
            string UserName;
            //UserName = System.Environment.UserName;   //local
            UserName = System.Web.HttpContext.Current.User.Identity.Name;// production

            return UserName;
        }

        [HttpGet]
        [Route("api/GetF03View")]
        public IHttpActionResult GetF03View()
        {
            var datacontext = new PetaPoco.Database("ConnStr");
            List<F03View> HL = new List<F03View>();
            try
            {
                HL = datacontext.Fetch<F03View>(";exec HL_Dashboard @0", 2);
                return Json(new { Orders = HL.ToList() });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/GetMainView")]
        public IHttpActionResult GetMainView()
        {
            var datacontext = new PetaPoco.Database("ConnStr");

            List<MainView> HL = new List<MainView>();
            try
            {
                HL = datacontext.Fetch<MainView>(";exec HL_Dashboard @0", 4);
                return Json(new
                {
                    Orders = HL.ToList()
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/GetHotlineView")]
        public IHttpActionResult GetHotlineView(string ordernum)
        {

            var datacontext = new PetaPoco.Database("ConnStr");
            List<F03View> HL = new List<F03View>();
            try
            {
                HL = datacontext.Fetch<F03View>(";exec HL_Dashboard @0 ,@1", 3, ordernum);
                return Json(new { Orders = HL.ToList() });
            }
            catch (Exception ex) {
                throw;
            }
        }

        [HttpGet]
        [Route("api/PostF03Status")] //orderNum,lineno,comments
        public IHttpActionResult PostF03Status(string status, string reason_code, string remarks, string commitdate, string ordernum,
            string Ord_QTY, double Line_Number, string Item_Name, bool flag, int sno, bool IsSplit ,string LINE)
        {

            var dataContext = new PetaPoco.Database("ConnStr");
            string date = System.DateTime.Now.AddHours(15).ToString("MM/dd/yyyy hh:mm tt");
            string sqlcommitdate, sqlfinal, spoc_last_update, LastUpdateDate = "";
            spoc_last_update = date.ToString();

            try
            {
                if (commitdate.ToString() == "null")
                    commitdate = "";
                if (reason_code != null || remarks != null || commitdate != "")
                    LastUpdateDate = date;
                else
                    LastUpdateDate = "";
                sqlcommitdate = "insert into tbl_FactoryDate(spoc_action_date, spoc_last_update, Factory_Date,Factory_Qty, LastUpdateDate, OrderNumber,Line_Number,Item_Name,status,reason_code,remarks,LINE) values";
                sqlcommitdate += "('" + spoc_last_update + "','" + LastUpdateDate + "','" + commitdate + "','" + Ord_QTY + "','" + LastUpdateDate + "','" + ordernum + "','" + Line_Number + "','" + Item_Name + "','" + status + "','" + reason_code + "','" + remarks + "','" + LINE + "')";

                if (IsSplit)
                {
                    sqlcommitdate = "insert into tbl_FactoryDate(Factory_Date,Factory_Qty, LastUpdateDate,Spoc_Last_Update, OrderNumber,Line_Number,Item_Name,status,reason_code,remarks,LINE) values";
                    Line_Number = Line_Number + 0.1;
                    sqlcommitdate += "('" + commitdate + "','" + Ord_QTY + "','" + LastUpdateDate + "','" + spoc_last_update + "','" + ordernum + "','" + Line_Number + "','" + Item_Name + "','" + status + "','" + reason_code + "','" + remarks + "','" + LINE + "')";
                    dataContext.Execute(sqlcommitdate);
                }
                else
                {
                    if (reason_code != null || remarks != null || commitdate != "")
                        spoc_last_update = System.DateTime.Now.AddHours(15).ToString("MM/dd/yyyy hh:mm tt");
                    else
                        spoc_last_update = "";
                    string sqlupdate = "update tbl_factorydate set  LastUpdateDate='" + LastUpdateDate + "',";
                    sqlupdate += "Factory_Date ='" + commitdate + "',";
                    if (LINE != null)
                        sqlupdate += "LINE ='" + LINE + "',";
                    if (Ord_QTY != null)
                        sqlupdate += "Factory_Qty ='" + Ord_QTY + "',";
                    if (Item_Name != null)
                        sqlupdate += "Item_Name='" + Item_Name + "',";
                    if (status != null)
                        sqlupdate += "Status='" + status + "',";
                    if (status != null)
                        sqlupdate += "Spoc_Last_Update='" + spoc_last_update + "',";
                    if (reason_code != null)
                        sqlupdate += "Reason_Code ='" + reason_code + "',";
                    sqlupdate += remarks == null ? "Remarks= '" + " " + "' ," : "Remarks='" + remarks + "',";
                    sqlupdate = sqlupdate.TrimEnd(',');
                    sqlupdate += " where Line_Number='" + Line_Number + "' and OrderNumber='" + ordernum + "'";
                    sqlfinal = "if exists( select 1 from tbl_FactoryDate where OrderNumber='" + ordernum + "' and Line_Number='" + Line_Number + "') BEGIN " + sqlupdate + "  END ELSE BEGIN " + sqlcommitdate + "END";
                    dataContext.Execute(sqlfinal);
                }

                return Json(new
                {
                    Orders = "Successfully Saved"
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/PostF03EmailData")] //orderNum,lineno,comments
        public IHttpActionResult PostF03EmailData(string Ordernum, string CCEmail , string Subject)
        {
            var dataContext = new PetaPoco.Database("ConnStr");
            try
            {  //463828_M9433-69901_1,1-11822302586-898_03458-69502_12
                string date = System.DateTime.Now.AddHours(15).ToString("MM/dd/yyyy hh:mm tt");
                string[] or = Ordernum.Split(',');
                string sqlcommitdate = "";
                string sqlupdate = ""; string sqltext1 = "";
               
                
                //sqlcommitdate += "insert into tbl_FactoryDate(spoc_action_date,ordernumber,item_name,status,issent,ischecked,line_number) values";
                //sqlupdate += " ";

                string ordernumber = "";
                foreach (string order in or)
                {


                    sqlcommitdate = "insert into tbl_FactoryDate(spoc_action_date,ordernumber,item_name,status,issent,ischecked,line_number) values";
                    string Sno = order.Split('@')[0];
                    ordernumber = order.Split('_')[0];
                    string itemname = order.Split('_')[1];
                    sqlcommitdate += "('" + date + "', '" + ordernumber + "','" + itemname + "', 'Pending-F03 Plnr/Buyer', 0, 1,1.1),";
                    sqlupdate += " update tbl_FactoryDate set spoc_action_date = '" + date + "', IsChecked = 1 , isSent = 0 where ordernumber = '" + ordernumber + "' and item_name='" + itemname + "'";
                    sqltext1 = "if exists( select 1 from tbl_FactoryDate where OrderNumber in ( '" + ordernumber + "') and item_name = '"+ itemname + "') BEGIN " + sqlupdate + " END ELSE BEGIN " + sqlcommitdate.TrimEnd(',') + " END";
                    dataContext.Execute(sqltext1);
                }
                                                                                                
                string sqltext = " select A.[SHIP TO ORG],isnull(D.[REASON_Code],'')[REASON_Code], A.[CUST ORD NUM] as IR, A.[ORDER] as ISO,  substring(A.LINE,1,3)as LINE,A.[ORD QTY], convert(VARCHAR(10), A.[BOOKED DATE], 101) [BOOKED DATE], A.PRTY as [Shipment Priority],A.[planning priority] ,";
                sqltext += " A.[MAKE_BUY],A.[PLNR CD], A.[PLNR NM],A.[ITEM],[SHIP TO BUYER NAME] as [SLSC BUYER],isnull(convert(VARCHAR(10), D.factory_date, 101),'') factory_date, isnull(D.Remarks,'') as Remarks from SpotFire_PLMData A   left join tbl_FactoryDate D on D.[OrderNumber] = A.[CUST ORD NUM] and D.item_name = A.ITEM where ischecked = 1 and issent = 0";
                List<F03View> HL = new List<F03View>();
                string strmail = "";
                strmail += @"<html><head> </head><body><table  id='customers' style='font-size: 10px'>";
                string thead = @"<tr><th>SHIP TO ORG</th><th>IR</th><th>ISO</th><th>LINE</th><th>ITEM</th>
                        <th>ORD QTY</th><th>BOOKED DATE</th><th>MAKE BUY</th><th>PLNR CD</th>
                        <th>PLNR NM</th><th>SPO BUYER</th><th>Shipment Priority</th><th>Planning Priority</th><th>Factory Commit Date</th>
                        <th>REASON CODE</th><th>REMARK</th></tr>";
                string tbody = "";

                HL = dataContext.Fetch<F03View>(sqltext);
                if (HL.Count > 0)
                {
                    for (int i = 0; i < HL.Count; i++)
                    {
                        tbody += @"<tr><td>" + HL[i].ShipToOrg + "</td><td>" + HL[i].IR + "</td><td>" + HL[i].SO + "</td><td>" + HL[i].LINE + "</td><td>"+ HL[i].ITEM + "</td><td>" + HL[i].ORD_QTY + "</td><td>" + HL[i].Booked_Date + "</td><td>" + HL[i].Make_Buy + "</td><td>"
                                                  + HL[i].PLNR_CD + "</td><td>" + HL[i].PLNR_NM + "</td><td>" + HL[i].SLSC_Buyer + "</td><td>" + HL[i].Shipment_Priority + "</td><td>"  + HL[i].Planning_Priority + "</td><td>" + HL[i].factory_date + "</td><td>" + HL[i].Reason_Code + "</td><td>" + HL[i].Remarks + "</td><tr>";

                    }
                }
                strmail += thead + tbody;
                strmail += "</table></body></html>";
                dataContext.Execute(";exec HL_Email_Composition @0, @1, @2", strmail, CCEmail.TrimEnd(','),Subject);
                return Json(new
                {
                    Orders = "Email is Successfully Sent"
                });
            }

            catch (Exception ex)
            {

                throw;
            }

            
        }


        [HttpGet]
        [Route("api/GetEmailAddress")]
        public string GetEmailAddress(string sno)
        {
            string emailaddress = "";
            try
            {
                List<string> EmailList = new List<string>();
                var dataContext = new PetaPoco.Database("ConnStr");
                EmailList = dataContext.Query<string>(";exec HL_Dashboard @0,@1,@2", 6, sno.ToString(), null).ToList();
                foreach (var mail in EmailList)
                {
                    emailaddress += mail + ',';
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return emailaddress;
        }

        [HttpGet]
        [Route("api/GetReasonCode")]
        public IHttpActionResult GetReasonCode()
        {
            var datacontext = new PetaPoco.Database("ConnStr");
            List<string> HL = new List<string>();
            HL = datacontext.Query<string>("select [reason code] as [Key]  from HoTT_tbl_Reason").ToList();
            return Json(new
            {
                Orders = HL.ToList()
            });
        }

        [HttpGet]
        [Route("api/GetColumnID")]
        public IHttpActionResult GetColumnID()
        {
            var datacontext = new PetaPoco.Database("ConnStr");
            List<ColumnCLass> HL = new List<ColumnCLass>();
            HL = datacontext.Query<ColumnCLass>("select columnid,columnsaved from tbl_ColumnDef where userNT='" + GetUser(0) + "'").ToList();

            if (HL == null)
            {
                return Json("");
            }

            return Json(new
            {
                Orders = HL.ToList()
            });
        }

        [HttpGet]
        [Route("api/GetHotlineTime")]
        public IHttpActionResult GetHotlineTime()
        {
            string path = @"\\wsgpew03.sgp.is.keysight.com\spo_supplychain\OrderMngt\Backlog\HotlineReport.xls";
            DateTime datetim = System.IO.File.GetLastWriteTime(path);
            DateTime LastUpdate =datetim.AddHours(15);
            //JavaScriptSerializer ser = new JavaScriptSerializer();
            //string json = ser.Serialize(datetim);// pass your date
            //return J
            return Json(new  { Orders = LastUpdate.ToString() });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HoTT_Hotline_Report_RawdataExists(int id)
        {
            return db.HoTT_Hotline_Report_Rawdata.Count(e => e.id == id) > 0;
        }

        //yogesh
        //[HttpGet]
        //[Route("api/SetCoumnPin")]
        //public IHttpActionResult SetCoumnPin(string Column, string ColumSave)
        //{
        //    string sqlcolumn, sqlcolumninst, sqlcolumnupd2 = "";
        //    var datacontext = new PetaPoco.Database("ConnStr");
        //    try
        //    {
        //        //nikhirat,{color,back_instr},{color,back_instr}
        //        sqlcolumninst = " insert into tbl_ColumnDef (userNT,columnid,columnsaved) values('" + GetUser(0) + "','" + Column+ "','" + ColumSave + "') ";
        //        sqlcolumnupd2 = " update  tbl_ColumnDef set columnid='" + Column + "', columnsaved='" + ColumSave + "' where userNT='" + GetUser(0) + "';";

        //        sqlcolumn = "if  NOT EXISTS (select top 1 columnid from tbl_ColumnDef where userNT='" + GetUser(0) + "') BEGIN" + sqlcolumninst + " END  ELSE BEGIN  " + sqlcolumnupd2 + "END";

        //        datacontext.Execute(sqlcolumn);
        //        return Json(new
        //        {
        //            Orders = "Column set Successfully "
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}

        [HttpGet]
        [Route("api/SetCoumnPin")]
        public IHttpActionResult SetCoumnPin(string Column, string ColumSave)
        {
            string sqlcolumn, sqlcolumninst, sqlcolumnupd2 = "";
            var datacontext = new PetaPoco.Database("ConnStr");
            try
            {
                //nikhirat,{color,back_instr},{color,back_instr}
                sqlcolumninst = " insert into tbl_ColumnDef (userNT,columnid,columnsaved) values('" + GetUser(0) + "','" + Column + "','" + ColumSave + "') ";
                sqlcolumnupd2 = " update  tbl_ColumnDef set columnid='" + Column + "', columnsaved='" + ColumSave + "' where userNT='" + GetUser(0) + "';";

                sqlcolumn = "if  NOT EXISTS (select top 1 columnid from tbl_ColumnDef where userNT='" + GetUser(0) + "') BEGIN" + sqlcolumninst + " END  ELSE BEGIN  " + sqlcolumnupd2 + "END";

                datacontext.Execute(sqlcolumn);
                return Json(new
                {
                    Orders = "Column set Successfully "
                });
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        // exceutes automatically.
        [HttpGet]
        [Route("api/SetData")]
        public IHttpActionResult SetData()
        {
            
            List<HLData> HL = new List<HLData>();
            var dataContext = new PetaPoco.Database("ConnStr");
            HL = dataContext.Query<HLData>(";exec HL_Dashboard @0", 1).ToList();
            try
            {
                foreach (var a in HL)
                {
                    if (a.Pack_Instruction != null)
                    {

                        if (a.Pack_Instruction.Contains("+") && a.IsSplit.Contains("0"))
                        {

                            string[] Ins = a.Pack_Instruction.Split('+');
                            int count = Ins.Length;
                            foreach (var instuc in Ins)
                                dataContext.Execute(";exec HL_Duplicate @0 ,@1", a.id, instuc);

                        }
                        else if (a.IsSplit != "1")
                        {
                            if (a.Pack_Instruction.Contains("DS"))
                            {
                                a.IR = a.Order_Source_Ref;
                                a.ISO = a.Order_Num;
                            }
                            else if (a.Pack_Instruction.Contains("/F03/"))
                            {
                                List<string> PIs = new List<string>();
                                PIs = a.Pack_Instruction.Split('/').ToList();
                                a.IR = PIs[PIs.IndexOf("F03") - 1];
                                a.ISO = PIs[PIs.IndexOf("F03") + 1];
                            }
                            else if (a.Pack_Instruction.Contains("/F01/"))
                            {
                                List<string> PIs = new List<string>();
                                PIs = a.Pack_Instruction.Split('/').ToList();
                                a.IR = PIs[PIs.IndexOf("F01") - 1];
                                a.ISO = PIs[PIs.IndexOf("F01") + 1];
                            }
                            else if (a.Pack_Instruction.Contains("/F55/"))
                            {
                                List<string> PIs = new List<string>();
                                PIs = a.Pack_Instruction.Split('/').ToList();
                                a.IR = PIs[PIs.IndexOf("F55") - 1];
                                a.ISO = PIs[PIs.IndexOf("F55") + 1];
                            }
                            else if (a.Pack_Instruction.Contains("/F51/"))
                            {
                                List<string> PIs = new List<string>();
                                PIs = a.Pack_Instruction.Split('/').ToList();
                                a.IR = PIs[PIs.IndexOf("F51") - 1];
                                a.ISO = PIs[PIs.IndexOf("F51") + 1];
                            }
                            else if (a.Pack_Instruction.Contains("/K02/"))
                            {
                                List<string> PIs = new List<string>();
                                PIs = a.Pack_Instruction.Split('/').ToList();
                                a.IR = PIs[PIs.IndexOf("K02") - 1];
                                a.ISO = PIs[PIs.IndexOf("K02") + 1];
                            }
                            else if (a.Pack_Instruction.Contains("/K03/"))
                            {
                                List<string> PIs = new List<string>();
                                PIs = a.Pack_Instruction.Split('/').ToList();
                                a.IR = PIs[PIs.IndexOf("K03") - 1];
                                a.ISO = PIs[PIs.IndexOf("K03") + 1];
                            }
                            else if (a.Pack_Instruction.Contains("/K04/"))
                            {
                                List<string> PIs = new List<string>();
                                PIs = a.Pack_Instruction.Split('/').ToList();
                                a.IR = PIs[PIs.IndexOf("K04") - 1];
                                a.ISO = PIs[PIs.IndexOf("K04") + 1];
                            }
                        }
                    }
                    dataContext.Execute("update HoTT_Hotline_Report_Rawdata set IR=@0,ISO=@1 where Order_num=@2 and Item_Name=@3 ", a.IR, a.ISO, a.Order_Num,a.Item_Name);
                }
                return Json(new
                {
                    Orders = "SuccessFully Updated Data"
                });
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        public bool ValidateUser()
        {
            int isvalid ;
            string sqlcolumn = "";
            string ntid = GetUser(1).Remove(0, 9);
            //string ntid = GetUser(1);

            var datacontext = new PetaPoco.Database("ConnStr");
            try
            {

                sqlcolumn = " if   EXISTS (select top 1 Email from Tbl_Users where Username like'%"+ ntid + "m%')BEGIN select CAST(1 AS BIT) END ELSE BEGIN  select CAST(0 AS BIT) END";
                isvalid= datacontext.ExecuteScalar<int>(sqlcolumn);
                if (isvalid == 1)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //#region Start
        [HttpGet]
        [Route("api/HoTT_Hotline_Report_Value_Arch")]
        public IHttpActionResult HoTT_Hotline_Report_Value_Arch(string datefrom, string dateto)
        {
            List<ProcLanding> HL = new List<ProcLanding>();
            List<SpotFire_PLMData> PLMData = new List<SpotFire_PLMData>();
            var dataContext = new PetaPoco.Database("ConnStr");
            try
            {
                HL = dataContext.Query<ProcLanding>(";exec HL_Dashboard_Arch @0,@1,@2,@3", 1,null,datefrom,dateto).ToList();
                return Json(new { Orders = HL.ToList() });
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        [Route("api/GetF03View_Arch")]
        public IHttpActionResult GetF03View_Arch()
        {
            var datacontext = new PetaPoco.Database("ConnStr");
            List<F03View> HL = new List<F03View>();
            try
            {
                HL = datacontext.Fetch<F03View>(";exec HL_Dashboard_Arch @0", 2);
                return Json(new { Orders = HL.ToList() });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/ItemDetails_Arch")]
        public IHttpActionResult ItemDetails_Arch(string tab_Name, string item_Name)
        {
            var dataContext = new PetaPoco.Database("ConnStr");
            try
            {
                List<HLData> HL = new List<HLData>();
                string[] tabname = tab_Name.Split(',');
                foreach (var name in tabname)
                {
                    List<HLData> HL1 = new List<HLData>();
                    HL1 = dataContext.Query<HLData>(";exec HL_Dashboard_Arch @0, @1, @2  ", 5, null, name).ToList();
                    HL.AddRange(HL1);

                }
                return Json(new
                {
                    Orders = HL.ToList()
                });
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //#region END
    }
}
