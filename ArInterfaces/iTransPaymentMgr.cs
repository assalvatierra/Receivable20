using ArModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArInterfaces
{
    public interface iTransPaymentMgr
    {
        bool AddTransPayment(ArTransPayment transPayment);
        bool EditTransPayment(ArTransPayment transPayment);
        bool RemoveTransPayment(ArTransPayment transPayment);
        ArTransPayment GetTransPaymentById(int id);
        List<ArTransPayment> GetTransPayments();
    }
}
