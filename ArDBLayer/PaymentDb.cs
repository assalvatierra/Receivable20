using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArModels;
using ArInterfaces;
using ArModels.Models;

namespace ArDBLayer
{
    public class PaymentDb : iPaymentDb
    {
        private ArDBContainer db;

        public PaymentDb()
        {
            this.db = new ArDBContainer();
        }
        public PaymentDb(ArDBContainer arDB)
        {
            this.db = arDB;
        }

        public bool AddPayment(ArPayment payment)
        {
            try
            {
                if (payment != null)
                {
                    db.ArPayments.Add(payment);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DbDispose()
        {
            db.Dispose();
            return true;
        }

        public bool EditPayment(ArPayment payment)
        {
            try
            {
                if (payment != null)
                {
                    db.Entry(payment).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<ArPayment> GetPayment()
        {
            try
            {
                return db.ArPayments;
            }
            catch
            {
                return null;
            }
        }

        public ArPayment GetPaymentById(int id)
        {
            try
            {
                return db.ArPayments.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ArPaymentType> GetPaymentTypes()
        {
            try
            {
                return db.ArPaymentTypes;
            }
            catch
            {
                return null;
            }
        }

        public bool RemovePayment(ArPayment payment)
        {

            try
            {
                if (payment != null)
                {
                    db.ArPayments.Remove(payment);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
