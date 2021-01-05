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
        IEnumerable<ArAccStatus> GetArAccStatus();

        List<ArAccntCredit> AllAccntCreditLimit(int AccntId);
        ArAccntCredit GetLatestAccntCreditLimit(int AccntId);
        bool UpdateAccntCredit(ArAccntCredit credit);
        bool AddAccntCredit(ArAccntCredit credit);

        List<ArAccntTerm> AllAccntPaymentTerm(int AccntId);
        ArAccntTerm GetLatestAccntPaymentTerm(int AccntId);
        bool UpdateAccntPaymentTerm(ArAccntTerm term);
        bool AddAccntPaymentTerm(ArAccntTerm term);

        bool AddAccntCreditDefault(int AccntId);
    }
}
