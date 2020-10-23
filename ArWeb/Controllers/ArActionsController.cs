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
    public class ArActionsController : Controller
    {
        private ReceivableFactory ar = new ReceivableFactory();

        // GET: ArActions
        public ActionResult Index()
        {
            var arActions = ar.ActionMgr.GetActions();
            return View(arActions.ToList());
        }

        // GET: ArActions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArAction arAction = ar.ActionMgr.GetActionById(id);
            if (arAction == null)
            {
                return HttpNotFound();
            }
            return View(arAction);
        }

        // GET: ArActions/Create
        public ActionResult Create()
        {
            ViewBag.ArTransactionId = new SelectList(ar.TransactionMgr.GetTransactions(), "Id", "Description");
            ViewBag.ArActionItemId = new SelectList(ar.ActionMgr.GetActionItems(), "Id", "Action");
            return View();
        }

        // POST: ArActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DtPerformed,PreformedBy,ArTransactionId,ArActionItemId")] ArAction arAction)
        {
            if (ModelState.IsValid)
            {
                ar.ActionMgr.AddAction(arAction);
                return RedirectToAction("Index");
            }

            ViewBag.ArTransactionId = new SelectList(ar.TransactionMgr.GetTransactions(), "Id", "Description", arAction.ArTransactionId);
            ViewBag.ArActionItemId = new SelectList(ar.ActionMgr.GetActionItems(), "Id", "Action", arAction.ArActionItemId);
            return View(arAction);
        }

        // GET: ArActions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArAction arAction = ar.ActionMgr.GetActionById(id);
            if (arAction == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArTransactionId = new SelectList(ar.TransactionMgr.GetTransactions(), "Id", "Description", arAction.ArTransactionId);
            ViewBag.ArActionItemId = new SelectList(ar.ActionMgr.GetActionItems(), "Id", "Action", arAction.ArActionItemId);
            return View(arAction);
        }

        // POST: ArActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DtPerformed,PreformedBy,ArTransactionId,ArActionItemId")] ArAction arAction)
        {
            if (ModelState.IsValid)
            {
                ar.ActionMgr.EditAction(arAction);
                return RedirectToAction("Index");
            }
            ViewBag.ArTransactionId = new SelectList(ar.TransactionMgr.GetTransactions(), "Id", "Description", arAction.ArTransactionId);
            ViewBag.ArActionItemId = new SelectList(ar.ActionMgr.GetActionItems(), "Id", "Action", arAction.ArActionItemId);
            return View(arAction);
        }

        // GET: ArActions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArAction arAction = ar.ActionMgr.GetActionById(id);
            if (arAction == null)
            {
                return HttpNotFound();
            }
            return View(arAction);
        }

        // POST: ArActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ar.ActionMgr.RemoveAction(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ar.ActionMgr.DbDispose();
            }
            base.Dispose(disposing);
        }
    }
}
