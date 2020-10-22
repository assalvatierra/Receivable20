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
    public class TransactionDb : iTransactionDb
    {
        private ArDBContainer db;

        public TransactionDb()
        {
            this.db = new ArDBContainer();
        }

        public bool AddTransaction(ArTransaction transaction)
        {
            try
            {
                if (transaction != null)
                {
                    db.ArTransactions.Add(transaction);
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

        public bool DeleteTransaction(ArTransaction transaction)
        {
            try
            {
                if (transaction == null)
                {
                    return false;
                }

                db.ArTransactions.Remove(transaction);
                db.SaveChanges();
                return true;
               
            }
            catch
            {
                return false;
            }
        }

        public bool EditTransaction(ArTransaction transaction)
        {
            try
            {
                if (transaction == null)
                {
                    return false;
                }

                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public ArTransaction GetTransactionById(int id)
        {
            try
            {
                return db.ArTransactions.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ArTransaction> GetTransactions()
        {
            try
            {
                return db.ArTransactions;
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<ArTransStatus> GetTransactionStatus()
        {
            try
            {
                return db.ArTransStatus;
            }
            catch
            {
                return null;
            }
        }
    }
}
