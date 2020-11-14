using ArModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArInterfaces;
using System.Data.Entity;

namespace ArDBLayer
{
    public class AccountDb : iAccountDb
    {
        private ArDBContainer db;

        public AccountDb()
        {
            this.db = new ArDBContainer();
        }
        public AccountDb(ArDBContainer arDB)
        {
            this.db = arDB;
        }

        public bool DbDispose()
        {
            db.Dispose();
            return true;
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
            catch (Exception ex)
            {
                throw new Exception(string.Format("Unable to Create new Recievable Account", "0", ex.Message));
                return false;
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
            catch (Exception ex)
            {
                throw new Exception(string.Format("Unable to Edit Recievable Account", "0", ex.Message));
                return false;
            }
        }

        public IQueryable<ArAccount> GetAccounts()
        {
            try
            {
                return db.ArAccounts;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Unable to retrieve Accounts", "0", ex.Message));
                return null;
            }
        }

        public bool RemoveAccount(ArAccount account)
        {
            try {
                if (account != null)
                {
                    db.ArAccounts.Remove(account);
                    db.SaveChanges();
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Unable to Remove Recievable Account", "0", ex.Message));
                return false;
            }
        }

        public ArAccount GetAccountById(int id)
        {
            try
            {
                return db.ArAccounts.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Unable to Retrieve Recievable Account by Id", "0", ex.Message));
                return null;
            }
        }

        public IQueryable<ArAccStatus> GetAccStatus()
        {
            try
            {
                return db.ArAccStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Unable to Get Recievable Account Status", "0", ex.Message));
                return null;
            }
        }

    }
}
