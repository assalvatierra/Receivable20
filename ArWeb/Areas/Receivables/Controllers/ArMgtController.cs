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

        #region Due Date Management
        // GET: Receivables/ArMgt
        public ActionResult Index()
        {
            var today = ar.DateClassMgr.GetCurrentDate();
            var tomorrow = today.AddDays(1);
            var yesterday = today.AddDays(-1);

            //get ongoing transactions
            var transactions = ar.TransactionMgr.GetActiveTransactions();
            var overDue = transactions.Where(t => t.DtDue.AddDays(1) < today);

            transactions = transactions.Where(c => !overDue.Contains(c)).ToList();

            ViewBag.today = today;
            ViewBag.OverDueTrans = overDue.OrderBy(t=>t.DtDue).ToList(); 

            return View(transactions.OrderBy(d => d.DtDue));
        }

        // GET: Receivables/ArMgt/UpdateDueDate
        // Param:   transId = transactionId
        //          dueDate = new dueDate
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

        // GET: Receivables/ArMgt/GetCustomerMobile
        // Param : transId = transactionId
        [HttpGet]
        public JsonResult GetTransactionDetails(int transId)
        {
            var transaction = ar.TransactionMgr.GetTransactionById(transId);

            if (transaction == null)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }

            return Json(new {
                transaction.Id,
                transaction.InvoiceId,
                transaction.DtInvoice,
                transaction.DtDue,
                transaction.Description,
                transaction.Amount,
                transaction.ArTransStatu.Status,

            }
                , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool SendEmailReminder(string recipient, string emailMessage)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(recipient.Trim()))
                {

                    emailMessage = emailMessage.Replace("\n", "<br>");

                    return ar.EmailMgr.SendEmail(recipient, emailMessage);
                }

                return false;
            }
            catch
            {
                return false;
            }
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