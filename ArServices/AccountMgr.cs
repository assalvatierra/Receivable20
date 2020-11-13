using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArInterfaces;
using ArModels.Models;
using ArDBLayer;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.SqlClient;

namespace ArServices
{
    public class AccountMgr : iAccountMgr
    {
        private AccountDb db;

        ArDBContainer DBContainer = new ArDBContainer();


        public AccountMgr()
        {
            db = new AccountDb();
        }
        public AccountMgr(ArDBContainer arDB)
        {
            db = new AccountDb(arDB);
        }

        public bool AddAccount(ArAccount account)
        {
            try
            {
                return db.AddAccount(account);
            }
            catch
            {
                return false;
            }
        }

        public bool EditAccount(ArAccount account)
        {
            try
            {
                return db.EditAccount(account);
            }
            catch
            {
                return false;
            }
        }

        public ArAccount GetAccountById(int id)
        {
            try
            {
                return db.GetAccountById(id);
            }
            catch
            {
                return null;
            }
        }

        public List<ArAccount> GetArAccounts()
        {
            try
            {
                return db.GetAccounts().ToList();
            }
            catch
            {
                
                return null;
            }
        }

        public bool RemoveAccount(ArAccount account)
        {
            try
            {
                return db.RemoveAccount(account);
            }
            catch
            {
                return false;
            }
        }


        public IEnumerable<ArAccStatus> GetArAccStatus()
        {
            try
            {
                return db.GetAccStatus().ToList();
            }
            catch
            {
                return null;
            }
        }

        #region Account Credit Limit
        public List<ArAccntCredit> AllAccntCreditLimit(int AccntId)
        {
            try
            {
                return DBContainer.ArAccntCredits.Where(d=>d.ArAccountId == AccntId).ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Account credit details Not found");
            }
        }

        public ArAccntCredit GetLatestAccntCreditLimit(int AccntId)
        {
            try
            {
                return this.AllAccntCreditLimit(AccntId).OrderByDescending(d=>d.DtCredit).First();
            }
            catch
            {
                throw new EntitySqlException("Services: Account credit details Not found");
            }

        }
       

        public bool UpdateAccntCredit(ArAccntCredit credit)
        {
            try
            {
                if (credit != null)
                {
                    DBContainer.Entry(credit).State = EntityState.Modified;
                    DBContainer.SaveChanges();
                    return true;
                }
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to udpate credit details");
            }

            return false;
        }

        public bool AddAccntCredit(ArAccntCredit credit)
        {
            try
            {
                if (credit != null)
                {
                    DBContainer.ArAccntCredits.Add(credit);
                    DBContainer.SaveChanges();
                    return true;
                }
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to add new credit details");
            }

            return false;
        }
        #endregion

        #region Payment term
        public List<ArAccntTerm> AllAccntPaymentTerm(int AccntId)
        {
            try
            {
                return DBContainer.ArAccntTerms.Where(d => d.ArAccountId == AccntId).ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: unable to retrieve Payment terms");
            }
            
        }

        public ArAccntTerm GetLatestAccntPaymentTerm(int AccntId)
        {
            try
            {
                return this.AllAccntPaymentTerm(AccntId).OrderByDescending(d => d.dtTerm).First();
            }
            catch
            {
                throw new EntitySqlException("Services: Account credit details Not found");
            }

        }

        public bool UpdateAccntPaymentTerm(ArAccntTerm term)
        {
            try
            {
                if (term != null)
                {
                    DBContainer.Entry(term).State = EntityState.Modified;
                    DBContainer.SaveChanges();
                    return true;
                }
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to udpate payment terms");
            }

            return false;
        }

        public bool AddAccntPaymentTerm(ArAccntTerm term)
        {
            try
            {
                if (term != null)
                {
                    DBContainer.ArAccntTerms.Add(term);
                    DBContainer.SaveChanges();
                    return true;
                }
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to add new payment term");
            }

            return false;
        }

        #endregion


    }
}
