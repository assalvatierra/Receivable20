using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArInterfaces;
using ArModels;
using ArModels.Models;
using ArDBLayer;

namespace ArServices
{
    public class AccountMgr : iAccountMgr
    {
        private AccountDb db;

        public AccountMgr()
        {
            db = new AccountDb();
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
    }
}
