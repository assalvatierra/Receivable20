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
        List<ArTransaction> GetTransactions(string status, string sortBy, string orderBy);
        List<ArTransaction> GetActiveTransactions();
        List<ArTransaction> GetApprovedTransactions();
        List<ArTransaction> GetForApprovalTrans();
        List<ArTransaction> GetForSettlementTrans();
        IEnumerable<ArTransStatus> GetTransactionStatus();
        int GetTransAccountId(int id);

        bool UpdateTransAcc(int transactionId, int accountId);
        bool CloseTransactionStatus(int id);
        bool CheckRepeatingTrans();

        bool IsClosed(int id);
    }
}
