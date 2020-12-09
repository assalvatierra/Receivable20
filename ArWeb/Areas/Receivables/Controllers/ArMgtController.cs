using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArModels.Models;
using ArServices;

namespace JobsV1.Areas.Receivables.Controllers
{
    public class ArMgtController : Controller
    {
        private ReceivableFactory ar = new ReceivableFactory();

        // GET: Receivables/ArMgt
        public ActionResult Index()
        {
            return View();
        }

        #region Due Date Management
        public ActionResult DueDateMgt()
        {
            //get ongoing transactions
            var transactions = ar.TransactionMgr.GetActiveTransactions();
            ViewBag.today = ar.DateClassMgr.GetCurrentDate();
            return View(transactions);
        }

        #endregion


        #region Reminders Module
        public ActionResult Reminders()
        {
            //get ongoing transactions
            var transactions = ar.TransactionMgr.GetActiveTransactions();

            return View(transactions);
        }

        #endregion


        #region Settlement Module
        public ActionResult Settlement()
        {
            //get ongoing transactions
            var transactions = ar.TransactionMgr.GetActiveTransactions();

            return View(transactions);
        }

        #endregion
    }
}