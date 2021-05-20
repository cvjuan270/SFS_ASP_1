using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SFS_ASP_1.Models;

namespace SFS_ASP_1.Controllers
{
    public class GuiasController : Controller
    {
        private SEGURIMAX02Entities db = new SEGURIMAX02Entities();

        // GET: Guias
        public ActionResult Index(DateTime? FecIni, DateTime? FecFin, string Ruc, string RazSoc, int NumCor = 0)
        {
            var guias = db.ODLN.AsQueryable();
            guias = from gr in db.ODLN select gr;

            if (String.IsNullOrEmpty(FecIni.ToString()) && String.IsNullOrEmpty(FecFin.ToString()))
            {
                guias = guias.Where(c => c.DocDate >= DateTime.Now && c.DocDate <= DateTime.Now);
            }

            if (!String.IsNullOrEmpty(FecIni.ToString()) && !String.IsNullOrEmpty(FecFin.ToString()))
            {
                guias = guias.Where(c => c.DocDate >= FecIni && c.DocDate <= FecFin);
            }

            if (!String.IsNullOrEmpty(Ruc))
            {
                guias = guias.Where(c => c.LicTradNum.Contains(Ruc));
            }
            if (!String.IsNullOrEmpty(RazSoc))
            {
                guias = guias.Where(c => c.CardName.Contains(RazSoc));
            }
            return View(guias.ToList());
        }

        // GET: Guias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODLN oDLN = db.ODLN.Find(id);
            if (oDLN == null)
            {
                return HttpNotFound();
            }
            return View(oDLN);
        }

