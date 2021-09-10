using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HOTT2._0.Models;

namespace HOTT2._0.Controllers
{
    public class Extract_IR_ISO : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("api/Extract_IR_ISO/SetData")]
        public IHttpActionResult SetData()
        {

            List<HLData> HL = new List<HLData>();
            var dataContext = new PetaPoco.Database("ConnStr");
            HL = dataContext.Query<HLData>(";exec HL_Dashboard1 @0", 1).ToList();
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
                 dataContext.Execute("update HoTT_Hotline_Report_Rawdata set IR=@0,ISO=@1 where Order_num=@2", a.IR, a.ISO, a.Order_Num);
            }
            return Json(new
            {
                Orders = HL.ToList()
            });

        }


       
    }
}