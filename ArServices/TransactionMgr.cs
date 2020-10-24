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
    public class TransactionMgr : iTransactionMgr
    {
        private TransactionDb db;

        public TransactionMgr()
        {
            db = new TransactionDb();
        }

        public TransactionMgr(ArDBContainer arDB)
        {
            this.db = new TransactionDb(arDB);
        }

        public bool AddTransaction(ArTransaction transaction)
        {
            try
            {
                return db.AddTransaction(transaction);
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
                return db.EditTransaction(transaction);
            }
            catch
            {
                return false;
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
                return 0;
            }
        }

        public ArTransaction GetTransactionById(int id)
        {
            try
            {
                return db.GetTransactionById(id);
            }
            catch
            {
                return null;
            }
        }

        public List<ArTransaction> GetTransactions()
        {
            try
            {
                return db.GetTransactions().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public IEnumerable<ArTransStatus> GetTransactionStatus()
        {
            try
            {
                return db.GetTransactionStatus().ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool RemoveTransaction(ArTransaction transaction)
        {
            try
            {
                return db.DeleteTransaction(transaction);
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTransAcc(int transactionId, int accountId)
        {
            try
            {
                //get transaction
                ArTransaction transaction = GetTransactionById(transactionId);
                //edit transaction account id
                transaction.ArAccountId = accountId;
                //update transaction
                return EditTransaction(transaction);

            }
            catch
            {
                return false;
            }
        }
    }
}
