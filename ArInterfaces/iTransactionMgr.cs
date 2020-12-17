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
        List<ArTransaction> GetTransactions(string status);
        List<ArTransaction> GetActiveTransactions();
        List<ArTransaction> GetApprovedTransactions();
        List<ArTransaction> GetForApprovalTrans();
        List<ArTransaction> GetForSettlementTrans();


        IEnumerable<ArTransStatus> GetTransactionStatus();
        bool UpdateTransAcc(int transactionId, int accountId);
        bool CloseTransactionStatus(int id);
        int GetTransAccountId(int id);

        bool IsClosed(int id);
    }
}
