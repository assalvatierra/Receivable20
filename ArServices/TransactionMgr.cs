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
    public class TransactionMgr : iTransactionMgr
    {
        private ArDBContainer db;

        public TransactionMgr()
        {
            db = new ArDBContainer();
        }

        public TransactionMgr(ArDBContainer arDB)
        {
            this.db = arDB;
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
                throw new EntitySqlException("Services: Unable to Add Transaction");
            }
        }

        public bool CloseTransactionStatus(int id)
        {
            try
            {
                var transaction = GetTransactionById(id);

                if (transaction == null)
                {
                    return false;
                }

                transaction.ArTransStatusId = 3; // close

                return EditTransaction(transaction);

            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Add Transaction");
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
                throw new EntitySqlException("Services: Unable to Edit Transaction");
            }
        }

        public int GetTransAccountId(int id)
        {
            try
            {
                return GetTransactionById(id).ArAccountId;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Transaction Account ");
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
                throw new EntitySqlException("Services: Unable to Get Transaction by Id ");
            }
        }

        public List<ArTransaction> GetTransactions()
        {
            try
            {
                return db.ArTransactions.ToList();
            }
            catch 
            {
               
                throw new EntitySqlException("Services: Unable to Get Transactions ");
            }
        }

        public IEnumerable<ArTransStatus> GetTransactionStatus()
        {
            try
            {
                return db.ArTransStatus.ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Transaction Status ");
            }
        }

        public bool IsClosed(int id)
        {
            try
            {
                var transaction = GetTransactionById(id);

                if (transaction.ArTransStatusId == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Transaction Closed Status ");
            }
        }

        public bool RemoveTransaction(ArTransaction transaction)
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
                throw new EntitySqlException("Services: Unable to Remove Transaction ");
            }
        }

        public bool UpdateTransAcc(int transactionId, int accountId)
        {
            try
            {
                if (transactionId != 0)
                {
                    //get transaction
                    ArTransaction transaction = GetTransactionById(transactionId);
                    //edit transaction account id
                    transaction.ArAccountId = accountId;
                    //update transaction
                    return EditTransaction(transaction);
                }
                return false;
            }
            catch 
            {
                throw new EntitySqlException("Services: Unable to Get Transaction Account ");
            }
        }
    }
}
