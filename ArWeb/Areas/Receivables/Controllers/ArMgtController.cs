using System;
using System.Collections.Generic;
using System.Globalization;
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

        #region Due Date Management
        public ActionResult Index()
        {
            var today = ar.DateClassMgr.GetCurrentDate();
            var tomorrow = today.AddDays(2);
            var yesterday = today.AddDays(-1);

            //get ongoing transactions
            var transactions = ar.TransactionMgr.GetActiveTransactions();
            var overDue = transactions.Where(t => t.DtDue <= yesterday);

            ViewBag.today = today;
            ViewBag.OverDueTrans = overDue.OrderBy(t=>t.DtDue).ToList(); 

            return View(transactions.Where(c=> !overDue.Contains(c)));
        }

        [HttpPost]
        public bool UpdateDueDate(int? transId, string dueDate)
        {

            if (transId == null || String.IsNullOrEmpty(dueDate.Trim()) )
            {
                return false;
            }

            var transaction = ar.TransactionMgr.GetTransactionById((int)transId);

            if (transaction == null)
            {
                return false;
            }

            //try parse if due date is datetime obj
            var newDueDate = new DateTime();
            if (!DateTime.TryParseExact(dueDate, "MM/dd/yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out newDueDate))
            {
                return false;
            }

            //edit 
            transaction.DtDue = newDueDate;
            return ar.TransactionMgr.EditTransaction(transaction);
        }

        #endregion


        #region For Approval Module
        public ActionResult Approval()
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