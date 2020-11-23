using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobsV1.Areas.Receivables.Controllers
{
    public class ArMgtController : Controller
    {
        // GET: Receivables/ArMgt
        public ActionResult Index()
        {
            return View();
        }

        #region Due Date Management
        public ActionResult DueDateMgt()
        {
            return View();
        }

        #endregion


        #region Reminders Module
        public ActionResult Reminders()
        {
            return View();
        }

        #endregion


        #region Settlement Module
        public ActionResult Settlement()
        {
            return View();
        }

        #endregion
    }
}