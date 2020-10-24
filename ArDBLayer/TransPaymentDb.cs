using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArInterfaces;
using ArModels.Models;
using System.Data.Entity;

namespace ArDBLayer
{
    public class TransPaymentDb : iTransPaymentDb
    {

        private ArDBContainer db;

        public TransPaymentDb()
        {
            this.db = new ArDBContainer();
        }

        public TransPaymentDb(ArDBContainer arDB)
        {
            this.db = arDB;
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
            catch (Exception ex )
            {
                throw ex;
                return false;
            }
        }

        public bool DbDispose()
        {
            try
            {
                db.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTransPayment(ArTransPayment transPayment)
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
                return false;
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
                return false;
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
                return null;
            }
        }

        public IQueryable<ArTransPayment> GetTransPayments()
        {


            try
            {
                return db.ArTransPayments;
            }
            catch
            {
                return null;
            }
        }
    }
}
