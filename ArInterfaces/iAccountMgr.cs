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
        //Account 
        bool AddAccount(ArAccount account);
        bool EditAccount(ArAccount account);
        bool RemoveAccount(ArAccount account);
        ArAccount GetAccountById(int id);
        List<ArAccount> GetArAccounts();
        IEnumerable<ArAccStatus> GetArAccStatus();

        //Account Credit Limit
        List<ArAccntCredit> AllAccntCreditLimit(int AccntId);
        ArAccntCredit GetLatestAccntCreditLimit(int AccntId);
        bool UpdateAccntCredit(ArAccntCredit credit);
        bool AddAccntCredit(ArAccntCredit credit);

        //Account Payment Terms
        List<ArAccntTerm> AllAccntPaymentTerm(int AccntId);
        ArAccntTerm GetLatestAccntPaymentTerm(int AccntId);
        bool UpdateAccntPaymentTerm(ArAccntTerm term);
        bool AddAccntPaymentTerm(ArAccntTerm term);

        bool AddAccntCreditDefault(int AccntId);

        //Account Contacts
        bool AddAccContact(ArAccContact contact);
        bool EditAccContact(ArAccContact contact);
        bool RemoveAccContact(ArAccContact contact);
        ArAccContact GetAccContactById(int id);
        List<ArAccContact> GetAccContactsByAccId(int accountId);
        List<ArAccContact> GetAccContacts();
    }
}
