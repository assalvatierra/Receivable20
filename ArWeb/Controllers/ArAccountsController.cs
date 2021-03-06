﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArModels.Models;
using ArServices;
using Microsoft.Ajax.Utilities;

namespace ArWeb.Controllers
{
    public class ArAccountsController : Controller
    {
        private ReceivableFactory ar = new ReceivableFactory();

        // GET: ArAccounts
        public ActionResult Index()
        {
            var accountList = ar.AccountMgr.GetArAccounts();

            return View(accountList);
        }

        // GET: ArAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var account = ar.AccountMgr.GetAccountById((int)id);

            if (account == null)
            {
                return HttpNotFound();
            }

            return View(account);
        }

        // GET: ArAccounts/Create
        public ActionResult Create()
        {
            ViewBag.ArAccStatusId = new SelectList(ar.AccountMgr.GetArAccStatus(), "Id", "Status");
            return View();
        }

        // POST: ArAccounts/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,Landline,Email,Mobile,Company,Address,Remarks,ArAccStatusId")] ArAccount account)
        {
            if (ModelState.IsValid && InputValidation(account))
            {
                ar.AccountMgr.AddAccount(account);

                return RedirectToAction("Index");
            }

            ViewBag.ArAccStatusId = new SelectList(ar.AccountMgr.GetArAccStatus(), "Id", "Status", account.ArAccStatusId);
            return View(account);
        }


        // GET: ArAccounts/Create
        public ActionResult CreateAccTrans( int transId )
        {
            ViewBag.TransId = transId;
            ViewBag.ArAccStatusId = new SelectList(ar.AccountMgr.GetArAccStatus(), "Id", "Status");
            return View();
        }

        // POST: ArAccounts/Create
        [HttpPost]
        public ActionResult CreateAccTrans([Bind(Include = "Id,Name,Landline,Email,Mobile,Company,Address,Remarks,ArAccStatusId")] ArAccount account, int transId)
        {
            if (ModelState.IsValid && InputValidation(account))
            {
                ar.AccountMgr.AddAccount(account);

                return RedirectToAction("Index");
            }

            ViewBag.TransId = transId;
            ViewBag.ArAccStatusId = new SelectList(ar.AccountMgr.GetArAccStatus(), "Id", "Status", account.ArAccStatusId);
            return View(account);
        }

        // GET: ArAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var account = ar.AccountMgr.GetAccountById((int)id);
            if (account == null)
            {
                return HttpNotFound();
            }

            ViewBag.ArAccStatusId = new SelectList(ar.AccountMgr.GetArAccStatus(), "Id", "Status");
            return View(account);
        }

        // POST: ArAccounts/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Landline,Email,Mobile,Company,Address,Remarks,ArAccStatusId")] ArAccount account)
        {
            if (ModelState.IsValid && InputValidation(account))
            {
                ar.AccountMgr.EditAccount(account);
                return RedirectToAction("Index");
            }
            ViewBag.ArAccStatusId = new SelectList(ar.AccountMgr.GetArAccStatus(), "Id", "Status");
            return View(account);
        }

        // GET: ArAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var account = ar.AccountMgr.GetAccountById((int)id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: ArAccounts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var account = ar.AccountMgr.GetAccountById((int)id);
                ar.AccountMgr.RemoveAccount(account);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public bool InputValidation(ArAccount account)
        {
            bool isValid = true;

            if (account.Name.IsNullOrWhiteSpace())
            {
                ModelState.AddModelError("Name", "Invalid Name");
                isValid = false;
            }

            if (account.Email.IsNullOrWhiteSpace())
            {
                ModelState.AddModelError("Email", "Invalid Email");
                isValid = false;
            }


            if (account.Mobile.IsNullOrWhiteSpace() || account.Mobile.Length < 11)
            {
                ModelState.AddModelError("Mobile", "Invalid Mobile");
                isValid = false;
            }


            return isValid;
        }

        //param: id = accountId
        [HttpGet]
        public decimal GetAccountCreditLimit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return 0;
                }

                var accountCreditLimit = ar.AccountMgr.GetLatestAccntCreditLimit((int)id);
                if (accountCreditLimit != null)
                {
                    return accountCreditLimit.CreditLimit;
                }

                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
