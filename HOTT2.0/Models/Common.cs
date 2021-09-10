using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace HOTT2._0.Models
{
    public class HLData
    {
        public string id { get; set; }
        public string IsSplit { get; set; }
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
        public string KeySight_Only { get; set; }
        public string Branded_UE { get; set; }
        public string STATUS { get; set; }
        public string EOS_DATE { get; set; }
        public string ESL_Date { get; set; }
        public string EESP_Date { get; set; }
        public string Item_Name { get; set; }
        public string Req_Qty { get; set; }
        public string Reserved_Qty { get; set; }
        public string K02_OH { get; set; }
        public string K03_OH { get; set; }
        public string K04_OH { get; set; }
        public string W68_OH { get; set; }
        public string K02_InTransit_Qty { get; set; }
        public string K03_InTransit_Qty { get; set; }
        public string K04_InTransit_Qty { get; set; }
        public string W68_InTransit_Qty { get; set; }
        public string Korg_FIXME_Qty { get; set; }
        public string Korg_QACHECK_Qty { get; set; }
        public string ref_part_num { get; set; }
        public string ref_Status { get; set; }
        public string ref_EOS { get; set; }
        public string Ref_ESL_Date_ { get; set; }
        public string Ref_EESP_Date_ { get; set; }
        public string K02_ref_OH { get; set; }
        public string K03_ref_OH { get; set; }
        public string K04_ref_OH { get; set; }
        public string W68_ref_OH { get; set; }
        public string K02_ref_InTransit_Qty { get; set; }
        public string K03_ref_InTransit_Qty { get; set; }
        public string K04_ref_InTransit_Qty { get; set; }
        public string W68_ref_InTransit_Qty { get; set; }
        public string Korg_ref_FIXME_Qty { get; set; }
        public string Korg_ref_QACHECK_Qty { get; set; }
        public string HOLD_TYPE { get; set; }
        public string WH_Status { get; set; }
        public string Line_type { get; set; }
        public string Order_Type { get; set; }
        public string Business { get; set; }
        public string Dest_Org { get; set; }
        public string DEST_LOC_CD { get; set; }
        public string PRODUCT_HEIRARCHY { get; set; }
        public string Deliver_to { get; set; }
        public string Item_Description { get; set; }
        public string Order_Source_Ref { get; set; }
        public string Org_Name { get; set; }
        public string Ord_Qty { get; set; }
        public string Schd_Dt { get; set; }
        public string Age { get; set; }
        public string REQ_Age_WD { get; set; }
        public string Line_Status { get; set; }
        public string Serv_Req_Num { get; set; }
        public string Ship_to { get; set; }
        public string S_City { get; set; }
        public string S_Post_Code { get; set; }
        public string S_Country { get; set; }
        public string Load_Date { get; set; }
        public string Address4 { get; set; }
        public string Ship_Set { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Number { get; set; }
        public string Cust_PO_Num { get; set; }
        public string SPR_Address { get; set; }
        public string booked_dt { get; set; }
        public string K02_Buyer { get; set; }
        public string K02_Supplier { get; set; }
        public string K03_Buyer { get; set; }
        public string K03_Supplier { get; set; }
        public string K04_Buyer { get; set; }
        public string K04_Supplier { get; set; }
        public string Line_Number { get; set; }
        public string LTB { get; set; }
        public string DataTimestamp { get; set; }
        public string Age_Group { get; set; }
        public string Due { get; set; }
        public string Order_Type2 { get; set; }
        public string demand_freq { get; set; }
        public string Tab_Name { get; set; }
        public string PLANNER { get; set; }
        public string PLANNER_CODE { get; set; }
        public string SR_Asset_Serial_Number { get; set; }
        public string MODEL { get; set; }
        public string Item_Type { get; set; }
        public string Ship_Method { get; set; }
        public string Ordering_INST { get; set; }
        public string Ship_To_Loc { get; set; }
        public string CN_HTS_Code { get; set; }
        public string China_CIQ_Approval_Status { get; set; }
        public string HWPL { get; set; }
      [PetaPoco.Column("Package_comments")]
        public string New_Pack_Instruction  { get; set; }
        [PetaPoco.Column("Remarks")]
        public string SCP_Remarks { get; set; }
        [PetaPoco.Column("DateAdded")]
        public string  New_PI_Last_Updated_Date_Time { get; set; }

        public string IR { get; set; }
        //public string IR { get; set; }
        public string ISO { get; set; }
        [PetaPoco.Column("LN")]
        public string  New_Line_Number { get; set; }
        public string LastUpdateDate { get; set; }
        [PetaPoco.Column("Factory_Date")]
        public string  Factory_Commit_Date { get; set; }
        [PetaPoco.Column("Factory_Qty")]
        public string  New_Order_Qty { get; set; }
        [PetaPoco.Column("spLine")]
        public string  Line_No { get; set; }
        public string Reason_Code { get; set; }
        [PetaPoco.Column("F_remarks")]
        public string Remarks  { get; set; }
        [PetaPoco.Column("F_Status")]
        public string Factory_Status{ get; set; }
        [PetaPoco.Column("Spoc_Last_Update")]
        public string  SPOC_Last_Updated_Date_Time { get; set; }
        public string Schedule_Ship_Date { get; set; }
        public string Pick_Status { get; set; }
        [PetaPoco.Column("delivery_id")]
        public string Delivery_Number { get; set; }
        [PetaPoco.Column("last_update_date")]
        public string  Last_updated { get; set; }
        [PetaPoco.Column("actual_shipment_date")]
        public string Actual_Ship_Date  { get; set; }
        [PetaPoco.Column("tracking_number")]
        public string Tracking_Number { get; set; }
        [PetaPoco.Column("waybill")]
        public string  way_bill { get; set; }
        [PetaPoco.Column("freight_carrier_code")]
        public string Freight_Carrier { get; set; }
        [PetaPoco.Column("shipped_quantity")]
        public string Shipped_Qty { get; set; }
        public string CIRF_Type { get; set; }
        public string CIRF_ID { get; set; }
        public string ReciveDate { get; set; }
        public string ColorCode { get; set; }
        public string ORD_QTY1 { get; set; }
        public string SSD { get; set; }
        [PetaPoco.Column("Delivery_Number")]
        public string DELIV_NUM  { get; set; }
        

    }

    public class ColumnCLass
    {
        public string columnid { get; set; }
        public string columnsaved { get; set; }
    }

    public class SpotFire_PLMData
    {
        [PetaPoco.Column("PLNR CD")]
        public string PLNR_CD { get; set; }
        [PetaPoco.Column("PLNR NM")]
        public string PLNR_NM { get; set; }
        public string PRTY { get; set; }
        [PetaPoco.Column("BOOKED DATE")]
        public string BOOKED_DATE { get; set; }
        [PetaPoco.Column("SSD")]
        public string SSD { get; set; }
        [PetaPoco.Column("PICK STATUS")]
        public string PICK_STATUS { get; set; }
        [PetaPoco.Column("DELIVERY NUM")]
        public string DELIVERY_NUM { get; set; }
        [PetaPoco.Column("COMMENTS")]
        public string COMMENTS { get; set; }
        [PetaPoco.Column("IOT")]
        public string IOT { get; set; }
        [PetaPoco.Column("ORDER")]
        public string ORDER { get; set; }
        [PetaPoco.Column("LINE")]
        public string   Line_No { get; set; }
        [PetaPoco.Column("ORD QTY")]
        public string ORD_QTY { get; set; }
        [PetaPoco.Column("FXX NET OHB")]
        public string FXX_NET_OHB { get; set; }
        [PetaPoco.Column("RES INV")]
        public string RES_INV { get; set; }
        [PetaPoco.Column("ITEM")]
        public string ITEM { get; set; }
        [PetaPoco.Column("SHIP TO ORG")]
        public string SHIP_TO_ORG { get; set; }
        [PetaPoco.Column("SHIP TO BUYER NAME")]
        public string SHIP_TO_BUYER_NAME { get; set; }
        [PetaPoco.Column("CUST ORD NUM")]
        public string CUST_ORD_NUM { get; set; }
        [PetaPoco.Column("MAKE_BUY")]
        public string MAKE_BUY { get; set; }

        [PetaPoco.Column("ORG")]
        public string ORG { get; set; }
        [PetaPoco.Column("SHIP BUYER NAME")]
        public string SHIP_BUYER_NAME { get; set; }
        [PetaPoco.Column("OU")]
        public string OU { get; set; }
        [PetaPoco.Column("NewLine_Number")]
        public string NewLine_Number { get; set; }


    }

    public class ProcLanding
    {

        public string Tab_Name { get; set; }
        public string Backlog_Instr { get; set; }
        public string Org { get; set; }
        public string Priority_Code { get; set; }
        public string Ord_Dt { get; set; }
        public string Promise_Date { get; set; }
        public string Order_Num { get; set; }
        public string Serv_Ord_Num { get; set; }
        public string Order_Source_Ref { get; set; }
        public string Pack_Instruction { get; set; }
        public string PackageComments { get; set; }
        public string Ship_Instruction { get; set; }
        public string Status { get; set; }
        public string Item_Name { get; set; }
        public string Req_Qty { get; set; }
        public string Reserved_Qty { get; set; }
        public string IR { get; set; }
        public string ISO { get; set; }
        public string SourceOrg { get; set; }
        public string ShipToOrg { get; set; }
        public string spIR { get; set; }
        public string spISO { get; set; }
        public string LINE { get; set; }
        public string ITEM { get; set; }
        public string ORD_QTY { get; set; }
        public string PICK_STATUS { get; set; }
        public string issplit { get; set; }
        public string LastUpdateDate { get; set; }
        public string NewlineNumber { get; set; }

        public string Factory_Date { get; set; }
        public string Factory_QTY { get; set; }
    }

    public class DropDowncls
    {
        public string Key { get; set; }
        public string Value { get; set; }

    }

    public class F03Status
    {
        [PetaPoco.Column("FactoryStatus")]
        public string Status { get; set; }
        public string SpocActionDate { get; set; }
        public string SpocLastDate { get; set; }
        public string FactoryCommit { get; set; }
        public string ReasonCode { get; set; }
        public string Remarks { get; set; }
        public string OrderNumber { get; set; }
        public string Ismail { get; set; }
    }


}