        // GET: Guias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocEntry,DocNum,DocType,CANCELED,Handwrtten,Printed,DocStatus,InvntSttus,Transfered,ObjType,DocDate,DocDueDate,CardCode,CardName,Address,NumAtCard,VatPercent,VatSum,VatSumFC,DiscPrcnt,DiscSum,DiscSumFC,DocCur,DocRate,DocTotal,DocTotalFC,PaidToDate,PaidFC,GrosProfit,GrosProfFC,Ref1,Ref2,Comments,JrnlMemo,TransId,ReceiptNum,GroupNum,DocTime,SlpCode,TrnspCode,PartSupply,Confirmed,GrossBase,ImportEnt,CreateTran,SummryType,UpdInvnt,UpdCardBal,Instance,Flags,InvntDirec,CntctCode,ShowSCN,FatherCard,SysRate,CurSource,VatSumSy,DiscSumSy,DocTotalSy,PaidSys,FatherType,GrosProfSy,UpdateDate,IsICT,CreateDate,Volume,VolUnit,Weight,WeightUnit,Series,TaxDate,Filler,DataSource,StampNum,isCrin,FinncPriod,UserSign,selfInv,VatPaid,VatPaidFC,VatPaidSys,UserSign2,WddStatus,draftKey,TotalExpns,TotalExpFC,TotalExpSC,DunnLevel,Address2,LogInstanc,Exported,StationID,Indicator,NetProc,AqcsTax,AqcsTaxFC,AqcsTaxSC,CashDiscPr,CashDiscnt,CashDiscFC,CashDiscSC,ShipToCode,LicTradNum,PaymentRef,WTSum,WTSumFC,WTSumSC,RoundDif,RoundDifFC,RoundDifSy,CheckDigit,Form1099,Box1099,submitted,PoPrss,Rounding,RevisionPo,Segment,ReqDate,CancelDate,PickStatus,Pick,BlockDunn,PeyMethod,PayBlock,PayBlckRef,MaxDscn,Reserve,Max1099,CntrlBnk,PickRmrk,ISRCodLine,ExpAppl,ExpApplFC,ExpApplSC,Project,DeferrTax,LetterNum,FromDate,ToDate,WTApplied,WTAppliedF,BoeReserev,AgentCode,WTAppliedS,EquVatSum,EquVatSumF,EquVatSumS,Installmnt,VATFirst,NnSbAmnt,NnSbAmntSC,NbSbAmntFC,ExepAmnt,ExepAmntSC,ExepAmntFC,VatDate,CorrExt,CorrInv,NCorrInv,CEECFlag,BaseAmnt,BaseAmntSC,BaseAmntFC,CtlAccount,BPLId,BPLName,VATRegNum,TxInvRptNo,TxInvRptDt,KVVATCode,WTDetails,SumAbsId,SumRptDate,PIndicator,ManualNum,UseShpdGd,BaseVtAt,BaseVtAtSC,BaseVtAtFC,NnSbVAt,NnSbVAtSC,NbSbVAtFC,ExptVAt,ExptVAtSC,ExptVAtFC,LYPmtAt,LYPmtAtSC,LYPmtAtFC,ExpAnSum,ExpAnSys,ExpAnFrgn,DocSubType,DpmStatus,DpmAmnt,DpmAmntSC,DpmAmntFC,DpmDrawn,DpmPrcnt,PaidSum,PaidSumFc,PaidSumSc,FolioPref,FolioNum,DpmAppl,DpmApplFc,DpmApplSc,LPgFolioN,Header,Footer,Posted,OwnerCode,BPChCode,BPChCntc,PayToCode,IsPaytoBnk,BnkCntry,BankCode,BnkAccount,BnkBranch,isIns,TrackNo,VersionNum,LangCode,BPNameOW,BillToOW,ShipToOW,RetInvoice,ClsDate,MInvNum,MInvDate,SeqCode,Serial,SeriesStr,SubStr,Model,TaxOnExp,TaxOnExpFc,TaxOnExpSc,TaxOnExAp,TaxOnExApF,TaxOnExApS,LastPmnTyp,LndCstNum,UseCorrVat,BlkCredMmo,OpenForLaC,Excised,ExcRefDate,ExcRmvTime,SrvGpPrcnt,DepositNum,CertNum,DutyStatus,AutoCrtFlw,FlwRefDate,FlwRefNum,VatJENum,DpmVat,DpmVatFc,DpmVatSc,DpmAppVat,DpmAppVatF,DpmAppVatS,InsurOp347,IgnRelDoc,BuildDesc,ResidenNum,U_ResponseCode,U_Description,U_TipNotCre,U_DigestValue")] ODLN oDLN)
        {
            if (ModelState.IsValid)
            {
                db.ODLN.Add(oDLN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oDLN);
        }

        // GET: Guias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODLN oDLN = db.ODLN.Find(id);
            if (oDLN == null)
            {
                return HttpNotFound();
            }
            return View(oDLN);
        }

