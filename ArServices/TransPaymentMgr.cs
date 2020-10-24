using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArDBLayer;
using ArInterfaces;
using ArModels.Models;

namespace ArServices
{
    public class TransPaymentMgr : iTransPaymentMgr
    {

        private TransPaymentDb db;

        public TransPaymentMgr()
        {
            db = new TransPaymentDb();
        }
        public TransPaymentMgr(ArDBContainer arDB)
        {
            db = new TransPaymentDb(arDB);
        }

        public bool AddTransPayment(ArTransPayment transPayment)
        {
            try
            {
                return db.AddTransPayment(transPayment);
            }
            catch
            {
                return false;
            }
        }

        public bool AddTransPayment(int transId, int paymentId)
        {
            try
            {
                if (transId == 0 || paymentId == 0)
                {
                    return false;
                }

                ArTransPayment arTransPayment = new ArTransPayment();
                arTransPayment.ArTransactionId = transId;
                arTransPayment.ArPaymentId = paymentId;

                return db.AddTransPayment(arTransPayment);
            }
            catch 
            {
               
                return false;
            }
        }

        public bool EditTransPayment(ArTransPayment transPayment)
        {
            try
            {
                return db.EditTransPayment(transPayment);
            }
            catch
            {
                return false;
            }
        }

        public ArTransPayment GetTransPaymentById(int id)
        {
            try
            {
                return db.GetTransPaymentById(id);
            }
            catch
            {
                return null;
            }
        }

        public List<ArTransPayment> GetTransPayments()
        {

            try
            {
                return db.GetTransPayments().ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<ArTransPayment> GetTransPaymentsByTransId(int transId)
        {

            try
            {
                return db.GetTransPayments().Where(t=>t.ArTransactionId == transId).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool RemoveTransPayment(ArTransPayment transPayment)
        {

            try
            {
                return db.DeleteTransPayment(transPayment);
            }
            catch
            {
                return false;
            }
        }
    }
}
