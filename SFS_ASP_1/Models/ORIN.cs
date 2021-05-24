//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SFS_ASP_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORIN
    {
        public int DocEntry { get; set; }
        public int DocNum { get; set; }
        public string DocType { get; set; }
        public string CANCELED { get; set; }
        public string Handwrtten { get; set; }
        public string Printed { get; set; }
        public string DocStatus { get; set; }
        public string InvntSttus { get; set; }
        public string Transfered { get; set; }
        public string ObjType { get; set; }
        public Nullable<System.DateTime> DocDate { get; set; }
        public Nullable<System.DateTime> DocDueDate { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Address { get; set; }
        public string NumAtCard { get; set; }
        public Nullable<decimal> VatPercent { get; set; }
        public Nullable<decimal> VatSum { get; set; }
        public Nullable<decimal> VatSumFC { get; set; }
        public Nullable<decimal> DiscPrcnt { get; set; }
        public Nullable<decimal> DiscSum { get; set; }
        public Nullable<decimal> DiscSumFC { get; set; }
        public string DocCur { get; set; }
        public Nullable<decimal> DocRate { get; set; }
        public Nullable<decimal> DocTotal { get; set; }
        public Nullable<decimal> DocTotalFC { get; set; }
        public Nullable<decimal> PaidToDate { get; set; }
        public Nullable<decimal> PaidFC { get; set; }
        public Nullable<decimal> GrosProfit { get; set; }
        public Nullable<decimal> GrosProfFC { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Comments { get; set; }
        public string JrnlMemo { get; set; }
        public Nullable<int> TransId { get; set; }
        public Nullable<int> ReceiptNum { get; set; }
        public Nullable<short> GroupNum { get; set; }
        public Nullable<short> DocTime { get; set; }
        public Nullable<short> SlpCode { get; set; }
        public Nullable<short> TrnspCode { get; set; }
        public string PartSupply { get; set; }
        public string Confirmed { get; set; }
        public Nullable<short> GrossBase { get; set; }
        public Nullable<int> ImportEnt { get; set; }
        public string CreateTran { get; set; }
        public string SummryType { get; set; }
        public string UpdInvnt { get; set; }
        public string UpdCardBal { get; set; }
        public short Instance { get; set; }
        public Nullable<int> Flags { get; set; }
        public string InvntDirec { get; set; }
        public Nullable<int> CntctCode { get; set; }
        public string ShowSCN { get; set; }
        public string FatherCard { get; set; }
        public Nullable<decimal> SysRate { get; set; }
        public string CurSource { get; set; }
        public Nullable<decimal> VatSumSy { get; set; }
        public Nullable<decimal> DiscSumSy { get; set; }
        public Nullable<decimal> DocTotalSy { get; set; }
        public Nullable<decimal> PaidSys { get; set; }
        public string FatherType { get; set; }
        public Nullable<decimal> GrosProfSy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string IsICT { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<decimal> Volume { get; set; }
        public Nullable<short> VolUnit { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<short> WeightUnit { get; set; }
        public Nullable<short> Series { get; set; }
        public Nullable<System.DateTime> TaxDate { get; set; }
        public string Filler { get; set; }
        public string DataSource { get; set; }
        public string StampNum { get; set; }
        public string isCrin { get; set; }
        public Nullable<int> FinncPriod { get; set; }
        public Nullable<short> UserSign { get; set; }
        public string selfInv { get; set; }
        public Nullable<decimal> VatPaid { get; set; }
        public Nullable<decimal> VatPaidFC { get; set; }
        public Nullable<decimal> VatPaidSys { get; set; }
        public Nullable<short> UserSign2 { get; set; }
        public string WddStatus { get; set; }
        public Nullable<int> draftKey { get; set; }
        public Nullable<decimal> TotalExpns { get; set; }
        public Nullable<decimal> TotalExpFC { get; set; }
        public Nullable<decimal> TotalExpSC { get; set; }
        public Nullable<int> DunnLevel { get; set; }
        public string Address2 { get; set; }
        public Nullable<short> LogInstanc { get; set; }
        public string Exported { get; set; }
        public Nullable<int> StationID { get; set; }
        public string Indicator { get; set; }
        public string NetProc { get; set; }
        public Nullable<decimal> AqcsTax { get; set; }
        public Nullable<decimal> AqcsTaxFC { get; set; }
        public Nullable<decimal> AqcsTaxSC { get; set; }
        public Nullable<decimal> CashDiscPr { get; set; }
        public Nullable<decimal> CashDiscnt { get; set; }
        public Nullable<decimal> CashDiscFC { get; set; }
        public Nullable<decimal> CashDiscSC { get; set; }
        public string ShipToCode { get; set; }
        public string LicTradNum { get; set; }
        public string PaymentRef { get; set; }
        public Nullable<decimal> WTSum { get; set; }
        public Nullable<decimal> WTSumFC { get; set; }
        public Nullable<decimal> WTSumSC { get; set; }
        public Nullable<decimal> RoundDif { get; set; }
        public Nullable<decimal> RoundDifFC { get; set; }
        public Nullable<decimal> RoundDifSy { get; set; }
        public string CheckDigit { get; set; }
        public Nullable<int> Form1099 { get; set; }
        public string Box1099 { get; set; }
        public string submitted { get; set; }
        public string PoPrss { get; set; }
        public string Rounding { get; set; }
        public string RevisionPo { get; set; }
        public short Segment { get; set; }
        public Nullable<System.DateTime> ReqDate { get; set; }
        public Nullable<System.DateTime> CancelDate { get; set; }
        public string PickStatus { get; set; }
        public string Pick { get; set; }
        public string BlockDunn { get; set; }
        public string PeyMethod { get; set; }
        public string PayBlock { get; set; }
        public Nullable<int> PayBlckRef { get; set; }
        public string MaxDscn { get; set; }
        public string Reserve { get; set; }
        public Nullable<decimal> Max1099 { get; set; }
        public string CntrlBnk { get; set; }
        public string PickRmrk { get; set; }
        public string ISRCodLine { get; set; }
        public Nullable<decimal> ExpAppl { get; set; }
        public Nullable<decimal> ExpApplFC { get; set; }
        public Nullable<decimal> ExpApplSC { get; set; }
        public string Project { get; set; }
        public string DeferrTax { get; set; }
        public string LetterNum { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<decimal> WTApplied { get; set; }
        public Nullable<decimal> WTAppliedF { get; set; }
        public string BoeReserev { get; set; }
        public string AgentCode { get; set; }
        public Nullable<decimal> WTAppliedS { get; set; }
        public Nullable<decimal> EquVatSum { get; set; }
        public Nullable<decimal> EquVatSumF { get; set; }
        public Nullable<decimal> EquVatSumS { get; set; }
        public Nullable<short> Installmnt { get; set; }
        public string VATFirst { get; set; }
        public Nullable<decimal> NnSbAmnt { get; set; }
        public Nullable<decimal> NnSbAmntSC { get; set; }
        public Nullable<decimal> NbSbAmntFC { get; set; }
        public Nullable<decimal> ExepAmnt { get; set; }
        public Nullable<decimal> ExepAmntSC { get; set; }
        public Nullable<decimal> ExepAmntFC { get; set; }
        public Nullable<System.DateTime> VatDate { get; set; }
        public string CorrExt { get; set; }
        public Nullable<int> CorrInv { get; set; }
        public Nullable<int> NCorrInv { get; set; }
        public string CEECFlag { get; set; }
        public Nullable<decimal> BaseAmnt { get; set; }
        public Nullable<decimal> BaseAmntSC { get; set; }
        public Nullable<decimal> BaseAmntFC { get; set; }
        public string CtlAccount { get; set; }
        public Nullable<int> BPLId { get; set; }
        public string BPLName { get; set; }
        public string VATRegNum { get; set; }
        public string TxInvRptNo { get; set; }
        public Nullable<System.DateTime> TxInvRptDt { get; set; }
        public string KVVATCode { get; set; }
        public string WTDetails { get; set; }
        public Nullable<int> SumAbsId { get; set; }
        public Nullable<System.DateTime> SumRptDate { get; set; }
        public string PIndicator { get; set; }
        public string ManualNum { get; set; }
        public string UseShpdGd { get; set; }
        public Nullable<decimal> BaseVtAt { get; set; }
        public Nullable<decimal> BaseVtAtSC { get; set; }
        public Nullable<decimal> BaseVtAtFC { get; set; }
        public Nullable<decimal> NnSbVAt { get; set; }
        public Nullable<decimal> NnSbVAtSC { get; set; }
        public Nullable<decimal> NbSbVAtFC { get; set; }
        public Nullable<decimal> ExptVAt { get; set; }
        public Nullable<decimal> ExptVAtSC { get; set; }
        public Nullable<decimal> ExptVAtFC { get; set; }
        public Nullable<decimal> LYPmtAt { get; set; }
        public Nullable<decimal> LYPmtAtSC { get; set; }
        public Nullable<decimal> LYPmtAtFC { get; set; }
        public Nullable<decimal> ExpAnSum { get; set; }
        public Nullable<decimal> ExpAnSys { get; set; }
        public Nullable<decimal> ExpAnFrgn { get; set; }
        public string DocSubType { get; set; }
        public string DpmStatus { get; set; }
        public Nullable<decimal> DpmAmnt { get; set; }
        public Nullable<decimal> DpmAmntSC { get; set; }
        public Nullable<decimal> DpmAmntFC { get; set; }
        public string DpmDrawn { get; set; }
        public Nullable<decimal> DpmPrcnt { get; set; }
        public Nullable<decimal> PaidSum { get; set; }
        public Nullable<decimal> PaidSumFc { get; set; }
        public Nullable<decimal> PaidSumSc { get; set; }
        public string FolioPref { get; set; }
        public Nullable<int> FolioNum { get; set; }
        public Nullable<decimal> DpmAppl { get; set; }
        public Nullable<decimal> DpmApplFc { get; set; }
        public Nullable<decimal> DpmApplSc { get; set; }
        public Nullable<int> LPgFolioN { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Posted { get; set; }
        public Nullable<int> OwnerCode { get; set; }
        public string BPChCode { get; set; }
        public Nullable<int> BPChCntc { get; set; }
        public string PayToCode { get; set; }
        public string IsPaytoBnk { get; set; }
        public string BnkCntry { get; set; }
        public string BankCode { get; set; }
        public string BnkAccount { get; set; }
        public string BnkBranch { get; set; }
        public string isIns { get; set; }
        public string TrackNo { get; set; }
        public string VersionNum { get; set; }
        public Nullable<int> LangCode { get; set; }
        public string BPNameOW { get; set; }
        public string BillToOW { get; set; }
        public string ShipToOW { get; set; }
        public string RetInvoice { get; set; }
        public Nullable<System.DateTime> ClsDate { get; set; }
        public Nullable<int> MInvNum { get; set; }
        public Nullable<System.DateTime> MInvDate { get; set; }
        public Nullable<short> SeqCode { get; set; }
        public Nullable<int> Serial { get; set; }
        public string SeriesStr { get; set; }
        public string SubStr { get; set; }
        public string Model { get; set; }
        public Nullable<decimal> TaxOnExp { get; set; }
        public Nullable<decimal> TaxOnExpFc { get; set; }
        public Nullable<decimal> TaxOnExpSc { get; set; }
        public Nullable<decimal> TaxOnExAp { get; set; }
        public Nullable<decimal> TaxOnExApF { get; set; }
        public Nullable<decimal> TaxOnExApS { get; set; }
        public string LastPmnTyp { get; set; }
        public Nullable<int> LndCstNum { get; set; }
        public string UseCorrVat { get; set; }
        public string BlkCredMmo { get; set; }
        public string OpenForLaC { get; set; }
        public string Excised { get; set; }
        public Nullable<System.DateTime> ExcRefDate { get; set; }
        public string ExcRmvTime { get; set; }
        public Nullable<decimal> SrvGpPrcnt { get; set; }
        public Nullable<int> DepositNum { get; set; }
        public string CertNum { get; set; }
        public string DutyStatus { get; set; }
        public string AutoCrtFlw { get; set; }
        public Nullable<System.DateTime> FlwRefDate { get; set; }
        public string FlwRefNum { get; set; }
        public Nullable<int> VatJENum { get; set; }
        public Nullable<decimal> DpmVat { get; set; }
        public Nullable<decimal> DpmVatFc { get; set; }
        public Nullable<decimal> DpmVatSc { get; set; }
        public Nullable<decimal> DpmAppVat { get; set; }
        public Nullable<decimal> DpmAppVatF { get; set; }
        public Nullable<decimal> DpmAppVatS { get; set; }
        public string InsurOp347 { get; set; }
        public string IgnRelDoc { get; set; }
        public string BuildDesc { get; set; }
        public string ResidenNum { get; set; }
        public string U_ResponseCode { get; set; }
        public string U_Description { get; set; }
        public string U_TipNotCre { get; set; }
        public string U_DigestValue { get; set; }
    }
}
