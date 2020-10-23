using ArInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArInterfaces;

namespace ArServices
{
    public class ReceivableFactory
    {
        iAccountMgr accountMgr;
        iTransactionMgr transactionMgr;
        iPaymentMgr paymentMgr;

        public ReceivableFactory()
        {
            this.accountMgr = new AccountMgr();
            this.transactionMgr = new TransactionMgr();
            this.paymentMgr = new PaymentMgr();
        }

        public iAccountMgr AccountMgr
        {
            get { return this.accountMgr; }
        }

        public iTransactionMgr TransactionMgr
        {
            get { return this.transactionMgr; }
        }

        public iPaymentMgr PaymentMgr
        {
            get { return this.paymentMgr; }
        }
    }
}
