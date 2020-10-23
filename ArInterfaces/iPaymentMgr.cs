using ArModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArInterfaces
{
    public interface iPaymentMgr 
    {
        bool AddPayment(ArPayment payment);
        bool EditPayment(ArPayment payment);
        bool RemovePayment(int? id);
        ArPayment GetPaymentById(int? id);
        List<ArPayment> GetPayments();
        IEnumerable<ArPaymentType> GetPaymentTypes();
        bool DbDispose();
    } 

}