        // POST: Guias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocEntry,DocNum,DocType,CANCELED,Handwrtten,Printed,DocStatus,InvntSttus,Transfered,ObjType,DocDate,DocDueDate,CardCode,CardName,Address,NumAtCard,VatPercent,VatSum,VatSumFC,DiscPrcnt,DiscSum,DiscSumFC,DocCur,DocRate,DocTotal,DocTotalFC,PaidToDate,PaidFC,GrosProfit,GrosProfFC,Ref1,Ref2,Comments,JrnlMemo,TransId,ReceiptNum,GroupNum,DocTime,SlpCode,TrnspCode,PartSupply,Confirmed,GrossBase,ImportEnt,CreateTran,SummryType,UpdInvnt,UpdCardBal,Instance,Flags,InvntDirec,CntctCode,ShowSCN,FatherCard,SysRate,CurSource,VatSumSy,DiscSumSy,DocTotalSy,PaidSys,FatherType,GrosProfSy,UpdateDate,IsICT,CreateDate,Volume,VolUnit,Weight,WeightUnit,Series,TaxDate,Filler,DataSource,StampNum,isCrin,FinncPriod,UserSign,selfInv,VatPaid,VatPaidFC,VatPaidSys,UserSign2,WddStatus,draftKey,TotalExpns,TotalExpFC,TotalExpSC,DunnLevel,Address2,LogInstanc,Exported,StationID,Indicator,NetProc,AqcsTax,AqcsTaxFC,AqcsTaxSC,CashDiscPr,CashDiscnt,CashDiscFC,CashDiscSC,ShipToCode,LicTradNum,PaymentRef,WTSum,WTSumFC,WTSumSC,RoundDif,RoundDifFC,RoundDifSy,CheckDigit,Form1099,Box1099,submitted,PoPrss,Rounding,RevisionPo,Segment,ReqDate,CancelDate,PickStatus,Pick,BlockDunn,PeyMethod,PayBlock,PayBlckRef,MaxDscn,Reserve,Max1099,CntrlBnk,PickRmrk,ISRCodLine,ExpAppl,ExpApplFC,ExpApplSC,Project,DeferrTax,LetterNum,FromDate,ToDate,WTApplied,WTAppliedF,BoeReserev,AgentCode,WTAppliedS,EquVatSum,EquVatSumF,EquVatSumS,Installmnt,VATFirst,NnSbAmnt,NnSbAmntSC,NbSbAmntFC,ExepAmnt,ExepAmntSC,ExepAmntFC,VatDate,CorrExt,CorrInv,NCorrInv,CEECFlag,BaseAmnt,BaseAmntSC,BaseAmntFC,CtlAccount,BPLId,BPLName,VATRegNum,TxInvRptNo,TxInvRptDt,KVVATCode,WTDetails,SumAbsId,SumRptDate,PIndicator,ManualNum,UseShpdGd,BaseVtAt,BaseVtAtSC,BaseVtAtFC,NnSbVAt,NnSbVAtSC,NbSbVAtFC,ExptVAt,ExptVAtSC,ExptVAtFC,LYPmtAt,LYPmtAtSC,LYPmtAtFC,ExpAnSum,ExpAnSys,ExpAnFrgn,DocSubType,DpmStatus,DpmAmnt,DpmAmntSC,DpmAmntFC,DpmDrawn,DpmPrcnt,PaidSum,PaidSumFc,PaidSumSc,FolioPref,FolioNum,DpmAppl,DpmApplFc,DpmApplSc,LPgFolioN,Header,Footer,Posted,OwnerCode,BPChCode,BPChCntc,PayToCode,IsPaytoBnk,BnkCntry,BankCode,BnkAccount,BnkBranch,isIns,TrackNo,VersionNum,LangCode,BPNameOW,BillToOW,ShipToOW,RetInvoice,ClsDate,MInvNum,MInvDate,SeqCode,Serial,SeriesStr,SubStr,Model,TaxOnExp,TaxOnExpFc,TaxOnExpSc,TaxOnExAp,TaxOnExApF,TaxOnExApS,LastPmnTyp,LndCstNum,UseCorrVat,BlkCredMmo,OpenForLaC,Excised,ExcRefDate,ExcRmvTime,SrvGpPrcnt,DepositNum,CertNum,DutyStatus,AutoCrtFlw,FlwRefDate,FlwRefNum,VatJENum,DpmVat,DpmVatFc,DpmVatSc,DpmAppVat,DpmAppVatF,DpmAppVatS,InsurOp347,IgnRelDoc,BuildDesc,ResidenNum,U_ResponseCode,U_Description,U_TipNotCre,U_DigestValue")] ODLN oDLN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oDLN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oDLN);
        }

        // GET: Guias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODLN oDLN = db.ODLN.Find(id);
            if (oDLN == null)
            {
                return HttpNotFound();
            }
            return View(oDLN);
        }

        // POST: Guias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ODLN oDLN = db.ODLN.Find(id);
            db.ODLN.Remove(oDLN);
            db.SaveChanges();
            return RedirectToAction("Index");
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
