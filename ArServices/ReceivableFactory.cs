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

        public ReceivableFactory()
        {
            this.accountMgr = new AccountMgr();
        }

        public iAccountMgr AccountMgr
        {
            get { return this.accountMgr; }
        }
    }
}
