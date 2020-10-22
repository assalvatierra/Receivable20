using ArModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArInterfaces
{
    public interface iTransactionDb
    {
        bool DbDispose();

        bool AddTransaction(ArTransaction transaction);
        bool EditTransaction(ArTransaction transaction);
        bool DeleteTransaction(ArTransaction transaction);
        ArTransaction GetTransactionById(int id);
        IQueryable<ArTransaction> GetTransactions();
        IQueryable<ArTransStatus> GetTransactionStatus();
    }
}
