using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArModels.Models;


namespace ArInterfaces
{
    public interface iAccountDb
    {
        bool DbDispose();

        IQueryable<ArAccount> GetAccounts();
        bool AddAccount(ArAccount account);
        bool EditAccount(ArAccount account);
        bool RemoveAccount(ArAccount account);
        ArAccount GetAccountById(int id);
        IQueryable<ArAccStatus> GetAccStatus();
    }
}
