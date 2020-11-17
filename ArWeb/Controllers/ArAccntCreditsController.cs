using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArModels.Models;

namespace JobsV1.Controllers
{
    public class ArAccntCreditsController : Controller
    {
        private ArDBContainer db = new ArDBContainer();

        // GET: ArAccntCredits
        public ActionResult Index()
        {
            var arAccntCredits = db.ArAccntCredits.Include(a => a.ArAccount).Include(a => a.ArCreditStatu);
            return View(arAccntCredits.ToList());
        }

        // GET: ArAccntCredits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArAccntCredit arAccntCredit = db.ArAccntCredits.Find(id);
            if (arAccntCredit == null)
            {
                return HttpNotFound();
            }
            return View(arAccntCredit);
        }

        // GET: ArAccntCredits/Create
        public ActionResult Create()
        {
            ViewBag.ArAccountId = new SelectList(db.ArAccounts, "Id", "Name");
            ViewBag.ArCreditStatusId = new SelectList(db.ArCreditStatus, "Id", "Status");
            return View();
        }

        // POST: ArAccntCredits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ArAccountId,DtCredit,CreditLimit,OverLimitAllowed,CreditWarning,ApprovedBy,ArCreditStatusId")] ArAccntCredit arAccntCredit)
        {
            if (ModelState.IsValid)
            {
                db.ArAccntCredits.Add(arAccntCredit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArAccountId = new SelectList(db.ArAccounts, "Id", "Name", arAccntCredit.ArAccountId);
            ViewBag.ArCreditStatusId = new SelectList(db.ArCreditStatus, "Id", "Status", arAccntCredit.ArCreditStatusId);
            return View(arAccntCredit);
        }

        // GET: ArAccntCredits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArAccntCredit arAccntCredit = db.ArAccntCredits.Find(id);
            if (arAccntCredit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArAccountId = new SelectList(db.ArAccounts, "Id", "Name", arAccntCredit.ArAccountId);
            ViewBag.ArCreditStatusId = new SelectList(db.ArCreditStatus, "Id", "Status", arAccntCredit.ArCreditStatusId);
            return View(arAccntCredit);
        }

        // POST: ArAccntCredits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ArAccountId,DtCredit,CreditLimit,OverLimitAllowed,CreditWarning,ApprovedBy,ArCreditStatusId")] ArAccntCredit arAccntCredit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arAccntCredit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArAccountId = new SelectList(db.ArAccounts, "Id", "Name", arAccntCredit.ArAccountId);
            ViewBag.ArCreditStatusId = new SelectList(db.ArCreditStatus, "Id", "Status", arAccntCredit.ArCreditStatusId);
            return View(arAccntCredit);
        }

        // GET: ArAccntCredits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArAccntCredit arAccntCredit = db.ArAccntCredits.Find(id);
            if (arAccntCredit == null)
            {
                return HttpNotFound();
            }
            return View(arAccntCredit);
        }

        // POST: ArAccntCredits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArAccntCredit arAccntCredit = db.ArAccntCredits.Find(id);
            db.ArAccntCredits.Remove(arAccntCredit);
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
