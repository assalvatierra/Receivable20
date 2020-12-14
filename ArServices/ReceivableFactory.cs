using ArInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArModels.Models;

namespace ArServices
{
    public class ReceivableFactory
    {
        private ArDBContainer arDB;
        iAccountMgr accountMgr;
        iTransactionMgr transactionMgr;
        iPaymentMgr paymentMgr;
        iActionMgr actionMgr;
        iCategoryMgr categoryMgr;
        iTransPaymentMgr transPaymentMgr;
        iTransPostMgr transPostMgr;

        //service
        iDateClassMgr dateClassMgr;
        iEmailMgr emailMgr;


        public ReceivableFactory()
        {
            this.arDB = new ArDBContainer();
            this.accountMgr = new AccountMgr(arDB);
            this.transactionMgr = new TransactionMgr(arDB);
            this.paymentMgr = new PaymentMgr(arDB);
            this.actionMgr = new ActionMgr(arDB);
            this.categoryMgr = new CategoryMgr(arDB);
            this.transPaymentMgr = new TransPaymentMgr(arDB);
            this.transPostMgr = new TransPostMgr(arDB);

            this.dateClassMgr = new DateClassMgr();
            this.emailMgr = new EmailMgr();
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
        public iActionMgr ActionMgr
        {
            get { return this.actionMgr; }
        }
        public iCategoryMgr CategoryMgr
        {
            get { return this.categoryMgr; }
        }
        public iTransPaymentMgr TransPaymentMgr
        {
            get { return this.transPaymentMgr; }
        }
        public iTransPostMgr TransPostMgr
        {
            get { return this.transPostMgr; }
        }

        public iDateClassMgr DateClassMgr
        {
            get { return this.dateClassMgr; }
        }
        public iEmailMgr EmailMgr
        {
            get { return this.emailMgr; }
        }
    }
}
