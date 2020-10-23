using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArModels;
using ArInterfaces;
using ArModels.Models;
using ArDBLayer;

namespace ArServices
{
    public class PaymentMgr : iPaymentMgr
    {
        private PaymentDb db;
        public PaymentMgr()
        {
            db = new PaymentDb();
        }

        public bool AddPayment(ArPayment payment)
        {
            try
            {
                return db.AddPayment(payment);
            }
            catch
            {
                return false;
            }
        }

        public bool DbDispose()
        {
            db.DbDispose();
            return true;
        }

        public bool EditPayment(ArPayment payment)
        {
            try
            {
                return db.EditPayment(payment);
            }
            catch
            {
                return false;
            }
        }

        public ArPayment GetPaymentById(int? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }

                return db.GetPaymentById((int)id);
            }
            catch
            {
                return null;
            }
        }

        public List<ArPayment> GetPayments()
        {
            try
            {
                return db.GetPayment().ToList();
            }
            catch
            {
                return new List<ArPayment>();
            }
        }

        public IEnumerable<ArPaymentType> GetPaymentTypes()
        {
            try
            {
                return db.GetPaymentTypes().ToList();
            }
            catch
            {
                return new List<ArPaymentType>();
            }
        }

        public bool RemovePayment(int id)
        {
            try
            {
                if(id == null)
                {
                    return false;
                }

                ArPayment payment = db.GetPaymentById((int)id);
                if (payment == null)
                {
                    return false;
                }

                return db.RemovePayment(payment);
            }
            catch
            {
                return false;
            }
        }
    }
}
