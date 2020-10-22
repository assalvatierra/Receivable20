using ArModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArInterfaces
{
    public interface iTransactionMgr
    {
        bool AddTransaction(ArTransaction transaction);
        bool EditTransaction(ArTransaction transaction);
        bool RemoveTransaction(ArTransaction transaction);
        ArTransaction GetTransactionById(int id);
        List<ArTransaction> GetTransactions();
        IEnumerable<ArTransStatus> GetTransactionStatus();
    }
}
