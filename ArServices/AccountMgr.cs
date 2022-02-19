using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArInterfaces;
using ArModels.Models;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.SqlClient;

namespace ArServices
{
    public class AccountMgr : iAccountMgr
    {
        //private AccountDb db;
        ArDBContainer db = new ArDBContainer();

        public AccountMgr()
        {
            if (db == null)
            {
                db = new ArDBContainer();
            }
        }
        public AccountMgr(ArDBContainer arDB)
        {
            db = arDB;
        }

        public bool AddAccount(ArAccount account)
        {
            try
            {
                if (account != null)
                {
                    db.ArAccounts.Add(account);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Add Recievable Account");
            }
        }

        public bool EditAccount(ArAccount account)
        {
            try
            {
                if (account != null)
                {
                    db.Entry(account).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Edit Recievable Account");
            }
        }

        public ArAccount GetAccountById(int id)
        {
            try
            {
                return db.ArAccounts.Find(id);
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Recievable Account by Id");
            }
        }

        public List<ArAccount> GetArAccounts()
        {
            try
            {
                return db.ArAccounts.ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Recievable Accounts");
            }
        }

        public bool RemoveAccount(ArAccount account)
        {
            try
            {
                if (account != null)
                {
                    db.ArAccounts.Remove(account);
                    db.SaveChanges();
                    return true;
                }
                return true;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Remove Recievable Account");
            } 
        }


        public IEnumerable<ArAccStatus> GetArAccStatus()
        {
            try
            {
                return db.ArAccStatus;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Recievable Account Status");
            }
        }

        #region Account Credit Limit
        public List<ArAccntCredit> AllAccntCreditLimit(int AccntId)
        {
            try
            {
                return db.ArAccntCredits.Where(d=>d.ArAccountId == AccntId).ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Account credit details Not found");
            }
        }

        public ArAccntCredit GetLatestAccntCreditLimit(int AccntId)
        {
            try { 

                if (this.AllAccntCreditLimit(AccntId).Count() == 0)
                {
                    return new ArAccntCredit();
                }

                return this.AllAccntCreditLimit(AccntId).OrderByDescending(d=>d.DtCredit).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
                throw new EntitySqlException("Services: Account credit details Not found");
            }

        }


        public bool UpdateAccntCredit(ArAccntCredit credit)
        {
            try
            {
                if (credit != null)
                {
                    db.Entry(credit).State = EntityState.Modified;
                    db.SaveChanges();
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
                    db.ArAccntCredits.Add(credit);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to add new credit details");
            }

            return false;
        }


        public bool AddAccntCreditDefault(int AccntId)
        {
            try
            {
                var today = new DateTime();

                ArAccntCredit accntCredit = new ArAccntCredit();
                accntCredit.ArAccountId = AccntId;
                accntCredit.ApprovedBy = "Default";
                accntCredit.ArCreditStatusId = 1;
                accntCredit.CreditWarning    = 10000;
                accntCredit.CreditLimit      = 20000;
                accntCredit.OverLimitAllowed = 30000;
                accntCredit.DtCredit = today;

                return this.AddAccntCredit(accntCredit);
                
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to add new credit details");
            }
        }
        #endregion

        #region Payment term
        public List<ArAccntTerm> AllAccntPaymentTerm(int AccntId)
        {
            try
            {
                return db.ArAccntTerms.Where(d => d.ArAccountId == AccntId).ToList();
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
                if (AllAccntPaymentTerm(AccntId) == null)
                {
                    return new ArAccntTerm();
                }
                var payments = AllAccntPaymentTerm(AccntId);
                return this.AllAccntPaymentTerm(AccntId).OrderByDescending(d => d.dtTerm).FirstOrDefault();
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
                    db.Entry(term).State = EntityState.Modified;
                    db.SaveChanges();
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
                    db.ArAccntTerms.Add(term);
                    db.SaveChanges();
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


        #region Contacts 

        public bool AddAccContact(ArAccContact contact)
        {
            try
            {
                if (contact != null)
                {
                    db.ArAccContacts.Add(contact);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Add Recievable Account Contact");
            }
        }

        public bool EditAccContact(ArAccContact contact)
        {
            try
            {
                if (contact != null)
                {
                    db.Entry(contact).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Edit Recievable Account Contact");
            }
        }

        public bool RemoveAccContact(ArAccContact contact)
        {
            try
            {
                if (contact != null)
                {
                    db.ArAccContacts.Remove(contact);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Remove Recievable Account Contact");
            }
        }

        public ArAccContact GetAccContactById(int id)
        {
            try
            {
                return db.ArAccContacts.Find(id);
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Recievable Account by Id");
            }
        }

        public List<ArAccContact> GetAccContactsByAccId(int accountId)
        {
            try
            {
                return db.ArAccContacts.Where(c=>c.ArAccountId == accountId).ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Recievable Account Contacts by AccountId");
            }
        }

        public List<ArAccContact> GetAccContacts()
        {
            try
            {
                return db.ArAccContacts.ToList();
            }
            catch
            {
                throw new EntitySqlException("Services: Unable to Get Recievable Account Contacts by AccountId");
            }
        }

        #endregion

    }
}
