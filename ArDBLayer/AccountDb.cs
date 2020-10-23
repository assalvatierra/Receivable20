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
            catch
            {
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
            catch
            {
               
                return false;
            }
        }

        public IQueryable<ArAccount> GetAccounts()
        {
            try
            {
                return db.ArAccounts;
            }
            catch
            {
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
            } catch
            {
                return false;
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
                return null;
            }
        }

        public IQueryable<ArAccStatus> GetAccStatus()
        {
            try
            {
                return db.ArAccStatus;
            }
            catch
            {
                return null;
            }
        }

    }
}
