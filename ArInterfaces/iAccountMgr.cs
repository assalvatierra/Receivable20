using ArModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArInterfaces
{
    public interface iAccountMgr
    {
        bool AddAccount(ArAccount account);
        bool EditAccount(ArAccount account);
        bool RemoveAccount(ArAccount account);
        ArAccount GetAccountById(int id);
        List<ArAccount> GetArAccounts();
    }
}
