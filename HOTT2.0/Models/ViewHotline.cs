using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOTT2._0.Models
{
    public class ViewModel
    {
        public string Tab_Name{ get; set; }
        public string Org{ get; set; }
        public string K02_Supplier { get; set; }
        public string K03_Supplier { get; set; }
        public string K04_Supplier { get; set; }
        public string K02_Buyer { get; set; }
        public string K03_Buyer { get; set; }
        public string K04_Buyer { get; set; }
        public string OrderNo { get; set; }
        public string Lineno { get; set; }

    }
    public class F03View
    {
        public int Sno { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public string Edit { get; set; }
        [PetaPoco.Column("FactoryStatus")]
        public string Status { get; set; }
        public string spoc_action_date { get; set; }
        public string Reason_Code { get; set; }
        public string Remarks { get; set; }
        [PetaPoco.Column("Ship To Org")]
        public string ShipToOrg { get; set; }
        public string Commit_Date { get; set; }
        public string factory_date { get; set; }
        public string spoc_last_update { get; set; }
        public string IR { get; set; }
        [PetaPoco.Column("ISO")]
        public string SO { get; set; }
        public string LINE { get; set; }
        public string ITEM { get; set; }
        [PetaPoco.Column("ORD QTY")]
        public string ORD_QTY { get; set; }
        [PetaPoco.Column("New_ORD_QTY")]
        public string New_ORD_QTY { get; set; }
        [PetaPoco.Column("NewLineNumber")]
        public string NewLineNumber { get; set; }
        [PetaPoco.Column("FXX NET OHB")]
        public string FXX_NET_OHB { get; set; }
        [PetaPoco.Column("RES INV")]
        public string RES_INV { get; set; }
        [PetaPoco.Column("Booked Date")]
        public string Booked_Date { get; set; }
        public string Make_Buy { get; set; }
        [PetaPoco.Column("PLNR CD")]
        public string PLNR_CD { get; set; }
        [PetaPoco.Column("PLNR NM")]
        public string PLNR_NM { get; set; }
        [PetaPoco.Column("SLSC Buyer")]
        public string SLSC_Buyer { get; set; }
        public string Description { get; set; }
        public string Concatenation { get; set; }
        public string HWPL { get; set; }
        public string Item_Type { get; set; }
        public string Order_Num { get; set; }
        public string Serv_Ord_Num { get; set; }
        public string Serv_Req_Num { get; set; }
        public string SR_Asset_Serial_Number { get; set; }
        public string MODEL { get; set; }
        public string Dest_Org { get; set; }
        public string EESP_Date { get; set; }
        public string ref_part_num { get; set; }
        public string ref_Status { get; set; }
        [PetaPoco.Column("Shipment Priority")]
        public string Shipment_Priority { get; set; }
        //public string Pick_Status { get; set; }
        public string Delivery_Number { get; set; }
        public string Last_updated { get; set; }
        public string ActualShip_Date { get; set; }
        [PetaPoco.Column("ReciveDate")]
        public string ReciveDate  { get; set; }

        [PetaPoco.Column("Planning Priority")]
        public string Planning_Priority { get; set; }
        public string CIRF_Type { get; set; }
        public string CIRF_ID { get; set; }
        [PetaPoco.Column("Dept WSF")]
        public string Dept_WSF { get; set; }
        public string DIV { get; set; }
        public string End_Customer_Name { get; set; }
        public string Part_Failure_Description { get; set; }
        public string CE_Name { get; set; }
        public string Age_until_SSD { get; set; }
        public string VLOOKUP_REF { get; set; }
        public string SSD { get; set; }
        public string schedule_ship_date { get; set; }
        public string pick_status { get; set; }
        public string delivery_id { get; set; }
        public string last_update_date { get; set; }
        public string actual_shipment_date { get; set; }
        public string tracking_number { get; set; }
        public string waywill { get; set; }
        [PetaPoco.Column("Concatenation Column")]
        public string concatenationcol { get; set; }
        public string ischecked { get; set; }

    }
    public class MainView
    {
        
        public string LastUpdateDate { get; set; }
        public string Tab_Name { get; set; }
        public string Backlog_Instr { get; set; }
        public string Org { get; set; }
        public string Priority_Code { get; set; }
        public string Ord_Dt { get; set; }
        public string Req_Dt { get; set; }
        public string Promise_Date { get; set; }
        public string Order_Num { get; set; }
        public string Serv_Ord_Num { get; set; }
        public string Pack_Instruction { get; set; }
        public string Ship_Instruction { get; set; }
        [PetaPoco.Column("Ship To Org")]
        public string ShipToOrg { get; set; }
        public string Commit_Date { get; set; }
        public string spoc_last_update { get; set; }
        public string IR { get; set; }
        public string Order_Source_Ref { get; set; }
        public string Reserved_Qty { get; set; }
        public string ISO { get; set; }
        public string Line_No { get; set; }
        public string LINE { get; set; }
        public string Req_Qty { get; set; }
        public string Factory_Date { get; set; }
        public string Item_Name { get; set; }
        [PetaPoco.Column("ORD QTY")]
        public string ORD_QTY { get; set; }
        [PetaPoco.Column("Package_comments")]
        public string Comments { get; set; }
        public string STATUS { get; set; }
        public string pick_status { get; set; }
        public string isSplit { get; set; }


    }

}