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
using Microsoft.Ajax.Utilities;

namespace ArWeb.Controllers
{
    public class ArTransactionsController : Controller
    {
        private ReceivableFactory ar = new ReceivableFactory();

        // GET: ArTransactions
        public ActionResult Index()
        {
            var arTransactions = ar.TransactionMgr.GetTransactions();
            return View(arTransactions.ToList());
        }

        // GET: ArTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArTransaction arTransaction = ar.TransactionMgr.GetTransactionById((int)id);
            if (arTransaction == null)
            {
                return HttpNotFound();
            }
            return View(arTransaction);
        }

        // GET: ArTransactions/Create
        public ActionResult Create()
        {
            ViewBag.ArTransStatusId = new SelectList(ar.TransactionMgr.GetTransactionStatus(), "Id", "Status");
            ViewBag.ArAccountId = new SelectList(ar.AccountMgr.GetArAccounts(), "Id", "Name");
            return View();
        }

        // POST: ArTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InvoiceId,DtInvoice,Description,DtEncoded,DtDue,Amount,Interval,IsRepeating,Remarks,ArTransStatusId,ArAccountId")] ArTransaction arTransaction)
        {
            if (ModelState.IsValid && InputValidation(arTransaction))
            {
                ar.TransactionMgr.AddTransaction(arTransaction);
                return RedirectToAction("Index");
            }

            ViewBag.ArTransStatusId = new SelectList(ar.TransactionMgr.GetTransactionStatus(), "Id", "Status");
            ViewBag.ArAccountId = new SelectList(ar.AccountMgr.GetArAccounts(), "Id", "Name");
            return View(arTransaction);
        }

        // GET: ArTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArTransaction arTransaction = ar.TransactionMgr.GetTransactionById((int)id);
            if (arTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArTransStatusId = new SelectList(ar.TransactionMgr.GetTransactionStatus(), "Id", "Status", arTransaction.ArTransStatusId);
            ViewBag.ArAccountId = new SelectList(ar.AccountMgr.GetArAccounts(), "Id", "Name", arTransaction.ArAccountId);
            return View(arTransaction);
        }

        // POST: ArTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InvoiceId,DtInvoice,Description,DtEncoded,DtDue,Amount,Interval,IsRepeating,Remarks,ArTransStatusId,ArAccountId")] ArTransaction arTransaction)
        {
            if (ModelState.IsValid && InputValidation(arTransaction))
            {
                ar.TransactionMgr.EditTransaction(arTransaction);
                return RedirectToAction("Index");
            }
            ViewBag.ArTransStatusId = new SelectList(ar.TransactionMgr.GetTransactionStatus(), "Id", "Status", arTransaction.ArTransStatusId);
            ViewBag.ArAccountId = new SelectList(ar.AccountMgr.GetArAccounts(), "Id", "Name", arTransaction.ArAccountId);
            return View(arTransaction);
        }

        // GET: ArTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArTransaction arTransaction = ar.TransactionMgr.GetTransactionById((int)id);
            if (arTransaction == null)
            {
                return HttpNotFound();
            }
            return View(arTransaction);
        }

        // POST: ArTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArTransaction arTransaction = ar.TransactionMgr.GetTransactionById((int)id);
            ar.TransactionMgr.RemoveTransaction(arTransaction);
            return RedirectToAction("Index");
        }

        public bool InputValidation(ArTransaction transaction)
        {
            bool isValid = true;

            if (transaction.InvoiceId == 0)
            {
                ModelState.AddModelError("InvoiceId", "Invalid InvoiceId");
                isValid = false;
            }

            if (transaction.Description.IsNullOrWhiteSpace())
            {
                ModelState.AddModelError("Description", "Invalid Description");
                isValid = false;
            }

            if (transaction.Amount.IsNullOrWhiteSpace())
            {
                ModelState.AddModelError("Amount", "Invalid Amount");
                isValid = false;
            }
            if (transaction.Interval.IsNullOrWhiteSpace())
            {
                ModelState.AddModelError("Interval", "Invalid Interval");
                isValid = false;
            }



            return isValid;
        }

    }
}
