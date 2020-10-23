using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArModels.Models;
using ArServices;

namespace ArWeb.Controllers
{
    public class ArPaymentsController : Controller
    {
        private ReceivableFactory ar = new ReceivableFactory();

        // GET: ArPayments
        public ActionResult Index()
        {
            var arPayments = ar.PaymentMgr.GetPayments();
            return View(arPayments.ToList());
        }

        // GET: ArPayments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArPayment arPayment = ar.PaymentMgr.GetPaymentById(id);
            if (arPayment == null)
            {
                return HttpNotFound();
            }
            return View(arPayment);
        }

        // GET: ArPayments/Create
        public ActionResult Create()
        {
            ViewBag.ArAccountId = new SelectList(ar.AccountMgr.GetArAccounts(), "Id", "Name");
            ViewBag.ArPaymentTypeId = new SelectList(ar.PaymentMgr.GetPaymentTypes(), "Id", "Type");
            return View();
        }

        // POST: ArPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DtPayment,Amount,Remarks,Reference,ArAccountId,ArPaymentTypeId")] ArPayment arPayment)
        {
            if (ModelState.IsValid)
            {
                ar.PaymentMgr.AddPayment(arPayment);
                return RedirectToAction("Index");
            }

            ViewBag.ArAccountId = new SelectList(ar.AccountMgr.GetArAccounts(), "Id", "Name", arPayment.ArAccountId);
            ViewBag.ArPaymentTypeId = new SelectList(ar.PaymentMgr.GetPaymentTypes(), "Id", "Type", arPayment.ArPaymentTypeId);
            return View(arPayment);
        }

        // GET: ArPayments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArPayment arPayment = ar.PaymentMgr.GetPaymentById(id);
            if (arPayment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArAccountId = new SelectList(ar.AccountMgr.GetArAccounts(), "Id", "Name", arPayment.ArAccountId);
            ViewBag.ArPaymentTypeId = new SelectList(ar.PaymentMgr.GetPaymentTypes(), "Id", "Type", arPayment.ArPaymentTypeId);
            return View(arPayment);
        }

        // POST: ArPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DtPayment,Amount,Remarks,Reference,ArAccountId,ArPaymentTypeId")] ArPayment arPayment)
        {
            if (ModelState.IsValid)
            {
                ar.PaymentMgr.EditPayment(arPayment);
                return RedirectToAction("Index");
            }
            ViewBag.ArAccountId = new SelectList(ar.AccountMgr.GetArAccounts(), "Id", "Name", arPayment.ArAccountId);
            ViewBag.ArPaymentTypeId = new SelectList(ar.PaymentMgr.GetPaymentTypes(), "Id", "Type", arPayment.ArPaymentTypeId);
            return View(arPayment);
        }

        // GET: ArPayments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArPayment arPayment = ar.PaymentMgr.GetPaymentById(id);
            if (arPayment == null)
            {
                return HttpNotFound();
            }
            return View(arPayment);
        }

        // POST: ArPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ar.PaymentMgr.RemovePayment(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ar.PaymentMgr.DbDispose();
            }
            base.Dispose(disposing);
        }
    }
}
