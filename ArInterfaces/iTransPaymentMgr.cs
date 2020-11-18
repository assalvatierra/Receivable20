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
        bool AddTransPayment(int transId, int paymentId);
        bool EditTransPayment(ArTransPayment transPayment);
        bool RemoveTransPayment(ArTransPayment transPayment);
        ArTransPayment GetTransPaymentById(int id);
        List<ArTransPayment> GetTransPayments();
        List<ArTransPayment> GetTransPaymentsByTransId(int transId);
        ArTransPayment GetTransPaymentsByPaymentId(int paymentId);
        Decimal GetTotalTransPayment(int transId);
    } 
}
