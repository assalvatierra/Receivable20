using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
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

        private ArDBContainer db;

        public TransPaymentMgr()
        {
            db = new ArDBContainer();
        }
        public TransPaymentMgr(ArDBContainer arDB)
        {
            db = arDB;
        }

        public bool AddTransPayment(ArTransPayment transPayment)
        {
            try
            {
                if (transPayment == null)
                {
                    return false;
                }

                db.ArTransPayments.Add(transPayment);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Add Transaction Payment");
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

                return AddTransPayment(arTransPayment);
            }
            catch 
            {
                throw new EntitySqlException("Services: Unable to Add Transaction Payment ");
            }
        }

        public bool EditTransPayment(ArTransPayment transPayment)
        {
            try
            {
                if (transPayment == null)
                {
                    return false;
                }

                db.Entry(transPayment).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Edit Transaction Payment ");
            }
        }

        public ArTransPayment GetTransPaymentById(int id)
        {
            try
            {
                return db.ArTransPayments.Find(id);
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Transaction Payment by Id");
            }
        }

        public List<ArTransPayment> GetTransPayments()
        {

            try
            {
                return db.ArTransPayments.ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Transaction Payments ");
            }
        }

        public List<ArTransPayment> GetTransPaymentsByTransId(int transId)
        {

            try
            {
                return GetTransPayments().Where(t=>t.ArTransactionId == transId).ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Transaction Payment by Transaction Id ");
            }
        }

        public bool RemoveTransPayment(ArTransPayment transPayment)
        {

            try
            {
                if (transPayment == null)
                {
                    return false;
                }

                db.ArTransPayments.Remove(transPayment);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Transaction Payment Remove Transaction Payment");
            }
        }
    }
}
